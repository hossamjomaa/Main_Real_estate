<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Unit_List_Status.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Unit_List_Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            var table = $('.datatable').DataTable({
                dom: 'Bfrtip',
                /*lengthChange: false,*/
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
            text-align: center
        }
        th{
            background-color:#cacff1;
        }
    </style>
    <%------------------------------------------------------------------------------------------------------------------------------------------%>
        <!-- Container Fluid-->
   <div class="container-fluid" id="container-wrapper">
        <div class="row">
            <div class="col-lg-2 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Unit_List" runat="server" Text="قائمة الوحدات"></asp:Label>
                    <asp:Label ID="lbl_titel_Unit_Status" runat="server"></asp:Label>
                </h1>
            </div>
            <div class="col-lg-3 mb-3">
                <asp:LinkButton CssClass="btn btn-light mb-1" runat="server" PostBackUrl="~/English/Main_Application/DashBoard.aspx" >العودة للوحة المؤشرات</asp:LinkButton>

            </div>
        </div>

        <div class="row">
        <div class="col-lg-12 mb-4">
            <!-- Simple Tables -->
            <div class="card">
                <div class="table-responsive" id="Grid" >
                  
                    <asp:Repeater ID="eeeee" runat="server" ClientIDMode="Static">
                        <HeaderTemplate>
                            <table  cellspacing="0" style="width: 100%; font-size:11px" class="datatable table table-striped table-bordered">
                                <thead>

                                    <th>رقم الوحدة</th>
                                    <th>مساحة الوحدة</th>
                                    <th>رقم الطابق </th>
                                    <th>الوضع الحالي</th>
                                    <th>نوع الوحدة</th>
                                    <th>الحالة الإيجارية</th>
                                    <th>القيمة الإفتراضية</th>
                                    <th style=" text-align: center;">تفاصيل الوحدة</th>
                                    <th>اسم الملكية</th>
                                    <th>اسم الابناء</th>
                                </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Unit_number" runat="server" Text='<%# Eval("Unit_Number") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Unit_Space" runat="server"  Text='<%# Eval("Unit_Space") %>'/></td>
                                <td>
                                    <asp:Label ID="lbl_Floor_Number" runat="server" Text='<%# Eval("Floor_Number") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_current_situation" runat="server" Text='<%# Eval("current_situation") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Unit_Arabic_Type" runat="server" Text='<%# Eval("Unit_Arabic_Type") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Unit_Arabic_Condition" runat="server" Text='<%# Eval("Unit_Arabic_Condition") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_virtual_Value" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "virtual_Value")))%>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Unit_Arabic_Detail" runat="server" Text='<%# Eval("Unit_Arabic_Detail") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Eval("Building_Arabic_Name") %>' /></td>
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
