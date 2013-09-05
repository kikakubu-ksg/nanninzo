Imports System
Imports System.Globalization
Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class Form1
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Private Declare Function GetSystemMetrics Lib "user32" (ByVal lnIndex As Long) As Long

    Private Const SM_CXFULLSCREEN As Long = 16
    Private Const SM_CYFULLSCREEN As Long = 17

    Dim fileName As String = Application.StartupPath + "\ksg.xml"
    Public soundName1 As String = "SE\in.wav"
    Public soundName2 As String = "SE\out.wav"
    Public soundName3 As String = "SE\busy.wav"
    Public soundDir As String = "SE"

    Dim ps As System.Diagnostics.Process()
    Dim pss As System.Diagnostics.Process
    Dim Message As String = "Not Defined"

    Public f2 As New Jimaku()
    Public f3 As New Jimaku()
    Private dialog2 As New Dialog2()
    Public fontDetail

    'デフォルトメッセージフォーマット
    Public defaultIMMessage As String = "いま$1人入ってるよ。最大$2人までokだよ。"

    'Dim pathBs As New System.Drawing.Drawing2D.GraphicsPath()


    '背景透過フラグ
    Dim noBGFlg As Boolean = False
    '人数表示変換フラグ
    Dim noIMFlg As Boolean = False

    '美人フラグ
    Dim busyFlg As Boolean = False

    Private mousePoint As Point

    Dim defaultWindow As String = "kagami"
    Dim currentId As Integer = 0

    'フォント基本情報
    'フォント色
    Public BaseFontColor As Color = Color.Black
    '縁取り
    Public BaseFontBorder As Color = Color.White
    '縁取り幅
    Public BaseFontBorderWidth As Integer = 0
    '影
    Public BaseFontShade As Color = Color.White
    '影有無
    Public BaseFontShadeOn As Boolean = False
    'アルファ値
    Public BaseFontAlpha As Integer = 0



    '/////////////////
    'オプションフラグ

    '右寄せ
    Public BaseAlignRightFlg As Boolean = False
    '美人時赤色
    Public BaseBusyHotFlg As Boolean = False
    'アンチエイリアス
    Public BaseAntiAriasFlg As Boolean = True

    'SE
    Public BaseSEInFlg As Boolean = False
    Public BaseSEOutFlg As Boolean = False
    Public BaseSEBusyFlg As Boolean = False


    '再描写フラグ
    Public RePaintFlg As Boolean = True

    '現在人数
    Public CurrentMem As Integer = 0

    Private Declare Function mciGetErrorString Lib "winmm.dll" Alias "mciGetErrorStringA" (ByVal fdwError As Integer, ByVal lpszErrorText As String, ByVal cchErrorText As Integer) As Integer

    Private aliasName As String = "MediaFile"

    Private gcHandle As System.Runtime.InteropServices.GCHandle
    Private waveBuffer As Byte() = Nothing

    Public Sub PlaySound(ByVal soundName As String)
        'Dim audio As Microsoft.DirectX.AudioVideoPlayback.Audio

        'Try
        '    audio = New Microsoft.DirectX.AudioVideoPlayback.Audio(Application.StartupPath + "\" + soundName)
        '    audio.Play()
        'Catch
        '    MessageBox.Show("ファイルの再生に失敗しました。" + Application.StartupPath + "\" + soundName)
        'End Try
    End Sub

    Public Shared Sub Main()

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        'If 終了時に変更を保存ToolStripMenuItem.CheckState = 1 Then
        'If DialogResult.Yes = _
        '    MessageBox.Show("現在の情報を保存しますか？", "解放ヾ(*´∀｀*)ﾉ", _
        '    MessageBoxButtons.YesNo, _
        '    MessageBoxIcon.Information) Then
        Save()
        'End If
        'End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        'If System.IO.File.Exists(fileName) Then
        '    'XmlSerializerオブジェクトの作成
        '    Dim serializer As _
        '        New System.Xml.Serialization.XmlSerializer( _
        '            GetType(SaveDataClass))

        '    'ファイルを開く
        '    Dim fs As New System.IO.FileStream( _
        '        fileName, System.IO.FileMode.Open)
        '    'XMLファイルから読み込み、逆シリアル化する
        '    Dim cls As SaveDataClass = _
        '        CType(serializer.Deserialize(fs), SaveDataClass)
        '    '閉じる
        '    fs.Close()

        '    Call Me.GetSaveData(cls)

        'End If

        Me.f2.setFormPair(Me.f3)
        Me.f2.setFormParent(Me)
        Me.f3.setFormPair(Me.f2)
        Me.f3.setFormParent(Me)
        Me.f2.Show()
        Me.f3.Show()

        Me.fontDetail = New FontDetail(Me)

        DefaultFins()
        Timer1.Interval = 1000
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Fins()
        If Me.noBGFlg Then
            If Me.RePaintFlg Then
                If Me.f2.Tag <> "hide" Then
                    'Me.f2.Show()
                    Me.f2.Visible = True
                End If
                If Me.f3.Tag <> "hide" Then
                    'Me.f3.Show()
                    Me.f3.Visible = True
                End If

                Call 透過()
                RePaintFlg = False
            End If
        Else
            Call 透過戻す()
        End If
    End Sub

    Sub DefaultFins()
        ps = System.Diagnostics.Process.GetProcessesByName(defaultWindow)

        If ps.Length = 0 Then
            Label1.Text = TimeString

        Else
            currentId = ps(0).Id
            Label1.Text = ps(0).MainWindowTitle

        End If

        Me.Message = Label1.Text

        'ファイル読み込み初期値

    End Sub

    Sub Fins()
        If currentId = 0 Then
            Label1.Text = TimeString
            'Dim dtNow As DateTime = DateTime.Now

            Try

                If Me.dialog2.RadioButton1.Checked Then
                    Message = String.Format("{0:HH:mm:ss}", Now())
                ElseIf Me.dialog2.RadioButton2.Checked Then
                    Message = String.Format("{0:yyyy/MM/dd HH:mm:ss}", Now())

                ElseIf Me.dialog2.RadioButton3.Checked Then

                    Message = String.Format("{0:HH時mm分ss秒}", Now())

                ElseIf Me.dialog2.RadioButton4.Checked Then
                    Message = String.Format("{0:yyyy年MM月dd日 HH時mm分ss秒}", Now())

                ElseIf Me.dialog2.RadioButton5.Checked Then
                    Message = String.Format("{0:HH:mm:ss.fff}", Now())


                ElseIf Me.dialog2.RadioButton6.Checked Then
                    'フリーのとき
                    Message = String.Format("{0:" + Me.dialog2.TextBox2.Text + "}", Now())

                End If

            Catch
                Message = String.Format("{0:HH:mm:ss}", Now())

            End Try

            'Message = dtNow.Hour.ToString + ":" + dtNow.Minute.ToString + ":" _
            '    + dtNow.Second.ToString + "." + dtNow.Millisecond.ToString
            'Message = TimeString
            RePaintFlg = True
        Else
            Try
                pss = System.Diagnostics.Process.GetProcessById(currentId)
                Dim mtTitle As String
                If noIMFlg And Regex.IsMatch(pss.MainWindowTitle, _
                    "EX ([\d]+)/([\d]+).*") Then

                    mtTitle = Regex.Replace(pss.MainWindowTitle, _
                    "EX ([\d]+)/([\d]+).*", _
                    defaultIMMessage)

                    Dim asMatch As Match
                    Dim areg As Regex
                    areg = New Regex("EX ([\d]+)/([\d]+).*")
                    asMatch = areg.Match(pss.MainWindowTitle)

                    If CInt(asMatch.Groups(1).Value) >= CInt(asMatch.Groups(2).Value) Then
                        '美人フラグ
                        Me.busyFlg = True
                    Else
                        Me.busyFlg = False
                    End If

                    If CurrentMem <> CInt(asMatch.Groups(1).Value) Then _
                    'And 音ToolStripMenuItem.CheckState _
                        If CInt(asMatch.Groups(1).Value) >= CInt(asMatch.Groups(2).Value) And _
                            Me.BaseSEBusyFlg Then

                            Me.PlaySound(Me.soundName3)

                        ElseIf CurrentMem < CInt(asMatch.Groups(1).Value) And Me.BaseSEInFlg Then

                            Me.PlaySound(Me.soundName1)

                        ElseIf CurrentMem > CInt(asMatch.Groups(1).Value) And Me.BaseSEOutFlg Then

                            Me.PlaySound(Me.soundName2)

                        End If
                    End If
                    CurrentMem = CInt(asMatch.Groups(1).Value)

                Else
                    mtTitle = pss.MainWindowTitle
                End If

                If Message <> mtTitle Then
                    Label1.Text = mtTitle
                    Message = mtTitle
                    RePaintFlg = True
                End If
            Catch
                Label1.Text = "Not Defined"
                Message = "Not Defined"
                currentId = 0
            End Try
        End If

    End Sub

    Private Sub 背景透過ToolStripMenuItem_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles 背景透過ToolStripMenuItem.CheckStateChanged
        'チェックされてたら背景透過フラグオン()
        If 背景透過ToolStripMenuItem.CheckState Then
            noBGFlg = True
        Else
            noBGFlg = False

        End If
        RePaintFlg = True
    End Sub

    Private Sub 透過()
        
        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
        Dim path2 As New System.Drawing.Drawing2D.GraphicsPath()
        Dim g As Graphics = Me.f2.CreateGraphics()
        Dim gs As Graphics = Me.f3.CreateGraphics()

        'If Me.dialog2.CheckBox05.CheckState = CheckState.Checked Then
        '    g.TextRenderingHint = TextRenderingHint.AntiAlias
        '    gs.TextRenderingHint = TextRenderingHint.AntiAlias

        'End If


        Dim brs1 As SolidBrush
        If Me.BaseBusyHotFlg And Me.busyFlg Then
            brs1 = New SolidBrush(Color.Red)
        Else
            brs1 = New SolidBrush(Me.BaseFontColor)
        End If
        Dim brs2 As Pen
        Dim brs3 As SolidBrush = New SolidBrush(Me.BaseFontShade)

        'フォントオブジェクトの作成
        Dim fnt As New Font(Label1.Font.FontFamily, Label1.Size.Height, _
                       Label1.Font.Style, GraphicsUnit.Pixel)
        'StringFormatオブジェクトの作成
        Dim sf As New StringFormat
        Dim stringSize As SizeF = _
        g.MeasureString(Message, fnt, 65535, sf)
        If stringSize.Height = 0 Or stringSize.Width = 0 Then
            stringSize.Height = 1
            stringSize.Width = 1
        End If

        Dim bBuf As New Bitmap(CInt(stringSize.Width * 1.17), CInt(stringSize.Height * 1.17))
        Dim gBuf As Graphics = Graphics.FromImage(bBuf)

        If Me.BaseAntiAriasFlg Then
            gBuf.SmoothingMode = SmoothingMode.AntiAlias
            'gBuf.PixelOffsetMode = PixelOffsetMode.HighQuality
        End If



        gBuf.Clear(Color.Transparent)
        'Debug.Print(bBuf.GetPixel(Int(bBuf.Width / 2), 0).ToString)


        If Me.BaseFontShadeOn Then
            path2.AddString(Message, Label1.Font.FontFamily, _
                       Label1.Font.Style, Label1.Font.Height, New Point(3, 3), _
                       StringFormat.GenericDefault)
            '文字列の中を塗りつぶす
            gBuf.FillPath(brs3, path2)
        End If

        path.AddString(Message, Label1.Font.FontFamily, _
            Label1.Font.Style, Label1.Font.Height, New Point(0, 0), _
            StringFormat.GenericDefault)

        If Me.BaseFontBorderWidth <> 0 Then
            brs2 = New Pen(Me.BaseFontBorder, Me.BaseFontBorderWidth)

            '文字列の縁を描画する
            gBuf.DrawPath(brs2, path)
            brs2.Dispose()

        End If

        '文字列の中を塗りつぶす
        gBuf.FillPath(brs1, path)

        Dim drawPoint As Point
        If Me.BaseAlignRightFlg Then
            drawPoint = New Point(Me.f2.Location.X + Me.f2.Width - stringSize.Width * 1.17, Me.f2.Location.Y)
        Else
            drawPoint = New Point(Me.f2.Location.X, Me.f2.Location.Y)
        End If

        Me.f2.Height = stringSize.Height * 1.17
        Me.f2.Width = stringSize.Width * 1.17
        Me.f3.Height = stringSize.Height * 1.17
        Me.f3.Width = stringSize.Width * 1.17

        'Debug.Print(stringSize.Height)
        'Debug.Print(stringSize.Width)

        Me.f2.Location = drawPoint
        Me.f3.Location = drawPoint

        g.Clear(Color.White)
        g.DrawImage(bBuf, 0, 0)

        gs.Clear(Color.White)
        gs.DrawImage(bBuf, 0, 0)

        'bBuf.MakeTransparent(Color.White)

        'リソースを開放する
        bBuf.Dispose()
        gBuf.Dispose()
        'gp.Dispose()
        g.Dispose()
        brs1.Dispose()
        brs3.Dispose()

        'フォームのアルファ値を設定する
        Me.f2.Opacity = BaseFontAlpha / 255
        Me.f3.Opacity = BaseFontAlpha / 255

    End Sub


    Sub 透過戻す()
        'Me.f2.Close()
        'Me.f3.Close()
        Me.f2.Visible = False
        Me.f3.Visible = False

    End Sub

    Private Sub 背景透過ToolStripMenuItem1_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles 背景透過ToolStripMenuItem1.CheckStateChanged
        'チェックされてたら背景透過フラグオン()
        If 背景透過ToolStripMenuItem1.CheckState Then
            noBGFlg = True
        Else
            noBGFlg = False

        End If
        RePaintFlg = True
    End Sub

    Private Sub フォントToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles フォントToolStripMenuItem.Click


        If Me.fontDetail.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.RePaintFlg = True
        End If

    End Sub

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If

    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y
        End If

    End Sub

    Private Sub プロセスToolStripMenuItem_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles プロセスToolStripMenuItem.DropDownItemClicked
        currentId = e.ClickedItem.Tag

    End Sub

    Private Sub プロセスToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles プロセスToolStripMenuItem.DropDownOpening
        Dim p As Process
        Dim tsi As ToolStripMenuItem

        'プロセス名を全部消す
        プロセスToolStripMenuItem.DropDownItems.Clear()

        For Each p In Process.GetProcesses()
            If Not p.MainWindowTitle = "" Then

                'Debug.Print(p.ProcessName + p.MainWindowTitle)
                'プロセス名を選択肢に入れる
                tsi = New ToolStripMenuItem()
                tsi.Text = p.ProcessName
                tsi.Tag = p.Id

                プロセスToolStripMenuItem.DropDownItems.Add(tsi)

            End If
        Next
    End Sub

    Private Sub ばじょんToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ばじょんToolStripMenuItem.Click
        Dialog1.ShowDialog()
    End Sub

    Private Sub 時計ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 時計ToolStripMenuItem.Click
        currentId = 0

    End Sub

    'エントリポイント
    Public Sub Save()
        '保存先のファイル名

        '保存するクラス(SampleClass)のインスタンスを作成
        Dim cls As New SaveDataClass
        'cls.UMessage = Message
        'If Not pss Is Nothing Then
        '    cls.UProcessName = pss.ProcessName
        'Else
        '    cls.UProcessName = "kagami"
        'End If

        Call SetSaveData(cls)

        'XmlSerializerオブジェクトを作成
        '書き込むオブジェクトの型を指定する
        'Dim serializer As _
        '    New System.Xml.Serialization.XmlSerializer( _
        '        GetType(SaveDataClass))

        ''OpenFileDialogクラスのインスタンスを作成
        'Dim ofd As New OpenFileDialog()

        ''はじめのファイル名を指定する
        ''はじめに「ファイル名」で表示される文字列を指定する
        'ofd.FileName = fileName
        ''[ファイルの種類]に表示される選択肢を指定する
        ''指定しないとすべてのファイルが表示される
        'ofd.Filter = "XMLファイル(*.xml)|*.xml"
        ''[ファイルの種類]ではじめに
        ''「すべてのファイル」が選択されているようにする
        'ofd.FilterIndex = 0
        ''タイトルを設定する
        'ofd.Title = "開くファイルを選択してください"
        ''ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        'ofd.RestoreDirectory = True

        ''ダイアログを表示する
        'If ofd.ShowDialog() = DialogResult.OK Then

        ''ファイルを開く
        'Dim fs As New System.IO.FileStream( _
        '    fileName, System.IO.FileMode.Create)
        ''シリアル化し、XMLファイルに保存する
        'serializer.Serialize(fs, cls)
        ''閉じる
        'fs.Close()

        'End If
    End Sub

    Function CalcFontStyle(ByVal vFont As Font) As FontStyle
        CalcFontStyle = FontStyle.Regular

        If vFont.Bold Then
            CalcFontStyle += FontStyle.Bold
        End If
        If vFont.Italic Then
            CalcFontStyle += FontStyle.Italic
        End If
        If vFont.Underline Then
            CalcFontStyle += FontStyle.Underline
        End If
        If vFont.Strikeout Then
            CalcFontStyle += FontStyle.Strikeout
        End If
    End Function

    Private Sub 人数表示変換_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 人数表示変換.Click
        If 人数表示変換.Checked Then
            noIMFlg = True
        Else
            noIMFlg = False
        End If
        Me.RePaintFlg = True
    End Sub

    Private Sub メッセージ編集_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles メッセージ編集.Click
        If MessageDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.defaultIMMessage = MessageDialog.編集.Text
            Me.RePaintFlg = True
        End If
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.dialog2.CheckBox02.CheckState = CheckState.Checked Then
            Me.ShowInTaskbar = False
            NotifyIcon1.Visible = True
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Visible = False
            Else
                Me.Visible = True
            End If

        End If

    End Sub

    Private Sub NotifyIcon1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Visible = True
            If (Me.WindowState = FormWindowState.Minimized) Then _
                    Me.WindowState = FormWindowState.Normal
            Me.Activate()
        End If
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub 時計ToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles 時計ToolStripMenuItem2.Click
        currentId = 0
    End Sub

    Private Sub 読み込みToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 読み込みToolStripMenuItem.Click
        'XmlSerializerオブジェクトの作成
        Dim serializer As _
            New System.Xml.Serialization.XmlSerializer( _
                GetType(SaveDataClass))

        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        ofd.FileName = fileName
        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        ofd.Filter = "XMLファイル(*.xml)|*.xml"
        '[ファイルの種類]ではじめに
        '「すべてのファイル」が選択されているようにする
        ofd.FilterIndex = 0
        'タイトルを設定する
        ofd.Title = "開くファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True

        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then

            'ファイルを開く
            Dim fs As New System.IO.FileStream( _
                ofd.FileName, System.IO.FileMode.Open)

            'XMLファイルから読み込み、逆シリアル化する
            Dim cls As SaveDataClass = _
                CType(serializer.Deserialize(fs), SaveDataClass)
            '閉じる
            fs.Close()

            Dim fontstyle As FontStyle = cls.UFontStyle
            Me.Label1.Font = New Font(cls.UFontFamily, cls.UFontSize, fontstyle)

            BaseFontColor = Color.FromArgb(cls.UBaseFontColor)
            BaseFontBorder = Color.FromArgb(cls.UBaseFontBorder)
            BaseFontBorderWidth = cls.UBaseFontBorderWidth
            BaseFontShade = Color.FromArgb(cls.UBaseFontShade)
            BaseFontShadeOn = cls.UBaseFontShadeOn

            defaultIMMessage = cls.UDefaultIMMessage
            '終了時に変更を保存ToolStripMenuItem.CheckState = cls.USaveAuto
            '音ToolStripMenuItem.CheckState = cls.USaveSound
        End If
    End Sub

    Private Sub 保存ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 保存ToolStripMenuItem.Click
        If MessageBox.Show("現在の情報を保存しますか？", "保存", _
                MessageBoxButtons.YesNo, _
                MessageBoxIcon.Information) Then
            Save()
        End If
    End Sub

    Private Sub 終了時に変更を保存ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub オプションToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles オプションToolStripMenuItem.Click
        Me.dialog2.ShowDialog(Me)
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

    End Sub

    Private Sub FontDialog1_Apply(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontDialog1.Apply

    End Sub

    Private Sub SetSaveData(ByRef cls As SaveDataClass)
        cls.UFontFamily = Label1.Font.FontFamily.Name
        cls.UFontStyle = CalcFontStyle(Label1.Font)
        cls.UFontSize = Label1.Font.Size

        cls.UBaseFontColor = BaseFontColor.ToArgb
        cls.UBaseFontBorder = BaseFontBorder.ToArgb
        cls.UBaseFontBorderWidth = BaseFontBorderWidth
        cls.UBaseFontShade = BaseFontShade.ToArgb
        cls.UBaseFontShadeOn = BaseFontShadeOn
        cls.UBaseFontAlpha = BaseFontAlpha

        cls.UDefaultIMMessage = defaultIMMessage

        cls.UJimakuDisplay = IIf(背景透過ToolStripMenuItem.CheckState = CheckState.Checked, True, False)
        cls.URegNumber = IIf(人数表示変換.CheckState = CheckState.Checked, True, False)

        cls.UJimakuLocation = Me.f2.Location
        cls.UJimakuSize = Me.f2.Size

        cls.UOptMostTop = IIf(Me.dialog2.CheckBox01.CheckState = CheckState.Checked, True, False)
        cls.UOptTaskTray = IIf(Me.dialog2.CheckBox02.CheckState = CheckState.Checked, True, False)

        cls.UOptAlignRight = Me.BaseAlignRightFlg
        cls.UOptHotBusy = Me.BaseBusyHotFlg
        cls.UOptAntiArias = Me.BaseAntiAriasFlg

        'SE情報
        '進入時フラグ
        cls.USEIn = Me.BaseSEInFlg
        '退出時フラグ
        cls.USEOut = Me.BaseSEOutFlg
        '美人時フラグ
        cls.USEBusy = Me.BaseSEBusyFlg
        '進入時サウンド
        cls.USEInSound = Me.soundName1
        '退出時サウンド
        cls.USEOutSound = Me.soundName2
        '美人時サウンド
        cls.USEBusySound = Me.soundName3

        cls.UIntervalTime = Timer1.Interval

    End Sub

    Private Sub GetSaveData(ByRef cls As SaveDataClass)
        Dim fontstyle As FontStyle = cls.UFontStyle
        Me.Label1.Font = New Font(cls.UFontFamily, cls.UFontSize, fontstyle)

        BaseFontColor = Color.FromArgb(cls.UBaseFontColor)
        BaseFontBorder = Color.FromArgb(cls.UBaseFontBorder)
        BaseFontBorderWidth = cls.UBaseFontBorderWidth
        BaseFontShade = Color.FromArgb(cls.UBaseFontShade)
        BaseFontShadeOn = cls.UBaseFontShadeOn
        BaseFontAlpha = cls.UBaseFontAlpha

        defaultIMMessage = cls.UDefaultIMMessage

        If cls.UJimakuDisplay Then
            背景透過ToolStripMenuItem.CheckState = CheckState.Checked
            背景透過ToolStripMenuItem1.CheckState = CheckState.Checked
            noBGFlg = True
        Else
            背景透過ToolStripMenuItem.CheckState = CheckState.Unchecked
            背景透過ToolStripMenuItem1.CheckState = CheckState.Unchecked
            noBGFlg = False
        End If
        If cls.URegNumber Then
            人数表示変換.CheckState = CheckState.Checked
            noIMFlg = True
        Else
            人数表示変換.CheckState = CheckState.Unchecked
            noIMFlg = False
        End If

        Me.f2.Location = cls.UJimakuLocation
        Me.f3.Location = cls.UJimakuLocation
        Me.f2.Size = cls.UJimakuSize
        Me.f3.Size = cls.UJimakuSize

        If cls.UOptMostTop Then
            Me.dialog2.CheckBox01.CheckState = CheckState.Checked
            Me.f2.TopMost = True
            Me.f3.TopMost = True
        Else
            Me.dialog2.CheckBox01.CheckState = CheckState.Unchecked
            Me.f2.TopMost = False
            Me.f3.TopMost = False
        End If
        If cls.UOptTaskTray Then
            Me.dialog2.CheckBox02.CheckState = CheckState.Checked
            Me.ShowInTaskbar = False
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Visible = False
                Me.NotifyIcon1.Visible = True
            End If
        Else
            Me.dialog2.CheckBox02.CheckState = CheckState.Unchecked
            Me.Visible = True
            If (Me.WindowState = FormWindowState.Minimized) Then _
                    Me.WindowState = FormWindowState.Normal
            Me.Activate()
            Me.ShowInTaskbar = True
            Me.NotifyIcon1.Visible = False
        End If

        Me.BaseAlignRightFlg = cls.UOptAlignRight
        If Me.BaseAlignRightFlg Then
            Me.dialog2.CheckBox03.CheckState = CheckState.Checked
        Else
            Me.dialog2.CheckBox03.CheckState = CheckState.Unchecked
        End If
        Me.BaseBusyHotFlg = cls.UOptHotBusy
        If Me.BaseBusyHotFlg Then
            Me.dialog2.CheckBox04.CheckState = CheckState.Checked
        Else
            Me.dialog2.CheckBox04.CheckState = CheckState.Unchecked
        End If
        Me.BaseAntiAriasFlg = cls.UOptAntiArias
        If Me.BaseAntiAriasFlg Then
            Me.dialog2.CheckBox05.CheckState = CheckState.Checked
        Else
            Me.dialog2.CheckBox05.CheckState = CheckState.Unchecked
        End If

        'SE情報
        '進入時フラグ
        Me.BaseSEInFlg = cls.USEIn
        If Me.BaseSEInFlg Then
            Me.dialog2.CheckBox_SE01.CheckState = CheckState.Checked
        Else
            Me.dialog2.CheckBox_SE01.CheckState = CheckState.Unchecked
        End If
        '退出時フラグ
        Me.BaseSEOutFlg = cls.USEOut
        If Me.BaseSEOutFlg Then
            Me.dialog2.CheckBox_SE02.CheckState = CheckState.Checked
        Else
            Me.dialog2.CheckBox_SE02.CheckState = CheckState.Unchecked
        End If
        '美人時フラグ
        Me.BaseSEBusyFlg = cls.USEBusy
        If Me.BaseSEBusyFlg Then
            Me.dialog2.CheckBox_SE03.CheckState = CheckState.Checked
        Else
            Me.dialog2.CheckBox_SE03.CheckState = CheckState.Unchecked
        End If

        '進入時サウンド
        Me.dialog2.ComboBox1.Text = cls.USEInSound
        Me.soundName1 = cls.USEInSound

        '退出時サウンド
        Me.dialog2.ComboBox2.Text = cls.USEOutSound
        Me.soundName2 = cls.USEOutSound
        '美人時サウンド
        Me.dialog2.ComboBox3.Text = cls.USEBusySound
        Me.soundName3 = cls.USEBusySound

        Timer1.Interval = cls.UIntervalTime
        Me.dialog2.更新間隔.Text = cls.UIntervalTime

    End Sub

End Class

Public Class SaveDataClass
    'Public UMessage As String
    'Public UProcessName As String

    'フォント基本情報
    Public UFontFamily As String
    '４項目加算
    Public UFontStyle As Integer

    Public UFontSize As Single

    'フォント色
    Public UBaseFontColor As Integer
    '縁取り
    Public UBaseFontBorder As Integer
    '縁取り幅
    Public UBaseFontBorderWidth As Integer
    '影
    Public UBaseFontShade As Integer
    '影有無
    Public UBaseFontShadeOn As Boolean
    'アルファ値
    Public UBaseFontAlpha As Integer

    '表示情報
    '字幕表示
    Public UJimakuDisplay As Integer
    '人数計算
    Public URegNumber As Integer

    '字幕位置情報
    Public UJimakuLocation As Point
    Public UJimakuSize As Size


    '///////////////////
    'オプション情報
    '常に最前面に表示
    Public UOptMostTop As Boolean
    'タスクトレイに格納する
    Public UOptTaskTray As Boolean
    '字幕を右寄せにする
    Public UOptAlignRight As Boolean
    '美人のとき赤くする
    Public UOptHotBusy As Boolean
    'アンチエイリアスをかける
    Public UOptAntiArias As Boolean

    '///////////////////
    'SE情報
    '進入時フラグ
    Public USEIn As Boolean
    '退出時フラグ
    Public USEOut As Boolean
    '美人時フラグ
    Public USEBusy As Boolean
    '進入時サウンド
    Public USEInSound As String
    '退出時サウンド
    Public USEOutSound As String
    '美人時サウンド
    Public USEBusySound As String

    Public UDefaultIMMessage As String

    '更新時間
    Public UIntervalTime As Integer

End Class
