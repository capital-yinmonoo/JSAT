<%@ Page Title="人材基本情報編集(DATA & PHOTO)" AutoEventWireup="true" MasterPageFile="~/Site.Master" Language="C#" CodeBehind="Career_Information.aspx.cs" Inherits="JSAT.Employee.Career_Information" %>
<%@ Register src="../Usercontrol/Career_InterviewControl.ascx" tagname="Career_InterviewControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../Styles/tooltip.css" rel="stylesheet" type="text/css" />
    <script src="../Styles/tooltip.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- preview image-->
    <div id="divBackground" class="modal">
</div>
    <div id="divImage">
    <table style="height: 100%; width: 100%">
        <tr>
            <td valign="middle" align="center">
                <img id="imgLoader" alt=""
                 src="images/loader.gif" />
                <img id="imgFull" alt="" src=""
                 style="display: none;
                height: 500px;width: 590px" />
            </td>
        </tr>
        <tr>
            <td align="center" valign="bottom">
                <input id="btnClose" type="button" value="close"
                 onclick="HideDiv()"/>
            </td>
        </tr>
    </table>
</div>
    <style type="text/css">
     body
     {
        margin:0;
        padding:0;
        height:100%;
     }
     .modal
     {
        display: none;
        position: absolute;
        top: 0px;
        left: 0px;
        background-color:black;
        z-index:100;
        opacity: 0.8;
        filter: alpha(opacity=60);
        -moz-opacity:0.8;
        min-height: 100%;
     }
     #divImage
     {
        display: none;
        z-index: 1000;
        position: fixed;
        top: 0;
        left: 0;
        background-color:White;
        height: 550px;
        width: 600px;
        padding: 3px;
        border: solid 1px black;
     }
   </style>
   <script type="text/javascript">
       function LoadDiv(url) {
           var img = new Image();
           var bcgDiv = document.getElementById("divBackground");
           var imgDiv = document.getElementById("divImage");
           var imgFull = document.getElementById("imgFull");
           var imgLoader = document.getElementById("imgLoader");
           imgLoader.style.display = "block";
           img.onload = function () {
               imgFull.src = img.src;
               imgFull.style.display = "block";
               imgLoader.style.display = "none";
           };
           img.src = url;
           var width = document.body.clientWidth;
           if (document.body.clientHeight > document.body.scrollHeight) {
               bcgDiv.style.height = document.body.clientHeight + "px";
           }
           else {
               bcgDiv.style.height = document.body.scrollHeight + "px";
           }
           imgDiv.style.left = (width - 650) / 2 + "px";
           imgDiv.style.top = "20px";
           bcgDiv.style.width = "100%";
           bcgDiv.style.display = "block";
           imgDiv.style.display = "block";
           return false;
       }
       function HideDiv() {
           var bcgDiv = document.getElementById("divBackground");
           var imgDiv = document.getElementById("divImage");
           var imgFull = document.getElementById("imgFull");
           if (bcgDiv != null) {
               bcgDiv.style.display = "none";
               imgDiv.style.display = "none";
               imgFull.style.display = "none";
           }
       }
</script>
    <div >
    <fieldset>
<table width="80%">
<tr>
<td rowspan="15">
    <uc1:Career_InterviewControl ID="Career_InterviewControl1" runat="server" Visible="False"/>
</td>
<td>
    <b>人材基本情報編集(DATA & PHOTO)</b>

</td>
<td>
&nbsp;
<span class="tooltip" onclick="tooltip.pop(this,'#demo2_tip')"><img id="Img1" 
        alt="?" src="../Images/help.png" runat="server" /><br />
    </span>
    &nbsp;<div style="display:none;">
    <div id="demo2_tip">
        <b>Tips</b><br /><br />
        Image type is only PDF, JPG, GIF, DOC, PNG.<br />
        Image size is maximum 10MB.<br />
        Do not allow "&" in image name!
   </div>
   </div>
</td>
<td>
    <div style="{text-align:right;width:80%}">
                <asp:Label ID="lblUpdater" runat="server" Text="更新者ID："></asp:Label>
                &nbsp
                <asp:Label runat="server" ID="lblUpdatedBy"></asp:Label>
                &nbsp
                <asp:Label ID="lblUpdateTime" runat="server" Text="更新日："></asp:Label>
                &nbsp
            <asp:Label runat="server" ID="lblUpdatedDate"></asp:Label>
    </div>
</td>
</tr>

