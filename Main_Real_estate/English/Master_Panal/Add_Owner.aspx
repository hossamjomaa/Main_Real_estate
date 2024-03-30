<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Add_Owner.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Add_Owner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid" id="container-wrapper">
    <!----------------------------------------------------------------------------------------------------------->
     <div class="d-sm-flex align-items-center justify-content-between mb-4">
       <h1 class="h3 mb-0 text-gray-800">
       <asp:Label ID="lbl_titel_Add_New_Owner" runat="server" Text="إضافة مالك جديد "></asp:Label>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Label ID="lbl_Success_Add_New_Owner" runat="server" ForeColor="#00FF40"></asp:Label>
       </h1>
     </div>
    <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-6">
                    <div class="card mb-4" >
                        <div class="card-body">
                            <div class="form-group">
                                <asp:Label ID="lbl_En_Owner_Name" runat="server" Text="اسم المالك بالانكليزية"></asp:Label>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_En_Owner_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف الإنكليزية" ForeColor="Red"
                                ValidationExpression="[a-z A-Z0-9]+"></asp:RegularExpressionValidator>  
                                <asp:TextBox ID="txt_En_Owner_Name" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                            
                            <div class="form-group">
                              <asp:Label ID="lbl_Ar_Owner_Name" runat="server" Text="اسم المالك بالعربية"></asp:Label>
                              &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ar_Owner_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                              <asp:TextBox ID="txt_Ar_Owner_Name" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                              <asp:Label ID="lbl_Owner_tell" runat="server" Text="هاتف المالك"></asp:Label>&nbsp;
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Owner_tell" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Owner_tell" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                            

                            <div class="form-group">
                          <asp:Label ID="lbl_Owner_Note" runat="server" Text="ملاحظات"></asp:Label>
                          <asp:TextBox ID="txt_Owner_Note" runat="server" CssClass="form-control"></asp:TextBox>                                
                        </div>
                            <br />
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
            <div class="col-lg-6">
             <div class="card mb-4" >
                 <div class="card-body">
                     <div class="form-group">
                        <asp:Label ID="lbl_Owner_Mobile" runat="server" Text="جوال المالك"></asp:Label>&nbsp;
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_Owner_Mobile" 
                        EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                        ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt_Owner_Mobile" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                     <div class="form-group">
                        <asp:Label ID="lbl_Owner_Email" runat="server" Text="البريد الإلكتروني"></asp:Label>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt_Owner_Email" 
                        EnableClientScript="True" ErrorMessage="بريد إلكتروني غير صالح" ForeColor="Red"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>  
                        <asp:TextBox ID="txt_Owner_Email" runat="server" CssClass="form-control" ></asp:TextBox>
                    </div>

                     <div class="form-group">
                        <asp:Label ID="lbl_Owner_Website" runat="server" Text="موقع الويب"></asp:Label>
                        <asp:TextBox ID="txt_Owner_Website" runat="server" CssClass="form-control"></asp:TextBox>
                    </div><br />

                     <div class="form-group">
                        <asp:Label ID="lbl_Owner_QID" runat="server" Text="تحميل هوية المالك"></asp:Label>
                        <asp:FileUpload ID="FUL_Owner_QID" runat="server"  CssClass="form-control" />
                    </div>
                 </div>
             </div>
            </div>
        </div>
        <asp:Button ID="btn_Add_Owner" runat="server" Text="إضافة مالك" CssClass="btn btn" BackColor="#52a2da" ForeColor="White"   Width="248px" OnClick="btn_Add_Owner_Click1" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Owner_List" runat="server" Text="العودة لقائمة الملاكين" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Owner_List_Click"/>
    </div>
</asp:Content>
