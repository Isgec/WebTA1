<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_hrmLocations.aspx.vb" Inherits="GF_hrmLocations" title="Maintain List: Locations" %>
<asp:Content ID="CPHhrmLocations" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelhrmLocations" runat="server" Text="&nbsp;List: Locations"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLhrmLocations" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLhrmLocations"
      ToolType = "lgNMGrid"
      EditUrl = "~/HRM_Main/App_Edit/EF_hrmLocations.aspx"
      AddUrl = "~/HRM_Main/App_Create/AF_hrmLocations.aspx?skip=1"
      ValidationGroup = "hrmLocations"
      runat = "server" />
    <asp:UpdateProgress ID="UPGShrmLocations" runat="server" AssociatedUpdatePanelID="UPNLhrmLocations" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVhrmLocations" SkinID="gv_silver" runat="server" DataSourceID="ODShrmLocations" DataKeyNames="LocationID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location ID" SortExpression="LocationID">
          <ItemTemplate>
            <asp:Label ID="LabelLocationID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LocationID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODShrmLocations"
      runat = "server"
      DataObjectTypeName = "SIS.HRM.hrmLocations"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "hrmLocationsSelectList"
      TypeName = "SIS.HRM.hrmLocations"
      SelectCountMethod = "hrmLocationsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVhrmLocations" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
