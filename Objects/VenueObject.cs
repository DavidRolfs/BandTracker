using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker
{
  public class Venue
  {
    private int _id;
    private string _name;
    private string _city;
    private string _photo;

    public Venue(string name, string city, int Id = 0)
    {
      _name = name;
      _id = Id;
      _city = city;
    }

    public override bool Equals(System.Object otherVenue)
    {
        if (!(otherVenue is Venue))
        {
          return false;
        }
        else {
          Venue newVenue = (Venue) otherVenue;
          bool idEquality = this.GetId() == newVenue.GetId();
          bool nameEquality = this.GetName() == newVenue.GetName();
          bool cityEquality = this.GetCity() == newVenue.GetCity();
          return (idEquality && nameEquality && cityEquality);
        }
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetCity()
    {
      return _city;
    }
    public static List<Venue> GetAll()
    {
      List<Venue> AllVenues = new List<Venue>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueName = rdr.GetString(1);
        string venueCity = rdr.GetString(2);
        Venue newVenue = new Venue(venueName, venueCity, venueId);
        AllVenues.Add(newVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllVenues;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO venues (name, city) OUTPUT INSERTED.id VALUES (@VenueName, @VenueCity)", conn);

      SqlParameter venueNameParam = new SqlParameter();
      venueNameParam.ParameterName = "@VenueName";
      venueNameParam.Value = this.GetName();

      SqlParameter venueCityParam = new SqlParameter();
      venueCityParam.ParameterName = "@VenueCity";
      venueCityParam.Value = this.GetCity();


      cmd.Parameters.Add(venueNameParam);
      cmd.Parameters.Add(venueCityParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM venues;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public static Venue Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues WHERE id = @VenueId", conn);
      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = id.ToString();
      cmd.Parameters.Add(venueIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundVenueId = 0;
      string foundVenueName = null;
      string foundVenueCity = null;

      while(rdr.Read())
      {
        foundVenueId = rdr.GetInt32(0);
        foundVenueName = rdr.GetString(1);
        foundVenueCity = rdr.GetString(2);
      }
      Venue foundVenue = new Venue(foundVenueName, foundVenueCity, foundVenueId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundVenue;
    }

    public void AddBand(Band newBand)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO bands_venues (band_id, venue_id) VALUES (@BandId, @VenueId);", conn);

      SqlParameter bandIdParameter = new SqlParameter();
      bandIdParameter.ParameterName = "@BandId";
      bandIdParameter.Value = newBand.GetId();
      cmd.Parameters.Add(bandIdParameter);

      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = this.GetId();
      cmd.Parameters.Add(venueIdParameter);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
    public List<Band> GetBands()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT bands.* FROM venues JOIN bands_venues ON (venues.id = bands_venues.venue_id) JOIN bands ON (bands_venues.band_id = bands.id) WHERE venues.id = @VenueId;", conn);
      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = this.GetId();

      cmd.Parameters.Add(venueIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Band> bands = new List<Band> {};

      while(rdr.Read())
        {
          int thisBandId = rdr.GetInt32(0);
          string bandName = rdr.GetString(1);
          Band foundBand = new Band(bandName, thisBandId);
          bands.Add(foundBand);
        }
        if (rdr != null)
        {
          rdr.Close();
        }

      if (conn != null)
      {
        conn.Close();
      }
      return bands;
    }
    public void UpdateVenueName(string newName)
		{
			SqlConnection conn = DB.Connection();
			conn.Open();

			SqlCommand cmd = new SqlCommand("UPDATE venues SET name = @NewName OUTPUT INSERTED.name WHERE id = @venueId;", conn);

			SqlParameter newNameParameter = new SqlParameter();
			newNameParameter.ParameterName = "@NewName";
			newNameParameter.Value = newName;
			cmd.Parameters.Add(newNameParameter);

			SqlParameter venueIdParameter = new SqlParameter();
			venueIdParameter.ParameterName = "@venueId";
			venueIdParameter.Value = this.GetId();
			cmd.Parameters.Add(venueIdParameter);

			SqlDataReader rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				this._name = rdr.GetString(0);
			}
			if(rdr != null)
			{
				rdr.Close();
			}
			if(conn != null)
			{
				conn.Close();
			}
		}
    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM venues WHERE id = @VenueId; DELETE FROM bands_venues WHERE venue_id = @VenueId;", conn);
      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = this.GetId();

      cmd.Parameters.Add(venueIdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
  }
}
