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
Imports System.IO.Compression
Imports System.IO
Public Class Compression

    Public Shared Function Compress(ByVal bytData() As Byte) As Byte()
        Using oMS As New MemoryStream()
            'GZip object that compress the file 
            Using oGZipStream As New GZipStream(oMS, CompressionMode.Compress)
                'Write to the Stream object from the buffer
                oGZipStream.Write(bytData, 0, bytData.Length)
                oGZipStream.Close()
                ReDim bytData(oMS.ToArray.Length - 1)
                bytData = oMS.ToArray
            End Using
            oMS.Close()
        End Using
        Return bytData
    End Function

    Public Shared Function Decompress(ByVal bytData() As Byte) As Byte()
        Using oMS As New MemoryStream(bytData)
            Using oGZipStream As New GZipStream(oMS, CompressionMode.Decompress)
                Const CHUNK As Integer = 1024
                Dim intTotalBytesRead As Integer = 0
                Do
                    ' Enlarge the buffer.
                    ReDim Preserve bytData(intTotalBytesRead + CHUNK - 1)
                    ' Read the next chunk.
                    Dim intBytesRead As Integer = oGZipStream.Read(bytData, intTotalBytesRead, CHUNK)
                    intTotalBytesRead += intBytesRead
                    ' See if we're done.
                    If intBytesRead < CHUNK Then
                        ' We're done. Make the buffer fit the data.
                        ReDim Preserve bytData(intTotalBytesRead - 1)
                        Exit Do
                    End If
                Loop
                oGZipStream.Close()
            End Using
            oMS.Close()
        End Using
        Return bytData
    End Function

End Class
