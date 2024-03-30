<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Contract_List.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Contract_List" %>
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

        table{
             table-layout: fixed !important;
             width: 100% !important;
             
        }
       
        th{
            background-color:#52a2da;
            color: #fff;
            text-align:center;
        }
        .table-bordered td, .table-bordered th {
        border: 1px solid #fff !important
    }
        .Indicator_buttons{
         
            border-radius:50px;
            border-style: solid; 
            width: 20px; 
            margin-right: 20px; 
            margin-top: 20px; 
            height: 20px; 
        }
        
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
            padding-right:15px;
            padding-top : 16px;
            padding-bottom : 16px;
            text-decoration: none;

        }

        .UUL li a:hover{
            background-color: #61aadd;
            color: #fff;
        }
       
    </style>

     <!-- Container Fluid-->
    <div class="container-fluid" id="container-wrapper">
        <div class="row">
            <div class="col-lg-2 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Contracts_List" runat="server" Text=" العقود"></asp:Label>
                </h1>
            </div>
            <div class="col-lg-3 mb-3">
                <asp:LinkButton ID="Add" CssClass="btn btn-primary" runat="server" PostBackUrl="~/English/Main_Application/Add-Contract.aspx" >
                    <i class="fa fa-plus" style="font-size:25px;"></i> &nbsp; إبرام عقد جديد</asp:LinkButton>
            </div>
        </div>
       
       <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                 
                    <div id="Grid" >
                        
                            <!-- Simple Tables -->
                            <ul class="UUL">
                                <li><a runat="server" id="A_3" onserverclick="A_3_ServerClick">كافة العقود</a></li>
                                <li><a runat="server" id="A_1" onserverclick="A_1_ServerClick">العقود المفرد</a></li>
                                <li><a runat="server" id="A_2" onserverclick="A_2_ServerClick">العقود المجملة</a></li>
                            </ul>    

                   
                            <div class="row">&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_all_Contract" runat="server"   CssClass="Indicator_buttons"  OnClick="btn_all_Contract_Click"/>
                                &nbsp;
                                    <span style="margin-top: 20px; ">كافة العقود</span>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                <asp:Button ID="btn_New_Contract" runat="server"   CssClass="Indicator_buttons" BackColor="#c5f8eb" OnClick="btn_New_Contarct_Click"/>
                                &nbsp;
                                    <span style="margin-top: 20px">عقود جديدة</span>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_Under_Expaired_Contract" runat="server" CssClass="Indicator_buttons" BackColor="#faced2" OnClick="btn_Under_Expaired_Contract_Click"/>
                                &nbsp;
                                    <span style="margin-top: 20px">عقود قيد الإنتهاء</span>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_Expaired_Contract" runat="server"   CssClass="Indicator_buttons" BackColor="#cbd0d8" OnClick="btn_Expaired_Contract_Click"/>
                                &nbsp;
                                    <span style="margin-top: 20px">عقود منتهية</span>
                        
                        </div>
                            <br />
         
        
                         
                        <span runat="server" id="U_C_Span" style="margin:auto; font-size:30px">
                            &nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="كافة العقود" />
                        </span>


                        <asp:Repeater  ID="Repeater1" runat="server" OnItemDataBound="contract_List_ItemDataBound" ClientIDMode="Static">
                            <HeaderTemplate>
                                <table  cellspacing="0" class="datatable table table-bordered">
                                    <thead>
                                        <%--<th style="text-align: center;vertical-align: middle;">م</th>--%>
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
                                    <%--<td> <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>--%>
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
                                        &nbsp;&nbsp;
                                        <asp:LinkButton id="U_Finsh" ForeColor="#0779c9"   runat="server" CommandArgument='<%# Eval("ID") %>' 
                                        OnClientClick="return confirm('هل تريد إنهاء العقد فعلاً ؟');" OnClick="Finsh_Click" > <i class="fa fa-hourglass-end" style="font-size:18px;"></i> </asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
            <%--***************************************************************************************************************************************************************************************************************************--%>

                        <asp:Repeater  ID="contract_List" runat="server" Visible="false" OnItemDataBound="contract_List_ItemDataBound" ClientIDMode="Static">
                            <HeaderTemplate>
                                <table  cellspacing="0" class="datatable table table-bordered">
                                    <thead>
                                        <%--<th style="text-align: center;vertical-align: middle;">م</th>--%>
                                        <th style="text-align:center;vertical-align: middle;">رقم العقد</th>
                                        <th style="text-align:center;vertical-align: middle;"> المنطقة</th>
                                        <th style="vertical-align: middle;">رمز الملكية</th>
                                        <th style="vertical-align: middle;">الملكية</th>
                                        <th style="vertical-align: middle;">البناء</th>
                                        <th style="vertical-align: middle;">الوحدة</th>
                                        <th style="text-align:center;vertical-align: middle">اسم المستأجر</th>
                                        <th style="text-align:center;vertical-align: middle"> الجنسية</th>
                                        <th style="vertical-align: middle;">نوع العقد</th>
                                        <th style="vertical-align: middle;">عدد الأشهر</th>
                                        <th style="vertical-align: middle;">عدد السنوات</th>
                                        <th style="vertical-align: middle;">قيمة الإيجار</th>
                                        <th style="vertical-align: middle;">تاريخ البدء</th>
                                        <th style="vertical-align: middle;">تاريخ الأنتهاء</th>
                                        <th style="display:none" >X</th>
                                        <th style="text-align:center; width:73px"  runat="server" id="H_One"></th>
                                    </thead>
                                <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="row" runat="server" >
                                    <%--<td> <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>--%>
                                    <td><asp:LinkButton ID="Contract_NO" Text='<%# Eval("CON_NO") %>'  runat="server" CommandArgument='<%# Eval("Contract_Id") %>' OnClick="C_ID_ServerClick" ></asp:LinkButton></td>
                                    <td><asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("zone_arabic_name") %>' /></td>
                                    <td><asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("owner_ship_Code") %>' /></td>
                                    <td><asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                    <td><asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Eval("Building_Arabic_Name") %>' /></td>
                                    <td><asp:Label ID="lbl_Unit_Number" runat="server" Text='<%# Eval("Unit_Number") %>' /></td>
                                    <td><asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>' /></td>
                                    <td><asp:Label ID="lbl_Arabic_nationality" runat="server" Text='<%# Eval("Arabic_nationality") %>' /></td>
                                    <td><asp:Label ID="lbl_Contract_Type" runat="server" Text='<%# Eval("Contract_Arabic_Type") %>' /></td>
                                    <td><asp:Label ID="lbl_Number_Of_Mounth" runat="server" Text='<%# Eval("Number_Of_Mounth") %>' /></td>
                                    <td><asp:Label ID="lbl_Number_Of_Years" runat="server" Text='<%# Eval("Number_Of_Years") %>' /></td>
                                    <td><asp:Label ID="lbl_Payment_Amount" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Payment_Amount")))%>' /></td>
                                    <td><asp:Label ID="lbl_Start_Date" runat="server" Text='<%# Eval("Start_Date") %>' /></td>
                                    <td><asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>' /></td>
                                    <td style="display:none"><asp:Label ID="lbl_New_ReNewed_Expaired"  runat="server" Text='<%# Eval("New_ReNewed_Expaired") %>' /></td>
                                    <td runat="server" id="B_One">
                                        <asp:LinkButton ID="U_Edit" ForeColor="#0779c9" runat="server" CommandArgument='<%# Eval("Contract_Id") %>' OnClick="Edit_Contract" > <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
                                        &nbsp;&nbsp;
                                        <asp:LinkButton id="U_Renew" ForeColor="#0779c9" Visible="false"  runat="server" CommandArgument='<%# Eval("Contract_Id") %>' OnClick="Renew_Contract" > <i class="fa fa-refresh" style="font-size:18px;"></i> </asp:LinkButton>
                                         &nbsp;&nbsp;
                                        <asp:LinkButton id="U_Finsh" ForeColor="#0779c9"   runat="server" CommandArgument='<%# Eval("Contract_Id") %>' 
                                        OnClientClick="return confirm('هل تريد إنهاء العقد فعلاً ؟');" OnClick="U_Finsh_Click" > <i class="fa fa-hourglass-end" style="font-size:18px;"></i> </asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                       <%--***************************************************************************************************************************************************************************************************************************--%>
                       
                        <asp:Repeater  ID="Building_Contarct_List" runat="server" Visible="false" OnItemDataBound="Building_Contarct_List_ItemDataBound" ClientIDMode="Static">
                            <HeaderTemplate>
                                <table  cellspacing="0" class="datatable table table-bordered">
                                    <thead>
                                        <th style="vertical-align: middle;">رقم العقد</th>
                                        <th style="vertical-align: middle;">اسم المنطقة</th>
                                        <th style="vertical-align: middle;">رمز الملكية</th>
                                        <th style="vertical-align: middle;">الملكية</th>
                                        <th style="text-align:center;vertical-align: middle;">اسم البناء/المجمع</th>
                                        <th style="text-align:center;vertical-align: middle;">اسم المستأجر</th>
                                        <th style="text-align:center;vertical-align: middle;"> الجنسية</th>
                                        <th style="text-align:center;vertical-align: middle;">نوع العقد</th>
                                        <th style="text-align:center;vertical-align: middle;">عدد الأشهر</th>
                                        <th style="text-align:center;vertical-align: middle;">عدد السنوات</th>
                                        <th style="text-align:center;vertical-align: middle;">قيمة الإيجار</th>
                                        <th style="text-align:center;vertical-align: middle;">تاريخ البدء</th>
                                        <th style="text-align:center;vertical-align: middle;">تاريخ الأنتهاء</th>
                                        <th style="display:none" >X</th>
                                        <th style="text-align:center; width:73px ;" runat="server" id="H_Two"></th>
                                        <th style="text-align:center;" runat="server" id="H_Two_Two"></th>
                                    </thead>
                                <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="row" runat="server">
                                    <td><asp:LinkButton ID="B_Contract_NO" Text='<%# Eval("CON_NO") %>'  runat="server" CommandArgument='<%# Eval("Contract_Id") %>' OnClick="B_Contract_NO_Click" ></asp:LinkButton></td>
                                    <td><asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("zone_arabic_name") %>' /></td>
                                    <td><asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("owner_ship_Code") %>' /></td>
                                    <td><asp:Label ID="lbl_B_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                    <td><asp:Label ID="lbl_Unit_Number" runat="server" Text='<%# Eval("Building_Arabic_Name") %>' /></td>
                                    <td><asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>' /></td>
                                    <td><asp:Label ID="lbl_Arabic_nationality" runat="server" Text='<%# Eval("Arabic_nationality") %>' /></td>
                                    <td><asp:Label ID="lbl_Contract_Type" runat="server" Text='<%# Eval("Contract_Arabic_Type") %>' /></td>
                                    <td><asp:Label ID="lbl_Number_Of_Mounth" runat="server" Text='<%# Eval("Number_Of_Mounth") %>' /></td>
                                    <td><asp:Label ID="lbl_Number_Of_Years" runat="server" Text='<%# Eval("Number_Of_Years") %>' /></td>
                                    <td><asp:Label ID="lbl_B_Payment_Amount" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Payment_Amount")))%>' /></td>
                                    <td><asp:Label ID="lbl_Start_Date" runat="server" Text='<%# Eval("Start_Date") %>' /></td>
                                    <td><asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>' /></td>
                                    <td style="display:none"><asp:Label ID="lbl_New_ReNewed_Expaired"  runat="server" Text='<%# Eval("New_ReNewed_Expaired") %>' /></td>
                                    <td runat="server" id="B_Two">
                                        <asp:LinkButton ID="B_Edit" ForeColor="#0779c9"  runat="server" CommandArgument='<%# Eval("Contract_Id") %>' OnClick="Edit_B_Contract" > <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
                                        &nbsp;&nbsp;
                                        <asp:LinkButton id="B_Renew" ForeColor="#0779c9" Visible="false"   runat="server" CommandArgument='<%# Eval("Contract_Id") %>' OnClick="Renew_B_Contract" > <i class="fa fa-refresh" style="font-size:18px;"></i> </asp:LinkButton><br />
                                    </td>
                                    <td runat="server" id="B_Two_Two">
                                        <asp:LinkButton id="B_Finsh" ForeColor="#0779c9"   runat="server" CommandArgument='<%# Eval("Contract_Id") %>' 
                                        OnClientClick="return confirm('هل تريد إنهاء العقد فعلاً ؟');" OnClick="B_Finsh_Click" > <i class="fa fa-hourglass-end" style="font-size:18px;"></i> </asp:LinkButton>
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
