<%@ Page Title="Count of users in application" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Task05.aspx.cs" Inherits="StateManagment.Task05" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <p> Visitors since the application is runing -></p>
    <asp:PlaceHolder ID="plVisitors" runat="server" />
</asp:Content>
