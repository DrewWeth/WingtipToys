<%@ Page Title="No Inventory" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoInventory.aspx.cs" Inherits="WingtipToys.NoInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h1><%#: Title %></h1>
        <a id="backToProducts" runat="server" Class="btn btn-primary" href="~/ProductList">Back To Product List</a>

</asp:Content>
