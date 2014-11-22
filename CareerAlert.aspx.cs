/*
 * Phong Huynh - 810194340, hnhp0025
 * Timmins Hospital Website
 * Career Alert
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

public partial class CareerAlert : System.Web.UI.Page
{

    phong_careeralertLinq objLinq = new phong_careeralertLinq();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

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
            // set uploaded file name to "Alert-Name-Resume".extension to prevent replacing similar resume 
            string serverFileName = "Alert-" + name + "-Resume" + Path.GetExtension(fu_resume.PostedFile.FileName);
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
            pnl_alertform.Visible = false;

            // database insert here
            _strMessage(objLinq.insertAlert(txt_name.Text, ddl_department.SelectedValue.ToString(), txt_email.Text, resume));
        }

    }

    // Clear Button: clears the form
    protected void subClear(object sender, EventArgs e)
    {
        // set textboxes to empty
        lbl_output.Text = string.Empty;
        txt_name.Text = string.Empty;
        txt_email.Text = string.Empty;
        lbl_rfvresume.Text = string.Empty;
        pnl_alertform.Visible = true;
    }

    // Sets output message
    private void _strMessage(bool flag)
    {
        // if database insert worked then output confirmation message
        if (flag)
        {
            //output message
            lbl_output.Text = "Thank you, " + txt_name.Text + ". Your information is now in our database and you will be notified by email when a relevant job opportunity is posted. <a href='CareerAlert.aspx'>Click here</a> to go back to the Career Alert page.";
        }
        // else database insert failed then output error message
        else
        {

            lbl_output.Text = "There is currently an error with the database.";
        }
    }

}