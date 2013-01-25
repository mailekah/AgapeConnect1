<%@ Control Language="C#" AutoEventWireup="false" Inherits="DotNetNuke.Modules.SearchResults.UKSearchResults" CodeFile="SearchResults.ascx.cs" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<script type="text/javascript">
    (function ($, Sys) {
        function setUpMyPager() {
            if ($('.PagingTable')[0]) {
                $('.dnnSearchResults').append('<br/><br/><div>Hello World</div>');
            }
            //$('.PagingTable').hide();
        }
        $(document).ready(function () {
            setUpMyPager();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                setUpMyPager();
            });
        });
    }(jQuery, window.Sys));
</script>
<style type="text/css">
    .seachImage {
        width: 80px;
        border: 1pt solid black;
    }

    .dnnGridItem:hover, .dnnGridAltItem:hover {
        border: 2px solid Blue;
    }
</style>
<div id="numPages">
    <asp:HiddenField ID="hfNumPages" runat="server" />
</div>
<div id="currentPage">
    <asp:HiddenField ID="hfCurrentPage" runat="server" />
</div>
<div class="Agape_Orange_H3">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
</div>
<br />
<br />
<div class="dnnForm dnnSearchResults dnnClear">
    <asp:Label CssClass="Agape_Search_Subtitle" ID="lblMessage" runat="server" /><br />
    <br />
    <asp:DataGrid ID="dgResults" runat="server" AutoGenerateColumns="False" AllowPaging="true" BorderStyle="None" ShowHeader="False" GridLines="None" PagerStyle-Visible="false">
        <ItemStyle CssClass="dnnGridItem" HorizontalAlign="Left" VerticalAlign="Top" />
        <AlternatingItemStyle CssClass="dnnGridAltItem" />
        <FooterStyle CssClass="dnnGridFooter" />
        <Columns>

            <asp:TemplateColumn>
                <ItemTemplate>

                    <asp:HyperLink ID="lnkLink" runat="server" CssClass="CommandButton" NavigateUrl='<%# FormatURL((int)DataBinder.Eval(Container.DataItem,"TabId"),(string)DataBinder.Eval(Container.DataItem,"Guid")) %>'>

                        <table>
                            <tr valign="top">
                                <td>
                                    <asp:Image ID="imgImage" runat="server" ImageUrl='<%# (string)DataBinder.Eval(Container.DataItem, "Image")  %>' CssClass="seachImage" />
                                    <asp:Label ID="lblTest" runat="server" Text='<%# testImageString((string)DataBinder.Eval(Container.DataItem, "Image")) %>'></asp:Label>

                                </td>

                                <td width="100%">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="SubHead AgapeH4" NavigateUrl='<%# FormatURL((int)DataBinder.Eval(Container.DataItem,"TabId"),(string)DataBinder.Eval(Container.DataItem,"Guid")) %>' Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' />
                                    <br />

                                    <asp:Panel ID="Panel1" runat="server" CssClass="Agape_Story_subtitle">
                                        <asp:Label ID="Label1" runat="server" CssClass="Normal" Text='<%# DataBinder.Eval(Container.DataItem, "AuthorName")  %>' Visible='<%#  ((string)DataBinder.Eval(Container.DataItem, "SearchKey")).StartsWith("S")  %>' />

                                        <asp:Label ID="Label2" runat="server" CssClass="Normal" Text='<%# FormatDate((DateTime)DataBinder.Eval(Container.DataItem, "PubDate")) %>' />


                                        <br />
                                    </asp:Panel>

                                    <asp:Label ID="Label3" runat="server" CssClass="Normal" Text='<%# DataBinder.Eval(Container.DataItem, "Description") + "<br>" %>' Visible="<%# !String.IsNullOrEmpty(ShowDescription()) %>" />

                                </td>
                            </tr>
                        </table>



                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid><dnn:PagingControl ID="ctlPagingControl" runat="server" Mode="PostBack" />
</div>
