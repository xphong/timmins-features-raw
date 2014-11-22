<%--Phong Huynh - 810194340, hnhp0025
Timmins Hospital Website
Job Postings Feature--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobPostings_admin.aspx.cs"
    Inherits="JobPostings_admin" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript">
    // checks if user enters a date earlier than the current date, outputs an error message
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
            Job Postings - Admin</h1>
        <%--Confirmation Message --%>
        <asp:Label ID="lbl_msg" runat="server" /><br />
        <br />
        <%--Anchor for insert--%>
        <asp:LinkButton ID="lnk_insertanc" runat="server" PostBackUrl="#insert" Text="Add new job posting" /><br />
        <br />
        <%-- View, Update, Delete --%>
        <asp:Panel ID="pnl_all" runat="server" GroupingText="All Job Postings">
        <%--View Panel--%>
            <table cellpadding="3" border="1">
                <thead style="background-color: SteelBlue;">
                    <tr>
                        <th>
                            <asp:LinkButton ID="lnk_titleH" runat="server" Text="Job Title" OnCommand="subSort"
                                CommandName="title" PostBackUrl="#pnl_all" />
                        </th>
                        <th>
                            <asp:LinkButton ID="lnk_datepostedH" runat="server" Text="Date Posted" OnCommand="subSort"
                                CommandName="dateposted" PostBackUrl="#pnl_all" />
                        </th>
                        <th>
                            <asp:LinkButton ID="lnk_hoursH" runat="server" Text="Hours" OnCommand="subSort" CommandName="hours"
                                PostBackUrl="#pnl_all" />
                        </th>
                        <th>
                            <asp:LinkButton ID="lnk_departmentH" runat="server" Text="Department" OnCommand="subSort"
                                CommandName="department" PostBackUrl="#pnl_all" />
                        </th>
                        <th>
                            <asp:LinkButton ID="lnk_description" runat="server" Text="Description" OnCommand="subSort"
                                CommandName="description" PostBackUrl="#pnl_all" />
                        </th>
                        <th>
                            <asp:LinkButton ID="lnk_qualifications" runat="server" Text="Qualifications" OnCommand="subSort"
                                CommandName="qualifications" PostBackUrl="#pnl_all" />
                        </th>
                        <th>
                            <asp:LinkButton ID="lnk_salary" runat="server" Text="Salary" OnCommand="subSort"
                                CommandName="salary" PostBackUrl="#pnl_all" />
                        </th>
                        <th>
                            <asp:LinkButton ID="lnk_deadline" runat="server" Text="Deadline" OnCommand="subSort"
                                CommandName="deadline" PostBackUrl="#pnl_all" />
                        </th>
                        <th>
                        </th>
                        <th>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%--Table view for job postings--%>
                    <asp:Repeater ID="rpt_all" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("title") %>
                                </td>
                                <td>
                                    <%#Eval("date_posted", "{0:dd/MM/yyyy}")%>
                                </td>
                                <td>
                                    <%#Eval("hours") %>
                                </td>
                                <td>
                                    <%#Eval("department") %>
                                </td>
                                <td>
                                    <%#Eval("description") %>
                                </td>
                                <td>
                                    <%#Eval("qualifications") %>
                                </td>
                                <td>
                                    <%#Eval("salary") %>
                                </td>
                                <td>
                                    <%#Eval("deadline", "{0:dd/MM/yyyy}")%>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btn_update" runat="server" Text="Update" CommandName="Update"
                                        CommandArgument='<%#Eval("jobposting_id") %>' OnCommand="subAdmin" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="btn_delete" runat="server" Text="Delete" CommandName="Delete"
                                        CommandArgument='<%#Eval("jobposting_id") %>' OnCommand="subAdmin" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </asp:Panel>
        <br />
        <%--Update Panel--%>
        <asp:Panel ID="pnl_update" runat="server" GroupingText="Update Job Posting">
            <table cellpadding="5" cellspacing="5">
                <thead style="background-color: SteelBlue;">
                    <tr>
                        <th>
                            <asp:Label ID="lbl_titleU" runat="server" Text="Job Title" />
                        </th>
                        <th>
                            <asp:Label ID="lbl_datepostedU" runat="server" Text="Date Posted" />
                        </th>
                        <th>
                            <asp:Label ID="lbl_hoursU" runat="server" Text="Hours" />
                        </th>
                        <th>
                            <asp:Label ID="lbl_departmentU" runat="server" Text="Department" />
                        </th>
                        <th>
                            <asp:Label ID="lbl_descriptionU" runat="server" Text="Description" />
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%-- Update --%>
                    <asp:Repeater ID="rpt_update" runat="server" OnItemCommand="subUpDel">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("jobposting_id") %>' />
                                <td>
                                    <asp:TextBox ID="txt_titleU" runat="server" Text='<%#Eval("title") %>' />
                                    <br />
                                    <%-- checking if empty --%>
                                    <asp:RequiredFieldValidator ID="rfv_titleU" runat="server" Text="Empty value" ErrorMessage="Please enter the job title"
                                        ControlToValidate="txt_titleU" Display="Dynamic" SetFocusOnError="true" ValidationGroup="update" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_datepostedU" runat="server" Text='<%#Eval("date_posted", "{0:dd/MM/yyyy}") %>'
                                        ReadOnly="true" />
                                </td>
                                <td>
                                    <%--Default dropdownlist for hours--%>
                                    <asp:DropDownList ID="ddl_hoursU" runat="server" SelectedValue='<%#Eval("hours") %>'>
                                        <asp:ListItem>Full-Time</asp:ListItem>
                                        <asp:ListItem>Part-Time</asp:ListItem>
                                        <asp:ListItem>Contract</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <%--Default dropdownlist for departments --%>
                                    <asp:DropDownList ID="ddl_departmentU" runat="server" SelectedValue='<%#Eval("department") %>'>
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
                                </td>
                                <td>
                                    <%--CK Editor for description--%>
                                    <CKEditor:CKEditorControl ID="CKEditor_descU" runat="server" Width="300" Text='<%#Eval("description") %>'>
                                    </CKEditor:CKEditorControl>
                                    <br />
                                    <%-- checking if empty --%>
                                    <asp:RequiredFieldValidator ID="rfv_descriptionU" runat="server" Text="Empty value"
                                        ErrorMessage="Please enter the job description" ControlToValidate="CKEditor_descU"
                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="update" />
                                </td>
                            </tr>
                            <%-- qualifications, salary, deadline on a new line --%>
                            <thead style="background-color: SteelBlue;">
                                <tr>
                                    <th>
                                        <asp:Label ID="lbl_qualificationsU" runat="server" Text="Qualifications" />
                                    </th>
                                    <th>
                                        <asp:Label ID="lbl_salaryU" runat="server" Text="Salary" />
                                    </th>
                                    <th>
                                        <asp:Label ID="lbl_deadlineU" runat="server" Text="Deadline" />
                                    </th>
                                </tr>
                            </thead>
                            <tr>
                                <td>
                                    <%--CK Editor for qualifications--%>
                                    <CKEditor:CKEditorControl ID="CKEditor_qualU" runat="server" Width="300" Text='<%#Eval("qualifications") %>'>
                                    </CKEditor:CKEditorControl>
                                    <br />
                                    <%-- checking if empty --%>
                                    <asp:RequiredFieldValidator ID="rfv_qualificationsU" runat="server" Text="Empty value"
                                        ErrorMessage="Please enter the job qualifications" ControlToValidate="CKEditor_qualU"
                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="update" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_salaryU" runat="server" Text='<%#Eval("salary") %>' />
                                    <br />
                                    <%-- checking if empty --%>
                                    <asp:RequiredFieldValidator ID="rfv_salaryU" runat="server" Text="Empty value" ErrorMessage="Please enter the job salary"
                                        ControlToValidate="txt_salaryU" Display="Dynamic" SetFocusOnError="true" ValidationGroup="update" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_deadlineU" runat="server" Text='<%#Eval("deadline", "{0:dd/MM/yyyy}") %>' />
                                    <%-- checking if empty --%>
                                    <asp:RequiredFieldValidator ID="rfv_deadlineU" runat="server" Text="Empty value"
                                        ErrorMessage="Please enter the job deadline" ControlToValidate="txt_deadlineU"
                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="update" />
                                    <%-- checking if value entered is date format  --%>
                                    <asp:RegularExpressionValidator ID="rev_deadlineU" runat="server" Text="Invalid date, Format: day/month/year"
                                        ErrorMessage="Please enter the correct deadline date" ControlToValidate="txt_deadlineU"
                                        Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\d{1,2}\/\d{1,2}\/\d{4}$"
                                        ValidationGroup="update" />
                                    <br />
                                    <%--Uses AJAX for calendar--%>
                                    <AJAX:CalendarExtender ID="ce_deadlineU" runat="server" TargetControlID="txt_deadlineU"
                                        Format="dd/MM/yyyy" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <%-- Validation Summary for job postings update --%>
                                    <asp:ValidationSummary ID="vds_update" runat="server" HeaderText="Form Errors:" DisplayMode="List"
                                        ValidationGroup="update" />
                                    <asp:Button ID="btn_update" runat="server" Text="Update" CommandName="Update" ValidationGroup="update" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false"
                                        PostBackUrl="#pnl_all" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </asp:Panel>
        <%--Delete Panel--%>
        <asp:Panel ID="pnl_delete" runat="server" GroupingText="Delete Product">
            <asp:Label ID="lbl_delete" runat="server" Text="Delete this record?" ForeColor="Red" />
            <table cellpadding="2" cellspacing="3">
                <thead style="background-color: SteelBlue;">
                    <%--Only show title, date posted, deadline for delete panel--%>
                    <tr>
                        <th>
                            <asp:Label ID="lbl_titleHD" runat="server" Text="Job Title" />
                        </th>
                        <th>
                            <asp:Label ID="lbl_datepostedHD" runat="server" Text="Date Posted" />
                        </th>
                        <th>
                            <asp:Label ID="lbl_deadlineHD" runat="server" Text="Deadline" />
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt_delete" runat="server" OnItemCommand="subUpDel">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("jobposting_id") %>' />
                                <td>
                                    <asp:Label ID="lbl_titleD" runat="server" Text='<%#Eval("title") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_datepostedD" runat="server" Text='<%#Eval("date_posted", "{0:d}") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_deadlineD" runat="server" Text='<%#Eval("deadline", "{0:d}") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CommandName="Cancel" PostBackUrl="#pnl_all" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </asp:Panel>
        </div>
        <div id="insert" >
        <br />
        <hr />
        <asp:Label ID="lbl_required" runat="server" Text="*Required" ForeColor="Maroon" />
        <br />
        <br />
        <%-- Insert --%>
        <asp:Label ID="lbl_titleI" runat="server" Text="Job Title*" AssociatedControlID="txt_titleI"
            Font-Bold="true" />
        <br />
        <asp:TextBox ID="txt_titleI" runat="server" />
        <%-- checking if empty --%>
        <asp:RequiredFieldValidator ID="rfv_titleI" runat="server" Text="Empty value" ErrorMessage="Please enter the job title"
            ControlToValidate="txt_titleI" Display="Dynamic" SetFocusOnError="true" ValidationGroup="insert" />
        <br />
        <asp:Label ID="lbl_datepostedI" runat="server" Text="Date Posted*" AssociatedControlID="txt_datepostedI"
            Font-Bold="true" />
        <br />
        <asp:TextBox ID="txt_datepostedI" runat="server" ReadOnly="true" />
        <br />
        <asp:Label ID="lbl_hoursI" runat="server" Text="Hours*" AssociatedControlID="ddl_hoursI"
            Font-Bold="true" />
        <br />
        <%--Default dropdownlist for hours --%>
        <asp:DropDownList ID="ddl_hoursI" runat="server">
            <asp:ListItem>Full-Time</asp:ListItem>
            <asp:ListItem>Part-Time</asp:ListItem>
            <asp:ListItem>Contract</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lbl_departmentI" runat="server" Text="Department*" AssociatedControlID="ddl_departmentI"
            Font-Bold="true" />
        <br />
        <%--Default dropdownlist for departments --%>
        <asp:DropDownList ID="ddl_departmentI" runat="server">
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
        <asp:Label ID="lbl_descriptionI" runat="server" Text="Description*" AssociatedControlID="CKEditor_descI"
            Font-Bold="true" />
        <br />
        <%-- CK Editor for description --%>
        <CKEditor:CKEditorControl ID="CKEditor_descI" runat="server" Width="500">
        </CKEditor:CKEditorControl>
        <%-- checking if empty --%>
        <asp:RequiredFieldValidator ID="rfv_descriptionI" runat="server" Text="Empty value"
            ErrorMessage="Please enter the job description" ControlToValidate="CKEditor_descI"
            Display="Dynamic" SetFocusOnError="true" ValidationGroup="insert" />
        <br />
        <asp:Label ID="lbl_qualificationsI" runat="server" Text="Qualifications*" AssociatedControlID="CKEditor_qualI"
            Font-Bold="true" />
        <br />
        <%-- CK Editor for qualifications --%>
        <CKEditor:CKEditorControl ID="CKEditor_qualI" runat="server" Width="500">
        </CKEditor:CKEditorControl>
        <%-- checking if empty --%>
        <asp:RequiredFieldValidator ID="rfv_qualifcationsI" runat="server" Text="Empty value"
            ErrorMessage="Please enter the job qualifications" ControlToValidate="CKEditor_qualI"
            Display="Dynamic" SetFocusOnError="true" ValidationGroup="insert" />
        <br />
        <asp:Label ID="lbl_salaryI" runat="server" Text="Salary*" AssociatedControlID="txt_salaryI"
            Font-Bold="true" />
        <br />
        <asp:TextBox ID="txt_salaryI" runat="server" />
        <%-- checking if empty --%>
        <asp:RequiredFieldValidator ID="rfv_salaryI" runat="server" Text="Empty value" ErrorMessage="Please enter the job salary"
            ControlToValidate="txt_salaryI" Display="Dynamic" SetFocusOnError="true" ValidationGroup="insert" />
        <br />
        <asp:Label ID="lbl_deadlineI" runat="server" Text="Deadline*" AssociatedControlID="txt_deadlineI"
            Font-Bold="true" />
        <br />
        <asp:TextBox ID="txt_deadlineI" runat="server" />
        <%-- checking if empty --%>
        <asp:RequiredFieldValidator ID="rfv_deadlineI" runat="server" Text="Empty value"
            ErrorMessage="Please enter the job deadline" ControlToValidate="txt_deadlineI"
            Display="Dynamic" SetFocusOnError="true" ValidationGroup="insert" />
        <asp:Label ID="lbl_calerror" runat="server" />
        <%-- checking if value entered is date format  --%>
        <asp:RegularExpressionValidator ID="rev_deadlineI" runat="server" Text="Invalid date, Format: day/month/year"
            ErrorMessage="Please enter the correct date" ControlToValidate="txt_deadlineI"
            Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\d{1,2}\/\d{1,2}\/\d{4}$"
            ValidationGroup="insert" />
        <%--Uses AJAX for calendar--%>
        <AJAX:CalendarExtender ID="ce_deadline" runat="server" TargetControlID="txt_deadlineI"
            Format="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
        <br />
        <br />
        <%-- Validation Summary for job postings insert --%>
        <asp:ValidationSummary ID="vds_insert" runat="server" HeaderText="Form Errors:" DisplayMode="List"
            ValidationGroup="insert" />
        <asp:Button ID="btn_insert" runat="server" Text="Insert" CommandName="Insert" OnCommand="subAdmin"
            ValidationGroup="insert" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CommandName="Cancel" OnCommand="subAdmin"
            CausesValidation="false" />
    </div>
    </form>
</body>
</html>
