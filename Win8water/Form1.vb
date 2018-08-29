Public Class Form1

    Public Water(6) As Bitmap

    Public i As Integer
    Public yy As Integer
    Public yd As Boolean

    'This isn't accurate and I don't give a shit
    Public PenisParty() As Integer = {0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, _
                                    2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, _
                                   0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, _
                                   2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, _
                                   0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, _
                                   4, 1, 4, 1, 4, 1, 4, 1, 4, 1, 4, 1, 4, 1, 4, 1}


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Height = 16
        Left = 0
        Top = My.Computer.Screen.WorkingArea.Bottom - 16
        Width = My.Computer.Screen.Bounds.Width

        Dim w = My.Resources.water
        For n As Integer = 0 To 5
            Water(n) = New Bitmap(64, 16, w.PixelFormat)
        Next

        Dim y As Integer = w.Width

        JHiggs(Water(0), 0, 0)
        JHiggs(Water(1), 1, 0)
        JHiggs(Water(2), 0, 1)
        JHiggs(Water(3), 1, 1)
        JHiggs(Water(4), 0, 2)
        JHiggs(Water(5), 1, 2)

    End Sub

    Public Sub JHiggs(w As Image, side As Integer, pick As Integer)

        'Harrison's shnozola

        Dim src As Rectangle
        If pick = 0 Then
            src = New Rectangle(0, 0, 32, 16)
        ElseIf pick = 1 Then
            src = New Rectangle(0, 16, 32, 16)
        Else
            src = New Rectangle(0, 32, 32, 16)

        End If

        Dim dst As Rectangle
        If side = 0 Then
            dst = New Rectangle(0, 0, 32, 16)
        Else
            dst = New Rectangle(32, 0, 32, 16)
        End If

        Dim g As Graphics = Graphics.FromImage(w)
        g.Clear(Color.Magenta)
        g.DrawImage(My.Resources.water, dst, src, GraphicsUnit.Pixel)
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If Water(0) Is Nothing Then Return
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Top = My.Computer.Screen.WorkingArea.Bottom - 5 + yy
        BackgroundImage = Water(PenisParty(i))
        i += 1

        If i >= PenisParty.Length - 1 Then i = 0

    End Sub

    Public max As Integer = 8

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If yd Then
            yy += 1
            If yy >= max Then
                yd = False
            End If
        Else
            yy -= 1
            If yy <= -max Then
                yd = True
            End If
        End If

    End Sub
End Class
