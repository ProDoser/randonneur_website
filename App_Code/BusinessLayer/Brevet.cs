using System;

/// <summary>
/// Summary description for Brevet
/// </summary>
public class Brevet
{
    private int brevetId;
    private int distance;
    private DateTime brevetDate;
    private string location;
    private int climbing;
	public Brevet()
	{
        brevetId = -1;
        distance = 0;
        brevetDate = new DateTime(1900, 1, 1);
        location = "";
        climbing = 0;

	}
    public int BrevetId { get; set; }
    public int Distance 
    {
        get {return distance;}
        set { distance = value; }
    }
    
    
    public DateTime BrevetDate { get; set; }
    public String Location { get; set; }
    public int Climbing { get; set; }
}