Public Class FrmBrowser
#Region "properties"
    Private _searchName As String
    Private _url As Uri
    Public Property Url() As Uri
        Get
            Return _url
        End Get
        Set(ByVal value As Uri)
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
#End Region
#Region "form control handlers"
    Private Sub BtnWikiFind_Click(sender As Object, e As EventArgs) Handles btnWikiFind.Click
        If Not String.IsNullOrEmpty(TxtSearchName.Text) Then
            _searchName = TxtSearchName.Text
            FindinWiki()
        End If
    End Sub
    Private Sub BtnImageFind_Click(sender As Object, e As EventArgs) Handles btnImageFind.Click
        If Not String.IsNullOrEmpty(TxtSearchName.Text) Then
            _searchName = TxtSearchName.Text
            FindImages()
        End If
    End Sub
    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        lblNav.Text = My.Resources.COMPLETE
        txtURL.Text = WebBrowser1.Url.AbsoluteUri
    End Sub
    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        WebBrowser1.GoBack()
    End Sub
    Private Sub BtnFwd_Click(sender As Object, e As EventArgs) Handles btnFwd.Click
        WebBrowser1.GoForward()
    End Sub
    Private Sub BtnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        WebBrowser1.Navigate(New Uri(txtURL.Text))
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
    Private Sub FrmBrowser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        WebBrowser1.Stop()
        My.Settings.bwsrformpos = SetFormPos(Me)
        My.Settings.Save()
        Me.Dispose()
    End Sub
#End Region
#Region "subroutines"
    Public Sub FindinWiki()
        NavigateToUrl(GetWikiSearchString(_searchName))
    End Sub
    Public Sub FindImages()
        NavigateToUrl(GetGoogleSearchString(_searchName))
    End Sub
    Public Sub FindInTwitter()
        NavigateToUrl(GetTwitterSearchString(_searchName))
    End Sub
    Public Sub NavigateToUrl(pSearchString As String)
        Dim _uri As New Uri(pSearchString)
        lblNav.Text = "Finding " & _searchName
        TxtSearchName.Text = _searchName
        WebBrowser1.Navigate(_uri)
    End Sub
    Private Sub FrmBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.bwsrformpos)
    End Sub
#End Region
End Class