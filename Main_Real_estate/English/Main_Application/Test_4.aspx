<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Test_4.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Test_4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {

            /*This will hide the icons if there is no URL*/
            /*If there is no files, URL will say "No File"*/
            $('a[href*="No File"]').each(function () {
                $(this).css('display', 'none');
            });
            
            table.buttons().container()
                .appendTo('#DataTables_Table_0_wrapper .col-md-6:eq(0)');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





    <div class="container-fluid" id="container-wrapper">
        <div class="row">
            <div class="col-lg-3 mb-3">
                <h1 class="h3 mb-0 text-gray-800">
                    <asp:Label ID="lbl_titel_Ownership_List" runat="server" Text="عمليات  الملكيات"></asp:Label>
                </h1>
            </div>
            <div class="col-lg-3 mb-3">
                <asp:LinkButton CssClass="btn btn-primary" runat="server" PostBackUrl="~/English/Main_Application/Accordin_Add_Ownership.aspx">
                    <i class="fa fa-plus" style="font-size:25px;"></i> &nbsp; إضافة ملكية جديدة</asp:LinkButton>
            </div>
        </div>


        <table cellspacing="0" style="width: 100%; font-size: 11px; background-color: #53b3b333; color: black" class="datatable table">

            <tr>
                <td>
                    <asp:Label ID="lbl_Zone_NO" runat="server" Text="رقم المنطقة" />
                    <asp:DropDownList ID="Zone_Name_DropDownList" runat="server" CssClass="form-control" DataTextField="Text" AutoPostBack="true" OnSelectedIndexChanged="Zone_Name_DropDownList_SelectedIndexChanged" />
                </td>

                <td>
                    <asp:Label ID="lbl_Ownershi_Code" runat="server" Text="كود الملكية" />
                    <asp:DropDownList ID="Ownershi_Code_DropDownList" runat="server" CssClass="form-control" DataTextField="Text" AutoPostBack="true" OnSelectedIndexChanged="Ownershi_Code_DropDownList_SelectedIndexChanged" />
                </td>

                <td>
                    <asp:Label ID="lbl_wnershi_Name" runat="server" Text="اسم الملكية" />
                    <asp:DropDownList ID="Ownershi_Name_DropDownList" runat="server" CssClass="form-control" DataTextField="Text" AutoPostBack="true" OnSelectedIndexChanged="Ownershi_Name_DropDownList_SelectedIndexChanged" />
                </td>

            </tr>
        </table>

        <hr />
        <asp:Label ID="Quari" runat="server" Visible="false" />





























        <asp:Repeater ID="ownership_List" runat="server" ClientIDMode="Static" OnItemDataBound="ownership_List_ItemDataBound">
            <HeaderTemplate>
                <table cellspacing="0" style="width: 100%; font-size: 8px; background-color: #53b3b333; color: black" class="datatable table">
                    <thead>

                        <th></th>
                        <th>مسلسل</th>
                        <th>المنطقة</th>
                        <th>رمز الملكية </th>
                        <th>اسم الملكية</th>
                        <th>المالك</th>
                        <th>الرقم المساحي</th>
                        <th>المساحة</th>
                        <th>سند الملكية</th>
                        <th>عدد المباني</th>
                        <th>تفصيل العمارات</th>

                        <th runat="server" id="H_Lan_Value">قيمة الأرض</th>

                        <th runat="server" id="H_Onee">الدخل الشهري الإفتراضي</th>
                        <th runat="server" id="H_Two">قيمة المباني</th>
                        <th runat="server" id="H_Three">المحصل السنوي</th>
                        <th runat="server" id="H_Four">العائد الإفتراضي / قيمة المباني</th>
                        <th runat="server" id="H_Five">الإيجار الشهري التعاقدي</th>
                        <th runat="server" id="H_six">الفرق السنوي</th>
                        <th runat="server" id="H_seven">القيمة الكلية</th>
                        <th runat="server" id="H_Eghit">العائد / قيمة العقار</th>
                        <th runat="server" id="H_Nine">الفرق التحصيل</th>




                        <th>مرفقات</th>
                        <th>العنوان</th>
                        <th runat="server" id="H_Add"></th>
                        <th runat="server" id="H_Edit"></th>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr >

                    <td data-toggle="collapse" data-target="#collapse<%# Container.ItemIndex%>name" class="accordion-toggle"> <i class="fa fa-eye" aria-hidden="true"></i> </td>
                    <td>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>

                    <td>
                        <asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("zone_arabic_name") %>' />
                        <asp:Label ID="lbl_Owner_Ship_Id" runat="server" Text='<%# Eval("Owner_Ship_Id") %>' Visible="false" />
                    </td>
                    <td>
                        <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("owner_ship_Code") %>' /></td>
                    <td>
                        <asp:LinkButton ID="lnk_Owner_Ship_AR_Name"  runat="server" CommandArgument='<%# Eval("Owner_Ship_Id") %>' Text='<%# Eval("Owner_Ship_AR_Name") %>' OnClick="lnk_Owner_Ship_AR_Name_Click"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="lbl_Owner_Arabic_name" runat="server" Text='<%# Eval("Owner_Arabic_name") %>' /></td>
                    <td>
                        <asp:Label ID="lbl_PIN_Number" runat="server" Text='<%# Eval("PIN_Number") %>' /></td>
                    <td>
                        <asp:Label ID="lbl_Parcel_Area" runat="server" Text='<%# Eval("Parcel_Area") %>' /></td>


                    <td>
                        <asp:Label ID="lbl_Bond_NO" runat="server" Text='<%# Eval("Bond_NO") %>' /></td>
                    <td>
                        <asp:Label ID="lbl_buildingCount" runat="server" Text='<%# Eval("buildingCount") %>' /></td>
                    <td>
                        <asp:Label ID="lbl_Unit_Type" runat="server" Text='<%# Eval("Unit_Type") %>' /></td>




                    <td runat="server" id="B_Lan_Value" style="background-color: khaki">
                        <asp:Label ID="lbl_Land_Value" runat="server" Text='<%# Eval("Land_Value", "{0:N0}") %>' /></td>



                    <td runat="server" id="B_Onee" style="background-color: khaki">
                        <asp:Label ID="lbl_Onee" runat="server"  Text='<%# Eval("Onee", "{0:N0}") %>' /></td>
                    <td runat="server" id="B_Two" style="background-color: khaki">
                        <asp:Label ID="lbl_Two" runat="server" Text='<%# Eval("Two", "{0:N0}") %>' /></td>
                    <td runat="server" id="B_Three" style="background-color: khaki">
                        <asp:Label ID="lbl_Three" runat="server" Text='<%# Eval("Three", "{0:N0}") %>' /></td>
                    <td runat="server" id="B_Four" style="background-color: khaki">
                        <asp:Label ID="lbl_Four" runat="server" Text='<%# Eval("Four", "{0:N0}") %>' /></td>
                    <td runat="server" id="B_Five" style="background-color: khaki">
                        <asp:Label ID="lbl_Five" runat="server" Text='<%# Eval("Five", "{0:N0}") %>' /></td>

                    <td runat="server" id="B_Six" style="background-color: khaki">
                        <asp:Label ID="lbl_Six" runat="server" Text='<%# Eval("Six", "{0:N0}") %>' /></td>
                    <td runat="server" id="B_Seven" style="background-color: khaki">
                        <asp:Label ID="lbl_Seven" runat="server" Text='<%# Eval("Seven", "{0:N0}") %>' /></td>
                    <td runat="server" id="B_Eghit" style="background-color: khaki">
                        <asp:Label ID="lbl_Eghit" runat="server" Text='<%# Eval("Eghit", "{0:N0}") %>' /></td>
                    <td runat="server" id="B_Nine" style="background-color: khaki">
                        <asp:Label ID="lbl_Nine" runat="server" Text='<%# Eval("Nine", "{0:N0}") %>' /></td>





                    <td>
                        <a href='<%# Eval("owner_ship_Certificate_Image_Path") %>' target="_blank" id="Link_Property_Scheme" style="font-size: 15px;">
                            <i class="fa fa-file-pdf" style="font-size: 20px;"></i>
                        </a>
                        <br />
                        <a href='<%# Eval("Property_Scheme_Image_Path") %>' target="_blank" id="A1" style="font-size: 15px;">
                            <i class="fa fa-file-image" style="font-size: 20px;"></i>
                        </a>
                    </td>

                    <td>
                        <a href='<%# Eval("Mab_Url") %>' target="_blank" id="A4" style="font-size: 8px;">
                            <%--<i class="fa fa-thumb-tack" style="font-size: 20px;"></i>--%>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("zone_arabic_name") %>' />/
                            شارع :
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Street_NO") %>' />
                        </a>
                    </td>


                    <td runat="server" id="B_Add">
                        <asp:LinkButton CssClass="btn btn-primary" runat="server" CommandArgument='<%# Eval("Owner_Ship_Id") %>' OnClick="Add_Building"> <i class="fa fa-plus" style="font-size:18px;"></i> </asp:LinkButton>
                    </td>
                    <td runat="server" id="B_Edit">
                        <asp:LinkButton CssClass="btn btn-success" runat="server" CommandArgument='<%# Eval("Owner_Ship_Id") %>' OnClick="Edit_Ownership"> <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton>

                    </td>
                </tr>
                
                <%--*********************************************************************************************--%>
                <tr>
                    <td colspan="23">
                        <div id="collapse<%# Container.ItemIndex%>name" class="accordian-body collapse">
                            <asp:Repeater ID="building_List" runat="server" ClientIDMode="Static" OnItemDataBound="building_List_ItemDataBound">
                                <HeaderTemplate>
                                    <table cellspacing="0" style="width: 100%; font-size: 8px; background-color: #dbcbb5; color: black" class="datatable table">
                                        <thead>
                                            <th></th>
                                            <th>مسلسل</th>
                                            <th>البناء</th>
                                            <th>رقم البناء</th>
                                            <th>مساحة البناء </th>
                                            <th>وضع الصيانة</th>
                                            <th>اسم الملكية</th>
                                            <th>حالة البناء</th>
                                            <th>نوع البناء</th>
                                            <th>التفاصيل</th>

                                            <th runat="server" id="H_Sum_virtual_Value">الدخل الفرضي</th>
                                            <th runat="server" id="H_Building_Value">قيمة البناء</th>
                                            <th runat="server" id="H_Building_Age">عمر البناء</th>
                                            <th runat="server" id="H_Still_Age">المتبقي تقديراً</th>
                                            <th runat="server" id="H_Annual_Waste">الهالك السنوي </th>
                                            <th runat="server" id="H_Cumulative_Waste">الهالك التراكمي</th>

                                            <th runat="server" id="H_Stiil_Building_Value">قيمة المتبقي</th>


                                            <th runat="server" id="H_Ijar_Taakudy">الإيجار التعاقدي</th>
                                            <th runat="server" id="H_R_NotBook_Still">المتبقي دفترياً</th>
                                            <th runat="server" id="H_Dakhel_FUly">الدخل الفعلي</th>


                                            <th>صورة البناء</th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th runat="server" id="H_Building_Add"></th>
                                            <th runat="server" id="H_Building_Edit"></th>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr >
                                        <td data-toggle="collapse" data-target="#collapse<%# Container.ItemIndex%>Unit" class="accordion-toggle">
                                            <i class="fa fa-eye" aria-hidden="true"></i>
                                        </td>
                                        <td><asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                        <td>

                                            <asp:Label ID="lbl_Building_Id" Visible="false" runat="server" Text='<%# Eval("Building_Id") %>' />

                                            <asp:LinkButton ID="lnk_Building_Arabic_Name"  runat="server" CommandArgument='<%# Eval("Building_Id") %>' Text='<%# Eval("Building_Arabic_Name") %>' OnClick="lnk_Building_Arabic_Name_Click"></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_zone_arabic_name" runat="server" Text='<%# Eval("Building_NO") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("Construction_Area") %>' /></td>

                                        <td>
                                            <asp:Label ID="lbl_PIN_Number" runat="server" Text='<%# Eval("Maintenance_status") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Bond_NO" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Parcel_Area" runat="server" Text='<%# Eval("Building_Arabic_Condition") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Building_Arabic_Type" runat="server" Text='<%# Eval("Building_Arabic_Type") %>' /></td>

                                        <td>
                                        شقة :
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Sum_apartment") %>' />/
                                        مكتب :
                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Sum_Office", "{0:N0}") %>' />/
                                        محل :
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Sum_Stor", "{0:N0}") %>' />
                                        </td>




                                        <td runat="server" id="B_Sum_virtual_Value" style="background-color: khaki">
                                            <asp:Label ID="lbl_Sum_virtual_Value" runat="server" Text='<%# Eval("Sum_virtual_Value") %>' /></td>

                                        <td runat="server" id="B_Building_Value" style="background-color: khaki">
                                            <asp:Label ID="lvl_Building_Value" runat="server" Text='<%# Eval("Building_Value","{0:N0}") %>'/></td>
                                        <td runat="server" id="B_Building_Age" style="background-color: khaki">
                                            <asp:Label ID="lbl_Building_Age" runat="server" Text='<%# Eval("Building_Age") %>' /></td>
                                        <td runat="server" id="B_Still_Age" style="background-color: khaki">
                                            <asp:Label ID="lbl_Still_Age" runat="server" Text='<%# Eval("Still_Age") %>' /></td>
                                        <td runat="server" id="B_Annual_Waste" style="background-color: khaki">
                                            <asp:Label ID="lbl_Annual_Waste" runat="server" Text='<%# Eval("Annual_Waste","{0:N0}") %>' /></td>
                                        <td runat="server" id="B_Cumulative_Waste" style="background-color: khaki">
                                            <asp:Label ID="lbl_Cumulative_Waste" runat="server" Text='<%# Eval("Cumulative_Waste","{0:N0}") %>' /></td>

                                        <td runat="server" id="B_Stiil_Building_Value" style="background-color: khaki">
                                            <asp:Label ID="lbl_Stiil_Building_Value" runat="server" Text='<%# Eval("Still_Building_Value","{0:N0}") %>' /></td>

                                        <td runat="server" id="B_Ijar_Taakudy" style="background-color: khaki">
                                            <asp:Label ID="lbl_Ijar_Taakudy" runat="server" Text='<%# Eval("Ijar_Taakudy","{0:N0}") %>' /></td>
                                        <td runat="server" id="B_R_NotBook_Still" style="background-color: khaki">
                                            <asp:Label ID="lbl_R_NotBook_Still" runat="server" Text='<%# Eval("R_NotBook_Still","{0:N0}") %>' /></td>
                                        <td runat="server" id="B_Dakhel_FUly" style="background-color: khaki">
                                            <asp:Label ID="lbl_Dakhel_FUly" runat="server" Text='<%# Eval("Dakhel_FUly","{0:N0}") %>' /></td>



                                        <td>
                                            <a href='<%# Eval("Building_Photo_Path") %>' target="_blank">
                                                <asp:Image ID="Building_Image" runat="server" ImageUrl='<%# Eval("Building_Photo_Path") %>' Width="80px" Height="80px" />
                                            </a>
                                            <asp:Label ID="lbl_Building_Image" runat="server" Text='<%# Eval("Building_Photo") %>' Visible="false" /></td>
                                        </td>

                                        <td>
                                            <a href='<%# Eval("Building_Permit_Path") %>' target="_blank" id="Link_Building_Permit_Path" style="font-size: 11px;">
                                                <i class="fa fa-file-image" style="font-size: 11px;"></i>
                                                <asp:Label ID="Label10" runat="server" Text="رخصة بناء"></asp:Label>
                                            </a>
                                        </td>
                                        <td>
                                            <a href='<%# Eval("certificate_of_completion_Path") %>' target="_blank" id="Link_certificate_of_completion_Path" style="font-size: 11px;">
                                                <i class="fa fa-file-pdf" style="font-size: 11px;"></i>
                                                <asp:Label ID="Label1" runat="server" Text="شهادة إتمام"></asp:Label>
                                            </a>
                                        </td>
                                        <td>
                                            <a href='<%# Eval("Map_path") %>' target="_blank" id="Link_Map_path" style="font-size: 11px;">
                                                <i class="fa fa-file-image" style="font-size: 11px;"></i>
                                                <asp:Label ID="Label2" runat="server" Text="خرائط"></asp:Label>
                                            </a>
                                        </td>

                                        <td runat="server" id="B_Building_Add">
                                            <asp:LinkButton CssClass="btn btn-primary" runat="server" CommandArgument='<%# Eval("Building_Id") %>' OnClick="Add_Unit"> <i class="fa fa-plus" style="font-size:18px;"></i> </asp:LinkButton></td>
                                        <td runat="server" id="B_Building_Edit">
                                            <asp:LinkButton CssClass="btn btn-success" runat="server" CommandArgument='<%# Eval("Building_Id") %>' OnClick="Edit_Building"> <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton></td>

                                    </tr>


                                    <%--*********************************************************************************************--%>
                                    <tr>
                                        <td colspan="24">
                                            <div id="collapse<%# Container.ItemIndex%>Unit" class="accordian-body collapse">






                                                <asp:Repeater ID="Units_List" runat="server" ClientIDMode="Static" OnItemDataBound="Units_List_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <table cellspacing="0" style="width: 100%; font-size: 8px; background-color: #afcd80; color: black" class="datatable table">
                                                            <thead>
                                                                <th>مسلسل</th>
                                                                <th>نوع الوحدة</th>
                                                                <th>رقم الطابق </th>
                                                                <th>رقم الوحدة</th>
                                                                <th>مساحة الوحدة</th>
                                                                <th>تفاصيل الوحدة</th>
                                                                <th>وضع الصيانة</th>
                                                                <th>الحالة الإيجارية</th>
                                                                <th>القيمة الإفتراضية</th>
                                                                <th runat="server" id="H_Unit_Edit"></th>

                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Unit_Arabic_Type" runat="server" Text='<%# Eval("Unit_Arabic_Type") %>' /></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Floor_Number" runat="server" Text='<%# Eval("Floor_Number") %>' /></td>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_Unit_Number"  runat="server" CommandArgument='<%# Eval("Unit_ID") %>' Text='<%# Eval("Unit_Number") %>' OnClick="lnk_Unit_Number_Click"></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_Unit_Space" runat="server" Text='<%# Eval("Unit_Space") %>' /></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Unit_Arabic_Detail" runat="server" Text='<%# Eval("Unit_Arabic_Detail") %>' /></td>
                                                             <td>
                                                                <asp:Label ID="lbl_current_situation" runat="server" Text='<%# Eval("current_situation") %>' /></td>
                                                            <td>
                                                                <asp:Label ID="lbl_Unit_Arabic_Condition" runat="server" Text='<%# Eval("Unit_Arabic_Condition") %>' /></td>
                                                            
                                                            <td style="background-color: khaki">
                                                                <asp:Label ID="lbl_virtual_Value" runat="server" Text='<%# Eval("virtual_Value","{0:N0}") %>' /></td>
                                                            
                                                            <td runat="server" id="B_Unit_Edit">
                                                                <asp:LinkButton CssClass="btn btn-success" runat="server" CommandArgument='<%# Eval("Unit_ID") %>' OnClick="Edit_Unit"> <i class="fa fa-pencil" style="font-size:18px;"></i> </asp:LinkButton></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody>
                                                         </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>









                                            </div>
                                        </td>
                                    </tr>
                                    <%--*********************************************************************************************--%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                            </table>
                                </FooterTemplate>
                            </asp:Repeater>









                        </div>
                    </td>
                </tr>
                <%--*********************************************************************************************--%>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
