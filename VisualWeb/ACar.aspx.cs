using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ACar : System.Web.UI.Page
{
    //var with global scope
    Int32 CarID;

    protected void Page_Load(object sender, EventArgs e)
    {
        
         CarID = Convert.ToInt32( Request.QueryString["CarID"]);

        //txtCarID.Text = Convert.ToString(Request.QueryString["CarID"]);

        if (CarID != -1)
        {
            if (IsPostBack != true)
            {
                DisplayCars(CarID);
            }
            
        }


        ////read the data from the query string 
        //Int32 CarID = Convert.ToInt32( Request.QueryString["CarID"]);


        ////if we are not adding a new record...
        //if (CarID != -1)
        //{
        //    if (IsPostBack != true)
        //    {
        //        //display existing data for that pk value
        //        DisplayCars(CarID);
        //    }          
        //}
        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //Go back to homepage
        Response.Redirect("Default.aspx");
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        clsCar  Car1 = new clsCar();
        string ErrorMsg;
        //we are calling the 'Valid' method here
        ErrorMsg =  Car1.CarValid(
                                  txtManufacturer.Text,
                                  txtModel.Text,
                                  txtColor.Text,
                                  txtRegistrationDate.Text);

        if (ErrorMsg == "")
        {
            //instance of CarCollection
            clsCarCollection CarCollection = new clsCarCollection();
            //do something with the new record - either insert or update depending on pk value

            //if carID is '-1' , meaning a new value, then call the insert method
            if (CarID == -1)
            {
                //copy data from the text boxes to the vars
                Car1.Manufacturer = txtManufacturer.Text;
                Car1.Model = txtModel.Text;
                Car1.Colour = txtColor.Text;
                Car1.RegistrationDate = Convert.ToDateTime(txtRegistrationDate.Text);

                //add the new record after all data has been copied
                CarCollection.Add(Car1);
            }
            //else (if pk value is not -1, it means its existing, therefore we update)
            else
            {
                //copy data from txt boxes to vars
                Car1.CarID = Convert.ToInt32(CarID);
                Car1.Manufacturer = txtManufacturer.Text;
                Car1.Model = txtModel.Text;
                Car1.Colour = txtColor.Text;
                Car1.RegistrationDate = Convert.ToDateTime(txtRegistrationDate.Text);

                //update the record
                CarCollection.Update(Car1);
            }


            //do somethin-insert or update
            Response.Redirect("Default.aspx");
        }
        else
        {
            lblError.Text = ErrorMsg;
        }
    }

    //func to display car record on form
    void DisplayCars(Int32 CarID)
    {
        clsCar Car = new clsCar();
        //find car we want to display
        Car.Find(CarID);
        //copy over the data to the text boxes
        txtManufacturer.Text = Car.Manufacturer;
        txtModel.Text = Car.Model;
        txtColor.Text = Car.Colour;
        ddlNoOfDoors.SelectedValue = Convert.ToString(Car.NoOfDoors);
        txtRegistrationDate.Text = Car.RegistrationDate.ToString("dd/MM/yyyy");
        chkFourWheels.Checked = Car.FourWheelDrive;
    }
}