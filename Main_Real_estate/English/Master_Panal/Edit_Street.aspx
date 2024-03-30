<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Edit_Street.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Edit_Street" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" id="container-wrapper" style="margin:auto; ">
         <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Edit_Street" runat="server" Text="Edit Street :"></asp:Label>&nbsp;
                <asp:Label ID="lbl_titel_Name_Edit_Street" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Success_Edit_Street" runat="server" ForeColor="#00FF40"></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-10">
                <div class="card mb-10" >
                     <div class="card-body">
                          
                              <div class="form-group">
                               <asp:Label ID="lbl_En_Street_Name" runat="server" Text="Street Name (En)"></asp:Label>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_En_Street_Name" 
                                EnableClientScript="True" ErrorMessage="Only English Latter Allowed" ForeColor="Red"
                                ValidationExpression="[a-z A-Z]+"></asp:RegularExpressionValidator>  
                                <asp:TextBox ID="txt_En_Street_Name" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqFuild1" ControlToValidate="txt_En_Street_Name"  
                                runat="server" ErrorMessage="* Required field !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>

                              <div class="form-group">
                               <asp:Label ID="lbl_Ar_Street_Name" runat="server" Text="Street Name (Ar)"></asp:Label>
                              &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ar_Street_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>
                              <asp:TextBox ID="txt_Ar_Street_Name" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Ar_Street_Name"  
                                runat="server" ErrorMessage="* Required field !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>

                              <div class="form-group">
                               <asp:Label ID="lbl_Street_Number" runat="server" Text="Street Number"></asp:Label>&nbsp;
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Street_Number" 
                                EnableClientScript="True" ErrorMessage="Only Number Allowed" ForeColor="Red"
                                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Street_Number" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="reqFuild3" ControlToValidate="txt_Street_Number"
                               runat="server" ErrorMessage="* Required field !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>

                      </div>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btn_Add_Street" runat="server" Text="Edit Street" CssClass="btn btn-danger mb-1" Width="248px" OnClick="Button1_Click"   />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Street_List" runat="server" Text="Back To Street List" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Street_List_Click"/>
    </div>
</asp:Content>
