<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IntroductionListFor_Career.aspx.cs" Inherits="JSAT.Employee.IntroductionListFor_Career" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Creative - Bootstrap 3 Responsive Admin Template">
    <meta name="author" content="GeeksLabs">
    <meta name="keyword" content="Creative, Dashboard, Admin, Template, Theme, Bootstrap, Responsive, Retina, Minimal">
    <style type="text/css">
  table
        {
            width: 1000px;
        }
 .grid_scroll1
        {
           overflow : scroll;
            border: solid 1px white;
            width: 900px;
        }
        legend 
        {
            font-size: 120%;
            color: Black;
        }
        .style1
        {
            width: 500px;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
<script type="text/javascript">
    $(function () {
        $("#<%= txtdate.ClientID %>").datepicker({
            dateFormat: 'yy/mm/dd'
        });
    });
    $(function () {
        $("#<%= txtinterviewdate.ClientID %>").datepicker({
        dateFormat: 'yy/mm/dd'
    });
});
$(function () {
    $("#<%=txtcv.ClientID %>").datepicker({
        dateFormat: 'yy/mm/dd'
    });
});
$(function () {
    $("#<%=txtintro.ClientID %>").datepicker({
        dateFormat: 'yy/mm/dd'
    });
});
</script>
<script type="text/javascript">
    function ShowDialog() {
        var width = 750;
        var height = 750;
        var left = (screen.width - width) / 2;
        var top = (screen.height - height) / 2;
        var params = 'width=' + 950 + ', height=' + 650;
        params += ', top=' + top + ', left=' + left;
        params += ', toolbar=no';
        params += ', menubar=no';
        params += ', resizable=yes';
        params += ', directories=no';
        params += ', scrollbars=yes';
        params += ', status=no';
        params += ', location=no';
        window.open('../popup/Search_Dialog_New.aspx?', window, params);
        //retval = window.showModalDialog
        //('../popup/Search_Dialog_New.aspx?', window, 'dialogHeight:500px; dialogLeft:300px; dialogRight :50px; dialogWidth:700px; dialogTop:80px;help:no; unadorned:no; resizable:no; status:no; scroll:yes; minimize:no; maximize:yes;modal=yes;center=yes;');
    }

    function updateCompanyName(value) {
        // this gets called from the popup window and updates the field with a new value
        var Name = '<%= hdfcompany.ClientID %>';
            document.getElementById(Name).value = value;
            __doPostBack('<%= imgSearch.ClientID  %>', '');
        }
</script>
<script type="text/javascript">
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if ((charCode >= 48 && charCode <= 57) || charCode == 8)
            return true;
        else return false;
    }
</script>
<script type="text/javascript">
    function Validate() {
        var message = "";
        if (document.getElementById("<%=txtempcode.ClientID %>").value == "") {
            message += "Please Fill Employee Code";
        }
        if (document.getElementById("<%=txtempname.ClientID %>").value == "") {
            message += "Please Fill Employee Name";
        }
        if (document.getElementById("<%=txtName.ClientID %>").value == "") {
            message += "Please Fill Company Name";
        }
        if (document.getElementById("<%=txtJobNo.ClientID %>").value == "") {
            message += "Please Fill  Job No";
        }
        if (message != '') {
            message = "" + message;
            alert(message);
            return false;
        }
        return true;
    }
    </script>
