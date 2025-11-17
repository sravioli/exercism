using System.Text;

public static class ResistorColorDuo
{
  private enum ResistorColors { Black, Brown, Red, Orange, Yellow, Green, Blue, Violet, Grey, White }

  public static int Value(string[] colors)
  {
    var sb = new StringBuilder();

    foreach (var c in colors.Take(2))
      sb.Append((int)Enum.Parse<ResistorColors>(c, ignoreCase: true));

    return !int.TryParse(sb.ToString(), out int result)
      ? throw new InvalidOperationException()
      : result;
  }
}
