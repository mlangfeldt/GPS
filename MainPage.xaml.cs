namespace CustomGPS;

public partial class MainPage : ContentPage
{
    private GeolocationRequest request;

    public MainPage()
    {
        InitializeComponent();
        Title = "Location Application";
        request = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(10));
    }

    async void UpdateLocation_OnClicked(object sender, EventArgs e)
    {
        Location location = await Geolocation.Default.GetLocationAsync(request);

        lblLat.Text = "Lat: " + location.Latitude.ToString();
        lblLon.Text = "Lon: " + location.Longitude.ToString();

        var placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);
        //will return all address within specific range
        var placemark = placemarks?.FirstOrDefault();//whatever is top on list

        lblAddress1.Text = placemark.SubThoroughfare +  " " + placemark.Thoroughfare;
        lblAddress2.Text = placemark.Locality +  " " + placemark.AdminArea + " " + placemark.PostalCode;
    }
}