Public Class Search

       Public Sub EnumerateDirectories(RootDirectory As IO.DirectoryInfo, Directory As Action(Of IO.DirectoryInfo))
        For Each item In RootDirectory.EnumerateDirectories
            Directory(item)
        Next
    End Sub
    Public Sub EnumerateFiles(RootDirectory As IO.DirectoryInfo, File As Action(Of IO.FileInfo))
        For Each item In RootDirectory.EnumerateFiles
            File(item)
        Next
    End Sub


End Class