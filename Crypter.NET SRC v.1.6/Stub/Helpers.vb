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
Module Helpers

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
 
    Public Function FixPathVars(ByVal sData As String) As String
        Select Case True
            Case sData.Contains("%[Program Files]")
                Return sData.Replace("%[Program Files]", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
            Case sData.Contains("%[Common Program Files]")
                Return sData.Replace("%[Common Program Files]", Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles))
            Case sData.Contains("%[Windows Desktop]")
                Return sData.Replace("", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory))
            Case sData.Contains("%[Favorites]")
                Return sData.Replace("%[Favorites]", Environment.GetFolderPath(Environment.SpecialFolder.Favorites))
            Case sData.Contains("%[History]")
                Return sData.Replace("%[History]", Environment.GetFolderPath(Environment.SpecialFolder.History))
            Case sData.Contains("%[Personal (My Documents)]")
                Return sData.Replace("%[Personal (My Documents)]", Environment.GetFolderPath(Environment.SpecialFolder.Personal))
            Case sData.Contains("%[Start Menu's Program]")
                Return sData.Replace("%[Start Menu's Program]", Environment.GetFolderPath(Environment.SpecialFolder.Programs))
            Case sData.Contains("%[Recent]")
                Return sData.Replace("%[Recent]", Environment.GetFolderPath(Environment.SpecialFolder.Recent))
            Case sData.Contains("%[Send To]")
                Return sData.Replace("%[Send To]", Environment.GetFolderPath(Environment.SpecialFolder.SendTo))
            Case sData.Contains("%[Start Menu]")
                Return sData.Replace("%[Start Menu]", Environment.GetFolderPath(Environment.SpecialFolder.StartMenu))
            Case sData.Contains("%[Startup]")
                Return sData.Replace("%[Startup]", Environment.GetFolderPath(Environment.SpecialFolder.Startup))
            Case sData.Contains("%[Windows System]")
                Return sData.Replace("%[Windows System]", Environment.GetFolderPath(Environment.SpecialFolder.System))
            Case sData.Contains("%[Windows]")
                Return sData.Replace("%[Windows]", Environment.GetEnvironmentVariable("SystemRoot"))
            Case sData.Contains("%[Application Data]")
                Return sData.Replace("%[Application Data]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
            Case sData.Contains("%[Common Application]")
                Return sData.Replace("%[Common Application]", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData))
            Case sData.Contains("%[Local Application Data]")
                Return sData.Replace("%[Local Application Data]", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData))
            Case sData.Contains("%[Cookies]")
                Return sData.Replace("%[Cookies]", Environment.GetFolderPath(Environment.SpecialFolder.Cookies))
            Case sData.Contains("%[.Net Directory]")
                Return sData.Replace("%[.Net Directory]", Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory)
            Case sData.Contains("%[none]")
                Return sData.Replace("%[none]", Application.ExecutablePath)
            Case Else
                Return sData
        End Select
    End Function

End Module
