﻿<%@ Page Title="Task02" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="H02TextFromServer.aspx.cs" Inherits="IntroWebForms.H02TextFromServer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


   
    <p> Executing assembly location: ->  <asp:Literal ID="AssemblyLocation" runat="server"></asp:Literal></p>
    <p> Path to the assambly: ->  <asp:Literal ID="AssemblyPath" runat="server"></asp:Literal></p>

    <h1 runat="server" id="GreetingTxt">Hello ASP.Net!</h1>
    <p>I was here!</p>
    <h1 runat="server" id="ServerGeneratedTxt"></h1>
    <p>I'm generated by the server!</p>
</asp:Content>
