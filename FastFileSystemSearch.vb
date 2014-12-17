Public Class FastFileSystemSearch

    Public Property Settings As New Settings

    Public Sub Search(StartPath As String, Files As Action(Of IO.FileInfo), Folder As Action(Of IO.DirectoryInfo))

        Dim multi As New MultiThreading

        multi.Run(Sub()
                      Enumerate(StartPath, Files, Folder, multi)
                  End Sub)


    End Sub
    'Public Sub Search(StartPath As String, Files As Action(Of IO.FileInfo), Folder As Action(Of IO.DirectoryInfo))
    'End Sub

    Private Sub Enumerate(path As String, Files As Action(Of IO.FileInfo), Folder As Action(Of IO.DirectoryInfo), multi As MultiThreading)
        Dim _folder As New IO.DirectoryInfo(path)

        If Settings.SearchSubFolders Then
            If Settings.RunEventForFolders Then
                For Each item In _folder.EnumerateDirectories
                    multi.ThreadSafe(item, Sub(dir As IO.DirectoryInfo)
                                               Folder(dir)
                                           End Sub)
                    Enumerate(item.FullName, Files, Folder, multi)
                Next
            Else
                For Each item In _folder.EnumerateDirectories
                    Enumerate(item.FullName, Files, Folder, multi)
                Next
            End If
           
        End If

        If Settings.RunEventForFiles Then
            For Each item In _folder.EnumerateFiles
                multi.ThreadSafe(item, Sub(fil As IO.FileInfo)
                                           Files(fil)
                                       End Sub)
            Next
        End If

    End Sub




End Class

Public Class Settings

    Public Property SearchSubFolders As Boolean = True
    Public Property RunEventForFolders As Boolean = True
    Public Property RunEventForFiles As Boolean = True


End Class