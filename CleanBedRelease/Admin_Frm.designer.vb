<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Frm
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Add_btn = New System.Windows.Forms.Button
        Me.Save_btn = New System.Windows.Forms.Button
        Me.Del_btn = New System.Windows.Forms.Button
        Me.Open_btn = New System.Windows.Forms.Button
        Me.Exit_btn = New System.Windows.Forms.Button
        Me.EMPID_Combo = New System.Windows.Forms.ComboBox
        Me.Category_combo = New System.Windows.Forms.ComboBox
        Me.Mobile_txt = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Save2_btn = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.MTN_chkbox = New System.Windows.Forms.CheckBox
        Me.Safety_chkbox = New System.Windows.Forms.CheckBox
        Me.HK_chkbox = New System.Windows.Forms.CheckBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.categoryID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CHKID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Deleted = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Label6 = New System.Windows.Forms.Label
        Me.Category_cmb2 = New System.Windows.Forms.ComboBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Employee ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Category"
        '
        'Add_btn
        '
        Me.Add_btn.Location = New System.Drawing.Point(41, 111)
        Me.Add_btn.Name = "Add_btn"
        Me.Add_btn.Size = New System.Drawing.Size(75, 23)
        Me.Add_btn.TabIndex = 7
        Me.Add_btn.Text = "Clear"
        Me.Add_btn.UseVisualStyleBackColor = True
        '
        'Save_btn
        '
        Me.Save_btn.Location = New System.Drawing.Point(122, 111)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(75, 23)
        Me.Save_btn.TabIndex = 8
        Me.Save_btn.Text = "Save"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Del_btn
        '
        Me.Del_btn.Location = New System.Drawing.Point(203, 111)
        Me.Del_btn.Name = "Del_btn"
        Me.Del_btn.Size = New System.Drawing.Size(75, 23)
        Me.Del_btn.TabIndex = 9
        Me.Del_btn.Text = "Delete"
        Me.Del_btn.UseVisualStyleBackColor = True
        '
        'Open_btn
        '
        Me.Open_btn.Location = New System.Drawing.Point(284, 111)
        Me.Open_btn.Name = "Open_btn"
        Me.Open_btn.Size = New System.Drawing.Size(75, 23)
        Me.Open_btn.TabIndex = 10
        Me.Open_btn.Text = "Open"
        Me.Open_btn.UseVisualStyleBackColor = True
        '
        'Exit_btn
        '
        Me.Exit_btn.Location = New System.Drawing.Point(505, 403)
        Me.Exit_btn.Name = "Exit_btn"
        Me.Exit_btn.Size = New System.Drawing.Size(75, 23)
        Me.Exit_btn.TabIndex = 11
        Me.Exit_btn.Text = "Exit"
        Me.Exit_btn.UseVisualStyleBackColor = True
        '
        'EMPID_Combo
        '
        Me.EMPID_Combo.FormattingEnabled = True
        Me.EMPID_Combo.Location = New System.Drawing.Point(130, 16)
        Me.EMPID_Combo.Name = "EMPID_Combo"
        Me.EMPID_Combo.Size = New System.Drawing.Size(163, 21)
        Me.EMPID_Combo.TabIndex = 12
        '
        'Category_combo
        '
        Me.Category_combo.FormattingEnabled = True
        Me.Category_combo.Location = New System.Drawing.Point(130, 51)
        Me.Category_combo.Name = "Category_combo"
        Me.Category_combo.Size = New System.Drawing.Size(163, 21)
        Me.Category_combo.TabIndex = 13
        '
        'Mobile_txt
        '
        Me.Mobile_txt.Location = New System.Drawing.Point(130, 78)
        Me.Mobile_txt.Name = "Mobile_txt"
        Me.Mobile_txt.Size = New System.Drawing.Size(163, 20)
        Me.Mobile_txt.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(12, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 19)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Mobile NO#"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(1, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(579, 394)
        Me.TabControl1.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Tan
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Category_combo)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Open_btn)
        Me.TabPage1.Controls.Add(Me.Del_btn)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Save_btn)
        Me.TabPage1.Controls.Add(Me.Mobile_txt)
        Me.TabPage1.Controls.Add(Me.Add_btn)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.EMPID_Combo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(571, 368)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Users"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(297, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "+96650XXXXXXX"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Tan
        Me.TabPage2.Controls.Add(Me.Save2_btn)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.MTN_chkbox)
        Me.TabPage2.Controls.Add(Me.Safety_chkbox)
        Me.TabPage2.Controls.Add(Me.HK_chkbox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(571, 368)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Department Activation"
        '
        'Save2_btn
        '
        Me.Save2_btn.Location = New System.Drawing.Point(157, 111)
        Me.Save2_btn.Name = "Save2_btn"
        Me.Save2_btn.Size = New System.Drawing.Size(90, 23)
        Me.Save2_btn.TabIndex = 9
        Me.Save2_btn.Text = "Save"
        Me.Save2_btn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(6, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(209, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Check the Department to be Active:"
        '
        'MTN_chkbox
        '
        Me.MTN_chkbox.AutoSize = True
        Me.MTN_chkbox.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MTN_chkbox.Location = New System.Drawing.Point(7, 90)
        Me.MTN_chkbox.Name = "MTN_chkbox"
        Me.MTN_chkbox.Size = New System.Drawing.Size(132, 23)
        Me.MTN_chkbox.TabIndex = 2
        Me.MTN_chkbox.Text = "Maintenance"
        Me.MTN_chkbox.UseVisualStyleBackColor = True
        '
        'Safety_chkbox
        '
        Me.Safety_chkbox.AutoSize = True
        Me.Safety_chkbox.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Safety_chkbox.Location = New System.Drawing.Point(7, 61)
        Me.Safety_chkbox.Name = "Safety_chkbox"
        Me.Safety_chkbox.Size = New System.Drawing.Size(80, 23)
        Me.Safety_chkbox.TabIndex = 1
        Me.Safety_chkbox.Text = "Safety"
        Me.Safety_chkbox.UseVisualStyleBackColor = True
        '
        'HK_chkbox
        '
        Me.HK_chkbox.AutoSize = True
        Me.HK_chkbox.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HK_chkbox.Location = New System.Drawing.Point(7, 32)
        Me.HK_chkbox.Name = "HK_chkbox"
        Me.HK_chkbox.Size = New System.Drawing.Size(144, 23)
        Me.HK_chkbox.TabIndex = 0
        Me.HK_chkbox.Text = "HouseKeeping"
        Me.HK_chkbox.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Tan
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.DataGridView1)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.Category_cmb2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(571, 368)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Check List"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(235, 343)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.categoryID, Me.CHKID, Me.Description, Me.Deleted})
        Me.DataGridView1.Location = New System.Drawing.Point(10, 33)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(555, 309)
        Me.DataGridView1.TabIndex = 3
        '
        'categoryID
        '
        Me.categoryID.HeaderText = "Categoryid"
        Me.categoryID.Name = "categoryID"
        Me.categoryID.Visible = False
        '
        'CHKID
        '
        Me.CHKID.HeaderText = "SEQ"
        Me.CHKID.Name = "CHKID"
        Me.CHKID.ReadOnly = True
        Me.CHKID.Width = 30
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.MaxInputLength = 200
        Me.Description.Name = "Description"
        Me.Description.Width = 300
        '
        'Deleted
        '
        Me.Deleted.HeaderText = "Deleted"
        Me.Deleted.Name = "Deleted"
        Me.Deleted.Width = 70
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(6, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 19)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Category"
        '
        'Category_cmb2
        '
        Me.Category_cmb2.FormattingEnabled = True
        Me.Category_cmb2.Location = New System.Drawing.Point(95, 6)
        Me.Category_cmb2.Name = "Category_cmb2"
        Me.Category_cmb2.Size = New System.Drawing.Size(173, 21)
        Me.Category_cmb2.TabIndex = 0
        '
        'Admin_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(592, 438)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Exit_btn)
        Me.Name = "Admin_Frm"
        Me.Text = "Administrator Form"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Add_btn As System.Windows.Forms.Button
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Del_btn As System.Windows.Forms.Button
    Friend WithEvents Open_btn As System.Windows.Forms.Button
    Friend WithEvents Exit_btn As System.Windows.Forms.Button
    Friend WithEvents EMPID_Combo As System.Windows.Forms.ComboBox
    Friend WithEvents Category_combo As System.Windows.Forms.ComboBox
    Friend WithEvents Mobile_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Safety_chkbox As System.Windows.Forms.CheckBox
    Friend WithEvents HK_chkbox As System.Windows.Forms.CheckBox
    Friend WithEvents MTN_chkbox As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Save2_btn As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Category_cmb2 As System.Windows.Forms.ComboBox
    Friend WithEvents categoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHKID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Deleted As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
