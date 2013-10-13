<%@ Page Title="Contatti" Language="C#" AutoEventWireup="true"  MasterPageFile="~/NestedMasterItalia.master" CodeBehind="Contact.aspx.cs" Inherits="InternationalWebSite.Italia.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Content" runat="server">
    <header>
       <h1><%: Title %></h1>
    </header>
    <div>
        <address>
            Via Montegrappa, 2, Bologna.  
            <abbr title="Phone">Tel.</abbr>
            +39.011.9713943 
        </address>

        <address>
            <i class="icon-envelope"></i><strong>Supporto:</strong>   <a href="mailto:Support@mail.it">Support@mail.it</a><br />
            <i class="icon-envelope"></i><strong>Marketing:</strong> <a href="mailto:Marketing@mail.it">Marketing@mail.it</a>
        </address>
    </div>
</asp:Content>