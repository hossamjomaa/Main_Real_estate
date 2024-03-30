<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Asset_List.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Asset_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Container Fluid-->
    <div class="container-fluid" id="container-wrapper">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Asset_List" runat="server" Text="قائمة الاصول"></asp:Label></h1>
        </div>
        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" style="border-radius: 10px;">
                        <asp:GridView AutoGenerateColumns="false" ID="Asset_GridView" runat="server" CssClass="table align-items-center table-flush" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Horizontal" Font-Size="Small" OnPageIndexChanging="Asset_GridView_PageIndexChanging1" AllowPaging="True" PageSize="5">
                            <Columns>
                                <asp:BoundField DataField="Assets_English_Name" HeaderText="الاسم بالإنكليزية" />
                                <asp:BoundField DataField="Assets_Arabic_Name" HeaderText="الاسم بالعربية" />
                                <asp:BoundField DataField="Assets_Value" HeaderText="قيمة الاصل" />
                                <asp:BoundField DataField="Quantitiy" HeaderText="نوعية الأصل" />
                                <asp:HyperLinkField ControlStyle-CssClass="btn btn-success" Text=" تعديل" DataNavigateUrlFields="Assets_Id" DataNavigateUrlFormatString="Edit_Asset.aspx?Id={0}">
                                    <ControlStyle CssClass="btn btn-success"></ControlStyle>
                                </asp:HyperLinkField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="btn btn-danger" ID="btn_Asset_Delete" runat="server" CommandArgument='<%# Eval("Assets_Id") %>' OnClick="Delete_Asset"> <i class="fa fa-trash"></i> حذف</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:HyperLinkField ControlStyle-CssClass="btn btn-primary" Text=" تفاصيل" DataNavigateUrlFields="Assets_Id" DataNavigateUrlFormatString="Asset_Details_Tabel.aspx?Id={0}">
                                    <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                                </asp:HyperLinkField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#eaecf4" Font-Bold="false" ForeColor="Black" Font-Size="18px" HorizontalAlign="Center" />
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="false" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                            <RowStyle HorizontalAlign="Center" />
                            <EditRowStyle HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <button class="btn btn-primary" style="background-color: #52a2da;" runat="server" onserverclick="GoToAddAsset"><i class="fa fa-plus-circle" aria-hidden="true"></i>إضافة اصل جديد</button>
        </div>
    </div>
    <!---Container Fluid-->
</asp:Content>
