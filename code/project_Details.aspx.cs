using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
public partial class project_Details : System.Web.UI.Page
{
    connection con = new connection();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["emailID"] != null)
        {
            if (!Page.IsPostBack)
            {
                BindChart();
                gvData.Visible = false;
                bindData();
                BindChart2();
                BindGvData2();
                GridView1.Visible = false;
            }
        }
        else
            Response.Redirect("login.aspx");

    }
    private void bindData()
    {

        if ((Request.QueryString["pid"] != null))
        {

            string i = (Request.QueryString["pid"]);

            string qquery = "select * from project where pid='" + i + "'";
            SqlCommand cmd = new SqlCommand(qquery, con.con_pass());
            con.open_connection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                Image1.ImageUrl = dr["pimage"].ToString();
                Label1.Text = dr["pid"].ToString();
                Label2.Text = dr["pname"].ToString();
                Label3.Text = dr["price"].ToString();
                Label4.Text = dr["pdesc"].ToString();
                Label5.Text = dr["pdate"].ToString();
                txtname.Text = dr["pname"].ToString(); ;
            }
            con.close_connection();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string st = "Pending";
        con.open_connection();
        string str = "insert into tbl_temp values('" + Label1.Text + "','" + Label2.Text + "','" + Label3.Text + "','" + Label4.Text + "','" + System.DateTime.Now.ToString() + "','" + Session["emailID"] + "','" + st + "')";
        SqlCommand cmd = new SqlCommand(str, con.con_pass());
        cmd.ExecuteNonQuery();
        con.close_connection();
        Response.Redirect("shoppingDetails.aspx");
    }
    private DataTable BindGvData()
    {
        string q = "SELECT 	hname, count(hrating) As Expr1 FROM rating_db group by hname";


        //Console.WriteLine(q);
        DataTable dt = new DataTable();
        SqlDataAdapter dp = new SqlDataAdapter(q, con.con_pass());
        dp.Fill(dt);
        if (dt.Rows.Count > 0)
        {

            gvData.DataSource = dt;
            gvData.DataBind();

        }
        return dt;
        // gvData.DataSource = GetChartData();
        //gvData.DataBind();
    }
    private void BindChart()
    {
        DataTable dsChartData = new DataTable();
        StringBuilder strScript = new StringBuilder();

        try
        {
            dsChartData = BindGvData();

            strScript.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']});</script>

                    <script type='text/javascript'>
                    function drawChart() {       
                    var data = google.visualization.arrayToDataTable([
                    ['Product Details', 'Total Product'],");

            foreach (DataRow row in dsChartData.Rows)
            {
                strScript.Append("['" + row["hname"] + "'," + row["Expr1"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@" var options = {   
                                    title: 'Overall Produt Rating',          
                                    is3D: true,        
                                    };   ");

            strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));        
                                chart.draw(data, options);      
                                }  
                            google.setOnLoadCallback(drawChart);
                            ");
            strScript.Append(" </script>");

            ltScripts.Text = strScript.ToString();
        }
        catch
        {
            //piechart_3d corechart
        }
        finally
        {
            dsChartData.Dispose();
            strScript.Clear();
        }
    }
    private DataTable BindGvData2()
    {
        //string name = "sadsd";
        string q = "SELECT  status, COUNT(*) AS Expr1 FROM feedback where hname='" + Label2.Text + "' GROUP BY status";


        //Console.WriteLine(q);
        DataTable dt = new DataTable();
        SqlDataAdapter dp = new SqlDataAdapter(q, con.con_pass());
        dp.Fill(dt);
        if (dt.Rows.Count > 0)
        {

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        return dt;
        // gvData.DataSource = GetChartData();
        //gvData.DataBind();
    }
    private void BindChart2()
    {
        DataTable dsChartData2 = new DataTable();
        StringBuilder strScript2 = new StringBuilder();

        try
        {
            dsChartData2 = BindGvData2();

            strScript2.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']});</script>

                    <script type='text/javascript'>
                    function drawChart() {       
                    var data = google.visualization.arrayToDataTable([
                    ['Yes', 'No'],");

            foreach (DataRow row in dsChartData2.Rows)
            {
                strScript2.Append("['" + row["status"] + "'," + row["Expr1"] + "],");
            }
            strScript2.Remove(strScript2.Length - 1, 1);
            strScript2.Append("]);");

            strScript2.Append(@" var options = {   
                                    title: 'Product Feedback',          
                                    is3D: true,        
                                    };   ");

            strScript2.Append(@"var chart = new google.visualization.PieChart(document.getElementById('Div1'));        
                                chart.draw(data, options);      
                                }  
                            google.setOnLoadCallback(drawChart);
                            ");
            strScript2.Append(" </script>");

            ltScripts2.Text = strScript2.ToString();
        }
        catch
        {
            //piechart_3d corechart
        }
        finally
        {
            dsChartData2.Dispose();
            strScript2.Clear();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string msg = null;
        try
        {
            int count1 = 0, count2 = 0, count3 = 0, count4 = 0, fcount = 0;
            if (txtdes.Text.Contains("good"))
            {
                count1 = 2;
            }
            if (txtdes.Text.Contains("bad"))
            {
                count2 = 1;
            }
            if (txtdes.Text.Contains("but"))
            {
                count3 = -1;
            }
            if (txtdes.Text.Contains("bad but"))
            {
                count4 = 0;
            }
            fcount = count1 + count2 + count3 + count4;
            if (fcount >= 2)
            {
                msg = "Positive";
            }
            else if (fcount == 1)
            {
                msg = "Average";
            }
            else
            {
                msg = "Negative";
            }
            con.open_connection();
            string s1 = "insert into feedback(hname,hdes,rdate,fuser,status) values('" + Label2.Text + "','" + txtdes.Text + "','" + System.DateTime.Now.ToString() + "','" + Session["emailID"] + "','" + msg + "')";
            SqlCommand cmd = new SqlCommand(s1, con.con_pass());
            cmd.ExecuteNonQuery();
            con.close_connection();
            Response.Write("<script>alert('Feedback Submitted Successfully') </script>");
            //Response.Redirect("project_Details.aspx?pid=" + Request.QueryString["pid"]);
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void Rating1_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
        Label1.Text = e.Value.ToString();

        con.open_connection();
        string s1 = "insert into rating_db(hname,hrating,email) values('" + Label2.Text + "','" + Label1.Text + "','" + Session["emailID"].ToString() + "')";
        SqlCommand cm = new SqlCommand(s1, con.con_pass());
        cm.ExecuteNonQuery();

        con.close_connection();
        Response.Write("<script>alert('Hotel Rating Give Successfully') </script>");
        Response.Redirect("project_Details.aspx?pid=" + Request.QueryString["pid"]);
    }

}