﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CartSummary.ascx.vb"
    Inherits="DotNetNuke.Modules.AgapeFR.Cart.CartSummary" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="dnn2" TagName="CartBreadcrumb" Src="~/DesktopModules/AgapeFR/Cart/CartBreadcrumb.ascx" %>
<script type="text/javascript">

    (function ($, Sys) {
        function setUpMyObjects() {

            $('.aButton').button();

        }

        $(document).ready(function () {
            setUpMyObjects();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                setUpMyObjects();

            });
        });
    }(jQuery, window.Sys));
</script>
<style type="text/css">

    .gridHeader {
        font-weight: bold;
        border-bottom: 1px solid #BBBBBB;
        text-align: center;
    }
    .gridHeader th
    {
        padding-bottom: 5px;
    }
    .gridRow {
        border-bottom: 1px solid #EEEEEE;
        height: 60px;
    }

    .imgColumn {
        width: 60px;
    }

    .itemNameColumn {
        /*width: 300px;*/
    }

    .numbersColumn {
        width: 100px;
        text-align: center;
    }

    .total {
        font-weight: bold;
    }

    .amount {
        color: #900;
    }

    .inclVAT {
        color: #888888;
    }
    .totalsTbl
    {
        margin-top: 0.8em;
    }
    .totalTd
    {
        padding-top: 5px;
        text-align: right;
    }
    .grandTotal
    {
        float: right;
        padding-top: 10px;
    }
    .grandTotalBox
    {
        border: 1px solid #BBBBBB;
        padding: 3px;
        background-color: #5EB6E4;
        display: inline;
    }
    .grandTotalVAT {
        margin-left: 3px;
    }

    .btnTd {
        text-align: right;
        padding-top: 1.5em;
    }

    .btnBackToCart {
        margin-right: 1.5em;
    }

    .addressBlock {
        width: 50%;
        float: left;
    }

    .addressContent {
        padding: 10px;
        border: solid 1px #BBB;
    }

    #DivShippingAddressContent {
        margin-left: 10px;
    }

    .addressTitle {
        width: 60%;
        float: left;
        padding-bottom: 5px;
    }

    .addressModifiers{
        width: 40%;
        float: left;
        text-align: right;
    }

    .clear {
        clear: both;
    }

    #DivCartItems {
        padding-top: 20px;
    }
</style>

<dnn2:CartBreadcrumb ID="CartBreadcrumb1" runat="server" CartCheckoutStep="SummaryStep" />

<asp:Panel ID="PnlEmptyCart" runat="server" Visible="False">
    <br />
    <asp:Label ID="LblEmptyCart" runat="server" ResourceKey="LblEmptyCart" Text=''></asp:Label>
    <br />
    <br />
