<%@ Page Title="Chat Room - admins" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminsPage.aspx.cs" Inherits="WebFormsTemplate.AdminsPage" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    <header>
        <h1><%: Title %></h1>
        <p class="lead">Go chat</p>
    </header>
    <div>
        <asp:ListView ID="usersPosts" runat="server"
            SelectMethod="usersPosts_GetData" 
            UpdateMethod="usersPosts_UpdateItem" 
             DeleteMethod="usersPosts_DeleteItem"
            ItemType="Data.Post"
            DataKeyNames="Id">
            <LayoutTemplate>
                <div>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </div>

            </LayoutTemplate>
            <ItemTemplate>
                <div>
                    <p><strong><%#: Item.AspNetUser.DisplayName %></strong>: </p>
                    <p><%#: Item.Text %></p>
                    <asp:Button ID="ButtonEdit" CssClass="btn" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="ButtonDelete" CssClass="btn" runat="server" CommandName="Delete" Text="Delete" />

                </div>
            </ItemTemplate>
            <EditItemTemplate>
                <div>
                    <asp:TextBox ID="TextEdit" runat="server" Text='<%#: BindItem.Text %>'></asp:TextBox>
                    <br />
                    <asp:Button ID="ButtonUpdate" CssClass="btn" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="ButtonCancel" CssClass="btn" runat="server" CommandName="Cancel" Text="Cancel" />
                </div>

            </EditItemTemplate>
        </asp:ListView>

        <div>
                   <asp:TextBox runat="server" ID="usersPostText" Columns="20" Rows="10"></asp:TextBox>

            <asp:Button ID="makePostBtn" runat="server" CssClass="btn" OnClick="makePostBtn_Click" Text="Send" />
        </div>
    </div>
</asp:Content>
