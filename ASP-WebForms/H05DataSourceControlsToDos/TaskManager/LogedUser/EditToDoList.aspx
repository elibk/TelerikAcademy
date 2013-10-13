<%@ Page Title="EditToDoList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditToDoList.aspx.cs" Inherits="TaskManager.LogedUser.EditToDoList" %>
<asp:Content ID="ContentEditToDoList" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="LabelTitleToDo" AssociatedControlID="TextBoxTitleToDo">
    </asp:Label>
    <asp:TextBox runat="server" ID="TextBoxTitleToDo" >
    </asp:TextBox>

     <asp:Label runat="server" ID="LabelContentToDo" AssociatedControlID="TextBoxContentToDo">
    </asp:Label>
    <textarea runat="server" id="TextBoxContentToDo">

    </textarea>
    <asp:Button runat="server" ID="UpdateToDoList" CssClass="btn btn-primary btn-large" Text="Update" OnClick="UpdateToDoList_Click"/>
</asp:Content>
