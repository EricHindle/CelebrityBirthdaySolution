
''' <summary>
''' An individual search result
''' </summary>
''' <remarks>
''' The search API returns results that are very different than the rest of the API.  Although a <c>TwitterSearchResult</c> does represent a
''' tweet, it is not the same thing as a <c>TwitterStatus</c>.
''' </remarks>
Public Class TwitterSearchResult

#Region "Prvate Members"
        Private _ID As String = String.Empty
        Private _CreatedAt As DateTime
        Private _StatusUrl As String = String.Empty
        Private _Title As String = String.Empty
        Private _Content As String = String.Empty
        Private _ProfileImageUrl As String = String.Empty
        Private _Source As String = String.Empty
        Private _AuthorName As String = String.Empty
        Private _AuthorUrl As String = String.Empty
#End Region

#Region "Public Properties"
        ''' <summary>
        ''' The ID of the tweet.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ID() As Int64
            Get
                Dim Sections() As String = _ID.Split(Convert.ToChar(":"))
                Return Int64.Parse(Sections(2))
            End Get
        End Property

        ''' <summary>
        ''' The date and time that the tweet was created.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>
        ''' This is UTC time.
        ''' </remarks>
        Public ReadOnly Property CreatedAt() As DateTime
            Get
                Return _CreatedAt
            End Get
        End Property

        ''' <summary>
        ''' The date and time that the tweet was created.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>
        ''' This is local time.
        ''' </remarks>
        Public ReadOnly Property CreatedAtLocalTime() As DateTime
            Get
                Return _CreatedAt.ToLocalTime
            End Get
        End Property

        ''' <summary>
        ''' The Url of the tweet.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property StatusUrl() As String
            Get
                Return _StatusUrl
            End Get
        End Property

        ''' <summary>
        ''' The actual text of the tweet.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Title() As String
            Get
                Return _Title
            End Get
        End Property

        ''' <summary>
        ''' The text of the tweet, with some items rendered as HTML.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>
        ''' Usernames are rendered as links in this text.
        ''' </remarks>
        Public ReadOnly Property Content() As String
            Get
                Return _Content
            End Get
        End Property

        ''' <summary>
        ''' The Url of the avatar of the user who posted the tweet.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ProfileImageUrl() As String
            Get
                Return _ProfileImageUrl
            End Get
        End Property

        ''' <summary>
        ''' The source of the tweet.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>
        ''' This is usually the name of the application that posted the tweet.
        ''' </remarks>
        Public ReadOnly Property Source() As String
            Get
                Return _Source
            End Get
        End Property

        ''' <summary>
        ''' The screen name of the user who posted the tweet.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property AuthorName() As String
            Get
                Return _AuthorName
            End Get
        End Property

        ''' <summary>
        ''' The Url of the Twitter profile of the user who posted the tweet.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property AuthorUrl() As String
            Get
                Return _AuthorUrl
            End Get
        End Property

#End Region

        ''' <summary>
        ''' Creates a <c>TwitterSearchResult</c> object.
        ''' </summary>
        ''' <param name="SearchResultNode">An <c>XmlNode</c> from the Twitter API response representing a search result.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal SearchResultNode As Xml.XmlNode)
            Me._ID = SearchResultNode("id").InnerText

            If SearchResultNode("published") IsNot Nothing Then
                Me._CreatedAt = DateTime.Parse(SearchResultNode("published").InnerText)
            End If

            Dim Links As Xml.XmlNodeList = SearchResultNode.SelectNodes("link")
            If Links(0).Attributes("href") IsNot Nothing Then
                Me._StatusUrl = Links(0).Attributes("href").Value
            End If
            If Links(1).Attributes("href") IsNot Nothing Then
                Me._ProfileImageUrl = Links(1).Attributes("href").Value
            End If

            If SearchResultNode("source") IsNot Nothing Then
                Me._Source = SearchResultNode("source").InnerText
            End If

            If SearchResultNode("author") IsNot Nothing Then
                Dim AuthorName As String = SearchResultNode("author").ChildNodes(0).InnerText
                Me._AuthorName = AuthorName.Substring(0, AuthorName.IndexOf(" "))
                'Me._AuthorName = Left(AuthorName, AuthorName.IndexOf(" "))
                Me._AuthorUrl = SearchResultNode("author").ChildNodes(1).InnerText
            End If

            If SearchResultNode("title") IsNot Nothing Then
                Me._Title = SearchResultNode("title").InnerText
            End If

            If SearchResultNode("content") IsNot Nothing Then
                Me._Content = SearchResultNode("content").InnerText
            End If
        End Sub
    End Class

