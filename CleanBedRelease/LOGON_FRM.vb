Public Class LOGON_FRM

    Private Sub SAVE_BTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVE_BTN.Click
        Entr_module()
    End Sub
    Private Sub EXIT_BTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXIT_BTN.Click
        End
    End Sub
    Public Function DecryptNew(ByVal StringToDecrypt As String) As String

Remarks:
        '   The following function takes the parameter 'StringToDecrypt' and performs
        '   multiple mathematical transformations on it.  Every step has been
        '   documented through remarks to cut down on confusion of the process
        '   itself.  Upon any error, the error is ignored and execution of the
        '   function continues.  Unlike the 'Encrypt' function, this function has
        '   proved itself to be virtually limitless in comparison.  For instance, on
        '   a 200 Mhz, with 128 MB RAM and Win98 SE, an uncompiled version of this
        '   function averaged the following times (over a period of ten trials):
        '
        '               1000 characters  (1K)    -   10000 characters per second
        '               3000 characters  (3K)    -   30000 characters per second
        '               5000 characters  (5K)    -   25000 characters per second
        '               8000 characters  (8K)    -   13333 characters per second
        '              10000 characters (10K)    -   25000 characters per second
        '              20000 characters (20K)    -   28571 characters per second
        '              30000 characters (30K)    -   20000 characters per second
        '
        '   In fact, after 120 trials that ranged from 1K to 30K, the function
        '   averaged 24769 characters per second.  There must be a size constraint,
        '   based on memory and processor, but it has not been found yet.

OnError:
        On Error GoTo ERRHANDLER

Dimensions:
        Dim intMousePointer As Cursor
        Dim dblCountLength As Double
        Dim intLengthChar As Integer
        Dim strCurrentChar As String
        Dim dblCurrentChar As Double
        Dim intCountChar As Integer
        Dim intRandomSeed As Integer
        Dim intBeforeMulti As Integer
        Dim intAfterMulti As Integer
        Dim intSubNinetyNine As Integer
        Dim intInverseAsc As Integer

Constants:
        '   [None]

MainCode:
        '   Store the current value of the mouse pointer
        ''intMousePointer = TextBox1.Cursor 'System.Windows.Forms.Cursors.WaitCursor
        'TextBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '   Change the mousepointer to an hourglass.
        'Screen.MousePointer = vbHourglass
        ''TextBox1.Cursor = New System.Windows.Forms.Cursor("C:\mypath\mycursor.cur")

        '   Start a For...Next loop that counts through the length of the parameter
        '   'StringToDecrypt'
        For dblCountLength = 1 To Len(StringToDecrypt)
            '   Place the character at 'dblCountLength' into the variable
            '   'intLengthChar'
            intLengthChar = Mid(StringToDecrypt, dblCountLength, 1)
            '   Place the string 'intLengthChar' long, directly following
            '   'dblCountLength' into the variable 'strCurrentChar'
            strCurrentChar = Mid(StringToDecrypt, dblCountLength + 1, _
                intLengthChar)
            '   Let the variable 'dblCurrentChar' be equal to 0
            dblCurrentChar = 0
            '   Start a For...Next loop that counts through the length of the
            '   variable 'strCurrentChar'
            For intCountChar = 1 To Len(strCurrentChar)
                '   Convert the variable 'strCurrent' from base 98 to base 10 and
                '   place the value into the variable 'dblCurrentChar'
                ''mazen
                dblCurrentChar = dblCurrentChar + (Asc(Mid(strCurrentChar, _
                    intCountChar, 1)) - 33) * (93 ^ (Len(strCurrentChar) - _
                    intCountChar))


                '   Go to the next character in the variable 'strCurrentChar'
            Next intCountChar
            '   Determine the random number that was used in the 'Encrypt' function
            intRandomSeed = Mid(dblCurrentChar, 3, 2)
            '   Determine the number that represents the character without the random
            '   seed
            intBeforeMulti = Mid(dblCurrentChar, 1, 2) & Mid(dblCurrentChar, 5, _
                2)
            '   Divide the number that represents the character by the random seed
            '   and place that value into the variable 'intAfterMulti'
            intAfterMulti = intBeforeMulti / intRandomSeed
            '   Subtract 99 from the variable 'intAfterMulti' and place that value
            '   into the variable 'intSubNinetyNine'
            intSubNinetyNine = intAfterMulti - 99
            '   Subtract the variable 'intSubNinetyNine' from 256 and place that
            '   value into the variable 'intInverseAsc'
            intInverseAsc = 256 - intSubNinetyNine
            '   Place the character equivalent of the variable 'intInverseAsc' at the
            '   end of the function 'Decrypt'
            DecryptNew = DecryptNew & Chr(intInverseAsc)
            '   Add the variable 'intLengthChar' to 'dblCountLength' to ensure that
            '   the next character is being analyzed
            dblCountLength = dblCountLength + intLengthChar
            '   Go to the next character in the variable 'StringToEncrypt'
        Next dblCountLength
        '   Return the mousepointer to the value that it was before the function
        '   started
        'Screen.MousePointer = intMousePointer
        ''TextBox1.Cursor = intMousePointer
        Exit Function

ERRHANDLER:
        '   Begin selecting occurences of an error number when an error has occured
        Select Case Err.Number
            '   For all occurences of an error number, do what follows
            Case Else
                '   Erase the error
                Err.Clear()
                '   Go to the line of code that follows the error
                Resume Next
                '   Stop selecting occurences of an error number
        End Select
    End Function
    Private Sub UserPass_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UserPass_txt.KeyPress
        If e.KeyChar = Chr(13) Then
            Entr_module()
            'test only 
        End If
    End Sub
    Public Sub Entr_module()

        Dim D As SqlClient.SqlDataReader
        Dim stat As String = _
 "select b.categoryid,b.employeeid,a.password " & _
 " from bedclearanceadmin b left join employee a on a.employeeid=convert(varchar(50),b.employeeid) " & _
 "  where b.employeeid=" & UserID_txt.Text.Trim


        D = STANDRED_MODULE.SQLREADER(stat)
        Try
            If D.HasRows = True Then
                With Container_FRM
                    Do While D.Read

                        STANDRED_MODULE.DepTIDGlob = D.GetValue(0)
                        'UserID_txt.Text = DecryptNew(D.GetString(2)) 'For Test 


                        If DecryptNew(D.GetString(2)) <> UserPass_txt.Text.Trim Then GoTo Repate

                    Loop
                    Dim lod As New Container_FRM
                    lod.Show()
                    Me.Hide()
                    STANDRED_MODULE.UserIDGlob = UserID_txt.Text.Trim
                End With
            Else
repate:
                UserID_txt.Focus()
                MsgBox("Wrong Entry!", MsgBoxStyle.Critical)

            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LOGON_FRM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = GlobalVerision
    End Sub
End Class