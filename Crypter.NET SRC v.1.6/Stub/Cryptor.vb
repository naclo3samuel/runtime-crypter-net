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
Imports System.Security
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Namespace Cryptor

    Public Class RijnDael

        Public Shared Function Decrypt(ByVal sData As String, ByVal sKey As String)
            Dim bytData() As Byte = Encoding.ASCII.GetBytes(sData)
            Return Decrypt(bytData, sKey)
        End Function
        Public Shared Function Decrypt(ByVal bytData As Byte(), ByVal strPass As String) As Byte()
            Dim bytResult As Byte()
            Using oRM As New System.Security.Cryptography.RijndaelManaged
                oRM.KeySize = 256
                oRM.Key = GeKey(strPass)
                oRM.IV = GetIV(strPass)
                '
                Using oMS As New MemoryStream(bytData)
                    Using oCS As New Cryptography.CryptoStream(oMS, oRM.CreateDecryptor, Security.Cryptography.CryptoStreamMode.Read)
                        Dim TempDecryptArr As Byte()
                        ReDim TempDecryptArr(bytData.Length)
                        Dim decryptedByteCount As Integer
                        decryptedByteCount = oCS.Read(TempDecryptArr, 0, bytData.Length)
                        '
                        ReDim bytResult(decryptedByteCount)
                        Array.Copy(TempDecryptArr, bytResult, decryptedByteCount)
                        '
                        oCS.Close()
                    End Using
                    oMS.Close()
                End Using
            End Using
            Return bytResult
        End Function

        Public Shared Function Encrypt(ByVal sData As String, ByVal sKey As String)
            Dim bytData() As Byte = Encoding.ASCII.GetBytes(sData)
            Return Encrypt(bytData, sKey)
        End Function
        Public Shared Function Encrypt(ByVal bytData As Byte(), ByVal strPass As String) As Byte()
            Dim bytResult As Byte()
            Using oRM As New Cryptography.RijndaelManaged
                oRM.KeySize = 256
                oRM.Key = GeKey(strPass)
                oRM.IV = GetIV(strPass)
                '
                Using oMS As New MemoryStream
                    Using oCS As New Cryptography.CryptoStream(oMS, oRM.CreateEncryptor, Cryptography.CryptoStreamMode.Write)
                        oCS.Write(bytData, 0, bytData.Length)
                        oCS.FlushFinalBlock()
                        bytResult = oMS.ToArray()
                        oCS.Close()
                    End Using
                    oMS.Close()
                End Using
            End Using
            Return bytResult
        End Function

        Private Shared Function GeKey(ByVal strPass As String) As Byte()
            Dim bytResult As Byte()
            'Generate a byte array of required length as the encryption key.
            'A SHA256 hash of the passphrase has just the required length. It is used twice in a manner of self-salting.
            Using oSHA256 As New Cryptography.SHA256Managed
                Dim L1 As String = System.Convert.ToBase64String(oSHA256.ComputeHash(Encoding.UTF8.GetBytes(strPass)))
                Dim L2 As String = strPass & L1
                bytResult = oSHA256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(L2))
                oSHA256.Clear()
            End Using
            Return bytResult
        End Function

        Private Shared Function GetIV(ByVal strPass As String) As Byte()
            Dim bytResult As Byte()
            'Generate a byte array of required length as the iv.
            'A MD5 hash of the passphrase has just the required length. It is used twice in a manner of self-salting.
            Using oMD5 As New Cryptography.MD5CryptoServiceProvider
                Dim L1 As String = System.Convert.ToBase64String(oMD5.ComputeHash(Encoding.UTF8.GetBytes(strPass)))
                Dim L2 As String = strPass & L1
                bytResult = oMD5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(L2))
                oMD5.Clear()
            End Using
            Return bytResult
        End Function

    End Class

    Public Class RC4

        Public Shared Function Encrypt(ByVal bytData() As Byte, ByVal sPassword As String) As Byte()
            Return RC4EnDeCrypt(bytData, StrToByteArray(sPassword))
        End Function

        Public Shared Function Decrypt(ByVal bytData() As Byte, ByVal sPassword As String) As Byte()
            Return RC4EnDeCrypt(bytData, StrToByteArray(sPassword))
        End Function

        ' RC4 encryption and decryption.
        Private Shared Function RC4EnDeCrypt(ByVal plaintxt As Byte(), ByVal password As Byte()) As Byte()
            Dim k As Int32
            Dim a, i, j As Int32
            Dim cipher As Byte()
            ReDim cipher(plaintxt.Length)

            Dim sbox(256) As Int32
            Dim temp As Int32

            i = 0
            j = 0
            RC4Initialize(password, sbox)
            For a = 0 To plaintxt.Length - 1
                i = (i + 1) Mod 256
                j = (j + sbox(i)) Mod 256
                'Swap
                temp = sbox(i)
                sbox(i) = sbox(j)
                sbox(j) = temp
                'Get the output
                k = sbox((sbox(i) + sbox(j)) Mod 256)
                plaintxt(a) = plaintxt(a) Xor Convert.ToByte(k)
            Next

            Return plaintxt
        End Function

        ' This routine called by EnDeCrypt function. Initializes the
        'sbox and the key array)
        Protected Shared Sub RC4Initialize(ByVal key As Byte(), ByRef sbox As Int32())
            Dim tempSwap As Int32
            Dim i, j, l As Int32
            l = key.Length

            For i = 0 To 255
                sbox(i) = i
            Next
            j = 0
            For i = 0 To 255
                j = (j + sbox(i) + key(i Mod l)) Mod 256
                tempSwap = sbox(i)
                sbox(i) = sbox(j)
                sbox(j) = tempSwap
            Next
        End Sub

        Private Shared Function StrToByteArray(ByVal str As String) As Byte()
            Dim oEnc As New System.Text.ASCIIEncoding()
            Return oEnc.GetBytes(str)
        End Function

        Private Shared Function ByteArrayToStr(ByVal dBytes() As Byte) As String
            Dim oEnc As New System.Text.ASCIIEncoding()
            Return oEnc.GetString(dBytes)
        End Function

    End Class

    Public Class MD5

        ' Encrypt a string using dual encryption method. Return a encrypted cipher Text
        Public Shared Function Encrypt(ByVal bytData() As Byte, _
                                        ByVal sKey As String, _
                               Optional ByVal tMode As CipherMode = CipherMode.ECB, _
                               Optional ByVal tPadding As PaddingMode = PaddingMode.PKCS7) As Byte()
            Dim keyArray As Byte()

            Dim hashmd5 As New MD5CryptoServiceProvider()
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(sKey))
            hashmd5.Clear()

            Dim tdes As New TripleDESCryptoServiceProvider()
            tdes.Key = keyArray
            tdes.Mode = tMode
            tdes.Padding = tPadding

            Dim cTransform As ICryptoTransform = tdes.CreateEncryptor()
            Dim resultArray As Byte() = cTransform.TransformFinalBlock(bytData, 0, bytData.Length)
            tdes.Clear()
            Return resultArray
        End Function

        ' DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        Public Shared Function Decrypt(ByVal bytData() As Byte, _
                                       ByVal sKey As String, _
                              Optional ByVal tMode As CipherMode = CipherMode.ECB, _
                              Optional ByVal tPadding As PaddingMode = PaddingMode.PKCS7) As Byte()
            Dim keyArray As Byte()
            Dim hashmd5 As New MD5CryptoServiceProvider()
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(sKey))
            hashmd5.Clear()

            Dim tdes As New TripleDESCryptoServiceProvider()
            tdes.Key = keyArray
            tdes.Mode = tMode
            tdes.Padding = tPadding

            Dim cTransform As ICryptoTransform = tdes.CreateDecryptor()
            Dim resultArray As Byte() = cTransform.TransformFinalBlock(bytData, 0, bytData.Length)
            tdes.Clear()
            Return resultArray
        End Function

    End Class

    Public Class [XOR]

        Public Shared Function Encrypt(ByVal bytData() As Byte, ByVal sPassword As String) As Byte()
            Return EncryptDecrypt(bytData, sPassword)
        End Function

        Public Shared Function Decrypt(ByVal bytData() As Byte, ByVal sPassword As String) As Byte()
            Return EncryptDecrypt(bytData, sPassword)
        End Function

        Private Shared Function EncryptDecrypt(ByVal bytData() As Byte, ByVal sPassword As String) As Byte()
            Dim bytRet(bytData.Length - 1) As Byte
            For i As Integer = 0 To bytData.Length - 1
                bytRet(i) = bytData(i) Xor Asc(sPassword.Substring(i Mod sPassword.Length, 1))
            Next
            Return bytRet
        End Function

    End Class

    Public Class Base64

        Public Shared Function Encrypt(ByVal bytData() As Byte) As Byte()
            Dim oEnc As New System.Text.ASCIIEncoding()
            Return oEnc.GetBytes(Convert.ToBase64String(bytData))
        End Function

        Public Shared Function Decrypt(ByVal bytData() As Byte) As Byte()
            Dim oEnc As New System.Text.ASCIIEncoding()
            Return Convert.FromBase64String(oEnc.GetString(bytData))
        End Function

    End Class

End Namespace
