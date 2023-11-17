Public Class FlagBed_Frm
    Dim EmpID As Integer = STANDRED_MODULE.UserIDGlob
    Dim VacantRoom = STANDRED_MODULE.RoomType
    Dim sfty, mtn, hk As Integer
    Private Sub FlagBed_Frm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Resize_Controls()
    End Sub
    Private Sub FlagBed_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VacantRoom = STANDRED_MODULE.RoomType
        'Me.Top = 0
        'Me.Left = 0
        'Resize_Controls()
        Desgin_DGRID(DataGridView1)
        fill_combo()
        STation_combo.SelectedIndex = 0
        Label2.Text = " Last Update time:" & Now.ToString
        Timer1.Start()
        REM new for view 
        Pan_chkList.Visible = False
        DesginListGrid()

        If STANDRED_MODULE.DepTIDGlob = 4 Or STANDRED_MODULE.DepTIDGlob = 5 Then
            Approved_btn.Enabled = True 'ALLOWED FOR NURS AND ADMIN ONLY
            DataGridView1.Columns("CHKID").ReadOnly = False
            DataGridView1.Columns("finalChk").ReadOnly = False
            DataGridView1.Columns("DelayReason").ReadOnly = False
        Else 'FOR VIEW ONLY 
            Approved_btn.Enabled = False
            DataGridView1.Columns("CHKID").ReadOnly = True
            DataGridView1.Columns("finalChk").ReadOnly = True
            DataGridView1.Columns("DelayReason").ReadOnly = True
        End If

        Me.WindowState = FormWindowState.Minimized
        Me.WindowState = FormWindowState.Maximized
        Resize_Controls()
    End Sub
    Private Sub Resize_Controls()
        Try
            Dim Siz As Size
            Siz.Width = Me.Size.Width - 30
            Siz.Height = Me.Height - 170

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

            Loc.X = Button2.Location.X
            Button2.Location = Loc

            Loc.X = Label2.Location.X
            Label2.Location = Loc

            'set font
            DataGridView1.Font = RadioButton3.Font

            Me.WindowState = FormWindowState.Maximized

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fill_combo()
        Try
            Dim sql As String
            sql = " select distinct deptcode from bed where deleted=0 and deptcode in ('N5S','N4S','N3S','N2N','N2S') and deptcode is not null  order by Deptcode "
            Dim ds As Data.DataSet = STANDRED_MODULE.SQLDATASET(sql, "Table1")
            STation_combo.DataSource = ds.Tables(0)
            STation_combo.DisplayMember = "Deptcode"
            STation_combo.ValueMember = "Deptcode"
            'STation_combo.Refresh()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Desgin_DGRID(ByVal DG As Object)
        'Visible Columns
        Dim IDBedNamecolumn As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim BedNamecolumn As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim Statuscolumn As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim pincolumn As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim PNamecolumn As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim chkValcolumn As New System.Windows.Forms.DataGridViewCheckBoxColumn


        Dim HkeepingChk As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim HkeepingDate As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim MinChk As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim MinDate As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim SafeChk As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim SafeDate As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim FinalChk As New System.Windows.Forms.DataGridViewCheckBoxColumn

        Dim ClearanceID As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim RegisteredBy As New System.Windows.Forms.DataGridViewTextBoxColumn


        'Dim HSKSTART As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim HSKSTART As New System.Windows.Forms.DataGridViewImageColumn
        Dim HSKCALLEDBy As New System.Windows.Forms.DataGridViewTextBoxColumn

        'Dim MNTSTART As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim MNTSTART As New System.Windows.Forms.DataGridViewImageColumn
        Dim MNTCALLEDBy As New System.Windows.Forms.DataGridViewTextBoxColumn


        'Dim SafSTART As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim SafSTART As New System.Windows.Forms.DataGridViewImageColumn
        Dim SafCALLEDBy As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim StartProc As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim DelayReason As New System.Windows.Forms.DataGridViewComboBoxColumn

        With IDBedNamecolumn
            .Name = "ID"
            .HeaderText = "Bed ID"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 150
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.White
            .ReadOnly = True
            .Visible = False
        End With
        DG.Columns.Insert(0, IDBedNamecolumn)

        With chkValcolumn
            .HeaderText = "For Clearing"
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
        With Statuscolumn
            .Name = "Status"
            .HeaderText = "Status"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 150
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.White
            .ReadOnly = True
        End With
        DG.Columns.Insert(3, Statuscolumn)

        With pincolumn
            .HeaderText = "PIN"
            .Name = "PIN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.White
            .ReadOnly = True
        End With
        DG.Columns.Insert(4, pincolumn) '

        With PNamecolumn
            .HeaderText = "Patient Name"
            .Name = "PTName"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.White
            .ReadOnly = True
        End With
        DG.Columns.Insert(5, PNamecolumn) '


        'The new columns
        With HkeepingChk
            .HeaderText = ""
            .Name = "Hkeepingchk"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            '.Width = 60
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.LightBlue
            .ReadOnly = True
        End With
        DG.Columns.Insert(6, HkeepingChk)

        With HkeepingDate
            .HeaderText = "HousKeeping Status"
            .Name = "Hkeepingdate"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.LightBlue
            .ReadOnly = True
        End With
        DG.Columns.Insert(7, HkeepingDate) '

        With HSKSTART
            .HeaderText = "HSK START"
            .Name = "HSKSTART"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .ReadOnly = True
            '.CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate = New DataGridViewImageCell
            .Image = My.Resources.f2
            .CellTemplate.Style.BackColor = Color.LightBlue
        End With
        DG.Columns.Insert(8, HSKSTART)

        With HSKCALLEDBy
            .HeaderText = "HSK-CALLED BY"
            .Name = "HSKCALLEDBy"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .ReadOnly = True
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.LightBlue
        End With
        DG.Columns.Insert(9, HSKCALLEDBy)


        With MinChk
            .HeaderText = ""
            .Name = "minchk"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            '.Width = 60
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.LightPink
            .ReadOnly = True
        End With
        DG.Columns.Insert(10, MinChk)

        With MinDate
            .HeaderText = "Maintenance Status"
            .Name = "Mindate"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.LightPink
            .ReadOnly = True
        End With
        DG.Columns.Insert(11, MinDate) '

        With MNTSTART
            .HeaderText = "MNT START"
            .Name = "MNTSTART"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .ReadOnly = True
            '.CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate = New DataGridViewImageCell
            .Image = My.Resources.f2
            .CellTemplate.Style.BackColor = Color.LightPink
        End With
        DG.Columns.Insert(12, MNTSTART)

        With MNTCALLEDBy
            .HeaderText = "MNT-CALLED BY"
            .Name = "MNTCALLEDBy"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .ReadOnly = True
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.LightPink
        End With
        DG.Columns.Insert(13, MNTCALLEDBy)



        With SafeChk
            .HeaderText = ""
            .Name = "safeChk"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            '.Width = 60
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.LightBlue
            .ReadOnly = True
            .Visible = False
        End With
        DG.Columns.Insert(14, SafeChk)

        With SafeDate
            .HeaderText = "Safety Status"
            .Name = "safedate"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.LightBlue
            .ReadOnly = True
            .Visible = False
        End With
        DG.Columns.Insert(15, SafeDate) '

        With SafSTART
            .HeaderText = "Safety START"
            .Name = "SafSTART"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .ReadOnly = True
            '.CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate = New DataGridViewImageCell
            .Image = My.Resources.f2
            .CellTemplate.Style.BackColor = Color.LightBlue
        End With
        DG.Columns.Insert(16, SafSTART)

        With SafCALLEDBy
            .HeaderText = "Safety-CALLED BY"
            .Name = "SafCALLEDBy"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .ReadOnly = True
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.LightBlue
        End With
        DG.Columns.Insert(17, SafCALLEDBy)



        With FinalChk
            .HeaderText = "Final Status"
            .Name = "finalChk"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            '.Width = 60
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.LightGreen
        End With
        DG.Columns.Insert(18, FinalChk)

        With ClearanceID
            .HeaderText = "ClearancID"
            .Name = "ClearanceID"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.White
            .ReadOnly = True
            .Visible = False
        End With
        DG.Columns.Insert(19, ClearanceID)

        With RegisteredBy
            .HeaderText = "Registered By"
            .Name = "RegBy"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .ReadOnly = True
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.LightPink
        End With
        DG.Columns.Insert(20, RegisteredBy)

        With StartProc
            .HeaderText = "Registered DT"
            .Name = "StartProc"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Width = 60
            .ReadOnly = True
            .CellTemplate = New DataGridViewTextBoxCell
            .CellTemplate.Style.BackColor = Color.LightPink
        End With
        DG.Columns.Insert(21, StartProc)

        With DelayReason
            .HeaderText = "Delay Reason"
            .Name = "DelayReason"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .Width = 400
            .CellTemplate = New DataGridViewComboBoxCell
            .CellTemplate.Style.BackColor = Color.White
            '.ReadOnly = True

            Dim ds As DataSet = SQLDATASET("select a.ID chkID,a.Description from bedclearance_checklist_master a where a.CategoryID=4 and Deleted=0 ", "Ta")
            .DataSource = ds.Tables(0)
            .DisplayMember = "Description"
            .ValueMember = "ChkID"
        End With
        DG.Columns.Insert(22, DelayReason) '

        'NEW
        Dim ParaReader As SqlClient.SqlDataReader =
        STANDRED_MODULE.SQLREADER("select * from tbl_bedclearanceParam")

        Do While ParaReader.Read
            sfty = ParaReader.GetValue(0)
            mtn = ParaReader.GetValue(1)
            hk = ParaReader.GetValue(2)
        Loop

        If sfty = 0 Then
            DG.Columns("safedate").Visible = False
            DG.Columns("safechk").Visible = False
            DG.columns("SafCALLEDBy").visible = False
            DG.columns("Safstart").visible = False
        ElseIf sfty = 1 Then
            DG.Columns("safedate").Visible = True
            DG.Columns("safechk").Visible = True
            DG.columns("SafCALLEDBy").visible = True
            DG.columns("Safstart").visible = True
        End If

        If mtn = 0 Then
            DG.Columns("Mindate").Visible = False
            DG.Columns("Minchk").Visible = False
            DG.columns("MNTCALLEDBy").visible = False
            DG.columns("MNTstart").visible = False
        ElseIf mtn = 1 Then
            DG.Columns("Mindate").Visible = True
            DG.Columns("Minchk").Visible = True
            DG.columns("MNTCALLEDBy").visible = True
            DG.columns("MNTstart").visible = True
        End If

        If hk = 0 Then
            DG.Columns("Hkeepingdate").Visible = False
            DG.Columns("Hkeepingchk").Visible = False
            DG.columns("HSKCALLEDBy").visible = False
            DG.columns("HSKstart").visible = False
        ElseIf hk = 1 Then
            DG.Columns("Hkeepingdate").Visible = True
            DG.Columns("Hkeepingchk").Visible = True
            DG.columns("HSKCALLEDBy").visible = True
            DG.columns("HSKstart").visible = True
        End If


        'by default
        DG.RowCount = 500
        'Desable Order by user 
        DG.AllowUserToOrderColumns = False
    End Sub
    Private Sub Clear_datagrid()
        Dim i, j As Integer

        For i = 0 To DataGridView1.Rows.Count - 1
            For j = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Item(j, i).Value = Nothing
            Next
        Next
        DataGridView1.RowCount = 500
        DataGridView1.Refresh()
    End Sub
    Private Sub LOad_data_sub(ByVal dg As Object, ByVal txt As String)
        Try
            Dim s As SqlClient.SqlDataReader = STANDRED_MODULE.SQLREADER(txt)
            Dim j As Integer = 0

            With dg
                Do While s.Read
                    .Item("ID", j).Value = s.GetValue(0)  'bed id
                    .Item("CHKID", j).Value = s.GetValue(5) 'chkvlaue
                    .Item("Bedname", j).Value = s.GetString(1) 'Bedname
                    .Item("STATUS", j).value = s.GetString(2) 'status
                    .Item("pin", j).Value = "SA01." & s.GetValue(3).ToString  'pin
                    If IsDBNull(s.GetValue(4)) = True Then
                        .Item("PTNAME", j).value = " "
                    Else
                        .item("PTNAME", j).value = s.GetString(4) 'patinet name
                    End If
                    'new records 
                    .Item("HKEEPINGCHK", j).Value = s.GetValue(6)  'hk chk id
                    .Item("HKEEPINGDATE", j).Value = s.GetString(7) 'hk date
                    .Item("MINCHK", j).Value = s.GetValue(8) 'min chkid
                    .Item("MINDATE", j).value = s.GetString(9) 'min date
                    .Item("SAFECHK", j).Value = s.GetValue(10) 'saftey chk id
                    .Item("SAFEDATE", j).Value = s.GetString(11) 'saftey date
                    .Item("FINALCHK", j).Value = s.GetValue(12) 'final approve
                    .item("CLEARANCEID", j).value = s.GetValue(13) 'clearanceID
                    .item("REGBY", j).value = s.GetString(14) 'RegisterBy
                    'NEW
                    If IsDBNull(s!hsk_call_datetime) Then
                        '.ITEM("HSKSTART", j).VALUE = s!HSK_CALL_DATETIME
                        .item("hskstart", j).value = My.Resources.f2
                        .ITEM("HSKCALLEDBY", j).VALUE = s!HSK_CALLEDBY
                    Else

                        .item("hskstart", j).value = My.Resources.f1
                        '.ITEM("HSKSTART", j).VALUE = Format(s!HSK_CALL_DATETIME, "HH:mm")
                        .ITEM("HSKCALLEDBY", j).VALUE = s!HSK_CALLEDBY & " @ " & Format(s!HSK_CALL_DATETIME, "HH:mm")
                    End If

                    If IsDBNull(s!mnt_call_datetime) Then
                        '.ITEM("MNTSTART", j).VALUE = s!MNT_CALL_DATETIME
                        .ITEM("MNTSTART", j).VALUE = My.Resources.f2
                        .ITEM("MNTCALLEDBY", j).VALUE = s!MNT_CALLEDBY

                    Else
                        '.ITEM("MNTSTART", j).VALUE = Format(s!MNT_CALL_DATETIME, "HH:mm")
                        .ITEM("MNTSTART", j).VALUE = My.Resources.f1
                        .ITEM("MNTCALLEDBY", j).VALUE = s!MNT_CALLEDBY & " @ " & Format(s!MNT_CALL_DATETIME, "HH:mm")
                    End If


                    If IsDBNull(s!SAF_call_datetime) Then
                        '.ITEM("SAFSTART", j).VALUE = s!SAF_CALL_DATETIME
                        .ITEM("SAFSTART", j).VALUE = My.Resources.f2
                        .ITEM("SAFCALLEDBY", j).VALUE = s!SAF_CALLEDBY
                    Else
                        '.ITEM("SAFSTART", j).VALUE = Format(s!SAF_CALL_DATETIME, "HH:mm")
                        .ITEM("SAFSTART", j).VALUE = My.Resources.f1
                        .ITEM("SAFCALLEDBY", j).VALUE = s!SAF_CALLEDBY & " & " & Format(s!SAF_CALL_DATETIME, "HH:mm")
                    End If


                    .item("StartProc", j).value = s!StartProc



                    '/*************PASS COMBO VALUE***********/
                    If IsDBNull(s!ChkListID) <> True Then
                        Dim i As Integer = 0
                        Dim objCombo As DataGridViewComboBoxCell
                        Dim drv As DataRowView
                        'Get our default combox value for this row
                        Dim strReason As String = s!ChkListID
                        objCombo = DirectCast(.Rows(j).Cells("DELAYREASON"), DataGridViewComboBoxCell)
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
                Loop
                dg.RowCount = j
                dg.AutoResizeColumns()

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub STation_combo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles STation_combo.SelectedValueChanged
        load_Combo()
    End Sub
    Private Sub load_Combo()
        Dim sql As String
        If STation_combo.Text.ToUpper <> "System.Data.DataRowView".ToUpper Then
            'sql = " select a.id,a.name,c.name,a.IPID" & _
            '" ,b.familyname + ' ' + b.FirstName, a.ForCleaning " & _
            '" from Bed a left join allinpatients b on (a.ipid=b.ipid and b.ipid<>0)" & _
            '" left join Bedstatus c on a.status=c.id " & _
            '" where a.deptcode='" & STation_combo.Text & "' and a.deptcode is not null and a.deleted=0 and c.id<>1"
            sql =
            " select a.id,a.name,c.name,b.registrationno " &
