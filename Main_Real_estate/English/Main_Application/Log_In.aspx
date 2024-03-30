<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log_In.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Log_In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Cairo:wght@200;300;400;500;600;700;800;900&display=swap" rel="stylesheet">


    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" rel="stylesheet" />
    <link href="../CSS/all.min.css" rel="stylesheet" />
    <link href="../CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../CSS/ruang-admin.min.css" rel="stylesheet" />
    <%--  <script src="../JS/JSY.js"></script>--%>
    <%--  <script src="../JS/JSY2.js"></script>
    <script src="../JS/JSY3.js"></script>
    <script src="../JS/JSY4.js"></script>--%>
    <%--<script src="../JS/JSY5.js"></script>
    <script src="../JS/chart-area-demo.js"></script>--%>
    <title>Ammlak</title>


    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js" integrity="sha512-894YE6QWD5I59HgZOGReFYm4dnWc1Qt5NtvYSaNcOP+u1T9qYdvdihz0PPSiiqn/+/3e7Jo4EaG7TubfWGUrMQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="/English/JS/jquery.vide.js"></script>

    <style type="text/css">
        * {
            font-family: 'Cairo', sans-serif;
        }


        body {
            margin: 0;
            padding: 0;
            height: 100vh;
            background: #eeeeee;
            direction: rtl;
        }
        .pass{direction:rtl}

        .layer {
            height: 100%;
            width: 100%;
            background: #000;
            opacity: 0.4;
        }

        form {
            background: #ffffff;
            opacity: 0.85;
            padding: 40px;
            /*width: 350px;*/
            width: 30%;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            border-radius: 6px;
        }

        .form-header {
            text-align: center;
            margin-bottom: 20px;
        }

            .form-header img {
                height: 80px;
            }

            .form-header h1 {
                font-size: 30px;
            }

            .form-header h3 {
                font-size: 15px;
            }

            .form-header h1,
            .form-header h3 {
                margin: 10px;
                font-weight: 100;
            }
    </style>


</head>
<body data-vide-bg="nature">
    <div class="layer"></div>
    <form id="form1" runat="server">
        <div class="container-login" style="padding-top: 70px">
            <div class="row justify-content-center">
                <div class="col-xl-12 col-lg-12 col-md-12">
                    <div class="card shadow-sm my-5">
                        <div class="card-body p-0">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="login-form">
                                        <%--<div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">تسجيل الدخول</h1>
                                        </div>--%>

                                        <div class="form-header">
                                            <img src="Main_Image/P_Logo.jpg" alt="logo">
                                            <h1>
                                                <asp:Label runat="server" Text="مرحبًا بعودتك !"></asp:Label></h1>
                                            <h3>
                                                <asp:Label runat="server" Text="أدخل بيانات الاعتماد الخاصة بك لتسجيل الدخول"></asp:Label>
                                            </h3>
                                        </div>
                                        <div class="user">
                                            <asp:Login ID="Login1" runat="server" OnAuthenticate="ValidateUser" CssClass="col-lg-12">
                                                <LayoutTemplate>
                                                    <div class="form-group" style="text-align: right">
                                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">اسم المستخدم:</asp:Label>
                                                        <asp:TextBox ID="UserName" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                        <br />
                                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">كلمة السر:</asp:Label>
                                                        <asp:TextBox ID="Password" CssClass="form-control pass" runat="server" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="كلمة السر مطلوبة" ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>

                                                        <asp:CheckBox ID="RememberMe" runat="server" Text="تذكرني في المرة القادمة" />
                                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Button ID="LoginButton" CssClass="btn btn btn-block" BackColor="#52a2da" ForeColor="White" runat="server" CommandName="Login" Text="تسجيل الدخول" ValidationGroup="Login1" />
                                                    </div>
                                                    <%--<hr />
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_Select_Language" runat="server" Text="Select Language"></asp:Label>
                                                        <asp:DropDownList ID="XXX" runat="server" CssClass="form-control">
                                                            
                                                            <asp:ListItem Value="1">Arabic</asp:ListItem>
                                                            <asp:ListItem Value="2">English</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </div>--%>
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
