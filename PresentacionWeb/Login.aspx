﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PresentacionWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <h2>Ingresa tus datos</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" cssClass="form-control" REQUIRED id="txtEmail"/>
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" cssClass="form-control"  ID="txtPassword" TextMode="Password"/>
            </div>
            <asp:Button text="Ingresar" runat="server" OnClick="btnIngresar_Click" cssClass="btn btn-primary" ID="btnIngresar"   />
            <a href="Default.aspx">Cancelar</a>
        </div>
    </div>
</asp:Content>
