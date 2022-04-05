<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="FilmTabelaEdit.aspx.cs" Inherits="KorisnickiInterfejs.FilmTabelaEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 238px;
    }
    .style2
    {
        font-size: medium;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <strong>SPISAK FILMOVA ZA AZURIRANJE</strong></td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:GridView ID="gvSpisakFilmovaEdit" runat="server" Font-Underline="False" 
                Height="277px"  
                Width="920px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvSpisakFilmovaEdit_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
