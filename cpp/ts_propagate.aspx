<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="ts_propagate.aspx.cs" Inherits="TomTom_Info_Page.cpp.ts_propagate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label4" runat="server" Text="Traffic Signs Propagate" Font-Size="Larger" Font-Bold="True"></asp:Label>
    <br />
    <hr />
    Press Button to select projects with transactions and propagate them on machines.
&nbsp;&nbsp;
<br />
<br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />&nbsp;&nbsp;&nbsp;
<asp:CheckBox ID="CheckBox1" runat="server" Text="start on machine" Checked="False" Enabled="False" Visible="False" />
<asp:CheckBox ID="CheckBox2" runat="server" Text="start in jenkins" Checked="False" Enabled="True" />
    <br />

    <br />
    Properties ONLY  for jenkins:  branchid&nbsp; <asp:TextBox ID="TextBox2" runat="server" Width="251px">233b38a4-f0bf-4289-bfdc-7f2a04fc4ab3</asp:TextBox>
     loadThreads: <asp:TextBox ID="TextBox3" runat="server" Width="35px">10</asp:TextBox>
    applyThreads: <asp:TextBox ID="TextBox4" runat="server" Width="35px">5</asp:TextBox>
    <br />
    <a href="http://jenkins.prod.tcnfs.tthad.net:8080/jenkins/view/Traffic-Signs/job/ts-traffic-signs-transaction-generator-batch/" target="_blank">http://jenkins.prod.tcnfs.tthad.net:8080/jenkins/view/Traffic-Signs</a>
    <br />
    <asp:TextBox ID="TextBox1" runat="server" Height="540px" TextMode="MultiLine" Width="780px"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lbl_err" runat="server" Text=""></asp:Label>
   
</asp:Content>
