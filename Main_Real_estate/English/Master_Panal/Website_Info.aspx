<%@ Page Title="" Language="C#" MasterPageFile="~/English/Master_Panal/Admin_Panel.Master" AutoEventWireup="true" CodeBehind="Website_Info.aspx.cs" Inherits="Main_Real_estate.English.Master_Panal.Website_Info" MaintainScrollPositionOnPostBack = "true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" id="container-wrapper">
    <div class="row">
        <div class="col-lg-12">
            <div class="card mb-12">
                <div class="card-body">
                    <asp:Label ID="Label1" runat="server" Font-Size="30px" Text="إضافة المعلومات الأساسية إلى الموقع العام"></asp:Label>&nbsp;&nbsp;
                    <asp:Label ID="lbl_WebSite_Info" Font-Size="30px" runat="server" ForeColor="Green"></asp:Label><br />
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                               <asp:Label ID="lbl_En_Who_Are_We" runat="server" Text="Who We Are "></asp:Label>
                                <asp:TextBox ID="txt_En_Who_Are_We" runat="server" TextMode="MultiLine" CssClass="form-control" ></asp:TextBox>
                             </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                               <asp:Label ID="lbl_AR_Who_Are_We" runat="server" Text="من نحن "></asp:Label>
                              <asp:TextBox ID="txt_Ar_Who_Are_We" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                              
                             </div>
                        </div>

                        <div class="col-lg-4" >
                            <div class="form-group">
                               <asp:Label ID="lbl_Phone" runat="server" Text="رقم الجوال / الهاتف"></asp:Label>
                                <asp:TextBox ID="txt_Phone" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>
                        </div>
                    </div>


                     <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                               <asp:Label ID="lbl_En_Address" runat="server" Text="Al Manara Company"></asp:Label>
                                <asp:TextBox ID="txt_En_Address" runat="server" TextMode="MultiLine" CssClass="form-control" ></asp:TextBox>
                             </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                               <asp:Label ID="lbl_AR_Address" runat="server" Text="عنوان شركة المنارة"></asp:Label>
                              <asp:TextBox ID="txt_Ar_Address" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                              
                             </div>
                        </div>

                        <div class="col-lg-4" >
                            <div class="form-group">
                               <asp:Label ID="lbl_Email" runat="server" Text="البريد الإلكتروني"></asp:Label>
                                <asp:TextBox ID="txt_Email" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>
                        </div>
                    </div>

                     <div class="row">
                        <div class="col-lg-4" >
                            <div class="form-group">
                               <asp:Label ID="lbl_FaceBook" runat="server" Text="رابط الفيس بوك"></asp:Label>
                                <asp:TextBox ID="txt_FaceBook" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>
                        </div>
                         <div class="col-lg-4" >
                            <div class="form-group">
                               <asp:Label ID="lbl_Whatssapp" runat="server" Text="رقم واتس أب"></asp:Label>
                                <asp:TextBox ID="txt_Whatssapp" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>
                        </div>

                         
                    </div>
                    <hr />
                        <asp:Label ID="lbl_Domain_Info" runat="server" Text="معلومات الدومين" Font-Size="30px"></asp:Label><br /><br />

                    <div class="row">
                        <div class="col-lg">
                            <div class="form-group">
                               <asp:Label ID="lbl_Email_From" runat="server" Text="Email From"></asp:Label>
                                <asp:TextBox ID="txt_Email_From" runat="server"  CssClass="form-control" ></asp:TextBox>
                             </div>
                        </div>

                        <div class="col-lg">
                            <div class="form-group">
                               <asp:Label ID="lbl_Email_To" runat="server" Text="Email TO"></asp:Label>
                                <asp:TextBox ID="txt_Email_To" runat="server"  CssClass="form-control" ></asp:TextBox>
                             </div>
                        </div>

                        <div class="col-lg">
                            <div class="form-group">
                               <asp:Label ID="lbl_Email_STMP" runat="server" Text="Email STMP"></asp:Label>
                                <asp:TextBox ID="txt_Email_STMP" runat="server"  CssClass="form-control" ></asp:TextBox>
                             </div>
                        </div>

                        <div class="col-lg">
                            <div class="form-group">
                               <asp:Label ID="lbl_Email_Password" runat="server" Text="Email Password"></asp:Label>
                                <asp:TextBox ID="txt_Email_Password" runat="server"  CssClass="form-control" ></asp:TextBox>
                             </div>
                        </div>

                        <div class="col-lg">
                            <div class="form-group">
                               <asp:Label ID="lbl_Email_Port" runat="server" Text="Email Port"></asp:Label>
                                <asp:TextBox ID="txt_Email_Port" runat="server"  CssClass="form-control" ></asp:TextBox>
                             </div>
                        </div>
                    </div>

                    <div class="row">
                         <div class="col-lg-4" >
                            <div class="form-group">
                               <br />
                                <asp:Button ID="Add_website_Info" CssClass="form-control" OnClick="Add_website_Info_Click" runat="server"  BackColor="#52a2da" ForeColor="White" Width="200px" Text="نقل إلى الموقع العام" />
                             </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr />
