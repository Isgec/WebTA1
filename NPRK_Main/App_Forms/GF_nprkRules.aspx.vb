Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.IO
Partial Class GF_nprkRules
  Inherits SIS.SYS.GridBase
  Public ReadOnly Property GetDownloadLink() As String
    Get
      Return "window.open('" & Server.MapPath("~/NPRK_Main/App_Downloads/PrkRule.aspx") & "', 'win9', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
    End Get
  End Property


  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkRules.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl & "?RuleID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkRules_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkRules.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RuleID As Int32 = GVnprkRules.DataKeys(e.CommandArgument).Values("RuleID")
        Dim RedirectUrl As String = TBLnprkRules.EditUrl & "?RuleID=" & RuleID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkRules_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkRules.Init
    DataClassName = "GnprkRules"
    SetGridView = GVnprkRules
  End Sub
  Protected Sub TBLnprkRules_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkRules.Init
    SetToolBar = TBLnprkRules
  End Sub
  Protected Sub F_PerkID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_PerkID.SelectedIndexChanged
    Session("F_PerkID") = F_PerkID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_CategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CategoryID.SelectedIndexChanged
    Session("F_CategoryID") = F_CategoryID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_PerkID.SelectedValue = String.Empty
    If Not Session("F_PerkID") Is Nothing Then
      If Session("F_PerkID") <> String.Empty Then
        F_PerkID.SelectedValue = Session("F_PerkID")
      End If
    End If
    F_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        F_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
  End Sub
  Private st As Long = HttpContext.Current.Server.ScriptTimeout

  Private Sub cmdTmplUpload_Click(sender As Object, e As EventArgs) Handles cmdTmplUpload.Click
    If IsUploaded.Value <> "YES" Then Exit Sub
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    IsUploaded.Value = ""
    Try
      With F_FileUpload
        If .HasFile Then
          Dim tmpPath As String = Server.MapPath("~/../App_Temp")
          Dim tmpName As String = IO.Path.GetRandomFileName()
          Dim tmpFile As String = tmpPath & "\\" & tmpName
          .SaveAs(tmpFile)
          Dim fi As FileInfo = New FileInfo(tmpFile)
          Dim IsError As Boolean = False
          Dim ErrMsg As String = ""
          Using xlP As ExcelPackage = New ExcelPackage(fi)
            Dim wsD As ExcelWorksheet = Nothing
            Try
              wsD = xlP.Workbook.Worksheets("Data")
            Catch ex As Exception
              wsD = Nothing
            End Try
            '1. Process Document
            If wsD Is Nothing Then
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Invalid XL File") & "');", True)
              xlP.Dispose()
              HttpContext.Current.Server.ScriptTimeout = st
              Exit Sub
            End If
            Dim xlStart As Integer = 25
            For I As Integer = xlStart To 99999
              Dim PerkDescription As String = wsD.Cells(I, 2).Text
              If PerkDescription = "" Then Exit For
              Dim tmp As SIS.NPRK.nprkRules = Nothing
              Dim RuleID As String = wsD.Cells(I, 1).Text
              If RuleID = "" Then RuleID = "0"
              If RuleID = "0" Then
                tmp = New SIS.NPRK.nprkRules
              Else
                If Not IsNumeric(RuleID) Then
                  IsError = True
                  ErrMsg = " At Line: " & I & ", Invalid Rule ID."
                  Exit For
                End If
                tmp = SIS.NPRK.nprkRules.nprkRulesGetByID(RuleID)
              End If
              If tmp Is Nothing Then
                IsError = True
                ErrMsg = " At Line: " & I & ", Rule ID Not Found."
                Exit For
              End If
              Dim xPerk As SIS.NPRK.nprkPerks = SIS.NPRK.nprkPerks.nprkPerksGetByDescription(PerkDescription)
              If xPerk Is Nothing Then
                IsError = True
                ErrMsg = " At Line: " & I & ", Invalid Perk ID."
                Exit For
              End If
              Dim xCategory As SIS.NPRK.nprkCategories = SIS.NPRK.nprkCategories.nprkCategoriesGetByDescription(wsD.Cells(I, 3).Text)
              If xCategory Is Nothing Then
                IsError = True
                ErrMsg = " At Line: " & I & ", Invalid Category ID."
                Exit For
              End If
              Dim xDate As String = wsD.Cells(I, 4).Text
              If xDate = "" Then
                IsError = True
                ErrMsg = " At Line: " & I & ", Invalid Effective Date"
                Exit For
              End If
              If Not IsDate(xDate) Then
                IsError = True
                ErrMsg = " At Line: " & I & ", Invalid Effective Date"
                Exit For
              End If
              Dim xPOB As String = wsD.Cells(I, 5).Text
              Dim POB As Boolean = False
              Select Case xPOB.ToLower
                Case "yes", "y"
                  POB = True
                Case "no", "n"
                  POB = False
                Case Else
                  IsError = True
                  ErrMsg = " At Line: " & I & ", Invalid Percentage of Basic. [YES/NO/Y/N/yes/no/y/n]"
                  Exit For
              End Select
              Dim xPer As String = wsD.Cells(I, 6).Text
              If xPer = "" Then xPer = 0
              If POB Then
                If Not IsNumeric(xPer) Then
                  IsError = True
                  ErrMsg = " At Line: " & I & ", Invalid Percent value."
                  Exit For
                End If
                If Convert.ToDecimal(xPer) < 0 Or Convert.ToDecimal(xPer) > 100 Then
                  IsError = True
                  ErrMsg = " At Line: " & I & ", Invalid Percent value. [0 - 100]"
                  Exit For
                End If
              End If
              Dim xFixed As String = wsD.Cells(I, 7).Text
              If xFixed = "" Then xFixed = 0
              If Not POB Then
                If Not IsNumeric(xFixed) Then
                  IsError = True
                  ErrMsg = " At Line: " & I & ", Invalid Fixed value."
                  Exit For
                End If
                If Convert.ToDecimal(xFixed) < 0 Then
                  IsError = True
                  ErrMsg = " At Line: " & I & ", Invalid Fixed value. [ >= 0]"
                  Exit For
                End If
              End If
              Dim xPosted As String = wsD.Cells(I, 8).Text
              Select Case xPosted.ToLower
                Case "none", "office", "site"
                Case Else
                  IsError = True
                  ErrMsg = " At Line: " & I & ", Invalid Posted At. [None, Office, Site]"
                  Exit For
              End Select
              Dim xVehicle As String = wsD.Cells(I, 9).Text
              Select Case xVehicle.ToLower
                Case "none", "car", "twowheeler"
                Case Else
                  IsError = True
                  ErrMsg = " At Line: " & I & ", Invalid Vehicle type. [None, Car, TwoWheeler]"
                  Exit For
              End Select
              Dim xInSal As String = wsD.Cells(I, 10).Text
              Dim InSal As Boolean = False
              Select Case xInSal.ToLower
                Case "yes", "y"
                  InSal = True
                Case "no", "n"
                  InSal = False
                Case Else
                  IsError = True
                  ErrMsg = " At Line: " & I & ", Invalid In Salary Value. [YES/NO/Y/N/yes/no/y/n]"
                  Exit For
              End Select
              Dim xWithDriver As String = wsD.Cells(I, 11).Text
              Dim WithDriver As Boolean = False
              Select Case xWithDriver.ToLower
                Case "yes", "y"
                  WithDriver = True
                Case "no", "n"
                  WithDriver = False
                Case Else
                  IsError = True
                  ErrMsg = " At Line: " & I & ", Invalid With driver Value. [YES/NO/Y/N/yes/no/y/n]"
                  Exit For
              End Select
              Dim xAddVal As String = wsD.Cells(I, 12).Text
              If xAddVal = "" Then xAddVal = "0"
              If Not IsNumeric(xAddVal) Then
                IsError = True
                ErrMsg = " At Line: " & I & ", Invalid Additional value."
                Exit For
              End If
              If Convert.ToDecimal(xAddVal) < 0 Then
                IsError = True
                ErrMsg = " At Line: " & I & ", Invalid Additional value. [ >= 0]"
                Exit For
              End If
            Next
            '=======Actual Insert / Update If NO Error========
            If Not IsError Then
              For I As Integer = xlStart To 99999
                Dim RuleID As String = wsD.Cells(I, 1).Text
                Dim PerkDescription As String = wsD.Cells(I, 2).Text
                If PerkDescription = "" Then Exit For
                Dim tmp As SIS.NPRK.nprkRules = Nothing
                If RuleID = "" Then
                  tmp = New SIS.NPRK.nprkRules
                Else
                  tmp = SIS.NPRK.nprkRules.nprkRulesGetByID(RuleID)
                End If
                If tmp Is Nothing Then Continue For
                Dim xPerk As SIS.NPRK.nprkPerks = SIS.NPRK.nprkPerks.nprkPerksGetByDescription(PerkDescription)
                Dim xCategory As SIS.NPRK.nprkCategories = SIS.NPRK.nprkCategories.nprkCategoriesGetByDescription(wsD.Cells(I, 3).Text)
                Dim xDate As String = wsD.Cells(I, 4).Text
                Dim xPOB As String = wsD.Cells(I, 5).Text
                Dim POB As Boolean = False
                Select Case xPOB.ToLower
                  Case "yes", "y"
                    POB = True
                  Case "no", "n"
                    POB = False
                End Select
                Dim xPer As String = wsD.Cells(I, 6).Text
                If xPer = "" Then xPer = 0
                Dim xFixed As String = wsD.Cells(I, 7).Text
                If xFixed = "" Then xFixed = 0
                Dim xPosted As String = wsD.Cells(I, 8).Text
                Dim xVehicle As String = wsD.Cells(I, 9).Text
                Dim xInSal As String = wsD.Cells(I, 10).Text
                Dim InSal As Boolean = False
                Select Case xInSal.ToLower
                  Case "yes", "y"
                    InSal = True
                  Case "no", "n"
                    InSal = False
                End Select
                Dim xWithDriver As String = wsD.Cells(I, 11).Text
                Dim WithDriver As Boolean = False
                Select Case xWithDriver.ToLower
                  Case "yes", "y"
                    WithDriver = True
                  Case "no", "n"
                    WithDriver = False
                End Select
                Dim xAddVal As String = wsD.Cells(I, 12).Text
                If xAddVal = "" Then xAddVal = "0"
                With tmp
                  .PerkID = xPerk.PerkID
                  .CategoryID = xCategory.CategoryID
                  .EffectiveDate = xDate
                  .PercentageOfBasic = POB
                  .Percentage = xPer
                  .FixedValue = xFixed
                  .PostedAt = xPosted
                  .VehicleType = xVehicle
                  .InSalary = InSal
                  .WithDriver = WithDriver
                  .AdditionalValue = xAddVal
                End With
                If tmp.RuleID = 0 Then
                  Try
                    SIS.NPRK.nprkRules.InsertData(tmp)
                  Catch ex As Exception
                    IsError = True
                    ErrMsg = " At Line: " & I & ", INSERT ERROR [Download Fresh File to compare before Re-Upload]"
                    Exit For
                  End Try
                Else
                  Try
                    SIS.NPRK.nprkRules.UpdateData(tmp)
                  Catch ex As Exception
                    IsError = True
                    ErrMsg = " At Line: " & I & ", UPDATE ERROR [Download Fresh File to compare before Re-Upload]"
                    Exit For
                  End Try
                End If
              Next
            End If
            '==========End of Update==========
            xlP.Dispose()
            If IsError Then
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ErrMsg) & "');", True)
            Else
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Updated") & "');", True)
            End If
          End Using
        End If
      End With
    Catch ex As Exception
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
    End Try
    HttpContext.Current.Server.ScriptTimeout = st
  End Sub

  Private Sub GF_nprkRules_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    cmdDownload.OnClientClick = "window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/NPRK_Main/App_Downloads/PrkRule.aspx" & "', 'win9', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
  End Sub
End Class
