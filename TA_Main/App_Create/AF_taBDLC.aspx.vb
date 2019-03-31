Imports System.Web.Script.Serialization
Partial Class AF_taBDLC
  Inherits SIS.SYS.GridBase
  Public Property dtMaskType As String
    Get
      If ViewState("dtMaskType") IsNot Nothing Then
        Return Convert.ToString(ViewState("dtMaskType"))
      End If
      Return "DateTime"
    End Get
    Set(value As String)
      ViewState.Add("dtMaskType", value)
    End Set
  End Property

  Public Property dtMask As String
    Get
      If ViewState("dtMask") IsNot Nothing Then
        Return Convert.ToString(ViewState("dtMask"))
      End If
      Return "99/99/9999 99:99"
    End Get
    Set(value As String)
      ViewState.Add("dtMask", value)
    End Set
  End Property

  Public Property dtFormat As String
    Get
      If ViewState("dtFormat") IsNot Nothing Then
        Return Convert.ToString(ViewState("dtFormat"))
      End If
      Return "dd/MM/yyyy HH:mm"
    End Get
    Set(value As String)
      ViewState.Add("dtFormat", value)
    End Set
  End Property

  Public Property IsForeign As Boolean
    Get
      If ViewState("IsForeign") IsNot Nothing Then
        Return Convert.ToBoolean(ViewState("IsForeign"))
      End If
      Return False
    End Get
    Set(value As Boolean)
      ViewState.Add("IsForeign", value)
    End Set
  End Property
  Public Property dCssClass As String
    Get
      If ViewState("dCssClass") IsNot Nothing Then
        Return Convert.ToString(ViewState("dCssClass"))
      End If
      Return "dmytxt"
    End Get
    Set(value As String)
      ViewState.Add("dCssClass", value)
    End Set
  End Property
  Public Property TravelStarted As String
    Get
      If ViewState("TravelStarted") IsNot Nothing Then
        Return Convert.ToString(ViewState("TravelStarted"))
      End If
      Return Now.ToString("dd/MM/yyyy")
    End Get
    Set(value As String)
      ViewState.Add("TravelStarted", value)
    End Set
  End Property

  Protected Sub GVtaBDLC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBDLC.Init
    DataClassName = "GtaBDLC"
    SetGridView = GVtaBDLC
  End Sub
  Protected Sub TBLtaBDLC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDLC.Init
    SetToolBar = TBLtaBDLC
  End Sub
  Private Sub AF_taBDLC_Init(sender As Object, e As EventArgs) Handles Me.Init ', Me.Load
    If Request.QueryString("TABillNo") IsNot Nothing Then
      F_TABillNo.Text = Request.QueryString("TABillNo")
      Dim otabh As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(Request.QueryString("TABillNo"))
      Select Case otabh.TravelTypeID
        Case TATravelTypeValues.Domestic, TATravelTypeValues.HomeVisit
          IsForeign = False
          dCssClass = "dmytxt"
          dtFormat = "dd/MM/yyyy HH:mm"
          dtMask = "99/99/9999 99:99"
          dtMaskType = "DateTime"
        Case TATravelTypeValues.ForeignSiteVisit, TATravelTypeValues.ForeignTravel
          IsForeign = True
          dCssClass = "mytxt"
          dtFormat = "dd/MM/yyyy"
          dtMask = "99/99/9999"
          dtMaskType = "Date"
      End Select
      If otabh.StartDateTime = "" Then
        TravelStarted = Now.ToString("dd/MM/yyyy")
      Else
        TravelStarted = otabh.StartDateTime
      End If
    End If
  End Sub
  Private Sub GVtaBDLC_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GVtaBDLC.RowCreated
    If e.Row.RowType = DataControlRowType.DataRow Then
      If Convert.ToDateTime(TravelStarted) < Convert.ToDateTime("15/03/2019") OrElse IsForeign Then
        Dim x As LC_taLCModes = CType(e.Row.FindControl("F_ModeLCID"), LC_taLCModes)
        RemoveHandler x.GetDropDown.SelectedIndexChanged, AddressOf DDLChanged
        x.AutoPostBack = False
      End If
    End If
  End Sub
  Public Sub DDLChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    If Convert.ToDateTime(TravelStarted) < Convert.ToDateTime("15/03/2019") Then Exit Sub
    Dim DDL As DropDownList = CType(sender, DropDownList)
    Dim xTmp As String = DDL.SelectedValue
    Dim aTmp() As String = DDL.ClientID.Split("_".ToCharArray)
    Dim gvR As GridViewRow = GVtaBDLC.Rows(aTmp(aTmp.Length - 1))
    Dim mayEnable As Boolean = False
    Select Case xTmp
      Case "1", "2", "3", "11" '1,2,3=Taxi | 11=OwnCar
        CType(gvR.FindControl("F_StayedWithRelative"), CheckBox).Enabled = False
        CType(gvR.FindControl("F_StayedInGuestHouse"), CheckBox).Enabled = False
        CType(gvR.FindControl("F_StayedAtSite"), CheckBox).Enabled = False
        CType(gvR.FindControl("F_AmountRateOU"), TextBox).Enabled = True
        CType(gvR.FindControl("F_AmountRateOU"), TextBox).CssClass = "mytxt"
        CType(gvR.FindControl("F_AmountRate"), TextBox).Enabled = True
        CType(gvR.FindControl("F_AmountRate"), TextBox).CssClass = "mytxt"
        CType(gvR.FindControl("RVF_AmountRate"), RangeValidator).Enabled = True
        CType(gvR.FindControl("L_RateAmount"), Label).Text = "Enter Amount"
      Case "4", "8" ' Three Wheeler
        CType(gvR.FindControl("F_StayedWithRelative"), CheckBox).Enabled = True
        CType(gvR.FindControl("F_StayedInGuestHouse"), CheckBox).Enabled = True
        CType(gvR.FindControl("F_StayedAtSite"), CheckBox).Enabled = True
        CType(gvR.FindControl("F_AmountRateOU"), TextBox).Enabled = False
        CType(gvR.FindControl("F_AmountRateOU"), TextBox).CssClass = ""
        CType(gvR.FindControl("F_AmountRate"), TextBox).Enabled = True
        CType(gvR.FindControl("F_AmountRate"), TextBox).CssClass = "mytxt"
        CType(gvR.FindControl("RVF_AmountRate"), RangeValidator).Enabled = True
        CType(gvR.FindControl("L_RateAmount"), Label).Text = ""
      Case Else
        CType(gvR.FindControl("F_StayedWithRelative"), CheckBox).Enabled = False
        CType(gvR.FindControl("F_StayedInGuestHouse"), CheckBox).Enabled = False
        CType(gvR.FindControl("F_StayedAtSite"), CheckBox).Enabled = False
        CType(gvR.FindControl("F_AmountRateOU"), TextBox).Enabled = True
        CType(gvR.FindControl("F_AmountRateOU"), TextBox).CssClass = "mytxt"
        CType(gvR.FindControl("F_AmountRate"), TextBox).Enabled = False
        CType(gvR.FindControl("F_AmountRate"), TextBox).CssClass = ""
        CType(gvR.FindControl("RVF_AmountRate"), RangeValidator).Enabled = False
        CType(gvR.FindControl("L_RateAmount"), Label).Text = "Enter Total Amount"
    End Select
    If IsForeign Then
      CType(gvR.FindControl("F_Date2Time"), TextBox).Enabled = False
      CType(gvR.FindControl("F_Date2Time"), TextBox).CssClass = ""
      CType(gvR.FindControl("CEDate2Time"), AjaxControlToolkit.CalendarExtender).Enabled = False
      CType(gvR.FindControl("MEVDate2Time"), AjaxControlToolkit.MaskedEditValidator).Enabled = False
    Else
      Select Case xTmp
        Case "1", "2", "3", "4", "8", "11" '1,2,3=Taxi | 4=Three Wheeler | 11=OwnCar
          CType(gvR.FindControl("F_Date2Time"), TextBox).Enabled = True
          CType(gvR.FindControl("F_Date2Time"), TextBox).CssClass = "mytxt"
          CType(gvR.FindControl("CEDate2Time"), AjaxControlToolkit.CalendarExtender).Enabled = True
          CType(gvR.FindControl("MEVDate2Time"), AjaxControlToolkit.MaskedEditValidator).Enabled = True
          CType(gvR.FindControl("F_City1ID"), TextBox).Enabled = True
          CType(gvR.FindControl("F_City1ID"), TextBox).CssClass = "mytxt"
          CType(gvR.FindControl("F_City1Text"), TextBox).Enabled = True
          CType(gvR.FindControl("F_City1Text"), TextBox).CssClass = "mypktxt"
        Case Else
          CType(gvR.FindControl("F_Date2Time"), TextBox).Enabled = False
          CType(gvR.FindControl("F_Date2Time"), TextBox).CssClass = ""
          CType(gvR.FindControl("CEDate2Time"), AjaxControlToolkit.CalendarExtender).Enabled = False
          CType(gvR.FindControl("MEVDate2Time"), AjaxControlToolkit.MaskedEditValidator).Enabled = False
          CType(gvR.FindControl("F_City1ID"), TextBox).Enabled = False
          CType(gvR.FindControl("F_City1ID"), TextBox).CssClass = ""
          CType(gvR.FindControl("F_City1Text"), TextBox).Enabled = False
          CType(gvR.FindControl("F_City1Text"), TextBox).CssClass = ""
      End Select
    End If
  End Sub
  Private Sub GVtaBDLC_PreRender(sender As Object, e As EventArgs) Handles GVtaBDLC.PreRender
    If Convert.ToDateTime(TravelStarted) < Convert.ToDateTime("15/03/2019") Then
      If IsForeign Then
        With GVtaBDLC
          .Columns(2).Visible = False
          .Columns(3).HeaderText = "From Place"
          .Columns(4).HeaderText = "To Place"
          .Columns(5).HeaderText = "Date"
          .Columns(6).Visible = False
          .Columns(7).HeaderText = "Amount"
          .Columns(8).Visible = False
        End With
      Else
        With GVtaBDLC
          .Columns(2).Visible = False
          .Columns(6).Visible = False
          .Columns(7).HeaderText = "Amount"
          .Columns(8).Visible = False
          .Columns(9).Visible = False
          .Columns(11).Visible = False
          .Columns(12).HeaderText = "Airport Pick & Drop"
        End With
      End If
    Else
      If IsForeign Then
        With GVtaBDLC
          .Columns(2).Visible = False
          .Columns(3).HeaderText = "From Place"
          .Columns(4).HeaderText = "To Place"
          .Columns(5).HeaderText = "Date"
          .Columns(6).Visible = False
          .Columns(7).HeaderText = "Amount"
          .Columns(8).Visible = False
        End With
      Else
        With GVtaBDLC
          .Columns(9).Visible = False
          .Columns(11).Visible = False
          .Columns(12).HeaderText = "Airport Pick & Drop"
        End With
      End If
    End If
  End Sub
  Private Sub TBLtaBDLC_SaveClicked(sender As Object, e As ImageClickEventArgs) Handles TBLtaBDLC.SaveClicked
    Dim Calculate As Boolean = True
    With GVtaBDLC
      For Each r As GridViewRow In .Rows
        Dim x As SIS.TA.taBDLC = GetObjectFromRow(r)
        If (x.ModeLCID <> "" Or x.ModeText <> "") And (x.AmountRateOU > 0 Or x.AmountRate > 0) And x.FromAddress <> String.Empty And x.Date1Time <> String.Empty Then
          If x.ConversionFactorOU <= 0 Then x.ConversionFactorOU = 1
          x.TABillNo = F_TABillNo.Text
          x.SerialNo = 0
          Try
            SIS.TA.taBDLC.UZ_taBDLCInsert(x)
          Catch ex As Exception
            Dim str As String = New JavaScriptSerializer().Serialize(ex.Message)
            Dim script As String = String.Format("alert({0});", str)
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
            Calculate = False
            Exit For
          End Try
        End If
      Next
    End With
    If Calculate Then
      SIS.TA.taBH.ValidateTABill(F_TABillNo.Text)
      MyBase.Saved()
    End If
  End Sub
  Private Function GetObjectFromRow(ByVal r As GridViewRow) As SIS.TA.taBDLC
    On Error Resume Next
    Dim tmp As New SIS.TA.taBDLC
    tmp.TABillNo = CType(r.FindControl("F_TABillNo"), TextBox).Text
    tmp.SerialNo = CType(r.FindControl("F_SerialNo"), TextBox).Text
    tmp.ModeLCID = CType(r.FindControl("F_ModeLCID"), LC_taLCModes).SelectedValue
    tmp.ModeText = CType(r.FindControl("F_ModeText"), TextBox).Text
    tmp.City1ID = CType(r.FindControl("F_City1ID"), TextBox).Text
    tmp.City1Text = CType(r.FindControl("F_City1Text"), TextBox).Text
    tmp.FromAddress = CType(r.FindControl("F_FromAddress"), TextBox).Text
    tmp.ToAddress = CType(r.FindControl("F_ToAddress"), TextBox).Text
    tmp.Date1Time = CType(r.FindControl("F_Date1Time"), TextBox).Text
    tmp.Date2Time = CType(r.FindControl("F_Date2Time"), TextBox).Text
    tmp.AmountRate = CType(r.FindControl("F_AmountRate"), TextBox).Text
    tmp.AmountRateOU = CType(r.FindControl("F_AmountRateOU"), TextBox).Text
    tmp.StayedWithRelative = CType(r.FindControl("F_StayedWithRelative"), CheckBox).Checked
    tmp.StayedInGuestHouse = CType(r.FindControl("F_StayedInGuestHouse"), CheckBox).Checked
    tmp.StayedAtSite = CType(r.FindControl("F_StayedAtSite"), CheckBox).Checked
    tmp.CurrencyID = CType(r.FindControl("F_CurrencyID"), LC_taCurrencies).SelectedValue
    tmp.CurrencyMain = CType(r.FindControl("F_CurrencyMain"), TextBox).Text
    tmp.ConversionFactorOU = CType(r.FindControl("F_ConversionFactorOU"), TextBox).Text
    tmp.AirportToHotel = CType(r.FindControl("F_AirportToHotel"), CheckBox).Checked
    tmp.Remarks = CType(r.FindControl("F_Remarks"), TextBox).Text
    If tmp.ModeLCID = "" Then tmp.ModeLCID = 12
    Return tmp
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillDetails_City1ID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim City1ID As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taLCCitiesGetByID(City1ID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function City1IDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaLCCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function

End Class
