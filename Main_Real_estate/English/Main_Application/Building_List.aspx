<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Building_List.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Building_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {


             $('a[href*="No File"]').each(function () {
                 $(this).css('display', 'none');
             });


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
            font-size: 13px !important;
            padding: 8px !important;
            text-align: center !important;
        }

        th {
            background-color: #52a2da;
            color: #ffffff;
            vertical-align: middle;
        }
    </style>
    <%--***********************************************************************************************--%>

    <!-- Container Fluid-->
    <div class="container-fluid" id="container-wrapper">


         <div class="row">
            <div class="col-lg-2 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Building_List" runat="server" Text="قائمة  الأبنية"></asp:Label>
                </h1>
            </div>
            <div class="col-lg-3 mb-3">
                <asp:LinkButton ID="Add" CssClass="btn btn-primary" runat="server" PostBackUrl="~/English/Main_Application/Add_Building.aspx" >
                    <i class="fa fa-plus" style="font-size:25px;"></i> &nbsp; إضافة بناء جديدة</asp:LinkButton>

            </div>
        </div>





        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" style="border-radius: 10px;">


                        <asp:Repeater ID="building_List" runat="server" ClientIDMode="Static" OnItemDataBound="building_List_ItemDataBound">
                        <HeaderTemplate>
                            <table  cellspacing="0" style="width: 100%; font-size:11px" class="datatable table table-striped table-bordered">
                                <thead>
                                    <th>#</th>
                                    <th>اسم الملكية</th>
                                    <th>البناء</th>
                                    <th>رقم البناء</th>
                                    <th>مساحة البناء </th>
                                    <th>وضع الصيانة</th>
                                    <th>حالة البناء</th>
                                    <th>نوع البناء</th>
                                    <th>قيمة البناء</th>
                                    <th>صورة البناء</th>
                                    <th style="text-align:right; width: 100px"></th>
                                    <th style="width: 50px"></th>
                                </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="lbl_Bond_NO" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("Building_Arabic_Name") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_zone_arabic_name" runat="server" Text='<%# Eval("Building_NO") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("Construction_Area") %>'/></td>
                                
                                <td>
                                    <asp:Label ID="lbl_PIN_Number" runat="server" Text='<%# Eval("Maintenance_status") %>' /></td>
                                
                                <td>
                                    <asp:Label ID="lbl_Parcel_Area" runat="server" Text='<%# Eval("Building_Arabic_Condition") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Building_Arabic_Type" runat="server" Text='<%# Eval("Building_Arabic_Type") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Building_Value" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Building_Value")))%>' /></td>

                                <td > 
                                           <a href='<%# Eval("Building_Photo_Path") %>' target="_blank"> 
                                               <asp:Image ID="Building_Image" runat="server" ImageUrl='<%# Eval("Building_Photo_Path") %>' Width="80px" Height="80px"/> 
                                           </a>

                                            <asp:Label ID="lbl_Building_Image" runat="server" Text='<%# Eval("Building_Photo") %>' Visible="false"/></td>

                                <td style="text-align:right">
                                    <a href='<%# Eval("Building_Permit_Path") %>' target="_blank" id="Link_Building_Permit_Path" style="font-size: 13px;">
                                        <i class="fa fa-file-image" style="font-size: 13px;"></i>
                                        <asp:Label ID="Label10" runat="server" Text="رخصة بناء"></asp:Label>
                                    </a>
                                    <hr />
                                    <a href='<%# Eval("certificate_of_completion_Path") %>' target="_blank" id="Link_certificate_of_completion_Path" style="font-size: 13px;">
                                        <i class="fa fa-file-pdf" style="font-size: 13px;"></i>
                                        <asp:Label ID="Label1" runat="server" Text="شهادة إتمام"></asp:Label>
                                    </a>
                                    <hr />
                                    <a href='<%# Eval("Map_path") %>' target="_blank" id="Link_Map_path" style="font-size: 13px;">
                                        <i class="fa fa-file-image" style="font-size: 13px;"></i>
                                        <asp:Label ID="Label2" runat="server" Text="خرائط"></asp:Label>
                                    </a>
                                </td>
                                <td>
                                    <asp:LinkButton ID="Edit" ForeColor="#0779c9" runat="server" CommandArgument='<%# Eval("Building_Id") %>' OnClick="Edit_Building" > <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
                                    <asp:LinkButton ID="Details" ForeColor="#0779c9" runat="server" CommandArgument='<%# Eval("Building_Id") %>' OnClick="Details_Building" > <i class="fa fa-list" style="font-size:18px;"></i> </asp:LinkButton>
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
