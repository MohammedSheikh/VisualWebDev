using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if this is the first time the form has been displayed...
        if (IsPostBack == false)
        {
            //display the car list 
            DisplayCars("");
        }
        
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Int32 CarID;

        //if user has clicked an item..
        if (lstCars.SelectedIndex != -1)
        {
            //var to store pk value (selectedValue) of selected item in list
            CarID = Convert.ToInt32(lstCars.SelectedValue);
            //go to 'Add' page + add the query string
            Response.Redirect("Delete.aspx?CarID=" + CarID);
        }
        else
        {
            //else display error
            lblError.Text = "Please enter an item from list to edit it";
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //go to 'Add' page
        Response.Redirect("ACar.aspx?CarID=-1");
    }

    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        DisplayCars("");
    }

    Int32 DisplayCars(string ColourFilter)
    {  
        Int32 CarID;
        string Manufacturer;
        string Colour;
        clsCarCollection Car1 = new clsCarCollection();
        Car1.FilterByColour(ColourFilter);
        Int32 Index = 0;
        Int32 RecordCount = Car1.Count;
        lstCars.Items.Clear();
        while (Index < RecordCount)
        {
            CarID = Car1.CarList[Index].CarID;
            Manufacturer = Car1.CarList[Index].Manufacturer;
            Colour = Car1.CarList[Index].Colour;
            //create new entry for list box - accepts two params
            //the first part is what is displayed in list (manufacturer + color), the second part is the pk (how the system recognizes)
            //the red empty string is basically to make space between the two items
            ListItem NewEntry = new ListItem(Manufacturer + "   " + Colour , CarID.ToString());
            //add the item
            lstCars.Items.Add(NewEntry);
            Index++;
        }
        return RecordCount;
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Int32 CarID;

        //if user has clicked an item..
        if (lstCars.SelectedIndex != -1)
        {
            //var to store pk value (selectedValue) of selected item in list
            CarID = Convert.ToInt32(lstCars.SelectedValue);
            //go to 'Add' page + add the query string
            Response.Redirect("ACar.aspx?CarID=" + CarID);
        }                      
        else
        {
            //else display error
            lblError.Text = "Please enter an item from list to edit it";
        }
       
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        DisplayCars(txtColor.Text);
    }
}