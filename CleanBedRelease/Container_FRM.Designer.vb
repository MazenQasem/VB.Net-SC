<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Container_FRM
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EXITToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BedClearanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RegistrationForRoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OtherRoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VacantsRoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AdministrationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ModulesToolStripMenuItem, Me.AdministrationsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(881, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXITToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EXITToolStripMenuItem
        '
        Me.EXITToolStripMenuItem.Name = "EXITToolStripMenuItem"
        Me.EXITToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.EXITToolStripMenuItem.Text = "EXIT"
        '
        'ModulesToolStripMenuItem
        '
        Me.ModulesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BedClearanceToolStripMenuItem, Me.RegistrationForRoomToolStripMenuItem})
        Me.ModulesToolStripMenuItem.Name = "ModulesToolStripMenuItem"
        Me.ModulesToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ModulesToolStripMenuItem.Text = "Modules"
        '
        'BedClearanceToolStripMenuItem
        '
        Me.BedClearanceToolStripMenuItem.Enabled = False
        Me.BedClearanceToolStripMenuItem.Name = "BedClearanceToolStripMenuItem"
        Me.BedClearanceToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.BedClearanceToolStripMenuItem.Text = "Bed Clearance Approval"
        '
        'RegistrationForRoomToolStripMenuItem
        '
        Me.RegistrationForRoomToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OtherRoomToolStripMenuItem, Me.VacantsRoomToolStripMenuItem})
        Me.RegistrationForRoomToolStripMenuItem.Name = "RegistrationForRoomToolStripMenuItem"
        Me.RegistrationForRoomToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.RegistrationForRoomToolStripMenuItem.Text = "Registration of Room for Cleaning"
        '
        'OtherRoomToolStripMenuItem
        '
        Me.OtherRoomToolStripMenuItem.Name = "OtherRoomToolStripMenuItem"
        Me.OtherRoomToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.OtherRoomToolStripMenuItem.Text = "Occupied/For Cleaning Rooms"
        '
        'VacantsRoomToolStripMenuItem
        '
        Me.VacantsRoomToolStripMenuItem.Enabled = False
        Me.VacantsRoomToolStripMenuItem.Name = "VacantsRoomToolStripMenuItem"
        Me.VacantsRoomToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.VacantsRoomToolStripMenuItem.Text = "Vacant Rooms"
        '
        'AdministrationsToolStripMenuItem
        '
        Me.AdministrationsToolStripMenuItem.Name = "AdministrationsToolStripMenuItem"
        Me.AdministrationsToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.AdministrationsToolStripMenuItem.Text = "Administrations"
        '
        'Container_FRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 547)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Container_FRM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "--> Bed Clearance System <--   Saudi German Hospitals Group -Jeddah"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EXITToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BedClearanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministrationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrationForRoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtherRoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VacantsRoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