<tr>
<td>
<asp:Label runat="server" Text="名前(Name)" Visible="False"></asp:Label>
</td>
<td>
<asp:TextBox runat="server" ID="txtName" Visible="False"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Label runat="server" Text="性別(Sex)" Visible="False">
</asp:Label>
</td>
<td>
<asp:DropDownList ID="ddlSex" runat="server" Visible="False"></asp:DropDownList>
</td>
</tr>
<tr>
<td>
<asp:Label runat="server" Text="現住所(Current Address)" Visible="False">
</asp:Label>
</td>
<td>
<asp:TextBox runat="server" ID="txtAddress" Visible="False"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Label runat="server" Text="備考(Remarks)" Visible="False"></asp:Label>
</td>
<td>
<asp:TextBox runat="server" ID="txtRemarks" Height="84px" TextMode="MultiLine" 
        Width="209px" Visible="False"></asp:TextBox>
</td>
</tr>
<tr>
<td>
◆SENT TO ALL COMPANIES
    <br />
</td>
</tr>
<tr>
<td style="vertical-align:top;">
    <br />
<asp:Label ID="Datasheet_Data" runat="server" Text="DATA SHEET & EMPLOYMENT RECORD"></asp:Label>
</td>
<td colspan="2" >
    1.<asp:LinkButton runat="server" ID="lnkDatasheetData"  onclick="lnkDatasheetData_Click"></asp:LinkButton> &nbsp; 
    <asp:Button runat="server" ID="btnDatasheetDataDelete" Text="削除する" OnClientClick="ClearFileUpload()"
        Visible="false" onclick="btnDatasheetDataDelete_Click" 
        style="height: 26px"/> 
     <asp:ImageButton ID="imgDatasheetData" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplDatasheetData" onClientClick="ShowText()"/>
<br/>
<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="uplDatasheetData"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    2.<asp:LinkButton runat="server" ID="lnkDatasheetData2" 
        onclick="lnkDatasheetData2_Click"></asp:LinkButton> &nbsp; 
    <asp:Button runat="server" ID="btnDatasheetData2Delete" Text="削除する" 
        Visible="false" onclick="btnDatasheetData2Delete_Click"/>
     <asp:ImageButton ID="imgDatasheetData2" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplDatasheetData2"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="uplDatasheetData2"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    3.<asp:LinkButton runat="server" ID="lnkDatasheetData3" 
        onclick="lnkDatasheetData3_Click"></asp:LinkButton> &nbsp;
        <asp:Button runat="server" ID="btnDatasheetData3Delete" Text="削除する" 
        Visible="false" onclick="btnDatasheetData3Delete_Click" />
         <asp:ImageButton ID="imgDatasheetData3" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplDatasheetData3"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="uplDatasheetData3"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    4.<asp:LinkButton runat="server" ID="lnkDatasheetData4" 
        onclick="lnkDatasheetData4_Click"></asp:LinkButton> &nbsp;
        <asp:Button runat="server" ID="btnDatasheetData4Delete" Text="削除する" 
        Visible="false" onclick="btnDatasheetData4Delete_Click" />
         <asp:ImageButton ID="imgDatasheetData4" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplDatasheetData4"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="uplDatasheetData4"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
      5.<asp:LinkButton runat="server" ID="lnkDatasheetData5" 
        onclick="lnkDatasheetData5_Click"></asp:LinkButton> &nbsp;
        <asp:Button runat="server" ID="btnDatasheetData5Delete" Text="削除する" 
        Visible="false" onclick="btnDatasheetData5Delete_Click" />
         <asp:ImageButton ID="imgDatasheetData5" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplDatasheetData5"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" ControlToValidate="uplDatasheetData5"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    <br />
    <br />
    </td>
</tr>
<tr>
<td style="vertical-align:top;">
<asp:Label ID="Label5" runat="server" Text="JAPANESE SHEET"></asp:Label>
</td>
<td colspan="2">
    1.<asp:LinkButton runat="server" ID="lnkJapaneseData" onclick="lnkJapaneseData_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnJapaneseData" Text="削除する" 
        Visible="false" onclick="btnJapaneseData_Click" />
         <asp:ImageButton ID="imgJapaneseData" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplJapaeseData"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="uplJapaeseData"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
<%--<br />
<asp:Label runat="server" ID="lblJapaneseData"></asp:Label>--%>
    <br />
    2.<asp:LinkButton runat="server" ID="lnkJapaneseData2" 
        onclick="lnkJapaneseData2_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnJapaneseData2" Text="削除する" 
        Visible="false" onclick="btnJapaneseData2_Click" />
         <asp:ImageButton ID="imgJapaneseData2" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplJapaeseData2"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="uplJapaeseData2"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    3.<asp:LinkButton runat="server" ID="lnkJapaneseData3" 
        onclick="lnkJapaneseData3_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnJapaneseData3" Text="削除する" 
        Visible="false" onclick="btnJapaneseData3_Click" />
         <asp:ImageButton ID="imgJapaneseData3" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplJapaeseData3"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="uplJapaeseData3"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    <br />
