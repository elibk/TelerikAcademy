<%@ Page Title="Контакти" Language="C#" AutoEventWireup="true"  MasterPageFile="~/NestedMasterBulgaria.master" CodeBehind="Contact.aspx.cs" Inherits="InternationalWebSite.Bulgaria.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Content" runat="server">
    <header>
       <h1><%: Title %></h1>
    </header>
    <div>
        <address>
           София<br />
            бул.България 25<br />
            <abbr title="Phone">Тел:</abbr>
            0888 88 88 88
        </address>

        <address>
            <i class="icon-envelope"></i><strong>Поддръжка:</strong>   <a href="mailto:Support@mail.bg">Support@mail.bg</a><br />
            <i class="icon-envelope"></i><strong>Маркетинг:</strong> <a href="mailto:Marketing@mail.bg">Marketing@mail.bg</a>
        </address>
    </div>
</asp:Content>