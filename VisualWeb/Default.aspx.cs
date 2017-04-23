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
        clsCarCollection Car = new clsCarCollection();
        Car.CarList();
    }
}