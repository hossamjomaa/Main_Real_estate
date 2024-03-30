<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Add_company_rep.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Add_company_rep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" />


    <div class="container-fluid" id="container-wrapper" style="margin: auto;">
        <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Com_rep" runat="server" Text="إضافة ممثل شركة جديد"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Success_Add_New_Com_rep" runat="server" ForeColor="#00FF40"></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-10">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Com_rep_Name" runat="server" Text="الإسم بالإنكليزية"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_En_Com_rep_Name"
                                        EnableClientScript="True" ErrorMessage="!!!  فقط أحرف الإنكليزية" ForeColor="Red"
                                        ValidationExpression="[a-z A-Z0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_En_Com_rep_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqFuild1" ControlToValidate="txt_En_Com_rep_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Com_rep_Name" runat="server" Text="الاسم بالعربية"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ar_Com_rep_Name"
                                        EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                        ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ar_Com_rep_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Ar_Com_rep_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Nationality" runat="server" Text="جنسية"></asp:Label>
                                    <asp:DropDownList ID="Nationality_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="nationality_RequiredFieldValidator" ControlToValidate="Nationality_DropDownList"
                                        InitialValue="إختر جنسية الممثل ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                             <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Company_Name" runat="server" Text="الشركة التي يمثلها"></asp:Label>
                                    <asp:DropDownList ID="Company_Name_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Company_Name_RequiredFieldValidator" ControlToValidate="Company_Name_DropDownList"
                                        InitialValue="إختر الشركة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <%--*************************************************************************************************************************--%>

                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Com_Rep_Qid_No" runat="server" Text="رقم البطاقة الشخصية"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Com_Rep_Qid_No"
                                        EnableClientScript="True" ErrorMessage="أرقام فقط !!" ForeColor="Red"
                                        ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Com_Rep_Qid_No" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_Com_Rep_Qid_No"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Com_Rep_Qid_File" runat="server" Text="تحميل صورة البطاقة الشخصية"></asp:Label>
                                    <asp:FileUpload ID="Com_Rep_Qid_File_FileUpload" runat="server" CssClass="form-control" />
                                </div>
                            </div>

                           <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Com_Rep_Mobile" runat="server" Text="رقم الجوال"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt_Com_Rep_Mobile"
                                        EnableClientScript="True" ErrorMessage="أرقام فقط !!" ForeColor="Red"
                                        ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Com_Rep_Mobile" runat="server" CssClass="form-control"></asp:TextBox>
                                    
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Com_Rep_Email" runat="server" Text="البريد الإلكتروني"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_Com_Rep_Email"
                                        EnableClientScript="True" ErrorMessage="بريد إلكتروني غير صالح" ForeColor="Red"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Com_Rep_Email" runat="server" CssClass="form-control"></asp:TextBox>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btn_Add_Com_rep" runat="server" Text="إضافة ممثل شركة" CssClass="btn btn" BackColor="#52a2da" ForeColor="White" Width="248px" OnClick="btn_Add_Com_rep_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Com_rep_List" runat="server" Text="العودة إلى قائمة ممثلين الشركات " ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Com_rep_List_Click" />
    </div>
    
     <script>$('#<%=Nationality_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Company_Name_DropDownList.ClientID%>').chosen();</script>
</asp:Content>
