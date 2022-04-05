<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="FilmUnos.aspx.cs" Inherits="KorisnickiInterfejs.FilmUnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 214px;
            text-align: right;
        }
        .style2
        {
            width: 214px;
            text-align: right;
            font-weight: bold;
        }
        .auto-style1 {
            width: 300px;
        }
        .auto-style2 {
            width: 177px;
        }
        .auto-style3 {
            width: 150px;
            text-align: right;
            font-weight: bold;
        }
        .auto-style4 {
            width: 150px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style3">
                &nbsp;</td>
            <td class="auto-style1">
                <b>UNOS FILMOVA</b></td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                Naziv filma</td>
            <td class="auto-style1">
                <asp:TextBox ID="NazivFilmatxb" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td class="auto-style4" rowspan="5">
                Početak prikazivanja</td>
            <td rowspan="5">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </td>
            <td rowspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                Originalni naziv</td>
            <td class="auto-style1">
                <asp:TextBox ID="OriginalniNazivtxb" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Reditelj</td>
            <td class="auto-style1">
                <asp:TextBox ID="Rediteljtxb" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Žanr</td>
            <td class="auto-style1">
                <asp:TextBox ID="ZanrTxb" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Trajanje</td>
            <td class="auto-style1">
                <asp:TextBox ID="TrajanjeTxb" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Uloge</td>
            <td class="auto-style1">
                <asp:TextBox ID="UlogeTxb" runat="server" Height="100px" Width="250px" Wrap ="true" Rows="1" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="auto-style4">
                Opis</td>
            <td>
                <asp:TextBox ID="OpisTxb" runat="server" Height="100px" Width="250px" Wrap ="true" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:Label ID="lblStatus" runat="server" Text="status"></asp:Label>
            </td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:Button ID="btnSnimi" runat="server" onclick="btnSnimi_Click" Text="SNIMI" 
                    Width="90px" />
                <asp:Button ID="btnOdustani" runat="server" onclick="btnOdustani_Click" 
                    Text="ODUSTANI" />
            </td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
