Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel

Partial Class MISView
  Inherits System.Web.UI.Page
  Private Sub RenderDS(ds As DataSet, BaseName As String, Optional InExcel As Boolean = False, Optional Index As Integer = 0)
    Dim cnt As Integer = 0
    For Each dt As DataTable In ds.Tables
      Dim hDiv As New HtmlGenericControl("div")
      Dim gv As New GridView
      cnt += 1
      gv.ID = BaseName & "Rep_" & cnt
      gv.CssClass = "mis-gv"
      With gv
        .HeaderStyle.BackColor = Drawing.ColorTranslator.FromHtml("#3AC0F2")
        .HeaderStyle.ForeColor = Drawing.Color.White
        .RowStyle.BackColor = Drawing.ColorTranslator.FromHtml("#dcf5f5")  '#A1DCF2
        .AlternatingRowStyle.BackColor = Drawing.Color.White
        .AlternatingRowStyle.ForeColor = Drawing.ColorTranslator.FromHtml("#000")
        .ShowFooter = True
      End With
      'If dt.TableName = "Table" And BaseName <> "BaaN" Then gv.CssClass = "mis-gv mis-count"
      gv.DataSource = dt
      gv.DataBind()
      If Not InExcel Then
        hDiv.Controls.Add(gv)
        mainContainer.Controls.Add(hDiv)
      Else
        If cnt = Index Then
          ExportToExcel(gv)
        End If
      End If
    Next
  End Sub

  Private Sub Loaddata(Optional InExcel As Boolean = False, Optional Index As Integer = 0)
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
    End Try
    Dim ds As New DataSet
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "sppak_LG_QCOnlineReport"
        'SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FDt", SqlDbType.DateTime, 21, fdt)
        'SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TDt", SqlDbType.DateTime, 21, tdt)
        Con.Open()
        Dim da As New SqlDataAdapter
        da.SelectCommand = Cmd
        da.Fill(ds)
      End Using
    End Using
    RenderDS(ds, "Joomla", InExcel, Index)
  End Sub

  Protected Sub ExportToExcel(GridView1 As GridView)
    Response.Clear()
    Response.Buffer = True
    Response.AddHeader("content-disposition", "attachment;filename=" & GridView1.ID & ".xls")
    Response.Charset = ""
    Response.ContentType = "application/vnd.ms-excel"
    Using sw As New IO.StringWriter()
      Dim hw As New HtmlTextWriter(sw)
      GridView1.HeaderRow.BackColor = Drawing.Color.White
      For Each cell As TableCell In GridView1.HeaderRow.Cells
        cell.BackColor = GridView1.HeaderStyle.BackColor
      Next
      For Each row As GridViewRow In GridView1.Rows
        row.BackColor = Drawing.Color.White
        For Each cell As TableCell In row.Cells
          If row.RowIndex Mod 2 = 0 Then
            cell.BackColor = GridView1.AlternatingRowStyle.BackColor
          Else
            cell.BackColor = GridView1.RowStyle.BackColor
          End If
          cell.CssClass = "textmode"
        Next
      Next
      GridView1.RenderControl(hw)
      'style to format numbers to string
      Dim style As String = "<style> .textmode { } </style>"
      Response.Write(style)
      Response.Output.Write(sw.ToString())
      Response.Flush()
      Response.[End]()
    End Using
  End Sub

  Public Overrides Sub VerifyRenderingInServerForm(control As Control)
    ' Verifies that the control is rendered
  End Sub

  Private Sub cmdGenerate_Click(sender As Object, e As EventArgs) Handles cmdGenerate.Click
    Loaddata()
  End Sub

  Private Sub cmdExcel_Click(sender As Object, e As EventArgs) Handles cmdExcel.Click
    Loaddata(True, 1)
  End Sub

  Private Sub MISView_Load(sender As Object, e As EventArgs) Handles Me.Load
    F_fDt.Text = Now.AddDays(-30).ToString("dd/MM/yyyy")
    F_tDt.Text = Now.ToString("dd/MM/yyyy")
  End Sub
End Class
