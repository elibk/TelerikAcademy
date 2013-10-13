<%@ Page  Title="Task06" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="T06Calculator.aspx.cs" Inherits="WebAndHtmlControls.T06Calculator" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p id="errBox" runat="server"></p>
    <div><span id="firstNumber" runat="server"></span><span id="operatorContainer" runat="server"></span><span id="secondNumber" runat="server"></span></div>
 <table>
      <tr>
         <td colspan="4"><asp:TextBox ID="resultBox" runat ="server" ReadOnly="true"></asp:TextBox></td>
      </tr>
      <tr>
         <td><asp:Button Text ="1" runat="server" OnClick="AddNumber_Click"></asp:Button></td>
         <td><asp:Button Text ="2" runat="server" OnClick="AddNumber_Click"></asp:Button></td>
         <td><asp:Button Text ="3" runat="server" OnClick="AddNumber_Click"></asp:Button></td>
         <td><asp:Button Text ="+" runat="server" OnClick="MathOperation_Click"></asp:Button></td>
      </tr>  
      <tr>  
         <td><asp:Button Text ="4" runat="server" OnClick="AddNumber_Click"></asp:Button></td>
         <td><asp:Button Text ="5" runat="server" OnClick="AddNumber_Click"></asp:Button></td>
         <td><asp:Button Text ="6" runat="server" OnClick="AddNumber_Click"></asp:Button></td>
         <td><asp:Button Text ="-" runat="server" OnClick="MathOperation_Click"></asp:Button></td>
     </tr>   
     <tr>   
         <td><asp:Button Text ="7" runat="server" OnClick="AddNumber_Click"></asp:Button></td>
         <td><asp:Button Text ="8" runat="server" OnClick="AddNumber_Click"></asp:Button></td>
         <td><asp:Button Text ="9" runat="server" OnClick="AddNumber_Click"></asp:Button></td>
         <td><asp:Button Text ="x" runat="server" OnClick="MathOperation_Click"></asp:Button></td>
     </tr>   
     <tr>   
         <td><asp:Button Text ="Clear" runat="server" OnClick="Clear_Click"></asp:Button></td>
         <td><asp:Button Text ="0" runat="server" OnClick="AddNumber_Click"></asp:Button></td>
         <td><asp:Button Text ="/" runat="server" OnClick="MathOperation_Click"></asp:Button></td>
         <td><asp:Button Text ="&radic;" runat="server" OnClick="MathOperation_Click"></asp:Button></td>
     </tr>
      <tr>
         <td colspan="4"><asp:Button Text ="=" runat="server" OnClick="Submit_Click"></asp:Button></td>
      </tr>
 </table>
</asp:Content>
