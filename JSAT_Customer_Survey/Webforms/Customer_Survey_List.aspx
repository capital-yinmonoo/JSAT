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
                lengthMenu: [10,20],
                bFilter: true,
                bSort: true,
                bPaginate: true,
                pagingType: "full_numbers",
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
      .hrtable{
          width:100%;
      }
  </style>
</head>

<body>
     <form id="form1" runat="server" >
	<div class="card card-primary">
		<div class="card-header h1" style="text-align:center">Customer Survey List
		</div>

      <div style="border-style: solid;border-width: 1px 1px;">
        <div style="padding-top: 30px;background-color:cornsilk;padding-left: 25px;">
        <label style="width:30%;height:10%;font-size:14px;">Q1- တက္ကသိုလ် ပထမနှစ် တက်ရောက်ဖူးပါသလား။</label>
        <label style="width:30%;height:10%;font-size:14px;">Q2- လက်ရှိတွင်အသက်(၁၉ နှစ်မှ ၂၆ နှစ်) အကြား ရှိပါသလား။</label>
        <label style="width:30%;height:10%;font-size:14px;">Q3- အိမ်ထောင်ရှိပါသလား။</label>
        </div>
        <div style="padding-top: 5px;background-color:azure;padding-left: 25px;">
        <label style="width:30%;height:10%;font-size:14px;">Q4- ၀င်ငွေမရှိဘဲ ဂျပန်စာသင်တန်းအား <br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;တစ်နှစ်တာအချိန်ပေး တက်ရောက်နိုင်ပါသလား။</label>
        <label style="width:30%;height:10%;font-size:14px;">Q5- နိုင်ငံခြားသွားဖူးပါသလား။</label>
        <label style="width:30%;height:10%;font-size:14px;">Q6- တက်တူးရှိပါသလား။ (ခန္ဓာကိုယ်၏ မည်သည့်နေရာတွင်ဖြစ်စေ)</label>
        </div>
        <div style="padding-top: 5px;padding-bottom: 5px;background-color:cornsilk;padding-left: 25px;">
        <label style="width:30%;height:10%;font-size:14px;">Q7- ရောဂါအခံရှိခြင်း၊ဆေးရုံတက်ခဲ့ရခြင်း၊ <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;မတော်တဆဖြစ်ဖူးခြင်းရှိပါသလား။</label>
        <label style="width:30%;height:10%;font-size:14px;">Q8- ဂျပန်စာလေ့လာဖူးပါသလား။</label>
        <label style="width:30%;height:10%;font-size:14px;">Q9- ဂျပန်လုပ်ငန်းတွင်လက်ရှိလုပ်ကိုင်နေပါသလား။</label>
        </div>
      </div>

          <div style="padding-top: 30px;">
            <table id="tbcustomers" class="hrtable" style="width=100%;">
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


<%--test by amon--%>
 


