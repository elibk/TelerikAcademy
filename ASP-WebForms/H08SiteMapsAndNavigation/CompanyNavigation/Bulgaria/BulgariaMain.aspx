<%@ Page Title="Bulgaria" Language="C#" MasterPageFile="~/BulgariaMaster.master" AutoEventWireup="true" CodeBehind="BulgariaMain.aspx.cs" Inherits="CompanyNavigation.Bulgaria.BulgariaMain" %>
<asp:Content ID="Content" ContentPlaceHolderID="BulgariaContentPlaceHolder" runat="server">
    <h2><%: Title %> Offices</h2>
    <asp:Menu ID="NavigationMenu" StaticMenuStyle-CssClass="nav nav-tabs" runat="server" CssClass="verticalMenu" 
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText=""
        DataSourceID="SiteMapDataSourceBulgaria">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSourceBulgaria" runat="server" 
        ShowStartingNode="False" StartingNodeOffset="5" />
</asp:Content>
