<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="OS_B_U_Arcive.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.OS_B_U_Arcive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .UUL {
            list-style-type: none;
            margin: auto;
            padding: 0;
            overflow: hidden;
            background-color: #52a2da;
        }

        li {
            float: right;
        }

            li a {
                display: block;
                color: #fff;
                text-align: center;
                padding-left: 50px;
                padding-right: 15px;
                padding-top: 16px;
                padding-bottom: 16px;
                text-decoration: none;
            }

            li a:hover{
                color: #fff;
            }
    </style>

    <style>
        .table-condensed tr th {
            border: 0px solid #fff;
            color: black;
            background-color: #cacff1;
        }

        .table-condensed, .table-condensed tr td {
            border: 0px solid #fff;
        }

        tr:nth-child(even) {
            background: #d7d7d7;
        }

        tr:nth-child(odd) {
            background: #e3e3e3;
        }
    </style>










    <ul class="UUL">
        <li><a runat="server" id="A_1" onserverclick="A_1_ServerClick">أرشيف الملكيات</a></li>
        <li><a runat="server" id="A_2" onserverclick="A_2_ServerClick">أرشيف الأبنية</a></li>
        <li><a runat="server" id="A_3" onserverclick="A_3_ServerClick">أرشيف الوحدات</a></li>
        <li><a runat="server" id="A_4" onserverclick="A_4_ServerClick">أرشيف الكل</a></li>
    </ul>
    <br />
    <div class="container-fluid" runat="server" id="OS_Arcive">
        <div class="row">
            <div class="col-lg-12 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Contracts_List" ForeColor="#52a2da" runat="server" Text=" أرشيف الملكيات"></asp:Label>
                </h1>
            </div>
            <br />

            <div class="row">
                <div class="col-lg-12 mb-4">
                    <!-- Simple Tables -->
                    <div class="card">
                        <div class="table-responsive">
                            <asp:GridView AutoGenerateColumns="false" ID="Ownership_GridView" runat="server"
                                CssClass="datatable table table-striped table-bordered" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Horizontal" Font-Size="11px">
                                <Columns>
                                    <asp:TemplateField HeaderText="مسلسل" ItemStyle-Width="10">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Users_Ar_First_Name" HeaderText="إسم  المستخدم" />
                                    <asp:BoundField DataField="Delete_Date" HeaderText="تاريخ الحذف" />
                                    <asp:BoundField DataField="Owner_Ship_AR_Name" HeaderText="إسم الملكية " />
                                    <asp:BoundField DataField="owner_ship_Code" HeaderText="رمز الملكية " />
                                    <asp:BoundField DataField="Reason_Delete" HeaderText="سبب الحذف " />
                                </Columns>
                                <EditRowStyle HorizontalAlign="Center" />
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#cacff1" Font-Bold="false" ForeColor="Black" Font-Size="11px" HorizontalAlign="Center" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="false" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </div>
                        <asp:Label ID="lbl_NO_O_Data" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <hr />
    </div>
    <%--*******************************************************************************************--%>
    <div class="container-fluid" runat="server" id="B_Arcive">
        <div class="row">
            <div class="col-lg-6 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="Label1" ForeColor="#52a2da" runat="server" Text=" أرشيف الأبنية"></asp:Label>
                </h1>
            </div>


            <div class="row">
                <div class="col-lg-12 mb-4">
                    <!-- Simple Tables -->
                    <div class="card">
                        <div class="table-responsive">
                            <asp:GridView AutoGenerateColumns="false" ID="Building_GridView" runat="server"
                                CssClass="datatable table table-striped table-bordered" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Horizontal" Font-Size="11px">
                                <Columns>
                                    <asp:TemplateField HeaderText="مسلسل" ItemStyle-Width="10">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Users_Ar_First_Name" HeaderText="إسم  المستخدم" />
                                    <asp:BoundField DataField="Delete_Date" HeaderText="تاريخ الحذف" />
                                    <asp:BoundField DataField="Owner_Ship_AR_Name" HeaderText="إسم الملكية " />
                                     <asp:BoundField DataField="owner_ship_Code" HeaderText="رمز الملكية " />
                                    <asp:BoundField DataField="Building_Arabic_Name" HeaderText="إسم البناء " />
                                    <asp:BoundField DataField="Building_NO" HeaderText="رقم البناء " />
                                    <asp:BoundField DataField="Reason_Delete" HeaderText="سبب الحذف " />
                                </Columns>
                                <EditRowStyle HorizontalAlign="Center" />
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#cacff1" Font-Bold="false" ForeColor="Black" Font-Size="11px" HorizontalAlign="Center" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="false" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </div>
                        <asp:Label ID="lbl_NO_B_Data" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <hr />
    </div>
    <%--*******************************************************************************************--%>
    <div class="container-fluid" runat="server" id="U_Arcive">
        <div class="row">
            <div class="col-lg-6 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="Label2" ForeColor="#52a2da" runat="server" Text=" أرشيف الوحدات"></asp:Label>
                </h1>
            </div>


            <div class="row">
                <div class="col-lg-12 mb-4">
                    <!-- Simple Tables -->
                    <div class="card">
                        <div class="table-responsive">
                            <asp:GridView AutoGenerateColumns="false" ID="Unit_GridView" runat="server"
                                CssClass="datatable table table-striped table-bordered" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Horizontal" Font-Size="11px">
                                <Columns>
                                    <asp:TemplateField HeaderText="مسلسل" ItemStyle-Width="10">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Users_Ar_First_Name" HeaderText="إسم  المستخدم" />
                                    <asp:BoundField DataField="Delete_Date" HeaderText="تاريخ الحذف" />
                                    <asp:BoundField DataField="Owner_Ship_AR_Name" HeaderText="إسم الملكية " />
                                     <asp:BoundField DataField="owner_ship_Code" HeaderText="رمز الملكية " />
                                    <asp:BoundField DataField="Building_Arabic_Name" HeaderText="إسم البناء " />
                                    <asp:BoundField DataField="Building_NO" HeaderText="رقم البناء " />
                                    <asp:BoundField DataField="Unit_Number" HeaderText="رقم الوحدة " />
                                    <asp:BoundField DataField="Reason_Delete" HeaderText="سبب الحذف " />
                                </Columns>
                                <EditRowStyle HorizontalAlign="Center" />
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#cacff1" Font-Bold="false" ForeColor="Black" Font-Size="11px" HorizontalAlign="Center" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="false" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </div>
                        <asp:Label ID="lbl_NO_U_Data" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
