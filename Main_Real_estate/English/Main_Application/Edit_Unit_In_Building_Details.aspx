<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Edit_Unit_In_Building_Details.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Edit_Unit_In_Building_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" />

    <div class="container-fluid" id="container-wrapper">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Edit_New_Unit" runat="server" Text="تعديل الوحدة :"></asp:Label>&nbsp;
                <asp:Label ID="lbl_Name_Of_Unit" runat="server" Text=""></asp:Label>&nbsp;
                <asp:Label ID="lbl_Success_Edit_New_Unit" runat="server" ForeColor="Green"></asp:Label>
            </h1>
        </div>
       <div class="row">
                        <div class="col-lg-8">
                            <div class="card mb-4">
                                <div class="card-body">
                                    <%--**--%>
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Unit_Type" runat="server" Text="نوع الوحدة"></asp:Label>
                                                <asp:DropDownList ID="Unit_Type_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Unit_Type_DropDownList_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Unit_Type_Req_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="Unit_Type_DropDownList"
                                                    InitialValue="إختر نوع الوحدة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Unit_Condition" runat="server" Text="الحالة الإيجارية"></asp:Label>
                                                <asp:DropDownList ID="Unit_Condition_DropDownList" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Unit_Condition_Req_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="Unit_Condition_DropDownList"
                                                    InitialValue="إختر حالة الوحدة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Unit_Detail" runat="server" Text="تفاصيل الوحدة"></asp:Label>
                                                <asp:DropDownList ID="Unit_Detail_DropDownList" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Unit_Detail_Req_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="Unit_Detail_DropDownList"
                                                    InitialValue="إختر تفاصيل الوحدة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-lg-3" id="div_Furniture_case" runat="server" visible="false">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Furniture_case" runat="server" Text="الفرش"></asp:Label>
                                                <asp:DropDownList ID="Furniture_case_DropDownList" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="1" Text="مفروش"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="نصف مفروش"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="غير مفروش"></asp:ListItem>
                                                    <asp:ListItem Enabled="false" Value="4" Text="غير محدد"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Furniture_case_RequiredFieldValidator" ValidationGroup="Unit_RequiredField" ControlToValidate="Furniture_case_DropDownList"
                                                    InitialValue="إختر الفرش ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Unit_Space" runat="server" Text="مساحة الوحدة"></asp:Label>
                                                <asp:RegularExpressionValidator ID="Unit_Space_Reg_Ex" runat="server" ControlToValidate="txt_Unit_Space"
                                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                <asp:TextBox ID="txt_Unit_Space" runat="server" CssClass="form-control"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator ID="Unit_Space_Req_Val" ControlToValidate="txt_Unit_Space"
                                                            runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
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
                                                EnableClientScript="True" ErrorMessage="أرقام فقط" ForeColor="Red"
                                                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                <asp:TextBox ID="txt_virtual_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="virtual_ValueReq_Field_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="txt_virtual_Value"
                                                 runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <div class="col-lg-4">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                          <div class="col-lg-12">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Building_Name" runat="server" Text="اسم البناء"></asp:Label>
                                                <asp:DropDownList ID="Building_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Building_Name_DropDownList_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Building_Name_Req_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="Building_Name_DropDownList"
                                                InitialValue="إختر إسم البناء ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="background-color: #015997; height: 190px; border-radius: 10px; margin-bottom: 10px">
                                        
                                        <div class="col-lg-6" >
                                            <div class="form-group" style="text-align: center">
                                                <asp:Label ID="lbl_Unit_NO" runat="server" Text="رقم الوحدة" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="txt_Unit_NO" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Unit_NO_Req_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="txt_Unit_NO"
                                                runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group" style="text-align: center">
                                                <asp:Label ID="lbl_Floor_NO" runat="server" Text="رقم الطابق" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="txt_Floor_NO" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Floor_NO_Req_Val" ValidationGroup="Unit_RequiredField" ControlToValidate="txt_Floor_NO"
                                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <%----------------------------------------------------%>
                                        <div class="col-lg-4">
                                            <div class="form-group" style="text-align: center">
                                                <asp:Label ID="lbl_Building_NO" runat="server" Text="رقم البناء" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="txt_Building_NO" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group" style="text-align: center">
                                                <asp:Label ID="lbl_Street_No" runat="server" Text=" الشارع" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="txt_Street_No" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group" style="text-align: center">
                                                <asp:Label ID="lbl_Zone_No" runat="server" Text=" المنطقة" ForeColor="White"></asp:Label>
                                                <asp:TextBox ID="txt_Zone_No" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
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
                                                <asp:Label ID="Image_One" runat="server" Text="Label" Visible="false"></asp:Label>
                                                <asp:Label ID="Image_One_Pathe" runat="server" Text="Label" Visible="false"></asp:Label>


                                                <div runat="server" id="Image_One_Div">
                                                    <a runat="server" id="Link_Image_One" style="font-size: 15px;">
                                                        <i class="fa fa-paperclip" style="font-size: 40px;"></i>
                                                        <asp:Label ID="lbl_Link_Image_One" runat="server" Text=""></asp:Label>
                                                    </a>
                                                    <asp:ImageButton ID="Btn_Remove_Link_Image_One" OnClick="Btn_Remove_Link_Image_One_Click" runat="server" Width="10px" Height="10px" ImageUrl="Main_Image/Calander_Close.png" />
                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Image_Two" runat="server" Text="تحميل صورة ثانية "></asp:Label>
                                                <asp:FileUpload ID="Image_Two_FileUpload" runat="server" CssClass="form-control" />
                                                <asp:Label ID="Image_Two" runat="server" Text="Label" Visible="false"></asp:Label>
                                                <asp:Label ID="Image_Two_Pathe" runat="server" Text="Label" Visible="false"></asp:Label>

                                                <div runat="server" id="Image_Two_Div">
                                                    <a runat="server" id="Link_Image_Two" style="font-size: 15px;">
                                                        <i class="fa fa-paperclip" style="font-size: 40px;"></i>
                                                        <asp:Label ID="lbl_Link_Image_Two" runat="server" Text=""></asp:Label>
                                                    </a>
                                                    <asp:ImageButton ID="Btn_Remove_Link_Image_Two" OnClick="Btn_Remove_Link_Image_Two_Click" runat="server" Width="10px" Height="10px" ImageUrl="Main_Image/Calander_Close.png" />
                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Image_Three" runat="server" Text="تحميل صورة ثالثة"></asp:Label>
                                                <asp:FileUpload ID="Image_Three_FileUpload" runat="server" CssClass="form-control" />
                                                <asp:Label ID="Image_Three" runat="server" Text="Label" Visible="false"></asp:Label>
                                                <asp:Label ID="Image_Three_Pathe" runat="server" Text="Label" Visible="false"></asp:Label>

                                                <div runat="server" id="Image_Three_Div">
                                                    <a runat="server" id="Link_Image_Three" style="font-size: 15px;">
                                                        <i class="fa fa-paperclip" style="font-size: 40px;"></i>
                                                        <asp:Label ID="lbl_Link_Image_Three" runat="server" Text=""></asp:Label>
                                                    </a>
                                                    <asp:ImageButton ID="Btn_Remove_Link_Image_Three" OnClick="Btn_Remove_Link_Image_Three_Click" runat="server" Width="10px" Height="10px" ImageUrl="Main_Image/Calander_Close.png" />
                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Image_Four" runat="server" Text="تحميل رابعة"></asp:Label>
                                                <asp:FileUpload ID="Image_Four_FileUpload" runat="server" CssClass="form-control" />
                                                <asp:Label ID="Image_Four" runat="server" Text="Label" Visible="false"></asp:Label>
                                                <asp:Label ID="Image_Four_Pathe" runat="server" Text="Label" Visible="false"></asp:Label>

                                                <div runat="server" id="Image_Four_Div">
                                                    <a runat="server" id="Link_Image_Four" style="font-size: 15px;">
                                                        <i class="fa fa-paperclip" style="font-size: 40px;"></i>
                                                        <asp:Label ID="lbl_Link_Image_Four" runat="server" Text=""></asp:Label>
                                                    </a>
                                                    <asp:ImageButton ID="Btn_Remove_Link_Image_Four" OnClick="Btn_Remove_Link_Image_Four_Click" runat="server" Width="10px" Height="10px" ImageUrl="Main_Image/Calander_Close.png" />
                                                </div>

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
                    <asp:Button ID="btn_Add_Unit" runat="server" Text="حفظ التغيرات" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" OnClick="btn_Add_Unit_Click" />
                    &nbsp;&nbsp;
                    <asp:Button CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة المباني" ValidationGroup="x" OnClick="Unnamed1_Click"  />
                </div>












      <%--*********************  Delete **********************************--%>
    <br />
    <hr />
    <div class="container-fluid">
        <h5>حذف الوحدة</h5>
        <div class="row">
            <div class="col-lg-1">
                <br />
                <asp:LinkButton ID="Delete_Unit" CssClass="btn btn-danger" runat="server" ValidationGroup="Delete" OnClick="Delete_Unit_Click" OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');"  ><i class="fa fa-trash" style="font-size:18px;"></i></asp:LinkButton>
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
    </div>






    <script>$('#<%=Unit_Type_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Unit_Condition_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Unit_Detail_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Building_Name_DropDownList.ClientID%>').chosen();</script>
</asp:Content>
