public static class Grains
{
  private const int SQUARES_NUMBER = 64;

  public static ulong Square(int n)
  {
    ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(n, 0);
    ArgumentOutOfRangeException.ThrowIfGreaterThan(n, SQUARES_NUMBER);

    return (ulong)1 << (n - 1);
  }

  public static ulong Total() => ulong.MaxValue;
}
