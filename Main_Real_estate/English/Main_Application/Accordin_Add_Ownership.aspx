<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Accordin_Add_Ownership.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Accordin_Add_Ownership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--XXXXXXX--%>
    <%--YYYYYYY--%>
    <style>
        .hiddencol { display: none; } 
    </style> 


    <div class="container-fluid" id="container-wrapper">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Ownership" runat="server" Text="إضافة ملكية جديدة"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                        
            </h1>

        </div>
        <div class="row">
            <div class="col-lg-8">
                <div class="card ">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Ownership_Name" runat="server" Text="Property Name"></asp:Label>
                                    <asp:RegularExpressionValidator ID="Reg_Ex_En_Ownership_Name" runat="server" ControlToValidate="txt_En_Ownership_Name"
                                        EnableClientScript="True" ErrorMessage="أحرف إنكليزية فقط" ForeColor="#fc544b"
                                        ValidationExpression="[a-z A-Z0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_En_Ownership_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Req_Val_En_Ownership_Name" ControlToValidate="txt_En_Ownership_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Ownership_Name" runat="server" Text="الاسم بالعربية"></asp:Label>
                                    <asp:RegularExpressionValidator ID="Reg_Ex_Ar_Ownership_Name" runat="server" ControlToValidate="txt_Ar_Ownership_Name"
                                        EnableClientScript="True" ErrorMessage="أحرف عربية فقط" ForeColor="#fc544b"
                                        ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ar_Ownership_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Req_Val_Ar_Ownership_Name" ControlToValidate="txt_Ar_Ownership_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ownership_Number" runat="server" Text="رقم الملكية"></asp:Label>
                                    <asp:RegularExpressionValidator ID="Reg_Exp_Ownership_Number" runat="server" ControlToValidate="txt_Ownership_Number"
                                        EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="#fc544b"
                                        ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ownership_Number" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Req_Val_Ownership_Number" ControlToValidate="txt_Ownership_Number"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_Bond_No" runat="server" Text="رقم السند"></asp:Label>
                                            <asp:TextBox ID="txt_Bond_No" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_PIN_Number" runat="server" Text="الرقم المساحي"></asp:Label>&nbsp;&nbsp;  
                                                <asp:RegularExpressionValidator ID="Reg_Exp_PIN_Number" runat="server" ControlToValidate="txt_PIN_Number"
                                                    EnableClientScript="True" ErrorMessage="أرقام فقط" ForeColor="#fc544b"
                                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                            <asp:TextBox ID="txt_PIN_Number" MaxLength="8" runat="server" CssClass="form-control" OnTextChanged="txt_PIN_Number_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="Req_Val_PIN_Number" ControlToValidate="txt_PIN_Number"
                                                runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            <asp:Label ID="Pin_No_Worrnig" runat="server" Visible="false" ForeColor="#fc544b"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_Zone_Name" runat="server" Text="اسم المنطقة"></asp:Label>
                                            <asp:DropDownList ID="Zone_Name_DropDownList" AutoPostBack="true" OnSelectedIndexChanged="Zone_Name_DropDownList_SelectedIndexChanged" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="Zone_Name_Req_Val" ControlToValidate="Zone_Name_DropDownList"
                                                InitialValue="أختر إسم المنطقة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Zone_Name_DropDownList" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="txt_PIN_Number" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Owner_Name" runat="server" Text="اسم المالك"></asp:Label>
                                    <asp:DropDownList ID="Owner_DropDownList" runat="server" CssClass="form-control" DataTextField="Text">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Owner_Name_Req_dVal" ControlToValidate="Owner_DropDownList"
                                        InitialValue="اختر إسم المالك ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Parcel_Area" runat="server" Text="مساحة الأرض"></asp:Label>
                                    <asp:TextBox ID="txt_Parcel_Area" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>

                                        <div class="form-group">
                                            <asp:Label ID="lbl_Lande_Value" runat="server" Text="قيمة الأرض"></asp:Label>
                                            <asp:RegularExpressionValidator ID="Reg_Exp_Land_Vaue" runat="server" ControlToValidate="txt_Lande_Value"
                                                EnableClientScript="True" ErrorMessage="أرقام فقط" ForeColor="#fc544b"
                                                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                            <asp:TextBox ID="txt_Lande_Value" runat="server" CssClass="form-control"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="Lande_Value_Req_Field_Val" ControlToValidate="txt_Lande_Value"
                                                runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>


                                            <asp:CheckBox ID="CheckBox_Appreciation" runat="server" Text="تقديري" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:CheckBox ID="CheckBox_octagon" runat="server" Text="مثمن" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged" />
                                        </div>

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="CheckBox_Appreciation" EventName="CheckedChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="CheckBox_octagon" EventName="CheckedChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                        
                
                    </div>
                   
                </div>
                 <br />
                    <div class="row">
                    <div class="col-lg-12">
                        <asp:Button ID="btn_Add_Ownership" runat="server" Text="إضافة ملكية" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" OnClick="Btn_Add_Ownership_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btn_Back_To_OwnerShip_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الملكيات" ValidationGroup="x" OnClick="btn_Back_To_OwnerShip_List_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbl_Success_Add_New_Ownership" runat="server" ForeColor="#66bb6a" Font-Size="30px" Text="تمت الإضافة بنجاح " Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
           

            <div class="col-lg-4">
                <div class="row" style="background-color: #015997; height: 155px; border-radius: 10px; margin-bottom: 10px">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lbl_Street_No" runat="server" Text="رقم الشارع" ForeColor="White"></asp:Label>
                            <asp:TextBox ID="txt_Street_No" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                     <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lbl_Street_Name" runat="server" Text="اسم الشارع" ForeColor="White"></asp:Label>
                            <asp:TextBox ID="txt_Street_Name" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                   
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:Label ID="lbl_Map_Url" runat="server" Text="Google Map" ForeColor="White"></asp:Label>
                            <asp:TextBox ID="txt_Map_Url" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>



                <div style="border-style: solid; border-radius: 10px; height: 225px;  padding:10px">
                    <div class="row" style="height: 70px;">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <asp:Label ID="lbl_bond_Date" runat="server" Text="تاريخ السند"> </asp:Label>
                                <asp:TextBox ID="txt_bond_Date" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="height: 70px;">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <asp:Label ID="lbl_Ownership_Certificates" runat="server" Text="تحميل سند الملكية"></asp:Label>
                                <asp:FileUpload ID="Ownership_Certificate_FileUpload" runat="server" CssClass="form-control" />
                            </div>
                        </div>

                    </div>
                    <div class="row" style="height: 70px;">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <asp:Label ID="lbl_Property_Scheme" runat="server" Text="تحميل المخطط"></asp:Label>
                                <asp:FileUpload ID="Property_Scheme_FileUpload" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />


    <br />

    <br />
    <%-- ************************************************************************  زر إضافة بناء للملكية المضافة  *******************************************************************--%>
    <div class="col-lg-4">
        <asp:Button CssClass="btn  mb-1" BackColor="#C7FC9A" ID="Button1" runat="server" Text="إضافة بناء للملكية السابقة" Visible="false" OnClick="Button1_Click" />
        <asp:Button CssClass="btn  mb-1" BackColor="#C7FC9A" ID="Button2" runat="server" Text="إضافة ملكية جديدة" Visible="false" ValidationGroup="X" OnClick="Button2_Click" />
    </div>
    <br />
    <%-- ************************************************************************  إضافة بناء للملكية المضافة *******************************************************************--%>

    <asp:Panel ID="Buidling_Panel" runat="server" Visible="false">
        <div class="container-fluid" id="Building_container-wrapper">
            <div class="d-sm-flex align-items-center justify-content-between mb-4">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_Add_New_Building" runat="server"></asp:Label>
                    <asp:Label ID="Added_Ownership_Id" runat="server" Visible="false"></asp:Label>
                </h1>
            </div>
            <div class="row">
            <div class="col-lg-8">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="row">

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

                        <div class="row">

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


                        <div class="row">



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
            <div class="col-lg-4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>

                        <div class="row">
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
                                    <asp:TextBox ID="txt_Building_NO" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3"></div>
                            <%----------------------------------------------------%>
                            <div class="col-lg-6">
                                <div class="form-group" style="text-align: center">
                                    <asp:Label ID="Label1" runat="server" Text=" الشارع" ForeColor="White"></asp:Label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group" style="text-align: center">
                                    <asp:Label ID="lbl_Zone_No" runat="server" Text=" المنطقة" ForeColor="White"></asp:Label>
                                    <asp:TextBox ID="txt_Zone_No" runat="server" CssClass="form-control"></asp:TextBox>
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
        </div>

        <div class="container-fluid" id="ATT_Building_container-wrapper">
            <div class="row">
                <div class="col-lg-12" style="border-style: solid; border-radius: 10px; width: 1221px;">
                    <h3 id="Building_ATT" runat="server">مرفقات البناء</h3>
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
                                    <asp:FileUpload ID="Image_FileUpload" runat="server" CssClass="form-control" onchaged="" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <br />
        <div class="col-lg-6">
            <asp:Button ID="btn_Add_Building" runat="server" Text="إضافة البناء" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" OnClick="Btn_Add_Building_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Building" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الأبنية" ValidationGroup="x" OnClick="btn_Back_To_Building_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_Success_Add_Building" runat="server" Font-Size="30px" ForeColor="#66bb6a"></asp:Label>

        </div>
    </asp:Panel>

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
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
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
                                                <asp:Label ID="Label2" runat="server" Text="رقم البناء" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group" style="text-align: center">
                                                <asp:Label ID="Label3" runat="server" Text=" الشارع" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group" style="text-align: center">
                                                <asp:Label ID="Label4" runat="server" Text=" المنطقة" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
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
        <div class="col-lg-6">
            <asp:Button ID="btn_Add_Unit" runat="server" Text="إضافة وحدة" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" OnClick="btn_Add_Unit_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Unit" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الوحدات" ValidationGroup="x" OnClick="btn_Back_To_Unit_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_Success_Add_Unit" runat="server" Font-Size="30px" ForeColor="#66bb6a"></asp:Label>
        </div>
    </asp:Panel>
</asp:Content>
