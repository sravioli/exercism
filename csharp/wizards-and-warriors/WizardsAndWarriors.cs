using System;
using System.Globalization;

abstract class Character
{
    private readonly string characterType;
    private static readonly bool IS_VULNERABLE = false;

    protected Character(string characterType) => this.characterType = characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => IS_VULNERABLE;

    public override string ToString() => $"Character is a {this.characterType}";
}

class Warrior : Character
{
    public Warrior()
        : base("Warrior") { }

    private static readonly int BASE_DMG = 6;
    private static readonly int VULNERABLE_DMG = 10;

    public override int DamagePoints(Character target) =>
        target.Vulnerable() ? VULNERABLE_DMG : BASE_DMG;
}

class Wizard : Character
{
    public Wizard()
        : base("Wizard") { }

    private static readonly int BASE_DMG = 3;
    private static readonly int SPELL_DMG = 12;

    private bool _isSpellPrepared = false;

    public override bool Vulnerable() => !this._isSpellPrepared;

    public override int DamagePoints(Character target) =>
        this._isSpellPrepared ? SPELL_DMG : BASE_DMG;

    public void PrepareSpell() => this._isSpellPrepared = true;
}
