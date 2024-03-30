<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Test_3.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Test_3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
            border: 1px solid #dddddd;
            text-align: center;
            padding: 8px;
        }
    </style>







    <div class="container-fluid">

       

        <asp:Repeater ID="eeeee" runat="server">
            <ItemTemplate>
                <ul style="background-color: #efefef; min-height: 0px; width: 100%" class="navbar-nav sidebar sidebar-light accordion" id="accordionSidebar">
                    <li class="nav-item" style="padding-bottom: 10px;" runat="server" id="Ownership_Div">
                        <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapse<%# Container.ItemIndex%>name" aria-expanded="true"
                            aria-controls="collapse<%# Container.ItemIndex%>name" style="width: 1268px;">






                            <table>
                                 <tr>
                                    <th>رقم المنطقة</th>
                                    <th>كود الملكية </th>
                                    <th>اسم الملكية</th>
                                    <th>المالك</th>
                                    <th>الرقم المساحي</th>
                                    <th>المساحة</th>
                                    <th>سند الملكية</th>
                                    <th>عدد المباني</th>
                                    <th>نوع الوحدات</th>
                                </tr>
                                
                                <tr>

                                    <td>
                                        <asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("zone_number") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("owner_ship_Code") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Owner_Arabic_name" runat="server" Text='<%# Eval("Owner_Arabic_name") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_PIN_Number" runat="server" Text='<%# Eval("PIN_Number") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Parcel_Area" runat="server" Text='<%# Eval("Parcel_Area") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Bond_NO" runat="server" Text='<%# Eval("Bond_NO") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("buildingCount") %>' /></td>

                                    <td>
                                        <asp:Label ID="lbl_Unit_Type" runat="server" Text='<%# Eval("Unit_Type") %>' /></td>

                                </tr>
                            </table>


                        </a>





                        <div id="collapse<%# Container.ItemIndex%>name" class="collapse" aria-labelledby="headingForm" data-parent="#accordionSidebar">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="card mb-12">
                                        <div class="card-body">
                                            XXXXXXXXXXXXXXXXX
                                            <br />
                                            YYYYYYYYYYYYY
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </ul>
            </ItemTemplate>
        </asp:Repeater>












    </div>
</asp:Content>
