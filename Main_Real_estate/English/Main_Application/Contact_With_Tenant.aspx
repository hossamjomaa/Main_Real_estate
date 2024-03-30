<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Contact_With_Tenant.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Contact_With_Tenant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            $('a[href*="No File"]').each(function () {
                $(this).css('display', 'none');
            });


            var table = $('.datatable').DataTable({
                dom: 'Bfrtip',
                // lengthChange: false,
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
            font-size: 13px !important;
            padding: 7px !important; 
            
        }
        th{
            background-color:#52a2da;
            color: #fff;
            text-align:center;
        }

       .hiddencol { display: none; }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container-fluid">
        <div class="row">
            <div class="col-lg">
                <ul style="background-color: #efefef; min-height: 0px; width: 100%" class="navbar-nav sidebar sidebar-light accordion" id="accordionSidebar">
                    <li class="nav-item" style="padding-bottom: 10px;" runat="server" id="Ownership_Div">
                        <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#M_Ownership" aria-expanded="true"
                            aria-controls="M_Ownership" style="width: 270px;">
                            <i class="fa fa-plus" style="font-size: 25px; font-weight: bold"></i>
                            <span style="font-size: 19px;">التواصل مع العملاء SMS </span>
                        </a>
                        <div id="M_Ownership" class="collapse" aria-labelledby="headingForm" data-parent="#accordionSidebar">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="card mb-12">
                                        <div class="card-body">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>

                                                     <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="form-group">
                                                                <asp:Label ID="lbl_Level" runat="server" Text="إختر  لمن تريد أن ترسل"></asp:Label>
                                                                <asp:DropDownList ID="Level_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="Level_DropDownList_SelectedIndexChanged">
                                                                    <asp:ListItem Value ="1" Text="مراسلة كافة العملاء"> </asp:ListItem>
                                                                    <asp:ListItem Value ="2" Text="مراسلة عملاء في بناء محدد"> </asp:ListItem>
                                                                    <asp:ListItem Value ="3" Text="مراسلة عميل محدد"> </asp:ListItem>
                                                                    <asp:ListItem Value ="4" Text="مجموعة عملاء"> </asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>




                                                    <div class="row" runat="server" id="Building_div" visible="false">
                                                        <div class="col-lg-12">
                                                            <div class="form-group">
                                                                <asp:Label ID="lbl_Building_Name" runat="server" Text="اسم البناء"></asp:Label>
                                                                <asp:DropDownList ID="Building_Name_DropDownList" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row" runat="server" id="Tenant_div" visible="false">
                                                        <div class="col-lg-12">
                                                            <div class="form-group">
                                                                <asp:Label ID="lbl_Tenant_Name" runat="server" Text="اسم العميل"></asp:Label>
                                                                <asp:DropDownList ID="Tenant_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Tenant_Name_DropDownList_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="Tenant_Name_Req_Field_Val" ControlToValidate="Tenant_Name_DropDownList" ValidationGroup="Contact_With_Tenant"
                                                                    InitialValue="أختر إسم العميل...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row" runat="server" id="Tenant_NO_div" visible="false">
                                                        <div class="col-lg-12">
                                                            <div class="form-group">
                                                                <asp:Label ID="lbl_tenant_NO" runat="server" Text="رقم الهاتف"></asp:Label>
                                                                <asp:TextBox ID="txt_tenant_NO" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>


                                                     <div class="row" runat="server" id="Div1">
                                                        <div class="col-lg-12">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label1" runat="server" Text="اسم العميل"></asp:Label>
                                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:GridView Width="100%" ID="Cheque_GridView" runat="server" OnRowDeleting="Cheque_GridView_RowDeleting" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="tenant_Name" HeaderText="اسم العميل" ItemStyle-Width="120" />
                                                            <asp:BoundField  DataField="ID" HeaderText="رقم الهاتف" ItemStyle-Width="120" />
                                                            <asp:CommandField ItemStyle-Width="10px" ShowDeleteButton="True" ButtonType="Image" 
                                                            DeleteImageUrl="~/English/Main_Application/Main_Image/Calander_Close.png" ControlStyle-Width="10px" ControlStyle-Height="10px"/>
                                                        </Columns>
                                                        <RowStyle HorizontalAlign="Center" />
                                                    </asp:GridView>


                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="form-group">
                                                                <asp:Label ID="lbl_tenant_Sms" runat="server" Text="نص الرسالة"></asp:Label>
                                                                <asp:TextBox ID="txt_tenant_Sms" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    

                                                   





                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <asp:Label ID="lbl_Send_Sussefilly" ForeColor="#33cc33" runat="server" ></asp:Label>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="Tenant_Name_DropDownList" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="Level_DropDownList" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="form-group">
                                                                <br />
                                                                <asp:Button ID="btn_Send_Sms" runat="server" Text="إرسال" CssClass="btn btn" BackColor="#52a2da" ValidationGroup="Contact_With_Tenant" ForeColor="White" Width="248px" OnClick="btn_Send_Sms_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                            







                                            
                                            <%--------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="col-lg">



                <ul style="background-color: #efefef; min-height: 0px; width: 100%" class="navbar-nav sidebar sidebar-light accordion" id="accordionSidebars">
                    <li class="nav-item" style="padding-bottom: 10px;" runat="server" id="Li1">
                        <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#Attatchment" aria-expanded="true"
                            aria-controls=" Attatchment" style="width: 270px;">
                            <i class="fa fa-plus" style="font-size: 25px; font-weight: bold"></i>
                            <span style="font-size: 19px;">المراسلات و المرفقات</span>
                        </a>
                        <div id="Attatchment" class="collapse" aria-labelledby="headingForm" data-parent="#accordionSidebar">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="card mb-12">
                                        <div class="card-body">

                                             <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                             <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="form-group">
                                                                <asp:Label ID="lbl_Att_Level" runat="server" Text="كافة العملاء / عملاء في بناء محدد / عميل محدد"></asp:Label>
                                                                <asp:DropDownList ID="Att_Level_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="Att_Level_DropDownList_SelectedIndexChanged">
                                                                    <asp:ListItem Value ="1" Text=" كافة العملاء"> </asp:ListItem>
                                                                    <asp:ListItem Value ="2" Text=" عملاء في بناء محدد"> </asp:ListItem>
                                                                    <asp:ListItem Value ="3" Text=" عميل محدد"> </asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                            <div class="row" runat="server" id="Att_Building_div" visible="false">
                                                        <div class="col-lg-12">
                                                            <div class="form-group">
                                                                <asp:Label ID="lbl_Att_Building_Name" runat="server" Text="اسم البناء"></asp:Label>
                                                                <asp:DropDownList ID="Att_Building_Name_DropDownList" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                            <div class="row" runat="server" id="Att_Tenant_div" visible="false">
                                                        <div class="col-lg-12">
                                                            <div class="form-group">
                                                                <asp:Label ID="lbl_Att_Tenant_Name" runat="server" Text="اسم العميل"></asp:Label>
                                                                <asp:DropDownList ID="Att_Tenant_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Tenant_Name_DropDownList_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="Att_Tenant_Name_Req_Field_Val" ControlToValidate="Tenant_Name_DropDownList" ValidationGroup="Contact_With_Tenant"
                                                                    InitialValue="أختر إسم العميل...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="Att_Level_DropDownList" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>

                                           <div class="row">
                                               <div class="col-lg-12">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Att" runat="server" Text="تحميل مرفق "></asp:Label>
                                                        <asp:FileUpload ID="Att_FileUpload" runat="server" CssClass="form-control" />
                                                    </div>
                                                </div>
                                           </div>

                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Att_Discription" runat="server" Text=" شرح"></asp:Label>
                                                        <asp:TextBox ID="txt_Att_Discription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                           </div>
                                            <div class="row">
                                                 <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:Button ID="btn_Att" runat="server" Text="إضافة" CssClass="btn btn" BackColor="#52a2da" ValidationGroup="Contact_With_Tenant" ForeColor="White" Width="248px" OnClick="btn_Att_Click" />
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
        </div>







    </div>




    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="row" style="margin-right:10px; margin-top:5px">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="lbl_Tenan" runat="server" Text="اسم المستأجر"></asp:Label>
                                <asp:DropDownList ID="Tenan_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Tenan_Name_DropDownList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="lbl_Type" runat="server" Text="نوع المراسلة"></asp:Label>
                                <asp:DropDownList ID="Type_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true"
                                    OnSelectedIndexChanged="Type_DropDownList_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="مرفق"> </asp:ListItem>
                                    <asp:ListItem Value="2" Text="رسالة SMS"> </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>


                    <div class="table-responsive" id="Grid">
                        <asp:Repeater ID="tenant_List" runat="server" ClientIDMode="Static">
                            <HeaderTemplate>
                                <table cellspacing="0" style="width: 100%" class="datatable table table-striped table-bordered">
                                    <thead>
                                        <th style="text-align: center;">م</th>
                                        <th style="text-align: center">اسم المستأجر</th>
                                        <th style="text-align: center">نوع المراسلة</th>
                                        <th style="text-align: center">الشهر</th>
                                        <th style="text-align: center">السنة</th>
                                        <th style="text-align: center">من قبل </th>
                                        <th style="text-align: center">رسائل SMS</th>
                                        <th style="text-align: center">المرفقات</th>
                                        <th style="text-align: center">ملاحظات</th>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td> <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                    <td> <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>' /></td>
                                    <td> <asp:Label ID="lbl_Type" runat="server" Text='<%# Eval("Type") %>' /></td>
                                    <td> <asp:Label ID="lbl_Mounth" runat="server" Text='<%# Eval("Mounth") %>' /></td>
                                    <td> <asp:Label ID="lbl_Year" runat="server" Text='<%# Eval("Year") %>' /></td>
                                    <td> <asp:Label ID="lbl_User_Name" runat="server" Text='<%# Eval("User_Name") %>' /></td>
                                    <td> <asp:Label ID="lbl_Tenants_Mobile" runat="server" Text='<%# Eval("SMS") %>' /></td>
                                    <td>
                                        <a href='<%# Eval("Attatchment_File_Path") %>' target="_blank" id="Link_Property_Scheme">
                                            <asp:Label ID="lbl_Link_Property_Scheme_Pdf" runat="server" Text='<%# Eval("Attatchment_File_Name") %>'></asp:Label>
                                        </a>
                                    </td>
                                    <td> <asp:Label ID="lbl_Tenants_Email" runat="server" Text='<%# Eval("Discription") %>' /></td>
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