</td>
</tr>
<tr>
<td style="vertical-align:top;">
<asp:Label ID="Label6" runat="server" Text="CV"></asp:Label>
</td>
<td colspan="2">
    1.<asp:LinkButton runat="server" ID="lnkCredentialData" 
        onclick="lnkCredentialData_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData" Text="削除する" 
        Visible="false" onclick="btnCredentialData_Click" />
         <asp:ImageButton ID="imgCredentialData" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="uplCredentialData"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
<%--<br />
<asp:Label runat="server" ID="lblCredentialData"></asp:Label>--%>
    <br />
    2.<asp:LinkButton runat="server" ID="lnkCredentialData2" 
        onclick="lnkCredentialData2_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData2" Text="削除する"  Visible="false" onclick="btnCredentialData2_Click" />
         <asp:ImageButton ID="imgCredentialData2" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False" />
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData2"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="uplCredentialData2"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    3.<asp:LinkButton runat="server" ID="lnkCredentialData3" 
        onclick="lnkCredentialData_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData3" Text="削除する"  Visible="false" onclick="btnCredentialData3_Click" />
         <asp:ImageButton ID="imgCredentialData3" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData3"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="uplCredentialData3"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />

    4.<asp:LinkButton runat="server" ID="lnkCredentialData4" 
        onclick="lnkCredentialData4_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData4" Text="削除する"  Visible="false" onclick="btnCredentialData4_Click" />
         <asp:ImageButton ID="imgCredentialData4" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData4"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="uplCredentialData4"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    5.<asp:LinkButton runat="server" ID="lnkCredentialData5" 
        onclick="lnkCredentialData5_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData5" Text="削除する"  Visible="false" onclick="btnCredentialData5_Click" />
         <asp:ImageButton ID="imgCredentialData5" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData5"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="uplCredentialData5"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
      6.<asp:LinkButton runat="server" ID="lnkCredentialData6" 
        onclick="lnkCredentialData6_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData6" Text="削除する"  Visible="false" onclick="btnCredentialData6_Click" />
         <asp:ImageButton ID="imgCredentialData6" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData6"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="uplCredentialData6"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
     7.<asp:LinkButton runat="server" ID="lnkCredentialData7" 
        onclick="lnkCredentialData7_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData7" Text="削除する"  Visible="false" onclick="btnCredentialData7_Click" />
         <asp:ImageButton ID="imgCredentialData7" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData7"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ControlToValidate="uplCredentialData7"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    <br />
</td>
</tr>
<tr>
<td style="vertical-align:top;">
<asp:Label ID="Photo" runat="server" Text="Photo"></asp:Label>
</td>
<td colspan="2">
    1.<asp:LinkButton runat="server" ID="lnkPhoto" onclick="lnkPhoto_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnPhoto" Text="削除する" 
        Visible="false" onclick="btnPhoto_Click" />
         <asp:ImageButton ID="imgPhoto" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplPhotoData"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="uplPhotoData"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    2.<asp:LinkButton runat="server" ID="lnkPhoto2" onclick="lnkPhoto2_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnPhoto2" Text="削除する" 
        Visible="false" onclick="btnPhoto2_Click" />
         <asp:ImageButton ID="imgPhoto2" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"   Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplPhotoData2"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="uplPhotoData2"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    3.<asp:LinkButton runat="server" ID="lnkPhoto3" onclick="lnkPhoto3_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnPhoto3" Text="削除する" 
        Visible="false" onclick="btnPhoto3_Click" />
         <asp:ImageButton ID="imgPhoto3" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False" />
        <br />
<asp:FileUpload runat="server" ID="uplPhotoData3"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="uplPhotoData3"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    <br />
</td>
</tr>
<tr>
<td>
◆SENT TO ALL COMPANIES
    <br />
    <br />
</td>
</tr>
<tr>
<td style="vertical-align:top;">
<asp:Label ID="Label7" runat="server" Text="University Certificate"></asp:Label>
</td>
<td colspan="2">
    1.<asp:LinkButton runat="server" ID="lnkGraduationData" 
        onclick="lnkGraduationData_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnGraduationData" Text="削除する" 
        Visible="false" onclick="btnGraduationData_Click" />
         <asp:ImageButton ID="imgGraduationData" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False" />
        <br />
