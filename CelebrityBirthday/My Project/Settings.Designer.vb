﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.5.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property mainformpos() As String
            Get
                Return CType(Me("mainformpos"),String)
            End Get
            Set
                Me("mainformpos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property findformpos() As String
            Get
                Return CType(Me("findformpos"),String)
            End Get
            Set
                Me("findformpos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property callUpgrade() As Integer
            Get
                Return CType(Me("callUpgrade"),Integer)
            End Get
            Set
                Me("callUpgrade") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property imgbrowsepos() As String
            Get
                Return CType(Me("imgbrowsepos"),String)
            End Get
            Set
                Me("imgbrowsepos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property imgselectpos() As String
            Get
                Return CType(Me("imgselectpos"),String)
            End Get
            Set
                Me("imgselectpos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("F:\CelebrityBirthday\Images")>  _
        Public Property ImgPath() As String
            Get
                Return CType(Me("ImgPath"),String)
            End Get
            Set
                Me("ImgPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("F:\CelebrityBirthday\Images\new")>  _
        Public Property NewImagePath() As String
            Get
                Return CType(Me("NewImagePath"),String)
            End Get
            Set
                Me("NewImagePath") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=NETWYRKS_6-PC\SQLEXPRESS;Initial Catalog=CelebrityBirthday;Persist Se"& _ 
            "curity Info=True;User ID=sa;Password=dkk.sql")>  _
        Public ReadOnly Property CelebrityBirthdayConnectionString() As String
            Get
                Return CType(Me("CelebrityBirthdayConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("F:\CelebrityBirthday\Twitter")>  _
        Public Property TwitterFilePath() As String
            Get
                Return CType(Me("TwitterFilePath"),String)
            End Get
            Set
                Me("TwitterFilePath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property updformpos() As String
            Get
                Return CType(Me("updformpos"),String)
            End Get
            Set
                Me("updformpos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property imgformpos() As String
            Get
                Return CType(Me("imgformpos"),String)
            End Get
            Set
                Me("imgformpos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("https://www.google.com/search?tbm=isch&q=")>  _
        Public Property googleImageSearch() As String
            Get
                Return CType(Me("googleImageSearch"),String)
            End Get
            Set
                Me("googleImageSearch") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://celebritybirthday.files.wordpress.com/")>  _
        Public Property WordPressUrl() As String
            Get
                Return CType(Me("WordPressUrl"),String)
            End Get
            Set
                Me("WordPressUrl") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://en.wikipedia.org/w/index.php?search=")>  _
        Public Property wikiSearchUrl() As String
            Get
                Return CType(Me("wikiSearchUrl"),String)
            End Get
            Set
                Me("wikiSearchUrl") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("https://twitter.com/search?f=users&src=typd&q=")>  _
        Public Property TwitterSearchUrl() As String
            Get
                Return CType(Me("TwitterSearchUrl"),String)
            End Get
            Set
                Me("TwitterSearchUrl") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property twitterfilespos() As String
            Get
                Return CType(Me("twitterfilespos"),String)
            End Get
            Set
                Me("twitterfilespos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property twitterimagepos() As String
            Get
                Return CType(Me("twitterimagepos"),String)
            End Get
            Set
                Me("twitterimagepos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("https://en.wikipedia.org/w/api.php?action=query&prop=extracts&exintro=&exsentence"& _ 
            "s=#&explaintext=&redirects=&formatversion=2&format=json&titles=")>  _
        Public Property wikiExtractSearch() As String
            Get
                Return CType(Me("wikiExtractSearch"),String)
            End Get
            Set
                Me("wikiExtractSearch") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("4")>  _
        Public Property wikiSentences() As Integer
            Get
                Return CType(Me("wikiSentences"),Integer)
            End Get
            Set
                Me("wikiSentences") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("F:\CelebrityBirthday\Twitter\Images")>  _
        Public Property twitterImageFolder() As String
            Get
                Return CType(Me("twitterImageFolder"),String)
            End Get
            Set
                Me("twitterImageFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("https://celebritybirthday.wordpress.com/#y/#m/#d/#D-#M/")>  _
        Public Property WordPressMonthUrl() As String
            Get
                Return CType(Me("WordPressMonthUrl"),String)
            End Get
            Set
                Me("WordPressMonthUrl") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property srchformpos() As String
            Get
                Return CType(Me("srchformpos"),String)
            End Get
            Set
                Me("srchformpos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property bwsrformpos() As String
            Get
                Return CType(Me("bwsrformpos"),String)
            End Get
            Set
                Me("bwsrformpos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property wprformpos() As String
            Get
                Return CType(Me("wprformpos"),String)
            End Get
            Set
                Me("wprformpos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property capformpos() As String
            Get
                Return CType(Me("capformpos"),String)
            End Get
            Set
                Me("capformpos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property botsdformpos() As String
            Get
                Return CType(Me("botsdformpos"),String)
            End Get
            Set
                Me("botsdformpos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property sndtwformpos() As String
            Get
                Return CType(Me("sndtwformpos"),String)
            End Get
            Set
                Me("sndtwformpos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property textformpos() As String
            Get
                Return CType(Me("textformpos"),String)
            End Get
            Set
                Me("textformpos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("https://en.wikipedia.org/w/api.php?action=query&list=allpages&redirects=&formatve"& _ 
            "rsion=2&format=json&apfrom=#f&apto=#t")>  _
        Public Property wikiTitleSearch() As String
            Get
                Return CType(Me("wikiTitleSearch"),String)
            End Get
            Set
                Me("wikiTitleSearch") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.CelebrityBirthday.My.MySettings
            Get
                Return Global.CelebrityBirthday.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
