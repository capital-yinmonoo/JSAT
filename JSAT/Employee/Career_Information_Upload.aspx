<%@ Page Title="人材基本情報編集(DATA & PHOTO)" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Career_Information_Upload.aspx.cs" Inherits="JSAT.Employee.Career_Information_Upload" %>
<asp:content id="Content1" contentplaceholderid="Head" runat="server">
 <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>  
  <style type="text/css">
      body
      {
          background: #fff;
          margin: 0;
      }

      .clear
      {
          clear: both;
          height: 0;
          visibility:;
          display: block;
      }

      a
      {
          text-decoration: none;
      }

      #tab-container
      {
          font-family: Arial, Verdana, Helvetica, sans-serif,Meiryo,Meiryob;
          font-size: 12px;
          line-height: 14px;
          margin: 3em auto;
          width: auto;
          overflow: scroll;
          height: auto;
      }

          #tab-container ul
          {
              list-style: none;
              list-style-position: outside;
              width: 100%;
          }

              #tab-container ul.tab-menu li
              {
                  display: block;
                  float: left;
                  position: relative;
                  font-weight: 700;
                  padding: 5px 10px 5px 10px;
                  background: #eee;
                  border: 1px solid #ddc;
                  border-bottom: none;
                  border-width: 1px;
                  color: #999;
                  cursor: default;
                  height: 20px;
                  margin-bottom: -1px;
                  margin-right: 5px;
                  border-top-left-radius: 3px;
                  border-top-right-radius: 3px;
              }

                  #tab-container ul.tab-menu li.active
                  {
                      background: #fff;
                      color: #0088CC;
                      height: 15px;
                      border-bottom: 0;
                  }

      .tab-top-border
      {
          border-bottom: 1px solid #d0ccc9;
      }

      .tab-content
      {
          margin: 0 auto;
          background: #efefef;
          background: #fff;
          border: 1px solid #ddc;
          border-top-style: none;
          text-align: left;
          padding: 10px;
          padding-bottom: 20px;
          font-size: 11px;
          display: none;
          height: auto;
      }

      #tab-container div.active
      {
          display: block;
      }
  </style>
   <script type="text/jscript">
       $(document).ready(function () {
           var activeTabIndex = -1;
           var tabNames = ["html", "javascript", "css", "jquery", "json", "http", "xml", "hsp"];

           $(".tab-menu > li").click(function (e) {
               for (var i = 0; i < tabNames.length; i++) {
                   if (e.target.id == tabNames[i]) {
                       activeTabIndex = i;
                   } else {
                       $("#" + tabNames[i]).removeClass("active");
                       $("#" + tabNames[i] + "-tab").css("display", "none");
                   }
               }
               $("#" + tabNames[activeTabIndex] + "-tab").fadeIn();
               $("#" + tabNames[activeTabIndex]).addClass("active");
               return false;
           });
       });
    </script>
