<%@ Page  Title="Task04" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="T04RegistrationForm.aspx.cs" Inherits="WebAndHtmlControls.T04RegistrationForm" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
        <asp:Panel runat="server" ID="container">
             <div id="errBox" runat="server">
                
            </div>
             <div>
                <span>Submited Students Count :</span>
                <asp:Literal Mode="Encode" Text ="<%# SubmitedStudentsCount  %>" runat="server" ID="displayField" />
                <asp:Button Text="Display submited students" runat="server" OnClick="ShowStudentsDetails_Click" />
            </div>
            <div>
               <asp:Label Text="First name:" runat="server" AssociatedControlId="firstNameTxtBox" />
               <asp:TextBox runat="server" ID="firstNameTxtBox" Text="<script>alert('hacked')</script>" />
            </div>
            <div>
                <asp:Label Text="Last name:" runat="server" AssociatedControlId="lastNameTxtBox" />
                <asp:TextBox runat="server" ID="lastNameTxtBox" />
            </div>
            <div>
                <asp:Label Text="Faculty number:" runat="server" AssociatedControlId="facNumTxtBox" />
                <asp:TextBox runat="server" ID="facNumTxtBox" />
            </div>
             <div>
               <asp:Label Text="University:" runat="server" AssociatedControlId="universityDDList" />
               <asp:DropDownList id="universityDDList" runat="server">
                <asp:ListItem>UNWE</asp:ListItem>
                <asp:ListItem>TU</asp:ListItem>
                <asp:ListItem>Telerik Academy</asp:ListItem>
                <asp:ListItem>SU</asp:ListItem>
               </asp:DropDownList>
            </div>
             <div>
               <asp:Label Text="Specialty :" runat="server" AssociatedControlId="specialtyDDList" />
               <asp:DropDownList id="specialtyDDList" runat="server">
                <asp:ListItem>BA</asp:ListItem>
                <asp:ListItem>KTS</asp:ListItem>
                <asp:ListItem>Fron-ender</asp:ListItem>
                <asp:ListItem>.Net ninja</asp:ListItem>
               </asp:DropDownList>
            </div>
             <div>
               <asp:Label Text="Courses :" runat="server" AssociatedControlId="coursesMultiDDList" />

               <asp:ListBox ID="coursesMultiDDList" runat="server" AutoPostBack="False" SelectionMode="Multiple">
                        <asp:ListItem Enabled="True" Selected="True">CSS </asp:ListItem>
                        <asp:ListItem Enabled="True">HTML</asp:ListItem>
                        <asp:ListItem Enabled="True">Javascript</asp:ListItem>
                        <asp:ListItem Enabled="True">C#</asp:ListItem>
                        <asp:ListItem Enabled="True" Selected="True">OOP</asp:ListItem>
                        <asp:ListItem Enabled="True">ASP.Net</asp:ListItem>
                        <asp:ListItem Enabled="True" Selected="True">Database</asp:ListItem>
                 </asp:ListBox>
            </div>
            <asp:Button Text="Add student" runat="server" OnClick="SumbitApplication_Click" />
             <div id="Detils" runat="server">
          
            </div>
        </asp:Panel>
</asp:Content>
