<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RiderManagement.aspx.cs" Inherits="RiderManagement" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html; charset=iso-8859-1" http-equiv="content-type" />
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Home Page - DWA Model Case</title>
    <style type="text/css">
        .listbox_main {}
        .div_right_buttons_button {
            margin-left: 143px;
        }
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
                <asp:ListBox ID="ListBoxRiders" runat="server" Height="305px" Width="280px" AutoPostBack="True" CssClass="listbox_main" OnSelectedIndexChanged="ListBoxClubs_SelectedIndexChanged"></asp:ListBox>
                <br />
                <br />
                <asp:Image ID="imageTeam" runat="server" ImageUrl="~/images/rider.png" />
                <br />
            </div>



            <div id="div_RIGHT">
                <div id="div_right_HEADER">
                    Club Details
                </div>

                    <div class="div_right_details_ROW">
                <asp:Label ID="lbRiderId" runat="server" CssClass="detail_label" Text="Rider ID: "></asp:Label>
                <asp:TextBox ID="tbRiderId" runat="server" CssClass="detail_textbox" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_RiderId" runat="server" ControlToValidate="tbRiderId" CssClass="validatorMessage" ErrorMessage="Required!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
                 

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbSurname" runat="server" Text="Surname:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbSurname" runat="server" CssClass="detail_textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Surname" runat="server" ControlToValidate="tbSurname" CssClass="validatorMessage" ErrorMessage="Required!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>       
               
                     <div class="div_right_details_ROW">
                         <asp:Label ID="lbGivenName" runat="server" CssClass="detail_label" Text="Given Name: "></asp:Label>
                         <asp:TextBox ID="tbGivenName" runat="server" CssClass="detail_textbox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator_GivenName" runat="server" ControlToValidate="tbGivenName" CssClass="validatorMessage" ErrorMessage="Required!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                         </div>
                    <div class="div_right_details_ROW">
                         <asp:Label ID="lbGender" runat="server" CssClass="detail_label" Text="Gender"></asp:Label>
                         <asp:RadioButtonList ID="RadioButtonListGender" runat="server" RepeatDirection="Horizontal" CssClass="detail_textbox">
                             <asp:ListItem Value="F" Selected="True">Female</asp:ListItem>
                             <asp:ListItem Value="M">Male</asp:ListItem>
                         </asp:RadioButtonList>
</div>                         
                <div class="div_right_details_ROW">
                         
                         <asp:Label ID="lbPhone" runat="server" CssClass="detail_label" Text="Phone"></asp:Label>
                         
                         <asp:TextBox ID="tbPhone" runat="server" CssClass="detail_textbox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbPhone" CssClass="validatorMessage" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                         
                         </div>
                     <div class="div_right_details_ROW">
                         <asp:Label ID="lbEmail" runat="server" CssClass="detail_label" Text="Email"></asp:Label>
                         <asp:TextBox ID="tbEmail" runat="server" CssClass="detail_textbox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server" ControlToValidate="tbEmail" CssClass="validatorMessage" ErrorMessage="Required!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                         </div>
                <div class="div_right_details_ROW">
                         
                         <asp:Label ID="lbClubName" runat="server" CssClass="detail_label" Text="Club Name"></asp:Label>
                         <asp:DropDownList ID="DropDownListClubName" runat="server" CssClass="detail_dropdownlist" DataSourceID="SqlDataSourceClubName" DataTextField="clubName" DataValueField="clubid">
                         </asp:DropDownList>
                         <asp:SqlDataSource ID="SqlDataSourceClubName" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT [clubName], [clubid] FROM [Club]"></asp:SqlDataSource>
                         
                         </div>
                <div class="div_right_details_ROW">
                         
                         <asp:Label ID="lbUserName" runat="server" CssClass="detail_label" Text="User Name"></asp:Label>
                         <asp:TextBox ID="tbUserName" runat="server" CssClass="detail_textbox"></asp:TextBox>
                         
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" ControlToValidate="tbUserName" CssClass="validatorMessage" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                         
                         </div>
                <div class="div_right_details_ROW">
                         
                         <asp:Label ID="lbPass" runat="server" CssClass="detail_label" Text="Rassword"></asp:Label>
                         <asp:TextBox ID="tbPass" runat="server" CssClass="detail_textbox" TextMode="Password"></asp:TextBox>
                         
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" ControlToValidate="tbPass" CssClass="validatorMessage" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                         
                         </div>
                <div class="div_right_details_ROW">
                         
                         <asp:Label ID="lbRePass" runat="server" CssClass="detail_label" Text="Re-enter pwd"></asp:Label>
                         <asp:TextBox ID="tbRePass" runat="server" CssClass="detail_textbox" TextMode="Password"></asp:TextBox>
                         
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorRePass" runat="server" ControlToValidate="tbRePass" CssClass="validatorMessage" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                         
                         </div>
                <div class="div_right_details_ROW">
                         
                         <asp:Label ID="lbRiderRole" runat="server" CssClass="detail_label" Text="Rider role"></asp:Label>
                         <asp:RadioButtonList ID="RadioButtonListRole" runat="server" RepeatDirection="Horizontal" CssClass="detail_textbox">
                             <asp:ListItem Value="user" Selected="True">Normal user</asp:ListItem>
                             <asp:ListItem Value="admin">Administrator</asp:ListItem>
                         </asp:RadioButtonList>
                         
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
                        ControlToValidate="tbRiderId" ErrorMessage="Raider ID should be between 10 and 99999"
                        Type="Integer" MinimumValue="10" MaximumValue="99999"
                        SetFocusOnError="True" CssClass="validatorMessage"></asp:RangeValidator>
                    <br />

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator_Email" runat="server"
                        ControlToValidate="tbEmail" ErrorMessage="Email is not correct"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        SetFocusOnError="True" CssClass="validatorMessage">
                    </asp:RegularExpressionValidator> 
                    

                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords not mutch" CssClass="validatorMessage" ControlToCompare="tbRePass" ControlToValidate="tbPass"></asp:CompareValidator>
                    

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

