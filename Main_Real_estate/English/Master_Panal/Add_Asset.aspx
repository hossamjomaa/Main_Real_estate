<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Add_Asset.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Add_Asset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" />
    <!----------------------------------------------------------------------------------------------------------->
    <div class="container-fluid" id="container-wrapper">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Asset" runat="server" Text="إضافة أصل جديد"></asp:Label><asp:Label ID="Last_Asset_ID" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Success_Add_New_Asset" runat="server" ForeColor="#00FF40"></asp:Label>
            </h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-12">
                    <div class="card-body">
                        <div class="row">
                             <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ownership_Building_Unit" runat="server" Text="ملكية / بناء / وحدة / مخزن"></asp:Label>
                                    <asp:DropDownList ID="Ownership_Building_Unit_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Ownership_Building_Unit_DropDownList_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="ملكية"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="بناء"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="وحدة"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="مخزن"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Ownership_Building_Unit_RequiredFieldValidator" ControlToValidate="Ownership_Building_Unit_DropDownList"
                                        InitialValue="إختر ملكية / بناء / وحدة  ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-6" id="Inventory_Div" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Inventory" runat="server" Text="اسم المخزن"></asp:Label>
                                    <asp:DropDownList ID="Inventory_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Inventory_RequiredFieldValidator" ControlToValidate="Inventory_DropDownList"
                                        InitialValue="إختر اسم المخزن  ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                         <!----------------------------------------------------------------------------------------------------------->
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Asset_Type" runat="server" Text="النوع الاساسي الأصل"></asp:Label>
                                    <asp:DropDownList ID="Asset_Type_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Asset_Type_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Asset_Type_RequiredFieldValidator" ControlToValidate="Asset_Type_DropDownList"
                                        InitialValue="أختر النوع الأساسي للأصل ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Asset_SubType" runat="server" Text="النوع الفرعي الأصل"></asp:Label>
                                    <asp:DropDownList ID="Asset_SubType_DropDownList" runat="server" CssClass="form-control" Enabled="false">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Asset_SubType_RequiredFieldValidator" ControlToValidate="Asset_SubType_DropDownList"
                                        InitialValue="أختر النوع الفرعي للأصل ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Asset_Condition" runat="server" Text="حالة الأصل"></asp:Label>
                                    <asp:DropDownList ID="Asset_Condition_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Asset_Condition_RequiredFieldValidator" ControlToValidate="Asset_Condition_DropDownList"
                                        InitialValue="أختر حالة الاصل ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            

                        </div>
                        <!----------------------------------------------------------------------------------------------------------->
                         <div class="row" id="Ownership_Building_Unit_Div" runat="server" visible="false">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ownership_Name" runat="server" Text="اسم الملكية"></asp:Label>
                                    <asp:DropDownList ID="Ownership_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Ownership_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Ownership_Name_RequiredFieldValidator" ControlToValidate="Ownership_Name_DropDownList"
                                        InitialValue="إختر اسم الملكية ...." runat="server" ValidationGroup="Contract_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Name" runat="server" Text="اسم البناء"></asp:Label>
                                    <asp:DropDownList ID="Building_Name_DropDownList" runat="server" CssClass="form-control" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="Building_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Building_Name_RequiredFieldValidator" ControlToValidate="Building_Name_DropDownList"
                                        InitialValue="إختر اسم البناء ...." runat="server" ValidationGroup="Contract_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3" id="Unit_Div" runat="server">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Units" runat="server" Text="الوحدة"></asp:Label>
                                    <asp:DropDownList ID="Units_DropDownList" runat="server" CssClass="form-control" Enabled="false">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Units_DropDownList"
                                        InitialValue="إختر الوحدة ...." runat="server" ValidationGroup="Contract_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Asset_Location" runat="server" Text="مكان الأصل"></asp:Label>
                                    <asp:DropDownList ID="Asset_Location_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Asset_Location_RequiredFieldValidator" ControlToValidate="Asset_Location_DropDownList"
                                        InitialValue="إختر مكان الأصل ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <!----------------------------------------------------------------------------------------------------------->
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_How_To_Get" runat="server" Text="طريقة التملك "></asp:Label>
                                    <asp:DropDownList ID="How_To_Get_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="How_To_Get_DropDownList_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="ضمن مشروع"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="شراء"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="How_To_Get_RequiredFieldValidator" ControlToValidate="How_To_Get_DropDownList"
                                        InitialValue="أختر طريقة التملك ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-3" id="Contractor_Div" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Contractor" runat="server" Text="المقاول"></asp:Label>
                                    <asp:DropDownList ID="Contractor_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="Contracto_RequiredFieldValidator" ControlToValidate="Contracto_DropDownList"
                                        InitialValue="إختر المقاول  ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>


                            <div class="col-lg-3" id="Buyer_Div" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Buyer" runat="server" Text="مسؤول الشراء"></asp:Label>
                                    <asp:DropDownList ID="Buyer_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="Contracto_RequiredFieldValidator" ControlToValidate="Contracto_DropDownList"
                                        InitialValue="إختر المقاول  ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Asset_Vendor" runat="server" Text="الموّرد"></asp:Label>
                                    <asp:DropDownList ID="Asset_Vendor_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Asset_Vendor_RequiredFieldValidator" ControlToValidate="Asset_Vendor_DropDownList"
                                        InitialValue="إختر الموّرد  ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                             <div class="col-lg-3" id="Contractor_Warranty_Period_Div" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Contractor_Warranty_Period" runat="server" Text="فترة ضمان المقاول "></asp:Label>
                                    <asp:TextBox ID="txt_Contractor_Warranty_Period" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_En_Asset_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red" ValidationGroup="Asset_RequiredField"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            </div>
                        <!----------------------------------------------------------------------------------------------------------->
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Asset_Name" runat="server" Text="اسم الاصل بالأنكليزية "></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="Asset_Name_RegularExpressionValidator" runat="server" ControlToValidate="txt_En_Asset_Name"
                                        EnableClientScript="True" ErrorMessage="فقط أحرف أنكليزية" ForeColor="Red"
                                        ValidationExpression="[a-z A-Z0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_En_Asset_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Asset_Name_reqFuild" ControlToValidate="txt_En_Asset_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red" ValidationGroup="Asset_RequiredField"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Asset_Name" runat="server" Text="اسم الأصل بالعربية"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="Ar_Asset_Name_RegularExpressionValidator" runat="server" ControlToValidate="txt_Ar_Asset_Name"
                                        EnableClientScript="True" ErrorMessage="فقط أحرف عربية" ForeColor="Red"
                                        ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ar_Asset_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Ar_Asset_Name_RequiredFieldValidator" ControlToValidate="txt_Ar_Asset_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red" ValidationGroup="Asset_RequiredField"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                             <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Serial_Number" runat="server" Text="الرقم التسلسلي للأصل"></asp:Label>&nbsp;
                                    <asp:TextBox ID="txt_Serial_Number" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_purchase_Date" runat="server" Text="تاريخ شراء الأصل"></asp:Label>&nbsp;

                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="txt_purchase_Date" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                            ErrorMessage="يجب أن يكون التاريخ بالنمط:  dd/MM/yyyy" ValidationGroup="Asst_RequiredField"  ForeColor="Red"/>

                                            <asp:TextBox ID="txt_purchase_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:Button ID="purchase_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Date_Chosee_Click" />
                                            <asp:ImageButton ID="ImageButton1" ImageUrl="../Main_Application/Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton1_Click" runat="server" />
                                            <div id="purchase_Date_divCalendar" runat="server" style="position: page;" visible="false">
                                                <asp:Calendar ID="purchase_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="purchase_Date_Calendar_SelectionChanged1">
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
                                            <asp:AsyncPostBackTrigger ControlID="purchase_Date_Chosee" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="purchase_Date_Calendar" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                            
                        
                        <!----------------------------------------------------------------------------------------------------------->
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Asset_Value" runat="server" Text="قيمة الأصل"></asp:Label>&nbsp;
                                <asp:RegularExpressionValidator ID="Asset_Value_RegularExpressionValidator" runat="server" ControlToValidate="txt_Asset_Value"
                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Asset_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Asset_Value_reqFuild" ControlToValidate="txt_Asset_Value"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red" ValidationGroup="Asset_RequiredField"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                           
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Asset_Description" runat="server" Text="وصف الأصل"></asp:Label>
                                    <asp:TextBox ID="txt_Asset_Description" runat="server" CssClass="form-control" TextMode="MultiLine" Height="40px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Asset_Description_RequiredFieldValidator" ControlToValidate="txt_Asset_Description"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red" ValidationGroup="Asst_RequiredField"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            
                        </div>
                       
                        <!----------------------------------------------------------------------------------------------------------->
                       
                        <asp:CheckBox ID="Warenty_CheckBox" runat="server" Text="إضافة ضمان للأصل " Font-Size="25px" AutoPostBack="true" OnCheckedChanged="Warenty_CheckBox_CheckedChanged"/>
                        
                    <!----------------------------------------------------------------------------------------------------------->
                    <div class="row" style="border-style: solid" id="Waranty_Div" runat="server" visible="false">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Warranty_Period" runat="server" Text="مدة الضمان"></asp:Label>&nbsp;
                                    <asp:TextBox ID="txt_Warranty_Period" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Warranty_Period_RequiredFieldValidator" ControlToValidate="txt_Warranty_Period"
                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red" ValidationGroup="Asset_RequiredField"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="Start_Date_UpdatePanel" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lbl_Start_Date" runat="server" Text="تاريخ بدء الضمان"></asp:Label>&nbsp;

                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txt_Start_Date" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                            ErrorMessage="يجب أن يكون التاريخ بالنمط:  dd/MM/yyyy" ValidationGroup="Asst_RequiredField"  ForeColor="Red"/>

                                        <asp:TextBox ID="txt_Start_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Button ID="Start_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Start_Date_Chosee_Click" />
                                    <asp:ImageButton ID="ImageButton2" ImageUrl="../Main_Application/Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton2_Click" runat="server" />
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
                                    <asp:Label ID="lbl_End_Date" runat="server" Text="تاريخ إنتهاء الضمان"></asp:Label>&nbsp;

                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txt_End_Date" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                            ErrorMessage="يجب أن يكون التاريخ بالنمط:  dd/MM/yyyy" ValidationGroup="Asst_RequiredField"  ForeColor="Red"/>


                                        <asp:TextBox ID="txt_End_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Button ID="End_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="End_Date_Chosee_Click" />
                                    <asp:ImageButton ID="ImageButton3" ImageUrl="../Main_Application/Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton3_Click" runat="server" />
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
                                    <asp:AsyncPostBackTrigger ControlID="End_Date_Chosee" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="ImageButton3" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Waranty_Image" runat="server" Text="صورة شهادة الضمان"></asp:Label>
                                <asp:FileUpload ID="Waranty_Image_FileUpload" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div><br />
        <div class="row">
        <asp:Button ID="btn_Add_Asset" runat="server" Text="إضافة أصل جديد" CssClass="btn btn" ValidationGroup="Asst_RequiredField" BackColor="#52a2da" ForeColor="White" Width="248px" OnClick="btn_Add_Asset_Click"   />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Back_To_Asset_List" runat="server" Text="العودة لقائمة الأصلول" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Asset_List_Click"/>
    </div><br /><br />
    </div>  
    
    <script>$('#<%=Asset_Type_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Asset_Condition_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Asset_Location_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Building_Name_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Ownership_Name_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Units_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Asset_Vendor_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Asset_SubType_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=How_To_Get_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Ownership_Building_Unit_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Inventory_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Buyer_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Contractor_DropDownList.ClientID%>').chosen();</script>
</asp:Content>
