<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Career_Resume_View.aspx.cs" Inherits="JSAT_Ver1.Employee.Career_Resume_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../js/jquery.sumoselect.min.js"></script>
    <link href="../css/sumoselect.css" rel="stylesheet" />
    <style type="text/css">
        .SumoSelect.open > .optWrapper {
            width:250px;
        }
        
        .ui-autocomplete
        {
            max-height: 300px;
            overflow-y:auto;
            overflow-x: hidden;
            padding-right: 20px;
        }
        html .ui-autocomplete {
            height: 450px;
        }

        .fixed-height {
			padding: 1px;
			max-height: 200px;
			overflow: auto;
		}
        .ui-menu-item {
            cursor: pointer;
            border-bottom: 2px groove #007AFF;
        }
    </style>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if ((charCode >= 48 && charCode <= 57) || charCode == 8)
                return true;
            else return false;
        }
    </script>

    <script type="text/javascript">
        $(function () {
            $("[id$=txtOther]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Career_Resume_View.aspx/GetOtherData",
                        data: "{'other': '" + document.getElementById('<%= txtOther.ClientID%>').value + "'}",
                         dataType: "json",
                         success: function (data) {
                             response($.map(data.d, function (item) {
                                 return {
                                     label: item.split('*')[0],
                                     val: item.split('*')[1]
                                 }
                             }))
                         },
                         error: function (response) {
                             alert(response.responseText);
                         },
                         failure: function (response) {
                             alert(response.responseText);
                         }
                     });
                 },
                 select: function (e, i) {
                     $("[id$=hfCustomerId]").val(i.item.val);
                 },
                 minLength: 1
             });
         });
    </script>

    <script type="text/javascript">
        $(function () {
            $("[id$=txtImpression]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Career_Resume_View.aspx/GetImpressionData",
                        data: "{'impression': '" + document.getElementById('<%= txtImpression.ClientID%>').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('*')[0],
                                    val: item.split('*')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row" style="height: 50px;">
                <div class="col-lg-12">
                    <h1 class="page-header">Employee</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            人材情報一覧(Career Registration)
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <table class="form-group" style="width: 100%;">
                                <tr> <td>登録形態(Type)</td>
                                     <td> <asp:CheckBox ID="chkdomestic" runat="server" Text="国内(Domestic)"/></td>
                                     <td> <asp:CheckBox ID="chkoversea" runat="server" Text="海外(Oversea)"/></td>
                                </tr>
                                <tr>
                                    <td>Registration No.</td>
                                    <td>
                                        <%--<asp:DropDownList runat="server" ID="ddlCode" CssClass="form-control" Width="70px" Height="30px" >
                                            <asp:ListItem> </asp:ListItem>
                                            <asp:ListItem>AC</asp:ListItem>
                                            <asp:ListItem>EN</asp:ListItem>
                                            <asp:ListItem>GN</asp:ListItem>
                                            <asp:ListItem>IT</asp:ListItem>
                                            <asp:ListItem>JP</asp:ListItem>
                                            <asp:ListItem>SL</asp:ListItem>
                                            <asp:ListItem>JPN</asp:ListItem>
                                            <asp:ListItem>CAD</asp:ListItem>
                                            <asp:ListItem>Y</asp:ListItem>
                                            <asp:ListItem>C</asp:ListItem>
                                        </asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcCode" runat="server" CssClass="form-control" Width="100px" DataPlaceHolder="--選択--" AllowSingleDeselect="true">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>AC</asp:ListItem>
                                            <asp:ListItem>EN</asp:ListItem>
                                            <asp:ListItem>GN</asp:ListItem>
                                            <asp:ListItem>IT</asp:ListItem>
                                            <asp:ListItem>JP</asp:ListItem>
                                            <%--<asp:ListItem>SL</asp:ListItem>--%>
                                            <asp:ListItem>JPN</asp:ListItem>
                                            <%-- <asp:ListItem>CAD</asp:ListItem>--%>
                                            <asp:ListItem>Y</asp:ListItem>
                                            <asp:ListItem>C</asp:ListItem>
                                        </asp:DropDownListChosen> -
                                        <asp:TextBox runat="server" ID="txtCode" Width="100px" Height="30px" CssClass="form-control"></asp:TextBox></td>
                                    <td>Name</td>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" Width="194px" Height="30px" CssClass="form-control"></asp:TextBox></td>
                                    <td>Gender</td>
                                    <td>
                                        <%--<asp:DropDownList runat="server" ID="ddlSex" CssClass="form-control" Width="65px" Height="30px"></asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcSex" runat="server" CssClass="form-control" Width="100px" DataPlaceHolder="--選択--" AllowSingleDeselect="true"></asp:DropDownListChosen></td>
                                </tr>
                                <tr>
                                    <td>Japanese</td>
                                    <td>R/W&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <%--<asp:DropDownList runat="server" ID="ddlJapaneseRW" CssClass="form-control" Width="65px" Height="30px"></asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcJapaneseRW" runat="server" CssClass="form-control" Width="100px" DataPlaceHolder="--選択--" AllowSingleDeselect="true"></asp:DropDownListChosen>
                                        <asp:CheckBox runat="server" ID="chkJPRW" Text="Above" /><br />
                                        Speaking
                                        <%--<asp:DropDownList runat="server" ID="ddlJapaneseSpeaking" CssClass="form-control" Width="65px" Height="30px"></asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcJapaneseSpeaking" runat="server" CssClass="form-control" Width="100px" DataPlaceHolder="--選択--" AllowSingleDeselect="true"></asp:DropDownListChosen>
                                        <asp:CheckBox runat="server" ID="chkJPSpeaking" Text="Above" /></td>
                                    <td>English</td>
                                    <td>R/W&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <%--<asp:DropDownList runat="server" ID="ddlEnglishRW" CssClass="form-control" Width="65px" Height="30px"></asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcEnglishRW" runat="server" CssClass="form-control" Width="100px" DataPlaceHolder="--選択--" AllowSingleDeselect="true"></asp:DropDownListChosen>
                                        <asp:CheckBox runat="server" ID="chkEngRW" Text="Above" /><br />
                                        Speaking
                                        <%--<asp:DropDownList runat="server" ID="ddlEnglishSpeaking" CssClass="form-control" Width="65px" Height="30px"></asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcEnglishSpeaking" runat="server" CssClass="form-control" Width="100px" DataPlaceHolder="--選択--" AllowSingleDeselect="true"></asp:DropDownListChosen>
                                        <asp:CheckBox runat="server" ID="chkEngSpeaking" Text="Above" /></td>
                                    <td style="text-align: left">Township</td>
                                    <td>
                                        <asp:ListBox ID="LbTownship" runat="server" CssClass="form-control" Width="250px" Height="30px" SelectionMode="Multiple"></asp:ListBox></td>
                                </tr>
                                <tr>
                                    <td>Age[From]~Age[To]</td>
                                    <td>
                                        <%--<asp:DropDownList ID="ddlFromAge" runat="server" CssClass="form-control" Width="65px" Height="30px">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>21</asp:ListItem>
                                            <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                            <asp:ListItem>24</asp:ListItem>
                                            <asp:ListItem>25</asp:ListItem>
                                            <asp:ListItem>26</asp:ListItem>
                                            <asp:ListItem>27</asp:ListItem>
                                            <asp:ListItem>28</asp:ListItem>
                                            <asp:ListItem>29</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                            <asp:ListItem>31</asp:ListItem>
                                            <asp:ListItem>32</asp:ListItem>
                                            <asp:ListItem>33</asp:ListItem>
                                            <asp:ListItem>34</asp:ListItem>
                                            <asp:ListItem>35</asp:ListItem>
                                            <asp:ListItem>36</asp:ListItem>
                                            <asp:ListItem>37</asp:ListItem>
                                            <asp:ListItem>38</asp:ListItem>
                                            <asp:ListItem>39</asp:ListItem>
                                            <asp:ListItem>40</asp:ListItem>
                                            <asp:ListItem>41</asp:ListItem>
                                            <asp:ListItem>42</asp:ListItem>
                                            <asp:ListItem>43</asp:ListItem>
                                            <asp:ListItem>44</asp:ListItem>
                                            <asp:ListItem>45</asp:ListItem>
                                            <asp:ListItem>46</asp:ListItem>
                                            <asp:ListItem>47</asp:ListItem>
                                            <asp:ListItem>48</asp:ListItem>
                                            <asp:ListItem>49</asp:ListItem>
                                            <asp:ListItem>50</asp:ListItem>
                                            <asp:ListItem>51</asp:ListItem>
                                            <asp:ListItem>52</asp:ListItem>
                                            <asp:ListItem>53</asp:ListItem>
                                            <asp:ListItem>54</asp:ListItem>
                                            <asp:ListItem>55</asp:ListItem>
                                        </asp:DropDownList>&nbsp; ～ 
                                        <asp:DropDownList ID="ddlToAge" runat="server" Width="65px" CssClass="form-control" Height="30px">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>18</asp:ListItem>
                                                <asp:ListItem>19</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                                <asp:ListItem>21</asp:ListItem>
                                                <asp:ListItem>22</asp:ListItem>
                                                <asp:ListItem>23</asp:ListItem>
                                                <asp:ListItem>24</asp:ListItem>
                                                <asp:ListItem>25</asp:ListItem>
                                                <asp:ListItem>26</asp:ListItem>
                                                <asp:ListItem>27</asp:ListItem>
                                                <asp:ListItem>28</asp:ListItem>
                                                <asp:ListItem>29</asp:ListItem>
                                                <asp:ListItem>30</asp:ListItem>
                                                <asp:ListItem>31</asp:ListItem>
                                                <asp:ListItem>32</asp:ListItem>
                                                <asp:ListItem>33</asp:ListItem>
                                                <asp:ListItem>34</asp:ListItem>
                                                <asp:ListItem>35</asp:ListItem>
                                                <asp:ListItem>36</asp:ListItem>
                                                <asp:ListItem>37</asp:ListItem>
                                                <asp:ListItem>38</asp:ListItem>
                                                <asp:ListItem>39</asp:ListItem>
                                                <asp:ListItem>40</asp:ListItem>
                                                <asp:ListItem>41</asp:ListItem>
                                                <asp:ListItem>42</asp:ListItem>
                                                <asp:ListItem>43</asp:ListItem>
                                                <asp:ListItem>44</asp:ListItem>
                                                <asp:ListItem>45</asp:ListItem>
                                                <asp:ListItem>46</asp:ListItem>
                                                <asp:ListItem>47</asp:ListItem>
                                                <asp:ListItem>48</asp:ListItem>
                                                <asp:ListItem>49</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                                <asp:ListItem>51</asp:ListItem>
                                                <asp:ListItem>52</asp:ListItem>
                                                <asp:ListItem>53</asp:ListItem>
                                                <asp:ListItem>54</asp:ListItem>
                                                <asp:ListItem>55</asp:ListItem>
                                                <asp:ListItem>56</asp:ListItem>
                                                <asp:ListItem>56</asp:ListItem>
                                                <asp:ListItem>57</asp:ListItem>
                                                <asp:ListItem>58</asp:ListItem>
                                                <asp:ListItem>59</asp:ListItem>
                                                <asp:ListItem>60</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcFromAge" runat="server" CssClass="form-control" Width="100px" DataPlaceHolder="--選択--" AllowSingleDeselect="true">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>21</asp:ListItem>
                                            <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                            <asp:ListItem>24</asp:ListItem>
                                            <asp:ListItem>25</asp:ListItem>
                                            <asp:ListItem>26</asp:ListItem>
                                            <asp:ListItem>27</asp:ListItem>
                                            <asp:ListItem>28</asp:ListItem>
                                            <asp:ListItem>29</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                            <asp:ListItem>31</asp:ListItem>
                                            <asp:ListItem>32</asp:ListItem>
                                            <asp:ListItem>33</asp:ListItem>
                                            <asp:ListItem>34</asp:ListItem>
                                            <asp:ListItem>35</asp:ListItem>
                                            <asp:ListItem>36</asp:ListItem>
                                            <asp:ListItem>37</asp:ListItem>
                                            <asp:ListItem>38</asp:ListItem>
                                            <asp:ListItem>39</asp:ListItem>
                                            <asp:ListItem>40</asp:ListItem>
                                            <asp:ListItem>41</asp:ListItem>
                                            <asp:ListItem>42</asp:ListItem>
                                            <asp:ListItem>43</asp:ListItem>
                                            <asp:ListItem>44</asp:ListItem>
                                            <asp:ListItem>45</asp:ListItem>
                                            <asp:ListItem>46</asp:ListItem>
                                            <asp:ListItem>47</asp:ListItem>
                                            <asp:ListItem>48</asp:ListItem>
                                            <asp:ListItem>49</asp:ListItem>
                                            <asp:ListItem>50</asp:ListItem>
                                            <asp:ListItem>51</asp:ListItem>
                                            <asp:ListItem>52</asp:ListItem>
                                            <asp:ListItem>53</asp:ListItem>
                                            <asp:ListItem>54</asp:ListItem>
                                            <asp:ListItem>55</asp:ListItem>
                                        </asp:DropDownListChosen> ～ 
                                        <asp:DropDownListChosen ID="ddlcToAge" runat="server" CssClass="form-control" Width="100px" DataPlaceHolder="--選択--" AllowSingleDeselect="true">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>21</asp:ListItem>
                                            <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                            <asp:ListItem>24</asp:ListItem>
                                            <asp:ListItem>25</asp:ListItem>
                                            <asp:ListItem>26</asp:ListItem>
                                            <asp:ListItem>27</asp:ListItem>
                                            <asp:ListItem>28</asp:ListItem>
                                            <asp:ListItem>29</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                            <asp:ListItem>31</asp:ListItem>
                                            <asp:ListItem>32</asp:ListItem>
                                            <asp:ListItem>33</asp:ListItem>
                                            <asp:ListItem>34</asp:ListItem>
                                            <asp:ListItem>35</asp:ListItem>
                                            <asp:ListItem>36</asp:ListItem>
                                            <asp:ListItem>37</asp:ListItem>
                                            <asp:ListItem>38</asp:ListItem>
                                            <asp:ListItem>39</asp:ListItem>
                                            <asp:ListItem>40</asp:ListItem>
                                            <asp:ListItem>41</asp:ListItem>
                                            <asp:ListItem>42</asp:ListItem>
                                            <asp:ListItem>43</asp:ListItem>
                                            <asp:ListItem>44</asp:ListItem>
                                            <asp:ListItem>45</asp:ListItem>
                                            <asp:ListItem>46</asp:ListItem>
                                            <asp:ListItem>47</asp:ListItem>
                                            <asp:ListItem>48</asp:ListItem>
                                            <asp:ListItem>49</asp:ListItem>
                                            <asp:ListItem>50</asp:ListItem>
                                            <asp:ListItem>51</asp:ListItem>
                                            <asp:ListItem>52</asp:ListItem>
                                            <asp:ListItem>53</asp:ListItem>
                                            <asp:ListItem>54</asp:ListItem>
                                            <asp:ListItem>55</asp:ListItem>
                                            <asp:ListItem>56</asp:ListItem>
                                            <asp:ListItem>56</asp:ListItem>
                                            <asp:ListItem>57</asp:ListItem>
                                            <asp:ListItem>58</asp:ListItem>
                                            <asp:ListItem>59</asp:ListItem>
                                            <asp:ListItem>60</asp:ListItem>
                                        </asp:DropDownListChosen>
                                    </td>
                                    <td colspan="4">
                                        <span style="color: rgb(0, 0, 0); font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif,Meiryo,Meiryob; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">Salary[From]~Salary[To]</span>
                                        <asp:TextBox ID="txtExpectedSalary" runat="server" Width="80px" CssClass="form-control" Height="30px" onkeypress="return isNumberKey(event)" MaxLength="10"></asp:TextBox> ～ 
                                        <asp:TextBox ID="txtExpectedSalary2" runat="server" Width="80px" CssClass="form-control" Height="30px" onkeypress="return isNumberKey(event)" MaxLength="10"></asp:TextBox>
                                        <asp:DropDownListChosen ID="ddlcsalarytype" runat="server" CssClass="form-control" Width="100px" DataPlaceHolder="--選択--" AllowSingleDeselect="true">
                                            <asp:ListItem Text="" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="KS" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="$" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="¥" Value="3"></asp:ListItem>
                                        </asp:DropDownListChosen>
                                        <asp:DropDownListChosen ID="ddlcsalaryformat" runat="server" CssClass="form-control" Width="100px" DataPlaceHolder="--選択--" AllowSingleDeselect="true">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Up to"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Nego"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Max"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Min"></asp:ListItem>
                                        </asp:DropDownListChosen>
                                        <%--<asp:DropDownList ID="ddlsalarytype" runat="server" CssClass="form-control" Width="65px" Height="30px">
                                            <asp:ListItem Text="" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="KS" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="$" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="¥" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlsalaryformat" runat="server" CssClass="form-control" Width="90px" Height="30px">
                                        <asp:ListItem Value="0">--</asp:ListItem>
                                         <asp:ListItem Value="1">Up to</asp:ListItem>
                                         <asp:ListItem Value="2">Nego</asp:ListItem>
                                         <asp:ListItem Value="3">Max</asp:ListItem>
                                         <asp:ListItem Value="4">Min</asp:ListItem>
                                    </asp:DropDownList>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Label runat="server" ID="lblMnRW" Text="R/W" Visible="false"></asp:Label>
                                        <asp:DropDownList runat="server" ID="ddlBurmeseRW" Visible="false"></asp:DropDownList>
                                        <asp:CheckBox runat="server" ID="chkMnRW" Text="Above" Visible="false" />
                                        <asp:Label runat="server" ID="lblMnSpeaking" Text="Speaking" Visible="false"></asp:Label>
                                        <asp:DropDownList runat="server" ID="ddlBurmeseSpeaking" Visible="false" Style="clear: right;"></asp:DropDownList>
                                        <asp:CheckBox runat="server" ID="chkMnSpeaking" Text="Above" Visible="false" /></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">Qualification</td>
                                    <td>
                                        <asp:ListBox ID="Lbqualification" runat="server" CssClass="form-control" Width="250px" SelectionMode="Multiple"></asp:ListBox></td>
                                    <td>Institution</td>
                                    <td>
                                        <%--<asp:DropDownList runat="server" ID="ddlInstitution" CssClass="form-control" Width="300px" Height="30px"></asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcInstitution" runat="server" Width="300px" CssClass="form-control" Height="30px" DataPlaceHolder="---選択---" AllowSingleDeselect="true"></asp:DropDownListChosen></td>
                                    <td style="text-align: left">Major</td>
                                    <td>
                                        <%--<asp:DropDownList runat="server" ID="ddlMajor" Width="250px" Height="30px" CssClass="form-control"></asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcMajor" runat="server" Width="250px" CssClass="form-control" Height="30px" DataPlaceHolder="---選択---" AllowSingleDeselect="true"></asp:DropDownListChosen></td>
                                </tr>
                                <tr>
                                    <asp:DataList ID="DLAbility" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" BorderStyle="None" OnItemDataBound="DLAbility_ItemDataBound">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltitle" runat="server" Font-Bold="true" Width="200px" Text='<%#DataBinder.Eval(Container.DataItem,"Description") %>'></asp:Label>
                                            <asp:ListBox SelectionMode="Multiple" ID="LBAbility" CssClass="form-control list" runat="server" Width="250px"></asp:ListBox>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td colspan="5">
                                        <asp:TextBox runat="server" ID="txtKeyword" Width="800px" Visible="False"></asp:TextBox>
                                        <asp:CheckBox ID="chkJobIntro" runat="server" />
                                        Job Introduction
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlDepartment" Visible="false"></asp:DropDownList></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlPosition" Width="100px" Visible="false"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="6">
                                        <asp:TextBox runat="server" ID="txtKey" Width="750px" Visible="false"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddlindustrynew" runat="server" Width="300px" Visible="false"></asp:DropDownList></td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddldepartmentnew" runat="server" Width="300px" Visible="false"></asp:DropDownList></td>
                                </tr>
                                <tr>Working History</tr>
                                <tr>
                                    <td>Experiences</td>
                                    <td>
                                        <asp:TextBox ID="txtexperience" runat="server" CssClass="form-control" Width="100px" Height="30px"></asp:TextBox>
                                        <asp:Label ID="lblyear" runat="server" Text="Year" Visible="false"></asp:Label>
                                        <asp:CheckBox runat="server" ID="chkexperience" Text="Above" Visible="false" />
                                        ～
                                        <asp:TextBox ID="txtexperienceto" runat="server" CssClass="form-control" Width="100px" Height="30px"></asp:TextBox>
                                        <%--<asp:DropDownList ID="ddlexptype" runat="server" CssClass="form-control" Width="100px" Height="30px">
                                            <asp:ListItem Text="Years" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Months" Value="2"></asp:ListItem>
                                        </asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcexptype" runat="server" CssClass="form-control" Width="100px" >
                                            <asp:ListItem Text="Years" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Months" Value="2"></asp:ListItem>
                                        </asp:DropDownListChosen>
                                    </td>

                                      <td style="border-left:medium solid #000000; border-spacing:10px; width:20px;"></td>
                                    <td>Other</td>
                                    <td>
                                        <asp:TextBox ID="txtOther" runat="server" CssClass="form-control" Width="250px"></asp:TextBox>
                                        <asp:HiddenField ID="hdfOther" runat="server" />
                                    </td>

                                    <td style="border-left:medium solid #000000; border-spacing:10px; width:20px;"></td>
                                    <td>Impression</td>
                                    <td>
                                        <asp:TextBox ID="txtImpression" runat="server" CssClass="form-control" Width="250px" Style="margin-left:10px;"></asp:TextBox>
                                        <asp:HiddenField ID="hdfImpression" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Type of Business</td>
                                    <td>
                                        <%--<asp:DropDownList ID="ddltypeofbusinessnew" runat="server" Width="400px" CssClass="form-control" Height="30px" Visible="false"></asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlctypeofbusinessnew" runat="server" Width="390px" CssClass="form-control" Height="30px" DataPlaceHolder="---選択---" AllowSingleDeselect="true"></asp:DropDownListChosen>
                                    </td>
                                    <td style="border-left:medium solid #000000; border-spacing:10px; width:20px;"></td>
                                    <td> Position Requested</td>
                                    <td style="width:390px">
                                        <asp:ListBox ID="lstpositionrequested" runat="server" CssClass="form-control" Width="250px" Height="30px" SelectionMode="Multiple"></asp:ListBox>
                                        <%--<asp:DropDownList ID="ddlpositionrequested" runat="server" Width="400px" CssClass="form-control" Height="30px" ></asp:DropDownList>--%></td>
                                    <td>
                                        <%--<asp:DropDownList ID="ddlpositionrequestedlevel" runat="server" CssClass="form-control" Height="30px" Width="150px"></asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcpositionrequestedlevel" runat="server" Width="150px" CssClass="form-control" Height="30px" DataPlaceHolder="---選択---" AllowSingleDeselect="true"></asp:DropDownListChosen></td>
                                </tr>
                                <tr>
                                    <td>Position </td>
                                    <td>
                                        <%--<asp:DropDownList ID="ddlpositionnew" runat="server" Width="400px" CssClass="form-control" Height="30px" ></asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcpositionnew" runat="server" Width="390px" CssClass="form-control lstpositionrequested" Height="30px" DataPlaceHolder="---選択---" AllowSingleDeselect="true"></asp:DropDownListChosen>
                                        <%--<asp:DropDownList ID="ddlpositionnewlevel" runat="server" CssClass="form-control" Width="150px" Height="30px" ></asp:DropDownList>--%>
                                        <asp:DropDownListChosen ID="ddlcpositionnewlevel" runat="server" Width="150px" CssClass="form-control" Height="30px" DataPlaceHolder="---選択---" AllowSingleDeselect="true"></asp:DropDownListChosen></td>
                                    <td style="border-left:medium solid #000000; border-spacing:10px; width:20px"></td>
                                    <td>Total Mark</td>
                                    <td>
                                        <asp:TextBox ID="txttotalmark" runat="server" Width="30px" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txttotalmark1" runat="server" Width="100px" CssClass="form-control" Height="30px"></asp:TextBox>
                                        <asp:CheckBox runat="server" ID="chktotalmark" Text="Above" />
                                    </td>
                                    <td style="border-left:medium solid #000000; border-spacing:3px; width:20px;"></td>
                                    <td>First Interviewer</td>
                                   <td>
                                      <asp:DropDownList ID="ddlfirsint" CssClass="form-control" Width="230px" Height="30px" runat="server" style="margin-left:10px;">
                                    </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center">
                                        <br />
                                        <asp:Button ID="btnsearch" runat="server" OnClick="Button1_Click" Width="200px" class="btn btn-primary" Text="Search" />&nbsp; &nbsp;                     
                                        <asp:Button ID="btnPrint" runat="server" CssClass="btn" Text="Print" Height="25px" Width="90px" Visible="False" CausesValidation="False" />&nbsp; &nbsp;<br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7" align="left">
                                        <asp:Button ID="btnNew" runat="server" class="btn btn-primary" Text="★ Register Talent Information (INFORMATION OF CANDIDATE)" OnClick="btnNew_Click1" />     <%--人材情報(INFORMATION OF CANDIDATE)を登録する--%>
                                        <asp:Button ID="btnExport" runat="server" class="btn btn-primary" OnClick="btnExport_Click" Text="Exporting (Export To Excel)" />  <%--エクスポートをする(Export To Excel)--%>
                                        <asp:LinkButton ID="lnkdownload" runat="server" OnClick="lnkdownload_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:ScriptManager ID="ScriptManager1" OnNavigate="ScriptManager1_Navigate" runat="server" EnableHistory="true"></asp:ScriptManager>
                            <asp:UpdatePanel runat="server" ID="udtPanel">
                                <ContentTemplate>
                                    <div id="gvscroll" runat="server" style="overflow: auto; height: 100%; margin-bottom: 37px;">
                                        <asp:GridView runat="server" ID="gvCareerProfileView" AutoGenerateColumns="False" ForeColor="#333333" DataKeyNames="ID" EmptyDataText="There is no data to display." Style="margin-left: 0px" AllowPaging="true"
                                            OnPageIndexChanging="PageIndexChanging" OnRowDataBound="gvCareerProfileView_RowDataBound" CellPadding="4" PageSize="10" DataSourceID="ObjectDataSource1"
                                            GridLines="None" HeaderStyle-Wrap="false" ShowHeaderWhenEmpty="True" OnPreRender="gvCareer_Profile_PreRender" AllowSorting="True" class="table"
                                            OnSorting="gvCareer_Profile_OnSorting" OnRowCommand="gvCareerProfileView_RowCommand">
                                            <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAll" runat="server" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="true" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="chkStatus" Enabled="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" HeaderText="">
                                                    <HeaderStyle Width="100px" />
                                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDetail" runat="server" CommandName="DataDetail" CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-primary">Details</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Career_Code" SortExpression="Career_Code" HeaderStyle-ForeColor="White">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Career_Code") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCareerCode" runat="server" Text='<%# Eval("Career_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:BoundField ItemStyle-Width="10%" ItemStyle-Wrap="false" DataField="Name" HeaderText="Name" HeaderStyle-ForeColor="White" SortExpression="Name">
                                                    <HeaderStyle Width="700px" />
                                                    <ItemStyle Width="700px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Age" HeaderText=" Age" SortExpression="Age">
                                                    <ItemStyle HorizontalAlign="Center" Width="300px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText=" Gender" SortExpression="Gender" HeaderStyle-ForeColor="White">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Gender") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="300px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="PhoneNo1" HeaderText="Phone No" HeaderStyle-ForeColor="White">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Area" HeaderText="Address" HeaderStyle-ForeColor="White">
                                                    <ItemStyle HorizontalAlign="Center" Width="300px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Language" ControlStyle-Width="100px" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblJapanese" Text="JAPANESE"></asp:Label>
                                                        <asp:Label runat="server" ID="lblEnglish" Text="ENGLISH"></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="R/W" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblJapaneseRWData" Text='<%#Eval("Japanese_RW_Level") %>'></asp:Label><br />
                                                        <asp:Label runat="server" ID="lblEnglishRWData" Text='<%#Eval("English_RW_Level") %>'></asp:Label><br />

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Speaking" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblJapaneseSpeakingData" Text='<%#Eval("Japanese_Speaking_Level") %>'></asp:Label><br />
                                                        <asp:Label runat="server" ID="lblEnglishSpeakingData" Text='<%#Eval("English_Speaking_Level") %>'></asp:Label><br />

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Salary" HeaderText="Salary" DataFormatString="{0:#,###0}" HeaderStyle-ForeColor="White">
                                                    <ItemStyle HorizontalAlign="Center" Width="300px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Age" HeaderText="年齢" SortExpression="Age" Visible="False">
                                                    <HeaderStyle BorderStyle="Solid" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DOB" HeaderText="生年月日" SortExpression="DOB" DataFormatString="{0:d MMM yyyy} " Visible="False">
                                                    <HeaderStyle BorderStyle="Solid" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Other_Address" HeaderText="Other Address" SortExpression="Other_Address" Visible="False">
                                                    <HeaderStyle BorderStyle="Solid" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Department" HeaderText="職種(大分類)" SortExpression="Department" Visible="False">
                                                    <HeaderStyle BorderStyle="Solid" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Position" HeaderText="職種(小分類)" SortExpression="Position" Visible="False">
                                                    <HeaderStyle BorderStyle="Solid" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Totalmark" HeaderText="職種(小分類)" SortExpression="Totalmark" Visible="False">
                                                    <HeaderStyle BorderStyle="Solid" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Experience" HeaderText="職種(小分類)" SortExpression="Experience" Visible="False">
                                                    <HeaderStyle BorderStyle="Solid" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CareerStatus" HeaderText="Career Status" Visible="True" HeaderStyle-ForeColor="White">
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UpdateDate" HeaderText="UpdateDate" Visible="True" HeaderStyle-ForeColor="White">
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="資格" HeaderStyle-Width="300px" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:GridView ID="gvQualification" runat="server" AutoGenerateColumns="false" ShowHeader="false">
                                                            <Columns>
                                                                <asp:BoundField DataField="Qualification" ItemStyle-Width="20%" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="300px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="JobIntroduction" HeaderText="Job_Introduction" HeaderStyle-ForeColor="White">
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </div>
                                    <div style="margin: 10px; vertical-align: central;">
                                        <asp:ObjectDataSource ID="ObjectDataSource1" EnablePaging="true" SortParameterName="sort" MaximumRowsParameterName="PageSize" SelectCountMethod="TotalRowCount" SelectMethod="SearchAndPaging" TypeName="JSAT_BL.Career_ResumeBL" StartRowIndexParameterName="startIndex" runat="server" OnSelecting="ObjectDataSource1_Selecting"></asp:ObjectDataSource>
                                        <asp:HiddenField runat="server" ID="hdfsearch" />
                                    </div>
                                    <asp:Label ID="lblCount" runat="server"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-6 -->
        </section>
        <!-- /#page-wrapper -->
    </section>
    <!-- /#page-wrapper -->
    <%--<script src="../js/jquery.js"></script>--%>
    <script src="../js/jquery-ui-1.10.4.min.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../js/scripts.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(<%= LbTownship.ClientID%>).SumoSelect({
                selectAll: true
            });
            $(<%= Lbqualification.ClientID%>).SumoSelect({
                selectAll: true
            });
            $(<%=lstpositionrequested.ClientID%>).SumoSelect({
                selectAll: true
            });
            $("#<%= DLAbility.ClientID %> .list").SumoSelect({
                selectAll: true
            });
        });
    </script>
</asp:Content>
