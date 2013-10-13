<%@ Page Title="Home" Language="C#" AutoEventWireup="true"  MasterPageFile="~/NestedMasterItalia.master" CodeBehind="Home.aspx.cs" Inherits="InternationalWebSite.Italia.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Content" runat="server">
     <header>
        <h1><%: Title %></h1>
        <p class="lead">Benvenuti nella nostra home page.</p>
    </header>

    <div class="row-fluid">
        <div class="span12">
            <p>Questa è la nostra home page.</p>
        </div>
    </div>
</asp:Content>