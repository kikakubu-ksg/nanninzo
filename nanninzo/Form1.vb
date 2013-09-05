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

    '�f�t�H���g���b�Z�[�W�t�H�[�}�b�g
    Public defaultIMMessage As String = "����$1�l�����Ă��B�ő�$2�l�܂�ok����B"

    'Dim pathBs As New System.Drawing.Drawing2D.GraphicsPath()


    '�w�i���߃t���O
    Dim noBGFlg As Boolean = False
    '�l���\���ϊ��t���O
    Dim noIMFlg As Boolean = False

    '���l�t���O
    Dim busyFlg As Boolean = False

    Private mousePoint As Point

    Dim defaultWindow As String = "kagami"
    Dim currentId As Integer = 0

    '�t�H���g��{���
    '�t�H���g�F
    Public BaseFontColor As Color = Color.Black
    '�����
    Public BaseFontBorder As Color = Color.White
    '����蕝
    Public BaseFontBorderWidth As Integer = 0
    '�e
    Public BaseFontShade As Color = Color.White
    '�e�L��
    Public BaseFontShadeOn As Boolean = False
    '�A���t�@�l
    Public BaseFontAlpha As Integer = 0



    '/////////////////
    '�I�v�V�����t���O

    '�E��
    Public BaseAlignRightFlg As Boolean = False
    '���l���ԐF
    Public BaseBusyHotFlg As Boolean = False
    '�A���`�G�C���A�X
    Public BaseAntiAriasFlg As Boolean = True

    'SE
    Public BaseSEInFlg As Boolean = False
    Public BaseSEOutFlg As Boolean = False
    Public BaseSEBusyFlg As Boolean = False


    '�ĕ`�ʃt���O
    Public RePaintFlg As Boolean = True

    '���ݐl��
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
        '    MessageBox.Show("�t�@�C���̍Đ��Ɏ��s���܂����B" + Application.StartupPath + "\" + soundName)
        'End Try
    End Sub

    Public Shared Sub Main()

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        'If �I�����ɕύX��ۑ�ToolStripMenuItem.CheckState = 1 Then
        'If DialogResult.Yes = _
        '    MessageBox.Show("���݂̏���ۑ����܂����H", "����S(*�L�́M*)�", _
        '    MessageBoxButtons.YesNo, _
        '    MessageBoxIcon.Information) Then
        Save()
        'End If
        'End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        'If System.IO.File.Exists(fileName) Then
        '    'XmlSerializer�I�u�W�F�N�g�̍쐬
        '    Dim serializer As _
        '        New System.Xml.Serialization.XmlSerializer( _
        '            GetType(SaveDataClass))

        '    '�t�@�C�����J��
        '    Dim fs As New System.IO.FileStream( _
        '        fileName, System.IO.FileMode.Open)
        '    'XML�t�@�C������ǂݍ��݁A�t�V���A��������
        '    Dim cls As SaveDataClass = _
        '        CType(serializer.Deserialize(fs), SaveDataClass)
        '    '����
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

                Call ����()
                RePaintFlg = False
            End If
        Else
            Call ���ߖ߂�()
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

        '�t�@�C���ǂݍ��ݏ����l

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

                    Message = String.Format("{0:HH��mm��ss�b}", Now())

                ElseIf Me.dialog2.RadioButton4.Checked Then
                    Message = String.Format("{0:yyyy�NMM��dd�� HH��mm��ss�b}", Now())

                ElseIf Me.dialog2.RadioButton5.Checked Then
                    Message = String.Format("{0:HH:mm:ss.fff}", Now())


                ElseIf Me.dialog2.RadioButton6.Checked Then
                    '�t���[�̂Ƃ�
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
                        '���l�t���O
                        Me.busyFlg = True
                    Else
                        Me.busyFlg = False
                    End If

                    If CurrentMem <> CInt(asMatch.Groups(1).Value) Then _
                    'And ��ToolStripMenuItem.CheckState _
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

    Private Sub �w�i����ToolStripMenuItem_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles �w�i����ToolStripMenuItem.CheckStateChanged
        '�`�F�b�N����Ă���w�i���߃t���O�I��()
        If �w�i����ToolStripMenuItem.CheckState Then
            noBGFlg = True
        Else
            noBGFlg = False

        End If
        RePaintFlg = True
    End Sub

    Private Sub ����()
        
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

        '�t�H���g�I�u�W�F�N�g�̍쐬
        Dim fnt As New Font(Label1.Font.FontFamily, Label1.Size.Height, _
                       Label1.Font.Style, GraphicsUnit.Pixel)
        'StringFormat�I�u�W�F�N�g�̍쐬
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
            '������̒���h��Ԃ�
            gBuf.FillPath(brs3, path2)
        End If

        path.AddString(Message, Label1.Font.FontFamily, _
            Label1.Font.Style, Label1.Font.Height, New Point(0, 0), _
            StringFormat.GenericDefault)

        If Me.BaseFontBorderWidth <> 0 Then
            brs2 = New Pen(Me.BaseFontBorder, Me.BaseFontBorderWidth)

            '������̉���`�悷��
            gBuf.DrawPath(brs2, path)
            brs2.Dispose()

        End If

        '������̒���h��Ԃ�
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

        '���\�[�X���J������
        bBuf.Dispose()
        gBuf.Dispose()
        'gp.Dispose()
        g.Dispose()
        brs1.Dispose()
        brs3.Dispose()

        '�t�H�[���̃A���t�@�l��ݒ肷��
        Me.f2.Opacity = BaseFontAlpha / 255
        Me.f3.Opacity = BaseFontAlpha / 255

    End Sub


    Sub ���ߖ߂�()
        'Me.f2.Close()
        'Me.f3.Close()
        Me.f2.Visible = False
        Me.f3.Visible = False

    End Sub

    Private Sub �w�i����ToolStripMenuItem1_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles �w�i����ToolStripMenuItem1.CheckStateChanged
        '�`�F�b�N����Ă���w�i���߃t���O�I��()
        If �w�i����ToolStripMenuItem1.CheckState Then
            noBGFlg = True
        Else
            noBGFlg = False

        End If
        RePaintFlg = True
    End Sub

    Private Sub �t�H���gToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �t�H���gToolStripMenuItem.Click


        If Me.fontDetail.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.RePaintFlg = True
        End If

    End Sub

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '�ʒu���L������
            mousePoint = New Point(e.X, e.Y)
        End If

    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y
        End If

    End Sub

    Private Sub �v���Z�XToolStripMenuItem_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles �v���Z�XToolStripMenuItem.DropDownItemClicked
        currentId = e.ClickedItem.Tag

    End Sub

    Private Sub �v���Z�XToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles �v���Z�XToolStripMenuItem.DropDownOpening
        Dim p As Process
        Dim tsi As ToolStripMenuItem

        '�v���Z�X����S������
        �v���Z�XToolStripMenuItem.DropDownItems.Clear()

        For Each p In Process.GetProcesses()
            If Not p.MainWindowTitle = "" Then

                'Debug.Print(p.ProcessName + p.MainWindowTitle)
                '�v���Z�X����I�����ɓ����
                tsi = New ToolStripMenuItem()
                tsi.Text = p.ProcessName
                tsi.Tag = p.Id

                �v���Z�XToolStripMenuItem.DropDownItems.Add(tsi)

            End If
        Next
    End Sub

    Private Sub �΂����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �΂����ToolStripMenuItem.Click
        Dialog1.ShowDialog()
    End Sub

    Private Sub ���vToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���vToolStripMenuItem.Click
        currentId = 0

    End Sub

    '�G���g���|�C���g
    Public Sub Save()
        '�ۑ���̃t�@�C����

        '�ۑ�����N���X(SampleClass)�̃C���X�^���X���쐬
        Dim cls As New SaveDataClass
        'cls.UMessage = Message
        'If Not pss Is Nothing Then
        '    cls.UProcessName = pss.ProcessName
        'Else
        '    cls.UProcessName = "kagami"
        'End If

        Call SetSaveData(cls)

        'XmlSerializer�I�u�W�F�N�g���쐬
        '�������ރI�u�W�F�N�g�̌^���w�肷��
        'Dim serializer As _
        '    New System.Xml.Serialization.XmlSerializer( _
        '        GetType(SaveDataClass))

        ''OpenFileDialog�N���X�̃C���X�^���X���쐬
        'Dim ofd As New OpenFileDialog()

        ''�͂��߂̃t�@�C�������w�肷��
        ''�͂��߂Ɂu�t�@�C�����v�ŕ\������镶������w�肷��
        'ofd.FileName = fileName
        ''[�t�@�C���̎��]�ɕ\�������I�������w�肷��
        ''�w�肵�Ȃ��Ƃ��ׂẴt�@�C�����\�������
        'ofd.Filter = "XML�t�@�C��(*.xml)|*.xml"
        ''[�t�@�C���̎��]�ł͂��߂�
        ''�u���ׂẴt�@�C���v���I������Ă���悤�ɂ���
        'ofd.FilterIndex = 0
        ''�^�C�g����ݒ肷��
        'ofd.Title = "�J���t�@�C����I�����Ă�������"
        ''�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���
        'ofd.RestoreDirectory = True

        ''�_�C�A���O��\������
        'If ofd.ShowDialog() = DialogResult.OK Then

        ''�t�@�C�����J��
        'Dim fs As New System.IO.FileStream( _
        '    fileName, System.IO.FileMode.Create)
        ''�V���A�������AXML�t�@�C���ɕۑ�����
        'serializer.Serialize(fs, cls)
        ''����
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

    Private Sub �l���\���ϊ�_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �l���\���ϊ�.Click
        If �l���\���ϊ�.Checked Then
            noIMFlg = True
        Else
            noIMFlg = False
        End If
        Me.RePaintFlg = True
    End Sub

    Private Sub ���b�Z�[�W�ҏW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���b�Z�[�W�ҏW.Click
        If MessageDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.defaultIMMessage = MessageDialog.�ҏW.Text
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

    Private Sub �I��ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles �I��ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ���vToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ���vToolStripMenuItem2.Click
        currentId = 0
    End Sub

    Private Sub �ǂݍ���ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �ǂݍ���ToolStripMenuItem.Click
        'XmlSerializer�I�u�W�F�N�g�̍쐬
        Dim serializer As _
            New System.Xml.Serialization.XmlSerializer( _
                GetType(SaveDataClass))

        'OpenFileDialog�N���X�̃C���X�^���X���쐬
        Dim ofd As New OpenFileDialog()

        '�͂��߂̃t�@�C�������w�肷��
        '�͂��߂Ɂu�t�@�C�����v�ŕ\������镶������w�肷��
        ofd.FileName = fileName
        '[�t�@�C���̎��]�ɕ\�������I�������w�肷��
        '�w�肵�Ȃ��Ƃ��ׂẴt�@�C�����\�������
        ofd.Filter = "XML�t�@�C��(*.xml)|*.xml"
        '[�t�@�C���̎��]�ł͂��߂�
        '�u���ׂẴt�@�C���v���I������Ă���悤�ɂ���
        ofd.FilterIndex = 0
        '�^�C�g����ݒ肷��
        ofd.Title = "�J���t�@�C����I�����Ă�������"
        '�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���
        ofd.RestoreDirectory = True

        '�_�C�A���O��\������
        If ofd.ShowDialog() = DialogResult.OK Then

            '�t�@�C�����J��
            Dim fs As New System.IO.FileStream( _
                ofd.FileName, System.IO.FileMode.Open)

            'XML�t�@�C������ǂݍ��݁A�t�V���A��������
            Dim cls As SaveDataClass = _
                CType(serializer.Deserialize(fs), SaveDataClass)
            '����
            fs.Close()

            Dim fontstyle As FontStyle = cls.UFontStyle
            Me.Label1.Font = New Font(cls.UFontFamily, cls.UFontSize, fontstyle)

            BaseFontColor = Color.FromArgb(cls.UBaseFontColor)
            BaseFontBorder = Color.FromArgb(cls.UBaseFontBorder)
            BaseFontBorderWidth = cls.UBaseFontBorderWidth
            BaseFontShade = Color.FromArgb(cls.UBaseFontShade)
            BaseFontShadeOn = cls.UBaseFontShadeOn

            defaultIMMessage = cls.UDefaultIMMessage
            '�I�����ɕύX��ۑ�ToolStripMenuItem.CheckState = cls.USaveAuto
            '��ToolStripMenuItem.CheckState = cls.USaveSound
        End If
    End Sub

    Private Sub �ۑ�ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �ۑ�ToolStripMenuItem.Click
        If MessageBox.Show("���݂̏���ۑ����܂����H", "�ۑ�", _
                MessageBoxButtons.YesNo, _
                MessageBoxIcon.Information) Then
            Save()
        End If
    End Sub

    Private Sub �I�����ɕύX��ۑ�ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub �I�v�V����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �I�v�V����ToolStripMenuItem.Click
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

        cls.UJimakuDisplay = IIf(�w�i����ToolStripMenuItem.CheckState = CheckState.Checked, True, False)
        cls.URegNumber = IIf(�l���\���ϊ�.CheckState = CheckState.Checked, True, False)

        cls.UJimakuLocation = Me.f2.Location
        cls.UJimakuSize = Me.f2.Size

        cls.UOptMostTop = IIf(Me.dialog2.CheckBox01.CheckState = CheckState.Checked, True, False)
        cls.UOptTaskTray = IIf(Me.dialog2.CheckBox02.CheckState = CheckState.Checked, True, False)

        cls.UOptAlignRight = Me.BaseAlignRightFlg
        cls.UOptHotBusy = Me.BaseBusyHotFlg
        cls.UOptAntiArias = Me.BaseAntiAriasFlg

        'SE���
        '�i�����t���O
        cls.USEIn = Me.BaseSEInFlg
        '�ޏo���t���O
        cls.USEOut = Me.BaseSEOutFlg
        '���l���t���O
        cls.USEBusy = Me.BaseSEBusyFlg
        '�i�����T�E���h
        cls.USEInSound = Me.soundName1
        '�ޏo���T�E���h
        cls.USEOutSound = Me.soundName2
        '���l���T�E���h
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
            �w�i����ToolStripMenuItem.CheckState = CheckState.Checked
            �w�i����ToolStripMenuItem1.CheckState = CheckState.Checked
            noBGFlg = True
        Else
            �w�i����ToolStripMenuItem.CheckState = CheckState.Unchecked
            �w�i����ToolStripMenuItem1.CheckState = CheckState.Unchecked
            noBGFlg = False
        End If
        If cls.URegNumber Then
            �l���\���ϊ�.CheckState = CheckState.Checked
            noIMFlg = True
        Else
            �l���\���ϊ�.CheckState = CheckState.Unchecked
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

        'SE���
        '�i�����t���O
        Me.BaseSEInFlg = cls.USEIn
        If Me.BaseSEInFlg Then
            Me.dialog2.CheckBox_SE01.CheckState = CheckState.Checked
        Else
            Me.dialog2.CheckBox_SE01.CheckState = CheckState.Unchecked
        End If
        '�ޏo���t���O
        Me.BaseSEOutFlg = cls.USEOut
        If Me.BaseSEOutFlg Then
            Me.dialog2.CheckBox_SE02.CheckState = CheckState.Checked
        Else
            Me.dialog2.CheckBox_SE02.CheckState = CheckState.Unchecked
        End If
        '���l���t���O
        Me.BaseSEBusyFlg = cls.USEBusy
        If Me.BaseSEBusyFlg Then
            Me.dialog2.CheckBox_SE03.CheckState = CheckState.Checked
        Else
            Me.dialog2.CheckBox_SE03.CheckState = CheckState.Unchecked
        End If

        '�i�����T�E���h
        Me.dialog2.ComboBox1.Text = cls.USEInSound
        Me.soundName1 = cls.USEInSound

        '�ޏo���T�E���h
        Me.dialog2.ComboBox2.Text = cls.USEOutSound
        Me.soundName2 = cls.USEOutSound
        '���l���T�E���h
        Me.dialog2.ComboBox3.Text = cls.USEBusySound
        Me.soundName3 = cls.USEBusySound

        Timer1.Interval = cls.UIntervalTime
        Me.dialog2.�X�V�Ԋu.Text = cls.UIntervalTime

    End Sub

End Class

Public Class SaveDataClass
    'Public UMessage As String
    'Public UProcessName As String

    '�t�H���g��{���
    Public UFontFamily As String
    '�S���ډ��Z
    Public UFontStyle As Integer

    Public UFontSize As Single

    '�t�H���g�F
    Public UBaseFontColor As Integer
    '�����
    Public UBaseFontBorder As Integer
    '����蕝
    Public UBaseFontBorderWidth As Integer
    '�e
    Public UBaseFontShade As Integer
    '�e�L��
    Public UBaseFontShadeOn As Boolean
    '�A���t�@�l
    Public UBaseFontAlpha As Integer

    '�\�����
    '�����\��
    Public UJimakuDisplay As Integer
    '�l���v�Z
    Public URegNumber As Integer

    '�����ʒu���
    Public UJimakuLocation As Point
    Public UJimakuSize As Size


    '///////////////////
    '�I�v�V�������
    '��ɍőO�ʂɕ\��
    Public UOptMostTop As Boolean
    '�^�X�N�g���C�Ɋi�[����
    Public UOptTaskTray As Boolean
    '�������E�񂹂ɂ���
    Public UOptAlignRight As Boolean
    '���l�̂Ƃ��Ԃ�����
    Public UOptHotBusy As Boolean
    '�A���`�G�C���A�X��������
    Public UOptAntiArias As Boolean

    '///////////////////
    'SE���
    '�i�����t���O
    Public USEIn As Boolean
    '�ޏo���t���O
    Public USEOut As Boolean
    '���l���t���O
    Public USEBusy As Boolean
    '�i�����T�E���h
    Public USEInSound As String
    '�ޏo���T�E���h
    Public USEOutSound As String
    '���l���T�E���h
    Public USEBusySound As String

    Public UDefaultIMMessage As String

    '�X�V����
    Public UIntervalTime As Integer

End Class
