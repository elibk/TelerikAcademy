<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="LibrarySystem.LoggedUser.Categories" %>
<asp:Content ID="ContentCategories" ContentPlaceHolderID="MainContent" runat="server">

     <asp:GridView 
        ID="GridViewEditCategories"
        runat="server" 
        AllowPaging="true" 
        AllowSorting="true" 
        ItemType="LibrarySystem.Models.Category" 
        DataKeyNames="Id" 
        SelectMethod="GridViewEditCategories_GetData" 
        AutoGenerateColumns="false" PageSize="5" EnableViewState="false" >

        <Columns>

            <asp:BoundField HeaderText="Category Name" SortExpression="Title" DataField="Title" />
            <asp:TemplateField HeaderText ="Action">
                
                <ItemTemplate>

                     <asp:LinkButton CssClass="btn" Text="Edit" runat="server" 
                        CommandName="RequestEditCategory" CommandArgument="<%# Item.Id %>"
                        OnCommand="RequestEditCategory_Command"/>

                    <asp:LinkButton CssClass="btn" Text="Delete" runat="server" 
                        CommandName="RequestDeleteCategory" CommandArgument="<%# Item.Id %>"
                        OnCommand="RequestDeleteCategory_Command" />
                </ItemTemplate>
            </asp:TemplateField>
         
        </Columns>
    </asp:GridView>
    <asp:Panel id="FormCommand" runat="server" Visible="false">
    <div class="form-horizontal" role="form" >
        <h2 runat="server" id="RequestCommandText"></h2>
        
        <div class="form-group">
     <label for="RequestedCategoryName" class="inline">Category: </label>
    <input type="text" runat="server" class="inline" id="RequestedCategoryName" placeholder="Category name">
      
            </div>
        <div class="form-group">
        <div class="col-lg-offset-2 col-lg-10">
            <asp:Button CssClass="btn btn-default" runat="server" ID="Comfirm" Text="Ok"  OnClick="Comfirm_Click" />
            <asp:Button CssClass="btn btn-default" runat="server" ID="Cancel" Text="Cancel" OnClick="Cancel_Click"  />  
        </div>
        </div>
   
        </div>
        </asp:Panel>
    <asp:LinkButton CssClass="btn-link" Text="Create new" runat="server"  ID="RequestCreateCategoryButton"
                        CommandName="RequestCreateCategory"
                        OnCommand="RequestCreateCategory_Command" /> 
    
    <div>
     <a href="../Default.aspx" class="btn-link block">Back to books</a>
        </div>
</asp:Content>