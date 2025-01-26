using System.Linq;

public static class FoodChain
{
    private static readonly string[] Animals = ["spider", "bird", "cat", "dog", "goat", "cow"];

    private static readonly string[] FollowUps =
    [
        "It wriggled and jiggled and tickled inside her.",
        "How absurd to swallow a bird!",
        "Imagine that, to swallow a cat!",
        "What a hog, to swallow a dog!",
        "Just opened her throat and swallowed a goat!",
        "I don't know how she swallowed a cow!",
    ];

    private static readonly string[] History =
    [
        "I don't know how she swallowed a cow!",
        "She swallowed the cow to catch the goat.",
        "She swallowed the goat to catch the dog.",
        "She swallowed the dog to catch the cat.",
        "She swallowed the cat to catch the bird.",
        "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.",
        "She swallowed the spider to catch the fly.",
        "I don't know why she swallowed the fly. Perhaps she'll die.",
    ];

    public static string Recite(int verseNumber) => Recite(verseNumber, verseNumber);

    public static string Recite(int startVerse, int endVerse) =>
        string.Join(
            "\n\n",
            Enumerable
                .Range(startVerse, endVerse - startVerse + 1)
                .Select(i => $"{VerseBegin(i)}\n{VerseEnd(i)}")
        );

    private static string VerseBegin(int number)
    {
        switch (number)
        {
            case 1:
                return "I know an old lady who swallowed a fly.";
            case 8:
                return "I know an old lady who swallowed a horse.";
        }

        var animal = Animals[number - 2];
        var followUp = FollowUps[number - 2];
        return $"I know an old lady who swallowed a {animal}.\n{followUp}";
    }

    private static string VerseEnd(int number) =>
        number == 8
            ? "She's dead, of course!"
            : string.Join("\n", History.Skip(History.Length - number).Take(number));
}
