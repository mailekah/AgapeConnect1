﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ScelliusPayment.ascx.vb" Inherits="DotNetNuke.Modules.AgapeFR.Cart.Payment.ScelliusPayment" %>
<script type="text/javascript">
    (function ($, Sys) {
        function setUpMyPage() {
        
            $('.aButton').button();
           
        }
        $(document).ready(function () {
            setUpMyPage();
          
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                setUpMyPage();
            });
        });
    }(jQuery, window.Sys));

</script>
<iframe id="IfrScelliusCall" src="/DesktopModules/AgapeFR/Cart/PaymentProviders/ScelliusPaymentFrame.aspx" width="1050" height="200" style="border: none; overflow: auto;" runat="server" visible="false"></iframe>
<%--Hide this on return--%>

<div id="divPaymentCanceled" runat="server" visible="false">
    <%--Show this on return--%>
    Il semble que vous ayez annulé le paiement de votre panier.<br />
    Que voulez-vous faire maintenant ?
    <div style="margin-top:10px;">
        <asp:Button ID="BtnPayAgain" runat="server" ResourceKey="BtnPayAgain" CssClass="aButton" Text="Again" />
        <asp:Button ID="BtnModifyCart" runat="server" ResourceKey="BtnModifyCart" CssClass="aButton" Text="Modify" />
        <asp:Button ID="BtnEmptyCart" runat="server" ResourceKey="BtnEmptyCart" CssClass="aButton" Text="Empty"/>
    </div>
</div>
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

