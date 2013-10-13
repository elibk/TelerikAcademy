<%@ Page  Title="Task01" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="T01HtmlControls.aspx.cs" Inherits="WebAndHtmlControls.T01HtmlControls" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
        <asp:Panel runat="server" ID="container">
            <div>
                <asp:Label Text="Bottom border:" runat="server" AssociatedControlId="minValue" />
               <asp:TextBox runat="server" ID="minValue" />
            </div>
            <div>
                <asp:Label Text="Top border:" runat="server" AssociatedControlId="maxValue" />
                <asp:TextBox runat="server" ID="maxValue" />
            </div>
            <asp:Button Width="80px" Text="Generate" runat="server" ID="ButtonGenerate" OnClick="ButtonGenerateRandom_Click" />
        </asp:Panel>
  
</asp:Content>
