<%--Phong Huynh - 810194340, hnhp0025
Timmins Hospital Website
Plan a Visit Admin--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanaVisit_admin.aspx.cs"
    Inherits="Planavisit_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Plan a Visit - Admin</h1>
        <asp:Label ID="lbl_info" runat="server" Text="Pending statuses mean the patient has not been notified about the visit yet. <br />Click on notify when you have notified the patient about the visit, and would like send a confirmation email to the visitor." />
        <br /><br />
        <asp:Label ID="lbl_msg" runat="server" />
        <br />
        <br />
        <%-- Gridview of visitors table --%>
        <asp:GridView ID="grv_visitors" runat="server" AutoGenerateColumns="false" CellPadding="5"
            HeaderStyle-BackColor="SteelBlue">
            <Columns>
                <%-- ID Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_id" runat="server" Text="ID" OnCommand="subSort" CommandName="id" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_id" runat="server" Text='<%#Eval("visitor_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Name Column--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_name" runat="server" Text="Name" OnCommand="subSort" CommandName="name" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_name" runat="server" Text='<%#Eval("name")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Email Column--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_email" runat="server" Text="Email" OnCommand="subSort" CommandName="email" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_email" runat="server" Text='<%#Eval("email")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Patient Name Column--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_pname" runat="server" Text="Patient Name" OnCommand="subSort"
                            CommandName="pname" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_pname" runat="server" Text='<%#Eval("patient_name")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Phone Number Column--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_phone" runat="server" Text="Phone Number" OnCommand="subSort"
                            CommandName="phone" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_number" runat="server" Text='<%#Eval("phone_number")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Number of Visitors Column--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_visitors" runat="server" Text="Number of Visitors" OnCommand="subSort"
                            CommandName="visitors" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_visitors" runat="server" Text='<%#Eval("visitors")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Date of Visit Column--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_date" runat="server" Text="Date of Visit" OnCommand="subSort"
                            CommandName="date" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_dateofvisit" runat="server" Text='<%#Eval("visit_date", "{0:dd/MM/yyyy}")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Duration of Visit--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_duration" runat="server" Text="Duration of Visit" OnCommand="subSort"
                            CommandName="duration" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_duration" runat="server" Text='<%#Eval("duration")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Status Column--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_status" runat="server" Text="Status" OnCommand="subSort"
                            CommandName="status" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_status" runat="server" Text='<%#Eval("status")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Notify Button--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnk_notify" runat="server" CommandArgument='<%#Eval("visitor_id") + "^" + Eval("name") + "^" + Eval("email") + "^" + Eval("patient_name")%>'
                            Text="Notify" OnClientClick="return confirm('Change status to notified, and email visitor?')" OnClick="Notify" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Pending Button--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnk_pending" runat="server" CommandArgument='<%#Eval("visitor_id") %>'
                            Text="Pending" OnClientClick="return confirm('Change status to pending?')" OnClick="Pending" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Delete Button--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnk_delete" runat="server" CommandArgument='<%#Eval("visitor_id") %>'
                            Text="Delete" OnClientClick="return confirm('Delete this record?')" OnClick="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%-- End gridview --%>
    </div>
    </form>
</body>
</html>
