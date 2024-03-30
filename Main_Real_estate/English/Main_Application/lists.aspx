<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="lists.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.lists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        td, th {
            border-style: solid;
            text-align: center;
            padding: 15px;
        }
    </style>


    <style>
        .UUL {
            list-style-type: none;
            margin: auto;
            padding: 0;
            overflow: hidden;
            background-color: #52a2da;
            height:65px;
        }

        li {
            float: right;
        }

        li a {
            display: block;
            color: white;
            text-align: center;
            padding-left: 50px;
            padding-right:15px;
            padding-top : 16px;
            padding-bottom : 16px;
            text-decoration: none;
        }

    </style>
    <%-----------------------------------------------------------------------------------------------------------%>

    <ul class="UUL">
        <li><a runat="server" id="A_1" onserverclick="A_1_ServerClick">ملكيات</a></li>
        <li><a runat="server" id="A_2" onserverclick="A_2_ServerClick">أبنية</a></li>
        <li><a runat="server" id="A_3" onserverclick="A_3_ServerClick">وحدات</a></li>
        <li><a runat="server" id="A_4" onserverclick="A_4_ServerClick">الكل</a></li>
        <li style="margin-right:200px">
            <asp:Label ID="Label2" runat="server" Text="فرز حسب معلومات / مرفقات / الكل" ForeColor="White"></asp:Label><br />
            <asp:DropDownList ID="Filter_DropDownList" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Value="1" Text="الكل"></asp:ListItem>
                <asp:ListItem Value="2" Text="معلومات"></asp:ListItem>
                <asp:ListItem Value="3" Text="مرفقات"></asp:ListItem>
            </asp:DropDownList> 

        </li>
    </ul>

    <br />


    <div class="container-fluid" id="OS" runat="server" style="border-style: solid; padding-right: 50px">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_Ownership_titelt" runat="server" Text=" القوائم و الحقول الغير مدخلة في الملكيات"></asp:Label>&nbsp;&nbsp;
            </h1>
        </div>
        <div class="row">
            <div class="col-lg-12 mb-4">
                <asp:Repeater ID="Ownership_Repeater_2" runat="server" >
                    <ItemTemplate>
                    </ItemTemplate>
                    </asp:Repeater>









                <asp:Repeater ID="Ownership_Repeater" runat="server" OnItemDataBound="Ownership_Repeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="row" runat="server" id="Ownership_Div" style="border-bottom-style: solid; padding-bottom: 10px; padding-top: 10px; border-width: thin">
                            <div class="col-lg-9">
                                <div style="display: inline-block;" runat="server" id="Div1">
                                    <asp:Label ID="lbl_Ownership_Name" runat="server" Font-Size="20px" Font-Bold="true" ForeColor="Blue" Text='<%# Eval("Owner_Ship_AR_Name") %>'></asp:Label>&nbsp;&nbsp;:&nbsp;&nbsp;
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Bond_NO_div">
                                    <asp:Label ID="lbl_Bond_NO" runat="server" Text='<%# Eval("Bond_NO") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="owner_Owner_Id_div">
                                    <asp:Label ID="lbl_owner_Owner_Id" runat="server" Text='<%# Eval("owner_Owner_Id") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Parcel_Area_div">
                                    <asp:Label ID="lbl_Parcel_Area" runat="server" Text='<%# Eval("Parcel_Area") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Street_Name_div">
                                    <asp:Label ID="lbl_Street_Name" runat="server" Text='<%# Eval("Street_Name") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server">
                                    <asp:Label ID="lbl_Street_NO" runat="server" Text='<%# Eval("Street_NO") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Certificate_div">
                                    <asp:Label ID="lbl_owner_ship_Certificate" runat="server" Text='<%# Eval("Certificate") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Scheme_div">
                                    <asp:Label ID="lbl_Property_Scheme" runat="server" Text='<%# Eval("Scheme") %>'></asp:Label>
                                </div>
                            </div>

                            <asp:LinkButton CssClass="btn btn-success" runat="server" OnClick="Edit_Ownership" CommandArgument='<%# Eval("Owner_Ship_Id") %>'> <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <br />
    <br />
    <%--******************************************************************************** Building Lists ***************************************************************************************--%>
    <div class="container-fluid" id="B" runat="server" style="border-style: solid; padding-right: 50px">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_Building_titelt" runat="server" Text=" القوائم و الحقول الغير مدخلة في الأبنية"></asp:Label>&nbsp;&nbsp;
            </h1>
        </div>
        <div class="row">
            <div class="col-lg-12 mb-4">
                <asp:Repeater ID="Building_Repeater" runat="server" OnItemDataBound="Building_Repeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="row" runat="server" id="Building_Div" style="border-bottom-style: solid; padding-bottom: 10px; padding-top: 10px; border-width: thin">
                            <div class="col-lg-9">
                                <div style="display: inline-block;" runat="server">
                                    <asp:Label ID="lbl_Ownership_Name" runat="server" Font-Size="20px" Font-Bold="true" ForeColor="Blue" Text='<%# Eval("Building_Arabic_Name") %>'></asp:Label>&nbsp;:
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Bond_NO_div">
                                    <asp:Label ID="lbl_Building_NO" runat="server" Text='<%# Eval("Building_NO") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Owner_Arabic_name_div">
                                    <asp:Label ID="lbl_Construction_Area" runat="server" Text='<%# Eval("Construction_Area") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Parcel_Area_div">
                                    <asp:Label ID="lbl_Maintenance_status" runat="server" Text='<%# Eval("Maintenance_status") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Street_Name_div">
                                    <asp:Label ID="lbl_electricity_meter" runat="server" Text='<%# Eval("electricity_meter") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Street_NO_div">
                                    <asp:Label ID="lbl_Water_meter" runat="server" Text='<%# Eval("Water_meter") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Certificate_div">
                                    <asp:Label ID="lbl_Construction_Completion_Date" runat="server" Text='<%# Eval("Construction_Completion_Date") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Scheme_div">
                                    <asp:Label ID="lbl_Building_Photo" runat="server" Text='<%# Eval("Building_Photo") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Div2">
                                    <asp:Label ID="lbl_Entrance_Photo" runat="server" Text='<%# Eval("Entrance_Photo") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Div3">
                                    <asp:Label ID="lbl_Statement" runat="server" Text='<%# Eval("Statement") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Div4">
                                    <asp:Label ID="lbl_Building_Permit" runat="server" Text='<%# Eval("Building_Permit") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Div5">
                                    <asp:Label ID="lbl_certificate_of_completion" runat="server" Text='<%# Eval("certificate_of_completion") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Div6">
                                    <asp:Label ID="lbl_Map" runat="server" Text='<%# Eval("Map") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server" id="Div7">
                                    <asp:Label ID="lbl_Plan" runat="server" Text='<%# Eval("Plan") %>'></asp:Label>
                                </div>
                            </div>

                            <asp:LinkButton CssClass="btn btn-success" runat="server" OnClick="Edit_Building" CommandArgument='<%# Eval("Building_Id") %>'> <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <br />
    <br />
    <%--******************************************************************************** Unit Lists ***************************************************************************************--%>
    <div class="container-fluid" id="U" runat="server" style="border-style: solid; padding-right: 50px">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="Label1" runat="server" Text=" القوائم و الحقول الغير مدخلة في الملكيات"></asp:Label>&nbsp;&nbsp;
            </h1>
        </div>
        <div class="row">
            <div class="col-lg-12 mb-4">
                <asp:Repeater ID="Units_Repeater" runat="server" OnItemDataBound="Units_Repeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="row" runat="server" id="Unit_Div" style="border-bottom-style: solid; padding-bottom: 10px; padding-top: 10px; border-width: thin">
                            <div class="col-lg-9">
                                <div style="display: inline-block;" runat="server">
                                    <asp:Label ID="lbl_Unit_Number" runat="server" Font-Size="20px" Font-Bold="true" ForeColor="Blue" Text='<%# Eval("Unit_Number") %>'></asp:Label>&nbsp;&nbsp;:&nbsp;&nbsp;
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server">
                                    <asp:Label ID="lbl_current_situation" runat="server" Text='<%# Eval("current_situation") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server">
                                    <asp:Label ID="lbl_Oreedo_Number" runat="server" Text='<%# Eval("Oreedo_Number") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server">
                                    <asp:Label ID="lbl_Electricityt_Number" runat="server" Text='<%# Eval("Electricityt_Number") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server">
                                    <asp:Label ID="lbl_Water_Number" runat="server" Text='<%# Eval("Water_Number") %>'></asp:Label>
                                </div>
                                <%-----------------------------------------------------------------------------------------------------------%>
                                <div style="display: inline-block" runat="server">
                                    <asp:Label ID="lbl_virtual_Value" runat="server" Text='<%# Eval("virtual_Value") %>'></asp:Label>
                                </div>
                            </div>

                            <asp:LinkButton CssClass="btn btn-success" runat="server" OnClick="Edit_Units" CommandArgument='<%# Eval("Unit_ID") %>'> <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
