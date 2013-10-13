<%@ Page Title="Employees Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesDetails.aspx.cs" Inherits="DataBindingHomework.EmployeesDetails" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
        
     <asp:Button ID="ButtonBack" runat="server" CssClass="btn-info" Text="Back" OnClick="BtnBack_Click"/>

     <asp:DetailsView ID="DetailsEmployeeDetails" runat="server" AutoGenerateRows="False" DataKeyNames="EmployeeID" >
         <Fields>
             <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" SortExpression="EmployeeID" />
             <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
             <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
             <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
             <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
             <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" />
             <asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate" />
             <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
             <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
             <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
             <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
             <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
             <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone" />
             <asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension" />
             <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
             <asp:TemplateField HeaderText="Full Name">
                    <ItemTemplate>
                         <asp:HyperLink Text='<%# Eval("Employee1.FirstName") + " " + Eval("Employee1.LastName") %>' 
                            NavigateUrl='<%# string.Format("~/EmployeesDetails.aspx?id={0}", Eval("Employee1.EmployeeID")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:BoundField DataField="PhotoPath" HeaderText="PhotoPath" />
         </Fields>
              
        </asp:DetailsView>
      
</asp:Content>

