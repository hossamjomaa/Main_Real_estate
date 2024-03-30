<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Edit_Building_In_Ownership_Detais.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Edit_Building_In_Ownership_Detais" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" />
   
    


            <div class="container-fluid" id="Building_container-wrapper">
                <div class="d-sm-flex align-items-center justify-content-between mb-4">
                    <h1 class="h3 mb-0 text-gray-800">
                        <asp:Label ID="lbl_Add_New_Building" runat="server" Text="تعديل البناء :"></asp:Label>&nbsp;
                                     <asp:Label ID="lbl_Name_Of_Building" runat="server" Text=""></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lbl_Success_Add_Building" runat="server" ForeColor="#00FF40"></asp:Label>
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
                                        EnableClientScript="True" ErrorMessage="أحرف عربية فقط" ForeColor="Red"
                                        ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ar_Bilding_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Req_Val_Ar_Bilding_Name" ControlToValidate="txt_Ar_Bilding_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:RegularExpressionValidator ID="Reg_Exp_En_Bilding_Name" runat="server" ControlToValidate="txt_En_Bilding_Name"
                                        EnableClientScript="True" ErrorMessage="Only English" ForeColor="Red"
                                        ValidationExpression="[0-9 a-z A-Z]+"></asp:RegularExpressionValidator>
                                    <asp:Label ID="lbl_En_Bilding_Name" runat="server" Text="Building Name"></asp:Label>
                                    <asp:TextBox ID="txt_En_Bilding_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Req_Val_En_Bilding_Name" ControlToValidate="txt_En_Bilding_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                        InitialValue="اختر حالة البناء ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Type" runat="server" Text="نوع البناء"></asp:Label>
                                    <asp:DropDownList ID="Building_Type_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Building_Type_Req_Val" ControlToValidate="Building_Type_DropDownList"
                                        InitialValue="إختر نوع البناء ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                        EnableClientScript="True" ErrorMessage="أرقام فقط" ForeColor="Red"
                                        ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Building_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Building_Value_Req_Field_Val" ControlToValidate="txt_Building_Value"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
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

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <asp:Label ID="lbl_ownership_Name" runat="server" Text="اسم الملكية"></asp:Label>
                                    <asp:DropDownList ID="ownership_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ownership_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ownership_Name_Req_Val" ControlToValidate="ownership_Name_DropDownList"
                                        InitialValue="أختر إسم الملكية...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                    <asp:Label ID="lbl_Street_No" runat="server" Text=" الشارع" ForeColor="White"></asp:Label>
                                    <asp:TextBox ID="txt_Street_No" runat="server" CssClass="form-control"></asp:TextBox>
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
            <div class="container-fluid" id="ATT_Building_container-wrapper">

                   <div class="row">
            <div class="col-lg-12" style="border-style: solid; border-radius: 10px; width: 1221px;">
                <h3>مرفقات البناء</h3>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Building_Photo" runat="server" Text="تحميل صورة المبنى"></asp:Label>
                                <asp:FileUpload ID="Building_Photo_FileUpload" runat="server" CssClass="form-control" />
                                <asp:Label ID="Building_Photo" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="Building_Photo_Path" runat="server" Visible="false"></asp:Label>

                                <div runat="server" id="Building_Photo_Div">
                                    <a runat="server" id="Link_Building_Photo" style="font-size: 15px;">
                                        <i class="fa fa-paperclip" style="font-size: 40px;"></i>
                                        <asp:Label ID="lbl_Link_Building_Photo" runat="server" Text=""></asp:Label>
                                    </a>
                                    <asp:ImageButton ID="Btn_Remove_Link_Building_Photo" runat="server" OnClick="Btn_Remove_Link_Building_Photo_Click" Width="10px" Height="10px" ImageUrl="Main_Image/Calander_Close.png" />
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Plan" runat="server" Text="تحميل المسقط الأفقي "></asp:Label>
                                <asp:FileUpload ID="Plan_FileUpload" runat="server" CssClass="form-control" />
                                <asp:Label ID="Plan" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="Plan_Path" runat="server" Visible="false"></asp:Label>


                                <div runat="server" id="Plan_Div">
                                    <a runat="server" id="Link_Plan" style="font-size: 15px;">
                                        <i class="fa fa-paperclip" style="font-size: 40px;"></i>
                                        <asp:Label ID="lbl_Link_Plan" runat="server" Text=""></asp:Label>
                                    </a>
                                    <asp:ImageButton ID="Btn_Remove_Link_Plan" runat="server" OnClick="Btn_Remove_Link_Plan_Click" Width="10px" Height="10px" ImageUrl="Main_Image/Calander_Close.png" />
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Statement" runat="server" Text="تحميل الإفادة"></asp:Label>
                                <asp:FileUpload ID="Statement_FileUpload" runat="server" CssClass="form-control" />
                                <asp:Label ID="Statement" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="Statement_Path" runat="server" Visible="false"></asp:Label>

                                  <div runat="server" id="Statement_Div">
                                    <a runat="server" id="Link_Statement" style="font-size: 15px;">
                                        <i class="fa fa-paperclip" style="font-size: 40px;"></i>
                                        <asp:Label ID="lbl_Link_Statement" runat="server" Text=""></asp:Label>
                                    </a>
                                    <asp:ImageButton ID="Btn_Remove_Link_Statement" runat="server" OnClick="Btn_Remove_Link_Statement_Click" Width="10px" Height="10px" ImageUrl="Main_Image/Calander_Close.png" />
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Maps" runat="server" Text="تحميل الخرائط"></asp:Label>
                                <asp:FileUpload ID="Maps_FileUpload" runat="server" CssClass="form-control" />
                                <asp:Label ID="Maps" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="Maps_Path" runat="server" Visible="false"></asp:Label>

                                <div runat="server" id="Maps_Div">
                                    <a runat="server" id="Link_Maps" style="font-size: 15px;">
                                        <i class="fa fa-paperclip" style="font-size: 40px;"></i>
                                        <asp:Label ID="lbl_Link_Maps" runat="server" Text=""></asp:Label>
                                    </a>
                                    <asp:ImageButton ID="Btn_Remove_Link_Maps" runat="server" OnClick="Btn_Remove_Link_Maps_Click" Width="10px" Height="10px" ImageUrl="Main_Image/Calander_Close.png" />
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Building_Permit" runat="server" Text="تحميل رخصة بناء "></asp:Label>
                                <asp:FileUpload ID="Building_Permit_FileUpload" runat="server" CssClass="form-control" />
                                <asp:Label ID="Building_Permit" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="Building_Permit_Path" runat="server" Visible="false"></asp:Label>


                                <div runat="server" id="Permit_Div">
                                    <a runat="server" id="Link_Permit" style="font-size: 15px;">
                                        <i class="fa fa-paperclip" style="font-size: 40px;"></i>
                                        <asp:Label ID="lbl_Link_Permit" runat="server" Text=""></asp:Label>
                                    </a>
                                    <asp:ImageButton ID="Btn_Remove_Link_Permit" runat="server" OnClick="Btn_Remove_Link_Permit_Click" Width="10px" Height="10px" ImageUrl="Main_Image/Calander_Close.png" />
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_certificate_of_completion" runat="server" Text="تحميل شهادة لإتمام"></asp:Label>
                                <asp:FileUpload ID="certificate_of_completion_FileUpload" runat="server" CssClass="form-control" />
                                <asp:Label ID="certificate_of_completion" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="certificate_of_completion_Path" runat="server" Visible="false"></asp:Label>

                                <div runat="server" id="certificate_of_completion_Div">
                                    <a runat="server" id="Link_certificate_of_completion" style="font-size: 15px;">
                                        <i class="fa fa-paperclip" style="font-size: 40px;"></i>
                                        <asp:Label ID="lbl_Link_certificate_of_completion" runat="server" Text=""></asp:Label>
                                    </a>
                                    <asp:ImageButton ID="Btn_Remove_Link_certificate_of_completion" OnClick="Btn_Remove_Link_certificate_of_completion_Click" runat="server" Width="10px" Height="10px" ImageUrl="Main_Image/Calander_Close.png" />
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Entrance_picture" runat="server" Text="تحميل صورة المدخل "></asp:Label>
                                <asp:FileUpload ID="Entrance_picture_FileUpload" runat="server" CssClass="form-control" />
                                <asp:Label ID="Entrance_picture" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="Entrance_picture_Path" runat="server" Visible="false"></asp:Label>

                                 <div runat="server" id="Entrance_picture_Div">
                                    <a runat="server" id="Link_Entrance_picture" style="font-size: 15px;">
                                        <i class="fa fa-paperclip" style="font-size: 40px;"></i>
                                        <asp:Label ID="lbl_Link_Entrance_picture" runat="server" Text=""></asp:Label>
                                    </a>
                                    <asp:ImageButton ID="Btn_Remove_Link_Entrance_picture" OnClick="Btn_Remove_Link_Entrance_picture_Click" runat="server" Width="10px" Height="10px" ImageUrl="Main_Image/Calander_Close.png" />
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="lbl_Image" runat="server" Text="تحميل صورة"></asp:Label>
                                <asp:FileUpload ID="Image_FileUpload" runat="server" CssClass="form-control" />
                                <asp:Label ID="Image" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="Image_Path" runat="server" Visible="false"></asp:Label>

                                 <div runat="server" id="Image_Div">
                                    <a runat="server" id="Link_Imagee" style="font-size: 15px;">
                                        <i class="fa fa-paperclip" style="font-size: 40px;"></i>
                                        <asp:Label ID="lbl_Link_Image" runat="server" Text=""></asp:Label>
                                    </a>
                                    <asp:ImageButton ID="Btn_Remove_Link_Image" runat="server" OnClick="Btn_Remove_Link_Image_Click" Width="10px" Height="10px" ImageUrl="Main_Image/Calander_Close.png" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
            </div>
            <br />
            <div class="col-lg-4">
                <asp:Button ID="btn_Add_Building" runat="server" Text="حفظ التغيرات" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" OnClick="btn_Add_Building_Click" />

                &nbsp;&nbsp;
                            <asp:Button ID="btn_Back_To_Building" CssClass="btn btn-light mb-1" runat="server" Text="العودة لتفاصيل الملكية" ValidationGroup="x"  OnClick="btn_Back_To_Building_Click" />
            </div>
        
    <br />
    <script>$('#<%=Building_Condition_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Building_Type_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=ownership_Name_DropDownList.ClientID%>').chosen();</script>





                
         <%--*********************  Delete **********************************--%>
    <br />
    <hr />
    <div class="container-fluid">
        <h4>حذف البناء</h4>
        <div class="row">
            <div class="col-lg-1">
                <br />
                <asp:LinkButton ID="Delete_Request" CssClass="btn btn-danger" runat="server" ValidationGroup="Delete" OnClick="Delete_Building_Click" OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');"  ><i class="fa fa-trash" style="font-size:18px;"></i></asp:LinkButton>
            </div>
            <div class="col-lg-5" runat="server" id="Delete_Div" visible="false">
                <div class="form-group">
                    <asp:Label ID="lbl_Reason_Delete" runat="server" Text="سبب الحذف" ></asp:Label>
                    <asp:TextBox ID="txt_Reason_Delete" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Delete_ReqFieVal" ControlToValidate="txt_Reason_Delete"
                    runat="server" ErrorMessage="* يرجى توضيح سبب الحذف" ForeColor="Red" ValidationGroup="Delete"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div><br /><br />
</asp:Content>
