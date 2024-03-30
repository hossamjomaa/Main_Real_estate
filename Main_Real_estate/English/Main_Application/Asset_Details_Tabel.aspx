<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Asset_Details_Tabel.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Asset_Details_Tabel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-login" style="padding-top: 70px">
        <div class="row justify-content-center" style="margin-top: -129px;">
            <div class="col-xl-12 col-lg-12 col-md-9">

                <div class="card shadow-sm my-5">
                    <div class="card-body p-0">
                        <div class="row" style="top: -14px; " >
                            <div class="col-lg-12">
                                <div class="login-form">
                                    <h1 class="h4 text-gray-900 mb-4" style="margin-left: 40%">
                                        &nbsp;تفاصيل :
                                        <asp:Label ID="lbl_Details_Asset_Name" runat="server" Text=""></asp:Label> 

                                    </h1>
                                    <div>
                                        <div class="row" style="border-style: solid; border-radius: 9px;">
                                            <div class="col-lg-6">
                                                <div class="card mb-2" style="padding: 30px">
                                                    <div class="row">
                                                        <table>
                                                            <tr >
                                                                <td style="padding-left: 70px; padding-bottom:20px">
                                                                    <asp:Label ID="lbl_Title_Name_EN" runat="server" Text="إسم الاصل بالانكليزية :" Font-Size="25px" ForeColor="#52a2da"></asp:Label>
                                                                </td>
                                                                <td  style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Name_EN" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td  style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Title_Name_Ar" runat="server" Text="اسم الاصل بالعربية :" Font-Size="25px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Name_Ar" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Title_Purchase_Date" runat="server" Text="تاريخ الشراء  :" Font-Size="25px" ForeColor="#52a2da"></asp:Label>

                                                                </td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Purchase_Date" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Title_Asset_Value" runat="server" Text="قيمة الأصل  :" Font-Size="25px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Asset_Value" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Title_Asset_Quantity" runat="server" Text="كمية الأصل  :" Font-Size="25px" ForeColor="#52a2da"></asp:Label>

                                                                </td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Asset_Quantity" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                </td>
                                                            </tr >
                                                            <tr >
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Title_Asset_Warranty" runat="server" Text="ضمان الأصل :" Font-Size="25px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Asset_Warranty" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >
                                                                    <asp:Label ID="lbl_Title_Asset_Description" runat="server" Text="وصف الأصل  :" Font-Size="25px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td >
                                                                    <asp:Label ID="lbl_Dtl_Asset_Description" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>



                                            <div class="col-lg-6">
                                                <div class="card mb-2" style="padding: 30px">
                                                    <div class="row">
                                                        <table>
                                                            <tr >
                                                                <td style="padding-left: 70px; padding-bottom:20px">
                                                                    <asp:Label ID="lbl_Title_Asset_Condition" runat="server" Text="حالة الأصل :" Font-Size="25px" ForeColor="#52a2da"></asp:Label>
                                                                </td>
                                                                <td  style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Asset_Condition" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td  style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Title_Asset_Type" runat="server" Text="نوع الأصل :" Font-Size="25px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Asset_Type" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Title_Asset_Location" runat="server" Text="مكان الأصل :" Font-Size="25px" ForeColor="#52a2da"></asp:Label>

                                                                </td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Asset_Location" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Title_Asset_Inventory" runat="server" Text="المخزون :" Font-Size="25px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Asset_Inventory" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Title_Asset_Vendor" runat="server" Text="البائع :" Font-Size="25px" ForeColor="#52a2da"></asp:Label>

                                                                </td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Asset_Vendor" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                </td>
                                                            </tr >
                                                            <tr >
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Title_Asset_Building" runat="server" Text="اسم البناء :" Font-Size="25px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Asset_Building" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >
                                                                    <asp:Label ID="lbl_Title_Asset_Unit" runat="server" Text="الوحدة :" Font-Size="25px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td >
                                                                    <asp:Label ID="lbl_Dtl_Asset_Unit" runat="server" Text="" Font-Size="25px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>



                                        </div><br /><br />
                                        <asp:Button ID="btn_Back_To_Asset_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة إلى قائمة الاصول" ValidationGroup="x" OnClick="btn_Back_To_Asset_List_Click"  />
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
