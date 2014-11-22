/*
 * Phong Huynh - 810194340, hnhp0025
 * Timmins Hospital Website
 * Plan A Visit Feature
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Planavisit_admin : System.Web.UI.Page
{
    phong_visitorsLinq objLinq = new phong_visitorsLinq();
    phong_email objEmail = new phong_email();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Binds gridview on page load
        if (!IsPostBack)
        {
            _subBind();
        }
    }


    // Subroutine to bind gridview
    private void _subBind()
    {
        grv_visitors.DataSource = objLinq.getVisitors();
        grv_visitors.DataBind();
    }

    // confirmation message
    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_msg.Text = "<span style='color:green'>Visitor " + str + " was successful.</span>";
        else
            lbl_msg.Text = "<span style='color:red'>Unable to " + str + " visitor.</span>";
    }

    // Set status to notified
    protected void Notify(object sender, EventArgs e)
    {
        LinkButton lnkNotify = (LinkButton)sender;

        // split command arguments to get id, name, email, patient name
        var args = lnkNotify.CommandArgument.Split('^');
        int id = Int32.Parse(args[0]);
        string name = args[1];
        string email = args[2];
        string pname = args[3];

        // set email subject and message
        string subject = "Patient notified about your visit";
        string message = "Hi " + name + ",<br /><br /><p>The patient '" + pname + "' has been notified about your visit.</p><br />"
                         + "<hr />Timmins and District Hospital"; 

        // email visitor with confirmation
        objEmail.sendEmail(email, subject, message);

        // change status to notified
        _strMessage(objLinq.notifyVisitor(id), "notify and email");

        _subBind();
    }


    // Set status to pending
    protected void Pending(object sender, EventArgs e)
    {
        LinkButton lnkPending = (LinkButton)sender;

        int id = Int32.Parse(lnkPending.CommandArgument);
        _strMessage(objLinq.pendingVisitor(id), "pending");
        _subBind();
    }

    // Delete visitor
    protected void Delete(object sender, EventArgs e)
    {
        LinkButton lnkDelete = (LinkButton)sender;

        int id = Int32.Parse(lnkDelete.CommandArgument);
        _strMessage(objLinq.deleteVisitor(id), "delete");
        _subBind();
    }

    // Sort selected column
    protected void subSort(object sender, CommandEventArgs e)
    {
        grv_visitors.DataSource = objLinq.sortColumn(e.CommandName);
        grv_visitors.DataBind();
    }

}