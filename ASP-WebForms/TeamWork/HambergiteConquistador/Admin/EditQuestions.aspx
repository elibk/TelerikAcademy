<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditQuestions.aspx.cs" Inherits="HambergiteConquistador.Admin.EditAnswers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <%-- <asp:Button ID="SelectApproved"  runat="server" Text="Select Approved" OnClick="SelectApproved_Click"/>
     <asp:Button ID="SelectUnApproved"  runat="server" Text="Select UnApproved" OnClick="SelectUnApproved_Click"/>--%>

     <h3>Edit questions</h3>

    <asp:GridView runat="server" ID="GridViewQuestions"
            AllowPaging="true" 
            AllowSorting="true" 
            ItemType="HambergiteConquistador.Models.Question"
            DataKeyNames="Id" 
            SelectMethod="GridViewQuestions_GetData"
            AutoGenerateColumns="false" 
            PageSize="5"
            CssClass="table table-bordered text-center"> 
         <Columns>  
           <asp:BoundField HeaderText="Question Text" SortExpression="TextContent" DataField="TextContent"/>
           <asp:CheckBoxField HeaderText="IsApproved" SortExpression="IsApproved" DataField="IsApproved" />
             <asp:TemplateField HeaderText ="Action">
                        <EditItemTemplate>
                        </EditItemTemplate>
                
                        <ItemTemplate>
                            <asp:Button ID="ButtonEditBook" Text="Edit" runat="server" OnCommand="ButtonEditBook_Command" CommandArgument="<%#: Item.Id %>"
                                   CssClass="btn btn-link" />
                             <asp:Button ID="ButtonDeleteBook"  runat="server" Text="Delete" OnCommand="Delete_Command" CommandArgument="<%#: Item.Id %>"
                                   CssClass="btn btn-link" />
                        </ItemTemplate>
                    </asp:TemplateField>
         </Columns>
    </asp:GridView>
         
</asp:Content>
