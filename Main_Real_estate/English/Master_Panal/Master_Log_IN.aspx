<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Master_Log_IN.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Master_Log_In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ammlak</title>
    <link href="../CSS/all.min.css" rel="stylesheet" />
    <link href="../CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../CSS/ruang-admin.min.css" rel="stylesheet" />
    <script src="../JS/JSY.js"></script>
    <script src="../JS/JSY2.js"></script>
    <script src="../JS/JSY3.js"></script>
    <script src="../JS/JSY4.js"></script>
    <script src="../JS/JSY5.js"></script>
    <script src="../JS/chart-area-demo.js"></script>
     <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="container-login" style="padding-top: 70px">
            <div class="row justify-content-center">
                <div class="col-xl-6 col-lg-12 col-md-9">
                    <div class="card shadow-sm my-5">
                        <div class="card-body p-0">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="login-form">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">تسجيل الدخول إلى اللوحة الرئيسية</h1>
                                        </div>
                                        <div class="user">
                                            <asp:Login ID="Login1" runat="server" OnAuthenticate="ValidateUser" CssClass="col-lg-12">
                                                <LayoutTemplate>
                                                    <div class="form-group">
                                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">اسم المستخدم:</asp:Label>
                                                        <asp:TextBox ID="UserName" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="اسم المستخدم مطلوب." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                        <br />
                                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">كلمة السر:</asp:Label>
                                                        <asp:TextBox ID="Password" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="كلمة السر مطلوبة." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>

                                                        <asp:CheckBox ID="RememberMe" runat="server" Text="تذكرني في المرة القادمة." />
                                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Button ID="LoginButton" CssClass="btn btn btn-block" BackColor="#52a2da" ForeColor="White" runat="server" CommandName="Login" Text="تسجيل الدخول" ValidationGroup="Login1" />
                                                    </div>
                                                    <hr />
                                                </LayoutTemplate>
                                            </asp:Login>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
