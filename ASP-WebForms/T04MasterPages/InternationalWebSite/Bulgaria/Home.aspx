<%@ Page Title="Начало" Language="C#" AutoEventWireup="true"  MasterPageFile="~/NestedMasterBulgaria.master" CodeBehind="Home.aspx.cs" Inherits="InternationalWebSite.Bulgaria.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Content" runat="server">
     <header>
        <h1><%: Title %></h1>
        <p class="lead">Добре дошли на нашата начална страница.</p>
    </header>

    <div class="row-fluid">
        <div class="span12">
            <p>Това е нашата начална страница.</p>
        </div>
    </div>
</asp:Content>