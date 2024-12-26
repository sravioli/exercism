using System.Collections.Generic;

public class Authenticator
{
    public Identity Admin { get; } =
        new(
            email: "admin@ex.ism",
            facialFeatures: new FacialFeatures(eyeColor: "green", philtrumWidth: 0.9M),
            nameAndAddress: ["Chanakya", "Mumbai", "India"]
        );

    public IDictionary<string, Identity> Developers { get; } =
        new Dictionary<string, Identity>
        {
            ["Bertrand"] = new(
                email: "bert@ex.ism",
                facialFeatures: new FacialFeatures(eyeColor: "blue", philtrumWidth: 0.8M),
                nameAndAddress: ["Bertrand", "Paris", "France"]
            ),
            ["Anders"] = new(
                email: "anders@ex.ism",
                facialFeatures: new FacialFeatures(eyeColor: "brown", philtrumWidth: 0.85M),
                nameAndAddress: ["Anders", "Redmond", "USA"]
            ),
        };
}

//**** please do not modify the FacialFeatures class ****
public class FacialFeatures
{
    public FacialFeatures() { }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public string EyeColor { get; set; }
    public decimal PhiltrumWidth { get; set; }
}

//**** please do not modify the Identity class ****
public class Identity
{
    public Identity() { }

    public Identity(string email, FacialFeatures facialFeatures, IList<string> nameAndAddress)
    {
        Email = email;
        FacialFeatures = facialFeatures;
        NameAndAddress = nameAndAddress;
    }

    public string Email { get; set; }
    public FacialFeatures FacialFeatures { get; set; }
    public IList<string> NameAndAddress { get; set; }
}
