﻿<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Edit_Contract.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Edit_Contract" %>

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

        .calendarMonthStyle th{
            padding: 0 !important;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" />  

    <div class="container-fluid" id="container-wrapper">
        <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Tenant" runat="server" Text="تعديل عقد المستأجر : "></asp:Label>
                <asp:Label ID="Contract_id" runat="server"></asp:Label>
                <asp:Label ID="Contarct_tenant_Name" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Label ID="lbl_Success_Add_New_Contract" runat="server" ForeColor="#00FF40"></asp:Label>
            </h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-12">
                    <div class="card-body">

                        <div class="row">
                            <div class="col-lg">
                                <asp:Label ID="lbl_Employee_Name" runat="server" Text="اسم الموظف :"></asp:Label>
                                <div class="form-group" style="border-style: solid; border-radius: 7px; border-width: 1px; background-color: #f3f3f3; padding: 5px;">
                                    <asp:Label ID="txt_Dtl_Employee_Name" runat="server" Font-Size="25px"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="نموذج العقد"></asp:Label>
                                    <asp:DropDownList ID="Contract_Templet_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Contract_RequiredField" ControlToValidate="Contract_Templet_DropDownList"
                                        InitialValue="إختر نموذج العقد ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Tenan_Name" runat="server" Text="اسم المستأجر"></asp:Label>
                                    <asp:DropDownList ID="Tenan_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Tenan_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Tenan_Name_RequiredFieldValidator" ControlToValidate="Tenan_Name_DropDownList"
                                        InitialValue="إختر اسم المستأجر ...." runat="server" ValidationGroup="Contract_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg" id="Com_Rep_Div" runat="server">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Com_Rep" runat="server" Text="اسم الممثل عن الشركة"></asp:Label>
                                    <asp:DropDownList ID="Com_Rep_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Com_Rep_RequiredFieldValidator" ControlToValidate="Com_Rep_DropDownList"
                                        InitialValue="إختر اسم الممثل ...." runat="server" ValidationGroup="Contract_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>


                        <div class="row">


                            <div class="col-lg">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ownership_Name" runat="server" Text="اسم الملكية"></asp:Label>
                                    <asp:DropDownList ID="Ownership_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Ownership_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Ownership_Name_RequiredFieldValidator" ControlToValidate="Ownership_Name_DropDownList"
                                        InitialValue="إختر اسم المستأجر ...." runat="server" ValidationGroup="Contract_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Name" runat="server" Text="اسم البناء"></asp:Label>
                                    <asp:DropDownList ID="Building_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Building_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Building_Name_RequiredFieldValidator" ControlToValidate="Building_Name_DropDownList"
                                        InitialValue="إختر اسم المستأجر ...." runat="server" ValidationGroup="Contract_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Units" runat="server" Text="الوحدة"></asp:Label>
                                    <asp:DropDownList ID="Units_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Tenan_Name_DropDownList"
                                        InitialValue="إختر الوحدة ...." runat="server" ValidationGroup="Contract_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                        <div class="row">



                            <div class="col-lg">
                                <div id="div_Reason_For_Rent" runat="server">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Reason_For_Rent" runat="server" Text="الغرض من الايجار"></asp:Label>
                                        <asp:DropDownList ID="Reason_For_Rent_DropDownList" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1" Text="سكن عائلي"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="عمل تجاري"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="سكن عزاب"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Reason_For_Rent_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="Reason_For_Rent_DropDownList"
                                            InitialValue="إختر الغرض من الإيجار ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg">
                                <div class="form-group">
                                    <asp:Label ID="LabelX" runat="server" Text="الوحدة الزمنية للتعاقد"></asp:Label>
                                    <asp:DropDownList ID="Contract_Type_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Contract_Type_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Contract_Type_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="Contract_Type_DropDownList"
                                        InitialValue="إختر الوحدة الزمنية ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg">
                                <div id="div_No_Of_Months" runat="server">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_No_Of_Months_Or_Years" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_No_Of_Months_Or_Years" runat="server" TextMode="Number" min="1"  step="1" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_No_Of_Months_Or_Years_TextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="No_Of_Months_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="Contract_Type_DropDownList"
                                            InitialValue="إختر عدد الأشهر ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>


                        </div>
                        <%--------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
<div class="row">
    <div class="col-lg-3">
        <div class="form-group">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lbl_Sign_Date" runat="server" Text="تاريخ توقيع العقد"></asp:Label>&nbsp;
			<asp:RegularExpressionValidator runat="server" ControlToValidate="txt_Sign_Date" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                    ErrorMessage="dd/MM/yyyy" ValidationGroup="Contract_RequiredField"  ForeColor="Red"/>
                    <asp:TextBox ID="txt_Sign_Date" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button ID="Sign_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Date_Chosee_Click"/>
                    <asp:ImageButton ID="ImageButton1" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton1_Click" runat="server"/>
                    <div id="Sign_Date_divCalendar" runat="server" style="position: page;" visible="false">

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
                    <asp:AsyncPostBackTrigger ControlID="Sign_Date_Chosee" EventName="Click"/>
                    <asp:AsyncPostBackTrigger ControlID="Sign_Date_Calendar" EventName="SelectionChanged"/>
                    <asp:AsyncPostBackTrigger ControlID="ImageButton3" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="col-lg-3">
        <asp:UpdatePanel ID="Start_Date_UpdatePanel" runat="server">
            <ContentTemplate>
                <asp:Label ID="lbl_Start_Date" runat="server" Text="تاريخ البدء"></asp:Label>&nbsp;
			<asp:RegularExpressionValidator runat="server" ControlToValidate="txt_Start_Date" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                    ErrorMessage="dd/MM/yyyy" ValidationGroup="Contract_RequiredField"  ForeColor="Red"/>
                <asp:TextBox ID="txt_Start_Date" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="Start_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Start_Date_Chosee_Click"/>
                <asp:ImageButton ID="ImageButton2" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton2_Click" runat="server"/>
                <div id="Start_Date_Div" runat="server" visible="false" style="position: page;">
                    <asp:Calendar ID="Start_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Start_Date_Calendar_SelectionChanged2">
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
                <asp:AsyncPostBackTrigger ControlID="Start_Date_Calendar" EventName="SelectionChanged"/>
                <asp:AsyncPostBackTrigger ControlID="Start_Date_Chosee" EventName="Click"/>
                <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="col-lg-3">
        <asp:UpdatePanel ID="End_Date_UpdatePanel" runat="server">
            <ContentTemplate>
                <asp:Label ID="lbl_End_Date" runat="server" Text="تاريخ الإنتهاء"></asp:Label>&nbsp;
			<asp:RegularExpressionValidator runat="server" ControlToValidate="txt_End_Date" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                    ErrorMessage="dd/MM/yyyy" ValidationGroup="Contract_RequiredField"  ForeColor="Red"/>
                <asp:TextBox ID="txt_End_Date" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                <asp:Button ID="End_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="End_Date_Chosee_Click" Visible="false"/>
                <asp:ImageButton ID="ImageButton3" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton3_Click" runat="server"/>
                <div id="End_Date_Div" runat="server" visible="false" style="position: page;">
                    <asp:Calendar ID="End_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="End_Date_Calendar_SelectionChanged1">
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
                <asp:AsyncPostBackTrigger ControlID="Sign_Date_Calendar" EventName="SelectionChanged"/>
                <asp:AsyncPostBackTrigger ControlID="Start_Date_Chosee" EventName="Click"/>
                <asp:AsyncPostBackTrigger ControlID="ImageButton3" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="col-lg-3">
        <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="نوع الدفعات"></asp:Label>
            <asp:DropDownList ID="Payment_Type_DropDownList" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="Payment_Type_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="Payment_Type_DropDownList"
                                        InitialValue="إخترنوع الدفع ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
    </div>
</div>
<br/>
<%--------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
<div class="row">
    <%--<div class="col-lg-3">
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="تكرار الدفعات"></asp:Label>
            <asp:DropDownList ID="Payment_Frquancy_DropDownList" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="Payment_Frquancy_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="Payment_Frquancy_DropDownList"
                                        InitialValue="إختر تكرار الدفعات ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
    </div>--%>
    
    <div class="col-lg-3">
        <div class="form-group">
            <asp:Label ID="lbl_Payment_Amount" runat="server" Text=" قيمة الإيجار بالأرقام"></asp:Label>&nbsp;
            <asp:RegularExpressionValidator ID="Payment_Amount_RegularExpressionValidator" runat="server" ControlToValidate="txt_Payment_Amount"
                                            EnableClientScript="True" ErrorMessage="أرقام فقط" ForeColor="Red"
                                            ValidationExpression="[0-9]+">
            </asp:RegularExpressionValidator>
            <asp:TextBox ID="txt_Payment_Amount" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Payment_Amount_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="txt_Payment_Amount"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="col-lg-3">
        <div class="form-group">
            <asp:Label ID="lbl_Payment_Amount_L" runat="server" Text=" قيمة الإيجار بالأحرف"></asp:Label>&nbsp;
            <asp:TextBox ID="txt_Payment_Amount_L" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Payment_Amount_L_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="txt_Payment_Amount_L"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="col-lg-3">
        <asp:Label ID="lbl_maintenance" runat="server" Text="الصيانة"></asp:Label>
        <asp:RadioButtonList ID="maintenance_RadioButtonList" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="1" Text="على المؤجر"></asp:ListItem>
            <asp:ListItem Value="2" Text="على المستأجر"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="maintenance_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="maintenance_RadioButtonList"
                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
        </asp:RequiredFieldValidator>
    </div>

    <div class="col-lg-3">
        <asp:Label ID="lbl_Rental_allowed_Or_Not_allowed" runat="server" Text="التنازل والبيع والايجار من الباطن"></asp:Label>
        <asp:RadioButtonList ID="Rental_allowed_Or_Not_allowed_RadioButtonList" RepeatDirection="Horizontal" runat="server">
            <asp:ListItem Value="1" Text="يجوز"></asp:ListItem>
            <asp:ListItem Value="2" Text="لا يجوز"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="Rental_allowed_Or_Not_allowed_RequiredFieldValidator" ValidationGroup="Contract_RequiredField"
                                    ControlToValidate="Rental_allowed_Or_Not_allowed_RadioButtonList" runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
        </asp:RequiredFieldValidator>
    </div>
    
</div>
<%--------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
<%--------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
<asp:UpdatePanel ID="Additional_Items_UpdatePanel" runat="server">
    <ContentTemplate>
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <asp:CheckBox ID="FREE_PERIOD_CheckBox" runat="server" Text="إضافة فترة سماح " AutoPostBack="true" OnCheckedChanged="FREE_PERIOD_CheckBox_CheckedChanged"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="Additional_Items_CheckBox" runat="server" Text="إضافة ملاحظات و بنود إضافية " AutoPostBack="true" OnCheckedChanged="Additional_Items_CheckBox_CheckedChanged"/>
                </div>
            </div>

            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Label ID="lbl_Real_Contract" runat="server" Text="تحميل صورة العقد المصدق"></asp:Label>
                    <asp:FileUpload ID="Real_Contract_FileUpload" runat="server" CssClass="form-control" />
                    <asp:Label ID="Real_Contract_FileName" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="Real_Contract_Path" runat="server" Text="" Visible="false"></asp:Label>
                </div>
                <div runat="server" id="Real_Contract_Div">
                <a runat="server" id="Link_Real_Contract" style="font-size: 15px;">
                    <i class="fa fa-paperclip" style="font-size: 20px;"></i>
                    <asp:Label ID="lbl_Link_Real_Contract" runat="server" Text=""></asp:Label>
                </a>
                <asp:ImageButton ID="Btn_Remove_Link_Real_Contract" OnClick="Btn_Remove_Link_Real_Contract_Click" runat="server" Width="15px" Height="15px" ImageUrl="Main_Image/Delete.png" />
            </div>
            </div>
            


            <div class="col-lg-12" id="Contract_Details_Div" runat="server" visible="false">
                <div class="form-group">
                    <asp:Label ID="lbl_Contract_Details" runat="server" Text="ملاحظات و بنود إضافية"></asp:Label>
                    &nbsp;
                    <asp:RegularExpressionValidator ID="Contract_Details_RegularExpressionValidator" runat="server" ControlToValidate="txt_Contract_Details"
                                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                                    ValidationExpression="[ا-ي أآى ة ئ ء]+">
                    </asp:RegularExpressionValidator>
                    <asp:TextBox ID="txt_Contract_Details" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="false"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row" id="FREE_PERIOD_Div" runat="server" visible="false">
            <div class="col-lg-3">
                <div class="form-group">
                    <asp:Label ID="lbl_FREE_PERIOD" runat="server" Text="تبدأ فترة السماح من الشهر"></asp:Label>
                    <asp:TextBox ID="txt_FREE_PERIOD" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="form-group">
                    <asp:Label ID="lbl_Duration_Of_The_Free_Period" runat="server" Text="مدة فترة السماح "></asp:Label>
                    <asp:TextBox ID="txt_Duration_Of_The_Free_Period" runat="server" TextMode="Number" min="1"  step="1" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_Duration_Of_The_Free_Period_TextChanged"></asp:TextBox>
                </div>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Additional_Items_CheckBox" EventName="CheckedChanged"/>
        <asp:AsyncPostBackTrigger ControlID="FREE_PERIOD_CheckBox" EventName="CheckedChanged"/>
    </Triggers>
</asp:UpdatePanel>
<hr/>
<%--------------------------------------------------------------Cheque / transformation / Cash Gridviwes ------------------------------------------------------------------------------------------------------%>
   

    <div class="col-lg-3">
        <asp:Label ID="lbl_Paymen_Method" runat="server" Text="طريقة السداد" ></asp:Label>
        <asp:RadioButtonList ID="Paymen_Method_RadioButtonList" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="Paymen_Method_RadioButtonList_SelectedIndexChanged">
            <asp:ListItem Value="1" Text="شيك"></asp:ListItem>
            <asp:ListItem Value="2" Text="تحويل"></asp:ListItem>
            <asp:ListItem Value="3" Text="نقداً"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="Paymen_Method_Req_Fiel_Val" ValidationGroup="Contract_RequiredField"
        ControlToValidate="Paymen_Method_RadioButtonList" runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
        </asp:RequiredFieldValidator>
    </div>

                        <div id="container" class="container-fluid" style="border-radius: 10px;">
                            <div calss="row">
                                <h4>
                                    <asp:Label ID="lbl_Tenant_Cheque" runat="server"></asp:Label></h4>

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="table-responsive">
                                                <asp:GridView ID="Contract_Cheque_List" DataKeyNames="Cheques_Id" runat="server" AutoGenerateColumns="false"
                                                    OnRowEditing="EditCustomer" OnRowDataBound="RowDataBound" OnRowDeleting="Contract_Cheque_List_RowDeleting" OnRowUpdating="UpdateCustomer"
                                                    OnRowCancelingEdit="CancelEdit">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="#" ItemStyle-Width="10">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--------------------------------------------------------------------------------------------------%>
                                                        <asp:TemplateField HeaderText="رقم الشيك">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txt_Cheques_No" runat="server" Text='<%# Bind("Cheques_No") %>'>  
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Cheques_No" runat="server" Text='<%# Eval("Cheques_No") %>'>  
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--------------------------------------------------------------------------------------------------%>
                                                        <asp:TemplateField HeaderText="تاريخ الشيك">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lbl_Cheques_Date" runat="server" Text='<%# Eval("Cheques_Date") %>'>  </asp:Label>
                                                                <asp:Calendar ID="Calendar2" runat="server">
                                                                    

                                                                     <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                                    <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                                    <OtherMonthDayStyle ForeColor="#5a5c69" />                  
                                                                    <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                                    <WeekendDayStyle BackColor="#dfeef8" />

                                                                </asp:Calendar>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Cheques_Date" runat="server" Text='<%# Eval("Cheques_Date") %>'>  </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%------------------------------------------------------------------------%>
                                                        <asp:TemplateField HeaderText="قيمة الشيك">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txt_Cheques_Amount" runat="server" Text='<%# Bind("Cheques_Amount") %>'>  
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Cheques_Amount" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Cheques_Amount")))%>'>  
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%------------------------------------------------------------------------%>
                                                        <asp:TemplateField HeaderText="نوع الشيك">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_cheque_type" runat="server" Text='<%# Eval("Cheque_arabic_Type")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label Visible="false" ID="lbl_cheque_Type" runat="server" Text='<%# Eval("Cheque_arabic_Type")%>'></asp:Label>
                                                                <asp:DropDownList ID="cheque_type_DropDownList" runat="server">
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <%-- ---------------------------------------------------------------------------------%>
                                                        <asp:TemplateField HeaderText="اسم البنك">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_bank" runat="server" Text='<%# Eval("Bank_Arabic_Name")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="bank_DropDownList" runat="server" Enabled="false">
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--------------------------------------------------------------------------------------------------%>
                                                        <asp:TemplateField HeaderText="صاحب الشيك">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txt_Cheque_Owner" runat="server" Text='<%# Bind("Cheque_Owner") %>'>  
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Cheque_Owner" runat="server" Text='<%# Eval("Cheque_Owner") %>'>  
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--------------------------------------------------------------------------------------------------%>
                                                        <asp:TemplateField HeaderText="اسم المستفيد">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txt_beneficiary_person" runat="server" Text='<%# Bind("beneficiary_person") %>'>  
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_beneficiary_person" runat="server" Text='<%# Eval("beneficiary_person") %>'>  
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%-----------------------------------------------------------------------------------%>
                                                        <asp:CommandField ShowDeleteButton="true" ShowEditButton="True" ButtonType="Button" DeleteText="حذف" EditText="تعديل" CancelText="إلغاء" UpdateText="تحديث" ControlStyle-Width="70px" />
                                                    </Columns>
                                                    <RowStyle HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <%--************************************************************** transformation Gridviwes *********************************************************************************************************************--%>
                            <div class="row">
                                <div class="table-responsive">
                                    <asp:GridView Width="100%" ID="transformation_GridView" DataKeyNames="transformation_Table_ID" runat="server" AutoGenerateColumns="false" OnRowDeleting="transformation_GridView_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="transformation_No" HeaderText="رقم الحوالة" ItemStyle-Width="120" />
                                            <asp:BoundField DataField="Bank_Name" HeaderText="اسم البنك" ItemStyle-Width="120" />
                                            <asp:BoundField DataField="transformation_Date" HeaderText="تاريخ التحويل" ItemStyle-Width="120" />
                                            <asp:BoundField DataField="Amount" HeaderText="قيمة التحويل" ItemStyle-Width="120" />
                                            <asp:BoundField DataField="Tenants_Arabic_Name" HeaderText="اسم المستأجر " ItemStyle-Width="120" />
                                            <%-------------------------------------------------------------------------------------------------%>
                                            <asp:CommandField ItemStyle-Width="10px" ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/English/Main_Application/Main_Image/Calander_Close.png" ControlStyle-Width="25px" ControlStyle-Height="25px" />
                                        </Columns>
                                        <RowStyle HorizontalAlign="Center" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <%--************************************************************** Cash Gridviwes *********************************************************************************************************************--%>
                            <div class="row">
                                <div class="table-responsive">
                                    <asp:GridView Width="100%" ID="Cash_GridView" runat="server" AutoGenerateColumns="false" DataKeyNames="Cash_Amount_ID" OnRowDeleting="Cash_GridView_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="Cash_Amount" HeaderText="قيمة الدفعة" ItemStyle-Width="120" />
                                            <asp:BoundField DataField="Cash_Date" HeaderText="تاريخ الدفعة" ItemStyle-Width="120" />
                                            <asp:BoundField DataField="Tenants_Arabic_Name" HeaderText="اسم المستأجر " ItemStyle-Width="120" />
                                            <%-------------------------------------------------------------------------------------------------%>
                                            <asp:CommandField ItemStyle-Width="10px" ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/English/Main_Application/Main_Image/Calander_Close.png" ControlStyle-Width="25px" ControlStyle-Height="25px" />
                                        </Columns>
                                        <RowStyle HorizontalAlign="Center" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="container-fluid" style="border-style: solid; border-radius: 10px;">
                        <%--************************************************************** transformation Input Feild *********************************************************************************************************************--%>

                        <div class="row" runat="server" id="transformation_Div" visible="false">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_transformation_No" runat="server" Text="رقم الحوالة"></asp:Label>
                                    <asp:TextBox ID="txt_transformation_No" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <asp:Label ID="lbl_transformation_Bank" runat="server" Text="اسم البنك"></asp:Label>
                                    <asp:DropDownList ID="transformation_Bank_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_transformation_Date" runat="server" Text="تاريخ التحويل"></asp:Label>&nbsp;
                            <asp:TextBox ID="txt_transformation_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:Button ID="transformation_Date_Button" runat="server" Text="إختر التاريخ" OnClick="transformation_Date_Button_Click" />
                                            <asp:ImageButton ID="ImageButton5" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton5_Click" runat="server" />
                                            <div id="transformation_Date_Div" runat="server" style="position: page;" visible="false">

                                                <asp:Calendar ID="transformation_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="transformation_Date_Calendar_SelectionChanged">
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
                                            <asp:AsyncPostBackTrigger ControlID="transformation_Date_Button" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="transformation_Date_Calendar" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton5" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <asp:Label ID="lbl_transformation_Amount" runat="server" Text="قيمة التحويل"></asp:Label>
                                    <asp:TextBox ID="txt_transformation_Amount" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <br />
                                <asp:ImageButton ID="btn_Add_Transformation" ImageUrl="Main_Image/plus.png" Width="25px" Height="25px" runat="server" OnClick="btn_Add_Transformation_Click" />
                            </div>
                        </div>

                        <%--************************************************************** Cash Input Feild *********************************************************************************************************************--%>


                        <div class="row" runat="server" id="Cash_div" visible="false">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Cash_Amount" runat="server" Text="قيمة الدفعة النقدية"></asp:Label>
                                    <asp:TextBox ID="txt_Cash_Amount" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Cash_Date" runat="server" Text="تاريخ الدفعة"></asp:Label>&nbsp;
                            <asp:TextBox ID="txt_Cash_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:Button ID="Cash_Date_Button" runat="server" Text="إختر التاريخ" OnClick="Cash_Date_Button_Click" />
                                            <asp:ImageButton ID="ImageButton6" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton6_Click" runat="server" />
                                            <div id="Cash_Date_Div" runat="server" style="position: page;" visible="false">

                                                <asp:Calendar ID="Cash_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cash_Date_Calendar_SelectionChanged">
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
                                            <asp:AsyncPostBackTrigger ControlID="transformation_Date_Button" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="transformation_Date_Calendar" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton5" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <br />
                                <asp:ImageButton ID="Add_Cash" ImageUrl="Main_Image/plus.png" Width="25px" Height="25px" runat="server" OnClick="Add_Cash_Click" />
                            </div>
                        </div>

                        <%--******************************************************************** Cheque Input Feild *******************************************************************************************--%>
                        <div calss="row">
                            <div class="row" style="overflow-x: auto;" runat="server" id="Cheque_Div">
                                <h4>إضافة شيك</h4>
                                &nbsp;&nbsp;
                                <asp:Label ID="lbl_Worrnig_Cheque" Text="معلومات الشيك غير كاملة ( اسم المستأجر  /  نوع الشيك  /  اسم البنك)" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                <div class="col-lg-12">
                                    <div class="form-group">

                                        <table>
                                            <tr>
                                                <th>رقم الشيك</th>
                                                <th>تاريخ الشيك</th>
                                                <th>قيمة الشيك</th>
                                                <th>نوع الشيك</th>
                                                <th>اسم البنك</th>
                                                <th>صاحب الشيك</th>
                                                <th>اسم المستفيد</th>
                                                <th></th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txt_Cheque_NO" runat="server"></asp:TextBox></td>
                                                <td>
                                                    <asp:UpdatePanel ID="Cheque_Date_UpdatePanel" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txt_Cheque_Date" runat="server" Width="150px" Enabled="false"></asp:TextBox>
                                                            <asp:Button ID="btn_Cheque_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque_Date_Chosee_Click" />
                                                            <asp:ImageButton ID="Cheque_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque_Date_ImageButton_Click" runat="server" />
                                                            <div id="Cheque_Date_Div" runat="server" visible="false" style="position: page;">
                                                                <asp:Calendar ID="Cheque_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque_Date_Calendar_SelectionChanged">
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
                                                            <asp:AsyncPostBackTrigger ControlID="Cheque_Date_Calendar" EventName="SelectionChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="btn_Cheque_Date_Chosee" EventName="Click" />
                                                            <asp:AsyncPostBackTrigger ControlID="Cheque_Date_ImageButton" EventName="Click" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_Cheque_Value" runat="server"></asp:TextBox></td>
                                                <td>
                                                    <asp:DropDownList ID="Cheque_Type_DropDownList" runat="server"></asp:DropDownList></td>
                                                <td>
                                                    <asp:DropDownList ID="Bank_Cheque_Name_DropDownList" runat="server" Width="150px"></asp:DropDownList></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Cheque_Owner" runat="server"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_beneficiary_person" runat="server"></asp:TextBox></td>
                                                <td>
                                                    <asp:ImageButton ID="ImageButton4" ImageUrl="Main_Image/plus.png" Width="25px" Height="25px" runat="server" OnClick="ImageButton4_Click" /></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
      <%-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
        <div class="row">
            <div class="col-lg-3">
                <br />
                <asp:Button ID="btn_Add_Contract" runat="server" Text="حفظ التغيرات" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" Width="248px" ValidationGroup="Contract_RequiredField" OnClick="btn_Add_Contract_Click" />
            </div>
            <div class="col-lg-3">
                <br />
                <asp:Button ID="btn_Back_To_Contract_List" runat="server" Text="العودة إلى قائمة العقود" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Contract_List_Click" />
            </div>
             <div >
                <br />
                <asp:LinkButton ID="Delete"  runat="server" ValidationGroup="Delete" OnClick="Delete_Contract_Click" OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');"  ><i class="fa fa-trash" style="font-size:40px; color:#0779c9"></i></asp:LinkButton>
            </div>
            <div class="col-lg-3">
                 <div class="form-group" runat="server" id="Reason_Div">
                    <asp:Label ID="lbl_Reason_Delete" runat="server" Text="سبب الحذف" ></asp:Label>
                    <asp:TextBox ID="txt_Reason_Delete" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Delete_ReqFieVal" ControlToValidate="txt_Reason_Delete"
                    runat="server" ErrorMessage="* يرجى توضيح سبب الحذف" ForeColor="Red" ValidationGroup="Delete"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    <%-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
    <script>$('#<%=Tenan_Name_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Payment_Type_DropDownList.ClientID%>').chosen();</script>
    <%--<script>$('#<%=Payment_Frquancy_DropDownList.ClientID%>').chosen();</script>--%>
    <script>$('#<%=Contract_Type_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Contract_Templet_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Units_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Ownership_Name_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Building_Name_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Com_Rep_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Reason_For_Rent_DropDownList.ClientID%>').chosen();</script>
</asp:Content>
