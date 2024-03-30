<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Employee_Task_Management.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Employee_Task_Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .Indicator_buttons{
            border-radius:50px;
            border-style: solid; 
            border-radius: 50px; 
            width: 20px; 
            margin-right: 20px; 
            margin-top: 20px; 
            height: 20px; 
        }
       
    </style>


    <div class="container-fluid" id="container-wrapper">

        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titelt" runat="server" Text="المهام الموكلة للسيد : "></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="lbl_Employee" runat="server"></asp:Label>
            </h1>
        </div>
        <div class="col-lg-6">
                    <asp:Button ID="btn_New_Contract" runat="server"   CssClass="Indicator_buttons"  Enabled="false"/>
                    &nbsp;
                        <span style="margin-top: 20px">معلقة</span>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_Under_Expaired_Contract" runat="server" CssClass="Indicator_buttons" BackColor="#72a2ff" Enabled="false"/>
                    &nbsp;
                        <span style="margin-top: 20px">قيد التنفيذ</span>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_Expaired_Contract" runat="server"   CssClass="Indicator_buttons" BackColor="#20b2aa" Enabled="false"/>
                    &nbsp;
                        <span style="margin-top: 20px">منفذة</span> 

        </div><br /><br />

        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" style="border-radius: 10px;">
                        <asp:GridView AutoGenerateColumns="false" ID="Employee_Task_Management_GV" runat="server" CssClass="table align-items-center table-flush" BackColor="White" BorderColor="#CCCCCC"
                            BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Both" Font-Size="10px"
                            OnRowDataBound="Employee_Task_Management_GV_RowDataBound"
                            OnRowEditing="Employee_Task_Management_GV_RowEditing"
                            OnRowUpdating="Employee_Task_Management_GV_RowUpdating"
                            OnRowCancelingEdit="Employee_Task_Management_GV_RowCancelingEdit">
                            <Columns>


                                <asp:TemplateField HeaderText="" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Task_Id" runat="server" Text='<%# Eval("Task_Management_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" ItemStyle-Width="10px">
                                    <ItemTemplate>
                                        <asp:Button ID="But_Priority" runat="server" CssClass="Indicator_buttons" Enabled="false" /></td>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="أولوية المهمة" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Task_Priority_Word" runat="server" Text='<%# Eval("Task_Priority_Word") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText=" المهمة">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Task_type" runat="server" Text='<%# Eval("Task_Type") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="إسم القسم">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Department_Name" runat="server" Text='<%# Eval("Department_Arabic_Name") %>'></asp:Label>
                                        <asp:Label ID="lbl_Department_Id" Visible="false" runat="server" Text='<%# Eval("Department_Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="اسم الموظف">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Employee_Name" runat="server" Text='<%# Eval("Employee_Arabic_name") %>'></asp:Label>
                                        <asp:Label ID="lbl_Employee_Id" runat="server" Visible="false" Text='<%# Eval("Employee_Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="تفاصيل المهمة" ControlStyle-CssClass="Task_Descrioption">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Task_Descrioption" runat="server" Text='<%# Eval("Task_Descrioption") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="تاريخ البدء">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Start_date" runat="server" Text='<%# Eval("Start_date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="تاريخ الأنتهاء المفترض">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="تاريخ الأنتهاء الفعلي">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Actual_End_Date" runat="server" Text='<%# Eval("Actual_End_Date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="حالة المهمة">
                                    <EditItemTemplate>
                                        <asp:Label Visible="false" ID="Task_Status" runat="server" Text='<%# Eval("Task_Status")%>'></asp:Label>
                                        <asp:DropDownList ID="Task_Status_DropDownList" runat="server">
                                            <asp:ListItem Value="1" Text="معلقة"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="قيد التنفيذ"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="منفذة"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Task_Status" runat="server" Text='<%# Eval("Task_Status")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="تاريخ الأنتهاء الفعلي" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_TaskStatus" runat="server" Text='<%# Eval("Task_Status") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="أولوية المهمة" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Task_Priority" runat="server" Text='<%# Eval("Task_Priority") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                 <asp:HyperLinkField ControlStyle-CssClass="btn btn-success" Text="تجزئة" DataNavigateUrlFields="Task_Management_ID" DataNavigateUrlFormatString="Task_Segmentation.aspx?Id={0}">
                                    <ControlStyle CssClass="btn btn-success"></ControlStyle>
                                </asp:HyperLinkField>

                                

                                <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="تعديل" CancelText="إلغاء" UpdateText="تحديث" ControlStyle-Width="70px" />

                            </Columns>
                            <EditRowStyle HorizontalAlign="Center" />
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#eaecf4" Font-Bold="false" ForeColor="Black" Font-Size="10px" HorizontalAlign="Center" />
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
</asp:Content>
