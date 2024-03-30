<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Assset_List.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Assset_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.js"></script>
    <script src="../JS/DataTableScript.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS/DataTableCss.css" rel="stylesheet" />
     <%--***********************************************************************************************--%>
    <!-- Container Fluid-->
    <div class="container-fluid" id="container-wrapper">


         <div class="row">
            <div class="col-lg-2 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Building_List" runat="server" Text="قائمة  الأصول"></asp:Label>
                </h1>
            </div>
            <div class="col-lg-3 mb-3">
                <asp:LinkButton CssClass="btn btn-primary" runat="server" PostBackUrl="~/English/Master_Panal/Add_Asset.aspx" >
                    <i class="fa fa-plus" style="font-size:25px;"></i> &nbsp; إضافة</asp:LinkButton>

            </div>
        </div>





        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" style="border-radius: 10px;">


                        <asp:Repeater ID="Assset_List_1" runat="server" ClientIDMode="Static">
                        <HeaderTemplate>
                            <table  cellspacing="0" style="width: 100%; font-size:11px" id="Table" class="datatable table table-striped table-bordered">
                                <thead>

                                    <th>نوع الأصل</th>
                                    <th>اسم الأصل</th>
                                    <th>الرقم التسلسلي </th>
                                    <th>حالة الأصل</th>
                                    <th>الموقع العام</th>

                                    <th> الملكية</th>
                                    <th> البناء</th>
                                    <th> الوحدة</th>

                                    <th>مكان الأصل</th>
                                    <th>الموّرد </th>
                                    <th style="width:200px"></th>
                                </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><asp:Label ID="lbl_Categoty_AR" runat="server" Text='<%# Eval("Categoty_AR") %>' /></td>
                                <td><asp:Label ID="lbl_Assets_Arabic_Name" runat="server" Text='<%# Eval("Assets_Arabic_Name") %>' /></td>
                                <td><asp:Label ID="lbl_Serial_Number" runat="server" Text='<%# Eval("Serial_Number") %>' /></td>
                                <td><asp:Label ID="lbl_Asset_Arabic_Condition" runat="server" Text='<%# Eval("Asset_Arabic_Condition") %>' /></td>
                                <td><asp:Label ID="lbl_Main_Place" runat="server" Text='<%# Eval("Main_Place") %>' /></td>

                                <td><asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                <td><asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Eval("Building_Arabic_Name") %>' /></td>
                                <td><asp:Label ID="lbl_Unit_Number" runat="server" Text='<%# Eval("Unit_Number") %>' /></td>

                                <td><asp:Label ID="lbl_Asset_Arabic_Location" runat="server" Text='<%# Eval("Asset_Arabic_Location") %>' /></td>
                                <td><asp:Label ID="lbl_Vendor_Arabic_Type" runat="server" Text='<%# Eval("Vendor_Arabic_Type") %>' /></td>
                                <td>
                                    <asp:LinkButton  runat="server" CommandArgument='<%# Eval("Assets_Id") %>' OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');" OnClick="Delete_Asset"  ><i class="fa fa-trash" style="font-size:18px;"></i></asp:LinkButton>
                                    &nbsp;&nbsp;
                                    <asp:LinkButton  runat="server" CommandArgument='<%# Eval("Assets_Id") %>' OnClick="Edit_Asset" > <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
                                    &nbsp;&nbsp;
                                    <asp:LinkButton  runat="server" CommandArgument='<%# Eval("Assets_Id") %>' OnClick="Asset_Details" >  <i class="fa fa-list" style="font-size:18px;"></i> </asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!---Container Fluid-->
</asp:Content>
