<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebUserControl1.ascx.vb" Inherits="Test_MultiSelect.WebUserControl1" %>
<asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple"></asp:ListBox>
<div style="display:none;">
    <asp:HiddenField ID="hIncludeSelectAllOption" runat="server" />
    <asp:HiddenField ID="hEnableFiltering" runat="server" />


    <asp:HiddenField ID="hTextField" runat="server" />
    <asp:HiddenField ID="hValueField" runat="server" />
</div>
<script type="text/javascript">
    var ucClientId = '#<%= ListBox1.ClientID%>';
    $(ucClientId).multiselect({
        <%= InitialListBoxOptions()%>
    });
</script>