<script type="text/javascript">
    function ShowJobNoDialog() {
        var width = 750;
        var height = 750;
        var left = (screen.width - width) / 2;
        var top = (screen.height - height) / 2;
        var params = 'width=' + 950 + ', height=' + 650;
        params += ', top=' + top + ', left=' + left;
        params += ', toolbar=no';
        params += ', menubar=no';
        params += ', resizable=yes';
        params += ', directories=no';
        params += ', scrollbars=yes';
        params += ', status=no';
        params += ', location=no';
        window.open('../popup/Job_DialogForInterviewList.aspx?', window, params);
        //retval = window.showModalDialog
        //('../popup/Job_DialogForInterviewList.aspx?', window, 'dialogHeight:600px; dialogLeft:50px; dialogRight :50px; dialogWidth:900px dialogTop:50px; help:no; unadorned:no; resizable:no; status:no; scroll:yes; minimize:no; maximize:yes;modal=yes;center=yes; ');
    }

    function updateJobNo(value) {
        // this gets called from the popup window and updates the field with a new value
        var Name = '<%= hdfJobNo.ClientID %>';
        document.getElementById(Name).value = value;
        __doPostBack('<%= imgSearch1.ClientID  %>', '');
        }
</script>
     <style type="text/css">
        #MainContent_gvintroduction tbody tr th {
            text-align: center;
            
        }
        
    </style>
    
    <section id="main-content">
        <section class="wrapper">
            <div class="row" style="height:50px">
                <div class="col-lg-12">
                    <h1 class="page-header">Interviewer</h1>
                       
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <div class="row" style="height:50px">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                         <div class="panel-heading">
                             Working History Detail
                             <%--<asp:Label ID="lblcode" runat="server" Text="Employee Working Detail"></asp:Label>--%>
                        </div>
                         <div class="panel-body">
                             <div class="panel-body">
                                 <div class="form-group">

                                     <fieldset style="width:1000; border-style:solid; margin-left: 0px;" >
                    <legend>Introductin List</legend>
                     <table>
                         <tr>
                             <td><asp:Label ID="lblemployeecode" runat="server" Text="Employee Code" Width="100px"></asp:Label></td>
                             <td><asp:DropDownList ID="ddlemployeecode" runat="server" Width="70px" CssClass="form-control" Height="30px">
                                 <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>AC</asp:ListItem>
						         <asp:ListItem>EN</asp:ListItem>
						         <asp:ListItem>GN</asp:ListItem>
						         <asp:ListItem>IT</asp:ListItem>
						         <asp:ListItem>JP</asp:ListItem>
						         <asp:ListItem>SL</asp:ListItem>
						         <asp:ListItem>JPN</asp:ListItem>
						         <asp:ListItem>CAD</asp:ListItem>
                                 </asp:DropDownList>
                            <asp:TextBox ID="txtempcode" runat="server" Width="150px" CssClass="form-control" Height="30px"></asp:TextBox>  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" ControlToValidate="txtempcode" ValidationGroup="myValidation"></asp:RequiredFieldValidator></td>
                        <td><asp:Label ID="lblname" runat="server" Text="Name"></asp:Label></td>
                        <td><asp:DropDownList ID="ddlgender" runat="server" Width="70px" CssClass="form-control" Height="30px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="1">Mr</asp:ListItem>
                        <asp:ListItem Value="2">Ms</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtempname" runat="server" CssClass="form-control" Height="30px" Width="150px"></asp:TextBox>  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ForeColor="Red" ControlToValidate="txtempname" ValidationGroup="myemployeename"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr><td><asp:Label ID="lblsalary" runat="server" Text="Salary"></asp:Label></td>
                    <td><asp:TextBox ID="txtsalary" CssClass="form-control" Height="30px" Width="150px" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox> 
                    <asp:RegularExpressionValidator id="RegularExpressionValidator1" ControlToValidate="txtsalary" ValidationExpression="\d+" Text="*" Display="Static" ForeColor="Red" EnableClientScript="true" ValidationGroup="check" ErrorMessage="Please enter numbers only" runat="server"/>
                    <asp:DropDownList ID="ddltype" runat="server" Height="30px" Width="70px" CssClass="form-control">
                    </asp:DropDownList></td>
                    <td><asp:Label ID="lblstartworking" runat="server" Text="Start Working Date"></asp:Label></td>
                    <td><asp:TextBox ID="txtdate" CssClass="form-control" Width="225px" Height="30px" runat="server"></asp:TextBox></td></tr>
                    <tr><td><asp:Label ID="lblsign" runat="server" Text="Sign"></asp:Label></td>
                    <td><asp:CheckBox ID="chksing" runat="server" /></td><asp:Label ID="lbldetailid" runat="server" Text="" Visible="false"></asp:Label></tr>
            </table>
            </fieldset>

           <fieldset style="width:1000; border-style:solid; margin-left: 0px;" >
           <legend>Job Information</legend>
           <table>
              <tr><td><asp:Label ID="lblCName" runat="server" Text="Company Name" Width="115px" ></asp:Label></td> 
                  <td><asp:TextBox ID="txtName" CssClass="form-control" Height="30px" runat="server" Width="200px"></asp:TextBox></td>
                      <asp:TextBox ID="txtID" runat="server" Width="15px" Visible="false"></asp:TextBox>
                   <td style="width:50px;"><asp:ImageButton ID="imgSearch" runat="server" Height="28px" Width="28px" 
                       ImageUrl="~/img/search.png" OnClientClick="ShowDialog()" 
                       onclick="imgSearch_Click" />  </td>             
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" ControlToValidate="txtName" ValidationGroup="myValidation"></asp:RequiredFieldValidator>   
                  <td><asp:Label ID="lblGroup" runat="server" Width="50px" Text="Job No"></asp:Label></td>
                  <td><asp:TextBox ID="txtJobNo" runat="server" CssClass="form-control" Height="30px" Width="50px"></asp:TextBox></td>
                   <td style="width:50px;"><asp:ImageButton ID="imgSearch1" runat="server" Height="28px" Width="28px" ImageUrl="~/img/search.png" OnClientClick="ShowJobNoDialog()" onclick="imgSearch_Click" /></td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" ControlToValidate="txtJobNo" ValidationGroup="myValidation"></asp:RequiredFieldValidator></td>
               
                  <td><asp:Label ID="lblintro" runat="server" Width="120px" Text="Intorduction Date"></asp:Label></td>
                  <td style="width:200px;"><asp:TextBox ID="txtintro" CssClass="form-control" Height="30px" Width="150px" runat="server"></asp:TextBox></td>
                  <td><asp:Label ID="lblsendcv" Width="90px" runat="server"  Text="SendCV Date"></asp:Label></td>
                  <td><asp:TextBox ID="txtcv" runat="server" CssClass="form-control" Width="130px" Height="30px"></asp:TextBox></td>
                 
              </tr>
               </table>
               <table>
               <tr>
                   <td><asp:Label ID="lblposition" runat="server" Width="95px" Text="Position"></asp:Label></td>
                   <td>
                       <asp:DropDownList ID="ddlposition" CssClass="form-control" Height="30px" Width="700px" runat="server">
                        </asp:DropDownList>
                  </td>
               </tr>
               </table>
               <table class="table">
               <tr>
                    <td class="col-sm-1"><asp:Label ID="Label3" Width="30px" runat="server" Text="Salary"></asp:Label></td>
                    <td style="width:300px"><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Height="30px" Width="150px"  onkeypress="return isNumberKey(event)"></asp:TextBox> 
                    <asp:RegularExpressionValidator id="RegularExpressionValidator2" ControlToValidate="TextBox2" ValidationExpression="\d+" Text="*" Display="Static" ForeColor="Red" EnableClientScript="true" ValidationGroup="check" ErrorMessage="Please enter numbers only" runat="server"/>
                    <asp:DropDownList ID="ddllexpectedsalarytype" CssClass="form-control" runat="server" Height="30" Width="60">
                    </asp:DropDownList></td>
                    <td class="col-sm-1"><asp:Label ID="lblcondition" runat="server" Text="Condition"></asp:Label></td> 
                    <td><asp:DropDownList ID="ddlcondition" CssClass="form-control" Width="150px" Height="30px" runat="server"></asp:DropDownList></td>           
               </tr>
               <tr><td><asp:Label ID="lblnotice" runat="server" Text="Notice"></asp:Label></td>
               <td><asp:RadioButton ID="rdocheckm" runat="server" Text="Other" GroupName="click" AutoPostBack="true" OnCheckedChanged="rdocheckchange"  />
                                         <asp:TextBox ID="txtnotice" runat="server" Width="40px" CssClass="form-control" Height="30px" Visible="false" onkeypress="return isNumberKey(event)" ></asp:TextBox> 
                                         <asp:RegularExpressionValidator id="RegularExpressionValidator3" ControlToValidate="txtsalary" ValidationExpression="\d+" Text="*" Display="Static" ForeColor="Red" EnableClientScript="true" ValidationGroup="check" ErrorMessage="Please enter numbers only" runat="server"/>
                                         <asp:DropDownList ID="ddlmw" runat="server" Visible="false" CssClass="form-control" Height="30px" Width="60px">
                                         <asp:ListItem></asp:ListItem>
                                         <asp:ListItem Value="1">m</asp:ListItem>
                                         <asp:ListItem Value="2">w</asp:ListItem>
                                         </asp:DropDownList>
              </td>
              <td><asp:RadioButton ID="rdocheckimmediate" runat="server" Width="100px" Text="Immediate" GroupName="click" AutoPostBack="true" OnCheckedChanged="rdocheckchange"  /></td>&nbsp;
              <td><asp:CheckBox ID="chkimmediate" runat="server" Visible="false" /><asp:Label ID="lblimmediate" runat="server" Text="Immediately" Visible="false"></asp:Label>
             </td>
          </tr>
          <tr><td><asp:Label ID="lblinterviewdate" runat="server" Text="Interview_Date"></asp:Label></td>
              <td><asp:TextBox ID="txtinterviewdate" CssClass="form-control" Height="30px" runat="server"></asp:TextBox></td>
              <td><asp:DropDownList ID="ddlintreviewtimehour" CssClass="form-control" runat="server" Width="70px" Height="30px">
                  <asp:ListItem></asp:ListItem>
                  <asp:ListItem >1</asp:ListItem>
                  <asp:ListItem >2</asp:ListItem>
                  <asp:ListItem >3</asp:ListItem>
                  <asp:ListItem >4</asp:ListItem>
                  <asp:ListItem >5</asp:ListItem>
                  <asp:ListItem >6</asp:ListItem>
                  <asp:ListItem >7</asp:ListItem>
                  <asp:ListItem >8</asp:ListItem>
                  <asp:ListItem >9</asp:ListItem>
                  <asp:ListItem>10</asp:ListItem>
                  <asp:ListItem >11</asp:ListItem>
                  <asp:ListItem >12</asp:ListItem>
                  <asp:ListItem >13</asp:ListItem>
                  <asp:ListItem >14</asp:ListItem>
                  <asp:ListItem>15</asp:ListItem>
                  <asp:ListItem >16</asp:ListItem>
                  <asp:ListItem >17</asp:ListItem>
                  <asp:ListItem >18</asp:ListItem>
                  <asp:ListItem >19</asp:ListItem>
                  <asp:ListItem >20</asp:ListItem>
                  <asp:ListItem >21</asp:ListItem>
                  <asp:ListItem >22</asp:ListItem>
                  <asp:ListItem >23</asp:ListItem>
                  <asp:ListItem >24</asp:ListItem>
                  </asp:DropDownList></td>
             <td> <asp:DropDownList ID="ddlinterviewtimeminute" CssClass="form-control" Height="30px" runat="server" Width="70px">
                  <asp:ListItem></asp:ListItem>
                  <asp:ListItem >5</asp:ListItem>
                  <asp:ListItem >10</asp:ListItem>
                  <asp:ListItem >15</asp:ListItem>
                  <asp:ListItem >20</asp:ListItem>
                  <asp:ListItem >25</asp:ListItem>
                  <asp:ListItem >30</asp:ListItem>
                  <asp:ListItem >35</asp:ListItem>
                  <asp:ListItem >40</asp:ListItem>
                  <asp:ListItem >45</asp:ListItem>
                  <asp:ListItem >50</asp:ListItem>
                  <asp:ListItem >55</asp:ListItem>
                  <asp:ListItem >60</asp:ListItem>
                  </asp:DropDownList>
                </td>
         </tr>
         <tr><td><asp:Label ID="lblresult" runat="server" Text="Result"></asp:Label></td>
                <td><asp:TextBox ID="txtresult" CssClass="form-control" Height="30px" runat="server"></asp:TextBox></td>
         </tr>
 </table>
 </fieldset>
    <center>
        <asp:Button ID="btnadd" runat="server" class="btn btn-primary" Text="Add"   Height="34px" Width="150px" onclick="btnadd_Click" ValidationGroup="myValidation" /><br />
    </center>
   <div>
     <br />
