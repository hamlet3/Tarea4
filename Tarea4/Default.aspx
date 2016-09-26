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
        .auto-style4 {
            margin-top: 12;
        }
        .auto-style5 {
            margin-left: 439px;
        }
        .auto-style6 {
            margin-left: 6px;
            margin-top: 0;
        }
        .auto-style7 {
            margin-left: 0px;
        }
        .auto-style8 {
            margin-left: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="Nombretxt" runat="server" CssClass="auto-style8" OnTextChanged="Nombretxt_TextChanged" Width="109px"></asp:TextBox>
                <asp:Label ID="Sexo" runat="server" Text="Label"></asp:Label>
                <asp:DropDownList ID="SexoDDw" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Telefono"></asp:Label>
                <asp:TextBox ID="Telefonotxt" runat="server" CssClass="auto-style7" Width="112px"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="Tipo de telefono"></asp:Label>
                <asp:TextBox ID="TipoTelefonotxt" runat="server"></asp:TextBox>
                <asp:Button ID="Agregarbtn" class="btn btn-primary" runat="server" Text="Agregar" OnClick="Agregarbtn_Click" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:ListBox ID="TelefonoLb" runat="server" Width="170px" OnSelectedIndexChanged="TelefonoLb_SelectedIndexChanged" CssClass="auto-style6" Height="68px"></asp:ListBox>
                <asp:Button ID="BorrarBtn"  runat="server" Text="Borrar" OnClick="BorrarBtn_Click" CssClass="auto-style4 btn btn-primary" Height="35px" style="margin-top: 0px" Width="70px" />
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
            <td>&nbsp;</td>
            <td>
<asp:Button ID="InsertarBtn" runat="server" Height="39px" OnClick="Button1_Click" Text="Insertar" Width="107px" CssClass="auto-style5 btn btn-primary" style="margin-left: 471px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
