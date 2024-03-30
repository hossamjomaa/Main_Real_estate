<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Add_OwnerShip.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Add_OwnerShip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" />


    <div class="container-fluid" id="container-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Ownership" runat="server" Text="إضافة ملكية جديدة"></asp:Label>&nbsp;
                <asp:Label ID="lbl_Success_Add_New_Ownership" runat="server" ForeColor="Green"></asp:Label>
            </h1>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="card mb-6">
                    <div class="card-body" style="height:683px">
                        <div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_En_Ownership_Name" runat="server" Text="الاسم بالإنكليزية"></asp:Label>
                                        <asp:RegularExpressionValidator ID="Reg_Ex_En_Ownership_Name" runat="server" ControlToValidate="txt_En_Ownership_Name"
                                            EnableClientScript="True" ErrorMessage="أحرف إنكليزية فقط" ForeColor="Red"
                                            ValidationExpression="[a-z A-Z]+"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txt_En_Ownership_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req_Val_En_Ownership_Name" ControlToValidate="txt_En_Ownership_Name"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Ar_Ownership_Name" runat="server" Text="الاسم بالعربية"></asp:Label>
                                        <asp:RegularExpressionValidator ID="Reg_Ex_Ar_Ownership_Name" runat="server" ControlToValidate="txt_Ar_Ownership_Name"
                                            EnableClientScript="True" ErrorMessage="أحرف عربية فقط" ForeColor="Red"
                                            ValidationExpression="[ا-ي أآى ة ئ ء ؤ]+"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txt_Ar_Ownership_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req_Val_Ar_Ownership_Name" ControlToValidate="txt_Ar_Ownership_Name"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Ownership_Number" runat="server" Text="رقم الملكية"></asp:Label>
                                        <asp:RegularExpressionValidator ID="Reg_Exp_Ownership_Number" runat="server" ControlToValidate="txt_Ownership_Number"
                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txt_Ownership_Number" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req_Val_Ownership_Number" ControlToValidate="txt_Ownership_Number"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Ownership_Certificate" runat="server" Text="شهادة الملكية"></asp:Label>
                                        <asp:TextBox ID="txt_Ownership_Certificate" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req_Val_Ownership_Certificate" ControlToValidate="txt_Ownership_Certificate"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Ownership_Lande_Initial_Value" runat="server" Text="قيمة الأرض"></asp:Label>

                                        <asp:RegularExpressionValidator ID="Reg_Exp_Land_Vaue" runat="server" ControlToValidate="txt_Ownership_Lande_Initial_Value"
                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>

                                        <asp:TextBox ID="txt_Ownership_Lande_Initial_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req_Val_Lande_Value" ControlToValidate="txt_Ownership_Lande_Initial_Value"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Building_Number" runat="server" Text="رقم البناء"></asp:Label>
                                        <asp:RegularExpressionValidator ID="Reg_Exp_Building_Number" runat="server" ControlToValidate="txt_Building_Number"
                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txt_Building_Number" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req_Val_Building_Number" ControlToValidate="txt_Building_Number"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">

                                                <asp:Label ID="lbl_Ownership_Space_Number" runat="server" Text="الرقم المساحي"></asp:Label>&nbsp;&nbsp;  
                                                <asp:RegularExpressionValidator ID="Reg_Exp_Ownership_Space_Number" runat="server" ControlToValidate="txt_Ownership_Space_Number"
                                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                <asp:TextBox ID="txt_Ownership_Space_Number" ReadOnly="true" runat="server" CssClass="form-control" OnTextChanged="txt_Ownership_Space_Number_TextChanged" AutoPostBack="true"></asp:TextBox>
                                             
                                                
                                                <asp:RequiredFieldValidator ID="Req_Val_Ownership_Space_Number" ControlToValidate="txt_Ownership_Space_Number"
                                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>



                                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBox1" AutoPostBack="true" runat="server" Text=" 7  أرقام" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:CheckBox AutoPostBack="true" ID="CheckBox2" runat="server" Text="8 أرقام" OnCheckedChanged="CheckBox2_CheckedChanged" />

                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Zone_Name" runat="server" Text="اسم المنطقة"></asp:Label>
                                                <asp:DropDownList ID="Zone_Name_DropDownList" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Zone_Name_Req_Val" ControlToValidate="Zone_Name_DropDownList"
                                                    InitialValue="أختر إسم المنطقة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="CheckBox1" EventName="CheckedChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="CheckBox2" EventName="CheckedChanged" />

                                </Triggers>
                            </asp:UpdatePanel>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Street_Number" runat="server" Text="رقم الشارع"></asp:Label>
                                        <asp:RegularExpressionValidator ID="Reg_Exp_Street_Number" runat="server" ControlToValidate="txt_Street_Number"
                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txt_Street_Number" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req_Val_Street_Number" ControlToValidate="txt_Street_Number"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Bond_Update" runat="server" Text="تحديث السند"></asp:Label>
                                        <%--<asp:RegularExpressionValidator  ID="Reg_Exp_Bond_Update" runat="server" ControlToValidate="txt_Bond_Update"
                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>--%>
                                        <asp:TextBox ID="txt_Bond_Update" runat="server" CssClass="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="Req_Val_Bond_Update" ControlToValidate="txt_Bond_Update"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:Label ID="lbl_Annual_Difference" runat="server" Text="الفرق السنوي"></asp:Label>
                                    <asp:TextBox ID="txt_Annual_Difference" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <asp:Label ID="lbl_ROI" runat="server" Text="الإسترداد"></asp:Label>
                                    <asp:TextBox ID="txt_ROI" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card mb-6">
                    <div class="card-body">
                        <div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Owner_Name" runat="server" Text="اسم المالك"></asp:Label>
                                        <asp:DropDownList ID="Owner_DropDownList" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Owner_Name_Req_dVal" ControlToValidate="Owner_DropDownList"
                                            InitialValue="اختر إسم المالك ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Ownership_Status" runat="server" Text="حالة الملكية"></asp:Label>
                                        <asp:DropDownList ID="Ownership_Status_DropDownList" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Ownership_Status_Req_Val" ControlToValidate="Ownership_Status_DropDownList"
                                            InitialValue="إختر حالة الملكية ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">


                                    <div class="form-group">
                                        <asp:Label ID="lbl_Buildings_Type" runat="server" Text="نوع الأبنية"></asp:Label>
                                        <asp:DropDownList ID="Buildings_Type_DropDownList" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Req_dVal_Buildings_Type" ControlToValidate="Buildings_Type_DropDownList"
                                            InitialValue="أختر نوع الأبنية ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </div>



                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Ownership_Area_Space" runat="server" Text="مساحة المنطقة"></asp:Label>
                                        <asp:RegularExpressionValidator CssClass="reg_B_N" ID="Reg_Exp_Ownership_Area_Space" runat="server" ControlToValidate="txt_Ownership_Area_Space"
                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txt_Ownership_Area_Space" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req_Val_Ownership_Area_Space" ControlToValidate="txt_Ownership_Area_Space"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:Label ID="lbl_Remaining_amount" runat="server" Text="المبلغ المتبقي"></asp:Label>
                                    <asp:TextBox ID="txt_Remaining_amount" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <asp:Label ID="lbl_Remaining_time" runat="server" Text="الزمن المتبقي"></asp:Label>
                                    <asp:TextBox ID="txt_Remaining_time" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:Label ID="lbl_Building_Value" runat="server" Text="قيمة المباني"></asp:Label>
                                    <asp:TextBox ID="txt_Building_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <asp:Label ID="lbl_Total_Value" runat="server" Text="القيمة الكلية"></asp:Label>
                                    <asp:TextBox ID="txt_Total_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:Label ID="lbl_Mortgage_Value" runat="server" Text="قيمة الرهن"></asp:Label>
                                    <asp:TextBox ID="txt_Mortgage_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <asp:Label ID="lbl_Mortgage_Status" runat="server" Text="وضع الرهن"></asp:Label>
                                    <asp:TextBox ID="txt_Mortgage_Status" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row" style="margin-top: 9px">
                                <div class="col-lg-4">
                                    <asp:Label ID="lbl_Annual_Revenue" runat="server" Text="المحصل السنوي"></asp:Label>
                                    <asp:TextBox ID="txt_Annual_Revenue" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:Label ID="lbl_Difference_of_the_collections" runat="server" Text="فرق التحصيل"></asp:Label>
                                    <asp:TextBox ID="txt_Difference_of_the_collections" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                                <asp:Label ID="lbl_Release_Date" runat="server" Text="تاريخ التحرير"></asp:Label>&nbsp;
                                                 <asp:TextBox ID="txt_Release_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                                <input type="button" value="إختر التاريخ" onclick="OnClick()"><br />
                                                <div id="Release_Date_divCalendar" style="position: unset; display:none">
                                                <asp:Calendar ID="Release_Date_Calendar" runat="server" Height="200px" Width="220px" 
                                                BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" 
                                                Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Release_Date_Calendar_SelectionChanged">
                                                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                                <OtherMonthDayStyle ForeColor="#999999" />
                                                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" 
                                                 Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                                <WeekendDayStyle BackColor="#CCCCFF" />
                                                </asp:Calendar>
                                            </div>
                                            <%--<asp:RequiredFieldValidator ID="Release_Date_RequiredFieldValidator" ControlToValidate="txt_Release_Date"
                                                runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Release_Date_Calendar" EventName="SelectionChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div id="container" class="container-fluid" style="border-style: solid; border-radius: 10px;">
            <%--<h3>Attachment</h3>--%><h3>مرفقات</h3>
            <div class="row">
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Label ID="lbl_Ownership_Certificates" runat="server" Text="تحميل شهادة الملكية"></asp:Label>
                        <asp:FileUpload ID="Ownership_Certificate_FileUpload" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Label ID="lbl_Ownership_Complition_Certificates" runat="server" Text="تحميل شهادة الإنجاز"></asp:Label>
                        <asp:FileUpload ID="Complition_Certificate_FileUpload" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lbl_Ownership_Building_License" runat="server" Text="تحميل رخصة البناء"></asp:Label>
                    <asp:FileUpload ID="Building_LicenseFileUpload" runat="server" CssClass="form-control" />
                </div>

                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Label ID="lbl_Ownership_Plan" runat="server" Text="تحميل الخطة"></asp:Label>
                        <asp:FileUpload ID="Plan_FileUpload" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Label ID="lbl_Ownership_Statment" runat="server" Text="تحميل البيان"></asp:Label>
                        <asp:FileUpload ID="Statment_FileUpload" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="Label17" runat="server" Text="تحميل أية ملفات أخرى"></asp:Label>
                    <asp:FileUpload ID="Other_FileUpload" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>
        <br />
        <div class="col-lg-4">

            <asp:Button ID="btn_Add_Ownership" runat="server" Text="إضافة ملكية" CssClass="btn  mb-1" OnClick="btn_Add_Ownership_Click" BackColor="#52a2da" ForeColor="White" />
            &nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_OwnerShip_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الملكيات" ValidationGroup="x" OnClick="btn_Back_To_OwnerShip_List_Click1" />
        </div>
        <br />
        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>--%>
                <asp:Button ID="Add_Building_TO_This_Ownership" runat="server" Text="هل تريد إضافة بناء لهذه الملكية" OnClick="Add_Building_TO_This_Ownership_Click" Visible="false"  ValidationGroup="x" /><br />
                <br />



                <%--*************************************************************************************************************************--%>
                <%--*************************************************************************************************************************--%>
                <%--*************************************** لوحة إضافة بناء لذات الملكية المضافة ********************************************--%>

                <asp:Panel ID="Panel1" runat="server" CssClass="Ownership_Building_Panel" Style="margin-right: -20px;" Visible="false">
                    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
                    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
                    <link href="../CSS/DDL.css" rel="stylesheet" />

                    <div class="container-fluid" id="container-wrapper1">
                        <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">
                                <asp:Label ID="lbl_titel_Add_New_Building" runat="server" Text=" إضافة بناء جديد للملكية :"></asp:Label>&nbsp;
                                <asp:Label ID="lbl_Name_Of_Added_Ownership" runat="server" Text=""></asp:Label>
                                <asp:Label ID="ownership_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                        
                                <asp:Label ID="lbl_Success_Add_New_Building" runat="server" ForeColor="Green"></asp:Label>
                            </h1>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="card mb-6">
                                    <div class="card-body">
                                        <div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_En_Building_Name" runat="server" Text="الاسم بالإنكليزية"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="Reg_EX_En_Building_Name" runat="server" ControlToValidate="txt_En_Building_Name"
                                                            EnableClientScript="True" ErrorMessage="أحرف إنكليزية فقط" ForeColor="Red"
                                                            ValidationExpression="[a-z A-Z]+"></asp:RegularExpressionValidator>
                                                        <asp:TextBox ID="txt_En_Building_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Req_Val_En_Building_Name" ControlToValidate="txt_En_Building_Name"
                                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Ar_Building_Name" runat="server" Text="الاسم بالعربية"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="Reg_EX_Ar_Building_Name" runat="server" ControlToValidate="txt_Ar_Building_Name"
                                                            EnableClientScript="True" ErrorMessage="أحرف عربية فقط" ForeColor="Red"
                                                            ValidationExpression="[ا-ي أآى ة ئ ء ؤ]+"></asp:RegularExpressionValidator>
                                                        <asp:TextBox ID="txt_Ar_Building_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Req_Val_Ar_Building_Name" ControlToValidate="txt_Ar_Building_Name"
                                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Building_NO" runat="server" Text="رقم البناء"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="Reg_EX_Building_NO" runat="server" ControlToValidate="txt_Building_NO"
                                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                        <asp:TextBox ID="txt_Building_NO" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Req_Val_Building_NO" ControlToValidate="txt_Building_NO"
                                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Building_Area" runat="server" Text="مساحة البناء"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="Reg_EX_Building_Area" runat="server" ControlToValidate="txt_Building_NO"
                                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                        <asp:TextBox ID="txt_Building_Area" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Req_Val_Building_Area" ControlToValidate="txt_Building_NO"
                                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_building_Valu" runat="server" Text="قيمة البناء"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="Reg_EX_building_Valu" runat="server" ControlToValidate="txt_Building_Value"
                                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                        <asp:TextBox ID="txt_building_Valu" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Req_Val_building_Valu" ControlToValidate="txt_building_Valu"
                                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Depreciation_Value" runat="server" Text="قيمة الهالك"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="Reg_EX_Depreciation_Value" runat="server" ControlToValidate="txt_Depreciation_Value"
                                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                        <asp:TextBox ID="txt_Depreciation_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Req_Val_Depreciation_Value" ControlToValidate="txt_Depreciation_Value"
                                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_presumed_Income" runat="server" Text="الدخل الفرضي"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="Reg_EX_presumed_income" runat="server" ControlToValidate="txt_presumed_Income"
                                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                        <asp:TextBox ID="txt_presumed_Income" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Req_Val_presumed_income" ControlToValidate="txt_presumed_Income"
                                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Actual_income" runat="server" Text="الدخل الفعلي"></asp:Label>
                                                        <%--<asp:RegularExpressionValidator ID="Reg_EX_Actual_income" runat="server" ControlToValidate="txt_Actual_income"
                                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>--%>
                                                        <asp:TextBox ID="txt_Actual_income" runat="server" CssClass="form-control"></asp:TextBox>
                                                       <%--<asp:RequiredFieldValidator ID="Req_Val_Actual_income" ControlToValidate="txt_Actual_income"
                                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Maintenance_status" runat="server" Text="وضع الصيانة"></asp:Label>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txt_Street_Number"
                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>--%>
                                                        <asp:TextBox ID="txt_Maintenance_status" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txt_Street_Number"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Renovation" runat="server" Text="التجديد"></asp:Label>
                                                        <%--<asp:RegularExpressionValidator  ID="Reg_Exp_Bond_Update" runat="server" ControlToValidate="txt_Bond_Update"
                                            EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>--%>
                                                        <asp:TextBox ID="txt_Renovation" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="Req_Val_Bond_Update" ControlToValidate="txt_Bond_Update"
                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_Balance_Value" runat="server" Text="قيمة المتبقي"></asp:Label>
                                                    <asp:TextBox ID="txt_Balance_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_residual_cost" runat="server" Text="المتبقي دفترياً"></asp:Label>
                                                    <asp:TextBox ID="txt_residual_cost" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_Estimated_residual_value" runat="server" Text="المتبقي تقديرياً"></asp:Label>
                                                    <asp:TextBox ID="txt_Estimated_residual_value" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_Current_Building_age" runat="server" Text="العمر الحالي"></asp:Label>
                                                    <asp:TextBox ID="txt_Current_Building_age" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="card mb-6">
                                    <div class="card-body">
                                        <div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Building_Condition" runat="server" Text="حالة البناء"></asp:Label>
                                                        <asp:DropDownList ID="B_Building_Condition_DropDownList" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="Req_Val_Building_Condition" ControlToValidate="B_Building_Condition_DropDownList"
                                                            InitialValue="اختر حالة البناء ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Building_Type" runat="server" Text="نوع البناء"></asp:Label>
                                                        <asp:DropDownList ID="B_Building_Type_DropDownList" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="Req_Val_Building_Type" ControlToValidate="B_Building_Type_DropDownList"
                                                            InitialValue="إختر نوع البناء ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Units_Type" runat="server" Text="نوعية الوحدات"></asp:Label>
                                                        <asp:DropDownList ID="B_Units_Type_DropDownList" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="Req_Val_Units_Type" ControlToValidate="B_Units_Type_DropDownList"
                                                            InitialValue="أختر نوعية الوحدات ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_ownership_Name" runat="server" Text="إسم الملكية"></asp:Label>
                                                    <asp:TextBox ID="txt_B_ownership_Name" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                    <%-- <div class="form-group">
                                                        <asp:Label ID="lbl_ownership_Name" runat="server" Text="إسم الملكية"></asp:Label>
                                                        <asp:DropDownList ID="B_ownership_Name_DropDownList" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="Req_Val_ownership_Name" ControlToValidate="B_ownership_Name_DropDownList"
                                                            InitialValue="أختر إسم الملكية...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </div>--%>
                                                </div>
                                            </div>
                                            


                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lbl_Completion_Date" runat="server" Text="تاريخ الإتمام"></asp:Label>&nbsp;
                                                            <asp:TextBox ID="txt_Completion_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                                            <input type="button" value="إختر التاريخ" onclick="OnClick1()"><br />
                                                            <div id="Completion_Date_divCalendar" style="position: unset; display:none; ">
                                                                <asp:Calendar ID="Completion_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Completion_Date_Calendar_SelectionChanged">
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
                                                            <asp:RequiredFieldValidator ID="Completion_Date_RequiredFieldValidator" ControlToValidate="txt_Completion_Date"
                                                                runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="Completion_Date_Calendar" EventName="SelectionChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_Depreciation_Year" runat="server" Text="الإهلاك / سنة"></asp:Label>
                                                    <asp:TextBox ID="txt_Depreciation_Year" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_Number_of_Conflict_Cases" runat="server" Text="عدد حالات النزاع"></asp:Label>
                                                    <asp:TextBox ID="txt_Number_of_Conflict_Cases" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_Contractual_Rent" runat="server" Text="الإيجار التعاقدي"></asp:Label>
                                                    <asp:TextBox ID="txt_Contractual_Rent" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_Electricity_Meter" runat="server" Text="عداد الكهرباء"></asp:Label>
                                                    <asp:TextBox ID="txt_Electricity_Meter" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_Water_Meter" runat="server" Text="عداد المياه"></asp:Label>
                                                    <asp:TextBox ID="txt_Water_Meter" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                
                                            </div>
                                            <br />
                                             <div class="row">
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_Occupied_Units" runat="server" Text="عدد الوحدات المؤجرة"></asp:Label>
                                                    <asp:TextBox ID="txt_Occupied_Units" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_Vacant_units" runat="server" Text="عدد الوحدات الشاغرة"></asp:Label>
                                                    <asp:TextBox ID="txt_Vacant_units" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>                                               
                                            </div><br />
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_Oreedo_Number" runat="server" Text="رقم أوريدوو"></asp:Label>
                                                    <asp:TextBox ID="txt_Oreedo_Number" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:Label ID="lbl_Number_of_units_under_construction" runat="server" Text="عدد الوحدات قيد الإنشاء"></asp:Label>
                                                    <asp:TextBox ID="txt_Number_of_units_under_construction" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            
                                            <%-- <div class="row">
                                <div class="col-lg-6">
                                    <asp:Label ID="Label24" runat="server" Text="قيمة الرهن"></asp:Label>
                                    <asp:TextBox ID="TextBox19" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <asp:Label ID="Label25" runat="server" Text="وضع الرهن"></asp:Label>
                                    <asp:TextBox ID="TextBox20" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div id="container1" class="container-fluid" style="border-style: solid; border-radius: 10px; width: 1250px; margin-right: 20px;">
                        <h3>مرفقات</h3>
                        <div class="row">
                            <div class="col-lg-4" id="Add_Building_Attatchment">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Map" runat="server" Text="تحميل خريطة البناء"></asp:Label>
                                    <asp:FileUpload ID="Building_Map_FileUpload" runat="server" CssClass="form-control" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="Building_Map_FileUpload"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Entrace_Photo" runat="server" Text="تحميل صورة المدخل"></asp:Label>
                                    <asp:FileUpload ID="Building_Entrace_Photo_FileUpload" runat="server" CssClass="form-control" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="Building_Entrace_Photo_FileUpload"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Photo" runat="server" Text="تحميل صورة البناء"></asp:Label>
                                    <asp:FileUpload ID="Building_Photo_FileUpload" runat="server" CssClass="form-control" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Building_Photo_FileUpload"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Facilities_Photo" runat="server" Text="تحميل صورة المرافق"></asp:Label>
                                    <asp:FileUpload ID="Building_Facilities_Photo_FileUpload" runat="server" CssClass="form-control" />
                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="Building_Facilities_Photo_FileUpload"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="col-lg-4">
                        <asp:Button ID="btn_Add_Building" runat="server" Text="إضافة بناء" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" OnClick="btn_Add_Building_Click1" />
                        &nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Building_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الأبنية" ValidationGroup="x" />
                    </div>
                    <br />
                    <script>$('#<%=B_Building_Condition_DropDownList.ClientID%>').chosen();</script>
                    <script>$('#<%=B_Building_Type_DropDownList.ClientID%>').chosen();</script>
                    <script>$('#<%=B_Units_Type_DropDownList.ClientID%>').chosen();</script>
                    <script>function OnClick1() { if (Completion_Date_divCalendar.style.display == "none") Completion_Date_divCalendar.style.display = ""; else Completion_Date_divCalendar.style.display = "none"; }</script>
                    <%--<script>$('#<%=B_ownership_Name_DropDownList.ClientID%>').chosen();</script>--%>
                    
                </asp:Panel>
           <%-- </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Add_Building_TO_This_Ownership" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>--%>
    </div>


    
    <script>function OnClick() { if (Release_Date_divCalendar.style.display == "none") Release_Date_divCalendar.style.display = ""; else Release_Date_divCalendar.style.display = "none"; }</script>




</asp:Content>

