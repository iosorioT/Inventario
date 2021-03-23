
Imports MySql.Data.MySqlClient


Public Class frmstaff

    Public adding As Boolean
    Public updating As Boolean


    Public Sub Loadstaffs(ByVal sql As String)
        Try
            ConnDB()
            cmd = New MySqlCommand(sql, conn)
            dr = cmd.ExecuteReader()

            Dim x As ListViewItem
            ListView1.Items.Clear()

            Do While dr.Read = True
                x = New ListViewItem(dr("staffId").ToString)
                x.SubItems.Add(dr("ClientName"))
                x.SubItems.Add(dr("ContactNo"))
                x.SubItems.Add(dr("Address"))
                x.SubItems.Add(dr("username"))
                x.SubItems.Add(dr("Role"))

                ListView1.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub frmstaff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        sqL = "SELECT staffID, CONCAT(Lastname, ', ', Firstname, ' ', MI) as ClientName, CONCAT(Street, ', ', Barangay, ', ', City , ', ', Province) as Address, ContactNo, username, role FROM staff ORDER By Lastname asc;"
        Loadstaffs(sqL)

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        adding = True
        updating = False
        frmAddUpdatestaff.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim strSearch As String
        strSearch = InputBox("ENTER LAST NAME OF THE staff.", "Search CLient", " ")
        If strSearch.Length >= 1 Then
            lblSearch.Text = strSearch.Trim
            sqL = "SELECT staffID, CONCAT(Lastname, ', ', Firstname, ' ', MI) as ClientName, CONCAT(Street, ', ', Barangay, ', ', City , ', ', Province) as Address, ContactNo, username, role FROM staff WHERE LASTNAME LIKE '" & lblSearch.Text & "%' ORDER By Lastname"
            Loadstaffs(sqL)
        ElseIf strSearch = "" Then
            Exit Sub

        End If


    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update")
            Exit Sub
        End If
        Try
            If ListView1.FocusedItem.Text = "" Then

            Else
                adding = False
                updating = True
                frmAddUpdatestaff.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class