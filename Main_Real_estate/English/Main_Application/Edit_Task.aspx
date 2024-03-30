<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Edit_Task.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Edit_Task" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        table {
            width: 100%;
        }

        th {
            text-align: center;
        }

        td {
        }

        .table-condensed tr th {
            border: 0px solid #fff;
            color: #fff;
            background-color: #52a2da;
        }

        .table-condensed, .table-condensed tr td {
            border: 0px solid #fff;
        }

        tr:nth-child(even) {
            background: #f0f0f3;
        }

        tr:nth-child(odd) {
            background: #fff;
        }

        .calendarMonthStyle, .calendarMonthStyle tr:nth-child(odd), .calendarMonthStyle tr:nth-child(even) {
            background-color: #37bc9b;
            border: solid 1px #37bc9b;
            font-weight: bold;
            font-size: 14px;
            color: #ffffff;
            padding: 2px;
            text-align: center;
        }

            .calendarMonthStyle th {
                padding: 0 !important;
            }
    </style>

    <div class="container-fluid" id="Unit_container-wrapper">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_Edit_New_Task" runat="server" Text="تعديل المهمة "></asp:Label>
                <asp:Label ID="lbl_Success_Edit_Task" runat="server" ForeColor="#66bb6a"></asp:Label>
            </h1>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Task_Type" runat="server" Text=" المهمة"></asp:Label>
                                    <asp:TextBox ID="txt_Task_Type" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Department" runat="server" Text="توجيه إلى .."></asp:Label>
                                    <asp:DropDownList ID="Department_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Department_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Employee_Name" runat="server" Text="اسم الموظف"></asp:Label>
                                    <asp:DropDownList ID="Employee_Name_DropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>


                        <%--*************************************************************************************************************************************************--%>

                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Task_Discreption" runat="server" Text="وصف المهمة"></asp:Label>
                                    <asp:TextBox ID="txt_Task_Discreption" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-4">
                                <asp:Label ID="lbl_Start_Date" runat="server" Text="تاريخ البدء"></asp:Label>&nbsp;
                                <asp:TextBox ID="txt_Start_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Button ID="Start_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Start_Date_Chosee_Click" />
                                <asp:ImageButton ID="ImageButton2" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton2_Click" runat="server" />
                                <div id="Start_Date_Div" runat="server" visible="false" style="position: page;">
                                    <asp:Calendar ID="Start_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPEditing="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Start_Date_Calendar_SelectionChanged2">
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
                            </div>

                            <div class="col-lg-4">
                                <asp:Label ID="lbl_End_Date" runat="server" Text="تاريخ الإنتهاء"></asp:Label>&nbsp;
                                <asp:TextBox ID="txt_End_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Button ID="End_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="End_Date_Chosee_Click" />
                                <asp:ImageButton ID="ImageButton3" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton3_Click" runat="server" />
                                <div id="End_Date_Div" runat="server" visible="false" style="position: page;">
                                    <asp:Calendar ID="End_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPEditing="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="End_Date_Calendar_SelectionChanged1">
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
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_priority" runat="server" Text="أولوية المهمة"></asp:Label>
                                    <asp:DropDownList ID="priority_DropDownList" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1" Text="اولوية من الدرجة الأولى"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="اولوية من الدرجة الثانية"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="اولوية من الدرجة الثالثة"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="اولوية من الدرجة الرابعة"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="اولوية من الدرجة الخامسة"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col-lg-3">
                                <asp:Button ID="btn_Edit_Task" runat="server" Text="حفظ التغيرات" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" Width="248px" ValidationGroup="Task_RequiredField" OnClick="btn_Edit_Task_Click" />
                            </div>
                            <div class="col-lg-3">
                                <asp:Button ID="btn_Back_To_Task_List" runat="server" Text="العودة إلى قائمة المهمات" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Task_List_Click" />
                            </div>
                            <div >
                                <br />
                                <asp:LinkButton ID="Delete_Task"  runat="server" ValidationGroup="Delete" OnClick="Delete_Task_Click" OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');"><i class="fa fa-trash" style="font-size:40px; color:#0779c9"></i></asp:LinkButton>
                            </div>
                            <div class="col-lg-5">
                                <div class="form-group" runat="server" id="Delete_Reason">
                                    <asp:Label ID="lbl_Reason_Delete" runat="server" Text="سبب الحذف"></asp:Label>
                                    <asp:TextBox ID="txt_Reason_Delete" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Delete_ReqFieVal" ControlToValidate="txt_Reason_Delete"
                                        runat="server" ErrorMessage="* يرجى توضيح سبب الحذف" ForeColor="#fc544b" ValidationGroup="Delete"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
