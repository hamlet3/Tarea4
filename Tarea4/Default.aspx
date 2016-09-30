<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tarea4.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            margin-left: 206px;
        }
        .auto-style2 {
            height: 20px;
        }
        .auto-style5 {
            margin-left: 439px;
        }
    .auto-style8 {
        margin-left: 4px;
    }
        .auto-style9 {
            margin-left: 23px;
            margin-bottom: 0;
        }
        .auto-style10 {
            margin-left: 111;
        }
        .auto-style11 {
            width: 42px;
        }
        .auto-style12 {
            height: 20px;
            width: 42px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="Nombretxt" runat="server" CssClass="auto-style8" OnTextChanged="Nombretxt_TextChanged" Width="109px"></asp:TextBox>
                <asp:Label ID="Sexo" runat="server" Text="Sexo"></asp:Label>
                <asp:DropDownList ID="SexoDDw" runat="server" OnSelectedIndexChanged="SexoDDw_SelectedIndexChanged">
                    <asp:ListItem>Seleccionar . . . . .</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="PersonaIdtxt" runat="server" CssClass="auto-style9" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                <asp:Button ID="BuscarBtn" CssClass="btn btn-info" runat="server" OnClick="BuscarBtn_Click" Text="Buscar" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="TelefonoGv" runat="server" AutoGenerateColumns="False" OnRowCommand="TelefonoGv_RowCommand" OnSelectedIndexChanged="TelefonoGv_SelectedIndexChanged" ShowFooter="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Telefono" SortExpression="Telefono">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TipoTelefono" SortExpression="TipoTelefono">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TipoTelefono") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="AddNew">Add</asp:LinkButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("TipoTelefono") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="asd" OnClick="LinkButton2_Click">LinkButton</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="Telefonotxt" runat="server"></asp:TextBox>
                <asp:DropDownList ID="TipoTelefonoDDL" runat="server">
                    <asp:ListItem>Seleccionar. . . .</asp:ListItem>
                    <asp:ListItem>Celular personal</asp:ListItem>
                    <asp:ListItem>Celular de trabajo</asp:ListItem>
                    <asp:ListItem>Telefono de casa</asp:ListItem>
                    <asp:ListItem>Telefono de trabajo</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <html>
        <head>

        </head>

        <body>

        </body>
    </html>
    <table style="width:100%;">
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12"></td>
            <td class="auto-style2">
                &nbsp;</td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <td>
<asp:Button ID="InsertarBtn" runat="server" Height="39px" OnClick="Button1_Click" Text="Insertar" Width="83px" CssClass="auto-style5 btn btn-primary" style="margin-left: 270px" />
                <asp:Button ID="EliminarBtn" runat="server" CssClass="auto-style10 btn btn-danger" Height="39px" Text="Eliminar" Width="94px" OnClick="EliminarBtn_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
