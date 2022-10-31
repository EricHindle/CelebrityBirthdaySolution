Imports System.IO
Imports System.Reflection

Public Class FrmBackup
#Region "properties"

#End Region
#Region "variables"
    Private backupImagePath As String
    Private backupDataPath As String
    Private dataPath As String
    Private imagePath As String
    Public tableList As New List(Of String)

#End Region
#Region "form control handlers"
    Private Sub FrmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Backup")
        PbCopyProgress.Visible = False
        InitialiseData()
        GetFormPos(Me, My.Settings.backupformpos)
        TxtBackupPath.Text = My.Settings.BackupPath
        AddProgress("Filling Table Tree")
        FillTableTree(TvDatatables)
        TvDatatables.ExpandAll()
        AddProgress("Filling Image Tree")
        FillImageTree()
        TvImages.ExpandAll()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub TvDatatables_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TvDatatables.AfterCheck, TvImages.AfterCheck
        Dim node As TreeNode = e.Node
        Dim ischecked As Boolean = node.Checked
        For Each subNode As TreeNode In node.Nodes
            subNode.Checked = ischecked
        Next
    End Sub
    Private Sub BtnBackup_Click(sender As Object, e As EventArgs) Handles BtnBackup.Click
        Dim isOKToBackup As Boolean = CheckPaths(True)
        If isOKToBackup Then
            AddProgress("Backup started -------------------------")
            DataTableBackup()
            ImageBackup()
            AddProgress("Backup complete -------------------------")
        End If
    End Sub
    Private Sub BtnSavePath_Click(sender As Object, e As EventArgs) Handles BtnSavePath.Click
        My.Settings.BackupPath = TxtBackupPath.Text
        My.Settings.Save()
    End Sub
    Private Sub BtnSelectPath_Click(sender As Object, e As EventArgs) Handles BtnSelectPath.Click
        Using fbd As New FolderBrowserDialog
            If Not String.IsNullOrEmpty(TxtBackupPath.Text) Then
                fbd.SelectedPath = TxtBackupPath.Text
            End If
            If fbd.ShowDialog() = DialogResult.OK Then
                TxtBackupPath.Text = fbd.SelectedPath
            End If
        End Using
    End Sub
    Private Sub FrmBackup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.BackupFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnSelectAll_Click(sender As Object, e As EventArgs) Handles BtnSelectAll.Click
        TvDatatables.Nodes(0).Checked = True
        TvImages.Nodes(0).Checked = True
    End Sub
