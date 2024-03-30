<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Tenant_Datials.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Tenant_Datials" %>
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
                                        <asp:Label ID="lbl_Details_Tenant_Name" runat="server" Text=""></asp:Label>

                                    </h1>
                                    <div>
                                        <div class="row" style="border-style: solid; border-radius: 9px;">
                                            <div class="col-lg-6">
                                                <div class="card mb-2" style="padding: 30px">
                                                    <div class="row">
                                                        <table>
                                                            <tr >
                                                                <td style="padding-left: 70px; padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Tenant_En_Name" runat="server" Text="اسم المستأجر بالأنكليزية :" Font-Size="20px" ForeColor="#52a2da"></asp:Label>
                                                                </td>
                                                                <td  style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Tenant_En_Name" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td  style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Tenant_Ar_Name" runat="server" Text="اسم المستأجر بالعربية :" Font-Size="20px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Tenant_Ar_Name" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Tenant_tell" runat="server" Text="هاتف المستأجر :" Font-Size="20px" ForeColor="#52a2da"></asp:Label>

                                                                </td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Tenant_tell" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Tenant_Moblie" runat="server" Text="جوال المستاجر :" Font-Size="20px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Tenant_Moblie" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Tenant_Fax" runat="server" Text="فاكس المستأجر :" Font-Size="20px" ForeColor="#52a2da"></asp:Label>

                                                                </td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Tenant_Fax" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr >
                                                            <tr >
                                                                <td style="padding-left: 90px; padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Tenant_Email" runat="server" Text="البريد الإلكتروني  :" Font-Size="20px" ForeColor="#52a2da"></asp:Label>
                                                                </td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Tenant_Email" runat="server" Text="" Font-Size="20px"></asp:Label>
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
                                                                    <asp:Label ID="lbl_Title_Tenant_type" runat="server" Text="نوع المستأجر :" Font-Size="20px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Tenant_type" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>

                                                                <td style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Comp_Rep" runat="server" Text="ممثل الشركة :" Font-Size="20px" ForeColor="#52a2da"></asp:Label>
                                                                </td>

                                                                <td>
                                                                    <asp:Label ID="lbl_Dtl_Comp_Rep" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Tenant_Nationality_Or_business_records" runat="server"  Font-Size="20px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Tenant_Nationality_Or_business_records" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Tenant_Address" runat="server" Text="عنوان المستأجر :" Font-Size="20px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Tenant_Address" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_Nationality_Address_Or_P_O_Box" runat="server"  Font-Size="20px" ForeColor="#52a2da"></asp:Label>

                                                                </td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_Tenant_Nationality_Address_Or_P_O_Box" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr >

                                                             <tr>
                                                                <td style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_ID_NO" runat="server" Text="رقم البطاقة الشخصية" Font-Size="20px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_ID_NO" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>


                                                            <tr>
                                                                <td style="padding-bottom:20px; font-weight: bold">
                                                                    <asp:Label ID="lbl_Title_ID_Expiry" runat="server" Text="تاريخ أنهاء البطاقة الشخصية" Font-Size="20px" ForeColor="#52a2da"></asp:Label></td>
                                                                <td style="padding-bottom:20px;">
                                                                    <asp:Label ID="lbl_Dtl_ID_Expiry" runat="server" Text="" Font-Size="20px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div><br />

                                        <h4><asp:Label ID="Label11" runat="server" Text=" الملفات الشخصية للمستأجر"></asp:Label></h4>






                                        <div class="row" style="border-style: solid; border-radius: 9px;">
                                            <div class="col-lg-6">
                                                <div class="card mb-2" style="padding: 30px; height: 120px">

                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <asp:Label ID="lbl_Titel_Tenant_Photo" runat="server" Text="بطافة  المستأجر :" Font-Size="20px" ForeColor="#52a2da"></asp:Label>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <a runat="server" id="Link_Tenants_QId" style="font-size: 15px;">
                                                                <i class="fa fa-file-pdf" style="font-size: 40px;"></i>
                                                                <asp:Label ID="lbl_Link_Tenants_QId" runat="server" Text=""></asp:Label>
                                                            </a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-6">
                                                <div class="card mb-2" style="padding: 30px; height: 120px">

                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <asp:Label ID="lbl_Titel_PassPort" runat="server" Text="جواز سفر المستأجر :" Font-Size="20px" ForeColor="#52a2da"></asp:Label>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <a runat="server" id="Link_PassPort" style="font-size: 15px;">
                                                                <i class="fa fa-file-pdf" style="font-size: 40px;"></i>
                                                                <asp:Label ID="lbl_Link_PassPort" runat="server" Text=""></asp:Label>
                                                            </a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-3">
                                            <asp:Button ID="btn_Back_To_Tenant_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة المستأجرين" ValidationGroup="x" OnClick="btn_Back_To_Tenant_List_Click"  />
                                            </div>
                                            <div class="col-lg-1">
                                                <asp:LinkButton Id="Delete_Tenant"  runat="server" CommandArgument='<%# Eval("Tenants_ID") %>'
                                                OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');" OnClick="Delete_Tenant_Click" >
                                                <i class="fa fa-trash" style="font-size:25px;"></i></asp:LinkButton>
                                            </div>

                                             <div class="col-lg-1">
                                                <asp:LinkButton Id="Edit_Tenant"  runat="server" CommandArgument='<%# Eval("Tenants_ID") %>' 
                                                OnClick="Edit_Tenant_Click" > <i class="fa fa-pencil" style="font-size:25px;"></i> </asp:LinkButton>
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
    <script type="text/javascript">function SetTarget() {document.forms[0].target = "_blank";}
    </script>
</asp:Content>
