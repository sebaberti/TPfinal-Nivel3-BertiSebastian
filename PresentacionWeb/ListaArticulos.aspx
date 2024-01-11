<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="PresentacionWeb.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <h1>Lista de Articulos</h1>
    <asp:UpdatePanel runat="server" ID="UpdatePanelList">
        <ContentTemplate>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />

            </div>
        </div>

        <div class=" col-6" style="display:flex; flex-direction:column; gap:5px; justify-content:flex-end">
            <div class="mb-3">
               
                
                <asp:CheckBox Text="Filtro Avanzado" CssClass="" ID="chkAzanzado" AutoPostBack="true" OnCheckedChanged="chkAzanzado_CheckedChanged"  runat="server" />
           
                <%if (chkAzanzado.Checked)
                { %>
                <div class="mb-3">
                        <asp:DropDownList runat="server" ID="ddlAvanzado" CssClass="form-control">
                            <asp:ListItem Text="Mayor a" />
                            <asp:ListItem Text="Menor a" />
                        </asp:DropDownList>
                    </div>
               <%}%>

            </div>
        </div>
            
            </div>
    
    <asp:GridView runat="server" ID="dgvArticulos" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging"
        AllowPaging="true" PageSize="5">

        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion " />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Aplicar" />

        </Columns>
    </asp:GridView>
    <a href="FormularioArticulo.aspx" class="btn btn-primary ">Agregar </a>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
