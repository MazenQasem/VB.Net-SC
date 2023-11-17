<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LOGON_FRM
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
        Me.EXIT_BTN = New System.Windows.Forms.Button
        Me.SAVE_BTN = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.UserPass_txt = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.UserID_txt = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'EXIT_BTN
        '
        Me.EXIT_BTN.Location = New System.Drawing.Point(177, 97)
        Me.EXIT_BTN.Name = "EXIT_BTN"
        Me.EXIT_BTN.Size = New System.Drawing.Size(103, 23)
        Me.EXIT_BTN.TabIndex = 64
        Me.EXIT_BTN.Text = "&EXIT"
        Me.EXIT_BTN.UseVisualStyleBackColor = True
        '
        'SAVE_BTN
        '
        Me.SAVE_BTN.Location = New System.Drawing.Point(15, 97)
        Me.SAVE_BTN.Name = "SAVE_BTN"
        Me.SAVE_BTN.Size = New System.Drawing.Size(103, 23)
        Me.SAVE_BTN.TabIndex = 63
        Me.SAVE_BTN.Text = "Enter"
        Me.SAVE_BTN.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(13, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(17, 17)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "*"
        '
        'UserPass_txt
        '
        Me.UserPass_txt.Location = New System.Drawing.Point(159, 47)
        Me.UserPass_txt.Name = "UserPass_txt"
        Me.UserPass_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.UserPass_txt.Size = New System.Drawing.Size(121, 20)
        Me.UserPass_txt.TabIndex = 61
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(29, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 17)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Password:"
        '
        'UserID_txt
        '
        Me.UserID_txt.Location = New System.Drawing.Point(159, 21)
        Me.UserID_txt.Name = "UserID_txt"
        Me.UserID_txt.Size = New System.Drawing.Size(121, 20)
        Me.UserID_txt.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(13, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 17)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(29, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 17)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Employee ID:"
        '
        'LOGON_FRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 132)
        Me.Controls.Add(Me.EXIT_BTN)
        Me.Controls.Add(Me.SAVE_BTN)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.UserPass_txt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.UserID_txt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Name = "LOGON_FRM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LOGIN SCREEN  Ver 2.1.3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EXIT_BTN As System.Windows.Forms.Button
    Friend WithEvents SAVE_BTN As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents UserPass_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents UserID_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
