<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Excel_report_New.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Excel_report_New" %>

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

        th  {
            border: 1px solid #dddddd;
            text-align: center;
            background-color: #52a2da;
            color: white;
            padding: 8px !important;
        }

        td {
            border: 1px solid #dddddd;
            text-align: center;
            padding: 8px !important;
        }

        .Indicator_buttons {
            border-radius: 50px;
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
            font-size: 11px;
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
        .Ownership th{
            background-color: #52a2da;
        }
        .Building th{
             background-color: #Dfeef8;
             color:black;
        }
        .Unit th{
            background-color: #f0f0f3;
             color:black;
        }
    </style>





    <div class="container-fluid" id="container-wrapper" style="padding:10px">
        <div class="table-responsive" id="Grid" >
        <asp:Repeater ID="ownership_List" runat="server" ClientIDMode="Static">
            <HeaderTemplate>
                <table cellspacing="0" style="width: 100%" class="datatable table table-striped table-bordered Ownership">
                    <thead >
                        <th>م</th>
                        <th><i class="fa fa-eye" aria-hidden="true" style="font-size: 9px"></i></th>
                        <th>المنطقة</th>
                        <th>رمز الملكية</th>
                        <th>اسم الملكية</th>
                        <th>المالك</th>
                        <th>الرقم المساحي</th>
                        <th>المساحة</th>
                        <th>السند</th>
                        <th>رقم الشارع</th>
                        <th>عدد المباني</th>
                        <th>تفصيل العمارات</th>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="background-color: white">
                    <td>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                    <td data-toggle="collapse" data-target="#collapse<%# Container.ItemIndex%>name" class="accordion-toggle"><i class="fa fa-eye" aria-hidden="true" style="font-size: 9px"></i></td>
                    <td>
                        <asp:Label ID="lbl_zone_number" runat="server" Text='<%# Eval("zone_arabic_name") %>' /></td>
                    <td>
                        <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("owner_ship_Code") %>' />
                        <asp:Label ID="lbl_Owner_Ship_Id" runat="server" Visible="false" Text='<%# Eval("Owner_Ship_Id") %>' />
                    </td>

                    <td>
                        <asp:LinkButton ID="lbl_Ownership_Arabic_name" Text='<%# Eval("Owner_Ship_AR_Name") %>'  runat="server" CommandArgument='<%# Eval("Owner_Ship_Id") %>' OnClick="lbl_Ownership_Arabic_name_Click" ></asp:LinkButton>

                    </td>

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
                    <td>
                        <asp:Label ID="lbl_buildingCount" runat="server" Text='<%# Eval("buildingCount") %>' /></td>
                    <td colspan="3">
                        <asp:Label ID="lbl_Unit_Type" runat="server" Text='<%# Eval("Unit_Type") %>' /></td>
                </tr>

                <tr id="collapse<%# Container.ItemIndex%>name" class="accordian-body collapse">
                    <td colspan="12">
                        <table style="font-size: 10px">
                            <tr>
                                <th>قيمة الأرض</th>
                                <th>قيمة المباني</th>
                                <th>القيمة الكلية</th>
                                <th>الدخل الشهري الافتراضي</th>
                                <th>الإيجارالشهري التعاقدي</th>
                                <th>الفرق السنوي</th>
                                <th>المحصل السنوي</th>
                                <th>فرق التحصيل </th>
                                <th>العائدالافتراضي / قيمة المباني </th>
                                <th>العائد/ قيمة العقار</th>
                                <th>الإسترداد</th>
                                <th>تحديث السند</th>
                            </tr>

                            <tr style="background-color: white; color:red">
                                <td>
                                    <asp:Label ID="lbl_Land_Value" runat="server" Text='<%# Eval("Land_Value", "{0:N0}") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Two" runat="server" Text='<%# Eval("Two", "{0:N0}") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Seven" runat="server" Text='<%# Eval("Seven", "{0:N0}") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Onee" runat="server" Text='<%# Eval("Onee", "{0:N0}") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Five" runat="server" Text='<%# Eval("Five", "{0:N3}") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Six" runat="server" Text='<%# Eval("Six", "{0:N0}") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Three" runat="server" Text='<%# Eval("Three", "{0:N0}") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Nine" runat="server" Text='<%# Eval("Nine", "{0:N0}") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Four" runat="server" Text='<%# Eval("Four", "{0:N3}") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Eghit" runat="server" Text='<%# Eval("Eghit", "{0:N3}") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Ten" runat="server" Text='<%# Eval("Ten", "{0:N3}") %>' /></td>
                                <td>
                                    <asp:Label ID="lbl_Bond_Date" runat="server" Text='<%# Eval("Bond_Date") %>' /></td>
                            </tr>
                            <tr>
                                <th colspan="3">وضع الرهن</th>
                                <th colspan="2">قيمة الرهن</th>
                                <th colspan="2">قيمة القسط</th>
                                <th colspan="2">المسدد</th>
                                <th colspan="1">المتبقي</th>
                                <th colspan="1">الزمن المتبقي</th>
                                <th colspan="2">تاريخ التحرير</th>

                            </tr>

                            <tr style="background-color: white ; color:green">
                                <td colspan="3">مرهون إلى :<asp:Label ID="lbl_Bank_Arabic_Name" runat="server" Text='<%# Eval("Bank_Arabic_Name", "{0:N0}") %>' /></td>
                                <td colspan="2">
                                    <asp:Label ID="lbl_Mortgage_Value" runat="server" Text='<%# Eval("Mortgage_Value", "{0:N0}") %>' /></td>
                                <td colspan="2">
                                    <asp:Label ID="lbl_Installment_Value" runat="server" Text='<%# Eval("Installment_Value", "{0:N3}") %>' /></td>
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
                                <th colspan="4">سند الملكية</th>
                                <th colspan="4">المخطط</th>
                                <th colspan="4">الإفادة</th>
                            </tr>

                            <tr>
                                <td colspan="4">
                                    <a href='<%# Eval("owner_ship_Certificate_Image_Path") %>' target="_blank" id="owner_ship_Certificate_Image_Path" style="font-size: 11px;">
                                        <i class="fa fa-file-image" style="font-size: 11px;"></i>
                                        <asp:Label ID="Label10" runat="server" Text="سند الملكية"></asp:Label>
                                    </a>
                                </td>
                                <td colspan="4">
                                    <a href='<%# Eval("Property_Scheme_Image_Path") %>' target="_blank" id="Property_Scheme_Image_Path" style="font-size: 11px;">
                                        <i class="fa fa-file-image" style="font-size: 11px;"></i>
                                        <asp:Label ID="Label12" runat="server" Text="سند الملكية"></asp:Label>
                                    </a>
                                </td>
                                <td colspan="4">
                                    <a href='<%# Eval("Statment_Id") %>' target="_blank" id="Statment_Id" style="font-size: 11px;">
                                        <i class="fa fa-file-image" style="font-size: 11px;"></i>
                                        <asp:Label ID="Label13" runat="server" Text="الإفادة"></asp:Label>
                                    </a>
                                </td>
                            </tr>
                            <tr data-toggle="collapse" data-target="#collapse<%# Container.ItemIndex%>Building" class="accordion-toggle">
                                <td colspan="12">المباني <i class="fa fa-eye" aria-hidden="true" style="font-size: 15px"></i>الموجودة </td>
                            </tr>
                            <tr id="collapse<%# Container.ItemIndex%>Building" class="accordian-body collapse">
                                <td colspan="12">
                                    <asp:Repeater ID="building_List" runat="server" ClientIDMode="Static">
                                        <HeaderTemplate>
                                            <table cellspacing="0" style="width: 100%; font-size: 11px" class="datatable table table-striped table-bordered Building">
                                                <thead>
                                                    <th>م</th>
                                                    <th><i class="fa fa-eye" aria-hidden="true" style="font-size: 9px"></i></th>
                                                    <th>رقم المبنى</th>
                                                    <th>اسم المبنى</th>
                                                    <th>نوع المبنى</th>
                                                    <th>مساحة البناء</th>
                                                    <th>نوعية الوحدات</th>
                                                    <th>تاريخ الإتمام</th>
                                                    <th>عداد الكهرباء</th>
                                                    <th>عداد الماء</th>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr style="background-color: white">
                                                <td>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                                <td data-toggle="collapse" data-target="#collapse<%# Eval("Building_Id")%>Building_Two" class="accordion-toggle"><i class="fa fa-eye" aria-hidden="true" style="font-size: 9px"></i></td>

                                                <td>
                                                    <asp:Label ID="lbl_zone_arabic_name" runat="server" Text='<%# Eval("Building_NO") %>' />
                                                    <asp:Label ID="lbl_Building_Id" runat="server" Text='<%# Eval("Building_Id") %>' Visible="false" />
                                                </td>

                                                <td>
                                                    <asp:LinkButton ID="lbl_Building_Arabic_Name" Text='<%# Eval("Building_Arabic_Name") %>'  runat="server" CommandArgument='<%# Eval("Building_Id") %>' OnClick="lbl_Building_Arabic_Name_Click" ></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Building_Arabic_Type" runat="server" Text='<%# Eval("Building_Arabic_Type") %>' /></td>
                                                <td>
                                                    <asp:Label ID="lbl_owner_ship_Code" runat="server" Text='<%# Eval("Construction_Area") %>' /></td>

                                                <td>شقة:
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Sum_apartment") %>' />/
                                                    مكتب :
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Sum_Office", "{0:N0}") %>' />/
                                                    محل :
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Sum_Stor", "{0:N0}") %>' />
                                                </td>

                                                <td>
                                                    <asp:Label ID="lbl_Construction_Completion_Date" runat="server" Text='<%# Eval("Construction_Completion_Date") %>' /></td>
                                                <td>
                                                    <asp:Label ID="lbl_electricity_meter" runat="server" Text='<%# Eval("electricity_meter") %>' /></td>
                                                <td>
                                                    <asp:Label ID="lbl_Water_meter" runat="server" Text='<%# Eval("Water_meter") %>' /></td>
                                            </tr>

                                            <tr id="collapse<%# Eval("Building_Id")%>Building_Two" class="accordian-body collapse">
                                                <td colspan="12">
                                                    <table style="font-size: 10px;">
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
                                                            <tr style="background-color:white; color:red">
                                                                <td>
                                                                    <asp:Label ID="lbl_Building_Age" runat="server" Text='<%# Eval("Building_Age") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Parcel_Area" runat="server" Text='<%# Eval("Building_Arabic_Condition") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lvl_Building_Value" runat="server" Text='<%# Eval("Building_Value","{0:N0}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Annual_Waste" runat="server" Text='<%# Eval("Annual_Waste","{0:N3}") %>' /></td>
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
                                                                    <asp:Label ID="lbl_Moajar" runat="server" Text='<%# Eval("R_Moajar") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Shagher" runat="server" Text='<%# Eval("R_Shagher") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_Insha_Siana" runat="server" Text='<%# Eval("R_Insha_Siana") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lbl_NeZaa" runat="server" Text='<%# Eval("R_NeZaa") %>' /></td>
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
                                                                    <a href='<%# Eval("Building_Permit_Path") %>' target="_blank" id="Link_Building_Permit_Path" style="font-size: 11px;">
                                                                        <i class="fa fa-file-image" style="font-size: 11px;"></i>
                                                                        <asp:Label ID="Label10" runat="server" Text="رخصة بناء"></asp:Label>
                                                                    </a>
                                                                </td>

                                                                <td colspan="5">
                                                                    <a href='<%# Eval("certificate_of_completion_Path") %>' target="_blank" id="Link_certificate_of_completion_Path" style="font-size: 11px;">
                                                                        <i class="fa fa-file-pdf" style="font-size: 11px;"></i>
                                                                        <asp:Label ID="Label7" runat="server" Text="شهادة إتمام"></asp:Label>
                                                                    </a>
                                                                </td>

                                                                <td colspan="5">
                                                                    <a href='<%# Eval("Map_path") %>' target="_blank" id="Link_Map_path" style="font-size: 11px;">
                                                                        <i class="fa fa-file-image" style="font-size: 11px;"></i>
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


                                                            <tr id="collapse<%# Container.ItemIndex%>Unit" class="accordian-body collapse">
                                                                <td colspan="17">
                                                                    <asp:Repeater ID="Units_List" runat="server" ClientIDMode="Static" OnItemDataBound="Units_List_ItemDataBound">
                                                                            <HeaderTemplate>
                                                                                <table cellspacing="0" style=" font-size: 10px; " class="Unit">
                                                                                    <thead>
                                                                                        <th   >م </th>
                                                                                        <th   >نوع الوحدة </th>
                                                                                        <th   > رقم الوحدة/ رقم الطابق</th>
                                                                                        <th   >مساحة الوحدة</th>
                                                                                        <th   >تفاصيل الوحدة</th>
                                                                                        <th   >عداد الكهرباء / عداد الماء</th>
                                                                                        <th   >الحالة الإيجارية</th>
                                                                                        <th  >المستأجر</th>
                                                                                        <th  >العقد</th>
                                                                                        <th   >بداية العقد</th>
                                                                                        <th   >نهاية العقد</th>
                                                                                        <th   >الإيجار الفرضي</th>
                                                                                        <th   >الإيجار التعاقدي</th>
                                                                                        <th  >المحصل المفترض</th>
                                                                                        <th   >المحصل الفعلي</th>
                                                                                        <th   >تصنيف المستأجر</th>
                                                                                        <th  >طريقة السداد</th>
                                                                                    </thead>
                                                                                    <tbody>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <tr >
                                                                                    <td>
                                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                                                                    <td    >
                                                                                        <asp:Label ID="lbl_Unit_Arabic_Type" runat="server" Text='<%# Eval("Unit_Arabic_Type") %>' />
                                                                                    </td>
                                                                                    
                                                                                    <td   >
                                                                                        <asp:LinkButton ID="lbl_Unit_Number" Text='<%# Eval("Unit_Number") %>'  runat="server" CommandArgument='<%# Eval("Unit_ID") %>' OnClick="lbl_Unit_Number_Click" ></asp:LinkButton>
                                                                                        /
                                                                                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("Floor_Number") %>' />
                                                                                    </td>
                                                                                    
                                                                                    <td   >
                                                                                        <asp:Label ID="lbl_Unit_Space" runat="server" Text='<%# Eval("Unit_Space") %>' /></td>
                                                                                    
                                                                                    <td   >
                                                                                        <asp:Label ID="lbl_Unit_Arabic_Detail" runat="server" Text='<%# Eval("Unit_Arabic_Detail") %>' /></td>
                                                                                    
                                                                                    <td   >
                                                                                        <asp:Label ID="lbl_Electricityt_Number" runat="server" Text='<%# Eval("Electricityt_Number") %>' />/
                                                                                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("Water_Number") %>' />
                                                                                    </td>
                                                                                    
                                                                                    <td   >
                                                                                        <asp:Label ID="lbl_Unit_Arabic_Condition" runat="server" Text='<%# Eval("Unit_Arabic_Condition") %>' /></td>





                                                                                    <td  >
                                                                                        <asp:Label ID="lbl_Tenants_Arabic_Name" runat="server" Text='<%# Eval("Tenants_Arabic_Name") %>' /></td>
                                                                                    <td  >
                                                                                        <asp:LinkButton ID="lnk_Contract_Id"  runat="server" CommandArgument='<%# Eval("Contract_Id") %>' Text="رابط العقد" OnClick="lnk_Contract_Id_Click"></asp:LinkButton>
                                                                                        <asp:Label ID="lbl_Contract_Id" runat="server" Text='<%# Eval("Contract_Id") %>' Visible="false"/>
                                                                                    </td>
                                                                                    <td   >
                                                                                        <asp:Label ID="lbl_Start_Date" runat="server" Text='<%# Eval("Start_Date") %>' /></td>
                                                                                    <td   >
                                                                                        <asp:Label ID="lbl_End_Date" runat="server" Text='<%# Eval("End_Date") %>' /></td>








                                                                                    <td  >
                                                                                        <asp:Label ID="lbl_virtual_Value" runat="server" Text='<%# Eval("virtual_Value","{0:N0}") %>' /> </td>


                                                                                    <td  >
                                                                                        <asp:Label ID="lbl_Payment_Amount" runat="server" Text='<%# Eval("Payment_Amount","{0:N3}") %>' /> </td>
                                                                                    <td  >
                                                                                        <asp:Label ID="lbl_Muhasal_Muftarad" runat="server" Text='<%# Eval("Muhasal_Muftarad","{0:N0}") %>' /> </td>
                                                                                    <td   >
                                                                                        <asp:Label ID="lbl_Muhasal_Fuly" runat="server" Text='<%# Eval("Muhasal_Fuly","{0:N0}") %>' /> </td>

                                                                                    
                                                                                    <td>
                                                                                        <asp:Label ID="lbl_Persenteg" runat="server" Visible="false" Text='<%# Eval("R_Persenteg") %>' />
                                                                                        <asp:Label ID="Label14" runat="server"  />
                                                                                    </td>


                                                                                     <td   >
                                                                                        <asp:Label ID="lbl_Com_rep_En_Name" runat="server" Text='<%# Eval("Paymen_Method") %>' /> </td>
                                                                                    
                                                                                    
                                                                                    
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                </tbody>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                        </asp:Repeater>
                                                                <td />
                                                            <tr/>
                                                    </table>
                                                </td>
                                            </tr>


                                            




                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                             </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </table>
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
</asp:Content>
