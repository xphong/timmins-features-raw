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

public partial class JobPostings : System.Web.UI.Page
{

    phong_jobpostingsLinq objLinq = new phong_jobpostingsLinq();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Binds gridview once on page load
            _subBind();
            // Check if user used Search
            _subCheckSearch();
            // Check if user used Advanced Search
            _subCheckASearch();
            // Check if user used Sort By department
            _subCheckDDL();
        }
    }

    // Subroutine to bind gridview
    private void _subBind()
    {
        // fill gridview
        grv_jobpostings.DataSource = objLinq.getJobPostings();
        grv_jobpostings.DataBind();
        
        // hide error messages
        lbl_error.Text = string.Empty;

        // check if user sorted by departments
        if (Request.QueryString["ddl"] != null)
        {
            // save department selected inside drop down list
            ddl_department.SelectedValue = Request.QueryString["ddl"];
        }
        else
        {
            ddl_department.SelectedIndex = 0;
        }

    }

    // Search Check: checks if user used the search
    private void _subCheckSearch()
    {
        if (Request.QueryString["search"] != null)
        {
            // binds search results to gridview
            grv_jobpostings.DataSource = objLinq.getJobPostingsBySearch(Request.QueryString["search"]);
            grv_jobpostings.DataBind();

            // checks if there are any search results
            if (grv_jobpostings.Rows.Count == 0)
            {
                // error message if there are no results
                lbl_error.Text = "No search results found. Please try the <a href='CareerAlert.aspx'>Career Alert Page</a> if you are having trouble finding a job posting.";
            }
        }
    }

    // Advanced Search Check: checks if user used advanced search
    private void _subCheckASearch()
    {
        if (Request.QueryString["as"] != null)
        {
            // get values from query string
            string search = Request.QueryString["asearch"];
            string department = Request.QueryString["department"];
            string hours = Request.QueryString["hours"];
            string deadline = Request.QueryString["deadline"];

            // check if user entered a search string
            if (search == "")
            {
                // query search results without search string
                grv_jobpostings.DataSource = objLinq.getJobPostingsByASearch(department, hours, deadline);
                grv_jobpostings.DataBind();
            }
            else
            {
                // query search results with search string
                grv_jobpostings.DataSource = objLinq.getJobPostingsByASearch(search, department, hours, deadline);
                grv_jobpostings.DataBind();
            }

            // checks if there are any search results
            if (grv_jobpostings.Rows.Count == 0)
            {
                // error message if there are no results
                lbl_error.Text = "No search results found. Please try the <a href='CareerAlert.aspx'>Career Alert Page</a> if you are having trouble finding a job posting.";
            }
        }
    }

    // Department Sort Check: checks if user sorted by department
    private void _subCheckDDL()
    {
        if (Request.QueryString["ddl"] != null)
        {
            // bind gridview with selected department
            grv_jobpostings.DataSource = objLinq.getDepartmentsBySort(Request.QueryString["ddl"]);
            grv_jobpostings.DataBind();

            if (grv_jobpostings.Rows.Count == 0)
            {
                // error message if there are no results
                lbl_error.Text = "There are currently no job postings available in the selected department";
            }
        }
    }

    // Search function: searches by title only
    protected void subSearch(object sender, EventArgs e)
    {
        Response.Redirect("JobPostings.aspx?search=" + txt_search.Text);
    }

    // View All Button: views all job postings
    protected void subViewAll(object sender, EventArgs e)
    {
        Response.Redirect("JobPostings.aspx");
    }

    // Sort by Department
    protected void subDDLChange(object sender, EventArgs e)
    {
        lbl_error.Text = string.Empty;

        Response.Redirect("JobPostings.aspx?ddl=" + ddl_department.SelectedValue.ToString());

    }

    // Sort selected column
    protected void subSort(object sender, CommandEventArgs e)
    {
        // check if user searched anything
        if (Request.QueryString["search"] != null)
        {       
            // if user searched, sort with search results
            grv_jobpostings.DataSource = objLinq.sortColumnBySearch(e.CommandName, Request.QueryString["search"]);
            grv_jobpostings.DataBind();
            
        }
        else
        {
            // sort normally
            grv_jobpostings.DataSource = objLinq.sortColumn(e.CommandName);
            grv_jobpostings.DataBind();
        }
    }
}