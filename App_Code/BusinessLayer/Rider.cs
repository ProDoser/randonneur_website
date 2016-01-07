using System;


/// <summary>
/// Summary description for Rider
/// </summary>
public class Rider
{
    private int riderid;
    private String familyName;
    private String givenName;
    private String gender;
    private String phone;
    private String email;
    private int clubid;
    private String username;
    private String password;
    private String role;
	public Rider()
	{
		
	}

    public int RiderId { get; set; }
    public String FamilyName { get; set; }
    public String GivenName {get;set;}
    public String Gender { get; set; }
    public String Phone { get; set; }
    public String Email { get; set; }
    public int ClubId { get; set; }
    public String Username { get; set; }
    public String Password { get; set; }
    public String Role { get; set; }
}