<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Add_Building.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Add_Building" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style> .width{height: 75px;}  </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" /> 

    <div class="container-fluid" id="Building_container-wrapper">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_Add_New_Building" runat="server" Text="إضافة بناء جديد"></asp:Label>
                 <asp:Label ID="Building_id" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbl_Success_Add_Building" runat="server" ForeColor="#66bb6a"></asp:Label>
            </h1>
        </div>
        <div class="row">
            <div class="col-lg-8">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="row width">

                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Bildingp_Name" runat="server" Text="الاسم بالعربية"></asp:Label>
                                    <asp:RegularExpressionValidator ID="Reg_Ex_Ar_Bilding_Name" runat="server" ControlToValidate="txt_Ar_Bilding_Name"
                                        EnableClientScript="True" ErrorMessage="أحرف عربية فقط" ForeColor="#fc544b"
                                        ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ar_Bilding_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Req_Val_Ar_Bilding_Name" ControlToValidate="txt_Ar_Bilding_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:RegularExpressionValidator ID="Reg_Exp_En_Bilding_Name" runat="server" ControlToValidate="txt_En_Bilding_Name"
                                        EnableClientScript="True" ErrorMessage="Only English" ForeColor="#fc544b"
                                        ValidationExpression="[0-9 a-z A-Z]+"></asp:RegularExpressionValidator>
                                    <asp:Label ID="lbl_En_Bilding_Name" runat="server" Text="Building Name"></asp:Label>
                                    <asp:TextBox ID="txt_En_Bilding_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Req_Val_En_Bilding_Name" ControlToValidate="txt_En_Bilding_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Construction_Area" runat="server" Text="مساحة البناء"></asp:Label>
                                    <asp:TextBox ID="txt_Construction_Area" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row width">

                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Condition" runat="server" Text="حالة البناء"></asp:Label>
                                    <asp:DropDownList ID="Building_Condition_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Building_Condition_Req_Val" ControlToValidate="Building_Condition_DropDownList"
                                        InitialValue="اختر حالة البناء ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Type" runat="server" Text="نوع البناء"></asp:Label>
                                    <asp:DropDownList ID="Building_Type_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Building_Type_Req_Val" ControlToValidate="Building_Type_DropDownList"
                                        InitialValue="إختر نوع البناء ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Maintenance_status" runat="server" Text="وضع الصيانة"></asp:Label>
                                    <asp:TextBox ID="txt_Maintenance_status" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row width">



                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_electricity_meter" runat="server" Text="عداد الكهرباء"></asp:Label>
                                    <asp:TextBox ID="txt_electricity_meter" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Water_meter" runat="server" Text="عداد المياه"></asp:Label>
                                    <asp:TextBox ID="txt_Water_meter" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Value" runat="server" Text="قيمة البناء"></asp:Label>
                                    <asp:RegularExpressionValidator ID="Reg_Exp_Building_Value" runat="server" ControlToValidate="txt_Building_Value"
                                        EnableClientScript="True" ErrorMessage="أرقام فقط" ForeColor="#fc544b"
                                        ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Building_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Building_Value_Req_Field_Val" ControlToValidate="txt_Building_Value"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Construction_Completion_Date" runat="server" Text="تاريخ إتمام البناء"></asp:Label>
                                    <asp:DropDownList ID="Construction_Completion_Date_DropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--**********************************************--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="col-lg-4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <div class="row width">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <asp:Label ID="lbl_ownership_Name" runat="server" Text="اسم الملكية"></asp:Label>
                                    <asp:DropDownList ID="ownership_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ownership_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ownership_Name_Req_Val" ControlToValidate="ownership_Name_DropDownList"
                                        InitialValue="أختر إسم الملكية...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="background-color: #015997; height: 190px; border-radius: 10px; margin-bottom: 10px">
                            <div class="col-lg-3"></div>
                            <div class="col-lg-6">
                                <div class="form-group" style="text-align: center">
                                    <asp:Label ID="lbl_Building_NO" runat="server" Text="رقم البناء" ForeColor="White"></asp:Label>
                                    <asp:TextBox ID="txt_Building_NO" style="text-align:center" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3"></div>
                            <%----------------------------------------------------%>
                            <div class="col-lg-6">
                                <div class="form-group" style="text-align: center">
                                    <asp:Label ID="lbl_Street_No" runat="server" Text=" الشارع" ForeColor="White"></asp:Label>
                                    <asp:TextBox ID="txt_Street_No" style="text-align:center" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group" style="text-align: center">
                                    <asp:Label ID="lbl_Zone_No" runat="server" Text=" المنطقة" ForeColor="White"></asp:Label>
                                    <asp:TextBox ID="txt_Zone_No" style="text-align:center" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ownership_Name_DropDownList" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txt_Street_No" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txt_Zone_No" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <%--**********************************************--%>
        </div>
    <div class="container-fluid" id="ATT_Building_container-wrapper">

        <div class="row">
          </div>
          <div class="col-lg-12" style="border-style: solid; border-radius: 10px; width: 1221px;">
                <h3>مرفقات البناء</h3>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Building_Photo" runat="server" Text="تحميل صورة المبنى"></asp:Label>
                                <asp:FileUpload ID="Building_Photo_FileUpload" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Plan" runat="server" Text="تحميل المسقط الأفقي "></asp:Label>
                                <asp:FileUpload ID="Plan_FileUpload" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Statement" runat="server" Text="تحميل الإفادة"></asp:Label>
                                <asp:FileUpload ID="Statement_FileUpload" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Maps" runat="server" Text="تحميل الخرائط"></asp:Label>
                                <asp:FileUpload ID="Maps_FileUpload" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Building_Permit" runat="server" Text="تحميل رخصة بناء "></asp:Label>
                                <asp:FileUpload ID="Building_Permit_FileUpload" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_certificate_of_completion" runat="server" Text="تحميل شهادة لإتمام"></asp:Label>
                                <asp:FileUpload ID="certificate_of_completion_FileUpload" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Entrance_picture" runat="server" Text="تحميل صورة المدخل "></asp:Label>
                                <asp:FileUpload ID="Entrance_picture_FileUpload" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Image" runat="server" Text="تحميل صورة"></asp:Label>
                                <asp:FileUpload ID="Image_FileUpload" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <br />
    <div class="col-lg-4">
        <asp:Button ID="btn_Add_Building" runat="server" Text="إضافة البناء" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" OnClick="btn_Add_Building_Click" />
        &nbsp;&nbsp;
         <asp:Button ID="btn_Back_To_Building" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الأبنية" ValidationGroup="x" OnClick="btn_Back_To_Building_List_Click1"/>
    </div>
    <br />

    <%-- ************************************************************************  زر إضافة وحدة للبناء المضاف  *******************************************************************--%>
    <br />
    <div class="col-lg-4">
        <asp:Button CssClass="btn  mb-1" BackColor="#C7FC9A" ID="Button3" runat="server" Text="إضافة وحدة للبناء المضاف" Visible="false" OnClick="Button3_Click" />
        <asp:Button CssClass="btn  mb-1" BackColor="#C7FC9A" ID="Button4" runat="server" Text="إضافة بناء جديد " Visible="false" ValidationGroup="X" OnClick="Button4_Click" />
    </div>
    <br />

    <%-- ************************************************************************  إضافة وحدة للبناء المضاف  *******************************************************************--%>
    <asp:Panel ID="Unit_Panel" runat="server" Visible="false">
        <div class="container-fluid" id="Unit_container-wrapper">
            <div class="d-sm-flex align-items-center justify-content-between mb-4">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_Add_New_Unit" runat="server"></asp:Label>
                    <asp:Label ID="Added_Building_Id" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lbl_Success_Add_Unit" runat="server" ForeColor="#66bb6a"></asp:Label>
                </h1>
            </div>

            <div class="row">
                        <div class="col-lg-8">
                            <div class="card mb-4">
                                <div class="card-body">
                                    <%--**--%>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Unit_Type" runat="server" Text="نوع الوحدة"></asp:Label>
                                                <asp:DropDownList ID="Unit_Type_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Unit_Type_DropDownList_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Unit_Type_Req_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="Unit_Type_DropDownList"
                                                    InitialValue="إختر نوع الوحدة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Unit_Condition" runat="server" Text="الحالة الإيجارية"></asp:Label>
                                                <asp:DropDownList ID="Unit_Condition_DropDownList" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Unit_Condition_Req_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="Unit_Condition_DropDownList"
                                                    InitialValue="إختر حالة الوحدة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Unit_Detail" runat="server" Text="تفاصيل الوحدة"></asp:Label>
                                                <asp:DropDownList ID="Unit_Detail_DropDownList" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Unit_Detail_Req_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="Unit_Detail_DropDownList"
                                                    InitialValue="إختر تفاصيل الوحدة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-lg-4" id="div_Furniture_case" runat="server" visible="false">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Furniture_case" runat="server" Text="الفرش"></asp:Label>
                                                <asp:DropDownList ID="Furniture_case_DropDownList" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="1" Text="مفروش"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="نصف مفروش"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="غير مفروش"></asp:ListItem>
                                                    <asp:ListItem Enabled="false" Value="4" Text="غير محدد"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Furniture_case_RequiredFieldValidator" ValidationGroup="Unit_RequiredField" ControlToValidate="Furniture_case_DropDownList"
                                                    InitialValue="إختر الفرش ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Unit_Space" runat="server" Text="مساحة الوحدة"></asp:Label>
                                                <asp:RegularExpressionValidator ID="Unit_Space_Reg_Ex" runat="server" ControlToValidate="txt_Unit_Space"
                                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="#fc544b"
                                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                <asp:TextBox ID="txt_Unit_Space" runat="server" CssClass="form-control"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator ID="Unit_Space_Req_Val" ControlToValidate="txt_Unit_Space"
                                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_current_situation" runat="server" Text="الوضع الحالي"></asp:Label>
                                                <asp:TextBox ID="txt_current_situation" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_virtual_Value" runat="server" Text="القيمة اللإفتراضية"></asp:Label>
                                                <asp:RegularExpressionValidator ID="virtual_Value_Reg_Exp_Val" runat="server" ControlToValidate="txt_virtual_Value"
                                                EnableClientScript="True" ErrorMessage="أرقام فقط" ForeColor="#fc544b"
                                                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                <asp:TextBox ID="txt_virtual_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="virtual_ValueReq_Field_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="txt_virtual_Value"
                                                 runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    


                                    <div class="row">
                                        

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Oreedo_Number" runat="server" Text="رقم أوريدو"></asp:Label>
                                                <asp:TextBox ID="txt_Oreedo_Number" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Electricityt_Number" runat="server" Text="عداد الكهرباء"></asp:Label>
                                                <asp:TextBox ID="txt_Electricityt_Number" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Water_Number" runat="server" Text="عداد المياه"></asp:Label>
                                                <asp:TextBox ID="txt_Water_Number" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                 <%--**--%>
                                </div>
                            </div>
                        </div>

                        <%--**********************************************--%>
                        <div class="col-lg-4">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                          <div class="col-lg-12">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Building_Name" runat="server" Text="اسم البناء"></asp:Label>
                                                <asp:DropDownList ID="Building_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Building_Name_DropDownList_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Building_Name_Req_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="Building_Name_DropDownList"
                                                InitialValue="إختر إسم البناء ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="background-color: #015997; height: 190px; border-radius: 10px; margin-bottom: 10px">
                                        
                                        <div class="col-lg-6" >
                                            <div class="form-group" style="text-align: center">
                                                <asp:Label ID="lbl_Unit_NO" runat="server" Text="رقم الوحدة" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="txt_Unit_NO" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Unit_NO_Req_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="txt_Unit_NO"
                                                runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group" style="text-align: center">
                                                <asp:Label ID="lbl_Floor_NO" runat="server" Text="رقم الطابق" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="txt_Floor_NO" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Floor_NO_Req_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="txt_Floor_NO"
                                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <%----------------------------------------------------%>
                                        <div class="col-lg-4">
                                            <div class="form-group" style="text-align: center">
                                                <asp:Label ID="Label1" runat="server" Text="رقم البناء" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group" style="text-align: center">
                                                <asp:Label ID="Label2" runat="server" Text=" الشارع" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group" style="text-align: center">
                                                <asp:Label ID="Label3" runat="server" Text=" المنطقة" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Building_Name_DropDownList" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="txt_Street_No" EventName="TextChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="txt_Zone_No" EventName="TextChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="txt_Building_NO" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <%--**********************************************--%>
                    </div>
            <div class="container-fluid" id="ATT_Unit_container-wrapper">

                <div class="row">
                    <div class="col-lg-12" style="border-style: solid; border-radius: 10px; width: 1221px;">
                        <h3>مرفقات الوحدة</h3>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Image_One" runat="server" Text="تحميل صورة أولى"></asp:Label>
                                        <asp:FileUpload ID="Image_One_FileUpload" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Image_Two" runat="server" Text="تحميل صورة ثانية "></asp:Label>
                                        <asp:FileUpload ID="Image_Two_FileUpload" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Image_Three" runat="server" Text="تحميل صورة ثالثة"></asp:Label>
                                        <asp:FileUpload ID="Image_Three_FileUpload" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Image_Four" runat="server" Text="تحميل رابعة"></asp:Label>
                                        <asp:FileUpload ID="Image_Four_FileUpload" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <br />
        </div>
        <div class="col-lg-4">
            <asp:Button ID="btn_Add_Unit" runat="server" Text="إضافة وحدة" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" OnClick="btn_Add_Unit_Click" />
            &nbsp;&nbsp;
                    <asp:Button ID="btn_Back_To_Unit" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الأبنية" ValidationGroup="x" />
        </div>
    </asp:Panel>


    <script>$('#<%=Unit_Type_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Unit_Condition_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Unit_Detail_DropDownList.ClientID%>').chosen();</script>


    <script>$('#<%=Building_Condition_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Building_Type_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=ownership_Name_DropDownList.ClientID%>').chosen();</script>

</asp:Content>
