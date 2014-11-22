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
/// Summary description for phong_jobpostingsLinq
/// </summary>
public class phong_jobpostingsLinq
{
    // TimminsDBDataContext - data context

    public IQueryable<tbl_jobposting> getJobPostings()
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objJobPostingsDC = new TimminsDBDataContext();
        // create anonymous variable with its value being instance of our LINQ object
        var allJobPostings = objJobPostingsDC.tbl_jobpostings.Select(x => x);
        return allJobPostings;
    }

    public IQueryable<tbl_jobposting> getJobPostingsByID(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objJobPostingsDC = new TimminsDBDataContext();
        var jobpostingID = objJobPostingsDC.tbl_jobpostings.Where(x => x.jobposting_id == _id).Select(x => x);
        return jobpostingID;
    }

    // Job Postings quick search - searches by job title
    public IQueryable<tbl_jobposting> getJobPostingsBySearch(string _search)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objJobPostingsDC = new TimminsDBDataContext();
        var jobpostingSearch = objJobPostingsDC.tbl_jobpostings.Where(x => x.title.Contains(_search)).Select(x => x);
        return jobpostingSearch;
    }

    // Job Postings advanced search - searches by department, hours, deadline
    public IQueryable<tbl_jobposting> getJobPostingsByASearch(string _department, string _hours, string _deadline)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objJobPostingsDC = new TimminsDBDataContext();

        // convert deadline string to date
        DateTime deadline = DateTime.Parse(_deadline);
        // get current date
        DateTime currentdate = DateTime.Now;

        // query for records with same department, hours, deadline
        var jobpostingASearch = objJobPostingsDC.tbl_jobpostings.Where(x => x.department == _department && x.hours == _hours && x.deadline.CompareTo(currentdate) >= 0 && x.deadline.CompareTo(deadline) <= 0).Select(x => x);
        
        // check if hours and departments are set to any
        // set appropriate query string
        if (_department == "Any" && _hours == "Any")
        {
            jobpostingASearch = objJobPostingsDC.tbl_jobpostings.Where(x => x.deadline.CompareTo(currentdate) >= 0 && x.deadline.CompareTo(deadline) <= 0).Select(x => x);
        }
        else if (_department == "Any")
        {

            jobpostingASearch = objJobPostingsDC.tbl_jobpostings.Where(x => x.hours == _hours && x.deadline.CompareTo(currentdate) >= 0 && x.deadline.CompareTo(deadline) <= 0).Select(x => x);
        }
        else if (_hours == "Any")
        {

            jobpostingASearch = objJobPostingsDC.tbl_jobpostings.Where(x => x.department == _department && x.deadline.CompareTo(currentdate) >= 0 && x.deadline.CompareTo(deadline) <= 0).Select(x => x);
        }
        else
        {
            jobpostingASearch = objJobPostingsDC.tbl_jobpostings.Where(x => x.department == _department && x.hours == _hours && x.deadline.CompareTo(currentdate) >= 0 && x.deadline.CompareTo(deadline) <= 0).Select(x => x);
        }

        return jobpostingASearch;
    }

    // Job Postings advanced search - searches by job title, department, hours, deadline
    public IQueryable<tbl_jobposting> getJobPostingsByASearch(string _search, string _department, string _hours, string _deadline)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objJobPostingsDC = new TimminsDBDataContext();

        // convert deadline string to date
        DateTime deadline = DateTime.Parse(_deadline);
        // get current date
        DateTime currentdate = DateTime.Now;

        // query for records with similar title, same department, same hours, deadline between now and selected deadline
        var jobpostingASearch = objJobPostingsDC.tbl_jobpostings.Where(x => x.title.Contains(_search) && x.department == _department && x.hours == _hours && x.deadline.CompareTo(currentdate) >= 0 && x.deadline.CompareTo(deadline) <= 0).Select(x => x);
        
        // check if hours and departments are set to any
        // set appropriate query string
        if (_department == "Any" && _hours == "Any")
        {
            jobpostingASearch = objJobPostingsDC.tbl_jobpostings.Where(x => x.title.Contains(_search) && x.deadline.CompareTo(currentdate) >= 0 && x.deadline.CompareTo(deadline) <= 0).Select(x => x);
        }
        else if (_department == "Any")
        {

            jobpostingASearch = objJobPostingsDC.tbl_jobpostings.Where(x => x.title.Contains(_search) && x.hours == _hours && x.deadline.CompareTo(currentdate) >= 0 && x.deadline.CompareTo(deadline) <= 0).Select(x => x);
        }
        else if (_hours == "Any")
        {

            jobpostingASearch = objJobPostingsDC.tbl_jobpostings.Where(x => x.title.Contains(_search) && x.department == _department && x.deadline.CompareTo(currentdate) >= 0 && x.deadline.CompareTo(deadline) <= 0).Select(x => x);
        }
        else
        {
            jobpostingASearch = objJobPostingsDC.tbl_jobpostings.Where(x => x.title.Contains(_search) && x.department == _department && x.hours == _hours && x.deadline.CompareTo(currentdate) >= 0 && x.deadline.CompareTo(deadline) <= 0).Select(x => x);
        }
        
        return jobpostingASearch;
    }

    // Sort by Department - returns department selected
    public IQueryable<tbl_jobposting> getDepartmentsBySort(string _department)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objJobPostingsDC = new TimminsDBDataContext();
        var departmentSort = objJobPostingsDC.tbl_jobpostings.Where(x => x.department == _department).Select(x => x);
        return departmentSort;
    }

    // Sort columns
    public IQueryable<tbl_jobposting> sortColumn(string _column)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objJobPostingsDC = new TimminsDBDataContext();
        // default to no sorting
        var columnSort = objJobPostingsDC.tbl_jobpostings.Select(x => x);
        
        // check which sorting the user clicked
        switch (_column)
        {
            case "id":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderBy(x => x.jobposting_id).Select(x => x);
                break;
            case "title":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderBy(x => x.title).Select(x => x);
                break;
            case "hours":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderBy(x => x.hours).Select(x => x);
                break;
            case "department":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderBy(x => x.department).Select(x => x);
                break;
            case "dateposted":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderByDescending(x => x.date_posted).Select(x => x);
                break;
            case "deadline":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderBy(x => x.deadline).Select(x => x);
                break;
            // admin side only
            case "description":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderBy(x => x.description).Select(x => x);
                break;
            case "qualifications":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderBy(x => x.qualifications).Select(x => x);
                break;
            case "salary":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderBy(x => x.salary).Select(x => x);
                break;
        }

        return columnSort;
    }

    // Sort columns with search results
    public IQueryable<tbl_jobposting> sortColumnBySearch(string _column, string _search)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objJobPostingsDC = new TimminsDBDataContext();
        // default to no sorting
        var columnSort = objJobPostingsDC.tbl_jobpostings.Select(x => x);

        // check which sorting the user clicked and where title contains search
        switch (_column)
        {
            case "title":
                // SELECT * FROM tbl_jobpostings WHERE title = searchresults ORDER BY title
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderBy(x => x.title).Where(x => x.title.Contains(_search)).Select(x => x);
                break;
            case "hours":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderBy(x => x.hours).Where(x => x.title.Contains(_search)).Select(x => x);
                break;
            case "department":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderBy(x => x.department).Where(x => x.title.Contains(_search)).Select(x => x);
                break;
            case "dateposted":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderByDescending(x => x.date_posted).Where(x => x.title.Contains(_search)).Select(x => x);
                break;
            case "deadline":
                columnSort = objJobPostingsDC.tbl_jobpostings.OrderBy(x => x.deadline).Where(x => x.title.Contains(_search)).Select(x => x);
                break;
        }
        return columnSort;
    }

    public bool insertJob(string _title, DateTime _dateposted, string _hours, string _department, string _description, string _qualifications, string _salary, DateTime _deadline)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objJobPostingsDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objJobPostingsDC)
        {
            // create instance of our table object
            tbl_jobposting objNewJobPosting = new tbl_jobposting();
            // set values
            objNewJobPosting.title = _title;
            objNewJobPosting.date_posted = _dateposted;
            objNewJobPosting.hours = _hours;
            objNewJobPosting.department = _department;
            objNewJobPosting.description = _description;
            objNewJobPosting.qualifications = _qualifications;
            objNewJobPosting.salary = _salary;
            objNewJobPosting.deadline = _deadline;
            // insert command
            objJobPostingsDC.tbl_jobpostings.InsertOnSubmit(objNewJobPosting);
            // commit insert against database
            objJobPostingsDC.SubmitChanges();
            return true;
        }
    }

    public bool updateJob(int _id, string _title, DateTime _dateposted, string _hours, string _department, string _description, string _qualifications, string _salary, DateTime _deadline)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objJobPostingsDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objJobPostingsDC)
        {
            // where id = _id
            var objUpJobPosting = objJobPostingsDC.tbl_jobpostings.Single(x => x.jobposting_id == _id);
            objUpJobPosting.title = _title;
            objUpJobPosting.date_posted = _dateposted;
            objUpJobPosting.hours = _hours;
            objUpJobPosting.department = _department;
            objUpJobPosting.description = _description;
            objUpJobPosting.qualifications = _qualifications;
            objUpJobPosting.salary = _salary;
            objUpJobPosting.deadline = _deadline;
            // commit update against database
            objJobPostingsDC.SubmitChanges();
            return true;
        }
    }

    public bool deleteJob(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objJobPostingsDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objJobPostingsDC)
        {
            var objDelJobPosting = objJobPostingsDC.tbl_jobpostings.Single(x => x.jobposting_id == _id);
            objJobPostingsDC.tbl_jobpostings.DeleteOnSubmit(objDelJobPosting);
            objJobPostingsDC.SubmitChanges();
            return true;
        }
    }


}