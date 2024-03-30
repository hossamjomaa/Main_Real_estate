<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Unit_DTL.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Unit_DTL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <br /><asp:Button ID="btn_Back_To_Building_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الوحدات" ValidationGroup="x" OnClientClick="JavaScript:window.history.back(1); return false;" /><br />
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
</asp:Content>
