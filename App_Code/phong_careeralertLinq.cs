/*
 * Phong Huynh - 810194340, hnhp0025
 * Timmins Hospital Website
 * Career Alert Feature
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for phong_careeralertLinq
/// </summary>
public class phong_careeralertLinq
{
    // TimminsDBDataContext - data context

    public List<careeralertResult> getAlerts()
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objAlertDC = new TimminsDBDataContext();
        using (objAlertDC)
        {
            // use stored procedure
            var allAlerts = objAlertDC.careeralert().ToList();
            return allAlerts;
        }
    }

    public List<careeralertByIDResult> getAlertByID(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objAlertDC = new TimminsDBDataContext();
        using (objAlertDC)
        {
            // used stored procedure
            var allAlerts = objAlertDC.careeralertByID(_id).ToList();
            return allAlerts;
        }
    }


    // Sort columns using table, can't ORDER BY parameter values
    public IQueryable<tbl_careeralert> sortColumn(string _column)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objAlertDC = new TimminsDBDataContext();
        // default to no sorting
        var columnSort = objAlertDC.tbl_careeralerts.Select(x => x);

        // check which sorting the user clicked
        switch (_column)
        {
            case "id":
                columnSort = objAlertDC.tbl_careeralerts.OrderBy(x => x.careeralert_id).Select(x => x);
                break;
            case "name":
                columnSort = objAlertDC.tbl_careeralerts.OrderBy(x => x.name).Select(x => x);
                break;
            case "department":
                columnSort = objAlertDC.tbl_careeralerts.OrderBy(x => x.department).Select(x => x);
                break;
            case "email":
                columnSort = objAlertDC.tbl_careeralerts.OrderBy(x => x.email).Select(x => x);
                break;
            case "resume":
                columnSort = objAlertDC.tbl_careeralerts.OrderBy(x => x.resume).Select(x => x);
                break;
            case "status":
                columnSort = objAlertDC.tbl_careeralerts.OrderByDescending(x => x.status).Select(x => x);
                break;
        }

        return columnSort;
    }

    // insert using stored procedure
    public bool insertAlert(string _name, string _department, string _email, string _resume)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objAlertDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objAlertDC)
        {
            var objUpAlert = objAlertDC.careeralertInsert(_name, _department, _email, _resume, "pending");
            // commit insert
            objAlertDC.SubmitChanges();
            return true;
        }
    }

    public bool deleteUser(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objAlertDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objAlertDC)
        {
            var objDelAlert = objAlertDC.careeralertDelete(_id);
            // commit delete
            objAlertDC.SubmitChanges();
            return true;
        }
    }

    // set status to notified
    public bool notifyUser(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objAlertDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objAlertDC)
        {
            var objDelAlert = objAlertDC.careeralertChangeStatus(_id, "notified");
            objAlertDC.SubmitChanges();
            return true;
        }
    }

    // set status to pending
    public bool pendingUser(int _id)
    {
        // create an instance of our LINQ object
        TimminsDBDataContext objAlertDC = new TimminsDBDataContext();
        // to ensure that all data will be disposed when finished
        using (objAlertDC)
        {
            var objDelAlert = objAlertDC.careeralertChangeStatus(_id, "pending");
            objAlertDC.SubmitChanges();
            return true;
        }
    }

}