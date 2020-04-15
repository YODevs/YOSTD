Imports System.IO

Public Class FileIO
    Public Shared Function FileOpen(path As String) As String
        If File.Exists(path) Then
            Return File.ReadAllText(path)
        Else
            Throw New Exception(path & " not founded .")
            Return False
        End If
    End Function

    Public Shared Function FileExists(path As String) As Boolean
        Return File.Exists(path)
    End Function

    Public Shared Function FileDelete(path As String) As Boolean
        If File.Exists(path) Then
            File.Delete(path)
            Return True
        Else
            Throw New Exception(path & " not founded .")
        End If
        Return False
    End Function

    Public Shared Function FileCopy(sourceLocation As String, newLocation As String) As Boolean
        If File.Exists(sourceLocation) Then
            File.Copy(sourceLocation, newLocation, True)
            Return True
        Else
            Throw New Exception(sourceLocation & " not founded .")
        End If
        Return False
    End Function

    Public Shared Function FileMove(sourceLocation As String, newLocation As String) As Boolean
        If File.Exists(sourceLocation) Then
            File.Move(sourceLocation, newLocation)
            Return True
        Else
            Throw New Exception(sourceLocation & " not founded .")
        End If
        Return False
    End Function

    Public Shared Function FileRename(path As String, newFilename As String) As Boolean
        If FileExists(path) Then
            My.Computer.FileSystem.RenameFile(path, newFilename)
            Return True
        Else
            Throw New Exception(path & " not founded .")
            Return False
        End If
    End Function

    Public Shared Sub FileWrite(path As String, text As String)
        File.WriteAllText(path, text)
    End Sub

    Public Shared Sub CreateDirectory(path As String)
        Directory.CreateDirectory(path)
    End Sub

    Public Shared Function DirectoryExists(path As String) As Boolean
        Return Directory.Exists(path)
    End Function

    Public Shared Function DirectoryDelete(path As String) As Boolean
        If Directory.Exists(path) Then
            Directory.Delete(path)
            Return True
        Else
            Throw New Exception(path & " - directory not found for option .")
            Return False
        End If
    End Function

    Public Shared Function DirectoryCopy(sourceLocation As String, newLocation As String) As Boolean
        If Directory.Exists(sourceLocation) Then
            My.Computer.FileSystem.CopyDirectory(sourceLocation, newLocation, True)
            Return True
        Else
            Throw New Exception(sourceLocation & " - directory not found for option .")
            Return False
        End If
    End Function

    Public Shared Function DirectoryMove(sourceLocation As String, newLocation As String) As Boolean
        If Directory.Exists(sourceLocation) Then
            My.Computer.FileSystem.MoveDirectory(sourceLocation, newLocation)
            Return True
        Else
            Throw New Exception(sourceLocation & " - directory not found for option .")
            Return False
        End If
    End Function

    Public Shared Function GetFiles(path As String) As String
        If Directory.Exists(path) Then
            Return YODA_Format.WriteYODA(New ArrayList(Directory.GetFiles(path)))
        Else
            Throw New Exception(path & " - directory not found for option .")
        End If
        Return False
    End Function

    Public Shared Function GetDirectories(path As String) As String
        If Directory.Exists(path) Then
            Return YODA_Format.WriteYODA(New ArrayList(Directory.GetDirectories(path)))
        Else
            Throw New Exception(path & " - directory not found for option .")
        End If
        Return False
    End Function



End Class
