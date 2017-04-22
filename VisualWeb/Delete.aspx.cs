using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        //Takes useer back to home page 'Default' page
        Response.Redirect("Default.aspx");
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        Int32 CarNo = Convert.ToInt32(txtDelete.Text);
        lblMessage.Text = "You deleted Car Number: " + CarNo;
    }
}