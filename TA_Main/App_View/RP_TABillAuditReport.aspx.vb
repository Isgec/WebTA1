Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class RP_TABillAuditReport
  Inherits SIS.SYS.GridBase
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Protected Sub TBLtaCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCountries.Init
    SetToolBar = TBLtaCountries
  End Sub

  Private Sub cmdGenerate_Click(sender As Object, e As EventArgs) Handles cmdGenerate.Click
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim fdt As String = Now.AddDays(-30).ToString("dd/MM/yyyy")
    Dim tdt As String = Now.ToString("dd/MM/yyyy")
    Try
      fdt = Convert.ToDateTime(F_fDt.Text).ToString("dd/MM/yyyy")
      Try
        tdt = Convert.ToDateTime(F_tDt.Text).ToString("dd/MM/yyyy")
      Catch ex As Exception
        tdt = Now.ToString("dd/MM/yyyy")
      End Try
    Catch ex As Exception
      HttpContext.Current.Server.ScriptTimeout = st
      Exit Sub
    End Try

    Dim FileName As String = CreateReport(fdt, tdt)

    Response.Clear()
    Response.AppendHeader("content-disposition", "attachment; filename=TABillList_" & fdt.Replace("/", "_") & ".xlsx")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType("abcd.xlsx")
    Response.WriteFile(FileName)
    HttpContext.Current.Server.ScriptTimeout = st
    Response.End()

  End Sub
  Private Function CreateReport(fdt As String, tdt As String) As String


    Dim TemplateName As String = "TABill_Template.xlsx"

    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
    If IO.File.Exists(tmpFile) Then
      IO.File.Copy(tmpFile, FileName)
      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Report")
      Dim r As Integer = 1
      Dim c As Integer = 1
      Dim cnt As Integer = 1
      Dim sn As Integer = 1

      'CurrentBillStartRow = cbsr
      Dim cbsr As Integer = 4
      'currentBillMaxRow =cbmr
      Dim cbmr As Integer = cbsr

      On Error Resume Next
      Dim tas As List(Of SIS.TA.taBH) = SIS.TA.taBH.taBHDateRangeSelectList(fdt, tdt)

      For Each tmp As SIS.TA.taBH In tas
        r = cbsr
        With xlWS
          c = 1
          '.Cells(r, c).Value = cnt
          'c += 1
          .Cells(r, c).Value = tmp.EmployeeID
          c += 1
          .Cells(r, c).Value = tmp.FK_TA_Bills_EmployeeID.EmployeeName
          c += 1
          .Cells(r, c).Value = tmp.TABillNo
          c += 1
          .Cells(r, c).Value = tmp.ForwardedOn
          c += 1
          .Cells(r, c).Value = tmp.FK_TA_Bills_TravelTypeID.TravelTypeDescription
          c += 1
          .Cells(r, c).Value = IIf(tmp.ApprovedByCC <> "", tmp.FK_TA_Bills_ApprovedByCC.EmployeeName, "")
          c += 1
          .Cells(r, c).Value = IIf(tmp.ApprovedBySA <> "", tmp.FK_TA_Bills_ApprovedBySA.EmployeeName, "")
          c += 1
          .Cells(r, c).Value = tmp.FK_TA_Bills_CityOfOrigin.CityName
          c += 1
          .Cells(r, c).Value = IIf(tmp.DestinationCity <> "", tmp.FK_TA_Bills_DestinationCity.CityName, tmp.DestinationName)
          c += 1
          .Cells(r, c).Value = tmp.PurposeOfJourney.Replace(Chr(10), " ").Replace(Chr(13), " ").Replace(Chr(8), " ")

          Dim sTmps As List(Of SIS.TA.taBillDetails) = SIS.TA.taBillDetails.taBillDetailsSelectList(0, 999, "", False, "", tmp.TABillNo)
          '1.Fare
          sn = 1
          r = cbsr
          For Each stmp As SIS.TA.taBillDetails In sTmps
            If stmp.ComponentID <> TAComponentTypes.Fare Then Continue For
            c = 11
            .Cells(r, c).Value = sn
            c += 1
            .Cells(r, c).Value = Convert.ToDateTime(stmp.Date1Time).ToString("dd/MM/yyyy")
            c += 1
            .Cells(r, c).Value = Convert.ToDateTime(stmp.Date1Time).ToString("HH:mm")
            c += 1
            .Cells(r, c).Value = IIf(stmp.City1ID <> "", stmp.FK_TA_BillDetails_City1ID.CityName, stmp.City1Text)
            c += 1
            .Cells(r, c).Value = Convert.ToDateTime(stmp.Date2Time).ToString("dd/MM/yyyy")
            c += 1
            .Cells(r, c).Value = Convert.ToDateTime(stmp.Date2Time).ToString("HH:mm")
            c += 1
            .Cells(r, c).Value = IIf(stmp.City2ID <> "", stmp.FK_TA_BillDetails_City2ID.CityName, stmp.City2Text)
            c += 1
            .Cells(r, c).Value = IIf(stmp.ModeTravelID <> "", stmp.FK_TA_BillDetails_ModeTravelID.ModeName, stmp.ModeText)
            c += 1
            .Cells(r, c).Value = stmp.AmountInINR
            c += 1
            .Cells(r, c).Value = stmp.PassedAmountInINR
            c += 1
            .Cells(r, c).Value = stmp.OOERemarks
            r += 1
            sn += 1
          Next
          If r > cbmr Then cbmr = r
          '2.Lodging
          sn = 1
          r = cbsr
          For Each stmp As SIS.TA.taBillDetails In sTmps
            If stmp.ComponentID <> TAComponentTypes.Lodging Then Continue For
            c = 22
            .Cells(r, c).Value = sn
            c += 1
            .Cells(r, c).Value = IIf(stmp.City1ID <> "", stmp.FK_TA_BillDetails_City1ID.CityName, stmp.City1Text) & " " & stmp.City1Text
            c += 1
            .Cells(r, c).Value = Convert.ToDateTime(stmp.Date1Time).ToString("dd/MM/yyyy")
            c += 1
            .Cells(r, c).Value = Convert.ToDateTime(stmp.Date1Time).ToString("HH:mm")
            c += 1
            .Cells(r, c).Value = Convert.ToDateTime(stmp.Date2Time).ToString("dd/MM/yyyy")
            c += 1
            .Cells(r, c).Value = Convert.ToDateTime(stmp.Date2Time).ToString("HH:mm")
            c += 1
            .Cells(r, c).Value = stmp.AmountInINR
            c += 1
            .Cells(r, c).Value = stmp.PassedAmountInINR
            c += 1
            .Cells(r, c).Value = stmp.OOERemarks
            r += 1
            sn += 1
          Next
          If r > cbmr Then cbmr = r
          '3.LC
          sn = 1
          r = cbsr
          For Each stmp As SIS.TA.taBillDetails In sTmps
            If stmp.ComponentID <> TAComponentTypes.LC Then Continue For
            c = 31
            .Cells(r, c).Value = sn
            c += 1
            .Cells(r, c).Value = Convert.ToDateTime(stmp.Date1Time).ToString("dd/MM/yyyy")
            c += 1
            .Cells(r, c).Value = stmp.SystemText
            c += 1
            .Cells(r, c).Value = stmp.AmountInINR
            c += 1
            .Cells(r, c).Value = stmp.PassedAmountInINR
            c += 1
            .Cells(r, c).Value = stmp.OOERemarks
            r += 1
            sn += 1
          Next
          If r > cbmr Then cbmr = r
          '4.DA
          sn = 1
          r = cbsr
          For Each stmp As SIS.TA.taBillDetails In sTmps
            If stmp.ComponentID <> TAComponentTypes.DA Then Continue For
            c = 37
            .Cells(r, c).Value = sn
            c += 1
            .Cells(r, c).Value = Convert.ToDateTime(stmp.Date1Time).ToString("dd/MM/yyyy")
            c += 1
            .Cells(r, c).Value = stmp.SystemText
            c += 1
            .Cells(r, c).Value = stmp.AmountInINR
            c += 1
            .Cells(r, c).Value = stmp.PassedAmountInINR
            c += 1
            .Cells(r, c).Value = stmp.OOERemarks
            r += 1
            sn += 1
          Next
          If r > cbmr Then cbmr = r
          '5.Other
          sn = 1
          r = cbsr
          For Each stmp As SIS.TA.taBillDetails In sTmps
            If stmp.ComponentID <> TAComponentTypes.Expense Then Continue For
            c = 43
            .Cells(r, c).Value = sn
            c += 1
            .Cells(r, c).Value = Convert.ToDateTime(stmp.Date1Time).ToString("dd/MM/yyyy")
            c += 1
            .Cells(r, c).Value = stmp.SystemText
            c += 1
            .Cells(r, c).Value = stmp.AmountInINR
            c += 1
            .Cells(r, c).Value = stmp.PassedAmountInINR
            c += 1
            .Cells(r, c).Value = stmp.OOERemarks
            r += 1
            sn += 1
          Next
          If r > cbmr Then cbmr = r
          '6.Mileage
          sn = 1
          r = cbsr
          For Each stmp As SIS.TA.taBillDetails In sTmps
            If stmp.ComponentID <> TAComponentTypes.Mileage Then Continue For
            c = 49
            .Cells(r, c).Value = sn
            c += 1
            .Cells(r, c).Value = Convert.ToDateTime(stmp.Date1Time).ToString("dd/MM/yyyy")
            c += 1
            .Cells(r, c).Value = stmp.SystemText
            c += 1
            .Cells(r, c).Value = stmp.AmountInINR
            c += 1
            .Cells(r, c).Value = stmp.PassedAmountInINR
            c += 1
            .Cells(r, c).Value = stmp.OOERemarks
            r += 1
            sn += 1
          Next
          If r > cbmr Then cbmr = r


          .Cells(cbsr, 1, cbmr, 54).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
          If cnt Mod 2 = 0 Then
            .Cells(cbsr, 1, cbmr, 54).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.AliceBlue)
          Else
            .Cells(cbsr, 1, cbmr, 54).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Bisque)
          End If
          .Cells(cbsr, 1, cbmr, 54).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)

          cnt += 1
          cbsr = cbmr
        End With
      Next

      xlPk.Save()
      xlPk.Dispose()
    End If
    Return FileName
  End Function
End Class
