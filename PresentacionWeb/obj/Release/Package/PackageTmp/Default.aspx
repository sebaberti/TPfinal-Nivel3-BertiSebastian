<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PresentacionWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

            <div class="row" style="margin-top:65px;">
                <div class="col-6">
                    <div class="mb-3">


                        <asp:Label Text="Filtrar" runat="server" />
                        <asp:Label Text="" ID="lblError" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="false" />
                    </div>
                </div>

                <%if (!chkAvanzadoDefault.Checked)

                    {%>
                <asp:RegularExpressionValidator ID="regexValidatorLetras" runat="server"
                    ControlToValidate="txtFiltro"
                    ValidationExpression="^[a-zA-Z]+$"
                    ErrorMessage="Solo se permiten letras."
                    Display="Dynamic" 
                    CssClass="error-message"/>

                <%} %>

                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end">
                    <div class="mb-3">
                        <asp:CheckBox Text="Filtro Avanzado" CssClass="" ID="chkAvanzadoDefault" AutoPostBack="true" OnCheckedChanged="chkAzanzadoDefault_CheckedChanged" runat="server" />

                        <%if (chkAvanzadoDefault.Checked)

                            { %>

                        <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                            ControlToValidate="txtFiltro"
                            ValidationExpression="^[0-9]*$"
                            ErrorMessage="Solo se permiten números."
                            Display="Dynamic"
                            CssClass="error-message" />


                        <div class="mb-3">
                            <asp:DropDownList runat="server" ID="ddlAvanzado" CssClass="form-control">
                                <asp:ListItem Text="Precio mayor a" />
                                <asp:ListItem Text="Precio menor a" />
                            </asp:DropDownList>
                        </div>
                        <%}%>
                    </div>

                </div>
            </div>

            <div class="row">

                <div class="text-center">
                    <asp:Button ID="btnBuscador" runat="server" Text="Buscar" class="btn btn-info" OnClick="btnBuscador_Click" />

                </div>
            </div>
            
        

            <div class="row row-cols-1 row-cols-md-4 row-cols-lg-3 g-4 mt-3 mb-5" style="display: flex; justify-content: center; align-items: center;">

                <style>
                    .container-img {
                        display: flex;
                        width: 250px;
                        height: 270px;
                    }
                </style>

                <asp:Repeater runat="server" ID="repRepetidor">
                    <ItemTemplate>


                        <div class="card m-4" style="width: 18rem; display: flex; justify-content: center; align-items: center; border-radius: 10px;">
                            <div class="container-img">
                                <img src="<%#Eval("Imagen")%>" class="card-img-top" alt=""  onerror="this.onerror=null; this.src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s'" >
                            </div>

                            <div class="card-body">
                                <h5 class="card-title" style="text-align: center;"><%#Eval("Nombre") %></h5>
                            </div>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">$ <%#Eval("Precio") %></li>
                            </ul>
                            <div class="card-body">

                                <a href="Detalles.aspx?id=<%#Eval("Id") %>" class="card-link btn btn-info">Ver detalles</a>

                            </div>
                        </div>
                      
                    </ItemTemplate>
                </asp:Repeater>
       
    
</asp:Content>
