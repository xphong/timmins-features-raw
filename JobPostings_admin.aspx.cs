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

public partial class JobPostings_admin : System.Web.UI.Page
{
    // create linq object
    phong_jobpostingsLinq objLinq = new phong_jobpostingsLinq();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subBind();
        }
    }

    // Subroutine to bind table
    private void _subBind()
    {
        // clear current insert boxes
        txt_titleI.Text = string.Empty;
        ddl_hoursI.SelectedIndex = 0;
        ddl_departmentI.SelectedIndex = 0;
        CKEditor_descI.Text = string.Empty;
        CKEditor_qualI.Text = string.Empty;
        txt_salaryI.Text = string.Empty;
        txt_deadlineI.Text = string.Empty;

        // set date posted to current date for insert
        txt_datepostedI.Text = DateTime.Now.ToString("dd/MM/yyyy");

        rpt_all.DataSource = objLinq.getJobPostings();
        rpt_all.DataBind();

        _panelControl(pnl_all);
    }

    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_msg.Text = "<span style='color:green'>Job Posting " + str + " was successful.</span>";
        else
            lbl_msg.Text = "<span style='color:red'>Unable to " + str + " Job Posting.</span>";
    }

    // controls view of table
    private void _panelControl(Panel pnl)
    {
        pnl_all.Visible = false;
        pnl_delete.Visible = false;
        pnl_update.Visible = false;
        pnl.Visible = true;
    }

    protected void subAdmin(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Insert":
                // sends the boolean from commitInsert into strMessage Flag and does the insert

                // encode decode converts string and format into html, keeps formatting
                _strMessage(objLinq.insertJob(txt_titleI.Text, DateTime.ParseExact(txt_datepostedI.Text, "dd/MM/yyyy", null), ddl_hoursI.SelectedValue.ToString(), ddl_departmentI.SelectedValue.ToString(), Server.HtmlDecode(CKEditor_descI.Text), Server.HtmlDecode(CKEditor_qualI.Text), txt_salaryI.Text, DateTime.ParseExact(txt_deadlineI.Text, "dd/MM/yyyy", null)), "insert");
                _subBind();
                break;
            case "Update":
                // show update panel
                _showUpdate(int.Parse(e.CommandArgument.ToString()));
                break;
            case "Delete":
                // show delete panel
                _showDelete(int.Parse(e.CommandArgument.ToString()));
                break;
            case "Cancel":
                _subBind();
                break;
        }
    }

    protected void subUpDel(object sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            // update table
            case "Update":
                // find controls inside repeater
                TextBox txtTitle = (TextBox)e.Item.FindControl("txt_titleU");
                TextBox txtDatePosted = (TextBox)e.Item.FindControl("txt_datepostedU");
                DropDownList ddlHours = (DropDownList)e.Item.FindControl("ddl_hoursU");
                DropDownList ddlDepartment = (DropDownList)e.Item.FindControl("ddl_departmentU");
                CKEditor.NET.CKEditorControl description = (CKEditor.NET.CKEditorControl)e.Item.FindControl("CKEditor_descU");
                CKEditor.NET.CKEditorControl qualifications = (CKEditor.NET.CKEditorControl)e.Item.FindControl("CKEditor_qualU");
                TextBox txtSalary = (TextBox)e.Item.FindControl("txt_salaryU");
                TextBox txtDeadline = (TextBox)e.Item.FindControl("txt_deadlineU");

                HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_id");
                
                // update job posting, send output message
                int jobID = int.Parse(hdfID.Value.ToString());
                _strMessage(objLinq.updateJob(jobID, txtTitle.Text, DateTime.ParseExact(txtDatePosted.Text, "dd/MM/yyyy", null), ddlHours.SelectedValue.ToString(), ddlDepartment.SelectedValue.ToString(), Server.HtmlDecode(description.Text), Server.HtmlDecode(qualifications.Text), txtSalary.Text, DateTime.ParseExact(txtDeadline.Text, "dd/MM/yyyy", null)), "update");
                _subBind();
                break;
            // delete table
            case "Delete":
                // delete job posting, send output message
                int _id = int.Parse(((HiddenField)e.Item.FindControl("hdf_id")).Value);
                _strMessage(objLinq.deleteJob(_id), "delete");
                _subBind();
                break;
            case "Cancel":
                _subBind();
                break;
        }
    }

    // control for update 
    private void _showUpdate(int id)
    {
        // show update panel
        _panelControl(pnl_update);
        
        phong_jobpostingsLinq _linq = new phong_jobpostingsLinq();
        rpt_update.DataSource = _linq.getJobPostingsByID(id);
        rpt_update.DataBind();
    }

    // control for delete
    private void _showDelete(int id)
    {
        // show delete panel
        _panelControl(pnl_delete);
        rpt_delete.DataSource = objLinq.getJobPostingsByID(id);
        rpt_delete.DataBind();
    }

    // Sort selected column
    protected void subSort(object sender, CommandEventArgs e)
    {
        rpt_all.DataSource = objLinq.sortColumn(e.CommandName);
        rpt_all.DataBind();
    }
}