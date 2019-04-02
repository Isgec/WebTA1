Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization

Partial Class PrkRule
  Inherits System.Web.UI.Page
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Private QCRequired As Boolean = False
  Private PortRequired As Boolean = False
  Private AllowNegativeBalance As Boolean = False
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    DownloadTmplPrkRule()
  End Sub

#Region " TMPL FOR PRK RULE "


  Private Sub DownloadTmplPrkRule()

    Dim TemplateName As String = "PRK_RuleTemplate.xlsx"

    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
    If IO.File.Exists(tmpFile) Then
      Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
      IO.File.Copy(tmpFile, FileName)
      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Data")
      Dim r As Integer = 25
      Dim c As Integer = 1


      r = 25
      c = 1
      Dim Rules As List(Of SIS.NPRK.nprkRules) = SIS.NPRK.nprkRules.nprkRulesSelectList(0, 99999, "RuleID", False, "", 0, 0)

      For Each tmp As SIS.NPRK.nprkRules In Rules
        With xlWS
          c = 1
          .Cells(r, c).Value = tmp.RuleID
          c += 1
          .Cells(r, c).Value = tmp.PRK_Perks2_Description
          c += 1
          .Cells(r, c).Value = tmp.PRK_Categories1_Description
          c += 1
          .Cells(r, c).Value = Convert.ToDateTime(tmp.EffectiveDate).ToString("dd/MM/yyyy")
          c += 1
          .Cells(r, c).Value = IIf(tmp.PercentageOfBasic, "YES", "NO")
          c += 1
          .Cells(r, c).Value = tmp.Percentage
          c += 1
          .Cells(r, c).Value = tmp.FixedValue
          c += 1
          .Cells(r, c).Value = tmp.PostedAt
          c += 1
          .Cells(r, c).Value = tmp.VehicleType
          c += 1
          .Cells(r, c).Value = IIf(tmp.InSalary, "YES", "NO")
          c += 1
          .Cells(r, c).Value = IIf(tmp.WithDriver, "YES", "NO")
          c += 1
          .Cells(r, c).Value = tmp.AdditionalValue
          c += 1

          r += 1
        End With

      Next

      xlPk.Save()
      xlPk.Dispose()

      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=PerkRule_" & Now.Year & "_" & Now.Day & ".xlsx")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
      Response.WriteFile(FileName)
      HttpContext.Current.Server.ScriptTimeout = st
      Response.End()
    End If
  End Sub

#End Region




End Class
