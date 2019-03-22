Partial Class AF_taD_LCRates
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaD_LCRates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_LCRates.Init
    DataClassName = "AtaD_LCRates"
    SetFormView = FVtaD_LCRates
  End Sub
  Protected Sub TBLtaD_LCRates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_LCRates.Init
    SetToolBar = TBLtaD_LCRates
  End Sub
  Protected Sub FVtaD_LCRates_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_LCRates.DataBound
    SIS.TA.taD_LCRates.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaD_LCRates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_LCRates.PreRender
    Dim oF_CityID_Display As Label  = FVtaD_LCRates.FindControl("F_CityID_Display")
    Dim oF_CityID As TextBox  = FVtaD_LCRates.FindControl("F_CityID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taD_LCRates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_LCRates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_LCRates", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaD_LCRates.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaD_LCRates.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CityIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaLCCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_D_LCRates_CityID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim CityID As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taLCCitiesGetByID(CityID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
