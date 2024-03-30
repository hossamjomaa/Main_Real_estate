<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Add_Contractor.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Add_Contractor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" id="container-wrapper">
        <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_contractor" runat="server" Text="إضافة مقاول جديد "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Label ID="lbl_Success_Add_New_contractor" runat="server" ForeColor="#00FF40"></asp:Label>
            </h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_contractor_Name" runat="server" Text="اسم المقاول بالانكليزية"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="En_contractor_Name_RegularExpressionValidator" runat="server" ControlToValidate="txt_En_contractor_Name"
                                        EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف الإنكليزية" ForeColor="Red"
                                        ValidationExpression="[a-z A-Z0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_En_contractor_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_contractor_Name" runat="server" Text="اسم المقاول بالعربية"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="Ar_contractor_Name_RegularExpressionValidator" runat="server" ControlToValidate="txt_Ar_contractor_Name"
                                        EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                        ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ar_contractor_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_contractor_tell" runat="server" Text="هاتف المقاول"></asp:Label>&nbsp;
                                <asp:RegularExpressionValidator ID="contractor_tell_RegularExpressionValidator" runat="server" ControlToValidate="txt_contractor_tell"
                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_contractor_tell" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Company_Name" runat="server" Text="اسم الشركة"></asp:Label>
                                    <asp:TextBox ID="txt_Company_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-8">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Company_Address" runat="server" Text="عنوان الشركة"></asp:Label>
                                    <asp:TextBox ID="txt_Company_Address" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br /><br />
                        <div class="row">
                            <div class="col-lg-3">
                                <asp:Button ID="btn_Add_contractor" runat="server" Text="إضافة مقاول" CssClass="btn btn" BackColor="#52a2da" ForeColor="White"   Width="248px" OnClick="btn_Add_contractor_Click"  />
                            </div>
                            <div class="col-lg-3">
                                <asp:Button ID="btn_Back_To_contractor_List" runat="server" Text="العودة لقائمة المقاولين" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_contractor_List_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
