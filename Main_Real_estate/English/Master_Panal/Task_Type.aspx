<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Task_Type.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Task_Type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" id="container-wrapper" style="margin: auto;">
        <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Task_Type" runat="server" Text="إضافة نوع مهمة جديدة"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Success_Add_New_Task_Type" runat="server" ForeColor="#00FF40"></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-12">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Task_Type_Name" runat="server" Text="اسم نوع المهمة بالعربي"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="Ar_Task_Type_Name_Reg_Exp_Val" runat="server" ControlToValidate="txt_Ar_Task_Type_Name" 
                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                    ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ar_Task_Type_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Ar_Task_Type_Name_Req_Field_Val" ValidationGroup="Task_Type_GVa" ControlToValidate="txt_Ar_Task_Type_Name" runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_EN_Task_Type_Name" runat="server" Text="اسم نوع المهمة بالإنكليزي"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="EN_Task_Type_Name_Reg_Exp_Val" runat="server" ControlToValidate="txt_EN_Task_Type_Name" 
                                    EnableClientScript="True" ErrorMessage="!!!  فقط الأحرف الإنكليزية" ForeColor="Red"
                                    ValidationExpression="[a-z A-Z]+"></asp:RegularExpressionValidator> 
                                    <asp:TextBox ID="txt_EN_Task_Type_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EN_Task_Type_Name_Req_Field_Val" ValidationGroup="Task_Type_GVa" ControlToValidate="txt_EN_Task_Type_Name" runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-4">
                                <div class="form-group">
                                    <br />
                                <asp:Button ID="btn_Add_Task_Type" runat="server" Text="إضافة نوع مهمة" CssClass="btn btn" BackColor="#52a2da"  ValidationGroup="Task_Type_GVa" ForeColor="White" Width="248px" OnClick="btn_Add_Task_Type_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <hr />
        <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="Label1" runat="server" Text="قائمة أنواع المهام "></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-12">
                    <div class="card-body">
                        <div class="row">
                            <div class="table-responsive" style="border-radius: 10px;">
                                <asp:GridView AutoGenerateColumns="false" ID="Task_Type_GV" runat="server"
                                    CssClass="table align-items-center table-flush" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Horizontal" Font-Size="Medium"

                                    OnRowEditing="Task_Type_GV_RowEditing"
                                    OnRowUpdating="Task_Type_GV_RowUpdating"
                                    OnRowCancelingEdit="Task_Type_GV_RowCancelingEdit"
                                    OnRowDeleting="Task_Type_GV_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="#" ItemStyle-Width="10">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="معرف المهمة الرئيسية" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Task_Type_Id" runat="server" Text='<%# Eval("Task_Type_Id") %>'> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="اسم المهمة بالعربي">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txt_Task_Arabic_Type" runat="server" Text='<%# Bind("Task_Arabic_Type") %>' Width="300px">  
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Task_Arabic_Type" runat="server" Text='<%# Eval("Task_Arabic_Type") %>'> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="اسم المهمة بالإنكليزي">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txt_Task_English_Type" runat="server" Text='<%# Bind("Task_English_Type") %>' Width="300px">  
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Task_English_Type" runat="server" Text='<%# Eval("Task_English_Type") %>'> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <%--------------------------------------------------------------------------------------------------%>
                                        <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="تعديل" CancelText="إلغاء" UpdateText="تحديث" ShowDeleteButton="true" DeleteText="حذف" ControlStyle-Width="70px" />
                                    </Columns>
                                    <EditRowStyle HorizontalAlign="Center" />
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#eaecf4" Font-Bold="false" ForeColor="Black" Font-Size="18px" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                    <RowStyle HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="false" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#242121" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br /><br />
    </div>
</asp:Content>
