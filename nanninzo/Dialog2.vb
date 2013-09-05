Imports System.Windows.Forms

Public Class Dialog2
    <System.Runtime.InteropServices.DllImport("winmm.dll", _
    CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function mciSendString(ByVal command As String, _
    ByVal buffer As System.Text.StringBuilder, _
    ByVal bufferSize As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function

    Private aliasName As String = "MediaFile"

    Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim myForm1 As Form1 = CType(Me.Owner, Form1)
        '��ɍőO�ʂɕ\��
        If Me.CheckBox01.CheckState = CheckState.Checked Then
            myForm1.f2.TopMost = True
            myForm1.f3.TopMost = True
        Else
            myForm1.f2.TopMost = False
            myForm1.f3.TopMost = False
        End If

        '�^�X�N�g���C�Ɋi�[����
        If Me.CheckBox02.CheckState = CheckState.Checked Then
            myForm1.ShowInTaskbar = False
            If myForm1.WindowState = FormWindowState.Minimized Then
                myForm1.Visible = False
                myForm1.NotifyIcon1.Visible = True
            End If
        Else
            myForm1.Visible = True
            If (myForm1.WindowState = FormWindowState.Minimized) Then _
                    myForm1.WindowState = FormWindowState.Normal
            myForm1.Activate()
            myForm1.ShowInTaskbar = True
            myForm1.NotifyIcon1.Visible = False
        End If

        '�������E�񂹂ɂ���
        If Me.CheckBox03.CheckState = CheckState.Checked Then
            myForm1.BaseAlignRightFlg = True
        Else
            myForm1.BaseAlignRightFlg = False
        End If

        '���l�̂Ƃ��Ԃ�����
        If Me.CheckBox04.CheckState = CheckState.Checked Then
            myForm1.BaseBusyHotFlg = True
        Else
            myForm1.BaseBusyHotFlg = False
        End If

        '�A���`�G�C���A�X��������
        If Me.CheckBox05.CheckState = CheckState.Checked Then
            myForm1.BaseAntiAriasFlg = True
        Else
            myForm1.BaseAntiAriasFlg = False
        End If

        'SE
        '�i�����t���O
        If Me.CheckBox_SE01.CheckState = CheckState.Checked Then
            myForm1.BaseSEInFlg = True
        Else
            myForm1.BaseSEInFlg = False
        End If
        '�ޏo���t���O
        If Me.CheckBox_SE02.CheckState = CheckState.Checked Then
            myForm1.BaseSEOutFlg = True
        Else
            myForm1.BaseSEOutFlg = False
        End If
        '���l���t���O
        If Me.CheckBox_SE03.CheckState = CheckState.Checked Then
            myForm1.BaseSEBusyFlg = True
        Else
            myForm1.BaseSEBusyFlg = False
        End If

        myForm1.soundName1 = Me.ComboBox1.Text
        myForm1.soundName2 = Me.ComboBox2.Text
        myForm1.soundName3 = Me.ComboBox3.Text

        '�X�V�Ԋu
        myForm1.Timer1.Interval = CInt(Me.�X�V�Ԋu.Text)

        myForm1.RePaintFlg = True
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '�T�E���h�t�H���_�擾
        Dim files As ArrayList = New ArrayList()
        Call GetSEFilenames(Form1.soundDir, "*.*", files)
        Me.ComboBox1.Items.Clear()
        Me.ComboBox2.Items.Clear()
        Me.ComboBox3.Items.Clear()

        Me.ComboBox1.Items.AddRange(files.ToArray)
        Me.ComboBox2.Items.AddRange(files.ToArray)
        Me.ComboBox3.Items.AddRange(files.ToArray)

    End Sub
    Public Sub GetSEFilenames(ByVal folder As String, _
        ByVal searchPattern As String, ByRef files As ArrayList)
        'folder�ɂ���t�@�C�����擾����
        Dim fs As String() = _
            System.IO.Directory.GetFiles(folder, searchPattern)
        'ArrayList�ɒǉ�����
        files.AddRange(fs)
    End Sub
    Public Sub PlaySound(ByVal soundName As String)
        'Dim audio As Microsoft.DirectX.AudioVideoPlayback.Audio

        'Try
        '    audio = New Microsoft.DirectX.AudioVideoPlayback.Audio(Application.StartupPath + "\" + soundName)
        '    audio.Play()
        'Catch
        '    MessageBox.Show("�t�@�C���̍Đ��Ɏ��s���܂����B")
        'End Try
        '�Đ�����t�@�C����

        Dim fileName As String = soundName

        Dim cmd As String
        '�t�@�C�����J��
        cmd = "open """ + fileName + """ type mpegvideo alias " + aliasName
        If mciSendString(cmd, Nothing, 0, IntPtr.Zero) <> 0 Then
            Return
        End If '�Đ�����
        cmd = "play " + aliasName
        mciSendString(cmd, Nothing, 0, IntPtr.Zero)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.PlaySound(Me.ComboBox1.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.PlaySound(Me.ComboBox2.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form1.PlaySound(Me.ComboBox3.Text)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        OK_Button_Click(sender, e)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Cancel_Button_Click(sender, e)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        '�����R�[�h���w�肷��
        Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_jis")


        Dim lport As Integer = CInt(Me.RecPort.Text)

        Dim listener As New System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, lport)


        listener.Start()

        StartAccept(listener.Server)


        
        'Dim tcp As System.Net.Sockets.TcpClient = _
        '            listener.AcceptTcpClient()

        'Label1.Text = "�N���C�A���g���ڑ����܂����B"

        ''NetworkStream���擾
        'Dim ns As System.Net.Sockets.NetworkStream = tcp.GetStream()

        ''�N���C�A���g���瑗��ꂽ�f�[�^����M����
        'Dim ms As New System.IO.MemoryStream
        'Dim resBytes(256) As Byte
        'Dim resSize As Integer

        'Do
        '    '�f�[�^�̈ꕔ����M����
        '    resSize = ns.Read(resBytes, 0, resBytes.Length)
        '    'Read��0��Ԃ������̓N���C�A���g���ؒf�����Ɣ��f
        '    If resSize = 0 Then
        '        Label1.Text = "�N���C�A���g���ؒf���܂����B"
        '        Return
        '    End If
        '    '��M�����f�[�^��~�ς���
        '    ms.Write(resBytes, 0, resSize)
        'Loop While ns.DataAvailable

        ''��M�����f�[�^�𕶎���ɕϊ�()
        'Dim resMsg As String = enc.GetString(ms.ToArray())
        'ms.Close()

        'TextBox3.Text = resMsg

        ''�N���C�A���g�Ƀf�[�^�𑗐M����
        'Dim sendMsg As String = resMsg.Length.ToString() + "����"
        ''�������Byte�^�z��ɕϊ�
        'Dim sendBytes As Byte() = enc.GetBytes(sendMsg)
        ''�f�[�^�𑗐M����
        'ns.Write(sendBytes, 0, sendBytes.Length)
        'Console.WriteLine(sendMsg)

        ''����
        'tcp.Close()

        ''���X�i�����
        'listener.Stop()

    End Sub


    '�N���C�A���g�̐ڑ��҂��X�^�[�g
    Private Shared Sub StartAccept( _
        ByVal server As System.Net.Sockets.Socket)
        '�ڑ��v���ҋ@���J�n����
        server.BeginAccept(New System.AsyncCallback( _
            AddressOf AcceptCallback), server)
    End Sub

    'BeginAccept�̃R�[���o�b�N
    Private Shared Sub AcceptCallback(ByVal ar As System.IAsyncResult)
        '�T�[�o�[Socket�̎擾
        Dim server As System.Net.Sockets.Socket = _
            CType(ar.AsyncState, System.Net.Sockets.Socket)

        '�ڑ��v�����󂯓����
        Dim client As System.Net.Sockets.Socket = Nothing
        Try
            '�N���C�A���gSocket�̎擾
            client = server.EndAccept(ar)
        Catch
            System.Console.WriteLine("���܂����B")
            Return
        End Try

        '�N���C�A���g���瑗��ꂽ�f�[�^����M����
        Dim ms As New System.IO.MemoryStream
        Dim resBytes(256) As Byte
        Dim resSize As Integer

        Try

            'resSize = client.Receive(resBytes)
            Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_jis")

            Do
                '�f�[�^�̈ꕔ����M����
                resSize = client.Receive(resBytes)
                'Read��0��Ԃ������̓N���C�A���g���ؒf�����Ɣ��f
                If resSize = 0 Then
                    Debug.Print("�N���C�A���g���ؒf���܂����B")
                    Console.ReadLine()
                    Return
                End If
                '��M�����f�[�^��~�ς���
                ms.Write(resBytes, 0, resSize)
            Loop While client.Available
            '��M�����f�[�^�𕶎���ɕϊ�
            Dim resMsg As String = enc.GetString(ms.ToArray())
            ms.Close()


            'Dim resMsg As String = enc.GetString(resBytes)

            Debug.Print(resMsg)

            Dim html As String = "<HTML><HEAD><TITLE>�S(*�L�́M*)�</TITLE></HEAD><BODY>�S(*�L�́M*)�</BODY></HTML>"



            '�N���C�A���g���ڑ��������̏����������ɏ���
            '�����ł͕�����𑗐M���āA�����ɕ��Ă���

            client.Send(System.Text.Encoding.UTF8.GetBytes( _
                "HTTP/1.1 200 OK" + vbCrLf + _
                "Content-Type: text/html" + vbCrLf + _
                "Content-Length: " + CStr(System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(html)) + vbCrLf + _
                vbCrLf _
                   ))

            client.Send(System.Text.Encoding.GetEncoding("Shift_JIS").GetBytes(html))
            client.Shutdown(System.Net.Sockets.SocketShutdown.Both)

        Catch
        End Try
        client.Close()

        '�ڑ��v���ҋ@���ĊJ����
        server.BeginAccept(New System.AsyncCallback( _
            AddressOf AcceptCallback), server)
    End Sub


    Private Sub TabPage3_Click(sender As System.Object, e As System.EventArgs) Handles TabPage3.Click

    End Sub
End Class