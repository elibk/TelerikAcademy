<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibrarySystem.BookDetails" %>
<asp:Content ID="ContentBookDetails" ContentPlaceHolderID="MainContent" runat="server">
    <section>
    <header>
    <h1><%: Title %></h1>    
    <p class="lead">
        <i  runat="server" id="BookTitle"></i>
    </p>

    <p>
         <i  runat="server" id="BookAuthor"></i>
    </p>
    <p>
         <i  runat="server" id="BookISBN"></i>
    </p>

     <p>
         <i runat="server" id="BookWebSite"></i>
    </p>
   </header>
        <section>
            <p runat="server" id="BookDescription"></p>
        </section>
   </section>
   <%--<input name="btnBack" class="btn-link" title="Previous Page" onclick="location.href = 'javascript:history.go(-1)'" type="button"
    value="Previous Page" >--%>

    <a href="Default.aspx" class="btn-link">Back to books</a>
</asp:Content>
