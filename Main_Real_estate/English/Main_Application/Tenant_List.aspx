<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Tenant_List.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Tenant_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('.datatable').DataTable({
                dom: 'Bfrtip',
               // lengthChange: false,
                "pageLength": 10000,
                buttons: [
                    'copyHtml5',
                    'excelHtml5',
                    'csvHtml5',
                    /*'pdfHtml5'*/
                ],
                language: {
                    url: 'https://cdn.datatables.net/plug-ins/1.12.1/i18n/ar.json'
                }
            });

            table.buttons().container()
                .appendTo('#DataTables_Table_0_wrapper .col-md-6:eq(0)');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
       table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            font-size: 13px;
            text-align: center;
            padding: 10px !important;
        }

        th {
            background-color: #52a2da;
            color: #ffffff;
        }
    </style>
    <%--***********************************************************************************************--%>
     <!-- Container Fluid-->
    <div class="row" style="padding: 20px">
        <div class="col-lg-3 mb-3" >
            <h1 class="h3 mb-0 text-gray-800" >
                <asp:Label ID="lbl_titel_Tenant_List" runat="server" Text="قائمة المستأجرين"></asp:Label>
            </h1>
        </div>
        <div class="col-lg-3 mb-3">
            <asp:LinkButton ID="Add" CssClass="btn btn-primary" runat="server" PostBackUrl="~/English/Main_Application/Add_Tenant.aspx">
                    <i class="fa fa-plus" style="font-size:25px;"></i> &nbsp; إضافة مستأجر جديد</asp:LinkButton>

        </div>
        <div class="col-lg-3">
            <div class="form-group">
                <asp:Label ID="lbl_Tenant_Type" runat="server" Text="نوع المستأجر"></asp:Label>
                <asp:DropDownList ID="Tenant_Type_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Tenant_Type_DropDownList_SelectedIndexChanged">
                    <asp:ListItem Value="1" Text="الكل"></asp:ListItem>
                    <asp:ListItem Value="2" Text="شركات"></asp:ListItem>
                    <asp:ListItem Value="3" Text="أفراد"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
     <div class="row" style="padding: 20px">
        <div class="col-lg-12 mb-4">
            <!-- Simple Tables -->
            <div class="card">

                


                <div class="table-responsive" id="Grid" >
                    <asp:Repeater ID="tenant_List" runat="server" ClientIDMode="Static" OnItemDataBound="tenant_List_ItemDataBound">
                        <HeaderTemplate>
                            <table  cellspacing="0" style="width: 100%; font-size:11px" class="datatable table table-striped table-bordered">
                                <thead>
                                    <th style="text-align: center;vertical-align: middle;">مسلسل</th>
                                    <th style="text-align: center;vertical-align: middle;">اسم المستأجر</th>
                                    <th style="text-align: center;vertical-align: middle;">الجوال</th>
                                    <th style="text-align: center;vertical-align: middle;">الهاتف</th>
                                    <th style="text-align: center;vertical-align: middle;">البريد الإلكتروني</th>
                                    <th style="text-align: center;vertical-align: middle;">تقيم العميل</th>
                                </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td> <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                <td>
                                    <asp:Label  runat="server"  />
                                    <asp:LinkButton ID="lbl_Tenants_Arabic_Name" Text='<%# Eval("Tenants_Arabic_Name") %>'  runat="server" CommandArgument='<%# Eval("Tenants_ID") %>' OnClick="Details_Tenant" > </asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Tenants_Mobile" runat="server" Text='<%# Eval("Tenants_Mobile") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Tenants_Tell" runat="server" Text='<%# Eval("Tenants_Tell") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Tenants_Email" runat="server" Text='<%# Eval("Tenants_Email") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Persenteg" runat="server" Text='<%# Eval("Persenteg") %>' /></td>
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
    <!---Container Fluid-->
</asp:Content>
