<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Expenses.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Expenses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.js"></script>
    <script src="../JS/DataTableScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS/DataTableCss.css" rel="stylesheet" />
     <div class="container-fluid" id="container-wrapper" style="margin: auto;">
        <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Expenses" runat="server" Text="المصاريف الإدارية و العقارية و مصاريف الصيانة"></asp:Label>

            </h1>
        </div>
        <hr />
         <!----------------------------------------------------------------------------------------------------------->
         <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <asp:Label ID="lbl_O_B_U" runat="server" Text="المصاريف على مستوى ( ملكية / بناء / وحدة / مصاريف إدارية)"></asp:Label>
                    <asp:DropDownList ID="O_B_U_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="O_B_U_DropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="1" Text="ملكية"></asp:ListItem>
                        <asp:ListItem Value="2" Text="بناء"></asp:ListItem>
                        <asp:ListItem Value="3" Text="وحدة"></asp:ListItem>
                        <asp:ListItem Value="4" Text="مصاريف إدارية"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="O_B_U_RequiredFieldValidator" ControlToValidate="O_B_U_DropDownList"
                        InitialValue="إختر (بناء / وحدة ) ...." runat="server" ValidationGroup="collection_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-12" >
                <div class="form-group">
                    <div class="row">
                        <div class="col-lg">
                            <div class="form-group">
                                <asp:Label ID="lbl_Mounth" runat="server" Text="الشهر"></asp:Label>
                                <asp:DropDownList ID="Mounth_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Mounth_DropDownList_SelectedIndexChanged">
                                    <asp:ListItem Value="13" Text="كل الأشهر"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Jan"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Feb"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Mar"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Apr"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="May "></asp:ListItem>
                                    <asp:ListItem Value="6" Text="Jun"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="Jul"></asp:ListItem>
                                    <asp:ListItem Value="8" Text="Aug"></asp:ListItem>
                                    <asp:ListItem Value="9" Text="Sep"></asp:ListItem>
                                    <asp:ListItem Value="10" Text="Oct"></asp:ListItem>
                                    <asp:ListItem Value="11" Text="Nov"></asp:ListItem>
                                    <asp:ListItem Value="12" Text="Dec"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Mounth_RequiredFieldValidator" ControlToValidate="Mounth_DropDownList"
                                    InitialValue="إختر الشهر ...." runat="server" ValidationGroup="Expenses_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg">
                            <div class="form-group">
                                <asp:Label ID="lbl_Year" runat="server" Text="السنة"></asp:Label>
                                <asp:DropDownList ID="Year_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Year_DropDownList_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Year_DropDownList"
                                    InitialValue="إخترالسنة ...." runat="server" ValidationGroup="Expenses_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-lg" runat="server" id="Ownership_Div">
                            <div class="form-group">
                                <asp:Label ID="lbl_Ownership_Name" runat="server" Text="اسم الملكية"></asp:Label>
                                <asp:DropDownList ID="Ownership_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Ownership_Name_DropDownList_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Ownership_Name_RequiredFieldValidator" ControlToValidate="Ownership_Name_DropDownList"
                                    InitialValue="إختر اسم الملكية ...." runat="server" ValidationGroup="Expenses_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg" runat="server" id="Building_Div" visible="false">
                            <div class="form-group">
                                <asp:Label ID="lbl_Building_Name" runat="server" Text="اسم البناء"></asp:Label>
                                <asp:DropDownList ID="Building_Name_DropDownList" runat="server" CssClass="form-control" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="Building_Name_DropDownList_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Building_Name_RequiredFieldValidator" ControlToValidate="Building_Name_DropDownList"
                                    InitialValue="إختر اسم البناء ...." runat="server" ValidationGroup="Expenses_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-lg" runat="server" id="Unit_Div" visible="false">
                            <div class="form-group">
                                <asp:Label ID="lbl_Unit_Name" runat="server" Text="رقم الوحدة"></asp:Label>
                                <asp:DropDownList ID="Unit_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Unit_Name_DropDownList_SelectedIndexChanged" >
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Unit_Name_RequiredFieldValidator" ControlToValidate="Unit_Name_DropDownList"
                                    InitialValue="إختر رقم الوحدة ...." runat="server" ValidationGroup="collection_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <%--************************************************************************************************************************************************************************************************--%>
                    <div class="row">
                        <div class="col-lg-4" runat="server" id="Management_Expenses_Div" visible="false">
                            <div class="form-group">
                                <asp:Label ID="lbl_Management_Expenses" runat="server" Text="المصاريف الإدارية "></asp:Label>
                                <asp:RegularExpressionValidator ID="Management_Expenses_RegularExpressionValidator" runat="server" ControlToValidate="txt_Management_Expenses"
                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red" ValidationExpression="[0-9 .]+">
                                </asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Management_Expenses" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4" runat="server" id="RealEstate_Expense_Div">
                            <div class="form-group">
                                <asp:Label ID="lbl_RealEstate_Expenses" runat="server" Text="المصاريف العقارية"></asp:Label>
                                <asp:RegularExpressionValidator ID="RealEstate_Expenses_RegularExpressionValidator" runat="server" ControlToValidate="txt_RealEstate_Expenses"
                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red" ValidationExpression="[0-9 .]+">
                                </asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_RealEstate_Expenses" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4" runat="server" id="Maintenance_Expenses_Div">
                            <div class="form-group">
                                <asp:Label ID="lbl_Maintenance_Expenses" runat="server" Text="مصاريف الصيانة"></asp:Label>
                                <asp:RegularExpressionValidator ID="Maintenance_Expenses_RegularExpressionValidator" runat="server" ControlToValidate="txt_Maintenance_Expenses"
                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red" ValidationExpression="[0-9 .]+">
                                </asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Maintenance_Expenses" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        
                    </div>
                    <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:LinkButton ID="Add" runat="server" Text="حفظ" CssClass="btn btn" BackColor="#52a2da" ForeColor="White" Width="248px" OnClick="btn_Add_Expenses_Click" />
                                </div>
                            </div>
                        </div>
                </div>
            </div>
        </div>
         <hr />
         <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" style="border-radius: 10px;" id="Grid">
                        <asp:Repeater ID="The_Table" runat="server" ClientIDMode="Static" OnItemDataBound="The_Table_ItemDataBound">
                        <HeaderTemplate>
                            <table  cellspacing="0" style="width: 100%; font-size:11px" id="Table" class="datatable table table-striped table-bordered">
                                <thead>
                                    <th>إسم الملكية</th>
                                    <th>إسم البناء</th>
                                    <th> رقم الوحدة</th>
                                    <th> الشهر</th>
                                    <th> السنة</th>
                                    <th>المصاريف العقارية</th>
                                    <th>مصاريف الصيانة</th>
                                </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr runat="server" id="row">
                                <td> <asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                <td> <asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Eval("Building_Arabic_Name") %>' /></td>
                                <td> <asp:Label ID="lbl_Unit_Number" runat="server" Text='<%# Eval("Unit_Number") %>' /></td>
                                <td> <asp:Label ID="lbl_Mounth" runat="server" Text='<%# Eval("Mounth") %>' /></td>
                                <td> <asp:Label ID="lbl_Year" runat="server" Text='<%# Eval("Year") %>' /></td>
                                <td> <asp:Label ID="lbl_RealEstate_Expenses" runat="server" Text='<%# Eval("RealEstate_Expenses") %>' /></td>
                                <td> <asp:Label ID="lbl_Maintenance_Expenses" runat="server" Text='<%# Eval("Maintenance_Expenses") %>' /></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>

                    </div>
                </div>
            </div>
        </div>


    </div>
</asp:Content>
