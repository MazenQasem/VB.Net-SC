Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns
Imports System.Data.Odbc
'Imports ADODB 'MUST ADD IN REFRENCE
Imports System.Web
'Imports System.IO
'Imports System.Text
'Imports Microsoft.VisualBasic.DateAndTime
Imports System.Drawing
Imports System.Collections
Imports System.Globalization
Imports System.Threading

Module STANDRED_MODULE
    Public DepTIDGlob As String 'for the DeptID 
    Public UserIDGlob As String 'for the UserID 
    Public RoomType As Integer ' 1=Vacant 2=Others type
    Public UserAllowedDelete As Integer 'For THe option if the user's can delete or not
    Public GlobalVerision As String = "Ver 2.1.3"
    Public MainConn As SqlConnection = New SqlConnection(Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString1"))
    Public TRANSConn As SqlClient.SqlTransaction

    Public oConn As SqlConnection
    Public oLEConn As OleDb.OleDbConnection
    Public oDBCConn As Odbc.OdbcConnection
    Dim LETTER_ARR(9, 4)     ' for the letter of the number -ARABIC
    Dim ARR(20, 3) As String   'FOR THE LETTER OF THE NUMBER -ENGLISH
    '=================================================================
    '==========================DATA FUNCTION =========================
    '=================================================================

    'connecation'
    Public Function odbccon() As String
        Dim sConnString As String = (Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString4"))
        Return sConnString
    End Function
    'SQL DATA ADPTER
    '===============
    Function SQLADPTER(ByVal STRSQL As String) As SqlClient.SqlDataAdapter
        Dim oCmd As New SqlClient.SqlCommand
        Dim oConn As SqlClient.SqlConnection
        Dim sConnString As String = (Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString1"))
        oConn = New SqlClient.SqlConnection(sConnString)
        oCmd = New SqlClient.SqlCommand(STRSQL, oConn)
        oCmd.CommandType = CommandType.Text
        oCmd.CommandTimeout = 400
        Try
            If oConn.State = ConnectionState.Closed Then
                oConn.Open()
            End If
            oCmd.ExecuteReader(CommandBehavior.CloseConnection)
            oCmd.Dispose()
            oConn.Dispose()
        Catch oErr As Exception
            Throw oErr
        End Try
    End Function
    ' OLE DATA ADPTER 
    '=================
    Function OLEADPTER(ByVal STRSQL As String) As OleDb.OleDbDataAdapter
        Dim oCmd As New OleDb.OleDbCommand
        Dim oLEConn As OleDb.OleDbConnection
        Dim sConnString As String = (Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString3"))
        oLEConn = New OleDb.OleDbConnection(sConnString)
        oCmd = New OleDb.OleDbCommand(STRSQL, oLEConn)
        oCmd.CommandType = CommandType.Text
        oCmd.CommandTimeout = 400
        Try
            If oLEConn.State = ConnectionState.Closed Then
                oLEConn.Open()
            End If
            oCmd.ExecuteReader(CommandBehavior.CloseConnection)
            oCmd.Dispose()
            oLEConn.Dispose()
        Catch oErr As Exception
            Throw oErr
        End Try
    End Function
    ' ODBC DATA ADPTER
    '=================
    Function ODBCADPTER(ByVal STRSQL As String) As Odbc.OdbcDataAdapter
        Dim oCmd As New Odbc.OdbcCommand
        Dim oDBCConn As Odbc.OdbcConnection
        Dim sConnString As String = (Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString4"))
        oDBCConn = New Odbc.OdbcConnection(sConnString)
        oCmd = New Odbc.OdbcCommand(STRSQL, oDBCConn)
        oCmd.CommandType = CommandType.Text
        oCmd.CommandTimeout = 400
        Try
            If oDBCConn.State = ConnectionState.Closed Then
                oDBCConn.Open()
            End If
            oCmd.ExecuteReader(CommandBehavior.CloseConnection)
            oCmd.Dispose()
            oDBCConn.Dispose()
        Catch oErr As Exception
            Throw oErr
        End Try
    End Function
    'OLE READER
    '==============
    Function OLEREADER(ByVal strsql As String) As OleDbDataReader
        Dim oCmd As New OleDbCommand
        Dim oLEConn As OleDbConnection
        Dim sConnString As String = (Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString3"))
        oLEConn = New OleDbConnection(sConnString)
        oCmd = New OleDbCommand(strsql, oLEConn)
        oCmd.CommandType = CommandType.Text
        oCmd.CommandTimeout = 400
        Try
            If oLEConn.State = ConnectionState.Closed Then
                oLEConn.Open()
            End If
            Return oCmd.ExecuteReader(CommandBehavior.CloseConnection)
            oCmd.Dispose()
            oLEConn.Dispose()
        Catch oErr As Exception
            Throw oErr
        End Try
    End Function
    'SQL READER
    '============
    Function SQLREADER(ByVal strsql As String) As SqlDataReader
        Dim oCmd As SqlCommand
        Dim oConn As SqlConnection
        oConn = New SqlConnection(Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString1"))
        oCmd = New SqlCommand(strsql, oConn)

        oCmd.CommandType = CommandType.Text
        oCmd.CommandTimeout = 400
        Try
            If oConn.State = ConnectionState.Closed Then
                oConn.Open()
            End If
            SQLREADER = oCmd.ExecuteReader
            Return SQLREADER
            oCmd.Dispose()
            oConn.Dispose()
        Catch oErr As Exception
            MsgBox(oErr.Message)
            Throw oErr
        End Try
    End Function
    'for sms sending
    Function SQLREADER_SMS(ByVal strsql As String) As SqlDataReader
        Dim oCmd As SqlCommand
        Dim oConn As SqlConnection
        oConn = New SqlConnection(Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString6"))
        oCmd = New SqlCommand(strsql, oConn)

        oCmd.CommandType = CommandType.Text
        oCmd.CommandTimeout = 400
        Try
            If oConn.State = ConnectionState.Closed Then
                oConn.Open()
            End If
            SQLREADER_SMS = oCmd.ExecuteReader
            Return SQLREADER_SMS
            oCmd.Dispose()
            oConn.Dispose()
        Catch oErr As Exception
            MsgBox(oErr.Message)
            Throw oErr
        End Try
    End Function
    'ODBC READER
    '===========
    Function ODBCREADER(ByVal strsql As String) As System.Data.Odbc.OdbcDataReader
        Dim oCmd As System.Data.Odbc.OdbcCommand
        Dim oDBCConn As Odbc.OdbcConnection
        Dim sConnString As String = (Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString4"))
        oDBCConn = New Odbc.OdbcConnection(sConnString)
        oCmd = New Odbc.OdbcCommand(strsql, oDBCConn)
        oCmd.CommandType = CommandType.Text
        oCmd.CommandTimeout = 400
        Try
            If oDBCConn.State = ConnectionState.Closed Then
                oDBCConn.Open()
            End If
            Return oCmd.ExecuteReader(CommandBehavior.CloseConnection)

            oCmd.Dispose()
            oLEConn.Dispose()
        Catch oErr As Exception
            Throw oErr
            MsgBox(oErr.Message)
        End Try
    End Function
    'OLE DATASET
    '============
    Function OLEDATASET(ByVal strsql As String, ByVal tblname As String) As DataSet
        Dim oCmd As OleDbCommand
        Dim oLEConn As OleDbConnection
        Dim oAdapter As OleDbDataAdapter
        Dim dsRet As New DataSet
        oLEConn = New OleDbConnection(Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString3"))
        Try
            If oLEConn.State = ConnectionState.Closed Then
                oLEConn.Open()
                oCmd = oLEConn.CreateCommand()
                oCmd.CommandText = strsql
                oAdapter = New OleDbDataAdapter
                oAdapter.SelectCommand = oCmd
                oAdapter.Fill(dsRet, tblname)
                Return dsRet
            End If
            Return dsRet
            oCmd.Dispose()
            oLEConn.Dispose()
            oAdapter.Dispose()
            dsRet.Dispose()
        Catch oErr As Exception
            'Throw oErr
            Throw New Exception(oErr.ToString)
        End Try
    End Function
    'SQL DATASET
    '===========
    Function SQLDATASET(ByVal strsql As String, ByVal tblname As String) As DataSet
        Dim oCmd As SqlCommand
        Dim oConn As SqlConnection
        Dim oAdapter As SqlDataAdapter
        Dim dsRet As New DataSet

        oConn = New SqlConnection(Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString1"))
        'oCmd.CommandTimeout = 500
        Try
            If oConn.State = ConnectionState.Closed Then
                oConn.Open()
                oCmd = oConn.CreateCommand()
                oCmd.CommandText = strsql
                oAdapter = New SqlDataAdapter
                oAdapter.SelectCommand = oCmd
                oAdapter.Fill(dsRet, tblname)
                Return dsRet
            End If
            Return dsRet
            oCmd.Dispose()
            oConn.Dispose()
            oAdapter.Dispose()
            dsRet.Dispose()
        Catch oErr As Exception
            'Throw oErr
            Throw New Exception(oErr.ToString)
        End Try
    End Function
    Function SQLDATASET2(ByVal strsql As String, ByVal tblname As String) As DataSet
        Dim oCmd As SqlCommand
        Dim oConn As SqlConnection
        Dim oAdapter As SqlDataAdapter
        Dim dsRet As New DataSet

        oConn = New SqlConnection(Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString5"))
        'oCmd.CommandTimeout = 500
        Try
            If oConn.State = ConnectionState.Closed Then
                oConn.Open()
                oCmd = oConn.CreateCommand()
                oCmd.CommandText = strsql
                oAdapter = New SqlDataAdapter
                oAdapter.SelectCommand = oCmd
                oAdapter.Fill(dsRet, tblname)
                Return dsRet
            End If
            Return dsRet
            oCmd.Dispose()
            oConn.Dispose()
            oAdapter.Dispose()
            dsRet.Dispose()
        Catch oErr As Exception
            'Throw oErr
            Throw New Exception(oErr.ToString)
        End Try
    End Function
    'ODBC DATASET
    '============
    Function ODBCDATASET(ByVal strsql As String, ByVal tblname As String) As System.Data.DataSet
        Try
            Dim oCmd As Odbc.OdbcCommand
            Dim oDBCConn As Odbc.OdbcConnection
            Dim oDBCAdapter As Odbc.OdbcDataAdapter
            Dim dsRet As New DataSet
            oDBCConn = New OdbcConnection(Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString4"))
            'oCmd.CommandTimeout = 500
            dsRet.Clear()
            If oDBCConn.State = ConnectionState.Closed Then
                oDBCConn.Open()
                oCmd = oDBCConn.CreateCommand()
                oCmd.CommandText = strsql
                oDBCAdapter = New Odbc.OdbcDataAdapter
                oDBCAdapter.SelectCommand = oCmd
                oDBCAdapter.Fill(dsRet, tblname)

                Return dsRet
            End If
            Return dsRet
            oCmd.Dispose()
            oDBCConn.Dispose()
            oDBCAdapter.Dispose()
            dsRet.Dispose()
        Catch oErr As Exception
            'Throw oErr
            Throw New Exception(oErr.ToString)
        End Try
    End Function
    'OLE COMMAND -EXECUTENONQUERY
    '=============================
    Function OLEExecute(ByVal strsql2 As String) As Boolean
        Dim oCmd As OleDbCommand
        Dim oLEConn As OleDbConnection
        oLEConn = New OleDbConnection(Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString3"))
        oCmd = New OleDbCommand(strsql2, oLEConn)
        oCmd.CommandType = CommandType.Text
        oCmd.CommandTimeout = 400
        Try
            If oLEConn.State = ConnectionState.Closed Then
                oLEConn.Open()
            End If
            oCmd.ExecuteNonQuery()
            Return True
        Catch oErr As Exception
            Throw New Exception(oErr.ToString)
            Return False
        End Try
    End Function
    'SQL COMMAND -EXECUTENONQUERY
    '=============================
    Function SQLExecute2(ByVal strsql2 As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
        Dim oCmd As SqlCommand
        'Dim oConn As SqlConnection
        'oConn = New SqlConnection(Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString1"))
        oCmd = New SqlCommand(strsql2, conn)
        oCmd.Transaction = Trans
        oCmd.CommandType = CommandType.Text
        oCmd.CommandTimeout = 400
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            'oCmd.Transaction = oConn.BeginTransaction
            oCmd.ExecuteNonQuery()
            Return True
        Catch oErr As Exception
            Throw New Exception(oErr.ToString)
            Return False
        End Try
    End Function
    Function SQLExecute(ByVal strsql2 As String) As Boolean
        Dim oCmd As SqlCommand
        Dim oConn As SqlConnection
        oConn = New SqlConnection(Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString1"))
        oCmd = New SqlCommand(strsql2, oConn)
        oCmd.CommandType = CommandType.Text
        oCmd.CommandTimeout = 400
        Try
            If oConn.State = ConnectionState.Closed Then
                oConn.Open()
            End If
            oCmd.ExecuteNonQuery()
            Return True
        Catch oErr As Exception
            Throw New Exception(oErr.ToString)
            Return False
        End Try
    End Function
    Function SQLExecute_SMS(ByVal strsql2 As String) As Boolean
        Dim oCmd As SqlCommand
        Dim oConn As SqlConnection
        oConn = New SqlConnection(Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString6"))
        oCmd = New SqlCommand(strsql2, oConn)
        oCmd.CommandType = CommandType.Text
        oCmd.CommandTimeout = 400
        Try
            If oConn.State = ConnectionState.Closed Then
                oConn.Open()
            End If
            oCmd.ExecuteNonQuery()
            Return True
        Catch oErr As Exception
            Throw New Exception(oErr.ToString)
            Return False
        End Try
    End Function
    'ODBC EXECUTE COMMAND
    '=======================
    Function ODBCExecute(ByVal strsql2 As String) As Boolean
        Dim oCmd As New Odbc.OdbcCommand
        Dim oDBCConn As Odbc.OdbcConnection
        oDBCConn = New Odbc.OdbcConnection(Global.System.Configuration.ConfigurationManager.AppSettings("ConnectionString4"))
        oCmd = New Odbc.OdbcCommand(strsql2, oDBCConn)
        oCmd.CommandType = CommandType.Text
        oCmd.CommandTimeout = 400
        Try
            If oDBCConn.State = ConnectionState.Closed Then
                oDBCConn.Open()
            End If
            oCmd.ExecuteNonQuery()
            Return True
        Catch oErr As Exception
            Throw New Exception(oErr.ToString)
            Return False
        End Try
    End Function
    '=================================================================
    '=====================FORMATING FUNCTION =========================
    '=================================================================

    ''1]String AND NUMBER Functions

    Function putSGLQ(ByVal StrData As String)
        If StrData <> "" Then
            Return "'" + Replace(StrData, "'", "''") + "'"
        ElseIf StrData = "''" Then
            Return StrData
        Else
            Return "NULL"
        End If
    End Function
    Function NullToBoolean(ByVal vVar As Object, Optional ByVal bDefault As Boolean = False) As Boolean
        'Purpose:
        '   Convert null string to Boolean
        'Input:
        '   vVar    - Input variable
        'Output:
        '   Function returns 0 if vVar is null else value
        Try
            If IsDBNull(vVar) Or vVar = "" Then
                NullToBoolean = bDefault
            Else
                NullToBoolean = CBool(vVar)
            End If
        Catch
            NullToBoolean = False
        End Try
    End Function
    Function NullToCurrency(ByVal vVar As Object) As Decimal
        'Purpose:
        '   Convert null string to currency
        'Input:
        '   vVar    - Input variable
        'Output:
        '   Function returns 0 if vVar is null else value
        If IsDBNull(vVar) Then
            NullToCurrency = 0
        Else
            NullToCurrency = CDec(vVar)
        End If
    End Function
    Function NullToDateFormat(ByVal vVar As Object, Optional ByVal sFormat As String = "dd/MMM/yyyy HH:mm") As String
        'Purpose:
        '   Convert null string to currency
        'Input:
        '   vVar    - Input variable
        '   sFormat -
        'Output:
        '   Function returns 0 if vVar is null else value
        If IsDBNull(vVar) Then
            NullToDateFormat = ""
        Else
            NullToDateFormat = Format$(CDate(vVar), sFormat)
        End If
    End Function
    Function CINTPlus(ByVal vVar As Object) As Integer
        'Purpose:
        '   Convert null string to Integer
        'Input:
        '   vVar    - Input variable
        'Output:
        '   Function returns 0 if vVar is null else value
        If IsDBNull(vVar) Then
            CINTPlus = 0
        Else
            CINTPlus = CInt(vVar)
        End If
    End Function
    Function NullToString(ByVal vVar As Object) As String
        'Purpose:
        '   Convert null string to string
        'Input:
        '   vVar    - Input variable
        'Output:
        '   Function returns "" if vVar is null else value
        If IsDBNull(vVar) Then
            NullToString = ""
        Else
            NullToString = CStr(vVar)
        End If
    End Function
    Function NullToNum(ByVal vVar As Object) As Integer
        'Purpose:
        '   Convert null string to string
        'Input:
        '   vVar    - Input variable
        'Output:
        '   Function returns "" if vVar is null else value
        If IsDBNull(vVar) Then
            NullToNum = 0
        Else
            NullToNum = CStr(vVar)
        End If
    End Function
    Function CDBLPlus(ByVal vVar As Object, ByVal dNum As Double) As Double
        'Purpose:
        '   Convert null string to string
        'Input:
        '   vVar    - Input variable
        'Output:
        '   Function returns "" if vVar is null else value
        If IsDBNull(vVar) Then
            CDBLPlus = dNum
        Else
            CDBLPlus = CDbl(vVar)
        End If
    End Function
    Function CDBLPlus(ByVal vVar As Object) As Double
        'Purpose:
        '   Convert null string to string
        'Input:
        '   vVar    - Input variable
        'Output:
        '   Function returns "" if vVar is null else value
        If IsDBNull(vVar) Then
            CDBLPlus = 0
        Else
            CDBLPlus = CDbl(vVar)
        End If
    End Function
    Function fixempid(ByVal strdata As String)

        If strdata <> "" Then
            Return Replace(strdata, "-", "")
        ElseIf strdata = "" Then
            Return strdata
        Else
            Return "NULL"
        End If


    End Function
    Function fixPIN(ByVal strPIN As String) As String

        Dim startPIN, midPIN, endPIN As String

        startPIN = Mid(strPIN, 1, 3)
        endPIN = Right(strPIN, 2)
        midPIN = Mid(strPIN, 4, InStr(4, strPIN, "-") - 4)

        fixPIN = startPIN & Format(CDBLPlus(midPIN), "00000000") & endPIN

    End Function
    '2] DATE FUNCTION
    Function StrtoDate(ByVal strDate As String) As String
        StrtoDate = Mid(Trim(strDate), 5, 2) & "/" & Mid(Trim(strDate), 7, 2) & "/" & Mid(Trim(strDate), 1, 4)
    End Function
    Function FormatDatePlus(ByVal p_Value, ByVal p_DateFormat)
        Dim t_date As Date
        Dim t_day, t_month, t_year As String
        t_date = p_Value

        t_day = Trim(Day(t_date))
        If Len(t_day) = 1 Then
            t_day = "0" & t_day
        End If

        t_month = Trim(Month(t_date))
        If Len(t_month) = 1 Then
            t_month = "0" & t_month
        End If

        t_year = Trim(Year(t_date))

        Select Case UCase(Trim(p_DateFormat))
            Case "DDMMYYYY"
                FormatDatePlus = t_day & t_month & t_year
            Case "DDYYYYMM"
                FormatDatePlus = t_day & t_year & t_month
            Case "MMDDYYYY"
                FormatDatePlus = t_month & t_day & t_year
            Case "MMYYYYDD"
                FormatDatePlus = t_month & t_year & t_day
            Case "YYYYMMDD"
                FormatDatePlus = t_year & t_month & t_day
            Case "YYYYDDMM"
                FormatDatePlus = t_year & t_day & t_month

            Case "DD-MM-YYYY"
                FormatDatePlus = t_day & "-" & t_month & "-" & t_year
            Case "DD-YYYY-MM"
                FormatDatePlus = t_day & "-" & t_year & "-" & t_month
            Case "MM-DD-YYYY"
                FormatDatePlus = t_month & "-" & t_day & "-" & t_year
            Case "MM-YYYY-DD"
                FormatDatePlus = t_month & "-" & t_year & "-" & t_day
            Case "YYYY-MM-DD"
                FormatDatePlus = t_year & "-" & t_month & "-" & t_day
            Case "YYYY-DD-MM"
                FormatDatePlus = t_year & "-" & t_day & "-" & t_month

            Case "DD/MM/YYYY"
                FormatDatePlus = t_day & "/" & t_month & "/" & t_year
            Case "DD/YYYY/MM"
                FormatDatePlus = t_day & "/" & t_year & "/" & t_month
            Case "MM/DD/YYYY"
                FormatDatePlus = t_month & "/" & t_day & "/" & t_year
            Case "MM/YYYY/DD"
                FormatDatePlus = t_month & "/" & t_year & "/" & t_day
            Case "YYYY/MM/DD"
                FormatDatePlus = t_year & "/" & t_month & "/" & t_day
            Case "YYYY/DD/MM"
                FormatDatePlus = t_year & "/" & t_day & "/" & t_month

            Case "DD_MM_YYYY"
                FormatDatePlus = t_day & " " & t_month & " " & t_year
            Case "DD_YYYY_MM"
                FormatDatePlus = t_day & " " & t_year & " " & t_month
            Case "MM_DD_YYYY"
                FormatDatePlus = t_month & " " & t_day & " " & t_year
            Case "MM_YYYY_DD"
                FormatDatePlus = t_month & " " & t_year & " " & t_day
            Case "YYYY_MM_DD"
                FormatDatePlus = t_year & " " & t_month & " " & t_day
            Case "YYYY_DD_MM"
                FormatDatePlus = t_year & " " & t_day & " " & t_month

            Case "DD_MMM_YYYY"
                FormatDatePlus = t_day & "-" & MonthName(t_month, True) & "-" & t_year
            Case "DD_YYYY_MMM"
                FormatDatePlus = t_day & " " & t_year & " " & MonthName(t_month, True)
            Case "MMM_DD_YYYY"
                FormatDatePlus = MonthName(t_month, True) & " " & t_day & " " & t_year
            Case "MMM_YYYY_DD"
                FormatDatePlus = MonthName(t_month, True) & " " & t_year & " " & t_day
            Case "YYYY_MMM_DD"
                FormatDatePlus = t_year & " " & MonthName(t_month, True) & " " & t_day
            Case "YYYY_DD_MMM"
                FormatDatePlus = t_year & " " & t_day & " " & MonthName(t_month, True)

            Case "DD_MMMM_YYYY"
                FormatDatePlus = t_day & " " & MonthName(t_month, False) & " " & t_year
            Case "DD_YYYY_MMMM"
                FormatDatePlus = t_day & " " & t_year & " " & MonthName(t_month, False)
            Case "MMMM_DD_YYYY"
                FormatDatePlus = MonthName(t_month, False) & " " & t_day & " " & t_year
            Case "MMMM_YYYY_DD"
                FormatDatePlus = MonthName(t_month, False) & " " & t_year & " " & t_day
            Case "YYYY_MMMM_DD"
                FormatDatePlus = t_year & " " & MonthName(t_month, False) & " " & t_day
            Case "YYYY_DD_MMMM"
                FormatDatePlus = t_year & " " & t_day & " " & MonthName(t_month, False)

            Case Else
                FormatDatePlus = t_date
        End Select
    End Function
    Public Function GregorianToHijri(ByVal DATEX As DateTime) As DateTime
        Try
            Dim YEAR, MONTH, DAY As String
            YEAR = DATEX.Year
            MONTH = DATEX.Month
            DAY = DATEX.Day

            Dim Ar As CultureInfo = New CultureInfo("ar-SY")
            Thread.CurrentThread.CurrentCulture = Ar
            Ar.DateTimeFormat.Calendar = New GregorianCalendar
            GregorianToHijri = New DateTime(YEAR, MONTH, DAY, Ar.DateTimeFormat.Calendar)
            Ar.DateTimeFormat.Calendar = New HijriCalendar

        Catch ex As Exception
            ex = Nothing
        End Try
    End Function
    Public Function GregorianToHijri(ByVal Year As Integer, _
        ByVal Month As Integer, ByVal Day As Integer) As DateTime
        Try
            Dim Ar As CultureInfo = New CultureInfo("ar-SY")
            Thread.CurrentThread.CurrentCulture = Ar
            Ar.DateTimeFormat.Calendar = New GregorianCalendar
            GregorianToHijri = New DateTime(Year, Month, Day, Ar.DateTimeFormat.Calendar)
            Ar.DateTimeFormat.Calendar = New HijriCalendar
        Catch ex As Exception
            ex = Nothing
        End Try
    End Function
    Public Function HijriToGregorian(ByVal DATEX As DateTime) As DateTime
        Try
            Dim YEAR, MONTH, DAY As String
            YEAR = DATEX.Year
            MONTH = DATEX.Month
            DAY = DATEX.Day
            Dim Ar As CultureInfo = New CultureInfo("ar-SY")
            Thread.CurrentThread.CurrentCulture = Ar
            Ar.DateTimeFormat.Calendar = New HijriCalendar
            HijriToGregorian = New DateTime(YEAR, MONTH, DAY, Ar.DateTimeFormat.Calendar)
            Ar.DateTimeFormat.Calendar = New GregorianCalendar
        Catch ex As Exception
            ex = Nothing
        End Try
    End Function
    Public Function HijriToGregorian(ByVal Year As Integer, _
        ByVal Month As Integer, ByVal Day As Integer) As DateTime
        Try
            Dim Ar As CultureInfo = New CultureInfo("ar-SY")
            Thread.CurrentThread.CurrentCulture = Ar
            Ar.DateTimeFormat.Calendar = New HijriCalendar
            HijriToGregorian = New DateTime(Year, Month, Day, Ar.DateTimeFormat.Calendar)
            Ar.DateTimeFormat.Calendar = New GregorianCalendar
        Catch ex As Exception
            ex = Nothing
        End Try
    End Function
    '3] OTHER
    Public Function App_Path() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory()
    End Function
    '======================================
    ' section of read the number
    '+#++#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+++#++
    ' THIS PROCDURE READ THE NUMBER FROM THE SYMPLOE "123"
    ' TO TRANSFATE TO LETTER AS " ONE TOW THREE "
    ' IN ARABIC LANGUGE.
    ' TO CALL THIS PROCESS GUST WRITE IN THE COMMAND EVENTS:
    ' DIM MYTEXT AS STRING
    ' SPLIT_TEXT MYTEXT
    '                  ****************************
    'NOTE: MUST WRITE THIS LINE IN : GENERAL DECLARATIONS
    ' DIM LETTER_ARR(9,4)
    '+#++#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+#+++#++

    '===========================================
    'FUNCTION TO SPLIT THE ORGINGAL DIGITAL TEXT
    ' ARABIC SECTION
    ' INTO 2 PART'S DPENDING ON "."
    ' BEGIN ------------------>
    '===========================================
    Public Function WRITE_AR(ByRef TXT As String) As String
        'THIS SEARCHING LOOP FOR THE TYPE OF NUMBER (132 OR 132.52)
        '=======================PART 1-1=========================================
        Dim TEXT_TYPE, IPOINT As Integer
        Dim I As Integer
        Dim ONE_CHAR, SOURCTEXT As String
        SOURCTEXT = TXT
        For I = 1 To Strings.Len(SOURCTEXT)
            ONE_CHAR = Strings.Mid(SOURCTEXT, I, 1)
            If ONE_CHAR = "." Or ONE_CHAR = "," Then
                TEXT_TYPE = 2
                IPOINT = I    'IPOINT MEAN "."
                GoTo STAGE2
            ElseIf ONE_CHAR <> "." Or ONE_CHAR <> "," Then
                TEXT_TYPE = 1   'IN CASE THERIS NO "."
            End If
        Next I

STAGE2:  ' THE SCAPE POINT FROM THE BRVIUSE LOOPING
        '=======================PART 1-2=========================================
        'DEVID THE NUMBER ITNO RYAL AND HALAL
        Dim RYAL, HAL As String
        Select Case TEXT_TYPE
            Case 1 : RYAL = Strings.Left(SOURCTEXT, Strings.Len(SOURCTEXT))
            Case 2 : RYAL = Strings.Left(SOURCTEXT, IPOINT - 1)
                HAL = Strings.Mid(SOURCTEXT, IPOINT + 1, Strings.Len(SOURCTEXT) - IPOINT)
        End Select

        '=======================PART 1-3=========================================
        'THE MEAN LOOPING (FIRST TIME FOR THE RYAL SECOND TIME FOR THE HALAH
        Dim TLOOP As Integer
        Dim SYNTEX As String
        For TLOOP = 1 To TEXT_TYPE
            If TLOOP = 1 Then SYNTEX = RYAL
            If TLOOP = 2 Then SYNTEX = HAL
            '==================PART 1-3-1==============================

            'DVIDE THE RYAL OR HAL STATMENT INTO 3 GROUP CONTAINE 3 DIGIT
            'FIRST LOADIT INTO ARR BY ONE FOR EACH ROW
            Dim TEMP_ARR(9) As String
            Dim LENTH, STRNO As Integer

            LENTH = Strings.Len(SYNTEX)

            For I = 0 To LENTH - 1
                STRNO = I + 1  ' INDEX OF THE TEMP ARRAY
                TEMP_ARR(LENTH - I) = Strings.Mid(SYNTEX, STRNO, 1) 'DESCINDING SORT
            Next I
            Dim A, J As Integer
            'SECOND CREATE THE GROUPS
            Dim C(3) As String
            A = 0
            For I = 1 To 3
                For J = 1 + A To 3 + A
                    C(I) = TEMP_ARR(J) + C(I)
                Next J
                A = 3 * I
            Next I
            '--------------------------------------------------------------------------
            '=======================PART 1-3-2=============================

            ' THOSE CONDITONS TO ORGNIZE THE " Ê "    AND EXCPTION WORD AS „·ÌÊ‰«‰°√·›Ì‰
            If C(1) <> "" And C(2) = "" And C(3) = "" Then 'ONLY ONE GROUP
                TRANSLATE_FUN(C(1))
                SOURCTEXT = C(1)
            ElseIf C(2) <> "" And C(3) = "" Then 'TOW GROUP ONLY
                TRANSLATE_FUN(C(1))
                TRANSLATE_FUN(C(2))
                If C(2) = " Ê«Õœ " Then
                    C(2) = " √·› "
                ElseIf C(2) = " «À‰Ì‰ " Then
                    C(2) = " √·›Ì‰ "
                Else : C(2) = C(2) + " √·› "
                End If
                If Trim(C(1)) <> "" Then SOURCTEXT = C(2) & " Ê " & C(1)
                If Trim(C(1)) = "" Then SOURCTEXT = C(2)
            ElseIf C(3) <> "" Then    'ALL THREE GROUP
                TRANSLATE_FUN(C(1))
                TRANSLATE_FUN(C(2))
                TRANSLATE_FUN(C(3))
                If C(2) = " Ê«Õœ " Then
                    C(2) = " √·› "
                ElseIf C(2) = " «À‰Ì‰ " Then
                    C(2) = " √·›Ì‰ "
                ElseIf Trim(C(2)) = "" Then
                    C(2) = ""
                Else : C(2) = C(2) + " √·› "
                End If
                If Trim(C(1)) <> "" Then C(2) = C(2) & " Ê " & C(1)
                If Trim(C(1)) = "" Then C(2) = C(2)
                If Trim(C(1)) <> "" And Trim(C(2)) = "" Then C(2) = C(1)
                If Trim(C(3)) = "Ê«Õœ" Then
                    C(3) = " „·ÌÊ‰ "
                ElseIf Trim(C(3)) = "«À‰Ì‰" Then
                    C(3) = " „·ÌÊ‰«‰ "
                Else : C(3) = C(3) + " „·ÌÊ‰ "
                End If
                If Trim(C(2)) <> "" Then SOURCTEXT = C(3) & " Ê " & C(2)
                If Trim(C(2)) = "" Then SOURCTEXT = C(3)
                'If Trim(C(1)) = "" And Trim(C(2)) <> "" Then SOURCTEXT = C(3) & " Ê " & C(2)
                'If Trim(C(1)) = "" And Trim(C(2)) = "" Then SOURCTEXT = C(3)
            End If
            '=======================PART 1-3-3=============================
            Dim DSOURCTEXT As String
            'ORGNIZE THE (R.S) OR HALLALH
            If TLOOP = 1 Then
                SOURCTEXT = SOURCTEXT + " —Ì«· ”⁄ÊœÌ "
                DSOURCTEXT = SOURCTEXT ' TO KEEP THE RYAL DATA TO USE IN HALALAH CASE
            End If
            If TLOOP = 2 Then SOURCTEXT = DSOURCTEXT + "  Ê " + SOURCTEXT + " Â··… ·« €Ì— "
            '=======================PART 1-3-4=============================
            Dim IX As Integer
            'CLEAR THE GROUP ARRAY & TEMP ARRAY
            For IX = 1 To 3
                C(IX) = ""
            Next IX
            For IX = 1 To 9
                TEMP_ARR(IX) = ""
            Next IX
        Next TLOOP 'NEXT T LOOP
        '===========================================
        ' END ------------------>
        '===========================================
        Return SOURCTEXT
    End Function
    '===========================================
    'THIS FUNCTION TO RADE THE DIGIT NUMBER AND
    ' WRITE IT AS LETTER
    '===========================================
    Private Sub TRANSLATE_FUN(ByRef GTXT As String)

        Dim LENTH, I, J As Integer
        Dim TT1, TT2, TT3, N1, N2, N3 As String

        LOAD_LETTER() 'TO LOAD THE LETTER FORM LETTER_ARR

        LENTH = Strings.Len(GTXT)
        '=======================PART 1=============================

        For I = 1 To LENTH
            For J = 1 To 9
                Select Case I
                    Case 1 To 1, 3
                        'FOR THE ONES
                        If I = 1 And LETTER_ARR(J, 1) = Strings.Right(GTXT, 1) Then
                            TT1 = LETTER_ARR(J, 2)
                            N1 = LETTER_ARR(J, 1)
                            'FOR HUNDREDS
                        ElseIf I = 3 And LETTER_ARR(J, 1) = Strings.Mid(GTXT, 1, 1) Then
                            TT3 = LETTER_ARR(J, 4)
                            N3 = LETTER_ARR(J, 1)

                        End If
                    Case 2
                        'FOR THOUSNDS
                        N2 = Strings.Right(GTXT, 2)
                        If Strings.Right(GTXT, 2) > 12 Then
                            If LETTER_ARR(J, 1) = Strings.Mid(Strings.Right(GTXT, 2), 1, 1) Then
                                TT2 = LETTER_ARR(J, 3)
                            End If
                            'EXCEPTIONS
                        ElseIf Strings.Right(GTXT, 2) = "10" Then
                            TT1 = ""
                            TT2 = "⁄‘—…"
                        ElseIf Strings.Right(GTXT, 2) = "11" Then
                            TT1 = ""
                            TT2 = "√ÕœÏ ⁄‘—"
                        ElseIf Strings.Right(GTXT, 2) = "12" Then
                            TT1 = ""
                            TT2 = "≈À‰« ⁄‘—"
                        End If
                End Select
            Next J
        Next I

        '=======================PART 2=============================

        'ORGNIZE THE " Ê "
        Dim SP1, SP2 As String
        If N2 <> "" And N1 <> "" And N2 >= 20 Then
            SP1 = " Ê "
        Else
            SP1 = " "
        End If

        If N3 <> "" And ((N2 > 0) Or N1 <> "") Then
            SP2 = " Ê "
        Else
            SP2 = " "
        End If
        '=======================PART 3=============================
        'RETURN THE RESULT
        GTXT = TT3 & SP2 & TT1 & SP1 & TT2
    End Sub
    '=============================
    'SET THE LETTERS
    '=============================
    Private Sub LOAD_LETTER()
        LETTER_ARR(1, 1) = "1"
        LETTER_ARR(2, 1) = "2"
        LETTER_ARR(3, 1) = "3"
        LETTER_ARR(4, 1) = "4"
        LETTER_ARR(5, 1) = "5"
        LETTER_ARR(6, 1) = "6"
        LETTER_ARR(7, 1) = "7"
        LETTER_ARR(8, 1) = "8"
        LETTER_ARR(9, 1) = "9"

        LETTER_ARR(1, 2) = "Ê«Õœ"
        LETTER_ARR(2, 2) = "«À‰Ì‰"
        LETTER_ARR(3, 2) = "À·«À…"
        LETTER_ARR(4, 2) = "√—»⁄…"
        LETTER_ARR(5, 2) = "Œ„”…"
        LETTER_ARR(6, 2) = "” …"
        LETTER_ARR(7, 2) = "”»⁄…"
        LETTER_ARR(8, 2) = "À„«‰Ì…"
        LETTER_ARR(9, 2) = " ”⁄…"

        LETTER_ARR(1, 3) = "⁄‘—…"
        LETTER_ARR(2, 3) = "⁄‘—Ê‰"
        LETTER_ARR(3, 3) = "À·«ÀÊ‰"
        LETTER_ARR(4, 3) = "√—»⁄Ê‰"
        LETTER_ARR(5, 3) = "Œ„”Ê‰"
        LETTER_ARR(6, 3) = "” Ê‰"
        LETTER_ARR(7, 3) = "”»⁄Ê‰"
        LETTER_ARR(8, 3) = "À„«‰Ê‰"
        LETTER_ARR(9, 3) = " ”⁄Ê‰"

        LETTER_ARR(1, 4) = "„∆…"
        LETTER_ARR(2, 4) = "„∆ «‰"
        LETTER_ARR(3, 4) = "À·«À „∆…"
        LETTER_ARR(4, 4) = "√—»⁄ „∆…"
        LETTER_ARR(5, 4) = "Œ„” „∆…"
        LETTER_ARR(6, 4) = "”  „∆…"
        LETTER_ARR(7, 4) = "”»⁄ „∆…"
        LETTER_ARR(8, 4) = "À„«‰ „∆…"
        LETTER_ARR(9, 4) = " ”⁄ „∆…"
    End Sub

    'WRITE NUMBER TO ENGLISH LETTER
    '===============================
    'FILL THE NUMBERS IN THE ARRAY
    Public Sub FILL_ARRAY()
        ARR(1, 1) = "1"
        ARR(2, 1) = "2"
        ARR(3, 1) = "3"
        ARR(4, 1) = "4"
        ARR(5, 1) = "5"
        ARR(6, 1) = "6"
        ARR(7, 1) = "7"
        ARR(8, 1) = "8"
        ARR(9, 1) = "9"

        ARR(10, 1) = "10"
        ARR(11, 1) = "11"
        ARR(12, 1) = "12"
        ARR(13, 1) = "13"
        ARR(14, 1) = "14"
        ARR(15, 1) = "15"
        ARR(16, 1) = "16"
        ARR(17, 1) = "17"
        ARR(18, 1) = "18"
        ARR(19, 1) = "19"

        '---------THE TEXT
        ARR(1, 2) = "ONE"
        ARR(2, 2) = "TOW"
        ARR(3, 2) = "THREE"
        ARR(4, 2) = "FOUR"
        ARR(5, 2) = "FIVE"
        ARR(6, 2) = "SIX"
        ARR(7, 2) = "SEVEN"
        ARR(8, 2) = "EIGHT"
        ARR(9, 2) = "NINE"

        ARR(10, 2) = "TEN"
        ARR(11, 2) = "ELEVEN"
        ARR(12, 2) = "TWELVE"
        ARR(13, 2) = "THIRTEEN"
        ARR(14, 2) = "FOURTEEN"
        ARR(15, 2) = "FIFTEEN"
        ARR(16, 2) = "SIXTEEN"
        ARR(17, 2) = "SEVENTEEN"
        ARR(18, 2) = "EIGHTEEN"
        ARR(19, 2) = "NINETEEN"

        ARR(1, 3) = "TEN"
        ARR(2, 3) = "TWENTY"
        ARR(3, 3) = "THIRTY"
        ARR(4, 3) = "FORTY"
        ARR(5, 3) = "FIFTY"
        ARR(6, 3) = "SIXTY"
        ARR(7, 3) = "SEVENTY"
        ARR(8, 3) = "EIGHTTY"
        ARR(9, 3) = "NINETY"

    End Sub
    '====================================
    ' THIS FUNCTIION TO WRITE THE AMOUNT IN ACCESSPT FOR THE INTEGER NUMBER 
    Public Function TRANSLATE_en(ByVal NET_TXT As String) As String
        FILL_ARRAY()
        Dim COUNT, I, X As Integer
        Dim T1, T2, T3, T4, T5, AMOUNT, TEMP As String
        COUNT = Strings.Len(NET_TXT)

        Dim XLOOP As Integer
        X = COUNT - 1
        For XLOOP = 1 To COUNT
            Select Case XLOOP
                Case 1
                    For I = 1 To 9
                        If NET_TXT.Chars(X) = ARR(I, 1) Then
                            T1 = ARR(I, 2)
                            AMOUNT = T1

                        End If
                    Next
                Case 2
                    If Val(NET_TXT.Chars(X)) > 1 Then
                        For I = 1 To 9
                            If NET_TXT.Chars(X) = ARR(I, 1) Then
                                T2 = ARR(I, 3)
                                AMOUNT = T2 + " " + AMOUNT
                            End If
                        Next
                    ElseIf Val(NET_TXT.Chars(X)) = 1 Then
                        For I = 10 To 19
                            If NET_TXT.Chars(X) + NET_TXT.Chars(X + 1) = ARR(I, 1) Then
                                T2 = ARR(I, 2)
                                AMOUNT = T2
                            End If
                        Next
                    End If
                Case 3
                    For I = 1 To 9
                        If NET_TXT.Chars(X) = ARR(I, 1) Then
                            T3 = ARR(I, 2)
                            AMOUNT = T3 + " HUNDRED " + AMOUNT
                        End If
                    Next

                Case 4
                    For I = 1 To 9
                        If NET_TXT.Chars(X) = ARR(I, 1) Then
                            T4 = ARR(I, 2)
                            TEMP = " THOUSAND " + AMOUNT
                            AMOUNT = T4 + " THOUSAND " + AMOUNT
                        End If
                    Next

                Case 5
                    If Val(NET_TXT.Chars(X)) > 1 Then
                        For I = 1 To 9
                            If NET_TXT.Chars(X) = ARR(I, 1) Then
                                T5 = ARR(I, 3)
                                AMOUNT = T5 + " " + AMOUNT
                            End If
                        Next
                    ElseIf Val(NET_TXT.Chars(X)) = 1 Then
                        For I = 10 To 19
                            If NET_TXT.Chars(X) + NET_TXT.Chars(X + 1) = ARR(I, 1) Then
                                T5 = ARR(I, 2)
                                AMOUNT = T5 + TEMP
                            End If
                        Next
                    End If

            End Select
            X -= 1
        Next
        Return AMOUNT
    End Function
    ' THIS IS THE MAIN FUNCTION FOR THE ENGLISH LETTER 
    ' CALL THIS FUNCTION FROM THE FORM 
    Public Function WRITE_EN(ByVal TEXT As String) As String
        Dim I, DOT As Integer
        Dim A, B As String
        Dim MYSTR As String
        For I = 0 To TEXT.Length - 1
            If TEXT.Chars(I) = "." Then
                DOT = I
                Exit For
            ElseIf I = TEXT.Length - 1 And TEXT.Chars(I) <> "." Then
                MYSTR = TRANSLATE_en(TEXT) + " RYALL"
                Return MYSTR
                Exit Function
            End If
        Next
        A = Strings.Left(TEXT, DOT)
        A = TRANSLATE_en(A) + " RYALL AND "
        B = Strings.Mid(TEXT, DOT + 2)
        B = TRANSLATE_en(B) + " HALLAH"
        MYSTR = A & B
        Return MYSTR
    End Function
    'To create  A Password as code
    ' 0 Un codein (open)
    ' 1 codeing (close)
    Function CodePass(ByVal Str As String, Optional ByVal IO As Integer = 0) As String
        'CodePass = Str
        CodePass = Nothing
        If IO = 0 Then
            'UnCoding
            CodePass = XorString(ReverseString(Str), "A")
            Return CodePass
        ElseIf IO = 1 Then
        ''Check Area if the type of the password is correct 
        Dim J As Integer = 0
        For J = 0 To Str.Length - 1
            If Asc(Str.Chars(J)) >= 48 And Asc(Str.Chars(J)) <= 57 Then
            ElseIf Asc(Str.Chars(J)) >= 65 And Asc(Str.Chars(J)) <= 90 Then
            ElseIf Asc(Str.Chars(J)) >= 97 And Asc(Str.Chars(J)) <= 122 Then
            Else
                MsgBox(" You Must Enter A letters Or Numbers Or both as Password : " & Chr(13) & _
                " 0~9 " & Chr(13) & " a~z " & " A~Z", MsgBoxStyle.Critical)
                Return Nothing
                Exit Function
            End If
        Next
        'Coding
            CodePass = XorString(ReverseString(Str), "A")
            Return CodePass
        End If
    End Function
    Function ReverseString(ByVal targetString As String) As String
        Dim Characters() As Char = targetString.ToCharArray
        Array.Reverse(Characters)
        Return Characters
    End Function
    Function XorString(ByVal targetString As String, ByVal maskValue As String) As String
        Dim Index As Integer = 0
        Dim ReturnValue As String = ""
        For Each CharValue As Char In targetString.ToCharArray
            ReturnValue = String.Concat(ReturnValue, Chr(Asc(CharValue) Xor Asc(maskValue.Substring(Index, 1))))
            Index = (Index + 1) Mod maskValue.Length
        Next
        Return ReturnValue
    End Function

    Public Sub BEGIN_TRANSACTION()
        If MainConn.State = ConnectionState.Closed Then MainConn.Open()
        TRANSConn = MainConn.BeginTransaction
    End Sub
    Public Sub END_TRANSACTION()
        TRANSConn.Commit()
        MainConn.Close()
    End Sub
    Public Sub Rollback()
        If MainConn.State <> ConnectionState.Closed Then
            TRANSConn.Rollback()
            MainConn.Close()
        End If
    End Sub

End Module
