Public Class Admin_Frm
    Dim TABLENAME As String
    Dim IDval As Integer
    Dim Loading As Boolean = False
    Private Sub loadData(Optional ByVal Wherestr As String = "")
        Try
            Dim SQL As String
            SQL = Wherestr
            Dim D As SqlClient.SqlDataReader = STANDRED_MODULE.SQLREADER("SELECT * FROM bedclearanceadmin " & SQL)
            If D.HasRows = False Then MsgBox("Sorry, There is No Data!")
            Category_combo.SelectedValue = 5
            Do While D.Read()
                EMPID_Combo.SelectedValue = D.GetValue(1) 'userid
                Category_combo.SelectedValue = D.GetValue(0) 'category id
                Mobile_txt.Text = D.GetString(2) 'mobilenumber
            Loop
        Catch ex As Exception
            MsgBox("Error When Load : " & ex.Message)
        End Try
    End Sub
    Private Sub clearTxt()
        EMPID_Combo.Text = ""
        Category_combo.Text = ""
        Mobile_txt.Text = 0
    End Sub
    Private Sub Open_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Open_btn.Click
        Try
            Dim PARA As String
            clearTxt()
            load_combo()
            PARA = InputBox("ENTER THE EMPLOYEE ID# : ", "ID NUMBER OF THE EMPLOYEE")
            IDval = PARA
            If IDval > 0 Then
                'TO make a list of the Same Employee if he have a multi record with defrent date's
                loadData(" where employeeID=" & IDval & "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Function NewRecordCheck() As Boolean
        Dim SQL As String
        SQL = "select * from bedclearanceadmin where employeeID=" & EMPID_Combo.Text & ""
        Try
            Dim TestDset As SqlClient.SqlDataReader = STANDRED_MODULE.SQLREADER(SQL)
            If TestDset.HasRows Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    '--< END >--
    Private Sub SaveRecord(ByVal NewRec As Boolean)
        Try
            Dim s As String = ""
            If NewRec = False Then
                s = "Update bedclearanceadmin set " & _
                    " categoryid=" & Category_combo.SelectedValue & ", " & _
                    " Mobilenumber='" & Mobile_txt.Text & "' " & _
                    " where employeeId=" & EMPID_Combo.Text.Trim
            ElseIf NewRec = True Then
                s = "Insert into bedclearanceadmin (employeeid,categoryid,mobilenumber)" & _
                " Values (" & EMPID_Combo.Text.Trim & "," & Category_combo.SelectedValue & "," & Mobile_txt.Text & ") "
            End If

            Dim n As Boolean = STANDRED_MODULE.SQLExecute(s)
            MsgBox("Data Saved!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Error When Save Dont leave A mobile No=Null ", MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Add_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_btn.Click
        clearTxt()
        EMPID_Combo.Focus()
    End Sub
    Private Sub Exit_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_btn.Click
        Me.Hide()
    End Sub
    Private Sub Del_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Del_btn.Click
        Try
            If EMPID_Combo.Text > 0 Then
                Dim ST As String = "DELETE FROM bedclearanceadmin where employeeID=" & EMPID_Combo.Text.Trim
                '                " WHERE EMPID=" & ID_COMBO.Text & " AND " & _
                '               " CURRENTDATE=#" & Date_Combo.Text & "#"
                Dim DEL As Boolean = STANDRED_MODULE.SQLExecute(ST)
                clearTxt()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Save_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_btn.Click
        Dim BOOL As Boolean = NewRecordCheck()
        SaveRecord(BOOL)
    End Sub

    Private Sub Admin_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loading = True
        Me.Left = 0
        Me.Top = 0
        load_combo()
        Load_DepartmentSData()
    End Sub
    Private Sub load_combo()
        Dim x As Data.DataSet = STANDRED_MODULE.SQLDATASET("Select employeeid from employee where id<>1", "Table1")
        EMPID_Combo.DataSource = x.Tables(0)
        EMPID_Combo.DisplayMember = "employeeid"
        EMPID_Combo.ValueMember = "employeeid"

        '
        Dim Y As Data.DataSet = STANDRED_MODULE.SQLDATASET("Select id,name from bedclearancecategory", "Table1")
        Category_combo.DataSource = Y.Tables(0)
        Category_combo.DisplayMember = "name"
        Category_combo.ValueMember = "id"

        Category_cmb2.DataSource = Y.Tables(0)
        Category_cmb2.DisplayMember = "name"
        Category_cmb2.ValueMember = "id"
        Category_cmb2.SelectedIndex = 4
        Loading = False
        clearTxt()
    End Sub
    'Department activation Part
    Private Sub Load_DepartmentSData()
        Try
            Dim y As SqlClient.SqlDataReader = STANDRED_MODULE.SQLREADER("select * from tbl_bedclearanceparam")
            Do While y.Read
                If y.GetValue(0) = 1 Then Safety_chkbox.Checked = True Else Safety_chkbox.Checked = False
                If y.GetValue(1) = 1 Then MTN_chkbox.Checked = True Else MTN_chkbox.Checked = False
                If y.GetValue(2) = 1 Then HK_chkbox.Checked = True Else HK_chkbox.Checked = False
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Save2_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save2_btn.Click
        Try
            Dim a, b, c As Integer
            If Safety_chkbox.Checked = True Then a = 1 Else a = 0
            If MTN_chkbox.Checked = True Then b = 1 Else b = 0
            If HK_chkbox.Checked = True Then c = 1 Else c = 0

            Dim Xcom As New Boolean
            Xcom = STANDRED_MODULE.SQLExecute(" UPdate tbl_bedclearanceparam set " & _
            " safetyID=" & a & " , maintenanceID=" & b & " , HousekeepingID=" & c)

            MsgBox("data Saved!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(" Error When Try To save: Real Message " & Chr(13) & ex.Message)
        End Try
    End Sub

    REM check list area
    Private Sub Clear_datagrid(ByVal Dg As DataGridView)
        Dim i, j As Integer

        For i = 0 To Dg.Rows.Count - 1
            For j = 0 To Dg.Columns.Count - 1
                Dg.Item(j, i).Value = Nothing
            Next
        Next
        Dg.RowCount = 100
        Dg.Refresh()
    End Sub
    Private Sub Category_cmb2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Category_cmb2.SelectedIndexChanged
        If Loading = False Then
            Clear_datagrid(DataGridView1)
            Get_records(Category_cmb2.SelectedValue)
        End If
    End Sub
    Private Sub Get_records(ByVal Catid)
        Dim Sq As SqlClient.SqlDataReader = SQLREADER("select * from bedclearance_checklist_master where categoryid=" & Catid)
        Dim i As Integer
        With DataGridView1

            i = 0
            If Sq.HasRows Then
                Do While Sq.Read
                    .Item("categoryid", i).Value = Sq!categoryid
                    .Item("chkid", i).Value = Sq!id
                    .Item("Description", i).Value = Sq!Description
                    .Item("deleted", i).Value = Sq!deleted
                    i += 1
                Loop
                If i = 0 Then i = 1
                .RowCount = i + 1
            Else
                .RowCount = 1

            End If
    
        End With
    End Sub
    Private Sub DataGridView1_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.UserAddedRow
        With DataGridView1
            .Item("categoryid", e.Row.Index - 1).Value = Category_cmb2.SelectedValue
            .Item("chkid", e.Row.Index - 1).Value = e.Row.Index - 1
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Row As DataGridViewRow
        Dim Bn As Boolean
        BEGIN_TRANSACTION()
        Bn = SQLExecute2("delete from bedClearance_checklist_master where categoryid=" & Category_cmb2.SelectedValue, TRANSConn.Connection, TRANSConn)
        With DataGridView1
            For Each Row In .Rows
                If .Item("Description", Row.Index).Value <> Nothing Then
                    Bn = SQLExecute2("insert into bedClearance_checklist_master values(" & _
                " " & .Item("chkid", Row.Index).Value & "," & .Item("categoryid", Row.Index).Value & "," & _
                " '" & .Item("description", Row.Index).Value & "'," & NullToNum(.Item("deleted", Row.Index).Value) & ") ", TRANSConn.Connection, TRANSConn)
                End If
            Next

        End With
        END_TRANSACTION()
    End Sub
End Class