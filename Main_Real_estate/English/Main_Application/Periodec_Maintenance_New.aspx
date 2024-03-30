<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Periodec_Maintenance_New.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Periodec_Maintenance_New" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link href="../CSS/DataTableCss.css" rel="stylesheet" />
     <%--***********************************************************************************************--%>
    <!-- Container Fluid-->
    <div id="Row"></div>
    <div class="container-fluid" id="container-wrapper">
        <asp:Label ID="lbl_Add_Maintenance" Font-Size="25px" runat="server"></asp:Label>

        <div class="row" runat="server" visible="false" id="Add">
            <div class="col-lg-3">
                <div class="form-group">
                    <asp:Label ID="lbl_Asset_Name" runat="server"  Text="اسم الاصل / الرقم التسلسلسي"></asp:Label>
                    <asp:Label ID="ID" runat="server"></asp:Label>
                    <asp:TextBox ID="txt_Asset_Name" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="form-group">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lbl_Date" runat="server" Text="تاريخ الصيانة"></asp:Label>&nbsp;
			                <asp:RegularExpressionValidator runat="server" ControlToValidate="txt_Date" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                ErrorMessage="dd/MM/yyyy" ValidationGroup="Maintenance_RequiredField" ForeColor="#fc544b" />
                            <asp:TextBox ID="txt_Date" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Button ID="Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Date_Chosee_Click" />
                            <asp:RequiredFieldValidator ID="txt_Date_RequiredFieldValidator" ValidationGroup="Maintenance_RequiredField"
                            ControlToValidate="txt_Date" runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"> </asp:RequiredFieldValidator>
                            <asp:ImageButton ID="Cal_Close" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton1_Click" runat="server" />
                            <div id="Date_divCalendar" runat="server" style="position: page;" visible="false">

                                <asp:Calendar ID="Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="#f0f0f3" BorderColor="#ccc" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="10pt" ForeColor="#5a5c69" OnSelectionChanged="Sign_Date_Calendar_SelectionChanged1">
                                    <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                    <OtherMonthDayStyle ForeColor="#5a5c69" />
                                    <SelectedDayStyle BackColor="#ff8d4f" Font-Bold="True" ForeColor="#ffffff" />
                                    <SelectorStyle BackColor="#5a5c69" ForeColor="#ffffff" />
                                    <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                    <TodayDayStyle BackColor="#37bc9b" ForeColor="#ffffff" />
                                    <WeekendDayStyle BackColor="#dfeef8" />
                                </asp:Calendar>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Date_Chosee" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="Date_Calendar" EventName="SelectionChanged" />
                            <asp:AsyncPostBackTrigger ControlID="Cal_Close" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="form-group">
                    <asp:Label ID="lbl_Employee_Tenant" runat="server" Text="اسم الموظف المسؤول"></asp:Label>
                    <asp:DropDownList ID="Employee_DropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="Employee_RequiredFieldValidator" ValidationGroup="Maintenance_RequiredField"
                    InitialValue="إختر الموظف المسؤول ...." ControlToValidate="Employee_DropDownList" runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"> </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="form-group">
                    <asp:Label ID="lbl_Notic" runat="server" Text="ملاحظات"></asp:Label>
                    <asp:TextBox ID="txt_Notic" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="form-group">
                    <asp:Button ID="btn_Add_Maintenance" runat="server" Text="إضافة" ValidationGroup="Maintenance_RequiredField" CssClass="btn  mb-1" BackColor="#52a2da" OnClick="btn_Add_Maintenance_Click" />
                </div>
            </div>
        </div>

        <div class="row"><div class="col-lg-2 mb-3"><h1 class="h3 mb-0 text-gray-800"><asp:Label ID="lbl_titel_Building_List" runat="server" Text="الصيانة  الدورية"></asp:Label></h1></div></div>
        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" style="border-radius: 10px;">
                        <asp:Repeater ID="Assset_List_1" runat="server" ClientIDMode="Static" OnItemDataBound="Assset_List_1_ItemDataBound">
                        <HeaderTemplate>
                            <table  cellspacing="0" style="width: 100%; font-size:11px" id="Table" class="datatable table table-striped table-bordered">
                                <thead>
                                    <th></th>
                                    <th>#</th>
                                    <th>نوع الأصل</th>
                                    <th>اسم الأصل</th>
                                    <th>الرقم التسلسلي </th>
                                    <th>حالة الأصل</th>
                                    <th>الموقع العام</th>
                                    <th>مكان الأصل</th>
                                    <th>الموّرد </th>
                                    <th>تاريخ الشراء </th>
                                    <th>تاريخ أخر صيانة دورية </th>
                                    <th></th>
                                </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td data-toggle="collapse" data-target="#collapse<%# Container.ItemIndex%>name" class="accordion-toggle"> <i class="fa fa-eye" aria-hidden="true"></i> </td>
                                <td>
                                    <asp:Label ID="lbl_Assets_Id" runat="server" Visible="false"  Text='<%# Eval("Assets_Id") %>' />
                                    <asp:Image ID="Image1" runat="server" ImageUrl="Main_Image/Lamp.png" Width="40" Height="40"/>
                                </td>
                                <td><asp:Label ID="lbl_Categoty_AR" runat="server" Text='<%# Eval("Categoty_AR") %>' /></td>
                                <td><asp:Label ID="lbl_Assets_Arabic_Name" runat="server" Text='<%# Eval("Assets_Arabic_Name") %>' /></td>
                                <td><asp:Label ID="lbl_Serial_Number" runat="server" Text='<%# Eval("Serial_Number") %>' /></td>
                                <td><asp:Label ID="lbl_Asset_Arabic_Condition" runat="server" Text='<%# Eval("Asset_Arabic_Condition") %>' /></td>
                                <td><asp:Label ID="lbl_Main_Place" runat="server" Text='<%# Eval("Main_Place") %>' /></td>
                                <td><asp:Label ID="lbl_Asset_Arabic_Location" runat="server" Text='<%# Eval("Asset_Arabic_Location") %>' /></td>
                                <td><asp:Label ID="lbl_Vendor_Arabic_Type" runat="server" Text='<%# Eval("Vendor_Arabic_Type") %>' /></td>
                                <td><asp:Label ID="lbl_Purchase_Date" runat="server" Text='<%# Eval("Purchase_Date") %>' /></td>
                                <td><asp:Label ID="lbl_Last_Maintanance" runat="server"  Text='<%# Eval("Last_periodec_maintenance") %>'/></td>
                                <td><asp:LinkButton  runat="server" CommandArgument='<%# Eval("Assets_Id") %>' OnClick="Unnamed_Click"><i class="fa fa-wrench" style="font-size:18px;"></i></asp:LinkButton> </td>
                            </tr>
                            <tr >
                                <td colspan="13">
                                    <div id="collapse<%# Container.ItemIndex%>name" class="accordian-body collapse">
                                        <asp:Repeater ID="Maintenance_Repeater" runat="server" ClientIDMode="Static">
                                            <HeaderTemplate>
                                                <table cellspacing="0" style="width: 100%; font-size: 11px" class="datatable table table-striped table-bordered">
                                                    <thead>
                                                        <th style="background-color:#d670ac">م</th>
                                                        <th style="background-color:#d670ac">التاريخ</th>
                                                        <th style="background-color:#d670ac">الموظف المسؤول</th>
                                                        <th style="background-color:#d670ac">ملاحظات</th>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                                    <td><asp:Label ID="lbl_Datre" runat="server" Text='<%# Eval("Datre") %>' /></td>
                                                    <td><asp:Label ID="lbl_Employee_Arabic_name" runat="server" Text='<%# Eval("Employee_Arabic_name") %>' /></td>
                                                    <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("Notic") %>' /></td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </td>
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
    <script>$('#<%= Employee_DropDownList.ClientID %>').chosen();</script>


     <script type="text/javascript">
         $(document).ready(function () {
             var a = document.getElementById('<%= lbl_Add_Maintenance.ClientID %>').textContent;
                if (a.length != 0) {
                    $('html, body').animate({
                        scrollTop: $('#Row').offset().top
                    }, 'slow');//w  w w.j a v a 2s.com 
                }
            });
     </script> 
</asp:Content>
