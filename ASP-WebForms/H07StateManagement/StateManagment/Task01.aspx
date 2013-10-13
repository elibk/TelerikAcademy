<%@ Page Title="ClientIP" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Task01.aspx.cs" Inherits="StateManagment.Task01" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        User IP from request :  <asp:Literal runat="server" ID="UserID" Mode="Encode" Text="" /> 
    </p>
</asp:Content>