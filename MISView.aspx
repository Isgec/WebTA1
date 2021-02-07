<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MISView.aspx.vb" Inherits="MISView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <style>
    .mis-main {
      display: flex;
      flex-direction: row;
      flex-wrap: wrap;
    }

      .mis-main > div {
        margin: 10px;
        border: 1pt solid red;
        border-radius: 6px;
        background-color: #f1f1f1;
      }

    .mis-gv {
      margin: 5px;
      border: 1pt solid gray;
    }

    .mis-count td {
      text-align: center;
      font-weight: bold;
      font-size: 1.1rem;
    }

    .mis-gv > tbody > tr:first-child th:first-child {
      border-top-left-radius: 6px;
    }

    .mis-gv > tbody > tr:first-child th:last-child {
      border-top-right-radius: 6px;
    }

    .mis-gv > tbody > tr:last-child td:first-child {
      border-bottom-left-radius: 6px;
    }

    .mis-gv > tbody > tr:last-child td:last-child {
      border-bottom-right-radius: 6px;
    }

    .mis-gv th {
      font-weight: bold;
      font-size: 1.2rem;
      background-color: #0094ff;
      color: white;
      padding: 3px;
    }

    .nt-but-danger {
      border: 1pt solid #960825;
      background-color: #d1062f;
      color: white;
    }

    .nt-but-primary {
      border: 1pt solid #5780f8;
      background-color: #2196F3;
      color: white;
    }

    .nt-but-grey {
      border: 1pt solid gray;
      background-color: #bdbcbc;
      color: black;
    }

    .nt-but-success {
      border: 1pt solid #049317;
      background-color: #06bf1e;
      color: white;
    }

    .nt-but-warning {
      border: 1pt solid #ff6a00;
      background-color: #ffd800;
      color: black;
    }

    .nt-but-danger,
    .nt-but-grey,
    .nt-but-primary,
    .nt-but-warning,
    .nt-but-success {
      border-radius: 4px;
      height: 20px;
      font-size: 10px;
      font-weight: bold;
    }

      .nt-but-warning:hover,
      .nt-but-danger:hover,
      .nt-but-grey:hover,
      .nt-but-primary:hover,
      .nt-but-success:hover {
        border: 1pt solid orange;
        opacity: 0.7;
      }
  </style>
</head>
<body style="font-family: 'Courier New'; font-size: 12px;">
  <form id="form1" runat="server">
    <div style="display: flex; flex-direction: column;align-items:flex-start;border:1pt solid black;border-radius:6px;padding:10px;margin:10px;">
      <div style="display: flex; flex-direction: row;padding:5px;">
        <asp:Label ID="repName" runat="server" Font-Bold="true" Font-Underline="true" Font-Size="14px" Text="TA Bill GST Report"></asp:Label>
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
        <div style="padding-left:20px;">
        <asp:Button CssClass="nt-but-primary" ID="cmdExcel" runat="server" Text="Export to Excel" />
        </div>
      </div>
    </div>
    <div id="mainContainer" runat="server" class="mis-main">
    </div>
  </form>
</body>
</html>
