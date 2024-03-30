<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Add_Role.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Add_Role" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
            border: 1px solid #dddddd;
            text-align: center;
            padding: 8px;
        }
    </style>





    <div class="container-fluid" id="container-wrapper">
        <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Role" runat="server" Text="إضافة صلاحية جديدة"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Label ID="lbl_Success_Add_New_Role" runat="server" ForeColor="#00FF40"></asp:Label>
            </h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <asp:Label ID="lbl_Role_Name" runat="server" Text="اسم الصلاحية"></asp:Label>
                    <asp:TextBox ID="txt_Role_Name" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Role_Name_Req_Val" ValidationGroup="Role_RequiredField" ControlToValidate="txt_Role_Name"
                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="card mb-4">
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr style="color:#52a2da;">
                                        <th>القسم</th>
                                        <th>عرض</th>
                                        <th>إضافة</th>
                                        <th>تعديل</th>
                                        <th>حذف</th>
                                    </tr>
                                    <tr>
                                        <th>الملكيات</th>
                                        <td><asp:CheckBox ID="Pro_R_Cb" runat="server" /></td>
                                        <td><asp:CheckBox ID="Pro_A_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="Pro_E_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="Pro_D_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                    </tr>
                                    <tr>
                                        <th>التعاقد</th>
                                        <td><asp:CheckBox ID="Con_R_Cb" runat="server" /></td>
                                        <td><asp:CheckBox ID="Con_A_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="Con_E_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="Con_D_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                    </tr>
                                    <tr>
                                        <th>شؤون العملاء</th>
                                        <td><asp:CheckBox ID="Te_R_Cb" runat="server" /></td>
                                        <td><asp:CheckBox ID="Te_A_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="Te_E_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="Te_D_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                    </tr>
                                    <tr>
                                        <th>إدارة الأصول</th>
                                        <td><asp:CheckBox ID="AsM_R_Cb" runat="server" /></td>
                                        <td><asp:CheckBox ID="AsM_A_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="AsM_E_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="AsM_D_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                    </tr>
                                    <tr>
                                        <th>التحصيل</th>
                                        <td><asp:CheckBox ID="Col_R_Cb" runat="server" /></td>
                                        <td></td>
                                        <td><asp:CheckBox ID="Col_E_Cb" runat="server" Visible="false" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Pro_A_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="Pro_E_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="Pro_D_Cb" EventName="CheckedChanged" />

                                <asp:AsyncPostBackTrigger ControlID="Con_A_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="Con_E_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="Con_D_Cb" EventName="CheckedChanged" />

                                <asp:AsyncPostBackTrigger ControlID="Te_A_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="Te_E_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="Te_D_Cb" EventName="CheckedChanged" />

                                <asp:AsyncPostBackTrigger ControlID="AsM_A_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="AsM_E_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="AsM_D_Cb" EventName="CheckedChanged" />

                                <asp:AsyncPostBackTrigger ControlID="Col_E_Cb" EventName="CheckedChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card mb-4">
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr style="color:#52a2da;">
                                        <th>القسم</th>
                                        <th>عرض</th>
                                        <th>إضافة</th>
                                        <th>تعديل</th>
                                        <th>حذف</th>
                                    </tr>
                                    <tr>
                                        <th>البيانات المالية</th>
                                        <td><asp:CheckBox ID="FS_R_Cb" runat="server" /></td>
                                        <td><asp:CheckBox ID="FS_A_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="FS_E_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="FS_D_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                    </tr>
                                    <tr>
                                        <th>التسويق</th>
                                        <td><asp:CheckBox ID="Mar_R_Cb" runat="server" /></td>
                                        <td><asp:CheckBox ID="Mar_A_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="Mar_E_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="Mar_D_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                    </tr>
                                    <tr>
                                        <th>إدارة المهام</th>
                                        <td><asp:CheckBox ID="TM_R_Cb" runat="server" /></td>
                                        <td><asp:CheckBox ID="TM_A_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="TM_E_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td><asp:CheckBox ID="TM_D_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                    </tr>
                                    <tr>
                                        <th>كشف النواقص</th>
                                        <td><asp:CheckBox ID="MF_R_Cb" runat="server" /></td>
                                        <td></td>
                                        <td><asp:CheckBox ID="MF_E_Cb" runat="server" AutoPostBack="true" OnCheckedChanged="Pro_A_Cb_CheckedChanged"/></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <th>إعدادات النظام</th>
                                        <td><asp:CheckBox ID="SS_R_Cb" runat="server" /></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="FS_A_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="FS_E_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="FS_D_Cb" EventName="CheckedChanged" />

                                <asp:AsyncPostBackTrigger ControlID="Mar_A_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="Mar_E_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="Mar_D_Cb" EventName="CheckedChanged" />

                                <asp:AsyncPostBackTrigger ControlID="TM_A_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="TM_E_Cb" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="TM_D_Cb" EventName="CheckedChanged" />

                                <asp:AsyncPostBackTrigger ControlID="MF_E_Cb" EventName="CheckedChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                         
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3">
                <asp:Button ID="btn_Add_Role" runat="server" Text="إضافة " CssClass="btn btn" BackColor="#52a2da" ValidationGroup="Role_RequiredField" ForeColor="White" Width="248px" OnClick="btn_Add_Role_Click" />
            </div>
            <div class="col-lg-3">
                <asp:Button ID="btn_Back" runat="server" Text="العودة لقائمة الصلاحيات" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_Click" />
            </div>
        </div>
    </div>


</asp:Content>
