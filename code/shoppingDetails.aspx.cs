using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shoppingDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_product.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.open('https://www.billdesk.com/pgidsk/pgijsp/sbicard/SBI_card.jsp','_blank');</script>");
       // Response.Redirect(https://p-y.tm/q-qiOWO);
    }
}