<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <h1>Books</h1>
    <div class="text-right">
         <div class="col-lg-6">
        <div class="input-group">
            <input runat="server" id="SearchInput" class="form-control" type ="text" placeholder="Search by book title / author..." />
            <asp:Button runat="server" ID="SerachButton" Text="Search" OnClick="SerachButton_Click" CssClass="btn"/>
        </div>
        </div>
    </div>
    <asp:ListView ID="ListViewBooks" runat="server" 
            ItemType="LibrarySystem.Models.Category"
            DataKeyNames="Id" SelectMethod="ListViewBooks_GetData">

            <LayoutTemplate>
                <span runat="server" id="itemPlaceholder" />
                <div class="pagerLine">
                    <asp:DataPager ID="DataPagerCustomers" runat="server" PageSize="4">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True" 
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="True" 
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>

            <EmptyDataTemplate>
                <div>No data was returned.</div>
            </EmptyDataTemplate>

            <ItemTemplate>
                <h1><%# Item.Title %></h1>
                <ul>
                   <asp:repeater id="ChildRepeater" runat="server" ItemType="LibrarySystem.Models.Book" DataSource="<%# Item.Books  %>">
                    <ItemTemplate>
                          
                            <li><a href="<%# string.Format("BookDetails.aspx?id={0}", DataBinder.Eval(Container.DataItem, "id"))%>"> <%#:DataBinder.Eval(Container.DataItem, "title")%> </a></li>
                          
                   </ItemTemplate>
                    </asp:repeater>
                </ul>
            </ItemTemplate>
        </asp:ListView>
</asp:Content>
