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
Public Class SystemIcons

    Private Shared ReadOnly TilePadding As New Padding(2, 1, 2, 1)
    Private __SelectedIcon As Icon

    Private Class TileSizeComboBoxItem
        Private _Size As Size
        Public Property Size() As Size
            Get
                Return _Size
            End Get
            Private Set(ByVal value As Size)
                _Size = value
            End Set
        End Property

        Public Sub New(ByVal size As Size)
            Me.Size = size
        End Sub

        Public Overloads Overrides Function ToString() As String
            Return [String].Format("{0} x {1}", Me.Size.Width, Me.Size.Height)
        End Function
    End Class

    Private Class IconListViewItem
        Inherits ListViewItem
        Private _Icon As Icon
        Public Property Icon() As Icon
            Get
                Return _Icon
            End Get
            Set(ByVal value As Icon)
                _Icon = value
            End Set
        End Property
    End Class

    Public ReadOnly Property SelectedIcon() As Icon
        Get
            Return __SelectedIcon
        End Get
    End Property
 
    Private Function GetIconBitDepth(ByVal icon As Icon) As Integer
        If icon Is Nothing Then
            Throw New ArgumentNullException("icon")
        End If

        Dim data As Byte() = Nothing
        Using stream As New MemoryStream()
            icon.Save(stream)
            data = stream.ToArray()
        End Using

        Return BitConverter.ToInt16(data, 12)
    End Function

    Private Sub ClearAllIcons()
        If TypeOf Me.lvwIcons.Tag Is Icon Then
            DirectCast(Me.lvwIcons.Tag, Icon).Dispose()
            Me.lvwIcons.Tag = Nothing
        End If

        For Each item As ListViewItem In Me.lvwIcons.Items
            If TypeOf item Is IconListViewItem Then
                DirectCast(item, IconListViewItem).Icon.Dispose()
            End If
        Next

        Me.lvwIcons.Items.Clear()
    End Sub

    Private Sub OpenDialog(Optional ByVal sPath As String = "")

        Me.Text = "Icon Extractor"

        If Not String.IsNullOrEmpty(sPath) Then
            Me.iconPickerDialog.Filename = sPath
        End If

        Dim result As DialogResult = Me.iconPickerDialog.ShowDialog(Me)
        If result <> DialogResult.OK Then
            Exit Sub
        End If

        Me.txtSelectedIcon.Text = (Me.iconPickerDialog.Filename & ", ") + Me.iconPickerDialog.IconIndex.ToString()

        Dim icon As Icon = Nothing
        Dim splitIcons As Icon() = Nothing
        Try
            If Path.GetExtension(Me.iconPickerDialog.Filename).ToLower() = ".ico" Then
                icon = New Icon(Me.iconPickerDialog.Filename)
            Else
                Using extractor As New IconExtractor(Me.iconPickerDialog.Filename)
                    icon = extractor.GetIcon(Me.iconPickerDialog.IconIndex)
                End Using
            End If

            splitIcons = IconExtractor.SplitIcon(icon)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "IconExtractor Demo - Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End Try

        ' Update Icons.
        Me.Icon = icon

        ' Update ListView
        Me.lvwIcons.BeginUpdate()
        ClearAllIcons()

        Me.lvwIcons.Tag = icon
        For Each i As Icon In splitIcons
            Dim item As New IconListViewItem()
            item.ToolTipText = [String].Format("{0} x {1}, {2}bits", i.Width, i.Height, GetIconBitDepth(i))
            item.Icon = i

            Me.lvwIcons.Items.Add(item)
        Next

        Me.lvwIcons.EndUpdate()
    End Sub

    Private Sub btnSelectIcon_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectIcon.Click
        OpenDialog("")
    End Sub

    Private Sub cmbTileSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTileSize.SelectedIndexChanged
        Dim item As TileSizeComboBoxItem = TryCast(DirectCast(sender, ComboBox).SelectedItem, TileSizeComboBoxItem)
        If item Is Nothing Then
            Exit Sub
        End If

        ' Change TileSize of the ListView
        Me.lvwIcons.BeginUpdate()

        Me.lvwIcons.TileSize = New Size(item.Size.Width + TilePadding.Horizontal, item.Size.Height + TilePadding.Vertical)
        If Me.lvwIcons.Items.Count <> 0 Then
            Me.lvwIcons.RedrawItems(0, Me.lvwIcons.Items.Count - 1, False)
        End If

        Me.lvwIcons.EndUpdate()
    End Sub

    Private Sub lvwIcons_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwIcons.DoubleClick
        If lvwIcons.SelectedItems.Count > 0 Then
            Me.Close()
        End If
    End Sub

    Private Sub lvwIcons_DrawItem(ByVal sender As Object, ByVal e As DrawListViewItemEventArgs) Handles lvwIcons.DrawItem
        Dim item As IconListViewItem = TryCast(e.Item, IconListViewItem)
        If item Is Nothing Then
            e.DrawDefault = True
            Exit Sub
        End If

        ' Draw item
        e.DrawBackground()
        e.Graphics.DrawRectangle(SystemPens.ControlLight, e.Bounds)

        Dim x As Integer = e.Bounds.X + (e.Bounds.Width - item.Icon.Width) / 2
        Dim y As Integer = e.Bounds.Y + (e.Bounds.Height - item.Icon.Height) / 2
        Dim rect As New Rectangle(x, y, item.Icon.Width, item.Icon.Height)
        Dim clipReg As New Region(e.Bounds)
        e.Graphics.Clip = clipReg
        e.Graphics.DrawIcon(item.Icon, rect)
    End Sub

    Private Sub lvwIcons_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwIcons.SelectedIndexChanged
        If lvwIcons.SelectedItems.Count > 0 Then
            Dim item As IconListViewItem = TryCast(lvwIcons.SelectedItems(0), IconListViewItem)
            picIcon.Image = item.Icon.ToBitmap
            __SelectedIcon = item.Icon
            btnSelect.Enabled = True
        Else
            picIcon.Image = Nothing
            __SelectedIcon = Nothing
            btnSelect.Enabled = False
        End If
    End Sub
 
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        __SelectedIcon = Nothing
        Me.Close()
    End Sub

    Private Sub SystemIcons_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        ClearAllIcons()
    End Sub

    Private Sub SystemIcons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Initialize ComboBox
        Dim s As Integer = 16
        While s <= 256
            Dim item As New TileSizeComboBoxItem(New Size(s, s))
            Me.cmbTileSize.Items.Add(item)
            s *= 2
        End While
        Me.cmbTileSize.SelectedIndex = 2
        FlatBorder(picIcon)
    End Sub

    Private Sub SystemIcons_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim sFiles() As String = DirectCast(e.Data.GetData(DataFormats.FileDrop, False), String())
        If sFiles IsNot Nothing Then
            If sFiles.Length = 1 Then
                If sFiles(0).ToLower.EndsWith(".exe") Then
                    OpenDialog(sFiles(0))
                End If
            End If
        End If
    End Sub

    Private Sub SystemIcons_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then e.Effect = DragDropEffects.Copy
    End Sub

End Class