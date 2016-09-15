<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="zombie.ascx.cs" Inherits="Orm.Interns.huy.zombie" %>

<head>
    <title>Trich xuat Database bang tu khoa</title>    
</head>
<body>
    <h1 style="text-align:center">Trích xuất thông tin từ Database</h1>
<asp:Label ID="lb1" runat="server" Text="Chọn từ khóa : "></asp:Label>
 <asp:DropDownList id=drpDList runat="server">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>

<div id="display_data" style="width:900px; height:400px">
    <p>
        <asp:Repeater ID="get10Lines" runat="server" OnItemDataBound="get10Lines_ItemDataBound" >
            <ItemTemplate>
                <li><asp:Label runat="server" ID="lb2"></asp:Label></li>
            </ItemTemplate>
        </asp:Repeater>
    <p>     
</div>
    
<div style="overflow: hidden;" style="text-align:right">    
    <asp:Button ID="btn_first" runat="server" Text="First" Visible="false" OnClick="btn_first_Click"/>  
    <asp:Button ID="btn_pre" runat="server" Text="<" OnClick="btn_pre_Click"/>    
        <asp:Repeater ID="rptPages" runat="server" onitemcommand="rptPages_ItemCommand1">
        <ItemTemplate>
            <asp:LinkButton ID="btnPage" style="padding:1px 3px; margin:1px; background:#ccc; border:solid 1px #666; font:8pt tahoma;"
            CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" OnClick="btn_Click"><%# Container.DataItem %>
            </asp:LinkButton>
        </ItemTemplate>
        </asp:Repeater>
    <asp:Button ID="btn_next" runat="server" Text=">" OnClick="btn_next_Click"/>
    <asp:Button ID="btn_last" runat="server" Text="Last" Visible="false" OnClick="btn_last_Click"/>  
</div>
    
</body>