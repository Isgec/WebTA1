Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taD_LCRates
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
    Public Function GetDeleteable() As Boolean
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
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function GetForCityByIDorType(ByVal tmpBD As SIS.TA.taBDLC) As SIS.TA.taD_LCRates
      Dim Results As SIS.TA.taD_LCRates = Nothing
      Dim Sql As String = ""
      Sql = ""
      Sql &= "   SELECT "
      Sql &= "     [TA_D_LCRates].* , "
      Sql &= "     [TA_Categories1].[cmba] AS TA_Categories1_cmba, "
      Sql &= "     [TA_Cities2].[CityName] AS TA_Cities2_CityName, "
      Sql &= "     [TA_CityTypes3].[CityTypeName] AS TA_CityTypes3_CityTypeName, "
      Sql &= "     [TA_LCModes4].[ModeName] AS TA_LCModes4_ModeName  "
      Sql &= "   FROM [TA_D_LCRates]  "
      Sql &= "   LEFT OUTER JOIN [TA_Categories] AS [TA_Categories1] "
      Sql &= "     ON [TA_D_LCRates].[CategoryID] = [TA_Categories1].[CategoryID] "
      Sql &= "   LEFT OUTER JOIN [TA_Cities] AS [TA_Cities2] "
      Sql &= "     ON [TA_D_LCRates].[CityID] = [TA_Cities2].[CityID] "
      Sql &= "   LEFT OUTER JOIN [TA_CityTypes] AS [TA_CityTypes3] "
      Sql &= "     ON [TA_D_LCRates].[CityTypeID] = [TA_CityTypes3].[CityTypeID] "
      Sql &= "   INNER JOIN [TA_LCModes] AS [TA_LCModes4] "
      Sql &= "     ON [TA_D_LCRates].[ModeID] = [TA_LCModes4].[ModeID] "
      Sql &= "   WHERE "
      Sql &= "   [TA_D_LCRates].[CityID] = '" & tmpBD.City1ID & "'"
      Sql &= "    AND [TA_D_LCRates].[ModeID] = '" & tmpBD.ModeLCID & "'"
      Sql &= "    AND convert(datetime,'" & tmpBD.Date1Time & "',103) Between [TA_D_LCRates].[FromDate] and [TA_D_LCRates].[TillDate]"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        If tmpBD.City1ID <> String.Empty Then
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If Reader.Read() Then
              Results = New SIS.TA.taD_LCRates(Reader)
            End If
            Reader.Close()
          End Using
        End If
        If Results Is Nothing Then
          Sql = ""
          Sql &= "   SELECT "
          Sql &= "     [TA_D_LCRates].* , "
          Sql &= "     [TA_Categories1].[cmba] AS TA_Categories1_cmba, "
          Sql &= "     [TA_Cities2].[CityName] AS TA_Cities2_CityName, "
          Sql &= "     [TA_CityTypes3].[CityTypeName] AS TA_CityTypes3_CityTypeName, "
          Sql &= "     [TA_LCModes4].[ModeName] AS TA_LCModes4_ModeName  "
          Sql &= "   FROM [TA_D_LCRates]  "
          Sql &= "   LEFT OUTER JOIN [TA_Categories] AS [TA_Categories1] "
          Sql &= "     ON [TA_D_LCRates].[CategoryID] = [TA_Categories1].[CategoryID] "
          Sql &= "   LEFT OUTER JOIN [TA_Cities] AS [TA_Cities2] "
          Sql &= "     ON [TA_D_LCRates].[CityID] = [TA_Cities2].[CityID] "
          Sql &= "   LEFT OUTER JOIN [TA_CityTypes] AS [TA_CityTypes3] "
          Sql &= "     ON [TA_D_LCRates].[CityTypeID] = [TA_CityTypes3].[CityTypeID] "
          Sql &= "   INNER JOIN [TA_LCModes] AS [TA_LCModes4] "
          Sql &= "     ON [TA_D_LCRates].[ModeID] = [TA_LCModes4].[ModeID] "
          Sql &= "   WHERE "
          If tmpBD.City1ID <> String.Empty Then
            Sql &= "   [TA_D_LCRates].[CityTypeID] = '" & tmpBD.FK_TA_BillDetails_City1ID.CityTypeForDA & "'"
          Else
            Sql &= "   [TA_D_LCRates].[CityTypeID] = 'OTHERS'"
          End If
          Sql &= "    AND [TA_D_LCRates].[ModeID] = '" & tmpBD.ModeLCID & "'"
          Sql &= "    AND convert(datetime,'" & tmpBD.Date1Time & "',103) Between [TA_D_LCRates].[FromDate] and [TA_D_LCRates].[TillDate]"
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If Reader.Read() Then
              Results = New SIS.TA.taD_LCRates(Reader)
            End If
            Reader.Close()
          End Using
        End If
        If Results Is Nothing Then
          Sql = ""
          Sql &= "   SELECT "
          Sql &= "     [TA_D_LCRates].* , "
          Sql &= "     [TA_Categories1].[cmba] AS TA_Categories1_cmba, "
          Sql &= "     [TA_Cities2].[CityName] AS TA_Cities2_CityName, "
          Sql &= "     [TA_CityTypes3].[CityTypeName] AS TA_CityTypes3_CityTypeName, "
          Sql &= "     [TA_LCModes4].[ModeName] AS TA_LCModes4_ModeName  "
          Sql &= "   FROM [TA_D_LCRates]  "
          Sql &= "   LEFT OUTER JOIN [TA_Categories] AS [TA_Categories1] "
          Sql &= "     ON [TA_D_LCRates].[CategoryID] = [TA_Categories1].[CategoryID] "
          Sql &= "   LEFT OUTER JOIN [TA_Cities] AS [TA_Cities2] "
          Sql &= "     ON [TA_D_LCRates].[CityID] = [TA_Cities2].[CityID] "
          Sql &= "   LEFT OUTER JOIN [TA_CityTypes] AS [TA_CityTypes3] "
          Sql &= "     ON [TA_D_LCRates].[CityTypeID] = [TA_CityTypes3].[CityTypeID] "
          Sql &= "   INNER JOIN [TA_LCModes] AS [TA_LCModes4] "
          Sql &= "     ON [TA_D_LCRates].[ModeID] = [TA_LCModes4].[ModeID] "
          Sql &= "   WHERE "
          Sql &= "   [TA_D_LCRates].[CityTypeID] = 'OTHERS'"
          Sql &= "    AND [TA_D_LCRates].[ModeID] = '" & tmpBD.ModeLCID & "'"
          Sql &= "    AND convert(datetime,'" & tmpBD.Date1Time & "',103) Between [TA_D_LCRates].[FromDate] and [TA_D_LCRates].[TillDate]"
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If Reader.Read() Then
              Results = New SIS.TA.taD_LCRates(Reader)
            End If
            Reader.Close()
          End Using
        End If
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_CategoryID"), Object).SelectedValue = ""
          CType(.FindControl("F_ModeID"), Object).SelectedValue = ""
          CType(.FindControl("F_CityID"), TextBox).Text = ""
          CType(.FindControl("F_CityID_Display"), Label).Text = ""
          CType(.FindControl("F_UseCityTypeID"), CheckBox).Checked = False
          CType(.FindControl("F_CityTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_AmountPerKM"), TextBox).Text = 0
          CType(.FindControl("F_NightCharges"), TextBox).Text = 0
          CType(.FindControl("F_NonAvailabilityCharges"), TextBox).Text = 0
          CType(.FindControl("F_FixedInterStateCharges"), TextBox).Text = 0
          CType(.FindControl("F_FromDate"), TextBox).Text = ""
          CType(.FindControl("F_TillDate"), TextBox).Text = ""
          CType(.FindControl("F_Active"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
