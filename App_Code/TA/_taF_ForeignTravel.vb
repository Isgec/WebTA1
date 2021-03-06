Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taF_ForeignTravel
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _Bord_Lodg_DA_Percent As String = "0.00"
    Private _Lodg_DA_Percent As String = "0.00"
    Private _DA_Adjested_LC_Percent As String = "0.00"
    Private _FromDate As String = ""
    Private _TillDate As String = ""
    Private _Active As Boolean = False
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property Bord_Lodg_DA_Percent() As String
      Get
        Return _Bord_Lodg_DA_Percent
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Bord_Lodg_DA_Percent = "0.00"
         Else
           _Bord_Lodg_DA_Percent = value
         End If
      End Set
    End Property
    Public Property Lodg_DA_Percent() As String
      Get
        Return _Lodg_DA_Percent
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Lodg_DA_Percent = "0.00"
         Else
           _Lodg_DA_Percent = value
         End If
      End Set
    End Property
    Public Property DA_Adjested_LC_Percent() As String
      Get
        Return _DA_Adjested_LC_Percent
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DA_Adjested_LC_Percent = "0.00"
         Else
           _DA_Adjested_LC_Percent = value
         End If
      End Set
    End Property
    Public Property FromDate() As String
      Get
        If Not _FromDate = String.Empty Then
          Return Convert.ToDateTime(_FromDate).ToString("dd/MM/yyyy")
        End If
        Return _FromDate
      End Get
      Set(ByVal value As String)
         _FromDate = value
      End Set
    End Property
    Public Property TillDate() As String
      Get
        If Not _TillDate = String.Empty Then
          Return Convert.ToDateTime(_TillDate).ToString("dd/MM/yyyy")
        End If
        Return _TillDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TillDate = ""
         Else
           _TillDate = value
         End If
      End Set
    End Property
    Public Property Active() As Boolean
      Get
        Return _Active
      End Get
      Set(ByVal value As Boolean)
        _Active = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKtaF_ForeignTravel
      Private _SerialNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taF_ForeignTravelGetNewRecord() As SIS.TA.taF_ForeignTravel
      Return New SIS.TA.taF_ForeignTravel()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taF_ForeignTravelGetByID(ByVal SerialNo As Int32) As SIS.TA.taF_ForeignTravel
      Dim Results As SIS.TA.taF_ForeignTravel = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaF_ForeignTravelSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taF_ForeignTravel(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taF_ForeignTravelSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TA.taF_ForeignTravel)
      Dim Results As List(Of SIS.TA.taF_ForeignTravel) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaF_ForeignTravelSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaF_ForeignTravelSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taF_ForeignTravel)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taF_ForeignTravel(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taF_ForeignTravelSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taF_ForeignTravelInsert(ByVal Record As SIS.TA.taF_ForeignTravel) As SIS.TA.taF_ForeignTravel
      Dim _Rec As SIS.TA.taF_ForeignTravel = SIS.TA.taF_ForeignTravel.taF_ForeignTravelGetNewRecord()
      With _Rec
        .Bord_Lodg_DA_Percent = Record.Bord_Lodg_DA_Percent
        .Lodg_DA_Percent = Record.Lodg_DA_Percent
        .DA_Adjested_LC_Percent = Record.DA_Adjested_LC_Percent
        .FromDate = Record.FromDate
        .TillDate = Record.TillDate
        .Active = Record.Active
      End With
      Return SIS.TA.taF_ForeignTravel.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taF_ForeignTravel) As SIS.TA.taF_ForeignTravel
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaF_ForeignTravelInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Bord_Lodg_DA_Percent",SqlDbType.Decimal,13, Iif(Record.Bord_Lodg_DA_Percent= "" ,Convert.DBNull, Record.Bord_Lodg_DA_Percent))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Lodg_DA_Percent",SqlDbType.Decimal,13, Iif(Record.Lodg_DA_Percent= "" ,Convert.DBNull, Record.Lodg_DA_Percent))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DA_Adjested_LC_Percent",SqlDbType.Decimal,13, Iif(Record.DA_Adjested_LC_Percent= "" ,Convert.DBNull, Record.DA_Adjested_LC_Percent))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate",SqlDbType.DateTime,21, Record.FromDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TillDate",SqlDbType.DateTime,21, Iif(Record.TillDate= "" ,Convert.DBNull, Record.TillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taF_ForeignTravelUpdate(ByVal Record As SIS.TA.taF_ForeignTravel) As SIS.TA.taF_ForeignTravel
      Dim _Rec As SIS.TA.taF_ForeignTravel = SIS.TA.taF_ForeignTravel.taF_ForeignTravelGetByID(Record.SerialNo)
      With _Rec
        .Bord_Lodg_DA_Percent = Record.Bord_Lodg_DA_Percent
        .Lodg_DA_Percent = Record.Lodg_DA_Percent
        .DA_Adjested_LC_Percent = Record.DA_Adjested_LC_Percent
        .FromDate = Record.FromDate
        .TillDate = Record.TillDate
        .Active = Record.Active
      End With
      Return SIS.TA.taF_ForeignTravel.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taF_ForeignTravel) As SIS.TA.taF_ForeignTravel
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaF_ForeignTravelUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Bord_Lodg_DA_Percent",SqlDbType.Decimal,13, Iif(Record.Bord_Lodg_DA_Percent= "" ,Convert.DBNull, Record.Bord_Lodg_DA_Percent))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Lodg_DA_Percent",SqlDbType.Decimal,13, Iif(Record.Lodg_DA_Percent= "" ,Convert.DBNull, Record.Lodg_DA_Percent))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DA_Adjested_LC_Percent",SqlDbType.Decimal,13, Iif(Record.DA_Adjested_LC_Percent= "" ,Convert.DBNull, Record.DA_Adjested_LC_Percent))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate",SqlDbType.DateTime,21, Record.FromDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TillDate",SqlDbType.DateTime,21, Iif(Record.TillDate= "" ,Convert.DBNull, Record.TillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function taF_ForeignTravelDelete(ByVal Record As SIS.TA.taF_ForeignTravel) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaF_ForeignTravelDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      If Convert.IsDBNull(Reader("Bord_Lodg_DA_Percent")) Then
        _Bord_Lodg_DA_Percent = 0.00
      Else
        _Bord_Lodg_DA_Percent = Ctype(Reader("Bord_Lodg_DA_Percent"), String)
      End If
      If Convert.IsDBNull(Reader("Lodg_DA_Percent")) Then
        _Lodg_DA_Percent = 0.00
      Else
        _Lodg_DA_Percent = Ctype(Reader("Lodg_DA_Percent"), String)
      End If
      If Convert.IsDBNull(Reader("DA_Adjested_LC_Percent")) Then
        _DA_Adjested_LC_Percent = 0.00
      Else
        _DA_Adjested_LC_Percent = Ctype(Reader("DA_Adjested_LC_Percent"), String)
      End If
      _FromDate = Ctype(Reader("FromDate"),DateTime)
      If Convert.IsDBNull(Reader("TillDate")) Then
        _TillDate = String.Empty
      Else
        _TillDate = Ctype(Reader("TillDate"), String)
      End If
      _Active = Ctype(Reader("Active"),Boolean)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
