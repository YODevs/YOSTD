Imports System.IO
Imports System.Net
Imports System.Security.Authentication

Public Class HTTP

    Public webRequest As HttpWebRequest
    Public webResult As WebResponse
    Public streamRD As StreamReader
    Private httpRequestState As Boolean = False
    Public statusCode As Int32
    Public charSet, contentEncoding, contentLength, contentType, method, server, protocolVersion, status As String

    Public Sub New()
        ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
        webRequest = HttpWebRequest.Create("http://localhost")
    End Sub

    Public Sub Create(link As String)
        webRequest = HttpWebRequest.Create(link)
        httpRequestState = True
    End Sub

    Public Function GetResponse() As String
        If httpRequestState = False Then
            Throw New Exception("First, call the 'create($cust _link)' method.")
            Return Nothing
        End If
        webResult = webRequest.GetResponse()

        statusCode = CType(webResult, HttpWebResponse).StatusCode
        charSet = CType(webResult, HttpWebResponse).CharacterSet
        contentLength = CType(webResult, HttpWebResponse).ContentLength
        contentEncoding = CType(webResult, HttpWebResponse).ContentEncoding
        contentType = CType(webResult, HttpWebResponse).ContentType
        method = CType(webResult, HttpWebResponse).Method
        protocolVersion = CType(webResult, HttpWebResponse).ProtocolVersion.ToString
        server = CType(webResult, HttpWebResponse).Server
        status = CType(webResult, HttpWebResponse).StatusDescription

        If statusCode = 200 Then
            streamRD = New StreamReader(webResult.GetResponseStream())
            Return streamRD.ReadToEnd()
        End If

        Return Nothing
    End Function

    Public Property refer() As String
        Get
            Return webRequest.Referer
        End Get
        Set(ByVal value As String)
            webRequest.Referer = value
        End Set
    End Property

    Public Property userAgent() As String
        Get
            Return webRequest.UserAgent
        End Get
        Set(ByVal value As String)
            webRequest.UserAgent = value
        End Set
    End Property

    Public Property allowAutoRediret() As String
        Get
            Return webRequest.AllowAutoRedirect
        End Get
        Set(ByVal value As String)
            webRequest.AllowAutoRedirect = value
        End Set
    End Property

    Public Property timeout() As Integer
        Get
            Return webRequest.Timeout
        End Get
        Set(ByVal value As Integer)
            webRequest.Timeout = value
        End Set
    End Property

    Public Property KeepAlive() As Boolean
        Get
            Return webRequest.KeepAlive
        End Get
        Set(ByVal value As Boolean)
            webRequest.KeepAlive = value
        End Set
    End Property


End Class
