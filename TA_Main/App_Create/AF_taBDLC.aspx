<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taBDLC.aspx.vb" Inherits="AF_taBDLC" title="Add: Conveyance Expenses" %>
<asp:Content ID="CPHtaBDLC" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBDLC" runat="server" Text="&nbsp;Add: Conveyance Expenses"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDLC" runat="server">
  <ContentTemplate>
    <table width="100%">
      <tr>
        <td><b>
          1. From Place, To Place & Date are Mandatory input to SAVE the record.
            </b></td>
      </tr>
    </table>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBDLC"
      ToolType="lgNMAdd"
      ValidationGroup = "taBDmLC"
      InsertAndStay="false"
      EnableExit="true"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBDLC" runat="server" AssociatedUpdatePanelID="UPNLtaBDLC" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:TextBox
      ID = "F_TABillNo"
      CssClass = "mypktxt"
      Width="88px"
      enabled="false"
      style="display:none"
      Runat="Server" />
    <script type="text/javascript"> 
     var script_City1ID = {
      ACECity1ID_Selected: function(sender, e) {
        var Prefix = sender._element.id.replace('City1ID','');
        var F_City1ID = $get(sender._element.id);
        var F_City1ID_Display = $get(sender._element.id.replace('City1ID', 'City1ID_Display'));
        var retval = e.get_value();
        var p = retval.split('|');
        F_City1ID.value = p[0];
        F_City1ID_Display.innerHTML = e.get_text();
      },
      ACECity1ID_Populating: function(sender,e) {
        var p = sender.get_element();
        var Prefix = sender._element.id.replace('City1ID','');
        p.style.backgroundImage  = 'url(../../images/loader.gif)';
        p.style.backgroundRepeat= 'no-repeat';
        p.style.backgroundPosition = 'right';
        sender._contextKey = '';
      },
      ACECity1ID_Populated: function(sender,e) {
        var p = sender.get_element();
        p.style.backgroundImage  = 'none';
      },
      validate_City1ID: function(sender) {
        var Prefix = sender.id.replace('City1ID','');
        this.validated_FK_TA_BillDetails_City1ID_main = true;
        this.validate_FK_TA_BillDetails_City1ID(sender,Prefix);
        },
      validate_FK_TA_BillDetails_City1ID: function(o,Prefix) {
        var value = o.id;
        var City1ID = $get(o.id);
        if(City1ID.value==''){
          if(this.validated_FK_TA_BillDetails_City1ID_main){
            var o_d = $get(o.id.replace('City1ID', 'City1ID_Display'));
            try{o_d.innerHTML = '';}catch(ex){}
          }
          return true;
        }
        value = value + ',' + City1ID.value ;
          o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
          o.style.backgroundRepeat= 'no-repeat';
          o.style.backgroundPosition = 'right';
          PageMethods.validate_FK_TA_BillDetails_City1ID(value, this.validated_FK_TA_BillDetails_City1ID);
        },
      validated_FK_TA_BillDetails_City1ID_main: false,
      validated_FK_TA_BillDetails_City1ID: function(result) {
        var p = result.split('|');
        var o = $get(p[1]);
        if(script_City1ID.validated_FK_TA_BillDetails_City1ID_main){
          var o_d = $get(p[1].replace('City1ID','City1ID_Display'));
          try{o_d.innerHTML = p[2];}catch(ex){}
        }
        o.style.backgroundImage  = 'none';
        if(p[0]=='1'){
          o.value='';
          o.focus();
        }
      },
      temp: function() {
      }
      }
    </script>
    <asp:GridView ID="GVtaBDLC" SkinID="gv_silver" runat="server" DataSourceID="ODStaBDLC" DataKeyNames="SerialNo,TABillNo">
      <Columns>
        <asp:TemplateField HeaderText="S.N." SortExpression="SerialNo" >
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Local Coveyance Mode" SortExpression="TA_LCModes13_ModeName">
          <ItemTemplate>
          <LGM:LC_taLCModes
            ID="F_ModeLCID"
            SelectedValue='<%# Bind("ModeLCID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="108px"
            CssClass="myddl"
            OnSelectedIndexChanged="DDLChanged"
            AutoPostBack="True"
            Runat="Server" />
          <asp:TextBox ID="F_ModeText"
            Text='<%# Bind("ModeText") %>'
            Width="100px"
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            MaxLength="100"
            runat="server" />
          <AJX:TextBoxWatermarkExtender 
            ID="TBWMEOtherMode" 
            runat="server" 
            TargetControlID="F_ModeText"
            WatermarkCssClass="waterMark"
            WatermarkText="[Other Mode]" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="In City" SortExpression="TA_Cities6_CityName">
          <ItemTemplate>
          <asp:TextBox
            ID = "F_City1ID"
            CssClass = "myfktxt"
            Text='<%# Bind("City1ID") %>'
            AutoCompleteType = "None"
            Width="100px"
            onfocus = "return this.select();"
            onblur= "script_City1ID.validate_City1ID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_City1ID_Display"
            Text='<%# Eval("TA_Cities6_CityName") %>'
            CssClass="myLbl"
            style="display:none;"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECity1ID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="City1IDCompletionList"
            TargetControlID="F_City1ID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_City1ID.ACECity1ID_Selected"
            OnClientPopulating="script_City1ID.ACECity1ID_Populating"
            OnClientPopulated="script_City1ID.ACECity1ID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
          <asp:TextBox ID="F_City1Text"
            Text='<%# Bind("City1Text") %>'
            Width="100px"
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            MaxLength="100"
            runat="server" />
          <AJX:TextBoxWatermarkExtender 
            ID="TBWMECity1Text" 
            runat="server" 
            TargetControlID="F_City1Text"
            WatermarkCssClass="waterMark"
            WatermarkText="[Other City]" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="From Address" SortExpression="FromAddress">
          <ItemTemplate>
          <asp:TextBox ID="F_FromAddress"
            Text='<%# Bind("FromAddress") %>'
            Width="120px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            TextMode="MultiLine"
            Height="60px"
            MaxLength="250"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFromAddress"
            runat = "server"
            ControlToValidate = "F_FromAddress"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "taBDmLC" & Container.DataItemIndex %>'
            SetFocusOnError="true" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="To Address" SortExpression="ToAddress">
          <ItemTemplate>
          <asp:TextBox ID="F_ToAddress"
            Text='<%# Bind("ToAddress") %>'
            Width="120px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            TextMode="MultiLine"
            Height="60px"
            MaxLength="250"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVToAddress"
            runat = "server"
            ControlToValidate = "F_ToAddress"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "taBDmLC" & Container.DataItemIndex %>'
            SetFocusOnError="true" />
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date Time" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="L_StartTime" runat="server" Text="Starting: "></asp:Label>
          <asp:TextBox ID="F_Date1Time"
            Text='<%# Bind("Date1Time") %>'
            Width="120px"
            CssClass = "mytxt"
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            runat="server" />
          <asp:Image ID="ImageButtonDate1Time" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDate1Time"
            TargetControlID="F_Date1Time"
            Format="dd/MM/yyyy HH:mm"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDate1Time" />
          <AJX:MaskedEditExtender 
            ID = "MEEDate1Time"
            runat = "server"
            mask = "99/99/9999 99:99"
            MaskType="DateTime"
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
            EmptyValueBlurredText = "*"
            InvalidValueMessage="*"
            Display = "Dynamic"
            EnableClientScript = "True"
            IsValidEmpty="False"
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            ForeColor="red"
            SetFocusOnError="True" />
            <asp:Label ID="L_Reaching" runat="server" Text="Reaching: "></asp:Label>
          <asp:TextBox ID="F_Date2Time"
            Text='<%# Bind("Date2Time") %>'
            Width="120px"
            CssClass = ""
            Enabled="false"
            onfocus = "return this.select();"
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            runat="server" />
          <asp:Image ID="ImageButtonDate2Time" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDate2Time"
            TargetControlID="F_Date2Time"
            Format="dd/MM/yyyy HH:mm"
            Enabled="false"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDate2Time" />
          <AJX:MaskedEditExtender 
            ID = "MEEDate2Time"
            runat = "server"
            mask = "99/99/9999 99:99"
            MaskType="DateTime"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Date2Time" />
          <AJX:MaskedEditValidator 
            ID = "MEVDate2Time"
            runat = "server"
            ControlToValidate = "F_Date2Time"
            ControlExtender = "MEEDate2Time"
            EmptyValueBlurredText = "*"
            InvalidValueMessage="*"
            Display = "Dynamic"
            EnableClientScript = "true"
            Enabled="false"
            IsValidEmpty = "False"
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            ForeColor="red"
            SetFocusOnError="true" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total KM" SortExpression="AmountRate">
          <ItemTemplate>
          <asp:TextBox ID="F_AmountRate"
            Text='<%# Bind("AmountRate") %>'
            Width="80px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            MaxLength="8"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
           <asp:RangeValidator 
             ID="RVF_AmountRate"
             ControlToValidate="F_AmountRate"
             MinimumValue="0.01"
             MaximumValue="99999.99"
             Type="Double"
             EnableClientScript="True"
             Text="*"
             Enabled="true"
             ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
             ErrorMessage = "<div class='errorLG'>Required!</div>"
             SetFocusOnError="true"
             ForeColor="Red"
             runat="server"/>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignright" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="" SortExpression="AmountRateOU">
          <ItemTemplate>
           <asp:Label ID="L_RateAmount" runat="server" Text=""></asp:Label>
          <asp:TextBox ID="F_AmountRateOU"
            Text='<%# Bind("AmountRateOU") %>'
            style="text-align: right"
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            MaxLength="8"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignright" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Additional Charges">
         <ItemTemplate>
           <table>
             <tr>
               <td>Night Charges</td>
               <td>            
                 <asp:CheckBox ID="F_StayedWithRelative"
                  Checked='<%# Bind("StayedWithRelative") %>'
                  Enabled="false"
                  runat="server" />
              </td>
             </tr>
             <tr>
               <td>Non Availability Charges</td>
               <td>
                <asp:CheckBox ID="F_StayedInGuestHouse"
                  Checked='<%# Bind("StayedInGuestHouse") %>'
                  Enabled="false"
                  runat="server" />
               </td>
             </tr>
             <tr>
               <td>Inter-State Toll</td>
               <td>
                <asp:CheckBox ID="F_StayedAtSite"
                  Checked='<%# Bind("StayedAtSite") %>'
                  Enabled="false"
                  runat="server" />
               </td>
             </tr>
           </table>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Currency" SortExpression="TA_Currencies10_CurrencyName">
          <ItemTemplate>
          <LGM:LC_taCurrencies
            ID="F_CurrencyID"
            SelectedValue='<%# Bind("CurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="100px"
            CssClass="myddl"
            ValidationGroup = '<%# "taBDmLC" & Container.DataItemIndex %>'
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Main Currency" SortExpression="CurrencyMain">
          <ItemTemplate>
          <asp:TextBox ID="F_CurrencyMain"
            Text='<%# Bind("CurrencyMain") %>'
            Width="56px"
            CssClass = "dmytxt"
            MaxLength="6"
            enabled="false"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="C.F. To Main Currency" SortExpression="ConversionFactorOU">
          <ItemTemplate>
          <asp:TextBox ID="F_ConversionFactorOU"
            Text='<%# Bind("ConversionFactorOU") %>'
            style="text-align: right"
            Width="100px"
            CssClass ='<%# dCssClass %>'
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,6);"
            Enabled='<%# IsForeign %>'
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignright" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Airport To/From Hotel/Client Location" SortExpression="AirportToHotel">
          <ItemTemplate>
          <asp:CheckBox ID="F_AirportToHotel"
            Checked='<%# Bind("AirportToHotel") %>'
            CssClass = "mychk"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
          <ItemTemplate>
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="100px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            MaxLength="500"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="">
          <ItemTemplate>
            <asp:Button ID="cmdSubmit" runat="server" Text="C" CommandName="x" ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="20px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBDLC"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBDLC"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBDLCSelectListForNew"
      TypeName = "SIS.TA.taBDLC"
      SelectCountMethod = "taBDLCSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBDLC" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>




</div>
</div>
</asp:Content>
