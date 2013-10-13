<%@ Page Title="AllCategories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllCategories.aspx.cs" Inherits="TaskManager.LogedUser.AllCategories" %>
<asp:Content ID="ContentAllCategories" ContentPlaceHolderID="MainContent" runat="server">
    <span runat ="server" id="storedValue" style="display:none"></span>
     <div class="text-center">
        <asp:Button  runat="server" CssClass="btn" Text="Ok" ID="ConfirmButton" OnClick="ConfirmButton_Click"/>
        <asp:Button  runat="server" CssClass="btn" Text="Cancel" ID="CanselButton" OnClick="CanselButton_Click"/>
     </div>
    <asp:GridView ID="GridViewCategories" runat="server" ViewStateMode="Disabled"
        AutoGenerateColumns="False" DataKeyNames="Id"
        PageSize="3" AllowPaging="true" AllowSorting="true"
        SelectMethod="GridViewCategories_GetData"
        DeleteMethod="GridViewCategories_DeleteItem" 
        UpdateMethod="GridViewCategories_UpdateItem" CssClass="table" ItemType="TaskManager.Models.Category">
        <EmptyDataTemplate>
            No categories, yet
        </EmptyDataTemplate>
        <Columns>            
             <asp:BoundField DataField="Title" HeaderText="Title"
                SortExpression="Title" />    
            <asp:CommandField ShowSelectButton="True" SelectText="Details..." HeaderText="More" />
            <asp:CommandField ShowDeleteButton="True" SelectText="Delete" HeaderText="Delete" />
            <asp:CommandField ShowEditButton="True" SelectText="EditTitle" HeaderText="Edit" />
        </Columns>
    </asp:GridView>
    <asp:TextBox runat ="server" ID="NewCategoryTitle"></asp:TextBox>
    <asp:Button runat="server" ID="CreateCategory" Text="Create category" CssClass="btn btn-primary btn-large" OnClick="CreateCategory_Click"/>
</asp:Content>
