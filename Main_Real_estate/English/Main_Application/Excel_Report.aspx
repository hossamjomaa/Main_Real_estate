<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Excel_Report.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Excel_Report" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register TagPrefix="ej" Namespace="Syncfusion.JavaScript.DataVisualization.Models" Assembly="Syncfusion.EJ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {

            /*This will hide the icons if there is no URL*/
            /*If there is no files, URL will say "No File"*/
            $('a[href*="No File"]').each(function () {
                $(this).css('display', 'none');
            });


        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            font-size: 13px;
        }

         th {
            border: 1px solid #dddddd;
            text-align: center;
            background-color:#52a2da;
            color:white;
            font-weight: bold;
            padding: 10px !important;
        }
         td{
             border: 1px solid #dddddd;
            text-align: center;
            padding: 10px !important;
         }
        
         .Indicator_buttons{
            border-radius:50px;
            border-style: solid; 
            border-radius: 50px; 
            width: 20px; 
            margin-right: 20px; 
            margin-top: 20px; 
            height: 20px; 
        }
        .card .table th {
            padding-left: 2px;
            padding-right: 11px;
            text-align: center;
            font-size: 13px;
        }


        #Unit table {
            border-collapse: collapse;
            width: 100%;
        }

         #Unit td, th {
            border: 1px solid #dddddd;
            text-align: center;
            padding: 8px;
        }

         #Unit tr:nth-child(even) {
            background-color: #dddddd;
        }
       
    </style>
    



    <div class="container-fluid" id="container-wrapper" style="margin: auto;">
        <div class="row">
            <div class="col-lg-8">
                <div class="form-group">
                    <asp:Label ID="lbl_Ownership_Name" runat="server" Text="اسم الملكية"></asp:Label>
                    <asp:DropDownList ID="Ownershi_Name_DropDownList" runat="server" CssClass="form-control" DataTextField="Text" AutoPostBack="true" OnSelectedIndexChanged="Ownership_Name_DropDownList_SelectedIndexChanged" />
                </div>
            </div>

            <div class="col-lg-4" runat="server" id="Chart_Div" visible="false">
                <div class="row" style="margin-top: -45px; padding-right: 105px">
                    <ej:WaitingPopup runat="server" ID="waitingpopup3" ShowOnInit="false"></ej:WaitingPopup>
                    <ej:Chart runat="server" ID="Unit_Status_Char" Enable3D="True" IsResponsive="True" OnClientDisplayTextRendering="textRendering">
                        <size width="200" height="150"></size>
                        <Legend Visible="True" Position="Left" Alignment="Center" EnableScrollbar="False"></Legend>
                        <CommonSeriesOptions LabelPosition="Inside">
                            <Tooltip Visible="false" Format="#point.x# : #point.y# " />
                        </CommonSeriesOptions>
                        <Series>
                            <ej:Series Type="Pie" Width="970" LabelPosition="Outside" PieCoefficient="0.7" StartAngle="145" ExplodeIndex="0" Fill="Pie">
                                <Border Width="2" Color="White" />
                            </ej:Series>
                        </Series>
                        <Legend Position="Left" Visible="false"></Legend>
                    </ej:Chart>
                </div>
                <div class="row" style="margin-top: -40px; margin-bottom: 11px">
                    <asp:Button ID="Undermaintenance" runat="server" CssClass="Indicator_buttons" BackColor="#6faab0" Enabled="false"/>
                    &nbsp;
                                <span style="margin-top: 20px">إنشاء/صيانة</span>
                    &nbsp;&nbsp;
                                <asp:Button ID="Available" runat="server" CssClass="Indicator_buttons" BackColor="#e94649" Enabled="false"/>
                    &nbsp;
                                <span style="margin-top: 20px">شاغر</span>
                    &nbsp;&nbsp;
                                <asp:Button ID="UnderProplem" runat="server" CssClass="Indicator_buttons" BackColor="#c4c24a" Enabled="false"/>
                    &nbsp;
                                <span style="margin-top: 20px">نزاع</span>
                    &nbsp;&nbsp;
                                <asp:Button ID="Rented" runat="server" CssClass="Indicator_buttons" BackColor="#f6b53f" Enabled="false"/>
                    &nbsp;
                                <span style="margin-top: 20px">مؤجر</span>
                </div>


            </div>
        </div>
        <%---------------------------------------------------------------------------------------%>
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-10">
                    <div class="card-body">

                        <asp:Repeater ID="ownership_List" runat="server" ClientIDMode="Static">
                            <ItemTemplate>
                                <table cellspacing="0" style="width: 100%;" class="datatable table">
                                    <tr>
                                        <th  >المنطقة</th>
                                        <th  >رمز الملكية</th>
                                        <th  >اسم الملكية</th>
                                        <th  colspan="1">المالك</th>
                                        <th  >الرقم المساحي</th>
                                        <th  >المساحة</th>
                                        <th  >السند</th>
                                        <th  >رقم الشارع</th>
                                        <th  >عدد المباني</th>
                                        <th  colspan="3">تفصيل العمارات</th>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("zone_arabic_name") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("owner_ship_Code") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Ownership_Arabic_name" runat="server" Text='<%# Eval("Owner_Ship_AR_Name") %>' /></td>
                                        <td colspan="1">
                                            <asp:Label ID="lbl_Owner_Arabic_name" runat="server" Text='<%# Eval("Owner_Arabic_name") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_PIN_Number" runat="server" Text='<%# Eval("PIN_Number") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Parcel_Area" runat="server" Text='<%# Eval("Parcel_Area") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Bond_NO" runat="server" Text='<%# Eval("Bond_NO") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Street_No" runat="server" Text='<%# Eval("Street_NO") %>' /></td>
                                        <td >
                                            <asp:Label ID="lbl_buildingCount" runat="server" Text='<%# Eval("buildingCount") %>' /></td>
                                        <td colspan="3">
                                            <asp:Label ID="lbl_Unit_Type" runat="server" Text='<%# Eval("Unit_Type") %>' /></td>
                                    </tr>

                                    <tr>
                                        <th  >قيمة الأرض</th>
                                        <th  >قيمة المباني</th>
                                        <th  >القيمة الكلية</th>
                                        <th  >الدخل الشهري الافتراضي</th>
                                        <th  >الإيجار الشهري التعاقدي</th>
                                        <th  >الفرق السنوي</th>
                                        <th  >المحصل السنوي</th>
                                        <th  >فرق التحصيل </th>
                                        <th  >العائد الافتراضي / قيمة المباني </th>
                                        <th  >العائد/ قيمة العقار</th>
                                        <th  >الإسترداد</th>
                                        <th  >تحديث السند</th>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Land_Value" runat="server" Text='<%# String.Format("{0:###,###,####}",Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Land_Value")))%>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Two" runat="server" Text='<%# Eval("Two", "{0:N0}") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Seven" runat="server" Text='<%# Eval("Seven", "{0:N0}") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Onee" runat="server" Text='<%# Eval("Onee", "{0:N0}") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Five" runat="server" Text='<%# Eval("Five", "{0:N0}") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Six" runat="server" Text='<%# Eval("Six", "{0:N0}") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Three" runat="server" Text='<%# Eval("Three", "{0:N0}") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Nine" runat="server" Text='<%# Eval("Nine", "{0:N0}") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Four" runat="server" Text='<%# Eval("Four", "{0:N0}") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Eghit" runat="server" Text='<%# Eval("Eghit", "{0:N0}") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Ten" runat="server" Text='<%# Eval("Eghit", "{0:N0}") %>' /></td>
                                        <td>
                                            <asp:Label ID="lbl_Bond_Date" runat="server" Text='<%# Eval("Bond_Date") %>' /></td>
                                    </tr>



                                    <tr>
                                        <th colspan="3"  >وضع الرهن</th>
                                        <th colspan="2"  >قيمة الرهن</th>
                                        <th colspan="2"  >قيمة القسط</th>
                                        <th colspan="2"  >المسدد</th>
                                        <th colspan="1"  >المتبقي</th>
                                        <th colspan="1"  >الزمن المتبقي</th>
                                        <th colspan="2"  >تاريخ التحرير</th>

                                    </tr>

                                    <tr>
                                        <td colspan="3">مرهون إلى :<asp:Label ID="lbl_Bank_Arabic_Name" runat="server" Text='<%# Eval("Bank_Arabic_Name", "{0:N0}") %>' /></td>
                                        <td colspan="2">
                                            <asp:Label ID="lbl_Mortgage_Value" runat="server" Text='<%# Eval("Mortgage_Value", "{0:N0}") %>' /></td>
                                        <td colspan="2">
                                            <asp:Label ID="lbl_Installment_Value" runat="server" Text='<%# Eval("Installment_Value", "{0:N0}") %>' /></td>
                                        <td colspan="2">
                                            <asp:Label ID="lbl_Amount_Paid" runat="server" Text='<%# Eval("Amount_Paid", "{0:N0}") %>' /></td>
                                        <td colspan="1">
                                            <asp:Label ID="lbl_Remaining_Amount" runat="server" Text='<%# Eval("Remaining_Amount", "{0:N0}") %>' /></td>
                                        <td colspan="1">
                                            <asp:Label ID="lbl_Remaining_Time" runat="server" Text='<%# Eval("Remaining_Time", "{0:N0}") %>' /></td>
                                        <td colspan="2">
                                            <asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>' /></td>
                                    </tr>



                                     <tr>
                                        <th colspan="4"  >سند الملكية</th>
                                        <th colspan="4"  >المخطط</th>
                                        <th colspan="4"  >الإفادة</th>
                                    </tr>

                                    <tr >
                                        <td colspan="4">
                                            <a href='<%# Eval("owner_ship_Certificate_Image_Path") %>' target="_blank" id="owner_ship_Certificate_Image_Path" style="font-size: 13px;">
                                                <i class="fa fa-file-image" style="font-size: 13px;"></i>
                                                <asp:Label ID="Label10" runat="server" Text="سند الملكية"></asp:Label>
                                            </a>
                                        </td>
                                        <td colspan="4">
                                            <a href='<%# Eval("Property_Scheme_Image_Path") %>' target="_blank" id="Property_Scheme_Image_Path" style="font-size: 13px;">
                                                <i class="fa fa-file-image" style="font-size: 13px;"></i>
                                                <asp:Label ID="Label12" runat="server" Text="سند الملكية"></asp:Label>
                                            </a>
                                        </td>
                                        <td colspan="4">
                                            <a href='<%# Eval("Statment_Id") %>' target="_blank" id="Statment_Id" style="font-size: 13px;">
                                                <i class="fa fa-file-image" style="font-size: 13px;"></i>
                                                <asp:Label ID="Label13" runat="server" Text="الإفادة"></asp:Label>
                                            </a>
                                        </td>
                                    </tr>




                                    <tr data-toggle="collapse" data-target="#collapse<%# Container.ItemIndex%>name" class="accordion-toggle">
                                        <td colspan="12">المباني
                                            <i class="fa fa-eye" aria-hidden="true" style="font-size: 13px"></i>
                                            الموجودة
                                        </td>

                                    </tr>


                                    <tr>
                                        <td colspan="12" style="padding-left: 0.5rem; padding-right: 0.5rem;">
                                            <div id="collapse<%# Container.ItemIndex%>name" class="accordian-body collapse">
                                                <asp:Repeater ID="building_List" runat="server" ClientIDMode="Static">
                                                    <ItemTemplate>
                                                        <table cellspacing="0" style=" width:-1px" class="datatable table">
                                                            <tr>
                                                                <th colspan="2"  >رقم المبنى</th>
                                                                <th colspan="2"  >اسم المبنى</th>
                                                                <th colspan="2"  >نوع المبنى</th>
                                                                <th colspan="2"  >مساحة البناء</th>
                                                                <th colspan="2"  >نوعية الوحدات</th>
                                                                <th colspan="2"  >تاريخ الإتمام</th>
                                                                <th colspan="2"  >عداد الكهرباء</th>
                                                                <th colspan="1"  >عداد الماء</th>
                                                            </tr>
                                                            <tr> 
                                                                <td colspan="2">
                                                                    <asp:Label ID="lbl_zone_arabic_name" runat="server" Text='<%# Eval("Building_NO") %>' /></td>
                                                                <asp:Label ID="lbl_Building_Id" runat="server" Text='<%# Eval("Building_Id") %>' Visible="false" /></td>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lbl_Building_Arabic_Name" runat="server" Text='<%# Eval("Building_Arabic_Name") %>' /></td>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lbl_Building_Arabic_Type" runat="server" Text='<%# Eval("Building_Arabic_Type") %>' /></td>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("Construction_Area") %>' /></td>
                                                                <td colspan="2">شقة :
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Sum_apartment") %>' />/
                                                                مكتب :
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Sum_Office", "{0:N0}") %>' />/
                                                                محل :
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Sum_Stor", "{0:N0}") %>' />
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lbl_Construction_Completion_Date" runat="server" Text='<%# Eval("Construction_Completion_Date") %>' /></td>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lbl_electricity_meter" runat="server" Text='<%# Eval("electricity_meter") %>' /></td>
                                                                <td colspan="1">
                                                                    <asp:Label ID="lbl_Water_meter" runat="server" Text='<%# Eval("Water_meter") %>' /></td>
                                                            </tr>


                                                                <th  >العمر الحالي</th>
                                                                <th  >حالة البناء</th>
                                                                <th  >قيمة البناء</th>
                                                                <th  >هالك سنوي</th>
                                                                <th  >هالك تراكمي</th>
                                                                <th  >الدخل الفرضي</th>
                                                                <th  >المتبقي دفترياً</th>
                                                                <th  >المتبقي تقديرياً</th>
                                                                <th  >قيمة المتبقي</th>
                                                                <th  >الدخل الفعلي</th>
                                                                <th  >الإيجار التعاقدي</th>
                                                                <th  >عدد الوحدات المؤجرة</th>
                                                                <th  >عدد الوحدات الشاغرة</th>
                                                                <th  >عدد الوحدات تحت الإنشاء او الصيانة</th>
                                                                <th  >عدد حالات النزاع</th>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lbl_Building_Age" runat="server" Text='<%# Eval("Building_Age") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Parcel_Area" runat="server" Text='<%# Eval("Building_Arabic_Condition") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lvl_Building_Value" runat="server" Text='<%# Eval("Building_Value","{0:N0}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Annual_Waste" runat="server" Text='<%# Eval("Annual_Waste","{0:N0}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Cumulative_Waste" runat="server" Text='<%# Eval("Cumulative_Waste","{0:N0}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Sum_virtual_Value" runat="server" Text='<%# Eval("Sum_virtual_Value") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_R_NotBook_Still" runat="server" Text='<%# Eval("R_NotBook_Still","{0:N0}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Still_Age" runat="server" Text='<%# Eval("Still_Age") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Stiil_Building_Value" runat="server" Text='<%# Eval("Still_Building_Value","{0:N0}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Dakhel_FUly" runat="server" Text='<%# Eval("Dakhel_FUly","{0:N0}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Ijar_Taakudy" runat="server" Text='<%# Eval("Ijar_Taakudy","{0:N0}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Moajar" runat="server" Text='<%# Eval("Moajar","{0:N0}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Shagher" runat="server" Text='<%# Eval("Shagher","{0:N0}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Insha_Siana" runat="server" Text='<%# Eval("Insha_Siana","{0:N0}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_NeZaa" runat="server" Text='<%# Eval("NeZaa","{0:N0}") %>' /></td>
                                                            </tr>


                                                            <tr>
                                                                <th colspan="5">صورة البناء</th>
                                                                <th colspan="5">صورة المدخل</th>
                                                                <th colspan="5">مسقط أفقي</th>
                                                                
                                                            </tr>

                                                            <tr>
                                                                <td colspan="5">
                                                                    <a href='<%# Eval("Building_Photo_Path") %>' target="_blank">
                                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Building_Photo_Path") %>' Width="100px" Height="100px" />
                                                                    </a>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Building_Photo") %>' Visible="false" />
                                                                </td>

                                                                <td colspan="5">
                                                                    <a href='<%# Eval("Entrance_Photo_Path") %>' target="_blank">
                                                                        <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("Entrance_Photo_Path") %>' Width="100px" Height="100px" />
                                                                    </a>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Entrance_Photo") %>' Visible="false" />
                                                                </td>

                                                                <td colspan="5">
                                                                    <a href='<%# Eval("Plano_Path") %>' target="_blank">
                                                                        <asp:Image ID="Image3" runat="server" ImageUrl='<%# Eval("Plano_Path") %>' Width="100px" Height="100px" />
                                                                    </a>
                                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Plan") %>' Visible="false" />
                                                                </td>

                                                            </tr>


                                                            <tr>
                                                                <th colspan="5">رخص البناء</th>
                                                                <th colspan="5">شهادة الإتمام</th>
                                                                <th colspan="5">خرائط</th>
                                                            </tr>

                                                            <tr>
                                                                <td colspan="5">
                                                                    <a href='<%# Eval("Building_Permit_Path") %>' target="_blank" id="Link_Building_Permit_Path" style="font-size: 13px;">
                                                                        <i class="fa fa-file-image" style="font-size: 13px;"></i>
                                                                        <asp:Label ID="Label10" runat="server" Text="رخصة بناء"></asp:Label>
                                                                    </a>
                                                                </td>

                                                                <td colspan="5">
                                                                    <a href='<%# Eval("certificate_of_completion_Path") %>' target="_blank" id="Link_certificate_of_completion_Path" style="font-size: 13px;">
                                                                        <i class="fa fa-file-pdf" style="font-size: 13px;"></i>
                                                                        <asp:Label ID="Label7" runat="server" Text="شهادة إتمام"></asp:Label>
                                                                    </a>
                                                                </td>

                                                                <td colspan="5">
                                                                    <a href='<%# Eval("Map_path") %>' target="_blank" id="Link_Map_path" style="font-size: 13px;">
                                                                        <i class="fa fa-file-image" style="font-size: 13px;"></i>
                                                                        <asp:Label ID="Label8" runat="server" Text="خرائط"></asp:Label>
                                                                    </a>
                                                                </td>
                                                            </tr>



                                                            <tr data-toggle="collapse" data-target="#collapse<%# Container.ItemIndex%>Unit" class="accordion-toggle">
                                                                <td colspan="17">الوحدات
                                                                    <i class="fa fa-eye" aria-hidden="true" style="font-size: 15px"></i>
                                                                    الموجودة
                                                                </td>

                                                            </tr>



                                                            <tr>
                                                                <td colspan="17" style="padding-left: 0.5rem; padding-right: 0.5rem; width:-1px">
                                                                    <div id="collapse<%# Container.ItemIndex%>Unit" class="accordian-body collapse">

                                                                        <asp:Repeater ID="Units_List" runat="server" ClientIDMode="Static" OnItemDataBound="Units_List_ItemDataBound">
                                                                            <HeaderTemplate>
                                                                                <table cellspacing="0"   id="Unit">
                                                                                    <thead>
                                                                                        <th colspan="6" >نوع الوحدة </th>
                                                                                        <th  colspan="6"> رقم الوحدة<hr /> رقم الطابق</th>
                                                                                        <th  colspan="6">مساحة الوحدة</th>
                                                                                        <th colspan="6" >تفاصيل الوحدة</th>
                                                                                        <th  colspan="6">عداد الكهرباء <hr /> عداد الماء</th>
                                                                                        <th  colspan="6">الحالة الإيجارية</th>
                                                                                        <th colspan="6">المستأجر</th>
                                                                                        <th colspan="6">العقد</th>
                                                                                        <th  colspan="6">بداية العقد</th>
                                                                                        <th  colspan="6">نهاية العقد</th>
                                                                                        <th  colspan="6">الإيجار الفرضي</th>
                                                                                        <th colspan="6" >الإيجار التعاقدي</th>
                                                                                        <th colspan="6">المحصل المفترض</th>
                                                                                        <th  colspan="6">المحصل الفعلي</th>
                                                                                        <th  colspan="6">تصنيف المستأجر</th>
                                                                                        <th  colspan="5">طريقة السداد</th>
                                                                                    </thead>
                                                                                    <tbody>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <tr >
                                                                                    <td  colspan="6" >
                                                                                        <asp:Label ID="lbl_Unit_Arabic_Type" runat="server" Text='<%# Eval("Unit_Arabic_Type") %>' />
                                                                                    </td>
                                                                                    
                                                                                    <td  colspan="6">
                                                                                        <asp:Label ID="lbl_Unit_Number" runat="server" Text='<%# Eval("Unit_Number") %>' /><hr />
                                                                                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("Floor_Number") %>' />
                                                                                    </td>
                                                                                    
                                                                                    <td  colspan="6">
                                                                                        <asp:Label ID="lbl_Unit_Space" runat="server" Text='<%# Eval("Unit_Space") %>' /></td>
                                                                                    
                                                                                    <td  colspan="6">
                                                                                        <asp:Label ID="lbl_Unit_Arabic_Detail" runat="server" Text='<%# Eval("Unit_Arabic_Detail") %>' /></td>
                                                                                    
                                                                                    <td  colspan="6">
                                                                                        <asp:Label ID="lbl_Electricityt_Number" runat="server" Text='<%# Eval("Electricityt_Number") %>' /><hr />
                                                                                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("Water_Number") %>' />
                                                                                    </td>
                                                                                    
                                                                                    <td  colspan="6">
                                                                                        <asp:Label ID="lbl_Unit_Arabic_Condition" runat="server" Text='<%# Eval("Unit_Arabic_Condition") %>' /></td>





                                                                                    <td colspan="6">
                                                                                        <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>' /></td>
                                                                                    <td colspan="6">
                                                                                        <asp:LinkButton ID="lnk_Contract_Id"  runat="server" CommandArgument='<%# Eval("Contract_Id") %>' Text="رابط العقد" OnClick="lnk_Contract_Id_Click"></asp:LinkButton>
                                                                                        <asp:Label ID="lbl_Contract_Id" runat="server" Text='<%# Eval("Contract_Id") %>' Visible="false"/>
                                                                                    </td>
                                                                                    <td  colspan="6">
                                                                                        <asp:Label ID="lbl_Start_Date" runat="server" Text='<%# Eval("Start_Date") %>' /></td>
                                                                                    <td  colspan="6">
                                                                                        <asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>' /></td>








                                                                                    <td colspan="6">
                                                                                        <asp:Label ID="lbl_virtual_Value" runat="server" Text='<%# Eval("virtual_Value","{0:N0}") %>' /> </td>


                                                                                    <td colspan="6">
                                                                                        <asp:Label ID="lbl_Payment_Amount" runat="server" Text='<%# Eval("Payment_Amount","{0:N0}") %>' /> </td>
                                                                                    <td colspan="6">
                                                                                        <asp:Label ID="lbl_Muhasal_Muftarad" runat="server" Text='<%# Eval("Muhasal_Muftarad","{0:N0}") %>' /> </td>
                                                                                    <td  colspan="6">
                                                                                        <asp:Label ID="lbl_Muhasal_Fuly" runat="server" Text='<%# Eval("Muhasal_Fuly","{0:N0}") %>' /> </td>

                                                                                    
                                                                                    <td  colspan="6">
                                                                                        <asp:Label ID="Label15" runat="server" Text='<%# Eval("Persenteg") %>' /> %</td>


                                                                                     <td  colspan="6">
                                                                                        <asp:Label ID="lbl_Com_rep_En_Name" runat="server" Text='<%# Eval("Paymen_Method") %>' /> </td>
                                                                                    
                                                                                    
                                                                                    
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














                                                        </table>
                                                        <br />
                                                        <div style="border-style: solid"></div>
                                                        <br />
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </td>
                                    </tr>




















                                </table>
                            </ItemTemplate>
                        </asp:Repeater>


                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
