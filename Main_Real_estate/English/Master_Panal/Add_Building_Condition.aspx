<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Add_Building_Condition.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Add_Building_Condition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid" id="container-wrapper" style="margin:auto; ">
         <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Building_Condition" runat="server" Text="إضافة حالة بناء جديدة"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Success_Add_New_Building_Condition" runat="server" ForeColor="#00FF40"></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-10">
                <div class="card mb-10" >
                     <div class="card-body">
                          
                              <div class="form-group">
                               <asp:Label ID="lbl_En_Building_Condition_Name" runat="server" Text="حالة البناء بالإنكليزية"></asp:Label>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_En_Building_Condition_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف الإنكليزية" ForeColor="Red"
                                ValidationExpression="[0-9 a-z A-Z]+"></asp:RegularExpressionValidator>  
                                <asp:TextBox ID="txt_En_Building_Condition_Name" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqFuild1" ControlToValidate="txt_En_Building_Condition_Name"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>

                              <div class="form-group">
                               <asp:Label ID="lbl_Ar_Building_Condition_Name" runat="server" Text="حالة البناء بالعربية"></asp:Label>
                              &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ar_Building_Condition_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                              <asp:TextBox ID="txt_Ar_Building_Condition_Name" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Ar_Building_Condition_Name"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>
                      </div>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btn_Add_Building_Condition" runat="server" Text="إضافة حالة بناء" CssClass="btn btn" Width="248px"  BackColor="#52a2da" ForeColor="White" OnClick="btn_Add_Building_Condition_Click"  />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Ownership_statu_List" runat="server" Text="العودة لقائمة حالات الأبنية" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Ownership_statu_List_Click"/>
    </div>
</asp:Content>
