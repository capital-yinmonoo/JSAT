<%@ Page Title="クライアント情報一覧" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Client_Profile_View.aspx.cs" Inherits="JSAT_Ver1.Employer.Client_Profile_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if ((charCode >= 48 && charCode <= 57) || charCode == 8)
                return true;
            else return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <section id="main-content">
        <section class="wrapper">
            <div class="row" style="height: 50px;">
                <div class="col-lg-12">
                    <h1 class="page-header">Employer</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            クライアント情報一覧(Client Information List)
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">
                                <fieldset>
                                    <strong style="font-size: medium;"></strong>
                                    <table>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                                    HeaderText="You must enter Only Number"
                                                    EnableClientScript="true"
                                                    ForeColor="Red"
                                                    ValidationGroup="check"
                                                    ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table>

                                        <tr>
                                            <td></td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>クライアントNo<br />
                                                (Client No)</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtClientNo" ValidationGroup="check" onkeypress="return isNumberKey(event)"
                                                    MaxLength="9" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                    ControlToValidate="txtClientNo"
                                                    ValidationExpression="\d+"
                                                    Display="Static" ForeColor="Red"
                                                    EnableClientScript="true" ValidationGroup="check" Text="*"
                                                    ErrorMessage="Please enter numbers only in クライアントNo."
                                                    runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="Label" Text="業種（大分類)(Large Industry) "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlIndustryMajor" Width="300px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlIndustryMajor_SelectedIndexChanged" CssClass="form-control">
                                                </asp:DropDownList></td>
                                        </tr>

                                        <tr>
                                            <td>会社名<br />
                                                (Company Name)</td>
                                            <td>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <td>
                                                <asp:Label runat="server" ID="Label1" Text="業種（小分類)(Small Industry)"></asp:Label>
                                                <br />
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlIndustrySmall" Width="500px"></asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td>フリーワード<br />
                                                (Free Word)
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox runat="server" ID="txtKey" Width="730px" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <br />
                                                <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" OnClick="btnSearch_Click" Text="検索する(Search)" Width="200px" ValidationGroup="check" />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table>
                                        <tr>
                                            <td>

                                                <asp:Button ID="New" runat="server" OnClick="btnNew_Click" class="btn btn-primary" Text="Register Client Information (INFORMATION OF CLIENT)" Width="400px" />  <%--クライアント情報(INFORMATION OF CLIENT)を登録する--%>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel runat="server" ID="uptPanel">
                                                    <ContentTemplate>
                                                        <asp:GridView runat="server" ID="gvClient_Profile" AutoGenerateColumns="False" ForeColor="#333333"
                                                            DataKeyNames="ID" EmptyDataText="There is no data to display." DataSourceID="ObjectDataSource1"
                                                            AllowPaging="True" CellPadding="4" PageSize="10"
                                                            GridLines="None" HeaderStyle-Wrap="false" AllowSorting="True" ShowHeaderWhenEmpty="True"
                                                            OnPageIndexChanging="PageIndexChanging"
                                                            OnRowDataBound="gvClient_Profile_RowDataBound"
                                                            OnPreRender="gvClient_Profile_PreRender"
                                                            OnSorting="gvClient_Profile_OnSorting"
                                                            OnRowCommand="gvClient_Profile_RowCommand" class="table">

                                                            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Options" HeaderStyle-ForeColor="White"> <%--操作--%>
                                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDetail" class="btn btn-primary" runat="server" CommandName="DataDetail" CommandArgument='<%# Eval("ID") %>'>Details</asp:LinkButton>    <%--詳細--%>
                                                                        <br />
                                                                        <asp:LinkButton ID="btnEdit" class="btn btn-primary" runat="server" CommandName="DataEdit" CommandArgument='<%# Eval("ID") %>'>Edit</asp:LinkButton>    <%--編集--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Client_Code" HeaderText="Client_No." SortExpression="Client_Code" HeaderStyle-ForeColor="White">   <%--クライアントNo--%>
                                                                    <HeaderStyle BorderStyle="Solid" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Client_Name" HeaderText="Company_Name" SortExpression="Client_Name" HeaderStyle-ForeColor="White">   <%--会社名--%>
                                                                    <HeaderStyle BorderStyle="Solid" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" HeaderStyle-ForeColor="White"> <%--所在地--%>
                                                                    <HeaderStyle BorderStyle="Solid" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Business" HeaderText="Industry(Small_Classification)"
                                                                    SortExpression="Industry" HeaderStyle-ForeColor="White">    <%--業種(小分類)--%>
                                                                    <HeaderStyle BorderStyle="Solid" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="500px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Consent" HeaderText="Consent" SortExpression="Consent" HeaderStyle-ForeColor="White">   <%--同意書--%>
                                                                    <HeaderStyle BorderStyle="Solid" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                        <asp:ObjectDataSource ID="ObjectDataSource1" EnablePaging="true" SortParameterName="sort" MaximumRowsParameterName="PageSize" SelectCountMethod="TotalRowCount" SelectMethod="SelectByCriteria" TypeName="JSAT_BL.Client_ProfileBL" StartRowIndexParameterName="startIndex" runat="server" OnSelecting="ObjectDataSource1_Selecting"></asp:ObjectDataSource>
                                                        <asp:HiddenField runat="server" ID="hdfsearch" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                                <!-- /.table-responsive -->
                            </div>
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.panel -->
                    </div>
                    <!-- /.col-lg-6 -->
                </div>
                <!-- /.row -->
            </div>
        </section>
        <!-- /#page-wrapper -->
    </section>
    <!-- javascripts -->
    <script src="../js/jquery.js"></script>
	<script src="../js/jquery-ui-1.10.4.min.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>   
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>    
    <script src="../js/scripts.js"></script>
</asp:Content>
