<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.pgbLevel1 = New System.Windows.Forms.ProgressBar()
        Me.pgbLevel3 = New System.Windows.Forms.ProgressBar()
        Me.pgbLevel4 = New System.Windows.Forms.ProgressBar()
        Me.pgbLevel2 = New System.Windows.Forms.ProgressBar()
        Me.cboDrives = New System.Windows.Forms.ComboBox()
        Me.lblDrive = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtExclude = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colHPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHBytes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHDig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(492, 413)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Analyze"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'txtLog
        '
        Me.txtLog.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.Location = New System.Drawing.Point(573, 113)
        Me.txtLog.MaxLength = 3276700
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(549, 416)
        Me.txtLog.TabIndex = 14
        '
        'pgbLevel1
        '
        Me.pgbLevel1.Location = New System.Drawing.Point(655, 33)
        Me.pgbLevel1.Name = "pgbLevel1"
        Me.pgbLevel1.Size = New System.Drawing.Size(467, 14)
        Me.pgbLevel1.TabIndex = 7
        '
        'pgbLevel3
        '
        Me.pgbLevel3.Location = New System.Drawing.Point(655, 73)
        Me.pgbLevel3.Name = "pgbLevel3"
        Me.pgbLevel3.Size = New System.Drawing.Size(467, 14)
        Me.pgbLevel3.TabIndex = 11
        '
        'pgbLevel4
        '
        Me.pgbLevel4.Location = New System.Drawing.Point(655, 93)
        Me.pgbLevel4.Name = "pgbLevel4"
        Me.pgbLevel4.Size = New System.Drawing.Size(467, 14)
        Me.pgbLevel4.TabIndex = 13
        '
        'pgbLevel2
        '
        Me.pgbLevel2.Location = New System.Drawing.Point(655, 53)
        Me.pgbLevel2.Name = "pgbLevel2"
        Me.pgbLevel2.Size = New System.Drawing.Size(467, 14)
        Me.pgbLevel2.TabIndex = 9
        '
        'cboDrives
        '
        Me.cboDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDrives.FormattingEnabled = True
        Me.cboDrives.Location = New System.Drawing.Point(82, 18)
        Me.cboDrives.Name = "cboDrives"
        Me.cboDrives.Size = New System.Drawing.Size(203, 21)
        Me.cboDrives.TabIndex = 1
        '
        'lblDrive
        '
        Me.lblDrive.AutoSize = True
        Me.lblDrive.Location = New System.Drawing.Point(13, 21)
        Me.lblDrive.Name = "lblDrive"
        Me.lblDrive.Size = New System.Drawing.Size(63, 13)
        Me.lblDrive.TabIndex = 0
        Me.lblDrive.Text = "Select drive"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 426)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Exclude directories"
        '
        'txtExclude
        '
        Me.txtExclude.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExclude.Location = New System.Drawing.Point(12, 442)
        Me.txtExclude.Multiline = True
        Me.txtExclude.Name = "txtExclude"
        Me.txtExclude.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExclude.Size = New System.Drawing.Size(555, 87)
        Me.txtExclude.TabIndex = 4
        Me.txtExclude.Text = "C:\Program*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "C:\Win*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "C:\$*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(576, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Level 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(576, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Level 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(576, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Level 3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(576, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Level 4"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(460, 21)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(85, 13)
        Me.LinkLabel1.TabIndex = 16
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "by Vijay Sridhara"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(322, 21)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(93, 13)
        Me.lblVersion.TabIndex = 15
        Me.lblVersion.Text = "Version:{0}.{1}.{2}"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colHPath, Me.colHBytes, Me.colHSize, Me.colHDig})
        Me.DataGridView1.Location = New System.Drawing.Point(16, 54)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(550, 353)
        Me.DataGridView1.TabIndex = 17
        '
        'colHPath
        '
        Me.colHPath.HeaderText = "Path"
        Me.colHPath.Name = "colHPath"
        Me.colHPath.ReadOnly = True
        Me.colHPath.Width = 250
        '
        'colHBytes
        '
        Me.colHBytes.HeaderText = "Bytes"
        Me.colHBytes.Name = "colHBytes"
        Me.colHBytes.ReadOnly = True
        Me.colHBytes.Width = 120
        '
        'colHSize
        '
        Me.colHSize.HeaderText = "Size"
        Me.colHSize.Name = "colHSize"
        Me.colHSize.ReadOnly = True
        Me.colHSize.Width = 80
        '
        'colHDig
        '
        Me.colHDig.HeaderText = "Dig"
        Me.colHDig.Name = "colHDig"
        Me.colHDig.ReadOnly = True
        Me.colHDig.Width = 50
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 541)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.txtExclude)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblDrive)
        Me.Controls.Add(Me.cboDrives)
        Me.Controls.Add(Me.pgbLevel4)
        Me.Controls.Add(Me.pgbLevel2)
        Me.Controls.Add(Me.pgbLevel3)
        Me.Controls.Add(Me.pgbLevel1)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FileSystemSizeAnalyzer"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents pgbLevel1 As System.Windows.Forms.ProgressBar
    Friend WithEvents pgbLevel3 As System.Windows.Forms.ProgressBar
    Friend WithEvents pgbLevel4 As System.Windows.Forms.ProgressBar
    Friend WithEvents pgbLevel2 As System.Windows.Forms.ProgressBar
    Friend WithEvents cboDrives As ComboBox
    Friend WithEvents lblDrive As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtExclude As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents lblVersion As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents colHPath As DataGridViewTextBoxColumn
    Friend WithEvents colHBytes As DataGridViewTextBoxColumn
    Friend WithEvents colHSize As DataGridViewTextBoxColumn
    Friend WithEvents colHDig As DataGridViewTextBoxColumn
End Class
