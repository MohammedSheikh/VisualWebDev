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
}