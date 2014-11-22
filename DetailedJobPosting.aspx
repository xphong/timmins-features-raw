<%--Phong Huynh - 810194340, hnhp0025
Timmins Hospital Website
Job Postings Feature--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailedJobPosting.aspx.cs"
    Inherits="DetailedJobPosting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Job Posting</h1>
        <asp:LinkButton ID="lnk_back" runat="server" PostBackUrl="~/JobPostings.aspx" Text="Back to Job Postings" />
        <br />
        <br />
        <asp:Label ID="lbl_error" runat="server" />
        <%--Repeater showing details of selected job posting--%>
        <asp:Repeater ID="rpt_detailed" runat="server">
            <ItemTemplate>
                <asp:Label ID="lbl_title" runat="server" Text="Job Title: " Font-Bold="true" />
                <%#Eval("title") %>
                <br />
                <asp:Label ID="lbl_dateposted" runat="server" Text="Date Posted: " Font-Bold="true" /><%#Eval("date_posted", "{0:dd/MM/yyyy}")%>
                <br />
                <asp:Label ID="lbl_hours" runat="server" Text="Hours: " Font-Bold="true" /><%#Eval("hours") %>
                <br />
                <asp:Label ID="lbl_department" runat="server" Text="Department: " Font-Bold="true" /><%#Eval("department") %>
                <br />
                <asp:Label ID="lbl_description" runat="server" Text="Description: " Font-Bold="true" /><%#Eval("description") %>
                <br />
                <asp:Label ID="lbl_qualifications" runat="server" Text="Qualifications: " Font-Bold="true" /><%#Eval("qualifications") %>
                <br />
                <asp:Label ID="lbl_salary" runat="server" Text="Salary: " Font-Bold="true" /><%#Eval("salary") %>
                <br />
                <asp:Label ID="lbl_deadline" runat="server" Text="Deadline: " Font-Bold="true" /><%#Eval("deadline", "{0:dd/MM/yyyy}")%>
                <br />
                <br />
                <asp:Button ID="lnk_apply" runat="server" Text="Apply to Job" OnClick="subApply" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