" ,b.familyname + ' ' + b.FirstName, (SELECT 'A'=CASE WHEN a.ForCleaning IS NULL THEN 0 WHEN A.FORCLEANING>0 THEN 1 ELSE 0 END) FORCLEANING " &
" ,(select 'A'= case  when d.HouseKeepingApproveID is null then 0 else 1 end) " &
" ,isnull(convert(varchar,d.HouseKeepingDateTime),'')" &
" ,(select 'A'= case  when d.MaintenanceApprove is null then 0 else 1 end ) " &
" ,isnull(convert(varchar,d.MaintenanceDateTime),'') " &
" ,(select 'A'= case  when d.SafetyApproveID is null then 0 else 1 end )" &
" ,isnull(convert(varchar,d.SafetyDateTime),'') " &
" ,0 as finalApprove ,d.id " &
" ,isnull((e.employeeid + '-' + e.FirstName + ' ' + e.lastname),'') as regBy" &
" ,HSK_CALL_DATETIME,HSK_CALLEDBY, MNT_CALL_DATETIME,MNT_CALLEDBY ,d.startdatetime as StartProc" &
" , SAF_CALL_DATETIME,SAF_CALLEDBY,CHK.ChkListID,CHK.DESCRIPTION " &
" from Bed a  " &
" left join allinpatients b on (a.ipid=b.ipid and b.ipid<>0) " &
" left join Bedstatus c on a.status=c.id " &
" INNER JOIN CLEANBEDRELEASE d on (d.bedid=a.id and d.FinalApproveID is null AND REVOKED IS NULL and ForCleaning>0) " &
" left join employee E on e.employeeid=convert(varchar,d.employeeid) " &
" LEFT join (Select adtl.BedClr_ID ,adtl.ChkListID ,amaster.Description " &
" from bedclearance_checklist_master as amaster, BedClearance_CheckList_Detail as adtl " &
" where amaster.CategoryID=adtl.CategoryID and amaster.ID=adtl.ChkListID and amaster.CategoryID=4) as chk " &
" on d.id=chk.BedClr_ID  " &
" where  a.deptcode='" & STation_combo.Text & "' and a.deptcode is not null and a.deleted=0 AND A.FORCLEANING>0 " &
" and d.id in (Select MAX(id) from CLEANBEDRELEASE where deptcode='" & STation_combo.Text & "' and FinalApproveID is null group by bedname) "
            'Select Case VacantRoom
            '    Case 1 : sql = sql + " and c.id=1 "
            '    Case 2 : sql = sql + " and c.id<>1 "
            'End Select
            Clear_datagrid()
            LOad_data_sub(DataGridView1, sql)
            'checkDepartmentParam()
        End If
    End Sub
    Private Function checkDepartmentParam(ByVal RID As Integer) As Boolean
        With DataGridView1
            Dim i As Integer
            i = RID
            'For i = 0 To .Rows.Count - 1

            'If .Item("CHKID", i).Value = 1 Or .Item("CHKID", i).Value = True Then
            '0=Not active
            Dim sq As String
            If sfty = 0 Then 'safety
                sq = "update cleanbedrelease set SafetyapproveID=0, safetydatetime =getdate() " &
                                                 " where SafetyapproveID is null and id=" & .Item("CLEARANCEID", i).Value
                Dim SFboolean As Boolean = STANDRED_MODULE.SQLExecute(sq)
            ElseIf sfty = 1 And (.Item("safeCHK", i).Value = 0 Or .Item("safeCHK", i).Value = False) Then
                MsgBox("Call Safety To Check the Room", MsgBoxStyle.Critical)
                Return False

            End If

            If mtn = 0 Then 'Maintinance
                sq = "update cleanbedrelease set Maintenanceapprove=0, maintenancedatetime =getdate() " &
                                    " where Maintenanceapprove is null and id=" & .Item("CLEARANCEID", i).Value
                Dim MiNboolean As Boolean = STANDRED_MODULE.SQLExecute(sq)
            ElseIf mtn = 1 And (.Item("MINCHK", i).Value = 0 Or .Item("MINCHK", i).Value = False) Then
                MsgBox("Call Maintenance To Check the Room", MsgBoxStyle.Critical)
                Return False
            End If

            If hk = 0 Then 'housekeeping
                sq = "update cleanbedrelease set HousekeepingapproveID=0, housekeepingdatetime =getdate() " &
                               " where HousekeepingapproveID is null and id=" & .Item("CLEARANCEID", i).Value
                Dim hkboolean As Boolean = STANDRED_MODULE.SQLExecute(sq)
            ElseIf hk = 1 And (.Item("HKEEPINGCHK", i).Value = 0 Or .Item("HKEEPINGCHK", i).Value = False) Then
                MsgBox("Call HouseKeeping To Check the Room", MsgBoxStyle.Critical)
                Return False
            End If
            'End If
            'Next

        End With
        Return True
        'MsgBox(sq)
    End Function
    Private Sub Approved_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Approved_btn.Click
        'step one check if there is no record in bed clearance was pending 'Final Approve"
        With DataGridView1
            Dim i As Integer
            Dim SQ As String
            For i = 0 To .Rows.Count - 1
                '' COMMENT: IF THE RECORD REAIS BY THE WardSec TRIGER. 
                If .Item("CHKID", i).Value = 1 Or .Item("CHKID", i).Value = True Then 'for cleaning
                    If checkRecPedning(.Item("ID", i).Value) = True Then
                        If .Item("FINALCHK", i).Value = 1 Or .Item("FINALCHK", i).Value = True Then

                            If checkDepartmentParam(i) = True Then  'to check which department for by pass

                                SQ = "update cleanbedrelease set FinalApproveID=" & EmpID &
                                     ", FinalDateTime =getdate() " &
                                    " where FinalApproveID is null and id=" & .Item("CLEARANCEID", i).Value
                                Dim Finalboolean As Boolean = STANDRED_MODULE.SQLExecute(SQ)

                                If .Item("STATUS", i).Value = "For Cleaning" Then
                                    SQ = "update bed set Status=1 where id=" & .Item("ID", i).Value &
                                    " and status=9 "
                                    Dim ChangeStatusboolean As Boolean = STANDRED_MODULE.SQLExecute(SQ)
                                End If

                                Dim sql1 As String = "update bed set ForCleaning=0 where id=" & .Item("ID", i).Value
                                Dim BedRelease As Boolean = STANDRED_MODULE.SQLExecute(sql1)

                                'new by Maze to clear the Uncomplete Records becuase of The IPclosing /Revok issue

                                Dim Sql2 As String
                                Sql2 = "update cleanbedrelease set FinalApproveID=139, FinalDateTime =getdate() " &
                                " where FinalApproveID is null and bedid=" & .Item("ID", i).Value
                                Dim CheckUpdate As Boolean = STANDRED_MODULE.SQLExecute(Sql2)

                            End If
                        End If
                    End If
                End If
            Next
            load_Combo()
        End With
    End Sub
    Private Function Approved_old()
        'step one check if there is no record in bed clearance was pending 'Final Approve"
        With DataGridView1
            Dim i As Integer
            For i = 0 To .Rows.Count - 1
                '' COMMENT: IF THE RECORD REAIS BY THE ADMISSION TRIGER. 
                If .Item("CHKID", i).Value = 1 Or .Item("CHKID", i).Value = True Then
                    If checkRecPedning(.Item("ID", i).Value) = True Then
                        'NO CHANGE , there is alrady record but not finish
                        'chek tha status
                        'updateTheCleanbedrelease if the check the Final Approve 

                        ''If .Item(12, i).Value = 1 Or .Item(12, i).Value = True And _
                        ''    (.Item(10, i).Value = 1 Or .Item(10, i).Value = True) And _
                        ''    (.Item(8, i).Value = 1 Or .Item(8, i).Value = True) And _
                        ''    (.Item(6, i).Value = 1 Or .Item(6, i).Value = True) Then

                        ''If .Item(12, i).Value = 1 Or .Item(12, i).Value = True Then

                        ''COMMENT: Allowed Only when HouseKeeping and MNT approved

                        If .Item("FINALCHK", i).Value = 1 Or .Item("FINALCHK", i).Value = True And
                           (.Item("HKEEPINGCHK", i).Value = 1 Or .Item("HKEEPINGCHK", i).Value = True) And
                          (.Item("MINCHK", i).Value = 1 Or .Item("MINCHK", i).Value = True) Then


                            ''If NO_MAIN_RECOD_SGH2(.Item(2, i).Value) = True Then ''this disabled on 02 06 2013 as per the agreement between Nur and MNT JR#6457

                            ''COMMENT: allowed OVERALL APPROVED BY NURSING AS PER MR. ABNER INSTRACTION 23/08/2010

                            'Dim sq As String = _
                            '"update cleanbedrelease set HousekeepingapproveID=" & EmpID & _
                            '", housekeepingdatetime =getdate() " & _
                            '" where HousekeepingapproveID is null and id=" & .Item(13, i).Value
                            'Dim hkboolean As Boolean = STANDRED_MODULE.SQLExecute(sq)

                            Dim SQ As String
                            'SQ = "update cleanbedrelease set SafetyapproveID=" & EmpID & _
                            '     ", safetydatetime =getdate() " & _
                            '     " where SafetyapproveID is null and id=" & .Item("CLEARANCEID", i).Value
                            'Dim SFboolean As Boolean = STANDRED_MODULE.SQLExecute(SQ)

                            'SQ = "update cleanbedrelease set Maintenanceapprove=" & EmpID & _
                            '     ", maintenancedatetime =getdate() " & _
                            '    " where Maintenanceapprove is null and id=" & .Item(13, i).Value
                            'Dim MiNboolean As Boolean = STANDRED_MODULE.SQLExecute(SQ)


                            SQ = "update cleanbedrelease set FinalApproveID=" & EmpID &
                                 ", FinalDateTime =getdate() " &
                                " where FinalApproveID is null and id=" & .Item("CLEARANCEID", i).Value
                            Dim Finalboolean As Boolean = STANDRED_MODULE.SQLExecute(SQ)

                            'If .Item(3, i).Value = "To be Cleaned" Then 
                            If .Item("STATUS", i).Value = "For Cleaning" Then
                                SQ = "update bed set Status=1 where id=" & .Item("ID", i).Value &
                                " and status=9 "
                                Dim ChangeStatusboolean As Boolean = STANDRED_MODULE.SQLExecute(SQ)
                            End If

                            Dim sql1 As String = "update bed set ForCleaning=0 where id=" & .Item("ID", i).Value
                            Dim BedRelease As Boolean = STANDRED_MODULE.SQLExecute(sql1)
                            'Else
                            'MsgBox("OTHER DEPARTMENTS SHOULD APPROVED FIRST!", MsgBoxStyle.Critical)

                            ''End If
                        ElseIf .Item("FINALCHK", i).Value = 1 Or .Item("FINALCHK", i).Value = True And
                            (.Item("HKEEPINGCHK", i).Value = 0 Or .Item("HKEEPINGCHK", i).Value = False) Then
                            MsgBox("Call HouseKeeping To Check the Room", MsgBoxStyle.Critical)
                        ElseIf .Item("FINALCHK", i).Value = 1 Or .Item("FINALCHK", i).Value = True And
                            (.Item("MINCHK", i).Value = 0 Or .Item("MINCHK", i).Value = False) Then
                            MsgBox("Call Maintenance To Check the Room", MsgBoxStyle.Critical)
                        End If
                        ' comment NO more sending Room for Cleain i will received from trigger of Admission Office.

                        ''ElseIf checkRecPedning(.Item(0, i).Value) = False Then
                        ''    'INSERT A NEW RECORD IN THE CLEANBEDRELEASE
                        ''    Dim S1 As String = _
                        ''    "INSERT INTO CLEANBEDRELEASE (" & _
                        ''    "bedid,bedname,HouseKeepingApproveID,HouseKeepingDateTime," & _
                        ''    "SafetyApproveID,SafetyDateTime,MaintenanceApprove,MaintenanceDateTime," & _
                        ''    "FinalApproveID, FinalDateTime,Startdatetime,status,deptcode,sms_status,employeeid) VALUES(" & _
                        ''    .Item(0, i).Value & ",'" & .Item(2, i).Value & "',NULL,NULL,NULL,NULL," & _
                        ''    "NULL,NULL,NULL,NULL,GETDATE(),'" & .Item(3, i).Value & "','" & STation_combo.SelectedValue & "','SEND'," & EmpID & ")"
                        ''    'MsgBox("the sql:" & S1)
                        ''    Dim COM1 As Boolean = STANDRED_MODULE.SQLExecute(S1)
                        ''    'UPDATE THE BED TABLE
                        ''    Dim COM2 As Boolean = STANDRED_MODULE.SQLExecute("UPDATE BED SET ForCleaning=1 WHERE ID=" & .Item(0, i).Value)
                        ''    MsgBox("Following Room has been sent for Room Cleaning!")
                    End If
                End If
            Next
            load_Combo()
        End With
    End Function REM no more use
    Private Function NO_MAIN_RECOD_SGH2(ByVal BEDNAME As String) As Boolean
        Try
            'MsgBox(BEDNAME.Substring(0, 3))

            Dim ParaReader As Odbc.OdbcDataReader =
                   STANDRED_MODULE.ODBCREADER("select STATUS from MNT_WORK_REQUEST " &
                   " WHERE FA_ITEM_NO LIKE 'R" & BEDNAME.Substring(0, 3) & "%' " &
                   " AND IMPORTANCE=2 " &
                   " AND  REQ_DATE>='01-" & Today.AddMonths(-1).ToString("MMM") & "-" & Today.Year.ToString.Substring(2, 2) & "' " &
                   " GROUP BY STATUS ORDER BY STATUS ")
            Dim SSS As Integer
            If ParaReader.HasRows = True Then
                Do While ParaReader.Read
                    SSS = ParaReader.GetValue(0)
                    ' CODE 30= user acknowledge the JOB done by MNT
                    ' CODE 35= user acknowledge the Cancelation done by the MNT
                    ' CODE 28= DONE BY MNT
                    ' CODE 32= CANCEL BY MNT
                    If SSS <> 28 And SSS <> 32 And SSS <> 30 And SSS <> 35 Then
                        MsgBox("THERE IS A PENDING JOB MAINTENANCE !" & Chr(13) &
                        " REQUEST FOR THIS ROOM. " & Chr(13) &
                        "PLEASE CALL MAINTENANCE FOR VERIFICATION", MsgBoxStyle.Critical)
                        Return False
                        Exit Function
                    End If
                Loop
            Else
                Return True
            End If
            Return True
        Catch ex As Exception
            'MsgBox("Check the ODBC Connection OF SGH2, Call IT")
            'Return False         'IN CASE IF THE SGH2 SERVER IS DOWN.
            '--new decide on 07-may-2012, if there is any error just pass this function and return true no need
            '-- 
            Return True
        End Try
    End Function
    Private Function checkRecPedning(ByVal ID As Integer) As Boolean
        Dim RD As SqlClient.SqlDataReader = STANDRED_MODULE.SQLREADER _
        ("SELECT * FROM cleanbedrelease WHERE BedID=" & ID & " AND FINALAPPROVEID IS NULL ")
        If RD.HasRows = True Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label2.Text = "Last Update time:" & Now.ToString
        load_Combo()
    End Sub
    'refresh now button
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        load_Combo()
    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

        If RadioButton1.Checked = True Then
            DataGridView1.Font = RadioButton1.Font
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            DataGridView1.Font = RadioButton2.Font
        End If
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            DataGridView1.Font = RadioButton4.Font
        End If
    End Sub
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            DataGridView1.Font = RadioButton3.Font
        End If
    End Sub
    'NEW 
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        If STANDRED_MODULE.DepTIDGlob = 4 Or STANDRED_MODULE.DepTIDGlob = 5 Then
            If e.ColumnIndex = DataGridView1.Columns("HSKSTART").Index And
                (IsDBNull(DataGridView1.Item("HSKCALLEDBY", e.RowIndex).Value)) Then
                Dim MS As MsgBoxResult = MsgBox("DO YOU WANT TO CALL HousKeeping TO START PROCESS?", MsgBoxStyle.YesNo)
                If MS = MsgBoxResult.Yes Then
                    Dim XB As Boolean
                    XB = SQLExecute("UPDATE CLEANBEDRELEASE SET HSK_CALL_DATETIME=SYSDATETIME(),HSK_CALLEDBY=" & EmpID _
                    & " WHERE ID=" & DataGridView1.Item("ClearanceID", e.RowIndex).Value)
                    SEND_SMS(1, e.RowIndex)

                End If
            ElseIf e.ColumnIndex = DataGridView1.Columns("HSKSTART").Index And
                Not (IsDBNull(DataGridView1.Item("HSKCALLEDBY", e.RowIndex).Value)) Then
                REM view 
                View_Load(DataGridView1.Item("ClearanceID", e.RowIndex).Value, 1, DataGridView1.Item("bedname", e.RowIndex).Value, "HSK Department")
            End If

            If e.ColumnIndex = DataGridView1.Columns("MNTSTART").Index And
               (IsDBNull(DataGridView1.Item("MNTCALLEDBY", e.RowIndex).Value)) Then
                Dim MS As MsgBoxResult = MsgBox("DO YOU WANT TO CALL Maintenance TO START PROCESS?", MsgBoxStyle.YesNo)
                If MS = MsgBoxResult.Yes Then
                    Dim XB As Boolean
                    XB = SQLExecute("UPDATE CLEANBEDRELEASE SET MNT_CALL_DATETIME=SYSDATETIME(),MNT_CALLEDBY=" & EmpID _
                    & " WHERE ID=" & DataGridView1.Item("ClearanceID", e.RowIndex).Value)
                    SEND_SMS(3, e.RowIndex)
                End If
            ElseIf e.ColumnIndex = DataGridView1.Columns("MNTSTART").Index And
               Not (IsDBNull(DataGridView1.Item("MNTCALLEDBY", e.RowIndex).Value)) Then
                View_Load(DataGridView1.Item("ClearanceID", e.RowIndex).Value, 3, DataGridView1.Item("bedname", e.RowIndex).Value, "MNT Department")
            End If

            If e.ColumnIndex = DataGridView1.Columns("SAFSTART").Index And
                (IsDBNull(DataGridView1.Item("SAFCALLEDBY", e.RowIndex).Value)) Then
                Dim MS As MsgBoxResult = MsgBox("DO YOU WANT TO CALL SAFETY TO START PROCESS?", MsgBoxStyle.YesNo)
                If MS = MsgBoxResult.Yes Then
                    Dim XB As Boolean
                    XB = SQLExecute("UPDATE CLEANBEDRELEASE SET SAF_CALL_DATETIME=SYSDATETIME(),SAF_CALLEDBY=" & EmpID _
                    & " WHERE ID=" & DataGridView1.Item("ClearanceID", e.RowIndex).Value)
                    SEND_SMS(2, e.RowIndex)
                End If
            ElseIf e.ColumnIndex = DataGridView1.Columns("SAFSTART").Index And
                Not (IsDBNull(DataGridView1.Item("SAFCALLEDBY", e.RowIndex).Value)) Then
                View_Load(DataGridView1.Item("ClearanceID", e.RowIndex).Value, 2, DataGridView1.Item("bedname", e.RowIndex).Value, "SAFETY Department")
            End If


            Label2.Text = "Last Update time:" & Now.ToString
            load_Combo()



        Else '************************* FOR VIEW ONLY ********************************
            If e.ColumnIndex = DataGridView1.Columns("HSKSTART").Index And
               Not (IsDBNull(DataGridView1.Item("HSKCALLEDBY", e.RowIndex).Value)) Then
                View_Load(DataGridView1.Item("ClearanceID", e.RowIndex).Value, 1, DataGridView1.Item("bedname", e.RowIndex).Value, "HSK Department")
            End If

            If e.ColumnIndex = DataGridView1.Columns("MNTSTART").Index And
               Not (IsDBNull(DataGridView1.Item("MNTCALLEDBY", e.RowIndex).Value)) Then
                View_Load(DataGridView1.Item("ClearanceID", e.RowIndex).Value, 3, DataGridView1.Item("bedname", e.RowIndex).Value, "MNT Department")
            End If

            If e.ColumnIndex = DataGridView1.Columns("SAFSTART").Index And
                Not (IsDBNull(DataGridView1.Item("SAFCALLEDBY", e.RowIndex).Value)) Then
                View_Load(DataGridView1.Item("ClearanceID", e.RowIndex).Value, 2, DataGridView1.Item("bedname", e.RowIndex).Value, "SAFETY Department")
            End If
        End If

    End Sub
    'new codeing for viewing the status
    Private Sub btn_Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Back.Click
        Pan_chkList.Visible = False
    End Sub
    Private Sub View_Load(ByVal ViewTransID, ByVal ViewDept, ByVal ViewBedName, ByVal DeptName)
        Clear_datagrid(dgv_list)
        lbl_Title.Text = "BedName : " & ViewBedName & Space(10) & " ' " & DeptName & " '"
        GetRecords(ViewTransID, ViewDept)
        Pan_chkList.Visible = True
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
                LoadList(Dept)
            End If
            dgv_list.Refresh()
            dgv_list.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("" & ex.Message)
        End Try
    End Sub
    Private Sub dgv_list_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        e.ThrowException = False
    End Sub
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

                Dim ds As DataSet = SQLDATASET("select employeeid as Empid,employeeid + ' - ' + Name as name from Employee where departmentid=60 and deleted=0 order by name ", "Ta")
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
    Private Sub LoadList(ByVal departmentid As Integer)
        Dim sql As String
        sql = " select ID as Seq,Description from BedCLearance_checklist_master " _
            & " where deleted=0 and Categoryid= " & departmentid
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
    'new function to send SMS
    Private Sub SEND_SMS(ByVal CID As Integer, ByVal Rid As Integer)
        Try
            Dim response As Boolean
            Dim SQL As String
            SQL =
            "select 'You may now Proceed, Room Number: " & DataGridView1.Item("BedName", Rid).Value & "' as textMessage " &
            ", MobileNumber " &
            " from BedClearanceAdmin   where categoryid=" & CID & " and len(mobilenumber)>10  "


            Dim sq As SqlClient.SqlDataReader = SQLREADER(SQL)
            If sq.HasRows = True Then
                Do While sq.Read
                    response = SQLExecute_SMS("Insert into SMSPOST1 " &
                        "select 1,'SEND','SGHJEDDAH','99','RECEPTION','" & sq!mobilenumber & "'," &
                        "N'" & sq!textMessage & " " & Format(Now, ("dd-MMM-yy hh:mm tt")) & "',''")
                Loop
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        e.ThrowException = False
    End Sub
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Try

            If e.ColumnIndex = DataGridView1.Columns("DELAYREASON").Index Then
                Dim UPD As Boolean =
                SQLExecute("DELETE FROM bedclearance_checklist_DETAIL WHERE BEDCLR_ID=" & DataGridView1.Item("CLEARANCEID", e.RowIndex).Value)

                UPD = SQLExecute("INSERT INTO Bedclearance_checklist_DETAIL VALUES(" & DataGridView1.Item("CLEARANCEID", e.RowIndex).Value & ",4," &
                     DataGridView1.Item("DELAYREASON", e.RowIndex).Value & "," & EmpID & ",SYSDATETIME(),'') ")


            End If
        Catch ex As Exception
            'MsgBox("ERROR WHEN TRY TO SAVE THE DELAY REASON!", MsgBoxStyle.Information)
        End Try

    End Sub


End Class