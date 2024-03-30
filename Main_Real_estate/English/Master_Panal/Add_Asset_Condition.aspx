<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Add_Asset_Condition.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Add_Asset_Condition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" id="container-wrapper" style="margin:auto; ">
         <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Asset_Condition" runat="server" Text="إضافة أصل جديد"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Success_Add_New_Asset_Condition" runat="server" ForeColor="#00FF40"></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-10">
                <div class="card mb-10" >
                     <div class="card-body">
                          
                              <div class="form-group">
                               <asp:Label ID="lbl_En_Asset_Condition_Name" runat="server" Text="حالة الأصل بالأنكليزية"></asp:Label>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_En_Asset_Condition_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف الإنكليزية" ForeColor="Red"
                                ValidationExpression="[a-z A-Z0-9]+"></asp:RegularExpressionValidator>  
                                <asp:TextBox ID="txt_En_Asset_Condition_Name" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqFuild1" ControlToValidate="txt_En_Asset_Condition_Name"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>

                              <div class="form-group">
                               <asp:Label ID="lbl_Ar_Asset_Condition_Name" runat="server" Text="حالة الاصل بالعربية"></asp:Label>
                              &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ar_Asset_Condition_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                              <asp:TextBox ID="txt_Ar_Asset_Condition_Name" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Ar_Asset_Condition_Name"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>
                      </div>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btn_Add_Asset_Condition" runat="server" Text="إضافة أصل جديد" CssClass="btn btn" BackColor="#52a2da" ForeColor="White" Width="248px" OnClick="btn_Add_Asset_Condition_Click"   />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Asset_Condition_List" runat="server" Text="العودة لقائمة الأصلول" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Asset_List_Click"/>
    </div>
</asp:Content>
