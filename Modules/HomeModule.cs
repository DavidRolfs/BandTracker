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
        Venue newVenue = new Venue(Request.Form["venue-name"], Request.Form["venue-city"], Request.Form["venue-photo"]);
        newVenue.Save();
        return View["success.cshtml"];
      };
      Get["venues/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Venue SelectedVenue = Venue.Find(parameters.id);
        List<Band> VenueBand = SelectedVenue.GetBands();
        List<Band> AllBands = Band.GetAll();
        model.Add("venue", SelectedVenue);
        model.Add("venueBand", VenueBand);
        model.Add("allBands", AllBands);
        return View["venue.cshtml", model];
      };
      Get["bands/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Band SelectedBand = Band.Find(parameters.id);
        List<Venue> BandVenue = SelectedBand.GetVenues();
        List<Venue> AllVenues = Venue.GetAll();
        model.Add("band", SelectedBand);
        model.Add("bandVenue", BandVenue);
        model.Add("allVenues", AllVenues);
        return View["band.cshtml", model];
      };
      Post["venues/add_band"] = _ => {
        Band band = Band.Find(Request.Form["band-id"]);
        Venue venue = Venue.Find(Request.Form["venue-id"]);
        venue.AddBand(band);
        return View["success.cshtml"];
      };
      Post["bands/add_venue"]= _ => {
        Band band = Band.Find(Request.Form["band-id"]);
        Venue venue = Venue.Find(Request.Form["venue-id"]);
        band.AddVenue(venue);
        return View["success.cshtml"];
      };
      Get["venues/delete/{id}"] = parameters => {
        Venue SelectedVenue = Venue.Find(parameters.id);
        return View["venue_delete.cshtml", SelectedVenue];
      };

      Delete["venues/delete/{id}"] = parameters => {
        Venue SelectedVenue = Venue.Find(parameters.id);
        SelectedVenue.Delete();
        return View["success.cshtml"];
      };
      Get["venues/edit/{id}"] = parameter => {
       Venue SelectedVenue = Venue.Find(parameter.id);
       return View["venue_edit.cshtml", SelectedVenue];
     };

     Patch["venues/edit/{id}"] = parameter => {
       Venue SelectedVenue = Venue.Find(parameter.id);
       SelectedVenue.UpdateVenueName(Request.Form["edit-venueName"]);
       List<Venue> allVenues = Venue.GetAll();
       return View["venues.cshtml", allVenues];
     };
    }
  }
}
