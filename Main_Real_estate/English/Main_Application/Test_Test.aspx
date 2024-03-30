<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Test_Test.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Test_Test" %>

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

        tr:nth-child(even) {
            background-color: #dddddd;
        }
    </style>



    <div class="container-fluid" id="container-wrapper">
        <div class="row">
            <div class="col-lg-12 mb-4">
                <asp:Repeater ID="OwnerShip_Repeater" runat="server">
                    <ItemTemplate>
                        <div class="card">
                        <table>
                            <thead>
                                <th>رقم المنطقة</th>
                                <th>اسم المنطقة</th>
                                <th>كود الملكية </th>
                                <th>اسم الملكية</th>
                                <th style="width: 100px; text-align: center">المالك</th>
                                <th>الرقم المساحي</th>
                                <th>المساحة</th>
                                <th>سند الملكية</th>
                                <th>عدد المباني</th>
                                <th style="width: 300px; text-align: center;">نوع الوحدات</th>
                                <th>قيمة الأرض</th>
                                <th></th>
                            </thead>
                            <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("zone_number") %>' />
                                <asp:Label ID="Owner_Ship_Id" runat="server" Text='<%# Eval("Owner_Ship_Id") %>' />

                            </td>
                            <td>
                                <asp:Label ID="lbl_zone_arabic_name" runat="server" Text='<%# Eval("zone_arabic_name") %>' /></td>
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
                            <td>
                                <asp:Label ID="lbl_Land_Value" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Land_Value")))%>' /></td>
                            <td>
                                <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="Show_Building" OnClick="Show_Building"> <i class="fa fa-plus" style="font-size:18px;"></i> </asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-primary" Visible="false" runat="server" ID="Hide_Building" OnClick="Hide_Building"> <i class="fa fa-minus" style="font-size:18px;"></i> </asp:LinkButton>
                            </td>
                        </tr>

                        <%-----------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                                    <asp:Repeater ID="Building_Repeater" runat="server" Visible="false">
                                        <HeaderTemplate>
                                            <table>
                                                <thead>
                                                    <th>البناء</th>
                                                    <th>رقم البناء</th>
                                                    <th>مساحة البناء </th>
                                                    <th>وضع الصيانة</th>
                                                    <th>اسم الملكية</th>
                                                    <th>حالة البناء</th>
                                                    <th>نوع البناء</th>
                                                    <th style="width: 300px; text-align: center;">نوع الوحدات</th>
                                                    <th>قيمة البناء</th>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("Building_Arabic_Name") %>' /></td>
                                                <td>
                                                    <asp:Label ID="lbl_zone_arabic_name" runat="server" Text='<%# Eval("Building_NO") %>' /></td>
                                                <td>
                                                    <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("Construction_Area") %>' /></td>

                                                <td>
                                                    <asp:Label ID="lbl_PIN_Number" runat="server" Text='<%# Eval("Maintenance_status") %>' /></td>
                                                <td>
                                                    <asp:Label ID="lbl_Bond_NO" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                                <td>
                                                    <asp:Label ID="lbl_Parcel_Area" runat="server" Text='<%# Eval("Building_Arabic_Condition") %>' /></td>
                                                <td>
                                                    <asp:Label ID="lbl_Building_Arabic_Type" runat="server" Text='<%# Eval("Building_Arabic_Type") %>' /></td>
                                               
                                                <td>
                                                    <asp:Label ID="lbl_Building_Value" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Building_Value")))%>' /></td>

                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                             </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </tr>
                        <%-----------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                                </table>
                            </div>
                        <hr />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