<asp:GridView ID="gvintroduction" runat="server" AutoGenerateColumns="False" ForeColor="#333333"
            DataKeyNames="ID" EmptyDataText="There is no data to display." HeaderStyle-CssClass="GridHeader"
             AllowPaging="True" OnPageIndexChanging="gvintroductionpageindexchage" PageSize="7" CellPadding="4" GridLines="None"   
            AllowSorting="True" ShowHeaderWhenEmpty="True" OnRowDataBound="gvintroduction_rowDataBound" OnRowCommand="gv_edit"
            Width="1250px">
            
            <Columns>
                <asp:TemplateField HeaderText="Job_No"  HeaderStyle-Width="50px" HeaderStyle-ForeColor="White">
                <ItemTemplate>
                     <asp:Label ID="lblemployee_no" runat="server"  Text='<%# Eval("Job_No")%>' Width="50px"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Company Name" HeaderStyle-HorizontalAlign="center" HeaderStyle-ForeColor="White"  HeaderStyle-Width="200px">
                <ItemTemplate>
                      <asp:Label ID="lblcompanyname" runat="server"  Text='<%# Eval("Company_Name")%>' Width="130px"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Postion" HeaderStyle-ForeColor="White"  HeaderStyle-Width="150px">
                <ItemTemplate>
                            <asp:Label ID="lblposition" runat="server"  Text='<%# Eval("Position")%>' Width="100px"></asp:Label>
                    </ItemTemplate>
                <ItemStyle HorizontalAlign="Left"  />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Introduction_Date"  HeaderStyle-ForeColor="White" HeaderStyle-Width="120px">
                <ItemTemplate>
                            <asp:Label ID="lblintrodction_Date" runat="server"  Text='<%# Eval("Introduction_Date")%>' Width="110px"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Sent_CV_Date" HeaderStyle-ForeColor="White"  HeaderStyle-Width="100px">
                <ItemTemplate>
                            <asp:Label ID="lblsentcvdate" runat="server"  Text='<%# Eval("Sent_CV_Date")%>' Width="80px"></asp:Label>
                    </ItemTemplate>
      <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ExpectedSalary" HeaderStyle-ForeColor="White"  HeaderStyle-Width="100px">
                <ItemTemplate>
                            <asp:Label ID="lblexpectedsalary" runat="server"  Text='<%# Eval("Expected_Salary")%>' Width="50px"></asp:Label>
                    </ItemTemplate>
      <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="" HeaderStyle-ForeColor="White" Visible="false">
                <ItemTemplate>
