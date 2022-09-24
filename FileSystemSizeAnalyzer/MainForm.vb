'***********************************************************************
'Copyright 2022 Vijay Sridhara

'Licensed under the Apache License, Version 2.0 (the "License");
'you may not use this file except in compliance with the License.
'You may obtain a copy of the License at

'   http://www.apache.org/licenses/LICENSE-2.0

'Unless required by applicable law or agreed to in writing, software
'distributed under the License is distributed on an "AS IS" BASIS,
'WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'See the License for the specific language governing permissions and
'limitations under the License.
'***********************************************************************
Imports System.IO
Imports System.Text.RegularExpressions

Public Class MainForm
    Private Exclude As New List(Of String)
    Private msgQueue As New Queue(Of String)
    Private _limitMaxSize As Long = 40960000
    Private selectedDrive As String = "C:\"
    Private WithEvents fileThd As Threading.Thread
    Private completed As Boolean

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Timer1.Enabled Then
            Timer1.Enabled = False
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds() As System.IO.DriveInfo = System.IO.DriveInfo.GetDrives
        For Each d As DriveInfo In ds
            cboDrives.Items.Add(d.Name)
        Next
        cboDrives.SelectedIndex = 0
        With My.Application.Info.Version
            lblVersion.Text = String.Format(lblVersion.Text, .Major, .Minor, .Revision)
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Analyze" Then
            ResetParams()
            completed = False
            Timer1.Enabled = True
            Timer1.Start()

            Dim arr() As String = txtExclude.Text.Split(vbLf)

            For Each a As String In arr
                Exclude.Add(a.Trim)
            Next
            For Each ex1 As String In Exclude
                msgQueue.Enqueue("0|Excluding folder : " & ex1)
            Next
            Dim stratInfo As New ProcessStartInfo
            stratInfo.Arguments = selectedDrive

            Button1.Text = "Stop"
            DataGridView1.Rows.Clear()
            txtLog.Clear()
            fileThd = New Threading.Thread(AddressOf ParseFolders)
            fileThd.Start(selectedDrive)
            Debug.Print("Started")
        Else
            Button1.Text = "Analyze"
            Button1.Enabled = False
            processInterrupt = True
        End If
    End Sub
    Private Sub ResetParams()
        Button1.Enabled = True
        Button1.Text = "Analyze"
        Timer1.Enabled = False
        processInterrupt = False
        level1Counter = 0
        level2Counter = 0
        level3Counter = 0
        level4Counter = 0
        level1Pct = 0
        level2Pct = 0
        level3pct = 0
        level4pct = 0
        pgbLevel1.Value = 0
        pgbLevel2.Value = 0
        pgbLevel3.Value = 0
        pgbLevel4.Value = 0
        Timer1.Stop()
        Exclude.Clear()
    End Sub

    Dim currentLevel As Integer = 0
    Dim level1Counter As Integer = 0
    Dim level2Counter As Integer = 0
    Dim level3Counter As Integer = 0
    Dim level4Counter As Integer = 0
    Dim level1Pct As Integer = 0
    Dim level2Pct As Integer = 0
    Dim level3pct As Integer = 0
    Dim level4pct As Integer = 0
    Dim processInterrupt As Boolean
    Dim MTCH As Match
    Dim RE As Regex

    Private Function CheckExclusions(path As String) As Boolean
        For Each ex As String In Exclude

            If ex.Equals(path, StringComparison.CurrentCultureIgnoreCase) Then
                msgQueue.Enqueue("1|Excluding: " & path & " qualified for : " & ex)
                Return True
            ElseIf ex.StartsWith("pat:", StringComparison.CurrentCultureIgnoreCase) And ex.EndsWith("]") Then
                Dim expr As String = ex.Substring(4)
                RE = New Regex(expr, RegexOptions.IgnoreCase Or RegexOptions.Compiled)
                MTCH = RE.Match(path)
                If MTCH.Success Then
                    msgQueue.Enqueue("1|Excluding: " & path & " qualified for : " & expr)
                    Return True
                End If
            ElseIf ex = "*" Then 'This is never reached in the path. It is actually happened at drive level itself
                ResetParams()
                msgQueue.Enqueue("1|Excluding: " & path & " qualified for : " & ex)
                Return True
            ElseIf ex.Contains("*") Then
                Dim spl() As String = ex.Split("*")
                Dim leftSt As String = spl(0)
                Dim rightSt As String = spl(1)
                If String.IsNullOrEmpty(leftSt) = False Then
                    If path.StartsWith(leftSt, StringComparison.CurrentCultureIgnoreCase) Then
                        If String.IsNullOrEmpty(rightSt) = False Then
                            If path.EndsWith(rightSt, StringComparison.CurrentCultureIgnoreCase) Then
                                msgQueue.Enqueue("1|Excluding: " & path & " qualified for : " & ex)
                                Return True
                            End If
                        Else
                            msgQueue.Enqueue("1|Excluding: " & path & " qualified for : " & ex)
                            Return True
                        End If
                    ElseIf String.IsNullOrEmpty(rightSt) = False Then
                        If path.EndsWith(rightSt, StringComparison.CurrentCultureIgnoreCase) Then
                            msgQueue.Enqueue("1|Excluding: " & path & " qualified for : " & ex)
                            Return True
                        End If
                    End If
                End If
            End If
        Next

        Return False
    End Function
    Private Sub ParseFolders(path As String, Optional level As Integer = 1)

        Try
            Application.DoEvents()

            If path <> selectedDrive Then
                Dim finfo As New IO.DirectoryInfo(path)

                msgQueue.Enqueue("1|Parsing " & path)

                If CheckExclusions(path) Then

                    Exit Sub

                End If



                Dim fSize As Long = DirectorySize(finfo, True)

                If fSize > _limitMaxSize Then

                    Dim sz As String
                    If fSize / (1024 * 1024 * 1024) > 1 Then
                        sz = Math.Round(fSize / (1024 * 1024 * 1024), 2) & "GB"
                    ElseIf fSize / (1024 * 1024) > 1 Then
                        sz = Math.Round(fSize / (1024 * 1024), 2) & "MB"
                    ElseIf fSize / 1024 > 1 Then
                        sz = Math.Round(fSize / 1024, 2) & "KB"
                    Else
                        sz = fSize & "Bytes"
                    End If


                    msgQueue.Enqueue("3|" & path & "|" & fSize & "|" & sz & "|" & "Yes")
                    Dim folders() As String = IO.Directory.GetDirectories(path)
                    For Each folder As String In folders

                        If processInterrupt Then GoTo LevelCheck
                        Select Case level
                            Case 1

                                level2Counter = 0
                                level3Counter = 0
                                level4Counter = 0
                            Case 2

                                level3Counter = 0
                                level4Counter = 0
                            Case 3

                                level4Counter = 0
                            Case 4

                        End Select
                        ParseFolders(folder, level + 1)
                        Select Case level
                            Case 1
                                level1Counter += 1
                                level1Pct = CInt(level1Counter / folders.Count * 100)
                            Case 2
                                level2Counter += 1
                                level2Pct = CInt(level2Counter / folders.Count * 100)
                            Case 3
                                level3Counter += 1
                                level3pct = CInt(level3Counter / folders.Count * 100)
                            Case 4
                                level4Counter += 1
                                level4pct = CInt(level4Counter / folders.Count * 100)
                        End Select
                    Next
                Else
                    'msgQueue.Enqueue("3|" & path & "|" & sz & "|" & "No")
                    'We are not interested in others. 
                End If
            Else


                If CheckExclusions(path) Then
                    Exit Sub
                End If

                Dim folders() As String = IO.Directory.GetDirectories(path)
                For Each folder As String In folders
                    If processInterrupt Then GoTo LevelCheck
                    Select Case level
                        Case 1

                            level2Counter = 0
                            level3Counter = 0
                            level4Counter = 0
                        Case 2

                            level3Counter = 0
                            level4Counter = 0
                        Case 3

                            level4Counter = 0
                        Case 4

                    End Select

                    ParseFolders(folder, level + 1)
                    Select Case level
                        Case 1
                            level1Counter += 1
                            level1Pct = CInt(level1Counter / folders.Count * 100)
                        Case 2
                            level2Counter += 1
                            level2Pct = CInt(level2Counter / folders.Count * 100)
                        Case 3
                            level3Counter += 1
                            level3pct = CInt(level3Counter / folders.Count * 100)
                        Case 4
                            level4Counter += 1
                            level4pct = CInt(level4Counter / folders.Count * 100)
                    End Select
                Next
            End If
