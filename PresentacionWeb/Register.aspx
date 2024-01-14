<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PresentacionWeb.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row d-flex align-items-center justify-content-center mt-5 border border-3 shadow p-3 bg-body-tertiary rounded " style="height: 600px; border-radius: 10px">
        <div class="col-6">
            <h2 class="text-center mb-4">Crea tu perfil</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
            </div>
            <div class="text-center m-4">
                <asp:Button Text="Registrarse" runat="server" OnClick="btnRegistrarse_Click" CssClass="btn btn-primary" ID="btnRegistrarse" />
                <a href="Default.aspx" class="btn btn-warning">Cancelar</a>
            </div>
            </div>
    </div>
</asp:Content>
