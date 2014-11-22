/*
 * Phong Huynh - 810194340, hnhp0025
 * Timmins Hospital Website
 * Job Postings Feature
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

public partial class ApplicationForm_admin : System.Web.UI.Page
{
    phong_applicationsLinq objLinq = new phong_applicationsLinq();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _subBind();
        }
    }

    // Subroutine to bind gridview
    private void _subBind()
    {
        grv_applications.DataSource = objLinq.getApplicationsJobTitle();
        grv_applications.DataBind();
    }

    // Sort selected column
    protected void subSort(object sender, CommandEventArgs e)
    {
        grv_applications.DataSource = objLinq.sortColumn(e.CommandName);
        grv_applications.DataBind();
    }

    // confirmation message
    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_msg.Text = "<span style='color:green'>Application " + str + " was successful.</span>";
        else
            lbl_msg.Text = "<span style='color:red'>Unable to " + str + " application.</span>";
    }

    // Delete application
    protected void Delete(object sender, EventArgs e)
    {
        LinkButton lnkDelete = (LinkButton)sender;

        // split command arguments to get id, resume
        var args = lnkDelete.CommandArgument.Split('^');
        int id = Int32.Parse(args[0]);
        string resume = args[1];

        // delete selected application
        _strMessage(objLinq.deleteApplication(id), "delete");
        
        // set file path for resume
        string resumePath = Server.MapPath("~/Resumes/") + resume;

        // check if file exists
        if (File.Exists(resumePath))
        {
            // delete resume file from server
            File.Delete(resumePath);
        }
        _subBind();
    }


}