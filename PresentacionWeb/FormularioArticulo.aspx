<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="PresentacionWeb.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <div class="row mt-5">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="TxtNombre" CssClass="form-control" />
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoria:</label>
                        <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label for="ddlMarca" class="form-label">Marca:</label>
                        <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
            <div class="mb-3">

                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a href="ListaArticulos.aspx" class="btn btn-secondary">Cancelar</a>
            </div>

        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" />
            </div>
            <asp:UpdatePanel ID="UpdatePanelImg" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <div class="mb-3">
                        <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png" runat="server" ID="imgArticulo" style="height:350px; width:350px;"   onerror="this.onerror=null; this.src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s'" />
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-6">

            <asp:UpdatePanel runat="server" ID="UpdatePaneEl">
                <ContentTemplate>
            <div class="mb-3">
                <asp:Button Text="Eliminar" OnClick="btnEliminar_Click" ID="btnEliminar" CssClass="btn btn-danger" runat="server" />
            </div>

            <%if (ConfirmaEliminacion) { %>

                 <div class="mb-3">
                <asp:CheckBox Text="Confirmar eliminacion" ID="chkconfirmaEliminacion" runat="server" />
                <asp:Button Text="Eliminar" OnClick="btnConfirmaEliminar_Click" ID="btnConfirmaEliminar" CssClass="btn btn-outline-danger" runat="server" />
            </div>

            <%}%>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
