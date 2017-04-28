using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ACar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
        ErrorMsg =  Car1.CarValid(txtCarID.Text,
                                  txtManufacturer.Text,
                                  txtModel.Text,
                                  txtColor.Text,
                                  txtRegistrationDate.Text);

        if (ErrorMsg == "")
        {
            //do somethin-insert or update
            Response.Redirect("Default.aspx");
        }
        else
        {
            lblError.Text = ErrorMsg;
        }
    }
}