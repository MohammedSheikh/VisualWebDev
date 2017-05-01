using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Delete : System.Web.UI.Page
{
    Int32 CarID;

    protected void Page_Load(object sender, EventArgs e)
    {
        CarID = Convert.ToInt32 ( Request.QueryString["CarID"]);
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        //Takes useer back to home page 'Default' page
        Response.Redirect("Default.aspx");
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        //instance of CarCollection class
        clsCarCollection CarCollection = new clsCarCollection();
        //Var to store outcome of process (did it work or not)
        Boolean Success;
        
        
        //copy outcome of delete methid (true/false) to this 'Success' var
        Success = CarCollection.Delete(CarID);
        // if value of Delete functio is true..
        if (Success == true)
        {
            //print happy message
            lblMessage.Text = "You deleted record number: " + CarID;
        }
        else
        {
            //print bad message if outcome was not true
            lblMessage.Text = "There was a problem deleting record";
        }
        
    }
}