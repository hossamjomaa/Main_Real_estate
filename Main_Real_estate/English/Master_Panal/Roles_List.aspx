<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Roles_List.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Roles_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.js"></script>
    <script src="../JS/DataTableScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../CSS/DataTableCss.css" rel="stylesheet" />
     <!-- Container Fluid-->
    <div class="container-fluid" id="container-wrapper">
        <div class="row">
            <div class="col-lg-4 mb-3" style="">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel" runat="server" Text="قائمة الصلاحيات"></asp:Label>
                </h1>
            </div>
            <div class="col-lg-4">
                <button style="background-color:#52a2da; color:white; border-style:none; height:40px; border-radius:7px;" runat="server" onserverclick="GoToAdd"><i class="fa fa-plus-circle" aria-hidden="true"></i> إضافة </button>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" style="border-radius: 10px;" id="Grid">
                        <asp:Repeater ID="The_Table" runat="server" ClientIDMode="Static">
                        <HeaderTemplate>
                            <table  cellspacing="0" style="width: 100%; font-size:11px" id="Table" class="datatable table table-striped table-bordered">
                                <thead>
                                    <th>إسم الصلاحية</th>
                                    <th>الملكيات</th>
                                    <th>التعاقد</th>
                                    <th>شؤون العملاء</th>
                                    <th>إدارة الاصول</th>
                                    <th>التحصيل</th>
                                    <th>البيانات المالية</th>
                                    <th>إدارة المهام</th>
                                    <th>كشف النواقص</th>
                                    <th>التسويق</th>
                                    <th>أعدادات النظام</th>
                                    <th></th>
                                </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td> <asp:Label ID="lbl_Role_name" runat="server" Text='<%# Eval("Role_name") %>' /></td>
                                <td> <asp:Label ID="lbl_properties" runat="server" Text='<%# Eval("properties") %>' /></td>
                                <td> <asp:Label ID="lbl_Contracting" runat="server" Text='<%# Eval("Contracting") %>' /></td>
                                <td> <asp:Label ID="lbl_Customer_Affairs" runat="server" Text='<%# Eval("Customer_Affairs") %>' /></td>
                                <td> <asp:Label ID="lbl_Asset_Management" runat="server" Text='<%# Eval("Asset_Management") %>' /></td>
                                <td> <asp:Label ID="lbl_Collecting" runat="server" Text='<%# Eval("Collecting") %>' /></td>
                                <td> <asp:Label ID="lbl_Financial_Statements" runat="server" Text='<%# Eval("Financial_Statements") %>' /></td>
                                <td> <asp:Label ID="lbl_Marketing" runat="server" Text='<%# Eval("Marketing") %>' /></td>
                                <td> <asp:Label ID="lbl_Task_Management" runat="server" Text='<%# Eval("Task_Management") %>' /></td>
                                <td> <asp:Label ID="lbl_Deficiency_Detection" runat="server" Text='<%# Eval("Deficiency_Detection") %>' /></td>
                                <td> <asp:Label ID="lbl_System_Settings" runat="server" Text='<%# Eval("System_Settings") %>' /></td>
                                <td>
                                    <asp:LinkButton  runat="server" CommandArgument='<%# Eval("Role_ID") %>' OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');" OnClick="Delete" ><i class="fa fa-trash" style="font-size:18px;"></i></asp:LinkButton>
                                    <asp:LinkButton  runat="server" CommandArgument='<%# Eval("Role_ID") %>' OnClick="Edit"> <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
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
