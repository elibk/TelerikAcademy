<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesRepeater.aspx.cs" Inherits="DataBindingHomework.EmployeesRepeater" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <asp:EntityDataSource ID="EntityDataSourceEmployees" 
            runat="server" 
            ConnectionString="name=NorthwindEntities" 
            DefaultContainerName="NorthwindEntities" 
            EntitySetName="Employees"
          Include="Employee1"
            EnableFlattening="false">
        </asp:EntityDataSource>

    <asp:Repeater ID="RepeaterViewEmployee" runat="server"  ItemType="DataBindingHomework.Employee">
        <HeaderTemplate>
            <table class=" table-bordered  text-center">
                <thead>
                    <tr>
                        <th> Employee ID:      </th>
                        <th> Last Name:        </th>
                        <th> FirstName:        </th>
                        <th> Job title:        </th>
                        <th> Title of Courtesy:</th>
                        <th> Birth Date:       </th>
                        <th> Hire Date:        </th>
                        <th> City:             </th>
                        <th> Region:           </th>
                        <th> Postal Code:      </th>
                        <th> Boss:      </th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
         <ItemTemplate>
             <tr>
                 <td> <%#: Item.EmployeeID %>      </td>
                 <td> <%#: Item.LastName %>        </td>
                 <td> <%#: Item.FirstName %>       </td>
                 <td> <%#: Item.Title %>           </td>
                 <td> <%#: Item.TitleOfCourtesy %> </td>
                 <td> <%#: Item.BirthDate %>       </td>
                 <td> <%#: Item.HireDate %>        </td>
                 <td> <%#: Item.City %>            </td>
                 <td> <%#: Item.Region %>          </td>
                 <td> <%#: Item.PostalCode %>      </td>
                <%-- <td> <%#: Item.Employee1.FirstName + " " + Item.Employee1.LastName %> If null -> Exception</td>--%>
                 <td> <%# Eval("Employee1.FirstName") + " " + Eval("Employee1.LastName")  %> </td>
             </tr>
            </ItemTemplate>
        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
