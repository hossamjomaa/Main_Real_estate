<%@ Page Title="" Language="C#" MasterPageFile="~/English/Main_Application/English.Master" AutoEventWireup="true" CodeBehind="Amlak_Dashboard.aspx.cs" Inherits="Main_Real_estate.English.Main_Application.Amlak_Dashboard" %>

<%@ Register TagPrefix="ej" Namespace="Syncfusion.JavaScript.DataVisualization.Models" Assembly="Syncfusion.EJ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script src="http://cdn.syncfusion.com/js/assets/external/jquery.globalize.min.js"></script>
    <script src="https://cdn.syncfusion.com/js/assets/i18n/ej.culture.es-CO.min.js"></script>
    <script> function textRendering(args) { args.data.text = args.data.text.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","); }</script>
    <style>
        label {
            margin-bottom: -25px !important;
            text-align: center !important;
        }

        .tooltipDivChart1 {
            background-color: #E94649;
            color: white;
            width: 130px;
        }

        #Tooltip > div:first-child {
            float: left;
        }

        #Tooltip #value {
            float: right;
            height: 50px;
            width: 68px;
        }

            #Tooltip #value > div {
                margin: 5px 5px 5px 5px;
            }

        #Tooltip #efpercentage {
            font-size: 20px;
            font-family: segoe ui;
            padding-left: 2px;
        }

        #Tooltip #ef {
            font-size: 12px;
            font-family: segoe ui;
        }

        #eficon {
            background-image: url("../Content/images/chart/eficon.png");
            height: 60px;
            width: 60px;
            background-repeat: no-repeat;
        }

        .Indicator_buttons {
            border-radius: 50px;
            border-style: solid;
            width: 20px;
            margin-right: 20px;
            margin-top: 20px;
            height: 20px;
        }

            .Indicator_buttons:active {
            }
    </style>



    <div class="container-fluid" id="container-wrapper1">
        <div class="row" style="width: 100%; background-color: #52a2da; border-radius: 10px; margin-right: 2px; padding: 10px;">
                <%--********************************************************** المصاريف ************************************************--%>

                <div class="col-lg-6">
                    <div class="card mb-3">
                        <div class="card-body">
                            <asp:UpdatePanel ID="Expenses_UpdatePanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DDL_Expenses_Month" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Expenses_Month_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="Jan"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Feb"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Mar"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Apr"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="May "></asp:ListItem>
                                        <asp:ListItem Value="6" Text="Jun"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="Jul"></asp:ListItem>
                                        <asp:ListItem Value="8" Text="Aug"></asp:ListItem>
                                        <asp:ListItem Value="9" Text="Sep"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="Oct"></asp:ListItem>
                                        <asp:ListItem Value="11" Text="Nov"></asp:ListItem>
                                        <asp:ListItem Value="12" Text="Dec"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DDL_Expenses_Year" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Expenses_Year_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:DropDownList ID="DDL_Expenses_Ownership" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Expenses_Ownership_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:DropDownList ID="DDL_Expenses_Building" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Expenses_Building_SelectedIndexChanged"></asp:DropDownList>
                                    <%------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                                    <ej:WaitingPopup runat="server" ID="waitingpopup" ShowOnInit="false"></ej:WaitingPopup>
                                    <ej:Chart ID="Expenses_Chart" runat="server" Width="550" Height="290" OnClientLoad="onChartLoad" IsResponsive="true" OnClientDisplayTextRendering="textRendering">
                                        <CommonSeriesOptions EnableAnimation="True" Tooltip-Visible="true"
                                            Tooltip-Format="#point.x# : #point.y# #series.name# ريال قطري">
                                            <Marker>
                                                <DataLabel Visible="True" ShowEdgeLabels="true" EnableContrastColor="true" />
                                            </Marker>
                                        </CommonSeriesOptions>
                                        <PrimaryYAxis RangePadding="Normal" LabelFormat="n0">
                                        </PrimaryYAxis>
                                        <Series>
                                            <ej:Series Name="مصاريف عقارية" XName="Xvalue" YName="YValue1" Fill="rgba(59,175,218,1)"></ej:Series>
                                            <ej:Series Name="مصاريف صيانة" XName="Xvalue" YName="YValue2" Fill="rgba(140,193,82,1)"></ej:Series>
                                            <ej:Series Name="مصاريف إدارية" XName="Xvalue" YName="YValue3" Fill="rgba(252,187,66,1)"></ej:Series>
                                        </Series>
                                        <Title Text="المصاريف"></Title><Legend Position="Bottom"></Legend>
                                    </ej:Chart>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DDL_Expenses_Ownership" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

                <%--********************************************************** القيمة الإيجارية ************************************************--%>

                <div class="col-lg-6">
                    <div class="card mb-3">
                        <div class="card-body">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DDL_Rental_Value_Month" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Rental_Value_Month_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="Jan"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Feb"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Mar"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Apr"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="May "></asp:ListItem>
                                        <asp:ListItem Value="6" Text="Jun"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="Jul"></asp:ListItem>
                                        <asp:ListItem Value="8" Text="Aug"></asp:ListItem>
                                        <asp:ListItem Value="9" Text="Sep"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="Oct"></asp:ListItem>
                                        <asp:ListItem Value="11" Text="Nov"></asp:ListItem>
                                        <asp:ListItem Value="12" Text="Dec"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DDL_Rental_Value_Year" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Rental_Value_Year_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:DropDownList ID="DDL_Rental_Value_Ownership" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Rental_Value_Ownership_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:DropDownList ID="DDL_Rental_Value_Building" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Rental_Value_Building_SelectedIndexChanged"></asp:DropDownList>
                                    <%------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                                    <ej:WaitingPopup runat="server" ID="waitingpopup2" ShowOnInit="false"></ej:WaitingPopup>
                            <ej:Chart ID="Rental_Value_Chart" Locale="fr-FR" runat="server" Width="550" Height="290" OnClientLoad="onChartLoad" IsResponsive="true" OnClientDisplayTextRendering="textRendering">
                                <CommonSeriesOptions EnableAnimation="True" Tooltip-Visible="true"
                                    Tooltip-Format="#point.x# : #point.y# #series.name# ريال قطري">
                                    <Marker>
                                        <DataLabel Visible="True" ShowEdgeLabels="true" EnableContrastColor="true">
                                        </DataLabel>
                                    </Marker>
                                </CommonSeriesOptions>
                                <PrimaryYAxis RangePadding="Normal" LabelFormat="n0"></PrimaryYAxis>
                                <Series>
                                    <ej:Series Name=" المفترض" XName="Xvalue" YName="YValue1" Fill="#fcbb42"></ej:Series>
                                    <ej:Series Name="المستحق" XName="Xvalue" YName="YValue2" Fill="#da4453"></ej:Series>
                                    <ej:Series Name="المحصل" XName="Xvalue" YName="YValue3" Fill="#37bc9b"></ej:Series>
                                </Series>
                                <Title Text="القيمة الإيجارية"></Title>
                                <Legend Position="Bottom"></Legend>
                            </ej:Chart>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                                    
                             
                        </div>
                    </div>
                </div>

                <%--******************************************************************************************************************--%>
        </div>
    </div>

</asp:Content>
