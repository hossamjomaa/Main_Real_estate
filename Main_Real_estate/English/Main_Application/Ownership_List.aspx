<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Ownership_List.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Ownership_List" %>

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
                //lengthChange: false,
                "pageLength": 10000,
                buttons: [
                    'excelHtml5',
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
    <div class="container-fluid" id="container-wrapper">
        <div class="row">
            <div class="col-lg-3 mb-3" style="">
                <h1 class="h3 mb-0 text-gray-800"></h1>
            </div>
        </div>
        <div class="row" >
            <div class="col-lg-3 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Ownership_List" runat="server" Text="كشف  الملكيات"></asp:Label>
                </h1>
            </div>
            <div class="col-lg-3 mb-3">
                <asp:LinkButton ID="Add" CssClass="btn btn-primary" runat="server" PostBackUrl="~/English/Main_Application/Accordin_Add_Ownership.aspx">
                    <i class="fa fa-plus" style="font-size:25px;"></i> &nbsp; إضافة ملكية جديدة</asp:LinkButton>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" id="Grid" >
                       <asp:Repeater ID="ownership_List" runat="server" ClientIDMode="Static" OnItemDataBound="ownership_List_ItemDataBound">
                <HeaderTemplate>
                    <table cellspacing="0" style="width: 100%; font-size: 13px" class="datatable table table-striped table-bordered">
                        <thead>
                            <th style="text-align: center; vertical-align: middle;">م</th>
                            <th style="text-align: center; vertical-align: middle;"> المنطقة</th>
                            <th style="text-align: center; vertical-align: middle;">كود الملكية </th>
                            <th style="width: 200px;text-align: center; vertical-align: middle;">اسم الملكية</th>
                            <th style="width: 100px; vertical-align: middle; text-align: center">المالك</th>
                            <th style="text-align: center; vertical-align: middle;">الرقم المساحي</th>
                            <th style="text-align: center; vertical-align: middle;">المساحة</th>
                            <th style="text-align: center; vertical-align: middle;">سند الملكية</th>
                            <th style="text-align: center; vertical-align: middle;">عدد المباني</th>
                            <th style="width: 220px; text-align: center; vertical-align: middle;">نوع الوحدات</th>
                            <th style="width: 150px"></th>
                            <th style="width: 50px"></th>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td> <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                    
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
                            <asp:Label ID="lbl_Parcel_Area" runat="server" Text='<%# Eval("Parcel_Area") %>' /></td>


                        <td>
                            <asp:Label ID="lbl_Bond_NO" runat="server" Text='<%# Eval("Bond_NO") %>' /></td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("buildingCount") %>' /></td>
                    
                        <td>
                            <asp:Label ID="lbl_Unit_Type" runat="server" Text='<%# Eval("Unit_Type") %>' /></td>

                        <td style="text-align: right">
                            <a href='<%# Eval("owner_ship_Certificate_Image_Path") %>' target="_blank" id="Link_Property_Scheme" style="font-size: 13px;">
                                <i class="fa fa-file-pdf" style="font-size: 13px;"></i>
                                <asp:Label ID="lbl_Link_Property_Scheme_Pdf" runat="server" Text="سند الملكية"></asp:Label>
                            </a>
                            <hr />
                            <a href='<%# Eval("Property_Scheme_Image_Path") %>' target="_blank" id="A1" style="font-size: 13px;">
                                <i class="fa fa-file-image" style="font-size: 13px;"></i>
                                <asp:Label ID="Label10" runat="server" Text="المخطط"></asp:Label>
                            </a>
                        </td>
                        <td>
                            <asp:LinkButton ID="Edit" ForeColor="#0779c9" runat="server" CommandArgument='<%# Eval("Owner_Ship_Id") %>' OnClick="Edit_Ownership"> <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
                            &nbsp;&nbsp
                            <asp:LinkButton ID="Details" ForeColor="#0779c9" runat="server" CommandArgument='<%# Eval("Owner_Ship_Id") %>' OnClick="Details_Ownership"> <i class="fa fa-list" style="font-size:18px;"></i> </asp:LinkButton>
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
