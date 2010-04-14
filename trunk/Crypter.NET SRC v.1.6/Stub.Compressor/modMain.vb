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
Imports System.IO.Compression
Module modMain

    Public Sub Main()
        Try
            Dim sPath As String = System.Environment.GetCommandLineArgs(1)
            If String.IsNullOrEmpty(sPath) Then Return

            Dim sPathComp As String = Path.ChangeExtension(sPath, "bin")
            Dim oFile As New FileInfo(sPath)

            Dim intOrig As Integer = oFile.Length
            Dim intFinal As Integer

            'A String object reads the file name (locally)
            Dim FileName As String = Path.GetFileName(sPath)
            Using oFS As New FileStream(sPath, FileMode.OpenOrCreate)
                Dim bytBuffer(oFS.Length) As Byte
                'Fill buffer
                oFS.Read(bytBuffer, 0, bytBuffer.Length)
                oFS.Close()
                'File Stream object used to change the extension of a file
                Dim oFileStream As FileStream = File.Create(sPathComp)
                'GZip object that compress the file 
                Using oGZipStream As New GZipStream(oFileStream, CompressionMode.Compress)
                    'Write to the Stream object from the buffer
                    oGZipStream.Write(bytBuffer, 0, bytBuffer.Length)
                    oGZipStream.Close()
                End Using
                oFile = New FileInfo(sPathComp)
                intFinal = oFile.Length
            End Using

            Console.WriteLine("Compression done!" & vbNewLine & _
                            "Original file size: " & FormatBytes(intOrig) & vbNewLine & _
                            "Compressed file size: " & FormatBytes(intFinal) & vbNewLine & _
                            "Reduzed size: " & FormatBytes(intOrig - intFinal) & " (" & FormatNumber((intFinal * 100 / intOrig), 2) & "%)")
            Console.ReadKey()

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Console.ReadKey()
        End Try
    End Sub

    Private Function FormatBytes(ByVal dblBytes As Double) As String
        Const KILOBYTE As Double = 1024
        Const MEGABYTE As Double = KILOBYTE ^ 2
        Const GIGABYTE As Double = KILOBYTE ^ 3
        Const TERABYTE As Double = KILOBYTE ^ 4
        Const PETABYTE As Double = KILOBYTE ^ 5

        Select Case dblBytes
            Case Is >= PETABYTE
                Return System.Math.Round(dblBytes / PETABYTE, 2) & " PiB"
            Case Is >= TERABYTE
                Return System.Math.Round(dblBytes / TERABYTE, 2) & " TiB"
            Case Is >= GIGABYTE
                Return System.Math.Round(dblBytes / GIGABYTE, 2) & " GiB"
            Case Is >= MEGABYTE
                Return System.Math.Round(dblBytes / MEGABYTE, 2) & " MiB"
            Case Is >= KILOBYTE
                Return System.Math.Round(dblBytes / KILOBYTE, 2) & " KiB"
            Case Else
                Return dblBytes & " Bytes"
        End Select
    End Function

End Module
