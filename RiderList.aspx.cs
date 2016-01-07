using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RiderList : System.Web.UI.Page
{
    private BrevetDAO brevetDAO = new BrevetDAO();
    private RiderDAO riderDAO = new RiderDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(false);
        if (this.IsPostBack == false)
        {
            createBrevetList();
        }
    }

    //CREATE LIST
    private void createBrevetList()
    {
        List<Brevet> brevetList = brevetDAO.GetAllBrevets();
        ListBoxBrevets.Items.Clear();
        if (brevetList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        else
        {
            foreach (Brevet brevet in brevetList)
            {
                String text = brevet.Distance + "km, " + brevet.BrevetDate.ToString("yyyy-MM-dd") + ", " + brevet.Location;

                ListItem listItem = new ListItem(text, "" + brevet.BrevetId);
                ListBoxBrevets.Items.Add(listItem);
            }
        }
    }


    protected void ListBoxBrevets_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListBoxRiders.Items.Clear();
        int brevetId = Convert.ToInt32(ListBoxBrevets.SelectedValue);
        List<String> riderList = riderDAO.GetAllRidersByBrevetId(brevetId);

        if (riderList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        else
        {
            //Brevet_Raider brevet_rider = new Brevet_Raider();
            foreach (String rider in riderList)
            {
                String text = "" + rider;
                ListItem listItem = new ListItem(text + brevetId);
                ListBoxRiders.Items.Add(listItem);

            }
        }
    }




    /*
     * ***********
     * MESSAGES*
     * ***********
     * */

    private void showNoMessage()
    {
        lbMessage.Text = "";
        lbMessage.ForeColor = System.Drawing.Color.Black;
    }

    private void showErrorMessage(String message)
    {
        lbMessage.Text = message;
        lbMessage.ForeColor = System.Drawing.Color.Red;
    }

    private void checkLogin(bool loginRequired)
    {
        Response.Cache.SetNoStore();    // Should disable browser's Back Button

        // (1) Hide all hyperlinks that are available for autenthicated users only

        hyperLinkClubManagement.Visible = false;
        hyperLinkBrevetManagement.Visible = false;
        hyperLinkRiderManagement.Visible = false;
        hyperLinkBrevetRegistration.Visible = false;
        if (loginRequired == true && Session["username"] == null)
        {
            Page.Response.Redirect("HomePage.aspx");  // Jump to the login page.
        }

        if (Session["username"] == null)
        {
            lbLoginInfo.Text = "You are not logged in";
            btLogout.Visible = false;
        }

        if (Session["username"] != null)
        {

            lbLoginInfo.Text = "You are logged in as " + Session["username"];
            btLogout.Visible = true;

            // (2) Show all hyperlinks that are available for autenthicated users only

            hyperLinkBrevetRegistration.Visible = true;
        }

        if (Session["administrator"] != null)
        {
            // (3) In addition, show all hyperlinks that are available for administrators only
            hyperLinkClubManagement.Visible = true;
            hyperLinkBrevetManagement.Visible = true;
            hyperLinkRiderManagement.Visible = true;

        }
    }
    protected void btLogout_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["administrator"] = null;
        Page.Response.Redirect("HomePage.aspx");
    }
}