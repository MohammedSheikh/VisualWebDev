using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsCar
/// </summary>
public class clsCar
{
    public clsCar()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //private variables that connect to their related public properties
    private Int32 carID;

    private string manufacturer;

    private string model;
    
    private string colour;

    private Int32 noOfDoors;

    private DateTime registrationDate;

    private Boolean fourWheelDrive;

    //public property that connects to its related private variable
    public Int32 CarID
    {
        //getter to get data from this propertry (read)
        get
        {
            return carID;
        }
        //setter to insert data (write)
        set
        {
            carID = value;
        }
    }

    public string Manufacturer
    {
        get
        {
            return manufacturer;
        }
        set
        {
            manufacturer = value;
        }
    }

    public string Model
    {
        get
        {
            return model;
        }
        set
        {
            model = value;
        }
    }

    public string Colour
    {
        get
        {
            return colour;
        }
        set
        {
            colour = value;
        }
    }

    public Int32 NoOfDoors
    {
        get
        {
            return noOfDoors;
        }
        set
        {
            noOfDoors = value;
        }
    }

    public DateTime RegistrationDate
    {
        get
        {
            return registrationDate;
        }
        set
        {
            registrationDate = value;
        }
    }

    public Boolean FourWheelDrive
    {
        get
        {
            return fourWheelDrive;
        }
        set
        {
            fourWheelDrive = value;
        }
    }

    public string CarValid(
                           string Manufacturer,
                           string Model,
                           string Colour,
                           string RegistrationDate)
    {
        string message;
        message = "";

        if (Manufacturer.Length < 1 | Manufacturer.Length > 50)
        {
            message = message + " , manufacturer must be between 1 and 50 chars";
        }
        if(Model.Length < 1 | Model.Length > 50)
        {
            message = message + " , model must be between 1 and 50 chars";
        }
        if (Colour.Length < 1 | Colour.Length > 50)
        {
            message = message + " , colour must be between 1 and 20 chars";
        }

        try
        {
            //assign date to temproary var
            DateTime temp = Convert.ToDateTime(RegistrationDate);
        }
        catch
        {
            message = "dates not valid";
        }

        if(message == "")
        {
            //return blank string if no erroes
            return "";
        }
        else
        {
            return " there were erros: " + message ;
        }  
    }


    //this find func is used to find record from db based on pk value entered and retrieve details of record
    public Boolean Find(Int32 CarID)
    {

        clsDataConnection DB = new clsDataConnection();
        DB.AddParameter("@CarID", CarID);
        DB.Execute("sproc_tblCar_FindByCarID");

        //if the record was found...
        if (DB.Count == 1)
        {
            carID = Convert.ToInt32(DB.DataTable.Rows[0]["CarID"]);
            manufacturer = Convert.ToString(DB.DataTable.Rows[0]["Manufacturer"]);
            model = Convert.ToString(DB.DataTable.Rows[0]["Model"]);
            colour = Convert.ToString(DB.DataTable.Rows[0]["Colour"]);
            noOfDoors = Convert.ToInt32(DB.DataTable.Rows[0]["NoOfDoors"]);
            registrationDate = Convert.ToDateTime(DB.DataTable.Rows[0]["RegistrationDate"]);

            try
            {
                fourWheelDrive = Convert.ToBoolean(DB.DataTable.Rows[0]["FourWheelDrive"]);
            }
            catch
            {
                fourWheelDrive = true;
            }

            return true;
        }
        else
        {
            return false;
        }   
    }
}