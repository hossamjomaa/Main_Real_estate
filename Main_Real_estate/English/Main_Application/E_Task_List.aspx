<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="E_Task_List.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.E_Task_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            text-align: center
        }

        th {
            background-color: #cacff1;
        }
    </style>

    <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
            border: 1px solid #dddddd;
            text-align: left;
            text-align: center;
        }
    </style>

    <style>
        .Indicator_buttons {
            border-radius: 50px;
            border-style: solid;
            border-radius: 50px;
            width: 20px;
            margin-right: 20px;
            margin-top: 20px;
            height: 20px;
        }
    </style>


    <div class="container-fluid" id="container-wrapper">


         <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titelt" runat="server" Text="المهام الموكلة للسيد : "></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="lbl_Employee" runat="server"></asp:Label>
            </h1>
        </div>


        <div class="row">
            <div class="col-lg-12 mb-4">
                <asp:Repeater ID="Task_Repeater" runat="server" OnItemDataBound="Task_Repeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="card" style="padding: 20px">
                            <div class="row" style="padding-right: 15px; text-align: center">
                                <table>
                                    <tr>
                                        <th style="display: none">ID</th>
                                        <th>الأولوية</th>
                                        <th>المهمة</th>
                                        <th>القسم</th>
                                        <th>الموظف</th>
                                        <th>تاريخ البدء</th>
                                        <th>تاريخ الإنتهاء</th>
                                        <th>تاريخ الإنتهاء الفعلي</th>
                                        <th style="width: 300px;">التقرير و الملاحظات</th>
                                        <th>الحالة</th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                    <tr>
                                        <td style="display: none">
                                            <asp:Label ID="Id" runat="server" Text='<%# Eval("Task_Management_ID") %>'></asp:Label></td>
                                        <td>
                                            <asp:Button ID="But_Priority" runat="server" CssClass="Indicator_buttons" Enabled="false" /><br />
                                            <asp:Label ID="lbl_Task_Priority_Word" runat="server" Text='<%# Eval("Task_Priority_Word") %>'></asp:Label>
                                            <asp:Label ID="lbl_Task_Priority" runat="server" Text='<%# Eval("Task_Priority") %>' Visible="false"></asp:Label>

                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Task_Type") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Department_Arabic_Name") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Employee_Arabic_name") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Start_date") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("End_Date") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("Actual_End_Date") %>'></asp:Label></td>

                                        <td style="width: 300px;">
                                            <asp:TextBox ID="lbl_Task_Descrioption" runat="server" Text='<%# Eval("Task_Descrioption") %>' Width="280px" TextMode="MultiLine" Enabled="false"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="lbl_Task_Status" runat="server" Text='<%# Eval("Task_Status") %>' Visible="false"></asp:Label>
                                            <asp:DropDownList ID="Task_Status_DropDownList" runat="server" Enabled="false">
                                                <asp:ListItem Value="1" Text="قيد التنفيذ"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="إنتظار"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="مجزئة"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="معلقة"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="ملغاة"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="منجزة"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>




                                        <td>
                                            <asp:LinkButton ID="Edit" CssClass="btn btn-primary" runat="server" CommandArgument='<%# Eval("Task_Management_ID") %>' OnClick="Edit_Unit" Text="تحديث" Visible="false"></asp:LinkButton>
                                            <asp:LinkButton ID="Cancel_Edit" CssClass="btn btn" runat="server" CommandArgument='<%# Eval("Task_Management_ID") %>' OnClick="Cancel_Edit" Text="إلغاء" Visible="false"></asp:LinkButton>
                                            <asp:LinkButton ID="OnEdit" CssClass="btn btn-success" runat="server" CommandArgument='<%# Eval("Task_Management_ID") %>' OnClick="ON_Edit" Text="تعديل">  </asp:LinkButton>
                                        </td>


                                        <td>
                                            <asp:LinkButton ID="parting" CssClass="btn btn-secondary" runat="server" CommandArgument='<%# Eval("Task_Management_ID") %>' OnClick="parting" Text="تجزءة"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <hr />

                            <div class="row" runat="server" id="PT_Div" visible="false">
                                <div class="col-lg-8">
                                    <div class="form-group">
                                         <asp:Label ID="Tasl_C_ARG" runat="server" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txt_Part_Task_Discreption" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <asp:Button ID="btn_Add_Part_Task" runat="server" Text="إضافة" OnClick="Add_Part" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" ValidationGroup="x" />
                                        <asp:Button ID="btn_Cancel_Add_Part_Task" runat="server" Text="إنهاء" OnClick="C_parting" CssClass="btn  mb-1" BackColor="#52ffda" ForeColor="White" ValidationGroup="X"/>
                                    </div>
                                </div>
                            </div>

                            <br />
                            


                            <asp:Label ID="lbl_titel_Part_Task" runat="server" Text="أجزاء المهمة" Font-Size="20px" ForeColor="Blue"></asp:Label>
                            <%---------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                            <asp:Repeater ID="Part" runat="server" OnItemDataBound="Part_ItemDataBound">
                                <ItemTemplate>
                                    <div class="row" style="padding: 15px; text-align: center; border-bottom-style: dotted">
                                        <div class="col-lg-4">
                                            <asp:TextBox ID="lbl_Part_Task_Description" runat="server" Text='<%# Eval("Task_Part_Discription") %>' Width="500px" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:DropDownList ID="Task_Status_DropDownList" runat="server" Enabled="false">
                                                <asp:ListItem Value="1" Text="قيد التنفيذ"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="إنتظار"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="مجزئة"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="معلقة"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="ملغاة"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="منجزة"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:LinkButton ID="Edit" CssClass="btn btn-primary" runat="server" CommandArgument='<%# Eval("Task_Part_Id") %>' OnClick="Edit_Part_Task" Text="تحديث" Visible="false"></asp:LinkButton>
                                            <asp:LinkButton ID="Cancel_Edit" CssClass="btn btn" runat="server" CommandArgument='<%# Eval("Task_Part_Id") %>' OnClick="PT_Cancel_Edit" Text="إلغاء" Visible="false"></asp:LinkButton>
                                            <asp:LinkButton ID="OnEdit" CssClass="btn btn-success" runat="server" CommandArgument='<%# Eval("Task_Part_Id") %>' OnClick="PT_ON_Edit" Text="تعديل">  </asp:LinkButton>
                                            <asp:LinkButton ID="Delete_Pate_Task" CssClass="btn btn-danger" runat="server" CommandArgument='<%# Eval("Task_Part_Id") %>' OnClick="Delete_Pate_Task" Text="حذف">  </asp:LinkButton>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <%---------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                        </div>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
