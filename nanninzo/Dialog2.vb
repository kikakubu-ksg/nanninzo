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
        '常に最前面に表示
        If Me.CheckBox01.CheckState = CheckState.Checked Then
            myForm1.f2.TopMost = True
            myForm1.f3.TopMost = True
        Else
            myForm1.f2.TopMost = False
            myForm1.f3.TopMost = False
        End If

        'タスクトレイに格納する
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

        '字幕を右寄せにする
        If Me.CheckBox03.CheckState = CheckState.Checked Then
            myForm1.BaseAlignRightFlg = True
        Else
            myForm1.BaseAlignRightFlg = False
        End If

        '美人のとき赤くする
        If Me.CheckBox04.CheckState = CheckState.Checked Then
            myForm1.BaseBusyHotFlg = True
        Else
            myForm1.BaseBusyHotFlg = False
        End If

        'アンチエイリアスをかける
        If Me.CheckBox05.CheckState = CheckState.Checked Then
            myForm1.BaseAntiAriasFlg = True
        Else
            myForm1.BaseAntiAriasFlg = False
        End If

        'SE
        '進入時フラグ
        If Me.CheckBox_SE01.CheckState = CheckState.Checked Then
            myForm1.BaseSEInFlg = True
        Else
            myForm1.BaseSEInFlg = False
        End If
        '退出時フラグ
        If Me.CheckBox_SE02.CheckState = CheckState.Checked Then
            myForm1.BaseSEOutFlg = True
        Else
            myForm1.BaseSEOutFlg = False
        End If
        '美人時フラグ
        If Me.CheckBox_SE03.CheckState = CheckState.Checked Then
            myForm1.BaseSEBusyFlg = True
        Else
            myForm1.BaseSEBusyFlg = False
        End If

        myForm1.soundName1 = Me.ComboBox1.Text
        myForm1.soundName2 = Me.ComboBox2.Text
        myForm1.soundName3 = Me.ComboBox3.Text

        '更新間隔
        myForm1.Timer1.Interval = CInt(Me.更新間隔.Text)

        myForm1.RePaintFlg = True
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'サウンドフォルダ取得
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
        'folderにあるファイルを取得する
        Dim fs As String() = _
            System.IO.Directory.GetFiles(folder, searchPattern)
        'ArrayListに追加する
        files.AddRange(fs)
    End Sub
    Public Sub PlaySound(ByVal soundName As String)
        'Dim audio As Microsoft.DirectX.AudioVideoPlayback.Audio

        'Try
        '    audio = New Microsoft.DirectX.AudioVideoPlayback.Audio(Application.StartupPath + "\" + soundName)
        '    audio.Play()
        'Catch
        '    MessageBox.Show("ファイルの再生に失敗しました。")
        'End Try
        '再生するファイル名

        Dim fileName As String = soundName

        Dim cmd As String
        'ファイルを開く
        cmd = "open """ + fileName + """ type mpegvideo alias " + aliasName
        If mciSendString(cmd, Nothing, 0, IntPtr.Zero) <> 0 Then
            Return
        End If '再生する
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

        '文字コードを指定する
        Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_jis")


        Dim lport As Integer = CInt(Me.RecPort.Text)

        Dim listener As New System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, lport)


        listener.Start()

        StartAccept(listener.Server)


        
        'Dim tcp As System.Net.Sockets.TcpClient = _
        '            listener.AcceptTcpClient()

        'Label1.Text = "クライアントが接続しました。"

        ''NetworkStreamを取得
        'Dim ns As System.Net.Sockets.NetworkStream = tcp.GetStream()

        ''クライアントから送られたデータを受信する
        'Dim ms As New System.IO.MemoryStream
        'Dim resBytes(256) As Byte
        'Dim resSize As Integer

        'Do
        '    'データの一部を受信する
        '    resSize = ns.Read(resBytes, 0, resBytes.Length)
        '    'Readが0を返した時はクライアントが切断したと判断
        '    If resSize = 0 Then
        '        Label1.Text = "クライアントが切断しました。"
        '        Return
        '    End If
        '    '受信したデータを蓄積する
        '    ms.Write(resBytes, 0, resSize)
        'Loop While ns.DataAvailable

        ''受信したデータを文字列に変換()
        'Dim resMsg As String = enc.GetString(ms.ToArray())
        'ms.Close()

        'TextBox3.Text = resMsg

        ''クライアントにデータを送信する
        'Dim sendMsg As String = resMsg.Length.ToString() + "文字"
        ''文字列をByte型配列に変換
        'Dim sendBytes As Byte() = enc.GetBytes(sendMsg)
        ''データを送信する
        'ns.Write(sendBytes, 0, sendBytes.Length)
        'Console.WriteLine(sendMsg)

        ''閉じる
        'tcp.Close()

        ''リスナを閉じる
        'listener.Stop()

    End Sub


    'クライアントの接続待ちスタート
    Private Shared Sub StartAccept( _
        ByVal server As System.Net.Sockets.Socket)
        '接続要求待機を開始する
        server.BeginAccept(New System.AsyncCallback( _
            AddressOf AcceptCallback), server)
    End Sub

    'BeginAcceptのコールバック
    Private Shared Sub AcceptCallback(ByVal ar As System.IAsyncResult)
        'サーバーSocketの取得
        Dim server As System.Net.Sockets.Socket = _
            CType(ar.AsyncState, System.Net.Sockets.Socket)

        '接続要求を受け入れる
        Dim client As System.Net.Sockets.Socket = Nothing
        Try
            'クライアントSocketの取得
            client = server.EndAccept(ar)
        Catch
            System.Console.WriteLine("閉じました。")
            Return
        End Try

        'クライアントから送られたデータを受信する
        Dim ms As New System.IO.MemoryStream
        Dim resBytes(256) As Byte
        Dim resSize As Integer

        Try

            'resSize = client.Receive(resBytes)
            Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_jis")

            Do
                'データの一部を受信する
                resSize = client.Receive(resBytes)
                'Readが0を返した時はクライアントが切断したと判断
                If resSize = 0 Then
                    Debug.Print("クライアントが切断しました。")
                    Console.ReadLine()
                    Return
                End If
                '受信したデータを蓄積する
                ms.Write(resBytes, 0, resSize)
            Loop While client.Available
            '受信したデータを文字列に変換
            Dim resMsg As String = enc.GetString(ms.ToArray())
            ms.Close()


            'Dim resMsg As String = enc.GetString(resBytes)

            Debug.Print(resMsg)

            Dim html As String = "<HTML><HEAD><TITLE>ヾ(*´∀｀*)ﾉ</TITLE></HEAD><BODY>ヾ(*´∀｀*)ﾉ</BODY></HTML>"



            'クライアントが接続した時の処理をここに書く
            'ここでは文字列を送信して、すぐに閉じている

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

        '接続要求待機を再開する
        server.BeginAccept(New System.AsyncCallback( _
            AddressOf AcceptCallback), server)
    End Sub


    Private Sub TabPage3_Click(sender As System.Object, e As System.EventArgs) Handles TabPage3.Click

    End Sub
End Class