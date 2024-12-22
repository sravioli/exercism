using System;
using System.Collections.Generic;

public class FacialFeatures(string eyeColor, decimal philtrumWidth)
{
    private string EyeColor { get; } = eyeColor;
    private decimal PhiltrumWidth { get; } = philtrumWidth;

    public override bool Equals(object obj) =>
        ReferenceEquals(this, obj) || Equals(obj as FacialFeatures);

    public bool Equals(FacialFeatures other) =>
        other != null
        && EyeColor.Equals(other.EyeColor)
        && PhiltrumWidth.Equals(other.PhiltrumWidth);

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity(string email, FacialFeatures facialFeatures)
{
    private string Email { get; } = email;
    private FacialFeatures FacialFeatures { get; } = facialFeatures;

    public override bool Equals(object obj) =>
        ReferenceEquals(this, obj) || Equals(obj as Identity);

    public bool Equals(Identity other) =>
        other != null && Email.Equals(other.Email) && FacialFeatures.Equals(other.FacialFeatures);

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private readonly HashSet<Identity> _identities = [];
    private static readonly Identity Admin = new("admin@exerc.ism", new("green", 0.9m));

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) =>
        faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(Admin);

    public bool Register(Identity identity) => !IsRegistered(identity) && _identities.Add(identity);

    public bool IsRegistered(Identity identity) => _identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) =>
        ReferenceEquals(identityA, identityB);
}
