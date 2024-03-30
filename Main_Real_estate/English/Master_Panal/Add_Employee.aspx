<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Add_Employee.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Add_Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" />

     <div class="container-fluid" id="container-wrapper">
    <!----------------------------------------------------------------------------------------------------------->
     <div class="d-sm-flex align-items-center justify-content-between mb-4">
       <h1 class="h3 mb-0 text-gray-800">
       <asp:Label ID="lbl_titel_Add_New_Employee" runat="server" Text="إضافة موظف جديد"></asp:Label>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Label ID="lbl_Success_Add_New_Employee" runat="server" ForeColor="#00FF40"></asp:Label>
       </h1>
     </div>
    <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-6">
                    <div class="card mb-4" >
                        <div class="card-body">
                            <div class="form-group">
                                <asp:Label ID="lbl_En_Employee_Name" runat="server" Text="اسم الموظف بالأنكليزية"></asp:Label>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_En_Employee_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف الأنكليزية" ForeColor="Red"
                                ValidationExpression="[a-z A-Z]+"></asp:RegularExpressionValidator>  
                                <asp:TextBox ID="txt_En_Employee_Name" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqFuild1" ControlToValidate="txt_En_Employee_Name"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            
                            <div class="form-group">
                              <asp:Label ID="lbl_Ar_Employee_Name" runat="server" Text="إسم الموظف بالعربية"></asp:Label>
                              &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ar_Employee_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>
                              <asp:TextBox ID="txt_Ar_Employee_Name" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Ar_Employee_Name"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                              <asp:Label ID="lbl_Employee_tell" runat="server" Text="هاتف الموظف"></asp:Label>&nbsp;
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Employee_tell" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Employee_tell" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="reqFuild3" ControlToValidate="txt_Employee_tell"
                               runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Employee_Mobile" runat="server" Text="جوال الموظف"></asp:Label>&nbsp;
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_Employee_Mobile" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Employee_Mobile" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_Employee_Mobile"
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            <div class="col-lg-6">
             <div class="card mb-4" >
                 <div class="card-body">
                    <div class="form-group">
                                <asp:Label ID="lbl_Employee_Designation" runat="server" Text="تعيين الموظف"></asp:Label>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txt_Employee_Designation" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>  
                                <asp:TextBox ID="txt_Employee_Designation" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txt_Employee_Designation"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Employee_Department" runat="server" Text="القسم"></asp:Label>
                                <asp:DropDownList ID="Employee_Department_DropDownList" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Ownership_Status_RequiredFieldValidator" ControlToValidate="Employee_Department_DropDownList"
                                InitialValue="إختر القسم ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Employee_Level" runat="server" Text="الدرجة"></asp:Label>
                                <asp:DropDownList ID="Employee_Level_DropDownList" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Employee_Level_DropDownList"
                                InitialValue="إختر الدرجة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                     <div class="form-group">
                        <asp:Label ID="lbl_Employee_Photo" runat="server" Text="تحميل صورة الموظف "></asp:Label>
                        <asp:FileUpload ID="FUL_Employee_Photo" runat="server"  CssClass="form-control" />
                        
                    </div>
                 </div>
             </div>
            </div>
        </div>
        <asp:Button ID="btn_Add_Employee" runat="server" Text="إضافة موظف" CssClass="btn btn" BackColor="#52a2da" ForeColor="White"   Width="248px" OnClick="btn_Add_Employee_Click1" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Employee_List" runat="server" Text="العودة لقائمة الموظفين" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Employee_List_Click"/>
    </div>


    <script>$('#<%=Employee_Department_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Employee_Level_DropDownList.ClientID%>').chosen();</script>
</asp:Content>
