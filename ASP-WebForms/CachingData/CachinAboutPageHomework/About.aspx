<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CachinAboutPageHomework.About" %>
<%@ Register Src="~/CacheableUserControl.ascx" TagPrefix="my" TagName="CacheableUserControl" %>
<%@ OutputCache CacheProfile="HourCaching" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <em>Last actualisation <%= DateTime.Now %></em>
        <h1><%: Title %></h1>
        <p class="lead">Your app description page.</p>
    </header>

    <div class="row-fluid">
        <div class="span12">
            <p>Use this area to provide additional information.</p>
        </div>
    </div>
    <div>
          <p>Not working in cached page.</p>
        <my:CacheableUserControl runat="server" />
    </div>
</asp:Content>
