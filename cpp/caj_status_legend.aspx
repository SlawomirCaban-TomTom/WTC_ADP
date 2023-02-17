<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="caj_status_legend.aspx.cs" Inherits="TomTom_Info_Page.cpp.caj_status_legend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
        .auto-style2 {
            height: 20px;
            width: 115px;
        }
        .auto-style3 {
            width: 115px;
        }
        .auto-style4 {
            height: 20px;
            width: 143px;
        }
        .auto-style5 {
            width: 143px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    CAJ status description
    <hr />
    <br />
Acitivities<table border="1" style="border-collapse: collapse; width: 80%; font-size: small;" width="694">
    <colgroup>
        <col span="2" width="257" />
        <col width="180" />
    </colgroup>
    <tr height="20">
        <td height="20" style="background-color: #FFFFCC" width="257"><strong>activity_id</strong></td>
        <td style="background-color: #FFFFCC" width="257"><strong>initial_state_id</strong></td>
        <td style="background-color: #FFFFCC" width="180"><strong>description</strong></td>
    </tr>
    <tr height="20">
        <td height="20">11111111-0000-0000-0000-000000000003</td>
        <td>11111111-0000-0000-0001-000000000003</td>
        <td>Auto calculation activity</td>
    </tr>
    <tr height="20">
        <td height="20" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
        <td style="background-color: #C0C0C0">11111111-0000-0000-0001-000000000004</td>
        <td style="background-color: #C0C0C0">Manual calculation activity</td>
    </tr>
    <tr height="20">
        <td height="20">11111111-0000-0000-0000-000000000005</td>
        <td>11111111-0000-0000-0001-000000000005</td>
        <td>Transaction commit activity</td>
    </tr>
    <tr height="20">
        <td height="20" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
        <td style="background-color: #C0C0C0">11111111-0000-0000-0001-000000000007</td>
        <td style="background-color: #C0C0C0">QC activity</td>
    </tr>
</table>
<br />
Activities/Statuses<table style="border-collapse:collapse;width:80%; font-size: small;" width="100%" border="1">
        <colgroup>
            <col />
            <col span="2" style="width:48pt" width="64" />
        </colgroup>
        <tr>
            <td class="auto-style2" style="background-color: #FFFFCC"><strong>activity_id</strong></td>
            <td class="auto-style4" style="background-color: #FFFFCC"><strong>state_id</strong></td>
            <td width="64" class="auto-style1" style="background-color: #FFFFCC"><strong>description</strong></td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3">11111111-0000-0000-0000-000000000003</td>
            <td class="auto-style5">11111111-0000-0000-0001-000000000003</td>
            <td>Automatic Calculation requested</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3">11111111-0000-0000-0000-000000000003</td>
            <td class="auto-style5">11111111-0000-0000-0002-000000000003</td>
            <td>Automatic Calculation succeeded</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3">11111111-0000-0000-0000-000000000003</td>
            <td class="auto-style5">11111111-0000-0000-0003-000000000003</td>
            <td>Automatic Calculation could not be performed by lack of data</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3">11111111-0000-0000-0000-000000000003</td>
            <td class="auto-style5">11111111-0000-0000-0004-000000000003</td>
            <td>Automatic Calculation failed with error</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3">11111111-0000-0000-0000-000000000003</td>
            <td class="auto-style5">11111111-0000-0000-0005-000000000003</td>
            <td>Automatic calculation done and in QC</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3">11111111-0000-0000-0000-000000000003</td>
            <td class="auto-style5">11111111-0000-0000-0006-000000000003</td>
            <td>Automatic calculation not needed - populated in coredb</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0001-000000000004</td>
            <td style="background-color: #C0C0C0">manual_requested</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0002-000000000004</td>
            <td style="background-color: #C0C0C0">manual_done</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0003-000000000004</td>
            <td style="background-color: #C0C0C0">manual_reject</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0004-000000000004</td>
            <td style="background-color: #C0C0C0">manual_moved_to_qc</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0005-000000000004</td>
            <td style="background-color: #C0C0C0">feeder_tool_exception</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0006-000000000004</td>
            <td style="background-color: #C0C0C0">manual reject - ADA realignment needed</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0007-000000000004</td>
            <td style="background-color: #C0C0C0">manual reject - Source missing</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0008-000000000004</td>
            <td style="background-color: #C0C0C0">manual reject - CoreDB changed</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0009-000000000004</td>
            <td style="background-color: #C0C0C0">manual reject - Technical radius missing</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0010-000000000004</td>
            <td style="background-color: #C0C0C0">manual reject - Technical source material issue</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0011-000000000004</td>
            <td style="background-color: #C0C0C0">manual reject - Technical Other</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000004</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0012-000000000004</td>
            <td style="background-color: #C0C0C0">manual reject - reject is handled.</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3">11111111-0000-0000-0000-000000000005</td>
            <td class="auto-style5">11111111-0000-0000-0001-000000000005</td>
            <td>commit_requested</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3">11111111-0000-0000-0000-000000000005</td>
            <td class="auto-style5">11111111-0000-0000-0002-000000000005</td>
            <td>commit_done</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3">11111111-0000-0000-0000-000000000005</td>
            <td class="auto-style5">11111111-0000-0000-0003-000000000005</td>
            <td>commit_exception</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0001-000000000007</td>
            <td style="background-color: #C0C0C0">qc_init</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0002-000000000007</td>
            <td style="background-color: #C0C0C0">qc_done</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0003-000000000007</td>
            <td style="background-color: #C0C0C0">qc_reject</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0004-000000000007</td>
            <td style="background-color: #C0C0C0">qc_update_db</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0005-000000000007</td>
            <td style="background-color: #C0C0C0">qc_update_tool_exception</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0006-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - ADA realignment needed</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0007-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - Source missing</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0008-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - CoreDB changed</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0009-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - Technical radius missing</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0010-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - Technical source material issue</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0011-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - Technical Other</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0012-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - reject is handled.</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0016-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - ADA realignment needed (QC DB updated)</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0017-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - Source missing (QC DB updated)</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0018-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - CoreDB changed (QC DB updated)</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0019-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - Technical radius missing (QC DB updated)</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0020-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - Technical source material issue (QC DB updated)</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3" style="background-color: #C0C0C0">11111111-0000-0000-0000-000000000007</td>
            <td class="auto-style5" style="background-color: #C0C0C0">11111111-0000-0000-0021-000000000007</td>
            <td style="background-color: #C0C0C0">QC reject - Technical Other (QC DB updated)</td>
        </tr>
        <tr height="20">
            <td height="20" class="auto-style3"></td>
            <td class="auto-style5"></td>
            <td></td>
        </tr>
    </table>

</asp:Content>
