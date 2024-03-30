<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Add_transformation_Bank.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Add_transformation_Bank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <style>
        .LTR {
            direction:ltr;
            text-align:left;
            display: block;
            width: 100%;
            height: calc(1.5em + .75rem + 7px);
            padding: .375rem .75rem;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #6e707e;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #d1d3e2;
            border-radius: .25rem;
            -webkit-transition: border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;
            transition: border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;
            transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out,-webkit-box-shadow .15s ease-in-out
        }
    </style>

    <div class="container-fluid" id="container-wrapper" style="margin: auto;">
        <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Bank" runat="server" Text="إضافة مصرف  جديد للحوالات"></asp:Label>
            </h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-10">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Bank_Name" runat="server" Text="اسم البنك"></asp:Label>
                                    <asp:DropDownList ID="Ar_Bank_Name_DropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Ar_Bank_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-6" style="text-align:left">
                                <div class="form-group" >
                                    <asp:Label ID="lbl_En_Bank_Name" runat="server" Text="Bank Name"></asp:Label>
                                    <asp:DropDownList ID="En_Bank_Name_DropDownList"  runat="server" CssClass="LTR" AutoPostBack="true" OnSelectedIndexChanged="En_Bank_Name_DropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Bank_NO" runat="server" Text="رقم البنك"></asp:Label>
                                    <asp:TextBox ID="txt_Ar_Bank_NO" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_Ar_Bank_NO_TextChanged"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-lg-6" style="text-align:left">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Bank_NO" runat="server" Text="Bank NO"></asp:Label>
                                    <asp:TextBox ID="txt_En_Bank_NO" runat="server" CssClass="LTR" AutoPostBack="true" OnTextChanged="txt_En_Bank_NO_TextChanged"></asp:TextBox>

                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Beneficiary_Name" runat="server" Text="اسم المستفيد"></asp:Label>
                                    <asp:TextBox ID="txt_Ar_Beneficiary_Name" runat="server" CssClass="form-control" ></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-lg-6" style="text-align:left">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Beneficiary_Name" runat="server" Text="Beneficiary Name"></asp:Label>
                                    <asp:TextBox ID="txt_En_Beneficiary_Name" runat="server" CssClass="LTR" ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_IBAN_Number" runat="server" Text="رقم الحساب"></asp:Label>
                                    <asp:TextBox ID="txt_Ar_IBAN_Number" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_Ar_IBAN_Number_TextChanged"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-lg-6" style="text-align:left">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_IBAN_Number" runat="server" Text="IBAN Number "></asp:Label>
                                    <asp:TextBox ID="txt_En_IBAN_Number" runat="server" CssClass="LTR" AutoPostBack="true" OnTextChanged="txt_En_IBAN_Number_TextChanged"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Swift_Code" runat="server" Text="رقم السوفت كود"></asp:Label>
                                    <asp:TextBox ID="txt_Ar_Swift_Code" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_Ar_Swift_Code_TextChanged"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-lg-6" style="text-align:left">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Swift_Code" runat="server" Text="Swift Code "></asp:Label>
                                    <asp:TextBox ID="txt_En_Swift_Code" runat="server" CssClass="LTR" AutoPostBack="true" OnTextChanged="txt_En_Swift_Code_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Curacy" runat="server" Text="العمله"></asp:Label>
                                    <asp:TextBox ID="txt_Ar_Curacy" runat="server" CssClass="form-control" ></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-lg-6" style="text-align:left">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Curacy" runat="server" Text="Curacy"></asp:Label>
                                    <asp:TextBox ID="txt_En_Curacy" runat="server" CssClass="LTR" ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Ar_Bank_Address" runat="server" Text="عنوان البنك"></asp:Label>
                                    <asp:TextBox ID="txt_Ar_Bank_Address" runat="server" CssClass="form-control" ></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-lg-6" style="text-align:left">
                                <div class="form-group">
                                    <asp:Label ID="lbl_En_Bank_Address" runat="server" Text="Bank Address"></asp:Label>
                                    <asp:TextBox ID="txt_En_Bank_Address" runat="server" CssClass="LTR" ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-3">
                               <asp:Button ID="btn_Add_Bank" runat="server" Text="إضافة " CssClass="btn btn" BackColor="#52a2da" ForeColor="White" Width="248px"  OnClick="btn_Add_Bank_Click"  />
                            </div>
                            <div class="col-lg-6">
                               <asp:Button ID="btn_Back_To_Bank_List" runat="server" Text="العودة لقائمة المصارف" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Bank_List_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
