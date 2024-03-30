<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Under_Under_Contract_Type_List.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Under_Under_Contract_Type_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Container Fluid-->
    <div class="container-fluid" id="container-wrapper">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Under_Contract_Type_List" runat="server" Text="قائمة انواع بموجب عقد"></asp:Label>
            </h1>
        </div>

        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" style="border-radius: 10px;">
                        <asp:GridView AutoGenerateColumns="false" ID="Under_Contract_Type_GridView1" runat="server" CssClass="table align-items-center table-flush" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Horizontal" Font-Size="Medium" AllowPaging="True" PageSize="5">
                            <Columns>
                                <asp:BoundField DataField="Under_Contractt_English_Type" HeaderText="النوع بالأنكليزية" />
                                <asp:BoundField DataField="Under_Contract_Arabic_Type" HeaderText="النوع بالعربية" />
                                <asp:HyperLinkField ControlStyle-CssClass="btn btn-success" Text="تعديل" DataNavigateUrlFields="Under_Contract_Id" DataNavigateUrlFormatString="Edit_Under_Contract_Type.aspx?Id={0}">
                                    <ControlStyle CssClass="btn btn-success"></ControlStyle>
                                </asp:HyperLinkField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="btn btn-danger" ID="btn_Under_Contract_Type_Delete" runat="server" CommandArgument='<%# Eval("Under_Contract_Id") %>' OnClick="Delete_Under_Contract_Type"><i class="fa fa-trash"></i> حذف</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
            <button style="background-color:#52a2da; color:white; border-style:none; height:40px; border-radius:7px;" runat="server" onserverclick="GoToAddBuildinType"><i class="fa fa-plus-circle" aria-hidden="true"></i> إضافة نوع بموجب عقد جديد</button>
        </div>
    </div>
    <!---Container Fluid-->
</asp:Content>
