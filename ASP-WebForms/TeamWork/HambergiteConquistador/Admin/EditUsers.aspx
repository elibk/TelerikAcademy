<%@ Page Title="EditUsers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUsers.aspx.cs" Inherits="HambergiteConquistador.Admin.EditUsers" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button runat="server" CssClass="btn btn-large" ID="ShowActive" OnClick="ShowActive_Click" Text="Active Users" /> 
    <asp:Button runat="server" CssClass="btn btn-large" ID="ShowAll" OnClick="ShowAll_Click" Text="All Users" /> 
    <asp:Button runat="server" CssClass="btn btn-large" ID="ShowDisabled" OnClick="ShowDisabled_Click" Text="Disabled Users"  /> 

    <asp:GridView 
        ID="GridViewEditUsers"
        runat="server" 
        AllowPaging="true" PageSize="5"
        AllowSorting="true" 
        ItemType="HambergiteConquistador.Models.AspNetUser" 
        DataKeyNames="Id" 
        SelectMethod="GridViewEditUsers_GetData" 
        AutoGenerateColumns="false" 
        UpdateMethod="GridViewEditUsers_UpdateItem" 
        CssClass="text-center container well" AutoGenerateEditButton="true" >
        <EmptyDataTemplate>
            <p>No users found.</p>
        </EmptyDataTemplate>

        <Columns>

            <asp:BoundField HeaderText="Username" SortExpression="Username" DataField="UserName" />
            <asp:BoundField HeaderText="Score" SortExpression="Score" DataField="Score" />
            <asp:BoundField HeaderText="Bonus Point" SortExpression="Bonus" DataField="Bonus" />
            <asp:TemplateField HeaderText ="Sign In">
                <EditItemTemplate>
                    <asp:CheckBox runat="server" Checked="<%# Item.AspNetUserManagement.DisableSignIn %>" Text="Disable Sign In"/>
                </EditItemTemplate>
                
                <ItemTemplate>
                    <p><%# (Item.AspNetUserManagement.DisableSignIn? "Disabled" : "Enabled")  %></p>
                </ItemTemplate>
            </asp:TemplateField>
            
        
            
            <asp:HyperLinkField runat="server" DataNavigateUrlFormatString="~/Admin/UpdateUserRoles.aspx?userName={0}" DataNavigateUrlFields="UserName"  Text="Update roles"></asp:HyperLinkField>
            <asp:HyperLinkField runat="server" DataNavigateUrlFormatString="~/Admin/ChangeUserPassword.aspx?userName={0}" DataNavigateUrlFields="UserName"  Text="Change Password"></asp:HyperLinkField>
            
        </Columns>
    </asp:GridView>
</asp:Content>