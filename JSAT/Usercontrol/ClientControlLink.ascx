<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientControlLink.ascx.cs" Inherits="JSAT_Ver1.Usercontrol.ClientControlLink" %>
<asp:LinkButton runat="server" ID="lnkProfile"  onclick="lnkProfile_Click"  CausesValidation="False" Enabled="false">01.Client Profile</asp:LinkButton><br />
(クライアントプロフィル)<br />
<br />
<asp:LinkButton runat="server" ID="lnkRecruitment"  onclick="lnkRecruitment_Click"  CausesValidation="False" Enabled="false" >02.Client Recruitment</asp:LinkButton><br />
(クライアントの募集)<br />
<br />
<asp:LinkButton runat="server" ID="lnkCVHistory" onclick="InkCVHistory_Click"  
    CausesValidation="False"  Enabled="false" Visible="False">03.CV History</asp:LinkButton>
<br />
<p>
    &nbsp;</p>

