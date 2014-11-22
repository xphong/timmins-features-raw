/*
 * Phong Huynh - 810194340, hnhp0025
 * Timmins Hospital Website
 * Job Postings Feature: Application Form
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

public partial class ApplicationForm : System.Web.UI.Page
{
    phong_applicationsLinq objLinq = new phong_applicationsLinq();
    phong_email objEmail = new phong_email();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _getJobTitle();
        }
    }
    
    // get job title for selected form
    private void _getJobTitle()
    {
        // get job posting id from the query string
        var jobID = Request.QueryString["id"];

        // set jobID to 0 if no querystring - so that no error shows
        if (jobID == null)
        {
            jobID = "0";
            // hide application form
            pnl_appform.Visible = false;
        }

        // bind job title to repeater
        rpt_jobtitle.DataSource = objLinq.getJobPostingTitle(Int32.Parse(jobID));
        rpt_jobtitle.DataBind();
    }

    // Submit Button: hide form panel, insert info into applications table, email to careers, upload resume
    protected void subSubmit(object sender, EventArgs e)
    {
        // check if empty
        if (fu_resume.PostedFile.FileName == "")
        {
            // error message
            lbl_rfvresume.Text = "No file specified.";
        }
        else
        {
            // get extension of file
            string extension = Path.GetExtension(fu_resume.PostedFile.FileName);

            // Check the extension of the resume
            switch (extension.ToLower())
            {
                // only accept .doc, .docx, .pdf files
                case ".doc":
                case ".docx":
                case ".pdf":
                    break;
                default:
                    lbl_rfvresume.Text = "Invalid file type, Please upload a .doc, .docx, or .pdf file";
                    return;
            }

            // upload resume file to resumes folder
            string location = "~/Resumes/".ToString();
            // trim spaces from name
            string name = txt_name.Text.Replace(" ", string.Empty);
            // set uploaded file name to "NAME-JOBID-Resume".extension to prevent replacing similar resume files
            string serverFileName = name + "-" + Request.QueryString["id"].ToString() + "-Resume" + Path.GetExtension(fu_resume.PostedFile.FileName);
            // used to insert into database
            string resume = serverFileName.ToString();
            // set upload directory
            string uploadDirectory = Path.Combine(Request.PhysicalApplicationPath, "Resumes");


            // path resumes are uploaded to
            string fullUploadPath = Path.Combine(uploadDirectory,
              serverFileName);

            try
            {
                // upload file to folder
                fu_resume.PostedFile.SaveAs(fullUploadPath);
            }
            catch (Exception err)
            {
                lbl_rfvresume.Text = err.Message;
            }
            // hide application form
            pnl_appform.Visible = false;

            // email application to timminscareers@gmail.com
            Label lblJobTitle = (Label)rpt_jobtitle.Items[0].FindControl("lbl_jobtitle");
            string email = "timminscareers@gmail.com";
            string subject = lblJobTitle.Text + " - " + txt_name.Text;
            string message = "<p>An applicant has applied for the " + lblJobTitle.Text
                              + "<br />Please view the <a href='http://timmins.sidhusweb.com'>job applications</a> admin page for more information about the applicant.<br /><br /> "
                            + "<strong>Name:</strong> " + txt_name.Text + "<br /><strong>Email:</strong> " + txt_email.Text + "<br /><strong>Phone Number:</strong> " + txt_number.Text
                            + "</p><br /><br /><hr />Timmins and District Hospital";
            // send email
            objEmail.sendEmail(email, subject, message);

            // database insert
            _strMessage(objLinq.insertApplication(Int32.Parse(Request.QueryString["id"]), txt_name.Text, txt_email.Text, txt_address.Text, txt_city.Text, txt_postalcode.Text, txt_number.Text, resume, txt_coverletter.Text));

        }

    }

    // Clear Button: clears the form
    protected void subClear(object sender, EventArgs e)
    {
        // set textboxes to empty
        lbl_output.Text = string.Empty;
        txt_name.Text = string.Empty;
        txt_email.Text = string.Empty;
        txt_number.Text = string.Empty;
        txt_address.Text = string.Empty;
        txt_city.Text = string.Empty;
        txt_postalcode.Text = string.Empty;
        lbl_rfvresume.Text = string.Empty;
        pnl_appform.Visible = true;
    }


    // Sets output message
    private void _strMessage(bool flag)
    {
        // if database insert worked then output confirmation message
        if (flag)
        {
            //output message
            lbl_output.Text = "Thank you, " + txt_name.Text + ". Your job application has been sent. <a href='JobPostings.aspx'>Click here</a> to go back to the job postings page.";
        }
        // else database insert failed then output error message
        else
        {

            lbl_output.Text = "There is currently an error with the database.";
        }
    }
}