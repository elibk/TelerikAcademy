<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="T07XmlTreeView.aspx.cs" Inherits="DataBindingHomework.T07XmlTreeView" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
     <div id="displayBlock" runat="server" class="span6 pull-right"></div>
    <asp:TreeView  ID="TreeViewXml" CssClass="inline" PopulateOnDemand ="true" runat="server" DataSourceID="XmlData" OnSelectedNodeChanged="TreeViewXml_SelectedNodeChanged">
        <DataBindings>

            <asp:TreeNodeBinding DataMember="genre" TextField="name"  />

            <asp:TreeNodeBinding DataMember="book" TextField="ISBN" />

            <asp:TreeNodeBinding DataMember="title" ValueField="#InnerText" Text="title" />

            <asp:TreeNodeBinding DataMember="price" ValueField="#InnerText" Text="price" />

            <asp:TreeNodeBinding DataMember="comments" Text="Comments" Value="Comments" />

            <asp:TreeNodeBinding DataMember="userComment" ValueField="#InnerText" Text="comment" ToolTipField="rating" />

        </DataBindings>
        
    </asp:TreeView>
    <asp:XmlDataSource ID="XmlData" runat="server" DataFile="~/XMLFile.xml"></asp:XmlDataSource>

    
</asp:Content>
