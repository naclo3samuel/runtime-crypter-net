<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpenExe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpenExe))
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
        Me.lvwAssembly = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.picIcon = New System.Windows.Forms.PictureBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnOpen = New System.Windows.Forms.ToolStripButton
        Me.grbAssemblyInfo.SuspendLayout()
        Me.pnlAssemblyInfo.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbAssemblyInfo
        '
        Me.grbAssemblyInfo.Controls.Add(Me.pnlAssemblyInfo)
        Me.grbAssemblyInfo.Enabled = False
        Me.grbAssemblyInfo.Location = New System.Drawing.Point(470, 150)
        Me.grbAssemblyInfo.Name = "grbAssemblyInfo"
        Me.grbAssemblyInfo.Size = New System.Drawing.Size(329, 262)
        Me.grbAssemblyInfo.TabIndex = 12
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
        Me.pnlAssemblyInfo.Location = New System.Drawing.Point(3, 16)
        Me.pnlAssemblyInfo.Name = "pnlAssemblyInfo"
        Me.pnlAssemblyInfo.Size = New System.Drawing.Size(323, 243)
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
        Me.txtAssemblyVersion.Size = New System.Drawing.Size(209, 20)
        Me.txtAssemblyVersion.TabIndex = 10
        '
        'txtLegalTrademarks
        '
        Me.txtLegalTrademarks.BackColor = System.Drawing.SystemColors.Window
        Me.txtLegalTrademarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLegalTrademarks.Location = New System.Drawing.Point(109, 149)
        Me.txtLegalTrademarks.MaxLength = 254
        Me.txtLegalTrademarks.Name = "txtLegalTrademarks"
        Me.txtLegalTrademarks.Size = New System.Drawing.Size(209, 20)
        Me.txtLegalTrademarks.TabIndex = 7
        '
        'txtOriginalFilename
        '
        Me.txtOriginalFilename.BackColor = System.Drawing.SystemColors.Window
        Me.txtOriginalFilename.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtOriginalFilename.Location = New System.Drawing.Point(109, 2)
        Me.txtOriginalFilename.MaxLength = 254
        Me.txtOriginalFilename.Name = "txtOriginalFilename"
        Me.txtOriginalFilename.Size = New System.Drawing.Size(209, 20)
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
        Me.txtComments.Size = New System.Drawing.Size(209, 20)
        Me.txtComments.TabIndex = 3
        '
        'txtFileDescription
        '
        Me.txtFileDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtFileDescription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFileDescription.Location = New System.Drawing.Point(109, 86)
        Me.txtFileDescription.MaxLength = 254
        Me.txtFileDescription.Name = "txtFileDescription"
        Me.txtFileDescription.Size = New System.Drawing.Size(209, 20)
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
        Me.txtInternalName.Size = New System.Drawing.Size(209, 20)
        Me.txtInternalName.TabIndex = 2
        '
        'txtCompanyName
        '
        Me.txtCompanyName.BackColor = System.Drawing.SystemColors.Window
        Me.txtCompanyName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCompanyName.Location = New System.Drawing.Point(109, 107)
        Me.txtCompanyName.MaxLength = 254
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(209, 20)
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
        Me.txtProductName.Size = New System.Drawing.Size(209, 20)
        Me.txtProductName.TabIndex = 1
        '
        'txtLegalCopyright
        '
        Me.txtLegalCopyright.BackColor = System.Drawing.SystemColors.Window
        Me.txtLegalCopyright.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLegalCopyright.Location = New System.Drawing.Point(109, 128)
        Me.txtLegalCopyright.MaxLength = 254
        Me.txtLegalCopyright.Name = "txtLegalCopyright"
        Me.txtLegalCopyright.Size = New System.Drawing.Size(209, 20)
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
        Me.txtProductVersion.Size = New System.Drawing.Size(209, 20)
        Me.txtProductVersion.TabIndex = 8
        '
        'txtFileVersion
        '
        Me.txtFileVersion.Location = New System.Drawing.Point(109, 191)
        Me.txtFileVersion.Mask = "0.0.0.0"
        Me.txtFileVersion.Name = "txtFileVersion"
        Me.txtFileVersion.Size = New System.Drawing.Size(209, 20)
        Me.txtFileVersion.TabIndex = 9
        '
        'lvwAssembly
        '
        Me.lvwAssembly.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvwAssembly.Location = New System.Drawing.Point(3, 28)
        Me.lvwAssembly.Name = "lvwAssembly"
        Me.lvwAssembly.Size = New System.Drawing.Size(347, 255)
        Me.lvwAssembly.TabIndex = 13
        Me.lvwAssembly.UseCompatibleStateImageBehavior = False
        Me.lvwAssembly.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Header"
        Me.ColumnHeader1.Width = 126
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Value"
        Me.ColumnHeader2.Width = 194
        '
        'picIcon
        '
        Me.picIcon.Location = New System.Drawing.Point(3, 287)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(32, 32)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIcon.TabIndex = 0
        Me.picIcon.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(275, 294)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(194, 294)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpen})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(355, 25)
        Me.ToolStrip1.TabIndex = 17
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
        'OpenExe
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 323)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.picIcon)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lvwAssembly)
        Me.Controls.Add(Me.grbAssemblyInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OpenExe"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OpenExe"
        Me.grbAssemblyInfo.ResumeLayout(False)
        Me.pnlAssemblyInfo.ResumeLayout(False)
        Me.pnlAssemblyInfo.PerformLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbAssemblyInfo As System.Windows.Forms.GroupBox
    Friend WithEvents pnlAssemblyInfo As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtAssemblyVersion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtLegalTrademarks As System.Windows.Forms.TextBox
    Friend WithEvents txtOriginalFilename As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtFileDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInternalName As System.Windows.Forms.TextBox
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents txtLegalCopyright As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtProductVersion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFileVersion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lvwAssembly As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnOpen As System.Windows.Forms.ToolStripButton
End Class
