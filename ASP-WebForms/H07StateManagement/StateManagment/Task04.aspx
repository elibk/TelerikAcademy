<%@ Page Title="Clear view state" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Task04.aspx.cs" Inherits="StateManagment.Task04" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
      <script type="text/javascript">
        window.alertViewState =  function (){
              var vCode = $('#__VIEWSTATE').val();
              alert('View State : ' +  vCode);
          }
         
         window.clearViewState = function() {
              $('#__VIEWSTATE').val("");
              alertViewState();
          }
      </script>
      <p>Clearing view state will coast post back and exception on the server.</p>
      <asp:TextBox id="UserInput" runat="server" Text=""></asp:TextBox>  
      <button class="btn btn-primary btn-large" onclick="alertViewState()">Alert View state</button>
      <button class="btn btn-primary btn-large" onclick="clearViewState()">Clear View state</button>
</asp:Content>
