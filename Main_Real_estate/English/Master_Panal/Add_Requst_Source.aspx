<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Add_Requst_Source.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Add_Requst_Source" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid" id="container-wrapper" style="margin:auto; ">
         <!----------------------------------------------------------------------------------------------------------->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_titel_Add_New_Requst_Source_Type" runat="server" Text="إضافة مصدر طلبات جديد"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Success_Add_New_Requst_Source_Type" runat="server" ForeColor="#00FF40"></asp:Label></h1>
        </div>
        <!----------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="col-lg-10">
                <div class="card mb-10" >
                     <div class="card-body">
                          
                              <div class="form-group">
                               <asp:Label ID="lbl_Ar_Requst_Source_Name" runat="server" Text="مصدر الطلب بالعربية"></asp:Label>
                                <asp:TextBox ID="txt_Ar_Requst_Source_Name" runat="server" CssClass="form-control" ></asp:TextBox>
                             </div>

                              <div class="form-group">
                               <asp:Label ID="lbl_En_Requst_Source_Name" runat="server" Text="مصدر الطلب بالإنكليزية"></asp:Label>
                              <asp:TextBox ID="txt_En_Requst_Source_Name" runat="server" CssClass="form-control"></asp:TextBox>
                              
                             </div>
                      </div>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btn_Add_Requst_Source" runat="server" Text="إضافة مصدر طلب" CssClass="btn btn" BackColor="#52a2da" ForeColor="White" Width="248px" OnClick="btn_Add_Requst_Source_Click"    />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Back_To_Requst_Source_List" runat="server" Text="العودة لقائمة مصادر الطلبات" ValidationGroup="x" CssClass="btn btn-light mb-1" OnClick="btn_Back_To_Requst_Source_List_Click" />
    </div>

</asp:Content>
