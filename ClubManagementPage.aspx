<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClubManagementPage.aspx.cs" Inherits="ClubManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html; charset=iso-8859-1" http-equiv="content-type" />
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Home Page - DWA Model Case</title>
    <style type="text/css">
        .listbox_main {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>Club Management</h1>
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
                    <asp:HyperLink ID="hyperLinkRiderList" runat="server" NavigateUrl="~/RiderLists.aspx">Rider List</asp:HyperLink>
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
                Clubs<br />
                <br />
                <asp:ListBox ID="ListBoxClubs" runat="server" Height="305px" Width="280px" AutoPostBack="True" CssClass="listbox_main" OnSelectedIndexChanged="ListBoxClubs_SelectedIndexChanged"></asp:ListBox>
                <br />
                <br />
                <asp:Image ID="imageTeam" runat="server" ImageUrl="~/images/team.png" />
                <br />
            </div>



            <div id="div_RIGHT">
                <div id="div_right_HEADER">
                    Club Details
                </div>

                    <div class="div_right_details_ROW">
                <asp:Label ID="lbClubId" runat="server" CssClass="detail_label" Text="Club ID: "></asp:Label>
                <asp:TextBox ID="tbClubId" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_ClubId" runat="server" ControlToValidate="tbClubId" CssClass="validatorMessage" ErrorMessage="Required!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
                 

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbClubName" runat="server" Text="Club Name:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbClubName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_ClubName" runat="server" ControlToValidate="tbClubName" CssClass="validatorMessage" ErrorMessage="Required!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>       
               
                     <div class="div_right_details_ROW">
                         <asp:Label ID="lbCity" runat="server" CssClass="detail_label" Text="City: "></asp:Label>
                         <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator_City" runat="server" ControlToValidate="tbCity" CssClass="validatorMessage" ErrorMessage="Required!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                         </div>
                     <div class="div_right_details_ROW">
                         <asp:Label ID="lbEmail" runat="server" CssClass="detail_label" Text="Email"></asp:Label>
                         <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server" ControlToValidate="tbEmail" CssClass="validatorMessage" ErrorMessage="Required!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                         </div>
                

                <div id="div_right_BUTTONS">
                    
                    <asp:Button ID="btNew" runat="server" Text="New" OnClick="btNew_Click" />
                    <asp:Button ID="btAdd" runat="server" Text="Add" OnClick="btAdd_Click" />
                    <asp:Button ID="btUpdate" runat="server" Text="Update" OnClick="btUpdate_Click" />
                    <asp:Button ID="btDelete" runat="server" OnClick="btDelete_Click" Text="Delete" />
                    
                </div>
                <div id="div_right_VALIDATORS">
                    <div>
                        <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label>
                    </div>

                   <asp:RangeValidator ID="RangeValidator_ClubId" runat="server"
                        ControlToValidate="tbClubId" ErrorMessage="Club ID should be between 101 and 9999"
                        Type="Integer" MinimumValue="101" MaximumValue="9999"
                        SetFocusOnError="True" CssClass="validatorMessage"></asp:RangeValidator>
                    <br />

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator_Email" runat="server"
                        ControlToValidate="tbEmail" ErrorMessage="Email is not correct"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        SetFocusOnError="True" CssClass="validatorMessage">
                    </asp:RegularExpressionValidator> 

                </div>
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

