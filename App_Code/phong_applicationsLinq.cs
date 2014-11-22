/*
 * Phong Huynh - 810194340, hnhp0025
 * Timmins Hospital Website
 * Job Postings Feature
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for phong_applicationsLinq
/// </summary>
public class phong_applicationsLinq
{
    // TimminsDBDataContext - data context

    public IQueryable<tbl_application> getApplications()
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objApplicationsDC = new TimminsDBDataContext();
        // create anonymous variable with its value being instance of our LINQ object
        var allApplications = objApplicationsDC.tbl_applications.Select(x => x);
        return allApplications;
    }

    public IQueryable<tbl_application> getApplicationByID(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objApplicationsDC = new TimminsDBDataContext();
        var applicationID = objApplicationsDC.tbl_applications.Where(x => x.application_id == _id).Select(x => x);
        return applicationID;
    }

    // get application table along with job title from job postings table through jobposting_id foreign key
    public IQueryable getApplicationsJobTitle()
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objApplicationsDC = new TimminsDBDataContext();
        // create anonymous variable with its value being instance of our LINQ object
        // inner join to job postings table to get job title
        var allApplications = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date });
        return allApplications;
    }


    // Sort columns
    public IQueryable sortColumn(string _column)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objApplicationsDC = new TimminsDBDataContext();
        // default to no sorting
        // inner join to job postings table to get job title
        var columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date });

        // check which sorting the user clicked
        switch (_column)
        {
            case "id":
                columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date }).OrderBy(a => a.application_id);
                break;
            case "jobid":
                columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date }).OrderBy(a => a.jobposting_id);
                break;
            case "title":
                columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date }).OrderBy(j => j.title);
                break;
            case "date":
                columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date }).OrderByDescending(a => a.app_date);
                break;
            case "name":
                columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date }).OrderBy(a => a.name);
                break;
            case "email":
                columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date }).OrderBy(a => a.email);
                break;
            case "phonenumber":
                columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date }).OrderBy(a => a.phonenumber);
                break;
            case "address":
                columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date }).OrderByDescending(a => a.address);
                break;
            case "city":
                columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date }).OrderByDescending(a => a.city);
                break;
            case "postalcode":
                columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date }).OrderByDescending(a => a.postalcode);
                break;
            case "resume":
                columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date }).OrderBy(a => a.resume);
                break;
            case "coverletter":
                columnSort = objApplicationsDC.tbl_applications.Join(objApplicationsDC.tbl_jobpostings, a => a.jobposting_id, j => j.jobposting_id, (a, j)
            => new { a.application_id, a.jobposting_id, j.title, a.name, a.email, a.phonenumber, a.address, a.city, a.postalcode, a.resume, a.coverletter, a.app_date }).OrderByDescending(a => a.coverletter);
                break;
        }

        return columnSort;
    }

    // get job title
    public IQueryable<tbl_jobposting> getJobPostingTitle(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objJobPostingDC = new TimminsDBDataContext();

        var jobpostingID = objJobPostingDC.tbl_jobpostings.Where(x => x.jobposting_id == _id).Select(x => x);
        return jobpostingID;
    }


    public bool insertApplication(int _jobpostingID, string _name, string _email, string _address, string _city, string _postalcode, string _phonenumber, string _resume, string _coverletter)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objApplicationsDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objApplicationsDC)
        {
            // create instance of our table object
            tbl_application objNewApplication = new tbl_application();
            // set values
            objNewApplication.jobposting_id = _jobpostingID;
            objNewApplication.name = _name;
            objNewApplication.email = _email;
            objNewApplication.address = _address;
            objNewApplication.city = _city;
            objNewApplication.postalcode = _postalcode;
            objNewApplication.phonenumber = _phonenumber;
            objNewApplication.resume = _resume;
            objNewApplication.coverletter = _coverletter;
            // set application date to current date
            objNewApplication.app_date = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null);
            // insert command
            objApplicationsDC.tbl_applications.InsertOnSubmit(objNewApplication);
            // commit insert against database
            objApplicationsDC.SubmitChanges();
            return true;
        }
    }

    public bool deleteApplication(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objApplicationsDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objApplicationsDC)
        {
            var objDelApplication = objApplicationsDC.tbl_applications.Single(x => x.application_id == _id);
            objApplicationsDC.tbl_applications.DeleteOnSubmit(objDelApplication);
            objApplicationsDC.SubmitChanges();
            return true;
        }
    }

}