<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="contractor_List.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.contractor_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.js"></script>
    <script src="../JS/DataTableScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





    <link href="../CSS/DataTableCss.css" rel="stylesheet" />
     <!-- Container Fluid-->
    <div class="container-fluid" id="container-wrapper">
        <div class="row">
            <div class="col-lg-4 mb-3" style="">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel" runat="server" Text="قائمة المقاولين"></asp:Label>
                </h1>
            </div>
            <div class="col-lg-4">
                <button style="background-color:#52a2da; color:white; border-style:none; height:40px; border-radius:7px;" runat="server" onserverclick="GoToAdd"><i class="fa fa-plus-circle" aria-hidden="true"></i> إضافة </button>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12 mb-4">
                <!-- Simple Tables -->
                <div class="card">
                    <div class="table-responsive" style="border-radius: 10px;" id="Grid">
                        <asp:Repeater ID="The_Table" runat="server" ClientIDMode="Static">
                        <HeaderTemplate>
                            <table  cellspacing="0" style="width: 100%; font-size:11px" id="Table" class="datatable table table-striped table-bordered">
                                <thead>
                                    <th>اسم المقاول</th>
                                    <th>contractor Name </th>
                                    <th>اسم الشركة</th>
                                    <th>عنوان الشركة</th>
                                    <th>هاتف</th>
                                    <th></th>
                                </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td> <asp:Label ID="lbl_Contractor_Ar_Name" runat="server" Text='<%# Eval("Contractor_Ar_Name") %>' /></td>
                                <td> <asp:Label ID="lbl_Contractor_En_Name" runat="server" Text='<%# Eval("Contractor_En_Name") %>' /></td>
                                <td> <asp:Label ID="lbl_Contractor_Company_Name" runat="server" Text='<%# Eval("Contractor_Company_Name") %>' /></td>
                                <td> <asp:Label ID="lbl_Contractor_Company_Address" runat="server" Text='<%# Eval("Contractor_Company_Address") %>' /></td>
                                <td> <asp:Label ID="lbl_Contractor_Phon" runat="server" Text='<%# Eval("Contractor_Phon") %>' /></td>
                                <td>
                                    <asp:LinkButton  runat="server" CommandArgument='<%# Eval("Contractor_ID") %>' OnClientClick="return confirm('هل أنت متأكد أنك تريد حذف؟');" OnClick="Delete" ><i class="fa fa-trash" style="font-size:18px;"></i></asp:LinkButton>
                                    <asp:LinkButton  runat="server" CommandArgument='<%# Eval("Contractor_ID") %>' OnClick="Edit"> <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>
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
