<%@ Page Title="Task01" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="H01HelloBox.aspx.cs" Inherits="IntroWebForms.H01HelloBox" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <div>
        <asp:Label ID="GreetingLabel" runat="server" Text="Enter your name:"></asp:Label>
        <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
        <asp:Button ID="SubmitBtn" runat="server" Text="Submit" OnClick="SubmitBtn_Click" />
        <h1 id="Greeting" runat="server"></h1>
    </div>

</asp:Content>