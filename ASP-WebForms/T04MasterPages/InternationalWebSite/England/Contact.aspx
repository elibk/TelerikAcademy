<%@ Page Title="Контакти" Language="C#" AutoEventWireup="true"  MasterPageFile="~/NestedMasterEngland.master" CodeBehind="Contact.aspx.cs" Inherits="InternationalWebSite.England.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Content" runat="server">
    <header>
       <h1><%: Title %></h1>
    </header>
    <div>
        <address>
            88 Old Street, London EC1V 9HU<br />
            <abbr title="Phone">P:</abbr>
           0300 330 1234
        </address>

        <address>
            <i class="icon-envelope"></i><strong>Support:</strong>   <a href="mailto:Support@mail.co.uk">Support@mail.co.uk</a><br />
            <i class="icon-envelope"></i><strong>Marketnig:</strong> <a href="mailto:Marketing@mail.co.uk">Marketing@mail.co.uk</a>
        </address>
    </div>
</asp:Content>