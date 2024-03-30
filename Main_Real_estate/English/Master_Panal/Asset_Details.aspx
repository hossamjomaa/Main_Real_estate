<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Asset_Details.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Asset_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                    <div class="row">
                                        <div class="col-lg-6" style="border-style: solid; text-align: center; padding-top: 10px; font-size: 25px; font-weight: bold">
                                            <div class="form-group">
                                                قسم الجرد و المخازن و الاصول الغير ثابتة 
                                            </div>
                                        </div>
                                        <div class="col-lg-6" style="border-style: solid; text-align: center; padding-top: 10px; font-size: 25px; font-weight: bold">
                                            <div class="form-group">
                                                شركة المنارة للصيانة والتجارة
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row">
                                        <div class="col-lg-12" style="border-style: solid; text-align: center; padding-top: 10px; font-size: 25px; font-weight: bold">
                                            <div class="form-group">
                                                <span style="color: red">تفاصيل الأصل ذو الرقم التسلسلي</span><br />
                                                <asp:Label ID="lbl_Serial_Number" Text="0111111" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <spa style="font-weight: bold">الاسم بالعربية:</spa>
                                                &nbsp;&nbsp;<asp:Label ID="lbl_Assets_Arabic_Name" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">الاسم بالإنكليزية: :</span> &nbsp;&nbsp;<asp:Label ID="lbl_Assets_English_Name" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">قيمة الأصل :</span>&nbsp;&nbsp;<asp:Label ID="lbl_Assets_Value" runat="server"></asp:Label>
                                                &nbsp;&nbsp;
                                                ريال قطري
                                            </div>
                                        </div>
                                        <div class="col-lg-12" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">وصف الأصل :</span>&nbsp;&nbsp;<asp:Label ID="lbl_Description" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-12" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">طريقة التملك : </span>&nbsp;&nbsp;<asp:Label ID="lbl_How_To_Get" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg" style="font-size: 20px; padding-top: 10px;" id="Contractor_Div" runat="server">
                                            <div class="form-group">
                                                <span style="font-weight: bold">اسم المقاول : </span>&nbsp;&nbsp;<asp:Label ID="lbl_Contractor" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg" style="font-size: 20px; padding-top: 10px;" id="Buyer_Div" runat="server">
                                            <div class="form-group">
                                                <span style="font-weight: bold">مسؤول الشراء : </span>&nbsp;&nbsp;<asp:Label ID="lbl_Buyer" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg" style="font-size: 20px; padding-top: 10px;" id="Vendor_Div" runat="server">
                                            <div class="form-group">
                                                <span style="font-weight: bold">اسم المورد:&nbsp;&nbsp;</span><asp:Label ID="lbl_Vendor_Arabic_Type" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg" style="font-size: 20px; padding-top: 10px;" id="Contractor_Waranty_Div" runat="server">
                                            <div class="form-group">
                                                <span style="font-weight: bold">فترة ضمان المقاول:&nbsp;&nbsp;</span><asp:Label ID="lbl_Contractor_Waranty_Period" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg" style="font-size: 20px; padding-top: 10px;" id="Contractor_Waranty_Remaining_Days_Div" runat="server">
                                            <div class="form-group">
                                                <span style="font-weight: bold">الأيام المتبقية :&nbsp;&nbsp;</span><asp:Label ID="lbl_Contractor_Waranty_Remaining_Days" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">تاريخ الشراء :</span>&nbsp;&nbsp;<asp:Label ID="lbl_Purchase_Date" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">حالة الأصل :</span>&nbsp;&nbsp;<asp:Label ID="lbl_Asset_Arabic_Condition" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">المكان العام للأصل:&nbsp;&nbsp;</span><asp:Label ID="lbl_Main_Place" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-12" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">مكان الأصل بالتفصيل :</span>&nbsp;&nbsp;
                                                <asp:Label ID="lbl_Location_Details" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-3" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">فترة ضمان الموّرد  :</span>&nbsp;&nbsp;
                                                <asp:Label ID="lbl_Waranty_Period" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-3" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">تاريخ بدء ضمان الموّرد  :</span>&nbsp;&nbsp;
                                                <asp:Label ID="lbl_Waranty_Start_Date" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-3" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">تاريخ إنتهاء ضمان الموّرد  :</span>&nbsp;&nbsp;
                                                <asp:Label ID="lbl_Waranty_End_Date" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-3" style="font-size: 20px; padding-top: 10px;" >
                                            <div class="form-group">
                                                <span style="font-weight: bold">الأيام المتبقية :&nbsp;&nbsp;</span><asp:Label ID="lbl_Waranty_Remaining_Days" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-12" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">صورة عن شهادة الضمان :</span>&nbsp;&nbsp;
                                                <a runat="server" id="Link_Waranty_Certificate_Path" style="font-size: 15px;">
                                                    <i class="fa fa-file-pdf" style="font-size: 40px;"></i>
                                                    <asp:Label ID="lbl_Link_Waranty_Certificate" runat="server" Text=""></asp:Label>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" >
                                    <div class="col-lg-12" >
                                        <asp:Button ID="btn_Back_To_Asset_List" runat="server" Text="العودة لقائمة الاصول" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Asset_List_Click" />
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
