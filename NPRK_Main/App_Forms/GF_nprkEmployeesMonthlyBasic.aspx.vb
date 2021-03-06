Partial Class GF_nprkEmployeesMonthlyBasic
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkEmployeesMonthlyBasic.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl & "?RecordID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkEmployeesMonthlyBasic_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkEmployeesMonthlyBasic.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RecordID As Int32 = GVnprkEmployeesMonthlyBasic.DataKeys(e.CommandArgument).Values("RecordID")
        Dim RedirectUrl As String = TBLnprkEmployeesMonthlyBasic.EditUrl & "?RecordID=" & RecordID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkEmployeesMonthlyBasic_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkEmployeesMonthlyBasic.Init
    DataClassName = "GnprkEmployeesMonthlyBasic"
    SetGridView = GVnprkEmployeesMonthlyBasic
  End Sub
  Protected Sub TBLnprkEmployeesMonthlyBasic_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkEmployeesMonthlyBasic.Init
    SetToolBar = TBLnprkEmployeesMonthlyBasic
  End Sub
  Protected Sub F_EmployeeID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_EmployeeID.TextChanged
    Session("F_EmployeeID") = F_EmployeeID.Text
    Session("F_EmployeeID_Display") = F_EmployeeID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function EmployeeIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.NPRK.nprkEmployees.SelectnprkEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_EmployeeID_Display.Text = String.Empty
    If Not Session("F_EmployeeID_Display") Is Nothing Then
      If Session("F_EmployeeID_Display") <> String.Empty Then
        F_EmployeeID_Display.Text = Session("F_EmployeeID_Display")
      End If
    End If
    F_EmployeeID.Text = String.Empty
    If Not Session("F_EmployeeID") Is Nothing Then
      If Session("F_EmployeeID") <> String.Empty Then
        F_EmployeeID.Text = Session("F_EmployeeID")
      End If
    End If
    Dim strScriptEmployeeID As String = "<script type=""text/javascript""> " &
      "function ACEEmployeeID_Selected(sender, e) {" &
      "  var F_EmployeeID = $get('" & F_EmployeeID.ClientID & "');" &
      "  var F_EmployeeID_Display = $get('" & F_EmployeeID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_EmployeeID.value = p[0];" &
      "  F_EmployeeID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EmployeeID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EmployeeID", strScriptEmployeeID)
    End If
    Dim strScriptPopulatingEmployeeID As String = "<script type=""text/javascript""> " &
      "function ACEEmployeeID_Populating(o,e) {" &
      "  var p = $get('" & F_EmployeeID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEEmployeeID_Populated(o,e) {" &
      "  var p = $get('" & F_EmployeeID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EmployeeIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EmployeeIDPopulating", strScriptPopulatingEmployeeID)
    End If
    Dim validateScriptEmployeeID As String = "<script type=""text/javascript"">" &
      "  function validate_EmployeeID(o) {" &
      "    validated_FK_PRK_EmployeesMonthlyBasic_PRK_Employees_main = true;" &
      "    validate_FK_PRK_EmployeesMonthlyBasic_PRK_Employees(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateEmployeeID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateEmployeeID", validateScriptEmployeeID)
    End If
    Dim validateScriptFK_PRK_EmployeesMonthlyBasic_PRK_Employees As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PRK_EmployeesMonthlyBasic_PRK_Employees(o) {" &
      "    var value = o.id;" &
      "    var EmployeeID = $get('" & F_EmployeeID.ClientID & "');" &
      "    try{" &
      "    if(EmployeeID.value==''){" &
      "      if(validated_FK_PRK_EmployeesMonthlyBasic_PRK_Employees.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + EmployeeID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PRK_EmployeesMonthlyBasic_PRK_Employees(value, validated_FK_PRK_EmployeesMonthlyBasic_PRK_Employees);" &
      "  }" &
      "  validated_FK_PRK_EmployeesMonthlyBasic_PRK_Employees_main = false;" &
      "  function validated_FK_PRK_EmployeesMonthlyBasic_PRK_Employees(result) {" &
      "    var p = result.split('|');" &
      "    var o = $get(p[1]);" &
      "    var o_d = $get(p[1]+'_Display');" &
      "    try{o_d.innerHTML = p[2];}catch(ex){}" &
      "    o.style.backgroundImage  = 'none';" &
      "    if(p[0]=='1'){" &
      "      o.value='';" &
      "      try{o_d.innerHTML = '';}catch(ex){}" &
      "      __doPostBack(o.id, o.value);" &
      "    }" &
      "    else" &
      "      __doPostBack(o.id, o.value);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PRK_EmployeesMonthlyBasic_PRK_Employees") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PRK_EmployeesMonthlyBasic_PRK_Employees", validateScriptFK_PRK_EmployeesMonthlyBasic_PRK_Employees)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PRK_EmployeesMonthlyBasic_PRK_Employees(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim EmployeeID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.NPRK.nprkEmployees = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(EmployeeID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  Protected Sub cmdImport_Basic(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim oBut As Button = CType(sender, Button)
    SIS.NPRK.nprkEmployeesMonthlyBasic.UpdateFASBasic(oBut.CommandArgument, F_UpdateEmp.Checked)
    GVnprkEmployeesMonthlyBasic.DataBind()
  End Sub
End Class
