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

public partial class _Default : System.Web.UI.Page
{
    phong_visitorsLinq objLinq = new phong_visitorsLinq();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Submit Button: hide form panel, insert info into visitors table
    protected void subSubmit(object sender, EventArgs e)
    {
        // hide visit form
        pnl_visitform.Visible = false;

        // set duration to 0 if not entered by user
        if (txt_duration.Text == "")
        {
            txt_duration.Text = "0";
        }

        // check if user selected minutes or hours
        if (ddl_duration.SelectedIndex == 0)
        {
            if (Page.IsValid)
            {
                // Database Insert if form is valid
                _strMessage(objLinq.insertVisitor(txt_name.Text, txt_pname.Text, txt_number.Text, Int32.Parse(txt_visitors.Text), DateTime.ParseExact(txt_dateofvisit.Text, "dd/MM/yyyy", null), txt_duration.Text + " minutes", txt_email.Text));
            }
        }
        else
        {
            if (Page.IsValid)
            {
                // Database Insert 
                _strMessage(objLinq.insertVisitor(txt_name.Text, txt_pname.Text, txt_number.Text, Int32.Parse(txt_visitors.Text), DateTime.ParseExact(txt_dateofvisit.Text, "dd/MM/yyyy", null), txt_duration.Text + " hours", txt_email.Text));

            }
        }
    }

    // Clear Button: clears the form
    protected void subClear(object sender, EventArgs e)
    {
        // set textboxes to empty
        lbl_output.Text = string.Empty;
        txt_name.Text = string.Empty;
        txt_pname.Text = string.Empty;
        txt_number.Text = string.Empty;
        txt_visitors.Text = string.Empty;
        txt_dateofvisit.Text = string.Empty;
        txt_duration.Text = string.Empty;
        txt_email.Text = string.Empty;
        pnl_visitform.Visible = true;
    }

    // Sets output message
    private void _strMessage(bool flag)
    {
        double parkingfee = 0.00;
        // if database insert worked then output confirmation message
        if (flag)
        {
            // if duration is empty then output different message
            if (txt_duration.Text == "0")
            {
                lbl_output.Text = "Thank you, " + txt_name.Text + ", for filling out the form. " + txt_pname.Text + " will be notified about the visit as soon as possible and an email will be sent to you.<br /><br />";
            }
            else
            {
                // calculate parking fee if user entered duration, $5 dollars per hour 

                // check if user selected minutes or hours
                if (ddl_duration.SelectedIndex == 0)
                {
                    parkingfee = (double.Parse(txt_duration.Text) / 60) * 5;
                }
                else
                {
                    parkingfee = double.Parse(txt_duration.Text) * 5;
                }

                //output message
                lbl_output.Text = "Thank you, " + txt_name.Text + ", for filling out the form. " + txt_pname.Text + " will be notified about the visit as soon as possible and an email will be sent to you.<br /><br />";
                lbl_output.Text += "Your Parking Fee: " + String.Format("{0:C}", parkingfee);
            }
        }
        // if database insert failed then output error message
        else
        {

            lbl_output.Text = "There is currently an error with the database.";
        }
    }

}