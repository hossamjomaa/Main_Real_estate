<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Edit_Transaction_Type.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Edit_Transaction_Type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid" id="container-wrapper" style="margin:auto; ">
         <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Edit_New_Transaction_Type" runat="server" Text="Edit Transaction Type :"></asp:Label>
                <asp:Label ID="lbl_Name_Of_Transaction_Type" runat="server" Text=""></asp:Label>&nbsp;
                <asp:Label ID="lbl_Success_Edit_New_Transaction_Type" runat="server" ForeColor="#00FF40"></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-10">
                <div class="card mb-10" >
                     <div class="card-body">
                          
                              <div class="form-group">
                               <asp:Label ID="lbl_En_Transaction_Type_Name" runat="server" Text="Transaction Type Name (En)"></asp:Label>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_En_Transaction_Type_Name" 
                                EnableClientScript="True" ErrorMessage="Only English Latter Allowed" ForeColor="Red"
                                ValidationExpression="[a-z A-Z]+"></asp:RegularExpressionValidator>  
                                <asp:TextBox ID="txt_En_Transaction_Type_Name" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqFuild1" ControlToValidate="txt_En_Transaction_Type_Name"  
                                runat="server" ErrorMessage="* Required field !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>

                              <div class="form-group">
                               <asp:Label ID="lbl_Ar_Transaction_Type_Name" runat="server" Text="Transaction Type Name (Ar)"></asp:Label>
                              &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ar_Transaction_Type_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>
                              <asp:TextBox ID="txt_Ar_Transaction_Type_Name" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Ar_Transaction_Type_Name"  
                                runat="server" ErrorMessage="* Required field !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>
                      </div>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btn_Edit_Transaction_Type" runat="server" Text="Update Transaction Type" CssClass="btn btn" BackColor="#52a2da" ForeColor="White" Width="248px" OnClick="btn_Edit_Transaction_Type_Click"  />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Transaction_Type_List" runat="server" Text="Back To Transaction Type List" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Transaction_Type_List_Click"/>
    </div>
</asp:Content>
