<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Task_List.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Task_List" %>

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
            background-color:  #52a2da;
            color: #fff;
        }


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
    <%--***********************************************************************************************--%>
    <!-- Container Fluid-->
    <div class="container-fluid" id="container-wrapper">
        <div class="row">
            <div class="col-lg-3 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Task_List" runat="server" Text="قائمة كافة المهام"></asp:Label>
                </h1>
            </div>
            <div class="col-lg-3 mb-3">
                <asp:LinkButton CssClass="btn btn-primary" runat="server" PostBackUrl="~/English/Main_Application/Add_Task.aspx">
                    <i class="fa fa-plus" style="font-size:25px;"></i> &nbsp; إضافة مهمة جديدة</asp:LinkButton>

            </div>
        </div>

        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" id="Grid">

                        <asp:Repeater ID="Task_List_R" runat="server" ClientIDMode="Static" OnItemDataBound="Task_List_R_ItemDataBound">
                            <HeaderTemplate>
                                <table cellspacing="0" style="width: 100%; font-size: 13px" class="datatable table table-striped table-bordered">
                                    <thead>
                                        <th style="text-align: center; width: 10px"></th>
                                        <th style="text-align: center">الأولوية</th>
                                        <th style="text-align: center"> المهمة</th>
                                        <th style="text-align: center">القسم</th>
                                        <th style="text-align: center">اسم الموظف </th>
                                        <th style="text-align: center">وصف المهمة</th>
                                        <th style="text-align: center">تاريخ البدء</th>
                                        <th style="text-align: center">تاريخ الإنتهاء</th>
                                        <th style="text-align: center">تاريخ الإنتهاء الفعلي</th>
                                        <th style="text-align: center">حالة المهمة</th>
                                        <th style="text-align: center; display: none">الأولوية</th>

                                        <th style="width: 50px"></th>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="row" runat="server">
                                    <td style="text-align: center; width: 10px">
                                        <asp:Button ID="But_Priority" runat="server" CssClass="Indicator_buttons" Enabled="false" /></td>
                                    <td>
                                        <asp:Label ID="lbl_Task_Priority_Word" Font-Bold="true" runat="server" Text='<%# Eval("Task_Priority_Word") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Task_Type" runat="server" Text='<%# Eval("Task_Type") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Department_Arabic_Name" runat="server" Text='<%# Eval("Department_Arabic_Name") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Employee_Arabic_name" runat="server" Text='<%# Eval("Employee_Arabic_name") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Task_Descrioption" runat="server" Text='<%# Eval("Task_Descrioption") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Start_date" runat="server" Text='<%# Eval("Start_date") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Actual_End_Date" runat="server" Text='<%# Eval("Actual_End_Date") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Task_Status" runat="server" Text='<%# Eval("Task_Status") %>' /></td>
                                    <td style="display: none">
                                        <asp:Label ID="lbl_Task_Priority" runat="server" Text='<%# Eval("Task_Priority") %>' /></td>

                                    <td>
                                    <asp:LinkButton ID="Edit"  runat="server" CommandArgument='<%# Eval("Task_Management_ID") %>' OnClick="Edit_Task"> <i class="fa fa-pencil" style="font-size:18px; color:#0779c9"></i> </asp:LinkButton>
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
        </div>
    </div>
    <!---Container Fluid-->
</asp:Content>
