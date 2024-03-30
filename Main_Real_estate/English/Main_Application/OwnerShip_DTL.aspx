<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="OwnerShip_DTL.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.OwnerShip_DTL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {


            $('a[href*="No File"]').each(function () {
                $(this).css('display', 'none');
            });

            $('img[src*="No File"]').each(function () {
                $(this).css('display', 'none');
            });


            var table = $('.datatable').DataTable({
                dom: '',
                "pageLength": 10000,
                buttons: ['excelHtml5'],
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
        img[src="No File"] {
            display: none;
        }

        #myImg {
            border-radius: 5px;
            cursor: pointer;
            transition: 0.3s;
        }

        #myImg2 {
            border-radius: 5px;
            cursor: pointer;
            transition: 0.3s;
        }

        #myImg3 {
            border-radius: 5px;
            cursor: pointer;
            transition: 0.3s;
        }

        #myImg:hover {
            opacity: 0.7;
        }

        #myImg2:hover {
            opacity: 0.7;
        }

        #myImg3:hover {
            opacity: 0.7;
        }

        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.9); /* Black w/ opacity */
        }

        /* Modal Content (image) */
        .modal-content {
            margin: auto;
            display: block;
            width: 80%;
            max-width: 700px;
        }

        /* Caption of Modal Image */
        #caption {
            margin: auto;
            display: block;
            width: 80%;
            max-width: 700px;
            text-align: center;
            color: #ccc;
            padding: 10px 0;
            height: 150px;
        }

        /* Add Animation */
        .modal-content, #caption {
            -webkit-animation-name: zoom;
            -webkit-animation-duration: 0.6s;
            animation-name: zoom;
            animation-duration: 0.6s;
        }

        @-webkit-keyframes zoom {
            from {
                -webkit-transform: scale(0)
            }

            to {
                -webkit-transform: scale(1)
            }
        }

        @keyframes zoom {
            from {
                transform: scale(0)
            }

            to {
                transform: scale(1)
            }
        }

        /* The Close Button */
        .close {
            position: absolute;
            top: 15px;
            right: 35px;
            color: #f1f1f1;
            font-size: 40px;
            font-weight: bold;
            transition: 0.3s;
        }

            .close:hover,
            .close:focus {
                color: #bbb;
                text-decoration: none;
                cursor: pointer;
            }

        /* 100% Image Width on Smaller Screens */
        @media only screen and (max-width: 700px) {
            .modal-content {
                width: 100%;
            }
        }
    </style>
    <link href="../CSS/Onership_Details.css" rel="stylesheet" />
    <%--******************************************************************************************************************************************************************--%>
    <div class="container">
        <asp:Label CssClass="Titel" ID="lbl_Details_ownership_Name" runat="server" />
        -
        (<asp:Label CssClass="Titel" ID="lbl_Dtl_Code" runat="server" />)
    </div>
    <br />

    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-6 main_div">

                <div class="row">
                    <div class="col-lg-4">
                        <div class="Radios_Info">
                            <img src="Main_Image/land.png" />
                            <br />
                            <asp:Label CssClass="Titel" ID="lbl_Titel_Land_Space" runat="server" Text="مساحة الأرض" />
                            <br />
                            <asp:Label CssClass="Dtl" ID="lbl_Dtl_Parcel_Area" runat="server" Text="456321" />
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="Radios_Info">
                            <img src="Main_Image/number-blocks.png" />
                            <br />
                            <asp:Label CssClass="Titel" ID="lbl_Titel_PIN" runat="server" Text="الرقم المساحي" />
                            <br />
                            <asp:Label CssClass="Dtl" ID="lbl_Dtl_PIN" runat="server" Text="456321" />
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="Radios_Info">
                            <img src="Main_Image/official-documents.png" />
                            <br />
                            <asp:Label CssClass="Titel" ID="lbl_Titel_Bond_No" runat="server" Text="رقم السند" />
                            <br />
                            <asp:Label CssClass="Dtl" ID="lbl_Dtl_Bond_No" runat="server" Text="456321" />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-4">
                        <div class="Radios_Info">
                            <img src="Main_Image/placeholder.png" />
                            <br />
                            <asp:Label CssClass="Titel" ID="lbl_Titel_Zone_Name" runat="server" Text="المنطقة" />
                            <br />
                            <asp:Label CssClass="Dtl" ID="lbl_Dtl_Zone_Name" runat="server" Text="مشيرب" />
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="Radios_Info">
                            <img src="Main_Image/money-bag.png" />
                            <br />
                            <asp:Label CssClass="Titel" ID="lbl_Titel_Land_Value" runat="server" Text="قيمة الأرض" />
                            <br />
                            <asp:Label CssClass="Dtl" ID="lbl_Dtl_Land_Value" runat="server" Text="5622056" />
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="Radios_Info">
                            <img src="Main_Image/motorway.png" />
                            <br />
                            <asp:Label CssClass="Titel" ID="lbl_Titel_Street" runat="server" Text="الشارع" />
                            <br />
                            <asp:Label CssClass="Dtl" ID="lbl_Dtl_Street_Name" runat="server" Text="روضة الخيل" />/<asp:Label CssClass="Dtl" ID="lbl_Dtl_Street_NO" runat="server" Text="13" />
                        </div>
                    </div>
                </div>
            </div>






            <div class="col-lg-6 main_div" style="border-style: solid">
                <div class="row">
                    <div class="col-lg-4">
                        <div class="Radios_Att">
                            <img src="Main_Image/verification.png" />
                            <br />
                            <asp:Label CssClass="Titel" ID="lbl_Titel_Certificate" runat="server" Text="السند" />
                            <br />
                            <a runat="server" id="Link_Ownership_Certificate_Pdf" style="font-size: 15px;">
                                <i class="fa fa-file-pdf" style="font-size: 30px;"></i>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="Radios_Att">
                            <img src="Main_Image/blueprint.png" />
                            <br />
                            <asp:Label CssClass="Titel" ID="lbl_Property_Scheme" runat="server" Text="المخطط" />
                            <br />
                            <a runat="server" id="Link_Property_Scheme" style="font-size: 15px;">
                                <i class="fa fa-file-pdf" style="font-size: 30px;"></i>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="Radios_Att">
                            <img src="Main_Image/statement.png" />
                            <br />
                            <asp:Label CssClass="Titel" ID="lbl_Stetmant" runat="server" Text="الإفادة" />
                            <br />
                            <a runat="server" id="Link_Stetmant" style="font-size: 15px;">
                                <i class="fa fa-file-pdf" style="font-size: 30px;"></i>
                            </a>
                        </div>
                    </div>
                </div>

                <div class="row" style="text-align: center; margin-top: 50px; padding: 10px; height:150px;overflow:auto;margin-top:20px; width:63%">
                    <asp:Repeater ID="Statment_List" runat="server" ClientIDMode="Static">
                        <HeaderTemplate>
                            <table class="scroll">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>

                                <td>
                                    <a href='<%# Eval("Statment_Path") %>' target="_blank" id="Link_Property_Scheme" style="font-size: 10px;">
                                        <i class="fa fa-file-pdf" style="font-size: 10px;"></i>
                                        <asp:Label ID="lbl_Link_Statment_FileName" runat="server" Text='<%# Eval("Statment_FileName") %>'></asp:Label>
                                    </a>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Statment_Date" runat="server" Text='<%# Eval("Statment_Date") %>' /></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <br />
                    <asp:Label CssClass="Titel" ID="lbl_No_Statment" Font-Size="15px" ForeColor="#d770ad" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <br /><asp:Button ID="btn_Back_To_OwnerShip_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الملكيات" ValidationGroup="x" OnClientClick="JavaScript:window.history.back(1); return false;" /><br />
    <%-- ********************************************************************************************* قائمة الابنية **********************************************************************************--%>
    <ul style="background-color: #efefef; min-height: 0px; width: 100%" class="navbar-nav sidebar sidebar-light accordion" id="accordionSidebar">
        <li class="nav-item" style="padding-bottom: 10px;" runat="server" id="Ownership_Div">
            <a class="nav-link" href="#" data-toggle="collapse" data-target="#M_Ownership" aria-expanded="true"
                aria-controls="M_Ownership" style="width: 270px;">
                <i class="fa fa-plus" style="font-size: 25px; font-weight: bold"></i>
                <span style="font-size: 18px;">قائمة  الأبنية</span>
            </a>
            <div id="M_Ownership" class="collapse show" aria-labelledby="headingForm" data-parent="#accordionSidebar">
                <div class="row">
                    <div class="table-responsive" style="border-radius: 10px;">
                        <asp:Repeater ID="building_List" runat="server" ClientIDMode="Static">
                            <HeaderTemplate>
                                <table cellspacing="0" style="width: 100%; font-size: 11px" class="datatable table table-striped table-bordered Buidling_In_Ownership">
                                    <thead>
                                        <th>#</th>
                                        <th>البناء</th>
                                        <th>رقم البناء</th>
                                        <th>مساحة البناء </th>
                                        <th>وضع الصيانة</th>
                                        <th>حالة البناء</th>
                                        <th>نوع البناء</th>
                                        <th>قيمة البناء</th>
                                        <th style="width: 20px"></th>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="row" runat="server">
                                    <td><asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                    <td><asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Eval("Building_Arabic_Name") %>' /><asp:Label ID="Building_Id" runat="server" Visible="false" Text='<%# Eval("Building_Id") %>' /> </td>
                                    <td><asp:Label ID="lbl_Building_NO" runat="server" Text='<%# Eval("Building_NO") %>' /></td>
                                    <td><asp:Label ID="lbl_Construction_Area" runat="server" Text='<%# Eval("Construction_Area") %>' /></td>
                                    <td><asp:Label ID="lbl_Maintenance_status" runat="server" Text='<%# Eval("Maintenance_status") %>' /></td>
                                    <td><asp:Label ID="lbl_Building_Arabic_Condition" runat="server" Text='<%# Eval("Building_Arabic_Condition") %>' /></td>
                                    <td><asp:Label ID="lbl_Building_Arabic_Type" runat="server" Text='<%# Eval("Building_Arabic_Type") %>' /></td>
                                    <td><asp:Label ID="lbl_Building_Value" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Building_Value")))%>' /></td>
                                    <td><asp:LinkButton ForeColor="#0779c9" runat="server" CommandArgument='<%# Eval("Building_Id") %>' OnClick="Building_Details"> <i class="fa fa-list" style="font-size:18px;"></i> </asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                            </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                 <%-- *************************************************************************************** تفاصيل الأبنية *******************************************************************************************************--%>
                <asp:Label Font-Size="25px" ID="T_B_D"  runat="server" /> : 
                <asp:Repeater ID="Repeater1" runat="server" ClientIDMode="Static">
                    <ItemTemplate>
                        <asp:Label Font-Size="25px" ID="Bu_No"  runat="server" Text='<%# Eval("Building_Arabic_Name") %>'/>
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-lg-8 main_div">
                                    <div class="row">
                                        <div class="col-lg-4" style="text-align: center; color: white;">
                                            <div class="row" style="background-color: #015997; border-style: solid; border-color: black; border-radius: 10px">
                                                <div class="col-lg-12" style="padding-bottom: 60px;">
                                                    <asp:Label Font-Size="25px" ID="lbl_Titel_Building_NO" runat="server" Text="رقم البناء" />
                                                    <br />
                                                    <asp:Label Font-Size="80px" ID="lbl_Dtl_Building_NO" runat="server" Text='<%# Eval("Building_NO") %>' />
                                                </div>
                                            </div>
                                            <div class="row" style="background-color: #015997; border-style: solid; border-color: black; border-radius: 10px">
                                                <div class="col-lg-6" style="border-left-style: solid">
                                                    <asp:Label Font-Size="20px" ID="lbl_Titel_Water_meter" runat="server" Text="رقم المياه" />
                                                    <br />
                                                    <asp:Label Font-Size="30px" ID="lbl_Dtl_Water_meter" runat="server" Text='<%# Eval("Water_meter") %>' />
                                                </div>
                                                <div class="col-lg-6" style="border-right-style: solid">
                                                    <asp:Label Font-Size="20px" ID="lbl_Titel_electricity_meter" runat="server" Text="رقم الكهرباء" />
                                                    <br />
                                                    <asp:Label Font-Size="30px" ID="lbl_Dtl_electricity_meter" runat="server" Text='<%# Eval("electricity_meter") %>' />
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-lg-8">
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="Radios_Info">
                                                        <img src="Main_Image/home.png" />
                                                        <br />
                                                        <asp:Label CssClass="Titel" ID="lbl_Titel_Construction_Area" runat="server" Text="مساحة البناء" />
                                                        <br />
                                                        <asp:Label CssClass="Dtl" ID="lbl_Dtl_Construction_Area" runat="server" Text='<%# Eval("Construction_Area") %>' />
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="Radios_Info">
                                                        <img src="Main_Image/money-bag.png" />
                                                        <br />
                                                        <asp:Label CssClass="Titel" ID="lbl_Titel_Building_Value" runat="server" Text="قيمة البناء" />
                                                        <br />
                                                        <asp:Label CssClass="Dtl" ID="lbl_Dtl_Building_Value" runat="server" Text='<%# Eval("Building_Value") %>' />
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="Radios_Info">
                                                        <img src="Main_Image/check-list.png" />
                                                        <br />
                                                        <asp:Label CssClass="Titel" ID="lbl_Titel_Building_Arabic_Condition" runat="server" Text="حالة البناء" />
                                                        <br />
                                                        <asp:Label CssClass="Dtl" ID="lbl_Dtl_Building_Arabic_Condition" runat="server" Text='<%# Eval("Building_Arabic_Condition") %>' />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="Radios_Info">
                                                        <img src="Main_Image/type.png" />
                                                        <br />
                                                        <asp:Label CssClass="Titel" ID="lbl_Titel_Building_Arabic_Type" runat="server" Text="نوع البناء" />
                                                        <br />
                                                        <asp:Label CssClass="Dtl" ID="lbl_Dtl_Building_Arabic_Type" runat="server" Text='<%# Eval("Building_Arabic_Type") %>' />
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="Radios_Info">
                                                        <img src="Main_Image/maintenance.png" />
                                                        <br />
                                                        <asp:Label CssClass="Titel" ID="lbl_Titel_Maintenance_status" runat="server" Text="وضع الصيانة" />
                                                        <br />
                                                        <asp:Label CssClass="Dtl" ID="lbl_Dtl_Maintenance_status" runat="server" Text='<%# Eval("Maintenance_status") %>' />
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="Radios_Info">
                                                        <img src="Main_Image/building.png" />
                                                        <br />
                                                        <asp:Label CssClass="Titel" ID="lbl_Titel_Unit_Connt" runat="server" Text="عدد الوحدات" />
                                                        <br />
                                                        <asp:Label CssClass="Dtl" ID="lbl_Dtl_Unit_Connt" runat="server" Text='<%# Eval("Unit_Connt") %>' />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-4 main_div" style="border-style: solid">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="Radios_Att" style="width: 115px;">
                                                <img src="Main_Image/verification.png" />
                                                <br />
                                                <asp:Label CssClass="Titel" ID="lbl_Titel_Building_Permit_Path" runat="server" Text="رخصة البناء" />
                                                <br />
                                                <a runat="server" id="Link_Building_Permit_Path" style="font-size: 15px;" href='<%# Eval("Building_Permit_Path") %>'>
                                                    <i class="fa fa-file-pdf" style="font-size: 30px;"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="Radios_Att" style="width: 115px;">
                                                <img src="Main_Image/blueprint.png" />
                                                <br />
                                                <asp:Label CssClass="Titel" ID="lbl_Titel_certificate_of_completion_Path" runat="server" Text="شهادة إتمام" />
                                                <br />
                                                <a runat="server" id="Link_certificate_of_completion_Path" style="font-size: 15px;" href='<%# Eval("certificate_of_completion_Path") %>'>
                                                    <i class="fa fa-file-pdf" style="font-size: 30px;"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="Radios_Att" style="width: 115px;">
                                                <img src="Main_Image/statement.png" />
                                                <br />
                                                <asp:Label CssClass="Titel" ID="lbl_Titel_Map_path" runat="server" Text="خرائط" />
                                                <br />
                                                <a runat="server" id="Link_Map_path" style="font-size: 15px;" href='<%# Eval("Map_path") %>'>
                                                    <i class="fa fa-file-pdf" style="font-size: 30px;"></i>
                                                </a>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="Radios_Att" style="width: 115px;">
                                                <asp:Label CssClass="Titel" ID="lbl_Titel_Building_Photo" runat="server" Text="صورة البناء" />
                                                <br />
                                                <img id="myImg" src='<%# Eval("Building_Photo_Path") %>' alt="Snow" style="width: 100%; max-width: 300px; height: 75%;">
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="Radios_Att" style="width: 115px;">
                                                <asp:Label CssClass="Titel" ID="lbl_Titel_Entrance_Photo" runat="server" Text="صورة المدخل" />
                                                <br />
                                                <img id="myImg2" src='<%# Eval("Entrance_Photo_Path") %>' alt="Snow" style="width: 100%; max-width: 300px; height: 75%;">
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="Radios_Att" style="width: 115px;">
                                                <asp:Label CssClass="Titel" ID="lbl_Titel_Plano" runat="server" Text="مخطط" />
                                                <br />
                                                <img id="myImg3" src='<%# Eval("Plano_Path") %>' alt="Snow" style="width: 100%; max-width: 300px; height: 75%;">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <div class="row" id="scrooltohere">
                    <div class="col-lg-12 mb-4">
                        <!-- Simple Tables -->
                        <div class="table-responsive" id="Grid">

                            <asp:Repeater ID="eeeee" runat="server" ClientIDMode="Static">
                                <HeaderTemplate>
                                    <table cellspacing="0" style="width: 100%; font-size: 11px" class="datatable table table-striped table-bordered">
                                        <thead style="background-color: #d770ad; color: white">
                                            <th>#</th>
                                            <th>رقم الوحدة</th>
                                            <th>مساحة الوحدة</th>
                                            <th>رقم الطابق </th>
                                            <th>وضع الصيانة</th>
                                            <th>نوع الوحدة</th>
                                            <th>الحالة الإيجارية</th>
                                            <th>القيمة الإفتراضية</th>
                                            <th>تفاصيل الوحدة</th>
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
                                            <asp:Label ID="lbl_virtual_Value" runat="server" Text='<%# Eval("virtual_Value") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Unit_Arabic_Detail" runat="server" Text='<%# Eval("Unit_Arabic_Detail") %>' /></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                            </table>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div >
                                <asp:Button ID="btn_Close" CssClass="btn btn-danger" runat="server" Text="إغلاق" OnClick="btn_Close_Click" Visible="false" Height="43px" Width="263px" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </li>
    </ul>
    <%--******************************************************************************************************************************************************************--%>
     <!-- The Modal -->
    <div id="myModal" class="modal">
        <span class="close">&times;</span>
        <img class="modal-content" id="img01">
        <div id="caption"></div>
    </div>
    <script>
        // Get the modal
        var modal = document.getElementById("myModal");

        // Get the image and insert it inside the modal - use its "alt" text as a caption
        var img = document.getElementById("myImg");
        var modalImg = document.getElementById("img01");
        var captionText = document.getElementById("caption");
        img.onclick = function () {
            modal.style.display = "block";
            modalImg.src = this.src;
            captionText.innerHTML = this.alt;
        }

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }




        /********************************************************************/

        // Get the modal
        var modal = document.getElementById("myModal");

        // Get the image and insert it inside the modal - use its "alt" text as a caption
        var img = document.getElementById("myImg2");
        var modalImg = document.getElementById("img01");
        var captionText = document.getElementById("caption");
        img.onclick = function () {
            modal.style.display = "block";
            modalImg.src = this.src;
            captionText.innerHTML = this.alt;
        }

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }




        /********************************************************************/

        // Get the modal
        var modal = document.getElementById("myModal");

        // Get the image and insert it inside the modal - use its "alt" text as a caption
        var img = document.getElementById("myImg3");
        var modalImg = document.getElementById("img01");
        var captionText = document.getElementById("caption");
        img.onclick = function () {
            modal.style.display = "block";
            modalImg.src = this.src;
            captionText.innerHTML = this.alt;
        }

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }

    </script>



    <script type="text/javascript">
        $(document).ready(function () {
            var a = document.getElementById('<%= T_B_D.ClientID %>').textContent;
            if (a.length != 0) {
                $('html, body').animate({
                    scrollTop: $('#scrooltohere').offset().top
                }, 'slow');//w  w w.j a v a 2s.com 
            }
        });
    </script>
</asp:Content>
