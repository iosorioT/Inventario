

Imports MySql.Data.MySqlClient

Public Class frmAddUpdatestaff

    Private Sub GetstaffID()
        Try
            sqL = "SELECT staffID FROM staff ORDER BY staffID DESC"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            dr = cmd.ExecuteReader()

            If dr.Read = True Then
                lblProductNo.Text = dr("staffID") + 1
            Else
                lblProductNo.Text = 1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub Addstaff()
        Try
            sqL = "INSERT INTO staff(Lastname, Firstname, MI, Street, Barangay, City, Province, ContactNo, Username, Role, UPassword) VALUES('" & txtLastname.Text & "', '" & txtFirstname.Text & "', '" & txtMI.Text & "', '" & txtStreet.Text & "', '" & txtBarangay.Text & "', '" & txtCity.Text & "', '" & txtProvince.Text & "', '" & txtContractNo.Text & "', '" & txtUsername.Text & "', '" & txtRole.Text & "', '" & txtPassword.Text & "')"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            cmd.ExecuteNonQuery()
            MsgBox("New staff successfully added.", MsgBoxStyle.Information, "Add staff")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub


    Private Sub Updatestaff()
        Try
            sqL = "Update staff SET Lastname = '" & txtLastname.Text & "', Firstname = '" & txtFirstname.Text & "', MI = '" & txtMI.Text & "', Street= '" & txtStreet.Text & "', Barangay = '" & txtBarangay.Text & "', City = '" & txtCity.Text & "', Province = '" & txtProvince.Text & "', ContactNo = '" & txtContractNo.Text & "', Username ='" & txtUsername.Text & "', Role = '" & txtRole.Text & "', UPassword = '" & txtPassword.Text & "' WHERE staffID = '" & frmstaff.ListView1.FocusedItem.Text & "'"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            cmd.ExecuteNonQuery()
            MsgBox("staff record successfully updated", MsgBoxStyle.Information, "Update staff")

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub LoadUpdatestaff()
        Try
            sqL = "SELECT * FROM staff WHERE staffID = '" & frmstaff.ListView1.FocusedItem.Text & "'"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            If dr.Read = True Then
                lblProductNo.Text = dr("staffID")
                txtLastname.Text = dr("lastname")
                txtFirstname.Text = dr("Firstname")
                txtMI.Text = dr("MI")
                txtStreet.Text = dr("Street")
                txtBarangay.Text = dr("barangay")
                txtCity.Text = dr("City")
                txtProvince.Text = dr("Province")
                txtContractNo.Text = dr("ContactNo")
                txtUsername.Text = dr("username")
                txtRole.Text = dr("Role")
                txtPassword.Text = dr("UPassword")
                txtConfirmPWD.Text = dr("UPassword")

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub ClearFields()
        lblProductNo.Text = ""
        txtLastname.Text = ""
        txtFirstname.Text = ""
        txtMI.Text = ""
        txtStreet.Text = ""
        txtBarangay.Text = ""
        txtCity.Text = ""
        txtProvince.Text = ""
        txtContractNo.Text = ""
        txtUsername.Text = ""
        txtRole.Text = ""
        txtPassword.Text = ""
        txtConfirmPWD.Text = ""
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmAddUpdatestaff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmstaff.adding = True Then
            lblTitle.Text = "Adding New staff"
            ClearFields()
            GetstaffID()
        Else
            lblTitle.Text = "Updating staff"
            LoadUpdatestaff()

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If frmstaff.adding = True Then
            Addstaff()
            Me.Close()
        Else
            Updatestaff()
            sqL = "SELECT staffID, CONCAT(Lastname, ', ', Firstname, ' ', MI) as ClientName, CONCAT(Street, ', ', Barangay, ', ', City , ', ', Province) as Address, ContactNo, username, role FROM staff ORDER By Lastname asc;"
            frmstaff.Loadstaffs(sqL)
            Me.Close()
        End If
    End Sub
End Class