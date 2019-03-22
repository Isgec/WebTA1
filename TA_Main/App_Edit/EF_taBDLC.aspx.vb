Partial Class EF_taBDLC
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
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
  Private oTABH As SIS.TA.taBH = Nothing
  Protected Sub ODStaBDLC_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaBDLC.Selected
    Dim tmp As SIS.TA.taBDLC = CType(e.ReturnValue, SIS.TA.taBDLC)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    oTABH = tmp.FK_TA_BillDetails_TABillNo
    Select Case oTABH.TravelTypeID
      Case TATravelTypeValues.Domestic, TATravelTypeValues.HomeVisit
        IsForeign = False
      Case TATravelTypeValues.ForeignSiteVisit, TATravelTypeValues.ForeignTravel
        IsForeign = True
    End Select
    If oTABH.StartDateTime = "" Then
      TravelStarted = Now.ToString("dd/MM/yyyy")
    Else
      TravelStarted = oTABH.StartDateTime
    End If
  End Sub
  Protected Sub FVtaBDLC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDLC.Init
    DataClassName = "EtaBDLC"
    SetFormView = FVtaBDLC
  End Sub
  Protected Sub TBLtaBDLC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDLC.Init
    SetToolBar = TBLtaBDLC
  End Sub

  Protected Sub FVtaBDLC_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDLC.PreRender
    TBLtaBDLC.EnableSave = Editable
    TBLtaBDLC.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taBDLC.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBDLC") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBDLC", mStr)
    End If
    If Convert.ToDateTime(TravelStarted) < Convert.ToDateTime("15/03/2019") Then
      CType(FVtaBDLC.FindControl("opt2"), HtmlTableRow).Style("display") = "none"
      CType(FVtaBDLC.FindControl("F_CurrencyMain"), TextBox).Text = oTABH.BillCurrencyID
      If Not IsForeign Then
        CType(FVtaBDLC.FindControl("L_AirportToHotel"), Label).Text = "Airport Pick & Drop :"
        CType(FVtaBDLC.FindControl("F_CurrencyID"), LC_taCurrencies).Enabled = False
        CType(FVtaBDLC.FindControl("F_CurrencyID"), LC_taCurrencies).CssClass = ""
        CType(FVtaBDLC.FindControl("F_ConversionFactorINR"), TextBox).Enabled = False
        CType(FVtaBDLC.FindControl("F_ConversionFactorINR"), TextBox).CssClass = ""
        CType(FVtaBDLC.FindControl("F_ConversionFactorOU"), TextBox).Enabled = False
        CType(FVtaBDLC.FindControl("F_ConversionFactorOU"), TextBox).CssClass = ""
      End If
      Dim x As LC_taLCModes = CType(FVtaBDLC.Row.FindControl("F_ModeLCID"), LC_taLCModes)
      RemoveHandler x.GetDropDown.SelectedIndexChanged, AddressOf DDLChanged
      x.AutoPostBack = False
    Else
      If IsForeign Then
        Dim x As LC_taLCModes = CType(FVtaBDLC.Row.FindControl("F_ModeLCID"), LC_taLCModes)
        RemoveHandler x.GetDropDown.SelectedIndexChanged, AddressOf DDLChanged
        x.AutoPostBack = False
        CType(FVtaBDLC.FindControl("opt2"), HtmlTableRow).Style("display") = "none"
      Else
        CType(FVtaBDLC.FindControl("L_AirportToHotel"), Label).Text = "Airport Pick & Drop :"
        Dim DDL As LC_taLCModes = CType(FVtaBDLC.FindControl("F_ModeLCID"), LC_taLCModes)
        Dim xTmp As String = DDL.SelectedValue
        Select Case xTmp
          Case "1", "2", "3", "11" '1,2,3=Taxi | 11=OwnCar
            CType(FVtaBDLC.FindControl("F_AmountRateOU"), TextBox).Enabled = True
            CType(FVtaBDLC.FindControl("F_AmountRateOU"), TextBox).CssClass = "mytxt"
            CType(FVtaBDLC.FindControl("F_AmountRate"), TextBox).Enabled = True
            CType(FVtaBDLC.FindControl("F_AmountRate"), TextBox).CssClass = "mytxt"

            CType(FVtaBDLC.FindControl("F_Date2Time"), TextBox).Enabled = True
            CType(FVtaBDLC.FindControl("F_Date2Time"), TextBox).CssClass = "mytxt"
            CType(FVtaBDLC.FindControl("CEDate2Time"), AjaxControlToolkit.CalendarExtender).Enabled = True
            CType(FVtaBDLC.FindControl("MEVDate2Time"), AjaxControlToolkit.MaskedEditValidator).Enabled = True
            CType(FVtaBDLC.FindControl("F_City1ID"), TextBox).Enabled = True
            CType(FVtaBDLC.FindControl("F_City1ID"), TextBox).CssClass = "mytxt"

            CType(FVtaBDLC.FindControl("F_City1Text"), TextBox).Enabled = True
            CType(FVtaBDLC.FindControl("F_City1Text"), TextBox).CssClass = "mypktxt"

            CType(FVtaBDLC.FindControl("opt2"), HtmlTableRow).Style("display") = "none"

          Case "4", "8" ' Three Wheeler
            CType(FVtaBDLC.FindControl("F_AmountRateOU"), TextBox).Enabled = False
            CType(FVtaBDLC.FindControl("F_AmountRateOU"), TextBox).CssClass = ""
            CType(FVtaBDLC.FindControl("F_AmountRate"), TextBox).Enabled = True
            CType(FVtaBDLC.FindControl("F_AmountRate"), TextBox).CssClass = "mytxt"

            CType(FVtaBDLC.FindControl("F_Date2Time"), TextBox).Enabled = True
            CType(FVtaBDLC.FindControl("F_Date2Time"), TextBox).CssClass = "mytxt"
            CType(FVtaBDLC.FindControl("CEDate2Time"), AjaxControlToolkit.CalendarExtender).Enabled = True
            CType(FVtaBDLC.FindControl("MEVDate2Time"), AjaxControlToolkit.MaskedEditValidator).Enabled = True
            CType(FVtaBDLC.FindControl("F_City1ID"), TextBox).Enabled = True
            CType(FVtaBDLC.FindControl("F_City1ID"), TextBox).CssClass = "mytxt"
            CType(FVtaBDLC.FindControl("F_City1Text"), TextBox).Enabled = True
            CType(FVtaBDLC.FindControl("F_City1Text"), TextBox).CssClass = "mypktxt"

            CType(FVtaBDLC.FindControl("opt2"), HtmlTableRow).Style("display") = "inlineblock"
          Case Else
            CType(FVtaBDLC.FindControl("F_AmountRateOU"), TextBox).Enabled = True
            CType(FVtaBDLC.FindControl("F_AmountRateOU"), TextBox).CssClass = "mytxt"
            CType(FVtaBDLC.FindControl("F_AmountRate"), TextBox).Enabled = False
            CType(FVtaBDLC.FindControl("F_AmountRate"), TextBox).CssClass = ""

            CType(FVtaBDLC.FindControl("F_Date2Time"), TextBox).Enabled = False
            CType(FVtaBDLC.FindControl("F_Date2Time"), TextBox).CssClass = ""
            CType(FVtaBDLC.FindControl("CEDate2Time"), AjaxControlToolkit.CalendarExtender).Enabled = False
            CType(FVtaBDLC.FindControl("MEVDate2Time"), AjaxControlToolkit.MaskedEditValidator).Enabled = False
            CType(FVtaBDLC.FindControl("F_City1ID"), TextBox).Enabled = False
            CType(FVtaBDLC.FindControl("F_City1ID"), TextBox).CssClass = ""
            CType(FVtaBDLC.FindControl("F_City1Text"), TextBox).Enabled = False
            CType(FVtaBDLC.FindControl("F_City1Text"), TextBox).CssClass = ""

            CType(FVtaBDLC.FindControl("opt2"), HtmlTableRow).Style("display") = "none"

        End Select

      End If

    End If

  End Sub
  Public Sub DDLChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    'Dim DDL As LC_taLCModes = CType(FVtaBDLC.FindControl("F_ModeLCID"), LC_taLCModes)
    'Dim xTmp As String = DDL.SelectedValue
    'Select Case xTmp
    '  Case "1", "2", "3", "11" '1,2,3=Taxi | 11=OwnCar
    '    CType(FVtaBDLC.FindControl("F_AmountRateOU"), TextBox).Enabled = True
    '    CType(FVtaBDLC.FindControl("F_AmountRateOU"), TextBox).CssClass = "mytxt"
    '    CType(FVtaBDLC.FindControl("F_AmountRate"), TextBox).Enabled = True
    '    CType(FVtaBDLC.FindControl("F_AmountRate"), TextBox).CssClass = "mytxt"
    '  Case "4", "8" ' Three Wheeler
    '    CType(FVtaBDLC.FindControl("F_AmountRateOU"), TextBox).Enabled = False
    '    CType(FVtaBDLC.FindControl("F_AmountRateOU"), TextBox).CssClass = ""
    '    CType(FVtaBDLC.FindControl("F_AmountRate"), TextBox).Enabled = True
    '    CType(FVtaBDLC.FindControl("F_AmountRate"), TextBox).CssClass = "mytxt"
    '  Case Else
    '    CType(FVtaBDLC.FindControl("F_AmountRateOU"), TextBox).Enabled = True
    '    CType(FVtaBDLC.FindControl("F_AmountRateOU"), TextBox).CssClass = "mytxt"
    '    CType(FVtaBDLC.FindControl("F_AmountRate"), TextBox).Enabled = False
    '    CType(FVtaBDLC.FindControl("F_AmountRate"), TextBox).CssClass = ""
    '    CType(FVtaBDLC.FindControl("RVF_AmountRate"), RangeValidator).Enabled = False
    'End Select
    'If IsForeign Then
    '  CType(FVtaBDLC.FindControl("F_Date2Time"), TextBox).Enabled = False
    '  CType(FVtaBDLC.FindControl("F_Date2Time"), TextBox).CssClass = ""
    '  CType(FVtaBDLC.FindControl("CEDate2Time"), AjaxControlToolkit.CalendarExtender).Enabled = False
    '  CType(FVtaBDLC.FindControl("MEVDate2Time"), AjaxControlToolkit.MaskedEditValidator).Enabled = False
    'Else
    '  Select Case xTmp
    '    Case "1", "2", "3", "4","8", "11" '1,2,3=Taxi | 4=Three Wheeler | 11=OwnCar
    '      CType(FVtaBDLC.FindControl("F_Date2Time"), TextBox).Enabled = True
    '      CType(FVtaBDLC.FindControl("F_Date2Time"), TextBox).CssClass = "mytxt"
    '      CType(FVtaBDLC.FindControl("CEDate2Time"), AjaxControlToolkit.CalendarExtender).Enabled = True
    '      CType(FVtaBDLC.FindControl("MEVDate2Time"), AjaxControlToolkit.MaskedEditValidator).Enabled = True
    '      CType(FVtaBDLC.FindControl("F_City1ID"), TextBox).Enabled = True
    '      CType(FVtaBDLC.FindControl("F_City1ID"), TextBox).CssClass = "mytxt"
    '      CType(FVtaBDLC.FindControl("F_City1Text"), TextBox).Enabled = True
    '      CType(FVtaBDLC.FindControl("F_City1Text"), TextBox).CssClass = "mypktxt"
    '    Case Else
    '      CType(FVtaBDLC.FindControl("F_Date2Time"), TextBox).Enabled = False
    '      CType(FVtaBDLC.FindControl("F_Date2Time"), TextBox).CssClass = ""
    '      CType(FVtaBDLC.FindControl("CEDate2Time"), AjaxControlToolkit.CalendarExtender).Enabled = False
    '      CType(FVtaBDLC.FindControl("MEVDate2Time"), AjaxControlToolkit.MaskedEditValidator).Enabled = False
    '      CType(FVtaBDLC.FindControl("F_City1ID"), TextBox).Enabled = False
    '      CType(FVtaBDLC.FindControl("F_City1ID"), TextBox).CssClass = ""
    '      CType(FVtaBDLC.FindControl("F_City1Text"), TextBox).Enabled = False
    '      CType(FVtaBDLC.FindControl("F_City1Text"), TextBox).CssClass = ""
    '  End Select
    'End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillDetails_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
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
