<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_costAdjustmentEntry.aspx.vb" Inherits="GF_costAdjustmentEntry" title="Maintain List: Adjustment Entry" %>
<asp:Content ID="CPHcostAdjustmentEntry" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostAdjustmentEntry" runat="server" Text="&nbsp;List: Adjustment Entry"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostAdjustmentEntry" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostAdjustmentEntry"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costAdjustmentEntry.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costAdjustmentEntry.aspx"
      AddPostBack = "True"
      ValidationGroup = "costAdjustmentEntry"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostAdjustmentEntry" runat="server" AssociatedUpdatePanelID="UPNLcostAdjustmentEntry" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" runat="server" Text="Project Group ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectGroupID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ProjectGroupID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectGroupID"
            BehaviorID="B_ACEProjectGroupID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectGroupIDCompletionList"
            TargetControlID="F_ProjectGroupID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEProjectGroupID_Selected"
            OnClientPopulating="ACEProjectGroupID_Populating"
            OnClientPopulated="ACEProjectGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" Text="Fin. Year :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_FinYear(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFinYear"
            BehaviorID="B_ACEFinYear"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FinYearCompletionList"
            TargetControlID="F_FinYear"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEFinYear_Selected"
            OnClientPopulating="ACEFinYear_Populating"
            OnClientPopulated="ACEFinYear_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" Text="Quarter :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_Quarter"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_Quarter(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEQuarter"
            BehaviorID="B_ACEQuarter"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="QuarterCompletionList"
            TargetControlID="F_Quarter"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEQuarter_Selected"
            OnClientPopulating="ACEQuarter_Populating"
            OnClientPopulated="ACEQuarter_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Revision" runat="server" Text="Revision :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_Revision"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEERevision"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Revision" />
          <AJX:MaskedEditValidator 
            ID = "MEVRevision"
            runat = "server"
            ControlToValidate = "F_Revision"
            ControlExtender = "MEERevision"
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVcostAdjustmentEntry" SkinID="gv_silver" runat="server" DataSourceID="ODScostAdjustmentEntry" DataKeyNames="ProjectGroupID,FinYear,Quarter,Revision,AdjustmentSerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Adjustment Serial No" SortExpression="AdjustmentSerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelAdjustmentSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AdjustmentSerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects8_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects8_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cr. GL Code" SortExpression="COST_ERPGLCodes3_GLDescription">
          <ItemTemplate>
             <asp:Label ID="L_CrGLCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CrGLCode") %>' Text='<%# Eval("COST_ERPGLCodes3_GLDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Dr. GL Code" SortExpression="COST_ERPGLCodes4_GLDescription">
          <ItemTemplate>
             <asp:Label ID="L_DrGLCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DrGLCode") %>' Text='<%# Eval("COST_ERPGLCodes4_GLDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
          <ItemTemplate>
            <asp:Label ID="LabelAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Amount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
          <ItemTemplate>
            <asp:Label ID="LabelRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Remarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Active" SortExpression="Active">
          <ItemTemplate>
            <asp:Label ID="LabelActive" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Active") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODScostAdjustmentEntry"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costAdjustmentEntry"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_costAdjustmentEntrySelectList"
      TypeName = "SIS.COST.costAdjustmentEntry"
      SelectCountMethod = "costAdjustmentEntrySelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_Quarter" PropertyName="Text" Name="Quarter" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_FinYear" PropertyName="Text" Name="FinYear" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ProjectGroupID" PropertyName="Text" Name="ProjectGroupID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_Revision" PropertyName="Text" Name="Revision" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostAdjustmentEntry" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_Quarter" />
    <asp:AsyncPostBackTrigger ControlID="F_FinYear" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectGroupID" />
    <asp:AsyncPostBackTrigger ControlID="F_Revision" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
