<%@ Page Title="AllToDoLists" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllToDoLists.aspx.cs" Inherits="TaskManager.AllToDoLists" %>
<asp:Content ID="AllToDoListsContent" ContentPlaceHolderID="MainContent" runat="server">
    <span runat ="server" id="storedValue" style="display:none"></span>
     <div class="text-center">
        <asp:Button  runat="server" CssClass="btn" Text="Ok" ID="ConfirmButton" OnClick="ConfirmButton_Click"/>
        <asp:Button  runat="server" CssClass="btn" Text="Cancel" ID="CanselButton" OnClick="CanselButton_Click"/>
     </div>
    <asp:GridView ID="GridViewToDoLists" runat="server" ViewStateMode="Disabled"
        AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table"
        PageSize="3" AllowPaging="true" AllowSorting="true"
        SelectMethod="GridViewToDoLists_GetData" OnSelectedIndexChanged="GridViewQuestions_SelectedIndexChanged" 
        DeleteMethod="GridViewToDoLists_RequestDelete" 
        UpdateMethod="GridViewToDoLists_UpdateItem" ItemType="TaskManager.Models.ToDoList">
        <Columns>            
             <asp:BoundField DataField="Title" HeaderText="Title"
                SortExpression="Title" /> 
              <asp:TemplateField  
                HeaderText="Category">
                     <EditItemTemplate>
                        <asp:DropDownList
                            ID="DDLContinentEdit" SelectMethod="DropDownList_Categories"
                            runat="server" DataTextField='Title'
                            DataValueField="Id"
                            SelectedValue='<%# BindItem.CategoryId %>'
                            AppendDataBoundItems="true">
                            <asp:ListItem Text="--Select category--" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>

                    <asp:Label Runat="server"
                    Text='<%#: Item.Category.Title %>' ID="LabelContinentName">
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>      
            <asp:CommandField ShowSelectButton="True" SelectText="Details..." HeaderText="More" />
            <asp:CommandField ShowDeleteButton="True" SelectText="Delete" HeaderText="Delete" />
            <asp:CommandField ShowEditButton="True" SelectText="EditTitle" HeaderText="Edit" />
            <asp:HyperLinkField HeaderText="EditList" DataNavigateUrlFormatString="EditToDoList.aspx?id={0}" DataNavigateUrlFields="Id" Text="Edit list"/>
        </Columns>
    </asp:GridView>

    <p runat="server" id="ContentToDoDisplay">

    </p>
    
</asp:Content>
