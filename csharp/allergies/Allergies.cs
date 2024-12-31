using System;
using System.Linq;

[Flags]
public enum Allergen
{
    Eggs = 0b0000_0001,
    Peanuts = 0b0000_0010,
    Shellfish = 0b0000_0100,
    Strawberries = 0b0000_1000,
    Tomatoes = 0b0001_0000,
    Chocolate = 0b0010_0000,
    Pollen = 0b0100_0000,
    Cats = 0b1000_0000,
}

public class Allergies(int mask)
{
    public bool IsAllergicTo(Allergen allergen) => (allergen & (Allergen)mask) != 0;

    public Allergen[] List() => Enum.GetValues<Allergen>().Where(IsAllergicTo).ToArray();
}
