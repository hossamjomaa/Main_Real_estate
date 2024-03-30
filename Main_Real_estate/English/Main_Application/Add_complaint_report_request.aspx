<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Add_complaint_report_request.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Add_complaint_report_request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        
        .hiddencol {
            display: none;
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
      
        
    </style>
    <%--------------------------------------------------------------------------------------------------------%>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" /> 
    <%--------------------------------------------------------------------------------------------------------%>
    <div class="container-fluid" id="container-wrapper">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Maintenance" runat="server" Text="إضافة طلب (بلاغ أو شكوى)"></asp:Label>&nbsp;
                <asp:Label ID="Request_id" runat="server"></asp:Label>
                <asp:Label ID="lbl_Success_Add_New_Maintenance" runat="server" ForeColor="#66bb6a"></asp:Label>
            </h1>
        </div>
        <%--------------------------------------------------------------------------------------------------------%>
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-12">
                    <div class="card-body">
                        <div class="row" style="height: 30px;">
                            <div class="col-lg">
                                <div class="form-group">
                                    <asp:Label ID="txt_Dtl_Employee_Name" runat="server" Font-Size="25px"></asp:Label><hr />
                                </div>
                            </div>
                        </div>
                        <br />
                        <%--------------------------------------------------------------------------------------------------------%>
                        <div class="row" style="height: 75px;">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Complainte_Source" runat="server" Text="مصدر الطلب"></asp:Label>
                                    <asp:DropDownList ID="Complainte_Source_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="Complainte_Source_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Complainte_Source_RequiredFieldValidator" ValidationGroup="Maintenance_RequiredField"
                                        ControlToValidate="Complainte_Source_DropDownList" InitialValue="إختر مصدر الطلب ...." runat="server"
                                        ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"> </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-3" runat="server" id="Employee_Tenant_Div">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Employee_Tenant" runat="server" Text="اسم المستأجر"></asp:Label>
                                    <asp:DropDownList ID="Employee_Tenant_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Employee_Tenant_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Employee_Tenant_RequiredFieldValidator" ValidationGroup="Maintenance_RequiredField"
                                        ControlToValidate="Employee_Tenant_DropDownList" runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"> </asp:RequiredFieldValidator>
                                </div>
                            </div>



                             <div class="col-lg-3" runat="server" id="Other_Div" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Souorce_Name" runat="server" Text="اسم المصدر"></asp:Label>
                                    <asp:TextBox ID="txt_Souorce_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Maintenance_RequiredField"
                                        ControlToValidate="txt_Souorce_Name" runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"> </asp:RequiredFieldValidator>
                                </div>
                            </div>



                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Or_unit" runat="server" Text="نوع الموقع"></asp:Label>
                                    <asp:DropDownList ID="Building_Or_unit_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="false"
                                        OnSelectedIndexChanged="Building_Or_unit_DropDownList_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="بناء"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="وحدة"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Building_Or_unit_RequiredFieldValidator" ControlToValidate="Building_Or_unit_DropDownList"
                                        InitialValue="إختر بناء أو وحدة ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Request_Classification" runat="server" Text="تصنيف الطلب"></asp:Label>
                                    <asp:DropDownList ID="Request_Classification_DropDownList" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1" Text="بلاغ"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="شكوى"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Request_Classification_RequiredFieldValidator" ControlToValidate="Request_Classification_DropDownList"
                                        InitialValue="إختر صنف الطلب ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------------------------------------------------------------------------%>
                        <div class="row" style="height: 75px;">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Name" runat="server" Text="اسم البناء"></asp:Label>
                                    <asp:DropDownList ID="Building_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Building_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Building_Name_RequiredFieldValidator" ControlToValidate="Building_Name_DropDownList"
                                        InitialValue="إختر اسم البناء ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-3" id="Unit_Div" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Units" runat="server" Text="الوحدة"></asp:Label>
                                    <asp:DropDownList ID="Units_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Units_DropDownList_RequiredFieldValidator" ControlToValidate="Units_DropDownList"
                                        InitialValue="إختر الوحدة ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>



                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Request_Type" runat="server" Text="النوع"></asp:Label>
                                    <asp:DropDownList ID="Request_Type_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Request_Type_DropDownList_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="صيانة"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="نظافة"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="مخالفة"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Request_Type_RequiredFieldValidator" ControlToValidate="Request_Type_DropDownList"
                                        InitialValue="إختر النوع ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Order_Direction" runat="server" Text="توجيه الطلب"></asp:Label>
                                    <asp:DropDownList ID="Order_Direction_DropDownList" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1" Text="الرقابة"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="شؤون العملاء"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Order_Direction_RequiredFieldValidator" ControlToValidate="Order_Direction_DropDownList"
                                        InitialValue="إختر توجيه البلاغ ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------------------------------------------------------------------------%>
                         <div class="row" style="height: 75px;">
                             <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Rreport_Text" runat="server" Text=" نص الطلب"></asp:Label>&nbsp;
                                    <asp:TextBox ID="txt_Rreport_Text" TextMode="MultiLine" Height="40px" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Inspection_Report_Description" runat="server" Text=" وصف تقرير الفحص"></asp:Label>&nbsp;
                                    <asp:TextBox ID="txt_Inspection_Report_Description" TextMode="MultiLine" Height="40px" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div><br />
                        <%--------------------------------------------------------------------------------------------------------%>
                        <div class="row">
                            <div class="col-lg-5" style="border-style:solid;border-radius:5px;height: 140px;">
                                <h4>الأولوية</h4>
                                <div class="row">
                                    <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Order_priority" runat="server" Text="مدى العاجلية "></asp:Label>
                                    <asp:DropDownList ID="Order_priority_DropDownList" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1" Text="تعطيل"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="إزعاج مؤقت"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="إزعاج عابر"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Order_priority_RequiredFieldValidator" ControlToValidate="Order_priority_DropDownList"
                                        InitialValue="إختر مدى العاجلية ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Danger_Magnitude" runat="server" Text="درجة الخطورة "></asp:Label>
                                    <asp:DropDownList ID="Danger_Magnitude_DropDownList" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1" Text="خطورة على الحياة"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="خطورة على الممتلكات"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="خطورة قليلة الإحتمالية"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Danger_Magnitude_RequiredFieldValidator" ControlToValidate="Danger_Magnitude_DropDownList"
                                        InitialValue="إختر درجة الخطورة ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                                </div>
                            </div>
                            

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Report_Date" runat="server" Text="تاريخ تقديم الطلب"></asp:Label>&nbsp;

                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="txt_Report_Date" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                            ErrorMessage="dd/MM/yyyy" ValidationGroup="Maintenance_RequiredField"  ForeColor="#fc544b"/>

                                            <asp:TextBox ID="txt_Report_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:Button ID="Report_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Date_Chosee_Click" />
                                            <asp:ImageButton ID="ImageButton1" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton1_Click" runat="server" />
                                            <div id="Report_Date_divCalendar" runat="server" style="position: page;" visible="false">

                                                <asp:Calendar ID="Report_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Report_Date_Calendar_SelectionChanged1">
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
                                            <asp:AsyncPostBackTrigger ControlID="Report_Date_Chosee" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="Report_Date_Calendar" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Image_One" runat="server" Text="تحميل صورة قبل"></asp:Label>
                                    <asp:FileUpload ID="Image_Befor_FileUpload" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" Text="تحميل صورة بعد"></asp:Label>
                                    <asp:FileUpload ID="Image_After_FileUpload" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------------------------------------------------------------------------%>
                        <div class="row" style="display:none">
                           
                            <div class="col-lg-6">
                                <asp:Label ID="lbl_Achievement_Verification" runat="server" Text="التحقق من الإنجاز"></asp:Label>
                                <div style="border-style: solid; border-width: 1px; height: 50px">
                                    <asp:RadioButtonList ID="Achievement_Verification_RadioButtonList" RepeatDirection="Horizontal" runat="server" CellPadding="20">
                                        <asp:ListItem Value="1" Selected="True" Text="&nbsp; معلق  "></asp:ListItem>
                                        <asp:ListItem Value="2" Text="&nbsp; تم أنجازه "></asp:ListItem>
                                        <asp:ListItem Value="3" Text="&nbsp; تحت الإجراء "></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_precaution" runat="server" Text=" الإجراء الوقائي"></asp:Label>&nbsp;
                                    <asp:TextBox ID="txt_precaution" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <asp:Panel ID="Maintenance_Panel" runat="server" Visible="false">
        <div class="container-fluid" id="container-wrapper_2">
            <div class="d-sm-flex align-items-center justify-content-between mb-4">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="Label1" runat="server" Text="إضافة طلب صيانة"></asp:Label>&nbsp;
                <asp:Label ID="Label2" runat="server" ForeColor="Green"></asp:Label>
                </h1>
            </div>
            <%--------------------------------------------------------------------------------------------------------%>
            <div class="row">
                <div class="col-lg-12">
                    <div class="card mb-12">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Maintenance_Status" runat="server" Text="حالة طلب الصيانة "></asp:Label>
                                        <asp:DropDownList ID="Maintenance_Status_DropDownList" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1" Text="معلق"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="قيد التنفيذ"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="منتهي"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Maintenance_Status_RequiredFieldValidator" ControlToValidate="Maintenance_Status_DropDownList"
                                            InitialValue="إختر حالة طلب الصيانة ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Maintenance_Type" runat="server" Text="نوع الصيانة "></asp:Label>
                                        <asp:DropDownList ID="Maintenance_Type_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Maintenance_Type_DropDownList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Maintenance_Type_RequiredFieldValidator" ControlToValidate="Maintenance_Type_DropDownList"
                                            InitialValue="إختر نوع الصيانة ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Maintenance_SubType" runat="server" Text="النوع الفرعي للصيانة "></asp:Label>
                                        <asp:DropDownList ID="Maintenance_SubType_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Maintenance_SubType_DropDownList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Maintenance_SubType_RequiredFieldValidator" ControlToValidate="Maintenance_SubType_DropDownList"
                                            InitialValue="إختر النوع الفرعي للصيانة ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Asset" runat="server" Text="الأصل"></asp:Label>
                                        <asp:DropDownList ID="Asset_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Asset_DropDownList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Asset_RequiredFieldValidator" ControlToValidate="Asset_DropDownList"
                                            InitialValue="إختر الاصل ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <%--------------------------------------------------------------------------------------------------------%>

                            <div class="row">
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Maintenance_Guarantor" runat="server" Text="تحميل التكلفة على "></asp:Label>
                                        <asp:DropDownList ID="Maintenance_Guarantor_DropDownList" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1" Text="المقاول"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="الموّرد"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="المالك"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="العميل"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Maintenance_Guarantor_RequiredFieldValidator" ControlToValidate="Maintenance_Guarantor_DropDownList"
                                            InitialValue="إختر  ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Executing_Agency" runat="server" Text="الجهة المنفذة"></asp:Label>
                                        <asp:DropDownList ID="Executing_Agency_DropDownList" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1" Text="فريق الصيانة"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="المقاول"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="الموّرد"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Executing_Agency_RequiredFieldValidator" ControlToValidate="Executing_Agency_DropDownList"
                                            InitialValue="إختر الجهة المنفذة ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <%--------------------------------------------------------------------------------------------------------%>

                            <div class="row">
                                <div class="col-lg">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Technical" runat="server" Text="الفني المسؤول "></asp:Label>
                                        <asp:DropDownList ID="Technical_DropDownList" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Technical_RequiredFieldValidator" ControlToValidate="Technical_DropDownList"
                                            InitialValue="إختر الفني المسؤول ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-lg">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Observer" runat="server" Text="المراقب"></asp:Label>
                                        <asp:DropDownList ID="Observer_DropDownList" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Observer_RequiredFieldValidator" ControlToValidate="Observer_DropDownList"
                                            InitialValue="إختر المراقب  ...." runat="server" ValidationGroup="Maintenance_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-lg">
                                    <asp:UpdatePanel ID="Start_Date_UpdatePanel" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Start_Date" runat="server" Text="تاريخ البدء"></asp:Label>&nbsp;

                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="txt_Start_Date" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                            ErrorMessage="يجب أن يكون التاريخ بالنمط:  dd/MM/yyyy" ValidationGroup="Maintenance_RequiredField"  ForeColor="#fc544b"/>

                                             <asp:TextBox ID="txt_Start_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:Button ID="Start_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Start_Date_Chosee_Click" />
                                            <asp:ImageButton ID="ImageButton2" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton2_Click" runat="server" />
                                            <div id="Start_Date_Div" runat="server" visible="false" style="position: page;">
                                                <asp:Calendar ID="Start_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Start_Date_Calendar_SelectionChanged2">
                                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                                    <OtherMonthDayStyle ForeColor="#999999" />
                                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                                </asp:Calendar>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Start_Date_Calendar" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="Start_Date_Chosee" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>

                                <div class="col-lg">
                                    <asp:UpdatePanel ID="End_Date_UpdatePanel" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_End_Date" runat="server" Text="تاريخ الإنتهاء"></asp:Label>&nbsp;

                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="txt_End_Date" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                            ErrorMessage="يجب أن يكون التاريخ بالنمط:  dd/MM/yyyy" ValidationGroup="Maintenance_RequiredField"  ForeColor="#fc544b"/>

                                            <asp:TextBox ID="txt_End_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:Button ID="End_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="End_Date_Chosee_Click" />
                                            <asp:ImageButton ID="ImageButton3" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton3_Click" runat="server" />
                                            <div id="End_Date_Div" runat="server" visible="false" style="position: page;">
                                                <asp:Calendar ID="End_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="End_Date_Calendar_SelectionChanged1">
                                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                                    <OtherMonthDayStyle ForeColor="#999999" />
                                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                                </asp:Calendar>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="End_Date_Calendar" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="Start_Date_Chosee" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton3" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-lg">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Cost" runat="server" Text="التكلفة"></asp:Label>&nbsp;
                                        <asp:TextBox ID="txt_Cost"  runat="server" CssClass="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="Inspection_Report_Description_RequiredFieldValidator"
                                            ValidationGroup="Maintenance_RequiredField" ControlToValidate="txt_Inspection_Report_Description"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                        </asp:RequiredFieldValidator>--%>
                                    </div>
                            </div>
                            </div>
                            <asp:ImageButton ID="Add_Maintenane" runat="server" ImageUrl="~/English/Main_Application/Main_Image/plus.png" ValidationGroup="Maintenance_RequiredField" Width="40px" Height="40px" OnClick="Add_Maintenane_Click" />
                            <br />
                            <div id="container" class="container-fluid" style="border-style: solid; border-radius: 10px;">
                                <div class="row">
                                    <div class="table-responsive">
                                        <%--OnRowDeleting="OnRowDeleting" OnRowDataBound="Cheque_GridView_RowDataBound"--%>
                                        <asp:GridView Width="100%" ID="Maintenance_GridView" runat="server" AutoGenerateColumns="false" OnRowDeleting="Maintenance_GridView_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField HeaderText="#" ItemStyle-Width="10">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Maintenance_Type" HeaderText="نوع الصيانة" ItemStyle-Width="120" />

                                                <asp:BoundField DataField="Maintenance_SubType" HeaderText="النوع الفرعي للصيانة" ItemStyle-Width="120" />
                                                <asp:BoundField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="maintenance_subtypes_Maintenance_Subtypes_Id" HeaderText="" />

                                                <asp:BoundField DataField="Asset" HeaderText="الأصل" ItemStyle-Width="120" />
                                                <asp:BoundField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="assets_Assets_Id" HeaderText="" />

                                                <asp:BoundField DataField="Cost_Direction" HeaderText="الجهة المعنية بالتكلفة" />
                                                <asp:BoundField DataField="Executing_Agency" HeaderText="الجهة المنفذة" />

                                                <asp:BoundField DataField="technical" HeaderText="الفني المسؤول" ItemStyle-Width="120" />
                                                <asp:BoundField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="Technical_ID" HeaderText="" />

                                                <asp:BoundField DataField="watcher" HeaderText="المراقب" ItemStyle-Width="120" />
                                                <asp:BoundField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="Watcher_ID" HeaderText="" />

                                                <asp:BoundField DataField="Start_Date" HeaderText="تاريخ البدء" />
                                                <asp:BoundField DataField="End_Date" HeaderText="تاريخ الانتهاء" />
                                                <asp:BoundField DataField="Cost" HeaderText=" التكلفة" />

                                                <asp:BoundField DataField="Act" HeaderText=" حالة الطلب" />

                                                <%-------------------------------------------------------------------------------------------------%>
                                                <asp:CommandField ItemStyle-Width="10px" ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/English/Main_Application/Main_Image/Calander_Close.png" ControlStyle-Width="25px" ControlStyle-Height="25px" />
                                            </Columns>
                                            <RowStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div><br />
    </asp:Panel>
    <%-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_Add_Request" runat="server" Text="إنشاء  الطلب" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" Width="248px" ValidationGroup="Maintenance_RequiredField" OnClick="btn_Add_Request_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_Back_To_Request_List" runat="server" Text="العودة إلى قائمة الطلبات" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Request_List_Click" />


    <br />
    <br />

    <asp:Label ID="Label3" runat="server" ></asp:Label><br />
    <asp:Label ID="Label4" runat="server" ></asp:Label>


    <script>$('#<%= Complainte_Source_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Units_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Employee_Tenant_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Building_Or_unit_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Building_Name_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Request_Classification_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Request_Type_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Order_Direction_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Order_priority_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Danger_Magnitude_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Maintenance_Status_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Maintenance_Type_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Maintenance_SubType_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Asset_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Maintenance_Guarantor_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Executing_Agency_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Technical_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Observer_DropDownList.ClientID %>').chosen();</script>
</asp:Content>