LevelCheck:
            If level = 1 Then
                msgQueue.Enqueue("0|Exiting the process...")
                completed = True
                ResetParams()
            End If
        Catch ex As Exception
            msgQueue.Enqueue("2|" & ex.Message)
        End Try

    End Sub
    Private Function DirectorySize(ByVal dInfo As IO.DirectoryInfo, ByVal includeSubDir As Boolean) As Long
        Application.DoEvents()
        Dim totalSize As Long = dInfo.EnumerateFiles().Sum(Function(file) file.Length)
        If includeSubDir Then totalSize += dInfo.EnumerateDirectories().Sum(Function(dir) DirectorySize(dir, True))
        Return totalSize
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Application.DoEvents()


            While msgQueue.Count > 0
                pgbLevel1.Value = level1Pct
                pgbLevel2.Value = level2Pct
                pgbLevel3.Value = level3pct
                pgbLevel4.Value = level4pct
                pgbLevel1.Update()
                pgbLevel2.Update()
                pgbLevel3.Update()
                pgbLevel4.Update()
                Dim msg As String() = msgQueue.Dequeue.Split("|")
                If msg(0) = "0" Then
                    txtLog.Text += "INFO >> " & msg(1) & vbCrLf
                    txtLog.SelectionStart = txtLog.Text.Length
                    txtLog.ScrollToCaret()
                ElseIf msg(0) = "2" Then
                    txtLog.Text += "ERROR >> " & msg(1) & vbCrLf
                    txtLog.SelectionStart = txtLog.Text.Length
                    txtLog.ScrollToCaret()
                ElseIf msg(0) = "1" Then
                    txtLog.Text += msg(1) & vbCrLf
                    txtLog.SelectionStart = txtLog.Text.Length
                    txtLog.ScrollToCaret()
                ElseIf msg(0) = "3" Then
                    DataGridView1.Rows.Add({msg(1), msg(2), msg(3), msg(4)})

                    DataGridView1.Refresh()
                End If

            End While

            'pgbLevel1.Visible = IIf(level1Pct = 0, False, True)
            'pgbLevel2.Visible = IIf(level2Pct = 0, False, True)
            'pgbLevel3.Visible = IIf(level3pct = 0, False, True)
            'pgbLevel4.Visible = IIf(level4pct = 0, False, True)

            If completed Then
                Timer1.Stop()
                Timer1.Enabled = False
                Button1.Enabled = True
            End If
        Catch ex As Exception
            Debug.Print("ERrorr " & ex.Message)
        End Try
    End Sub

    Private Sub cboDrives_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDrives.SelectedIndexChanged
        selectedDrive = cboDrives.Text
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim proc As New Process()
        proc.Start("https://github.com/VijaySridhara/")
    End Sub
End Class
