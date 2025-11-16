public enum Classification
{
  Perfect,
  Abundant,
  Deficient
}

// The aliquot sum is defined as the sum of the factors of a number not
// including the number itself. For example, the aliquot sum of 15 is 1 + 3 + 5 = 9.

public static class PerfectNumbers
{
  public static Classification Classify(int number)
  {
    ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(number, 0);

    if (number == 1)
      return Classification.Deficient;

    var sum = Enumerable
      .Range(1, number - 1)
      .Where(x => number % x == 0)
      .Sum();

    return number switch
    {
      int n when n < sum => Classification.Abundant,
      int n when n > sum => Classification.Deficient,
      _ => Classification.Perfect,
    };
  }
}
