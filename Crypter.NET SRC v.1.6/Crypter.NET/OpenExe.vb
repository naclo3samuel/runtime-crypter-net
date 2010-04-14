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
Imports Api.Assembly
Imports System.IO
Imports System.Text
Public Class OpenExe

    Private __ExePath As String
    Private __ExeIcon As Icon
    Private __Assembly As Hashtable

    Public ReadOnly Property ExePath() As String
        Get
            Return __ExePath
        End Get
    End Property

    Public ReadOnly Property ExeIcon() As Icon
        Get
            Return __ExeIcon
        End Get
    End Property

    Public ReadOnly Property Assembly() As Hashtable
        Get
            Return __Assembly
        End Get
    End Property

    Private Function ValideExe(ByVal sPath As String) As Boolean
        Dim bytEXE() As Byte = File.ReadAllBytes(sPath)
        Dim strEXE As String = Encoding.ASCII.GetString(bytEXE)
        If strEXE.Contains("|S1|") And strEXE.Contains("|S2|") And strEXE.Contains("|E1|") Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub OpenExe_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim sFiles() As String = DirectCast(e.Data.GetData(DataFormats.FileDrop, False), String())
        If sFiles IsNot Nothing Then
            If sFiles.Length = 1 Then
                If sFiles(0).ToLower.EndsWith(".exe") Then
                    LoadExe(sFiles(0))
                End If
            End If
        End If
    End Sub

    Private Sub OpenExe_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        __ExePath = Nothing : Me.Close()
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        ' Open the Exe..
        Using oOFD As New OpenFileDialog
            oOFD.Filter = "Executable file *.exe|*.exe"
            If oOFD.ShowDialog = Windows.Forms.DialogResult.OK Then
                LoadExe(oOFD.FileName)
            End If
        End Using
    End Sub

    Private Sub LoadExe(ByVal sPath As String)
        Try

            If Not ValideExe(sPath) Then
                MessageBox.Show("The executable is already encrypted!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lvwAssembly.Items.Clear()
                __Assembly = Nothing
                __ExeIcon = Nothing
                __ExePath = Nothing
                picIcon.Image = Nothing
                btnOK.Enabled = False
            End If

            Dim oVR As New VersionResource()
            oVR.LoadFrom(sPath)
            Dim oStringFileInfo As StringFileInfo = DirectCast(oVR("StringFileInfo"), StringFileInfo)
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
            __Assembly = New Hashtable
            lvwAssembly.BeginUpdate()
            lvwAssembly.Items.Clear()
            For Each oST As KeyValuePair(Of String, StringTable) In oStringFileInfo.Strings
                For Each oSR As KeyValuePair(Of String, StringResource) In oST.Value.Strings
                    Dim Item As New ListViewItem(oSR.Key)
                    Item.SubItems.Add(oSR.Value.Value)
                    lvwAssembly.Items.Add(Item)
                    __Assembly.Add(oSR.Key, oSR.Value.Value)
                Next
            Next
            oStringFileInfo = Nothing
            oVR = Nothing
            lvwAssembly.EndUpdate()
            ' Create a temp icon..
            Dim oIE As New IconExtractor(sPath)
            If oIE.IconCount > 0 Then
                __ExeIcon = oIE.GetIcon(0)
                picIcon.Image = __ExeIcon.ToBitmap
            Else
                __ExeIcon = Nothing
                picIcon.Image = Nothing
            End If
            __ExePath = sPath
            btnOK.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub New(Optional ByVal sPath As String = "")
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        If Not String.IsNullOrEmpty(sPath) Then
            LoadExe(sPath)
        End If
    End Sub

End Class