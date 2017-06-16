using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/bands"] = _ => {
        List<Band> AllBands = Band.GetAll();
        return View["bands.cshtml", AllBands];
      };
      Get["/venues"] = _ => {
        List<Venue> AllVenues = Venue.GetAll();
        return View["venues.cshtml", AllVenues];
      };
      Get["/bands/add"]= _ => {
        return View["bands_form.cshtml"];
      };
      Post["/bands/add"]= _ => {
        Band newBand = new Band(Request.Form["band-name"]);
        newBand.Save();
        return View["success.cshtml"];
      };
      Get["/venues/add"]= _ => {
        return View["venues_form.cshtml"];
      };
      Post["/venues/add"]= _ => {
        Venue newVenue = new Venue(Request.Form["venue-name"], Request.Form["venue-city"]);
        newVenue.Save();
        return View["success.cshtml"];
      };
    }
  }
}
