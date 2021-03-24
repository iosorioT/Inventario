
Imports MySql.Data.MySqlClient
Public Class frmAddUpdateCategory

    Private Sub GetCategoryNo()
        Try
            sqL = "SELECT CategoryNo FROM category ORDER BY CategoryNo DESC"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            dr = cmd.ExecuteReader()

            If dr.Read = True Then
                lblCategoryNo.Text = dr("CategoryNo") + 1
            Else
                lblCategoryNo.Text = 1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub LoadUpdateCategory()
        Try
            sqL = "SELECT * FROM category WHERE CategoryNo = '" & frmCategory.ListView1.FocusedItem.Text & "'"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            dr = cmd.ExecuteReader()

            If dr.Read = True Then
                lblCategoryNo.Text = dr("CategoryNo")
                txtCatName.Text = dr("CategoryName")
                txtDescription.Text = dr("Description")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub AddCategory()
        Try
            sqL = "INSERT INTO category(CategoryName, Description) VALUES('" & txtCatName.Text & "', '" & txtDescription.Text & "')"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            cmd.ExecuteNonQuery()
            MsgBox("New category successfully added.", MsgBoxStyle.Information, "Add Category")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub UpdateCategory()
        Try
            sqL = "UPDATE category SET CategoryName= '" & txtCatName.Text & "', Description = '" & txtDescription.Text & "' WHERE CategoryNo = '" & lblCategoryNo.Text & "'"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Category successfully updated.", MsgBoxStyle.Information, "Update Category")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub CLearFields()
        lblCategoryNo.Text = ""
        txtCatName.Text = ""
        txtDescription.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmAddUpdateCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmCategory.adding = True Then
            lblTitle.Text = "Adding New Category"
            CLearFields()
            GetCategoryNo()
        Else
            lblTitle.Text = "Updating Category"
            LoadUpdateCategory()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Comentario prueba commit
        If frmCategory.adding = True Then
            AddCategory()
            Me.Close()
        Else
            UpdateCategory()
            sqL = "SELECT * FROM CATEGORY WHERE ORDER By CategoryName asc;"
            frmCategory.LoadCategories(sqL)
            Me.Close()
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class