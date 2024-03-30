<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Com_Rep_Details.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Com_Rep_Details" %>
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
                                        <asp:Label ID="lbl_Details_Com_Rep_Name" runat="server" Text=""></asp:Label>

                                    </h1>
                                    <div>
                                        <div class="row" style="border-style: solid; border-radius: 9px;">
                                            <div class="col-lg-6">
                                                <div class="card mb-2" style="padding: 30px">
                                                    <div class="row">
                                                        <table>
                                                            
                                                            <tr>
                                                                <td  style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Com_Rep_Ar_Name" runat="server" Text="اسم الممثل بالعربية :" Font-Size="20px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Com_Rep_Ar_Name" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td  style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Com_Rep_Ar_Mobile" runat="server" Text="جوال الممثل  :" Font-Size="20px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Com_Rep_Ar_Mobile" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr >
                                                                <td style="padding-left: 70px; padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Company_Name" runat="server" Text="ممثل للشركة  :" Font-Size="20px" ForeColor="#52a2da"></asp:Label>
                                                                </td>
                                                                <td  style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Company_Name" runat="server" Text="" Font-Size="20px"></asp:Label>
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
                                                            
                                                            <tr>
                                                                <td style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Com_Rep_Qid_No" runat="server" Text="رقم البطاقة الشخصية :" Font-Size="20px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Com_Rep_Qid_No" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                            

                                                            <tr>
                                                                <td style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Com_Rep_Nationality" runat="server" Text="جنسية الممثل :" Font-Size="20px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Com_Rep_Nationality" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>

                                                             <tr>
                                                                <td style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Com_Rep_Email" runat="server" Text="البريد الإلكتروني" Font-Size="20px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Com_Rep_Email" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>


                                                            
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div><br />

                                        <h4><asp:Label ID="Label11" runat="server" Text=" الملفات الشخصية للممثل"></asp:Label></h4>






                                        <div class="row" style="border-style: solid; border-radius: 9px;">
                                            <div class="col-lg-6">
                                                <div class="card mb-2" style="padding: 30px; height: 120px">

                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <asp:Label ID="lbl_Titel_Com_Rep_Photo" runat="server" Text="بطافة  الممثل :" Font-Size="20px" ForeColor="#52a2da"></asp:Label>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <a runat="server" id="Link_Com_Reps_QId" style="font-size: 15px;">
                                                                <i class="fa fa-file-pdf" style="font-size: 40px;"></i>
                                                                <asp:Label ID="lbl_Link_Com_Reps_QId" runat="server" Text=""></asp:Label>
                                                            </a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="btn_Back_To_Com_Rep_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الممثلين" ValidationGroup="x" OnClick="btn_Back_To_Com_Rep_List_Click"  />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
         </div>
    <script type="text/javascript">function SetTarget() {document.forms[0].target = "_blank";}
    </script>
</asp:Content>
