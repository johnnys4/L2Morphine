<%@ Page Title="" Language="C#" MasterPageFile="~/CharPanel/Site1.Master" AutoEventWireup="True" CodeBehind="ManChar.aspx.cs" Inherits="WebApplication1.CharPanel.ManChar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div style="margin-top:30px">
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="black-font" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" OnLoad="DropDownList1_Load"></asp:DropDownList>
           </div>
                <asp:ListView ID="CharListView" runat="server" OnItemDataBound="CharListView_ItemDataBound">
                <ItemTemplate>
                    <div class="charheal">
                        <div class="charlvl"><%#Eval("level") %></div>
                        <div class="charname"><%#Eval("char_name") %></div>
                        <asp:Panel ID="Panel1" runat="server" CssClass="lostcp"></asp:Panel>
                        <div class="charcp"></div>
                        <div class="txt"><%#Eval("curCP") %> / <%#Eval("maxCP") %></div>
                        <asp:Panel ID="Panel2" runat="server" CssClass="losthp"></asp:Panel>
                        <div class="charhp"></div>
                        <div class="txt"><%#Eval("curHP") %> / <%#Eval("maxHP") %></div>
                        <asp:Panel ID="Panel3" runat="server" CssClass="lostmp"></asp:Panel>
                        <div class="charmp"></div>
                        <div class="txt"><%#Eval("curMP") %> / <%#Eval("maxMP") %></div>
                    </div>
                        <asp:Image ID="Image1" runat="server" CssClass="charrace" />
                    <div class="charstatus">
                        <div class="title">Status (base stats)</div>
                        <div class="status-content">
                            <div class="status-left">P.Atk: <%#Eval("pAtk") %> <br />P.Def: <%#Eval("pDef") %><br />Accuracy: <%#Eval("acc") %> <br />Crit.Rate: <%#Eval("crit") %> <br />Atk.Speed: <%#Eval("pSpd") %>
                                <hr />
                                STR: <%#Eval("str") %><br />CON: <%#Eval("con") %><br />DEX: <%#Eval("dex") %>
                                <hr />
                                Karma: <%#Eval("karma") %> <br />Rec. Score: <%#Eval("rec_have") %>
                            </div>
                            <div class="status-right">M.Atk: <%#Eval("mAtk") %> <br />M.Def: <%#Eval("mDef") %><br />Evasion: <%#Eval("evasion") %><br />Speed: <%#Eval("runSpd") %> <br />Casting Speed: <%#Eval("mSpd") %>
                                <hr />
                                INT: <%#Eval("_int") %><br />MEN: <%#Eval("men") %><br />WIT: <%#Eval("wit") %>
                                <hr />
                                PvP/PK: <%#Eval("pvpkills") %>/<%#Eval("pkkills") %><br />Rec. Remaining: <%#Eval("rec_left") %>
                            </div>
                        </div>
                    </div>
                    <div class="chardonatepoints">
                        <div class="title">Donate Points</div>
                        <div class="points-content">
                            0
                        </div>
                    </div>
                    <div class="charactions">
                        <div class="title">Actions</div>
                        <div class="actions-content">
                            <asp:Button ID="BtnRepair" runat="server" Text="Repair" CssClass="actions-button" />
                            <asp:Button ID="BtnDelevel" runat="server" Text="Delevel" CssClass="actions-button" />
                            <asp:Button ID="Button3" runat="server" Text="Color Name" CssClass="actions-button" />
                            <asp:Button ID="Button4" runat="server" Text="Color Title"  CssClass="actions-button" />
                            <asp:Button ID="Button5" runat="server" Text="Change Sex"  CssClass="actions-button" />
                            <asp:Button ID="Button1" runat="server" Text="Shop"  CssClass="actions-button" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
