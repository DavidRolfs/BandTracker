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
      Band firstBand = new Band("Animal Collective");
      Band secondBand = new Band("Animcal Collective");

      Assert.Equal(firstBand, secondBand);
    }

    [Fact]
    public void Test_Save_SavesBandToDatabase()
    {
      Band testBand = new Band("Animal Collective");
      testBand.Save();

      List<Band> result = Band.GetAll();
      List<Band> testList = new List<Band>{testBand};

      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Save_AssignsIdToCategoryObject()
    {
      Band testBand = new Band("Animal Collective");
      testBand.Save();

      Band savedBand = Band.GetAll()[0];

      int result = savedBand.GetId();
      int testId = testBand.GetId();

      Assert.Equal(testId, result);
    }
    public void Dispose()
    {
      Band.DeleteAll();
    }
  }
}
