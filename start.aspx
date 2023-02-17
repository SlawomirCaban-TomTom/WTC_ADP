<%@ Page Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true"
    CodeBehind="start.aspx.cs" Inherits="TomTom_Info_Page.start" Title="ADP Info Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .newStyle1
        {
            font-family: "High Tower Text";
            font-weight: bold;
            color: #800000;
            height: 25px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <table>
    <tr>
                
                <td align="center"><asp:Image ID="Image1" runat="server" BorderColor="#FFFF66" BorderStyle="Inset" 
                        BorderWidth="3px" ImageUrl="~/img/ADP_LODZ.jpg" Height="525px" Width="944px"  />
                    </tr>
                    <tr><td>
                        
                     
                       
                </td>
            
        </tr>
<tr><td>
                        
                     
                       
                </td>
            
        </tr>
  <tr>
                
                <td align="center"><asp:Image ID="Image2" runat="server" BorderColor="#FFFF66" BorderStyle="Inset" 
                        BorderWidth="3px" ImageUrl="~/img/ADP_PUNE.png" Height="480px" Width="954px"  />
                    </tr>
                    <tr><td>
                        
                     
                       
                </td>
            
        </tr>
    </table>
       

       <br />
       <br />
    

       <asp:Label ID="Label1" runat="server" 
    Text="Update in progress - some functionality may not work!" Font-Bold="False" ></asp:Label>
</asp:Content>
