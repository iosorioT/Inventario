Public Class frmFilterDailySales

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmReportDailySales.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmFilterDailySales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class