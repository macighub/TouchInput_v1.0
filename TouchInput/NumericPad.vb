Public Class NumericPad

    Public Enum NumericButtons
        Button_0
        Button_1
        Button_2
        Button_3
        Button_4
        Button_5
        Button_6
        Button_7
        Button_8
        Button_9
        Button_Up
        Button_Down
        Button_Left
        Button_Right
        Button_Delete
        Button_Clear
        Button_Dot
    End Enum

    Public Event ButtonPressed(Button As NumericButtons)

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

        '
        ' TODO : Add constructor code after InitializeComponents
        '
    End Sub

    Public Property DecimalValueEnabled() As Boolean
        Set(value As Boolean)
            button10.Enabled = value
        End Set
        Get
            Return button10.Enabled
        End Get
    End Property

    Public Property UpDownArrows() As Boolean
        Set(value As Boolean)
            If value Then
                button13.Font = button14.Font
                button13.Text = "â"
                button15.Font = button14.Font
                button15.Text = "á"
            Else
                button13.Font = button10.Font
                button13.Text = "-"
                button15.Font = button10.Font
                button15.Text = "+"
            End If
        End Set
        Get
            If button13.Text = "â" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Sub Button_Click(sender As Object, e As EventArgs) Handles button9.Click, button8.Click, button7.Click, button6.Click, button5.Click, button4.Click, button3.Click, button2.Click, button17.Click, button16.Click, button15.Click, button14.Click, button13.Click, button12.Click, button11.Click, button10.Click, button1.Click
        Select Case sender.Text
            Case "0"
                RaiseEvent ButtonPressed(NumericButtons.Button_0)
            Case "1"
                RaiseEvent ButtonPressed(NumericButtons.Button_1)
            Case "2"
                RaiseEvent ButtonPressed(NumericButtons.Button_2)
            Case "3"
                RaiseEvent ButtonPressed(NumericButtons.Button_3)
            Case "4"
                RaiseEvent ButtonPressed(NumericButtons.Button_4)
            Case "5"
                RaiseEvent ButtonPressed(NumericButtons.Button_5)
            Case "6"
                RaiseEvent ButtonPressed(NumericButtons.Button_6)
            Case "7"
                RaiseEvent ButtonPressed(NumericButtons.Button_7)
            Case "8"
                RaiseEvent ButtonPressed(NumericButtons.Button_8)
            Case "9"
                RaiseEvent ButtonPressed(NumericButtons.Button_9)
            Case "+"
                RaiseEvent ButtonPressed(NumericButtons.Button_Up)
            Case "-"
                RaiseEvent ButtonPressed(NumericButtons.Button_Down)
            Case "á"
                RaiseEvent ButtonPressed(NumericButtons.Button_Up)
            Case "â"
                RaiseEvent ButtonPressed(NumericButtons.Button_Down)
            Case "ß"
                RaiseEvent ButtonPressed(NumericButtons.Button_Left)
            Case "à"
                RaiseEvent ButtonPressed(NumericButtons.Button_Right)
            Case "Delete"
                RaiseEvent ButtonPressed(NumericButtons.Button_Delete)
            Case "Clear"
                RaiseEvent ButtonPressed(NumericButtons.Button_Clear)
            Case "."
                RaiseEvent ButtonPressed(NumericButtons.Button_Dot)
        End Select
    End Sub
End Class
