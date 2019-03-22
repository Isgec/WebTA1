<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_taD_LCRates.aspx.vb" Inherits="GF_taD_LCRates" title="Maintain List: City Wise KM Rates" %>
<asp:Content ID="CPHtaD_LCRates" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaD_LCRates" runat="server" Text="&nbsp;List: City Wise KM Rates"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaD_LCRates" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaD_LCRates"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taD_LCRates.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taD_LCRates.aspx"
      ValidationGroup = "taD_LCRates"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaD_LCRates" runat="server" AssociatedUpdatePanelID="UPNLtaD_LCRates" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaD_LCRates" SkinID="gv_silver" runat="server" DataSourceID="ODStaD_LCRates" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="S.N." SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TA Category" SortExpression="TA_Categories1_cmba">
          <ItemTemplate>
             <asp:Label ID="L_CategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CategoryID") %>' Text='<%# Eval("TA_Categories1_cmba") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="LC Mode" SortExpression="TA_LCModes4_ModeName">
          <ItemTemplate>
             <asp:Label ID="L_ModeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ModeID") %>' Text='<%# Eval("TA_LCModes4_ModeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City" SortExpression="TA_Cities2_CityName">
          <ItemTemplate>
             <asp:Label ID="L_CityID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CityID") %>' Text='<%# Eval("TA_Cities2_CityName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City Type" SortExpression="TA_CityTypes3_CityTypeName">
          <ItemTemplate>
             <asp:Label ID="L_CityTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CityTypeID") %>' Text='<%# Eval("TA_CityTypes3_CityTypeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount Per KM" SortExpression="AmountPerKM">
          <ItemTemplate>
            <asp:Label ID="LabelAmountPerKM" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AmountPerKM") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Night Charges %" SortExpression="NightCharges">
          <ItemTemplate>
            <asp:Label ID="LabelNightCharges" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("NightCharges") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Non Availability Charges %" SortExpression="NonAvailabilityCharges">
          <ItemTemplate>
            <asp:Label ID="LabelNonAvailabilityCharges" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("NonAvailabilityCharges") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fixed Inter State Amount" SortExpression="FixedInterStateCharges">
          <ItemTemplate>
            <asp:Label ID="LabelFixedInterStateCharges" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FixedInterStateCharges") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaD_LCRates"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taD_LCRates"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taD_LCRatesSelectList"
      TypeName = "SIS.TA.taD_LCRates"
      SelectCountMethod = "taD_LCRatesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaD_LCRates" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
