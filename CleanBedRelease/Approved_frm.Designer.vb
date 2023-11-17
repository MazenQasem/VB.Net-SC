<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Approved_frm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Approved_btn = New System.Windows.Forms.Button
        Me.Exit_btn = New System.Windows.Forms.Button
        Me.Section_lbl = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.Pan_chkList = New System.Windows.Forms.Panel
        Me.btn_Print = New System.Windows.Forms.Button
        Me.lbl_RecordID = New System.Windows.Forms.Label
        Me.btn_Back = New System.Windows.Forms.Button
        Me.dgv_list = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_Status = New System.Windows.Forms.ComboBox
        Me.Save_btn = New System.Windows.Forms.Button
        Me.txt_approver = New System.Windows.Forms.TextBox
        Me.lbl_Title = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)

        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan_chkList.SuspendLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Approved_btn
        '
        Me.Approved_btn.BackColor = System.Drawing.Color.Lime
        Me.Approved_btn.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Approved_btn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Approved_btn.Location = New System.Drawing.Point(10, 371)
        Me.Approved_btn.Name = "Approved_btn"
        Me.Approved_btn.Size = New System.Drawing.Size(136, 26)
        Me.Approved_btn.TabIndex = 0
        Me.Approved_btn.Text = "Release Bed"
        Me.Approved_btn.UseVisualStyleBackColor = False
        '
        'Exit_btn
        '
        Me.Exit_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Exit_btn.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exit_btn.Location = New System.Drawing.Point(317, 371)
        Me.Exit_btn.Name = "Exit_btn"
        Me.Exit_btn.Size = New System.Drawing.Size(136, 26)
        Me.Exit_btn.TabIndex = 4
        Me.Exit_btn.Text = "EXIT"
        Me.Exit_btn.UseVisualStyleBackColor = False
        '
        'Section_lbl
        '
        Me.Section_lbl.AutoSize = True
        Me.Section_lbl.Font = New System.Drawing.Font("Tahoma", 14.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Section_lbl.ForeColor = System.Drawing.Color.Red
        Me.Section_lbl.Location = New System.Drawing.Point(10, 9)
        Me.Section_lbl.Name = "Section_lbl"
        Me.Section_lbl.Size = New System.Drawing.Size(145, 23)
        Me.Section_lbl.TabIndex = 5
        Me.Section_lbl.Text = "Bed name List"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(497, 378)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Bed name List"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(10, 34)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 26
        Me.DataGridView1.Size = New System.Drawing.Size(725, 335)
        Me.DataGridView1.TabIndex = 12
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(162, 371)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 26)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Pan_chkList
        '
        Me.Pan_chkList.AutoScroll = True
        Me.Pan_chkList.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Pan_chkList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pan_chkList.Controls.Add(Me.btn_Print)
        Me.Pan_chkList.Controls.Add(Me.lbl_RecordID)
        Me.Pan_chkList.Controls.Add(Me.btn_Back)
        Me.Pan_chkList.Controls.Add(Me.dgv_list)
        Me.Pan_chkList.Controls.Add(Me.GroupBox1)
        Me.Pan_chkList.Controls.Add(Me.lbl_Title)
        Me.Pan_chkList.Controls.Add(Me.Label3)
        Me.Pan_chkList.Location = New System.Drawing.Point(10, 421)
        Me.Pan_chkList.Name = "Pan_chkList"
        Me.Pan_chkList.Size = New System.Drawing.Size(725, 440)
        Me.Pan_chkList.TabIndex = 14
        '
        'btn_Print
        '
        Me.btn_Print.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btn_Print.Location = New System.Drawing.Point(387, 409)
        Me.btn_Print.Name = "btn_Print"
        Me.btn_Print.Size = New System.Drawing.Size(86, 23)
        Me.btn_Print.TabIndex = 71
        Me.btn_Print.Text = "Print List"
        Me.btn_Print.UseVisualStyleBackColor = True
        '
        'lbl_RecordID
        '
        Me.lbl_RecordID.AutoSize = True
        Me.lbl_RecordID.Location = New System.Drawing.Point(533, 8)
        Me.lbl_RecordID.Name = "lbl_RecordID"
        Me.lbl_RecordID.Size = New System.Drawing.Size(68, 13)
        Me.lbl_RecordID.TabIndex = 70
        Me.lbl_RecordID.Text = "lbl_RecordID"
        Me.lbl_RecordID.Visible = False
        '
        'btn_Back
        '
        Me.btn_Back.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btn_Back.Location = New System.Drawing.Point(618, 3)
        Me.btn_Back.Name = "btn_Back"
        Me.btn_Back.Size = New System.Drawing.Size(86, 23)
        Me.btn_Back.TabIndex = 65
        Me.btn_Back.Text = "Back"
        Me.btn_Back.UseVisualStyleBackColor = True
        '
        'dgv_list
        '
        Me.dgv_list.AllowUserToAddRows = False
        Me.dgv_list.AllowUserToDeleteRows = False
        Me.dgv_list.AllowUserToResizeColumns = False
        Me.dgv_list.AllowUserToResizeRows = False
        Me.dgv_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgv_list.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgv_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv_list.Location = New System.Drawing.Point(7, 66)
        Me.dgv_list.MultiSelect = False
        Me.dgv_list.Name = "dgv_list"
        Me.dgv_list.RowHeadersVisible = False
        Me.dgv_list.Size = New System.Drawing.Size(707, 337)
        Me.dgv_list.TabIndex = 69
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmb_Status)
        Me.GroupBox1.Controls.Add(Me.Save_btn)
        Me.GroupBox1.Controls.Add(Me.txt_approver)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(707, 37)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Approver"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(406, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Status"
        '
        'cmb_Status
        '
        Me.cmb_Status.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Status.FormattingEnabled = True
        Me.cmb_Status.Items.AddRange(New Object() {"Pending", "Release"})
        Me.cmb_Status.Location = New System.Drawing.Point(456, 10)
        Me.cmb_Status.Name = "cmb_Status"
        Me.cmb_Status.Size = New System.Drawing.Size(118, 22)
        Me.cmb_Status.TabIndex = 71
        '
        'Save_btn
        '
        Me.Save_btn.Location = New System.Drawing.Point(612, 8)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(86, 23)
        Me.Save_btn.TabIndex = 70
        Me.Save_btn.Text = "Save"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'txt_approver
        '
        Me.txt_approver.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_approver.Location = New System.Drawing.Point(65, 10)
        Me.txt_approver.Name = "txt_approver"
        Me.txt_approver.Size = New System.Drawing.Size(335, 22)
        Me.txt_approver.TabIndex = 63
        '
        'lbl_Title
        '
        Me.lbl_Title.AutoSize = True
        Me.lbl_Title.Font = New System.Drawing.Font("Traditional Arabic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lbl_Title.ForeColor = System.Drawing.Color.Firebrick
        Me.lbl_Title.Location = New System.Drawing.Point(3, 2)
        Me.lbl_Title.Name = "lbl_Title"
        Me.lbl_Title.Size = New System.Drawing.Size(469, 29)
        Me.lbl_Title.TabIndex = 56
        Me.lbl_Title.Text = "Bed Name : 202-A , Date Of Action Start 20-01-2013"
        Me.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(-16, 355)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "1"
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 6000
        '
        'Approved_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(838, 599)
        Me.Controls.Add(Me.Pan_chkList)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Section_lbl)
        Me.Controls.Add(Me.Exit_btn)
        Me.Controls.Add(Me.Approved_btn)
        Me.Name = "Approved_frm"
        Me.Text = "SGHg- Clean Bed Release"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan_chkList.ResumeLayout(False)
        Me.Pan_chkList.PerformLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Approved_btn As System.Windows.Forms.Button
    Friend WithEvents Exit_btn As System.Windows.Forms.Button
    Friend WithEvents Section_lbl As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Pan_chkList As System.Windows.Forms.Panel
    Friend WithEvents lbl_Title As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_approver As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Back As System.Windows.Forms.Button
    Friend WithEvents dgv_list As System.Windows.Forms.DataGridView
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_Status As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_RecordID As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer

    Friend WithEvents btn_Print As System.Windows.Forms.Button

End Class