<asp:FileUpload runat="server" ID="uplGraduationData"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="uplGraduationData"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    2.<asp:LinkButton runat="server" ID="lnkGraduationData2" 
        onclick="lnkGraduationData2_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnGraduationData2" Text="削除する" 
        Visible="false" onclick="btnGraduationData2_Click" />
         <asp:ImageButton ID="imgGraduationData2" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplGraduationData2"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="uplGraduationData2"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    3.<asp:LinkButton runat="server" ID="lnkGraduationData3" 
        onclick="lnkGraduationData3_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnGraduationData3" Text="削除する" 
        Visible="false" onclick="btnGraduationData3_Click" />
         <asp:ImageButton ID="imgGraduationData3" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplGraduationData3"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="uplGraduationData3"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    <br />
</td>
</tr>

<tr>
<td style="vertical-align:top;">
<asp:Label ID="Label8" runat="server" Text="Qualification"></asp:Label>
</td>
<td colspan="2">
    1.<asp:LinkButton runat="server" ID="lnkQualificationData" 
        onclick="lnkQualificationData_Click" ></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnQualificationDataDelete" Text="削除する" 
        Visible="false" onclick="btnQualificationDataDelete_Click" />
         <asp:ImageButton ID="imgQualificationData" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False" />
        <br />
<asp:FileUpload runat="server" ID="uplQualificationData"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="uplQualificationData"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    2.<asp:LinkButton runat="server" ID="lnkQualificationData2" 
        onclick="lnkQualificationData2_Click" ></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnQualificationData2" Text="削除する" 
        Visible="false" onclick="btnQualificationData2_Click" />
         <asp:ImageButton ID="imgQualificationData2" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplQualificationData2"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="uplQualificationData2"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    3.<asp:LinkButton runat="server" ID="lnkQualificationData3" 
        onclick="lnkQualificationData3_Click" ></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnQualificationData3" Text="削除する" 
        Visible="false" onclick="btnQualificationData3_Click" />
         <asp:ImageButton ID="imgQualificationData3" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplQualificationData3"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="uplQualificationData3"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    <br />
</td>
</tr>
<tr>
<td style="vertical-align:top;">
<asp:Label runat="server" Text="ID Card"></asp:Label>
</td>
<td colspan="2">
    1.<asp:LinkButton runat="server" ID="lnkCardData" onclick="lnkCardData_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCardData" Text="削除する" 
        Visible="false" onclick="btnCardData_Click" />
         <asp:ImageButton ID="imgCardData" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"   Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCardData"/>
    <br />
<asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="uplCardData"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    &nbsp;<br />
</td>
</tr>

<tr>
<td style="vertical-align:top;">
<asp:Label ID="Label10" runat="server" Text="Labour Card"></asp:Label>
</td>
<td colspan="2">
    1.<asp:LinkButton runat="server" ID="lnkLabourCard" 
        onclick="lnkLabourCard_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnLabourCard" Text="削除する" 
        Visible="false" onclick="btnLabourCard_Click" />
         <asp:ImageButton ID="imgLabourCard" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplLabourCard"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="uplLabourCard"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
        <br />
    &nbsp;
        <br />
</td>
</tr>

<tr>
<td colspan="3" align="right">
<asp:Button runat="server" ID="btnSubmit" Text="登録する" onclick="btnSubmit_Click" Width="200px"/>
    <br />
    <br />

    <asp:HiddenField ID="hfCareerCode" runat="server" />
</td>
</tr>
</table>
<b>インタビュー情報(EMPLOYMENT RECORD) </b>
<br />
<br />
<asp:Button  runat="server" ID="btnEmploymentRecord" 
            Text="★ インタビュー情報(EMPLOYMENT RECORD)を追加する" 
            onclick="btnEmploymentRecord_Click" />
<br />
<br />
<b>インタビュー情報(CHECK & COMMENTS) </b>
<br />
<br />
<asp:Button runat="server" ID="btnCheckComment" 
        Text="★ インタビュー情報(CHECK & COMMENTS)を編集する" onclick="btnCheckComment_Click"/>
<br />
<br />
<b>インタビュー情報(FOR J-SAT)</b>
<br />
<br />
<asp:Button runat="server" ID="btnForJSAT"  Text="★ インタビュー情報(FOR J-SAT)を編集する" onclick="btnForJSAT_Click"/>
<br />
<br />
<b>人材基本情報(INFORMATION OF CANDIDATE)</b>
    <br />
    <br />
    <asp:Button runat="server" ID="btnCareerResume" 
            Text=" ★ 人材基本情報(INFORMATION OF CANDIDATE)を編集する" onclick="btnCareerResume_Click"/>
</fieldset>
</div>
 <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
