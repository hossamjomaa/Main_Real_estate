<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="complaint_report_request_List.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.complaint_report_request_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
         $(document).ready(function () {


             $('a[href*="No File"]').each(function () {
                 $(this).css('display', 'none');
             });


             var table = $('.datatable').DataTable({
                
                dom: 'Bfrtip',
                /*lengthChange: false,*/
                "pageLength": 10000,

                buttons: [
                    'copyHtml5',
                    'excelHtml5',
                    'csvHtml5',
                    /*'pdfHtml5'*/
                ],
                language: {
                    url: 'https://cdn.datatables.net/plug-ins/1.12.1/i18n/ar.json'
                }
            });

            table.buttons().container()
                .appendTo('#DataTables_Table_0_wrapper .col-md-6:eq(0)');
         });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            text-align: center !important;
            font-size: 13px;
             padding: 5px !important;         
        }

        table{
             table-layout: fixed !important;
             width: 100% !important;
             
        }
       
        th{
            background-color:#52a2da;
            color: #fff;
            text-align:center;
        }
        .Indicator_buttons{
            border-radius:50px;
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
                    <asp:Label ID="lbl_titel_complaint_report_request_List" runat="server" Text="قائمة  البلاغات والشكاوي"></asp:Label>
                </h1>
            </div>
            <div class="col-lg-3 mb-3">
                <asp:LinkButton ID="Add" CssClass="btn btn-primary" runat="server" PostBackUrl="~/English/Main_Application/Add_complaint_report_request.aspx" >
                    <i class="fa fa-plus" style="font-size:25px;"></i> &nbsp; إضافة بلاغ أو شكوى </asp:LinkButton>

            </div>
        </div>





        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="row">
                        <div class="col-lg-9">
                            <asp:Button ID="btn_all" runat="server" CssClass="Indicator_buttons" OnClick="btn_all_Click" />
                        &nbsp;
                        <span style="margin-top: 20px">كافة الطلبات</span>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_P_1" runat="server" CssClass="Indicator_buttons" BackColor="#faced2" OnClick="btn_P_1_Click" />
                        &nbsp;
                        <span style="margin-top: 20px">أولوية من الدرجة الأولى</span>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_P_2" runat="server" CssClass="Indicator_buttons" BackColor="#c5f8eb" OnClick="btn_P_2_Click" />
                        &nbsp;
                        <span style="margin-top: 20px">أولوية من الدرجة الثانية</span>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_P_3" runat="server" CssClass="Indicator_buttons" BackColor="#f1d5a1" OnClick="btn_P_3_Click" />
                        &nbsp;
                        <span style="margin-top: 20px">أولوية من الدرجة الثالثة</span>
                        
                        </div>


                        <div class="col-lg-2">
                            <div class="form-group" style="padding-left:10px">
                                <asp:Label ID="lbl_Complainte_Satus" runat="server" Text="حالة الطلب"></asp:Label>
                                <asp:DropDownList ID="Filter_DropDownList" runat="server" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="Filter_DropDownList_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="الكل"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="معلقة"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="منجزة"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="تحت الإجراء"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                   


                    <div class="table-responsive" style="border-radius: 10px;">


                        <asp:Repeater ID="request_List" runat="server" ClientIDMode="Static" OnItemDataBound="request_List_ItemDataBound" >
                        <HeaderTemplate>
                            <table  cellspacing="0" style="width: 100%; font-size:11px" class="datatable table table-bordered">
                                <thead>
                                    <th style="text-align: center;vertical-align: middle;">مسلسل</th>
                                    <th style="text-align: center;vertical-align: middle;">رقم</th>
                                    <th style="text-align: center;vertical-align: middle;">المصدر</th>
                                    <th style="text-align: center;vertical-align: middle;">اسم المستأجر</th>
                                    <th style="text-align: center;vertical-align: middle;">اسم الموظف </th>
                                    <th style="text-align: center;vertical-align: middle;">العنوان</th>
                                    <th style="text-align: center;vertical-align: middle;">التصنيف</th>
                                    <th style="text-align: center;vertical-align: middle;">النوع</th>
                                    <th style="text-align: center;vertical-align: middle;">التوجيه</th>
                                    <th style="text-align: center;vertical-align: middle;">تاريخ التقديم</th>
                                    <th style="text-align: center;vertical-align: middle;"> حالة الطلب</th>
                                    <th style="display:none"></th>
                                    <th style="width:30px"></th>
                                </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr id="row" runat="server">
                                <td> <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                <td>
                                <asp:LinkButton ID="LinK_Complaint_Report_Request" runat="server" CommandArgument='<%# Eval("Complaint_Report_Request_Id") %>' OnClick="Edit_Request">Edit</asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="lbl_source" runat="server" Text='<%# Eval("source") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Employee_Arabic_name" runat="server" Text='<%# Eval("Employee_Arabic_name") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text=' <%# Eval("Building_Arabic_Name") %>' />
                                    <br />
                                    <asp:Label ID="lbl_Unit_Number" runat="server" Text='<%# Eval("Unit_Number") %>' />
                                </td>
                                
                                <td>
                                    <asp:Label ID="lbl_Order_Classification" runat="server" Text='<%# Eval("Order_Classification") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Report_Type" runat="server" Text='<%# Eval("Report_Type") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Report_Direction" runat="server" Text='<%# Eval("Report_Direction") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Date" runat="server" Text='<%# Eval("Date") %>' /></td>
                                 <td>
                                    <asp:Label ID="lbl_Activ" runat="server" Text='<%# Eval("Activ") %>' /></td>

                                <td style="display:none">
                                    <asp:Label ID="lbl_priority_Danger" runat="server" Text='<%# Eval("priority_Danger") %>' /></td>
                                
                                 <%--<td>
                                    <asp:Label ID="lbl_precaution" runat="server" Text='<%# Eval("precaution") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_" runat="server" Text='<%# Eval("Activ") %>' /></td>--%>

                                <td>
                                    <asp:LinkButton ForeColor="#0779c9" runat="server" CommandArgument='<%# Eval("Complaint_Report_Request_Id") %>' OnClick="Details_Request" > <i class="fa fa-list" style="font-size:18px;"></i> </asp:LinkButton>
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
