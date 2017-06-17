using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  [Collection("tester")]
  public class BandTest : IDisposable
  {
    public BandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_BandEmptyAtFirst()
    {
      int result = Band.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      Band firstBand = new Band("Animal Collective", "website.com/photoOfband.jpg");
      Band secondBand = new Band("Animal Collective", "website.com/photoOfband.jpg");

      Assert.Equal(firstBand, secondBand);
    }

    [Fact]
    public void Test_Save_SavesBandToDatabase()
    {
      Band testBand = new Band("Animal Collective", "website.com/photoOfband.jpg");
      testBand.Save();

      List<Band> result = Band.GetAll();
      List<Band> testList = new List<Band>{testBand};

      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Save_AssignsIdToBand()
    {
      Band testBand = new Band("Animal Collective", "website.com/photoOfband.jpg");
      testBand.Save();

      Band savedBand = Band.GetAll()[0];

      int result = savedBand.GetId();
      int testId = testBand.GetId();

      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsBandInDatabase()
    {
      Band testBand = new Band("Animal Collective", "website.com/photoOfband.jpg");
      testBand.Save();

      Band foundBand = Band.Find(testBand.GetId());

      Assert.Equal(testBand, foundBand);
    }
    [Fact]
    public void AddVenues_AddVenuesToBands_AddsVenueToBand()

    {
      Band testBand = new Band("Animal Collective", "website.com/photoOfband.jpg");
      testBand.Save();

      Venue testVenue = new Venue("Crystal Ballroom", "Portland", "website.com/photoOfCrystalBallroom.jpg");
      testVenue.Save();

      testBand.AddVenue(testVenue);

      List<Venue> savedVenues = testBand.GetVenues();
      List<Venue> testList = new List<Venue>{testVenue};

      Assert.Equal(testList, savedVenues);
    }

    [Fact]
    public void GetVenues_ReturnAllBandVenues_VenueList()
    {
      Band testBand = new Band("Animal Collective", "website.com/photoOfband.jpg");
      testBand.Save();

      Venue testVenue1 = new Venue("Crystal Ballroom", "Portland", "website.com/photoOfCrystalBallroom.jpg");
      testVenue1.Save();

      Venue testVenue2 = new Venue("Wonder Ballroom", "PLand", "website.com/photoOfCrystalBallroom.jpg");
      testVenue2.Save();

      testBand.AddVenue(testVenue1);
      List<Venue> savedVenue = testBand.GetVenues();
      List<Venue> testList = new List<Venue> {testVenue1};

      Assert.Equal(testList, savedVenue);
    }
    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
