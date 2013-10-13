<%@ Page Title="UnitedKingdom" Language="C#" MasterPageFile="~/UnitedKingdomMaster.master" AutoEventWireup="true" CodeBehind="UnitedKingdomMain.aspx.cs" Inherits="CompanyNavigation.UnitedKingdom.UnitedKingdomMain" %>
<asp:Content ID="Content" ContentPlaceHolderID="UnitedKingdomContentPlaceHolder" runat="server">
    <h2><%: Title %> Offices</h2>

     <asp:Menu ID="NavigationMenu" StaticMenuStyle-CssClass="nav nav-tabs" runat="server" CssClass="verticalMenu" 
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText=""
        DataSourceID="SiteMapDataSourceUK" >
    </asp:Menu>
   <asp:SiteMapDataSource ID="SiteMapDataSourceUK" runat="server" 
        ShowStartingNode="False" StartingNodeOffset="5" />
</asp:Content>
