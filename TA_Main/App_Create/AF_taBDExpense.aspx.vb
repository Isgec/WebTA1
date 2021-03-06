Partial Class AF_taBDExpense
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaBDExpense_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDExpense.Init
    DataClassName = "AtaBDExpense"
    SetFormView = FVtaBDExpense
  End Sub
  Protected Sub TBLtaBDExpense_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDExpense.Init
    SetToolBar = TBLtaBDExpense
  End Sub
  Protected Sub FVtaBDExpense_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDExpense.DataBound
    SIS.TA.taBDExpense.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaBDExpense_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDExpense.PreRender
    Dim oF_TABillNo_Display As Label  = FVtaBDExpense.FindControl("F_TABillNo_Display")
    oF_TABillNo_Display.Text = String.Empty
    If Not Session("F_TABillNo_Display") Is Nothing Then
      If Session("F_TABillNo_Display") <> String.Empty Then
        oF_TABillNo_Display.Text = Session("F_TABillNo_Display")
      End If
    End If
    Dim oF_TABillNo As TextBox  = FVtaBDExpense.FindControl("F_TABillNo")
    oF_TABillNo.Enabled = True
    oF_TABillNo.Text = String.Empty
    If Not Session("F_TABillNo") Is Nothing Then
      If Session("F_TABillNo") <> String.Empty Then
        oF_TABillNo.Text = Session("F_TABillNo")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taBDExpense.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBDExpense") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBDExpense", mStr)
    End If
    If Request.QueryString("TABillNo") IsNot Nothing Then
      CType(FVtaBDExpense.FindControl("F_TABillNo"), TextBox).Text = Request.QueryString("TABillNo")
      CType(FVtaBDExpense.FindControl("F_TABillNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaBDExpense.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaBDExpense.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
    Try
      Dim tmp As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(Request.QueryString("TABillNo"))
      Dim tmp1 As LC_taCurrencies = CType(FVtaBDExpense.FindControl("F_CurrencyID"), LC_taCurrencies)
      Dim tmp2 As Label = CType(FVtaBDExpense.FindControl("F_CurrencyMain"), Label)
      tmp1.SelectedValue = tmp.BillCurrencyID
      tmp2.Text = tmp.BillCurrencyID
      If tmp.TravelTypeID = TATravelTypeValues.Domestic Then
        Dim tmp3 As Label = CType(FVtaBDExpense.FindControl("L_CurrencyID"), Label)
        Dim tmp4 As HtmlTableRow = CType(FVtaBDExpense.FindControl("ouc"), HtmlTableRow)
        Dim tmp5 As TextBox = CType(FVtaBDExpense.FindControl("F_ConversionFactorINR"), TextBox)
        tmp1.Enabled = False
        tmp3.Attributes.Add("style", "display:none")
        tmp4.Attributes.Add("style", "display:none")
        tmp5.Enabled = False
      End If
    Catch ex As Exception

    End Try
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TABillNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taBH.SelecttaBHAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_BillDetails_TABillNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TABillNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
