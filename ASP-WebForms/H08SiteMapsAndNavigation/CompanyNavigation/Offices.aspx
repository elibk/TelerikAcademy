<%@ Page Title="Offices" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Offices.aspx.cs" Inherits="CompanyNavigation.Offices" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>Our offices are:</p>
    <asp:Menu ID="NavigationMenu" StaticMenuStyle-CssClass="nav nav-tabs" runat="server" CssClass="verticalMenu" 
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText="" StaticDisplayLevels="2"
        DataSourceID="SiteMapDataSource">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" 
        ShowStartingNode="False" StartingNodeOffset="1" />
</asp:Content>
