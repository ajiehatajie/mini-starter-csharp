<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="CmsEbook.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="height: 40px">
        <asp:Label ID="lblTitleForm" Text="Change Password" runat="server" SkinID="2" />
    </div>
    <div>
        <table cellpadding="3" cellspacing="3" class="tableBorder">
            <tr>
                <td class="isi">Current Password</td>
                <td>
                    <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="isi">New Password</td>
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="isi" style="white-space:nowrap;">Confirm New Password</td>
                <td>
                    <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <asp:Label ID="lblErrorMessage" runat="server" EnableViewState="false" CssClass="errorMessage"></asp:Label>
    <div style="height:40px; border-top :1px solid #FF7110; text-align : right; padding-top:10px; margin-top:10px;">
        <asp:Button ID="btnSave" Width="70px" Text="Save" runat="server" 
            onclick="btnSave_Click" />&nbsp;
        <asp:Button ID="btnCancel" Width="70px" Text="Cancel" runat="server" OnClientClick="OnCancel();return false;" Visible="false" />
    </div>
</asp:Content>
