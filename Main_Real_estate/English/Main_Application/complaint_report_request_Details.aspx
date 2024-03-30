<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="complaint_report_request_Details.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.complaint_report_request_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
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
    <%--**********************************************************************************************************--%>
    <div class="container-login" style="padding-top: 70px">
        <div class="row justify-content-center" style="margin-top: -129px;">
            <div class="col-xl-12 col-lg-12 col-md-9">
                <div class="card shadow-sm my-5">
                    <div class="card-body p-0">
                        <div class="row" style="top: -14px;">
                            <div class="col-lg-12">
                                <div class="login-form">
                                    <div class="row">
                                        <div class="col-lg-6" style="border-style: solid; text-align: center; padding-top: 10px; font-size: 25px; font-weight: bold">
                                            <div class="form-group">
                                                قسم خدمة شؤون العملاء 
                                            </div>
                                        </div>
                                        <div class="col-lg-6" style="border-style: solid; text-align: center; padding-top: 10px; font-size: 25px; font-weight: bold">
                                            <div class="form-group">
                                                شركة المنارة للصيانة والتجارة
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row">
                                        <div class="col-lg-12" style="border-style: solid; text-align: center; padding-top: 10px; font-size: 25px; font-weight: bold">
                                            <div class="form-group">
                                                <span style="color: #fc544b">الطلبات البلاغات و الشكاوي</span>
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <spa style="font-weight: bold">مصدر البلاغ:</spa>
                                                &nbsp;&nbsp;<asp:Label ID="lbl_source" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">العنوان :</span> &nbsp;&nbsp;<asp:Label ID="lbl_Building_Name" runat="server"></asp:Label>
                                                &nbsp;&nbsp;<asp:Label ID="lbl_Unit_Number" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">التاريخ :</span>&nbsp;&nbsp;<asp:Label ID="lbl_Date" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">التنصنيف : </span>&nbsp;&nbsp;<asp:Label ID="lbl_Order_Classification" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">النوع : </span>&nbsp;&nbsp;<asp:Label ID="lbl_Report_Type" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">توجيه البلاغ:&nbsp;&nbsp;</span><asp:Label ID="lbl_Report_Direction" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="col-lg-12" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">نص البلاغ :</span><br />
                                                <asp:Label ID="lbl_Report_Text" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">مدى عاجلية البلاغ:</span>&nbsp;&nbsp;<asp:Label ID="lbl_Priority" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">درجة خطورة البلاغ:</span>&nbsp;&nbsp;<asp:Label ID="lbl_Danger" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">أولوية البلاغ:&nbsp;&nbsp;</span><asp:Label ID="lbl_Priority_Resut" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-12" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">وصف تقرير الفحص :</span><br />
                                                <asp:Label ID="lbl_Report_Description" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-12" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">الإجراء الوقائي :</span><br />
                                                <asp:Label ID="lbl_precaution" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--**********************************************************************************************************--%>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-12" style="font-size: 20px; padding-top: 10px;">
                                            <div class="form-group">
                                                <span style="font-weight: bold">التحقق من إنجاز الطلب :</span>&nbsp;&nbsp;<asp:Label ID="lbl_Activ" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="border: solid">
                                        <div class="col-lg-6" style="font-size: 20px; padding-top: 10px;">
                                            <span style="font-weight: bold">قبل </span><br />
                                            <asp:ImageButton ID="Image_Befor" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Image_Befor_Click" />
                                        </div>
                                        <div class="col-lg-6" style="font-size: 20px; padding-top: 10px;">
                                            <span style="font-weight: bold">بعد </span><br />
                                            <asp:ImageButton ID="Image_After" runat="server" Width="80px" Height="80px" OnClientClick="target ='_blank';" OnClick="Image_After_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-login" style="padding-top: 70px" id="Maintenance_div" runat="server">
        <div class="row">
            <div class="col-lg-6">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Building_List" runat="server" Text="قائمة طلبات الصيانة"></asp:Label>
                </h1>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" id="Grid">
                        <asp:Repeater ID="Maintenance_Request_Liist" runat="server" ClientIDMode="Static">
                            <HeaderTemplate>
                                <table cellspacing="0" style="width: 100%; font-size: 11px" class="datatable table table-striped table-bordered">
                                    <thead>

                                        <th style="width: 90px; text-align: center;">نوع الصيانة</th>
                                        <th style="text-align: center;">تاريخ البدء</th>
                                        <th style="text-align: center;">تاريخ الإنتهاء</th>
                                        <th style="text-align: center;">الحالة</th>
                                        <th style="text-align: center;">التكلفة</th>

                                        <th style="width: 150px"></th>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Categoty_AR" runat="server" Text='<%# Eval("Categoty_AR") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Start_Date" runat="server" Text='<%# Eval("Start_Date") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Activ") %>' /></td>
                                    <td>
                                        <asp:Label ID="lbl_Cost" runat="server" Text='<%# Eval("Cost") %>' /></td>

                                    <td>
                                        <asp:LinkButton CssClass="btn btn-danger" runat="server" CommandArgument='<%# Eval("Maintenance_Request_ID") %>' OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');" OnClick="Delete_Maintenance_Request"><i class="fa fa-trash" style="font-size:18px;"></i></asp:LinkButton>
                                        &nbsp;&nbsp;
                                        <asp:LinkButton CssClass="btn btn-primary" runat="server" CommandArgument='<%# Eval("Maintenance_Request_ID") %>' OnClick="Details_Maintenance_Request"> <i class="fa fa-list" style="font-size:18px;"></i> </asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <div id="maintenance_request_Details_Div" runat="server" style="border-style: solid;" visible="false">
                            <div class="row">
                                <div class="col-lg-6" style="border-style: solid; text-align: center; padding-top: 10px; font-size: 25px; font-weight: bold">
                                    <div class="form-group">
                                        إدارة الأصول و المرافق  
                                    </div>
                                </div>
                                <div class="col-lg-6" style="border-style: solid; text-align: center; padding-top: 10px; font-size: 25px; font-weight: bold">
                                    <div class="form-group">
                                        شركة المنارة للصيانة والتجارة
                                    </div>
                                </div>
                            </div>
                            <%--**********************************************************************************************************--%>
                            <div class="row">
                                <div class="col-lg-12" style="border-style: solid; text-align: center; padding-top: 10px; font-size: 25px; font-weight: bold">
                                    <div class="form-group">
                                        <span style="color: red">طلب صيانة</span>
                                    </div>
                                </div>
                            </div>
                            <%--**********************************************************************************************************--%>
                            <div class="row" style="border: solid">
                                <div class="col-lg-3" style="font-size: 20px; padding-top: 10px;">
                                    <div class="form-group">
                                        <span style="font-weight: bold">الضمان :</span> &nbsp;&nbsp;<asp:Label ID="lbl_Waranty" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3" style="font-size: 20px; padding-top: 10px;">
                                    <div class="form-group">
                                        <span style="font-weight: bold">جهة الضمان :</span>&nbsp;&nbsp;<asp:Label ID="lbl_Waranty_Direction" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3" style="font-size: 20px; padding-top: 10px;">
                                    <div class="form-group">
                                        <span style="font-weight: bold">تحميل التكلفة على :</span>&nbsp;&nbsp;<asp:Label ID="lbl_Cost_Direction" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3" style="font-size: 20px; padding-top: 10px;">
                                    <div class="form-group">
                                        <span style="font-weight: bold">توجيه إلى :</span>&nbsp;&nbsp;<asp:Label ID="lbl_Executing_Agency" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <%--**********************************************************************************************************--%>
                            <div class="row" style="border: solid">
                                <div class="col-lg-3" style="font-size: 20px; padding-top: 10px;">
                                    <div class="form-group">
                                        <span style="font-weight: bold">الفني المسؤول :</span> &nbsp;&nbsp;<asp:Label ID="lbl_Technical" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3" style="font-size: 20px; padding-top: 10px;">
                                    <div class="form-group">
                                        <span style="font-weight: bold">المراقب :</span>&nbsp;&nbsp;<asp:Label ID="lbl_Watcher" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-6" style="font-size: 20px; padding-top: 10px;">
                                    <div class="form-group">
                                        <span style="font-weight: bold">الأجهزة المصانة :</span>&nbsp;&nbsp;<asp:Label ID="lbl_Asset" runat="server"></asp:Label>
                                    </div>
                                </div>

                            </div>
                            <%--**********************************************************************************************************--%>
                            <asp:Button ID="btn_Close_Maintenance_Details" CssClass="btn btn-danger" runat="server" Text="إغلاق" OnClick="btn_Close_Maintenance_Details_Click" Height="43px" Width="263px" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <asp:Button ID="btn_Back_To_complaint_report_request_List" runat="server" Text="العودة لقائمة الطلبات" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_complaint_report_request_List_Click" />
            </div>
        </div>
    </div>
</asp:Content>
