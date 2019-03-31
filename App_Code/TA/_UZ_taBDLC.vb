Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taBDLC
    Public Shared Function UZ_taBDLCSelectListForNew(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDLC)
      Dim Results As List(Of SIS.TA.taBDLC) = Nothing
      Results = New List(Of SIS.TA.taBDLC)()
      Dim tmp As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
      For i As Integer = 1 To 10
        Dim x As New SIS.TA.taBDLC
        With x
          .TABillNo = TABillNo
          .SerialNo = i
          .CurrencyMain = tmp.BillCurrencyID
          .ConversionFactorINR = tmp.ConversionFactorINR
          .ConversionFactorOU = "1.000000"
          .CurrencyID = tmp.BillCurrencyID
        End With
        Results.Add(x)
      Next
      RecordCount = 10
      Return Results
    End Function
    Public Shared Function UZ_taBDLCSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDLC)
      Dim Results As List(Of SIS.TA.taBDLC) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BDLCSelectListSearch"
            Cmd.CommandText = "sptaBDLCSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BDLCSelectListFilteres"
            Cmd.CommandText = "sptaBDLCSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 10, TAComponentTypes.LC)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBDLC)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBDLC(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBDLCInsert(ByVal Record As SIS.TA.taBDLC) As SIS.TA.taBDLC
      Dim sBill As SIS.TA.taBH = Record.FK_TA_BillDetails_TABillNo
      If sBill.StartDateTime = "" Then
        Throw New Exception("Pl. enter FARE or Lodging record before Local Conveyance.")
      End If
      Dim xTmp As String = Record.ModeLCID
      With Record
        .ComponentID = TAComponentTypes.LC
        .AutoCalculated = False
        .TourExtended = False
        .ProjectID = sBill.ProjectID
        .CostCenterID = sBill.CostCenterID
        .ConversionFactorINR = sBill.ConversionFactorINR
        If sBill.BillCurrencyID <> "INR" Then
          If .CurrencyID = "INR" Then
            .ConversionFactorOU = 1
            .ConversionFactorINR = 1
          End If
        End If
        If Convert.ToDateTime(sBill.StartDateTime) < Convert.ToDateTime("15/03/2019") Then
          .AmountRate = 1
          .AmountFactor = .AmountRateOU * .ConversionFactorOU
          .AmountBasic = (.AmountFactor * .AmountRate)
          .AmountTaxOU = 0
          .AmountTax = .AmountTaxOU * .ConversionFactorOU
          .AmountTotal = (.AmountBasic + .AmountTax)
          .AmountInINR = .AmountTotal * .ConversionFactorINR
          .PassedAmountFactor = .AmountFactor
          .PassedAmountRate = .AmountRate
          .PassedAmountBasic = .AmountBasic
          .PassedAmountTax = .AmountTax
          .PassedAmountTotal = .AmountTotal
          .PassedAmountInINR = .AmountInINR
        Else
          Select Case sBill.TravelTypeID
            Case TATravelTypeValues.Domestic, TATravelTypeValues.HomeVisit
              Select Case xTmp
                Case "1", "2", "3", "11" 'Taxi
                  'If .AmountRateOU = 0 Then
                  '  'pick from mileage entitlement
                  '  Dim LocationID As Integer = sBill.FK_TA_Bills_EmployeeID.C_OfficeID
                  '  Dim cityID As String = ""
                  '  Select Case LocationID
                  '    Case 4 'Chennai
                  '      cityID = "Chennai-TN"
                  '    Case 5 'Pune
                  '      cityID = "Pune-MH"
                  '    Case 7 ' Kolkatta
                  '      cityID = "Kolkata-WB"
                  '    Case 8 'Mumbai
                  '      cityID = "MumbaiCity-MH"
                  '  End Select
                  '  Dim tmp As SIS.TA.taD_Mileage = SIS.TA.taD_Mileage.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), cityID, Convert.ToDateTime(.Date1Time))
                  '  If tmp IsNot Nothing Then
                  '    .AmountRateOU = tmp.AmountPerKM
                  '  End If
                  'End If

                  .AmountFactor = (.AmountRateOU * .ConversionFactorOU) / .AmountRate
                  'Stop multiplying KM, user will enter total amount
                  '.AmountBasic = (.AmountFactor * .AmountRate)
                  .AmountBasic = (.AmountRateOU * .ConversionFactorOU)
                  .AmountTaxOU = 0
                  .AmountTax = .AmountTaxOU * .ConversionFactorOU
                  .AmountTotal = (.AmountBasic + .AmountTax)
                  .AmountInINR = .AmountTotal * .ConversionFactorINR
                  .PassedAmountFactor = .AmountFactor
                  .PassedAmountRate = .AmountRate
                  .PassedAmountBasic = .AmountBasic
                  .PassedAmountTax = .AmountTax
                  .PassedAmountTotal = .AmountTotal
                  .PassedAmountInINR = .AmountInINR
                  .SystemText = " [Taxi] Total KM: " & .AmountRate & " @: " & .AmountFactor.ToString("n") & " per KM."
                Case "4", "8"
                  Dim tmpStr As String = "["
                  Dim xLCRate As SIS.TA.taD_LCRates = SIS.TA.taD_LCRates.GetForCityByIDorType(Record)
                  .AmountRateOU = xLCRate.AmountPerKM
                  tmpStr &= "Basic: " & .AmountRateOU
                  If Record.StayedWithRelative Then
                    .AmountRateOU += ((xLCRate.AmountPerKM * xLCRate.NightCharges) / 100)
                    tmpStr &= ", NC: " & xLCRate.NightCharges & "%"
                  End If
                  If Record.StayedInGuestHouse Then
                    .AmountRateOU += ((xLCRate.AmountPerKM * xLCRate.NonAvailabilityCharges) / 100)
                    tmpStr &= ", NA: " & xLCRate.NonAvailabilityCharges & "%"
                  End If
                  .AmountFactor = .AmountRateOU * .ConversionFactorOU
                  .AmountBasic = (.AmountFactor * .AmountRate)
                  .AmountTaxOU = 0
                  If Record.StayedAtSite Then
                    .AmountTaxOU = xLCRate.FixedInterStateCharges
                    tmpStr &= ", Toll: " & xLCRate.FixedInterStateCharges
                  End If
                  .AmountTax = .AmountTaxOU * .ConversionFactorOU
                  .AmountTotal = (.AmountBasic + .AmountTax)
                  .AmountInINR = .AmountTotal * .ConversionFactorINR
                  .PassedAmountFactor = .AmountFactor
                  .PassedAmountRate = .AmountRate
                  .PassedAmountBasic = .AmountBasic
                  .PassedAmountTax = .AmountTax
                  .PassedAmountTotal = .AmountTotal
                  .PassedAmountInINR = .AmountInINR
                  .SystemText = " [Auto] Total KM: " & .AmountRate & " @: " & .AmountFactor.ToString("n") & " per KM. " & tmpStr & "]"
                Case Else
                  .AmountRate = 1
                  .AmountFactor = .AmountRateOU * .ConversionFactorOU
                  .AmountBasic = (.AmountFactor * .AmountRate)
                  .AmountTaxOU = 0
                  .AmountTax = .AmountTaxOU * .ConversionFactorOU
                  .AmountTotal = (.AmountBasic + .AmountTax)
                  .AmountInINR = .AmountTotal * .ConversionFactorINR
                  .PassedAmountFactor = .AmountFactor
                  .PassedAmountRate = .AmountRate
                  .PassedAmountBasic = .AmountBasic
                  .PassedAmountTax = .AmountTax
                  .PassedAmountTotal = .AmountTotal
                  .PassedAmountInINR = .AmountInINR
              End Select
            Case TATravelTypeValues.ForeignTravel, TATravelTypeValues.ForeignSiteVisit
              .AmountRate = 1
              .AmountFactor = .AmountRateOU * .ConversionFactorOU
              .AmountBasic = (.AmountFactor * .AmountRate)
              .AmountTaxOU = 0
              .AmountTax = .AmountTaxOU * .ConversionFactorOU
              .AmountTotal = (.AmountBasic + .AmountTax)
              .AmountInINR = .AmountTotal * .ConversionFactorINR
              .PassedAmountFactor = .AmountFactor
              .PassedAmountRate = .AmountRate
              .PassedAmountBasic = .AmountBasic
              .PassedAmountTax = .AmountTax
              .PassedAmountTotal = .AmountTotal
              .PassedAmountInINR = .AmountInINR
          End Select
        End If
        If .ModeLCID <> String.Empty AndAlso .ModeLCID <> "12" Then
          .ModeText = .FK_TA_BillDetails_ModeLCID.ModeName
        End If
        .SystemText = "From " & .FromAddress & " To " & .ToAddress & " LC Mode " & .ModeText & " On " & .Date1Time & .SystemText
      End With
      Dim _Result As SIS.TA.taBDLC = InsertData(Record)
      'taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taBDLCUpdate(ByVal Record As SIS.TA.taBDLC) As SIS.TA.taBDLC
      Dim sBill As SIS.TA.taBH = Record.FK_TA_BillDetails_TABillNo
      If sBill.StartDateTime = "" Then
        Throw New Exception("Pl. enter FARE or Lodging record before Local Conveyance.")
      End If
      Dim xTmp As String = Record.ModeLCID
      With Record
        If Convert.ToDateTime(sBill.StartDateTime) < Convert.ToDateTime("15/03/2019") Then
          .ComponentID = TAComponentTypes.LC
          .AmountRate = 1
          .AmountFactor = .AmountRateOU * .ConversionFactorOU
          .AmountBasic = (.AmountFactor * .AmountRate)
          .AmountTaxOU = 0
          .AmountTax = .AmountTaxOU * .ConversionFactorOU
          .AmountTotal = (.AmountBasic + .AmountTax)
          .AmountInINR = .AmountTotal * .ConversionFactorINR
          .PassedAmountFactor = .AmountFactor
          .PassedAmountRate = .AmountRate
          .PassedAmountBasic = .AmountBasic
          .PassedAmountTax = .AmountTax
          .PassedAmountTotal = .AmountTotal
          .PassedAmountInINR = .AmountInINR
        Else
          Select Case sBill.TravelTypeID
            Case TATravelTypeValues.Domestic, TATravelTypeValues.HomeVisit
              Select Case xTmp
                Case "1", "2", "3", "11"
                  .ComponentID = TAComponentTypes.LC
                  'If .AmountRateOU = 0 Then
                  '  'pick from mileage entitlement
                  '  Dim LocationID As Integer = sBill.FK_TA_Bills_EmployeeID.C_OfficeID
                  '  Dim cityID As String = ""
                  '  Select Case LocationID
                  '    Case 4 'Chennai
                  '      cityID = "Chennai-TN"
                  '    Case 5 'Pune
                  '      cityID = "Pune-MH"
                  '    Case 7 ' Kolkatta
                  '      cityID = "Kolkata-WB"
                  '    Case 8 'Mumbai
                  '      cityID = "MumbaiCity-MH"
                  '  End Select
                  '  Dim tmp As SIS.TA.taD_Mileage = SIS.TA.taD_Mileage.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), cityID, Convert.ToDateTime(.Date1Time))
                  '  If tmp IsNot Nothing Then
                  '    .AmountRateOU = tmp.AmountPerKM
                  '  End If
                  'End If
                  .AmountFactor = (.AmountRateOU * .ConversionFactorOU) / .AmountRate
                  .AmountBasic = (.AmountRateOU * .ConversionFactorOU)
                  .AmountTaxOU = 0
                  .AmountTax = .AmountTaxOU * .ConversionFactorOU
                  .AmountTotal = (.AmountBasic + .AmountTax)
                  .AmountInINR = .AmountTotal * .ConversionFactorINR
                  .PassedAmountFactor = .AmountFactor
                  .PassedAmountRate = .AmountRate
                  .PassedAmountBasic = .AmountBasic
                  .PassedAmountTax = .AmountTax
                  .PassedAmountTotal = .AmountTotal
                  .PassedAmountInINR = .AmountInINR
                  .SystemText = " [Taxi] Total KM: " & .AmountRate & " @: " & .AmountFactor.ToString("n") & " per KM."
                Case "4", "8"
                  Dim tmpStr As String = "["
                  .ComponentID = TAComponentTypes.LC
                  Dim xLCRate As SIS.TA.taD_LCRates = SIS.TA.taD_LCRates.GetForCityByIDorType(Record)
                  .AmountRateOU = xLCRate.AmountPerKM
                  tmpStr &= "Basic: " & .AmountRateOU
                  If Record.StayedWithRelative Then
                    .AmountRateOU += ((xLCRate.AmountPerKM * xLCRate.NightCharges) / 100)
                    tmpStr &= ", NC: " & xLCRate.NightCharges & "%"
                  End If
                  If Record.StayedInGuestHouse Then
                    .AmountRateOU += ((xLCRate.AmountPerKM * xLCRate.NonAvailabilityCharges) / 100)
                    tmpStr &= ", NA: " & xLCRate.NonAvailabilityCharges & "%"
                  End If
                  .AmountFactor = .AmountRateOU * .ConversionFactorOU
                  .AmountBasic = (.AmountFactor * .AmountRate)
                  .AmountTaxOU = 0
                  If Record.StayedAtSite Then
                    .AmountTaxOU = xLCRate.FixedInterStateCharges
                    tmpStr &= ", Toll: " & xLCRate.FixedInterStateCharges
                  End If
                  .AmountTax = .AmountTaxOU * .ConversionFactorOU
                  .AmountTotal = (.AmountBasic + .AmountTax)
                  .AmountInINR = .AmountTotal * .ConversionFactorINR
                  .PassedAmountFactor = .AmountFactor
                  .PassedAmountRate = .AmountRate
                  .PassedAmountBasic = .AmountBasic
                  .PassedAmountTax = .AmountTax
                  .PassedAmountTotal = .AmountTotal
                  .PassedAmountInINR = .AmountInINR
                  .SystemText = " [Auto] Total KM: " & .AmountRate & " @: " & .AmountFactor.ToString("n") & " per KM. " & tmpStr & "]"
                Case Else
                  .ComponentID = TAComponentTypes.LC
                  .AmountRate = 1
                  .AmountFactor = .AmountRateOU * .ConversionFactorOU
                  .AmountBasic = (.AmountFactor * .AmountRate)
                  .AmountTaxOU = 0
                  .AmountTax = .AmountTaxOU * .ConversionFactorOU
                  .AmountTotal = (.AmountBasic + .AmountTax)
                  .AmountInINR = .AmountTotal * .ConversionFactorINR
                  .PassedAmountFactor = .AmountFactor
                  .PassedAmountRate = .AmountRate
                  .PassedAmountBasic = .AmountBasic
                  .PassedAmountTax = .AmountTax
                  .PassedAmountTotal = .AmountTotal
                  .PassedAmountInINR = .AmountInINR
              End Select
            Case TATravelTypeValues.ForeignTravel, TATravelTypeValues.ForeignSiteVisit
              .ComponentID = TAComponentTypes.LC
              .AmountRate = 1
              .AmountFactor = .AmountRateOU * .ConversionFactorOU
              .AmountBasic = (.AmountFactor * .AmountRate)
              .AmountTaxOU = 0
              .AmountTax = .AmountTaxOU * .ConversionFactorOU
              .AmountTotal = (.AmountBasic + .AmountTax)
              .AmountInINR = .AmountTotal * .ConversionFactorINR
              .PassedAmountFactor = .AmountFactor
              .PassedAmountRate = .AmountRate
              .PassedAmountBasic = .AmountBasic
              .PassedAmountTax = .AmountTax
              .PassedAmountTotal = .AmountTotal
              .PassedAmountInINR = .AmountInINR
          End Select
        End If
        If .ModeLCID <> String.Empty AndAlso .ModeLCID <> "12" Then
          .ModeText = .FK_TA_BillDetails_ModeLCID.ModeName
        End If
        .SystemText = "From " & .FromAddress & " To " & .ToAddress & " LC Mode " & .ModeText & " On " & .Date1Time & .SystemText
      End With
      Dim _Result As SIS.TA.taBDLC = UpdateData(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taBDLCDelete(ByVal Record As SIS.TA.taBDLC) As Int32
      Dim _Result As Integer = taBillDetailsDelete(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
  End Class
End Namespace
