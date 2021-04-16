'
' Copyright (c) 2020 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2020
Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Threading
Public NotInheritable Class LogUtil
#Region "properties"
    Private Shared _LogFolder As String
    Public Shared Property LogFolder() As String
        Get
            Return _LogFolder
        End Get
        Set(ByVal value As String)
            _LogFolder = value
        End Set
    End Property
#End Region
#Region "Start / stop"
    Public Shared Sub InitialiseLogging()
        LogFolder = My.Settings.LogFolder
        My.Application.Log.DefaultFileLogWriter.LogFileCreationSchedule = Logging.LogFileCreationScheduleOption.Daily
        If _LogFolder IsNot Nothing Then
            My.Application.Log.DefaultFileLogWriter.CustomLocation = _LogFolder
        End If
        My.Application.Log.DefaultFileLogWriter.Append = True
        My.Application.Log.DefaultFileLogWriter.AutoFlush = True
        My.Application.Log.DefaultFileLogWriter.ReserveDiskSpace = 50000000
    End Sub
    Public Shared Sub StartLogging()
        Info("=".PadRight(40, "="))
        Info(My.Application.Info.Title & " version " & My.Application.Info.Version.ToString)
        Info(My.Application.Info.Copyright)
        Info("Logging started at " & Format(Now, "dd/MM/yyyy HH:mm:ss"))
    End Sub
    Public Shared Sub StopLogging()
        Info("Logging stopped at " & Format(Now, "dd/MM/yyyy HH:mm:ss"))
        Info("=".PadRight(40, "="))
        My.Application.Log.DefaultFileLogWriter.Flush()
        My.Application.Log.DefaultFileLogWriter.Close()
    End Sub
#End Region
#Region "Add log"
    Public Shared Sub AddLog(ByVal sText As String, Optional ByVal severity As TraceEventType = TraceEventType.Information, Optional ByVal sSub As String = "", Optional ByVal errorCode As String = Nothing, Optional ByRef padCt As Integer = 0)
        InitialiseLogging()
        Dim thisThread As String = "{" & CStr(Thread.CurrentThread.ManagedThreadId) & "} "
        padCt += (6 - thisThread.Length)
        Dim sPad As String = "".PadRight(padCt)
        Dim sPrefix As String = sPad & thisThread & My.Computer.Clock.LocalTime.ToString(myStringFormatProvider) & " - "
        If Not String.IsNullOrEmpty(sSub) Then
            sPrefix += "(" & sSub & ") "
        End If
        If Not String.IsNullOrEmpty(errorCode) Then
            sPrefix += "Error code: " & errorCode & " "
        End If
        Try
            My.Application.Log.WriteEntry(sPrefix & sText, severity)
        Catch ex As InvalidEnumArgumentException
        Catch ex As Security.SecurityException
        End Try
    End Sub
    Public Shared Sub AddExceptionLog(ByVal ex As Exception, ByVal sText As String, Optional ByVal eventType As TraceEventType = TraceEventType.Error, Optional ByVal sSub As String = "", Optional ByVal errorCode As String = Nothing, Optional ByRef padCt As Integer = 0)
        InitialiseLogging()
        Dim exMessage As String = If(ex Is Nothing, "no excepion message", ex.Message)
        Dim sErrorText = sText & " : Exception - " & exMessage
        AddLog(sErrorText, eventType, sSub, errorCode, padCt)
    End Sub
    Public Shared Sub Info(ByVal pStr As String, Optional ByVal psub As String = "")
        AddLog(pStr, TraceEventType.Information, psub)
    End Sub
    Public Shared Sub Warn(ByVal pStr As String, Optional ByVal psub As String = "")
        AddLog(pStr, TraceEventType.Warning, psub, , 4)
    End Sub
    Public Shared Sub Problem(ByVal pStr As String, Optional ByVal psub As String = "", Optional ByVal errorCode As String = Nothing)
        AddLog(pStr, TraceEventType.Error, psub, errorCode, 6)
    End Sub
    Public Shared Sub Debug(ByVal pStr As String, Optional ByVal psub As String = "")
        Dim pad As Integer = 4
        Dim level As TraceEventType = TraceEventType.Verbose
        AddLog(pStr, level, psub, , pad)
    End Sub
    Public Shared Sub Fatal(ByVal pStr As String, Optional ByVal psub As String = "", Optional ByVal errorCode As String = Nothing)
        AddLog(pStr, TraceEventType.Critical, psub, errorCode, 3)
    End Sub
    Public Shared Sub Exception(ByVal pStr As String, ByVal pEx As Exception, Optional ByVal psub As String = "", Optional ByVal errorCode As String = Nothing)
        AddExceptionLog(pEx, pStr, TraceEventType.Error, psub, errorCode, 6)
    End Sub
#End Region
#Region "Log file"
    Public Shared Function GetLogfileName() As String
        Return My.Application.Log.DefaultFileLogWriter.FullLogFileName
    End Function
    Public Shared Function GetLogfileName(newDate As Date) As String
        Return Path.Combine(LogUtil.LogFolder, My.Application.Log.DefaultFileLogWriter.BaseFileName & "-" & Format(newDate, "yyyy-MM-dd") & ".log")
    End Function
    Public Shared Sub ClearLogFile()
        Dim sLogFile As String = GetLogfileName()
        My.Application.Log.DefaultFileLogWriter.Close()
        Using sr As New StreamWriter(sLogFile, False)
            sr.Write("")
        End Using
        StartLogging()
        LogUtil.Info("Log file cleared by " & My.User.Name & " on " & Format(Now, "dd/MM/yyyy HH:mm:ss"))
    End Sub
    Public Shared Function GetLogContents() As String
        Dim sLogFile As String = GetLogfileName()
        My.Application.Log.DefaultFileLogWriter.Close()
        GetLogContents = My.Computer.FileSystem.ReadAllText(sLogFile)
        My.Application.Log.DefaultFileLogWriter.Write("")
    End Function

#End Region
End Class
