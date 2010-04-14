<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemIcons
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
        Me.cmbTileSize = New System.Windows.Forms.ComboBox
        Me.lvwIcons = New System.Windows.Forms.ListView
        Me.txtSelectedIcon = New System.Windows.Forms.TextBox
        Me.btnSelectIcon = New System.Windows.Forms.Button
        Me.picIcon = New System.Windows.Forms.PictureBox
        Me.btnSelect = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.iconPickerDialog = New Crypter.NET.IconPickerDialog
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbTileSize
        '
        Me.cmbTileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTileSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbTileSize.FormattingEnabled = True
        Me.cmbTileSize.Location = New System.Drawing.Point(4, 3)
        Me.cmbTileSize.Name = "cmbTileSize"
        Me.cmbTileSize.Size = New System.Drawing.Size(79, 21)
        Me.cmbTileSize.TabIndex = 4
        '
        'lvwIcons
        '
        Me.lvwIcons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwIcons.Location = New System.Drawing.Point(4, 28)
        Me.lvwIcons.MultiSelect = False
        Me.lvwIcons.Name = "lvwIcons"
        Me.lvwIcons.OwnerDraw = True
        Me.lvwIcons.ShowItemToolTips = True
        Me.lvwIcons.Size = New System.Drawing.Size(283, 217)
        Me.lvwIcons.TabIndex = 1
        Me.lvwIcons.TileSize = New System.Drawing.Size(64, 64)
        Me.lvwIcons.UseCompatibleStateImageBehavior = False
        Me.lvwIcons.View = System.Windows.Forms.View.Tile
        '
        'txtSelectedIcon
        '
        Me.txtSelectedIcon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSelectedIcon.Location = New System.Drawing.Point(89, 4)
        Me.txtSelectedIcon.Name = "txtSelectedIcon"
        Me.txtSelectedIcon.ReadOnly = True
        Me.txtSelectedIcon.Size = New System.Drawing.Size(117, 21)
        Me.txtSelectedIcon.TabIndex = 5
        '
        'btnSelectIcon
        '
        Me.btnSelectIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectIcon.Location = New System.Drawing.Point(212, 3)
        Me.btnSelectIcon.Name = "btnSelectIcon"
        Me.btnSelectIcon.Size = New System.Drawing.Size(75, 22)
        Me.btnSelectIcon.TabIndex = 0
        Me.btnSelectIcon.Text = "&Open"
        Me.btnSelectIcon.UseVisualStyleBackColor = True
        '
        'picIcon
        '
        Me.picIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picIcon.Location = New System.Drawing.Point(4, 251)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(32, 32)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIcon.TabIndex = 10
        Me.picIcon.TabStop = False
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.Enabled = False
        Me.btnSelect.Location = New System.Drawing.Point(131, 251)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 25)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "&Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(212, 251)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'iconPickerDialog
        '
        Me.iconPickerDialog.Filename = Nothing
        '
        'SystemIcons
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 287)
        Me.Controls.Add(Me.picIcon)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.cmbTileSize)
        Me.Controls.Add(Me.lvwIcons)
        Me.Controls.Add(Me.txtSelectedIcon)
        Me.Controls.Add(Me.btnSelectIcon)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(286, 284)
        Me.Name = "SystemIcons"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Icon Extractor (Drag-Drop here.. Exe/Dll/Ocx)"
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents cmbTileSize As System.Windows.Forms.ComboBox
    Private WithEvents lvwIcons As System.Windows.Forms.ListView
    Private WithEvents txtSelectedIcon As System.Windows.Forms.TextBox
    Private WithEvents btnSelectIcon As System.Windows.Forms.Button
    Friend WithEvents iconPickerDialog As Crypter.NET.IconPickerDialog
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Private WithEvents btnSelect As System.Windows.Forms.Button
    Private WithEvents btnCancel As System.Windows.Forms.Button
End Class
