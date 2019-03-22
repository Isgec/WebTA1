Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taD_LCRates
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _CategoryID As String = ""
    Private _ModeID As Int32 = 0
    Private _CityID As String = ""
    Private _UseCityTypeID As Boolean = False
    Private _CityTypeID As String = ""
    Private _AmountPerKM As String = "0.00"
    Private _NightCharges As String = "0.00"
    Private _NonAvailabilityCharges As String = "0.00"
    Private _FixedInterStateCharges As String = "0.00"
    Private _FromDate As String = ""
    Private _TillDate As String = ""
    Private _Active As Boolean = False
    Private _TA_Categories1_cmba As String = ""
    Private _TA_Cities2_CityName As String = ""
    Private _TA_CityTypes3_CityTypeName As String = ""
    Private _TA_LCModes4_ModeName As String = ""
    Private _FK_TA_D_LCRates_CategoryID As SIS.TA.taCategories = Nothing
    Private _FK_TA_D_LCRates_CityID As SIS.TA.taCities = Nothing
    Private _FK_TA_D_LCRates_CityTypeID As SIS.TA.taCityTypes = Nothing
    Private _FK_TA_D_LCRates_ModeID As SIS.TA.taLCModes = Nothing
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
    Public Property CategoryID() As String
      Get
        Return _CategoryID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CategoryID = ""
         Else
           _CategoryID = value
         End If
      End Set
    End Property
    Public Property ModeID() As Int32
      Get
        Return _ModeID
      End Get
      Set(ByVal value As Int32)
        _ModeID = value
      End Set
    End Property
    Public Property CityID() As String
      Get
        Return _CityID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CityID = ""
         Else
           _CityID = value
         End If
      End Set
    End Property
    Public Property UseCityTypeID() As Boolean
      Get
        Return _UseCityTypeID
      End Get
      Set(ByVal value As Boolean)
        _UseCityTypeID = value
      End Set
    End Property
    Public Property CityTypeID() As String
      Get
        Return _CityTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CityTypeID = ""
         Else
           _CityTypeID = value
         End If
      End Set
    End Property
    Public Property AmountPerKM() As String
      Get
        Return _AmountPerKM
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AmountPerKM = "0.00"
         Else
           _AmountPerKM = value
         End If
      End Set
    End Property
    Public Property NightCharges() As String
      Get
        Return _NightCharges
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _NightCharges = "0.00"
         Else
           _NightCharges = value
         End If
      End Set
    End Property
    Public Property NonAvailabilityCharges() As String
      Get
        Return _NonAvailabilityCharges
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _NonAvailabilityCharges = "0.00"
         Else
           _NonAvailabilityCharges = value
         End If
      End Set
    End Property
    Public Property FixedInterStateCharges() As String
      Get
        Return _FixedInterStateCharges
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _FixedInterStateCharges = "0.00"
         Else
           _FixedInterStateCharges = value
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
    Public Property TA_Categories1_cmba() As String
      Get
        Return _TA_Categories1_cmba
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Categories1_cmba = ""
         Else
           _TA_Categories1_cmba = value
         End If
      End Set
    End Property
    Public Property TA_Cities2_CityName() As String
      Get
        Return _TA_Cities2_CityName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Cities2_CityName = ""
         Else
           _TA_Cities2_CityName = value
         End If
      End Set
    End Property
    Public Property TA_CityTypes3_CityTypeName() As String
      Get
        Return _TA_CityTypes3_CityTypeName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_CityTypes3_CityTypeName = ""
         Else
           _TA_CityTypes3_CityTypeName = value
         End If
      End Set
    End Property
    Public Property TA_LCModes4_ModeName() As String
      Get
        Return _TA_LCModes4_ModeName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_LCModes4_ModeName = ""
         Else
           _TA_LCModes4_ModeName = value
         End If
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
    Public Class PKtaD_LCRates
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
    Public ReadOnly Property FK_TA_D_LCRates_CategoryID() As SIS.TA.taCategories
      Get
        If _FK_TA_D_LCRates_CategoryID Is Nothing Then
          _FK_TA_D_LCRates_CategoryID = SIS.TA.taCategories.taCategoriesGetByID(_CategoryID)
        End If
        Return _FK_TA_D_LCRates_CategoryID
      End Get
    End Property
    Public ReadOnly Property FK_TA_D_LCRates_CityID() As SIS.TA.taCities
      Get
        If _FK_TA_D_LCRates_CityID Is Nothing Then
          _FK_TA_D_LCRates_CityID = SIS.TA.taCities.taCitiesGetByID(_CityID)
        End If
        Return _FK_TA_D_LCRates_CityID
      End Get
    End Property
    Public ReadOnly Property FK_TA_D_LCRates_CityTypeID() As SIS.TA.taCityTypes
      Get
        If _FK_TA_D_LCRates_CityTypeID Is Nothing Then
          _FK_TA_D_LCRates_CityTypeID = SIS.TA.taCityTypes.taCityTypesGetByID(_CityTypeID)
        End If
        Return _FK_TA_D_LCRates_CityTypeID
      End Get
    End Property
    Public ReadOnly Property FK_TA_D_LCRates_ModeID() As SIS.TA.taLCModes
      Get
        If _FK_TA_D_LCRates_ModeID Is Nothing Then
          _FK_TA_D_LCRates_ModeID = SIS.TA.taLCModes.taLCModesGetByID(_ModeID)
        End If
        Return _FK_TA_D_LCRates_ModeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taD_LCRatesGetNewRecord() As SIS.TA.taD_LCRates
      Return New SIS.TA.taD_LCRates()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taD_LCRatesGetByID(ByVal SerialNo As Int32) As SIS.TA.taD_LCRates
      Dim Results As SIS.TA.taD_LCRates = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaD_LCRatesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taD_LCRates(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taD_LCRatesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TA.taD_LCRates)
      Dim Results As List(Of SIS.TA.taD_LCRates) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaD_LCRatesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaD_LCRatesSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taD_LCRates)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taD_LCRates(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taD_LCRatesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taD_LCRatesInsert(ByVal Record As SIS.TA.taD_LCRates) As SIS.TA.taD_LCRates
      Dim _Rec As SIS.TA.taD_LCRates = SIS.TA.taD_LCRates.taD_LCRatesGetNewRecord()
      With _Rec
        .CategoryID = Record.CategoryID
        .ModeID = Record.ModeID
        .CityID = Record.CityID
        .UseCityTypeID = Record.UseCityTypeID
        .CityTypeID = Record.CityTypeID
        .AmountPerKM = Record.AmountPerKM
        .NightCharges = Record.NightCharges
        .NonAvailabilityCharges = Record.NonAvailabilityCharges
        .FixedInterStateCharges = Record.FixedInterStateCharges
        .FromDate = Record.FromDate
        .TillDate = Record.TillDate
        .Active = Record.Active
      End With
      Return SIS.TA.taD_LCRates.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taD_LCRates) As SIS.TA.taD_LCRates
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaD_LCRatesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Iif(Record.CategoryID= "" ,Convert.DBNull, Record.CategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeID",SqlDbType.Int,11, Record.ModeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityID",SqlDbType.NVarChar,31, Iif(Record.CityID= "" ,Convert.DBNull, Record.CityID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseCityTypeID",SqlDbType.Bit,3, Record.UseCityTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityTypeID",SqlDbType.NVarChar,7, Iif(Record.CityTypeID= "" ,Convert.DBNull, Record.CityTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountPerKM",SqlDbType.Decimal,13, Iif(Record.AmountPerKM= "" ,Convert.DBNull, Record.AmountPerKM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NightCharges",SqlDbType.Decimal,13, Iif(Record.NightCharges= "" ,Convert.DBNull, Record.NightCharges))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonAvailabilityCharges", SqlDbType.Decimal, 13, IIf(Record.NonAvailabilityCharges = "", Convert.DBNull, Record.NonAvailabilityCharges))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FixedInterStateCharges",SqlDbType.Decimal,13, Iif(Record.FixedInterStateCharges= "" ,Convert.DBNull, Record.FixedInterStateCharges))
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
    Public Shared Function taD_LCRatesUpdate(ByVal Record As SIS.TA.taD_LCRates) As SIS.TA.taD_LCRates
      Dim _Rec As SIS.TA.taD_LCRates = SIS.TA.taD_LCRates.taD_LCRatesGetByID(Record.SerialNo)
      With _Rec
        .CategoryID = Record.CategoryID
        .ModeID = Record.ModeID
        .CityID = Record.CityID
        .UseCityTypeID = Record.UseCityTypeID
        .CityTypeID = Record.CityTypeID
        .AmountPerKM = Record.AmountPerKM
        .NightCharges = Record.NightCharges
        .NonAvailabilityCharges = Record.NonAvailabilityCharges
        .FixedInterStateCharges = Record.FixedInterStateCharges
        .FromDate = Record.FromDate
        .TillDate = Record.TillDate
        .Active = Record.Active
      End With
      Return SIS.TA.taD_LCRates.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taD_LCRates) As SIS.TA.taD_LCRates
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaD_LCRatesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Iif(Record.CategoryID= "" ,Convert.DBNull, Record.CategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeID",SqlDbType.Int,11, Record.ModeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityID",SqlDbType.NVarChar,31, Iif(Record.CityID= "" ,Convert.DBNull, Record.CityID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseCityTypeID",SqlDbType.Bit,3, Record.UseCityTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityTypeID",SqlDbType.NVarChar,7, Iif(Record.CityTypeID= "" ,Convert.DBNull, Record.CityTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountPerKM",SqlDbType.Decimal,13, Iif(Record.AmountPerKM= "" ,Convert.DBNull, Record.AmountPerKM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NightCharges",SqlDbType.Decimal,13, Iif(Record.NightCharges= "" ,Convert.DBNull, Record.NightCharges))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonAvailabilityCharges", SqlDbType.Decimal, 13, IIf(Record.NonAvailabilityCharges = "", Convert.DBNull, Record.NonAvailabilityCharges))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FixedInterStateCharges",SqlDbType.Decimal,13, Iif(Record.FixedInterStateCharges= "" ,Convert.DBNull, Record.FixedInterStateCharges))
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
    Public Shared Function taD_LCRatesDelete(ByVal Record As SIS.TA.taD_LCRates) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaD_LCRatesDelete"
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
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
