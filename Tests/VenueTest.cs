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
    public void Dispose()
    {
      Venue.DeleteAll();
    }
  }
}
