Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkRules
    Private Shared _RecordCount As Integer
    Private _RuleID As Int32 = 0
    Private _PerkID As Int32 = 0
    Private _CategoryID As Int32 = 0
    Private _EffectiveDate As String = ""
    Private _PercentageOfBasic As Boolean = False
    Private _Percentage As Decimal = 0
    Private _FixedValue As Decimal = 0
    Private _PostedAt As String = ""
    Private _VehicleType As String = ""
    Private _InSalary As Boolean = False
    Private _WithDriver As Boolean = False
    Private _PRK_Categories1_Description As String = ""
    Private _PRK_Perks2_Description As String = ""
    Private _FK_PRK_Rules_PRK_Categories As SIS.NPRK.nprkCategories = Nothing
    Private _FK_PRK_Rules_PRK_Perks As SIS.NPRK.nprkPerks = Nothing
    Public Property AdditionalValue As Decimal = 0
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
    Public Property WithDriver As Boolean
      Get
        Return _WithDriver
      End Get
      Set(value As Boolean)
        _WithDriver = value
      End Set
    End Property
    Public Property RuleID() As Int32
      Get
        Return _RuleID
      End Get
      Set(ByVal value As Int32)
        _RuleID = value
      End Set
    End Property
    Public Property PerkID() As Int32
      Get
        Return _PerkID
      End Get
      Set(ByVal value As Int32)
        _PerkID = value
      End Set
    End Property
    Public Property CategoryID() As Int32
      Get
        Return _CategoryID
      End Get
      Set(ByVal value As Int32)
        _CategoryID = value
      End Set
    End Property
    Public Property EffectiveDate() As String
      Get
        If Not _EffectiveDate = String.Empty Then
          Return Convert.ToDateTime(_EffectiveDate).ToString("dd/MM/yyyy")
        End If
        Return _EffectiveDate
      End Get
      Set(ByVal value As String)
         _EffectiveDate = value
      End Set
    End Property
    Public Property PercentageOfBasic() As Boolean
      Get
        Return _PercentageOfBasic
      End Get
      Set(ByVal value As Boolean)
        _PercentageOfBasic = value
      End Set
    End Property
    Public Property Percentage() As Decimal
      Get
        Return _Percentage
      End Get
      Set(ByVal value As Decimal)
        _Percentage = value
      End Set
    End Property
    Public Property FixedValue() As Decimal
      Get
        Return _FixedValue
      End Get
      Set(ByVal value As Decimal)
        _FixedValue = value
      End Set
    End Property
    Public Property PostedAt() As String
      Get
        Return _PostedAt
      End Get
      Set(ByVal value As String)
        _PostedAt = value
      End Set
    End Property
    Public Property VehicleType() As String
      Get
        Return _VehicleType
      End Get
      Set(ByVal value As String)
        _VehicleType = value
      End Set
    End Property
    Public Property InSalary() As Boolean
      Get
        Return _InSalary
      End Get
      Set(ByVal value As Boolean)
        _InSalary = value
      End Set
    End Property
    Public Property PRK_Categories1_Description() As String
      Get
        Return _PRK_Categories1_Description
      End Get
      Set(ByVal value As String)
        _PRK_Categories1_Description = value
      End Set
    End Property
    Public Property PRK_Perks2_Description() As String
      Get
        Return _PRK_Perks2_Description
      End Get
      Set(ByVal value As String)
        _PRK_Perks2_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _RuleID
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
    Public Class PKnprkRules
      Private _RuleID As Int32 = 0
      Public Property RuleID() As Int32
        Get
          Return _RuleID
        End Get
        Set(ByVal value As Int32)
          _RuleID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PRK_Rules_PRK_Categories() As SIS.NPRK.nprkCategories
      Get
        If _FK_PRK_Rules_PRK_Categories Is Nothing Then
          _FK_PRK_Rules_PRK_Categories = SIS.NPRK.nprkCategories.nprkCategoriesGetByID(_CategoryID)
        End If
        Return _FK_PRK_Rules_PRK_Categories
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Rules_PRK_Perks() As SIS.NPRK.nprkPerks
      Get
        If _FK_PRK_Rules_PRK_Perks Is Nothing Then
          _FK_PRK_Rules_PRK_Perks = SIS.NPRK.nprkPerks.nprkPerksGetByID(_PerkID)
        End If
        Return _FK_PRK_Rules_PRK_Perks
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkRulesGetNewRecord() As SIS.NPRK.nprkRules
      Return New SIS.NPRK.nprkRules()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkRulesGetByID(ByVal RuleID As Int32) As SIS.NPRK.nprkRules
      Dim Results As SIS.NPRK.nprkRules = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkRulesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RuleID",SqlDbType.Int,RuleID.ToString.Length, RuleID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkRules(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByPerkID(ByVal PerkID As Int32, ByVal OrderBy as String) As List(Of SIS.NPRK.nprkRules)
      Dim Results As List(Of SIS.NPRK.nprkRules) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkRulesSelectByPerkID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID",SqlDbType.Int,PerkID.ToString.Length, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkRules)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkRules(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByCategoryID(ByVal CategoryID As Int32, ByVal OrderBy As String) As List(Of SIS.NPRK.nprkRules)
      Dim Results As List(Of SIS.NPRK.nprkRules) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkRulesSelectByCategoryID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID", SqlDbType.Int, CategoryID.ToString.Length, CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkRules)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkRules(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function nprkRulesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PerkID As Int32, ByVal CategoryID As Int32) As List(Of SIS.NPRK.nprkRules)
      Dim Results As List(Of SIS.NPRK.nprkRules) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkRulesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkRulesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PerkID", SqlDbType.Int, 10, IIf(PerkID = Nothing, 0, PerkID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CategoryID", SqlDbType.Int, 10, IIf(CategoryID = Nothing, 0, CategoryID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkRules)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkRules(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkRulesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PerkID As Int32, ByVal CategoryID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkRulesGetByID(ByVal RuleID As Int32, ByVal Filter_PerkID As Int32, ByVal Filter_CategoryID As Int32) As SIS.NPRK.nprkRules
      Return nprkRulesGetByID(RuleID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkRulesInsert(ByVal Record As SIS.NPRK.nprkRules) As SIS.NPRK.nprkRules
      Dim _Rec As SIS.NPRK.nprkRules = SIS.NPRK.nprkRules.nprkRulesGetNewRecord()
      With _Rec
        .PerkID = Record.PerkID
        .CategoryID = Record.CategoryID
        .EffectiveDate = Record.EffectiveDate
        .PercentageOfBasic = Record.PercentageOfBasic
        .Percentage = Record.Percentage
        .FixedValue = Record.FixedValue
        .PostedAt = Record.PostedAt
        .VehicleType = Record.VehicleType
        .InSalary = Record.InSalary
        .WithDriver = Record.WithDriver
        .AdditionalValue = Record.AdditionalValue
      End With
      Return SIS.NPRK.nprkRules.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkRules) As SIS.NPRK.nprkRules
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkRulesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID",SqlDbType.Int,11, Record.PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EffectiveDate",SqlDbType.DateTime,21, Record.EffectiveDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PercentageOfBasic",SqlDbType.Bit,3, Record.PercentageOfBasic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Percentage",SqlDbType.Decimal,9, Record.Percentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FixedValue",SqlDbType.Decimal,13, Record.FixedValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedAt",SqlDbType.NVarChar,21, Record.PostedAt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleType",SqlDbType.NVarChar,21, Record.VehicleType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InSalary",SqlDbType.Bit,3, Record.InSalary)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WithDriver", SqlDbType.Bit, 3, Record.WithDriver)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdditionalValue", SqlDbType.Decimal, 13, Record.AdditionalValue)
          Cmd.Parameters.Add("@Return_RuleID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RuleID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.RuleID = Cmd.Parameters("@Return_RuleID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkRulesUpdate(ByVal Record As SIS.NPRK.nprkRules) As SIS.NPRK.nprkRules
      Dim _Rec As SIS.NPRK.nprkRules = SIS.NPRK.nprkRules.nprkRulesGetByID(Record.RuleID)
      With _Rec
        .PerkID = Record.PerkID
        .CategoryID = Record.CategoryID
        .EffectiveDate = Record.EffectiveDate
        .PercentageOfBasic = Record.PercentageOfBasic
        .Percentage = Record.Percentage
        .FixedValue = Record.FixedValue
        .PostedAt = Record.PostedAt
        .VehicleType = Record.VehicleType
        .InSalary = Record.InSalary
        .WithDriver = Record.WithDriver
        .AdditionalValue = Record.AdditionalValue
      End With
      Return SIS.NPRK.nprkRules.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkRules) As SIS.NPRK.nprkRules
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkRulesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RuleID",SqlDbType.Int,11, Record.RuleID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID",SqlDbType.Int,11, Record.PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EffectiveDate",SqlDbType.DateTime,21, Record.EffectiveDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PercentageOfBasic",SqlDbType.Bit,3, Record.PercentageOfBasic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Percentage",SqlDbType.Decimal,9, Record.Percentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FixedValue",SqlDbType.Decimal,13, Record.FixedValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedAt",SqlDbType.NVarChar,21, Record.PostedAt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleType",SqlDbType.NVarChar,21, Record.VehicleType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InSalary",SqlDbType.Bit,3, Record.InSalary)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WithDriver", SqlDbType.Bit, 3, Record.WithDriver)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdditionalValue", SqlDbType.Decimal, 13, Record.AdditionalValue)
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
    Public Shared Function nprkRulesDelete(ByVal Record As SIS.NPRK.nprkRules) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkRulesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RuleID",SqlDbType.Int,Record.RuleID.ToString.Length, Record.RuleID)
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
