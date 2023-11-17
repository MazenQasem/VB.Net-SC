Public Class Container_FRM

    Private Sub BedClearanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BedClearanceToolStripMenuItem.Click
        Dim n As New Approved_frm
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub EXITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXITToolStripMenuItem.Click
        End
    End Sub

    Private Sub AdministrationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministrationsToolStripMenuItem.Click
        Dim n As New Admin_Frm
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub Container_FRM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub Container_FRM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AdministrationsToolStripMenuItem.Enabled = False
        Me.RegistrationForRoomToolStripMenuItem.Enabled = False
        Me.BedClearanceToolStripMenuItem.Enabled = False

        
        Select Case STANDRED_MODULE.DepTIDGlob
            Case 5
                Me.AdministrationsToolStripMenuItem.Enabled = True
                Me.RegistrationForRoomToolStripMenuItem.Enabled = True
                Me.BedClearanceToolStripMenuItem.Enabled = True
            Case 4
                Me.RegistrationForRoomToolStripMenuItem.Enabled = True

            Case 1  'house keeping
                Me.BedClearanceToolStripMenuItem.Enabled = True
                Me.RegistrationForRoomToolStripMenuItem.Enabled = True
            Case 3  'MNT
                Me.BedClearanceToolStripMenuItem.Enabled = True
                Me.RegistrationForRoomToolStripMenuItem.Enabled = True
            Case 6
                Me.RegistrationForRoomToolStripMenuItem.Enabled = True
        End Select
    End Sub
    Private Sub OtherRoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherRoomToolStripMenuItem.Click
        Dim n As New FlagBed_Frm
        STANDRED_MODULE.RoomType = 2
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub VacantsRoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VacantsRoomToolStripMenuItem.Click
        Dim n As New FlagBed_Frm
        STANDRED_MODULE.RoomType = 1
        n.MdiParent = Me
        n.Show()
    End Sub

   
End Class