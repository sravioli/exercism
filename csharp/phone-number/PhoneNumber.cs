using System.Text.RegularExpressions;

public static partial class Re
{
  [GeneratedRegex(@"[2-9][0-9]{2}[2-9][0-9]{6}")]
  public static partial Regex ValidPhoneNumber();
  [GeneratedRegex(@"^(\+1|1)?")]
  public static partial Regex Prefix();

  [GeneratedRegex(@"\D*")]
  public static partial Regex NonDigit();
}

public class PhoneNumber
{
  private const int MAX_NUMBER_LENGHT = 10;

  public static string Clean(string phoneNumber)
  {
    if (!Re.Prefix().IsMatch(phoneNumber))
      throw new ArgumentException("Invalid prefix");

    phoneNumber = Re.Prefix().Replace(phoneNumber, string.Empty);
    phoneNumber = Re.NonDigit().Replace(phoneNumber, string.Empty);

    return phoneNumber.Length > MAX_NUMBER_LENGHT || !Re.ValidPhoneNumber().IsMatch(phoneNumber)
      ? throw new ArgumentException("The given number is invlid")
      : phoneNumber;
  }
}
