<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="PresentacionWeb.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

    <asp:UpdatePanel runat="server" ID="panelDetalle">
        <ContentTemplate>
            <div class="container mt-5 ">
                <div class="card mb-3">
                    <div class="row g-0 align-items-center">
                        <div class="col-md-4">
                           <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png" ID="imgDetalle"  class="img-fluid" runat="server" />
                        </div>
                        <div class="col-md-8">
                            <div class="card-body  ">
                                <h5>  <asp:Label Text="asdas" ID="lblNombreTitulo" runat="server" /> </h5>
                                <p> <asp:Label Text="asdas" ID="lblMarca" runat="server" /></p>
                                <p>   <asp:Label Text="asdas" ID="lblCategoria" runat="server" /></p>
                                 <p>   <asp:Label Text="asdaasdas" ID="lblDescripciom" runat="server" /></p>
                                 <p>   <asp:Label Text="asdasdas" ID="lblPrecio" runat="server" /></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
