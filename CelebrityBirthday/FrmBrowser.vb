Public Class FrmBrowser
    Private _searchName As String
    Private _url As String
    Public Property Url() As String
        Get
            Return _url
        End Get
        Set(ByVal value As String)
            _url = value
        End Set
    End Property
    Public Property SearchName() As String
        Get
            Return _searchName
        End Get
        Set(ByVal value As String)
            _searchName = value
        End Set
    End Property
    Private Sub btnWikiFind_Click(sender As Object, e As EventArgs) Handles btnWikiFind.Click
        If Not String.IsNullOrEmpty(TxtSearchName.Text) Then
            _searchName = TxtSearchName.Text
            FindinWiki()
        End If
    End Sub
    Public Sub FindinWiki()
        Dim searchstring As String = My.Settings.wikiSearchUrl
        _url = searchstring & _searchName
        lblNav.Text = "Finding " & _searchName
        WebBrowser1.Navigate(_url)
    End Sub

    Private Sub BtnImageFind_Click(sender As Object, e As EventArgs) Handles btnImageFind.Click
        If Not String.IsNullOrEmpty(TxtSearchName.Text) Then
            _searchName = TxtSearchName.Text
            FindImages()
        End If
    End Sub
    Public Sub FindImages()
        _url = GetGoogleSearchString(_searchName)
        lblNav.Text = "Finding " & _searchName
        WebBrowser1.Navigate(_url)
    End Sub
    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        lblNav.Text = "Complete"
        txtURL.Text = WebBrowser1.Url.AbsoluteUri
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        WebBrowser1.GoBack()
    End Sub

    Private Sub btnFwd_Click(sender As Object, e As EventArgs) Handles btnFwd.Click
        WebBrowser1.GoForward()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        WebBrowser1.Navigate(txtURL.Text)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnFindTwitter_Click(sender As Object, e As EventArgs) Handles BtnFindTwitter.Click
        If Not String.IsNullOrEmpty(TxtSearchName.Text) Then
            _searchName = TxtSearchName.Text

            FindInTwitter()
        End If
    End Sub

    Public Sub FindInTwitter()
        lblNav.Text = "Finding " & _searchName
        _url = GetTwitterSearchString(_searchName)
        lblNav.Text = "Finding " & _searchName
        WebBrowser1.Navigate(_url)
    End Sub

    Private Sub FrmBrowser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        WebBrowser1.Stop()
        Me.Dispose()
    End Sub
End Class