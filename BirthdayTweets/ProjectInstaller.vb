﻿' Hindleware
' Copyright (c) 2020-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Configuration.Install

Public Class ProjectInstaller

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add initialization code after the call to InitializeComponent

    End Sub

    Private Sub ServiceInstaller1_AfterInstall(sender As Object, e As InstallEventArgs) Handles ServiceInstaller1.AfterInstall

    End Sub

    Private Sub ServiceProcessInstaller1_AfterInstall(sender As Object, e As InstallEventArgs) Handles ServiceProcessInstaller1.AfterInstall

    End Sub
End Class
