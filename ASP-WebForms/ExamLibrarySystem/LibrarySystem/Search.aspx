<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LibrarySystem.Search" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="SerchResultsTitle" runat="server"></h1>

    <ul>
        <asp:Repeater ID="ListSerachResults" runat="server" ItemType="LibrarySystem.Models.Book" SelectMethod="ListSerachResults_GetData">
             <ItemTemplate>
                <li>
                   <a href="<%# string.Format("BookDetails.aspx?id={0}", DataBinder.Eval(Container.DataItem, "id"))%>"> 
                       <%#: string.Format("{0} by {1}", DataBinder.Eval(Container.DataItem, "Title"), DataBinder.Eval(Container.DataItem, "Author"))%> </a>
                    (<%#: string.Format("Category: {0}", DataBinder.Eval(Container.DataItem, "Category.Title")) %>)
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Content>
