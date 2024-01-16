<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="PresentacionWeb.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="text-center mt-5">
             <h2>  <asp:Label Text="" ID="lblError" runat="server" />  </h2> 
                <asp:Image CssClass="error" ImageUrl="https://cdn-icons-png.flaticon.com/512/5220/5220262.png" runat="server" />
            </div>
    
</asp:Content>
