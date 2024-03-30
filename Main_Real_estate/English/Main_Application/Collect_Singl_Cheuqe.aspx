<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Collect_Singl_Cheuqe.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Collect_Singl_Cheuqe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .table-condensed tr th {
            border: 0px solid #fff;
            color: #fff;
            background-color: #52a2da;
        }

        .table-condensed, .table-condensed tr td {
            border: 0px solid #fff;
        }

        tr:nth-child(even) {
            background:  #f0f0f3;
        }

        tr:nth-child(odd) {
            background: #fff;
        }

        .calendarMonthStyle, .calendarMonthStyle tr:nth-child(odd), .calendarMonthStyle tr:nth-child(even){
            background-color: #37bc9b; 
            border: solid 1px #37bc9b;
            font-weight: bold;
            font-size: 14px;
            color: #ffffff;
           padding: 0px;
           text-align: center

        }
    </style>

    <div class="container-fluid" id="Building_container-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
            <asp:Label ID="O_ID" runat="server" ></asp:Label>
            <asp:Label ID="B_ID" runat="server" ></asp:Label>
            <asp:Label ID="U_ID" runat="server" ></asp:Label>
            <asp:Label ID="Month" runat="server" ></asp:Label>
            <asp:Label ID="Year" runat="server" ></asp:Label>
            <asp:Label ID="Tenant_ID" runat="server" ></asp:Label>



            <div class="col-lg-12">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Cheuqe_NO" runat="server" Text="رقم الشيك"></asp:Label>
                                    <asp:TextBox ID="txt_Cheuqe_NO" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Cheuqe_Amount" runat="server" Text="قيمة الشيك"></asp:Label>
                                    <asp:TextBox ID="txt_Cheuqe_Amount" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Bank_Name" runat="server" Text="اسم البنك"></asp:Label>
                                    <asp:TextBox ID="txt_Bank_Name" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:UpdatePanel ID="Cheuqe_Date_UpdatePanel" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Cheuqe_Date" runat="server" Text="تاريخ الشيك"></asp:Label>&nbsp;
			                                 <asp:RegularExpressionValidator runat="server" ControlToValidate="txt_Cheuqe_Date" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                                 ErrorMessage="dd/MM/yyyy" ValidationGroup="Collect_Singl_Cheuqe_RequiredField" ForeColor="Red" />
                                            <asp:TextBox ID="txt_Cheuqe_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:Button ID="Cheuqe_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Date_Chosee_Click" />
                                            <asp:ImageButton ID="ImageButton1" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton1_Click" runat="server" />
                                            <div id="Cheuqe_Date_divCalendar" runat="server" style="position: page;" visible="false">

                                                <asp:Calendar ID="Cheuqe_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Sign_Date_Calendar_SelectionChanged1">
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
                                            <asp:AsyncPostBackTrigger ControlID="Cheuqe_Date_Chosee" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="Cheuqe_Date_Calendar" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>


                        <%--------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>

                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Cheuqe_Status" runat="server" Text="حالة الشيك"></asp:Label>
                                    <asp:DropDownList ID="Cheuqe_Status_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Cheuqe_Status_DropDownList_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="مودع"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="غير مودع"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="محصل"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="غير محصل"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="مؤجل"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="مرتجع"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="مستبدل بالتحويل"></asp:ListItem>
                                        <asp:ListItem Value="8" Text="مستبدل نقداً"></asp:ListItem>
                                        <asp:ListItem Value="9" Text="مستبدل بشيك اخر"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Cheuqe_Status_RequiredFieldValidator" ControlToValidate="Cheuqe_Status_DropDownList"
                                        InitialValue="إختر حالة الشيك ...." runat="server" ValidationGroup="Collect_Singl_Cheuqe_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-4" runat="server" id="Collect_Type_Div" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Collect_Type" runat="server" Text="نوع التحصيل"></asp:Label>
                                    <asp:DropDownList ID="Collect_Type_DropDownList" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1" Text="محصل بالشيك"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="محصل نقداً"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="محصل بالتحويل"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Collect_Type_Req_Fiel_dVal" ControlToValidate="Collect_Type_DropDownList"
                                        InitialValue="إختر نوع التحصيل ...." runat="server" ValidationGroup="Collect_Singl_Cheuqe_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Collect_Date" runat="server" Text="تاريخ التحصيل"></asp:Label>&nbsp;
			                                 <asp:RegularExpressionValidator runat="server" ControlToValidate="txt_Collect_Date" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                                 ErrorMessage="dd/MM/yyyy" ValidationGroup="Collect_Singl_Cheuqe_RequiredField" ForeColor="Red" />
                                            <asp:TextBox ID="txt_Collect_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:Button ID="Collect_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Collect_Date_Chosee_Click" />
                                            <asp:ImageButton ID="ImageButton2" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton2_Click" runat="server" />
                                            <div id="Collect_Date_divCalendar" runat="server" style="position: page;" visible="false">

                                                <asp:Calendar ID="Collect_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Collect_Calendar_SelectionChanged">
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
                                            <asp:AsyncPostBackTrigger ControlID="Collect_Date_Chosee" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="Collect_Calendar" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-3">
                                <asp:Button ID="btn_Sumit_Collect" runat="server" Text="تأكيد" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" Width="248px" 
                                ValidationGroup="Collect_Singl_Cheuqe_RequiredField" OnClick="btn_Sumit_Collect_Click"/>
                            </div>
                             <div class="col-lg-3">
                                <asp:Button ID="btn_Back" CssClass="btn btn-light mb-1" runat="server" Text="رجوع" ValidationGroup="x" OnClick="btn_Back_Click" />
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
