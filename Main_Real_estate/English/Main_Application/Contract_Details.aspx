<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contract_Details.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Contract_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">

    <link runat="server" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" rel="stylesheet" />
    <link id="link4" runat="server" href="../CSS/all-rtl.min.css" rel="stylesheet" />
    <link id="link5" runat="server" href="../CSS/bootstrap-rtl.min.css" rel="stylesheet" />
    <link runat="server" href="../CSS/ruang-admin-rtl.min.css" rel="stylesheet" />

    <title></title>
    <style>
        body {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
            background-color: #FAFAFA;
            font: 750px;
        }

        * {
            box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .page {
            width: 210mm;
            min-height: 100%;
            padding: 2mm;
            margin: 10mm auto;
            border: 1px #D3D3D3 solid;
            border-radius: 5px;
            background: white;
            box-shadow: 0 0 5px rgba(0, 0, 0, 0.1);
        }

        .subpage {
            padding: 1cm;
            height: 100%;
        }

        @page {
            size: A4;
            margin: 0;
        }

        @media print {

            html,
            body {
                width: 210mm;
                height: 100%;
            }

            .page {
                margin: 0;
                border: initial;
                border-radius: initial;
                width: initial;
                min-height: initial;
                box-shadow: initial;
                background-color: white;
                page-break-after: always;
                word-wrap: break-word;
            }

            .Contarct_Back_btn {
                border-radius: 10px
            }

            footer {
                font-size: 9px;
                color: #f00;
                text-align: center;
            }
        }
    </style>
    <script>
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1"  runat="server"/>
        <div class="row" style="position: fixed; top: 10px; margin-right: 10px; margin-left: 10px; padding-left: 10px">
            <button style="width: 150px; height: 50px; background-color: #52a2da; font-size: 20px; color: white; border-radius: 10px"
                onclick="printDiv('print')">
                <i class="fa fa-print" aria-hidden="true"></i>&nbsp;طباعة العقد
            </button>
            &nbsp;&nbsp;
            <%--<asp:Button ID="btn_Contarct_Back"  border-radius="10px" runat="server" Text="عودة" OnClick="Button1_Click" />--%>

            <button id="Back" runat="server" onserverclick="Button1_Click" style="font-size: 20px; color: black; border-radius: 10px">
                رجوع &nbsp;<i class="fa fa-backward" aria-hidden="true"></i></button>
        </div>

        <div class="row">
            <div class="container" style="align-items: center">
                <div id="print" class="book" style="direction: rtl;">
                    <div class="page" style="padding: 50px; font-size: 23px;">
                        <%--<div class="subpage">--%>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="Main_Image/Manara_Header.png" style="width: 60%; direction: inherit;" /><br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <span style="font-weight: bold">عقـــــــد ايجــــــــار</span>
                        <br />
                        <br />
                        في يوم الموافق<asp:Label Font-Bold="true" ID="lbl_Sgin_Date" runat="server"></asp:Label>
                        تم الاتفاق بين:  
                    <br />
                        الســــــــــادة / شــركة المنــارة للصيـانة والتجــارة،
                    سجل تجاري رقم 15000 تليفون: 44727280 ص.ب. رقم 9359 ويشــــــــار اليه فيمـا بعد بالطـــــرف الأول 
                    <br />
                        (المــؤجـــــر)
                    <br />
                        <asp:Label Font-Bold="true" ID="lbl_MR_Or_Mrs_Or_Com" runat="server"></asp:Label>
                        <asp:Label Font-Bold="true" ID="lbl_tenant_Name" runat="server"></asp:Label>
                        ,
                    <asp:Label Font-Bold="true" ID="lbl_Po_Cr" runat="server"></asp:Label>
                        رقم الهاتف :
                    <asp:Label Font-Bold="true" ID="lbl_Tenant_Mobile" runat="server"></asp:Label>

                        <asp:Label Font-Bold="true" ID="lbl_Com_Rep_Name" runat="server"></asp:Label>
                        ، الجنسية 	
                    (<asp:Label Font-Bold="true" ID="lbl_Tenant_Nationality" runat="server"></asp:Label>)
                    البطاقة الشخصية رقم 
                    <asp:Label Font-Bold="true" ID="lbl_Tenant_Qid" runat="server"></asp:Label>
                        <br />
                        <asp:Label Font-Bold="true" ID="lbl_Com_Rep_Mobile" runat="server"></asp:Label>
                        <br />
                        ويشــــــــار اليه فيمـا بعد بالطـــــرف الثـــــــاني
                    <br />
                        (المستأجـــــر)
                    <br />
                        وبعد ان اقر الطرفان بأهليتهما المعتبرة شرعاً وقانوناً للتعاقد اتفقا على ابرام هذا العقد وفقا للشروط والاحكام التالية:
                    <br />
                        <span style="font-weight: bold">البند الاول:</span>
                        موضوع العقد
                    <br />
                        بموجب هذا العقـد استـأجر الطـرف الثـاني من الطـرف الأول
                    (<asp:Label Font-Bold="true" ID="lbl_Unit_Type" runat="server"></asp:Label>)
                    رقم : 
                    (<asp:Label Font-Bold="true" ID="lbl_Unit_Number" runat="server"></asp:Label>)
                    رقم البناء :
                    (<asp:Label Font-Bold="true" ID="lbl_Building_Number" runat="server"></asp:Label>)
                    <br />
                        رقم الشارع
                    (<asp:Label Font-Bold="true" ID="lbl_Street_Number" runat="server"></asp:Label>)
                    اسم الشارع 
                    (<asp:Label Font-Bold="true" ID="lbl_street_Name" runat="server"></asp:Label>)
                    ورقم المنطقة 
                    (<asp:Label Font-Bold="true" ID="lbl_Zone_Number" runat="server"></asp:Label>) 
                    والتي تشتمل اوصافها 
                    (<asp:Label Font-Bold="true" ID="lbl_furniture_case" runat="server"></asp:Label>) 
                    عدد الوحدات والغرف:
                    (<asp:Label Font-Bold="true" ID="lbl_Unit_Details" runat="server"></asp:Label>) 
                    <br />
                        رقم الكهرباء :
                    (<asp:Label Font-Bold="true" ID="lbl_Electrisity_Meter" runat="server"></asp:Label>) 
                    رقم المياه :
                    (<asp:Label Font-Bold="true" ID="lbl_Water_Meter" runat="server"></asp:Label>) 
                    <br />
                        <br />
                        <span style="font-weight: bold">البند الثاني:</span>
                        مدة العقد
                    <br />
                        مدة هذا العقد هي : 
                    <asp:Label Font-Bold="true" ID="lbl_Month_Year_Number" runat="server"></asp:Label>
                        <asp:Label Font-Bold="true" ID="lbl_Duration_free_period" runat="server"></asp:Label>
                        تبدأ في :
                    <asp:Label Font-Bold="true" ID="lbl_Strat_Date" runat="server"></asp:Label>
                        وتنتهي في : 
                    <asp:Label Font-Bold="true" ID="lbl_End_Date" runat="server"></asp:Label>
                        وينتهي العقد بانتهاء هذه المدة دون الحاجة الي اخطار او تنبيه علما
                     بانه إذا اخلي الطرف الثاني العين المؤجرة قبل انتهاء مدة العقد يلتزم بدفع القيمة الايجارية حتي نهاية المدة المؤجرة. 
                      وفي حالة رغب العميل بتجديد العقد فأن عليه إحراز موافقة المؤجر على التجديد قبل انتهاء العقد بمدة شهرين على الأقل . 
                    <br />
                        <br />
                        <span style="font-weight: bold">البند الثالث: </span>
                        القيمة الايجارية وطريقة الدفع
                    <br />
                        اتفق الطرفان على ان القيمة الايجارية مبلـغ وقـدره                
                    <asp:Label Font-Bold="true" ID="lbl_Payment_Amount" runat="server"></asp:Label>
                        (<asp:Label Font-Bold="true" ID="lbl_Payment_Amount_L" runat="server"></asp:Label>)
                    ريـال شهريــا  
                   تسدد مقدما  
                    (<asp:Label Font-Bold="true" ID="Payment_Type" runat="server"></asp:Label>)
                     كل بداية شهر 
                        <asp:Label Font-Bold="true" ID="lbl_Paymen_Method" runat="server"></asp:Label>
                        عن كامل مدة التعاقد.
                        <br />
                        <asp:Label Font-Bold="true" ID="lbl_Transformation_Bank" Font-Size="20px" runat="server"></asp:Label>
                    <br />

                        • وفي حالة تأخر الطرف الثاني عن الوفاء بالقيمة الايجارية في موعد استحقاقها او عند ارتجاع 
                    اي شيك من الشيكات فانه يحق للطرف الاول فسخ العقد واخلائه من العين المؤجرة دون حاجة 
                    الى انذار او حكم قضائي بذلك ولو بالقوة مع حقه في المطالبة بالقيمة الايجارية عن الفترة المتبقية من العقد.
                    <br />
                        <hr />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="Main_Image/Manara_Header.png" style="width: 60%; direction: inherit;" /><br />
                        <div runat="server" id="Free_Period" style="height: 170px;">
                            •
                    	يحصل المستأجر على فترة سماح تبدأ من الشهر 
                    (<asp:Label Font-Bold="true" ID="Start_Free_Period" runat="server"></asp:Label>)
                    مدتها
                    (<asp:Label Font-Bold="true" ID="Duration_free_period" runat="server"></asp:Label>)
                     أشهر وبالتالي تكون فترة الايجار هي (مدة الايجار +فترة السماح) ويشترط ذلك بسداد جميع الإيجارات والتزام 
                    المستأجر بكافة بنود العقد، فاذا تخلف عن سداد أي قسط إيجاري يحق للمؤجر المطالبة بها أو خصمها من مدة الايجار الكلية  
                    (موافقة المدير ) 
                        </div>


                        <%---------------------------------------------------------------------------------------------------------------------%>

                        <span style="font-weight: bold">البند الرابع:</span>
                        الغرض من استعمال العين المؤجرة
                    <br />
                        الغرض من الايجار هو استخدام العين المؤجرة 
                    (<asp:Label Font-Bold="true" ID="lbl_Reason_For_Rent" runat="server"></asp:Label>)
                    (<asp:Label Font-Bold="true" ID="lbl_Reason_For_Rent_Discribtion" runat="server"></asp:Label>)
                    وأقر لطرف الثاني بأنه قد تسلم العين المؤجرة بحالة جيدة صالحة للانتفاع بها للغرض الذي اعدت له وقَبِلها بحالتها
                    الراهنة، وتعهد بأن يبذل العناية اللازمة في المحافظة عليها ويكون مسئولا عما يصيبها من تلف،
                    ويلتزم بردها بالحالة التي تسلمها بها عند التعاقد دون إزالة اية اضافات او ديكورات الا إذا طلب الطرف الأول ذلك.  
                    <br />
                        <br />
                        <span style="font-weight: bold">البند الخامس: </span>
                        الالتزام بالصيانة
                    <br />
                        يقوم الطرف الأول بالصيانة الأساسية اللازمة لسلامة البناء ومحتويات العين المؤجرة
                    من المرفقات غير المتحركة وأثاث وأجهزة كهربائية، ما دامت جزأ من العين المؤجرة، وتعود ملكيتها للمؤجر.
                    (<asp:Label Font-Bold="true" ID="lbl_maintenance" runat="server"></asp:Label>)
                    <br />
                        <br />
                        <span style="font-weight: bold">البند السادس:</span>
                        التنازل والبيع والايجار من الباطن.
                    <br />
                        <asp:Label Font-Bold="true" ID="lbl_Rental_allowed_Or_Not_allowed" runat="server"></asp:Label>
                        للطـرف الثاني التـأجير من البـاطن و بيـع عقد او حق الانتفاع الناتج عنه بغير اذن كتابي من
                    الطرف الاول.
                    <br />
                        <br />
                        <span style="font-weight: bold">البند السابع:</span>
                        الاضافات والتغييرات
                    <br />
                        لايجوز
                    للطرف الثاني ان يجري في العين المؤجرة اية تغييرات سواء كانت بسيطة او جسيمة خاصة تلك التي من شأنها ان
                    تحدث بالعين المؤجرة اي ضرر، ويجوز له بعد الموافقة الكتابية من الطرف الاول إجراء الترميمات والاصلاحات وعمل
                    ديكورات على نفقته الخاصة، بشرط ان يجريها بطريقة تتفق مع الاصول الفنية السليمة المتعارف عليها، ولا يجوز له
                    إزالتها عند إخلاء العين المؤجرة الا إذا طلب الطرف الاول ذلك
                    <br />
                        <br />
                        <div style="font-size: 20px">
                            <span style="font-weight: bold">البند الثامن:</span>
                            التعويض في حالة اجراء تغيرات دون الحصول على الموافقة المسبقة
                            <br />
                            إذا أحدَّث الطرف الثاني بالعين المؤجرة اية تعديلات او اضافات دون إذن كتابي من الطرف الاول او رغم معارضته، كان
                            للأخير ان يطلب ازالتها أو إزالتها بنفسه وان يطلب فوق ذلك تعويض عن الضرر الذي يصيب العين المؤجرة والتكاليف من هذه
                            الازالة إن ازالها بنفسه.
                        </div>
                        <br />
                        <div id="NO_Nine_U" runat="server" style="font-size: 20px">
                            <span style="font-weight: bold">البند التاسع:</span>
                            الرسوم
                    <br />
                            1- يقوم المستأجر بنقل عداد الكهرباء والماء بمجرد توثيق العقد لدى الجهة المختصة والا فانه يقوم بإيداع مبلغ
                    التأمين لدى الطرف الأول حتى قيامه بذلك
                    <br />
                            2- يلتزم الطرف الثاني بدفع رسوم الكهرباء والماء والهاتف وغيرها من رسوم الخدمات للجهات المختصة والحصول على
                    اشعارات تبرئ ذمته من تاريخ استلامه للعين المؤجرة وحتي نهاية مدة العقد، ويلتزم بإحضار وصل تأمين كهرماء كما يكون
                    ملزماً بأية رسوم تفرضها الدولة مستقبلا.
                    <br />
                            3- لا يعتبر قد سلم الوحدة بمستند اغلاق العداد واسترداد التأمين
                        </div>
                        <br />


                        <%-------------------------------------------------------------------------------------------------------------------------%>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="Main_Image/Manara_Header.png" style="width: 60%; direction: inherit;" /><br />
                        <div id="NO_Nine_D" runat="server">
                            <span style="font-weight: bold">البند التاسع:</span>
                            الرسوم
                    <br />
                            1- يقوم المستأجر بنقل عداد الكهرباء والماء بمجرد توثيق العقد لدى الجهة المختصة والا فانه يقوم بإيداع مبلغ
                    التأمين لدى الطرف الأول حتى قيامه بذلك
                    <br />
                            2- يلتزم الطرف الثاني بدفع رسوم الكهرباء والماء والهاتف وغيرها من رسوم الخدمات للجهات المختصة والحصول على
                    اشعارات تبرئ ذمته من تاريخ استلامه للعين المؤجرة وحتي نهاية مدة العقد، ويلتزم بإحضار وصل تأمين كهرماء كما يكون
                    ملزماً بأية رسوم تفرضها الدولة مستقبلا.
                    <br />
                            3- لا يعتبر قد سلم الوحدة بمستند اغلاق العداد واسترداد التأمين
                        </div>
                        <br />
                        <span style="font-weight: bold">البند العاشر:</span>
                        التأمينات والالتزامات العامة
                    <br />
                        ريال قطري وذلك كتأمين عن اداء الطرف الثاني لالتزاماته المترتبة عليه بموجب هذا العقد ،وخصوصاً تلك الواردة ادناه
                    في البند الحادي عشر تحت مسمي( الالتزامات العامة ) والتي يجب علي الطرف الثاني مراعاتها ويعتبر اي اخلال بها
                    اخلالاً ببنود هذا العقد يوجب الفسخ والاخلاء دون حاجة الي انذار او حكم ،مع العلم ان هذه الالتزامات واردة علي سبيل
                    المثال لا الحصر وانها قابلة للإضافة عليها من وقت لآخر حسب ما يراه الطرف الاول .ودون الاخلال بأية تعويضات اخري
                    يجوز للطرف الاول استخدام التأمين لتغطية اية نفقات قد يتكبدها في سبيل ازالة المخالفات التي يتسبب فيها الطرف
                    الثاني وذلك بعد انذاره بضرورة ازالتها في وقت مناسب ،وإلاَّ يحق للطرف الاول إزالتها علي نفقة الطرف الثاني خصماً
                    علي قيمة التأمين .وكما يكون مفهوما وبصورة واضحة ومتفقا عليه بأن قيمة التأمين غير مخصصة اطلاقا للوفاء بالقيمة
                    الايجارية.
                    <br />
                        <br />
                        الالتزامات العامة: 
                    <br />
                        -	يتعهد الطرف الثاني وفي كافة الاوقات بالالتزام بمراعاة الأنظمة والتعليمات الصادرة عن الطرف الاول والتي تتعلق بالإدارة وسلوك المستأجرين،
                    وان فشله في الالتزام بهذه الأنظمة والتعليمات يشكل خرقاً لبنود هذا العقد   
                    <br />
                        -	يلتزم الطرف الثاني بالتخلص من النفايات ويلتزم بالقيام بتنظيف العين المؤجرة ويجب 
                    القاء جميع النفايات في اوعية مناسبة ويجب ان يعمل على تنظيم ازالتها عن العقار بصورة مناسبة
                    <br />
                        -	يتعهد الطرف الثاني بعدم وضع اي منقولات امام العين المؤجرة او بمداخل العقار اعلي سطح 
                    المبني او ارتكاب اي فعل يؤدي الي الاضرار بباقي المستأجرين او الناحية الجمالية، وان يستجيب لاي توجيهات من الادارة في هذا الشأن، والا يسمح بإعاقة،
                   او اي شي يؤدي الى ازعاج عن طريق النوافذ او الضوء او شفاطات الهواء الفاسد او مضايقة المستأجرين الاخرين، وان لا يسمح بوقوف اية سيارات او عوائق الا في حدود
                    المساحات المسموح بها
                    <br />
                        <div id="No_Ten_U" runat="server">
                            ووفقا للأنظمة المعمول بها، وان لا يعيق المداخل والطرق والمصاعد والادراج 
                    <br />
                            -	يجب على الطرف الثاني اصلاح اية اعطال او اضرار تحدث في المنطقة المشتركة بينه وبقية المستأجرين او اي مناطق مجاورة تتأثر بسبب سوء الاستخدام من قبل 
                    الطرف الثاني، او مستخدميه، او وكلائه، او غيرهم مما يشكل خرقاً وإخلالاً بالتزامات الطرف الثاني 
                    <br />
                            -	يتعهد الطرف الثاني بالتقيد بكافة معايير السلامة والحريق ويكون مسئولا تجاه الاول بالإضافة للتعويضات بإعادة العين المؤجرة الي حالتها.
                    <br />
                            الشقق المفروشة والجديدة:
                    <br />
                            يلزم الطرف الثاني بإيداع شيك تأمين قيمة (شهر واحد) لضمان حسن سداد الايجار وعدم التخلف عنه في الظروف المختلفة.
                        </div>
                        <hr />
                        <br />
                        <%-------------------------------------------------------------------------------------------------------------------------%>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="Main_Image/Manara_Header.png" style="width: 60%; direction: inherit;" /><br />
                        <div id="No_Ten_D" runat="server">
                            ووفقا للأنظمة المعمول بها، وان لا يعيق المداخل والطرق والمصاعد والادراج 
                    <br />
                            -	يجب على الطرف الثاني اصلاح اية اعطال او اضرار تحدث في المنطقة المشتركة بينه وبقية المستأجرين او اي مناطق مجاورة تتأثر بسبب سوء الاستخدام من قبل 
                    الطرف الثاني، او مستخدميه، او وكلائه، او غيرهم مما يشكل خرقاً وإخلالاً بالتزامات الطرف الثاني 
                    <br />
                            -	يتعهد الطرف الثاني بالتقيد بكافة معايير السلامة والحريق ويكون مسئولا تجاه الاول بالإضافة للتعويضات بإعادة العين المؤجرة الي حالتها.
                    <br />
                            الشقق المفروشة والجديدة:
                    <br />
                            يلزم الطرف الثاني بإيداع شيك تأمين قيمة (شهر واحد) لضمان حسن سداد الايجار وعدم التخلف عنه في الظروف المختلفة.
                        </div>
                        <br />
                        <br />
                        <span style="font-weight: bold">البند الحادي عشر: </span>
                        الحريق والتعويضات 
                    <br />
                        إذا حدث بعد تسليم العين المؤجرة للطرف الثاني ان أُصيبت او أي جزء منها بأضرار بسبب الحريق او أي سبب اخر نتيجة اجراء قام به الطرف الثاني او اهمال من جانبه،
                    او وكلائه، او موظفيه، او مدعويه او تابعيه، فانه لا يجوز تخفيض القيمة الايجارية اثناء اصلاح الاضرار ويكون المستأجر مسئولا عن تكاليف الاصلاحات التي لا يغطيها التأمين،
                    ويحتفظ المستأجر علي نفقته بوثيقة تأمين عام وشامل للأنشطة التي يقوم بها داخل العين المؤجرة.
                    <br />
                        <br />
                        <span style="font-weight: bold">البند الثاني عشر:</span>
                        الاعفاء والتعويضات
                    <br />
                        يعفي الطرف الثاني الاول ويخلي طرفه من اية تعويضات، او اية اصابات، او خسائر، او مطالبات، 
                    او اضرار تقع لأشخاص او ممتلكات في العين المؤجرة او خارجها ما لم تكن ناتجة عن اعمال متعمدة من جانب الطرف الاول أو موظفيه.
                    <br />
                        <br />
                        <span style="font-weight: bold">البند الثالث عشر: </span>
                        القوة القاهرة
                    <br />
                        في حالة وقوع اي سبب من شأنه تشكيل قوة قاهرة وفي أقرب وقت ممكن يقوم الطرف الثاني
                    بأخطار الاول بكافة التفاصيل كتابة بوقوع تلك الأحداث التي من شأنها جعل المستأجر عاجزا كلياً او جزئياً عن اداء التزاماته 
                    <br />
                        <br />
                        <span style="font-weight: bold">البند الرابع عشر:</span>
                        نزع ملكية العين المؤجرة للمنفعة العامة
                    <br />
                        في حالة ما اذا تم نزع ملكية العين المؤجرة للمنفعة العامة فان الطرف الاول لا يلتزم بأي تعويض تجاه الطرف الثاني.
                    <br />
                        <div id="No_Fifteen_U" runat="server">
                            <br />
                            <span style="font-weight: bold">البند الخامس عشر: </span>
                            الغياب واغلاق المحل
                    <br />
                            أقر الطرف الثاني بحق الطرف الاول في دخول العين المؤجرة واسترداد ها بعد جرد محتوياتها ان وجدت وذلك في حالة ما اذا ترك الطرف الثاني العين المؤجرة
                    مغلقة لأكثر من ثلاثة اشهر،
                    <br />
                            كما واسقط الطرف الثاني وبصورة صريحة حقه في المطالبة بأية تعويضات يدعيها ترتبت على هذا الدخول ، ويمتد الإعفاء من المسئولية ليشمل المسئولية الجنائية.
                    <br />
                        </div>
                        <br />
                        <div id="No_Sixteen_U" runat="server">
                            <span style="font-weight: bold">البند السادس عشر: </span>
                            انهاء العقد
                    <br />
                            يجوز للطرف الاول ولو قبل انتهاء مدة هذا العقد سواء الاصلية منها او تلك التي تجددت ان يخلي الطرف الثاني من العين المؤجرة ودون انزار او حكم قضائي بذلك في الحالات الاتية:
                   <br />
                            1/ إذا لم يقم الطرف الثاني بالوفاء بالأجرة في موعد استحقاقها كما هو مبين في هذا العقد
                        </div>
                        <hr />
                        <br />
                        <%-------------------------------------------------------------------------------------------------------------------------%>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="Main_Image/Manara_Header.png" style="width: 60%; direction: inherit;" /><br />
                        <div id="No_Fifteen_D" runat="server">
                            <span style="font-weight: bold">البند الخامس عشر: </span>
                            الغياب واغلاق المحل
                    <br />
                            أقر الطرف الثاني بحق الطرف الاول في دخول العين المؤجرة واسترداد ها بعد جرد محتوياتها ان وجدت وذلك في حالة ما اذا ترك الطرف الثاني العين المؤجرة
                    مغلقة لأكثر من ثلاثة اشهر،
                    <br />
                            كما واسقط الطرف الثاني وبصورة صريحة حقه في المطالبة بأية تعويضات يدعيها ترتبت على هذا الدخول ، ويمتد الإعفاء من المسئولية ليشمل المسئولية الجنائية.
                    <br />
                        </div>

                        <br />
                        <br />
                        <div id="No_Sixteen_D" runat="server">
                            <span style="font-weight: bold">البند السادس عشر: </span>
                            انهاء العقد
                    <br />
                            يجوز للطرف الاول ولو قبل انتهاء مدة هذا العقد سواء الاصلية منها او تلك التي تجددت ان يخلي الطرف الثاني من العين المؤجرة ودون انزار او حكم قضائي بذلك في الحالات الاتية:
                   <br />
                            1/ إذا لم يقم الطرف الثاني بالوفاء بالأجرة في موعد استحقاقها كما هو مبين في هذا العقد
                        </div>
                        2/ إذا تنازل الطرف الثاني عن العين او قام ببيعها او تركها باي وجه من الوجوه بغير اذن كتابي من الطرف الاول
                   <br />
                        3/ إذا استعمل الطرف الثاني العين المؤجرة او سمح باستعمالها بطريقة تخالف شروط العقد او تتنافى مع النظام     العام والآداب
                  <br />
                        4/إذا رغب الطرف الاول في هدم العقار
                   <br />
                        5/ إذا صدر قرار من الجهات المختصة بهدم المبنى بعد ان أصبح يخشى منه على سلامة السكان
                  <br />
                        6/ إذا حدث اي اخلال من جانب الطرف الثاني لبنود هذا العقد
                    <br />
                        <br />
                        <span style="font-weight: bold">البند السابع عشر: </span>
                        الواجبات عند انتهاء هذا العقد
                    <br />
                        علي الطرف الثاني عند انتهاء هذا العقد تسليم العين المؤجرة بكامل التركيبات والتمديدات والتوصيلات والاضافات مالم يطلب 
                    الطرف الاول غير ذلك فيجب ازالتها وابقاء العين المؤجرة بالحالة التي تسلمها بها بالإضافة الى تسليم مفاتيح
                    العين المؤجرة وإذا طلب الطرف الاول ازالة كافة الاضافات التي اجراها الطرف الثاني فيجب عليه ازالتها كما
                    ويجب تنفيذ اعمال الازالة من قبل مقاول يعينه الطرف الثاني ويجب ان يكون معتمداً من قبل الطرف الاول
                    ويجب عليه اصلاح كافة الاضرار بأفضل اصول الصنعة وفي حالة فشل الطرف الثاني في ذلك،
                    فان الطرف الاول سوف يقوم بإصلاح كافة الاضرار وتكون التكاليف التي تكبدها بسبب اعمال الازالة والصيانة على نفقة الطرف الثاني يجب ادائها
                    خلال سبعة ايام من تاريخ ابلاغه بها ،وإلاَّ يحق للطرف الاول خصمها من قيمة التأمين  والمطالبة بالمتبقي اذا لم يفئ مبلغ التأمين بها.
                    <br />
                        <div id="No_18_19_U" runat="server">
                            <br />
                            <span style="font-weight: bold">البند الثامن عشر:</span>
                            <br />
                            ابقاء الطرف الثاني للعين المؤجرة عند انتهاء العقد دون وجه حق
                    اذا ابقي الطرف الثاني العين المؤجرة بعد انتهاء  
                    مدة العقد رغم التنبيه عليه بالإخلاء وعدم الرغبة في التجديد
                    ،فانه يكون ملزماً بدفع ضعف القيمة الايجارية المحددة في العقد
                    ،مع تحمله لأية اضرار قد تصيب الطرف الاول بسبب فشله او رفضه تسليم العين المؤجرة حسب شروط هذا العقد.
                    <br />
                            <br />
                            <span style="font-weight: bold">البند التاسع عشر:</span>
                            الاموال المودعة (مبلغ التأمين)
                    <br />
                            على الطرف الثاني (المستأجر)دفع شيك ( كضمان) مقدما عند التوقيع على العقد تحفظ كتامين ويفرج عن هذا المبلغ للمستأجر حال ثبوت تسديد الكهرباء والماء والهاتف 
                   واحضار ما يفيد بذلك من الجهات المعنية ( كيوتل كهرماء وغيرها) وتسليم العين المؤجرة الى الطرف الاول بحالة جيدة بمحضر رسمي يوقع عليه الطرفين بالاستلام.
                        </div>
                        <hr />
                        <br />
                        <br />
                        <%-------------------------------------------------------------------------------------------------------------------------%>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="Main_Image/Manara_Header.png" style="width: 60%; direction: inherit;" /><br />
                        <div id="No_18_19_D" runat="server">
                            <span style="font-weight: bold">البند الثامن عشر:</span>
                            <br />
                            ابقاء الطرف الثاني للعين المؤجرة عند انتهاء العقد دون وجه حق
                    اذا ابقي الطرف الثاني العين المؤجرة بعد انتهاء  
                    مدة العقد رغم التنبيه عليه بالإخلاء وعدم الرغبة في التجديد
                    ،فانه يكون ملزماً بدفع ضعف القيمة الايجارية المحددة في العقد
                    ،مع تحمله لأية اضرار قد تصيب الطرف الاول بسبب فشله او رفضه تسليم العين المؤجرة حسب شروط هذا العقد.
                    <br />
                            <br />
                            <span style="font-weight: bold">البند التاسع عشر:</span>
                            الاموال المودعة (مبلغ التأمين)
                    <br />
                            على الطرف الثاني (المستأجر)دفع شيك ( كضمان) مقدما عند التوقيع على العقد تحفظ كتامين ويفرج عن هذا المبلغ للمستأجر حال ثبوت تسديد الكهرباء والماء والهاتف 
                   واحضار ما يفيد بذلك من الجهات المعنية ( كيوتل كهرماء وغيرها) وتسليم العين المؤجرة الى الطرف الاول بحالة جيدة بمحضر رسمي يوقع عليه الطرفين بالاستلام.
                        </div>
                        <br />
                        <span style="font-weight: bold">البند العشرين:</span>
                        العناوين والاخطارات
                    <br />
                        يقر كل من الطرفين المتعاقدين بانه قد اتخذ العنوان المذكور قرين كل منه الموضح بصدر هذا العقد موطناً مختاراً له 
                    ،وكل إخطار او عنوان يرسل له يعتبر صحيحاً ومنتجاً لكافة آثاره القانونية ،هذا بالإضافة لاي طريقة اخري يقرها القانون الفطري:
                     أ/ التسليم الشخصي ب/ ارسالها بالبريد المسجل ج/ علي الفاكس شريطة تقديم ما يثبت ذلك.
                    <br />
                        <br />
                        <span style="font-weight: bold">البند الحادي والعشرين:</span>
                        تحمل المخالفات
                    <br />
                        يتحمل الطرف الثاني أيه رسوم مخالفات ناتجه عن أي خطأ أو إهمال صادر عنه.
                    <br />
                        <br />
                        <span style="font-weight: bold">البند الثاني والعشرين :</span>
                        القانون الواجب التطبيق والاختصاص :
                    <br />
                        تسرى احكام القانون رقم 4 لسنة 2008وتعديلاته بشأن ايجار العقارات  والفصل الاول من الباب الثاني من القانون المدني فيما لم يرد بشأنه نص في هذا العقد
                    ،كما وتختص لجنة فض المنازعات بوزارة الشئون البلدية والزراعة المنشئة بموجب القانون المشار اليه اضافة الى المحاكم القطرية في كل نزاع ينشأ عن تطبيق هذا العقد لا قدر الله.
                    <br />
                        <asp:Label Font-Bold="true" ID="lbl_No_23" runat="server"></asp:Label>
                        <asp:Label Font-Bold="true" ID="lbl_Contract_Details" runat="server"></asp:Label>
                        قام الطرفان بمراجعة بنود هذا العقد وتعهدا بالالتزام بتنفيذ احكامه نصاً وروحاً ,,,
	                <br />
                        والله ولي التوفيـــق,,,
                    <br />
                        <br />
                        <span style="font-weight: bold">الطرف الاول </span>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <span style="font-weight: bold">الطرف الثاني </span>



                        <%--</div>--%>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
