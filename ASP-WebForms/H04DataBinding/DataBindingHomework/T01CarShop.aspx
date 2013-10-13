<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="T01CarShop.aspx.cs" Inherits="DataBindingHomework.T01CarShop" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
     <div class="hero-unit">
         <asp:Literal ID="DisplayField" Mode="Encode" Text="" runat="server">
         </asp:Literal>
    </div>
    <div class="hero-unit">
        <asp:Label AssociatedControlID="DDLProducers" runat="server"><strong>Producer:</strong></asp:Label>
        <asp:DropDownList RepeatLayout="UnorderedList" ID="DDLProducers" AutoPostBack="true" OnSelectedIndexChanged="ListProducers_SelectedIndexChanged" runat="server" DataTextField="Name">
        </asp:DropDownList>
        <asp:CustomValidator 
            EnableClientScript ="false" 
            ID="CustomValidatorProducer" runat="server" 
            OnServerValidate="DropDown_OnServerValidate" 
            ErrorMessage="Field 'producer' is requierd." 
            ControlToValidate="DDLProducers" >

        </asp:CustomValidator>

        <asp:Label AssociatedControlID="DDLModels" runat="server"><strong>Model:</strong></asp:Label>
        <asp:DropDownList Enabled="false" RepeatLayout="UnorderedList" ID="DDLModels" runat="server">
            <asp:ListItem Value="-1">--Select--</asp:ListItem>
        </asp:DropDownList>
        <asp:CustomValidator EnableClientScript ="false" ID="CustomValidatorModel" runat="server" OnServerValidate="DropDown_OnServerValidate" ErrorMessage="Field 'model' is requierd." ControlToValidate="DDLModels" ></asp:CustomValidator>

        <asp:Label AssociatedControlID="ExtrasCheckBox" runat="server"><strong>Extras:</strong></asp:Label>
        <asp:CheckBoxList RepeatLayout="UnorderedList"  CssClass="inline"  ID="ExtrasCheckBox" runat="server"></asp:CheckBoxList>
        

        <asp:Label AssociatedControlID="RadioButtonListEngines" runat="server"><strong>Engine:</strong></asp:Label>
        <asp:RadioButtonList RepeatLayout="UnorderedList" CssClass="inline" ID="RadioButtonListEngines" runat="server"></asp:RadioButtonList>
        <asp:RequiredFieldValidator EnableClientScript ="false" ControlToValidate="RadioButtonListEngines" ID="RequiredFieldValidatorEngine" runat="server" ErrorMessage="Field 'engine' is requierd."></asp:RequiredFieldValidator>
       
        <asp:Button ID="SubmitCar" CssClass="btn btn-primary btn-large" runat="server" Text="Submit" OnClick="SubmitCar_Click" />
    </div>
</asp:Content>
