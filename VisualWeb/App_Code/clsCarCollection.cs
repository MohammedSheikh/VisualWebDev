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

    public void CarList()
    {
        //declare a var for primary key value
        Int32 CarID;
        string Manufacturer;
        string Model;
        string Colour;
        Int32 NoOfDoors;
        DateTime RegistrationDate;
        Boolean FourWheelDrive;
        //instance of db connection
        clsDataConnection DB1 = new clsDataConnection();
        //pass parameter data to data layer (in sproc_tblCar_FilterByColour)
        DB1.AddParameter("@Colour","");
        //execute the sproc
        DB1.Execute("sproc_tblCar_FilterByColour");
        //copy data form table to RAM variable
        CarID = Convert.ToInt32(DB1.DataTable.Rows[0]["CarID"]);
        Manufacturer = Convert.ToString(DB1.DataTable.Rows[0]["Manufacturer"]);
        Model = Convert.ToString(DB1.DataTable.Rows[0]["Model"]);
        Colour = Convert.ToString(DB1.DataTable.Rows[0]["Colour"]);
        NoOfDoors = Convert.ToInt32(DB1.DataTable.Rows[0]["NoOfDoors"]);
        RegistrationDate = Convert.ToDateTime(DB1.DataTable.Rows[0]["RegistrationDate"]);
        FourWheelDrive = Convert.ToBoolean(DB1.DataTable.Rows[0]["FourWheelDrive"]);
    }
}