Public Class ProgressDialog
    Private Sub ProgressDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Calculate the position to center the form
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim formWidth As Integer = Me.Width
        Dim formHeight As Integer = Me.Height
        Dim xPos As Integer = (screenWidth - formWidth) \ 2
        Dim yPos As Integer = (screenHeight - formHeight) \ 2

        ' Set the location of the form
        Me.Location = New Point(xPos, yPos)
    End Sub
End Class