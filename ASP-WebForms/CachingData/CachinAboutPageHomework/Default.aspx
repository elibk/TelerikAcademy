<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CachinAboutPageHomework._Default" %>
<%@ Register Src="~/CacheableUserControl.ascx" TagPrefix="my" TagName="CacheableUserControl" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <em>Last actualisation <%= DateTime.Now %></em>
    <div class="hero-unit">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-large">Learn more &raquo;</a></p>
    </div>
    <div>
      
        <my:CacheableUserControl runat="server" />
    </div>
</asp:Content>
