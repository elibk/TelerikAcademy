<%@ Page  Title="Task02" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="T02WebControls.aspx.cs" Inherits="WebAndHtmlControls.T02WebControls" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
        <label for="minValue">Bottom border:</label>    
        <input id="minValue" type="text" runat="server" />
        <label for="minValue">Top border:</label>    
        <input id="maxValue" type="text" runat="server" />
        <input id="ButtonGenerate" type="button"
            runat="server" value="Generate random"
            onserverclick="ButtonGenerateRandom_Click" />
</asp:Content>
