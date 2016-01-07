using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RiderManagement : System.Web.UI.Page
{
    private RiderDAO riderDAO = new RiderDAO();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(true);
        if (this.IsPostBack == false)
        {
            viewStateNew();
            createRidersList();
            
        }
    }
    private void createRidersList()
    {
        List<Rider> riderList = riderDAO.GetAllRiders();
        ListBoxRiders.Items.Clear();
        if (riderList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        else
        {
            foreach (Rider rider in riderList)
            {
                String text = rider.GivenName + " " + rider.FamilyName;

                ListItem listItem = new ListItem(text, "" + rider.RiderId);
                ListBoxRiders.Items.Add(listItem);
            }
        }
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
    protected void btNew_Click(object sender, EventArgs e)
    {
        viewStateNew();
    }
    protected void btAdd_Click(object sender, EventArgs e)
    {
        Rider rider = screenToModel();
        int insertOk = riderDAO.InsertRider(rider);

        if (insertOk == 0)// Secceeded
        {
            createRidersList();
            ListBoxRiders.SelectedValue = rider.RiderId.ToString();
            viewStateDetailsDisplayed();
            showNoMessage();
        }
        else if (insertOk == 1)
        {
            showErrorMessage("Club id " + rider.RiderId +
             " is already in use. No record inserted into the database.");
            tbRiderId.Focus();
        }
        else
        {
            showErrorMessage("No record inserted into the database. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }
    protected void btUpdate_Click(object sender, EventArgs e)
    {
        Rider rider = screenToModel();
        int updateOK = riderDAO.UpdateRider(rider);

        if (updateOK == 0) // OK
        {
            String selectedValue = ListBoxRiders.SelectedValue;

            createRidersList();
            ListBoxRiders.SelectedValue = selectedValue;
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
        int riderId = Convert.ToInt32(ListBoxRiders.SelectedValue);
        int deleteOk = riderDAO.DeleteRider(riderId);

        if (deleteOk == 0) // Delete succeeded
        {
            createRidersList();
            viewStateNew();
            showNoMessage();
        }
        else if (deleteOk == 1)
        {
            showErrorMessage("No record deleted. " +
              "Please delete the ridersresults first.");
        }
        else
        {
            showErrorMessage("No record deleted. " +
             "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }
    protected void ListBoxClubs_SelectedIndexChanged(object sender, EventArgs e)
    {
        int riderid = Convert.ToInt32(ListBoxRiders.SelectedValue);
        Rider rider = riderDAO.GetRiderByID(riderid);
        

        if (rider != null)
        {
            modelToScreen(rider);
            viewStateDetailsDisplayed();
            showNoMessage();
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

    private void resetForm()
    {
        tbRiderId.Text = "";
        tbGivenName.Text = "";
        tbSurname.Text = "";
        tbUserName.Text = "";
        tbEmail.Text = "";
        tbPass.Text = "";
        tbPhone.Text = "";
        tbRePass.Text = "";
        RadioButtonListGender.SelectedValue = "F";
        RadioButtonListRole.SelectedValue = "user";
    }
    /* ************
    * STATE MANAGEMENT
    ***************/
    private void viewStateNew()
    {
        
        tbRiderId.Enabled = true;
        tbRiderId.Focus();

        btAdd.Enabled = true;
        btDelete.Enabled = false;
        btNew.Enabled = true;
        btUpdate.Enabled = false;

        resetForm();
        ListBoxRiders.SelectedIndex = -1;
        showNoMessage();
    }

    private void viewStateDetailsDisplayed()
    {
        tbRiderId.Enabled = false;

        btAdd.Enabled = false;
        btDelete.Enabled = true;
        btNew.Enabled = true;
        btUpdate.Enabled = true;
    }

    /*
     * ***************
     * RIDER DETAILS*
     * ***************
     * */

    private void modelToScreen(Rider rider)
    {
        tbRiderId.Text = "" + rider.RiderId;
        tbSurname.Text = "" + rider.FamilyName;
        tbGivenName.Text = "" + rider.GivenName;
        tbPhone.Text = "" + rider.Phone;
        tbEmail.Text = "" + rider.Email;
        tbUserName.Text = "" + rider.Username;
        RadioButtonListGender.SelectedValue = "" + rider.Gender;
        RadioButtonListRole.SelectedValue = "" + rider.Role;
        DropDownListClubName.SelectedValue = "" + rider.ClubId;
        
    }

    private Rider screenToModel()
    {
        Rider rider = new Rider();

        rider.RiderId = Convert.ToInt32(tbRiderId.Text.Trim());
        rider.FamilyName = tbSurname.Text.Trim();
        rider.GivenName = tbGivenName.Text.Trim();
        rider.Phone = tbPhone.Text.Trim();
        rider.Email = tbEmail.Text.Trim();
        rider.Password = tbPass.Text.Trim();
        rider.Username = tbUserName.Text.Trim();
        rider.Gender = RadioButtonListGender.SelectedValue.ToString();
        rider.ClubId = Convert.ToInt32(DropDownListClubName.SelectedValue.ToString());
        rider.Role = RadioButtonListRole.SelectedValue.ToString();
               
        return rider;
    }
}