<%--Phong Huynh - 810194340, hnhp0025
Timmins Hospital Website
Plan a Visit Feature--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanaVisit.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript">
    function checkDate(sender, args) {
        if (sender._selectedDate < new Date()) {
            // alert user
            document.getElementById('<%= lbl_calerror.ClientID %>').innerHTML = 'Cannot select a date earlier than today.';
            sender._selectedDate = new Date();
            // set the date back to the current date
            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
        }
        else {
            document.getElementById('<%= lbl_calerror.ClientID %>').innerHTML = '';
        }
    }
</script>
<body>
    <form id="form1" runat="server">
    <div>
        <AJAX:ToolkitScriptManager ID="tsm_main" runat="server" />
        <h1>
            Plan a Visit</h1>
        <asp:Panel ID="pnl_visitform" runat="server">
            <asp:Label ID="lbl_info" runat="server" Text="Plan a visit to Timmins and District Hospital by filling out the form below. We will notify the patient you are visiting and then email you to confirm.<br /> You can also enter the duration of the visit to calculate your parking fee." />
            <br />
            <br />
            <asp:Label ID="lbl_required" runat="server" Text="*Required" ForeColor="Maroon" />
            <br />
            <%--Name--%>
            <asp:Label ID="lbl_name" runat="server" Text="*Name: " AssociatedControlID="txt_name" />
            <asp:TextBox ID="txt_name" runat="server" />
            <%-- checking if empty --%>
            <asp:RequiredFieldValidator ID="rfv_name" runat="server" Text="Empty value" ErrorMessage="Please enter your name."
                ControlToValidate="txt_name" Display="Dynamic" SetFocusOnError="true" ValidationGroup="visit_form" />
            <%-- checking if value entered is text format  --%>
            <asp:RegularExpressionValidator ID="rev_name" runat="server" Text="Invalid name"
                ErrorMessage="Please enter your name correctly." ControlToValidate="txt_name"
                Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"
                ValidationGroup="visit_form" />
            <br />
            <%--Email--%>
            <asp:Label ID="lbl_email" runat="server" Text="*Email: " AssociatedControlID="txt_email" />
            <asp:TextBox ID="txt_email" runat="server" />
            <%-- checking if empty --%>
            <asp:RequiredFieldValidator ID="rfv_email" runat="server" Text="Empty value" ErrorMessage="Please enter your email."
                ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationGroup="visit_form" />
            <%-- checking if value entered is email format  --%>
            <asp:RegularExpressionValidator ID="rev_email" runat="server" Text="Invalid email format, Format: name@email.com"
                ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"
                ErrorMessage="Please enter a correct email address." ValidationGroup="visit_form" />
            <br />
            <%--Patient Name--%>
            <asp:Label ID="lbl_pname" runat="server" Text="*Patient Name: " AssociatedControlID="txt_pname" />
            <asp:TextBox ID="txt_pname" runat="server" />
            <%-- checking if empty  --%>
            <asp:RequiredFieldValidator ID="rfv_pname" runat="server" Text="Empty value" ErrorMessage="Please enter the patient's name."
                ControlToValidate="txt_pname" Display="Dynamic" SetFocusOnError="true" ValidationGroup="visit_form" />
            <%-- checking if value entered is text format  --%>
            <asp:RegularExpressionValidator ID="rev_pname" runat="server" Text="Invalid patient name"
                ErrorMessage="Please enter the correct patient name." ControlToValidate="txt_pname"
                Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"
                ValidationGroup="visit_form" />
            <br />
            <%--Phone Number--%>
            <asp:Label ID="lbl_number" runat="server" Text="*Phone Number: " AssociatedControlID="txt_number"
                EnableTheming="true" />
            <asp:TextBox ID="txt_number" runat="server" />
            <%-- checking if empty --%>
            <asp:RequiredFieldValidator ID="rfv_number" runat="server" Text="Empty value" ErrorMessage="Please enter your phone number."
                ControlToValidate="txt_number" Display="Dynamic" SetFocusOnError="true" ValidationGroup="visit_form" />
            <%-- checking if value entered is phone number format  --%>
            <asp:RegularExpressionValidator ID="rev_number" runat="server" Text="Invalid phone number, Format: ***-***-****"
                ErrorMessage="Please enter the correct phone number." ControlToValidate="txt_number"
                Display="Dynamic" SetFocusOnError="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"
                ValidationGroup="visit_form" />
            <br />
            <%--Visitors--%>
            <asp:Label ID="lbl_visitors" runat="server" Text="*Number of Visitors (Max 5): "
                AssociatedControlID="txt_visitors" />
            <asp:TextBox ID="txt_visitors" runat="server" />
            <%-- checking if empty --%>
            <asp:RequiredFieldValidator ID="rfv_visitors" runat="server" Text="Empty value" ErrorMessage="Please enter the number of visitors."
                ControlToValidate="txt_visitors" Display="Dynamic" SetFocusOnError="true" ValidationGroup="visit_form" />
            <%-- checking if range is correct for number of visitors --%>
            <asp:RangeValidator ID="rav_visitors" runat="server" Text="Invalid number of visitors"
                ErrorMessage="Please enter the correct number of visitors (1-5)" ControlToValidate="txt_visitors"
                SetFocusOnError="true" MinimumValue="1" MaximumValue="5" Type="Integer" ValidationGroup="visit_form" />
            <br />
            <%--Date of Visit--%>
            <asp:Label ID="lbl_dateofvisit" runat="server" Text="*Date of Visit: " AssociatedControlID="txt_dateofvisit" />
            <asp:TextBox ID="txt_dateofvisit" runat="server" />
            <asp:Label ID="lbl_calerror" runat="server" />
            <%-- checking if empty --%>
            <asp:RequiredFieldValidator ID="rfv_dateofvisit" runat="server" Text="Empty value"
                ErrorMessage="Please enter the date." ControlToValidate="txt_dateofvisit" Display="Dynamic"
                SetFocusOnError="true" ValidationGroup="visit_form" />
            <%-- checking if value entered is date format  --%>
            <asp:RegularExpressionValidator ID="rev_dateofvisit" runat="server" Text="Invalid date, Format: dd/mm/yyyy"
                ErrorMessage="Please enter the correct date." ControlToValidate="txt_dateofvisit"
                Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\d{1,2}\/\d{1,2}\/\d{4}$"
                ValidationGroup="visit_form" />
            <%--Uses AJAX for calendar--%>
            <AJAX:CalendarExtender ID="ce_dateofvisit" runat="server" TargetControlID="txt_dateofvisit"
                Format="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
            <br />
            <%--Duration of Visit: not required, calculate for parking fees--%>
            <asp:Label ID="lbl_duration" runat="server" Text="Duration of Visit: " AssociatedControlID="txt_duration" />
            <asp:DropDownList ID="ddl_duration" runat="server">
                <asp:ListItem>Minutes</asp:ListItem>
                <asp:ListItem>Hours</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txt_duration" runat="server" />
            <br />
            <%-- Google's reCaptcha Control --%>
            <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6LfFiN8SAAAAABop6Oc_WgwO8KKqGS3pFxmXmYpe"
                PrivateKey="6LfFiN8SAAAAACEWa2mLiz9_fi4MEZbn3EjhUIL0" />
            <br />
            <br />
            <%-- Validation Summary for plan a visit form --%>
            <asp:ValidationSummary ID="vds_visit" runat="server" HeaderText="Form Errors:" DisplayMode="List"
                ValidationGroup="visit_form" />
            <br />
            <%-- Submit and Clear Buttons --%>
            <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="subSubmit" ValidationGroup="visit_form" />
            <asp:Button ID="btn_clear" runat="server" Text="Clear" OnClick="subClear" />
        </asp:Panel>
        <%-- Output Label --%>
        <asp:Label ID="lbl_output" runat="server" />
    </div>
    </form>
</body>
</html>