<asp:Label ID="lblsalaryhidden" runat="server"  Text='<%# Eval("Salary_Hidden")%>' Width="50px"></asp:Label>
                    </ItemTemplate>
     <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="" Visible="false" HeaderStyle-ForeColor="White">
                <ItemTemplate>
<asp:Label ID="lblexpectedsalarytype" runat="server"  Text='<%# Eval("Salary_Type")%>' Width="50px"></asp:Label>
                    </ItemTemplate>
     <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Condition" HeaderStyle-ForeColor="White"  HeaderStyle-Width="100px">
                <ItemTemplate>
                            <asp:Label ID="lblcondition" runat="server"  Text='<%# Eval("Condition")%>' Width="50px"></asp:Label>
                    </ItemTemplate>
      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Notice" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px">
                <ItemTemplate>
                            <asp:Label ID="lblnotice" runat="server"  Text='<%# Eval("NoticeType")%>' Width="50px"></asp:Label>
                    </ItemTemplate>
      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="InterviewDate" HeaderStyle-ForeColor="White" HeaderStyle-Width="140px">
                <ItemTemplate>
                            <asp:Label ID="lblinterviewdate" runat="server"  Text='<%# Eval("Interview_Date")%>' Width="50px"></asp:Label>
                    </ItemTemplate>
      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="" HeaderStyle-ForeColor="White" Visible="false">
                <ItemTemplate>
                            <asp:Label ID="lblinterviewtime" runat="server"  Text='<%# Eval("Interview_Time")%>' Width="50px"></asp:Label>
                    </ItemTemplate>
      <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Result" HeaderStyle-ForeColor="White"  HeaderStyle-Width="100px">
                <ItemTemplate>
                            <asp:Label ID="lblresult" runat="server"  Text='<%# Eval("Result")%>' Width="50px"></asp:Label>
                    </ItemTemplate>
      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="PositionID" HeaderStyle-ForeColor="White" HeaderStyle-Width="200px" Visible="false"  >
                <ItemTemplate>
                            <asp:Label ID="lblpostiionID" runat="server"  Text='<%# Eval("positionID")%>' Width="50px"></asp:Label>
                    </ItemTemplate>
      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CompanyID"  HeaderStyle-ForeColor="White" HeaderStyle-Width="200px" Visible="false"  >
                <ItemTemplate>
                            <asp:Label ID="lblCompanyID" runat="server"  Text='<%# Eval("companyID")%>' Width="50px"></asp:Label>
                    </ItemTemplate>
      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID" HeaderStyle-ForeColor="White" HeaderStyle-Width="200px" Visible="false"  >
                <ItemTemplate>
                            <asp:Label ID="lbldetailID" runat="server"  Text='<%# Eval("ID")%>' Width="50px"></asp:Label>
                    </ItemTemplate>
      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                      <asp:TemplateField ShowHeader="False" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px">
                            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Detail Edit" Text="Edit" CommandArgument='<%# Bind("ID") %>'></asp:LinkButton>
                             <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                            CommandName="Detail Delete" Text="Delete" CommandArgument='<%# Bind("ID") %>'></asp:LinkButton>
                            </ItemTemplate>
                            </asp:TemplateField>
                </Columns> 
                 <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#007aff"  Font-Bold="true" ForeColor="red" Height="50px"  />
                 <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />   
            </asp:GridView>
            </div>
       <%--  <table align="center">
         <tr>
                <td>--%>
               <center> <asp:Button ID="btnsave" runat="server" Text="Save"  Height="30px" Width="150px" onclick="btnsave_Click" />
                        <asp:Button ID="btnsupdate" runat="server" Text="Update"  Height="30px" Width="150px" Visible="false" onclick="btnsupdate_Click" /></center>
                       <%-- </td>
            </tr>
        </table>--%>
     <asp:HiddenField ID="hdfcompany" runat="server" />
     <asp:HiddenField ID="hdfJobNo" runat="server" />
     <asp:HiddenField ID="hdfjob" runat="server" />
      <asp:HiddenField ID="hdfEID" runat="server" />
                                     </div>
                             </div>
                         </div>
                    </div>
                </div>
            </div>
        </section>
    </section>
    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../js/scripts.js"></script>
	<script src="../js/jquery.autosize.min.js"></script>
</asp:Content>
