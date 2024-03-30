<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Cash_Icome.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Cash_Icome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="Income_ScriptManager" runat="server"></asp:ScriptManager>
    <div class="container-fluid" id="container-wrapper">
        <div calss="row" style="margin: auto">
            <h4><asp:Label ID="lbl_Avilabel_transformation" runat="server"></asp:Label></h4>
            <br /><hr />
            <h4><asp:Label ID="Label1" runat="server" Text=" الدفعات النقدية للعقود المفردة"></asp:Label></h4><br />




            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="table-responsive">
                            <asp:GridView ID="Avilabel_Cash" DataKeyNames="Cash_Amount_ID" runat="server" AutoGenerateColumns="false"
                                OnRowDataBound="Avilabel_Cash_RowDataBound"
                                OnRowEditing="Avilabel_Cash_RowEditing"
                                OnRowUpdating="Avilabel_Cash_RowUpdating"
                                OnRowCancelingEdit="Avilabel_Cash_RowCancelingEdit">
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
                                    <asp:TemplateField HeaderText="قيمة الدفعة">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Cash_Amount" runat="server" Text='<%# Eval("Cash_Amount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                     <asp:TemplateField HeaderText="تاريخ الدفعة">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Cash_Date" runat="server" Text='<%# Eval("Cash_Date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="اسم المستأجر">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="حالة الدفعة">
                                        <EditItemTemplate>
                                            <asp:Label Visible="false" ID="Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label>
                                            <asp:DropDownList ID="Status_DropDownList" runat="server">
                                                <asp:ListItem Value="1" Text="غير محصل"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="محصل"></asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                     <asp:TemplateField HeaderText="تاريخ تحصيل الدفعة">
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
                                    <asp:TemplateField HeaderText="حالة الدفعة" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="test_lbl_Tr_Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label>
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
                </ContentTemplate>
            </asp:UpdatePanel>
           <%-- ***********************************************************************************************************************************************
            ***********************************************************************************************************************************************--%>
            <br />
            <hr />
            <h4><asp:Label ID="Label2" runat="server" Text=" الدفعات النقدية للعقود المجملة"></asp:Label></h4><br />
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="table-responsive">
                            <asp:GridView ID="Building_Cash_Amount" DataKeyNames="Cash_Amount_ID" runat="server" AutoGenerateColumns="false"
                                OnRowDataBound="Building_Cash_Amount_RowDataBound"
                                OnRowEditing="Building_Cash_Amount_RowEditing"
                                OnRowUpdating="Building_Cash_Amount_RowUpdating"
                                OnRowCancelingEdit="Building_Cash_Amount_RowCancelingEdit">
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

                                    


                                    <%--------------------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="قيمة الدفعة">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Cash_Amount" runat="server" Text='<%# Eval("Cash_Amount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                     <asp:TemplateField HeaderText="تاريخ الدفعة">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Cash_Date" runat="server" Text='<%# Eval("Cash_Date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="اسم المستأجر">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="حالة الدفعة">
                                        <EditItemTemplate>
                                            <asp:Label Visible="false" ID="Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label>
                                            <asp:DropDownList ID="Status_DropDownList" runat="server">
                                                <asp:ListItem Value="1" Text="غير محصل"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="محصل"></asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                     <asp:TemplateField HeaderText="تاريخ تحصيل الدفعة">
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
                                    <asp:TemplateField HeaderText="حالة الدفعة" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="test_lbl_Tr_Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
