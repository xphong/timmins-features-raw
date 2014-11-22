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

public partial class DetailedJobPosting : System.Web.UI.Page
{

    phong_jobpostingsLinq objLinq = new phong_jobpostingsLinq();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _subBind();
        }
    }

    private void _subBind()
    {
        // get job id from previous job posting list page
        var jobID = Request.QueryString["id"];

        // check if there is a job id is sent
        if (jobID == null)
        {
            jobID = "0";
            lbl_error.Text = "No job posting found.";
        }

        // fill labels with job details
        rpt_detailed.DataSource = objLinq.getJobPostingsByID(Int32.Parse(jobID));
        rpt_detailed.DataBind();
    }

    // apply to job link: sends user to application form
    protected void subApply(object sender, EventArgs e)
    {
        // store job id in the query string
        Response.Redirect("~/ApplicationForm.aspx?id=" + Request.QueryString["id"]);
    }


}