<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Tenant_Disclosure_Test.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Tenant_Disclosure_Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            text-align: center !important;
            font-size: 13px !important;
            padding: 7px !important;
        }
        th {background-color: #52a2da; color: #fff;text-align: center; }
        .UUL {
            list-style-type: none;
            margin: auto;
            padding: 0;
            overflow: hidden;
            background-color: #52a2da;
            border-radius: .375rem .375rem 0 0;
        }
        .UUL li { float: right;}
        .UUL li a {
            display: block;
            color: white;
            text-align: center;
            padding-left: 50px;
            padding-right: 15px;
            padding-top: 16px;
            padding-bottom: 16px;
            text-decoration: none;
        }
        .UUL li a:hover { background-color: #61aadd;color: #fff;}
        .right-spaced { margin-right: 20px }
    </style>
    <%----------------------------------------------------------------------------------------------%>
    <div class="container-fluid" id="container-wrapper">
        <div class="row">
            <div class="col-lg-4 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Tenants_List" runat="server" Text="كشف المستأجرين"></asp:Label>
                </h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div id="Grid">
                        <ul class="UUL">
                            <li><a runat="server" id="A_3" onserverclick="A_3_ServerClick">كشف مستأجرين للكل</a></li>
                            <li><a runat="server" id="A_1" onserverclick="A_1_ServerClick">كشف مستأجرين العقود المفردة</a></li>
                            <li><a runat="server" id="A_2" onserverclick="A_2_ServerClick">كشف مستأجرين العقود المجملة</a></li>
                        </ul>
                        <asp:Label ID="Typee" runat="server" />
                        <br />
                        <div class="row" style="padding: 20px">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Tenant_Name" runat="server" Text="اسم المستأجر"></asp:Label><br />
                                    <asp:DropDownList ID="Tenant_Name_DropDownList" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="Tenant_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <span runat="server" id="U_C_Span" style="font-size: 30px; margin-right: 20px">
                            <asp:Label ID="lbl_titelt" runat="server" Text="كشف المستأجرين" />
                        </span>
                        <br />
                        <br />
                        <asp:Button ID="Excel" runat="server" Text="Excel" OnClick="Excel_Click" CssClass="btn btn-secondary right-spaced" /><br />
                        <div class="row" style="">
                            <div class="col-lg-12 mb-4">
                                <asp:Repeater ID="Header_Repeater" runat="server">
                                    <ItemTemplate>
                                        <div class="card" style="padding: 20px">
                                            <table class="datatable table table-striped table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th style="background-color: #0779c9; color: white; font-size: 16px !important;" colspan="15">
                                                            <asp:Label ID="lbl_tenants_Tenants_ID" runat="server" Text='<%# Eval("tenants_Tenants_ID") %>' Visible="false"></asp:Label>&nbsp;&nbsp; اسم المستأجر :&nbsp;
                                                            <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label>&nbsp;&nbsp;/ جنسية المستأجر :&nbsp;
                                                            <asp:Label ID="lbl_Arabic_nationality" runat="server" Text='<%# Eval("Arabic_nationality") %>'></asp:Label>&nbsp;&nbsp;/ موبايل المستأجر :&nbsp;
                                                            <asp:Label ID="lbl_Tenants_Mobile" runat="server" Text='<%# Eval("Tenants_Mobile") %>'></asp:Label>
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <%------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                                                        <asp:Repeater ID="Body_Repeater" runat="server" ClientIDMode="Static">
                                                            <HeaderTemplate>
                                                                <tr>
                                                                    <th>رمز الملكية</th>
                                                                    <th>اسم الملكية</th>
                                                                    <th>اسم البناء</th>
                                                                    <th>رقم البناء</th>
                                                                    <th>رقم / نوع الوحدة</th>
                                                                    <th>التصنيف</th>
                                                                    <th>الحالة</th>
                                                                    <th>عداد الكهرباء</th>
                                                                    <th>عداد الماء</th>
                                                                    <th>مدة الإيجار</th>
                                                                    <th>بداية الإيجار</th>
                                                                    <th>نهايةالإيجار</th>
                                                                    <th>مبلغ الإيجار</th>
                                                                    <th>طريقة السداد</th>
                                                                    <th>ملاحظات</th>
                                                                </tr>

                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td><asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("owner_ship_Code") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Eval("Building_Arabic_Name") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Building_NO" runat="server" Text='<%# Eval("Building_NO") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Unit_Number" runat="server" Text='<%# Eval("Unit_Number") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Unit_Arabic_Detail" runat="server" Text='<%# Eval("Unit_Arabic_Detail") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Unit_Arabic_Condition" runat="server" Text='<%# Eval("Unit_Arabic_Condition") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Electricityt_Number" runat="server" Text='<%# Eval("Electricityt_Number") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Water_Number" runat="server" Text='<%# Eval("Water_Number") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Number_Of_Years" runat="server" Text='<%# Eval("Number_Of_Years") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Start_Date" runat="server" Text='<%# Eval("Start_Date") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Payment_Amount" runat="server" Text='<%# Eval("Payment_Amount") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Paymen_Method" runat="server" Text='<%# Eval("Paymen_Method") %>'></asp:Label></td>
                                                                    <td><asp:Label ID="lbl_Contract_Details" runat="server" Text='<%# Eval("Contract_Details") %>'></asp:Label></td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                        <%------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <br />
                                        <br />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
