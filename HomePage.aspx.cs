using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(false);
    }
    protected void btLogin_Click(object sender, EventArgs e)
    {
        LoginDAO loginDAO = new LoginDAO();
        LoginRole loginRole;

        loginRole = loginDAO.GetLoginRole(tbUserName.Text, tbPassword.Text);

        if (loginRole.Role == null)
        {
            lbMessage.Text = "Username/password do not match. Try again.";
        }

        if (loginRole.Role != null)
        {
            Session["username"] = tbUserName.Text;

            if (loginRole.Role == "administrator")
            {
                Session["administrator"] = tbUserName.Text;
            }

            lbMessage.Text = "";
            Page.Response.Redirect("HomePage.aspx");
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
            panelLogin.Visible = false;

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