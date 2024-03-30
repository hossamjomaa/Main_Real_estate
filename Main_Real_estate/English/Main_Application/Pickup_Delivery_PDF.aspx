<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Pickup_Delivery_PDF.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Pickup_Delivery_PDF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('.datatable').DataTable({
                dom: 'Bfrtip',
                // lengthChange: false,
                "pageLength": 10000,
                buttons: [
                    
                    'excelHtml5',
                    
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

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" /> 
    



    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            text-align: center;
            font-size: 13px;
        }
        th{
            background-color:#52a2da;
            color: #fff;
        }
    </style>

    <style>
        .Borderr {
            border-style: solid
        }

       




        body {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
            background-color: #FAFAFA;
            font: 750px;
        }

        * {
            box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .page {
            width: 210mm;
            min-height: 100%;
            padding: 2mm;
            margin: 10mm auto;
            border: 1px #D3D3D3 solid;
            border-radius: 5px;
            background: white;
            box-shadow: 0 0 5px rgba(0, 0, 0, 0.1);
        }

        .subpage {
            padding: 1cm;
            height: 100%;
        }

        @page {
            size: A4;
            margin: 0;
        }

        @media print {

            html,
            body {
                width: 210mm;
                height: 100%;
            }

            .page {
                margin: 0;
                border: initial;
                border-radius: initial;
                width: 100%;
                min-height: initial;
                box-shadow: initial;
                background-color: white;
                page-break-after: always;
                word-wrap: break-word;
            }

            .Contarct_Back_btn {
                border-radius: 10px
            }

            footer {
                font-size: 9px;
                color: #f00;
                text-align: center;
            }
        }
    </style>


    <script>
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
        }
    </script>























    <div class="container-fluid" id="container-wrapper" style="margin: auto;">
        <div class="row">
            <div class="col-lg-12">
                <asp:Label ID="Label2" runat="server" Visible="false" Text="Label"></asp:Label>
                <asp:Label ID="Label3" runat="server" Visible="false" Text="Label"></asp:Label>
                <asp:Label ID="Label4" runat="server" Visible="false" Text="Label"></asp:Label>
                <asp:Label ID="Label5" runat="server" Visible="false" Text="Label"></asp:Label>


                <h3>كشوفات إستلام وتسليم الوحدات</h3><br />
                <div class="card mb-10">
                    
                    <div class="card-body">
                        <div class="row">


                            <div class="col-lg-2">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Tenan_Name" runat="server" Text="اسم المستأجر"></asp:Label>
                                    <asp:DropDownList ID="Tenan_Name_DropDownList" runat="server"  CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Tenan_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Tenan_Name_RequiredFieldValidator" ControlToValidate="Tenan_Name_DropDownList"
                                        InitialValue="الكل ..." runat="server" ValidationGroup="Contract_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>





                            <div class="col-lg-2">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ownership_Name" runat="server" Text="اسم الملكية"></asp:Label>
                                    <asp:DropDownList ID="Ownership_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="Ownership_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Ownership_Name_RequiredFieldValidator" ControlToValidate="Ownership_Name_DropDownList"
                                        InitialValue="إختر اسم الملكية ...." runat="server" ValidationGroup="Contract_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="اسم البناء"></asp:Label>
                                    <asp:DropDownList ID="Building_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="Building_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Building_Name_RequiredFieldValidator" ControlToValidate="Building_Name_DropDownList"
                                        InitialValue="إختر اسم البناء ...." runat="server" ValidationGroup="Contract_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Units" runat="server" Text="الوحدة"></asp:Label>
                                    <asp:DropDownList ID="Units_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="Units_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Units_DropDownList"
                                        InitialValue="إختر الوحدة ...." runat="server" ValidationGroup="PDF_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>



                            <div class="col-lg-2">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Prosees" runat="server" Text="العملية"></asp:Label>
                                    <asp:DropDownList ID="Prosees_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Prosees_DropDownList_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="تسليم"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="إستلام"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Prosees_DropDownList"
                                        InitialValue="إختر العملية ...." runat="server" ValidationGroup="PDF_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="col-lg-2">
                                <div class="form-group">
                                    <asp:Label ID="lbl_date" runat="server" Text="التاريخ"></asp:Label>
                                    <asp:DropDownList ID="date_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="date_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="date_DropDownList"
                                        InitialValue="إختر التاريخ ...." runat="server" ValidationGroup="PDF_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            
                        </div>

                        <%--------------------------------------------------------------------------------------------------------------------------------------------------------------%>

                        <div class="row">
                            <div class="table-responsive" id="Grid" >
                    <asp:Repeater ID="Pickup_Delivery_List" runat="server" ClientIDMode="Static">
                        <HeaderTemplate>
                            <table  cellspacing="0" style="width: 100%; font-size:13px" class="datatable table table-striped table-bordered">
                                <thead>
                                    <th style="text-align: center;">مسلسل</th>
                                    <th style="text-align: center;">المستأجر</th>
                                    <th style="text-align: center">الملكية</th>
                                    <th style="text-align: center">البناء</th>
                                    <th style="text-align: center">الوحدة</th>
                                    <th style="text-align: center">العملية</th>
                                    <th style="text-align: center">التاريخ</th>
                                    
                                    <th style="width:200px"></th>
                                </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td> <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Eval("Building_Arabic_Name") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Unit_Number" runat="server" Text='<%# Eval("Unit_Number") %>' />
                                    <asp:Label ID="lbl_Unit_ID" Visible="false" runat="server" Text='<%# Eval("Unit_ID") %>' />

                                </td>
                                <td>
                                    <asp:Label ID="lbl_Prossess" runat="server" Text='<%# Eval("Prossess") %>' />
                                    <asp:Label ID="Prosses" Visible="false" runat="server" Text='<%# Eval("Prosses") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Date" runat="server" Text='<%# Eval("Date") %>' /></td>
                                
                                <td>
                                    <asp:LinkButton  runat="server" CommandArgument='<%# Eval("Pickup_Delivery_Id") %>' OnClick="Unnamed_Click" > <i class="fa fa-list" style="font-size:18px; color:#0779c9"></i> </asp:LinkButton>
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

                        <%--------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                        <hr />

                        <div class="col-lg-3">
                                <asp:Button ID="Button1" runat="server" Text="جلب" Visible="false" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" Width="248px" ValidationGroup="PDF_RequiredField" OnClick="Button1_Click1" />
                                <button runat="server" id="printt" visible="false" style="font-size: 18px; width: 150px"  class="btn btn-lg btn-primary"
                                    onclick="printDiv('print')">
                                    <i class="fa fa-print" aria-hidden="true"></i>&nbsp;طباعة 
                                </button>
                            </div>


                        <div class="row">
                            <div class="container-fluid">
                                <div id="print" class="book">
                                    <div class="page">
                                            <asp:Repeater ID="Repeater1" runat="server" ClientIDMode="Static" OnItemDataBound="Repeater1_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table cellspacing="0" style="width: 100%; font-size: 15px" class=" table table-striped table-bordered">
                                                        <thead>
                                                            <tr>
                                                                <th style="text-align: center; font-size: 25px; color: #5a5c69; background-color: #fff !important" colspan="4">شركة المنارة للصيانة والتجارة</th>
                                                            </tr>
                                                            <tr>
                                                                <th style="text-align: center; font-size: 19px; color:#d770ad; background-color: #fff !important" colspan="4">إستلام و تسليم وحدة</th>
                                                            </tr>
                                                            <tr>
                                                                <th style="text-align: center; font-size: 19px; color: #5a5c69; background-color: #fff !important" colspan="4">
                                                                    العنوان :
                                                                    <asp:Label ID="lbl_Building" runat="server"  />/
                                                                    <asp:Label ID="lbl_Unit" runat="server"  />
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    التاريخ :
                                                                    <asp:Label ID="lbl_Date" runat="server"  />
                                                                    <br />
                                                                    العملية :
                                                                    <asp:Label ID="lbl_Prosess" runat="server"  />

                                                                </th>
                                                            </tr>

                                                            <tr>
                                                                <th style="width: 10px">#</th>
                                                                <th style="font-size: 15px; font-weight: bold; text-align: center; ">قائمة الجرد</th>
                                                                <th style="font-size: 15px; font-weight: bold; text-align: center;">الحالة</th>
                                                                <th style="font-size: 15px; font-weight: bold; text-align: center;">ملاحظات</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr id="row" runat="server">
                                                        <td>
                                                            <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                                        <td style="font-size: 15px; font-weight: bold; text-align: center;">
                                                            <asp:Label ID="lbl_Type" runat="server" Text='<%# Eval("Type") %>' /></td>
                                                        <td style="font-size: 15px; text-align: center;">
                                                            <asp:Label ID="lbl_good" runat="server" Text='<%# Eval("good") %>' />&nbsp; 
                                                            سليم
                                                             &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp; 
                                                            <asp:Label ID="lbl_bad" runat="server" Text='<%# Eval("bad") %>' />&nbsp; 
                                                            متضرر
                                                        </td>
                                                        <td style="font-size: 15px;text-align: center;">
                                                            <asp:Label ID="lbl_Note" runat="server" Text='<%# Eval("Note") %>' /></td>
                                                    </tr>

                                                     <tr id="row2" runat="server">
                                                        <td colspan="4" style="font-size: 15px;text-align: center;">
                                                            ملاحظات 
                                                            <br />
                                                            <asp:Label ID="lbl_Discription" runat="server" Text='<%# Eval("Discription") %>' />
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
        </div>
    </div>
    <script>$('#<%= Units_DropDownList.ClientID %>').chosen();</script>
<script>$('#<%= Ownership_Name_DropDownList.ClientID %>').chosen();</script>
<script>$('#<%= Building_Name_DropDownList.ClientID %>').chosen();</script>
<script>$('#<%= Prosees_DropDownList.ClientID %>').chosen();</script>
<script>$('#<%= Tenan_Name_DropDownList.ClientID %>').chosen();</script>
<script>$('#<%= date_DropDownList.ClientID %>').chosen();</script>
</asp:Content>
