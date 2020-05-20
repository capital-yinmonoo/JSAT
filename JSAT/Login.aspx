<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JSAT_Ver1.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Creative - Bootstrap 3 Responsive Admin Template">
    <meta name="author" content="GeeksLabs">
    <meta name="keyword" content="Creative, Dashboard, Admin, Template, Theme, Bootstrap, Responsive, Retina, Minimal">
    <link rel="shortcut icon" href="img/JSAT_logo.ico">
    <title>JSAT</title>
    <!-- Bootstrap CSS -->    
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <!-- bootstrap theme -->
    <link href="css/bootstrap-theme.css" rel="stylesheet">
    <!--external css-->
    <!-- font icon -->
    <link href="css/elegant-icons-style.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <!-- Custom styles -->
    <link href="css/style.css" rel="stylesheet">
    <link href="css/style-responsive.css" rel="stylesheet" />
</head>
<body class="login-img3-body">
    <div class="container">
      <form class="login-form" runat="server"> 
        <div class="login-wrap">
            <p class="login-img"><i class="icon_lock_alt"></i></p>
            <div class="input-group">
              <span class="input-group-addon"><i class="icon_profile"></i></span>
              <asp:TextBox  class="form-control" ID="txtLoginID" runat="server" placeholder="ユーザーID(User ID)" Width="255px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginID" ErrorMessage="*" ForeColor="Red" EnableClientScript="true" Width="10px" ></asp:RequiredFieldValidator>
            </div>
            <div class="input-group">
                <span class="input-group-addon"><i class="icon_key_alt"></i></span>
                <asp:TextBox class="form-control" placeholder="パスワード(Password)" ID="txtPassword" runat="server" TextMode="Password" Width="255px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red" EnableClientScript="true" Width="10px" ></asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="ログイン(Log in)" onclick="btnLogin_Click" class="btn btn-lg btn-primary btn-block"  Width="295px"/>
            <br />
            <a href="Employee/Employee_SelfEntry.aspx">
            <asp:Label ID="LbldegreeEdit" runat="server" Text="Career Registration Public" class="btn btn-info btn-lg btn-block" style="width:295px;"></asp:Label></a>
        </div>
      </form>
    </div>
</body>
</html>
