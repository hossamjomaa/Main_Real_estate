<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="M_Ownership_List.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.M_Ownership_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {

            /*This will hide the icons if there is no URL*/
            /*If there is no files, URL will say "No File"*/
            $('a[href*="No File"]').each(function () {
                $(this).css('display', 'none');
            });


            var table = $('.datatable').DataTable({
                dom: 'Bfrtip',
                "pageLength": 10000,
                buttons: [
                    /* 'copyHtml5',*/
                    'excelHtml5',
                    /*'csvHtml5',*/
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
            font-size: 12px;
            text-align: center !important;
            
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
           padding: 2px;
           text-align: center

        }
        .vetiacl{
            vertical-align: middle;
        }
    </style>




    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="../CSS/DDL.css" rel="stylesheet" />

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container-fluid">
        <ul style="background-color: #efefef; min-height: 0px; width: 100%" class="navbar-nav sidebar sidebar-light accordion" id="accordionSidebar">
            <li class="nav-item" style="padding-bottom: 10px;" runat="server" id="Ownership_Div">
                <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#M_Ownership" aria-expanded="true"
                    aria-controls="M_Ownership" style="width: 270px;">
                    <i class="fa fa-plus" style="font-size: 25px; font-weight: bold"></i>
                    <span style="font-size: 18px;">إضافة الملكيات المرهونة</span>
                </a>
                <div id="M_Ownership" class="collapse" aria-labelledby="headingForm" data-parent="#accordionSidebar">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card mb-12">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_ownership_Name" runat="server" Text="اسم الملكية"></asp:Label>
                                                <asp:DropDownList ID="ownership_Name_DropDownList" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ownership_Name_Req_Field_Val" ControlToValidate="ownership_Name_DropDownList" ValidationGroup="Mortgage_GV"
                                                    InitialValue="أختر إسم الملكية...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Bank_Name" runat="server" Text="جهة الرهن"></asp:Label>
                                                <asp:DropDownList ID="Bank_Name_DropDownList" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Bank_Name_Req_Field_Val" ControlToValidate="Bank_Name_DropDownList" ValidationGroup="Mortgage_GV"
                                                    InitialValue="أختر جهة الرهن...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Mortgage_Value" runat="server" Text="قيمة الرهن"></asp:Label>
                                                &nbsp;<asp:RegularExpressionValidator ID="Mortgage_Value_Reg_Exp_Vali" runat="server" ControlToValidate="txt_Mortgage_Value"
                                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="#fc544b"
                                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                <asp:TextBox ID="txt_Mortgage_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Mortgage_Value_Req_Field_Val" ValidationGroup="Mortgage_GV" ControlToValidate="txt_Mortgage_Value"
                                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <%--------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                                    <div class="row">


                                          <div class="col-lg-3">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Paymen_Type" runat="server" Text="دورة السداد"></asp:Label>
                                                <asp:DropDownList ID="Paymen_Type_DropDownList" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="1" Text="شهري"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="ربع سنوي"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ownership_Name_DropDownList" ValidationGroup="Mortgage_GV"
                                                    InitialValue="أختر دورة السداد...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>



                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Installment_Value" runat="server" Text="قيمة القسط"></asp:Label>
                                                &nbsp;<asp:RegularExpressionValidator ID="Installment_Value_Reg_Exp_Vali" runat="server" ControlToValidate="txt_Installment_Value"
                                                    EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="#fc544b"
                                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                <asp:TextBox ID="txt_Installment_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Installment_Value_Req_Field_Val" ValidationGroup="Mortgage_GV" ControlToValidate="txt_Installment_Value"
                                                    runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:UpdatePanel ID="Start_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lbl_Start_Date" runat="server" Text="تاريخ البدء"></asp:Label>&nbsp;
                                        <asp:TextBox ID="txt_Start_Date" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                    <asp:Button ID="Start_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="Start_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="ImageButton2" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton2_Click" runat="server" />
                                                    <asp:RequiredFieldValidator ID="Start_Date_Req_Field_Val" ValidationGroup="Mortgage_GV" ControlToValidate="txt_Start_Date"
                                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                                    <div id="Start_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="Start_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="#f0f0f3" BorderColor="#ccc" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="10pt" ForeColor="#5a5c69" OnSelectionChanged="Start_Date_Calendar_SelectionChanged2">
                                                            <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                            <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                            <OtherMonthDayStyle ForeColor="#5a5c69" />
                                                            <SelectedDayStyle BackColor="#ff8d4f" Font-Bold="True" ForeColor="#ffffff" />
                                                            <SelectorStyle BackColor="#5a5c69" ForeColor="#ffffff" />
                                                            <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                            <TodayDayStyle BackColor="#37bc9b" ForeColor="#ffffff" />
                                                            <WeekendDayStyle BackColor="#dfeef8" />
                                                        </asp:Calendar>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="Start_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="Start_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:UpdatePanel ID="End_Date_UpdatePanel" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lbl_End_Date" runat="server" Text="تاريخ التحرير"></asp:Label>&nbsp;
                                        <asp:TextBox ID="txt_End_Date" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                    <asp:Button ID="End_Date_Chosee" runat="server" Text="إختر التاريخ" OnClick="End_Date_Chosee_Click" />
                                                    <asp:ImageButton ID="ImageButton3" ImageUrl="Main_Image/Calander_Close.png" Width="10px" Height="10px" Visible="false" OnClick="ImageButton3_Click" runat="server" />
                                                    <asp:RequiredFieldValidator ID="End_Date_Req_Field_Val" ValidationGroup="Mortgage_GV" ControlToValidate="txt_End_Date"
                                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b"></asp:RequiredFieldValidator>
                                                    <div id="End_Date_Div" runat="server" visible="false" style="position: page;">
                                                        <asp:Calendar ID="End_Date_Calendar" runat="server" Height="200px" Width="220px" BackColor="#f0f0f3" BorderColor="#ccc" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="10pt" ForeColor="#5a5c69" OnSelectionChanged="End_Date_Calendar_SelectionChanged1">
                                                            <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                            <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                            <OtherMonthDayStyle ForeColor="#5a5c69" />
                                                            <SelectedDayStyle BackColor="#ff8d4f" Font-Bold="True" ForeColor="#ffffff" />
                                                            <SelectorStyle BackColor="#5a5c69" ForeColor="#ffffff" />
                                                            <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                            <TodayDayStyle BackColor="#37bc9b" ForeColor="#ffffff" />
                                                            <WeekendDayStyle BackColor="#dfeef8" />
                                                        </asp:Calendar>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="End_Date_Calendar" EventName="SelectionChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="End_Date_Chosee" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="ImageButton3" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <%--------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <br />
                                                <%--<asp:Button ID="btn_Add_M_OwnerShip" runat="server" Text="إضافة" CssClass="btn btn" BackColor="#52a2da" ValidationGroup="Mortgage_GV" ForeColor="White" Width="248px" OnClick="btn_Add_M_OwnerShip_Click" />--%>
                                                <asp:LinkButton ID="Add" runat="server" CssClass="btn btn" BackColor="#52a2da" ValidationGroup="Mortgage_GV" ForeColor="White" Width="248px" OnClick="btn_Add_M_OwnerShip_Click">إضافة</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </li>
        </ul>
    </div>
    <br />
        <hr />
    <div class="container-fluid" id="container-wrapper" >
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-12">
                    <div class="card-body">
        
        <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="Label1" runat="server" Text=" الملكيات المرهونة "></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="table-responsive datatable table table-bordered"  id="M_OwnerShip">
                                        <asp:GridView AutoGenerateColumns="false" ID="M_OwnerSip_GV" runat="server" 
                                            OnRowEditing="M_OwnerSip_GV_RowEditing"
                                            OnRowUpdating="M_OwnerSip_GV_RowUpdating"
                                            OnRowCancelingEdit="M_OwnerSip_GV_RowCancelingEdit"
                                            OnRowDeleting="M_OwnerSip_GV_RowDeleting"
                                            OnRowDataBound="M_OwnerSip_GV_RowDataBound">

                                            <Columns>
                                                <asp:TemplateField HeaderText="م" ItemStyle-CssClass="vetiacl" ItemStyle-Width="10%"  HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                                <%--------------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField HeaderText="معرف الملكية المرهونة" Visible="false" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Mortgaged_Wonership_Id" runat="server" Text='<%# Eval("Mortgaged_Wonership_Id") %>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <%--------------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField HeaderText="تاريخ البدء" ItemStyle-Width="40%" HeaderStyle-ForeColor="White">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lbl_Start_Date" runat="server" Text='<%# Eval("Start_Date") %>'>  </asp:Label>
                                                        <asp:Calendar ID="Start_Date_Calendar" runat="server">
                                                           

                                                            <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                            <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                            <OtherMonthDayStyle ForeColor="#5a5c69" />
                                                            <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                            <WeekendDayStyle BackColor="#dfeef8" />

                                                        </asp:Calendar>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Start_Date" runat="server" Text='<%# Eval("Start_Date") %>'>  </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--------------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField HeaderText="تاريخ التحرير" ItemStyle-Width="40%" HeaderStyle-ForeColor="White">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>'>  </asp:Label>
                                                        <asp:Calendar ID="End_Date_Calendar" runat="server">
                                                            <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                            <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                            <OtherMonthDayStyle ForeColor="#5a5c69" />
                                                            <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                            <WeekendDayStyle BackColor="#dfeef8" />
                                                        </asp:Calendar>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>'>  </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--------------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField HeaderText="اسم الملكية المرهونة" ItemStyle-Width="100%" HeaderStyle-ForeColor="White">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="OwnerShip_DropDownList" runat="server"></asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--------------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField HeaderText="جهة الرهن"  ItemStyle-Width="100%" HeaderStyle-ForeColor="White">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="bank_DropDownList" runat="server"></asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Bank_Arabic_Name" runat="server" Text='<%# Eval("Bank_Arabic_Name") %>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--------------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField HeaderText="قيمة الرهن"  HeaderStyle-ForeColor="White">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txt_Mortgage_Value" runat="server" Text='<%# Bind("Mortgage_Value") %>' Width="300px">  
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Mortgage_Value" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Mortgage_Value")))%>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <%--------------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField HeaderText="دورة السداد" HeaderStyle-ForeColor="White">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="PaymenType_DropDownList" runat="server">
                                                            <asp:ListItem Value="1" Text="شهري"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="ربع سنوي"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_PaymenType" runat="server" Text='<%# Eval("Paymen_Type") %>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--------------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField HeaderText="قيمة القسط" HeaderStyle-ForeColor="White">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txt_Installment_Value" runat="server" Text='<%# Bind("Installment_Value") %>' Width="300px">  
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Installment_Value" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Installment_Value")))%>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                <%--------------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField HeaderText="المبلغ المسدد" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Amount_Paid" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Amount_Paid")))%>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--------------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField HeaderText="المبلغ المتبقي" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Remaining_Amount" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Remaining_Amount")))%>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--------------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField HeaderText="عدد الأقساط المتبقية" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Remaining_Time" runat="server" Text='<%# Eval("Remaining_Installments")%>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--------------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton  ID="Delete" runat="server" CommandArgument='<%# Eval("Mortgaged_Wonership_Id") %>' OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');" OnClick="Delete"><i class="fa fa-trash" style="font-size:30px"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--------------------------------------------------------------------------------------------------%>

                                                <%--<asp:CommandField ShowEditButton="false" ButtonType="Image" DeleteImageUrl="~/English/Main_Application/Main_Image/Delete.png" CancelText="إلغاء" UpdateText="تحديث" ShowDeleteButton="true"  ControlStyle-Width="30px"/>--%>
                                            </Columns>
                                            <EditRowStyle HorizontalAlign="Center" />
                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                            <HeaderStyle BackColor="#52a2da" Font-Bold="false" ForeColor="#fff" Font-Size="13px" HorizontalAlign="Center" VerticalAlign="Middle"/>
                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                            <RowStyle HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="false" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#242121" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>

        <br />
        <br />
    </div>


    <%--<script>$('#<%= ownership_Name_DropDownList.ClientID %>').chosen();</script>
    <script>$('#<%= Bank_Name_DropDownList.ClientID %>').chosen();</script>--%>






    <script type="text/javascript">
        $(document).ready(function () {

            $('html, body').animate({
                scrollTop: $('#M_OwnerShip').offset().top
            }, 'slow');//w  w w.j a v a 2s.com 

        });
    </script>
</asp:Content>
