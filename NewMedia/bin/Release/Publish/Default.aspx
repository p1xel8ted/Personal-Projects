<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewMedia._Default" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>Newly Added Movies</h3>
        <p>Results:&nbsp;
            <asp:DropDownList ID="MovieResults" runat="server" AutoPostBack="True">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>35</asp:ListItem>
                <asp:ListItem>40</asp:ListItem>
                <asp:ListItem>45</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:GridView ID="MovieGrid" runat="server" Width="100%" GridLines="None" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="MovieGrid_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ImageField DataImageUrlField="Poster" HeaderText="Poster" >
                        <HeaderStyle CssClass="NamePadding" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Name" HeaderText="Name">
                    <ControlStyle CssClass="NamePadding" />
                    <HeaderStyle CssClass="NamePadding" />
                    <ItemStyle Wrap="False" CssClass="NamePadding" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Plot" HeaderText="Plot">
                    <HeaderStyle CssClass="PlotCellPadding" />
                    <ItemStyle CssClass="PlotCellPadding" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Rating" HeaderText="Rating">
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Runtime" HeaderText="Runtime">
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Date Added" HeaderText="Date Added">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle Width="10%" Wrap="False" />
                    </asp:BoundField>
                    <asp:CommandField HeaderText="Download" SelectText="Download" ShowSelectButton="True">
                    <ItemStyle Width="10%" />
                    </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
</p>

    </div>
    
    <div class="jumbotron">
        <h3>Newly Added TV Episodes</h3>
        <p>Results:
            <asp:DropDownList ID="TvResults" runat="server" AutoPostBack="True">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>35</asp:ListItem>
                <asp:ListItem>40</asp:ListItem>
                <asp:ListItem>45</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:GridView ID="TvGrid" runat="server" Width="100%" GridLines="None" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="TvGrid_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                          <asp:BoundField DataField="Name" HeaderText="Name">
                          <HeaderStyle CssClass="NamePadding" />
                    <ItemStyle Width="80%" CssClass="NamePadding" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Date Added" HeaderText="Date Added">
                        <ItemStyle Width="10%" Wrap="False" />
                    </asp:BoundField>
                          <asp:CommandField ShowSelectButton="True" HeaderText="Download" SelectText="Download" >
                          <ItemStyle Width="10%" />
                          </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
           
        </p>
       
    </div>
    
    </asp:Content>
