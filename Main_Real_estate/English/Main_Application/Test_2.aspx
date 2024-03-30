<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Test_2.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Test_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>







    <asp:Repeater ID="ownership_List" runat="server" ClientIDMode="Static">
        <ItemTemplate>
            <div id="'<%# Eval("owner_ship_Code") %>'">

                <div>
                    <asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("zone_number") %>' /> &nbsp;&nbsp;| &nbsp;&nbsp;  
                    <asp:Label ID="lbl_zone_arabic_name" runat="server" Text='<%# Eval("zone_arabic_name") %>' /> &nbsp;&nbsp;| &nbsp;&nbsp; 
                    <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("owner_ship_Code") %>' />&nbsp;&nbsp;| &nbsp;&nbsp; 
                    <asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' />&nbsp;&nbsp;| &nbsp;&nbsp;
                </div>
                <div>
                    <p>XXXXXXXXXXXXXXXXXXXXXXXXXXXX</p>
                    <p>YYYYYYYYYYYYYYYYYYYYYYYYYYYY</p>
                </div>
            </div>


               <script>
                   $(function () {
                       $("'#<%#Eval("owner_ship_Code")%>'").accordion({
                           collapsible: true,
                           active: 'none'
                       });
                   });
               </script>
        </ItemTemplate>
    </asp:Repeater>








 
</asp:Content>
