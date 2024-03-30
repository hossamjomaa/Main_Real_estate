<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Edit_Ownership.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Edit_Ownership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style> .width { height:75px; }  </style>


    <style>
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 50px;
}

td, th {
    width:100px;
  border: 1px solid ;
  text-align: center;
  padding: 8px;
}
</style>


    <div class="container-fluid" id="container-wrapper">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Ownership" runat="server" Text="تعديل الملكية :"></asp:Label>&nbsp;
                                    <asp:Label ID="lbl_Name_Of_Ownership" runat="server" Text=""></asp:Label>
                <asp:Label ID="lbl_Success_Add_New_Ownership" runat="server" ForeColor="Green"></asp:Label>
            </h1>
        </div>
        <div class="row">
            <div class="col-lg-8">
                <div class="card ">
                    <div class="card-body">
                        <div class="row width">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Ownership_Name" runat="server" Text="Property Name"></asp:Label>
                                    <asp:RegularExpressionValidator ID="Reg_Ex_En_Ownership_Name" runat="server" ControlToValidate="txt_En_Ownership_Name"
                                        EnableClientScript="True" ErrorMessage="أحرف إنكليزية فقط" ForeColor="Red"
                                        ValidationExpression="[a-z A-Z0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_En_Ownership_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Req_Val_En_Ownership_Name" ControlToValidate="txt_En_Ownership_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Ownership_Name" runat="server" Text="الاسم بالعربية"></asp:Label>
                                    <asp:RegularExpressionValidator ID="Reg_Ex_Ar_Ownership_Name" runat="server" ControlToValidate="txt_Ar_Ownership_Name"
                                        EnableClientScript="True" ErrorMessage="أحرف عربية فقط" ForeColor="Red"
                                        ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_Ar_Ownership_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Req_Val_Ar_Ownership_Name" ControlToValidate="txt_Ar_Ownership_Name"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
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
                        </div>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="row width">
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
                                                    EnableClientScript="True" ErrorMessage="أرقام فقط" ForeColor="Red"
                                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                            <asp:TextBox ID="txt_PIN_Number" MaxLength="8" runat="server" CssClass="form-control" OnTextChanged="txt_PIN_Number_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="Req_Val_PIN_Number" ControlToValidate="txt_PIN_Number"
                                                runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:Label ID="Pin_No_Worrnig" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_Zone_Name" runat="server" Text="اسم المنطقة"></asp:Label>
                                            <asp:DropDownList ID="Zone_Name_DropDownList" AutoPostBack="true" OnSelectedIndexChanged="Zone_Name_DropDownList_SelectedIndexChanged" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="Zone_Name_Req_Val" ControlToValidate="Zone_Name_DropDownList"
                                                InitialValue="أختر إسم المنطقة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Zone_Name_DropDownList" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="txt_PIN_Number" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="row width">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Owner_Name" runat="server" Text="اسم المالك"></asp:Label>
                                    <asp:DropDownList ID="Owner_DropDownList" runat="server" CssClass="form-control" DataTextField="Text">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Owner_Name_Req_dVal" ControlToValidate="Owner_DropDownList"
                                        InitialValue="اختر إسم المالك ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                                EnableClientScript="True" ErrorMessage="أرقام فقط" ForeColor="Red"
                                                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                            <asp:TextBox ID="txt_Lande_Value" runat="server" CssClass="form-control"></asp:TextBox>

                                            


                                            <asp:CheckBox ID="CheckBox_Appreciation" runat="server" Text="تقديري" AutoPostBack="true" OnCheckedChanged="CheckBox_Appreciation_CheckedChanged" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:CheckBox ID="CheckBox_octagon" runat="server" Text="مثمن" AutoPostBack="true" OnCheckedChanged="CheckBox_octagon_CheckedChanged" />
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
                <div class="row width">
                    <div class="col-lg-6">
                        <asp:Button ID="btn_Add_Ownership" runat="server" Text="حفظ التغيرات" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" OnClick="btn_Add_Ownership_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btn_Back_To_OwnerShip_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الملكيات" ValidationGroup="x" OnClick="btn_Back_To_OwnerShip_List_Click1" />
                    </div>
                    <div class="col-lg-1">
                        <asp:LinkButton ID="Delete_Ownership"  runat="server" ValidationGroup="Delete" OnClick="Delete_Ownership_Click" OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');"><i class="fa fa-trash" style="font-size:40px; color:#0779c9"></i></asp:LinkButton>
                    </div>
                    <div class="col-lg-5">
                        <div class="form-group" runat="server" id="Delete_Reason">
                            <asp:Label ID="lbl_Reason_Delete" runat="server" Text="سبب الحذف"></asp:Label>
                            <asp:TextBox ID="txt_Reason_Delete"  runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Delete_ReqFieVal" ControlToValidate="txt_Reason_Delete"
                                runat="server" ErrorMessage="* يرجى توضيح سبب الحذف" ForeColor="Red" ValidationGroup="Delete"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    </div>
                <hr />

                <div class="row width">
            <div class="col-lg-5">
                <div class="form-group">
                    <asp:Label ID="lbl_Statment" runat="server" Text="تحميل إفادة"></asp:Label>
                    <asp:FileUpload ID="Statment_FileUpload" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="Statment_Req_Field_Val" ControlToValidate="Statment_FileUpload"
                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red" ValidationGroup="Statment"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-lg-5">
                <div class="form-group">
                    <asp:Label ID="lbl_Statment_Date" runat="server" Text="تاريخ إفادة"></asp:Label>
                    <asp:TextBox ID="txt_Statment_Date" runat="server" CssClass="form-control" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Statment_Date_Req_Field_Val" ControlToValidate="txt_Statment_Date"
                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red" ValidationGroup="Statment"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-lg-2">
                <br />
                <asp:ImageButton ID="btn_Add_Statment" ImageUrl="Main_Image/plus.png" Width="25px" Height="25px" runat="server"  ValidationGroup="Statment" OnClick="btn_Add_Statment_Click"/>
            </div>
        </div>
        <div class="row">
            <div class="table-responsive">
                 <asp:Repeater ID="Statment_List" runat="server" ClientIDMode="Static" OnItemDataBound="Statment_List_ItemDataBound">
            <HeaderTemplate>
                <table cellspacing="0" style="width: 50%; font-size: 11px">
                    <thead>
                        <th>م</th>
                        <th style="text-align: center;">المرفق</th>
                        <th style="text-align: center;">تاريخ الإفادة</th>
                        <th></th>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                    
                    <td>
                        <a href='<%# Eval("Statment_Path") %>' target="_blank" id="Link_Property_Scheme" style="font-size: 10px;"> <i class="fa fa-file-pdf" style="font-size: 10px;"></i>
                        <asp:Label ID="lbl_Link_Property_Scheme_Pdf" runat="server" Text='<%# Eval("Statment_FileName") %>'></asp:Label>
                        </a>
                    </td>
                    <td><asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("Statment_Date") %>' /></td>

                    
                    <td>
                        <asp:LinkButton ID="Statment_delete" runat="server" OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');" CommandArgument='<%# Eval("Statment_Id") %>' OnClick="Statment_delete_Click"><i class="fa fa-trash" style="font-size:18px;"></i></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                            </table>
            </FooterTemplate>
        </asp:Repeater>
            </div>
        </div>
            </div>



            <div class="col-lg-4">
                <div class="row" style="background-color: #015997; height: 190px; border-radius: 10px; margin-bottom: 10px">
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



                <div style="border-style: solid; border-radius: 10px; height: 250px;">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row">
                                <div class="col-lg-10" style="margin-right:8px;">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_bond_Date" runat="server" Text="تاريخ السند"> </asp:Label>
                                        <asp:TextBox ID="txt_bond_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-8">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Ownership_Certificates" runat="server" Text="تحميل سند الملكية"></asp:Label>
                                        <asp:FileUpload ID="Ownership_Certificate_FileUpload" runat="server" CssClass="form-control" />
                                        <asp:Label ID="Ownership_Certificates_FileName" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="Ownership_Certificates_FilePath" runat="server" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <br />
                                    <div runat="server" id="Ownership_Certificate_Div">
                                        <a runat="server" id="Link_Ownership_Certificate_Pdf" style="font-size: 15px;">
                                            <i class="fa fa-file-pdf" style="font-size: 15px;"></i>
                                            <asp:Label ID="lbl_Link_Ownership_Certificate_Pdf" runat="server" Text="" Font-Size="10px"></asp:Label>
                                        </a>
                                        &nbsp;&nbsp;
                                        <%--<asp:ImageButton ID="Remove_Ownership_Certificates" ImageUrl="Main_Image/Delete.png" OnClick="Remove_Ownership_Certificates_Click" Width="15px" Height="15px" runat="server" />--%>
                                        <asp:LinkButton ID="Remove_Certificates" runat="server" OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');"  OnClick="Remove_Ownership_Certificates_Click">
                                            <i class="fa fa-trash" style="font-size:15px;"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-8">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_Property_Scheme" runat="server" Text="تحميل المخطط"></asp:Label>
                                        <asp:FileUpload ID="Property_Scheme_FileUpload" runat="server" CssClass="form-control" />
                                        <asp:Label ID="Property_Scheme_FileName" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="Property_Scheme_FilePath" runat="server" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <br />
                                    <div runat="server" id="Property_Scheme_Div">
                                        <a runat="server" id="Link_Property_Scheme_Pdf" style="font-size: 15px;">
                                            <i class="fa fa-file-pdf" style="font-size: 15px;"></i>
                                            <asp:Label ID="lbl_Link_Property_Scheme_Pdf" runat="server" Text="" Font-Size="10px"></asp:Label>
                                        </a>
                                        &nbsp;&nbsp;
                                       <%-- <asp:ImageButton ID="Remove_Property_Scheme" ImageUrl="Main_Image/Delete.png" OnClick="Remove_Property_Scheme_Click" Width="15px" Height="15px" runat="server" />--%>


                                        <asp:LinkButton ID="Remove_Scheme" runat="server" OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');"  OnClick="Remove_Property_Scheme_Click">
                                            <i class="fa fa-trash" style="font-size:15px;"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>



                           

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <%--*********************  Statment **********************************--%>
        
</asp:Content>
