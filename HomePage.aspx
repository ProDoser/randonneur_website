<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html; charset=iso-8859-1" http-equiv="content-type" />
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Home Page - DWA Model Case</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>HH Ranonneurs</h1>
                </div>

                <div id="div_header_LOGIN_STATUS">
                    <asp:Label ID="lbLoginInfo" runat="server"></asp:Label>
                    .<br />
                    <asp:LinkButton ID="btLogout" runat="server" CssClass="logout_link" OnClick="btLogout_Click">LOGOUT</asp:LinkButton>
                    <br />
                </div>
            </div>



            <div id="div_LEFT">
                <div id="div_NAV">
                    <asp:HyperLink ID="hyperLinkHomePage" runat="server" CssClass="current_page_link" NavigateUrl="~/HomePage.aspx">Home</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="hyperLinkRiderList" runat="server" NavigateUrl="~/RiderList.aspx">Rider List</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="hyperLinkBrevetResults" runat="server" NavigateUrl="~/BrevetResults.aspx">Brevet Results</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="hyperLinkBrevetRegistration" runat="server" NavigateUrl="~/BrevetRegistration.aspx">Brevet Registration</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="hyperLinkBrevetManagement" runat="server" NavigateUrl="~/BrevetManagement.aspx">Brevet Management</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="hyperLinkRiderManagement" runat="server" NavigateUrl="~/RiderManagement.aspx">Rider Management</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="hyperLinkClubManagement" runat="server" NavigateUrl="~/ClubManagementPage.aspx">Club Management</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="hyperLinkUpdateResults" runat="server" NavigateUrl="~/HomePage.aspx">Update Results</asp:HyperLink>
                    <br />
                </div>
            </div>



            <div id="div_CENTER">
                Welcome to HH Randonneurs page!<br />
&nbsp;<br />
                <img src="images/brevet_rider.png" alt="Team image" /><br />
                <br />
               HH Randonneurs organize annual Super Randonneur series of 200, 
                300, 400 and 600km brevets. In addition, we orginize 1000 and 
                1200km brevets when possible.
                <br />
                <br />
                Whichever brevet you choose, we'll make it an unforgettable ride!
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>



            <div id="div_RIGHT">
                You can view the home page and contact info page without logging in.<br />
                <br />
                Login is required for all other pages.&nbsp;You can login with the following<br />
                username/password:&nbsp; user/user or admin/admin<br />
                <br />
                <asp:Panel ID="panelLogin" runat="server" CssClass="loginPanel" GroupingText="Login" Height="119px" Width="141px">
                    <asp:Label ID="lbUsername" runat="server" Text="Username:"></asp:Label>
                    <br />
                    <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lbPassword" runat="server" Text="Password:"></asp:Label>
                    <br />
                    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="btLogin" runat="server" Text="Login" Width="129px" OnClick="btLogin_Click" />
                    <br />
                </asp:Panel>
                <asp:Label ID="lbMessage" runat="server" CssClass="validatorMessage"></asp:Label>
                <br />

                <br />
            </div>



            <div id="div_FOOTER">
                <div id="div_footer_W3C_ICONS">
                    <a href="http://validator.w3.org/check?uri=referer">
                        <img class="w3c_icon" src="images/valid-xhtml10.png" alt="Valid XHTML 1.0 Transitional" /></a>
                    <a href="http://jigsaw.w3.org/css-validator/">
                        <img class="w3c_icon" src="images/vcss.png" alt="Valid CSS!" /></a>
                </div>

                <div id="div_footer_AUTHOR">
                    Leonid Zadorozhnykh 2015 v1.0
                </div>
            </div>


        </div>
        <!-- End of div_CONTAINER -->
    </form>
</body>
</html>

