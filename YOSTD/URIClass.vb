Public Class URI
    Dim uriWrp As System.Uri
    Dim intialObject As Boolean = False
    Public Sub New()
    End Sub

    Public Sub Create(uriStr As String)
        uriWrp = New System.Uri(uriStr)
        intialObject = True
    End Sub

    Public ReadOnly Property absolutePath() As String
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.AbsolutePath
        End Get
    End Property


    Public ReadOnly Property absoluteUri() As String
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.AbsoluteUri
        End Get
    End Property



    Public ReadOnly Property authority() As String
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.Authority
        End Get
    End Property

    Public ReadOnly Property dnsSafeHost() As String
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.DnsSafeHost
        End Get
    End Property



    Public ReadOnly Property fragment() As String
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.Fragment
        End Get
    End Property



    Public ReadOnly Property host() As String
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.Host
        End Get
    End Property

    Public ReadOnly Property isAbsoluteUri() As Boolean
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.IsAbsoluteUri
        End Get
    End Property
    Public ReadOnly Property isDefaultPort() As Boolean
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.IsDefaultPort
        End Get
    End Property

    Public ReadOnly Property isLoopback() As Boolean
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.IsLoopback
        End Get
    End Property


    Public ReadOnly Property isFile() As Boolean
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.IsFile
        End Get
    End Property

    Public ReadOnly Property isUnc() As Boolean
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.IsUnc
        End Get
    End Property

    Public ReadOnly Property localPath() As String
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.LocalPath
        End Get
    End Property

    Public ReadOnly Property originalString() As String
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.OriginalString
        End Get
    End Property
    Public ReadOnly Property pathAndQuery() As String
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.PathAndQuery
        End Get
    End Property
    Public ReadOnly Property port() As Integer
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.Port
        End Get
    End Property

    Public ReadOnly Property query() As String
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.Query
        End Get
    End Property

    Public ReadOnly Property scheme() As String
        Get
            If intialObject = False Then Throw New Exception("Before using the properties, must call create($cust uritext) method in the uri class.")
            Return uriWrp.Scheme
        End Get
    End Property

End Class
