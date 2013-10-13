<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesInListView.aspx.cs" Inherits="DataBindingHomework.EmployeesInListView" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewEmployee"  runat="server" ItemType="DataBindingHomework.Employee">
        <ItemTemplate>
            <ul>
                <li>Employee ID:      <%#: Item.EmployeeID %>      </li>
                <li>Last Name:        <%#: Item.LastName %>        </li>
                <li>FirstName:        <%#: Item.FirstName %>       </li>
                <li>Job title:        <%#: Item.Title %>           </li>
                <li>Title of Courtesy:<%#: Item.TitleOfCourtesy %> </li>
                <li>Birth Date:       <%#: Item.BirthDate %>       </li>
                <li>Hire Date:        <%#: Item.HireDate %>        </li>
                <li>City:             <%#: Item.City %>            </li>
                <li>Region:           <%#: Item.Region %>          </li>
                <li>Postal Code:      <%#: Item.PostalCode %>      </li>
                <li>Boss:             <%# Eval("Employee1.FirstName") + " " + Eval("Employee1.LastName")  %></li>
            </ul> 
        </ItemTemplate>           
    </asp:ListView>
</asp:Content>
