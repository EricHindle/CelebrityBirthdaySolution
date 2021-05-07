Module ModExtractDate
    Public Function ExtractCbdatesFromWikiExtract(wikiExtract As String) As List(Of CbDates)
        Dim cbdates As New List(Of CbDates)
        Dim _blocks As List(Of String) = ParseStringWithBrackets(wikiExtract)
        Dim isBracketsFound As Boolean = True
        Do Until Not isBracketsFound
            If _blocks.Count = 3 Then
                Dim _dateString As String = _blocks(1)
                If Not String.IsNullOrEmpty(_dateString) Then
                    Dim _semiSplit As String() = Split(_dateString, ";")
                    For Each _semi As String In _semiSplit
                        If Not String.IsNullOrEmpty(_semi) Then
                            Dim isInnerBracketsFound As Boolean = True
                            Dim isOs As Boolean = False
                            Do Until Not isInnerBracketsFound
                                Dim testStringParts As List(Of String) = ParseStringWithBrackets(_semi)
                                isInnerBracketsFound = testStringParts.Count = 3
                                If isInnerBracketsFound Then
                                    If IsStringContainsOs(testStringParts(1)) Then
                                        isOs = True
                                    End If
                                    _semi = testStringParts(0) & testStringParts(2)
                                End If
                            Loop
                            Dim splitDates As String() = Split(FixQuotesAndHyphens(_semi, True), " - ", 2)
                            Dim birthString As String = splitDates(0).ToLower.Replace("born", "").Replace("  ", " ").Trim
                            Dim deathString As String = String.Empty
                            If splitDates.Length = 2 Then
                                deathString = splitDates(1).ToLower.Replace("  ", " ").Trim
                            End If
                            Dim _cbDates As CbDates = BuildCbDatesFromStrings(birthString, deathString, isOs)
                            If _cbDates.BirthDate.IsValidDate Then
                                cbdates.Add(_cbDates)
                            End If
                        Else
                        End If
                    Next
                Else
                    LogUtil.Problem("Wiki extract has empty brackets", "ExtractCbdatesFromWikiExtract")
                End If
                _blocks = ParseStringWithBrackets(_blocks(2))
            ElseIf _blocks.Count = 2 Then
                isBracketsFound = False
                LogUtil.Problem("Wiki extract has missing closing bracket", "ExtractCbdatesFromWikiExtract")
                LogUtil.Problem(wikiExtract, "ExtractCbdatesFromWikiExtract")
            ElseIf _blocks.Count = 1 Then
                isBracketsFound = False
            End If
        Loop
        Return cbdates
    End Function

    Private Function BuildCbDatesFromStrings(birthString As String, deathString As String, isOsFound As Boolean) As CbDates
        Dim _cbDates As New CbDates With {
            .BirthDate = FindDateInString(birthString, isOsFound),
            .DeathDate = FindDateInString(deathString, False)
        }
        Return _cbDates
    End Function
    Private Function FindDateInString(possibleDateString As String, isOsFound As Boolean)
        Dim _cbDate As New CbDate
        Dim isOs As Boolean = isStringContainsOs(possibleDateString) Or isOsFound
        Dim isBc As Boolean = isStringContainsBc(possibleDateString)
        If IsDate(possibleDateString) Then
            _cbDate.DateValue = CDate(possibleDateString)
            _cbDate.DateString = possibleDateString
            _cbDate.IsValidDate = True
        Else
            Dim _words As List(Of String) = Split(possibleDateString, " ").ToList
            For index As Integer = _words.Count - 1 To 0 Step -1
                If String.IsNullOrEmpty(_words(index).Trim) Then
                    _words.RemoveAt(index)
                End If
            Next
            If _words.Count >= 3 Then
                For w As Integer = 0 To _words.Count - 3
                    Dim _testDate As String = _words(w) & " " & _words(w + 1) & " " & _words(w + 2)
                    If IsDate(_testDate) Then
                        _cbDate.DateValue = CDate(_testDate)
                        _cbDate.DateString = _testDate
                        Exit For
                    End If
                Next
            End If
        End If
        Return _cbDate
    End Function

    Private Function IsStringContainsBc(birthString As String) As Boolean
        Return birthString.ToLower.Contains("bc")
    End Function

    Private Function IsStringContainsOs(birthString As String) As Boolean
        Return birthString.ToLower.Contains("os") Or birthString.ToLower.Contains("o.s.")
    End Function
End Module
