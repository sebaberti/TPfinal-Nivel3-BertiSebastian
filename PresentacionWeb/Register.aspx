<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PresentacionWeb.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="row">
        <div class="col-6">
            <h2>Crea tu perfil</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" cssClass="form-control" id="txtEmail"/>
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" cssClass="form-control" ID="txtPassword" TextMode="Password"/>
            </div>
            <asp:Button text="Registrarse" runat="server" OnClick="btnRegistrarse_Click"  cssClass="btn btn-primary" ID="btnRegistrarse"   />
            <a href="Default.aspx">Cancelar</a>
        </div>
    </div>
</asp:Content>
