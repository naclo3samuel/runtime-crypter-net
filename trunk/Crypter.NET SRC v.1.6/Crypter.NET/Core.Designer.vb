<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Core
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Core))
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.numSuiecidedWait = New System.Windows.Forms.NumericUpDown
        Me.chkGZip = New System.Windows.Forms.CheckBox
        Me.chkSuiecideStub = New System.Windows.Forms.CheckBox
        Me.chkAntiSandboxie = New System.Windows.Forms.CheckBox
        Me.chkInstallAutoRun = New System.Windows.Forms.CheckBox
        Me.txtInstallFileName = New System.Windows.Forms.TextBox
        Me.chkInstall = New System.Windows.Forms.CheckBox
        Me.cmbInstallDir = New System.Windows.Forms.ComboBox
        Me.chkInstallHidden = New System.Windows.Forms.CheckBox
        Me.grbInstall = New System.Windows.Forms.GroupBox
        Me.cmbShutdown = New System.Windows.Forms.ComboBox
        Me.chkShutdown = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkUseSameProcess = New System.Windows.Forms.CheckBox
        Me.chkFakeMessageBox = New System.Windows.Forms.CheckBox
        Me.grbFakeMessageBox = New System.Windows.Forms.GroupBox
        Me.cmbFakeMsgButtons = New System.Windows.Forms.ComboBox
        Me.btnFakeMsg = New System.Windows.Forms.Button
        Me.cmbFakeMsgIcon = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFakeMsgTitle = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFakeMsg = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbAlgorithm = New System.Windows.Forms.ComboBox
        Me.btnRandomKey = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtEncryptionKey = New System.Windows.Forms.TextBox
        Me.grbInjectProcess = New System.Windows.Forms.GroupBox
        Me.txtProcessInject = New System.Windows.Forms.TextBox
        Me.cmbProcessInject = New System.Windows.Forms.ComboBox
        Me.lstMenu = New System.Windows.Forms.ListBox
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.pnlAssembly = New System.Windows.Forms.Panel
        Me.chkAssemblyInfoUseDefaut = New System.Windows.Forms.CheckBox
        Me.chkIconUseDefaut = New System.Windows.Forms.CheckBox
        Me.grbIcon = New System.Windows.Forms.GroupBox
        Me.btnSystemIcon = New System.Windows.Forms.Button
        Me.picIcon = New System.Windows.Forms.PictureBox
        Me.grbAssemblyInfo = New System.Windows.Forms.GroupBox
        Me.pnlAssemblyInfo = New System.Windows.Forms.Panel
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtAssemblyVersion = New System.Windows.Forms.MaskedTextBox
        Me.txtLegalTrademarks = New System.Windows.Forms.TextBox
        Me.txtOriginalFilename = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.txtFileDescription = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtInternalName = New System.Windows.Forms.TextBox
        Me.txtCompanyName = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtProductName = New System.Windows.Forms.TextBox
        Me.txtLegalCopyright = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtProductVersion = New System.Windows.Forms.MaskedTextBox
        Me.txtFileVersion = New System.Windows.Forms.MaskedTextBox
        Me.pnlStubs = New System.Windows.Forms.Panel
        Me.btnRefreshStubs = New System.Windows.Forms.Button
        Me.lvwStubs = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.pnlAbout = New System.Windows.Forms.Panel
        Me.picAbout = New Crypter.NET.WaterFX
        Me.pnlFake = New System.Windows.Forms.Panel
        Me.pnlInstall = New System.Windows.Forms.Panel
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnOpen = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.btnBuild = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox6.SuspendLayout()
        CType(Me.numSuiecidedWait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbInstall.SuspendLayout()
        Me.grbFakeMessageBox.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.grbInjectProcess.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlAssembly.SuspendLayout()
        Me.grbIcon.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbAssemblyInfo.SuspendLayout()
        Me.pnlAssemblyInfo.SuspendLayout()
        Me.pnlStubs.SuspendLayout()
        Me.pnlAbout.SuspendLayout()
        Me.pnlFake.SuspendLayout()
        Me.pnlInstall.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.numSuiecidedWait)
        Me.GroupBox6.Controls.Add(Me.chkGZip)
        Me.GroupBox6.Controls.Add(Me.chkSuiecideStub)
        Me.GroupBox6.Controls.Add(Me.chkAntiSandboxie)
        Me.GroupBox6.Location = New System.Drawing.Point(7, 135)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(348, 73)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Misc"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(180, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 21)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Secunds to wait:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numSuiecidedWait
        '
        Me.numSuiecidedWait.Enabled = False
        Me.numSuiecidedWait.Location = New System.Drawing.Point(302, 46)
        Me.numSuiecidedWait.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.numSuiecidedWait.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numSuiecidedWait.Name = "numSuiecidedWait"
        Me.numSuiecidedWait.Size = New System.Drawing.Size(37, 21)
        Me.numSuiecidedWait.TabIndex = 4
        Me.numSuiecidedWait.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'chkGZip
        '
        Me.chkGZip.AutoSize = True
        Me.chkGZip.Checked = True
        Me.chkGZip.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGZip.Location = New System.Drawing.Point(7, 15)
        Me.chkGZip.Name = "chkGZip"
        Me.chkGZip.Size = New System.Drawing.Size(144, 17)
        Me.chkGZip.TabIndex = 3
        Me.chkGZip.Text = "Enable GZip compression"
        Me.chkGZip.UseVisualStyleBackColor = True
        '
        'chkSuiecideStub
        '
        Me.chkSuiecideStub.AutoSize = True
        Me.chkSuiecideStub.Location = New System.Drawing.Point(7, 49)
        Me.chkSuiecideStub.Name = "chkSuiecideStub"
        Me.chkSuiecideStub.Size = New System.Drawing.Size(155, 17)
        Me.chkSuiecideStub.TabIndex = 2
        Me.chkSuiecideStub.Text = "Suiecide Stub after startup"
        Me.chkSuiecideStub.UseVisualStyleBackColor = True
        '
        'chkAntiSandboxie
        '
        Me.chkAntiSandboxie.AutoSize = True
        Me.chkAntiSandboxie.Location = New System.Drawing.Point(7, 32)
        Me.chkAntiSandboxie.Name = "chkAntiSandboxie"
        Me.chkAntiSandboxie.Size = New System.Drawing.Size(96, 17)
        Me.chkAntiSandboxie.TabIndex = 0
        Me.chkAntiSandboxie.Text = "Anti VirtualBox"
        Me.chkAntiSandboxie.UseVisualStyleBackColor = True
        '
        'chkInstallAutoRun
        '
        Me.chkInstallAutoRun.AutoSize = True
        Me.chkInstallAutoRun.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkInstallAutoRun.Location = New System.Drawing.Point(251, 91)
        Me.chkInstallAutoRun.Name = "chkInstallAutoRun"
        Me.chkInstallAutoRun.Size = New System.Drawing.Size(90, 17)
        Me.chkInstallAutoRun.TabIndex = 4
        Me.chkInstallAutoRun.Text = "Add auto-run"
        Me.chkInstallAutoRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkInstallAutoRun.UseVisualStyleBackColor = True
        '
        'txtInstallFileName
        '
        Me.txtInstallFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInstallFileName.BackColor = System.Drawing.SystemColors.Window
        Me.txtInstallFileName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtInstallFileName.Location = New System.Drawing.Point(107, 47)
        Me.txtInstallFileName.MaxLength = 100
        Me.txtInstallFileName.Name = "txtInstallFileName"
        Me.txtInstallFileName.Size = New System.Drawing.Size(233, 21)
        Me.txtInstallFileName.TabIndex = 3
        '
        'chkInstall
        '
        Me.chkInstall.AutoSize = True
        Me.chkInstall.Location = New System.Drawing.Point(13, 2)
        Me.chkInstall.Name = "chkInstall"
        Me.chkInstall.Size = New System.Drawing.Size(55, 17)
        Me.chkInstall.TabIndex = 4
        Me.chkInstall.Text = "Install"
        Me.chkInstall.UseVisualStyleBackColor = True
        '
        'cmbInstallDir
        '
        Me.cmbInstallDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbInstallDir.BackColor = System.Drawing.SystemColors.Window
        Me.cmbInstallDir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbInstallDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbInstallDir.FormattingEnabled = True
        Me.cmbInstallDir.Location = New System.Drawing.Point(107, 20)
        Me.cmbInstallDir.MaxDropDownItems = 20
        Me.cmbInstallDir.Name = "cmbInstallDir"
        Me.cmbInstallDir.Size = New System.Drawing.Size(233, 21)
        Me.cmbInstallDir.TabIndex = 1
        '
        'chkInstallHidden
        '
        Me.chkInstallHidden.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkInstallHidden.AutoSize = True
        Me.chkInstallHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkInstallHidden.Location = New System.Drawing.Point(196, 74)
        Me.chkInstallHidden.Name = "chkInstallHidden"
        Me.chkInstallHidden.Size = New System.Drawing.Size(145, 17)
        Me.chkInstallHidden.TabIndex = 5
        Me.chkInstallHidden.Text = "Protect and hide the EXE"
        Me.chkInstallHidden.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkInstallHidden.UseVisualStyleBackColor = True
        '
        'grbInstall
        '
        Me.grbInstall.Controls.Add(Me.cmbShutdown)
        Me.grbInstall.Controls.Add(Me.chkShutdown)
        Me.grbInstall.Controls.Add(Me.chkInstallHidden)
        Me.grbInstall.Controls.Add(Me.Label3)
        Me.grbInstall.Controls.Add(Me.Label2)
        Me.grbInstall.Controls.Add(Me.chkInstallAutoRun)
        Me.grbInstall.Controls.Add(Me.cmbInstallDir)
        Me.grbInstall.Controls.Add(Me.txtInstallFileName)
        Me.grbInstall.Enabled = False
        Me.grbInstall.Location = New System.Drawing.Point(7, 3)
        Me.grbInstall.Name = "grbInstall"
        Me.grbInstall.Size = New System.Drawing.Size(347, 146)
        Me.grbInstall.TabIndex = 3
        Me.grbInstall.TabStop = False
        '
        'cmbShutdown
        '
        Me.cmbShutdown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbShutdown.BackColor = System.Drawing.SystemColors.Window
        Me.cmbShutdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShutdown.Enabled = False
        Me.cmbShutdown.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbShutdown.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbShutdown.FormattingEnabled = True
        Me.cmbShutdown.Location = New System.Drawing.Point(107, 114)
        Me.cmbShutdown.MaxDropDownItems = 20
        Me.cmbShutdown.Name = "cmbShutdown"
        Me.cmbShutdown.Size = New System.Drawing.Size(233, 21)
        Me.cmbShutdown.TabIndex = 7
        '
        'chkShutdown
        '
        Me.chkShutdown.AutoSize = True
        Me.chkShutdown.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkShutdown.Location = New System.Drawing.Point(27, 117)
        Me.chkShutdown.Name = "chkShutdown"
        Me.chkShutdown.Size = New System.Drawing.Size(73, 17)
        Me.chkShutdown.TabIndex = 6
        Me.chkShutdown.Text = "Power OS"
        Me.chkShutdown.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkShutdown.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Filename:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Path:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkUseSameProcess
        '
        Me.chkUseSameProcess.AutoSize = True
        Me.chkUseSameProcess.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkUseSameProcess.Checked = True
        Me.chkUseSameProcess.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseSameProcess.Location = New System.Drawing.Point(166, 84)
        Me.chkUseSameProcess.Name = "chkUseSameProcess"
        Me.chkUseSameProcess.Size = New System.Drawing.Size(185, 17)
        Me.chkUseSameProcess.TabIndex = 2
        Me.chkUseSameProcess.Text = "Use same process (Recomended)"
        Me.chkUseSameProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkUseSameProcess.UseVisualStyleBackColor = True
        '
        'chkFakeMessageBox
        '
        Me.chkFakeMessageBox.AutoSize = True
        Me.chkFakeMessageBox.Location = New System.Drawing.Point(13, 2)
        Me.chkFakeMessageBox.Name = "chkFakeMessageBox"
        Me.chkFakeMessageBox.Size = New System.Drawing.Size(112, 17)
        Me.chkFakeMessageBox.TabIndex = 6
        Me.chkFakeMessageBox.Text = "Fake MessageBox"
        Me.chkFakeMessageBox.UseVisualStyleBackColor = True
        '
        'grbFakeMessageBox
        '
        Me.grbFakeMessageBox.Controls.Add(Me.cmbFakeMsgButtons)
        Me.grbFakeMessageBox.Controls.Add(Me.btnFakeMsg)
        Me.grbFakeMessageBox.Controls.Add(Me.cmbFakeMsgIcon)
        Me.grbFakeMessageBox.Controls.Add(Me.Label6)
        Me.grbFakeMessageBox.Controls.Add(Me.txtFakeMsgTitle)
        Me.grbFakeMessageBox.Controls.Add(Me.Label4)
        Me.grbFakeMessageBox.Controls.Add(Me.Label5)
        Me.grbFakeMessageBox.Controls.Add(Me.txtFakeMsg)
        Me.grbFakeMessageBox.Enabled = False
        Me.grbFakeMessageBox.Location = New System.Drawing.Point(7, 3)
        Me.grbFakeMessageBox.Name = "grbFakeMessageBox"
        Me.grbFakeMessageBox.Size = New System.Drawing.Size(347, 148)
        Me.grbFakeMessageBox.TabIndex = 5
        Me.grbFakeMessageBox.TabStop = False
        '
        'cmbFakeMsgButtons
        '
        Me.cmbFakeMsgButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFakeMsgButtons.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFakeMsgButtons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFakeMsgButtons.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbFakeMsgButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbFakeMsgButtons.FormattingEnabled = True
        Me.cmbFakeMsgButtons.Location = New System.Drawing.Point(203, 116)
        Me.cmbFakeMsgButtons.MaxDropDownItems = 20
        Me.cmbFakeMsgButtons.Name = "cmbFakeMsgButtons"
        Me.cmbFakeMsgButtons.Size = New System.Drawing.Size(92, 21)
        Me.cmbFakeMsgButtons.TabIndex = 6
        '
        'btnFakeMsg
        '
        Me.btnFakeMsg.Location = New System.Drawing.Point(302, 115)
        Me.btnFakeMsg.Name = "btnFakeMsg"
        Me.btnFakeMsg.Size = New System.Drawing.Size(41, 23)
        Me.btnFakeMsg.TabIndex = 7
        Me.btnFakeMsg.Text = "Test"
        Me.btnFakeMsg.UseVisualStyleBackColor = True
        '
        'cmbFakeMsgIcon
        '
        Me.cmbFakeMsgIcon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFakeMsgIcon.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFakeMsgIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFakeMsgIcon.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbFakeMsgIcon.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbFakeMsgIcon.FormattingEnabled = True
        Me.cmbFakeMsgIcon.Location = New System.Drawing.Point(107, 116)
        Me.cmbFakeMsgIcon.MaxDropDownItems = 20
        Me.cmbFakeMsgIcon.Name = "cmbFakeMsgIcon"
        Me.cmbFakeMsgIcon.Size = New System.Drawing.Size(92, 21)
        Me.cmbFakeMsgIcon.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(9, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 21)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Icon/Button(s):"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFakeMsgTitle
        '
        Me.txtFakeMsgTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFakeMsgTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFakeMsgTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFakeMsgTitle.Location = New System.Drawing.Point(107, 20)
        Me.txtFakeMsgTitle.MaxLength = 100
        Me.txtFakeMsgTitle.Name = "txtFakeMsgTitle"
        Me.txtFakeMsgTitle.Size = New System.Drawing.Size(233, 21)
        Me.txtFakeMsgTitle.TabIndex = 1
        Me.txtFakeMsgTitle.Text = "Error"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 21)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Message:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(9, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 21)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Title:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFakeMsg
        '
        Me.txtFakeMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFakeMsg.BackColor = System.Drawing.SystemColors.Window
        Me.txtFakeMsg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFakeMsg.Location = New System.Drawing.Point(107, 47)
        Me.txtFakeMsg.MaxLength = 255
        Me.txtFakeMsg.Multiline = True
        Me.txtFakeMsg.Name = "txtFakeMsg"
        Me.txtFakeMsg.Size = New System.Drawing.Size(233, 63)
        Me.txtFakeMsg.TabIndex = 3
        Me.txtFakeMsg.Text = "Runtime error 0x842"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.cmbAlgorithm)
        Me.GroupBox5.Controls.Add(Me.btnRandomKey)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.txtEncryptionKey)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(347, 77)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Cryptography"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(9, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 21)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Algorithm:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbAlgorithm
        '
        Me.cmbAlgorithm.BackColor = System.Drawing.SystemColors.Window
        Me.cmbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlgorithm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbAlgorithm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbAlgorithm.FormattingEnabled = True
        Me.cmbAlgorithm.Location = New System.Drawing.Point(107, 20)
        Me.cmbAlgorithm.MaxDropDownItems = 20
        Me.cmbAlgorithm.Name = "cmbAlgorithm"
        Me.cmbAlgorithm.Size = New System.Drawing.Size(234, 21)
        Me.cmbAlgorithm.TabIndex = 5
        '
        'btnRandomKey
        '
        Me.btnRandomKey.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRandomKey.Location = New System.Drawing.Point(273, 47)
        Me.btnRandomKey.Name = "btnRandomKey"
        Me.btnRandomKey.Size = New System.Drawing.Size(69, 22)
        Me.btnRandomKey.TabIndex = 2
        Me.btnRandomKey.Text = "&Random"
        Me.btnRandomKey.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Encryption Key:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEncryptionKey
        '
        Me.txtEncryptionKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEncryptionKey.Location = New System.Drawing.Point(107, 48)
        Me.txtEncryptionKey.MaxLength = 128
        Me.txtEncryptionKey.Name = "txtEncryptionKey"
        Me.txtEncryptionKey.Size = New System.Drawing.Size(160, 21)
        Me.txtEncryptionKey.TabIndex = 1
        '
        'grbInjectProcess
        '
        Me.grbInjectProcess.Controls.Add(Me.txtProcessInject)
        Me.grbInjectProcess.Controls.Add(Me.cmbProcessInject)
        Me.grbInjectProcess.Location = New System.Drawing.Point(7, 86)
        Me.grbInjectProcess.Name = "grbInjectProcess"
        Me.grbInjectProcess.Size = New System.Drawing.Size(348, 43)
        Me.grbInjectProcess.TabIndex = 1
        Me.grbInjectProcess.TabStop = False
        Me.grbInjectProcess.Text = "Process to inject (Path)"
        '
        'txtProcessInject
        '
        Me.txtProcessInject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProcessInject.AutoCompleteCustomSource.AddRange(New String() {"a", "b", "c"})
        Me.txtProcessInject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtProcessInject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtProcessInject.Location = New System.Drawing.Point(203, 16)
        Me.txtProcessInject.Name = "txtProcessInject"
        Me.txtProcessInject.Size = New System.Drawing.Size(138, 21)
        Me.txtProcessInject.TabIndex = 1
        Me.txtProcessInject.Text = "explorer.exe"
        '
        'cmbProcessInject
        '
        Me.cmbProcessInject.BackColor = System.Drawing.SystemColors.Window
        Me.cmbProcessInject.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbProcessInject.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbProcessInject.FormattingEnabled = True
        Me.cmbProcessInject.Location = New System.Drawing.Point(7, 16)
        Me.cmbProcessInject.MaxDropDownItems = 20
        Me.cmbProcessInject.Name = "cmbProcessInject"
        Me.cmbProcessInject.Size = New System.Drawing.Size(193, 21)
        Me.cmbProcessInject.TabIndex = 0
        '
        'lstMenu
        '
        Me.lstMenu.FormattingEnabled = True
        Me.lstMenu.IntegralHeight = False
        Me.lstMenu.Location = New System.Drawing.Point(3, 28)
        Me.lstMenu.Name = "lstMenu"
        Me.lstMenu.Size = New System.Drawing.Size(113, 216)
        Me.lstMenu.TabIndex = 2
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.chkUseSameProcess)
        Me.pnlMain.Controls.Add(Me.GroupBox5)
        Me.pnlMain.Controls.Add(Me.grbInjectProcess)
        Me.pnlMain.Controls.Add(Me.GroupBox6)
        Me.pnlMain.Location = New System.Drawing.Point(119, 28)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(363, 216)
        Me.pnlMain.TabIndex = 3
        '
        'pnlAssembly
        '
        Me.pnlAssembly.Controls.Add(Me.chkAssemblyInfoUseDefaut)
        Me.pnlAssembly.Controls.Add(Me.chkIconUseDefaut)
        Me.pnlAssembly.Controls.Add(Me.grbIcon)
        Me.pnlAssembly.Controls.Add(Me.grbAssemblyInfo)
        Me.pnlAssembly.Location = New System.Drawing.Point(119, 28)
        Me.pnlAssembly.Name = "pnlAssembly"
        Me.pnlAssembly.Size = New System.Drawing.Size(363, 216)
        Me.pnlAssembly.TabIndex = 4
        '
        'chkAssemblyInfoUseDefaut
        '
        Me.chkAssemblyInfoUseDefaut.AutoSize = True
        Me.chkAssemblyInfoUseDefaut.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAssemblyInfoUseDefaut.Checked = True
        Me.chkAssemblyInfoUseDefaut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAssemblyInfoUseDefaut.Location = New System.Drawing.Point(228, 2)
        Me.chkAssemblyInfoUseDefaut.Name = "chkAssemblyInfoUseDefaut"
        Me.chkAssemblyInfoUseDefaut.Size = New System.Drawing.Size(121, 17)
        Me.chkAssemblyInfoUseDefaut.TabIndex = 12
        Me.chkAssemblyInfoUseDefaut.Text = "Use same Exe fields"
        Me.chkAssemblyInfoUseDefaut.UseVisualStyleBackColor = True
        '
        'chkIconUseDefaut
        '
        Me.chkIconUseDefaut.AutoSize = True
        Me.chkIconUseDefaut.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIconUseDefaut.Checked = True
        Me.chkIconUseDefaut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIconUseDefaut.Location = New System.Drawing.Point(231, 158)
        Me.chkIconUseDefaut.Name = "chkIconUseDefaut"
        Me.chkIconUseDefaut.Size = New System.Drawing.Size(117, 17)
        Me.chkIconUseDefaut.TabIndex = 8
        Me.chkIconUseDefaut.Text = "Use same Exe Icon"
        Me.chkIconUseDefaut.UseVisualStyleBackColor = True
        '
        'grbIcon
        '
        Me.grbIcon.Controls.Add(Me.btnSystemIcon)
        Me.grbIcon.Controls.Add(Me.picIcon)
        Me.grbIcon.Enabled = False
        Me.grbIcon.Location = New System.Drawing.Point(7, 159)
        Me.grbIcon.Name = "grbIcon"
        Me.grbIcon.Size = New System.Drawing.Size(347, 49)
        Me.grbIcon.TabIndex = 7
        Me.grbIcon.TabStop = False
        Me.grbIcon.Text = "Icon"
        '
        'btnSystemIcon
        '
        Me.btnSystemIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSystemIcon.Location = New System.Drawing.Point(271, 19)
        Me.btnSystemIcon.Name = "btnSystemIcon"
        Me.btnSystemIcon.Size = New System.Drawing.Size(69, 22)
        Me.btnSystemIcon.TabIndex = 2
        Me.btnSystemIcon.Text = "&Open"
        Me.btnSystemIcon.UseVisualStyleBackColor = True
        '
        'picIcon
        '
        Me.picIcon.Location = New System.Drawing.Point(6, 13)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(32, 32)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIcon.TabIndex = 0
        Me.picIcon.TabStop = False
        '
        'grbAssemblyInfo
        '
        Me.grbAssemblyInfo.Controls.Add(Me.pnlAssemblyInfo)
        Me.grbAssemblyInfo.Enabled = False
        Me.grbAssemblyInfo.Location = New System.Drawing.Point(7, 2)
        Me.grbAssemblyInfo.Name = "grbAssemblyInfo"
        Me.grbAssemblyInfo.Size = New System.Drawing.Size(347, 151)
        Me.grbAssemblyInfo.TabIndex = 11
        Me.grbAssemblyInfo.TabStop = False
        Me.grbAssemblyInfo.Text = "Assembly Information"
        '
        'pnlAssemblyInfo
        '
        Me.pnlAssemblyInfo.AutoScroll = True
        Me.pnlAssemblyInfo.Controls.Add(Me.Label19)
        Me.pnlAssemblyInfo.Controls.Add(Me.txtAssemblyVersion)
        Me.pnlAssemblyInfo.Controls.Add(Me.txtLegalTrademarks)
        Me.pnlAssemblyInfo.Controls.Add(Me.txtOriginalFilename)
        Me.pnlAssemblyInfo.Controls.Add(Me.Label18)
        Me.pnlAssemblyInfo.Controls.Add(Me.Label7)
        Me.pnlAssemblyInfo.Controls.Add(Me.txtComments)
        Me.pnlAssemblyInfo.Controls.Add(Me.txtFileDescription)
        Me.pnlAssemblyInfo.Controls.Add(Me.Label17)
        Me.pnlAssemblyInfo.Controls.Add(Me.Label8)
        Me.pnlAssemblyInfo.Controls.Add(Me.txtInternalName)
        Me.pnlAssemblyInfo.Controls.Add(Me.txtCompanyName)
        Me.pnlAssemblyInfo.Controls.Add(Me.Label16)
        Me.pnlAssemblyInfo.Controls.Add(Me.Label9)
        Me.pnlAssemblyInfo.Controls.Add(Me.txtProductName)
        Me.pnlAssemblyInfo.Controls.Add(Me.txtLegalCopyright)
        Me.pnlAssemblyInfo.Controls.Add(Me.Label15)
        Me.pnlAssemblyInfo.Controls.Add(Me.Label10)
        Me.pnlAssemblyInfo.Controls.Add(Me.Label11)
        Me.pnlAssemblyInfo.Controls.Add(Me.Label14)
        Me.pnlAssemblyInfo.Controls.Add(Me.txtProductVersion)
        Me.pnlAssemblyInfo.Controls.Add(Me.txtFileVersion)
        Me.pnlAssemblyInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAssemblyInfo.Location = New System.Drawing.Point(3, 17)
        Me.pnlAssemblyInfo.Name = "pnlAssemblyInfo"
        Me.pnlAssemblyInfo.Size = New System.Drawing.Size(341, 131)
        Me.pnlAssemblyInfo.TabIndex = 30
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(5, 210)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 21)
        Me.Label19.TabIndex = 30
        Me.Label19.Text = "Assembly Version:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAssemblyVersion
        '
        Me.txtAssemblyVersion.Location = New System.Drawing.Point(109, 212)
        Me.txtAssemblyVersion.Mask = "0.0.0.0"
        Me.txtAssemblyVersion.Name = "txtAssemblyVersion"
        Me.txtAssemblyVersion.Size = New System.Drawing.Size(209, 21)
        Me.txtAssemblyVersion.TabIndex = 10
        '
        'txtLegalTrademarks
        '
        Me.txtLegalTrademarks.BackColor = System.Drawing.SystemColors.Window
        Me.txtLegalTrademarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLegalTrademarks.Location = New System.Drawing.Point(109, 149)
        Me.txtLegalTrademarks.MaxLength = 254
        Me.txtLegalTrademarks.Name = "txtLegalTrademarks"
        Me.txtLegalTrademarks.Size = New System.Drawing.Size(209, 21)
        Me.txtLegalTrademarks.TabIndex = 7
        '
        'txtOriginalFilename
        '
        Me.txtOriginalFilename.BackColor = System.Drawing.SystemColors.Window
        Me.txtOriginalFilename.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtOriginalFilename.Location = New System.Drawing.Point(109, 2)
        Me.txtOriginalFilename.MaxLength = 254
        Me.txtOriginalFilename.Name = "txtOriginalFilename"
        Me.txtOriginalFilename.Size = New System.Drawing.Size(209, 21)
        Me.txtOriginalFilename.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(4, 147)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 21)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "LegalTrademarks:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(4, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 21)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "FileDescription:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.SystemColors.Window
        Me.txtComments.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtComments.Location = New System.Drawing.Point(109, 65)
        Me.txtComments.MaxLength = 254
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(209, 21)
        Me.txtComments.TabIndex = 3
        '
        'txtFileDescription
        '
        Me.txtFileDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtFileDescription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFileDescription.Location = New System.Drawing.Point(109, 86)
        Me.txtFileDescription.MaxLength = 254
        Me.txtFileDescription.Name = "txtFileDescription"
        Me.txtFileDescription.Size = New System.Drawing.Size(209, 21)
        Me.txtFileDescription.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(5, 63)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 21)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Comments:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(4, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 21)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "CompanyName:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtInternalName
        '
        Me.txtInternalName.BackColor = System.Drawing.SystemColors.Window
        Me.txtInternalName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtInternalName.Location = New System.Drawing.Point(109, 44)
        Me.txtInternalName.MaxLength = 254
        Me.txtInternalName.Name = "txtInternalName"
        Me.txtInternalName.Size = New System.Drawing.Size(209, 21)
        Me.txtInternalName.TabIndex = 2
        '
        'txtCompanyName
        '
        Me.txtCompanyName.BackColor = System.Drawing.SystemColors.Window
        Me.txtCompanyName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCompanyName.Location = New System.Drawing.Point(109, 107)
        Me.txtCompanyName.MaxLength = 254
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(209, 21)
        Me.txtCompanyName.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(5, 42)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 21)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "InternalName:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(4, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 21)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "LegalCopyright:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtProductName
        '
        Me.txtProductName.BackColor = System.Drawing.SystemColors.Window
        Me.txtProductName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProductName.Location = New System.Drawing.Point(109, 23)
        Me.txtProductName.MaxLength = 254
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(209, 21)
        Me.txtProductName.TabIndex = 1
        '
        'txtLegalCopyright
        '
        Me.txtLegalCopyright.BackColor = System.Drawing.SystemColors.Window
        Me.txtLegalCopyright.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLegalCopyright.Location = New System.Drawing.Point(109, 128)
        Me.txtLegalCopyright.MaxLength = 254
        Me.txtLegalCopyright.Name = "txtLegalCopyright"
        Me.txtLegalCopyright.Size = New System.Drawing.Size(209, 21)
        Me.txtLegalCopyright.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(5, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 21)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "ProductName:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(5, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 21)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "ProductVersion:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(5, 189)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 21)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "FileVersion:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 21)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "OriginalFilename:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtProductVersion
        '
        Me.txtProductVersion.Location = New System.Drawing.Point(109, 170)
        Me.txtProductVersion.Mask = "0.0.0.0"
        Me.txtProductVersion.Name = "txtProductVersion"
        Me.txtProductVersion.Size = New System.Drawing.Size(209, 21)
        Me.txtProductVersion.TabIndex = 8
        '
        'txtFileVersion
        '
        Me.txtFileVersion.Location = New System.Drawing.Point(109, 191)
        Me.txtFileVersion.Mask = "0.0.0.0"
        Me.txtFileVersion.Name = "txtFileVersion"
        Me.txtFileVersion.Size = New System.Drawing.Size(209, 21)
        Me.txtFileVersion.TabIndex = 9
        '
        'pnlStubs
        '
        Me.pnlStubs.Controls.Add(Me.btnRefreshStubs)
        Me.pnlStubs.Controls.Add(Me.lvwStubs)
        Me.pnlStubs.Location = New System.Drawing.Point(119, 28)
        Me.pnlStubs.Name = "pnlStubs"
        Me.pnlStubs.Size = New System.Drawing.Size(363, 216)
        Me.pnlStubs.TabIndex = 5
        '
        'btnRefreshStubs
        '
        Me.btnRefreshStubs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshStubs.Location = New System.Drawing.Point(286, 184)
        Me.btnRefreshStubs.Name = "btnRefreshStubs"
        Me.btnRefreshStubs.Size = New System.Drawing.Size(69, 22)
        Me.btnRefreshStubs.TabIndex = 1
        Me.btnRefreshStubs.Text = "&Refresh"
        Me.btnRefreshStubs.UseVisualStyleBackColor = True
        '
        'lvwStubs
        '
        Me.lvwStubs.CheckBoxes = True
        Me.lvwStubs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvwStubs.FullRowSelect = True
        Me.lvwStubs.HideSelection = False
        Me.lvwStubs.Location = New System.Drawing.Point(7, 3)
        Me.lvwStubs.Name = "lvwStubs"
        Me.lvwStubs.Size = New System.Drawing.Size(347, 175)
        Me.lvwStubs.TabIndex = 0
        Me.lvwStubs.UseCompatibleStateImageBehavior = False
        Me.lvwStubs.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Filename"
        Me.ColumnHeader1.Width = 158
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Size"
        Me.ColumnHeader2.Width = 85
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Real Size"
        Me.ColumnHeader3.Width = 81
        '
        'pnlAbout
        '
        Me.pnlAbout.Controls.Add(Me.picAbout)
        Me.pnlAbout.Location = New System.Drawing.Point(119, 28)
        Me.pnlAbout.Name = "pnlAbout"
        Me.pnlAbout.Size = New System.Drawing.Size(363, 216)
        Me.pnlAbout.TabIndex = 7
        '
        'picAbout
        '
        Me.picAbout.BackColor = System.Drawing.Color.Transparent
        Me.picAbout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picAbout.ImageBitmap = Nothing
        Me.picAbout.Location = New System.Drawing.Point(0, 0)
        Me.picAbout.Name = "picAbout"
        Me.picAbout.Scale = 1
        Me.picAbout.Size = New System.Drawing.Size(363, 216)
        Me.picAbout.TabIndex = 1
        '
        'pnlFake
        '
        Me.pnlFake.Controls.Add(Me.chkFakeMessageBox)
        Me.pnlFake.Controls.Add(Me.grbFakeMessageBox)
        Me.pnlFake.Location = New System.Drawing.Point(119, 28)
        Me.pnlFake.Name = "pnlFake"
        Me.pnlFake.Size = New System.Drawing.Size(363, 216)
        Me.pnlFake.TabIndex = 6
        '
        'pnlInstall
        '
        Me.pnlInstall.Controls.Add(Me.chkInstall)
        Me.pnlInstall.Controls.Add(Me.grbInstall)
        Me.pnlInstall.Location = New System.Drawing.Point(119, 28)
        Me.pnlInstall.Name = "pnlInstall"
        Me.pnlInstall.Size = New System.Drawing.Size(363, 216)
        Me.pnlInstall.TabIndex = 9
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpen, Me.toolStripSeparator, Me.btnBuild, Me.toolStripSeparator1, Me.btnExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(484, 25)
        Me.ToolStrip1.TabIndex = 10
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnOpen
        '
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(53, 22)
        Me.btnOpen.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'btnBuild
        '
        Me.btnBuild.Image = Global.Crypter.NET.My.Resources.Resources.Build
        Me.btnBuild.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuild.Name = "btnBuild"
        Me.btnBuild.Size = New System.Drawing.Size(49, 22)
        Me.btnBuild.Text = "&Build"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnExit
        '
        Me.btnExit.Image = Global.Crypter.NET.My.Resources.Resources._Exit
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(45, 22)
        Me.btnExit.Text = "&Exit"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 248)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(484, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.AutoToolTip = True
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(469, 17)
        Me.lblStatus.Spring = True
        Me.lblStatus.Text = "lblStatus"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Core
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 270)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lstMenu)
        Me.Controls.Add(Me.pnlFake)
        Me.Controls.Add(Me.pnlStubs)
        Me.Controls.Add(Me.pnlAssembly)
        Me.Controls.Add(Me.pnlInstall)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlAbout)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Core"
        Me.Opacity = 0
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Runtime Crypter.NET v.{0}.{1}"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.numSuiecidedWait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbInstall.ResumeLayout(False)
        Me.grbInstall.PerformLayout()
        Me.grbFakeMessageBox.ResumeLayout(False)
        Me.grbFakeMessageBox.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.grbInjectProcess.ResumeLayout(False)
        Me.grbInjectProcess.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlAssembly.ResumeLayout(False)
        Me.pnlAssembly.PerformLayout()
        Me.grbIcon.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbAssemblyInfo.ResumeLayout(False)
        Me.pnlAssemblyInfo.ResumeLayout(False)
        Me.pnlAssemblyInfo.PerformLayout()
        Me.pnlStubs.ResumeLayout(False)
        Me.pnlAbout.ResumeLayout(False)
        Me.pnlFake.ResumeLayout(False)
        Me.pnlFake.PerformLayout()
        Me.pnlInstall.ResumeLayout(False)
        Me.pnlInstall.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAntiSandboxie As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstall As System.Windows.Forms.CheckBox
    Friend WithEvents cmbInstallDir As System.Windows.Forms.ComboBox
    Friend WithEvents txtInstallFileName As System.Windows.Forms.TextBox
    Friend WithEvents chkInstallAutoRun As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstallHidden As System.Windows.Forms.CheckBox
    Friend WithEvents grbInstall As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtEncryptionKey As System.Windows.Forms.TextBox
    Friend WithEvents btnRandomKey As System.Windows.Forms.Button
    Friend WithEvents chkFakeMessageBox As System.Windows.Forms.CheckBox
    Friend WithEvents grbFakeMessageBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFakeMsg As System.Windows.Forms.TextBox
    Friend WithEvents txtFakeMsgTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbFakeMsgIcon As System.Windows.Forms.ComboBox
    Friend WithEvents btnFakeMsg As System.Windows.Forms.Button
    Friend WithEvents cmbFakeMsgButtons As System.Windows.Forms.ComboBox
    Friend WithEvents grbInjectProcess As System.Windows.Forms.GroupBox
    Friend WithEvents cmbProcessInject As System.Windows.Forms.ComboBox
    Private WithEvents txtProcessInject As System.Windows.Forms.TextBox
    Friend WithEvents chkUseSameProcess As System.Windows.Forms.CheckBox
    Friend WithEvents lstMenu As System.Windows.Forms.ListBox
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pnlAssembly As System.Windows.Forms.Panel
    Friend WithEvents pnlStubs As System.Windows.Forms.Panel
    Friend WithEvents pnlAbout As System.Windows.Forms.Panel
    Friend WithEvents pnlFake As System.Windows.Forms.Panel
    Friend WithEvents grbIcon As System.Windows.Forms.GroupBox
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents picAbout As Crypter.NET.WaterFX
    Friend WithEvents lvwStubs As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkIconUseDefaut As System.Windows.Forms.CheckBox
    Friend WithEvents grbAssemblyInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFileDescription As System.Windows.Forms.TextBox
    Friend WithEvents chkAssemblyInfoUseDefaut As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtLegalCopyright As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtProductVersion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFileVersion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnRefreshStubs As System.Windows.Forms.Button
    Friend WithEvents btnSystemIcon As System.Windows.Forms.Button
    Friend WithEvents chkSuiecideStub As System.Windows.Forms.CheckBox
    Friend WithEvents cmbAlgorithm As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pnlInstall As System.Windows.Forms.Panel
    Friend WithEvents chkGZip As System.Windows.Forms.CheckBox
    Friend WithEvents chkShutdown As System.Windows.Forms.CheckBox
    Friend WithEvents cmbShutdown As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
    Friend WithEvents numSuiecidedWait As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtOriginalFilename As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtInternalName As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtLegalTrademarks As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents pnlAssemblyInfo As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtAssemblyVersion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnBuild As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel

End Class
