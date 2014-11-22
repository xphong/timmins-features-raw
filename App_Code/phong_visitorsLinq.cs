/*
 * Phong Huynh - 810194340, hnhp0025
 * Timmins Hospital Website
 * Plan A Visit Feature
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for phong_visitorsLinq
/// </summary>
public class phong_visitorsLinq
{
    // TimminsDBDataContext - data context

    public IQueryable<tbl_visitor> getVisitors()
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objVisitorsDC = new TimminsDBDataContext();
        // create anonymous variable with its value being instance of our LINQ object
        var allVisitors = objVisitorsDC.tbl_visitors.Select(x => x);
        return allVisitors;
    }

    public IQueryable<tbl_visitor> getVisitorByID(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objVisitorsDC = new TimminsDBDataContext();
        var visitorID = objVisitorsDC.tbl_visitors.Where(x => x.visitor_id == _id).Select(x => x);
        return visitorID;
    }

    // Sort columns
    public IQueryable<tbl_visitor> sortColumn(string _column)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objVisitorsDC = new TimminsDBDataContext();
        // default to no sorting
        var columnSort = objVisitorsDC.tbl_visitors.Select(x => x);

        // check which sorting the user clicked
        switch (_column)
        {
            case "id":
                columnSort = objVisitorsDC.tbl_visitors.OrderBy(x => x.visitor_id).Select(x => x);
                break;
            case "name":
                columnSort = objVisitorsDC.tbl_visitors.OrderBy(x => x.name).Select(x => x);
                break;
            case "email":
                columnSort = objVisitorsDC.tbl_visitors.OrderBy(x => x.email).Select(x => x);
                break;
            case "pname":
                columnSort = objVisitorsDC.tbl_visitors.OrderBy(x => x.patient_name).Select(x => x);
                break;
            case "phone":
                columnSort = objVisitorsDC.tbl_visitors.OrderBy(x => x.phone_number).Select(x => x);
                break;
            case "visitors":
                columnSort = objVisitorsDC.tbl_visitors.OrderBy(x => x.visitors).Select(x => x);
                break;
            case "date":
                columnSort = objVisitorsDC.tbl_visitors.OrderByDescending(x => x.visit_date).Select(x => x);
                break;
            case "duration":
                columnSort = objVisitorsDC.tbl_visitors.OrderBy(x => x.duration).Select(x => x);
                break;
            case "status":
                columnSort = objVisitorsDC.tbl_visitors.OrderByDescending(x => x.status).Select(x => x);
                break;
        }

        return columnSort;
    }


    public bool insertVisitor(string _name, string _patientname, string _phonenumber, int _visitors, DateTime _visitdate, string _duration, string _email)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objVisitorsDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objVisitorsDC)
        {
            // create instance of our table object
            tbl_visitor objNewVisitor = new tbl_visitor();
            // set values
            objNewVisitor.name = _name;
            objNewVisitor.patient_name = _patientname;
            objNewVisitor.phone_number = _phonenumber;
            objNewVisitor.visitors = _visitors;
            objNewVisitor.visit_date = _visitdate;
            objNewVisitor.duration = _duration;
            objNewVisitor.status = "pending";
            objNewVisitor.email = _email;
            // insert command
            objVisitorsDC.tbl_visitors.InsertOnSubmit(objNewVisitor);
            // commit insert against database
            objVisitorsDC.SubmitChanges();
            return true;
        }
    }

    public bool deleteVisitor(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objVisitorsDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objVisitorsDC)
        {
            var objDelVisitor = objVisitorsDC.tbl_visitors.Single(x => x.visitor_id == _id);
            objVisitorsDC.tbl_visitors.DeleteOnSubmit(objDelVisitor);
            objVisitorsDC.SubmitChanges();
            return true;
        }
    }

    // set status to notified
    public bool notifyVisitor(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objVisitorsDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objVisitorsDC)
        {
            var objNotVisitor = objVisitorsDC.tbl_visitors.Single(x => x.visitor_id == _id);
            objNotVisitor.status = "notified";
            // commit update against database
            objVisitorsDC.SubmitChanges();
            return true;
        }
    }

    public bool pendingVisitor(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objVisitorsDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objVisitorsDC)
        {
            var objNotVisitor = objVisitorsDC.tbl_visitors.Single(x => x.visitor_id == _id);
            objNotVisitor.status = "pending";
            // commit update against database
            objVisitorsDC.SubmitChanges();
            return true;
        }
    }

}