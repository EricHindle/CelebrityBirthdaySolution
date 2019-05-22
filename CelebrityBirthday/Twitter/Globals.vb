''' <summary>
''' Global items that need to be visible to the entire library
''' </summary>
''' <remarks></remarks>
''' <exclude/>
Public Module Globals

        ''' <summary>
        ''' The number of API calls remaining in the current API period.
        ''' </summary>
        ''' <remarks></remarks>
        Public API_RemainingHits As String

        ''' <summary>
        ''' The total number of API calls allowed in the current API period.
        ''' </summary>
        ''' <remarks></remarks>
        Public API_HourlyLimit As String

        ''' <summary>
        ''' The time when the next API period starts and <c>RemainingHits</c> will reset.
        ''' </summary>
        ''' <remarks></remarks>
        Public API_Reset As String

        ''' <summary>
        ''' The username that will be passed to the default proxy server.
        ''' </summary>
        ''' <remarks></remarks>
        Public Proxy_Username As String = String.Empty

        ''' <summary>
        ''' The password that will be passed to the default proxy server.
        ''' </summary>
        ''' <remarks></remarks>
        Public Proxy_Password As String = String.Empty

        ''' <summary>
        ''' Specifies how to parse the response from the Trends methods of the Twitter API.
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum TrendFormat
            ''' <summary>
            ''' Returns the top ten topics that are currently trending on Twitter.
            ''' </summary>
            ''' <remarks></remarks>
            Trends

            ''' <summary>
            ''' Returns the current top 10 trending topics on Twitter.  The response includes the time of the request, the name of each trending topic, and query used on Twitter Search results page for that topic.
            ''' </summary>
            ''' <remarks></remarks>
            Current

            ''' <summary>
            ''' Returns the top 20 trending topics for each hour in a given day.
            ''' </summary>
            ''' <remarks></remarks>
            Daily

            ''' <summary>
            ''' Returns the top 30 trending topics for each day in a given week.
            ''' </summary>
            ''' <remarks></remarks>
            Weekly

            ''' <summary>
            ''' Returns the top 10 trending topics for given location.
            ''' </summary>
            ''' <remarks></remarks>
            ByLocation
        End Enum

        ''' <summary>
        ''' Specifies which Url shortening service to use.
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum UrlShortener

            

            ''' <summary>
            ''' Indicates that the Is.Gd service will be used.
            ''' </summary>
            ''' <remarks></remarks>
            IsGd

            ''' <summary>
            ''' Indicates that the TinyUrl service will be used.
            ''' </summary>
            ''' <remarks></remarks>
            TinyUrl
            ''' <summary>
            ''' Indicates that the Br.st service will be used.
            ''' </summary>
            ''' <remarks></remarks>
            BrSt
            ''' <summary>
            ''' Indicates that the bit.ly service will be used.
            ''' </summary>
            ''' <remarks></remarks>
            BitLy

        End Enum

        ''' <summary>
        ''' Controls whether a list is public or private.
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum ListMode
            ''' <summary>
            ''' Indicates that the list will be public.
            ''' </summary>
            ''' <remarks></remarks>
            [Public]

            ''' <summary>
            ''' Indicates that the list will be private.
            ''' </summary>
            ''' <remarks></remarks>
            [Private]
        End Enum

    End Module
