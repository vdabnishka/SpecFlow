<%@ Page Title="Some Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrimeNumbersView.aspx.cs" Inherits="LNL.MvpSpecFlow.Web.PrimeNumbersView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-top: 20px;"></div>
    <div class="row">
        <div class="col-md-4">
            <label>ID:</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtEntityId" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label>Name:</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtEntityName"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label>Number:</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtEntityNumber"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label>Enabled:</label>
        </div>
        <div class="col-md-4">
            <asp:CheckBox runat="server" ID="chbEntityIsEnabled"></asp:CheckBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label>IsPrime:</label>
        </div>
        <div class="col-md-4">
            <asp:CheckBox runat="server" ID="chbEntityIsNumberPrime" ReadOnly="True"></asp:CheckBox>
        </div>
    </div>
    <div style="padding-top: 10px;"></div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button runat="server" ID="btnSave" OnClick="btnSave_OnClick" Text="Save Me"></asp:Button>
        </div>
    </div>
    <div style="padding-top: 20px;"></div>
    <div class="row">
        <div class="col-md-4">
            <h3>All primes up to given number:</h3>
        </div>
        <div class="col-md-4">
            <asp:Button runat="server" ID="btnShowPrimes" OnClick="btnShowPrimes_OnClick" Text="Calculate"></asp:Button>
        </div>
    </div>
    <div style="padding-top: 10px;"></div>
    <asp:Repeater ID="rptPrimesCollection" runat="server">
        <HeaderTemplate>
              <div class="row" style="background-color: grey">
                <div class="col-md-4">
                    <label>Number:</label>
                </div>
                <div class="col-md-4">
                    <label>Is Prime:</label>
                </div>
            </div>
          </HeaderTemplate>
        <ItemTemplate>
            <div class="row">
                <div class="col-md-4">
                    <label><%# ((System.Collections.Generic.KeyValuePair<int, bool>)Container.DataItem).Key %></label>
                </div>
                <div class="col-md-4">
                    <label><%# ((System.Collections.Generic.KeyValuePair<int, bool>)Container.DataItem).Value %></label>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
