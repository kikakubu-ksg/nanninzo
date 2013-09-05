<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog2
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox_SE03 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_SE02 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_SE01 = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.CheckBox01 = New System.Windows.Forms.CheckBox()
        Me.CheckBox02 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBox06 = New System.Windows.Forms.CheckBox()
        Me.CheckBox05 = New System.Windows.Forms.CheckBox()
        Me.CheckBox04 = New System.Windows.Forms.CheckBox()
        Me.CheckBox03 = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.更新間隔 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.watchPattern = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.RecPort = New System.Windows.Forms.TextBox()
        Me.RadioButton8 = New System.Windows.Forms.RadioButton()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.watchPattern.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(406, 371)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 27)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 21)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 21)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "キャンセル"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CheckBox_SE03)
        Me.GroupBox1.Controls.Add(Me.CheckBox_SE02)
        Me.GroupBox1.Controls.Add(Me.CheckBox_SE01)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ComboBox3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(173, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(381, 217)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SoundEffect"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(123, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(188, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "SEフォルダに格納されているwavファイル"
        '
        'CheckBox_SE03
        '
        Me.CheckBox_SE03.AutoSize = True
        Me.CheckBox_SE03.Location = New System.Drawing.Point(65, 123)
        Me.CheckBox_SE03.Name = "CheckBox_SE03"
        Me.CheckBox_SE03.Size = New System.Drawing.Size(54, 16)
        Me.CheckBox_SE03.TabIndex = 11
        Me.CheckBox_SE03.Text = "鳴らす"
        Me.CheckBox_SE03.UseVisualStyleBackColor = True
        '
        'CheckBox_SE02
        '
        Me.CheckBox_SE02.AutoSize = True
        Me.CheckBox_SE02.Location = New System.Drawing.Point(65, 86)
        Me.CheckBox_SE02.Name = "CheckBox_SE02"
        Me.CheckBox_SE02.Size = New System.Drawing.Size(54, 16)
        Me.CheckBox_SE02.TabIndex = 10
        Me.CheckBox_SE02.Text = "鳴らす"
        Me.CheckBox_SE02.UseVisualStyleBackColor = True
        '
        'CheckBox_SE01
        '
        Me.CheckBox_SE01.AutoSize = True
        Me.CheckBox_SE01.Location = New System.Drawing.Point(65, 50)
        Me.CheckBox_SE01.Name = "CheckBox_SE01"
        Me.CheckBox_SE01.Size = New System.Drawing.Size(54, 16)
        Me.CheckBox_SE01.TabIndex = 9
        Me.CheckBox_SE01.Text = "鳴らす"
        Me.CheckBox_SE01.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(315, 123)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(45, 19)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "再生"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "進入時"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "満員時"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(125, 48)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(174, 20)
        Me.ComboBox1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "退出時"
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(125, 121)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(174, 20)
        Me.ComboBox3.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(315, 84)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(45, 19)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "再生"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(315, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(45, 19)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "再生"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(125, 86)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(174, 20)
        Me.ComboBox2.TabIndex = 1
        '
        'CheckBox01
        '
        Me.CheckBox01.AutoSize = True
        Me.CheckBox01.Checked = True
        Me.CheckBox01.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox01.Location = New System.Drawing.Point(16, 20)
        Me.CheckBox01.Name = "CheckBox01"
        Me.CheckBox01.Size = New System.Drawing.Size(114, 16)
        Me.CheckBox01.TabIndex = 5
        Me.CheckBox01.Text = "常に最前面に表示"
        Me.CheckBox01.UseVisualStyleBackColor = True
        '
        'CheckBox02
        '
        Me.CheckBox02.AutoSize = True
        Me.CheckBox02.Checked = True
        Me.CheckBox02.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox02.Location = New System.Drawing.Point(16, 42)
        Me.CheckBox02.Name = "CheckBox02"
        Me.CheckBox02.Size = New System.Drawing.Size(121, 16)
        Me.CheckBox02.TabIndex = 7
        Me.CheckBox02.Text = "タスクバーに格納する"
        Me.CheckBox02.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.CheckBox06)
        Me.GroupBox2.Controls.Add(Me.CheckBox05)
        Me.GroupBox2.Controls.Add(Me.CheckBox04)
        Me.GroupBox2.Controls.Add(Me.CheckBox03)
        Me.GroupBox2.Controls.Add(Me.CheckBox02)
        Me.GroupBox2.Controls.Add(Me.CheckBox01)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(155, 388)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options"
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(6, 217)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(142, 1)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        '
        'CheckBox06
        '
        Me.CheckBox06.AutoSize = True
        Me.CheckBox06.Enabled = False
        Me.CheckBox06.Location = New System.Drawing.Point(16, 130)
        Me.CheckBox06.Name = "CheckBox06"
        Me.CheckBox06.Size = New System.Drawing.Size(112, 16)
        Me.CheckBox06.TabIndex = 11
        Me.CheckBox06.Text = "チラツキを防止する"
        Me.CheckBox06.UseVisualStyleBackColor = True
        Me.CheckBox06.Visible = False
        '
        'CheckBox05
        '
        Me.CheckBox05.AutoSize = True
        Me.CheckBox05.Checked = True
        Me.CheckBox05.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox05.Location = New System.Drawing.Point(16, 108)
        Me.CheckBox05.Name = "CheckBox05"
        Me.CheckBox05.Size = New System.Drawing.Size(132, 16)
        Me.CheckBox05.TabIndex = 10
        Me.CheckBox05.Text = "アンチエイリアスをかける"
        Me.CheckBox05.UseVisualStyleBackColor = True
        '
        'CheckBox04
        '
        Me.CheckBox04.AutoSize = True
        Me.CheckBox04.Location = New System.Drawing.Point(16, 86)
        Me.CheckBox04.Name = "CheckBox04"
        Me.CheckBox04.Size = New System.Drawing.Size(125, 16)
        Me.CheckBox04.TabIndex = 9
        Me.CheckBox04.Text = "美人の時に赤で表示"
        Me.CheckBox04.UseVisualStyleBackColor = True
        '
        'CheckBox03
        '
        Me.CheckBox03.AutoSize = True
        Me.CheckBox03.Location = New System.Drawing.Point(16, 64)
        Me.CheckBox03.Name = "CheckBox03"
        Me.CheckBox03.Size = New System.Drawing.Size(119, 16)
        Me.CheckBox03.TabIndex = 8
        Me.CheckBox03.Text = "字幕を右寄せにする"
        Me.CheckBox03.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(577, 440)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.更新間隔)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(569, 414)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "一般"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 261)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 12)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "短くしすぎると危険です。"
        '
        '更新間隔
        '
        Me.更新間隔.Location = New System.Drawing.Point(28, 284)
        Me.更新間隔.Name = "更新間隔"
        Me.更新間隔.Size = New System.Drawing.Size(45, 19)
        Me.更新間隔.TabIndex = 10
        Me.更新間隔.Text = "1000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 245)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "更新間隔（ミリ秒）"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.watchPattern)
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(569, 414)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "時計"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'watchPattern
        '
        Me.watchPattern.Controls.Add(Me.TextBox2)
        Me.watchPattern.Controls.Add(Me.Label7)
        Me.watchPattern.Controls.Add(Me.RadioButton6)
        Me.watchPattern.Controls.Add(Me.RadioButton5)
        Me.watchPattern.Controls.Add(Me.RadioButton4)
        Me.watchPattern.Controls.Add(Me.RadioButton3)
        Me.watchPattern.Controls.Add(Me.RadioButton2)
        Me.watchPattern.Controls.Add(Me.RadioButton1)
        Me.watchPattern.Location = New System.Drawing.Point(8, 6)
        Me.watchPattern.Name = "watchPattern"
        Me.watchPattern.Size = New System.Drawing.Size(309, 265)
        Me.watchPattern.TabIndex = 2
        Me.watchPattern.TabStop = False
        Me.watchPattern.Text = "表示形式"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(23, 172)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(248, 19)
        Me.TextBox2.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(77, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(189, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "（yyyy年mm月dd日 hh時mm分ss秒）"
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(6, 149)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(48, 16)
        Me.RadioButton6.TabIndex = 5
        Me.RadioButton6.Text = "フリー"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(6, 127)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(163, 16)
        Me.RadioButton5.TabIndex = 4
        Me.RadioButton5.Text = "12:34:56.789　（hh:mm:ss.fff）"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(6, 84)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(193, 16)
        Me.RadioButton4.TabIndex = 3
        Me.RadioButton4.Text = "20XX年01月23日 12時34分56秒　"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(6, 62)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(193, 16)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "12時34分56秒　（hh時mm分ss秒）"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(6, 40)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(265, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "20XX/01/23 12:34:56　（yyyy/mm/dd hh:mm:ss）"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 18)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(129, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "12:34:56　（hh:mm:ss）"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Button4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button5, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(393, 360)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(146, 27)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button4.Location = New System.Drawing.Point(3, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(67, 21)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "OK"
        '
        'Button5
        '
        Me.Button5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button5.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button5.Location = New System.Drawing.Point(76, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(67, 21)
        Me.Button5.TabIndex = 1
        Me.Button5.Text = "キャンセル"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TextBox3)
        Me.TabPage3.Controls.Add(Me.Button6)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(569, 414)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "通信"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(20, 167)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(424, 158)
        Me.TextBox3.TabIndex = 4
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(20, 341)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 3
        Me.Button6.Text = "通信開始"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.RecPort)
        Me.GroupBox4.Controls.Add(Me.RadioButton8)
        Me.GroupBox4.Controls.Add(Me.RadioButton7)
        Me.GroupBox4.Enabled = False
        Me.GroupBox4.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(204, 136)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "通信ポート"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 12)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "ポート"
        '
        'RecPort
        '
        Me.RecPort.Location = New System.Drawing.Point(53, 62)
        Me.RecPort.Name = "RecPort"
        Me.RecPort.Size = New System.Drawing.Size(81, 19)
        Me.RecPort.TabIndex = 2
        Me.RecPort.Text = "0"
        '
        'RadioButton8
        '
        Me.RadioButton8.AutoSize = True
        Me.RadioButton8.Location = New System.Drawing.Point(6, 40)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(76, 16)
        Me.RadioButton8.TabIndex = 1
        Me.RadioButton8.TabStop = True
        Me.RadioButton8.Text = "受信しない"
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Checked = True
        Me.RadioButton7.Location = New System.Drawing.Point(6, 18)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(66, 16)
        Me.RadioButton7.TabIndex = 0
        Me.RadioButton7.TabStop = True
        Me.RadioButton7.Text = "受信する"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'Dialog2
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(575, 441)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "何人ぞオプション"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.watchPattern.ResumeLayout(False)
        Me.watchPattern.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox_SE03 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_SE02 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_SE01 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckBox01 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox02 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox04 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox03 As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents CheckBox05 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox06 As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents 更新間隔 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents watchPattern As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents RecPort As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button

End Class
