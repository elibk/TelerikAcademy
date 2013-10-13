<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Task02.aspx.cs" Inherits="Validation.Task02" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
      <asp:ValidationSummary 
        ID="ValidationSummaryLoginInfo" runat="server" CssClass="text-error"
        DisplayMode="SingleParagraph" ShowValidationErrors="true" ValidationGroup="LoginInfo" /> 

    <asp:ValidationSummary 
        ID="ValidationSummaryPersonalInfo" runat="server" CssClass="text-warning"
        DisplayMode="SingleParagraph" ShowValidationErrors="true" ValidationGroup="PersonalInfo" /> 

    <asp:ValidationSummary 
        ID="ValidationSummaryAddressInfo" runat="server" CssClass="text-danger" ValidationGroup="AddressInfo"
        DisplayMode="SingleParagraph" ShowValidationErrors="true" /> 

    <asp:ValidationSummary 
        ID="ValidationSummaryAllOthers" runat="server" CssClass="lead"
        DisplayMode="SingleParagraph" ShowValidationErrors="true" /> 

    <div class="form-horizontal" runat="server" id="formForLogin">

         <div class="control-group">
            <asp:Label runat="server" ID="LabelUserName" AssociatedControlID="TextBoxUserName" Text="User Name" CssClass="control-label" />
            <div class="controls">
                <asp:TextBox ID="TextBoxUserName" runat="server" Text="User Name"></asp:TextBox>
            </div>
        </div>

        <div class="control-group">
            <asp:Label runat="server" ID="LabelPasswordInput" AssociatedControlID="TextBoxPassword" Text="Password" CssClass="control-label" />
            <div class="controls">
                <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" Text="Password"></asp:TextBox>
            </div>
        </div>

        <div class="control-group">
            <asp:Label runat="server" ID="LabelPasswordRepeat" AssociatedControlID="TextBoxPasswordRepeat" Text="Repeat Password" CssClass="control-label" />
            <div class="controls">
                <asp:TextBox ID="TextBoxPasswordRepeat" TextMode="Password" runat="server" Text="Password"></asp:TextBox>
            </div>
        </div>

         <div class="control-group">
            <asp:Label runat="server" ID="LabelFirstName" AssociatedControlID="TextBoxFirstName" Text="First Name" CssClass="control-label" />
            <div class="controls">
                <asp:TextBox ID="TextBoxFirstName" runat="server" Text="First Name"></asp:TextBox>
            </div>
        </div>

          <div class="control-group">
            <asp:Label runat="server" ID="LabelLastName" AssociatedControlID="TextBoxLastName" Text="Last Name" CssClass="control-label" />
            <div class="controls">
                <asp:TextBox ID="TextBoxLastName" runat="server" Text="Last Name"></asp:TextBox>
            </div>
        </div>

         <div class="control-group">
            <asp:Label runat="server" ID="LabelAge" AssociatedControlID="TextBoxLastName" Text="Age" CssClass="control-label" />
            <div class="controls">
                <asp:TextBox ID="TextBoxAge" runat="server" Text="Age"></asp:TextBox>
            </div>
        </div>

        <div class="control-group">
            <asp:Label runat="server" ID="LabelEmail" AssociatedControlID="TextBoxEmail" Text="Email" CssClass="control-label" />
            <div class="controls">
                <asp:TextBox ID="TextBoxEmail" runat="server" Text="some@mail.bg"></asp:TextBox>
            </div>
        </div>

         <div class="control-group">
            <asp:Label runat="server" ID="LabelLocalAddress" AssociatedControlID="TextBoxLocalAddress" Text="Local Address" CssClass="control-label" />
            <div class="controls">
                <asp:TextBox TextMode="multiline" Columns="50" Rows="5" ID="TextBoxLocalAddress" runat="server" Text="Local Address..."></asp:TextBox>
            </div>
        </div>

        <div class="control-group">
            <asp:Label runat="server" ID="LabelPhone" AssociatedControlID="TextBoxPhone" Text="Phone" CssClass="control-label" />
            <div class="controls">
                <asp:TextBox ID="TextBoxPhone" runat="server" Text="(000)000-0000"></asp:TextBox>
            </div>
        </div>

        <div class="control-group">
            <div class="controls">
                <label class="checkbox">
                    I accept
                 <asp:CheckBox runat="server" ID="CheckboxAccept" />
                </label>
                
                <asp:Button runat="server" ID="SendData" CssClass="btn btn-large" Text="Sign in" CausesValidation="true" OnClientClick="return (Page_ClientValidate('LoginInfo') && Page_ClientValidate('PersonalInfo') && Page_ClientValidate('AddressInfo'));" OnClick="Submit_Click" />
            </div>
        </div>
    </div>

     <asp:RequiredFieldValidator 
         Display="None"
         runat="server" 
         ControlToValidate="TextBoxUserName" 
         ErrorMessage="The Field UserName is required.<br/>" ValidationGroup="LoginInfo"/>

     <asp:RequiredFieldValidator 
         Display="None"
         runat="server" 
         ControlToValidate="TextBoxPassword" 
         ErrorMessage="The Field Password is required.<br/>" ValidationGroup="LoginInfo"/>
     <asp:CustomValidator
        id="MatchingPasswordValidator"
        runat="server"
        OnServerValidate="MatchingPasswordValidator_ServerValidate"
        ErrorMessage="The Password and Repeat Password should match.<br/>"
        ControlToValidate="TextBoxPassword" Display="None" />

     <asp:RequiredFieldValidator 
         Display="None"
         runat="server" 
         ControlToValidate="TextBoxPasswordRepeat" 
         ErrorMessage="The Field Password Repeat is required.<br/>" ValidationGroup="LoginInfo"/>

    <asp:RequiredFieldValidator 
         Display="None"
         runat="server" 
         ControlToValidate="TextBoxFirstName" 
         ErrorMessage="The Field First Name is required.<br/>"/>

    <asp:RequiredFieldValidator 
         Display="None"
         runat="server" 
         ControlToValidate="TextBoxLastName" 
         ErrorMessage="The Field Last Name is required.<br/>"/>

     <asp:RequiredFieldValidator 
         Display="None"
         runat="server" 
         ControlToValidate="TextBoxAge" 
         ErrorMessage="The Field Age is required.<br/>"/>
    <asp:RangeValidator
        Display="None"
         runat="server" 
         ControlToValidate="TextBoxAge" 
         ErrorMessage="The Age must be from 18 to 81.<br/>"
         MinimumValue="18"
         MaximumValue="81"
         Type="Integer" ValidationGroup="PersonalInfo"/>

     <asp:RequiredFieldValidator 
         Display="None"
         runat="server" 
         ControlToValidate="TextBoxEmail" 
         ErrorMessage="The Field Email is required.<br/>"/>
    <asp:RegularExpressionValidator
        runat="server"
        ControlToValidate="TextBoxEmail"
        ValidationExpression="^((?:(?:(?:[a-zA-Z0-9][\.\-\+_]?)*)[a-zA-Z0-9])+)\@((?:(?:(?:[a-zA-Z0-9][\.\-_]?){0,62})[a-zA-Z0-9])+)\.([a-zA-Z0-9]{2,6})$"
        ErrorMessage="The Email must be in format 'some@mail.bg'.<br/>" ValidationGroup="AddressInfo"/>


      <asp:RequiredFieldValidator 
         Display="None"
         runat="server" 
         ControlToValidate="TextBoxLocalAddress" 
         ErrorMessage="The Field Local Address is required.<br/>" ValidationGroup="AddressInfo"/>

     <asp:RequiredFieldValidator 
         Display="None"
         runat="server" 
         ControlToValidate="TextBoxPhone" 
         ErrorMessage="The Field Phone is required.<br/>"/>
     <asp:RegularExpressionValidator
        runat="server"
        ControlToValidate="TextBoxPhone"
        ValidationExpression="^\(\d{3}\) ?\d{3}( |-)?\d{4}|^\d{3}( |-)?\d{3}( |-)?\d{4}"
        ErrorMessage="The Phone must be in format '(000)000-0000'.<br/>" ValidationGroup="AddressInfo"/>
    
     <asp:CustomValidator 
        id="AcceptValidator" 
        Display="None"
        runat="server" 
        OnServerValidate="AcceptValidator_ServerValidate"
        ErrorMessage="You have to accept what we propose. ;)<br/>"
        ClientValidationFunction="CheckBoxRequired_ClientValidate" />
</asp:Content>
