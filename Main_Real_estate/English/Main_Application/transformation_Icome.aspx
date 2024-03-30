<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="transformation_Icome.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.transformation_Icome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .Indicator_buttons {
            border-radius: 50px;
            border-style: solid;
            border-radius: 50px;
            width: 20px;
            margin-right: 20px;
            margin-top: 20px;
            height: 20px;
        }
    </style>

    <asp:ScriptManager ID="Income_ScriptManager" runat="server"></asp:ScriptManager>
    <div class="container-fluid" id="container-wrapper">
        <div calss="row" style="margin: auto">
            <h4>
                <asp:Label ID="lbl_Avilabel_transformation" runat="server"></asp:Label></h4>
            <br />
            <hr />
            <h4>
                <asp:Label ID="Label1" runat="server" Text="حوالات العقود المفردة"></asp:Label></h4>
            <br />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="table-responsive">
                            <asp:GridView ID="Avilabel_transformation" DataKeyNames="transformation_Table_ID" runat="server" AutoGenerateColumns="false"
                                OnRowDataBound="Avilabel_transformation_RowDataBound"
                                OnRowEditing="Avilabel_transformation_RowEditing"
                                OnRowUpdating="Avilabel_transformation_RowUpdating"
                                OnRowCancelingEdit="Avilabel_transformation_RowCancelingEdit">
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
                                    <asp:TemplateField HeaderText="رقم الحوالة">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_transformation_No" runat="server" Text='<%# Eval("transformation_No") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="تاريخ الحوالة">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_transformation_Date" runat="server" Text='<%# Eval("transformation_Date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="قيمة الحوالة">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Amount" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Amount")))%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="اسم المستأجر">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="اسم المستفيد">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_beneficiary_person" runat="server" Text='<%# Eval("Beneficiary_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-----------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="اسم البنك">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Bank_Arabic_Name" runat="server" Text='<%# Eval("Bank_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="رقم الحساب">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Account_No" runat="server" Text='<%# Eval("Account_No") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="سوفت كود">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Soaft_Code_No" runat="server" Text='<%# Eval("Soaft_Code_No") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="حالة الحوالة">
                                        <EditItemTemplate>
                                            <asp:Label Visible="false" ID="Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                            <asp:DropDownList ID="Status_DropDownList" runat="server">
                                                <asp:ListItem Value="1" Text="غير محصل"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="محصل"></asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="تاريخ تحصيل الحوالة">
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
                                            <asp:Label ID="test_lbl_Tr_Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
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
            <hr />
            <div calss="row" style="margin: auto">
                <h4>
                    <asp:Label ID="Label3" runat="server" Text="حوالات العقود المجملة"></asp:Label></h4>
                <br />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" DataKeyNames="transformation_Table_ID" runat="server" AutoGenerateColumns="false"
                                    OnRowDataBound="GridView1_RowDataBound"
                                    OnRowEditing="GridView1_RowEditing"
                                    OnRowUpdating="GridView1_RowUpdating"
                                    OnRowCancelingEdit="GridView1_RowCancelingEdit">
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
                                        <asp:TemplateField HeaderText="رقم الحوالة">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltransformation_No" runat="server" Text='<%# Eval("transformation_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="تاريخ الحوالة">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_transformation_Date" runat="server" Text='<%# Eval("transformation_Date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="قيمة الحوالة">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Amount" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Amount")))%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="اسم المستأجر">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="اسم المستفيد">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_beneficiary_person" runat="server" Text='<%# Eval("Beneficiary_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-----------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="اسم البنك">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Bank_Arabic_Name" runat="server" Text='<%# Eval("Bank_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="رقم الحساب">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Account_No" runat="server" Text='<%# Eval("Account_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="سوفت كود">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Soaft_Code_No" runat="server" Text='<%# Eval("Soaft_Code_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="حالة الحوالة">
                                            <EditItemTemplate>
                                                <asp:Label Visible="false" ID="Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                <asp:DropDownList ID="Status_DropDownList" runat="server">
                                                    <asp:ListItem Value="1" Text="غير محصل"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="محصل"></asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField HeaderText="تاريخ تحصيل الحوالة">
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
                                                <asp:Label ID="test_lbl_Tr_Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
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
    </div>
</asp:Content>
