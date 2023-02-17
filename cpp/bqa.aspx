<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="bqa.aspx.cs" Inherits="TomTom_Info_Page.cpp.bqa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type = "text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
        function SetTargetSelf() {
            document.forms[0].target = "_self";
        }

</script>

    <br />

    <asp:Label ID="Label1" runat="server" Text="BQA support page" Font-Size="Larger" Font-Bold="True"></asp:Label>
    <br /> <hr />
    <a href="https://confluence.tomtomgroup.com/display/ADP/BQA+Slow+Rules"> https://confluence.tomtomgroup.com/display/ADP/BQA+Slow+Rules</a><br />
    <a href="http://bulkqa-bqamaas1-cpp-r2.service.eu-west-1-mapsco.maps-contentops.amiefarm.com/qa-webservice/qa/getDeployedJars">Rule package on maas1</a><br />
    <a href="http://bulkqa-bqamaas3-cpp-r2.service.eu-west-1-mapsco.maps-contentops.amiefarm.com/qa-webservice/qa/getDeployedJars">Rule package on maas3</a><br />
    <a href="http://bulkqa-bqamaas1.maps-india-contentops.amiefarm.com/qa-webservice/qa/getDeployedJars">Rule package on IND maas1</a><br />
    <a href="http://bulkqa-bqamaas3.maps-india-contentops.amiefarm.com/qa-webservice/qa/getDeployedJars">Rule package on IND maas3</a><br />

    <asp:Button ID="btnreset" runat="server" OnClick="btnreset_Click" Text="Reset" />
    <br />
   
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>WORLD</asp:ListItem>
        <asp:ListItem>INDIA</asp:ListItem>
        <asp:ListItem>KOREA</asp:ListItem>
    </asp:DropDownList>
  
    <asp:textbox runat="server" ID="txtJobid" Width="334px">jobid</asp:textbox>
    <asp:button runat="server" text="Get violated rules" ID="btnGetViolRules" OnClientClick = "SetTargetSelf();"  OnClick="btnGetViolRules_Click" Width="145px" />
    <asp:Button ID="btnGetvioltiles" runat="server" OnClientClick = "SetTargetSelf();"  OnClick="btnGetvioltiles_Click" Text="Get violated tiles" Width="134px" />
    &nbsp;
    
    <asp:Button ID="btnGetfailedtiles" runat="server" OnClick="btnGetfailedtiles_Click"  OnClientClick = "SetTargetSelf();" Text="Get failed tiles" Width="134px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSlowRulesKibana" runat="server" OnClick="btnSlowRulesKibana_Click"  OnClientClick = "SetTarget();"  Text="Show slow rules" Width="134px" />

    &nbsp;<asp:Button ID="btnGetviolations" runat="server" Text="Get violations" OnClick="btnGetviolations_Click" />
&nbsp;<asp:Label ID="lblViolCount" runat="server" Text="ViolCount" Visible="False"></asp:Label>
    <br />



    <asp:Label ID="lblViolatedRules" runat="server" Text="Violated rules" Visible="False"></asp:Label>
    <br />
    <asp:TextBox ID="txtViolatedRules" runat="server" Height="73px" TextMode="MultiLine" Visible="False" Width="1072px"></asp:TextBox>



    <br /><br /><br />
    <asp:TextBox ID="txtPresetid" runat="server">presetid</asp:TextBox>
    <asp:Button ID="btnGetrules" runat="server" Text="Get rules for preset"  OnClientClick = "SetTargetSelf();" OnClick="btnGetrules_Click" />
    <asp:Button ID="btnGetallrules" runat="server" OnClick="btnGetallrules_Click" OnClientClick = "SetTarget();"  Text="Get ALL rules" />

    <br />
    <asp:Label ID="lblRulesforpreset" runat="server" Text="Rules for preset" Visible="False"></asp:Label>
    <br />
    <asp:TextBox ID="txtRulesforpreset" runat="server" Height="133px" TextMode="MultiLine" Visible="False" Width="1070px"></asp:TextBox>




    <br />
   
    <asp:TextBox ID="tb_rid" runat="server" ToolTip="please provide coma separated RuleIds" Width="815px" Text="ruleid" EnableViewState="True"></asp:TextBox> 
    <asp:Button ID="Button1" runat="server" Text="Get rule message" OnClick="get_message_for_rules" />
    <br />

    <asp:Label ID="Label2" runat="server" Text="RuleID; Violation message" Font-Bold="True" Visible="False"></asp:Label>
    <br />
    <asp:TextBox ID="tb_rid_message" runat="server" Height="133px" TextMode="MultiLine" Visible="False" Width="1070px"></asp:TextBox>
        
    <br />
    <asp:Button ID="ButtonRefresh" runat="server" OnClick="ButtonRefresh_Click" Text="Show last BQA jobs" />
        
    &nbsp;<asp:CheckBox ID="CheckBoxFailed" runat="server" Text="show failed tiles count" />
        
    <br />
    <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" Font-Size="Smaller" ForeColor="Black" GridLines="None">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <sortedascendingcellstyle backcolor="#FAFAE7" />
        <sortedascendingheaderstyle backcolor="#DAC09E" />
        <sorteddescendingcellstyle backcolor="#E1DB9C" />
        <sorteddescendingheaderstyle backcolor="#C2A47B" />
    </asp:GridView>
    <br /><br />
   

     <asp:Label ID="lbl_err" runat="server" Visible="False" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
</asp:Content>
