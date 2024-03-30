<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Income_New.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Income_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.29.1/moment.min.js"></script>
    <script src="https://https://cdn.datatables.net/plug-ins/1.10.11/sorting/date-eu.js"></script>
    

    <script type="text/javascript">
        $(document).ready(function () {
            function extractDate($element) {
                var dateText = $element.text().trim();
                if (dateText === '') {
                    return null; // Return null for empty dates
                } else {
                    return moment(dateText, 'DD/MM/YYYY', true); // Parse non-empty dates using Moment.js
                }
            }
            jQuery.extend(jQuery.fn.dataTableExt.oSort, {
                "date-custom-asc": function (a, b) {
                    var dateA = extractDate($(a));
                    var dateB = extractDate($(b));

                    if (dateA === null && dateB === null) {
                        return 0; // Both empty values are considered equal
                    } else if (dateA === null) {
                        return 1; // Empty value is greater than non-empty value
                    } else if (dateB === null) {
                        return -1; // Non-empty value is greater than empty value
                    } else {
                        // Compare non-empty dates
                        return dateA.isBefore(dateB) ? -1 : (dateA.isAfter(dateB) ? 1 : 0);
                    }
                },
                "date-custom-desc": function (a, b) {
                    var dateA = extractDate($(a));
                    var dateB = extractDate($(b));

                    if (dateA === null && dateB === null) {
                        return 0; // Both empty values are considered equal
                    } else if (dateA === null) {
                        return 1; // Empty value is considered greater than non-empty value
                    } else if (dateB === null) {
                        return -1; // Non-empty value is considered less than empty value
                    } else {
                        // Compare non-empty dates
                        return dateA.isBefore(dateB) ? 1 : (dateA.isAfter(dateB) ? -1 : 0);
                    }
                }
            });
            var table = $('.datatable').DataTable({
                dom: 'Bfrtip',
                /*lengthChange: false,*/
                "pageLength": 10000,
                buttons: [
                    'excelHtml5',
                ],
                language: {
                    url: 'https://cdn.datatables.net/plug-ins/1.12.1/i18n/ar.json'
                },
                columnDefs: [
                    {
                        target: "dataCol", orderable: true, type: 'date-custom'
                        }
                    
                ]
            });

            table.buttons().container()
                .appendTo('#DataTables_Table_0_wrapper .col-md-6:eq(0)');

            
        });

  
            function CollectChequeLinkClick(chequesId, url1, url2) {
                var array_id = chequesId.split('/');
                let target = "_blank";
                let url = url2;
                if (array_id[0] == "A")
                    url = url1;
                var redirectUrl = url + "?Id=" + array_id[1] + "&Cq_T_Ca=" + document.getElementById('<%= Cq_T_Ca.ClientID %>').value +
                    "&Collection=" + document.getElementById('<%= Collected_Or_NotCollected_DropDownList.ClientID %>').value +
                    "&Singel_Multi=" + document.getElementById('<%= Singel_Multi_DropDownList.ClientID %>').value;
                
                window.open(redirectUrl, '_blank');
                return false;
        }
    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
            .UUL {
                list-style-type: none;
                margin: auto;
                padding: 0;
                overflow: hidden;
                background-color: #52a2da;
                border-radius: .375rem .375rem 0 0;
            }

            .UUL li {
                float: right;
            }

            .UUL li a {
                display: block;
                color: white;
                text-align: center;
                padding-left: 50px;
                padding-right: 15px;
                padding-top: 16px;
                padding-bottom: 16px;
                text-decoration: none;
            }

            .UUL li a:hover{
                 background-color: #61aadd;
                color: #fff;
            }

          table, th, td {
              border: 1px solid #ddd;
            font-size: 12px;
            text-align: center !important;
            padding: 8px !important;
            
            
          }

       
        th{
            background-color:#52a2da;
            color: #fff;
            text-align:center;
        }
        .table-condensed tr th {
            border: 0px solid #fff;
            color: #fff;
            background-color: #52a2da;
        }

        .table-condensed, .table-condensed tr td {
            border: 0px solid #fff;
        }

        tr:nth-child(even) {
            background:  #f0f0f3;
        }

        tr:nth-child(odd) {
            background: #fff;
        }

        .calendarMonthStyle, .calendarMonthStyle tr:nth-child(odd), .calendarMonthStyle tr:nth-child(even){
            background-color: #37bc9b; 
            border: solid 1px #37bc9b;
            font-weight: bold;
            font-size: 14px;
            color: #ffffff;
           padding: 0px;
           text-align: center

        }
    </style>
    <%---------------------------------------------------------------------------------------------------------------------------------%>
    <div class="container-fluid" id="container-wrapper">
        <div class="row">
            <div class="col-lg-2 mb-3">
                <h1 class="h4 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Incomes_New_List" runat="server" Text="عمليات التحصيل"></asp:Label>
                </h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 mb-4">
                <div class="card">
                    <div class="row">
                        <div class="col-lg-12 mb-4">
                            <ul class="UUL">
                                <li><a runat="server" id="A_1" onserverclick="A_1_ServerClick">تحصيل الشيكات</a></li>
                                <li><a runat="server" id="A_2" onserverclick="A_2_ServerClick">تحصيل الحولات</a></li>
                                <li><a runat="server" id="A_3" onserverclick="A_3_ServerClick">تحصيل الدفعات النقدية</a></li>
                                <li><a runat="server" id="A_4" onserverclick="A_4_ServerClick">الكل</a></li>
                                <li>
                                    <asp:Label ID="Cq_T_Ca" runat="server"></asp:Label></li>
                            </ul>
                        </div>
                    </div>
                    <div class="row" style="padding: 20px">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="Label5" runat="server" Text="فرز حسب الكل / محصل / غير محصل"></asp:Label><br />
                                <asp:DropDownList ID="Collected_Or_NotCollected_DropDownList" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="Collected_Or_NotCollected_DropDownList_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="الكل"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="محصل"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="غير محصل"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="Label8" runat="server" Text="فرز حسب مفردة / مجملة "></asp:Label><br />
                                <asp:DropDownList ID="Singel_Multi_DropDownList" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="Singel_Multi_DropDownList_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="الكل"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="مفردة"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="مجملة"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3">
                             <div class="form-group">
                                 <asp:Label ID="lbl_Date_Filter" runat="server" Text="فرز حسب تاريخ اليوم / الكل"></asp:Label>
                                 <asp:DropDownList ID="Date_Filter_DropDownList" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="Date_Filter_DropDownList_SelectedIndexChanged">
                                     <asp:ListItem Value="1" Text="الكل"></asp:ListItem>
                                     <asp:ListItem Value="2" Text="تاريخ اليوم الحالي"></asp:ListItem>
                                     <asp:ListItem Value="3" Text="تاريخ الشهر الحالي"></asp:ListItem>
                                 </asp:DropDownList>
                             </div>
                         </div>
                    </div>
                    <div class="container-fluid">
                    <div class="row" runat="server" id="Cheuqe">
                        <h4><asp:Label ID="lbl_Cheques" runat="server"></asp:Label></h4>
                        <div class="table-responsive" id="Grid" >
                            <asp:Repeater ID="Avilabel_Cheuqes" runat="server" ClientIDMode="Static" OnItemDataBound="Avilabel_Cheuqes_ItemDataBound">
                                <HeaderTemplate>
                                    <table cellspacing="0" cellpadding="0" style="font-size: 12px;" class="datatable table table-striped table-bordered">
                                        <thead>
                                            <th style="display:none"></th>
                                            <th style="text-align: center;">كود الملكية</th>
                                            <th style="text-align: center;"> الملكية</th>
                                            <th style="text-align: center;">البناء أو الوحدة</th>
                                            <th style="text-align: center;"> المستأجر</th>
                                            <th style="text-align: center;">رقم الشيك</th>
                                            <th style="text-align: center;">تاريخ الشيك</th>
                                            <th style="text-align: center;">قيمة الشيك </th>
                                            <th style="text-align: center;">صاحب الشيك </th>
                                            <th style="text-align: center;">اسم المستفيد</th>
                                            <th style="text-align: center;">البنك </th>
                                            <th style="text-align: center;"> الحالة</th>
                                            <th class="dataCol" style="text-align: center;">تاريخ التحصيل</th>
                                            <th style="text-align: center;"></th>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr runat="server" id="row">
                                        <td style="display:none"> <asp:Label ID="lbl_Cheques_Id" runat="server" Text='<%# Eval("Cheques_Id") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Ownership_Code"  runat="server" Text='<%# Eval("O_Code") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Ownership_Name" runat="server" Text='<%# Eval("O_Name") %>'></asp:Label></td>
                                        <td> <asp:Label ID="lbl_U_NO" runat="server" Text='<%# Eval("U_NO") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Cheques_No" runat="server" Text='<%# Eval("Cheques_No") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Cheques_Date" runat="server" Text='<%# Eval("Cheques_Date") %>'>  </asp:Label></td>
                                        <td><asp:Label ID="lbl_Cheques_Amount" runat="server" Text='<%# Eval("Cheques_Amount") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Cheque_Owner" runat="server" Text='<%# Eval("Cheque_Owner") %>'></asp:Label></td>
                                        <td> <asp:Label ID="lbl_beneficiary_person" runat="server" Text='<%# Eval("beneficiary_person") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Bank_Arabic_Name" runat="server" Text='<%# Eval("Bank_Arabic_Name") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_cheque_Status" runat="server" Text='<%# Eval("Cheques_Status")%>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label></td>
                                        <td>
                                            <a href="#" id="Collect_cheque_link" style="color: #0779c9;" onclick="return CollectChequeLinkClick('<%# Eval("Cheques_Id") %>', 'Collect_Singl_Cheuqe.aspx', 'Collect_Multi_Cheuqe.aspx');">
                                                <i class="fa fa-sort-amount-desc" style="font-size: 18px;"></i>
                                            </a>
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
                    <%-------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                    <div class="row" runat="server" id="Transformation">
                        <h4><asp:Label ID="lbl_Transformation" runat="server"></asp:Label></h4>
                        <div class="table-responsive" >
                            <asp:Repeater ID="Repeater1" runat="server" ClientIDMode="Static" OnItemDataBound="Avilabel_Cheuqes_ItemDataBound">
                                <HeaderTemplate>
                                    <table cellspacing="0" cellpadding="0" style="font-size: 12px;" class="datatable table table-striped table-bordered">
                                        <thead>
                                            <th style="display:none"></th>
                                            <th style="text-align: center;">كود الملكية</th>
                                            <th style="text-align: center;"> الملكية</th>
                                            <th style="text-align: center;">البناء أو الوحدة</th>
                                            <th style="text-align: center;"> المستأجر</th>
                                            <th style="text-align: center;">رقم الحوالة</th>
                                            <th style="text-align: center;">تاريخ الحوالة</th>
                                            <th style="text-align: center;">قيمة الحوالة </th>
                                            <th style="text-align: center;">اسم المستفيد </th>
                                            <th style="text-align: center;">البنك </th>
                                            <th style="text-align: center;">رقم الحساب </th>
                                            <th style="text-align: center;">سوفت كود</th>
                                            <th style="text-align: center;"> الحالة</th>
                                            <th class="dataCol" style="text-align: center;">تاريخ التحصيل</th>
                                            <th style="text-align: center;"></th>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr runat="server" id="row">
                                        <td style="display:none"> <asp:Label ID="lbl_Cheques_Id" runat="server" Text='<%# Eval("transformation_Id") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Ownership_Code"  runat="server" Text='<%# Eval("O_Code") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Ownership_Name" runat="server" Text='<%# Eval("O_Name") %>'></asp:Label></td>
                                        <td> <asp:Label ID="lbl_U_NO" runat="server" Text='<%# Eval("U_NO") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_transformation_No" runat="server" Text='<%# Eval("transformation_No") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_transformation_Date" runat="server" Text='<%# Eval("transformation_Date") %>'>  </asp:Label></td>
                                        <td><asp:Label ID="lbl_Amount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label></td>
                                        <td> <asp:Label ID="lbl_beneficiary_person" runat="server" Text='<%# Eval("Beneficiary_Name") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Bank_Arabic_Name" runat="server" Text='<%# Eval("Bank_Name") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Account_No_En" runat="server" Text='<%# Eval("Account_No_En")%>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Soaft_Code_No_En" runat="server" Text='<%# Eval("Soaft_Code_No_En") %>'>  </asp:Label></td>
                                        <td><asp:Label ID="lbl_cheque_Status" runat="server" Text='<%# Eval("Status") %>'>  </asp:Label></td>
                                        <td><asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label></td>
                                        <td>
                                            <a href="#" id="Collect_transformation_link" style="color: #0779c9;" onclick="return CollectChequeLinkClick('<%# Eval("transformation_Id") %>', 'Collect_Singl_Transformation.aspx', 'Collect_Multi_Transformation.aspx');">
                                                <i class="fa fa-sort-amount-desc" style="font-size: 18px;"></i>
                                              </a>

                                            <!--<asp:LinkButton ID="Collect_transformation" ForeColor="#0779c9" runat="server" CommandArgument='<%# Eval("transformation_Id") %>' 
                                        OnClick="Collect_transformation_Click"><i class="fa fa-sort-amount-desc" style="font-size:18px;"></i> </asp:LinkButton>-->

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
                     <%-------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                    <div class="row" runat="server" id="Cash">
                        <h4><asp:Label ID="lbl_Cash" runat="server"></asp:Label></h4>
                        <div class="table-responsive" >
                            <asp:Repeater ID="Repeater2" runat="server" ClientIDMode="Static" OnItemDataBound="Avilabel_Cheuqes_ItemDataBound">
                                <HeaderTemplate>
                                    <table cellspacing="0" cellpadding="0" style="font-size: 12px;" class="datatable table table-striped table-bordered">
                                        <thead>
                                            <th style="display:none"></th>
                                            <th style="text-align: center;">كود الملكية</th>
                                            <th style="text-align: center;"> الملكية</th>
                                            <th style="text-align: center;">البناء أو الوحدة</th>
                                            <th style="text-align: center;"> المستأجر</th>
                                            <th style="text-align: center;">تاريخ الدفعة</th>
                                            <th style="text-align: center;">قيمة الشيك </th>
                                            <th style="text-align: center;"> الحالة</th>
                                            <th class="dataCol" style="text-align: center;">تاريخ التحصيل</th>
                                            <th style="text-align: center;"></th>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr runat="server" id="row">
                                        <td style="display:none"> <asp:Label ID="lbl_Cheques_Id" runat="server" Text='<%# Eval("Cash_Amount_ID") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Ownership_Code"  runat="server" Text='<%# Eval("O_Code") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Ownership_Name" runat="server" Text='<%# Eval("O_Name") %>'></asp:Label></td>
                                        <td> <asp:Label ID="lbl_U_NO" runat="server" Text='<%# Eval("U_NO") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Cash_Date" runat="server" Text='<%# Eval("Cash_Date") %>'>  </asp:Label></td>
                                        <td><asp:Label ID="lbl_Cash_Amount" runat="server" Text='<%# Eval("Cash_Amount") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_cheque_Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label></td>
                                        <td>
                                            <a href="#" id="Collect_cash_link" style="color: #0779c9;" onclick="return CollectChequeLinkClick('<%# Eval("Cash_Amount_ID") %>', 'Collect_Singl_Cash.aspx', 'Collect_Multi_Cash.aspx');">
                                                <i class="fa fa-sort-amount-desc" style="font-size: 18px;"></i>
                                             </a>
                                            <!--<asp:LinkButton ID="Collect_Cash" ForeColor="#0779c9" runat="server" CommandArgument='<%# Eval("Cash_Amount_ID") %>' 
                                        OnClick="Collect_Cash_Click"><i class="fa fa-sort-amount-desc" style="font-size:18px;"></i> </asp:LinkButton>-->


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
        </div>
    </div>
</asp:Content>

