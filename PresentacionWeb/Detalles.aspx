<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="PresentacionWeb.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img-tam {
            width: 400px;
            height: 400px;
        }

        @media screen and (max-width: 990px) {
            .img-tam {
                width: 250px;
                height: 250px;
            }

            @media screen and (max-width: 767px) {
                .container-btn {
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    gap: 10px;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

    <asp:UpdatePanel runat="server" ID="panelDetalle">
        <ContentTemplate>
            <h2 class="text-center m-5">Detalles del producto seleccionado</h2>
            <div class="container shadow-sm p-3 bg-body-tertiary rounded contenedor">
                <div class="card mb-3">
                    <div class="row g-0 align-items-center">
                        <div class="col-md-6 text-center">
                            <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png" ID="imgDetalle" class="img-fluid" CssClass="img-tam" runat="server" onerror="this.onerror=null; this.src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s'" />
                        </div>
                        <div class="col-md-6">
                            <div class="card-body">
                                <h3 class="text-center">
                                    <asp:Label Text="" ID="lblNombreTitulo" runat="server" />
                                </h3>
                                <p>
                                    <asp:Label runat="server" Text="Marca: "></asp:Label>
                                    <asp:Label Text="" ID="lblMarca" runat="server" />
                                </p>
                                <p>
                                    <asp:Label runat="server" Text="Categoria: "></asp:Label>
                                    <asp:Label Text="" ID="lblCategoria" runat="server" />
                                </p>
                                <p>
                                    <asp:Label runat="server" Text="Descripcion del producto: "></asp:Label>
                                    <asp:Label Text="" ID="lblDescripciom" runat="server" />
                                </p>
                                <p>
                                    <asp:Label runat="server" Text="Precio: "></asp:Label>
                                    <asp:Label Text="" ID="lblPrecio" runat="server" />
                                </p>

                                <div class="container-btn">
                                    <asp:Button ID="btnQuitarFAV" runat="server" Text="Quitar de favoritos" OnClick="btnQuitarFAV_Click" class="btn btn-primary" />
                                    <asp:Button ID="btnFav" runat="server" Text="Agregar a favoritos" OnClick="btnFav_Click" class="btn btn-primary" />
                                    <a href="Default.aspx" class="btn btn-secondary">Regresar</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
