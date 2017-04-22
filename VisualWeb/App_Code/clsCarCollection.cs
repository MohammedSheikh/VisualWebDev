using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsCarCollection
/// </summary>
public class clsCarCollection
{
    public clsCarCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Boolean Delete(Int32 CarID)
    {
        //try to delete record
        try
        {
             //instance of db connection
            clsDataConnection DBConnection = new clsDataConnection();
            //use the add param method to use for deleting data in db
            DBConnection.AddParameter("@CarID",CarID);
            //execute the sproc
            DBConnection.Execute("sproc_tblCar_Delete");
            //return true value for func if success
            return true;
        }
        catch
        {
            //if problem happened return error msg
            return false;
        }

      
    }
}