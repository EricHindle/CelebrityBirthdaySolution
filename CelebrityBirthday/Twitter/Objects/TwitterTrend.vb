
''' <summary>
''' A trend currently tracked by Twitter
''' </summary>
''' <remarks></remarks>
Public Class TwitterTrend
        Private _TrendName As String = String.Empty
        Private _TrendText As String = String.Empty
        Private _AsOf As DateTime

        ''' <summary>
        ''' The name of the trend, as displayed on the Twitter website
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TrendName() As String
            Get
                Return _TrendName
            End Get
            Set(ByVal value As String)
                _TrendName = value
            End Set
        End Property

        ''' <summary>
        ''' Either the URL of a Twitter search, or the terms of a Twitter search, depending on which Trends method was called.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>
        ''' The Twitter API returns different information for different trends requests.
        ''' <para/>
        ''' If you called <c>Trends()</c>, this is a URL to a Twitter search.
        ''' <para/>
        ''' If you called <c>TrendsCurrent()</c>, <c>TrendsDaily()</c> or <c>TrendsWeekly()</c>, this is a Twitter search string.
        ''' </remarks>
        Public Property TrendText() As String
            Get
                Return _TrendText
            End Get
            Set(ByVal value As String)
                _TrendText = value
            End Set
        End Property

        ''' <summary>
        ''' The effective date of the Twitter trend.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>
        ''' If you called <c>TrendsDaily()</c> or <c>TrendsWeekly()</c>, you will usually see multiple trends in the list with different dates.
        ''' For more information, see <a href="http://apiwiki.twitter.com/Twitter-Search-API-Method:-trends-daily">http://apiwiki.twitter.com/Twitter-Search-API-Method:-trends-daily</a>
        ''' or <a href="http://apiwiki.twitter.com/Twitter-Search-API-Method:-trends-weekly">http://apiwiki.twitter.com/Twitter-Search-API-Method:-trends-weekly</a>
        ''' </remarks>
        Public Property AsOf() As DateTime
            Get
                Return _AsOf
            End Get
            Set(ByVal value As DateTime)
                _AsOf = value
            End Set
        End Property

        ''' <summary>
        ''' Creates a <c>TwitterTrend</c> object.
        ''' </summary>
        ''' <param name="Name">The name of the trend.</param>
        ''' <param name="Text">The text of the trend.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Name As String, ByVal Text As String)
            Me._TrendName = Name
            Me._TrendText = Text
        End Sub
    End Class

