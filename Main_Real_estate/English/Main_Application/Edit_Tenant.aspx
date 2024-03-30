<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Edit_Tenant.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Edit_Tenant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" />

    <div class="container-fluid" id="container-wrapper">
        <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Edit_Tenant" runat="server" Text="تعديل المستأجر :"></asp:Label>
                <asp:Label ID="lbl_Name_Of_Tenant" runat="server" Text=""></asp:Label>&nbsp;
                <asp:Label ID="lbl_Success_Edit_Tenant" runat="server" ForeColor="#00FF40"></asp:Label>
            </h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-4">
                    <div class="card-body">

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Tenant_Name" runat="server" Text="إسم المستأجر بالإنكليزية"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_En_Tenant_Name"
                                        EnableClientScript="True" ErrorMessage="!!! أحرف إنكليزية فقط" ForeColor="Red"
                                        ValidationExpression="[a-z A-Z0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_En_Tenant_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqFuild1" ControlToValidate="txt_En_Tenant_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Tenant_Name" runat="server" Text="اسم المستأجر بالعربية"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ar_Tenant_Name"
                                        EnableClientScript="True" ErrorMessage="!!! أحرف عربية فقط" ForeColor="Red"
                                        ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ar_Tenant_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Ar_Tenant_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>



                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>



                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Tenant_Type" runat="server" Text="نوع المستأجر"></asp:Label>
                                    <asp:DropDownList ID="Tenant_Type_DropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Tenant_Type_DropDownList_SelectedIndexChanged" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Tenant_Type_RequiredFieldValidator" ValidationGroup="Tenant_RequiredField" ControlToValidate="Tenant_Type_DropDownList"
                                        InitialValue="إختر نوع المستأجر ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-4" id="P_O_Box_Div" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_P_O_Box" runat="server" Text="صندوق بريد"></asp:Label>
                                    <asp:TextBox ID="txt_P_O_Box" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-4" id="business_records_Div" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_business_records" runat="server" Text="السجل التجاري"></asp:Label>
                                    <asp:TextBox ID="txt_business_records" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-4" id="nationality" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_nationality" runat="server" Text="جنسية المستأجر"></asp:Label>
                                    <asp:DropDownList ID="nationality_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-4" id="Tenant_Nationality_Address" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Tenant_Nationality_Address" runat="server" Text="العنوان في البلد الأصل"></asp:Label>
                                    <asp:TextBox ID="txt__Tenant_Nationality_Address" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">


                            <div class="col-lg-3" id="business_records_File_Div" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_business_records_File" runat="server" Text=" تحميل صورة عن السجل التجاري"></asp:Label>
                                    <asp:FileUpload ID="business_records_File_FileUpload" runat="server" CssClass="form-control" />
                                    <asp:Label ID="lbl_B_R_FN" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_B_R_P" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>

                            <div class="col-lg-3" id="Establishment_Registration_Number_Div" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Establishment_Registration_Number" runat="server" Text="رقم قيد المنشأة"></asp:Label>
                                    <asp:TextBox ID="txt_Establishment_Registration_Number" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3" id="Company_registration_Div" runat="server" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Company_registration" runat="server" Text=" تحميل صورة عن قيد المنشأة"></asp:Label>
                                    <asp:FileUpload ID="Company_registration_FileUpload" runat="server" CssClass="form-control" />
                                    <asp:Label ID="lbl_C_R_FN" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_C_R_P" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>


                        <div class="col-lg-3" id="Add_Tenant_Div" runat="server" visible="false">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="إضافة ممثل عن الشركة"></asp:Label><br />
                                <asp:ImageButton ID="Add_Tenantt" runat="server" ImageUrl="Main_Image/plus.png" OnClick="Add_Tenantt_Click" Width="40px" Height="40px" />
                            </div>
                        </div>
                        <br />











                        <div class="row">
                            <div class="col-lg-4">
                                <asp:Label ID="lbl_Tenant_Tell" runat="server" Text="هاتف "></asp:Label>&nbsp;
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txt_Tenant_Tell"
                                            EnableClientScript="True" ErrorMessage="!!!ارقام فقط" ForeColor="Red"
                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Tenant_Tell" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Tenant_Mobile" runat="server" Text="جوال "></asp:Label>&nbsp;
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_Tenant_Mobile"
                                                EnableClientScript="True" ErrorMessage="!!!ارقام فقط" ForeColor="Red"
                                                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Tenant_Mobile" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_Tenant_Mobile"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-4">
                                <asp:Label ID="lbl_Tenant_Fax" runat="server" Text="فاكس "></asp:Label>
                                &nbsp;
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txt_Tenant_Fax"
                                            EnableClientScript="True" ErrorMessage="!!!ارقام فقط" ForeColor="Red"
                                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Tenant_Fax" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Tenant_Email" runat="server" Text="البريد الألكتروني"></asp:Label>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt_Tenant_Email"
                                        EnableClientScript="True" ErrorMessage="البريد الاكتروني غير صالح" ForeColor="Red"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Tenant_Email" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Tenant_Address" runat="server" Text="عنوان المستأجر"></asp:Label>
                                    <asp:TextBox ID="txt_Tenant_Address" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />





                        <div class="row" id="ID_PassPort_IdExpaired_Div" runat="server" visible="false">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Passport" runat="server" Text="تعديل جواز سفر المستأجر"></asp:Label>
                                    <asp:FileUpload ID="Passport_FileUpload" runat="server" CssClass="form-control" />
                                    <asp:Label ID="Passport" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="Passport_path" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Tenant_QID" runat="server" Text="تعديل بطاقة المستأجر"></asp:Label>
                                    <asp:FileUpload ID="FUL_Tenant_QID" runat="server" CssClass="form-control" />
                                    <asp:Label ID="Tenants_QId" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="Tenants_QId_Path" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_ID_NO" runat="server" Text="رقم البطاقة"></asp:Label>
                                    <asp:TextBox ID="txt_ID_NO" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lbl_Expiry" runat="server" Text="تاريخ إنتهاء البطاقة"></asp:Label>&nbsp;
                                            <asp:TextBox ID="txt_End_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:Button ID="Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Date_Chosee_Click" />
                                        <asp:ImageButton ID="ImageButton1" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton1_Click" runat="server" />
                                        <div id="End_Date_divCalendar" runat="server" style="position: absolute;" visible="false">

                                            <asp:Calendar ID="End_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="End_Date_Calendar_SelectionChanged">
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
                                        <asp:AsyncPostBackTrigger ControlID="Date_Chosee" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>



                        <div class="row" style="border-style: solid; border-radius: 10px">
                            <div class="col-lg-12"><h5>إنشاء حساب للعميل على موقع المنارة</h5></div><br />
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Tenant_User_Name" runat="server" Text="اسم المستخدم"></asp:Label>
                                    <asp:TextBox ID="txt_Tenant_User_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            
                                    <div class="col-lg-4">
                                        <div class="form-group">


                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                            <asp:Label ID="lbl_Tenant_PassPword" runat="server" Text="كلمة السر "></asp:Label>
                                            <asp:TextBox ID="txt_Tenant_PassPword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Text="إظهار كلمة السر" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />


                                    </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="CheckBox1" EventName="CheckedChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Button ID="btn_Edit_Tenant" runat="server" Text="حفظ التغيرات" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" Width="248px" OnClick="btn_Edit_Tenant_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Tenant_List" runat="server" Text="العودة لقائمة المستأجرين" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Tenant_List_Click" />
        </div>
        <script>$('#<%=Tenant_Type_DropDownList.ClientID%>').chosen();</script>
        <script>$('#<%=nationality_DropDownList.ClientID%>').chosen();</script>
        <script>function OnClick_E() { if (End_Date_divCalendar.style.display == "none") End_Date_divCalendar.style.display = ""; else End_Date_divCalendar.style.display = "none"; }</script>
</asp:Content>
