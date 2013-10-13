<%@ Page Title="Home" Language="C#" AutoEventWireup="true"  MasterPageFile="~/NestedMasterEngland.master" CodeBehind="Home.aspx.cs" Inherits="InternationalWebSite.England.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Content" runat="server">
     <header>
        <h1><%: Title %></h1>
        <p class="lead">Wellcome to our home page.</p>
    </header>

    <div class="row-fluid">
        <div class="span12">
            <p>This is our home page.</p>
        </div>
    </div>
</asp:Content>