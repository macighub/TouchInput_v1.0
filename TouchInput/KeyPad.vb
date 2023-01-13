Imports System.Drawing

Public Class KeyPad

    Private Declare Function GetCaretPos Lib "user32" (ByRef lpPoint As Point) As Integer
    Public Declare Auto Function SetCaretPos Lib "User32" (ByVal x As Integer, ByVal y As Integer) As Boolean

    Dim l_EditBox
    Dim l_KeyProcessing As Boolean = False

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

        '
        ' TODO : Add constructor code after InitializeComponents
        '
        Me.DoubleBuffered = True
    End Sub

    Sub Button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        If l_KeyProcessing And e IsNot Nothing Then Exit Sub

        l_KeyProcessing = True

        If button2.Text = "<" Then
            pnl_NumPad.Width = 372
            button2.Text = ">"
        Else
            pnl_NumPad.Width = button2.Width
            button2.Text = "<"
        End If

        l_EditBox.Focus()

        l_KeyProcessing = False
    End Sub

    Sub Button4_Click(sender As Object, e As EventArgs)
        If l_KeyProcessing Then Exit Sub

        l_KeyProcessing = True
        If button2.Text = ">" Then
            Button2_Click(sender, e)
        End If

        Shift_Click()
    End Sub

    Sub Shift_Click()
        Me.SuspendLayout()

        If pnl_Normal.Visible Then
            pnl_Shift.Visible = True
            pnl_Normal.Visible = False
        ElseIf button4.BackColor = System.Drawing.Color.FromArgb(64, 64, 64) Then
            button4.BackColor = System.Drawing.Color.LimeGreen
            button4.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64)
            pnl_Shift.Visible = True
            pnl_Normal.Visible = False
        Else
            button4.BackColor = System.Drawing.Color.FromArgb(64, 64, 64)
            button4.ForeColor = System.Drawing.Color.Silver
            pnl_Normal.Visible = True
            pnl_Shift.Visible = False
        End If

        Me.ResumeLayout()

        l_EditBox.Focus()

        l_KeyProcessing = False
    End Sub

    Public Property EditBox()
        Get
            Return l_EditBox
        End Get
        Set(value)
            l_EditBox = value
        End Set
    End Property

    Sub Buttons_Click(sender As Object, e As EventArgs) Handles pnl_Shift.Click, pnl_Normal.Click, MyBase.Click, button99.Click, button98.Click, button97.Click, button96.Click, button95.Click, button94.Click, button93.Click, button92.Click, button91.Click, button90.Click, button9.Click, button89.Click, button88.Click, button87.Click, button86.Click, button85.Click, button84.Click, button83.Click, button82.Click, button81.Click, button80.Click, button8.Click, button79.Click, button78.Click, button77.Click, button76.Click, button75.Click, button74.Click, button73.Click, button72.Click, button71.Click, button70.Click, button7.Click, button69.Click, button68.Click, button67.Click, button66.Click, button65.Click, button64.Click, button63.Click, button62.Click, button61.Click, button60.Click, button6.Click, button59.Click, button58.Click, button55.Click, button54.Click, button53.Click, button52.Click, button51.Click, button50.Click, button5.Click, button49.Click, button48.Click, button47.Click, button46.Click, button45.Click, button44.Click, button43.Click, button42.Click, button41.Click, button40.Click, button4.Click, button39.Click, button38.Click, button37.Click, button36.Click, button35.Click, button34.Click, button33.Click, button32.Click, button31.Click, button30.Click, button3.Click, button29.Click, button28.Click, button27.Click, button26.Click, button25.Click, button24.Click, button23.Click, button22.Click, button21.Click, button20.Click, button19.Click, button18.Click, button17.Click, button16.Click, button15.Click, button14.Click, button13.Click, button12.Click, button11.Click, button105.Click, button104.Click, button103.Click, button102.Click, button101.Click, button100.Click, button10.Click, button1.Click
        If button2.Text = ">" Then
            Button2_Click(button2, Nothing)
        End If

        Select Case sender.text
            Case "SHIFT"
                Shift_Click()
            Case "ß"
                Left_Click()
            Case "à"
                Right_Click()
            Case "Clear All"
                Clear_Click()
            Case "ENTER"
                Enter_Click()
            Case "  Backspace"
                BackSpace_Click()
            Case Else
                Key_Click(sender.Text, e)
        End Select
    End Sub

    Sub BackSpace_Click()
        If l_KeyProcessing Then Exit Sub
        l_KeyProcessing = True

        l_EditBox.Focus()
        SendKeys.Send("{BACKSPACE}")

        l_KeyProcessing = False
    End Sub

    Sub Delete_Click()
        If l_KeyProcessing Then Exit Sub
        l_KeyProcessing = True

        l_EditBox.Focus()
        SendKeys.Send("{DELETE}")

        l_KeyProcessing = False
    End Sub

    Sub Key_Click(KeyText As String, Optional e As EventArgs = Nothing)
        If l_KeyProcessing Then Exit Sub

        l_KeyProcessing = True

        l_EditBox.Focus()
        SendKeys.Send(KeyText)

        If button4.BackColor = System.Drawing.Color.FromArgb(64, 64, 64) Then
            pnl_Normal.Visible = True
            pnl_Shift.Visible = False
        End If

        l_KeyProcessing = False
    End Sub

    Sub Enter_Click()
        If l_KeyProcessing Then Exit Sub

        l_KeyProcessing = True

        l_EditBox.Focus()
        SendKeys.Send("{ENTER}")

        l_KeyProcessing = False
    End Sub

    Sub Button105_Click(sender As Object, e As EventArgs)
        Clear_Click()
    End Sub

    Sub Clear_Click()
        If l_KeyProcessing Then Exit Sub

        l_KeyProcessing = True

        Try
            l_EditBox.Text = vbNullString
            l_EditBox.Refresh()
        Catch

        End Try

        l_EditBox.Focus()

        l_KeyProcessing = False
    End Sub

    Sub Button5_Click(sender As Object, e As EventArgs)
        Left_Click()
    End Sub

    Sub Left_Click()
        If l_KeyProcessing Then Exit Sub

        l_KeyProcessing = True

        l_EditBox.Focus()
        If pnl_Shift.Visible Then
            SendKeys.Send("+{LEFT}")
        Else
            SendKeys.Send("{LEFT}")
        End If

        l_KeyProcessing = False
    End Sub

    Sub Up_Click()
        If l_KeyProcessing Then Exit Sub

        l_KeyProcessing = True

        l_EditBox.Focus()
        If pnl_Shift.Visible Then
            SendKeys.Send("+{UP}")
        Else
            SendKeys.Send("{UP}")
        End If

        l_KeyProcessing = False
    End Sub

    Sub Down_Click()
        If l_KeyProcessing Then Exit Sub

        l_KeyProcessing = True

        l_EditBox.Focus()
        If pnl_Shift.Visible Then
            SendKeys.Send("+{DOWN}")
        Else
            SendKeys.Send("{DOWN}")
        End If

        l_KeyProcessing = False
    End Sub

    Sub NumericPad_ButtonPressed(Button As NumericPad.NumericButtons) Handles NumericPad2.ButtonPressed
        Select Case Button
            Case NumericPad.NumericButtons.Button_0
                Key_Click("0")
            Case NumericPad.NumericButtons.Button_1
                Key_Click("1")
            Case NumericPad.NumericButtons.Button_2
                Key_Click("2")
            Case NumericPad.NumericButtons.Button_3
                Key_Click("3")
            Case NumericPad.NumericButtons.Button_4
                Key_Click("4")
            Case NumericPad.NumericButtons.Button_5
                Key_Click("5")
            Case NumericPad.NumericButtons.Button_6
                Key_Click("6")
            Case NumericPad.NumericButtons.Button_7
                Key_Click("7")
            Case NumericPad.NumericButtons.Button_8
                Key_Click("8")
            Case NumericPad.NumericButtons.Button_9
                Key_Click("9")
            Case NumericPad.NumericButtons.Button_Dot
                Key_Click(".")
            Case NumericPad.NumericButtons.Button_Up
                Up_Click()
            Case NumericPad.NumericButtons.Button_Down
                Down_Click()
            Case NumericPad.NumericButtons.Button_Left
                Left_Click()
            Case NumericPad.NumericButtons.Button_Right
                Right_Click()
            Case NumericPad.NumericButtons.Button_Delete
                Delete_Click()
            Case NumericPad.NumericButtons.Button_Clear
                Clear_Click()
        End Select
    End Sub

    Sub Button58_Click(sender As Object, e As EventArgs)
        Right_Click()
    End Sub

    Sub Right_Click()
        If l_KeyProcessing Then Exit Sub

        l_EditBox.Focus()
        If pnl_Shift.Visible Then
            SendKeys.Send("+{RIGHT}")
        Else
            SendKeys.Send("{RIGHT}")
        End If

        l_KeyProcessing = False
    End Sub

End Class
