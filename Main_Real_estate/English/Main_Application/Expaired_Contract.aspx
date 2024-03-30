<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Expaired_Contract.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Expaired_Contract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('.datatable').DataTable({
                dom: 'Bfrtip',
                /*lengthChange: false,*/
                "pageLength": 10000,
                buttons: [
                    //'copyHtml5',
                    'excelHtml5',
                    //'csvHtml5',
                    /*'pdfHtml5'*/
                ],
                language: {
                    url: 'https://cdn.datatables.net/plug-ins/1.12.1/i18n/ar.json'
                }
            });


        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            text-align: center !important;
            font-size: 12px;
            padding: 5px !important;
        }
        table { table-layout: fixed !important;  width: 100% !important; }
        th { background-color: #52a2da;color: #fff;text-align: center; }
        .table-bordered td, .table-bordered th {border: 1px solid #fff !important }
    </style>
    <%-------------------------------------------------------------------------------------------------------------------------------%>
    <div class="container-fluid" id="container-wrapper">
        <div class="row">
            <div class="col-lg-4 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Contracts_List" runat="server" Text="العقد قيد الإنتهاء"></asp:Label>
                </h1>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div id="Grid">
                         <asp:Repeater  ID="Repeater1" runat="server" OnItemDataBound="contract_List_ItemDataBound" ClientIDMode="Static">
                            <HeaderTemplate>
                                <table  cellspacing="0" class="datatable table table-bordered">
                                    <thead>
                                        <th style="text-align: center;vertical-align: middle;">م</th>
                                        <th style="text-align:center;vertical-align: middle;">رقم العقد</th>
                                        <th style="text-align:center;vertical-align: middle;"> المنطقة</th>
                                        <th style="vertical-align: middle;">رمز الملكية</th>
                                        <th style="vertical-align: middle;">الملكية</th>
                                        <th style="vertical-align: middle;">العنصر المؤجر</th>
                                        <th style="text-align:center;vertical-align: middle">اسم المستأجر</th>
                                        <th style="text-align:center;vertical-align: middle"> الجنسية</th>
                                        <th style="vertical-align: middle;">نوع العقد</th>
                                        <th style="vertical-align: middle;">عدد السنوات</th>
                                        <th style="vertical-align: middle;">قيمة الإيجار</th>
                                        <th style="vertical-align: middle;">تاريخ البدء</th>
                                        <th style="vertical-align: middle;">تاريخ الأنتهاء</th>
                                        <th style="display:none" >X</th>
                                        <th style="text-align:center;" runat="server" id="H_One"></th>
                                    </thead>
                                <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="row" runat="server">
                                    <td> <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                    <td><asp:LinkButton ID="Contract_NO" Text='<%# Eval("CON_NO") %>'  runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="Contract_NO_Click" ></asp:LinkButton></td>
                                    <td><asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("zone_arabic_name") %>' /></td>
                                    <td><asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("owner_ship_Code") %>' /></td>
                                    <td><asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                    <td><asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Eval("Unit_Number") %>' /></td>
                                    <td><asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>' /></td>
                                    <td><asp:Label ID="lbl_Arabic_nationality" runat="server" Text='<%# Eval("Arabic_nationality") %>' /></td>
                                    <td><asp:Label ID="lbl_Contract_Type" runat="server" Text='<%# Eval("Contract_Arabic_Type") %>' /></td>
                                    <td><asp:Label ID="lbl_Number_Of_Years" runat="server" Text='<%# Eval("Number_Of_Years") %>' /></td>
                                    <td><asp:Label ID="lbl_Payment_Amount" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Payment_Amount")))%>' /></td>
                                    <td><asp:Label ID="lbl_Start_Date" runat="server" Text='<%# Eval("Start_Date") %>' /></td>
                                    <td><asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>' /></td>
                                    <td style="display:none"><asp:Label ID="lbl_New_ReNewed_Expaired"  runat="server" Text='<%# Eval("New_ReNewed_Expaired") %>' /></td>
                                    <td runat="server" id="B_One">
                                        <asp:LinkButton ID="U_Edit" ForeColor="#0779c9" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="U_Edit_Click" > <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
                                        &nbsp;&nbsp;
                                        <asp:LinkButton id="U_Renew" ForeColor="#0779c9" Visible="false"  runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="U_Renew_Click" > <i class="fa fa-refresh" style="font-size:18px;"></i> </asp:LinkButton>
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
</asp:Content>
