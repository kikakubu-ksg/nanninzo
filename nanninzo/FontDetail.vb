Imports System.Windows.Forms

Public Class FontDetail

    Dim myForm1 As Form1
    Public pFont As Font
    Dim noChgFlg As Boolean = False


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        myForm1.BaseFontColor = �t�H���g�F.BackColor
        myForm1.BaseFontBorder = �����.BackColor
        myForm1.BaseFontBorderWidth = ����蕝.Value
        myForm1.BaseFontShade = �e.BackColor
        myForm1.BaseFontShadeOn = �e����.Checked
        myForm1.BaseFontAlpha = Me.TrackBar1.Value
        myForm1.Label1.Font = pFont.Clone
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FontDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        FontDialog1.Font = New Font(pFont.Name, pFont.Size, CalcFontStyle())

        FontDialog1.ShowDialog()

        pFont = New Font(FontDialog1.Font.Name, FontDialog1.Font.Size, _
        CalcFontStyle2())
        noChgFlg = True
        ����.Checked = pFont.Bold
        �Α�.Checked = pFont.Italic
        noChgFlg = False
        doFin()

    End Sub


    Private Sub �t�H���g�F_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �t�H���g�F.Click
        ColorDialog1.Color = �t�H���g�F.BackColor
        ColorDialog1.ShowDialog()
        �t�H���g�F.BackColor = ColorDialog1.Color
        doFin()

    End Sub

    Private Sub �����_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �����.Click
        ColorDialog1.Color = �����.BackColor
        ColorDialog1.ShowDialog()
        �����.BackColor = ColorDialog1.Color
        doFin()
    End Sub

    Private Sub �e_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �e.Click

        ColorDialog1.Color = �e.BackColor
        ColorDialog1.ShowDialog()
        �e.BackColor = ColorDialog1.Color
        doFin()
    End Sub

    Sub doFin()
        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
        Dim path2 As New System.Drawing.Drawing2D.GraphicsPath()
        Dim g As Graphics = ����Ȋ���.CreateGraphics()

        Dim brs1 As SolidBrush = New SolidBrush(Color.FromArgb(Me.TrackBar1.Value, �t�H���g�F.BackColor))
        Dim brs2 As Pen
        Dim brs3 As SolidBrush = New SolidBrush(Color.FromArgb(Me.TrackBar1.Value, �e.BackColor))

        g.Clear(Color.White)

        If �e����.Checked Then
            path2.AddString(����Ȋ���.Text, pFont.FontFamily, _
                       pFont.Style, pFont.Height, New Point(3, 3), _
                       StringFormat.GenericDefault)


            '������̒���h��Ԃ�
            g.FillPath(brs3, path2)
        End If

        path.AddString(����Ȋ���.Text, pFont.FontFamily, _
            pFont.Style, pFont.Height, New Point(0, 0), _
            StringFormat.GenericDefault)

        If ����蕝.Value <> 0 Then
            brs2 = New Pen(Color.FromArgb(Me.TrackBar1.Value, �����.BackColor), ����蕝.Value)

            '������̉���`�悷��
            g.DrawPath(brs2, path)
            brs2.Dispose()

        End If

        '������̒���h��Ԃ�
        g.FillPath(brs1, path)

        '���\�[�X���J������
        g.Dispose()
        brs1.Dispose()
        brs3.Dispose()

        �t�H���g��.Text = pFont.FontFamily.Name
        �t�H���g�T�C�Y.Text = pFont.Size

    End Sub

    Private Sub �e����_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �e����.CheckedChanged
        doFin()
    End Sub

    Public Sub New(ByRef f As Form1)
        InitializeComponent()
        myForm1 = f
        'pFont = New Font(myForm1.Label1.Font.FontFamily, myForm1.Label1.Font.Size, myForm1.CalcFontStyle(myForm1.Label1.Font))
        pFont = myForm1.Label1.Font.Clone
        'pFont = New Font(Form1.Label1.Font.FontFamily, Form1.Label1.Font.Size, Form1.CalcFontStyle(Form1.Label1.Font))

        noChgFlg = True

        ����.Checked = pFont.Bold
        �Α�.Checked = pFont.Italic
        ����.Checked = pFont.Underline
        ��������.Checked = pFont.Strikeout

        �t�H���g�F.BackColor = myForm1.BaseFontColor
        �����.BackColor = myForm1.BaseFontBorder
        ����蕝.Value = myForm1.BaseFontBorderWidth
        �e.BackColor = myForm1.BaseFontShade
        �e����.Checked = myForm1.BaseFontShadeOn

        �t�H���g��.Text = pFont.FontFamily.Name
        �t�H���g�T�C�Y.Text = pFont.Size

        noChgFlg = False

        ' ���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B


        ' InitializeComponent() �Ăяo���̌�ŏ�������ǉ����܂��B



    End Sub

    Private Sub ����_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����.CheckedChanged
        If Not noChgFlg Then
            pFont = New Font(pFont.Name, pFont.Size, CalcFontStyle())
            doFin()
        End If
    End Sub

    Private Sub �Α�_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �Α�.CheckedChanged
        If Not noChgFlg Then
            pFont = New Font(pFont.Name, pFont.Size, CalcFontStyle())
            doFin()
        End If
    End Sub
    Private Sub ����_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����.CheckedChanged
        If Not noChgFlg Then
            pFont = New Font(pFont.Name, pFont.Size, CalcFontStyle())
            doFin()
        End If
    End Sub

    Private Sub ��������_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��������.CheckedChanged
        If Not noChgFlg Then
            pFont = New Font(pFont.Name, pFont.Size, CalcFontStyle())
            doFin()
        End If
    End Sub

    Function CalcFontStyle() As FontStyle
        CalcFontStyle = FontStyle.Regular

        If ����.Checked Then
            CalcFontStyle += FontStyle.Bold
        End If
        If �Α�.Checked Then
            CalcFontStyle += FontStyle.Italic
        End If
        If ����.Checked Then
            CalcFontStyle += FontStyle.Underline
        End If
        If ��������.Checked Then
            CalcFontStyle += FontStyle.Strikeout
        End If
    End Function

    Function CalcFontStyle2() As FontStyle
        CalcFontStyle2 = FontStyle.Regular

        If FontDialog1.Font.Bold Then
            CalcFontStyle2 += FontStyle.Bold
        End If
        If FontDialog1.Font.Italic Then
            CalcFontStyle2 += FontStyle.Italic
        End If
        If ����.Checked Then
            CalcFontStyle2 += FontStyle.Underline
        End If
        If ��������.Checked Then
            CalcFontStyle2 += FontStyle.Strikeout
        End If
    End Function

   
    Private Sub �ĕ`��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �ĕ`��.Click
        doFin()
    End Sub

    Private Sub ����蕝_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����蕝.ValueChanged
        doFin()
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Me.alphaVal.Text = Me.TrackBar1.Value
        pFont = New Font(pFont.Name, pFont.Size, CalcFontStyle())
        doFin()
    End Sub
End Class