#End Region
#Region "subroutines"
    Private Sub FillImageTree()
        TvImages.Nodes.Clear()
        TvImages.Nodes.Add("Images")
        Dim topNode As TreeNode = TvImages.Nodes(0)
        Dim fileList As IReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(My.Settings.ImgPath)
        For Each _filename As String In fileList
            Dim _fname As String = Path.GetFileName(_filename)
            topNode.Nodes.Add(_filename, _fname)
        Next
    End Sub
    Private Function CheckPaths(isOKToBackup As Boolean) As Boolean
        If Not String.IsNullOrEmpty(TxtBackupPath.Text) Then
            backupDataPath = If(chkAddDate.Checked, Path.Combine(TxtBackupPath.Text.Trim, Format(Today, "yyyyMMdd")), TxtBackupPath.Text.Trim)
            backupImagePath = TxtBackupPath.Text.Trim
            dataPath = Path.Combine(backupDataPath, "data")
            imagePath = Path.Combine(backupImagePath, "images")
            Try
                If Not My.Computer.FileSystem.DirectoryExists(backupDataPath) Then
                    AddProgress("Creating backup folder")
                    My.Computer.FileSystem.CreateDirectory(backupDataPath)
                End If
                If Not My.Computer.FileSystem.DirectoryExists(backupImagePath) Then
                    AddProgress("Creating backup folder")
                    My.Computer.FileSystem.CreateDirectory(backupImagePath)
                End If
                If Not My.Computer.FileSystem.DirectoryExists(dataPath) Then
                    AddProgress("Creating data folder")
                    My.Computer.FileSystem.CreateDirectory(dataPath)
                End If
                If Not My.Computer.FileSystem.DirectoryExists(imagePath) Then
                    AddProgress("Creating image folder")
                    My.Computer.FileSystem.CreateDirectory(imagePath)
                End If
            Catch ex As ArgumentException
                DisplayException(MethodBase.GetCurrentMethod(), ex, "File creation", False)
                AddProgress("Failed : " & ex.Message)
                isOKToBackup = False
            Catch ex As PathTooLongException
                DisplayException(MethodBase.GetCurrentMethod(), ex, "File creation", False)
                AddProgress("Failed : " & ex.Message)
                isOKToBackup = False
            Catch ex As NotSupportedException
                DisplayException(MethodBase.GetCurrentMethod(), ex, "File creation", False)
                AddProgress("Failed : " & ex.Message)
                isOKToBackup = False
            Catch ex As IOException
                DisplayException(MethodBase.GetCurrentMethod(), ex, "File creation", False)
                AddProgress("Failed : " & ex.Message)
                isOKToBackup = False
            Catch ex As UnauthorizedAccessException
                DisplayException(MethodBase.GetCurrentMethod(), ex, "File creation", False)
                AddProgress("Failed : " & ex.Message)
                isOKToBackup = False
            End Try
        Else
            AddProgress("No destination. No backup.")
            isOKToBackup = False
        End If
        Return isOKToBackup
    End Function
    Private Sub ImageBackup()
        AddProgress("Image backup ======")
        PbCopyProgress.Value = 0
        PbCopyProgress.Visible = True
        Dim _selct As Integer = 0
        For Each oNode As TreeNode In TvImages.Nodes(0).Nodes
            If oNode.Checked Then
                _selct += 1
            End If
        Next
        PbCopyProgress.Maximum = _selct
        For Each oNode As TreeNode In TvImages.Nodes(0).Nodes
            If oNode.Checked Then
                Dim _filename As String = oNode.Text
                Dim _fullname As String = oNode.Name
                Dim _destination As String = Path.Combine(imagePath, _filename)
                If Not My.Computer.FileSystem.FileExists(_destination) Then
                    AddProgress(oNode.Text)
                    My.Computer.FileSystem.CopyFile(_fullname, _destination, True)
                    AddProgress(_filename & " copied")
                End If
                PbCopyProgress.Value += 1
                oNode.Checked = False
            End If
        Next
        TvImages.Nodes(0).Checked = False
        PbCopyProgress.Visible = False
    End Sub
    Private Sub DataTableBackup()
        AddProgress("Data backup ======")
        PbCopyProgress.Visible = True
        PbCopyProgress.Value = 0
        Dim _selct As Integer = 0
        For Each oNode As TreeNode In TvDatatables.Nodes(0).Nodes
            If oNode.Checked Then
                _selct += 1
            End If
        Next
        PbCopyProgress.Maximum = _selct
        For Each oNode As TreeNode In TvDatatables.Nodes(0).Nodes
            If oNode.Checked Then
                AddProgress(oNode.Text)
                Select Case oNode.Text
                    Case "Audit"
                        BackupTable(GetAuditTable)
                    Case "BotSD"
                        BackupTable(GetBotSDTable)
                    Case "Dates"
                        BackupTable(GetDatesTable)
                    Case "Image"
                        BackupTable(GetImageTable)
                    Case "Person"
                        BackupTable(GetPersonTable)
                    Case "Settings"
                        BackupTable(GetSettingsTable)
                    Case "SocialMedia"
                        BackupTable(GetSocialMediaTable)
                    Case "Tweets"
                        BackupTable(GetTweetsTable)
                    Case "TwitterAuth"
                        BackupTable(GetTwitterAuthTable)
                    Case "CelebrityTypes"
                        BackupTable(GetCelebrityTypesTable)
                End Select
                oNode.Checked = False
            End If
        Next
        TvDatatables.Nodes(0).Checked = False
        PbCopyProgress.Visible = False
    End Sub
    Private Sub AddProgress(pText As String)
        LogUtil.Info(pText, MyBase.Name)
        rtbProgress.Text &= vbCrLf & pText
        rtbProgress.SelectionStart = rtbProgress.Text.Length
        rtbProgress.ScrollToCaret()
        rtbProgress.Refresh()
    End Sub
    Private Sub BackupTable(backupDataTable As DataTable)
        Dim sTableName As String = backupDataTable.TableName
        Dim sDbFullPath As String = dataPath
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".xml")
        AddProgress("Writing " & sBackupFile)
        backupDataTable.WriteXml(sBackupFile)
        AddProgress("Writing " & sBackupFile & " complete")
        PbCopyProgress.Value += 1
    End Sub
    Public Sub InitialiseData()
        tableList.Add("Audit")
        tableList.Add("BotSD")
        tableList.Add("Dates")
        tableList.Add("Image")
        tableList.Add("Person")
        tableList.Add("Settings")
        tableList.Add("SocialMedia")
        tableList.Add("Tweets")
        tableList.Add("TwitterAuth")
        tableList.Add("CelebrityTypes")
    End Sub
    Public Sub FillTableTree(ByRef tvtables As TreeView)
        tvtables.Nodes.Clear()
        tvtables.Nodes.Add("Tables")
        For Each oTable As String In tableList
            tvtables.Nodes(0).Nodes.Add(oTable)
        Next
    End Sub

#End Region
End Class