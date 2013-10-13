<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayGame.aspx.cs" Inherits="HambergiteConquistador.LoggedUser.PlayGame" %>
<%@ Register Src="~/Controls/MakePictureFromText/MakePictureFromText.ascx" TagPrefix="userControl" TagName="MakePictureFromText" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="text-center"> Play Game Page </h2>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h4 class="text-center">Score:
                <asp:Literal ID="LiteralScore" runat="server" Mode="Encode" /></h4>
            <h4 class="text-center">Bonus Points:
                <asp:Literal ID="LiteralBonus" runat="server" Mode="Encode" /></h4>

            <h4 class="text-left">Question:</h4>
            <userControl:MakePictureFromText runat="server" ID="MakePictureFromText" />
            <h3 class="text-left">
                <asp:Literal ID="LiteralAnswer" runat="server" Mode="Encode" /></h3>

            <asp:RadioButtonList ID="RadioButtonListAnswers" runat="server"
                CssClass="inline text-center"
                DataTextField="ContentText"
                DataValueField="Id"
                RepeatLayout="UnorderedList">
            </asp:RadioButtonList>
        </ContentTemplate>
    </asp:UpdatePanel>    
        
    <div class="text-center">
        <div class="btn-group btn-group-justified">
            <asp:Button ID="ButtonSubmit" Text="Submit Answer" runat="server" OnClick="ButtonSubmit_Click" CssClass="btn btn-success" />
            <asp:Button ID="ButtonJoker25" ToolTip="You need 10 bonus points." Text="Joker 25%" runat="server" OnClick="ButtonJoker25_Click" CssClass="btn"/>
            <asp:Button ID="ButtonJoker50" ToolTip="You need 20 bonus points." Text="Joker 50%" runat="server" OnClick="ButtonJoker50_Click" CssClass="btn"/>
            <asp:Button ID="ButtonNextQuestion" Text="NextQuestion" runat="server" OnClick="ButtonNextQuestion_Click" CssClass="btn btn-primary"/>
        </div>
    </div>
    </asp:Content>