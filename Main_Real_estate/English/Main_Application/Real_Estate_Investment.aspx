<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Real_Estate_Investment.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Real_Estate_Investment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <style>
        .table-condensed tr th {
            border: 0px solid #fff;
            color: black;
            background-color: #cacff1;
        }

        .table-condensed, .table-condensed tr td {
            border: 0px solid #fff;
        }

        tr:nth-child(even) {
            background: #d7d7d7;
        }

        tr:nth-child(odd) {
            background: #e3e3e3;
        }
    </style>


    <div class="container-fluid">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_REI" runat="server" Text="إضافة إستثمار عقاري جديد"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Success_Add_New_REI" runat="server" ForeColor="#00FF40"></asp:Label></h1>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-6">
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ownership_Or_Building" runat="server" Text="ملكية أو بناء"></asp:Label>
                                    <asp:DropDownList ID="Ownership_Or_Building_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Ownership_Or_Building_DropDownList_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="ملكية"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="بناء"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Ownership_Or_Building_RequiredFieldValidator" ControlToValidate="Ownership_Or_Building_DropDownList"
                                        InitialValue="إختر ملكلية أو بناء ...." runat="server" ValidationGroup="REI_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4" runat="server" id="Ownership" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ownership_Name" runat="server" Text="اسم الملكية"></asp:Label>
                                    <asp:DropDownList ID="Ownership_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Ownership_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Ownership_Name_RequiredFieldValidator" ControlToValidate="Ownership_Name_DropDownList"
                                        InitialValue="إختر اسم الملكية ...." runat="server" ValidationGroup="REI_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4" runat="server" id="Building" visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Building_Name" runat="server" Text="اسم البناء"></asp:Label>
                                    <asp:DropDownList ID="Building_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Building_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Building_Name_RequiredFieldValidator" ControlToValidate="Building_Name_DropDownList"
                                        InitialValue="إختر اسم المستأجر ...." runat="server" ValidationGroup="REI_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="#fc544b">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_REI_Value" runat="server" Text="قيمة الإستثمار"></asp:Label>&nbsp;
                                    <asp:RegularExpressionValidator ID="REI_Reg_Exp_Val" runat="server" ControlToValidate="txt_REI_Value"
                                        EnableClientScript="True" ErrorMessage="!!! يُسمح فقط بالأرقام" ForeColor="Red"
                                        ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txt_REI_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="REI_Req_Fuild" ControlToValidate="txt_REI_Value"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red" ValidationGroup="REI_RequiredField"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Year" runat="server" Text="السنة"></asp:Label>
                                    <asp:DropDownList ID="Year_DropDownList" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Year_DropDownList"
                                        InitialValue="إخترالسنة ...." runat="server" ValidationGroup="REI_RequiredField" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="lbl_REI_Name" runat="server" Text="إسم الإستثمار"></asp:Label>
                                    <asp:TextBox ID="txt_REI_Name" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="REI_Req_Fiel" ControlToValidate="txt_REI_Name" ValidationGroup="REI_RequiredField"
                                        runat="server" ErrorMessage="* حقل مطلوب !!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Ownership_Or_Building_DropDownList" EventName="SelectedIndexChanged"/>
                                <asp:AsyncPostBackTrigger ControlID="Ownership_Name_DropDownList" EventName="SelectedIndexChanged"/>
                                <asp:AsyncPostBackTrigger ControlID="Building_Name_DropDownList" EventName="SelectedIndexChanged"/>
                            </Triggers>
                        </asp:UpdatePanel>
                        
                        <br />
                        <asp:LinkButton ID="Add" runat="server" Text="إضافة الإستثمار الجديد" CssClass="btn  mb-1" BackColor="#52a2da" ForeColor="White" Width="248px" ValidationGroup="REI_RequiredField" OnClick="btn_Add_Contract_Click" />
                        <hr />
                        <div class="row">
                            <div class="col-lg-12 mb-4">
                                <div class="card">
                                    <div class="table-responsive" >
                                        <asp:GridView AutoGenerateColumns="false" ID="ERI_GridView1" runat="server"
                                            CssClass="datatable table table-striped table-bordered" BackColor="White" BorderColor="#CCCCCC"
                                            BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Horizontal" Font-Size="11px" OnRowDataBound="ERI_GridView1_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Name" HeaderText="إسم الإستثمار العقاري" />

                                                <asp:TemplateField HeaderText="قيمة الإستثمار ">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Value" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Value")))%>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Year" HeaderText="السنة" />


                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton  ID="btn_investment_Delete" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="Delete_investment"><i class="fa fa-trash" style="font-size:20px; color:#0779c9"></i> </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle HorizontalAlign="Center" />
                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                            <HeaderStyle BackColor="#cacff1" Font-Bold="false" ForeColor="Black" Font-Size="11px" HorizontalAlign="Center" />
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
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
