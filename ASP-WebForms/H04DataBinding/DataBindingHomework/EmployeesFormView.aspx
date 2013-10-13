<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesFormView.aspx.cs" Inherits="DataBindingHomework.EmployeesFormView" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
     <asp:FormView RepeatLayout="UnorderedList" ID="FormViewEmployee" runat="server" 
            ItemType="DataBindingHomework.Employee">
            <ItemTemplate>
                 <table>
                      <tr><td>Employee ID:      </td>       <td><%#: Item.EmployeeID %>      </td></tr>
                      <tr><td>Last Name:        </td>       <td><%#: Item.LastName %>        </td></tr>
                      <tr><td>FirstName:        </td>       <td><%#: Item.FirstName %>       </td></tr>
                      <tr><td>Job title:        </td>       <td><%#: Item.Title %>           </td></tr>
                      <tr><td>Title of Courtesy:</td>       <td><%#: Item.TitleOfCourtesy %> </td></tr>
                      <tr><td>Birth Date:       </td>       <td><%#: Item.BirthDate %>        </td></tr>
                      <tr><td>Hire Date:        </td>       <td><%#: Item.HireDate %>         </td></tr>
                      <tr><td>City:             </td>       <td><%#: Item.City %>             </td></tr>
                      <tr><td>Region:           </td>       <td><%#: Item.Region %>           </td></tr>
                      <tr><td>Postal Code:      </td>       <td><%#: Item.PostalCode %>       </td></tr>
                      <tr><td>Boss:              </td>      <td><%# Eval("Employee1.FirstName") + " " + Eval("Employee1.LastName")  %>  </td></tr>
                </table> 
            </ItemTemplate>  
                            
        </asp:FormView>                                  
</asp:Content>                                           
                
