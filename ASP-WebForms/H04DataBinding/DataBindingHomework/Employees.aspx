<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="DataBindingHomework.Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Employees</h1>

        <asp:EntityDataSource ID="EntityDataSourceEmployees" 
            runat="server" 
            ConnectionString="name=NorthwindEntities" 
            DefaultContainerName="NorthwindEntities" 
            EntitySetName="Employees"
            EnableFlattening="false">
        </asp:EntityDataSource>

        <asp:GridView ID="GridViewEmployee" runat="server" 
            DataSourceID="EntityDataSourceEmployees"
            AutoGenerateColumns="False" DataKeyNames="EmployeeID"
            AllowPaging="True" AllowSorting="True"
            CssClass="table table-striped table-bordered table-condensed">
            <Columns>
                <asp:TemplateField HeaderText="Full Name">
                    <ItemTemplate>
                         <asp:HyperLink Text='<%# Eval("FirstName") + " " + Eval("LastName") %>' 
                            NavigateUrl='<%# string.Format("~/EmployeesDetails.aspx?id={0}", Eval("EmployeeID")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
               
                 <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName"/>
                 <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName"/>
                 <asp:TemplateField HeaderText="View In Form" ShowHeader="False">
                      <ItemTemplate>
                        <asp:LinkButton CssClass="btn" ID="btnDetailsInForm" runat="server" CausesValidation="false" Text="View in form" CommandArgument='<%# Eval("EmployeeID") %>' oncommand="btnDetailsInForm_RedirectCommand" />
                      </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="View with repeater" ShowHeader="False">
                      <ItemTemplate>
                        <asp:LinkButton CssClass="btn" ID="btnDetailsWithRepeter" runat="server" CausesValidation="false" Text="View with repeater" CommandArgument='<%# Eval("EmployeeID") %>' oncommand="btnDetailsWithRepiter_RedirectCommand" />
                      </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="View in list View" ShowHeader="False">
                      <ItemTemplate>
                        <asp:LinkButton CssClass="btn" ID="btnDetailsInListView" runat="server" CausesValidation="false" Text="View in list View" CommandArgument='<%# Eval("EmployeeID") %>' oncommand="btnDetailsWithKistView_RedirectCommand"/>
                      </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</asp:Content>
