<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="transformation_Bank_List.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.transformation_Bank_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Container Fluid-->
    <div class="container-fluid" id="container-wrapper">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Bank_List" runat="server" Text="قائمة مصارف الحوالات"></asp:Label>
            </h1>

            <button style="background-color:#52a2da; color:white; border-style:none; height:40px; border-radius:7px;" runat="server" onserverclick="Unnamed_ServerClick"><i class="fa fa-plus-circle" aria-hidden="true"></i>إضافة مصرف جديد</button>
        </div>

        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" style="border-radius: 10px;">
                        <asp:GridView AutoGenerateColumns="false" ID="Bank_GridView1" runat="server" CssClass="table align-items-center table-flush" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="Black">
                            <Columns>
                                <asp:BoundField DataField="Bank_No" HeaderText="رقم المصرف" />
                                <asp:BoundField DataField="Bank_Name" HeaderText="اسم المصرف " />
                                <asp:BoundField DataField="Account_No" HeaderText="رقم الحساب" />
                                <asp:BoundField DataField="Soaft_Code_No" HeaderText="سوفت كود" />
                                <asp:BoundField DataField="Bank_Adress" HeaderText="العنوان" />
                                <asp:BoundField DataField="currency_type" HeaderText="العملة" />
                                <asp:BoundField DataField="Beneficiary_Name" HeaderText="اسم المستفيد" />




                                <asp:HyperLinkField ControlStyle-CssClass="btn btn-success" Text="تعديل" DataNavigateUrlFields="transformation_Bank_ID" DataNavigateUrlFormatString="Edit_transformation_Bank.aspx?Id={0}">
                                    <ControlStyle CssClass="btn btn-success"></ControlStyle>

                                </asp:HyperLinkField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="btn btn-danger" ID="btn_Bank_Delete" runat="server" CommandArgument='<%# Eval("transformation_Bank_ID") %>' OnClick="btn_Bank_Delete_Click"><i class="fa fa-trash"></i> حذف</asp:LinkButton>
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
            

        </div>
    </div>
    <!---Container Fluid-->
</asp:Content>
