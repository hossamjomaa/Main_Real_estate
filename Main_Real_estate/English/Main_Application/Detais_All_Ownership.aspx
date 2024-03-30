<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Detais_All_Ownership.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Detais_All_Ownership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        

        $(document).ready(function () {

            /*This will hide the icons if there is no URL*/
            /*If there is no files, URL will say "No File"*/
            $('a[href*="No File"]').each(function () {
                $(this).css('display', 'none');
            });




            var table = $('.datatable').DataTable({
                dom: 'Bfrtip',
                /* lengthChange: false,*/
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
        .table-condensed tr th {
            border: 0px solid #fff;
            color: black;
            background-color: #cacff1;
        }

        .table-condensed, .table-condensed tr td {
            border: 0px solid #fff;
        }

        tr:nth-child(even) {
            background: #d7d7d7;
        }

        tr:nth-child(odd) {
            background: #e3e3e3;
        }
    </style>

    <div class="container-fluid" id="container-wrapper">
        <div class="row">
            <div class="col-lg-3 mb-3" style="">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Building_List" runat="server" Text="كشف الملكيات"></asp:Label>
                </h1>
            </div>
        </div>
        <%--*************************************************************************************************************--%>

        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" id="Grid">
                        <asp:Repeater ID="Unit_GridView" runat="server" ClientIDMode="Static">
                            <HeaderTemplate>
                                <table cellspacing="0" style="width: 100%" class="datatable table table-striped table-bordered">
                                    <thead>

                                        <th style="width: 25px;">رقم المنطقة</th>
                                        <th style="width: 150px; text-align: center;">اسم المنطقة</th>
                                        <th>رمز الملكية</th>
                                        <th style="width: 150px; text-align: center;">إسم الملكية</th>
                                        <th style="width: 150px; text-align: center;">المالك</th>
                                        <th>الرقم المساحي</th>
                                        <th>قيمة الأرض</th>
                                        <th>المساحة</th>
                                        <th>سند الملكية</th>
                                        <th>عدد المباني</th>
                                        <th style="width: 300px; text-align: center;">تفصيل العمارات</th>
                                        <th>سند الملكية</th>
                                        <th>المخطط</th>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("zone_number") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_zone_arabic_name" runat="server" Text='<%# Eval("zone_arabic_name") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("owner_ship_Code") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Owner_Arabic_name" runat="server" Text='<%# Eval("Owner_Arabic_name") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_PIN_Number" runat="server" Text='<%# Eval("PIN_Number") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Land_Value" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Land_Value")))%>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Bond_NO" runat="server" Text='<%# Eval("Bond_NO") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Parcel_Area" runat="server" Text='<%# Eval("Parcel_Area") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_buildingCount" runat="server" Text='<%# Eval("buildingCount") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Unit_Type" runat="server" Text='<%# Eval("Unit_Type") %>' /></td>
                                    <td>
                                        <a href='<%# Eval("owner_ship_Certificate_Image_Path") %>' target="_blank" id="Link_Property_Scheme" style="font-size: 15px;">
                                            <i class="fa fa-file-pdf" style="font-size: 20px;"></i>
                                            <%-- <asp:Label ID="lbl_Link_Property_Scheme_Pdf" runat="server" Text="خرائط"></asp:Label>--%>
                                        </a>

                                    </td>
                                    <td>
                                        <a href='<%# Eval("Property_Scheme_Image_Path") %>' target="_blank" id="A1" style="font-size: 15px;">
                                            <i class="fa fa-file-image" style="font-size: 20px;"></i>
                                            <%-- <asp:Label ID="Label10" runat="server" Text="صور"></asp:Label>--%>
                                        </a>
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
</asp:Content>
