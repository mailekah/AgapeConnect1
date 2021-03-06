<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>
<div class="Container-10393-1">
	<div class="contentmain1"> 	
		<div class="c_top">
			<div class="dnntitle">
				<dnn:TITLE runat="server" id="dnnTITLE1" CSSClass="title1" />
			</div>
		</div>
		<dnn:ACTIONS runat="server" id="dnnACTIONS" />
		<div class="contentpane" id="ContentPane" runat="server"></div>
		<div class="c_footer_1"><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON1" CommandName="AddContent.Action" DisplayIcon="True" DisplayLink="True" /><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON3" CommandName="PrintModule.Action" DisplayIcon="True" DisplayLink="False" /><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON2" CommandName="SyndicateModule.Action" DisplayIcon="True" DisplayLink="False" /><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON4" CommandName="ModuleSettings.Action" DisplayIcon="True" DisplayLink="False" /></div>   
	</div>
</div>








