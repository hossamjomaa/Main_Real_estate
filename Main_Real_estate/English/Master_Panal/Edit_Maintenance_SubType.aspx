<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Edit_Maintenance_SubType.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Edit_Maintenance_SubType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" />


     <div class="container-fluid" id="container-wrapper" style="margin:auto; ">
         <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Edit_New_Maintenance_Subtypes" runat="server" Text="تعديل نوع الصيانة الفرعي :"></asp:Label>
                <asp:Label ID="lbl_Name_Of_Maintenance_Subtypes" runat="server" Text=""></asp:Label>&nbsp;
                <asp:Label ID="lbl_Success_Edit_New_Maintenance_Subtypes" runat="server" ForeColor="#00FF40"></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-10">
                <div class="card mb-10">
                    <div class="card-body">

                        <div class="row">
                            <div class="col-lg">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Maintenance_Types" runat="server" Text="نوع الصيانة"></asp:Label>
                                    <asp:DropDownList ID="Maintenance_Types_DropDownList" runat="server" CssClass="form-control"  >
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Maintenance_Types_RequiredFieldValidator" ControlToValidate="Maintenance_Types_DropDownList"
                                        InitialValue="إختر نوع الصيانة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lbl_En_Maintenance_Subtypes_Name" runat="server" Text="نوع  بالأنكليزية"></asp:Label>
                            
                            <asp:TextBox ID="txt_En_Maintenance_Subtypes_Name" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqFuild1" ControlToValidate="txt_En_Maintenance_Subtypes_Name"
                                runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lbl_Ar_Maintenance_Subtypes_Name" runat="server" Text="نوع  بالعربية"></asp:Label>
                            
                            <asp:TextBox ID="txt_Ar_Maintenance_Subtypes_Name" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Ar_Maintenance_Subtypes_Name"
                                runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btn_Edit_Maintenance_Subtypes" runat="server" Text="حفظ التغيرات" CssClass="btn btn" BackColor="#52a2da" ForeColor="White" Width="248px" OnClick="btn_Edit_Maintenance_Subtypes_Click"    />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Maintenance_Subtypes_List" runat="server" Text="العودة لقائمة الأنواع الفرعية للصيانات" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Maintenance_Subtypes_List_Click"/>
    </div>

    <script>$('#<%= Maintenance_Types_DropDownList.ClientID %>').chosen();</script>
</asp:Content>
