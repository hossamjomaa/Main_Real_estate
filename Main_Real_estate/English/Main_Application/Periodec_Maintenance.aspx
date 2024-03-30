<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Periodec_Maintenance.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Periodec_Maintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
       table, th, td {
            border: 1px solid #000;
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
            border-color: #eee;
        }
        .XXX {
            width: 20px
        }
    </style>


    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 1000);
            return false;
        }
    </script>



    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container-fluid" id="container-wrapper">
         <div class="row">
            <div class="col-lg-3 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_periodic_maintenance" runat="server" Text="الصيانة الدورية"></asp:Label>
                </h1>
            </div>
          </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-12">
                    <div class="card-body">
                        <div id="container" class="container-fluid" style="border-radius: 10px;">
                            <div calss="row">
                                <div class="row">
                                    <div class="col-lg-8">
                                        <asp:Button ID="btn_Open_New_Year" runat="server" Text="فتح جدول صيانة دورية جديد" CssClass="btn btn" BackColor="#52a2da" ForeColor="White" Width="248px" OnClick="btn_Open_New_Year_Click" />
                                        <asp:Label ID="Last_periodic_maintenence_id" runat="server" Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_Last_Years" runat="server" Text="الصيانات الدورية للسنوات السابقة"></asp:Label>
                                            <asp:DropDownList ID="Last_Years_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Last_Years_DropDownList_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row" id="Year_Div" runat="server" visible="false" style="border-style: solid">
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_Year" runat="server" Text=" السنة"></asp:Label>
                                            <asp:DropDownList ID="Year_DropDownList" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="ownership_Name_Req_Val" ControlToValidate="Year_DropDownList"
                                                InitialValue="أخترالسنة...." runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b" ValidationGroup="Year"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-lg-2" style="padding-top: 25px">
                                        <asp:ImageButton ID="Add_New_Year" ImageUrl="Main_Image/plus.png" Width="40px" Height="40px" runat="server" OnClick="Add_New_Year_Click" />
                                    </div>
                                    <div class="col-lg-8" style="padding-top: 25px">
                                        <asp:Button ID="Cancel_Add_New_Year" runat="server" Text="إلغاء" CssClass="btn btn-light mb-1" OnClick="Cancel_Add_New_Year_Click" />
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"/>
                                    </div>
                                    <div class="col-lg-6">
                                         <asp:Button ID="Search_Btn" Text="بحث" CssClass="btn btn-secondary" runat="server" OnClick="Search_Btn_Click" Width="50px" Height="40px"/>
                                    </div>
                                    <div class="col-lg-2" style="text-align: left; padding: 0" >
                                        <%--<asp:Button ID="btnPrint" runat="server" Text="XXXXXXX" OnClientClick="return PrintPanel();" />--%>

                                        <button ID="btnPrint" style="font-size: 18px; width: 150px"  class="btn btn-lg btn-primary"  onclick="return PrintPanel();"><i class="fa fa-print" aria-hidden="true" runat="server"></i>&nbsp;طباعة  </button>
                                    </div>
                                
                                </div><br />
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <div class="row" runat="server" id="pnlContents">
                                                <div class="table-responsive datatable table table-bordered">
                                                    <asp:GridView ID="Periodic_Maintenence_List" DataKeyNames="Periodic_Maintenence_ID" runat="server" AutoGenerateColumns="false"
                                                        OnRowEditing="EditCustomer" OnRowDataBound="RowDataBound" OnRowCancelingEdit="CancelEdit" OnRowUpdating="UpdateCustomer">
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Asset_Id" runat="server" Text='<%# Eval("Asset_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:BoundField DataField="Assets_Arabic_Name" HeaderText="إسم الأصل" ControlStyle-Font-Bold="false" />
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="العنوان (ملكية / بناء / وحدة)" ItemStyle-Width="150" HeaderStyle-Width="150">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Ownership" runat="server" Text='<%# Eval("Owner_Ship_AR_Name")%>'></asp:Label>/
                                                            <asp:Label ID="lbl_Building" runat="server" Text='<%# Eval("Building_Arabic_Name")%>'></asp:Label>/
                                                            <asp:Label ID="lbl_Unit" runat="server" Text='<%# Eval("Unit_Number")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="Jan">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_M_1" runat="server" Text='<%# Eval("M_1")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_E_M_1" runat="server" Text='<%# Eval("Em1")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_D_M_1" runat="server" Text='<%# Eval("D_M_1")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_M_1" Visible="false" runat="server" Text='<%# Eval("M_1")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Calendar_M_1" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_E_M_1" Visible="false" runat="server" Text='<%# Eval("Em1")%>'></asp:Label>
                                                                    <asp:DropDownList ID="DropDownList_E_M_1" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_D_M_1" Visible="false" runat="server" Text='<%# Eval("D_M_1")%>'></asp:Label>
                                                                    <asp:TextBox ID="TextBox_D_M_1" runat="server" Text='<%# Bind("D_M_1") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <%------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="Feb">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_M_2" runat="server" Text='<%# Eval("M_2")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_E_M_2" runat="server" Text='<%# Eval("Em2")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_D_M_2" runat="server" Text='<%# Eval("D_M_2")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_M_2" Visible="false" runat="server" Text='<%# Eval("M_2")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Calendar_M_2" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_E_M_2" Visible="false" runat="server" Text='<%# Eval("Em2")%>'></asp:Label>
                                                                    <asp:DropDownList ID="DropDownList_E_M_2" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_D_M_2" Visible="false" runat="server" Text='<%# Eval("D_M_2")%>'></asp:Label>
                                                                    <asp:TextBox ID="TextBox_D_M_2" runat="server" Text='<%# Bind("D_M_2") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <%------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="Mar">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_M_3" runat="server" Text='<%# Eval("M_3")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_E_M_3" runat="server" Text='<%# Eval("Em3")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_D_M_3" runat="server" Text='<%# Eval("D_M_3")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_M_3" Visible="false" runat="server" Text='<%# Eval("M_3")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Calendar_M_3" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_E_M_3" Visible="false" runat="server" Text='<%# Eval("Em3")%>'></asp:Label>
                                                                    <asp:DropDownList ID="DropDownList_E_M_3" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_D_M_3" Visible="false" runat="server" Text='<%# Eval("D_M_3")%>'></asp:Label>
                                                                    <asp:TextBox ID="TextBox_D_M_3" runat="server" Text='<%# Bind("D_M_3") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-- ---------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="Apr">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_M_4" runat="server" Text='<%# Eval("M_4")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_E_M_4" runat="server" Text='<%# Eval("Em4")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_D_M_4" runat="server" Text='<%# Eval("D_M_4")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_M_4" Visible="false" runat="server" Text='<%# Eval("M_4")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Calendar_M_4" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_E_M_4" Visible="false" runat="server" Text='<%# Eval("Em4")%>'></asp:Label>
                                                                    <asp:DropDownList ID="DropDownList_E_M_4" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_D_M_4" Visible="false" runat="server" Text='<%# Eval("D_M_4")%>'></asp:Label>
                                                                    <asp:TextBox ID="TextBox_D_M_4" runat="server" Text='<%# Bind("D_M_4") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="May">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_M_5" runat="server" Text='<%# Eval("M_5")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_E_M_5" runat="server" Text='<%# Eval("Em5")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_D_M_5" runat="server" Text='<%# Eval("D_M_5")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_M_5" Visible="false" runat="server" Text='<%# Eval("M_5")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Calendar_M_5" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_E_M_5" Visible="false" runat="server" Text='<%# Eval("Em5")%>'></asp:Label>
                                                                    <asp:DropDownList ID="DropDownList_E_M_5" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_D_M_5" Visible="false" runat="server" Text='<%# Eval("D_M_5")%>'></asp:Label>
                                                                    <asp:TextBox ID="TextBox_D_M_5" runat="server" Text='<%# Bind("D_M_5") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>

                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="Jun">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_M_6" runat="server" Text='<%# Eval("M_6")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_E_M_6" runat="server" Text='<%# Eval("Em6")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_D_M_6" runat="server" Text='<%# Eval("D_M_6")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_M_6" Visible="false" runat="server" Text='<%# Eval("M_6")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Calendar_M_6" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_E_M_6" Visible="false" runat="server" Text='<%# Eval("Em6")%>'></asp:Label>
                                                                    <asp:DropDownList ID="DropDownList_E_M_6" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_D_M_6" Visible="false" runat="server" Text='<%# Eval("D_M_6")%>'></asp:Label>
                                                                    <asp:TextBox ID="TextBox_D_M_6" runat="server" Text='<%# Bind("D_M_6") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <%------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="Jul">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_M_7" runat="server" Text='<%# Eval("M_7")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_E_M_7" runat="server" Text='<%# Eval("Em7")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_D_M_7" runat="server" Text='<%# Eval("D_M_7")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_M_7" Visible="false" runat="server" Text='<%# Eval("M_7")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Calendar_M_7" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_E_M_7" Visible="false" runat="server" Text='<%# Eval("Em7")%>'></asp:Label>
                                                                    <asp:DropDownList ID="DropDownList_E_M_7" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_D_M_7" Visible="false" runat="server" Text='<%# Eval("D_M_7")%>'></asp:Label>
                                                                    <asp:TextBox ID="TextBox_D_M_7" runat="server" Text='<%# Bind("D_M_7") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <%------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="Aug">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_M_8" runat="server" Text='<%# Eval("M_8")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_E_M_8" runat="server" Text='<%# Eval("Em8")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_D_M_8" runat="server" Text='<%# Eval("D_M_8")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_M_8" Visible="false" runat="server" Text='<%# Eval("M_8")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Calendar_M_8" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_E_M_8" Visible="false" runat="server" Text='<%# Eval("Em8")%>'></asp:Label>
                                                                    <asp:DropDownList ID="DropDownList_E_M_8" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_D_M_8" Visible="false" runat="server" Text='<%# Eval("D_M_8")%>'></asp:Label>
                                                                    <asp:TextBox ID="TextBox_D_M_8" runat="server" Text='<%# Bind("D_M_8") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-- ---------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="Sep">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_M_9" runat="server" Text='<%# Eval("M_9")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_E_M_9" runat="server" Text='<%# Eval("Em9")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_D_M_9" runat="server" Text='<%# Eval("D_M_9")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_M_9" Visible="false" runat="server" Text='<%# Eval("M_9")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Calendar_M_9" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_E_M_9" Visible="false" runat="server" Text='<%# Eval("Em9")%>'></asp:Label>
                                                                    <asp:DropDownList ID="DropDownList_E_M_9" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_D_M_9" Visible="false" runat="server" Text='<%# Eval("D_M_9")%>'></asp:Label>
                                                                    <asp:TextBox ID="TextBox_D_M_9" runat="server" Text='<%# Bind("D_M_9") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="Oct">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_M_10" runat="server" Text='<%# Eval("M_10")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_E_M_10" runat="server" Text='<%# Eval("Em10")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_D_M_10" runat="server" Text='<%# Eval("D_M_10")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_M_10" Visible="false" runat="server" Text='<%# Eval("M_10")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Calendar_M_10" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_E_M_10" Visible="false" runat="server" Text='<%# Eval("Em10")%>'></asp:Label>
                                                                    <asp:DropDownList ID="DropDownList_E_M_10" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_D_M_10" Visible="false" runat="server" Text='<%# Eval("D_M_10")%>'></asp:Label>
                                                                    <asp:TextBox ID="TextBox_D_M_10" runat="server" Text='<%# Bind("D_M_10") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-----------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="Nov">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_M_11" runat="server" Text='<%# Eval("M_11")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_E_M_11" runat="server" Text='<%# Eval("Em11")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_D_M_11" runat="server" Text='<%# Eval("D_M_11")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_M_11" Visible="false" runat="server" Text='<%# Eval("M_11")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Calendar_M_11" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_E_M_11" Visible="false" runat="server" Text='<%# Eval("Em11")%>'></asp:Label>
                                                                    <asp:DropDownList ID="DropDownList_E_M_11" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_D_M_11" Visible="false" runat="server" Text='<%# Eval("D_M_11")%>'></asp:Label>
                                                                    <asp:TextBox ID="TextBox_D_M_11" runat="server" Text='<%# Bind("D_M_11") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--------------------------------------------------------------------------------------------------%>
                                                            <asp:TemplateField HeaderText="Dec">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_M_12" runat="server" Text='<%# Eval("M_12")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_E_M_12" runat="server" Text='<%# Eval("Em12")%>'></asp:Label><hr />
                                                                    <asp:Label ID="lbl_D_M_12" runat="server" Text='<%# Eval("D_M_12")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbl_M_12" Visible="false" runat="server" Text='<%# Eval("M_12")%>'></asp:Label>
                                                                    <asp:DropDownList ID="Calendar_M_12" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_E_M_12" Visible="false" runat="server" Text='<%# Eval("Em12")%>'></asp:Label>
                                                                    <asp:DropDownList ID="DropDownList_E_M_12" runat="server"></asp:DropDownList>

                                                                    <asp:Label ID="lbl_D_M_12" Visible="false" runat="server" Text='<%# Eval("D_M_12")%>'></asp:Label>
                                                                    <asp:TextBox ID="TextBox_D_M_12" runat="server" Text='<%# Bind("D_M_12") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-----------------------------------------------------------------------------------%>
                                                            <asp:BoundField DataField="Year" HeaderText=" العام" />
                                                            <%-----------------------------------------------------------------------------------%>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Last_Periodic_Maintenance_Date" runat="server" Text='<%# Eval("Last_Periodic_Maintenance_Date") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-----------------------------------------------------------------------------------%>
                                                            <asp:CommandField  ShowEditButton="True" ButtonType="Button" EditText="تعديل" CancelText="إلغاء" UpdateText="تحديث" ControlStyle-Width="55px" ControlStyle-CssClass="btn btn-sm btn-secondary" />
                                                        </Columns>
                                                        <RowStyle HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#dfeef8" Font-Bold="false" ForeColor="Black"  HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                        </div>
                        <br />

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
