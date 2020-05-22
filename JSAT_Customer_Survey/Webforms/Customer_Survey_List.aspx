<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_Survey_List.aspx.cs" Inherits="JSAT_Customer_Survey.Webforms.Customer_Survey_List" %>


<!DOCTYPE html>

<html>
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>JSAT Customer Survey</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../plugins/fontawesome-free/css/all.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Theme style -->
        <link rel="stylesheet" href="../dist/css/adminlte.min.css">
    <!-- Google Font: Source Sans Pro -->
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
     <link rel="stylesheet" href="../plugins/icheck-bootstrap/icheck-bootstrap.min.css">
       <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(function () {
        $.ajax({
            type: "POST",
            url: "Customer_Survey_List.aspx/GetSurvey",
            data: '{ }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
          
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }
        });
    });
    function OnSuccess(response) {
        $("[id*=gvSurvey]").DataTable(
        {
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true,
                data: response.d,
                columns: [{ 'data': 'ID' },
                      { 'data': 'Name' },
                      { 'data': 'PhoneNo' }]
        });
    };
</script>

</head>

<body>
     <form id="form1" runat="server" >
	<div class="card card-primary">
		<div class="card-header h1" style="text-align:center">Customer Survey List
		</div>
          <div style="width: 500px;padding-top: 50px;">
    <asp:GridView ID="gvSurvey" runat="server"  AutoGenerateColumns="false">
        <Columns>
             <asp:BoundField ItemStyle-Width="150px" DataField="ID" HeaderText="ID" />
                <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Customer Name" />
                <asp:BoundField ItemStyle-Width="150px" DataField="PhoneNo" HeaderText="PhoneNo:" />
        </Columns>
    </asp:GridView>
        </div>
	</div> 
         </form>
</body>
</html>
 


