<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PresentacionWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row row-cols-1 row-cols-md-3 g-4" style="display:flex; justify-content:center;align-items:center; gap:30px; margin-top:10px; margin-bottom:50px; " >

        <style>
            .container-img{
                display:flex;
                width:200px;
                height:250px;
            }
        </style>
        
       <%-- <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("Imagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>

                            <a href="Detalles.aspx?id=<%#Eval("Id") %>">Ver detalle</a>
                        </div>
                    </div>
                </div>--%>


                
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate >
                <div class="card" style="width: 18rem;display:flex; justify-content:center;align-items:center; ">
                    <div class="container-img">
          
                        
                        
                    <img src="<%#Eval("Imagen")%>" class="card-img-top"  alt="">
                      
                    </div>
                    
                    <div class="card-body">
                        <h5 class="card-title" style="text-align:center;"><%#Eval("Nombre") %></h5>
                        <p class="card-text" style="background:red; text-align:center; "><%#Eval("Descripcion") %> </p>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">$ <%#Eval("Precio") %></li>
                    </ul>
                    <div class="card-body">
                        <a href="Detalles.aspx?id=<%#Eval("Id") %>" class="card-link">Detalles</a>
                        
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>





    </div>
</asp:Content>
