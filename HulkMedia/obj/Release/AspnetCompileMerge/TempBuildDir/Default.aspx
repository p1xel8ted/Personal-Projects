<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HulkMedia.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>Newly Added Movies</h3>
        <p>
            Results:&nbsp;
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
            <asp:GridView ID="MovieGrid" runat="server" Width="100%" GridLines="None" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AllowSorting="True" Style="margin-top: 0">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ImageField DataImageUrlField="Poster" HeaderText="Poster">
                        <HeaderStyle CssClass="NamePadding" />
                        <ItemStyle CssClass="PaddingBetweenMovies" HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                    </asp:ImageField>
                    <asp:HyperLinkField HeaderText="Name" DataTextField="Name" DataNavigateUrlFields="Name" DataNavigateUrlFormatString="https://www.google.com/search?q={0}" Target="_blank">
                        <ControlStyle CssClass="NamePadding" />
                        <HeaderStyle CssClass="NamePadding" />
                        <ItemStyle Wrap="True" CssClass="NamePadding" Width="15%" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="Plot" HeaderText="Plot">
                        <HeaderStyle CssClass="PlotCellPadding" />
                        <ItemStyle CssClass="PlotPadding" Width="35%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Rating" HeaderText="Rating">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Runtime" HeaderText="Runtime">
                        <ControlStyle CssClass="LocationCSS" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Location" HeaderText="Location">
                        <ControlStyle CssClass="LocationCSS" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:BoundField>
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
        <p>
            Results:
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
            <asp:GridView ID="TvGrid" runat="server" Width="100%" GridLines="None" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AllowSorting="True" Style="margin-top: 0">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ImageField DataImageUrlField="Poster" HeaderText="Poster">
                        <HeaderStyle CssClass="NamePadding" />
                        <ItemStyle CssClass="PaddingBetweenMovies" HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                    </asp:ImageField>
                    <asp:HyperLinkField HeaderText="Episode" DataTextField="Name" DataNavigateUrlFields="Name" DataNavigateUrlFormatString="https://www.google.com/search?q={0}" Target="_blank">
                        <ControlStyle CssClass="NamePadding" />
                        <HeaderStyle CssClass="NamePadding" />
                        <ItemStyle Wrap="True" CssClass="NamePadding" Width="15%" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="Plot" HeaderText="Plot">
                        <HeaderStyle CssClass="PlotCellPadding" />
                        <ItemStyle CssClass="PlotPadding" Width="35%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Rating" HeaderText="Rating">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Runtime" HeaderText="Avg Runtime">
                        <ControlStyle CssClass="LocationCSS" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Location" DataField="Location">
                        <ControlStyle CssClass="LocationCSS" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:BoundField>
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
