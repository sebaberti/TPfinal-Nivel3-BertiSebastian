<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="PresentacionWeb.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <h1 class="text-center m-5">Productos Favoritos</h1>
    <%if (Session["Favoritos"] == null)
        { %>
    <h3 class="text-center mb-5">
    
        Agregue aqui sus productos favoritos
    </h3>
    <% }%>


    <asp:UpdatePanel runat="server" ID="UpdatePanelFav">
                <contenttemplate>
        <div class="row">
            <div class="col-12">
                    <asp:GridView runat="server" ID="dgvArticulosFavoritos"  CssClass="table table-secondary" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulosFavoritos_SelectedIndexChanged" >
                        <columns>
                            
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Marca" DataField="MarcaFav.Descripcion" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Eliminar" />

                        </columns>
                    </asp:GridView>
            </div>
        </div>
                    <div class="text-center">
                        <a href="Default.aspx" class="btn btn-secondary">Regresar</a>
                    </div>
                </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
