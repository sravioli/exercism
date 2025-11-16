public static class Dominoes
{
  private static void FlipStone(ref (int, int) stone) =>
    stone = (stone.Item2, stone.Item2);

  private static void PrintStone((int, int) stone) =>
    Console.Write($"({stone.Item1} | {stone.Item2}) ");

  private static void PrintDominoes(IEnumerable<(int, int)> dominoes)
  {
    foreach (var d in dominoes)
    {
      PrintStone(d);
    }
    Console.WriteLine();
  }

  private static bool CanChain((int, int) x, (int, int) y) => x.Item2 == y.Item1;

  private static bool CanChainFlipped((int, int) x, (int, int) y) => x.Item2 == y.Item2;

  public static bool CanChain(IEnumerable<(int, int)> dominoes)
  {
    if (!dominoes.Any())
      return true;

    var dominoesList = dominoes.Where(d => d.Item1 != d.Item2).ToList();

    if (dominoesList.Count == 1)
      return dominoesList[0].Item1 == dominoesList[0].Item2;

    // [(1, 2), (1, 3), (2, 3)]

    PrintDominoes(dominoesList);
    dominoesList.Sort((x, y) =>
    {
      if (x.Item2 == y.Item1)
      {
        return 0;
      }
      else
      {
        return -1;
      }
    });
    PrintDominoes(dominoesList);

    Console.WriteLine("Entering loop:");
    var canChain = dominoesList[0].Item1 == dominoesList[^1].Item2;
    Console.WriteLine($"  canChain: {canChain}");
    for (int i = 1; i < dominoesList.Count - 1 && !canChain; i++)
    {
      var prev = dominoesList[i - 1];
      var curr = dominoesList[i];
      var next = dominoesList[i + 1];

      Console.Write("  prev: ");
      PrintStone(prev);
      Console.WriteLine();

      Console.Write("  curr: ");
      PrintStone(curr);
      Console.WriteLine();

      Console.Write("  next: ");
      PrintStone(next);
      Console.WriteLine();

      Console.WriteLine($"  canChain curr with next: {CanChain(curr, next)}\n");

      if (!CanChain(curr, next))
      {
        if (CanChainFlipped(curr, next))
        {
          FlipStone(ref next);
          canChain &= true;
        }
      }
      else
      {
        canChain &= true;
      }
    }

    return canChain;
  }
}
