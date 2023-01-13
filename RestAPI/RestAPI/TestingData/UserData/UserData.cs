using System.Text.Json.Serialization;

namespace RestAPI.TestingData.UserData;

public class Address
{
    [JsonPropertyName("street")]
    public string Street { get; set; }

    [JsonPropertyName("suite")]
    public string Suite { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("zipcode")]
    public string Zipcode { get; set; }

    [JsonPropertyName("geo")]
    public Geo Geo { get; set; }
    
    public override bool Equals(object? obj)
    {
        return obj != null && 
               ((Address) obj).Street.Equals(Street) && 
               ((Address) obj).Suite.Equals(Suite) && 
               ((Address) obj).City.Equals(City) && 
               ((Address) obj).Zipcode.Equals(Zipcode) && 
               ((Address) obj).Geo.Equals(Geo);
    }
}

public class Company
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("catchPhrase")]
    public string CatchPhrase { get; set; }

    [JsonPropertyName("bs")]
    public string Bs { get; set; }
    
    public override bool Equals(object? obj)
    {
        return obj != null && 
               ((Company) obj).Name.Equals(Name) && 
               ((Company) obj).Bs.Equals(Bs) && 
               ((Company) obj).CatchPhrase.Equals(CatchPhrase);
    }
}

public class Geo
{
    [JsonPropertyName("lat")]
    public string Lat { get; set; }

    [JsonPropertyName("lng")]
    public string Lng { get; set; }

    public override bool Equals(object? obj)
    {
        return obj != null && 
               ((Geo) obj).Lat.Equals(Lat) && 
               ((Geo) obj).Lng.Equals(Lng);
    }
}

public class UserData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("address")]
    public Address Address { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("website")]
    public string Website { get; set; }

    [JsonPropertyName("company")]
    public Company Company { get; set; }

    public override bool Equals(object? obj)
    {
        return obj != null &&
               ((UserData) obj).Address.Equals(Address) && 
               ((UserData) obj).Name.Equals(Name) && 
               ((UserData) obj).Username.Equals(Username) && 
               ((UserData) obj).Email.Equals(Email) && 
               ((UserData) obj).Phone.Equals(Phone) && 
               ((UserData) obj).Website.Equals(Website) && 
               ((UserData) obj).Company.Equals(Company);
    }
}