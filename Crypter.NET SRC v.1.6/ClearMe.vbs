'************************************ 
'         c0DeD bY fLaSh 			'
'  	 © Copyright 2010 Carlos.DF		'
'       c4rl0s.pt@gmail.com			'
'************************************
Option Explicit

'On Error Resume Next
' Limpa as DIR's Temp, geradas por o visual studio..
'Call DelTree ("Api.Assembly\bin", False)
'Call DelTree ("Api.Assembly\obj", False)

Call DelTree ("Crypter.NET\bin", False)
Call DelTree ("Crypter.NET\obj", False)

Call DelTree ("Stub\bin", False)
Call DelTree ("Stub\obj", False)

Call DelTree ("Stub.Compressor\bin", False)
Call DelTree ("Stub.Compressor\obj", False)

Call DelTree ("Stub.Suiecide\bin", False)
Call DelTree ("Stub.Suiecide\obj", False)

Call DelTree ("Released", True)
Call DelTree ("Released Stub", True)

Sub DelTree( myFolder, blnKeepRoot )
    Dim arrSpecialFolders(3)
    Dim objMyFSO, objMyFile, objMyFolder, objMyShell
    Dim objPrgFolder, objPrgFolderItem, objSubFolder, wshMyShell
    Dim strPath, strSpecialFolder
	
    Const WINDOWS_FOLDER =  0
    Const SYSTEM_FOLDER  =  1
    Const PROGRAM_FILES  = 38
	
    ' Use custom error handling
    On Error Resume Next
	
    ' List the paths of system folders that should NOT be deleted
    Set wshMyShell       = CreateObject( "WScript.Shell" )
    Set objMyFSO         = CreateObject( "Scripting.FileSystemObject" )
    Set objMyShell       = CreateObject( "Shell.Application" )
    Set objPrgFolder     = objMyShell.Namespace( PROGRAM_FILES )
    Set objPrgFolderItem = objPrgFolder.Self
	
    arrSpecialFolders(0) = wshMyShell.SpecialFolders( "MyDocuments" )
    arrSpecialFolders(1) = objPrgFolderItem.Path
    arrSpecialFolders(2) = objMyFSO.GetSpecialFolder( SYSTEM_FOLDER  ).Path
    arrSpecialFolders(3) = objMyFSO.GetSpecialFolder( WINDOWS_FOLDER ).Path
	
    Set objPrgFolderItem = Nothing
    Set objPrgFolder     = Nothing
    Set objMyShell       = Nothing
    Set wshMyShell       = Nothing
	
    ' Check if a valid folder was specified
    If Not objMyFSO.FolderExists( myFolder ) Then
        WScript.Echo "Error: path not found (" & myFolder & ")"
        WScript.Quit 1
    End If
    Set objMyFolder = objMyFSO.GetFolder( myFolder )
	
    ' Protect vital system folders and root directories from being deleted
    For Each strSpecialFolder In arrSpecialFolders
        If UCase( strSpecialFolder ) = UCase( objMyFolder.Path ) Then
            WScript.Echo "Error: deleting """ _
                       & objMyFolder.Path & """ is not allowed"
            WScript.Quit 1
        End If
    Next
	
    ' Protect root directories from being deleted
    If Len( objMyFolder.Path ) < 4 Then
        WScript.Echo "Error: deleting root directories is not allowed"
        WScript.Quit 1
    End If
	
    ' First delete the files in the directory specified
    For Each objMyFile In objMyFolder.Files
        strPath = objMyFile.Path
		objMyFSO.DeleteFile strPath, True
        If Err Then
            WScript.Echo "Error # " & Err.Number & vbCrLf _
                       & Err.Description         & vbCrLf _
                       & "(" & strPath & ")"     & vbCrLf
        End If
    Next
	
    ' Next recurse through the subfolders
    For Each objSubFolder In objMyFolder.SubFolders
        DelTree objSubFolder, False
    Next
	
    ' Finally, remove the "root" directory unless it should be preserved
    If Not blnKeepRoot Then
        strPath = objMyFolder.Path
        objMyFSO.DeleteFolder strPath, True
        If Err Then
            WScript.Echo "Error # " & Err.Number & vbCrLf _
                       & Err.Description         & vbCrLf _
                       & "(" & strPath & ")"     & vbCrLf
        End If
    End If
	
    ' Cleaning up the mess
    On Error Goto 0
    Set objMyFolder = Nothing
    Set objMyFSO    = Nothing
End Sub

WScript.Echo "Done..."
 