<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee_SelfView.aspx.cs" Inherits="JSAT_Ver1.Employee.Employee_SelfView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/style.css"/>
     <script language="javascript" type="text/javascript">
         function PreviewImg(imgFile) {
             var newPreview = document.getElementById("newPreview");
             newPreview.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src =
             imgFile.value;
             newPreview.style.width = "80px";
             newPreview.style.height = "60px";
         }
    </script>
</head>
<body style="background-color:#F8F8F8;">
 <div class="form-style-10">
<h1>Your Information!<span>View Your Information!</span></h1>
<form id="Form1" runat="server">
<div class="inner-wrap">
<label><asp:Label ID="lblAutoNo1" runat="server" Text="Career Code" Font-Bold="true"></asp:Label></label>
<label><asp:Label ID="lblAutoNo" runat="server"></asp:Label></label>
<label><asp:Label ID="lblName" runat="server" Text="Name" Font-Bold="true"></asp:Label>
<br />
<br />
    <asp:Label ID="lblName1" runat="server"></asp:Label>
    <br />
    <br />
    </label>
  <label><span><asp:Label ID="Label1" runat="server" Text="Date Of Birth" Font-Bold="true"></asp:Label></span>
  <br />
  <br />
 <table>
 <tr>
  <td>
      <asp:Label ID="lblDOB" runat="server"></asp:Label>
 
 </td>
 
 </tr>
 </table>
 </label>
          <br />
   
  <label>
 <asp:Label ID="lblGender" runat="server" Text="Gender" Font-Bold="true"></asp:Label>
 <br />
 <br />
      <asp:Label ID="lblGender1" runat="server"></asp:Label>
     </label>
     <br />
  <label>
  <asp:Label ID="lblReligion" runat="server" Text="Religion" Font-Bold="true"></asp:Label>
  <br />
  <br />
            <asp:Label ID="lblReligion1" runat="server"></asp:Label>
          <br />
          <br />
          </label>
   <label>
  <asp:Label ID="lblAddress" runat="server" Text="Address" Font-Bold="true"></asp:Label>
  <br />
  <br />
            <asp:Label ID="lblAddress1" runat="server"></asp:Label>
          <br />
          <br />
          </label>
 <label>
<asp:Label ID="lblPhone" runat="server" Text="Phone" Font-Bold="true"></asp:Label>
<br />
<br />
     <asp:Label ID="lblPhone1" runat="server"></asp:Label></label>
   <br />
   <label >
       <asp:Label ID="lblEName" runat="server" Text="Emergency Contant Person" Font-Bold="true" ></asp:Label>
       <br />
       <br />
       <asp:Label ID="lblEName1" runat="server" Text=""></asp:Label>
   </label>

    <label>
<asp:Label ID="lblEPhone" runat="server" Text="Emergency Phone Number" Font-Bold="true"></asp:Label>
<br />
<br />
        <asp:Label ID="lblEPhone1" runat="server"></asp:Label></label>
    <br />
    <label>
 <asp:Label ID="lblEmail" runat="server" Text="Email" Font-Bold="true"></asp:Label> 
 <br />
 <br />
        <asp:Label ID="lblEmail1" runat="server"></asp:Label></label>
   <br />
<label><asp:Label ID="lblPhoto" runat="server" Text="Photo" Font-Bold="true"></asp:Label>
<br />
<br />
   <asp:Image runat="server" ID="Image1" Height="164px" Width="125px"/>
   <asp:Label ID="lblimage" runat="server" ></asp:Label>
   <br />
   <br /></label>
</div>
        <label><asp:Button ID="btnConfirm" runat="server" Text="Confirm" onclick="btnConfirm_Click" Width="124px" CssClass="btn"/>
               <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="124px" onclick="BtnEdit_Click" CssClass="btn"/></label>
               <asp:HiddenField ID="hfCareerID" runat="server" />
       </form>
    </div>
</body>
</html>
