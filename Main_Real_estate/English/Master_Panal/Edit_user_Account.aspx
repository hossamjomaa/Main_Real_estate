<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Edit_user_Account.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Edit_user_Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Edit_user_Account" runat="server" Text="تعديل حساب المستخدم :"></asp:Label>
                &nbsp;
                <asp:Label ID="lbl_user_Account_Name" runat="server" ></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Success_Edit_user_Account" runat="server" ForeColor="#00FF40"></asp:Label></h1>

            
        </div>
        <!----------------------------------------------------------------------------------------------------------->

        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-10">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <asp:Label ID="lbl_Employee" runat="server" Text=" الموظف"></asp:Label>
                                            <asp:DropDownList ID="Employe_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Employe_DropDownList_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="Employe_Req_Val" ValidationGroup="user_Account" ControlToValidate="Employe_DropDownList"
                                                InitialValue="إختر الموظف ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            <asp:Label ID="Photo_FileName" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="Photo_FilePath" runat="server" Visible="false"></asp:Label>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="Employe_DropDownList" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_First_Name" runat="server" Text="الاسم الأول"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Ar_First_Name"
                                        EnableClientScript="True" ErrorMessage="أحرف عربية فقط " ForeColor="Red"
                                        ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ar_First_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqFuild1" ValidationGroup="user_Account" ControlToValidate="txt_Ar_First_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Last_Name" runat="server" Text="الاسم الأخير"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Ar_Last_Name"
                                        EnableClientScript="True" ErrorMessage="أحرف عربية فقط " ForeColor="Red"
                                        ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ar_Last_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="user_Account" ControlToValidate="txt_Ar_Last_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_User_Name"
                                        EnableClientScript="True" ErrorMessage="Only English" ForeColor="Red"
                                        ValidationExpression="[a-z A-Z0-9 !@#$%^&*()-_]+"></asp:RegularExpressionValidator>
                                    <asp:Label ID="lbl_User_Name" runat="server" Text="User Name"></asp:Label>
                                    <asp:TextBox ID="txt_User_Name" Style="text-align: left" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="user_Account" ControlToValidate="txt_User_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Password" runat="server" Text="كلمة السر"></asp:Label>
                                            <asp:TextBox ID="txt_Password" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Text="إظهار كلمة السر" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="user_Account" ControlToValidate="txt_Password"
                                                runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="CheckBox1" EventName="CheckedChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Confirm_Password" runat="server" Text="تأكيد كلمة السر"></asp:Label>
                                            <asp:TextBox ID="txt_Confirm_Password" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:CompareValidator runat="server" ControlToCompare="txt_Password" ValidationGroup="user_Account" ControlToValidate="txt_Confirm_Password"
                                                ErrorMessage="كلمة السر غير مطابقة" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                                            <asp:CheckBox ID="CheckBox2" runat="server" Text="إظهار كلمة السر" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="CheckBox2" EventName="CheckedChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Rull" runat="server" Text="الصلاحيات"></asp:Label>
                                    <asp:DropDownList ID="Role_DropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="user_Account" ControlToValidate="Role_DropDownList"
                                        InitialValue="إختر الصلاحية ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
                <br />
                <div class="row">
                    <div class="col-lg-2">
                        <asp:Button ID="btn_Edit_user_Account" runat="server" Text="حفظ التغيرات" ValidationGroup="user_Account" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" OnClick="btn_Edit_user_Account_Click" />
                    </div>
                    <div class="col-lg-3">
                        <asp:Button ID="btn_Back" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة حسابات المستخدمين" ValidationGroup="x" OnClick="btn_Back_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
