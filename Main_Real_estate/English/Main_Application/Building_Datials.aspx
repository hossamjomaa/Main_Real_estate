<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Building_Datials.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Building_Datials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <script src="https://cdnjs.cloudflare.com/ajax/libs/ekko-lightbox/5.3.0/ekko-lightbox.min.js"></script>



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
                                            table {
                                                margin-top: 10px;
                                            }
                                            table, th, td {
                                                border: 1px solid #ddd;
                                                border-collapse: collapse;
                                                text-align: center
                                            }

                                            th {
                                                background-color: #52a2da;
                                                color: #fff;
                                            }
                                        </style>


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
                                                                <asp:Label ID="lbl_Title_Name_EN" runat="server" Text="Building Name" Font-Size="15px" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Name_Ar" runat="server" Text="  البناء بالعربي " Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Number" runat="server" Text="رقم البناء " Font-Size="15px" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Construction_Area" runat="server" Text="مساحة البناء " Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Maintenance_status" runat="server" Text="وضع الصيانة  " Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Building_Value" runat="server" Text="قيمة البناء  " Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Name_EN" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Name_Ar" runat="server" Font-Size="15px"></asp:Label></td>
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
                                                                <asp:Label ID="lbl_Title_Ownership" runat="server" Text="الملكية" Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Building_Condition" runat="server" Text="حالة البناء" Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Building_Type" runat="server" Text="نوع البناء" Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_electricity_meter" runat="server" Text="عداد الكهرباء" Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Water_meter" runat="server" Text="عداد المياه" Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Number_Of_Units" runat="server" Text="عدد الوحدات " Font-Size="15px"  Font-Bold="true"></asp:Label></th>
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
                                        <h4> <asp:Label ID="Label11" runat="server" Text="مستندات و صور البناء"></asp:Label></h4>
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
                                                            <th>خرائط</th>
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
                                        <br />
                                        <asp:Button ID="btn_Back_To_Building_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الأبنية" ValidationGroup="x" OnClientClick="X" OnClick="btn_Back_To_Building_List_Click" />

                                        <hr />

                                        <%-- ************************************************************************************   قائمة الوحدات  *****************************************************************************************************************--%>

                                       
                                        <%--***********************************************************************************************--%>




                                        <ul style="background-color: #efefef; min-height: 0px; width: 100%" class="navbar-nav sidebar sidebar-light accordion" id="accordionSidebar">
                                            <li class="nav-item" style="padding-bottom: 10px;" runat="server" id="Ownership_Div">
                                                <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#M_Ownership" aria-expanded="true"
                                                    aria-controls="M_Ownership" style="width: 270px;">
                                                    <i class="fa fa-plus" style="font-size: 25px; font-weight: bold"></i>
                                                    <span style="font-size: 18px;">قائمة  الوحدات</span>
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
                                                                                <div class="container-fluid" id="container-wrapper">
                                            <div class="row">
                                                <div class="col-lg-12 mb-4">
                                                    <!-- Simple Tables -->
                                                    
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
                                                                            <th style="width: 100px"></th>
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
                                                                            <asp:LinkButton CssClass="btn btn-success" runat="server" CommandArgument='<%# Eval("Unit_Id") %>' OnClick="Edit_Unit"> <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
                                                                            &nbsp;&nbsp;
                                                                            <asp:LinkButton CssClass="btn btn-primary" runat="server" CommandArgument='<%# Eval("Unit_Id") %>' OnClick="Details_Unit"> <i class="fa fa-list" style="font-size:18px;"></i> </asp:LinkButton>
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







                                        <%-- ************************************************************************************   تفاصيل الوحدات  *****************************************************************************************************************--%>

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
                                                                               ( <asp:Label ID="lbl_Details_Unit_Name" runat="server" Text=""></asp:Label>)

                                                                            </h1>
                                                                            <div>



                                                                                <div class="row" style="border-style: solid; border-radius: 9px;">
                                                                                    <div class="col-lg-12">
                                                                                        <div class="card mb-2">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Unit_Number" runat="server" Text="رقم الوحدة" Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Floor_Number" runat="server" Text="رقم الطابق" Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Unit_Sapce" runat="server" Text="مساحة الوحدة " Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Oreedo_Number" runat="server" Text="رقم أوريدوو" Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Electricity_Number" runat="server" Text="رقم الكهرباء" Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Unit_Number" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Floor_Number" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Unit_Sapce" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Oreedo_Number" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Electricity_Number" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                            </table>
                                                                                        </div>
                                                                                </div>
                                                                                    <div class="col-lg-12">
                                                                                        <div class="card mb-2">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Water_Number" runat="server" Text="رقم المياه" Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_current_situation" runat="server" Text="الوضع الحالي" Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Unit_type" runat="server" Text="نوع الوحدة " Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Unit_Condition" runat="server" Text="حالة الوحدة " Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label ID="lbl_Title_Unit_Detail" runat="server" Text="تفاصيل الوحدة " Font-Size="15px"  Font-Bold="true"></asp:Label></th>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Water_Number" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_current_situation" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Unit_type" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Unit_Condition" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lbl_Dtl_Unit_Detail" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <br />
                                                                                <h4> <asp:Label ID="Label1" runat="server" Text="صور الوحدة"></asp:Label></h4>
                                                                                <div class="row" style="border-style: solid; border-radius: 9px;">
                                                                                    <div class="col-lg-12">
                                                                                        <div class="card mb-2">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <th><asp:Label ID="lbl_Titel_Image_1" runat="server" Text="صورة 1 " Font-Size="15px" ></asp:Label></th>
                                                                                                    <th><asp:Label ID="lbl_Titel_Image_2" runat="server" Text="صورة 2 " Font-Size="15px" ></asp:Label></th>
                                                                                                    <th><asp:Label ID="lbl_Titel_Image_3" runat="server" Text="صورة 3 " Font-Size="15px" ></asp:Label></th>
                                                                                                    <th><asp:Label ID="lbl_Titel_Image_4" runat="server" Text="صورة 4 " Font-Size="15px" ></asp:Label></th>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td><asp:ImageButton ID="Image_1" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Photo_Click" /></td>
                                                                                                    <td><asp:ImageButton ID="Image_2" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Image_2_Click" /></td>
                                                                                                    <td><asp:ImageButton ID="Image_3" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Image_3_Click" /></td>
                                                                                                    <td><asp:ImageButton ID="Image_4" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Image_4_Click" /></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <br />
                                                                                <%--<asp:Button ID="btn_Back_To_Unit_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الوحدات" ValidationGroup="x" OnClick="btn_Back_To_Unit_List_Click" OnClientClick="x"  />--%>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
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
