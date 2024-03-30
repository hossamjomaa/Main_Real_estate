<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Ashraf.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Ashraf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptCustomers" runat="server" OnItemDataBound="OnItemDataBound">
        <HeaderTemplate>
            <table class="Grid" cellspacing="0" rules="all" border="1">
                <tr>
                    <th scope="col">&nbsp;
                    </th>
                    <th scope="col" style="width: 150px">Contact Name
                    </th>
                    <th scope="col" style="width: 150px">City
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <img src="Main_Image/Calander_Close.png" style="width:30px; height:30px;"/>
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        <asp:Repeater ID="rptOrders" runat="server">
                            <HeaderTemplate>
                                <table class="ChildGrid" cellspacing="0" rules="all" border="1">
                                    <tr>
                                        <th scope="col" style="width: 150px">Order Id
                                        </th>
                                        <th scope="col" style="width: 150px">Date
                                        </th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="Owner_Ship_Id" runat="server" Text='<%# Eval("Owner_Ship_Id") %>' />
                                        <asp:Label ID="lblOrderId" runat="server" Text='<%# Eval("owner_ship_Code") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                    <asp:HiddenField ID="hfCustomerId" runat="server" Value='<%# Eval("Owner_Ship_Id") %>' />
                </td>
                <td>
                    <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("Building_NO") %>' />
                </td>
                <td>
                    <asp:Label ID="lblCity" runat="server" Text='<%# Eval("Building_Value") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>





    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $("body").on("click", "[src*=plus]", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "images/minus.png");
    });
    $("body").on("click", "[src*=minus]", function () {
        $(this).attr("src", "images/plus.png");
        $(this).closest("tr").next().remove();
    });
</script>
</asp:Content>
