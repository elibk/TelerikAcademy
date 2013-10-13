<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Task02.aspx.cs" Inherits="StateManagment.Task02" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox runat="server" ID="UserInput">
    </asp:TextBox>

    <asp:Button runat="server" id="SubmitUserInput" Text="Submit" OnClick="SubmitUserInput_Click"/>

    <p>User inputs: <asp:Label runat="server" ID="UserInputs"></asp:Label>
    </p>
</asp:Content>
