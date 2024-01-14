<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="PresentacionWeb.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
        .validacion{
            color:red;
            font-size:13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center m-5">Mi Perfil</h2>
    <div class="row d-flex justify-content-center">
        <div class="col-lg-4 ">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"  />
            </div>
             <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"  />
                 <asp:RequiredFieldValidator ErrorMessage="Debe cargar un nombre" CssClass="validacion" ControlToValidate="txtNombre" runat="server" />
                 </div>
             <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido"  />
            </div>
            


        </div>
        <div class="col-lg-4 ">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server"  class="form-control"/>
            </div>
            <div class="text-center">

            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.pulsecarshalton.co.uk/wp-content/uploads/2016/08/jk-placeholder-image.jpg" runat="server" CssClass="img-fluid mb-3 " />
            </div>
            </div>
     </div>
    <div class="row m-4">
        <div class=" text-center">
            <asp:Button Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" ID="btnGuardar" runat="server" />
            <a href="/" class="btn btn-secondary">Regresar</a>
        </div>
    </div>
</asp:Content>
