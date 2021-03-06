Partial Class AF_taCDExpense
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaCDExpense_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCDExpense.Init
    DataClassName = "AtaCDExpense"
    SetFormView = FVtaCDExpense
  End Sub
  Protected Sub TBLtaCDExpense_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCDExpense.Init
    SetToolBar = TBLtaCDExpense
  End Sub
  Protected Sub FVtaCDExpense_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCDExpense.DataBound
    SIS.TA.taCDExpense.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaCDExpense_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCDExpense.PreRender
    Dim oF_TABillNo_Display As Label  = FVtaCDExpense.FindControl("F_TABillNo_Display")
    oF_TABillNo_Display.Text = String.Empty
    If Not Session("F_TABillNo_Display") Is Nothing Then
      If Session("F_TABillNo_Display") <> String.Empty Then
        oF_TABillNo_Display.Text = Session("F_TABillNo_Display")
      End If
    End If
    Dim oF_TABillNo As TextBox  = FVtaCDExpense.FindControl("F_TABillNo")
    oF_TABillNo.Enabled = True
    oF_TABillNo.Text = String.Empty
    If Not Session("F_TABillNo") Is Nothing Then
      If Session("F_TABillNo") <> String.Empty Then
        oF_TABillNo.Text = Session("F_TABillNo")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taCDExpense.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCDExpense") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCDExpense", mStr)
    End If
    If Request.QueryString("TABillNo") IsNot Nothing Then
      CType(FVtaCDExpense.FindControl("F_TABillNo"), TextBox).Text = Request.QueryString("TABillNo")
      CType(FVtaCDExpense.FindControl("F_TABillNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaCDExpense.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaCDExpense.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
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
