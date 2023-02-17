<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="gradient_dashboard.aspx.cs" Inherits="TomTom_Info_Page.cpp.gradient_dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <title></title>  

    <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
            vertical-align:text-bottom;
            margin-top:-60px;
        }      
    pre
	{margin-bottom:.0001pt;
	font-size:10.0pt;
	font-family:"Courier New";
	        margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
 p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;
	        margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
    </style> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Timer ID="Timer1" runat="server" OnTick="Page_Load" Interval="208000">
    </asp:Timer>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">  
 
<body>  

   <!-- <asp:FileUpload ID="FileUpload1" CssClass="button" runat="server" />  
    --> 
    <br />
    <asp:Label ID="Label4" runat="server" Text="Gradient Dashboard" Font-Size="Larger" Font-Bold="True"></asp:Label>
    &nbsp;<br />
    <hr />
    <br />
    Latest report in csv: <asp:HyperLink ID="HyperLink1" runat="server" >       </asp:HyperLink><br />
     <br /> Jenkins job: <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://jenkins-adp-lodz.tomtomgroup.com:8080/view/Dashboards/job/GradientDashboard/ws/" Target="_blank">http://jenkins-adp-lodz.tomtomgroup.com:8080/view/Dashboards/job/GradientDashboard/ws/</asp:HyperLink>
     &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Visible="False" Text="Refresh report" />
&nbsp;(it will take ~0.5h)<br />
    <br />
    <asp:TextBox ID="TextBox1" runat="server" Width="32px" AutoPostBack="True" Visible="False">300</asp:TextBox>
    &nbsp;&nbsp;&nbsp; Report date_time:
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
<br />

 
    <asp:GridView ID="GridView1" runat="server"  HeaderStyle-BackColor="YellowGreen" 
AutoGenerateColumns="false" AlternatingRowStyle-BackColor="WhiteSmoke" 
OnRowDataBound="gvDistricts_RowDataBound" Font-Size="Smaller">  
        <Columns>
            <asp:TemplateField HeaderText="pID" 

            HeaderStyle-Width="50px" ItemStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblpID" runat="server" 

                    Text='<%#Eval("pID")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="pName" 

            HeaderStyle-Width="150px" ItemStyle-Width="150px">
                <ItemTemplate>
                    <asp:Label ID="lblpName" runat="server" 

                    Text='<%#Eval("pName")%>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
<asp:TemplateField HeaderText="Total" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <asp:Label ID="lblTotal" runat="server" 

                    Text='<%#Eval("Total")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total to write" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <asp:Label ID="lblTotaltowrite" runat="server" 

                    Text='<%#Eval("Total to write")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>
            <asp:TemplateField HeaderText="ToDo" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <asp:Label ID="lblToDo" runat="server" 

                    Text='<%#Eval("ToDo")%>'></asp:Label>
                </ItemTemplate>
        </asp:TemplateField>

<asp:TemplateField HeaderText="Progress %" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <asp:Label ID="Progress" runat="server" 

                    Text='<%#Eval("Progress %")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>
            <asp:TemplateField HeaderText="Success" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <asp:Label ID="lblSuccess" runat="server" 

                    Text='<%#Eval("Success")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>
            <asp:TemplateField HeaderText="Total failed" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <asp:Label ID="lblToFailed" runat="server" 

                    Text='<%#Eval("Total failed")%>'></asp:Label>
                </ItemTemplate>
        </asp:TemplateField>
            <asp:TemplateField HeaderText="CSR %" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <asp:Label ID="lblCSR" runat="server" 

                    Text='<%#Eval("CSR %")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>


                        <asp:TemplateField HeaderText="Failed - PE" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999980" ItemStyle-BackColor="#CCCCB0">
                <ItemTemplate>
                    <asp:Label ID="Failed_PE" runat="server" 
                    Text='<%#Eval("Failed - PE")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>


                   <asp:TemplateField HeaderText="Failed - NTC" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="Failed_NTC" runat="server" 
                    Text='<%#Eval("Failed - NTC")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField> 
             <asp:TemplateField HeaderText="Failed - QA" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="Failed_QA" runat="server" 
                    Text='<%#Eval("Failed - QA")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>     
            <asp:TemplateField HeaderText="QAR %" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="QAR" runat="server" 
                    Text='<%#Eval("QAR %")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>     

            <asp:TemplateField HeaderText="Failed - CRF" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="Failed_CRF" runat="server" 
                    Text='<%#Eval("Failed - CRF")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>
            

            <asp:TemplateField HeaderText="Failed - CE" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="Failed_CE" runat="server" 
                    Text='<%#Eval("Failed - CE")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>

            <asp:TemplateField HeaderText="Failed - DAE" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="Failed_DAE" runat="server" 
                    Text='<%#Eval("Failed - DAE")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>
            <asp:TemplateField HeaderText="Failed - IVV" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="Failed_IVV" runat="server" 
                    Text='<%#Eval("Failed - IVV")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>
            <asp:TemplateField HeaderText="Failed - NER" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="Failed_NER" runat="server" 
                    Text='<%#Eval("Failed - NER")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>
            <asp:TemplateField HeaderText="Failed - OCP" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="Failed_OCP" runat="server" 
                    Text='<%#Eval("Failed - OCP")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>

            <asp:TemplateField HeaderText="Not Processed - NFC" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="NFC" runat="server" 
                    Text='<%#Eval("Not Processed - NFC")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>

            <asp:TemplateField HeaderText="Not Processed - UE" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="UE" runat="server" 
                    Text='<%#Eval("Not Processed - UE")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>

            <asp:TemplateField HeaderText="Not Processed - LQ" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="LQ" runat="server" 
                    Text='<%#Eval("Not Processed - LQ")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>

            <asp:TemplateField HeaderText="Not Processed - ND" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="ND" runat="server" 
                    Text='<%#Eval("Not Processed - ND")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>
            <asp:TemplateField HeaderText="Not Processed - LOC" 

            HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="LOC" runat="server" 
                    Text='<%#Eval("Not Processed - LOC")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>
            <asp:TemplateField HeaderText="Other" 

            HeaderStyle-Width="50px" ItemStyle-Width="50px" HeaderStyle-BackColor="#999999" ItemStyle-BackColor="#CCCCCC">
                <ItemTemplate>
                    <asp:Label ID="Other" runat="server" 
                    Text='<%#Eval("Other")%>'></asp:Label>
                </ItemTemplate>
</asp:TemplateField>
            

                
        </Columns>
    </asp:GridView>

    <br />
    <br />
    <pre><span style="font-size:10.5pt;color:#333333">***Legend***<o:p></o:p></span></pre>
    <p class="MsoNormal">
        <span style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333"><o:p>&nbsp;</o:p></span></p>
    <p class="MsoNormal">
        <span style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333">pID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Project ID.<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333">pN</span><span lang="EN-US" style="font-size:10.5pt;font-family:
&quot;Courier New&quot;;color:#333333;mso-ansi-language:EN-US">ame&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Project name.<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Total&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total number of transactions registered for that project.<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Total to write -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total number of transactions able to be written.<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">ToDo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Number of transactions waiting to be processed (transactions currently processed by GTW are still included here).<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Progress&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Number (in %) of processed transactions.<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Success&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Number of transactions successfully commited.<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">CSR&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Current success rate, how many % of already processed transaction were successful (useful when GTW is running).<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed NTC&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Number of transactions that had nothing to commit (ignorable).<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed Decode&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Number of transactions that failed because geometry changed after GSP started and decode couldn&#39;t map them onto new geometry.<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed QA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Number of transactions that failed due to some QA rules being violated (violated rules are stored in a separate table).<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed IAE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Illegal Argument Exception<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed PE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Processing Exception<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed CCFT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cannot Convert From Ttom<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed CCE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Class Cast Exception<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed CRF&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Client Response Failure<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed CE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Connection Exception<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed DAE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Database Access Exception<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed ISE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Number of transactions that failed because of illegalStateException (this shouldn&#39;t really happen, report for investigation).<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed ILAC&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Inconsistent Length And Chainage<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed IVV&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Inconsistent Values On V2 Within Stretch<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed NER&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Non Existing Road Element On Branch<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Failed OCP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Other Cpp Problem - coredb-main-ws returned unexpected error<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Not Processed ME&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Matching error - errors while performing matching based on correspondence db<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Not Processed NFC&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Not fully covered - match does not cover the entire length of stretch<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Not Processed UE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Unexpected error<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Not Processed LQ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Low quality - matched moma data had low quality and was rejected<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Not Processed ND&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; No data - no correspondenses in database<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="font-size:10.5pt;font-family:&quot;Courier New&quot;;
color:#333333;mso-ansi-language:EN-US">Not Processed LOC&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lack of context to interpolate, extrapolate - some points of data in match were rejected due to quality and can not be interpolated/extrapolated<o:p></o:p></span></p>
    <p class="MsoNormal">
        <span lang="EN-US" style="mso-ansi-language:EN-US;mso-fareast-language:
EN-US"><o:p>&nbsp;</o:p></span></p>
    <br />
    History reports: <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="\\ams2-svm01-cifs.ttg.global\sppproc\tifdata\TSD\Gradient\dashboard" Target="_blank">\\ams2-svm01-cifs.ttg.global\sppproc\tifdata\TSD\Gradient\dashboard</asp:HyperLink>
    
</body>  
</html>  
    <asp:Label ID="lbl_err" runat="server" Text=""></asp:Label>
</asp:Content>




