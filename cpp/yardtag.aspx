<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="yardtag.aspx.cs" Inherits="TomTom_Info_Page.yardtag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Label ID="Label4" runat="server" Text="YARD TAG Checker" Font-Size="Larger" 
        Font-Bold="True"></asp:Label>
    <br />
    <br />
    Choose environment:
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>WORLD</asp:ListItem>
        <asp:ListItem>INDIA</asp:ListItem>
        <asp:ListItem>KOREA</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    Search by:
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
        Height="64px" Width="175px" 
        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
        <asp:ListItem Value="branch">branch</asp:ListItem>
        <asp:ListItem Value="continent">continent / version</asp:ListItem>
    </asp:RadioButtonList>
    

    <br />
    

<asp:Label ID="branchID" runat="server" Text="branch: " ></asp:Label><asp:textbox runat="server" ID="branchTxtbox" Width="294px"></asp:textbox>
    
    

    &nbsp;<asp:Label ID="continent" runat="server" Text="continent: " ></asp:Label><asp:textbox runat="server" ID="continentTxtbox" Width="294px"></asp:textbox>
    <asp:Label ID="version" runat="server" Text="version: " ></asp:Label><asp:textbox runat="server" ID="versionTxtbox" Width="294px"></asp:textbox>
    <br />
    <br />
    <asp:Button runat="server" Text="Search" onclick="Unnamed1_Click"></asp:Button><br />
    <br />
    <br />
    Result:<br />
    <asp:TextBox ID="output" runat="server" Height="69px" TextMode="MultiLine" 
        Width="507px" Font-Bold="True" ForeColor="#0000CC"></asp:TextBox>
    <br />

</asp:Content>




