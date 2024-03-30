<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Edit_Owner.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Edit_Owner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid" id="container-wrapper">
        <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Edit_Owner" runat="server">تعديل المالك : </asp:Label>
                <asp:Label ID="lbl_titel_Name_Edit_Owner" runat="server"></asp:Label>&nbsp;
            <asp:Label ID="lbl_Success_Edit_Owner" runat="server" ForeColor="#00FF40"></asp:Label>
            </h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-6">
                <div class="card mb-4">
                    <div class="card-body">

                        <div class="form-group">
                                <asp:Label ID="lbl_En_Owner_Name" runat="server" Text="اسم المالك بالانكليزية"></asp:Label>

                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_En_Owner_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف الإنكليزية" ForeColor="Red"
                                ValidationExpression="[a-z A-Z0-9]+"></asp:RegularExpressionValidator>  


                                <asp:TextBox ID="txt_En_Owner_Name" runat="server" CssClass="form-control" ></asp:TextBox>

                                <asp:RequiredFieldValidator ID="reqFuild1" ControlToValidate="txt_En_Owner_Name"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            
                            <div class="form-group">
                              <asp:Label ID="lbl_Ar_Owner_Name" runat="server" Text="اسم المالك بالعربية"></asp:Label>
                              &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ar_Owner_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                              <asp:TextBox ID="txt_Ar_Owner_Name" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Ar_Owner_Name"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                              <asp:Label ID="lbl_Owner_tell" runat="server" Text="هاتف المالك"></asp:Label>&nbsp;
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Owner_tell" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Owner_tell" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="reqFuild3" ControlToValidate="txt_Owner_tell"
                               runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                          <asp:Label ID="lbl_Owner_Note" runat="server" Text="ملاحظات"></asp:Label>
                          <asp:TextBox ID="txt_Owner_Note" runat="server" CssClass="form-control"></asp:TextBox>                                
                        </div><br />

                         <div class="form-group">
                          <asp:Label ID="lbl_Owner_Salary" runat="server" Text="الرتب الشهري"></asp:Label>
                          <asp:TextBox ID="txt_Owner_Salary" runat="server" CssClass="form-control"></asp:TextBox> 
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txt_Owner_Salary" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
            </div>
            <!----------------------------------------------------------------------------------------------------------->
            <div class="col-lg-6">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="form-group">
                        <asp:Label ID="lbl_Owner_Mobile" runat="server" Text="جوال المالك"></asp:Label>&nbsp;
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_Owner_Mobile" 
                        EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                        ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt_Owner_Mobile" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_Owner_Mobile"
                        runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                     <div class="form-group">
                        <asp:Label ID="lbl_Owner_Email" runat="server" Text="البريد الإلكتروني"></asp:Label>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt_Owner_Email" 
                        EnableClientScript="True" ErrorMessage="بريد إلكتروني غير صالح" ForeColor="Red"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>  
                        <asp:TextBox ID="txt_Owner_Email" runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txt_Owner_Email"  
                        runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                     <div class="form-group">
                        <asp:Label ID="lbl_Owner_Website" runat="server" Text="موقع الويب"></asp:Label>
                        <asp:TextBox ID="txt_Owner_Website" runat="server" CssClass="form-control"></asp:TextBox>
                    </div><br />

                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:Label ID="Label8" runat="server" Text="تعديل البطاقة الشخصية"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="lbl_path" runat="server" Text="Label" Visible="False"></asp:Label>
                                     <asp:Label ID="QID_NAME" runat="server" Text="Label" Visible="False"></asp:Label>
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                </div>

                                <div class="col-lg-6">
                                    <asp:Panel ID="Panel1" runat="server">
                                        <asp:Image ID="Image1" runat="server" Width="100%" Height="70%" />
                                    </asp:Panel>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <!----------------------------------------------------------------------------------------------------------->
        </div>
        <asp:Button ID="btn_Update_Owner" runat="server" Text="حفظ التغيرات" CssClass="btn btn" BackColor="#52a2da" ForeColor="White" ValidationGroup="OwnerFrame" Width="248px" OnClick="btn_Update_Owner_Click1" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Owner_List" runat="server" Text="العودة لقائمة الملاكين" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Owner_List_Click" />
    </div>
</asp:Content>
