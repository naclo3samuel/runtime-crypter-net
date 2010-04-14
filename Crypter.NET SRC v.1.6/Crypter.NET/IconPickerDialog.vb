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
Imports System
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
 
Public Class IconPickerDialog
    Inherits CommonDialog
    Private Const MAX_PATH As Integer = 260

    <DllImport("shell32.dll", EntryPoint:="#62", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function SHPickIconDialog(ByVal hWnd As IntPtr, ByVal pszFilename As StringBuilder, ByVal cchFilenameMax As Integer, ByRef pnIconIndex As Integer) As Boolean
    End Function

    Private _filename As String = Nothing

    <DefaultValue("")> _
    Public Property Filename() As String
        Get
            Return Me._filename
        End Get
        Set(ByVal value As String)
            Me._filename = value
        End Set
    End Property

    Private _iconIndex As Integer = 0

    <DefaultValue(0)> _
    Public Property IconIndex() As Integer
        Get
            Return Me._iconIndex
        End Get
        Set(ByVal value As Integer)
            Me._iconIndex = value
        End Set
    End Property

    Protected Overloads Overrides Function RunDialog(ByVal hwndOwner As IntPtr) As Boolean
        Dim buf As New StringBuilder(Me._filename, MAX_PATH)
        Dim iconIndex As Integer

        Dim ok As Boolean = SHPickIconDialog(hwndOwner, buf, MAX_PATH, iconIndex)
        If ok Then
            Me._filename = Environment.ExpandEnvironmentVariables(buf.ToString())
            Me._iconIndex = iconIndex
        End If

        Return ok
    End Function

    Public Overloads Overrides Sub Reset()
        Me._filename = Nothing
        Me._iconIndex = 0
    End Sub
End Class
 