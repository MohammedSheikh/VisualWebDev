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

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //clikcing takes user to 'Delete' page
        Response.Redirect("Delete.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //go to 'Add' page
        Response.Redirect("ACar.aspx");
    }

    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        DisplayCars();
    }

    Int32 DisplayCars()
    {  
        Int32 CarID;
        string Manufacturer;
        string Colour;
        clsCarCollection Car1 = new clsCarCollection();
        Int32 Index = 0;
        Int32 RecordCount = Car1.Count;
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
}