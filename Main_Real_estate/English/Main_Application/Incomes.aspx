<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Incomes.aspx.cs" EnableEventValidation="false" Inherits="Main_Real_estate.English.Main_Application.Incomes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

            .right-spaced{
               
             }


          table, th, td {
              border: 1px solid #ddd;
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
           padding: 0px;
           text-align: center

        }

        
    </style>


<div class="container-fluid" id="container-wrapper">

    <div class="row">
            <div class="col-lg-2 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Incomes_List" runat="server" Text="التحصيل المالي"></asp:Label>
                </h1>
            </div>
        </div>
   <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                 
                    <div  id="Grid" >
                            <ul class="UUL">
                                <li><a runat="server" id="A_1" onserverclick="A_1_ServerClick">تحصيل الشيكات</a></li>
                                <li><a runat="server" id="A_2" onserverclick="A_2_ServerClick">تحصيل الحولات</a></li>
                                <li><a runat="server" id="A_3" onserverclick="A_3_ServerClick">تحصيل الدفعات النقدية</a></li>
                                <li><a runat="server" id="A_4" onserverclick="A_4_ServerClick">الكل</a></li>
                                <li style="margin-right:50px">
                                    

                                </li>

                                 <li style="margin-right:50px">
                                    

                                </li>
                            </ul>

                         <br />   
                         <div class="row" style="padding: 20px">
                             <div class="col-lg-3">
                                  <div class="form-group"> 
                                      <asp:Label ID="Label5" runat="server" Text="فرز حسب الكل / محصل / غير محصل"></asp:Label><br />
                                    <asp:DropDownList ID="Filter_DropDownList" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="Filter_DropDownList_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="الكل"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="محصل"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="غير محصل"></asp:ListItem>
                                    </asp:DropDownList> 
                                  </div>
                            </div>
                             <div class="col-lg-3">
                                  <div class="form-group">
                                      <asp:Label ID="Label8" runat="server" Text="فرز حسب مفردة / مجملة "></asp:Label><br />
                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="الكل"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="مفردة"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="مجملة"></asp:ListItem>
                                    </asp:DropDownList> 
                                  </div>
                            </div>
                            
                        </div>


                            <asp:ScriptManager ID="Income_ScriptManager" runat="server"></asp:ScriptManager>
                            <div class="container-fluid" runat="server" id="Cheuqes_Div">
        
                                <div calss="row" style="margin: auto">

                                    <div runat="server" id="Cheuqes_Mfrade">
                                        <h4><asp:Label ID="lbl_Avilabel_Cheuqes" ForeColor="#52a2da" runat="server"></asp:Label></h4>
                                    <br />
                                    <h5><asp:Label ID="Label1" runat="server" ></asp:Label></h5>
                                    <br />
                                    <div class="row" style="display:none">
                                        <div class="col-lg-4">
                                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged" />
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Button ID="Search_Btn" Text="بحث" runat="server" CssClass="btn btn-secondary" OnClick="Search_Btn_Click1" Width="50px" Height="40px" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <asp:Button ID="Button1" runat="server" Text="Excel"  CssClass="btn btn-secondary right-spaced"  OnClick="Btn_Print_Click"/><br />
                                    </div>
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="table-responsive">
                                                    <asp:GridView CellPadding="5" ID="Avilabel_Cheuqes" DataKeyNames="Cheques_Id" runat="server" AutoGenerateColumns="false"
                                                        OnRowDataBound="Avilabel_Cheuqes_RowDataBound"
                                                        OnRowEditing="Avilabel_Cheuqes_RowEditing"
                                                        OnRowUpdating="Avilabel_Cheuqes_RowUpdating"
                                                        OnRowCancelingEdit="Avilabel_Cheuqes_RowCancelingEdit">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="مسلسل" ItemStyle-Width="10">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="إسم الملكية">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Ownership_Name" runat="server" Text='<%# Eval("O_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Ownership_ID" Visible="false" runat="server" Text='<%# Eval("O_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="إسم البناء">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Building_Name" runat="server" Text='<%# Eval("B_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Building_ID" Visible="false" runat="server" Text='<%# Eval("B_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="رقم الوحدة">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Unit_Name" runat="server" Text='<%# Eval("U_NO") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Unit_ID" runat="server" Visible="false" Text='<%# Eval("U_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------------------%>
                                                             <asp:TemplateField HeaderText="اسم المستأجر">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Tenants_Id" runat="server" Visible="false" Text='<%# Eval("Tenants_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="رقم الشيك">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cheques_No" runat="server" Text='<%# Eval("Cheques_No") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="تاريخ الشيك">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_Cheques_Date" runat="server" Text='<%# Eval("Cheques_Date") %>'>  </asp:Label>
                                                                    <asp:Calendar ID="Calendar2" runat="server">
                                                                         <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                                        <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                                        <OtherMonthDayStyle ForeColor="#5a5c69" />
                                                                        <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                                        <WeekendDayStyle BackColor="#dfeef8" />

                                                                    </asp:Calendar>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cheques_Date" runat="server" Text='<%# Eval("Cheques_Date") %>'>  </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="قيمة الشيك">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cheques_Amount" runat="server" Text='<%# Eval("Cheques_Amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="صاحب الشيك">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cheque_Owner" runat="server" Text='<%# Eval("Cheque_Owner") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="اسم المستفيد">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_beneficiary_person" runat="server" Text='<%# Eval("beneficiary_person") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-----------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="اسم البنك">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Bank_Arabic_Name" runat="server" Text='<%# Eval("Bank_Arabic_Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                   
                                                            <asp:TemplateField HeaderText="حالة الشيك">
                                                                <EditItemTemplate>
                                                                    <asp:Label Visible="false" ID="cheque_Status" runat="server" Text='<%# Eval("Cheques_Status")%>'></asp:Label>
                                                                    <asp:DropDownList ID="cheque_Status_DropDownList" runat="server">
                                                                        <asp:ListItem Value="1" Text="غير محصل"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="مؤجل"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="مرتجع"></asp:ListItem>
                                                                        <asp:ListItem Value="4" Text="محصل بالشيك"></asp:ListItem>
                                                                        <asp:ListItem Value="5" Text="محصل نقداً"></asp:ListItem>
                                                                        <asp:ListItem Value="6" Text="محصل بالتحويل"></asp:ListItem>

                                                                        <asp:ListItem Value="7" Text="مستبدل : بالتحويل"></asp:ListItem>
                                                                        <asp:ListItem Value="8" Text="مستبدل : نقداً"></asp:ListItem>
                                                                        <asp:ListItem Value="9" Text="مستبدل : بشيك أخر"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_cheque_Status" runat="server" Text='<%# Eval("Cheques_Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="تاريخ تحصيل الشيك">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                                                    <asp:Calendar ID="Collection_Date_Calendar" runat="server">
                                                                        
                                                                        <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                                        <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                                        <OtherMonthDayStyle ForeColor="#5a5c69" />
                                                                        <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                                        <WeekendDayStyle BackColor="#dfeef8" />

                                                                    </asp:Calendar>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="حالة الشيك" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="test_lbl_cheque_Status" runat="server" Text='<%# Eval("Cheques_Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="تعديل"  CancelText="إلغاء" UpdateText="تحديث" ControlStyle-Width="55px" ControlStyle-CssClass="btn btn-sm btn-secondary" />
                                                        </Columns>
                                                        <EditRowStyle HorizontalAlign="Center" />
                                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#cacff1" Font-Bold="false" ForeColor="Black" Font-Size="15px" HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                                        <RowStyle HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="false" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                                        <RowStyle HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    </div>
            
                                    <%-- ***********************************************************************************************************************************************
                                    ***********************************************************************************************************************************************--%>
                                    <br />

                                    <div runat="server" id="Cheuqes_Mujmale">
                                        <h5> <asp:Label ID="Label2" runat="server"></asp:Label></h5>

                                    <div class="row" style="display:none">
                                        <div class="col-lg-4">
                                            <asp:TextBox ID="Building_txtSearch" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="Building_txtSearch_TextChanged" />
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Button ID="Building_Search_Btn" Text="بحث" runat="server"  CssClass="btn btn-secondary" OnClick="Building_Search_Btn_Click" Width="50px" Height="40px" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <asp:Button ID="Button2" runat="server" Text="Excel"  CssClass="btn btn-secondary right-spaced"  OnClick="Search_Btn_Click1"/><br />
                                    </div>
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="Building_Avilabel_Cheuqes" CellPadding="5" DataKeyNames="Cheques_Id" runat="server" AutoGenerateColumns="false"
                                                        OnRowDataBound="Building_Avilabel_Cheuqes_RowDataBound"
                                                        OnRowEditing="Building_Avilabel_Cheuqes_RowEditing"
                                                        OnRowUpdating="Building_Avilabel_Cheuqes_RowUpdating"
                                                        OnRowCancelingEdit="Building_Avilabel_Cheuqes_RowCancelingEdit">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="مسلسل" ItemStyle-Width="10">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="إسم الملكية">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Ownership_Name" runat="server" Text='<%# Eval("O_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Ownership_ID" Visible="false" runat="server" Text='<%# Eval("O_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="إسم البناء">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Building_Name" runat="server" Text='<%# Eval("B_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Building_ID" Visible="false" runat="server" Text='<%# Eval("B_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------------------%>
                                                             <asp:TemplateField HeaderText="اسم المستأجر">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Tenants_Id" runat="server" Visible="false" Text='<%# Eval("Tenants_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="رقم الشيك">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cheques_No" runat="server" Text='<%# Eval("Cheques_No") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="تاريخ الشيك">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_Cheques_Date" runat="server" Text='<%# Eval("Cheques_Date") %>'>  </asp:Label>
                                                                    <asp:Calendar ID="Calendar2" runat="server">
                                                                        <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                                        <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                                        <OtherMonthDayStyle ForeColor="#5a5c69" />
                                                                        <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                                        <WeekendDayStyle BackColor="#dfeef8" />
                                                                    </asp:Calendar>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cheques_Date" runat="server" Text='<%# Eval("Cheques_Date") %>'>  </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="قيمة الشيك">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cheques_Amount" runat="server" Text='<%# Eval("Cheques_Amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="صاحب الشيك">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cheque_Owner" runat="server" Text='<%# Eval("Cheque_Owner") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="اسم المستفيد">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_beneficiary_person" runat="server" Text='<%# Eval("beneficiary_person") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-----------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="اسم البنك">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Bank_Arabic_Name" runat="server" Text='<%# Eval("Bank_Arabic_Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                   
                                                            <asp:TemplateField HeaderText="حالة الشيك">
                                                                <EditItemTemplate>
                                                                    <asp:Label Visible="false" ID="cheque_Status" runat="server" Text='<%# Eval("Cheques_Status")%>'></asp:Label>
                                                                    <asp:DropDownList ID="cheque_Status_DropDownList" runat="server">
                                                                        <asp:ListItem Value="1" Text="غير محصل"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="مؤجل"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="مرتجع"></asp:ListItem>
                                                                        <asp:ListItem Value="4" Text="محصل بالشيك"></asp:ListItem>
                                                                        <asp:ListItem Value="5" Text="محصل نقداً"></asp:ListItem>
                                                                        <asp:ListItem Value="6" Text="محصل بالتحويل"></asp:ListItem>

                                                                        <asp:ListItem Value="7" Text="مستبدل : بالتحويل"></asp:ListItem>
                                                                        <asp:ListItem Value="8" Text="مستبدل : نقداً"></asp:ListItem>
                                                                        <asp:ListItem Value="9" Text="مستبدل : بشيك أخر"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_cheque_Status" runat="server" Text='<%# Eval("Cheques_Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="تاريخ تحصيل الشيك">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_B_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                                                    <asp:Calendar ID="B_Collection_Date_Calendar" runat="server">
                                                                        <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                                        <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                                        <OtherMonthDayStyle ForeColor="#5a5c69" />
                                                                        <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                                        <WeekendDayStyle BackColor="#dfeef8" />
                                                                    </asp:Calendar>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_B_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="حالة الشيك" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="test_lbl_cheque_Status" runat="server" Text='<%# Eval("Cheques_Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="تعديل"  CancelText="إلغاء" UpdateText="تحديث" ControlStyle-Width="55px" ControlStyle-CssClass="btn btn-sm btn-secondary" />
                                                        </Columns>
                                                        <EditRowStyle HorizontalAlign="Center" />
                                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#cacff1" Font-Bold="false" ForeColor="Black" Font-Size="15px" HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                                        <RowStyle HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="false" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                                        <RowStyle HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    </div>
                                    <hr />
            
                                    <br />
                                    <br />
                                    <br />
                                </div>
                            </div>
                            <div style="border-style: solid"></div>
                            <br />
                            <%--*****************************************************  تحصيل الحوالات *****************************************************************--%>
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

                            <div class="container-fluid" runat="server" id="transformation_Div">
                                <div calss="row" style="margin: auto">


                                    <div runat="server" id="transformation_Mufrade">
                                        <h4><asp:Label ID="lbl_Avilabel_transformation" ForeColor="#52a2da" runat="server"></asp:Label></h4>
                                    <br />
                                    <h5> <asp:Label ID="Label3"  runat="server"></asp:Label></h5>
                                    <br />

                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="Avilabel_transformation" CellPadding="5" DataKeyNames="transformation_Table_ID" runat="server" AutoGenerateColumns="false"
                                                        OnRowDataBound="Avilabel_transformation_RowDataBound"
                                                        OnRowEditing="Avilabel_transformation_RowEditing"
                                                        OnRowUpdating="Avilabel_transformation_RowUpdating"
                                                        OnRowCancelingEdit="Avilabel_transformation_RowCancelingEdit">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="مسلسل" ItemStyle-Width="10">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="إسم الملكية">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Ownership_Name" runat="server" Text='<%# Eval("O_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Ownership_ID" Visible="false" runat="server" Text='<%# Eval("O_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="إسم البناء">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Building_Name" runat="server" Text='<%# Eval("B_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Building_ID" Visible="false" runat="server" Text='<%# Eval("B_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="رقم الوحدة">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Unit_Name" runat="server" Text='<%# Eval("U_NO") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Unit_ID" runat="server" Visible="false" Text='<%# Eval("U_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="اسم المستأجر">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="رقم الحوالة">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_transformation_No" runat="server" Text='<%# Eval("transformation_No") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="تاريخ الحوالة">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_transformation_Date" runat="server" Text='<%# Eval("transformation_Date") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="قيمة الحوالة">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Amount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                    
                                                            <asp:TemplateField HeaderText="اسم المستفيد">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_beneficiary_person" runat="server" Text='<%# Eval("Beneficiary_Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-----------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="اسم البنك">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Bank_Arabic_Name" runat="server" Text='<%# Eval("Bank_Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="رقم الحساب">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Account_No" runat="server" Text='<%# Eval("Account_No") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="سوفت كود">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Soaft_Code_No" runat="server" Text='<%# Eval("Soaft_Code_No") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="حالة الحوالة">
                                                                <EditItemTemplate>
                                                                    <asp:Label Visible="false" ID="Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Status_DropDownList" runat="server">
                                                                        <asp:ListItem Value="1" Text="غير محصل"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="محصل"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="تاريخ تحصيل الحوالة">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                                                    <asp:Calendar ID="Collection_Date_Calendar" runat="server">
                                                                        <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                                        <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                                        <OtherMonthDayStyle ForeColor="#5a5c69" />
                                                                        <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                                        <WeekendDayStyle BackColor="#dfeef8" />
                                                                    </asp:Calendar>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="حالة الشيك" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="test_lbl_Tr_Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="تعديل"  CancelText="إلغاء" UpdateText="تحديث" ControlStyle-Width="55px" ControlStyle-CssClass="btn btn-sm btn-secondary" />
                                                        </Columns>
                                                        <EditRowStyle HorizontalAlign="Center" />
                                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#cacff1" Font-Bold="false" ForeColor="Black" Font-Size="15px" HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                                        <RowStyle HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="false" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                                        <RowStyle HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    </div>



            
                                    <%-- ***********************************************************************************************************************************************
                                    ***********************************************************************************************************************************************--%>
                                    <hr />
                                    <div calss="row" style="margin: auto">


                                        <div runat="server" id="transformation_Mujmale">



                                            <h5> <asp:Label ID="Label4" runat="server" ></asp:Label></h5>
                                        <br />
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <div class="row">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GridView1" CellPadding="5" DataKeyNames="transformation_Table_ID" runat="server" AutoGenerateColumns="false"
                                                            OnRowDataBound="GridView1_RowDataBound"
                                                            OnRowEditing="GridView1_RowEditing"
                                                            OnRowUpdating="GridView1_RowUpdating"
                                                            OnRowCancelingEdit="GridView1_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="مسلسل" ItemStyle-Width="10">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="إسم الملكية">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Ownership_Name" runat="server" Text='<%# Eval("O_Name") %>'></asp:Label>
                                                                        <asp:Label ID="lbl_Ownership_ID" Visible="false" runat="server" Text='<%# Eval("O_ID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="إسم البناء">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Building_Name" runat="server" Text='<%# Eval("B_Name") %>'></asp:Label>
                                                                        <asp:Label ID="lbl_Building_ID" Visible="false" runat="server" Text='<%# Eval("B_ID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--------------------------------------------------------------------------------------------------------------%>
                                                                <asp:TemplateField HeaderText="اسم المستأجر">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--------------------------------------------------------------------------------------------------%>
                                                                <asp:TemplateField HeaderText="رقم الحوالة">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbltransformation_No" runat="server" Text='<%# Eval("transformation_No") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--------------------------------------------------------------------------------------------------%>
                                                                <asp:TemplateField HeaderText="تاريخ الحوالة">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_transformation_Date" runat="server" Text='<%# Eval("transformation_Date") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--------------------------------------------------------------------------------------------------%>
                                                                <asp:TemplateField HeaderText="قيمة الحوالة">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Amount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--------------------------------------------------------------------------------------------------%>
                                        
                                                                <asp:TemplateField HeaderText="اسم المستفيد">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_beneficiary_person" runat="server" Text='<%# Eval("Beneficiary_Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%-----------------------------------------------------------------------------------%>
                                                                <asp:TemplateField HeaderText="اسم البنك">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Bank_Arabic_Name" runat="server" Text='<%# Eval("Bank_Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--------------------------------------------------------------------------------------------------%>
                                                                <asp:TemplateField HeaderText="رقم الحساب">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Account_No" runat="server" Text='<%# Eval("Account_No") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--------------------------------------------------------------------------------------------------%>
                                                                <asp:TemplateField HeaderText="سوفت كود">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Soaft_Code_No" runat="server" Text='<%# Eval("Soaft_Code_No") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--------------------------------------------------------------------------------------------------%>
                                                                <asp:TemplateField HeaderText="حالة الحوالة">
                                                                    <EditItemTemplate>
                                                                        <asp:Label Visible="false" ID="Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                                        <asp:DropDownList ID="Status_DropDownList" runat="server">
                                                                            <asp:ListItem Value="1" Text="غير محصل"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="محصل"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--------------------------------------------------------------------------------------------------%>
                                                                <asp:TemplateField HeaderText="تاريخ تحصيل الحوالة">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                                                        <asp:Calendar ID="Collection_Date_Calendar" runat="server">
                                                                            <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                                        <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                                        <OtherMonthDayStyle ForeColor="#5a5c69" />
                                                                        <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                                        <WeekendDayStyle BackColor="#dfeef8" />
                                                                        </asp:Calendar>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--------------------------------------------------------------------------------------------------%>
                                                                <asp:TemplateField HeaderText="حالة الشيك" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="test_lbl_Tr_Status" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--------------------------------------------------------------------------------------------------%>
                                                                <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="تعديل"  CancelText="إلغاء" UpdateText="تحديث" ControlStyle-Width="55px" ControlStyle-CssClass="btn btn-sm btn-secondary" />
                                                            </Columns>
                                                            <EditRowStyle HorizontalAlign="Center" />
                                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                                            <HeaderStyle BackColor="#cacff1" Font-Bold="false" ForeColor="Black" Font-Size="15px" HorizontalAlign="Center" />
                                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                                            <RowStyle HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="false" ForeColor="White" />
                                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                            <SortedDescendingHeaderStyle BackColor="#242121" />
                                                            <RowStyle HorizontalAlign="Center" />
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
                            <div style="border-style: solid"></div>
                            <br />
                            <br />
                            <%--************************************************************************  تحصيل الدفعات *******************************************************************--%>
                            <div class="container-fluid" runat="server" id="cash_Div">
                                <div calss="row" style="margin: auto">

                                    <div runat="server" id="cash_Mufrade_Div">
                                        <h4> <asp:Label ID="lbl_Avilabel_cash" ForeColor="#52a2da" runat="server"></asp:Label></h4>
                                    <br />
                                    <h5>  <asp:Label ID="Label6" runat="server"></asp:Label></h5>
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="Avilabel_Cash" CellPadding="5" DataKeyNames="Cash_Amount_ID" runat="server" AutoGenerateColumns="false"
                                                        OnRowDataBound="Avilabel_Cash_RowDataBound"
                                                        OnRowEditing="Avilabel_Cash_RowEditing"
                                                        OnRowUpdating="Avilabel_Cash_RowUpdating"
                                                        OnRowCancelingEdit="Avilabel_Cash_RowCancelingEdit">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="مسلسل" ItemStyle-Width="10">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="إسم الملكية">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Ownership_Name" runat="server" Text='<%# Eval("O_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Ownership_ID" Visible="false" runat="server" Text='<%# Eval("O_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="إسم البناء">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Building_Name" runat="server" Text='<%# Eval("B_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Building_ID" Visible="false" runat="server" Text='<%# Eval("B_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="رقم الوحدة">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Unit_Name" runat="server" Text='<%# Eval("U_NO") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Unit_ID" runat="server" Visible="false" Text='<%# Eval("U_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <%--------------------------------------------------------------------------------------------------------------%>
                                                             <asp:TemplateField HeaderText="اسم المستأجر">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="قيمة الدفعة">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cash_Amount" runat="server" Text='<%# Eval("Cash_Amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="تاريخ الدفعة">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cash_Date" runat="server" Text='<%# Eval("Cash_Date") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                   
                                                            <asp:TemplateField HeaderText="حالة الدفعة">
                                                                <EditItemTemplate>
                                                                    <asp:Label Visible="false" ID="Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Status_DropDownList" runat="server">
                                                                        <asp:ListItem Value="1" Text="غير محصل"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="محصل"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="تاريخ تحصيل الدفعة">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                                                    <asp:Calendar ID="Collection_Date_Calendar" runat="server">
                                                                        <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                                        <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                                        <OtherMonthDayStyle ForeColor="#5a5c69" />
                                                                        <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                                        <WeekendDayStyle BackColor="#dfeef8" />
                                                                    </asp:Calendar>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="حالة الدفعة" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="test_lbl_Tr_Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="تعديل"  CancelText="إلغاء" UpdateText="تحديث" ControlStyle-Width="55px" ControlStyle-CssClass="btn btn-sm btn-secondary" />
                                                            
                                                        </Columns>
                                                        <EditRowStyle HorizontalAlign="Center" />
                                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#cacff1" Font-Bold="false" ForeColor="Black" Font-Size="15px" HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                                        <RowStyle HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="false" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                                        <RowStyle HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    </div>





            
                                    <%-- ***********************************************************************************************************************************************
                                    ***********************************************************************************************************************************************--%>
                                    <br />
                                    <div runat="server" id="Cash_Mujmale_Deiv">
                                         <hr />
                                    <h5> <asp:Label ID="Label7" runat="server"></asp:Label></h5>
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="Building_Cash_Amount" CellPadding="5" DataKeyNames="Cash_Amount_ID" runat="server" AutoGenerateColumns="false"
                                                        OnRowDataBound="Building_Cash_Amount_RowDataBound"
                                                        OnRowEditing="Building_Cash_Amount_RowEditing"
                                                        OnRowUpdating="Building_Cash_Amount_RowUpdating"
                                                        OnRowCancelingEdit="Building_Cash_Amount_RowCancelingEdit">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="مسلسل" ItemStyle-Width="10">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="إسم الملكية">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Ownership_Name" runat="server" Text='<%# Eval("O_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Ownership_ID" Visible="false" runat="server" Text='<%# Eval("O_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="إسم البناء">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Building_Name" runat="server" Text='<%# Eval("B_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_Building_ID" Visible="false" runat="server" Text='<%# Eval("B_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="اسم المستأجر">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="قيمة الدفعة">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cash_Amount" runat="server" Text='<%# Eval("Cash_Amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="تاريخ الدفعة">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cash_Date" runat="server" Text='<%# Eval("Cash_Date") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                    
                                                            <asp:TemplateField HeaderText="حالة الدفعة">
                                                                <EditItemTemplate>
                                                                    <asp:Label Visible="false" ID="Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Status_DropDownList" runat="server">
                                                                        <asp:ListItem Value="1" Text="غير محصل"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="محصل"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="تاريخ تحصيل الدفعة">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                                                    <asp:Calendar ID="Collection_Date_Calendar" runat="server">
                                                                        <DayHeaderStyle BackColor="#52a2da" ForeColor="#ffffff" Height="1px" />
                                                                        <NextPrevStyle Font-Size="8pt" ForeColor="#ffffff" />
                                                                        <OtherMonthDayStyle ForeColor="#5a5c69" />
                                                                        <TitleStyle CssClass="calendarMonthStyle" Height="25px" />
                                                                        <WeekendDayStyle BackColor="#dfeef8" />
                                                                    </asp:Calendar>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Collection_Date" runat="server" Text='<%# Eval("Collection_Date") %>'>  </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="حالة الدفعة" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="test_lbl_Tr_Status" runat="server" Text='<%# Eval("Satuts")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="تعديل"  CancelText="إلغاء" UpdateText="تحديث" ControlStyle-Width="55px" ControlStyle-CssClass="btn btn-sm btn-secondary" />
                                                        </Columns>
                                                        <EditRowStyle HorizontalAlign="Center" />
                                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#cacff1" Font-Bold="false" ForeColor="Black" Font-Size="15px" HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                                        <RowStyle HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="false" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                                        <RowStyle HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </div>
                                                <asp:Label ID="lbl_B_Cash_NO_Data"  runat="server" ></asp:Label>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    </div>
           
                                </div>
                            </div>
                            <br /><br /><br /><br /><br />

                </div>
            </div>
        </div>
    </div>


</div>

</asp:Content>