</asp:Panel>
<asp:Panel ID="PnlNotEmptyCart" runat="server" Visible="False">
    <div class="addressBlock">
        <div id="DivBillingAddressContent" class="addressContent">
            <asp:Label ID="LblBillingAddressTitle" runat="server" ResourceKey="BillingAddressTitle" CssClass="AgapeH4 addressTitle"></asp:Label>
            <div class="addressModifiers">
                <asp:LinkButton ID="BtnModifyBillingAddress" runat="server" ResourceKey="BtnModify"></asp:LinkButton><br />
                <asp:LinkButton ID="BtnCopyShippingAddress" runat="server" ResourceKey="BtnCopyShippingAddress"></asp:LinkButton>
            </div>
            <div class="clear">
                <asp:Label ID="LblBillingAddress" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    <div id="DivShippingAddressBlock" runat="server" class="addressBlock">
        <div id="DivShippingAddressContent" class="addressContent">
            <asp:Label ID="LblShippingAddressTitle" runat="server" ResourceKey="ShippingAddressTitle" CssClass="AgapeH4 addressTitle"></asp:Label>
            <div class="addressModifiers">
                <asp:LinkButton ID="BtnModifyShippingAddress" runat="server" ResourceKey="BtnModify"></asp:LinkButton><br />
                <asp:LinkButton ID="BtnCopyBillingAddress" runat="server" ResourceKey="BtnCopyBillingAddress"></asp:LinkButton>
            </div>
            <div class="clear">
                <asp:Label ID="LblShippingAddress" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    <div id="DivCartItems" class="clear">
        <asp:Repeater ID="DrCart" runat="server">
            <ItemTemplate>
                <asp:HiddenField ID="HfItemType" Value='<%# eval("ItemType") %>' runat="server" />
                <asp:Label ID="LblCartSectionTitle" runat="server" Text='<%# LocalizeString(ItemType.GetName(Eval("ItemType")) & "SectionTitle")%>'
                    CssClass="AgapeH4"></asp:Label>
                <asp:GridView ID="GvCartSection" runat="server" AutoGenerateColumns="False" DataSource='<%# eval("Group") %>'
                    GridLines="None" CellPadding="5" HeaderStyle-HorizontalAlign="Left" RowStyle-HorizontalAlign="Left"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="" ItemStyle-CssClass="imgColumn">
                            <ItemTemplate>
                                <a href='<%# CartFunctions.GetCartItemLink(eval("ItemRef"), eval("ItemType")) %>'>
                                    <asp:Image ID="ImgItemPicture" runat="server" Width="50px" EnableViewState="False"
                                        ImageUrl='<%# CartFunctions.GetCartItemPictureURL(eval("ItemRef"), eval("ItemType")) %>' /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-CssClass="itemNameColumn">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfCartContentId" Value='<%# eval("CartContentId") %>' runat="server" />
                                <a href='<%# CartFunctions.GetCartItemLink(eval("ItemRef"), eval("ItemType")) %>'>
                                    <asp:Label ID="LblItemName" runat="server" Text='<%# eval("ItemName") %>' CssClass="AgapeH5"></asp:Label></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="numbersColumn">
                            <HeaderTemplate>
                                <asp:Label ID="LblUnitPriceHeader" runat="server" ResourceKey="LblUnitPriceHeader"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblUnitPrice" runat="server" Text='<%# StaffBrokerFunctions.GetFormattedCurrency(PortalId, (CDbl(eval("Cost"))+CDbl(eval("Tax"))).ToString(StrCurrencyAmountsPattern)) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="numbersColumn">
                            <HeaderTemplate>
                                <dnn:Label ID="LblDiscountHeader" runat="server" ResourceKey="LblDiscountHeader"
                                    Text=''></dnn:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblDiscountAmt" runat="server" Text='<%# StaffBrokerFunctions.GetFormattedCurrency(PortalId, (CDbl(eval("DiscountAmt"))).ToString(StrCurrencyAmountsPattern)) %>'
                                    Visible='<%# eval("DiscountAmt")<>0 %>'></asp:Label>
                                <asp:Label ID="LblDiscountPercent" runat="server" Text='<%# Bind("DiscountPercent", "{0:p0}") %>'
                                    Visible='<%# eval("DiscountPercent")<>0 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="numbersColumn">
                            <HeaderTemplate>
                                <asp:Label ID="LblQuantityHeader" runat="server" ResourceKey="LblQuantityHeader"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblQuantity" runat="server" Text='<%# Bind("Quantity") %>'
                                    ViewStateMode="Disabled"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="numbersColumn">
                            <HeaderTemplate>
                                <asp:Label ID="LblAmountHeader1" runat="server" ResourceKey="LblAmountHeader"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblAmount" runat="server" Text='<%# StaffBrokerFunctions.GetFormattedCurrency(PortalId, ((CDbl(eval("Cost"))+CDbl(eval("Tax")))*CDbl(eval("Quantity"))).ToString(StrCurrencyAmountsPattern)) %>'
                                    CssClass="amount"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="numbersColumn">
                            <HeaderTemplate>
                                <asp:Label ID="LblAmountHeader2" runat="server" ResourceKey="LblAmountHeader"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblCurrencyLeft" runat="server" Text='<%# StaffBrokerFunctions.GetSetting("Currency", PortalId) %>'
                                    Visible='<%# StaffBrokerFunctions.GetSetting("CurrencyLocation", PortalId) <> "Right" %>'
                                    CssClass="amount"></asp:Label>
                                <asp:Label ID="LblDonationAmount" runat="server" Text='<%# Bind("Cost", "{0:n0}") %>' ViewStateMode="Disabled"
                                    CssClass='<%# "amount"%>'></asp:Label>
                                <asp:Label ID="LblCurrencyRight" runat="server" Text='<%# StaffBrokerFunctions.GetSetting("Currency", PortalId) %>'
                                    Visible='<%# StaffBrokerFunctions.GetSetting("CurrencyLocation", PortalId) = "Right" %>'
                                    CssClass="amount"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="gridHeader" />
                    <RowStyle CssClass="gridRow" />
                </asp:GridView>
                <table cellpadding="5" width="100%" runat="server" id="TblSectionTotals">
                    <tr>
                        <td class="totalTd">
                            <asp:Label ID="LblTotalSectionGrossTitle" runat="server" Text="" CssClass="total"></asp:Label>
                            <asp:Label ID="LblTotalSectionGrossAmount" runat="server" Text="" CssClass="total amount"></asp:Label>
                            <asp:Label ID="LblTotalSectionVAT" runat="server" Text="" CssClass="inclVAT"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <SeparatorTemplate>
            </SeparatorTemplate>
        </asp:Repeater>
        <table cellpadding="5" width="100%" class="totalsTbl">
            <tr id="TrDeliveryCost" runat="server">
                <td class="totalTd">
                    <asp:Label ID="LblDeliveryGrossTitle" runat="server" ResourceKey="LblDeliveryGrossTitle" Text='' CssClass="total"></asp:Label>
                    <asp:Label ID="LblDeliveryGrossAmount" runat="server" Text="" CssClass="total amount"></asp:Label><asp:Label
                        ID="LblDeliveryVAT" runat="server" Text="" CssClass="inclVAT"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="totalTd">
                    <div class="grandTotal">
                        <div class="grandTotalBox">
                            <asp:Label ID="LblGrandTotalTitle" runat="server" ResourceKey="LblGrandTotalTitle" Text='' CssClass="total"></asp:Label>
                            <asp:Label ID="LblGrandTotalAmount" runat="server" Text="" CssClass="total amount"></asp:Label>
                        </div>
                        <asp:Label ID="LblGrandTotalVAT" runat="server" Text="" CssClass="inclVAT grandTotalVAT"></asp:Label>
                    </div>
                    <div class="clear" />
                </td>
            </tr>
            <tr>
                <td class="btnTd">
                    <asp:LinkButton ID="BtnBackToCart" runat="server" ResourceKey="BtnBackToCart" Text="" CssClass="btnBackToCart" />
                    <asp:Button ID="BtnPay" runat="server" ResourceKey="BtnPay" Text="" CssClass="aButton" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>

