'Original code By Tsuda Kageyu
' http://www.codeproject.com/KB/cs/IconExtractor.aspx
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Collections
Public Class IconExtractor
    Implements IDisposable
#Region "Win32 interop"

#Region "Unmanaged Types"

    <UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet:=CharSet.Auto)> _
    Private Delegate Function EnumResNameProc(ByVal hModule As IntPtr, ByVal lpszType As Integer, ByVal lpszName As IntPtr, ByVal lParam As IconResInfo) As Boolean

#End Region

#Region "Consts"

    Private Const LOAD_LIBRARY_AS_DATAFILE As Integer = &H2

    Private Const RT_ICON As Integer = 3
    Private Const RT_GROUP_ICON As Integer = 14

    Private Const MAX_PATH As Integer = 260

    Private Const ERROR_SUCCESS As Integer = 0
    Private Const ERROR_FILE_NOT_FOUND As Integer = 2
    Private Const ERROR_BAD_EXE_FORMAT As Integer = 193
    Private Const ERROR_RESOURCE_TYPE_NOT_FOUND As Integer = 1813

    Private Const sICONDIR As Integer = 6
    ' sizeof(ICONDIR) 
    Private Const sICONDIRENTRY As Integer = 16
    ' sizeof(ICONDIRENTRY)
    Private Const sGRPICONDIRENTRY As Integer = 14
    ' sizeof(GRPICONDIRENTRY)
#End Region

#Region "API Functions"

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function LoadLibrary(ByVal lpFileName As String) As IntPtr
    End Function

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function LoadLibraryEx(ByVal lpFileName As String, ByVal hFile As IntPtr, ByVal dwFlags As Integer) As IntPtr
    End Function

    Private Declare Auto Function FreeLibrary Lib "kernel32.dll" (ByVal hModule As IntPtr) As Boolean

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function GetModuleFileName(ByVal hModule As IntPtr, ByVal lpFilename As StringBuilder, ByVal nSize As Integer) As Integer
    End Function

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function EnumResourceNames(ByVal hModule As IntPtr, ByVal lpszType As Integer, ByVal lpEnumFunc As EnumResNameProc, ByVal lParam As IconResInfo) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function FindResource(ByVal hModule As IntPtr, ByVal lpName As IntPtr, ByVal lpType As Integer) As IntPtr
    End Function

    Private Declare Auto Function LoadResource Lib "kernel32.dll" (ByVal hModule As IntPtr, ByVal hResInfo As IntPtr) As IntPtr
    Private Declare Auto Function LockResource Lib "kernel32.dll" (ByVal hResData As IntPtr) As IntPtr
    Private Declare Auto Function SizeofResource Lib "kernel32.dll" (ByVal hModule As IntPtr, ByVal hResInfo As IntPtr) As Integer

#End Region
#End Region

#Region "Managed Types"

    Private Class IconResInfo
        Public IconNames As New List(Of ResourceName)()
    End Class

    Private Class ResourceName
        Private _Id As IntPtr
        Public Property Id() As IntPtr
            Get
                Return _Id
            End Get
            Private Set(ByVal value As IntPtr)
                _Id = value
            End Set
        End Property
        Private _Name As String
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Private Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Private _bufPtr As IntPtr = IntPtr.Zero

        Public Sub New(ByVal lpName As IntPtr)
            If (CUInt(lpName) >> 16) = 0 Then
                ' #define IS_INTRESOURCE(_r) ((((ULONG_PTR)(_r)) >> 16) == 0)
                Me.Id = lpName
                Me.Name = Nothing
            Else
                Me.Id = IntPtr.Zero
                Me.Name = Marshal.PtrToStringAuto(lpName)
            End If
        End Sub

        Public Function GetValue() As IntPtr
            If Me.Name Is Nothing Then
                Return Me.Id
            Else
                Me._bufPtr = Marshal.StringToHGlobalAuto(Me.Name)
                Return Me._bufPtr
            End If
        End Function

        Public Sub Free()
            If Me._bufPtr <> IntPtr.Zero Then
                Try
                    Marshal.FreeHGlobal(Me._bufPtr)
                Catch
                End Try

                Me._bufPtr = IntPtr.Zero
            End If
        End Sub
    End Class

#End Region

#Region "Private Fields"

    Private _hModule As IntPtr = IntPtr.Zero
    Private _resInfo As IconResInfo = Nothing

    Private _iconCache As Icon() = Nothing

#End Region

#Region "Public Properties"

    Private _filename As String = Nothing

    ' Full path 
    Public ReadOnly Property Filename() As String
        Get
            Return Me._filename
        End Get
    End Property

    Public ReadOnly Property IconCount() As Integer
        Get
            Return Me._resInfo.IconNames.Count
        End Get
    End Property

#End Region

