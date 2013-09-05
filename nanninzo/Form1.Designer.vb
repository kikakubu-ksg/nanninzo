<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ファイルToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.読み込みToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.背景透過ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.人数表示変換 = New System.Windows.Forms.ToolStripMenuItem()
        Me.メッセージ編集 = New System.Windows.Forms.ToolStripMenuItem()
        Me.プロセスToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.時計ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.フォントToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.オプションToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ばじょんToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.背景透過ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.時計ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Timer1
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルToolStripMenuItem, Me.ToolStripMenuItem1, Me.プロセスToolStripMenuItem, Me.時計ToolStripMenuItem, Me.フォントToolStripMenuItem, Me.オプションToolStripMenuItem, Me.ばじょんToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(422, 48)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ファイルToolStripMenuItem
        '
        Me.ファイルToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.読み込みToolStripMenuItem, Me.保存ToolStripMenuItem})
        Me.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem"
        Me.ファイルToolStripMenuItem.Size = New System.Drawing.Size(68, 22)
        Me.ファイルToolStripMenuItem.Text = "ファイル"
        '
        '読み込みToolStripMenuItem
        '
        Me.読み込みToolStripMenuItem.Name = "読み込みToolStripMenuItem"
        Me.読み込みToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.読み込みToolStripMenuItem.Text = "読み込み"
        '
        '保存ToolStripMenuItem
        '
        Me.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem"
        Me.保存ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.保存ToolStripMenuItem.Text = "保存"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.背景透過ToolStripMenuItem, Me.人数表示変換, Me.メッセージ編集})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(44, 22)
        Me.ToolStripMenuItem1.Text = "表示"
        '
        '背景透過ToolStripMenuItem
        '
        Me.背景透過ToolStripMenuItem.CheckOnClick = True
        Me.背景透過ToolStripMenuItem.Name = "背景透過ToolStripMenuItem"
        Me.背景透過ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.背景透過ToolStripMenuItem.Text = "字幕表示"
        '
        '人数表示変換
        '
        Me.人数表示変換.CheckOnClick = True
        Me.人数表示変換.Name = "人数表示変換"
        Me.人数表示変換.Size = New System.Drawing.Size(172, 22)
        Me.人数表示変換.Text = "人数表示変換"
        '
        'メッセージ編集
        '
        Me.メッセージ編集.Name = "メッセージ編集"
        Me.メッセージ編集.Size = New System.Drawing.Size(172, 22)
        Me.メッセージ編集.Text = "▲メッセージ編集"
        '
        'プロセスToolStripMenuItem
        '
        Me.プロセスToolStripMenuItem.Name = "プロセスToolStripMenuItem"
        Me.プロセスToolStripMenuItem.Size = New System.Drawing.Size(68, 22)
        Me.プロセスToolStripMenuItem.Text = "プロセス"
        '
        '時計ToolStripMenuItem
        '
        Me.時計ToolStripMenuItem.Name = "時計ToolStripMenuItem"
        Me.時計ToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
        Me.時計ToolStripMenuItem.Text = "時計"
        '
        'フォントToolStripMenuItem
        '
        Me.フォントToolStripMenuItem.Name = "フォントToolStripMenuItem"
        Me.フォントToolStripMenuItem.Size = New System.Drawing.Size(68, 22)
        Me.フォントToolStripMenuItem.Text = "フォント"
        '
        'オプションToolStripMenuItem
        '
        Me.オプションToolStripMenuItem.Name = "オプションToolStripMenuItem"
        Me.オプションToolStripMenuItem.Size = New System.Drawing.Size(80, 22)
        Me.オプションToolStripMenuItem.Text = "オプション"
        '
        'ばじょんToolStripMenuItem
        '
        Me.ばじょんToolStripMenuItem.Name = "ばじょんToolStripMenuItem"
        Me.ばじょんToolStripMenuItem.Size = New System.Drawing.Size(93, 22)
        Me.ばじょんToolStripMenuItem.Text = "ヾ(*´∀｀*)ﾉ"
        '
        'FontDialog1
        '
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.背景透過ToolStripMenuItem1, Me.時計ToolStripMenuItem2, Me.終了ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(125, 70)
        '
        '背景透過ToolStripMenuItem1
        '
        Me.背景透過ToolStripMenuItem1.CheckOnClick = True
        Me.背景透過ToolStripMenuItem1.DoubleClickEnabled = True
        Me.背景透過ToolStripMenuItem1.Name = "背景透過ToolStripMenuItem1"
        Me.背景透過ToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.背景透過ToolStripMenuItem1.Text = "字幕表示"
        '
        '時計ToolStripMenuItem2
        '
        Me.時計ToolStripMenuItem2.Name = "時計ToolStripMenuItem2"
        Me.時計ToolStripMenuItem2.Size = New System.Drawing.Size(124, 22)
        Me.時計ToolStripMenuItem2.Text = "時計"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "占拠中"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(422, 72)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(200, 80)
        Me.Name = "Form1"
        Me.Text = "何人ぞ"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 背景透過ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents プロセスToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents フォントToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ばじょんToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 背景透過ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 人数表示変換 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 時計ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents メッセージ編集 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents オプションToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ファイルToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 読み込みToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 保存ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 終了ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 時計ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem

End Class
