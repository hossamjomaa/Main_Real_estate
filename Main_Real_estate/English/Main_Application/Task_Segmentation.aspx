<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Task_Segmentation.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Task_Segmentation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" id="Unit_container-wrapper">



        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_Add_Part_Task" runat="server" Text="تجزئة المهمة : "></asp:Label>
                <asp:Label ID="lbl_Task_Type" runat="server"></asp:Label>
            </h1>
        </div>


        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-8">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Part_Task_Discreption" runat="server" Text="الشرح"></asp:Label>
                                    <asp:TextBox ID="txt_Part_Task_Discreption" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Part_Task_RequiredFieldValidator" ControlToValidate="txt_Part_Task_Discreption"
                                        runat="server" ValidationGroup="Part_Task_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"> </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <br />
                                <br />
                                <asp:Button ID="btn_Add_Part_Task" runat="server" Text="إضافة" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" Width="248px" ValidationGroup="Part_Task_RequiredField" OnClick="btn_Add_Part_Task_Click" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-4">
                                <asp:Button ID="btn_Back_To_Task_List" runat="server" Text="العودة إلى قائمة المهمات" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Task_List_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        

        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="row">
                            <div class="table-responsive" style="border-radius: 10px;">
                                <asp:GridView AutoGenerateColumns="false" ID="Part_Task_GV" runat="server" CssClass="table align-items-center table-flush" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Both" Font-Size="13px"
                                    OnRowDataBound="Part_Task_GV_RowDataBound"
                                    OnRowEditing="Part_Task_GV_RowEditing"
                                    OnRowUpdating="Part_Task_GV_RowUpdating1"
                                    OnRowCancelingEdit="Part_Task_GV_RowCancelingEdit"
                                    OnRowDeleting="Part_Task_GV_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="#" ItemStyle-Width="10">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="معرف المهمة الرئيسية" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Task_ID" runat="server" Text='<%# Eval("Task_Id") %>'> </asp:Label>
                                                <asp:Label ID="lbl_Task_Part_Id" runat="server" Text='<%# Eval("Task_Part_Id") %>'> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="وصف المهمة">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txt_Task_Part_Discription" runat="server" Text='<%# Bind("Task_Part_Discription") %>' TextMode="MultiLine">  
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Task_Part_Discription" runat="server" Text='<%# Eval("Task_Part_Discription") %>'> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="الحالة">
                                            <EditItemTemplate>
                                                <asp:Label Visible="false" ID="Task_Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                <asp:DropDownList ID="Task_Status_DropDownList" runat="server">
                                                    <asp:ListItem Value="1" Text="معلقة"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="قيد التنفيذ"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="منتهية"></asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Task_Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="تعديل" CancelText="إلغاء" UpdateText="تحديث" ShowDeleteButton="true" DeleteText="حذف" ControlStyle-Width="70px" />

                                    </Columns>
                                    <EditRowStyle HorizontalAlign="Center" />
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#eaecf4" Font-Bold="false" ForeColor="Black" Font-Size="15px" HorizontalAlign="Center" />
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
    </div>
</asp:Content>
