<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RP_TABillAuditReport.aspx.vb" Inherits="RP_TABillAuditReport" title="TA Bill Report" %>
<asp:Content ID="CPHtaCountries" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaCountries" runat="server" Text="&nbsp;Report"></asp:Label>
</div>
<div class="pagedata">
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCountries"
      ToolType = "lgNReport"
      ValidationGroup = "taReport"
      runat = "server" />
    <br />
    <div style="display: flex; flex-direction: column;align-items:flex-start;border:1pt solid black;border-radius:6px;padding:10px;margin:10px;">
      <div style="display: flex; flex-direction: row;padding:5px;">
        <asp:Label ID="repName" runat="server" Font-Bold="true" Font-Underline="true" Font-Size="14px" Text="TA Bill Report"></asp:Label>
      </div>
      <div style="display: flex; flex-direction: row;">
        <div>From Date [DD/MM/YYYY]:</div>
        <div>
          <asp:TextBox ID="F_fDt" runat="server" ClientIDMode="Static" MaxLength="10" Width="100px"></asp:TextBox>
        </div>
      </div>
      <div style="display: flex; flex-direction: row;">
        <div>To &nbsp;Date&nbsp; [DD/MM/YYYY]:</div>
        <div>
          <asp:TextBox ID="F_tDt" runat="server" ClientIDMode="Static" MaxLength="10" Width="100px"></asp:TextBox>
        </div>
      </div>
      <div style="display: flex; flex-direction: row;">
        <div>
        <asp:Button CssClass="nt-but-danger" ID="cmdGenerate" runat="server" Text="Print Report" />
        </div>
      </div>
    </div>

  </td></tr></table>
</div>
</div>
</asp:Content>