#Region "Contructor/Destructor and relatives"

    ''' <summary>
    ''' Load the specified executable file or DLL, and get ready to extract the icons.
    ''' </summary>
    ''' <param name="filename">The name of a file from which icons will be extracted.</param>
    Public Sub New(ByVal filename As String)
        If filename Is Nothing Then
            Throw New ArgumentNullException("filename")
        End If

        Me._hModule = LoadLibrary(filename)
        If Me._hModule = IntPtr.Zero Then
            Me._hModule = LoadLibraryEx(filename, IntPtr.Zero, LOAD_LIBRARY_AS_DATAFILE)
            If Me._hModule = IntPtr.Zero Then
                Select Case Marshal.GetLastWin32Error()
                    Case ERROR_FILE_NOT_FOUND
                        Throw New FileNotFoundException("Specified file '" & filename & "' not found.")

                    Case ERROR_BAD_EXE_FORMAT
                        Throw New ArgumentException("Specified file '" & filename & "' is not an executable file or DLL.")
                    Case Else

                        Throw New Win32Exception()
                End Select
            End If
        End If

        Dim buf As New StringBuilder(MAX_PATH)
        Dim len As Integer = GetModuleFileName(Me._hModule, buf, buf.Capacity + 1)
        If len <> 0 Then
            Me._filename = buf.ToString()
        Else
            Select Case Marshal.GetLastWin32Error()
                Case ERROR_SUCCESS
                    Me._filename = filename
                    Exit Select
                Case Else

                    Throw New Win32Exception()
            End Select
        End If

        Me._resInfo = New IconResInfo()
        Dim success As Boolean = EnumResourceNames(Me._hModule, RT_GROUP_ICON, AddressOf EnumResNameCallBack, Me._resInfo)
        If Not success Then
            'Throw New Win32Exception()
        End If

        Me._iconCache = New Icon(Me.IconCount - 1) {}
    End Sub

    Protected Overrides Sub Finalize()
        Try
            Dispose()
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If Me._hModule <> IntPtr.Zero Then
            Try
                FreeLibrary(Me._hModule)
            Catch
            End Try

            Me._hModule = IntPtr.Zero
        End If

        If Me._iconCache IsNot Nothing Then
            For Each i As Icon In Me._iconCache
                If i IsNot Nothing Then
                    Try
                        i.Dispose()
                    Catch
                    End Try
                End If
            Next

            Me._iconCache = Nothing
        End If
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Extract an icon from the loaded executable file or DLL. 
    ''' </summary>
    ''' <param name="iconIndex">The zero-based index of the icon to be extracted.</param>
    ''' <returns>A System.Drawing.Icon object which may consists of multiple icons.</returns>
    ''' <remarks>Always returns new copy of the Icon. It should be disposed by the user.</remarks>
    Public Function GetIcon(ByVal iconIndex As Integer) As Icon
        If Me._hModule = IntPtr.Zero Then
            Throw New ObjectDisposedException("IconExtractor")
        End If

        If iconIndex < 0 OrElse Me.IconCount <= iconIndex Then
            Throw New ArgumentException("iconIndex is out of range. It should be between 0 and " & (Me.IconCount - 1).ToString() & ".")
        End If

        If Me._iconCache(iconIndex) Is Nothing Then
            Me._iconCache(iconIndex) = CreateIcon(iconIndex)
        End If

        Return DirectCast(Me._iconCache(iconIndex).Clone(), Icon)
    End Function

    ''' <summary>
    ''' Split an Icon consists of multiple icons into an array of Icon each consist of single icons.
    ''' </summary>
    ''' <param name="icon">The System.Drawing.Icon to be split.</param>
    ''' <returns>An array of System.Drawing.Icon each consist of single icons.</returns>
    Public Shared Function SplitIcon(ByVal icon As Icon) As Icon()
        If icon Is Nothing Then
            Throw New ArgumentNullException("icon")
        End If

        ' Get multiple .ico file image.
        Dim srcBuf As Byte() = Nothing
        Using stream As New MemoryStream()
            icon.Save(stream)
            srcBuf = stream.ToArray()
        End Using

        Dim splitIcons As New List(Of Icon)()
        If True Then
            Dim count As Integer = BitConverter.ToInt16(srcBuf, 4)
            ' ICONDIR.idCount
            For i As Integer = 0 To count - 1
                Using destStream As New MemoryStream()
                    Using writer As New BinaryWriter(destStream)
                        ' Copy ICONDIR and ICONDIRENTRY.
                        writer.Write(srcBuf, 0, sICONDIR - 2)
                        writer.Write(CShort(1))
                        ' ICONDIR.idCount == 1;
                        writer.Write(srcBuf, sICONDIR + sICONDIRENTRY * i, sICONDIRENTRY - 4)
                        writer.Write(sICONDIR + sICONDIRENTRY)
                        ' ICONDIRENTRY.dwImageOffset = sizeof(ICONDIR) + sizeof(ICONDIRENTRY)
                        ' Copy picture and mask data.
                        Dim imgSize As Integer = BitConverter.ToInt32(srcBuf, sICONDIR + sICONDIRENTRY * i + 8)
                        ' ICONDIRENTRY.dwBytesInRes
                        Dim imgOffset As Integer = BitConverter.ToInt32(srcBuf, sICONDIR + sICONDIRENTRY * i + 12)
                        ' ICONDIRENTRY.dwImageOffset
                        writer.Write(srcBuf, imgOffset, imgSize)

                        ' Create new icon.
                        destStream.Seek(0, SeekOrigin.Begin)
                        splitIcons.Add(New Icon(destStream))
                    End Using
                End Using
            Next
        End If

        Return splitIcons.ToArray()
    End Function

    Public Overloads Overrides Function ToString() As String
        Dim text As String = [String].Format("IconExtractor (Filename: '{0}', IconCount: {1})", Me.Filename, Me.IconCount)
        Return text
    End Function

#End Region

#Region "Private Methods"

    Private Function EnumResNameCallBack(ByVal hModule As IntPtr, ByVal lpszType As Integer, ByVal lpszName As IntPtr, ByVal lParam As IconResInfo) As Boolean
        ' Callback function for EnumResourceNames().

        If lpszType = RT_GROUP_ICON Then
            lParam.IconNames.Add(New ResourceName(lpszName))
        End If

        Return True
    End Function

    Private Function CreateIcon(ByVal iconIndex As Integer) As Icon
        ' Get group icon resource.
        Dim srcBuf As Byte() = GetResourceData(Me._hModule, Me._resInfo.IconNames(iconIndex), RT_GROUP_ICON)

        ' Convert the resouce into an .ico file image.
        Using destStream As New MemoryStream()
            Using writer As New BinaryWriter(destStream)
                Dim count As Integer = BitConverter.ToUInt16(srcBuf, 4)
                ' ICONDIR.idCount
                Dim imgOffset As Integer = sICONDIR + sICONDIRENTRY * count

                ' Copy ICONDIR.
                writer.Write(srcBuf, 0, sICONDIR)

                For i As Integer = 0 To count - 1
                    ' Copy GRPICONDIRENTRY converting into ICONDIRENTRY.
                    writer.BaseStream.Seek(sICONDIR + sICONDIRENTRY * i, SeekOrigin.Begin)
                    writer.Write(srcBuf, sICONDIR + sGRPICONDIRENTRY * i, sICONDIRENTRY - 4)
                    ' Common fields of structures
                    writer.Write(imgOffset)
                    ' ICONDIRENTRY.dwImageOffset
                    ' Get picture and mask data, then copy them.
                    Dim nID As IntPtr = CType(BitConverter.ToUInt16(srcBuf, sICONDIR + sGRPICONDIRENTRY * i + 12), IntPtr)
                    ' GRPICONDIRENTRY.nID
                    Dim imgBuf As Byte() = GetResourceData(Me._hModule, nID, RT_ICON)

                    writer.BaseStream.Seek(imgOffset, SeekOrigin.Begin)
                    writer.Write(imgBuf, 0, imgBuf.Length)

                    imgOffset += imgBuf.Length
                Next

                destStream.Seek(0, SeekOrigin.Begin)
                Return New Icon(destStream)
            End Using
        End Using
    End Function

    Private Function GetResourceData(ByVal hModule As IntPtr, ByVal lpName As IntPtr, ByVal lpType As Integer) As Byte()
        ' Get binary image of the specified resource.

        Dim hResInfo As IntPtr = FindResource(hModule, lpName, lpType)
        If hResInfo = IntPtr.Zero Then
            Throw New Win32Exception()
        End If

        Dim hResData As IntPtr = LoadResource(hModule, hResInfo)
        If hResData = IntPtr.Zero Then
            Throw New Win32Exception()
        End If

        Dim hGlobal As IntPtr = LockResource(hResData)
        If hGlobal = IntPtr.Zero Then
            Throw New Win32Exception()
        End If

        Dim resSize As Integer = SizeofResource(hModule, hResInfo)
        If resSize = 0 Then
            Throw New Win32Exception()
        End If

        Dim buf As Byte() = New Byte(resSize - 1) {}
        Marshal.Copy(hGlobal, buf, 0, buf.Length)

        Return buf
    End Function

    Private Function GetResourceData(ByVal hModule As IntPtr, ByVal name As ResourceName, ByVal lpType As Integer) As Byte()
        Try
            Dim lpName As IntPtr = name.GetValue()
            Return GetResourceData(hModule, lpName, lpType)
        Finally
            name.Free()
        End Try
    End Function

#End Region
End Class
