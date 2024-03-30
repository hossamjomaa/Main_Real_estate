<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Add_Inventory.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Add_Inventory" %>
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
                <asp:Label ID="lbl_titel_Add_New_Inventory" runat="server" Text="إضافة مخزن جديد"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Success_Add_New_Inventory" runat="server" ForeColor="#00FF40"></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-12">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Inventory_Name" runat="server" Text="اسم المخزن بالإنكليزية"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_En_Inventory_Name"
                                        EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف الإنكليزية" ForeColor="Red"
                                        ValidationExpression="[a-z A-Z]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_En_Inventory_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqFuild1" ControlToValidate="txt_En_Inventory_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Inventory_Name" runat="server" Text="اسم المخزن بالعربية"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ar_Inventory_Name"
                                        EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                        ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ar_Inventory_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Ar_Inventory_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <!----------------------------------------------------------------------------------------------------------->
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Inventory_Location" runat="server" Text="مكان المخزن"></asp:Label>&nbsp;
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Ar_Inventory_Name"
                                        EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                        ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Inventory_Location" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqFuild3" ControlToValidate="txt_Inventory_Location"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_storekeeper" runat="server" Text="أمين المخزن"></asp:Label>
                                    <asp:DropDownList ID="storekeeper_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="storekeeper_RequiredFieldValidator" ControlToValidate="storekeeper_DropDownList"
                                        InitialValue="إختر أمين المخزن  ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btn_Add_Inventory" runat="server" Text="إضافة مخزون" CssClass="btn btn" BackColor="#52a2da" ForeColor="White" Width="248px" OnClick="btn_Add_Inventory_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Inventory_List" runat="server" Text="العودة لقائمة المخازن" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Inventory_List_Click1" />
    </div>
    <script>$('#<%= storekeeper_DropDownList.ClientID %>').chosen();</script>
</asp:Content>
