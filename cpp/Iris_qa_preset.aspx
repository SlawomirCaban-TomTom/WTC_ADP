<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Iris_qa_preset.aspx.cs" Inherits="TomTom_Info_Page.cpp.Iris_qa_preset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            font-size: x-large;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
        <tr>
            <td class="auto-style2">
                Project qa preset checker</td>
        </tr>
    </table>
    <hr />
    <table><tr><td>
    <asp:TextBox ID="tb_project" runat="server" Width="386px"></asp:TextBox> </td><td></td>
        
        <td><asp:Button ID="bt_add" runat="server" Text="Check" OnClick="bt_add_Click" />
            </td></tr></table>
    <br />
    <asp:Label ID="lbl_result" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
    <br />

    <asp:Label ID="lbl_err" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
</asp:Content>
