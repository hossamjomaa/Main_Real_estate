<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Sub_Main_Type_Evaluation.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Sub_Main_Type_Evaluation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid" id="container-wrapper" style="margin:auto; ">
         <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Sub_Type_Evaluation" runat="server" Text="إضافة نوع فرعي جديد"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Success_Add_New_Sub_Type_Evaluation" runat="server" ForeColor="#00FF40"></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-10">
                <div class="card mb-10" >
                     <div class="card-body">


                         <div class="form-group">
                                    <asp:Label ID="lbl_main_Type" runat="server" Text="النوع الرئيسي"></asp:Label>
                                    <asp:DropDownList ID="main_Type_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="main_Type_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="main_Type_Req_Field_Val" ControlToValidate="main_Type_DropDownList"
                                        InitialValue="إختر النوع الرئيسي ...." runat="server" ValidationGroup="Contract_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>



                          
                              <div class="form-group">
                               <asp:Label ID="lbl_En_Sub_Type_Evaluation_Name" runat="server" Text="إسم النوع بالإنكليزية"></asp:Label>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_En_Sub_Type_Evaluation_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف الإنكليزية" ForeColor="Red"
                                ValidationExpression="[a-z A-Z0-9]+"></asp:RegularExpressionValidator>  
                                <asp:TextBox ID="txt_En_Sub_Type_Evaluation_Name" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqFuild1" ControlToValidate="txt_En_Sub_Type_Evaluation_Name"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>

                              <div class="form-group">
                               <asp:Label ID="lbl_Ar_Sub_Type_Evaluation_Name" runat="server" Text="إسم النوع بالعربية"></asp:Label>
                              &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ar_Sub_Type_Evaluation_Name" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                              <asp:TextBox ID="txt_Ar_Sub_Type_Evaluation_Name" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Ar_Sub_Type_Evaluation_Name"  
                                runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>

                              <div class="form-group">
                               <asp:Label ID="lbl_Sub_Type_Evaluation_Number" runat="server"  Text=" الوزن"></asp:Label>&nbsp;
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Sub_Type_Evaluation_Number" 
                                EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Sub_Type_Evaluation_Number" runat="server" TextMode="Number" Enabled="false" min="1" max="100" CssClass="form-control"
                                    AutoPostBack="true" OnTextChanged="txt_Sub_Type_Evaluation_Number_TextChanged"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="reqFuild3" ControlToValidate="txt_Sub_Type_Evaluation_Number"
                               runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>


                         <div class="form-group">
                               <asp:Label ID="lbl_Sub_Type_Evaluation_Number_Persenteg" runat="server"  Text="النسبة المؤية" ></asp:Label>&nbsp;
                                <asp:TextBox ID="txt_Sub_Type_Evaluation_Number_Persenteg" runat="server" Enabled="false" CssClass="form-control"
                                ></asp:TextBox>
                             </div>

                      </div>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btn_Add_Sub_Type_Evaluation" runat="server" Text="إضافة " CssClass="btn btn" BackColor="#52a2da" ForeColor="White" Width="248px" OnClick="btn_Add_Sub_Type_Evaluation_Click"    />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Sub_Type_Evaluation_List" runat="server" Text="العودة لقائمة الأنواع" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Sub_Type_Evaluation_List_Click"/>
     </div>
</asp:Content>
