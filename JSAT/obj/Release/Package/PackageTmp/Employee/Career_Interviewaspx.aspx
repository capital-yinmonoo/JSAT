<%@ Page Title="インタビュー情報編集(FOR J-SAT)" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Career_Interviewaspx.aspx.cs" Inherits="JSAT.Employee.Career_Interviewaspx" %>
<%@ Register src="../Usercontrol/Career_InterviewControl.ascx" tagname="Career_InterviewControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 499px;
        }
        .style2
        {
            width: 344px;
        }
    </style>

<%--    <script type="text/javascript">
        function radioMe(e) {
            if (!e) e = window.event;
            var sender = e.target || e.srcElement;

            if (sender.nodeName != 'INPUT') return;
            var checker = sender;
            var chkBox = document.getElementById('<%= cblLocation.ClientID %>');
            var chks = chkBox.getElementsByTagName('INPUT');
            for (i = 0; i < chks.length; i++) {
                if (chks[i] != checker)
                    chks[i].checked = false;
            }
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div>
<fieldset>
<table>
        <tr>
            <td class="style2">
                <asp:Label runat="server" ID="lblTitle" Text="インタビュー情報編集(FOR J-SAT)" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </td>
            <td>
                <asp:HiddenField ID="hdfID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style2"></td>
            <td align="right" class="style1">
                <asp:Label ID="lblUpdater" runat="server" Text="更新者ID："></asp:Label>
                &nbsp
                <asp:Label runat="server" ID="lblUpdatedBy"></asp:Label>
                &nbsp
                <asp:Label ID="lblUpdateTime" runat="server" Text="更新日："></asp:Label>
                &nbsp
            <asp:Label runat="server" ID="lblUpdatedDate"></asp:Label>
        </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    HeaderText="You must enter a value in the following fields:" 
                    EnableClientScript="true"
                    ForeColor="Red"
                    ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true"  ValidationGroup="check" />
            </td>
        </tr>
    </table>
<table>
<tr> 
<td  style="vertical-align:top" >  
    <uc1:Career_InterviewControl ID="Career_InterviewControl1" runat="server" Visible="False" />
</td> 
<td class="style3">
    <table>
    <tr>
        <td><asp:CheckBox  runat="server" ID="chkJobIntro" Text="お仕事紹介可能"/>
            <asp:Label ID="Label16" runat="server" Font-Names="Zawgyi-One" 
                Text="အလုပ္မိတ္ဆက္ေပးရန္ သင့္/မသင့္"></asp:Label>
        </td>
    </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label15" Text="住所"></asp:Label>
                <asp:Label ID="Label17" runat="server" Font-Names="Zawgyi-One" 
                    Text="ေနရပ္လိပ္စာ"></asp:Label>
            </td>
            <td ><asp:TextBox runat ="server" ID="txtAddress" Width="585px"  ValidationGroup="check"
                    TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress" ErrorMessage="住所" ForeColor="Red" Text="*"  ValidationGroup="check"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label1" Text="居住エリア"></asp:Label>
                <asp:Label ID="Label18" runat="server" Font-Names="Zawgyi-One" Text="ၿမိဳ႕နယ္ "></asp:Label>
            </td>
            <td><asp:Label runat="server" ID="txtArea" Width="200px"></asp:Label>
          
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label2" Text="電話番号1"></asp:Label>
                <asp:Label ID="Label19" runat="server" Font-Names="Zawgyi-One" 
                    Text="ဖုန္းနံပါတ္ ၁ "></asp:Label>
            </td>
            <td><asp:TextBox runat ="server" ID="txtPhone1" Width="200px"  ValidationGroup="check"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                    ControlToValidate="txtPhone1" ErrorMessage="電話番号1 ဖုန္းနံပါတ္ ၁ " ForeColor="Red"  ValidationGroup="check"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
                    ID="regPhone" 
                    runat="server" 
                    ControlToValidate="txtPhone1" 
                    ForeColor="Red"
                    Text="*"
                    ErrorMessage="Invalid 電話番号1 ဖုန္းနံပါတ္ ၁  Eg.095118746"
                    ValidationExpression="[+]?[0-9]{2}?[-]?\d+"
                    ValidationGroup="check"
                />
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label3" Text="電話番号2"></asp:Label>
                <asp:Label ID="Label20" runat="server" Font-Names="Zawgyi-One" 
                    Text="ဖုန္းနံပါတ္ ၂ "></asp:Label>
            </td>
            <td ><asp:TextBox runat ="server" ID="txtPhone2" Width="200px"  ValidationGroup="check"></asp:TextBox>
                <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidator1" 
                    runat="server" 
                    ControlToValidate="txtPhone2" 
                    ForeColor="Red"
                    Text="*"
                    ErrorMessage="Invalid 電話番号2 ဖုန္းနံပါတ္ ၂   Eg.095118746"
                    ValidationExpression="[+]?[0-9]{2}?[-]?\d+"
                    ValidationGroup="check"
                />
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label4" Text="メールアドレス"></asp:Label>
                <asp:Label ID="Label21" runat="server" Font-Names="Zawgyi-One" Text="အီးေမးလ္"></asp:Label>
            </td>
            <td ><asp:TextBox runat ="server" ID="txtEmail" Width="300px"></asp:TextBox>
                <%--<asp:RegularExpressionValidator 
                ID="RegularExpressionValidator2" 
                runat="server" 
                ControlToValidate="txtEmail" 
                ForeColor="Red"
                Text="*"
                ErrorMessage="Invalid メールアドレス အီးေမးလ္ Eg.mgmg@gmail.com"
                ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"
                ValidationGroup="check"
            /> --%>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label5" Text="緊急連絡番号"></asp:Label>
                <asp:Label ID="Label22" runat="server" Font-Names="Zawgyi-One" 
                    Text="အေရးေပၚဆက္သြယ္ရန္ ဖုန္းနံပါတ္"></asp:Label>
            </td>
            <td ><asp:TextBox runat ="server" ID="txtEmergencyNo" Width="300px"  ValidationGroup="check"></asp:TextBox>
                <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidator3" 
                    runat="server" 
                    ControlToValidate="txtEmergencyNo" 
                    ForeColor="Red"
                    Text="*"
                    ErrorMessage="Invalid 緊急連絡番号အေရးေပၚဆက္သြယ္ရန္ ဖုန္းနံပါတ္   Eg.095118746"
                    ValidationExpression="[+]?[0-9]{2}?[-]?\d+"
                    ValidationGroup="check"
                />
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label6" Text="緊急連絡名"></asp:Label>
                <asp:Label ID="Label23" runat="server" Font-Names="Zawgyi-One" 
                    Text="အေရးေပၚဆက္သြယ္ရမည္႕သူ နာမည္"></asp:Label>
            </td>
            <td><asp:TextBox runat ="server" ID="txtEmergencyName" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label7" Text="家族人数"></asp:Label>
                <asp:Label ID="Label24" runat="server" Font-Names="Zawgyi-One" 
                    Text="မိသားစု အေရအတြက္"></asp:Label>
            </td>
            <td >
                    <asp:DropDownList runat="server" ID="ddlPersons" Width="50px">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label8" Text="家族職業"></asp:Label>
                <asp:Label ID="Label25" runat="server" Font-Names="Zawgyi-One" 
                    Text="မိသားစု အလုပ္အကိုင္"></asp:Label>
            </td>
            <td>
            <asp:TextBox runat ="server" ID="txtOccupation" TextMode="MultiLine" Width="585px" 
                    Height="180px"></asp:TextBox></td>
             <asp:CustomValidator id="CustomValidator1" runat="server" 
                    OnServerValidate="cusCustom_ServerValidate" 
                    ControlToValidate="txtOccupation" 
                    Text="*"
                    ForeColor="Red"
                    ErrorMessage="家族職業မိသားစု အလုပ္အကိုင္ allow only 400 characters.Your comment is more than maximum length."> </asp:CustomValidator>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label9" Text="家族収入"></asp:Label>
                <asp:Label ID="Label26" runat="server" Font-Names="Zawgyi-One" 
                    Text="မိသားစု ဝင္ေငြ"></asp:Label>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlIncome" Width="130px" >
                <asp:ListItem Value="1">～$500</asp:ListItem>
                <asp:ListItem Value="2">$500～$3000</asp:ListItem>
                <asp:ListItem Value="3">$3000～</asp:ListItem>
               </asp:DropDownList>
            </td>
        </tr>
    <tr>
        <td colspan="2"><asp:CheckBox runat="server" ID="chkAccuracy" Text="実習生制度"/>
            <asp:Label ID="Label27" runat="server" Font-Names="Zawgyi-One" 
                Text="အလုပ္သင္လုပ္ရန္ စိတ္ပါ/မပါ"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2"><asp:CheckBox runat="server" ID="chkAbroad" AutoPostBack="true" Text="海外勤務" onclick="document.getElementById('cblLocation').disabled=this.checked;"/>
            <asp:Label ID="Label28" runat="server" Font-Names="Zawgyi-One" 
                Text="ႏိုင္ငံၿခား၌အလုပ္လုပ္ရန္ စိတ္ပါ/မပါ"></asp:Label>
        </td>
    </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label10" Text="場所"></asp:Label>
                <asp:Label ID="Label29" runat="server" Font-Names="Zawgyi-One" 
                    Text="အလုပ္လုပ္ခၽင္သည္႕ ႏိုင္ငံ"></asp:Label>
            </td>
            <td> <asp:CheckBoxList runat="server" ID="cblLocation" RepeatDirection="Horizontal" Width="500px"
                    ClientIDMode="Static" Font-Names="Zawgyi-One"> </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label11" Text="その他場所"></asp:Label>
                <asp:Label ID="Label30" runat="server" Font-Names="Zawgyi-One" 
                    Text="အၿခားအလုပ္လုပ္ခၽင္သည္႕ ႏိုင္ငံ"></asp:Label>
            </td>
            <td ><asp:TextBox runat ="server" ID="txtPlace" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label12" Text="期間"></asp:Label>
                <asp:Label ID="Label31" runat="server" Font-Names="Zawgyi-One" 
                    Text="အလုပ္လုပ္ႏိုင္သည္႕ ကာလ"></asp:Label>
            </td>
            <td >
                    <asp:DropDownList runat="server" ID="ddlPeriod" Width="130px">
                    <asp:ListItem Value="1">3 months</asp:ListItem>
                    <asp:ListItem Value="2">6 months</asp:ListItem>
                    <asp:ListItem Value="3">1 year</asp:ListItem>
                    <asp:ListItem Value="4">2 years</asp:ListItem>
                    <asp:ListItem Value="5">3 years</asp:ListItem>
                    <asp:ListItem Value="6">Others</asp:ListItem>
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label13" Text="その他期間"></asp:Label>
                <asp:Label ID="Label32" runat="server" Font-Names="Zawgyi-One" 
                    Text="အၿခားအလုပ္လုပ္ႏိုင္သည္႕ ကာလ"></asp:Label>
            </td>
            <td><asp:TextBox runat ="server" ID="txtPeriod" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label14" Text="備考"></asp:Label>
                <asp:Label ID="Label33" runat="server" Font-Names="Zawgyi-One" 
                    Text="မွတ္ခၽက္ေပးရန္"></asp:Label>
            </td>
            <td><asp:TextBox runat ="server" ID="txtRemarks" TextMode="MultiLine" Width="585px" 
                    Height="180px" ></asp:TextBox></td>
                    <asp:CustomValidator id="CustomValidator2" runat="server" 
                    OnServerValidate="cusCustom_ServerValidate" 
                    ControlToValidate="txtRemarks" 
                    Text="*"
                    ForeColor="Red"
                    ErrorMessage="備考မွတ္ခၽက္ေပးရန္ allow only 400 characters.Your comment is more than maximum length."> </asp:CustomValidator>
        </tr>
    </table>
</td>
</tr>
</table>
<table>
    <tr>
        <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" ID="btnSave" Text="登録する" onclick="btnSave_Click" Width="200px"  ValidationGroup="check"/>
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
<b>人材基本情報(DATA & PHOTO)</b>
<br />
<br />
<asp:Button runat="server" ID="btnDataPhoto" Text="★ 人材基本情報(DATA & PHOTO)を編集する" onclick="btnDataPhoto_Click"/>
<br />
<br />
<b>人材基本情報(INFORMATION OF CANDIDATE)</b>
    <br />
    <br />
    <asp:Button runat="server" ID="btnCareerResume" 
            Text=" ★ 人材基本情報(INFORMATION OF CANDIDATE)を編集する" onclick="btnCareerResume_Click"/>
</fieldset>
</div>

</asp:Content>
