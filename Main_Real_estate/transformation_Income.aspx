<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="transformation_Income.aspx.cs" Inherits="Main_Real_estate.transformation_Income" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="table-responsive">
                <asp:GridView ID="Avilabel_Cheuqes" DataKeyNames="transformations_Id" runat="server" AutoGenerateColumns="false"
                    OnRowDataBound="Avilabel_Cheuqes_RowDataBound"
                    OnRowEditing="Avilabel_Cheuqes_RowEditing"
                    OnRowUpdating="Avilabel_Cheuqes_RowUpdating"
                    OnRowCancelingEdit="Avilabel_Cheuqes_RowCancelingEdit">
                    <Columns>
                        <asp:TemplateField HeaderText="إسم الملكية">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Ownership_Name" runat="server" Text='<%# Eval("O_Name") %>'></asp:Label>
                                <asp:Label ID="lbl_Ownership_ID" Visible="false" runat="server" Text='<%# Eval("O_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="إسم البناء">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Building_Name" runat="server" Text='<%# Eval("B_Name") %>'></asp:Label>
                                <asp:Label ID="lbl_Building_ID" Visible="false" runat="server" Text='<%# Eval("B_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="رقم الوحدة">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Unit_Name" runat="server" Text='<%# Eval("U_NO") %>'></asp:Label>
                                <asp:Label ID="lbl_Unit_ID" runat="server" Visible="false" Text='<%# Eval("U_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <%--------------------------------------------------------------------------------------------------------------%>
                        <asp:TemplateField HeaderText="رقم الشيك">
                            <ItemTemplate>
                                <asp:Label ID="lbl_transformations_No" runat="server" Text='<%# Eval("transformations_No") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--------------------------------------------------------------------------------------------------%>
                        <asp:TemplateField HeaderText="تاريخ الشيك">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_transformations_Date" runat="server" Text='<%# Eval("transformations_Date") %>'>  </asp:Label>
                                <asp:Calendar ID="Calendar2" runat="server">
                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_transformations_Date" runat="server" Text='<%# Eval("transformations_Date") %>'>  </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--------------------------------------------------------------------------------------------------%>
                        <asp:TemplateField HeaderText="قيمة الشيك">
                            <ItemTemplate>
                                <asp:Label ID="lbl_transformations_Amount" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "transformations_Amount")))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--------------------------------------------------------------------------------------------------%>
                        <asp:TemplateField HeaderText="صاحب الشيك">
                            <ItemTemplate>
                                <asp:Label ID="lbl_transformation_Owner" runat="server" Text='<%# Eval("transformation_Owner") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--------------------------------------------------------------------------------------------------%>
                        <asp:TemplateField HeaderText="اسم المستفيد">
                            <ItemTemplate>
                                <asp:Label ID="lbl_beneficiary_person" runat="server" Text='<%# Eval("beneficiary_person") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-----------------------------------------------------------------------------------%>
                        <asp:TemplateField HeaderText="اسم البنك">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Bank_Arabic_Name" runat="server" Text='<%# Eval("Bank_Arabic_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--------------------------------------------------------------------------------------------------%>
                        <asp:TemplateField HeaderText="اسم المستأجر">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label>
                                <asp:Label ID="lbl_Tenants_Id" runat="server" Visible="false" Text='<%# Eval("Tenants_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--------------------------------------------------------------------------------------------------%>
                        <asp:TemplateField HeaderText="حالة الشيك">
                            <EditItemTemplate>
                                <asp:Label Visible="false" ID="transformation_Status" runat="server" Text='<%# Eval("transformations_Status")%>'></asp:Label>
                                <asp:DropDownList ID="transformation_Status_DropDownList" runat="server">
                                    <asp:ListItem Value="1" Text="غير محصل"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="مؤجل"></asp:ListItem>
                                   
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_transformation_Status" runat="server" Text='<%# Eval("transformations_Status")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--------------------------------------------------------------------------------------------------%>
                        <asp:TemplateField HeaderText="تاريخ تحصيل الشيك">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                <asp:Calendar ID="Collection_Date_Calendar" runat="server">
                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--------------------------------------------------------------------------------------------------%>
                        <asp:TemplateField HeaderText="حالة الشيك" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="test_lbl_transformation_Status" runat="server" Text='<%# Eval("transformations_Status")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--------------------------------------------------------------------------------------------------%>
                        <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="تعديل" CancelText="إلغاء" UpdateText="تحديث" ControlStyle-Width="70px" />
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
                    <RowStyle HorizontalAlign="Center" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
