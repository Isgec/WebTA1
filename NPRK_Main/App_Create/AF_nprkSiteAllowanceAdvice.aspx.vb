Partial Class AF_nprkSiteAllowanceAdvice
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkSiteAllowanceAdvice_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceAdvice.Init
    DataClassName = "AnprkSiteAllowanceAdvice"
    SetFormView = FVnprkSiteAllowanceAdvice
  End Sub
  Protected Sub TBLnprkSiteAllowanceAdvice_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSiteAllowanceAdvice.Init
    SetToolBar = TBLnprkSiteAllowanceAdvice
  End Sub
  Protected Sub ODSnprkSiteAllowanceAdvice_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkSiteAllowanceAdvice.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.NPRK.nprkSiteAllowanceAdvice = CType(e.ReturnValue,SIS.NPRK.nprkSiteAllowanceAdvice)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&FinYear=" & oDC.FinYear
      tmpURL &= "&Quarter=" & oDC.Quarter
      tmpURL &= "&AdviceNo=" & oDC.AdviceNo
      TBLnprkSiteAllowanceAdvice.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVnprkSiteAllowanceAdvice_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceAdvice.DataBound
    SIS.NPRK.nprkSiteAllowanceAdvice.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkSiteAllowanceAdvice_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceAdvice.PreRender
    Dim oF_FinYear_Display As Label  = FVnprkSiteAllowanceAdvice.FindControl("F_FinYear_Display")
    oF_FinYear_Display.Text = String.Empty
    If Not Session("F_FinYear_Display") Is Nothing Then
      If Session("F_FinYear_Display") <> String.Empty Then
        oF_FinYear_Display.Text = Session("F_FinYear_Display")
      End If
    End If
    Dim oF_FinYear As TextBox  = FVnprkSiteAllowanceAdvice.FindControl("F_FinYear")
    oF_FinYear.Enabled = True
    oF_FinYear.Text = String.Empty
    If Not Session("F_FinYear") Is Nothing Then
      If Session("F_FinYear") <> String.Empty Then
        oF_FinYear.Text = Session("F_FinYear")
      End If
    End If
    Dim oF_Quarter_Display As Label  = FVnprkSiteAllowanceAdvice.FindControl("F_Quarter_Display")
    oF_Quarter_Display.Text = String.Empty
    If Not Session("F_Quarter_Display") Is Nothing Then
      If Session("F_Quarter_Display") <> String.Empty Then
        oF_Quarter_Display.Text = Session("F_Quarter_Display")
      End If
    End If
    Dim oF_Quarter As TextBox  = FVnprkSiteAllowanceAdvice.FindControl("F_Quarter")
    oF_Quarter.Enabled = True
    oF_Quarter.Text = String.Empty
    If Not Session("F_Quarter") Is Nothing Then
      If Session("F_Quarter") <> String.Empty Then
        oF_Quarter.Text = Session("F_Quarter")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkSiteAllowanceAdvice.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkSiteAllowanceAdvice") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkSiteAllowanceAdvice", mStr)
    End If
    If Request.QueryString("FinYear") IsNot Nothing Then
      CType(FVnprkSiteAllowanceAdvice.FindControl("F_FinYear"), TextBox).Text = Request.QueryString("FinYear")
      CType(FVnprkSiteAllowanceAdvice.FindControl("F_FinYear"), TextBox).Enabled = False
    End If
    If Request.QueryString("Quarter") IsNot Nothing Then
      CType(FVnprkSiteAllowanceAdvice.FindControl("F_Quarter"), TextBox).Text = Request.QueryString("Quarter")
      CType(FVnprkSiteAllowanceAdvice.FindControl("F_Quarter"), TextBox).Enabled = False
    End If
    If Request.QueryString("AdviceNo") IsNot Nothing Then
      CType(FVnprkSiteAllowanceAdvice.FindControl("F_AdviceNo"), TextBox).Text = Request.QueryString("AdviceNo")
      CType(FVnprkSiteAllowanceAdvice.FindControl("F_AdviceNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FinYearCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costFinYear.SelectcostFinYearAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function QuarterCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costQuarters.SelectcostQuartersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PRK_SiteAllowanceAdvice_FinYear(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim FinYear As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.COST.costFinYear = SIS.COST.costFinYear.costFinYearGetByID(FinYear)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PRK_SiteAllowanceAdvice_Quarter(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim Quarter As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.COST.costQuarters = SIS.COST.costQuarters.costQuartersGetByID(Quarter)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
