<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="Id">
                <ItemTemplate>
                    <div id="news">
                        <div class="news_image">
                            <img src="Images/News/<%# Eval("image")%>" border="0"class="news_image_con" />
                        </div>
                        <div class="news_right">
                            <div class="news_title">
                                <%# Eval("title") %>
                            </div>
                            <div class="news_text">
                                <%# Eval("content") %>
                            </div>
                            <div class="news_postedby">
                               Posted by <i><%# Eval("postedby") %></i>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <LayoutTemplate>
                            <table runat="server" id="itemPlaceholderContainer">
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                            <div class="links">
                                <asp:DataPager runat="server" ID="DataPager1" PageSize="4" >
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="True" NextPageText="►" PreviousPageText="◄" FirstPageText="⏪"></asp:NextPreviousPagerField>
                                        <asp:NumericPagerField></asp:NumericPagerField>
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ShowNextPageButton="True" ShowPreviousPageButton="False" NextPageText="►" PreviousPageText="◄" LastPageText="⏩"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                            </div>
                </LayoutTemplate>
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT * FROM [News]"></asp:SqlDataSource>
</asp:Content>
