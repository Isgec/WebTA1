<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_tarTRSanctionByMD.aspx.vb" Inherits="EF_tarTRSanctionByMD" title="Edit: Travel Request Sanction By MD" %>
<asp:Content ID="CPHtarTRSanctionByMD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltarTRSanctionByMD" runat="server" Text="&nbsp;Edit: Travel Request Sanction By MD"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtarTRSanctionByMD" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtarTRSanctionByMD"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_tarTRSanctionByMD.aspx?pk="
    ValidationGroup = "tarTRSanctionByMD"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVtarTRSanctionByMD"
  runat = "server"
  DataKeyNames = "RequestID"
  DataSourceID = "ODStarTRSanctionByMD"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RequestID" runat="server" ForeColor="#CC6633" Text="Req.ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RequestID"
            Text='<%# Bind("RequestID") %>'
            ToolTip="Value of Req.ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequestedFor" runat="server" Text="Travelling Employee :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_RequestedFor"
            Width="72px"
            Text='<%# Bind("RequestedFor") %>'
            Enabled = "False"
            ToolTip="Value of Travelling Employee."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_RequestedFor_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RequestedForEmployees" runat="server" Text="Travelling Employees Group [List] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_RequestedForEmployees"
            Text='<%# Bind("RequestedForEmployees") %>'
            ToolTip="Value of Travelling Employees Group [List]."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TravelTypeID" runat="server" Text="Travel Type :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TravelTypeID"
            Width="88px"
            Text='<%# Bind("TravelTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Travel Type."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_TravelTypeID_Display"
            Text='<%# Eval("TA_TravelTypes13_TravelTypeDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            Enabled = "False"
            ToolTip="Value of Project Code."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects9_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProjectManagerID" runat="server" Text="Project Manager :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectManagerID"
            Width="72px"
            Text='<%# Bind("ProjectManagerID") %>'
            Enabled = "False"
            ToolTip="Value of Project Manager."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectManagerID_Display"
            Text='<%# Eval("aspnet_users7_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CostCenterID" runat="server" Text="Cost Center :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CostCenterID"
            Width="56px"
            Text='<%# Bind("CostCenterID") %>'
            Enabled = "False"
            ToolTip="Value of Cost Center."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CostCenterID_Display"
            Text='<%# Eval("HRM_Departments8_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TravelItinerary" runat="server" Text="Travel Itinerary :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TravelItinerary"
            Text='<%# Bind("TravelItinerary") %>'
            ToolTip="Value of Travel Itinerary."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Purpose" runat="server" Text="Purpose :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Purpose"
            Text='<%# Bind("Purpose") %>'
            ToolTip="Value of Purpose."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalRequestedAmount" runat="server" Text="Requested Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalRequestedAmount"
            Text='<%# Bind("TotalRequestedAmount") %>'
            ToolTip="Value of Requested Amount."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RequestedCurrencyID" runat="server" Text="Currency :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_RequestedCurrencyID"
            Width="56px"
            Text='<%# Bind("RequestedCurrencyID") %>'
            Enabled = "False"
            ToolTip="Value of Currency."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_RequestedCurrencyID_Display"
            Text='<%# Eval("TA_Currencies10_CurrencyName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequestedConversionFactor" runat="server" Text="Conversion Factor to INR of Requested Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_RequestedConversionFactor"
            Text='<%# Bind("RequestedConversionFactor") %>'
            ToolTip="Value of Conversion Factor to INR of Requested Amount."
            Enabled = "False"
            Width="200px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TotalRequestedAmountINR" runat="server" Text="Total Requested Amount [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalRequestedAmountINR"
            Text='<%# Bind("TotalRequestedAmountINR") %>'
            ToolTip="Value of Total Requested Amount [INR]."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_StatusID"
            Width="88px"
            Text='<%# Bind("StatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text='<%# Eval("TA_TravelRequestStatus12_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="72px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Created By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BudgetCheckedBy" runat="server" Text="Budget Checked By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_BudgetCheckedBy"
            Width="72px"
            Text='<%# Bind("BudgetCheckedBy") %>'
            Enabled = "False"
            ToolTip="Value of Budget Checked By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BudgetCheckedBy_Display"
            Text='<%# Eval("aspnet_users3_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BudgetCheckedOn" runat="server" Text="Budget Checked On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BudgetCheckedOn"
            Text='<%# Bind("BudgetCheckedOn") %>'
            ToolTip="Value of Budget Checked On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectManagerRemarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProjectManagerRemarks"
            Text='<%# Bind("ProjectManagerRemarks") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovedBy" runat="server" Text="Approved By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedBy"
            Width="72px"
            Text='<%# Bind("ApprovedBy") %>'
            Enabled = "False"
            ToolTip="Value of Approved By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedBy_Display"
            Text='<%# Eval("aspnet_users4_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovedOn" runat="server" Text="Approved On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedOn"
            Text='<%# Bind("ApprovedOn") %>'
            ToolTip="Value of Approved On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApproverRemarks" runat="server" Text="Approver Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApproverRemarks"
            Text='<%# Bind("ApproverRemarks") %>'
            ToolTip="Value of Approver Remarks."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BHApprovalBy" runat="server" Text="Approval By Business Head :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_BHApprovalBy"
            Width="72px"
            Text='<%# Bind("BHApprovalBy") %>'
            Enabled = "False"
            ToolTip="Value of Approval By Business Head."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BHApprovalBy_Display"
            Text='<%# Eval("aspnet_users5_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BHApprovalOn" runat="server" Text="Approval By Business Head On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BHApprovalOn"
            Text='<%# Bind("BHApprovalOn") %>'
            ToolTip="Value of Approval By Business Head On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BHRemarks" runat="server" Text="Business Head Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BHRemarks"
            Text='<%# Bind("BHRemarks") %>'
            ToolTip="Value of Business Head Remarks."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MDApprovalBy" runat="server" Text="Approval For MD By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_MDApprovalBy"
            Width="72px"
            Text='<%# Bind("MDApprovalBy") %>'
            Enabled = "False"
            ToolTip="Value of Approval For MD By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_MDApprovalBy_Display"
            Text='<%# Eval("aspnet_users6_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MDApprovalOn" runat="server" Text="Approval By MD On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MDApprovalOn"
            Text='<%# Bind("MDApprovalOn") %>'
            ToolTip="Value of Approval By MD On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MDRemarks" runat="server" Text="Remarks From MD :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_MDRemarks"
            Text='<%# Bind("MDRemarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tarTRSanctionByMD"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks From MD."
            MaxLength="250"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVMDRemarks"
            runat = "server"
            ControlToValidate = "F_MDRemarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tarTRSanctionByMD"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MDCurrencyID" runat="server" Text="MD Sanction In Currency :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taCurrencies
            ID="F_MDCurrencyID"
            SelectedValue='<%# Bind("MDCurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "tarTRSanctionByMD"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_MDConversionFactor" runat="server" Text="Conversion Factor to INR of MD Sanction :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_MDConversionFactor"
            Text='<%# Bind("MDConversionFactor") %>'
            style="text-align: right"
            Width="200px"
            CssClass = "mytxt"
            ValidationGroup= "tarTRSanctionByMD"
            MaxLength="24"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEMDConversionFactor"
            runat = "server"
            mask = "99999999.999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_MDConversionFactor" />
          <AJX:MaskedEditValidator 
            ID = "MEVMDConversionFactor"
            runat = "server"
            ControlToValidate = "F_MDConversionFactor"
            ControlExtender = "MEEMDConversionFactor"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tarTRSanctionByMD"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MDDAAmount" runat="server" Text="MD Sanctioned DA Amount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_MDDAAmount"
            Text='<%# Bind("MDDAAmount") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            ValidationGroup= "tarTRSanctionByMD"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEMDDAAmount"
            runat = "server"
            mask = "99999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_MDDAAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVMDDAAmount"
            runat = "server"
            ControlToValidate = "F_MDDAAmount"
            ControlExtender = "MEEMDDAAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tarTRSanctionByMD"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MDDAAmountINR" runat="server" Text="MD Sanctioned DA Amount [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MDDAAmountINR"
            Text='<%# Bind("MDDAAmountINR") %>'
            ToolTip="Value of MD Sanctioned DA Amount [INR]."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MDLodgingAmount" runat="server" Text="MD Sanctioned Lodging Amount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_MDLodgingAmount"
            Text='<%# Bind("MDLodgingAmount") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            ValidationGroup= "tarTRSanctionByMD"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEMDLodgingAmount"
            runat = "server"
            mask = "99999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_MDLodgingAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVMDLodgingAmount"
            runat = "server"
            ControlToValidate = "F_MDLodgingAmount"
            ControlExtender = "MEEMDLodgingAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tarTRSanctionByMD"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MDLodgingAmountINR" runat="server" Text="MD Sanctioned Lodging Amount [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MDLodgingAmountINR"
            Text='<%# Bind("MDLodgingAmountINR") %>'
            ToolTip="Value of MD Sanctioned Lodging Amount [INR]."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStarTRSanctionByMD"
  DataObjectTypeName = "SIS.TAR.tarTRSanctionByMD"
  SelectMethod = "tarTRSanctionByMDGetByID"
  UpdateMethod="UZ_tarTRSanctionByMDUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TAR.tarTRSanctionByMD"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestID" Name="RequestID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
