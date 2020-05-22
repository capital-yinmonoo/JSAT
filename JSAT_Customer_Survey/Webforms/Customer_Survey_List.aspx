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
                    data: {},
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
        $('#tbcustomers').DataTable(
        {
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true,
                data: response.d,
                columns: [{ 'data': 'ID' },
                    { 'data': 'Name'},
                    { 'data': 'PhoneNo' },
                    { 'data': 'Q1' },
                    { 'data': 'Q2' },
                    { 'data': 'Q3' },
                    { 'data': 'Q4' },
                    { 'data': 'Q5' },
                    { 'data': 'Q6' },
                    { 'data': 'Q7' },
                    { 'data': 'Q8' },
                    { 'data': 'Q9' },
                    { 'data': 'Description' },
                    { 'data': 'InsertedDate' }
                ]
        });
    };
</script>
  <style type="text/css">
      .hrtable thead th {
          color: black;
          background:cornsilk;
      }
      .hrtable tr:nth-child(even) {
          background:azure;
      }

      .hrtable tr {
          color:black;
      }
  </style>
</head>

<body>
     <form id="form1" runat="server" >
	<div class="card card-primary">
		<div class="card-header h1" style="text-align:center">Customer Survey List
		</div>
          <div style="width: 100%;padding-top: 30px;">
            <table id="tbcustomers" class="hrtable">
                                <thead>
                                    <tr style="height:5px;">
                                        <th>ID</th>
                                        <th>Customer Name</th>
                                         <th>PhoneNo:</th>
                                         <th>Q1</th>
                                         <th>Q2</th>
                                         <th>Q3</th>
                                         <th>Q4</th>
                                         <th>Q5</th>
                                         <th>Q6</th>
                                         <th>Q7</th>
                                         <th>Q8</th>
                                         <th>Q9</th>
                                         <th>Description</th>
                                         <th>InsertedDate:</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                </tfoot>
                            </table>
        </div>
	</div> 
         </form>
</body>
</html>
 


