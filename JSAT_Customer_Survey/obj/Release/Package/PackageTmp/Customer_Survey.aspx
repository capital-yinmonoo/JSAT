<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_Survey.aspx.cs" Inherits="JSAT_Customer_Survey.Customer_Survey" %>

<!DOCTYPE html>

<html>
<head>
     <script type="text/javascript" >
function validatenumerics(key) {
           var keycode = (key.which) ? key.which : key.keyCode;
           if (keycode > 31 && (keycode < 48 || keycode > 57)) {
               return false;
           }
           else return true;
       }
      </script>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>JSAT Customer Survey</title>

     
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <!-- Font Awesome -->
  <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="dist/css/adminlte.min.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
  <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <link rel="shortcut icon" href="images/JSAT_logo.ico">
</head>
<body>
     <form id="form1" runat="server" >
	<div class="card card-primary">
		<div class="card-header h1" style="text-align:center">Customer Survey Form
		</div>
		<div class="card-body">

				<div class="row col-md-6">               
					<span id="lblName" style="margin-top:20px; padding-left:30px; " >နာမည် </span> 
					<span style=" margin-top:25px; color:red; margin-left:30px;">***  </span>
					<input name="txtName" type="text" maxlength="40" id="txtName"  runat="server" class="form-control" style="height:30px;width:200px;margin-left:23px; margin-top:20px;"/>         
				</div>
				<div class="row col-md-6">              
					<span id="lblPhno" style=" margin-top:20px; padding-left:30px;">ဖုန်းနံပါတ် </span>
					<span style="margin-top:25px; color:red;margin-left:10px;">***  </span>
					<input name="txtPhno" type="text" maxlength="40" id="txtPhno" runat="server" onkeypress="return validatenumerics(event);" class="form-control" style="height:30px;width:200px;margin-left:22px; margin-top:20px; margin-bottom:30px;"/>       
				</div>
			<table class="table">
                  <thead>
                    <tr>
                      <th style="width: 10px"></th>
                      <th style="width: 70%"></th>
                      <th style="width: 30%"></th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>၁။</td>
                      <td>တက္ကသိုလ် ပထမနှစ် တက်ရောက်ဖူးပါသလား။ </td>
                      <td>
                        <div class="form-group clearfix">
                      <div class="icheck-primary d-inline" style="padding-right:10px !important">
                        <input type="radio" id="rdoQ1" name="rdoGName1" runat="server" >
                        <label for="rdoQ1">YES
                        </label>
                      </div>
                      <div class="icheck-primary d-inline">
                        <input type="radio" id="rdo1" name="rdoGName1" runat="server" checked="true">
                        <label for="rdo1">NO
                        </label>
                      </div>
                    </div>
                      </td>
                    </tr>
                    <tr>
                      <td>၂။</td>
                      <td>လက်ရှိတွင်အသက်(၁၉ နှစ်မှ ၂၆ နှစ်) အကြား ရှိပါသလား။ </td>
                      <td>
                        <div class="form-group clearfix">
                      <div class="icheck-primary d-inline" style="padding-right:10px !important">
                        <input type="radio" id="rdoQ2" name="rdoGName2" runat="server">
                        <label for="rdoQ2">YES
                        </label>
                      </div>
                      <div class="icheck-primary d-inline">
                        <input type="radio" id="rdo2" name="rdoGName2" runat="server" checked="true">
                        <label for="rdo2">NO
                        </label>
                      </div>
                    </div>
                      </td>
                    </tr>
                    <tr>
                      <td>၃။</td>
                      <td>အိမ်ထောင်ရှိပါသလား။ </td>
                      <td>
                        <div class="form-group clearfix">
                      <div class="icheck-primary d-inline" style="padding-right:10px !important">
                        <input type="radio" id="rdoQ3" name="rdoGName3" runat="server">
                        <label for="rdoQ3">YES
                        </label>
                      </div>
                      <div class="icheck-primary d-inline">
                        <input type="radio" id="rdo3" name="rdoGName3" runat="server" checked="true">
                        <label for="rdo3">NO
                        </label>
                      </div>
                    </div>
                      </td>
                    </tr>
					<tr>
                      <td>၄။</td>
                      <td>၀င်ငွေမရှိဘဲ ဂျပန်စာသင်တန်းအား တစ်နှစ်တာအချိန်ပေး တက်ရောက်နိုင်ပါသလား။ </td>
                      <td>
                        <div class="form-group clearfix">
                      <div class="icheck-primary d-inline" style="padding-right:10px !important">
                        <input type="radio" id="rdoQ4" name="rdoGName4" runat="server">
                        <label for="rdoQ4">YES
                        </label>
                      </div>
                      <div class="icheck-primary d-inline">
                        <input type="radio" id="rdo4" name="rdoGName4" runat="server" checked="true">
                        <label for="rdo4">NO
                        </label>
                      </div>
                    </div>
                      </td>
                    </tr>
					<tr>
                      <td>၅။</td>
                      <td>နိုင်ငံခြားသွားဖူးပါသလား။ </td>
                      <td>
                        <div class="form-group clearfix">
                      <div class="icheck-primary d-inline" style="padding-right:10px !important">
                        <input type="radio" id="rdoQ5" name="rdoGName5" runat="server">
                        <label for="rdoQ5">YES
                        </label>
                      </div>
                      <div class="icheck-primary d-inline">
                        <input type="radio" id="rdo5" name="rdoGName5" runat="server" checked="true">
                        <label for="rdo5">NO
                        </label>
                      </div>
                    </div>
                      </td>
                    </tr>
					<tr>
                      <td>၆။</td>
                      <td>တက်တူးရှိပါသလား။ (ခန္ဓာကိုယ်၏ မည်သည့်နေရာတွင်ဖြစ်စေ) </td>
                      <td>
                        <div class="form-group clearfix">
                      <div class="icheck-primary d-inline" style="padding-right:10px !important">
                        <input type="radio" id="rdoQ6" name="rdoGName6" runat="server">
                        <label for="rdoQ6">YES
                        </label>
                      </div>
                      <div class="icheck-primary d-inline">
                        <input type="radio" id="rdo6" name="rdoGName6" runat="server" checked="true">
                        <label for="rdo6">NO
                        </label>
                      </div>
                    </div>
                      </td>
                    </tr>
					<tr>
                      <td>၇။</td>
                      <td>ရောဂါအခံရှိခြင်း၊ဆေးရုံတက်ခဲ့ရခြင်း၊မတော်တဆဖြစ်ဖူးခြင်းရှိပါသလား။ </td>
                      <td>
                        <div class="form-group clearfix">
                      <div class="icheck-primary d-inline" style="padding-right:10px !important">
                        <input type="radio" id="rdoQ7" name="rdoGName7" runat="server">
                        <label for="rdoQ7">YES
                        </label>
                      </div>
                      <div class="icheck-primary d-inline">
                        <input type="radio" id="rdo7" name="rdoGName7" runat="server" checked="true">
                        <label for="rdo7">NO
                        </label>
                      </div>
                    </div>
                      </td>
                    </tr>
					<tr>
                      <td>၈။</td>
                      <td>ဂျပန်စာလေ့လာဖူးပါသလား။</td>
                      <td>
                        <div class="form-group clearfix">
                      <div class="icheck-primary d-inline" style="padding-right:10px !important">
                        <input type="radio" id="rdoQ8" name="rdoGName8" runat="server">
                        <label for="rdoQ8">YES
                        </label>
                      </div>
                      <div class="icheck-primary d-inline">
                        <input type="radio" id="rdo8" name="rdoGName8" runat="server" checked="true">
                        <label for="rdo8">NO
                        </label>
                      </div>
                    </div>
                      </td>
                    </tr>
					<tr>
                      <td>၉။</td>
                      <td>ဂျပန်လုပ်ငန်းတွင်လက်ရှိလုပ်ကိုင်နေပါသလား။ </td>
                      <td>
                        <div class="form-group clearfix">
                      <div class="icheck-primary d-inline" style="padding-right:10px !important">
                        <input type="radio" id="rdoQ9" name="rdoGName9" runat="server">
                        <label for="rdoQ9">YES
                        </label>
                      </div>
                      <div class="icheck-primary d-inline">
                        <input type="radio" id="rdo9" name="rdoGName9" runat="server" checked="true">
                        <label for="rdo9">NO
                        </label>
                      </div>
                    </div>
                      </td>
                    </tr>
                  </tbody>
                </table>
		</div>
		<div class="card-footer" style="text-align:center">
		 <%-- <button type="submit" runat="server" class="btn btn-info" onclick="btnSave_Click">&nbsp;&nbsp;&nbsp;&nbsp;Save&nbsp;&nbsp;&nbsp;&nbsp;</button>
		  <button type="submit"  runat="server" class="btn btn-default" onclick="btnCancel_Click">Cancel</button>--%>
           <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-info" />
            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="btn btn-default"/>
		</div>
	</div>     
         </form>
</body>
</html>
