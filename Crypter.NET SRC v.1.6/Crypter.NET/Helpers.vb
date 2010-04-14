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
Imports System.Text
Imports System.Runtime.InteropServices

Module Helpers
 
    <DllImport("user32.dll", SetLastError:=True)> _
    Private Function SetWindowPos( _
            ByVal hWnd As IntPtr, _
            ByVal hWndInsertAfter As IntPtr, _
            ByVal X As Integer, _
            ByVal Y As Integer, _
            ByVal cx As Integer, _
            ByVal cy As Integer, _
            ByVal uFlags As UInteger) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Function SetWindowLong( _
            ByVal hWnd As IntPtr, _
            ByVal nIndex As Integer, _
            ByVal dwNewLong As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Function GetWindowLong( _
            ByVal hWnd As IntPtr, _
            ByVal nIndex As Integer) As Integer
    End Function

    'Consts
    Private Const GWL_EXSTYLE As Short = (-20)
    Private Const WS_EX_CLIENTEDGE As Short = &H200S
    Private Const WS_EX_STATICEDGE As Integer = &H20000
    Private Const SWP_FRAMECHANGED As Short = &H20S
    Private Const SWP_NOACTIVATE As Short = &H10S
    Private Const SWP_NOMOVE As Short = &H2S
    Private Const SWP_NOSIZE As Short = &H1S
    Private Const SWP_NOZORDER As Short = &H4S
    Private Const SWP_DRAWFRAME As Short = SWP_FRAMECHANGED
    Private Const SWP_FLAGS As Boolean = SWP_NOZORDER Or SWP_NOSIZE Or SWP_NOMOVE Or SWP_DRAWFRAME

    'Função para aplicar um efeito "Flat Border" por API
    Public Sub FlatBorder(ByVal c As Control)
        Dim intFlat As Integer
        intFlat = GetWindowLong(c.Handle.ToInt32, GWL_EXSTYLE)
        intFlat = intFlat And Not WS_EX_CLIENTEDGE Or WS_EX_STATICEDGE
        SetWindowLong(c.Handle.ToInt32, GWL_EXSTYLE, intFlat)
        SetWindowPos(c.Handle.ToInt32, 0, 0, 0, 0, 0, SWP_NOACTIVATE Or SWP_NOZORDER Or SWP_FRAMECHANGED Or SWP_NOSIZE Or SWP_NOMOVE)
    End Sub

    ''' <summary>
    ''' Remove bad chars from supplied file name to make it a safe file name
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' You should supply a file name, directory or full path is not supported.
    ''' </remarks>
    Public Function SafeFileName(ByVal fileName As String) As String
        fileName = fileName.Replace(".", String.Empty)
        Return RemoveChars(fileName, IO.Path.GetInvalidFileNameChars)
    End Function

    ''' <summary>
    ''' Remove bad chars from supplied file name to make it a safe file name
    ''' </summary>
    ''' <param name="folderName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' You should supply a file name, directory or full path is not supported.
    ''' </remarks>
    Public Function SafeFolderName(ByVal folderName As String) As String
        folderName = folderName.Replace(".", String.Empty)
        Return RemoveChars(folderName, IO.Path.GetInvalidPathChars)
    End Function

    ''' <summary>
    ''' Remove supplied Character List from string
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="charList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RemoveChars(ByVal name As String, ByVal charList As Char()) As String
        For Each Character As Char In charList
            name = name.Replace(Character, String.Empty)
        Next
        Return name
    End Function

    Public Function BytesToHex(ByVal bytes() As Byte) As String
        Dim hex As New StringBuilder
        For n As Integer = 0 To bytes.Length - 1
            hex.AppendFormat("{0:X2}", bytes(n))
        Next
        Return hex.ToString
    End Function

    '********************************************************
    '* HexToBytes: Converts a hex-encoded string to a
    '*             byte array
    '********************************************************
    Public Function HexToBytes(ByVal Hex As String) As Byte()
        Dim numBytes As Integer = Hex.Length / 2
        Dim bytes(numBytes - 1) As Byte
        For n As Integer = 0 To numBytes - 1
            Dim hexByte As String = Hex.Substring(n * 2, 2)
            bytes(n) = Integer.Parse(hexByte, Globalization.NumberStyles.HexNumber)
        Next
        Return bytes
    End Function

    Public Function StringToHex(ByVal sText As String) As String
        Dim keyValue As Char() = sText.ToCharArray()
        ' convert character array to byte array
        Dim keyByte As Byte() = Encoding.ASCII.GetBytes(keyValue)
        ' Format the byte into hexadecimal
        Dim str As String = ""
        For i As Integer = 0 To keyByte.Length - 1
            str += String.Format("{0:x2}", keyByte(i))
        Next
        Return "0x" + str
    End Function

    Public Function HexToString(ByVal sText As String) As String
        Dim tmpValue1 As String = sText
        Dim tmpValue2 As String = ""
        Dim str As String = ""
        If tmpValue1.StartsWith("0x") Then
            tmpValue1 = tmpValue1.Substring(2)
        End If
        Dim i As Integer = 0
        While i < tmpValue1.Length
            str = tmpValue1.Substring(i, 2)
            tmpValue2 += CChar(ChrW(UShort.Parse(str, System.Globalization.NumberStyles.HexNumber)))
            i = i + 2
        End While
        Return tmpValue2
    End Function

    Public Function FormatBytes(ByVal dblBytes As Double) As String
        Const KILOBYTE As Double = 1024
        Const MEGABYTE As Double = KILOBYTE ^ 2
        Const GIGABYTE As Double = KILOBYTE ^ 3
        Const TERABYTE As Double = KILOBYTE ^ 4
        Const PETABYTE As Double = KILOBYTE ^ 5
        Select Case dblBytes
            Case Is >= PETABYTE
                Return System.Math.Round(dblBytes / PETABYTE, 2) & " PiB"
            Case Is >= TERABYTE
                Return System.Math.Round(dblBytes / TERABYTE, 2) & " TiB"
            Case Is >= GIGABYTE
                Return System.Math.Round(dblBytes / GIGABYTE, 2) & " GiB"
            Case Is >= MEGABYTE
                Return System.Math.Round(dblBytes / MEGABYTE, 2) & " MiB"
            Case Is >= KILOBYTE
                Return System.Math.Round(dblBytes / KILOBYTE, 2) & " KiB"
            Case Else
                Return dblBytes & " Bytes"
        End Select
    End Function

End Module
