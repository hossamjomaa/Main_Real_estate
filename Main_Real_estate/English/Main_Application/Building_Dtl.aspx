<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Building_Dtl.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Building_Dtl" %>
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
     <%--*************************************************************************************************************************************************************************************************************--%>
    <div class="container-fluid">
        <div class="row">
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
        </div>
    </div>
    <br /><asp:Button ID="btn_Back_To_Building_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الأبنية" ValidationGroup="x" OnClientClick="JavaScript:window.history.back(1); return false;" /><br />
    <%--**************************************************************************************  قائمة الوحدات ******************************************************************************************--%>
    <ul style="background-color: #efefef; min-height: 0px; width: 100%" class="navbar-nav sidebar sidebar-light accordion" id="accordionSidebar">
        <li class="nav-item" style="padding-bottom: 10px;" runat="server" id="Ownership_Div">
            <a class="nav-link" href="#" data-toggle="collapse" data-target="#M_Ownership" aria-expanded="true"
                aria-controls="M_Ownership" style="width: 270px;">
                <i class="fa fa-plus" style="font-size: 25px; font-weight: bold"></i>
                <span style="font-size: 18px;">قائمة  الوحدات</span>
            </a>
            <div id="M_Ownership" class="collapse show" aria-labelledby="headingForm" data-parent="#accordionSidebar">
                <div class="row" >
                    <div class="col-lg-12 mb-4">
                        <!-- Simple Tables -->
                        <div class="card">
                            <div class="table-responsive">
                                <asp:Repeater ID="eeeee" runat="server" ClientIDMode="Static">
                                    <HeaderTemplate>
                                        <table cellspacing="0" style="width: 100%; font-size: 11px" class="datatable table table-striped table-bordered Buidling_In_Ownership">
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
                                                <th></th>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                            <td><asp:Label ID="lbl_Unit_number" runat="server" Text='<%# Eval("Unit_Number") %>' /></td>
                                            <td><asp:Label ID="lbl_Unit_Space" runat="server" Text='<%# Eval("Unit_Space") %>' /></td>
                                            <td> <asp:Label ID="lbl_Floor_Number" runat="server" Text='<%# Eval("Floor_Number") %>' /></td>
                                            <td> <asp:Label ID="lbl_current_situation" runat="server" Text='<%# Eval("current_situation") %>' /></td>
                                            <td><asp:Label ID="lbl_Unit_Arabic_Type" runat="server" Text='<%# Eval("Unit_Arabic_Type") %>' /></td>
                                            <td><asp:Label ID="lbl_Unit_Arabic_Condition" runat="server" Text='<%# Eval("Unit_Arabic_Condition") %>' /></td>
                                            <td><asp:Label ID="lbl_virtual_Value" runat="server" Text='<%# Eval("virtual_Value") %>' /></td>
                                            <td><asp:Label ID="lbl_Unit_Arabic_Detail" runat="server" Text='<%# Eval("Unit_Arabic_Detail") %>' /></td>
                                            <td><asp:LinkButton ForeColor="Blue" runat="server" CommandArgument='<%# Eval("Unit_Id") %>' OnClick="Details_Unit" > <i class="fa fa-list" style="font-size:18px;"></i> </asp:LinkButton></td>
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
                <%--**************************************************************************************  تفاصيل الوحدات ******************************************************************************************--%>
                <div class="container-fluid" id="scrooltohere">
                    <asp:Label Font-Size="25px" ID="T_U_D"  runat="server" />
                    <asp:Repeater ID="Unit_Details" runat="server" ClientIDMode="Static">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Details_Unit_Name" Font-Size="25px" runat="server" Text= '<%# Eval("Unit_Number") %>'/>
                            <div class="row">
                                <div class="col-lg-12 main_div">
                                    <div class="row" style="text-align: center; color: white">
                                        <div class="col-lg-4">
                                            <div class="row" style="background-color: #015997; border-style: solid; border-radius: 10px; border-color: black; padding: 10px">
                                                <div class="col-lg-4" style="border-left-style: solid; border-color: white">
                                                    <asp:Label ID="lbl_Titel_Floor_Number" runat="server" Font-Size="23px" Text="رقم الطابق" /><br />
                                                    <asp:Label ID="lbl_Dtl_Floor_Number" runat="server" Font-Size="50px" Text='<%# Eval("Floor_Number") %>' />
                                                </div>
                                                <div class="col-lg-8">
                                                    <asp:Label ID="lbl_Titel_Unit_Number" runat="server" Font-Size="25px" Text="رقم الوحدة" /><br />
                                                    <asp:Label ID="lbl_Dtl_Unit_Number" runat="server" Font-Size="70px" Text='<%# Eval("Unit_Number") %>' />
                                                </div>
                                            </div>
                                            <div class="row" style="background-color: #015997; border-style: solid; border-radius: 10px; border-color: black">
                                                <div class="col-lg-4" style="border-left-style: solid; border-color: white">
                                                    <asp:Label ID="lbl_Titel_Water_Number" runat="server" Text=" الماء" /><br />
                                                    <asp:Label ID="lbl_Dtl_Water_Number" runat="server" Text='<%# Eval("Water_Number") %>' />
                                                </div>
                                                <div class="col-lg-4" style="border-left-style: solid; border-color: white">
                                                    <asp:Label ID="lbl_Titel_Electrcity_Number" runat="server" Text=" الكهرباء" /><br />
                                                    <asp:Label ID="Labellbl_Dtl_Electrcity_Number12" runat="server" Text='<%# Eval("Electricityt_Number") %>' />
                                                </div>
                                                <div class="col-lg-4">
                                                    <asp:Label ID="lbl_Titel_Oreedo_Number" runat="server" Text=" أوريدو" /><br />
                                                    <asp:Label ID="lbl_Dtl_Oreedo_Number" runat="server" Text='<%# Eval("Oreedo_Number") %>' />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <div class="Radios_Att" style="width: 190px;height:215px">
                                                        <asp:Label CssClass="Titel" ID="lbl_Image_One_Path" runat="server" Text="مخطط" />
                                                        <br />
                                                        <img id="myImg4" src='<%# Eval("Image_One_Path") %>' alt="Snow" style="width: 100%; max-width: 300px; height: 75%;">
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="Radios_Att" style="width: 190px;height:215px">
                                                        <asp:Label CssClass="Titel" ID="lbl_Image_Two_Path" runat="server" Text="مخطط" />
                                                        <br />
                                                        <img id="myImg5" src='<%# Eval("Image_Two_Path") %>' alt="Snow" style="width: 100%; max-width: 300px; height: 75%;">
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="Radios_Att" style="width: 190px;height:215px">
                                                        <asp:Label CssClass="Titel" ID="lbl_Image_Three_Path" runat="server" Text="مخطط" />
                                                        <br />
                                                        <img id="myImg6" src='<%# Eval("Image_Three_Path") %>' alt="Snow" style="width: 100%; max-width: 300px; height: 75%;">
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="Radios_Att" style="width: 190px; height:215px">
                                                        <asp:Label CssClass="Titel" ID="lbl_Image_Four_Path" runat="server" Text="مخطط" />
                                                        <br />
                                                        <img id="myImg7" src='<%# Eval("Image_Four_Path") %>' alt="Snow" style="width: 100%; max-width: 300px; height: 75%;">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <br />
                <div >
                    <asp:Button ID="btn_Close" CssClass="btn btn-danger" runat="server" Text="إغلاق" OnClick="btn_Close_Click" Visible="false" Height="43px" Width="263px" />
                </div>
            </div>
        </li>
    </ul>
    
    <%--*************************************************************************************************************************************************************************************************************--%>

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
        /********************************************************************/
        // Get the modal
        var modal = document.getElementById("myModal");

        // Get the image and insert it inside the modal - use its "alt" text as a caption
        var img = document.getElementById("myImg4");
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
        var img = document.getElementById("myImg5");
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
        var img = document.getElementById("myImg6");
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
        var img = document.getElementById("myImg7");
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
            var a = document.getElementById('<%= T_U_D.ClientID %>').textContent;
            if (a.length != 0) {
                $('html, body').animate({
                    scrollTop: $('#scrooltohere').offset().top
                }, 'slow');//w  w w.j a v a 2s.com 
            }
        });
    </script>
</asp:Content>
