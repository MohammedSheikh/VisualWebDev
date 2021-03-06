﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsCarCollection
/// </summary>
public class clsCarCollection
{
    clsDataConnection DBFilter = new clsDataConnection();

    public clsCarCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //insert data method, which accepts one param of object type clsCar
    //once record is added it returns primary key of new record
    public Int32 Add(clsCar NewCar)
    {
        clsDataConnection DB = new clsDataConnection();
        DB.AddParameter("@Manufacturer", NewCar.Manufacturer);
        DB.AddParameter("@Model", NewCar.Model);
        DB.AddParameter("@Colour", NewCar.Colour);
        DB.AddParameter("@NoOfDoors", NewCar.NoOfDoors);
        DB.AddParameter("@RegistrationDate", NewCar.RegistrationDate);
        DB.AddParameter("@FourWheelDrive", NewCar.FourWheelDrive);
        //execute sproc which contains primary key value of the new record 
        return DB.Execute("sproc_tblCar_Insert");
    }

    public void Update(clsCar NewCar1)
    {
        clsDataConnection DB1 = new clsDataConnection();

        //in this update method we also need to pass carId param so we know whcih address to update
        DB1.AddParameter("@CarID", NewCar1.CarID);
        DB1.AddParameter("@Manufacturer", NewCar1.Manufacturer);
        DB1.AddParameter("@Model", NewCar1.Model);
        DB1.AddParameter("@Colour", NewCar1.Colour);
        DB1.AddParameter("@NoOfDoors", NewCar1.NoOfDoors);
        DB1.AddParameter("@RegistrationDate", NewCar1.RegistrationDate);
        DB1.AddParameter("@FourWheelDrive", NewCar1.FourWheelDrive);

        DB1.Execute("sproc_tblCar_Update");
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

    //function to create list of record(s)
    public List<clsCar> CarList
    {
        get
        {
            //middle layer array list of single car page (clsCar)
            List<clsCar> list = new List<clsCar>();

            //declare a var for primary key value
            //Int32 CarID;
            //string Manufacturer;
            //string Model;
            //string Colour;
            //Int32 NoOfDoors;
            //DateTime RegistrationDate;
            //Boolean FourWheelDrive;
            //var to store record count
            Int32 RecordCount;
            //var to store index (index tells loop which record it is at)
            Int32 Index = 0;
            ////instance of db connection
            //clsDataConnection DB1 = new clsDataConnection();
            ////pass parameter data to data layer (in sproc_tblCar_FilterByColour)
            //DB1.AddParameter("@Colour", "");
            ////execute the sproc
            //DB1.Execute("sproc_tblCar_FilterByColour");
            //get the count of records
            RecordCount = DBFilter.Count;
            //while there are still records to process
            while (Index < RecordCount)
            {
                //blank car page 
                clsCar CarPage = new clsCar();
                //copy data form table to RAM variable
                CarPage.CarID = Convert.ToInt32(DBFilter.DataTable.Rows[Index]["CarID"]);
                CarPage.Manufacturer = Convert.ToString(DBFilter.DataTable.Rows[Index]["Manufacturer"]);
                CarPage.Model = Convert.ToString(DBFilter.DataTable.Rows[Index]["Model"]);
                CarPage.Colour = Convert.ToString(DBFilter.DataTable.Rows[Index]["Colour"]);
                CarPage.NoOfDoors = Convert.ToInt32(DBFilter.DataTable.Rows[Index]["NoOfDoors"]);
                CarPage.RegistrationDate = Convert.ToDateTime(DBFilter.DataTable.Rows[Index]["RegistrationDate"]);
                CarPage.FourWheelDrive = Convert.ToBoolean(DBFilter.DataTable.Rows[Index]["FourWheelDrive"]);
                //add the blank car page record to the array list
                list.Add(CarPage);
                //increase index each time the loop arrives here
                Index++;
            }
            return list;
        }
    }
    //public read only property to expose record count (read only thats y there is no setter)
    public Int32 Count
    {
        get
        {
            //clsDataConnection DB1 = new clsDataConnection();
            //DB1.AddParameter("@Colour","");
            //DB1.Execute("sproc_tblCar_FilterByColour");
            return DBFilter.Count;
        }
    }

    //filter method
    public void FilterByColour (string Colour)
    {
        //accepts single param (Colour) and returns no value
        DBFilter = new clsDataConnection();
        DBFilter.AddParameter("@Colour", Colour);
        DBFilter.Execute("sproc_tblCar_FilterByColour");
    }
}