<%@ Page Title="CreateToDo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateToDo.aspx.cs" Inherits="TaskManager.LogedUser.CreateToDo" %>
<asp:Content ID="ContentCreateToDo" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="LabelTitleToDo" AssociatedControlID="TextBoxTitleToDo">
    </asp:Label>
    <asp:TextBox runat="server" ID="TextBoxTitleToDo" >
    </asp:TextBox>

     <asp:Label runat="server" ID="LabelContentToDo" AssociatedControlID="TextBoxContentToDo">
    </asp:Label>
    <textarea runat="server" id="TextBoxContentToDo">

    </textarea>
   
    <asp:DropDownList runat="server"
         ID="CategoryDDL"
         AppendDataBoundItems="true"
         DataTextField='Title'
         DataValueField="Id">
        <asp:ListItem Text="--Select category--" Value="-1"></asp:ListItem>

    </asp:DropDownList>

     <asp:Button runat="server" ID="CreateToDoList" CssClass="btn btn-primary btn-large" Text="Create" OnClick="CreateToDoList_Click"/>

</asp:Content>
