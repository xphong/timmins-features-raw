<%--Phong Huynh - 810194340, hnhp0025
Timmins Hospital Website
Career Alert Feature--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CareerAlert.aspx.cs" Inherits="CareerAlert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Career Alert</h1>
        <asp:Panel ID="pnl_alertform" runat="server">
            <asp:Label ID="lbl_info" runat="server" Text="Use our career alert if you want to be notified when job postings matching your qualifications become available.<br /><br />Select the department of the job you are looking for, and submit your name and email in the fields below.<br />For your <strong>resume</strong> please upload a .doc, .docx, or a .pdf file. " />
            <br />
            <br />
            <asp:Label ID="lbl_required" runat="server" Text="*Required" ForeColor="Maroon" />
            <br />
            <%--Department--%>
            <asp:Label ID="lbl_department" runat="server" Text="Department*" AssociatedControlID="ddl_department" />
            <%--Default dropdownlist for departments --%>
            <asp:DropDownList ID="ddl_department" runat="server">
                <asp:ListItem>Finance</asp:ListItem>
                <asp:ListItem>General</asp:ListItem>
                <asp:ListItem>Human Resources</asp:ListItem>
                <asp:ListItem>IT</asp:ListItem>
                <asp:ListItem>Management</asp:ListItem>
                <asp:ListItem>Media</asp:ListItem>
                <asp:ListItem>Medicine</asp:ListItem>
                <asp:ListItem>Nursing</asp:ListItem>
                <asp:ListItem>Psychiatry</asp:ListItem>
                <asp:ListItem>Research</asp:ListItem>
                <asp:ListItem>Services</asp:ListItem>
                <asp:ListItem>Support</asp:ListItem>
                <asp:ListItem>Surgery</asp:ListItem>
                <asp:ListItem>Volunteer</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <%--Name--%>
            <asp:Label ID="lbl_name" runat="server" Text="*Name: " AssociatedControlID="txt_name" />
            <asp:TextBox ID="txt_name" runat="server" />
            <%-- checking if empty --%>
            <asp:RequiredFieldValidator ID="rfv_name" runat="server" Text="Empty value" ErrorMessage="Please enter your name."
                ControlToValidate="txt_name" Display="Dynamic" SetFocusOnError="true" ValidationGroup="alert_form" />
            <%-- checking if value entered is text format  --%>
            <asp:RegularExpressionValidator ID="rev_name" runat="server" Text="Invalid name"
                ErrorMessage="Please enter your name correctly." ControlToValidate="txt_name"
                Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"
                ValidationGroup="alert_form" />
            <br />
            <%--Email--%>
            <asp:Label ID="lbl_email" runat="server" Text="*Email: " AssociatedControlID="txt_email" />
            <asp:TextBox ID="txt_email" runat="server" />
            <%-- checking if empty --%>
            <asp:RequiredFieldValidator ID="rfv_email" runat="server" Text="Empty value" ErrorMessage="Please enter your email."
                ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationGroup="alert_form" />
            <%-- checking if value entered is email format  --%>
            <asp:RegularExpressionValidator ID="rev_email" runat="server" Text="Invalid email format, Format: name@email.com"
                ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"
                ErrorMessage="Please enter a correct email address." ValidationGroup="alert_form" />
            <br />
            <%--Resume--%>
            <asp:Label ID="lbl_resume" runat="server" Text="*Resume: " />
            <asp:FileUpload ID="fu_resume" runat="server" />
            <%-- checking if empty --%>
            <asp:Label ID="lbl_rfvresume" runat="server" />
            <br />
            <%-- Validation Summary for career alert form --%>
            <asp:ValidationSummary ID="vds_alert" runat="server" HeaderText="Form Errors:" DisplayMode="List"
                ValidationGroup="alert_form" />
            <br />
            <%-- Submit and Clear Buttons --%>
            <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="subSubmit" ValidationGroup="alert_form" />
            <asp:Button ID="btn_clear" runat="server" Text="Clear" OnClick="subClear" />
        </asp:Panel>
        <%-- Output Label --%>
        <asp:Label ID="lbl_output" runat="server" />
    </div>
    </form>
</body>
</html>
