<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Unit_Datials.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Unit_Datials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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





    <div class="container-login" style="padding-top: 70px">
        <div class="row justify-content-center" style="margin-top: -129px;">
            <div class="col-xl-12 col-lg-12 col-md-9">

                <div class="card shadow-sm my-5">
                    <div class="card-body p-0">
                        <div class="row" style="top: -14px;">
                            <div class="col-lg-12">
                                <div class="login-form">
                                    <h1 class="h4 text-gray-900 mb-4" style="margin-left: 40%">&nbsp;تفاصيل
                                                                                <asp:Label ID="lbl_Details_Unit_Name" runat="server" Text=""></asp:Label>

                                    </h1>
                                    <div>



                                        <div class="row" style="border-style: solid; border-radius: 9px;">
                                            <div class="col-lg-12">
                                                <div class="card mb-2">
                                                    <table>
                                                        <tr>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Unit_Number" runat="server" Text="رقم الوحدة" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Floor_Number" runat="server" Text="رقم الطابق" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Unit_Sapce" runat="server" Text="مساحة الوحدة " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Oreedo_Number" runat="server" Text="رقم أوريدوو" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Electricity_Number" runat="server" Text="رقم الكهرباء" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Unit_Number" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Floor_Number" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Unit_Sapce" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Oreedo_Number" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Electricity_Number" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="card mb-2">
                                                    <table>
                                                        <tr>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Water_Number" runat="server" Text="رقم المياه" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_current_situation" runat="server" Text="الوضع الحالي" Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Unit_type" runat="server" Text="نوع الوحدة " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Unit_Condition" runat="server" Text="حالة الوحدة " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Title_Unit_Detail" runat="server" Text="تفاصيل الوحدة " Font-Size="15px" ForeColor="#52a2da" Font-Bold="true"></asp:Label></th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Water_Number" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_current_situation" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Unit_type" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Unit_Condition" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Dtl_Unit_Detail" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <h4>
                                            <asp:Label ID="Label1" runat="server" Text="صور الوحدة"></asp:Label></h4>
                                        <div class="row" style="border-style: solid; border-radius: 9px;">
                                            <div class="col-lg-12">
                                                <div class="card mb-2">
                                                    <table>
                                                        <tr>
                                                            <th>
                                                                <asp:Label ID="lbl_Titel_Image_1" runat="server" Text="صورة 1 " Font-Size="15px" ForeColor="#52a2da"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Titel_Image_2" runat="server" Text="صورة 2 " Font-Size="15px" ForeColor="#52a2da"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Titel_Image_3" runat="server" Text="صورة 3 :" Font-Size="15px" ForeColor="#52a2da"></asp:Label></th>
                                                            <th>
                                                                <asp:Label ID="lbl_Titel_Image_4" runat="server" Text="صورة 4 :" Font-Size="15px" ForeColor="#52a2da"></asp:Label></th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="Image_1" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Photo_Click" /></td>
                                                            <td>
                                                                <asp:ImageButton ID="Image_2" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Image_2_Click" /></td>
                                                            <td>
                                                                <asp:ImageButton ID="Image_3" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Image_3_Click" /></td>
                                                            <td>
                                                                <asp:ImageButton ID="Image_4" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Image_4_Click" /></td>
                                                        </tr>
                                                        <tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <%--<asp:Button ID="btn_Back_To_Unit_List" CssClass="btn btn-light mb-1" runat="server" Text="العودة لقائمة الوحدات" ValidationGroup="x" OnClick="btn_Back_To_Unit_List_Click" OnClientClick="x"  />--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
