using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  [Collection("tester")]
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = Venue.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Equals_TrueForSameObjects_Venue()
    {
      //Arrange, Act
      Venue firstVenue = new Venue("Crystal Ballroom", "Portland", "website.com/photoOfCrystalBallroom.jpg");
      Venue secondVenue = new Venue("Crystal Ballroom", "Portland", "website.com/photoOfCrystalBallroom.jpg");

      //Assert
      Assert.Equal(firstVenue, secondVenue);
    }

    [Fact]
    public void Save_VenueSavesToDatabase_VenueList()
    {
      //Arrange
      Venue testVenue = new Venue("Crystal Ballroom", "Portland", "website.com/photoOfCrystalBallroom.jpg");
      testVenue.Save();

      //Act
      List<Venue> result = Venue.GetAll();
      List<Venue> testList = new List<Venue>{testVenue};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Save_AssignsIdToObject_id()
    {
      //Arrange
      Venue testVenue = new Venue("Crystal Ballroom", "Portland", "website.com/photoOfCrystalBallroom.jpg");
      testVenue.Save();

      //Act
      Venue savedVenue = Venue.GetAll()[0];

      int result = savedVenue.GetId();
      int testId = testVenue.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Find_FindsVenueInDatabase_Venue()
    {
      //Arrange
      Venue testVenue = new Venue("Crystal Ballroom", "Portland", "website.com/photoOfCrystalBallroom.jpg");
      testVenue.Save();

      //Act
      Venue result = Venue.Find(testVenue.GetId());

      //Assert
      Assert.Equal(testVenue, result);
    }
    [Fact]
    public void AddBand_AddsBandsToVenue_BandList()
    {
      Venue testVenue = new Venue("Crystal Ballroom", "Portland", "website.com/photoOfCrystalBallroom.jpg");
      testVenue.Save();

      Band testBand = new Band("Animal Collective", "website.com/photoOfband.jpg");
      testBand.Save();

      testVenue.AddBand(testBand);

      List<Band> result = testVenue.GetBands();
      List<Band> testList = new List<Band>{testBand};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void GetBands_ReturnsAllBands_BandList()
    {
      Venue testVenue = new Venue("Crystal Ballroom", "Portland", "website.com/photoOfCrystalBallroom.jpg");
      testVenue.Save();

      Band testBand1 = new Band("Animal Collective", "website.com/photoOfband.jpg");
      testBand1.Save();

      Band testBand2 = new Band("Future Islands", "website.com/photoOfband.jpg");
      testBand2.Save();

      testVenue.AddBand(testBand1);
      List<Band> result = testVenue.GetBands();
      List<Band> testList = new List<Band> {testBand1};

      Assert.Equal(testList, result);
    }
    [Fact]
    public void Delete_DeletesVenueAssociationsFromDataBase_VenueList()
    {
      Band testBand = new Band("Animal Collective", "website.com/photoOfband.jpg");
      testBand.Save();

      Venue testVenue = new Venue("Crystal Ballroom", "Portland", "website.com/photoOfCrystalBallroom.jpg");
      testVenue.Save();

      testVenue.AddBand(testBand);
      testVenue.Delete();

      List<Venue> result = testBand.GetVenues();
      List<Venue> test = new List<Venue>{};

      Assert.Equal(test, result);
    }
    [Fact]
    public void Test_Update_UpdatesVenuesPhotoInDatabase()
    {
      Venue testVenue = new Venue("Crystal Ballroom", "Portland", "website.com/photoOfCrystalBallroom.jpg");
      testVenue.Save();
      string newName = "website.com/diffphoto";

      testVenue.UpdateVenuePhoto(newName);

      string result = testVenue.GetName();

      Assert.Equal(newName, result);
    }


    public void Dispose()
    {
      Venue.DeleteAll();
      Band.DeleteAll();
    }
  }
}
