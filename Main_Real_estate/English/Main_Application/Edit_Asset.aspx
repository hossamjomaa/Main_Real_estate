<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Edit_Asset.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Edit_Asset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" />

    <div class="container-fluid" id="container-wrapper">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Edit_Asset" runat="server" Text="تعديل الأصل :"></asp:Label>&nbsp;
                <asp:Label ID="lbl_Name_Of_Asset" runat="server" Text=""></asp:Label>&nbsp;
                <asp:Label ID="lbl_Success_Edit_Asset" runat="server" ForeColor="Green"></asp:Label>
            </h1>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="card mb-6">
                    <div class="card-body">
                        <div>
                            <div class="form-group">
                                <asp:Label ID="lbl_En_Asset_Name" runat="server" Text="اسم الاصل بالأنكليزية "></asp:Label>
                                &nbsp;<asp:RegularExpressionValidator ID="Asset_Name_RegularExpressionValidator" runat="server" ControlToValidate="txt_En_Asset_Name"
                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف الأنكليزية" ForeColor="Red"
                                    ValidationExpression="[a-z A-Z]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_En_Asset_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Asset_Name_reqFuild" ControlToValidate="txt_En_Asset_Name"
                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Ar_Asset_Name" runat="server" Text="اسم الأصل بالعربية"></asp:Label>
                                &nbsp;<asp:RegularExpressionValidator ID="Ar_Asset_Name_RegularExpressionValidator" runat="server" ControlToValidate="txt_Ar_Asset_Name"
                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                    ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Ar_Asset_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Ar_Asset_Name_RequiredFieldValidator" ControlToValidate="txt_Ar_Asset_Name"
                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Asset_Purchase_Date" runat="server" Text="تاريخ الشراء"></asp:Label>&nbsp;
                                 <asp:TextBox ID="txt_Asset_Purchase_Date" runat="server" CssClass="form-control"></asp:TextBox>
                                <input type="button" value="إختر التاريخ" onclick="OnClick()"><br />
                                <div id="divCalendar" style="position: absolute; display: none;">
                                    <asp:Calendar ID="Asset_Purchase_Date_Calendar" runat="server" Height="200px" Width="220px" OnSelectionChanged="Asset_Purchase_Date_Calendar_SelectionChanged" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399">
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
                                <asp:RequiredFieldValidator ID="Asset_Purchase_Date_RequiredFieldValidator" ControlToValidate="txt_Asset_Purchase_Date"
                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Asset_Value" runat="server" Text="قيمة الأصل"></asp:Label>&nbsp;
                                <asp:RegularExpressionValidator ID="Asset_Value_RegularExpressionValidator" runat="server" ControlToValidate="txt_Asset_Value"
                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Asset_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Asset_Value_reqFuild" ControlToValidate="txt_Asset_Value"
                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Asset_Quantity" runat="server" Text="كمية الأصل"></asp:Label>&nbsp;
                                <asp:RegularExpressionValidator ID="Asset_Quantity_RegularExpressionValidator" runat="server" ControlToValidate="txt_Asset_Quantity"
                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Asset_Quantity" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Asset_Quantity_reqFuild" ControlToValidate="txt_Asset_Quantity"
                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Asset_Description" runat="server" Text="وصف الأصل"></asp:Label>
                                &nbsp;<asp:RegularExpressionValidator ID="Asset_Description_RegularExpressionValidator" runat="server" ControlToValidate="txt_Asset_Description"
                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأحرف العربية" ForeColor="Red"
                                    ValidationExpression="[ا-ي أآى ة ئ ء]+"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txt_Asset_Description" runat="server" CssClass="form-control" TextMode="MultiLine" Height="40px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Asset_Description_RequiredFieldValidator" ControlToValidate="txt_Asset_Description"
                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Asset_Warranty" runat="server" Text="ضمان الأصل"></asp:Label>
                                <asp:DropDownList ID="Asset_Warranty_DropDownList" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Asset_Warranty_RequiredFieldValidator" ControlToValidate="Asset_Warranty_DropDownList"
                                    InitialValue="إختر ضمان الأصل ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card mb-6">
                    <div class="card-body">
                        <div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Asset_Condition" runat="server" Text="حالة الأصل"></asp:Label>
                                <asp:DropDownList ID="Asset_Condition_DropDownList" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Asset_Condition_RequiredFieldValidator" ControlToValidate="Asset_Condition_DropDownList"
                                    InitialValue="أختر حالة الاصل ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>


                            <div class="form-group">
                                <asp:Label ID="lbl_Asset_Type" runat="server" Text="نوع الأصل"></asp:Label>
                                <asp:DropDownList ID="Asset_Type_DropDownList" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Asset_Type_RequiredFieldValidator" ControlToValidate="Asset_Type_DropDownList"
                                    InitialValue="أختر نوع الأصل ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Asset_Location" runat="server" Text="مكان الأصل"></asp:Label>
                                <asp:DropDownList ID="Asset_Location_DropDownList" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Asset_Location_RequiredFieldValidator" ControlToValidate="Asset_Location_DropDownList"
                                    InitialValue="إختر مكان الأصل ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <asp:Label ID="lbl_Asset_Inventory" runat="server" Text="المخزون"></asp:Label>
                                <asp:DropDownList ID="Asset_Inventory_DropDownList" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Asset_Inventory_RequiredFieldValidator" ControlToValidate="Asset_Inventory_DropDownList"
                                    InitialValue="إختر مخزون الأصل ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Asset_Vendor" runat="server" Text="بائع"></asp:Label>
                                <asp:DropDownList ID="Asset_Vendor_DropDownList" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Asset_Vendor_RequiredFieldValidator" ControlToValidate="Asset_Vendor_DropDownList"
                                    InitialValue="إختر بائع الاصل ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Asset_Building" runat="server" Text="اسم البناء"></asp:Label>
                                <asp:DropDownList ID="Assets_Building_DropDownList" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Asset_Building_RequiredFieldValidator" ControlToValidate="Assets_Building_DropDownList"
                                    InitialValue="أختر اسم البناء ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lbl_Asset_Unit" runat="server" Text="اسم الوحدة"></asp:Label>
                                <asp:DropDownList ID="Asset_Unit_DropDownList" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Asset_Unit_RequiredFieldValidator" ControlToValidate="Asset_Unit_DropDownList"
                                    InitialValue="اختر اسم الوحدة ...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="col-lg-4">
        <asp:Button ID="btn_Edit_Asset" runat="server" Text="حفظ التغيرات" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" OnClick="btn_Edit_Asset_Click" />
        &nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Asset_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة إلى قائمة الأصول" ValidationGroup="x" OnClick="btn_Back_To_Asset_List_Click" />
    </div>
    <br />
    
    
    <script>$('#<%=Asset_Type_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Asset_Condition_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Asset_Location_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Asset_Inventory_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Assets_Building_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Asset_Unit_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Asset_Vendor_DropDownList.ClientID%>').chosen();</script>
    <script>$('#<%=Asset_Warranty_DropDownList.ClientID%>').chosen();</script>
    <script>function OnClick() { if (divCalendar.style.display == "none") divCalendar.style.display = ""; else divCalendar.style.display = "none"; }</script>
</asp:Content>
