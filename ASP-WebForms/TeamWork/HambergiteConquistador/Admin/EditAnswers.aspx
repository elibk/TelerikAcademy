<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAnswers.aspx.cs" Inherits="HambergiteConquistador.Admin.EditAnswers1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <input name="btnBack" title="Previous Page" onclick="location.href = 'javascript:history.go(-1)'" type="button"
    value="Previous Page" class="btn btn-primary"><br />
    <h3>Edit Answer</h3>
    <div class="form-inline">
        <asp:Label runat="server" Text="New answer:" CssClass="form-group"></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxEdit" CssClass="form-control"></asp:TextBox>
        <asp:CheckBox runat="server" ID="CheckBoxIsCorrect" />
        <asp:Label ID="LabesIsCorrect" runat="server" Text="Is Correct" />
        <asp:Button runat="server" Text="Save changes" OnCommand="EditAnswer_Command" CssClass="btn btn-success"/>
    </div>
</asp:Content>