</asp:content>
<asp:content id="Content2" contentplaceholderid="MainContent" runat="server">
<br /><br /><br />
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
            margin: 0;
            padding: 0;
            height: 100%;
        }

        .modal
        {
            display: none;
            position: absolute;
            top: 0px;
            left: 0px;
            background-color: black;
            z-index: 100;
            opacity: 0.8;
            filter: alpha(opacity=60);
            -moz-opacity: 0.8;
            min-height: 100%;
        }

        #divImage
        {
            display: none;
            z-index: 1000;
            position: fixed;
            top: 0;
            left: 0;
            background-color: White;
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
    <div style="width:95%">
       
                <asp:Label ID="Label7" runat="server" Text="◆SENT TO ALL COMPANIES" />
        <hr />
       
               
            <div id="tab-container" >

    
               
    <ul class="tab-menu">  
        <li id="html" class="active">DATA SHEET & EMPLOYMENT RECORD</li>  
        <li id="css">JAPANESE SHEET</li>  
        <li id="javascript">CV</li>  
        <li id ="jquery">Photo</li>
        <li id="json">University Certificate</li>
        
        <li id ="http">Qualification</li>
          <li id ="xml">ID Card</li>
          <li id ="hsp">Labour Card</li>
    </ul>  
      <div class="clear"></div>  
    <div class="tab-top-border"></div>
     <%-- <div class="tabcontents">--%>
         <%--   <div id="view1">--%>
               <div id="html-tab" class="tab-content active">
            <table class="myTable" cellpadding="5" cellspacing="3" width="100%" height="auto">
            
            <tr>
<td style="vertical-align:top;">
    <br />
<asp:Label ID="Datasheet_Data" runat="server" Text="DATA SHEET & EMPLOYMENT RECORD"></asp:Label>
</td>
<td colspan="2" >
    1.<asp:LinkButton runat="server" ID="lnkDatasheetData"  onclick="lnkDatasheetData_Click"></asp:LinkButton> &nbsp; 
    <asp:Button runat="server" ID="btnDatasheetDataDelete" Text="削除する" 
        Visible="false" onclick="btnDatasheetDataDelete_Click" />
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

     6.<asp:LinkButton runat="server" ID="lnkDatasheetData6" 
        onclick="lnkDatasheetData6_Click"></asp:LinkButton> &nbsp;
        <asp:Button runat="server" ID="btnDatasheetData6Delete" Text="削除する" 
        Visible="false" onclick="btnDatasheetData6Delete_Click" />
         <asp:ImageButton ID="imgDatasheetData6" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplDatasheetData6"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server" ControlToValidate="uplDatasheetData6"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />

     7.<asp:LinkButton runat="server" ID="lnkDatasheetData7" 
        onclick="lnkDatasheetData7_Click"></asp:LinkButton> &nbsp;
        <asp:Button runat="server" ID="btnDatasheetData7Delete" Text="削除する" 
        Visible="false" onclick="btnDatasheetData7Delete_Click" />
         <asp:ImageButton ID="imgDatasheetData7" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplDatasheetData7"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ControlToValidate="uplDatasheetData7"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />

     8.<asp:LinkButton runat="server" ID="lnkDatasheetData8" 
        onclick="lnkDatasheetData8_Click"></asp:LinkButton> &nbsp;
        <asp:Button runat="server" ID="btnDatasheetData8Delete" Text="削除する" 
        Visible="false" onclick="btnDatasheetData8Delete_Click" />
         <asp:ImageButton ID="imgDatasheetData8" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplDatasheetData8"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server" ControlToValidate="uplDatasheetData8"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    <br />
    <br />
    </td>
</tr>
<%--<tr>
<td colspan="3" align="right">
<asp:Button runat="server" ID="btnSubmit" Text="登録する" onclick="btnSubmit_Click" Width="200px"/>
    <br />
    <br />
    <asp:HiddenField ID="hfCareerCode" runat="server" />
</td>
</tr>--%>
</table>
            </div>



     
         <div id="css-tab" class="tab-content">
      
        
            <table class="myTable" cellpadding="5" cellspacing="3" width="100%" >
         <tr>
<td  colspan="2" style="vertical-align:top;" >
<asp:Label ID="Label1" runat="server" Text="JAPANESE SHEET"></asp:Label>
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

      4.<asp:LinkButton runat="server" ID="lnkJapaneseData4" 
        onclick="lnkJapaneseData4_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnJapaneseData4" Text="削除する" 
        Visible="false" onclick="btnJapaneseData4_Click" />
         <asp:ImageButton ID="imgJapaneseData4" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplJapaeseData4"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" ControlToValidate="uplJapaeseData4"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />

     5.<asp:LinkButton runat="server" ID="lnkJapaneseData5" 
        onclick="lnkJapaneseData5_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnJapaneseData5" Text="削除する" 
        Visible="false" onclick="btnJapaneseData5_Click" />
         <asp:ImageButton ID="imgJapaneseData5" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplJapaeseData5"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ControlToValidate="uplJapaeseData5"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    <br />
</td>
</tr>   
           </table>
       
            </div>

              <div id="javascript-tab" class="tab-content">  
            <table  class="myTable" cellpadding="5" cellspacing="3" width="100%" >
           <tr>
<td colspan="2" style="vertical-align:top;">
<asp:Label ID="Label2" runat="server" Text="CV"></asp:Label>
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
        onclick="lnkCredentialData3_Click"></asp:LinkButton>&nbsp;
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
    
      8.<asp:LinkButton runat="server" ID="lnkCredentialData8" 
        onclick="lnkCredentialData8_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData8" Text="削除する"  Visible="false" onclick="btnCredentialData8_Click" />
         <asp:ImageButton ID="imgCredentialData8" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData8"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server" ControlToValidate="uplCredentialData8"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />

       9.<asp:LinkButton runat="server" ID="lnkCredentialData9" 
        onclick="lnkCredentialData9_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData9" Text="削除する"  Visible="false" onclick="btnCredentialData9_Click" />
         <asp:ImageButton ID="imgCredentialData9" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData9"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server" ControlToValidate="uplCredentialData9"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />

        10.<asp:LinkButton runat="server" ID="lnkCredentialData10" 
        onclick="lnkCredentialData10_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData10" Text="削除する"  Visible="false" onclick="btnCredentialData10_Click" />
         <asp:ImageButton ID="imgCredentialData10" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData10"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server" ControlToValidate="uplCredentialData10"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
     11.<asp:LinkButton runat="server" ID="lnkCredentialData11" 
        onclick="lnkCredentialData11_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData11" Text="削除する"  Visible="false" onclick="btnCredentialData11_Click" />
         <asp:ImageButton ID="imgCredentialData11" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData11"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator34" runat="server" ControlToValidate="uplCredentialData11"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
     12.<asp:LinkButton runat="server" ID="lnkCredentialData12" 
        onclick="lnkCredentialData12_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData12" Text="削除する"  Visible="false" onclick="btnCredentialData12_Click" />
         <asp:ImageButton ID="imgCredentialData12" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData12"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator35" runat="server" ControlToValidate="uplCredentialData12"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
       13.<asp:LinkButton runat="server" ID="lnkCredentialData13" 
        onclick="lnkCredentialData13_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData13" Text="削除する"  Visible="false" onclick="btnCredentialData13_Click" />
         <asp:ImageButton ID="imgCredentialData13" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData13"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator36" runat="server" ControlToValidate="uplCredentialData13"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    14.<asp:LinkButton runat="server" ID="lnkCredentialData14" 
        onclick="lnkCredentialData14_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData14" Text="削除する"  Visible="false" onclick="btnCredentialData14_Click" />
         <asp:ImageButton ID="imgCredentialData14" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData14"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator37" runat="server" ControlToValidate="uplCredentialData14"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
      15.<asp:LinkButton runat="server" ID="lnkCredentialData15" 
        onclick="lnkCredentialData15_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCredentialData15" Text="削除する"  Visible="false" onclick="btnCredentialData15_Click" />
         <asp:ImageButton ID="imgCredentialData15" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCredentialData15"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator38" runat="server" ControlToValidate="uplCredentialData15"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    <br />
</td>
</tr>
</table>
            </div>
   
          <div id ="jquery-tab" class="tab-content">
            <table  class="myTable" cellpadding="5" cellspacing="3" width="100%" >
          <tr>
<td colspan="2"  style="vertical-align:top;">
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
</table>
            </div>
      
         <div id="json-tab" class="tab-content">
            <table  class="myTable" cellpadding="5" cellspacing="3" width="100%" >
         <tr>
<td colspan="2"  style="vertical-align:top;">
<asp:Label ID="Label3" runat="server" Text="University Certificate"></asp:Label>
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

        4.<asp:LinkButton runat="server" ID="lnkGraduationData4" 
        onclick="lnkGraduationData4_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnGraduationData4" Text="削除する" 
        Visible="false" onclick="btnGraduationData4_Click" />
         <asp:ImageButton ID="imgGraduationData4" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplGraduationData4"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator39" runat="server" ControlToValidate="uplGraduationData4"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    5.<asp:LinkButton runat="server" ID="lnkGraduationData5" 
        onclick="lnkGraduationData5_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnGraduationData5" Text="削除する" 
        Visible="false" onclick="btnGraduationData5_Click" />
         <asp:ImageButton ID="imgGraduationData5" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplGraduationData5"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator40" runat="server" ControlToValidate="uplGraduationData5"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
   




    <br />
</td>
</tr>
</table>
            </div>
    
         <div id="http-tab" class="tab-content">
            <table  class="myTable" cellpadding="5" cellspacing="3" width="100%" >
            <tr>
<td colspan="2"  style="vertical-align:top;">
<asp:Label ID="Label4" runat="server" Text="Qualification"></asp:Label>
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
       4.<asp:LinkButton runat="server" ID="lnkQualificationData4" 
        onclick="lnkQualificationData4_Click" ></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnQualificationData4" Text="削除する" 
        Visible="false" onclick="btnQualificationData4_Click" />
         <asp:ImageButton ID="imgQualificationData4" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplQualificationData4"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator41" runat="server" ControlToValidate="uplQualificationData4"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
       5.<asp:LinkButton runat="server" ID="lnkQualificationData5" 
        onclick="lnkQualificationData5_Click" ></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnQualificationData5" Text="削除する" 
        Visible="false" onclick="btnQualificationData5_Click" />
         <asp:ImageButton ID="imgQualificationData5" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplQualificationData5"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator42" runat="server" ControlToValidate="uplQualificationData5"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
       6.<asp:LinkButton runat="server" ID="lnkQualificationData6" 
        onclick="lnkQualificationData6_Click" ></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnQualificationData6" Text="削除する" 
        Visible="false" onclick="btnQualificationData6_Click" />
         <asp:ImageButton ID="imgQualificationData6" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplQualificationData6"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator43" runat="server" ControlToValidate="uplQualificationData6"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
       7.<asp:LinkButton runat="server" ID="lnkQualificationData7" 
        onclick="lnkQualificationData7_Click" ></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnQualificationData7" Text="削除する" 
        Visible="false" onclick="btnQualificationData7_Click" />
         <asp:ImageButton ID="imgQualificationData7" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplQualificationData7"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator44" runat="server" ControlToValidate="uplQualificationData7"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
       8.<asp:LinkButton runat="server" ID="lnkQualificationData8" 
        onclick="lnkQualificationData8_Click" ></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnQualificationData8" Text="削除する" 
        Visible="false" onclick="btnQualificationData8_Click" />
         <asp:ImageButton ID="imgQualificationData8" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplQualificationData8"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator45" runat="server" ControlToValidate="uplQualificationData8"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
       9.<asp:LinkButton runat="server" ID="lnkQualificationData9" 
        onclick="lnkQualificationData9_Click" ></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnQualificationData9" Text="削除する" 
        Visible="false" onclick="btnQualificationData9_Click" />
         <asp:ImageButton ID="imgQualificationData9" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplQualificationData9"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator46" runat="server" ControlToValidate="uplQualificationData9"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
      10.<asp:LinkButton runat="server" ID="lnkQualificationData10" 
        onclick="lnkQualificationData10_Click" ></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnQualificationData10" Text="削除する" 
        Visible="false" onclick="btnQualificationData10_Click" />
         <asp:ImageButton ID="imgQualificationData10" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"  Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplQualificationData10"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator47" runat="server" ControlToValidate="uplQualificationData10"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
        ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    <br />
</td>
</tr>
         </table>
            </div>
        
              <div id="xml-tab" class="tab-content">
            <table  class="myTable" cellpadding="5" cellspacing="3" width="100%" >
            <tr>
<td  colspan="2" style="vertical-align:top;">
<asp:Label ID="Label5" runat="server" Text="ID Card"></asp:Label>
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
    2.<asp:LinkButton runat="server" ID="lnkCardData2" onclick="lnkCardData2_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCardData2" Text="削除する" 
        Visible="false" onclick="btnCardData2_Click" />
         <asp:ImageButton ID="imgCardData2" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"   Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCardData2"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator48" runat="server" ControlToValidate="uplCardData2"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
 <br />
3.<asp:LinkButton runat="server" ID="lnkCardData3" onclick="lnkCardData3_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnCardData3" Text="削除する" 
        Visible="false" onclick="btnCardData3_Click" />
         <asp:ImageButton ID="imgCardData3" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px"   Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplCardData3"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator49" runat="server" ControlToValidate="uplCardData3"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
    <br />
    <br />
    &nbsp;<br />
</td>
</tr>
            </table>
         
            </div>
           
               <div id="hsp-tab"  class="tab-content">
            <table  class="myTable" cellpadding="5" cellspacing="3" width="100%" >
            <tr>
<td colspan="2"  style="vertical-align:top;">
<asp:Label ID="Label6" runat="server" Text="Labour Card"></asp:Label>
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
         2.<asp:LinkButton runat="server" ID="lnkLabourCard2" 
        onclick="lnkLabourCard2_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnLabourCard2" Text="削除する" 
        Visible="false" onclick="btnLabourCard2_Click" />
         <asp:ImageButton ID="imgLabourCard2" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplLabourCard2"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator50" runat="server" ControlToValidate="uplLabourCard2"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
        <br />
         3.<asp:LinkButton runat="server" ID="lnkLabourCard3" 
        onclick="lnkLabourCard3_Click"></asp:LinkButton>&nbsp;
        <asp:Button runat="server" ID="btnLabourCard3" Text="削除する" 
        Visible="false" onclick="btnLabourCard3_Click" />
         <asp:ImageButton ID="imgLabourCard3" runat="server" 
        OnClientClick = "return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False"/>
        <br />
<asp:FileUpload runat="server" ID="uplLabourCard3"/>
    <br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator51" runat="server" ControlToValidate="uplLabourCard3"
 ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" 
 ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
        <br />
    &nbsp;
        <br />
</td>
</tr>
            </table>
         </div>
            </div>
             
             

<div align="center">
<asp:Button runat="server" ID="btnSubmit" Text="登録する" onclick="btnSubmit_Click" Width="200px"/>
</div>
    <br />
  
    <asp:HiddenField ID="hfCareerCode" runat="server" />

 
</asp:content>
