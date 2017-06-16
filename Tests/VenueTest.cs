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
    public void Equals_TrueForSameDescription_Venue()
    {
      //Arrange, Act
      Venue firstVenue = new Venue("Crystal Ballroom", "Portland");
      Venue secondVenue = new Venue("Crystal Ballroom", "Portland");

      //Assert
      Assert.Equal(firstVenue, secondVenue);
    }

    [Fact]
    public void Save_VenueSavesToDatabase_VenueList()
    {
      //Arrange
      Venue testVenue = new Venue("Crystal Ballroom", "Portland");
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
      Venue testVenue = new Venue("Crystal Ballroom", "Portland");
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
      Venue testVenue = new Venue("Crystal Ballroom", "Portland");
      testVenue.Save();

      //Act
      Venue result = Venue.Find(testVenue.GetId());

      //Assert
      Assert.Equal(testVenue, result);
    }
    [Fact]
    public void AddBand_AddsAirpotToVenue_BandList()
    {
      Venue testVenue = new Venue("Crystal Ballroom", "Portland");
      testVenue.Save();

      Band testBand = new Band("Animal Collective");
      testBand.Save();

      testVenue.AddBand(testBand);

      List<Band> result = testVenue.GetBands();
      List<Band> testList = new List<Band>{testBand};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void GetBands_ReturnsAllFLightBands_BandList()
    {
      Venue testVenue = new Venue("Crystal Ballroom", "Portland");
      testVenue.Save();

      Band testBand1 = new Band("Animal Collective");
      testBand1.Save();

      Band testBand2 = new Band("Future Islands");
      testBand2.Save();

      testVenue.AddBand(testBand1);
      List<Band> result = testVenue.GetBands();
      List<Band> testList = new List<Band> {testBand1};

      Assert.Equal(testList, result);
    }
    [Fact]
    public void Delete_DeletesVenueAssociationsFromDataBase_VenueList()
    {
      Band testBand = new Band("Animal Collective");
      testBand.Save();

      Venue testVenue = new Venue("Crystal Ballroom", "Portland");
      testVenue.Save();

      testVenue.AddBand(testBand);
      testVenue.Delete();

      List<Venue> result = testBand.GetVenues();
      List<Venue> test = new List<Venue>{};

      Assert.Equal(test, result);
    }
    [Fact]
    public void Test_Update_UpdatesVenuesNameInDatabase()
    {
      Venue testVenue = new Venue("Crystal Ballroom", "Portland");
      testVenue.Save();
      string newName = "Paul";

      testVenue.UpdateVenueName(newName);

      string result = testVenue.GetName();

      Assert.Equal(newName, result);
    }


    public void Dispose()
    {
      Venue.DeleteAll();
    }
  }
}
