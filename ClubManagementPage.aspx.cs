using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClubManagement : System.Web.UI.Page
{
    private ClubDAO clubDAO = new ClubDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(true);
        if (this.IsPostBack == false)
        {
            viewStateNew();
            createClubsList();
        }
    }

    private void addButtonScripts()
    {
        btDelete.Attributes.Add("onclick",
          "return confirm('Are you sure you want to delete the data?');");
    }

    private void createClubsList()
    {
        List<Club> clubList = clubDAO.GetAllClubs();
        ListBoxClubs.Items.Clear();
        if (clubList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        else
        {
            foreach (Club club in clubList)
            {
                String text = club.ClubName + ", " + club.ClubCity;

                ListItem listItem = new ListItem (text,""+ club.ClubId);
                ListBoxClubs.Items.Add(listItem);
            }
        }
    }



    protected void btNew_Click(object sender, EventArgs e)
    {
        viewStateNew();
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        Club club = screenToModel();
        int insertOk = clubDAO.InsertClub(club);

        if (insertOk ==0)// Secceeded
        {
            createClubsList();
            ListBoxClubs.SelectedValue = club.ClubId.ToString();
            viewStateDetailsDisplayed();
            showNoMessage();
        }
        else if (insertOk == 1)
        {
            showErrorMessage ("Club id " + club.ClubId +
             " is already in use. No record inserted into the database.");
            tbClubId.Focus();
        }
        else
        {
            showErrorMessage("No record inserted into the database. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    protected void btUpdate_Click(object sender, EventArgs e)
    {
        Club club = screenToModel();
        int updateOK = clubDAO.UpdateClub(club);

        if (updateOK == 0) // OK
        {
            String selectedValue = ListBoxClubs.SelectedValue;

            createClubsList();
            ListBoxClubs.SelectedValue = selectedValue;
            showNoMessage();
        }
        else
        {
            showErrorMessage("No record updated. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    protected void btDelete_Click(object sender, EventArgs e)
    {
        int clubId = Convert.ToInt32(ListBoxClubs.SelectedValue);
        int deleteOk = clubDAO.DeleteClub(clubId);

        if (deleteOk == 0) // Delete succeeded
        {
            createClubsList();
            viewStateNew();
            showNoMessage();
        }
        else if (deleteOk == 1)
        {
            showErrorMessage("No record deleted. " +
              "Please delete the club's riders first.");
        }
        else
        {
            showErrorMessage("No record deleted. " +
             "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    private void resetForm()
    {
        tbClubId.Text = "";
        tbClubName.Text = "";
        tbCity.Text = "";
        tbEmail.Text = "";
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

    /* ************
    * STATE MANAGEMENT
    ***************/
    private void viewStateNew()
    {
        tbClubId.Enabled = true;
        tbClubId.Focus();

        btAdd.Enabled = true;
        btDelete.Enabled = false;
        btNew.Enabled = true;
        btUpdate.Enabled = false;

        resetForm();
        ListBoxClubs.SelectedIndex = -1;
        showNoMessage();
    }

    private void viewStateDetailsDisplayed()
    {
        tbClubId.Enabled = false;

        btAdd.Enabled = false;
        btDelete.Enabled = true;
        btNew.Enabled = true;
        btUpdate.Enabled = true;
    }

    /*
     * ***************
     * CLUB DETAILS*
     * ***************
     * */

    private void modelToScreen(Club club)
    {
        tbClubId.Text = "" + club.ClubId;
        tbClubName.Text = "" + club.ClubName;
        tbCity.Text = "" + club.ClubCity;
        tbEmail.Text = "" + club.ClubEmail;
    }

    private Club screenToModel()
    {
        Club club = new Club();

        club.ClubId = Convert.ToInt32(tbClubId.Text.Trim());
        club.ClubName = tbClubName.Text.Trim();
        club.ClubCity = tbCity.Text.Trim();
        club.ClubEmail = tbEmail.Text.Trim();
        return club;
    }
    protected void ListBoxClubs_SelectedIndexChanged(object sender, EventArgs e)
    {
        int clubid = Convert.ToInt32(ListBoxClubs.SelectedValue);
        Club club = clubDAO.GetClubByID(clubid);

        if (club != null)
        {
            modelToScreen(club);
            viewStateDetailsDisplayed();
            showNoMessage();
        }
    }

    /*
     * 
     * LOGIN
     * 
     * */
    private void checkLogin(bool loginRequired)
    {
        Response.Cache.SetNoStore();    // Should disable browser's Back Button

        // (1) Hide all hyperlinks that are available for autenthicated users only
        
        hyperLinkClubManagement.Visible=false;
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