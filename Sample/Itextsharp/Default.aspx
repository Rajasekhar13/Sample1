<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Itextsharp_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h3>iText Sharp</h3>
    </div>
    <div>
        <asp:Button ID="btnShow" runat="server" Text="Show PDF"
                                    OnClick="btnShow_OnClick"/>
    </div>



</asp:Content>

