<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Add_Contract.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Add_Contract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        table {
            width: 100%;
        }

      th {
            border: 1px solid #dddddd;
            text-align: center;
            padding: 8px;
        }
        td{
            border: 1px solid #dddddd;
            padding: 8px;
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
                <asp:Label ID="lbl_titel_Add_New_Tenant" runat="server" Text="إضافة عقد جديد"></asp:Label>
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
                                 <div class="form-group">
                                    <asp:Label ID="lbl_Employee_Name" runat="server" Text="اسم الموظف"></asp:Label>
                                     <asp:TextBox ID="txt_Employee_Name" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    <%--<asp:DropDownList ID="Employee_Name_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>--%>
                                    <asp:RequiredFieldValidator ID="Employee_Name_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="txt_Employee_Name"
                                        InitialValue="إختر اسم الموظف ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg">
                               <div class="form-group">
                                    <asp:Label ID="lbl_Tenan_Name" runat="server" Text="اسم المستأجر"></asp:Label>
                                    <asp:DropDownList ID="Tenan_Name_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Tenan_Name_RequiredFieldValidator" ControlToValidate="Tenan_Name_DropDownList"
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
                            <div class="col-lg">
                                <div class="form-group">
                                    <asp:Label ID="LabelX" runat="server" Text="نوع العقد"></asp:Label>
                                    <asp:DropDownList ID="Contract_Type_DropDownList" runat="server"  CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Contract_Type_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Contract_Type_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="Contract_Type_DropDownList"
                                        InitialValue="إخترنوع العقد ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg">
                            <div  id="div_No_Of_Months" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_No_Of_Months" runat="server"></asp:Label>
                                    <asp:DropDownList ID="No_Of_Months_DropDownList" runat="server"  CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="No_Of_Months_DropDownList_SelectedIndexChanged">
                                        <%--<asp:ListItem Value="1" Text="1"></asp:ListItem> <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="3"></asp:ListItem> <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="5"></asp:ListItem> <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="7"></asp:ListItem> <asp:ListItem Value="8" Text="8"></asp:ListItem>
                                        <asp:ListItem Value="9" Text="9"></asp:ListItem> <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                        <asp:ListItem Value="11" Text="11"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="No_Of_Months_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="Contract_Type_DropDownList"
                                        InitialValue="إختر عدد الأشهر ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                                </div>
                        </div>
                        <div class="row">
                            <h6><asp:Label ID="lbl_Add_Cheques" runat="server" Text="إضافة الشيكات" Visible="false"></asp:Label></h6> &nbsp;&nbsp;
                            <asp:ImageButton ID="Close_Cheque_Table_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Close_Cheque_Table_ImageButton_Click" runat="server" />
                            
                            <div class="col-lg-12">
                                <div class="form-group">
                                <table id="Cheque_Tbl" runat="server" visible="false">
                                    
                                    <tr>
                                        <th></th>
                                        <th>رقم الشيك</th>
                                        <th>تاريخ الشيك</th>
                                        <th>قيمة الشيك</th>
                                        <th>نوع الشيك</th>
                                        <th>اسم البنك</th>
                                        <th>اسم المستأجر</th>
                                        
                                    </tr>
                                    <tr id="Cheque_1" runat="server">
                                        <td>1</td>
                                        <td><asp:TextBox ID="TextBox67" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:UpdatePanel ID="Cheque1_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque1_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque1_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque1_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque1_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque1_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque1_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque1_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque1_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque1_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque1_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque1_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td><asp:TextBox ID="TextBox69" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox70" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox71" runat="server"></asp:TextBox>
                                        </td>
                                        <td><asp:TextBox ID="TextBox72" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr id="Cheque_2" runat="server">
                                        <td>2</td>
                                        <td><asp:TextBox ID="TextBox61" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:UpdatePanel ID="Cheque2_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque2_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque2_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque2_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque2_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque2_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque2_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque2_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque2_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque2_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque2_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque2_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td><asp:TextBox ID="TextBox63" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox64" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox65" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox66" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr id="Cheque_3" runat="server">
                                        <td>3</td>
                                        <td><asp:TextBox ID="TextBox55" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:UpdatePanel ID="Cheque3_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque3_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque3_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque3_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque3_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque3_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque3_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque3_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque3_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque3_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque3_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque3_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td><asp:TextBox ID="TextBox57" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox58" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox59" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox60" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr id="Cheque_4" runat="server">
                                        <td>4</td>
                                        <td><asp:TextBox ID="TextBox54" runat="server"></asp:TextBox></td>
                                        <td><asp:UpdatePanel ID="Cheque4_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque4_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque4_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque4_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque4_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque4_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque4_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque4_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque4_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque4_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque4_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque4_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel></td>
                                        <td><asp:TextBox ID="TextBox52" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox51" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox50" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox49" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr id="Cheque_5" runat="server">
                                        <td>5</td>
                                        <td><asp:TextBox ID="TextBox48" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:UpdatePanel ID="Cheque5_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque5_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque5_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque5_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque5_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque5_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque5_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque5_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque5_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque5_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque5_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque5_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td><asp:TextBox ID="TextBox46" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox45" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox44" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox43" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr id="Cheque_6" runat="server" >
                                        <td>6</td>
                                        <td><asp:TextBox ID="TextBox42" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:UpdatePanel ID="Cheque6_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque6_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque6_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque6_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque6_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque6_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque6_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque6_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque6_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque6_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque6_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque6_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td><asp:TextBox ID="TextBox40" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox39" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox38" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox37" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr id="Cheque_7" runat="server">
                                        <td>7</td>
                                        <td><asp:TextBox ID="TextBox36" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:UpdatePanel ID="Cheque7_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque7_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque7_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque7_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque7_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque7_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque7_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque7_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque7_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque7_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque7_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque7_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td><asp:TextBox ID="TextBox34" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox33" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox32" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox31" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr id="Cheque_8" runat="server">
                                        <td>8</td>
                                        <td><asp:TextBox ID="TextBox30" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:UpdatePanel ID="Cheque8_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque8_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque8_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque8_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque8_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque8_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque8_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque8_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque8_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque8_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque8_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque8_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td><asp:TextBox ID="TextBox28" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox27" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox26" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox25" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr id="Cheque_9" runat="server">
                                        <td>9</td>
                                        <td><asp:TextBox ID="TextBox24" runat="server"></asp:TextBox></td>
                                        <td><asp:UpdatePanel ID="Cheque9_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque9_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque9_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque9_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque9_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque9_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque9_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque9_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque9_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque9_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque9_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque9_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel></td>
                                        <td><asp:TextBox ID="TextBox22" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox21" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox20" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox19" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr id="Cheque_10" runat="server">
                                        <td>10</td>
                                        <td><asp:TextBox ID="TextBox18" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:UpdatePanel ID="Cheque10_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque10_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque10_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque10_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque10_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque10_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque10_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque10_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque10_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque10_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque10_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque10_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td><asp:TextBox ID="TextBox16" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox15" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox14" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox13" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr id="Cheque_11" runat="server">
                                        <td>11</td>
                                        <td><asp:TextBox ID="TextBox12" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:UpdatePanel ID="Cheque11_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque11_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque11_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque11_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque11_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque11_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque11_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque11_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque11_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque11_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque11_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque11_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr id="Cheque_12" runat="server" >
                                        <td>12</td>
                                        <td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:UpdatePanel ID="Cheque12_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque12_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque12_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque12_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque12_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque12_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque12_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque12_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque12_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque12_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque12_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque12_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr id="Cheque_13" runat="server" >
                                        <td>13</td>
                                        <td><asp:TextBox ID="TextBox73" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:UpdatePanel ID="Cheque13_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                             <asp:TextBox ID="txt_Cheque13_Date" runat="server" ></asp:TextBox>
                                                    <asp:Button ID="btn_Cheque13_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="btn_Cheque13_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="Cheque13_Date_ImageButton" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="Cheque13_Date_ImageButton_Click" runat="server" />
                                                    <div id="Cheque13_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Cheque13_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Cheque13_Date_Calendar_SelectionChanged">
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
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque13_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Cheque13_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="Cheque13_Date_ImageButton" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td><asp:TextBox ID="TextBox75" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox76" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox77" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TextBox78" runat="server"></asp:TextBox></td>
                                    </tr>
                                </table>
                                    </div>
                                <br />
                            </div>
                        </div>
                        
                        
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Tenant_Type" runat="server" Text="نموذج العقد"></asp:Label>
                                    <asp:DropDownList ID="Contract_Templet_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Tenant_Type_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="Contract_Templet_DropDownList"
                                        InitialValue="إختر نموذج العقد ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="تكرار الدفعات"></asp:Label>
                                    <asp:DropDownList ID="Payment_Frquancy_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Payment_Frquancy_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="Payment_Frquancy_DropDownList"
                                        InitialValue="إختر تكرار الدفعات ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="نوع الدفعات"></asp:Label>
                                    <asp:DropDownList ID="Payment_Type_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Payment_Type_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="Payment_Type_DropDownList"
                                        InitialValue="إخترنوع الدفع ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>                                
                            </div>
                            <div class="col-lg-3">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Payment_Amount" runat="server" Text="مبلغ الدفع"></asp:Label>&nbsp;
                                        <asp:RegularExpressionValidator ID="Payment_Amount_RegularExpressionValidator" runat="server" ControlToValidate="txt_Payment_Amount"
                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txt_Payment_Amount" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Payment_Amount_RequiredFieldValidator" ValidationGroup="Contract_RequiredField" ControlToValidate="txt_Payment_Amount"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                        </div>
                        
                       

                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Sign_Date" runat="server" Text="تاريخ توقيع العقد"></asp:Label>&nbsp;
                                            <asp:TextBox ID="txt_Sign_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:Button ID="Sign_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Date_Chosee_Click" />
                                            <asp:ImageButton ID="ImageButton1" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton1_Click" runat="server" />
                                            <div id="Sign_Date_divCalendar" runat="server" style="position: page;" visible="false">

                                                <asp:Calendar ID="Sign_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Sign_Date_Calendar_SelectionChanged1">
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
                                            <asp:AsyncPostBackTrigger ControlID="Sign_Date_Chosee" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="Sign_Date_Calendar" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton3" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <asp:UpdatePanel ID="Start_Date_UpdatePanel" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lbl_Start_Date" runat="server" Text="تاريخ البدء"></asp:Label>&nbsp;
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
                            <div class="col-lg-3">
                                <asp:UpdatePanel ID="End_Date_UpdatePanel" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lbl_End_Date" runat="server" Text="تاريخ الإنتهاء"></asp:Label>&nbsp;
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
                                        <asp:AsyncPostBackTrigger ControlID="Sign_Date_Calendar" EventName="SelectionChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="Start_Date_Chosee" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="ImageButton3" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Contract_Details" runat="server" Text="ملاحظات و بنود إضافية"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="Contract_Details_RegularExpressionValidator" runat="server" ControlToValidate="txt_Contract_Details"
                                        EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                        ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Contract_Details" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Contract_RequiredField" ControlToValidate="txt_Contract_Details"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        


                    </div>
                </div>
            </div>
          <%--  <div class="col-lg-6">
                <div class="card mb-4">
                    <div class="card-body">
                                              
                        
                        
                      
                            <div class="row">
                                <div class="col-lg-6">
                                   
                                </div>


                                 
                                <div class="col-lg-6">
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
        <asp:Button ID="btn_Add_Contract" runat="server" Text="إضافة عقد" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" Width="248px" ValidationGroup="Contract_RequiredField" OnClick="btn_Add_Contract_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Contract_List" runat="server" Text="العودة إلى قائمة العقود" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Contract_List_Click"/> 
    <br />
    <script>$('#<%=Tenan_Name_DropDownList.ClientID%>').chosen();</script>
     <script>$('#<%=Payment_Type_DropDownList.ClientID%>').chosen();</script>
     <script>$('#<%=Payment_Frquancy_DropDownList.ClientID%>').chosen();</script>
     <script>$('#<%=Contract_Type_DropDownList.ClientID%>').chosen();</script>
     <%--<script>$('#<%=Employee_Name_DropDownList.ClientID%>').chosen();</script>--%>
     <script>$('#<%=Contract_Templet_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Units_DropDownList.ClientID%>').chosen();</script>


    
</asp:Content>
