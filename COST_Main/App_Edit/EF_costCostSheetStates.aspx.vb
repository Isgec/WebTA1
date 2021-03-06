Partial Class EF_costCostSheetStates
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODScostCostSheetStates_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostCostSheetStates.Selected
    Dim tmp As SIS.COST.costCostSheetStates = CType(e.ReturnValue, SIS.COST.costCostSheetStates)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostCostSheetStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCostSheetStates.Init
    DataClassName = "EcostCostSheetStates"
    SetFormView = FVcostCostSheetStates
  End Sub
  Protected Sub TBLcostCostSheetStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostCostSheetStates.Init
    SetToolBar = TBLcostCostSheetStates
  End Sub
  Protected Sub FVcostCostSheetStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCostSheetStates.PreRender
    TBLcostCostSheetStates.EnableSave = Editable
    TBLcostCostSheetStates.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costCostSheetStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostCostSheetStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostCostSheetStates", mStr)
    End If
  End Sub

End Class
