Imports CrystalDecisions
Imports CrystalDecisions.CrystalReports.Engine
Public Class Approved_frm

    Dim DepartmentID As Integer ' 1=houskeeping     2=safety        3=maintenance          4=nurssing     5=Admin
    Dim DatefieldName As String = ""
    'Dim UserIDfieldName As String = ""
    Dim Field, COND2, ExtraField As String
    Dim AdmDept As String = 5
    Dim ComboCount As Integer
    Dim EmpID As Integer = STANDRED_MODULE.UserIDGlob
    Private Sub Desgin_DGRID(ByVal DG As Object)
        'Visible Columns
        Dim IDclearance As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim chkValcolumn As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim BedNamecolumn As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim HkeepingDate As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim MinDate As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim SafeDate As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim Finaldate As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim start As New System.Windows.Forms.DataGridViewTextBoxColumn





        With IDclearance
            .Name = "ID"
            .HeaderText = "ID"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 150
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.White
            .ReadOnly = True
            .Visible = False
        End With
        DG.Columns.Insert(0, IDclearance)

        With chkValcolumn
            .HeaderText = "Approve"
            .Name = "chkID"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            '.Width = 60
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.LightSalmon
        End With
        DG.Columns.Insert(1, chkValcolumn)

        With BedNamecolumn
            .Name = "BedName"
            .HeaderText = "Bed Name"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 150
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.White
            .ReadOnly = True
        End With
        DG.Columns.Insert(2, BedNamecolumn)

        'The new columns

        With HkeepingDate
            .HeaderText = "HousKeeping Status"
            .Name = "Hkeepingdate"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.White
            .ReadOnly = True
        End With
        DG.Columns.Insert(3, HkeepingDate) '


        With SafeDate
            .HeaderText = "Saftey Status"
            .Name = "safedate"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.White
            .ReadOnly = True
        End With
        DG.Columns.Insert(4, SafeDate) '

        With MinDate
            .HeaderText = "Maintenance Status"
            .Name = "Mindate"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.White
            .ReadOnly = True
        End With
        DG.Columns.Insert(5, MinDate) '

        With Finaldate
            .HeaderText = "Final Status"
            .Name = "finalChk"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.LightPink
        End With
        DG.Columns.Insert(6, Finaldate)


        With start
            .HeaderText = "Start Datetime"
            .Name = "start"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.LightPink
        End With
        DG.Columns.Insert(7, start)

        'by default
        DG.RowCount = 100
        'Desable Order by user 
        DG.AllowUserToOrderColumns = False

    End Sub
    REM new options 2013 jun 10
    REM create the new data grid
    Private Sub DesginListGrid()
        With dgv_list

            'Visible Columns
            Dim BedClr_id As New System.Windows.Forms.DataGridViewTextBoxColumn
            Dim chkListID As New System.Windows.Forms.DataGridViewTextBoxColumn
            Dim Description As New System.Windows.Forms.DataGridViewTextBoxColumn
            Dim DoneBy As New System.Windows.Forms.DataGridViewComboBoxColumn
            Dim Remark As New System.Windows.Forms.DataGridViewTextBoxColumn
            Dim eDateTime As New System.Windows.Forms.DataGridViewTextBoxColumn

            With BedClr_id
                .Name = "BedClr_ID"
                .HeaderText = "BedClr_ID"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Width = 150
                .CellTemplate = New DataGridViewTextBoxCell
                .CellTemplate.Style.BackColor = Color.White
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Insert(0, BedClr_id)

            With chkListID
                .HeaderText = "Seq"
                .Name = "chkListid"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 60
                .CellTemplate = New DataGridViewTextBoxCell()
                .CellTemplate.Style.BackColor = Color.LightSalmon
            End With
            .Columns.Insert(1, chkListID)

            With Description
                .Name = "Description"
                .HeaderText = "Description"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 200
                .CellTemplate = New DataGridViewTextBoxCell
                .CellTemplate.Style.BackColor = Color.White
                .ReadOnly = True
            End With
            .Columns.Insert(2, Description)

            With DoneBy
                .HeaderText = "Technician"
                .Name = "DoneBy"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 400
                .CellTemplate = New DataGridViewComboBoxCell
                .CellTemplate.Style.BackColor = Color.White
                '.ReadOnly = True

                Dim ds As DataSet = SQLDATASET("select employeeid as Empid,Name + ' (' + employeeid + ' )' as name from Employee where departmentid IN (60,48) and deleted=0 order by name ", "Ta")
                .DataSource = ds.Tables(0)
                .DisplayMember = "name"
                .ValueMember = "EmpID"
            End With
            .Columns.Insert(3, DoneBy) '


            With Remark
                .HeaderText = "Remark"
                .Name = "Remark"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 200
                .CellTemplate = New DataGridViewTextBoxCell
                .CellTemplate.Style.BackColor = Color.White
                '.ReadOnly = True
            End With
            .Columns.Insert(4, Remark) '

            With eDateTime
                .HeaderText = "DateTime"
                .Name = "eDateTime"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 150
                .ReadOnly = True
                .CellTemplate = New DataGridViewTextBoxCell
                .CellTemplate.Style.BackColor = Color.White
                .Visible = False
            End With
            .Columns.Insert(5, eDateTime) '


            'by default
            .RowCount = 100
            'Desable Order by user 
            .AllowUserToOrderColumns = False
            .AllowUserToResizeColumns = False
        End With


    End Sub
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
    Private Sub Resize_Controls()
        Try
            Dim Siz As Size
            Siz.Width = Me.Size.Width - 30
            Siz.Height = Me.Height - 130

            DataGridView1.Width = Siz.Width
            DataGridView1.Height = Siz.Height

            Pan_chkList.Width = Siz.Width
            Pan_chkList.Height = Siz.Height + 40


            Dim Loc As New Point
            Loc.Y = Me.DataGridView1.Location.Y + Siz.Height + 10

            Loc.X = Approved_btn.Location.X
            Approved_btn.Location = Loc

            Loc.X = Button1.Location.X
            Button1.Location = Loc

            Loc.X = Exit_btn.Location.X
            Exit_btn.Location = Loc

            Loc.X = Label2.Location.X
            Label2.Location = Loc

            

            Me.WindowState = FormWindowState.Maximized

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Approved_frm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Resize_Controls()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Desgin_DGRID(DataGridView1)
        DesginListGrid()

        Resize_Controls()

        DepartmentID = STANDRED_MODULE.DepTIDGlob
        Field = FieldLoad()

        Me.Top = 0
        Me.Left = 0
        If DepartmentID <= 4 Then
            fill_grid(DataGridView1)
        ElseIf DepartmentID = 5 Then ' For Admin 
            fill_grid(DataGridView1)
        End If

        ComboCount = DataGridView1.Rows.Count


        REM New Options 2013 Jun 10
        If DepartmentID = 3 Then
            DataGridView1.Columns("CHKID").Visible = False
            Approved_btn.Visible = False
        Else
            DataGridView1.Columns("CHKID").Visible = True
            Approved_btn.Visible = True
        End If
        Pan_chkList.Visible = False
        Pan_chkList.Location = DataGridView1.Location
        LoadList()
        cmb_Status.SelectedIndex = 0

        'For Timer
        Label2.Text = "Last Update time:" & Now.ToString
        Timer1.Start()
        'AutoMateCheck() 'automatic check and approved
    End Sub
    Function FieldLoad() As String
        Dim fieldx As String
        Select Case DepartmentID
            Case 1 : fieldx = "HousekeepingapproveID"
                Section_lbl.Text = "HOUSEKEEPING DEPARTMENT"
                DatefieldName = "housekeepingdatetime"
                COND2 = " AND HSK_CalledBY IS NOT NULL "
                ExtraField = " , hsk_call_datetime as Start "
            Case 2 : fieldx = "SafetyapproveID"
                Section_lbl.Text = "SAFTEY DEPARTMENT"
                DatefieldName = "safetydatetime"
                COND2 = " AND SAF_CalledBY IS NOT NULL "
                ExtraField = " ,null as Start "
            Case 3 : fieldx = "Maintenanceapprove"
                Section_lbl.Text = "MAINTENANCE DEPARTMENT"
                DatefieldName = "maintenancedatetime"
                COND2 = " AND MNT_CalledBY IS NOT NULL "
                ExtraField = " , mnt_call_datetime as Start "
            Case 4 : fieldx = "FinalapproveID"
                Section_lbl.Text = "NURSING DEPARTMENT"
                DatefieldName = "Finaldatetime"
                COND2 = " "
                ExtraField = " "
            Case 5

                AdmDept = InputBox("Please Enter the ID of Module you want to Open:" & Chr(13) & _
                            " 1 = Housekeeping " & Chr(13) & " 2 = Safety " & Chr(13) & " 3 = Maintenance " & Chr(13) & _
                            " Thank you ", "select Module to Open", 1, ).Trim
                If AdmDept = Nothing Or IsDBNull(AdmDept) = True Then
                    AdmDept = 1
                End If
                Select Case AdmDept
                    Case 1 : fieldx = "HousekeepingapproveID"
                        Section_lbl.Text = "HOUSEKEEPING DEPARTMENT"
                        DatefieldName = "housekeepingdatetime"
                        COND2 = " AND HSK_CalledBY IS NOT NULL "
                        ExtraField = " , hsk_call_datetime as Start "

                    Case 2 : fieldx = "SafetyapproveID"
                        Section_lbl.Text = "SAFTEY DEPARTMENT"
                        DatefieldName = "safetydatetime"
                        COND2 = " AND SAF_CalledBY IS NOT NULL "
                        ExtraField = " ,null as Start "
                    Case 3 : fieldx = "Maintenanceapprove"
                        Section_lbl.Text = "MAINTENACE DEPARTMENT"
                        DatefieldName = "maintenancedatetime"
                        COND2 = " AND MNT_CalledBY IS NOT NULL "
                        ExtraField = " , mnt_call_datetime as Start "
                    Case 4 : fieldx = "FinalapproveID"
                        Section_lbl.Text = "NURSING DEPARTMENT"
                        DatefieldName = "Finaldatetime"
                        COND2 = "  "
                        ExtraField = "  "
                    Case Else
                        fieldx = "FinalapproveID"
                        Section_lbl.Text = "NURSING DEPARTMENT"
                        DatefieldName = "Finaldatetime"
                        COND2 = "  "
                        ExtraField = "  "
                End Select
        End Select
        Return fieldx
    End Function
    Private Sub fill_grid(ByVal dg As Object)
        Try
            Clear_datagrid(DataGridView1)
            If Pan_chkList.Visible = False Then Clear_datagrid(dgv_list)



            Dim sql As String
            'DataGridView1.DataSource = Nothing
            'If Field <> Nothing And deptid < 4 Then
            ' sql = " select distinct bedid as 'BED ID',bedname AS 'BED NAME','Pending' As Status from cleanbedrelease where " & Field & " is null order by bedname"
            ' Dim ds As Data.DataSet = STANDRED_MODULE.SQLDATASET(sql, "Table1")
            ' DataGridView1.DataSource = ds.Tables(0)
            ' DataGridView1.ReadOnly = True
            ' DataGridView1.Refresh()
            'ElseIf Field <> Nothing And deptid >= 4 Then
            sql = " select distinct cleanbedrelease.id As 'ClearanceID',0,bedname AS 'BED NAME'," & _
            " (select 'HOUSEKEEPING'= case when HouseKeepingapproveid is not null then 'Approved' else 'Pending' end) as 'HOUSEKEEPING'," & _
            " (select 'SAFTEY'= case when SAFETYapproveid is not null then 'Approved' else 'Pending' end) as 'SAFETY'," & _
            " (select 'MAINTENANCE'= case when MaintenanceApprove is not null then 'Approved' else 'Pending' end) as 'MAINTENANCE'" & _
            " ,'Pending' As 'Final Status' " & ExtraField & " from cleanbedrelease,bed b where " & Field & " is null " _
            & " and cleanbedrelease.bedid=b.id and b.forcleaning>0 and cleanbedrelease.Revoked is null " & COND2 _
            & " and cleanbedrelease.id in (Select MAX(id) from cleanbedrelease where " & Field & " is null and FinalApproveID is null AND REVOKED IS NULL group by Bedname) " _
            & " order by bedname"


            'Dim dsx As Data.DataSet = STANDRED_MODULE.SQLDATASET(sql, "Table1")
            'DataGridView1.DataSource = dsx.Tables(0)
            'DataGridView1.ReadOnly = True
            'DataGridView1.Refresh()
            'End If
            'MsgBox(sql)


            Dim s As SqlClient.SqlDataReader = STANDRED_MODULE.SQLREADER(sql)
            Dim j As Integer = 0

            With dg
                Do While s.Read = True
                    .Item(0, j).Value = s.GetValue(0)  'Clearance id
                    .Item(1, j).Value = s.GetValue(1)   'Virtual ChkBox Value
                    .Item(2, j).Value = s.GetString(2) 'Bedname
                    .Item(3, j).Value = s.GetString(3) 'housekeeping
                    .Item(4, j).Value = s.GetString(4) 'saftey
                    .Item(5, j).Value = s.GetString(5) 'mintincase 
                    .Item(6, j).Value = s.GetString(6) 'Final approve
                    .Item(7, j).Value = s!start 'startdate time
                    j += 1
                Loop

            End With
            dg.RowCount = j
            dg.Columns(0).Visible = False
            dg.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("" & ex.Message)
        End Try
    End Sub
    Private Sub Exit_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_btn.Click
        Me.Hide()
    End Sub
    Private Sub Approved_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Approved_btn.Click
        changeBedStatus()
    End Sub
    Private Sub changeBedStatus()
        'If check_pending() = True Then
        savedata()
        'fill_combo(DepartmentID)
        fill_grid(DataGridView1)
        ComboCount = DataGridView1.Rows.Count  'Pass the Current items qty to the count 
        'End If
    End Sub
    Private Sub savedata()
        Try
            With DataGridView1
                Dim j As Integer
                For j = 0 To .Rows.Count - 1
                    If .Item(1, j).Value = 1 Or .Item(1, j).Value = True Then
                        Dim sql As String = _
                        "update cleanbedrelease set " & Field & "=" & EmpID & _
                        ", " & DatefieldName & " =getdate() " & _
                        " where " & Field & " is null and id=" & .Item(0, j).Value
                        'MsgBox(sql)
                        Dim xs As Boolean = STANDRED_MODULE.SQLExecute(sql)
                    End If
                Next j
            End With
            fill_grid(DataGridView1)
        Catch ex As Exception
            '            MsgBox(ex.Message)
            MsgBox("Error When Update! please call IT Depratment.", MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label2.Text = "Last Update time:" & Now.ToString
        'AutoMateCheck()
        fill_grid(DataGridView1)
        If ComboCount < DataGridView1.Rows.Count Then
            MsgBox("There is a new bed's Need to clearance!" & Chr(13) & " Number oF new Bed=" _
            & DataGridView1.Rows.Count - ComboCount, MsgBoxStyle.Information, "Bed Clearance Alarm")
            ComboCount = DataGridView1.Rows.Count
            PlaySound()
        End If
    End Sub
    'Private Sub fill_combo(ByVal deptid As Integer)
    '    Try
    'Dim sql As String
    '        If Field <> Nothing Then
    '            sql = " select distinct id,bedname from cleanbedrelease where " & Field & " is null order by bedname "
    'Dim ds As Data.DataSet = STANDRED_MODULE.SQLDATASET(Sql, "Table1")
    '           bed_combo.DataSource = ds.Tables(0)
    '           bed_combo.DisplayMember = "bedname"
    '           bed_combo.ValueMember = "id"
    '           bed_combo.Refresh()
    '       End If
    '   Catch ex As Exception'

    'End Try
    'End Sub

    'Function check_pending() As Boolean
    '   If DepartmentID >= 4 Then
    'Dim count As Integer = 0
    'Try
    ' Dim rd As SqlClient.SqlDataReader = _
    ' STANDRED_MODULE.SQLREADER("select * from cleanbedrelease where id=" & bed_combo.SelectedValue)
    ' If rd.HasRows = True Then
    ' Do While rd.Read
    ' If Not IsDBNull(rd.GetValue(3)) Then count += 1
    ' If Not IsDBNull(rd.GetValue(5)) Then count += 1
    ' If Not IsDBNull(rd.GetValue(7)) Then count += 1
    ' Loop
    'Else
    'MsgBox("Wrong Entry, please check the BED NAME ", MsgBoxStyle.Critical)
    'End If
    ''MsgBox(count)
    'If count = 3 Then
    ' 'Save the record 
    ' Dim sql1 As String = "update bed set ForCleaning=0 where Name='" & bed_combo.Text.Trim & "'"
    ' Dim BedRelease As Boolean = STANDRED_MODULE.SQLExecute(sql1)
    ' Return True
    'Else
    ' MsgBox("Sorry Can't Approved this Bed Until be Approved first from : " & Chr(13) & _
    '"        - Maintenance " & Chr(13) & _
    '    "        - Werehouse " & Chr(13) & _
    '    "        - Safety " & Chr(13) & " Thank You!")
    'Return False
    'End If
    'Catch ex As Exception
    ' MsgBox(ex.Message)
    ' End Try
    '    ElseIf DepartmentID < 4 Then
    '        Return True
    'ElseIf DepartmentID = 5 Then
    ' Return True
    '    End If
    'End Function

    'For where house thru nursing
    'Private Sub Wh_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    'Dim sql As String = _
    '"update cleanbedrelease set HousekeepingapproveID=" & EmpID & _
    '", housekeepingdatetime =getdate() " & _
    '" where HousekeepingapproveID is null and id=" & bed_combo.SelectedValue
    ''MsgBox(sql)
    'Dim xs As Boolean = STANDRED_MODULE.SQLExecute(Sql)
    ''fill_combo(DepartmentID)
    '        fill_grid(DepartmentID)
    '    Catch ex As Exception
    '            MsgBox(ex.Message)
    '        MsgBox("Error When Update! please call IT Depratment.", MsgBoxStyle.Critical)
    '    End Try
    'End Sub
    'Private Sub sf_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    'Dim sql As String = _
    '"update cleanbedrelease set SafetyapproveID=" & EmpID & _
    '", safetydatetime =getdate() " & _
    '" where SafetyapproveID is null and id=" & bed_combo.SelectedValue
    ''MsgBox(sql)

    'Dim xs As Boolean = STANDRED_MODULE.SQLExecute(Sql)
    ''fill_combo(DepartmentID)
    '        fill_grid(DepartmentID)
    '    Catch ex As Exception
    ''            MsgBox(ex.Message)
    '       MsgBox("Error When Update! please call IT Depratment.", MsgBoxStyle.Critical)
    '   End Try
    'End Sub
    'Private Sub min_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    'Dim sql As String = _
    '"update cleanbedrelease set Maintenanceapprove=" & EmpID & _
    '", maintenancedatetime =getdate() " & _
    '" where Maintenanceapprove is null and id=" & bed_combo.SelectedValue
    ''MsgBox(sql)
    'Dim xs As Boolean = STANDRED_MODULE.SQLExecute(Sql)
    ''fill_combo(DepartmentID)
    '        fill_grid(DepartmentID)
    '    Catch ex As Exception
    ''            MsgBox(ex.Message)
    '       MsgBox("Error When Update! please call IT Depratment.", MsgBoxStyle.Critical)
    '   End Try
    'End Sub

    'For automate action for change the bed status
    'Private Sub AutoMateCheck()
    'only from the Nursing screen
    '    If DepartmentID >= 4 Then
    'Dim count As Integer = 0
    'Dim inx As Integer = 0
    'Dim rd As SqlClient.SqlDataReader
    'Dim sql As String
    'Dim BedRelease, xs As Boolean
    '        Try
    '            For inx = 0 To bed_combo.Items.Count - 1
    '                count = 0
    '                bed_combo.SelectedIndex = inx
    ''MsgBox("bedValue:" & bed_combo.SelectedValue)
    '                rd = STANDRED_MODULE.SQLREADER("select * from cleanbedrelease where id=" & bed_combo.SelectedValue)

    '                If rd.HasRows = True Then
    '                    Do While rd.Read
    '                        If Not IsDBNull(rd.GetValue(3)) Then count += 1
    '                        If Not IsDBNull(rd.GetValue(5)) Then count += 1
    '                        If Not IsDBNull(rd.GetValue(7)) Then count += 1
    '                   Loop
    '               End If
    '               If count = 3 Then 'Save the record 
    ''Update the BedClearance table
    '                    sql = _
    '                        "update cleanbedrelease set " & Field & "=" & 1 & _
    '                        ", " & DatefieldName & " =getdate() " & _
    '                        " where " & Field & " is null and id=" & bed_combo.SelectedValue
    '                    xs = STANDRED_MODULE.SQLExecute(sql)

    ''update the main table bed
    '                    BedRelease = _
    '                    STANDRED_MODULE.SQLExecute("update bed set status=1 where id=" & bed_combo.SelectedValue)
    '                End If
    '            Next
    '        Catch ex As Exception
    '            MsgBox("the rong is here: " & ex.Message)
    '        End Try
    '    End If
    'End Sub
    'refresh
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        fill_grid(DataGridView1)
        If ComboCount < DataGridView1.Rows.Count Then
            MsgBox("There is a new bed's Need to clearance!" & Chr(13) & " Number oF new Bed=" _
            & DataGridView1.Rows.Count - ComboCount, MsgBoxStyle.Information, "Bed Clearance Alarm")
            ComboCount = DataGridView1.Rows.Count
            PlaySound()
        End If

    End Sub

    REM new Options 2013 jun 10
    Private Sub btn_Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Back.Click
        Pan_chkList.Visible = False
    End Sub
    REM new Options 2013 jun 10
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        lbl_Title.Text = "BedName : " & DataGridView1.Item("BedName", e.RowIndex).Value & ", Start@ " & DataGridView1("start", e.RowIndex).Value
        GetRecords(DataGridView1.Item("id", e.RowIndex).Value, DepartmentID)
        Pan_chkList.Visible = True
    End Sub
    Private Sub LoadList()
        Dim sql As String
        sql = " select ID as Seq,Description from BedCLearance_checklist_master " _
            & " where deleted=0 and Categoryid= " & DepartmentID
        Try
            Dim s As SqlClient.SqlDataReader = STANDRED_MODULE.SQLREADER(sql)
            Dim j As Integer = 0
            dgv_list.RowCount = 100
            With dgv_list
                Do While s.Read = True
                    .Item("chklistID", j).Value = s!seq  'Clearance id
                    .Item("Description", j).Value = s!Description   'Virtual ChkBox Value
                    j += 1
                Loop
            End With
            dgv_list.RowCount = j
        Catch ex As Exception
            MsgBox("" & ex.Message)
        End Try
    End Sub
    Private Sub dgv_list_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.ColumnIndex = dgv_list.Columns("DoneBy").Index Then
            dgv_list.Item("remark", e.RowIndex).Value = dgv_list.Item("doneby", e.RowIndex).Value
        End If
    End Sub
    Private Sub GetRecords(ByVal bedClean_id As Integer, ByVal Dept As Integer)
        Dim sql As String
        sql = " select a.id as seq,a.description,b.doneby,b.remark,b.datetime " _
        & " from BEDCLEARANCE_CHECKLIST_DETAIL b, BedClearance_CheckList_Master a  " _
        & " where a.ID*=b.ChkListID and a.CategoryID=b.CategoryID and a.Deleted=0 " _
        & " and b.BedClr_ID = " & bedClean_id & " and a.categoryid=" & Dept

        Try
            Dim s As SqlClient.SqlDataReader = STANDRED_MODULE.SQLREADER(sql)
            Dim j As Integer = 0

            Clear_datagrid(dgv_list)
            lbl_RecordID.Text = bedClean_id

            dgv_list.RowCount = 100
            If s.HasRows = True Then
                With dgv_list
                    Do While s.Read = True
                        If s!seq = 0 Then
                            txt_approver.Text = NullToString(s!remark)
                        Else
                            .Item("bedclr_id", j).Value = bedClean_id
                            .Item("chklistID", j).Value = s!seq  'Clearance id
                            .Item("Description", j).Value = s!Description   'Virtual ChkBox Value
                            .Item("remark", j).Value = NullToString(s!remark)
                            .Item("eDatetime", j).Value = s!Datetime


                            '/************************/
                            If IsDBNull(s!doneby) <> True Then
                                '.Rows(j).Cells("DoneBy").Value = s!Doneby.ToString
                                Dim i As Integer = 0
                                Dim objCombo As DataGridViewComboBoxCell
                                Dim drv As DataRowView
                                'Get our default combox value for this row
                                Dim strReason As String = s!doneby
                                objCombo = DirectCast(.Rows(j).Cells("Doneby"), DataGridViewComboBoxCell)
                                i = 0
                                'loop through the ComboBoxCell values
                                For Each objItem As Object In objCombo.Items
                                    drv = DirectCast(objItem, DataRowView)
                                    'check whether our ComboBoxCell value matches our required value
                                    'MsgBox(drv.Item(0).ToString)
                                    If drv.Item(0).ToString = strReason Then
                                        'we have a match .. so apply it to the ComboBoxCell
                                        objCombo.Value = objCombo.Items(i).Item(0)
                                        Exit For
                                    End If
                                    i += 1
                                Next
                            End If
                            '/************************/
                            j += 1
                        End If

                    Loop
                End With
                dgv_list.RowCount = j

            Else
                LoadList()
            End If
            dgv_list.Refresh()
            dgv_list.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("" & ex.Message)
        End Try
    End Sub
    Private Sub dgv_list_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_list.DataError
        e.ThrowException = False
    End Sub

    Private Sub Save_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_btn.Click
        Dim str As String
        Try
            BEGIN_TRANSACTION()
            Dim xs As Boolean

            xs = STANDRED_MODULE.SQLExecute2("Delete from BEDCLEARANCE_CHECKLIST_DETAIL where bedclr_id=" _
               & lbl_RecordID.Text, TRANSConn.Connection, TRANSConn)

            str = "insert into BEDCLEARANCE_CHECKLIST_DETAIL values (" & lbl_RecordID.Text & "," _
                  & DepartmentID & "," & 0 & "," & EmpID & ",sysdatetime(),'" & txt_approver.Text & "') "
            xs = SQLExecute2(str, TRANSConn.Connection, TRANSConn)

            With dgv_list
                Dim j As Integer
                For j = 0 To .Rows.Count - 1
                    If .Item("chkListid", j).Value <> 0 And .Item("doneby", j).Value > 0 Then
                        str = "insert into BEDCLEARANCE_CHECKLIST_DETAIL values (" & lbl_RecordID.Text & "," _
                             & DepartmentID & "," & .Item("chklistid", j).Value _
                             & "," & .Item("doneby", j).Value & ",sysdatetime(),'" _
                             & NullToString(.Item("remark", j).Value) & "') "
                        xs = SQLExecute2(str, TRANSConn.Connection, TRANSConn)
                    End If
                Next j
            End With


            If cmb_Status.SelectedIndex = 1 Then '1= clear bed
                str = "update cleanbedrelease set " & Field & "=" & EmpID & _
                        ", " & DatefieldName & " =getdate() " & _
                        " where " & Field & " is null and id=" & lbl_RecordID.Text
                xs = SQLExecute2(str, TRANSConn.Connection, TRANSConn)
            End If
            END_TRANSACTION()
            MsgBox("Data Saved!", MsgBoxStyle.Information)

            Pan_chkList.Visible = False
            fill_grid(DataGridView1)

        Catch ex As Exception
            Rollback()
            MsgBox(ex.Message)
            MsgBox("Error when try to Save Records!Please check your Entry.", MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub PlaySound()
        Timer2.Start()
        'My.Computer.Audio.Play(My.Resources.alert, AudioPlayMode.Background,)
        My.Computer.Audio.Play(My.Resources.alert, AudioPlayMode.BackgroundLoop)
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        My.Computer.Audio.Stop()
    End Sub

    Private Function GetEmployeeName(ByVal Eid) As String
        Try
            If IsDBNull(Eid) Or Eid = Nothing Then Return ""
            Dim Sq As Data.SqlClient.SqlDataReader
            Sq = SQLREADER("select employeeid + ' - ' + Name as name from Employee where departmentid=60 and deleted=0 and employeeid='" & Eid & "' order by name ")
            If Sq.HasRows = True Then
                Do While Sq.Read
                    Return Sq!name
                Loop
            Else
                Return ""
            End If

        Catch ex As Exception
            Return ""
        End Try
    End Function



End Class