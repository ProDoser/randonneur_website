using System;

public class Club
{
    private int clubId;
    private String clubName;
    private String clubCity;
    private String clubEmail;

    public Club()
    {
        clubId = -1;
        clubName = "";
        clubCity = "";
        clubEmail = "";
    }

    public int ClubId
    {
        get { return clubId; }
        set { clubId = value; }
    }
    public String ClubName
    {
        get { return clubName; }
        set { clubName = value; }
    }
    public String ClubCity { get; set; }
    public String ClubEmail { get; set; }
}

