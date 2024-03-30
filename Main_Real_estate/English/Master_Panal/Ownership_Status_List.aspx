<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Ownership_Status_List.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Ownership_Status_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Container Fluid-->
    <div class="container-fluid" id="container-wrapper">
        <div class="row" style="height: 70px">
            <div class="col-lg-3 mb-5" style="height: 40px">
                <div class="d-sm-flex align-items-center justify-content-between mb-4">
                    <h1 class="h3 mb-0 text-gray-800">
                        <asp:Label ID="lbl_titel_Ownership_Status_List" runat="server" Text="قائمة حالات الملكيات"></asp:Label>
                        <asp:Image ID="Image1" Height="20px" Width="20" Visible="false" runat="server" />
                    </h1>
                </div>
            </div>
            <div class="col-lg-4 mb-5" style="height: 40px; top:40px">
                <div class="d-sm-flex align-items-center justify-content-between mb-4">
                    <div class="form-group">
                        <asp:Label ID="lbl_En_Asset_Condition_Name" runat="server" Text="طريقة عرض المحتويات"></asp:Label>
                    <h4>
                        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Text="كل الملكيات في صفحة واحدة" Value="10000"></asp:ListItem>
                            <asp:ListItem Text="5 ملكيات في الصفحة" Value="5"></asp:ListItem>
                            <asp:ListItem Text="10 ملكيات في الصفحة" Value="10"></asp:ListItem>
                            <asp:ListItem Text="20 ملكيات في الصفحة" Value="20"></asp:ListItem>
                            <asp:ListItem Text="30 ملكيات في الصفحة" Value="30"></asp:ListItem>
                            <asp:ListItem Text="40 ملكيات في الصفحة" Value="40"></asp:ListItem>
                            <asp:ListItem Text="50 ملكيات في الصفحة" Value="50"></asp:ListItem>
                        </asp:DropDownList>
                    </h4>
                    </div>&nbsp;&nbsp;&nbsp;
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="طريقة الفرز"></asp:Label>
                     <h4>
                        <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                            <asp:ListItem Text="إختر طريقة الفرز"    Value="0"></asp:ListItem>
                            <asp:ListItem Text="تصاعدي عربي"    Value="1"></asp:ListItem>
                            <asp:ListItem Text="تنازلي عربي"    Value="2"></asp:ListItem>
                            <asp:ListItem Text="تصاعدي إنكليزي" Value="3"></asp:ListItem>
                            <asp:ListItem Text="تنازلي إنكليزي" Value="4"></asp:ListItem>
                            <asp:ListItem Text="تصاعدي الرقم"   Value="5"></asp:ListItem>
                            <asp:ListItem Text="تنازلي الرقم"   Value="6"></asp:ListItem>
                        </asp:DropDownList>
                    </h4>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 mb-5" style="height: 40px; margin-right:70px;top:65px">
                <div>
                    <div class="row">
                        <div class="col-lg-0 mb-5">
                            <%--<asp:Button ID="Button1" Height="42px" runat="server" Text="بحث"/>--%>
                            <button style="background-color: #716e6e; color: white; border-style: none; width: 70px; height: 42px; border-radius: 7px;" runat="server" onserverclick="Unnamed_ServerClick"><i class="fa fa-search" aria-hidden="true"></i>بحث </button>
                        </div>
                        <div class="col-lg-8 mb-5">
                            <asp:TextBox ID="txt_Search_In_Ownership_Status" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <button style="background-color: #52a2da; color: white; border-style: none; height: 40px; border-radius: 7px;" runat="server" onserverclick="GoToAddBuildinType"><i class="fa fa-plus-circle" aria-hidden="true"></i>إضافة حالة ملكية جديدة</button>
        <br />
        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" style="border-radius: 10px;">
                        <%--AllowSorting="True"   OnSorting="GridView1_Sorting"   CurrentSortField="ownership_status_id"--%>
                        <asp:GridView ID="Ownership_Status_GridView1" runat="server" AutoGenerateColumns="False" 
                            AllowPaging="true" PageSize="10" 
                            OnPageIndexChanging="Ownership_Status_GridView1_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                            BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Horizontal" Font-Size="Medium" CssClass="table align-items-center table-flush">

                            <Columns>


                                <%--<asp:TemplateField HeaderText="ownership_status_id" SortExpression="ownership_status_id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("ownership_status_id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:BoundField HtmlEncode="false" SortExpression="ownership_english_status" DataField="ownership_english_status" HeaderText="حالةعربي" />
                                <asp:BoundField HtmlEncode="false" SortExpression="ownership_arabic_status" DataField="ownership_arabic_status" HeaderText="حالةإنكليزي" />
                                <asp:BoundField HtmlEncode="false" SortExpression="ownership_status_id" DataField="ownership_status_id" HeaderText="ownership_status_id" />

                                <asp:HyperLinkField SortExpression=" " HeaderText=" " ControlStyle-CssClass="btn btn-success" Text="تعديل" DataNavigateUrlFields="ownership_status_id" DataNavigateUrlFormatString="Edit_Ownership_Status.aspx?Id={0}">
                                    <ControlStyle CssClass="btn btn-success"></ControlStyle>
                                </asp:HyperLinkField>

                                <asp:TemplateField SortExpression=" " HeaderText=" ">
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="btn btn-danger" ID="btn_Ownership_Status_Delete" runat="server" OnClick="Delete_Ownership_Status" CommandArgument='<%# Eval("Ownership_Status_Id") %>'><i class="fa fa-trash"></i> حذف</asp:LinkButton>
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
