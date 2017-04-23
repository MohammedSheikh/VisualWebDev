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
        //var to store record count
        Int32 RecordCount;
        //var to store index (index tells loop which record it is at)
        Int32 Index = 0;
        //instance of db connection
        clsDataConnection DB1 = new clsDataConnection();
        //pass parameter data to data layer (in sproc_tblCar_FilterByColour)
        DB1.AddParameter("@Colour","");
        //execute the sproc
        DB1.Execute("sproc_tblCar_FilterByColour");
        //get the count of records
        RecordCount = DB1.Count;
        //while there are still records to process
        while (Index < RecordCount)
        {
            //copy data form table to RAM variable
            CarID = Convert.ToInt32(DB1.DataTable.Rows[Index]["CarID"]);
            Manufacturer = Convert.ToString(DB1.DataTable.Rows[Index]["Manufacturer"]);
            Model = Convert.ToString(DB1.DataTable.Rows[Index]["Model"]);
            Colour = Convert.ToString(DB1.DataTable.Rows[Index]["Colour"]);
            NoOfDoors = Convert.ToInt32(DB1.DataTable.Rows[Index]["NoOfDoors"]);
            RegistrationDate = Convert.ToDateTime(DB1.DataTable.Rows[Index]["RegistrationDate"]);
            FourWheelDrive = Convert.ToBoolean(DB1.DataTable.Rows[Index]["FourWheelDrive"]);
            //increase index each time the loop arrives here
            Index++;
        }
    }
}