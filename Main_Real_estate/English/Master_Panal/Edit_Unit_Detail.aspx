﻿<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Edit_Unit_Detail.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Edit_Unit_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid" id="container-wrapper" style="margin:auto; ">
         <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Edit_New_Unit_Detail" runat="server" Text="تعديل تفصيل الوحدة :"></asp:Label>
                <asp:Label ID="lbl_Name_Of_Unit_Detail" runat="server" Text=""></asp:Label>&nbsp;
                <asp:Label ID="lbl_Success_Edit_New_Unit_Detail" runat="server" ForeColor="#00FF40"></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-10">
                <div class="card mb-10" >
                     <div class="card-body">
                          
                              <div class="form-group">
                               <asp:Label ID="lbl_En_Unit_Detail_Name" runat="server" Text="تفاصيل الوحدة بالإنكليزية"></asp:Label>
                                <%--&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_En_Unit_Detail_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف الإنكليزية" ForeColor="Red"
                                ValidationExpression="[a-z A-Z]+"></asp:RegularExpressionValidator>  --%>
                                <asp:TextBox ID="txt_En_Unit_Detail_Name" runat="server" CssClass="form-control" ></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="reqFuild1" ControlToValidate="txt_En_Unit_Detail_Name"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>--%>
                             </div>

                              <div class="form-group">
                               <asp:Label ID="lbl_Ar_Unit_Detail_Name" runat="server" Text="تفاصيل الوحدة بالعربية"></asp:Label>
                              <%--&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ar_Unit_Detail_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>--%>
                              <asp:TextBox ID="txt_Ar_Unit_Detail_Name" runat="server" CssClass="form-control"></asp:TextBox>
                              <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Ar_Unit_Detail_Name"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>--%>
                             </div>
                      </div>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btn_Edit_Unit_Detail" runat="server" Text="Uحفظ التغيرات" CssClass="btn btn" BackColor="#52a2da" ForeColor="White" Width="248px" OnClick="btn_Edit_Unit_Detail_Click"    />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Unit_Detail_List" runat="server" Text="العودة لقائمة تفاصيل الوحدات" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Unit_Detail_List_Click"/>
    </div>
</asp:Content>
