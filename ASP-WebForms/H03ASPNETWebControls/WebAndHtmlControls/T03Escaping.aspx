<%@ Page  Title="Task03" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="T03Escaping.aspx.cs" Inherits="WebAndHtmlControls.T03Escaping" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
        <asp:Panel runat="server" ID="container">
            <div>
                <asp:Label Text="First value:" runat="server" AssociatedControlId="firstTxtBox" />
               <asp:TextBox runat="server" ID="firstTxtBox" Text="<script>alert('hacked')</script>" />
            </div>
            <div>
                <asp:Label Text="Second value:" runat="server" AssociatedControlId="secondTxtBox" />
                <asp:TextBox runat="server" ID="secondTxtBox" />
            </div>
            <asp:Button Text="Exchnage values" runat="server" OnClick="ButtonExchangeValues_Click" />
             <div>
                <asp:Literal Mode="Encode" Text ="" runat="server" ID="displayField" />
            </div>
        </asp:Panel>
</asp:Content>
