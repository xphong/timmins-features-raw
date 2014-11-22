<%--Phong Huynh - 810194340, hnhp0025
Timmins Hospital Website
Career Alert Feature--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CareerAlert_admin.aspx.cs"
    Inherits="CareerAlert_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Career Alert - Admin</h1>
        <asp:Label ID="lbl_info" runat="server" Text="Pending statuses mean the user has not been notified about any job postings yet. <br />Click on notify when you would like send an alert email to the user." />
        <br />
        <br />
        <asp:Label ID="lbl_msg" runat="server" /><br />
        <br />
        <br />
        <%--Listview of users for Career Alert--%>
        <asp:ListView ID="ltv_alerts" runat="server" OnItemCommand="subAdmin">
            <LayoutTemplate>
                <table cellpadding="5" cellspacing="5">
                    <thead>
                        <tr>
                            <th>
                                Name
                            </th>
                            <th>
                                Department
                            </th>
                            <th>
                                Email
                            </th>
                            <th>
                                Resume
                            </th>
                            <th>
                                Status
                            </th>
                            <th>
                                Option
                            </th>
                            <th>
                                Option
                            </th>
                            <th>
                                Option
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("careeralert_id") %>' />
                        <asp:Label ID="lbl_name" runat="server" Text='<%#Eval("name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lbl_department" runat="server" Text='<%#Eval("department") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lbl_email" runat="server" Text='<%#Eval("email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lbl_resume" runat="server" Text='<%#Eval("resume") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lbl_status" runat="server" Text='<%#Eval("status") %>' />
                    </td>
                    <td>
                        <%--Notify Button--%>
                        <asp:LinkButton ID="lnk_notify" runat="server" Text="Notify" OnClientClick="return confirm('Change status to notified, and email user?')"
                            CommandName="subNotify" />
                    </td>
                    <td>
                        <%--Pending Button--%>
                        <asp:LinkButton ID="lnk_pending" runat="server" Text="Pending" OnClientClick="return confirm('Change status to pending?')"
                            CommandName="subPending" />
                    </td>
                    <td>
                        <%--Delete Button--%>
                        <asp:LinkButton ID="lnk_delete" runat="server" Text="Delete" OnClientClick="return confirm('Delete this record?')"
                            CommandName="subDelete" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
