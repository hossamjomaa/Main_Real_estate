<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Maintenence_Templet.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Maintenence_Templet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" /> 


    <div class="container-fluid" id="container-wrapper" style="margin: auto;">
        <style>
            table {
                width: 100%;
            }

            td, th {
               
                text-align: center;
            }

            th {
                background-color: #52a2da;
                color: #fff;
                font-weight: bold;
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
            padding: 2px;
            text-align: center;

        }

        
        .table-row-stripe tr, .table-row-stripe td { background-color: #fff; }
        .table-row-stripe table tr, .table-row-stripe table tr td{ border: none; padding: 10px;}
        .table-row-stripe tr{
            text-align: right !important;
            border-bottom: 1px solid #ddd;
            border-top: 1px solid #ddd;
            border-collapse: collapse;
        } 
       
        .table-row-stripe td, .table-row-stripe th{
            text-align: right !important;
            padding: 5px;
        }
        .right-float{
            float: right;
        }
        </style>
        <%-----------------------------------------------------------------------------------%>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-10">
                    <div class="card-body">
                        <div class="container" style="color: red; font-weight: bold">
                            <h3>نموذج الرقابة الدورية للعقار</h3>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Employee_Name" runat="server" Text="اسم المراقب"></asp:Label>
                                    <asp:DropDownList ID="Employee_Name_DropDownList" runat="server"  CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Employee_Name_ReqFieldVal" ControlToValidate="Employee_Name_DropDownList"
                                        InitialValue="إختر المراقب ...." runat="server" ValidationGroup="Maintenence_Templet_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ownership_Name" runat="server" Text="اسم الملكية"></asp:Label>
                                    <asp:DropDownList ID="Ownership_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="Ownership_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Ownership_Name_RequiredFieldValidator" ControlToValidate="Ownership_Name_DropDownList"
                                        InitialValue="إختر الملكية ...." runat="server" ValidationGroup="Maintenence_Templet_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Name" runat="server" Text="اسم البناء"></asp:Label>
                                    <asp:DropDownList ID="Building_Name_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Building_Name_RequiredFieldValidator" ControlToValidate="Building_Name_DropDownList"
                                        InitialValue="إختر البناء ...." runat="server" ValidationGroup="Maintenence_Templet_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3" >
                                <div class="form-group" >
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Sign_Date" runat="server" Text="التاريخ"></asp:Label>&nbsp;
                                            <asp:TextBox ID="txt_Sign_Date" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="Sign_Date_ReqFieldVal" ControlToValidate="txt_Sign_Date"  
                                             runat="server" ErrorMessage="* حقل مطلوب !!!"  ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            <asp:Button ID="Sign_Date_Chosee" runat="server" ValidationGroup="x" Text="إختر التاريخ" CssClass="right-float" OnClick="Date_Chosee_Click" />
                                            <asp:ImageButton ID="ImageButton1" ValidationGroup="x" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton1_Click" runat="server" />
                                            <div id="Sign_Date_divCalendar" runat="server" style="position: page; " visible="false">

                                                <asp:Calendar ID="Sign_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Sign_Date_Calendar_SelectionChanged1">
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
                                            <asp:AsyncPostBackTrigger ControlID="Sign_Date_Chosee" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="Sign_Date_Calendar" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Location_IFO" runat="server" Text="معلومات مطلوبة من الموقع"></asp:Label>
                                    <asp:TextBox ID="txt_Location_IFO" runat="server"  Width="80%" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <table id="tblData" runat="server" style="margin: 10px; padding: 10px; " class="table-row-stripe">
                                <tr>
                                    <th style="width:200px">المرافق</th>
                                    <th>نظافة</th>
                                    <th>حماية</th>
                                    <th>صيانة</th>
                                    <th>مخالفات</th>
                                    <th style="width:300px">ملاحظات</th>
                                </tr>



                                <tr>
                                    <td>مواقف</td>
                                    <td><asp:CheckBox ID="CheckBox1" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox2" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox3" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox4" runat="server" /></td>
                                    <td><asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>مداخل</td>
                                    <td><asp:CheckBox ID="CheckBox5" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox6" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox7" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox8" runat="server" /></td>
                                    <td><asp:TextBox ID="TextBox2" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>الدرج</td>
                                    <td><asp:CheckBox ID="CheckBox9" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox10" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox11" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox12" runat="server" /></td>
                                    <td><asp:TextBox ID="TextBox3" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>السطح</td>
                                   <td><asp:CheckBox ID="CheckBox13" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox14" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox15" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox16" runat="server" /></td>
                                    <td><asp:TextBox ID="TextBox4" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>القبو</td>
                                    <td><asp:CheckBox ID="CheckBox17" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox18" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox19" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox20" runat="server" /></td>
                                    <td><asp:TextBox ID="TextBox5" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>غرفة المولد</td>
                                    <td><asp:CheckBox ID="CheckBox21" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox22" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox23" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox24" runat="server" /></td>
                                    <td><asp:TextBox ID="TextBox6" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>غرفة الكهرباء</td>
                                    <td><asp:CheckBox ID="CheckBox25" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox26" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox27" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox28" runat="server" /></td>
                                    <td><asp:TextBox ID="TextBox7" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>غرفة الدفاع المدني</td>
                                    <td><asp:CheckBox ID="CheckBox29" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox30" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox31" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox32" runat="server" /></td>
                                    <td><asp:TextBox ID="TextBox8" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>مكب القمامة</td>
                                    <td><asp:CheckBox ID="CheckBox33" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox34" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox35" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox36" runat="server" /></td>
                                    <td><asp:TextBox ID="TextBox9" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>المصاعد</td>
                                    <td><asp:CheckBox ID="CheckBox37" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox38" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox39" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox40" runat="server" /></td>
                                    <td><asp:TextBox ID="TextBox10" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>الممرات</td>
                                    <td><asp:CheckBox ID="CheckBox41" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox42" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox43" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox44" runat="server" /></td>
                                    <td><asp:TextBox ID="TextBox11" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>أجهزة عامة / أثاث عام</td>
                                    <td><asp:CheckBox ID="CheckBox45" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox46" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox47" runat="server" /></td>
                                    <td><asp:CheckBox ID="CheckBox48" runat="server" /></td>
                                    <td><asp:TextBox ID="TextBox12" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                            </table>
                        </div>
                        <hr />
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_One_Date" runat="server" Text="تاريخ أخر صيانة"></asp:Label>&nbsp;
                                        <asp:TextBox ID="txt_One_Date" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            <asp:Button ID="One_Date_Chosee" runat="server" ValidationGroup="x" Text="إختر التاريخ" OnClick="One_Date_Chosee_Click" />
                                            <asp:ImageButton ID="ImageButton2" ValidationGroup="x" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="One_ImageButton1_Click" runat="server" />
                                            <div id="One_Date_divCalendar" runat="server" style="position: page;" visible="false">

                                                <asp:Calendar ID="One_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="One_Date_Calendar_SelectionChanged1">
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
                                            <asp:AsyncPostBackTrigger ControlID="One_Date_Chosee" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="One_Date_Calendar" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                </div>
                                <div class="col-lg-4">
                                    <asp:Label ID="Label1" runat="server" Text="نوعها"></asp:Label>
                                    <asp:RadioButtonList ID="Radio_1" runat="server"  RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1" Text="دورية"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="حادثة"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Two_Date" runat="server" Text="تاريخ أخر نظافة"></asp:Label>&nbsp;
                                        <asp:TextBox ID="txt_Two_Date" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            <asp:Button ID="Two_Date_Chosee" runat="server" Text="إختر التاريخ" ValidationGroup="x" OnClick="Two_Date_Chosee_Click" />
                                            <asp:ImageButton ID="ImageButton3" ValidationGroup="x" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Two_ImageButton1_Click" runat="server" />
                                            <div id="Two_Date_divCalendar" runat="server" style="position: page;" visible="false">

                                                <asp:Calendar ID="Two_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Two_Date_Calendar_SelectionChanged1">
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
                                            <asp:AsyncPostBackTrigger ControlID="Two_Date_Chosee" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="Two_Date_Calendar" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton3" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>

                                </div>
                                 <div class="col-lg-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label2" runat="server" Text="نوعها"></asp:Label>
                                        <asp:RadioButtonList ID="Radio_2" runat="server"  RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Text="دورية"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="حادثة"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Discription" runat="server" Text="ملاحظات"></asp:Label>
                                    <asp:TextBox ID="txt_Discription" runat="server"  Width="80%" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <asp:Button ID="btn_Maintenence_Templet" runat="server" Text="إضافة " CssClass="btn  mb-1" BackColor="#52a2da" 
                                    ValidationGroup="Maintenence_Templet_RequiredField" ForeColor="White" OnClick="btn_Maintenence_Templet_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>$('#<%= Employee_Name_DropDownList.ClientID %>').chosen();</script>
<script>$('#<%= Ownership_Name_DropDownList.ClientID %>').chosen();</script>
<script>$('#<%= Building_Name_DropDownList.ClientID %>').chosen();</script>
</asp:Content>
