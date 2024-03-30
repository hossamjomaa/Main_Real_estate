<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Rental_Disclosure.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Rental_Disclosure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        td, th {
            border-style: solid;
            text-align: center;
            padding: 15px;
        }
        .UUL {
            list-style-type: none;
            margin: auto;
            padding: 0;
            overflow: hidden;
            background-color: #52a2da;
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

      <ul class="UUL">
        <li><a runat="server" id="A_1" onserverclick="A_1_ServerClick">كشف مؤجرات العقود المفردة</a></li>
        <li><a runat="server" id="A_2" onserverclick="A_2_ServerClick">كشف مؤجرات العقود المجملة</a></li>
        <li><a runat="server" id="A_3" onserverclick="A_3_ServerClick">كشف مؤجرات للكل</a></li>
    </ul>
    <br />
     <div class="row">
                <div class="col-lg-1">
                    <br />
                </div>
                <div class="col-lg-2">
                    <div class="form-group">
                        <asp:Label ID="lbl_Ownershi_Code" runat="server" Text="كود الملكية" />
                        <asp:DropDownList ID="Ownershi_Code_DropDownList" runat="server" CssClass="form-control" DataTextField="Text" AutoPostBack="true" OnSelectedIndexChanged="Ownershi_Code_DropDownList_SelectedIndexChanged" />
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <asp:Label ID="lbl_wnershi_Name" runat="server" Text="اسم الملكية" />
                        <asp:DropDownList ID="Ownershi_Name_DropDownList" runat="server" CssClass="form-control" DataTextField="Text" AutoPostBack="true" OnSelectedIndexChanged="Ownershi_Name_DropDownList_SelectedIndexChanged" />
                    </div>
                </div>
                <div class="col-lg-2">
                    <div class="form-group">
                        <asp:Label ID="lbl_Building_No" runat="server" Text="رقم العقار" />
                        <asp:DropDownList ID="Building_No_DropDownList" runat="server" CssClass="form-control" DataTextField="Text"  />
                    </div>
                </div>
                <div class="col-lg-2">
                    <div class="form-group">
                        <asp:Label ID="lbl_Street_No" runat="server" Text="رقم الشارع" />
                        <asp:DropDownList ID="Street_N_DropDownList" runat="server" CssClass="form-control" DataTextField="Text" AutoPostBack="true" OnSelectedIndexChanged="Street_N_DropDownList_SelectedIndexChanged" />
                    </div>
                </div>
            </div>
            <asp:Label ID="Quari" runat="server" Visible="true" />
    <%-----------------------------------------------------------------------------------------------------------%>
    <div class="container-fluid" id="container-wrapper">
        <div runat="server" id="Unit_Contract_Div">
            <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titelt" runat="server" Text="كشف المؤجرات  المفردة : "></asp:Label>&nbsp;&nbsp;
            </h1>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Excel" OnClick="Button1_Click" /><br /> <br />
        <div class="row" style="font-size: 10px">
            <div class="col-lg-12 mb-4">

                <asp:Repeater ID="Header_Repeater" runat="server">
                    <ItemTemplate>
                        <div class="card" style="padding: 20px">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("owner_ship_Code") %>' Font-Size="20px" Font-Bold="true"></asp:Label>
                            <table>
                                <tr>
                                    <th>
                                        <asp:Label ID="lbl_Building_Id" runat="server" Text='<%# Eval("Building_Id") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>'></asp:Label>&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("owner_ship_Code") %>'></asp:Label>&nbsp;&nbsp;- المالك :&nbsp;
                                        <asp:Label ID="lbl_Owner_Arabic_name" runat="server" Text='<%# Eval("Owner_Arabic_name") %>'></asp:Label>&nbsp;&nbsp;- عقار :&nbsp;
                                        <asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Eval("Building_NO") %>'></asp:Label>&nbsp;&nbsp;- بشارع :&nbsp;
                                        <asp:Label ID="lbl_Street_Name" runat="server" Text='<%# Eval("Street_Name") %>'></asp:Label>
                                        <asp:Label ID="lbl_Street_NO" runat="server" Text='<%# Eval("Street_NO") %>'></asp:Label>
                                    </th>
                                </tr>

                                <tr>
                                    <%------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                                    <asp:Repeater ID="Body_Repeater" runat="server" ClientIDMode="Static">
                                        <HeaderTemplate>
                                            <table>
                                                <thead>
                                                    <th>رقم / نوع الوحدة</th>
                                                    <th>التصنيف</th>
                                                    <th>الحالة</th>
                                                    <th>عداد الكهرباء</th>
                                                    <th>عداد الماء</th>
                                                    <th>المستأجر</th>
                                                    <th>الهاتف</th>
                                                    <th>ص.ب</th>
                                                    <th>مدة الإيجار</th>
                                                    <th>بداية الإيجار</th>
                                                    <th>نهايةالإيجار</th>
                                                    <th>مبلغ الإيجار</th>
                                                    <th>طريقة السداد</th>
                                                    <th>ملاحظات</th>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Unit_Number" runat="server" Text='<%# Eval("Unit_Number") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Unit_Arabic_Detail" runat="server" Text='<%# Eval("Unit_Arabic_Detail") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Unit_Arabic_Condition" runat="server" Text='<%# Eval("Unit_Arabic_Condition") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Electricityt_Number" runat="server" Text='<%# Eval("Electricityt_Number") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Water_Number" runat="server" Text='<%# Eval("Water_Number") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Tenants_Mobile" runat="server" Text='<%# Eval("Tenants_Mobile") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_P_O_Box" runat="server" Text='<%# Eval("P_O_Box") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Number_Of_Years" runat="server" Text='<%# Eval("Number_Of_Years") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Start_Date" runat="server" Text='<%# Eval("Start_Date") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Payment_Amount" runat="server" Text='<%# Eval("Payment_Amount") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Paymen_Method" runat="server" Text='<%# Eval("Paymen_Method") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Contract_Details" runat="server" Text='<%# Eval("Contract_Details") %>'></asp:Label></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <%------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        </div>
        
       <%-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++  كشف المؤجرات المجملة *****************************************************************************************************************--%>
        <div runat="server" id="Building_Contract_Div" visible="false">
            <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_B_titel" runat="server" Text="كشف المؤجرات  المجملة : "></asp:Label>&nbsp;&nbsp;
            </h1>
        </div>
        <asp:Button ID="Button2" runat="server" Text="Excel" OnClick="Button2_Click" /><br /> <br />
        <div class="row" style="font-size: 10px">
            <div class="col-lg-12 mb-4">

                <asp:Repeater ID="B_Header_Repeater" runat="server">
                    <ItemTemplate>
                        <div class="card" style="padding: 20px">
                            <table>
                                <tr>
                                    <th>
                                        <asp:Label ID="lbl_Building_Id" runat="server" Text='<%# Eval("Building_Id") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>'></asp:Label>&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("owner_ship_Code") %>'></asp:Label>&nbsp;&nbsp;- المالك :&nbsp;
                                        <asp:Label ID="lbl_Owner_Arabic_name" runat="server" Text='<%# Eval("Owner_Arabic_name") %>'></asp:Label>&nbsp;&nbsp;- عقار :&nbsp;
                                        <asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Eval("Building_NO") %>'></asp:Label>&nbsp;&nbsp;- بشارع :&nbsp;
                                        <asp:Label ID="lbl_Street_Name" runat="server" Text='<%# Eval("Street_Name") %>'></asp:Label>
                                        <asp:Label ID="lbl_Street_NO" runat="server" Text='<%# Eval("Street_NO") %>'></asp:Label>
                                    </th>
                                </tr>

                                <tr>
                                    <%------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                                    <asp:Repeater ID="B_Body_Repeater" runat="server" ClientIDMode="Static">
                                        <HeaderTemplate>
                                            <table>
                                                <thead>
                                                    <th>رقم / نوع الوحدة</th>
                                                    <th>التصنيف</th>
                                                    <th>الحالة</th>
                                                    <th>عداد الكهرباء</th>
                                                    <th>عداد الماء</th>
                                                    <th>المستأجر</th>
                                                    <th>الهاتف</th>
                                                    <th>ص.ب</th>
                                                    <th>مدة الإيجار</th>
                                                    <th>بداية الإيجار</th>
                                                    <th>نهايةالإيجار</th>
                                                    <th>مبلغ الإيجار</th>
                                                    <th>طريقة السداد</th>
                                                    <th>ملاحظات</th>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Unit_Number" runat="server" Text='<%# Eval("Unit_Number") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Unit_Arabic_Detail" runat="server" Text='<%# Eval("Unit_Arabic_Detail") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Unit_Arabic_Condition" runat="server" Text='<%# Eval("Unit_Arabic_Condition") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Electricityt_Number" runat="server" Text='<%# Eval("Electricityt_Number") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Water_Number" runat="server" Text='<%# Eval("Water_Number") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Tenants_Mobile" runat="server" Text='<%# Eval("Tenants_Mobile") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_P_O_Box" runat="server" Text='<%# Eval("P_O_Box") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Number_Of_Years" runat="server" Text='<%# Eval("Number_Of_Years") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Start_Date" runat="server" Text='<%# Eval("Start_Date") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Payment_Amount" runat="server" Text='<%# Eval("Payment_Amount") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Paymen_Method" runat="server" Text='<%# Eval("Paymen_Method") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Contract_Details" runat="server" Text='<%# Eval("Contract_Details") %>'></asp:Label></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <%------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                                </tr>
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
</asp:Content>
