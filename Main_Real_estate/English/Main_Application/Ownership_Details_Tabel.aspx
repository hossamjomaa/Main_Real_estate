<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Ownership_Details_Tabel.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Ownership_Details_Tabel" %>

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
    <div class="container-login" style="padding-top: 70px">
        <div class="row justify-content-center" style="margin-top: -129px;">
            <div class="col-xl-12 col-lg-12 col-md-9">

                <div class="card shadow-sm my-5">
                    <div class="card-body p-0">
                        <div class="row" style="top: -14px;">
                            <div class="col-lg-12">
                                <div class="login-form">
                                    <h1 class="h4 text-gray-900 mb-4" style="margin-left: 40%">&nbsp;تفاصيل :
                                        <asp:Label ID="lbl_Details_ownership_Name" runat="server" Text=""></asp:Label>
                                    </h1>
                                    <div>
                                        <div class="row" style="border-style: solid; border-radius: 9px;">

                                            <div class="col-lg-12">
                                                <div class="card mb-2" style="padding: 30px">
                                                    <table>
                                                        <tr>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Name_Ar" runat="server" Text=" اسم الملكية" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Name_EN" runat="server" Text="property name" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Code" runat="server" Text="رمز الملكية" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_PIN" runat="server" Text="الرقم المساحي" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Bond_No" runat="server" Text="رقم السند " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Number_Of_Building" runat="server" Text="عدد الابنية " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Zone_Name" runat="server" Text=" المنطقة" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Name_Ar" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Name_En" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Code" runat="server" Text=".../..." Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_PIN" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Bond_No" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Number_Of_Building" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Zone_Name" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>

                                            <div class="col-lg-12">
                                                <div class="card mb-2" style="padding: 30px">
                                                    <table>
                                                        <tr>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Zone_NO" runat="server" Text="رقم المنطقة " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Landlord" runat="server" Text=" المالك" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Land_Value" runat="server" Text="قيمة الأرض " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Parcel_Area" runat="server" Text="مساحة الأرض" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Street_NO" runat="server" Text="رقم الشارع " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Street_Name" runat="server" Text="اسم الشارع " Font-Size="15" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Zone_NO" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Landlord" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Land_Value" runat="server" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Parcel_Area" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Street_NO" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Street_Name" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <h4>
                                            <asp:Label ID="Label11" runat="server" Text="مستندات الملكية"></asp:Label></h4>

                                        <div class="row" style="border-style: solid; border-radius: 9px;">
                                            <div class="col-lg-6">

                                                <div class="card mb-2" style="padding: 30px; height: 120px">
                                                    <h6>سيند الملكية - مخطط الملكية</h6>
                                                    <table>
                                                        <tr>
                                                            <th>
                                                                <asp:Label ID="lbl_Titel_Ownership_Certificate_Pdf" runat="server" Text="سند ملكية" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Titel_Property_Scheme" runat="server" Text="مخطط" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <a runat="server" id="Link_Ownership_Certificate_Pdf" style="font-size: 15px;">
                                                                    <i class="fa fa-file-pdf" style="font-size: 30px;"></i>
                                                                    <asp:Label ID="lbl_Link_Ownership_Certificate_Pdf" runat="server" Text=""></asp:Label>
                                                                </a>
                                                            </td>
                                                            <td>
                                                                <a runat="server" id="Link_Property_Scheme" style="font-size: 15px;">
                                                                    <i class="fa fa-file-pdf" style="font-size: 30px;"></i>
                                                                    <asp:Label ID="lbl_Link_Property_Scheme_Pdf" runat="server" Text=""></asp:Label>
                                                                </a>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="card mb-2" style="padding: 30px; height: 120px">
                                                    <h6>جدول المرفقات</h6>
                                                    <div class="row">
                                                        <asp:Repeater ID="Statment_List" runat="server" ClientIDMode="Static">
                                                            <HeaderTemplate>
                                                                <table cellspacing="0" style="width: 100%; font-size: 11px">
                                                                    <thead>
                                                                        <th>م</th>
                                                                        <th style="text-align: center;">المرفق</th>
                                                                        <th style="text-align: center;">تاريخ الإفادة</th>

                                                                    </thead>
                                                                    <tbody>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>

                                                                    <td>
                                                                        <a href='<%# Eval("Statment_Path") %>' target="_blank" id="Link_Property_Scheme" style="font-size: 10px;">
                                                                            <i class="fa fa-file-pdf" style="font-size: 10px;"></i>
                                                                            <asp:Label ID="lbl_Link_Property_Scheme_Pdf" runat="server" Text='<%# Eval("Statment_FileName") %>'></asp:Label>
                                                                        </a>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("Statment_Date") %>' /></td>
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
                                        <br />
                                        <asp:Button ID="btn_Back_To_OwnerShip_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الملكيات" ValidationGroup="x" OnClientClick="JavaScript:window.history.back(1); return false;" />
                                        <br />
                                        <br />
                                        <br />
                                        <hr />

                                        <%-- ************************************************************************************   قائمة الأبنية  *****************************************************************************************************************--%>


                                        <style>
                                            table, th, td {
                                                border: 1px solid black;
                                                border-collapse: collapse;
                                                text-align: center
                                            }

                                            th {
                                                background-color: #cacff1;
                                            }
                                        </style>
                                        <%--***********************************************************************************************--%>

                                        <%--<div class="container-fluid" id="container-wrapper" style="border-style:solid;width:100%">--%>







                                        <ul style="background-color: #efefef; min-height: 0px; width: 100%" class="navbar-nav sidebar sidebar-light accordion" id="accordionSidebar">
                                            <li class="nav-item" style="padding-bottom: 10px;" runat="server" id="Ownership_Div">
                                                <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#M_Ownership" aria-expanded="true"
                                                    aria-controls="M_Ownership" style="width: 270px;">
                                                    <i class="fa fa-plus" style="font-size: 25px; font-weight: bold"></i>
                                                    <span style="font-size: 18px;">قائمة  الأبنية</span>
                                                </a>
                                                <div id="M_Ownership" class="collapse" aria-labelledby="headingForm" data-parent="#accordionSidebar">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="card mb-12">
                                                                <div class="card-body">
                                                                    <div class="row">
                                                                        <div class="col-lg-12 mb-4">
                                                                            <!-- Simple Tables -->
                                                                            <div class="card">
                                                                                <div class="table-responsive" style="border-radius: 10px;">
                                                                                    <asp:Repeater ID="building_List" runat="server" ClientIDMode="Static">
                                                                                        <HeaderTemplate>
                                                                                            <table cellspacing="0" style="width: 100%; font-size: 11px" class="datatable table table-striped table-bordered">
                                                                                                <thead>

                                                                                                    <th>البناء</th>
                                                                                                    <th>رقم البناء</th>
                                                                                                    <th>مساحة البناء </th>
                                                                                                    <th>وضع الصيانة</th>
                                                                                                    <th>اسم الملكية</th>
                                                                                                    <th>حالة البناء</th>
                                                                                                    <th>نوع البناء</th>
                                                                                                    <th>قيمة البناء</th>
                                                                                                    <th style="text-align: right"></th>
                                                                                                    <th style="width: 30px"></th>
                                                                                                </thead>
                                                                                                <tbody>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("Building_Arabic_Name") %>' /></td>
                                                                                                <td>
                                                                                                    <asp:Label ID="lbl_zone_arabic_name" runat="server" Text='<%# Eval("Building_NO") %>' /></td>
                                                                                                <td>
                                                                                                    <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("Construction_Area") %>' /></td>
                                                                                                <td>
                                                                                                    <asp:Label ID="lbl_PIN_Number" runat="server" Text='<%# Eval("Maintenance_status") %>' /></td>
                                                                                                <td>
                                                                                                    <asp:Label ID="lbl_Bond_NO" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                                                                                <td>
                                                                                                    <asp:Label ID="lbl_Parcel_Area" runat="server" Text='<%# Eval("Building_Arabic_Condition") %>' /></td>
                                                                                                <td>
                                                                                                    <asp:Label ID="lbl_Building_Arabic_Type" runat="server" Text='<%# Eval("Building_Arabic_Type") %>' /></td>
                                                                                                <td>
                                                                                                    <asp:Label ID="lbl_Building_Value" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Building_Value")))%>' /></td>



                                                                                                <td style="text-align: right">
                                                                                                    <a href='<%# Eval("Building_Permit_Path") %>' target="_blank" id="Link_Building_Permit_Path" style="font-size: 15px;">
                                                                                                        <i class="fa fa-file-image" style="font-size: 11px;"></i>
                                                                                                        <asp:Label ID="Label10" runat="server" Text="رخصة بناء"></asp:Label>
                                                                                                    </a>
                                                                                                    <a href='<%# Eval("certificate_of_completion_Path") %>' target="_blank" id="Link_certificate_of_completion_Path" style="font-size: 15px;">
                                                                                                        <i class="fa fa-file-pdf" style="font-size: 11px;"></i>
                                                                                                        <asp:Label ID="Label1" runat="server" Text="شهادة إتمام"></asp:Label>
                                                                                                    </a>
                                                                                                    <a href='<%# Eval("Map_path") %>' target="_blank" id="Link_Map_path" style="font-size: 15px;">
                                                                                                        <i class="fa fa-file-image" style="font-size: 11px;"></i>
                                                                                                        <asp:Label ID="Label2" runat="server" Text="خرائط"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:LinkButton CssClass="btn btn-success" runat="server" CommandArgument='<%# Eval("Building_Id") %>' OnClick="Edit_Building"> <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
                                                                                                    &nbsp;&nbsp;
                                                                            <asp:LinkButton CssClass="btn btn-primary" runat="server" CommandArgument='<%# Eval("Building_Id") %>' OnClick="Details_Building"> <i class="fa fa-list" style="font-size:18px;"></i> </asp:LinkButton>
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
                                                                    <%--</div>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>





































                                        <%-- ************************************************************************************   تفاصيل الأبنية  *****************************************************************************************************************--%>


                                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                                            <div class="container-login" style="padding-top: 70px">
                                                <div class="row justify-content-center" style="margin-top: -129px;">
                                                    <div class="col-xl-12 col-lg-12 col-md-9">

                                                        <div class="card shadow-sm my-5">
                                                            <div class="card-body p-0">
                                                                <div class="row" style="top: -14px;">
                                                                    <div class="col-lg-12">
                                                                        <div class="login-form">
                                                                            <h1 class="h4 text-gray-900 mb-4" style="margin-left: 40%">&nbsp;تفاصيل 
                                                                             <asp:Label ID="lbl_Details_Building_Name" runat="server" Text=""></asp:Label>

                                                                            </h1>
                                                                            <div>
                                                                                <div class="row" style="border-style: solid; border-radius: 9px; padding: 30px">


                                                                                    <div class="col-lg-12">
                                                                                        <div class="card mb-2">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Tiltel_Buliding_En_Name" runat="server" Text="Building Name" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Dtl_Buliding_Ar_Name" runat="server" Text="  البناء بالعربي " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Number" runat="server" Text="رقم البناء " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Construction_Area" runat="server" Text="مساحة البناء " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Maintenance_status" runat="server" Text="وضع الصيانة  " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Building_Value" runat="server" Text="قيمة البناء  " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label5" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label6" runat="server" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Number" runat="server" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Construction_Area" runat="server" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Maintenance_status" runat="server" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Building_Value" runat="server" Font-Size="15px"></asp:Label></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>

                                                                                    <br />





                                                                                    <div class="col-lg-12">
                                                                                        <div class="card mb-2">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Ownership" runat="server" Text="الملكية" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Building_Condition" runat="server" Text="حالة البناء" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Building_Type" runat="server" Text="نوع البناء" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_electricity_meter" runat="server" Text="عداد الكهرباء" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Water_meter" runat="server" Text="عداد المياه" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Number_Of_Units" runat="server" Text="عدد الوحدات :" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Building_Ownership" runat="server" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Building_Condition" runat="server" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Building_Type" runat="server" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_electricity_meter" runat="server" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Water_meter" runat="server" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Number_Of_Units" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <br />
                                                                                <h4>
                                                                                    <asp:Label ID="Label7" runat="server" Text="مستندات و صور البناء"></asp:Label></h4>
                                                                                <div class="row" style="border-style: solid; border-radius: 9px;">
                                                                                    <div class="col-lg-6">
                                                                                        <div class="card mb-2" style="padding: 30px;">

                                                                                            <table>
                                                                                                <tr>
                                                                                                    <th>صورة </th>
                                                                                                    <th>المدخل</th>
                                                                                                    <th>مسقط</th>
                                                                                                    <th>صورة</th>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:ImageButton ID="Building_Photo" runat="server" Width="80px" Height="80px" OnClick="Building_Photo_Click" OnClientClick="target ='_blank';" /></td>
                                                                                                    <td>
                                                                                                        <asp:ImageButton ID="Entrance" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Entrance_Click" /></td>
                                                                                                    <td>
                                                                                                        <asp:ImageButton ID="Plan" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Plan_Click" /></td>
                                                                                                    <td>
                                                                                                        <asp:ImageButton ID="Image" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Image_Click" /></td>
                                                                                                </tr>
                                                                                            </table>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="col-lg-6">
                                                                                        <div class="card mb-2" style="padding: 30px;">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <th>رخصة البناء </th>
                                                                                                    <th>شهادة الإتمام</th>
                                                                                                    <th>خرائك</th>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <a runat="server" id="Link_Building_Permit" style="font-size: 15px;">
                                                                                                            <i class="fa fa-file-pdf" style="font-size: 40px;"></i>
                                                                                                            <asp:Label ID="lbl_Link_Building_Permit_Pdf" runat="server" Text=""></asp:Label>
                                                                                                        </a>
                                                                                                    </td>

                                                                                                    <td>
                                                                                                        <a runat="server" id="Link_certificate_of_completion" style="font-size: 15px;">
                                                                                                            <i class="fa fa-file-pdf" style="font-size: 40px;"></i>
                                                                                                            <asp:Label ID="lbl_Link_certificate_of_completion_Pdf" runat="server" Text=""></asp:Label>
                                                                                                        </a>
                                                                                                    </td>

                                                                                                    <td>
                                                                                                        <a runat="server" id="Link_Map" style="font-size: 15px;">
                                                                                                            <i class="fa fa-file-pdf" style="font-size: 40px;"></i>
                                                                                                            <asp:Label ID="lbl_Link_Map" runat="server" Text=""></asp:Label>
                                                                                                        </a>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <br />
                                                                                            <br />
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>




                                            <div class="row">
                                                <div class="col-lg-12 mb-4">
                                                    <!-- Simple Tables -->
                                                    <div class="card">
                                                        <div class="table-responsive" id="Grid">

                                                            <asp:Repeater ID="Unit_List" runat="server" ClientIDMode="Static">
                                                                <HeaderTemplate>
                                                                    <table cellspacing="0" style="width: 100%; font-size: 11px" class="datatable table table-striped table-bordered">
                                                                        <thead>
                                                                            <th>#</th>
                                                                            <th>رقم الوحدة</th>
                                                                            <th>مساحة الوحدة</th>
                                                                            <th>رقم الطابق </th>
                                                                            <th>وضع الصيانة</th>
                                                                            <th>نوع الوحدة</th>
                                                                            <th>الحالة الإيجارية</th>
                                                                            <th>القيمة الإفتراضية</th>
                                                                            <th style="text-align: center;">تفاصيل الوحدة</th>
                                                                            <th>اسم البناء</th>
                                                                            <th></th>
                                                                        </thead>
                                                                        <tbody>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                                                        <td>
                                                                            <asp:Label ID="lbl_Unit_number" runat="server" Text='<%# Eval("Unit_Number") %>' /></td>
                                                                        <td>
                                                                            <asp:Label ID="lbl_Unit_Space" runat="server" Text='<%# Eval("Unit_Space") %>' /></td>
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
                                                                            <asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Eval("Building_Arabic_Name") %>' /></td>
                                                                        <td>
                                                                            <asp:LinkButton CssClass="btn btn-success" runat="server" CommandArgument='<%# Eval("Unit_Id") %>' OnClick="Edit_Unit"> <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
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
                                            <asp:Button ID="btn_Close_Building_Details" CssClass="btn btn-danger" runat="server" Text="إغلاق" OnClick="btn_Close_QID_Panel_Click" Height="43px" Width="263px" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