<%--***********************************************************************************Service Section Start*********************************************************************************************--%>
        <div class="row">
        <div class="col-lg-12">
            <div class="card mb-12">
                <div class="card-body">
                    <asp:Label ID="lbl_Add_Services" runat="server" Font-Size="30px" Text="إضافة خدمات الشركة إلى الموقع العام"></asp:Label>&nbsp;&nbsp;
                    <asp:Label ID="lbl_Add_Services_Sucssefully" Font-Size="30px" runat="server" ForeColor="Green"></asp:Label><br />
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <%--<asp:RegularExpressionValidator ID="Reg_Ex_Servic_EN_Titlee" runat="server" ControlToValidate="txt_Servic_EN_Title"
                                EnableClientScript="True" ErrorMessage="English Only" ForeColor="Red"
                                ValidationExpression="[a-z A-Z0-9]+"></asp:RegularExpressionValidator>--%>

                               <asp:Label ID="lbl_Servic_EN_Title" runat="server" Text="Service Titel"></asp:Label>
                                <asp:TextBox ID="txt_Servic_EN_Title" runat="server"  CssClass="form-control" ></asp:TextBox>

                                <asp:RequiredFieldValidator ID="Servic_EN_Title_Req_Field_Vali" ControlToValidate="txt_Servic_EN_Title"
                                runat="server" ErrorMessage="* Required field!!!" ForeColor="Red" ValidationGroup="Add_Servic"></asp:RequiredFieldValidator>
                             </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                               <asp:Label ID="lbl_Servic_AR_Title" runat="server" Text="اسم الخدمة"></asp:Label>

                                <%--<asp:RegularExpressionValidator ID="Reg_Ex_Servic_AR_Titlee" runat="server" ControlToValidate="txt_Servic_AR_Title"
                                EnableClientScript="True" ErrorMessage="أحرف عربية فقط" ForeColor="Red"
                                ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>--%>

                              <asp:TextBox ID="txt_Servic_AR_Title" runat="server"  CssClass="form-control"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="Servic_AR_Title_Req_Field_Vali" ControlToValidate="txt_Servic_AR_Title"
                                runat="server" ErrorMessage="* حقل مطلوب!!!" ForeColor="Red" ValidationGroup="Add_Servic"></asp:RequiredFieldValidator>
                             </div>
                        </div>
                    </div>

                     <div class="row">
                        <div class="col-lg-6" >
                            <div class="form-group">
                                <%--<asp:RegularExpressionValidator ID="Reg_Ex_Servic_EN_Descriptione" runat="server" ControlToValidate="txt_Servic_EN_Description"
                                EnableClientScript="True" ErrorMessage="English Only" ForeColor="Red"
                                ValidationExpression="[a-z A-Z0-9]+"></asp:RegularExpressionValidator>--%>

                               <asp:Label ID="lbl_Servic_EN_Description" runat="server" Text="Service Description"></asp:Label>
                                <asp:TextBox ID="txt_Servic_EN_Description" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="Servic_EN_Body_Req_Field_Vali" ControlToValidate="txt_Servic_EN_Description"
                                runat="server" ErrorMessage="* Required field!!!" ForeColor="Red" ValidationGroup="Add_Servic"></asp:RequiredFieldValidator>
                             </div>
                        </div>
                        <div class="col-lg-6" >
                            <div class="form-group">
                               <asp:Label ID="lbl_Servic_AR_Description" runat="server" Text="شرح الخدمة"></asp:Label>

                                <%--<asp:RegularExpressionValidator ID="Reg_Ex_Servic_AR_Description" runat="server" ControlToValidate="txt_Servic_AR_Description"
                                EnableClientScript="True" ErrorMessage="أحرف عربية فقط" ForeColor="Red"
                                ValidationExpression="[ا-ي إ أ آ ى ة ئ ء ؤ 0-9 ]+"></asp:RegularExpressionValidator>--%>
                                <asp:TextBox ID="txt_Servic_AR_Description" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="Servic_AR_Body_Req_Field_Vali" ControlToValidate="txt_Servic_AR_Description"
                                runat="server" ErrorMessage="* حقل مطلوب!!!" ForeColor="Red" ValidationGroup="Add_Servic"></asp:RequiredFieldValidator>
                             </div>
                        </div>
                    </div>

                     <div class="row">
                        <div class="col-lg-6" >
                            <div class="form-group">
                               <asp:Label ID="lbl_Servic_Imag" runat="server" Text="الصورة"></asp:Label>
                                <asp:FileUpload ID="FUL_Servic_Imag" runat="server"  CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="Img_Servic_Req_Field_Vali" ControlToValidate="FUL_Servic_Imag"
                                runat="server" ErrorMessage="* حقل مطلوب!!!" ForeColor="Red" ValidationGroup="Add_Servic"></asp:RequiredFieldValidator>
                             </div>
                        </div>
                          <div class="col-lg-6" >
                            <div class="form-group">
                               <br />
                                <asp:Button ID="BTN_Add_Servic" CssClass="form-control" OnClick="BTN_Add_Servic_Click" ValidationGroup="Add_Servic"
                                runat="server"  BackColor="#52a2da" ForeColor="White" Width="200px" Text="نقل إلى الموقع العام" />
                             </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="container-fluid">
                                 <asp:GridView Width="100%" ID="Service_GridView" runat="server" AutoGenerateColumns="false" 
                                 BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Both">
                                    <Columns>
                                        <asp:BoundField DataField="Arabic_Titel" HeaderText="اسم الخدمة"/>
                                        <asp:BoundField DataField="English_Titel" HeaderText="Service Titel"/>
                                        <asp:BoundField DataField="Arabic_Description" HeaderText="وصف الخدمة"/>
                                        <asp:BoundField DataField="English_Description" HeaderText="Servic Description"/>
                                        <asp:TemplateField HeaderText="الصورة ">
                                            <ItemTemplate>
                                                 <asp:Image ID="Image_One_Path_Image" runat="server" ImageUrl='<%# Eval("Servic_Image_Path") %>' Width="100" Height="100" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-------------------------------------------------------------------------------------------------%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-danger" ID="btn_Servic_Delete" Width="50px" Height="40px" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="Delete_Servic"><i class="fa fa-trash"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                <RowStyle HorizontalAlign="Center"/>
                                     <EditRowStyle HorizontalAlign="Center" />
                                    <RowStyle Font-Size="15px" />
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#eaecf4" Font-Bold="false" ForeColor="Black" Font-Size="15px" HorizontalAlign="Center" />
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
<%--************************************************************************************Service Section End************************************************************************************************--%>
    <hr>
    <!-- Container Fluid-->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">
                <asp:Label ID="lbl_Websit_Info" runat="server" Text="إختيار الواحدات التي ستعرض في الموقع العام "></asp:Label>
            </h1>
        </div>

         <div class="row">
            <div class="col-lg-3">
                <div class="form-group">
                    <div class="form-group">
                    <asp:Label ID="lbl_ownership_Name" runat="server" Text="اسم الملكية"></asp:Label>
                     <h4>
                        <asp:DropDownList CssClass="form-control" ID="ownership_Name_DropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ownership_Name_DropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </h4>
                </div>
                </div>
            </div>
            <div class="col-lg-3" ">
                <div class="form-group">
                 <asp:Label ID="lbl_Building_Name" runat="server" Text="اسم البناء "></asp:Label>
                        <asp:DropDownList CssClass="form-control" ID="Building_Name_DropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Building_Name_DropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
            </div>


             <div class="col-lg-3" ">
                 <br />
             <asp:Button ID="Button1" CssClass="form-control" runat="server" OnClick="Button1_Click" BackColor="#52a2da" ForeColor="White" Width="200px" Text="نقل إلى الموقع العام" />
                 </div>
                 </div>
        </div>



        <div class="row">
            <div class="col-lg-12">
                <div class="container-fluid" style="border-style:solid;border-color:#efefef">
                <!-- Simple Tables -->
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                            ForeColor="Black" GridLines="Both">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Unit_Id" runat="server" Text='<%# Bind("Unit_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم الوحدة">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Unit_Number" runat="server" Text='<%# Bind("Unit_Number") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="المساحة">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Unit_Space" runat="server" Text='<%# Bind("Unit_Space") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="النوع">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Unit_Arabic_Type" runat="server" Text='<%# Bind("Unit_Arabic_Type") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="التفاصيل">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Unit_Arabic_Detail" runat="server" Text='<%# Bind("Unit_Arabic_Detail") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="البناء">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Bind("Building_Arabic_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم البناء">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Building_NO" runat="server" Text='<%# Bind("Building_NO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الملكية">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Owner_Ship_AR_Name" runat="server" Text='<%# Bind("Owner_Ship_AR_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم الشارع">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Street_NO" runat="server" Text='<%# Bind("Street_NO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الشارع">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Street_Name" runat="server" Text='<%# Bind("Street_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الطابق">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Floor_Number" runat="server" Text='<%# Bind("Floor_Number") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الصورة الاساسية">
                                    <ItemTemplate>
                                        <asp:Image ID="Image_One_Path_Image" runat="server" ImageUrl='<%# Eval("Image_One_Path") %>' Width="100" Height="100" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Activ" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="City" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Image_One" runat="server" Text='<%# Bind("Image_One") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="City" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Image_Two" runat="server" Text='<%# Bind("Image_Two") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="City" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Image_Three" runat="server" Text='<%# Bind("Image_Three") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="City" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Image_Four" runat="server" Text='<%# Bind("Image_Four") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" ControlStyle-Width="25">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle HorizontalAlign="Center" />
                            <RowStyle Font-Size="15px" />
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#eaecf4" Font-Bold="false" ForeColor="Black" Font-Size="15px" HorizontalAlign="Center" />
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
</asp:Content>
