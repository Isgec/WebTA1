Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taF_LodgDA
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        'CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        'CType(.FindControl("F_CategoryID"), TextBox).Text = ""
        'CType(.FindControl("F_CategoryID_Display"), Label).Text = ""
        'CType(.FindControl("F_RegionID"), TextBox).Text = ""
        'CType(.FindControl("F_RegionID_Display"), Label).Text = ""
        'CType(.FindControl("F_Lodging"), TextBox).Text = ""
        'CType(.FindControl("F_DA"), TextBox).Text = ""
        'CType(.FindControl("F_FromDate"), TextBox).Text = ""
        'CType(.FindControl("F_TillDate"), TextBox).Text = ""
        'CType(.FindControl("F_Active"), CheckBox).Checked = False
      End With
      Return sender
    End Function
    Public Shared Function GetByCategoryID(ByVal CategoryID As Int32, ByVal RegionID As String, ByVal ForStartDate As DateTime) As SIS.TA.taF_LodgDA
      Dim Results As SIS.TA.taF_LodgDA = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spta_LG_F_LodgDASelectByCategoryID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID", SqlDbType.Int, CategoryID.ToString.Length, CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionID", SqlDbType.NVarChar, 10, RegionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForStartDate", SqlDbType.DateTime, 20, ForStartDate)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results = (New SIS.TA.taF_LodgDA(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
