<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taBDFinance.aspx.vb" Inherits="AF_taBDFinance" title="Add: Source of Finance" %>
<asp:Content ID="CPHtaBDFinance" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBDFinance" runat="server" Text="&nbsp;Add: Source of Finance"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDFinance" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaBDFinance"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taBDFinance"
    runat = "server" />
<asp:FormView ID="FVtaBDFinance"
  runat = "server"
  DataKeyNames = "TABillNo,SerialNo"
  DataSourceID = "ODStaBDFinance"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaBDFinance" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TABillNo" ForeColor="#CC6633" runat="server" Text="TA Bill No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TABillNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("TABillNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for TA Bill No."
            ValidationGroup = "taBDFinance"
            onblur= "script_taBDFinance.validate_TABillNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVTABillNo"
            runat = "server"
            ControlToValidate = "F_TABillNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBDFinance"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_TABillNo_Display"
            Text='<%# Eval("TA_Bills5_PurposeOfJourney") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETABillNo"
            BehaviorID="B_ACETABillNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TABillNoCompletionList"
            TargetControlID="F_TABillNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taBDFinance.ACETABillNo_Selected"
            OnClientPopulating="script_taBDFinance.ACETABillNo_Populating"
            OnClientPopulated="script_taBDFinance.ACETABillNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Date1Time" runat="server" Text="Finance Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Date1Time"
            Text='<%# Bind("Date1Time") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="taBDFinance"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonDate1Time" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDate1Time"
            TargetControlID="F_Date1Time"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDate1Time" />
          <AJX:MaskedEditExtender 
            ID = "MEEDate1Time"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Date1Time" />
          <AJX:MaskedEditValidator 
            ID = "MEVDate1Time"
            runat = "server"
            ControlToValidate = "F_Date1Time"
            ControlExtender = "MEEDate1Time"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBDFinance"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ModeFinanceID" runat="server" Text="Finance Source :" />&nbsp;
        </td>
        <td>
          <LGM:LC_taFinanceHeads
            ID="F_ModeFinanceID"
            SelectedValue='<%# Bind("ModeFinanceID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_ModeText" runat="server" Text="Finance Source [ If not found in List ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ModeText"
            Text='<%# Bind("ModeText") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Finance Source [ If not found in List ]."
            MaxLength="100"
            Width="350px" 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AmountRateOU" runat="server" Text="Financed Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AmountRateOU"
            Text='<%# Bind("AmountRateOU") %>'
            Width="88px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="10"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CurrencyID" runat="server" Text="Currency :*" />
        </td>
        <td>
          <LGM:LC_taCurrencies
            ID="F_CurrencyID"
            SelectedValue='<%# Bind("CurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taBDFinance"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr id="ouc" runat="server" ClientIDMode="Static">
        <td class="alignright">
          <asp:Label ID="L_CurrencyMain" runat="server" Text="Main Currency of TA Bill :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_CurrencyMain"
            Text='<%# Bind("CurrencyMain") %>'
            Width="88px"
            CssClass = "mytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ConversionFactorOU" runat="server" Text="Conversion Factor Main Currency :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ConversionFactorOU"
            Text='<%# Bind("ConversionFactorOU") %>'
            style="text-align: right"
            Width="100px"
            CssClass = "mytxt"
            ValidationGroup= "taBDFinance"
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,6);"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaBDFinance"
  DataObjectTypeName = "SIS.TA.taBDFinance"
  InsertMethod="UZ_taBDFinanceInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taBDFinance"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
