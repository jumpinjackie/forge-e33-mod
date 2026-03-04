using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Net;
using DotMake.CommandLine;
using Microsoft.VisualBasic;

await Cli.RunAsync<RootCommand>(args);

public class CardFaceDesign
{
    public string? Name { get; set; }

    public string? InvariantName { get; set; }

    public string[]? ManaCost { get; set; }

    public string[]? ColorIdentity { get; set; }

    public string FormatManaCost()
    {
        return string.Join(string.Empty, (ManaCost ?? []).Select(mc => FormatPip(mc)));
    }

    static string FormatPip(string pip)
    {
        if (pip.All(char.IsDigit))
            return pip;
        else if (pip.Length == 1)
            return pip.ToUpperInvariant();
        else if (pip.Length == 2)
            return $"({pip[0]}/{pip[1]})";
        return string.Empty; // No idea WTF this is
    }

    public string[]? Types { get; set; }

    public string? TypeLine { get; set; }

    public string[]? ForgeScript { get; set; }

    public string[]? Oracle { get; set; }

    public string? OracleTextFull => this.Oracle is not null ? string.Join("\n", this.Oracle) : null;

    public string[]? FlavorText { get; set; }

    public string? FlavorTextFull => this.FlavorText is not null ? string.Join("\n", this.FlavorText) : null;

    public string[]? DesignNotes { get; set; }

    public string[]? ExtraNotes { get; set; }

    public string[]? Bugs { get; set; }

    public string? PT { get; set; }

    public string? Loyalty { get; set; }

    public string? Rarity { get; set; }

    public string? Artist { get; set; }

    public string? ArtNotes { get; set; }

    public string[]? AbilityWords { get; set; }

    public bool IsReprint { get; set; } = false;

    public bool IsCommander { get; set; } = false;

    public string? NicknameFor { get; set; }

    public bool EntersTapped { get; set; } = false;

    public string[]? RelatedTokens { get; set; }

    public int? DraftScore { get; set; }

    public string[]? Tags { get; set; }

    public string[]? Cycle { get; set; }

    internal void Apply(string propertyName, IEnumerable<string> buffer)
    {
        switch (propertyName)
        {
            case nameof(Name):
                Name = string.Join(" ", buffer);
                break;
            case nameof(InvariantName):
                InvariantName = string.Join(" ", buffer);
                break;
            case nameof(ManaCost):
                ManaCost = buffer.ToArray();
                break;
            case nameof(ColorIdentity):
                ColorIdentity = buffer.ToArray();
                break;
            case nameof(Rarity):
                Rarity = string.Join(" ", buffer);
                break;
            case nameof(Artist):
                Artist = string.Join(" ", buffer);
                break;
            case nameof(ArtNotes):
                ArtNotes = string.Join("\n", buffer);
                break;
            case nameof(Types):
                Types = buffer.ToArray();
                this.TypeLine = BuildTypeLine(Types);
                break;
            case nameof(Oracle):
                Oracle = buffer.ToArray();
                break;
            case nameof(FlavorText):
                FlavorText = buffer.ToArray();
                break;
            case nameof(ForgeScript):
                ForgeScript = buffer.ToArray();
                break;
            case nameof(DesignNotes):
                DesignNotes = buffer.ToArray();
                break;
            case nameof(Bugs):
                Bugs = buffer.ToArray();
                break;
            case nameof(PT):
                PT = string.Join(" ", buffer);
                break;
            case nameof(Loyalty):
                Loyalty = string.Join(" ", buffer);
                break;
            case nameof(AbilityWords):
                AbilityWords = buffer.ToArray();
                break;
            case nameof(IsReprint):
                IsReprint = string.Join(" ", buffer) == "true";
                break;
            case nameof(IsCommander):
                IsCommander = string.Join(" ", buffer) == "true";
                break;
            case nameof(NicknameFor):
                NicknameFor = string.Join(" ", buffer);
                break;
            case nameof(EntersTapped):
                EntersTapped = string.Join(" ", buffer) == "true";
                break;
            case nameof(RelatedTokens):
                RelatedTokens = buffer.ToArray();
                break;
            case nameof(DraftScore):
                if (int.TryParse(string.Join(" ", buffer), out var score))
                    DraftScore = score;
                break;
            case nameof(Tags):
                Tags = buffer.ToArray();
                break;
            case nameof(Cycle):
                Cycle = buffer.ToArray();
                break;
            case nameof(ExtraNotes):
            case "Rulings":
                ExtraNotes = buffer.ToArray();
                break;
        }
    }

    public static string BuildTypeLine(string[] types)
    {
        var tokens = types.ToList();

        // Determine which token to insert a - after
        bool bDone = false;
        int mostSignificantIdx = -1;
        for (var i = 0; i < tokens.Count; i++)
        {
            if (bDone)
                break;

            if (i < tokens.Count - 1)
            {
                switch (tokens[i])
                {
                    case "Sorcery":
                    case "Instant":
                    case "Land":
                    case "Artifact":
                    case "Enchantment":
                    case "Creature":
                    case "Planeswalker":
                        mostSignificantIdx = i;
                        break;
                }
            }
        }
        if (mostSignificantIdx < tokens.Count - 1 && mostSignificantIdx >= 0)
        {
            tokens.Insert(mostSignificantIdx + 1, "-");
        }

        return string.Join(" ", tokens);
    }

    internal async Task WriteScriptAsync(StreamWriter sw, TextWriter stdout, TextWriter stderr, CardFaceType faceType)
    {
        await sw.WriteLineAsync($"Name:{this.Name}");
        if (this.ManaCost is not null)
            await sw.WriteLineAsync($"ManaCost:{string.Join(" ", this.ManaCost)}");
        else
            await sw.WriteLineAsync("ManaCost:no cost");
        if (this.ColorIdentity is not null)
            await sw.WriteLineAsync($"Colors:{string.Join(" ", this.ColorIdentity)}");
        await sw.WriteLineAsync($"Types:{string.Join(" ", this.Types ?? [])}");
        if (this.Loyalty is not null)
            await sw.WriteLineAsync($"Loyalty:{this.Loyalty}");
        if (this.PT is not null)
            await sw.WriteLineAsync($"PT:{this.PT}");
        if (this.ForgeScript is not null)
        {
            foreach (var scriptLine in this.GetForgeScript().Split("\n"))
            {
                await sw.WriteLineAsync(scriptLine);
            }
        }
        var oracle = this.GetOracleText()?.Trim()?.Split('\n');
        if (oracle is not null)
        {
            if (faceType == CardFaceType.SplitRoom)
                await sw.WriteAsync($"Oracle:(You may cast either half. That door unlocks on the battlefield. As a sorcery, you may pay the mana cost of a locked door to unlock it.)\\n{string.Join("\\n", oracle)}");
            else if (faceType == CardFaceType.SplitFuse)
                await sw.WriteAsync($"Oracle:{string.Join("\\n", oracle)}\\nFuse (You may cast one or both halves of this card from your hand.)");
            else
                await sw.WriteAsync($"Oracle:{string.Join("\\n", oracle)}");
        }
    }

    internal string GetForgeScript()
    {
        var sb = new StringBuilder(string.Join("\n", this.ForgeScript ?? []));
        sb.Replace("$NEVRON_DEATH_ABILITY", """
        T:Mode$ ChangesZone | Origin$ Battlefield | Destination$ Graveyard | ValidCard$ Card.Self | Execute$ TrigToken | TriggerDescription$ When this creature dies, target opponent creates a Lumina token.
        SVar:TrigToken:DB$ Token | TokenAmount$ 1 | ValidTgts$ Opponent | TokenOwner$ Targeted | TokenScript$ c_a_lumina
        """);
        sb.Replace("$EXPEDITIONER_DEATH_ABILITY", """
        T:Mode$ ChangesZone | Origin$ Battlefield | Destination$ Graveyard | ValidCard$ Card.Self | Execute$ TrigToken | TriggerDescription$ When CARDNAME dies, create a Chroma token
        SVar:TrigToken:DB$ Token | TokenScript$ c_a_chroma | TokenOwner$ You | TokenAmount$ 1
        """);
        sb.Replace("~", "CARDNAME");
        sb.Replace("$DEVOID_REMINDER_TEXT", "(This card has no color.)");
        sb.Replace("$SHIELD_REMINDER_TEXT", "(If it would be dealt damage or destroyed, remove a shield counter from it instead.)");
        sb.Replace("$LEGENDARY_SORCERY_REMINDER_TEXT", "(You may cast a legendary sorcery only if you control a legendary creature or planeswalker.)");
        sb.Replace("$INVESTIGATE_REMINDER_TEXT", "(Create a Clue token. It's an artifact with \"{2}, Sacrifice this artifact: Draw a card.\")");
        sb.Replace("$NEVRON_DEATH_ABILITY_TEXT_SHORT", "When this creature dies, target opponent creates a Lumina token.");
        sb.Replace("$NEVRON_DEATH_ABILITY_TEXT", "When this creature dies, target opponent creates a Lumina token. $LUMINA_REMINDER_TEXT");
        sb.Replace("$CHROMA_REMINDER_TEXT", "(It's an artifact with \"{T}, Sacrifice this artifact: Add one mana of any color. Spend this mana only to cast a Nevron, Gestral or Expeditioner spell.\")");
        sb.Replace("$LUMINA_REMINDER_TEXT", "(It's an artifact with \"{T}, Sacrifice this artifact: Scry 1.\")");
        sb.Replace("$EXPEDITIONER_TOKEN_TEXT", "\"When this creature dies, create a Chroma token.\"");
        sb.Replace("$EXPEDITIONER_DEATH_ABILITY_TEXT", "When this creature dies, create a Chroma token.");

        // Handle parameterized PICTO_REPLICATE_ABILITY at the end after all other replacements
        var text = sb.ToString();
        int startIdx;
        while ((startIdx = text.IndexOf("$PICTO_REPLICATE_ABILITY(")) != -1)
        {
            var endIdx = text.IndexOf(')', startIdx);
            if (endIdx == -1) break;

            var costValue = text.Substring(startIdx + 25, endIdx - (startIdx + 25));
            var replacement = $"""
        A:AB$ CopyPermanent | Cost$ Sac<{costValue}/Lumina> | CheckSVar$ TokenCopies | SVarCompare$ EQ0 | ValidTgts$ Creature.YouCtrl | Defined$ Self | NumCopies$ 1 | AttachedTo$ Targeted | SpellDescription$ Create a token copy of CARDNAME attached to target creature you control. Activate this ability only if you control no token copies of CARDNAME.
        SVar:TokenCopies:Count$Valid Artifact.YouCtrl+token+named{this.Name}
        """;
            text = text.Remove(startIdx, endIdx - startIdx + 1).Insert(startIdx, replacement);
        }

        // Convert first character to uppercase
        if (text.Length > 0)
        {
            text = char.ToUpper(text[0]) + text.Substring(1);
        }
        return text;
    }

    internal string GetCardConjurerOracleText()
    {
        var text = new StringBuilder(this.GetOracleText());

        // Italicize all ability words
        if (this.AbilityWords is not null)
        {
            foreach (var aw in this.AbilityWords)
            {
                text.Replace(aw, "{i}" + aw + "{/i}");
            }
        }

        // Append flavor text afterwards only if present
        if (this.FlavorTextFull is not null)
        {
            text.Append("{flavor}" + this.FlavorTextFull);
        }

        return text.ToString();
    }

    internal string GetCockatriceManaCost()
    {
        if (this.ManaCost is null)
            return string.Empty;
        if (this.ManaCost[0] == "no cost")
            return string.Empty;
        return this.FormatManaCost();
    }

    internal int? GetManaValue()
    {
        if (this.ManaCost is not null && this.ManaCost.Length > 0 && this.ManaCost[0] != "no cost")
        {
            int total = 0;
            foreach (var pip in this.ManaCost)
            {
                if (int.TryParse(pip, out int num))
                {
                    total += num;
                }
                else if (pip.Length == 1 && "WUBRG".Contains(char.ToUpperInvariant(pip[0])))
                {
                    total += 1;
                }
                else if (pip.Length == 2) // hybrid
                {
                    total += 1;
                }
                // Other symbols like X are treated as 0
            }
            return total;
        }
        return null;
    }

    internal void PopulateColorsFromManaCost(HashSet<char> colors)
    {
        if (this.ManaCost is not null)
        {
            foreach (var pip in this.ManaCost)
            {
                if (pip.Length == 1)
                {
                    var c = char.ToUpperInvariant(pip[0]);
                    if ("WUBRG".Contains(c)) colors.Add(c);
                }
                else if (pip.Length == 2)
                {
                    var c1 = char.ToUpperInvariant(pip[0]);
                    var c2 = char.ToUpperInvariant(pip[1]);
                    if ("WUBRG".Contains(c1)) colors.Add(c1);
                    if ("WUBRG".Contains(c2)) colors.Add(c2);
                }
            }
        }
    }

    internal void PopulateColorsFromColorIdentity(HashSet<char> colors)
    {
        if (this.ColorIdentity is not null)
        {
            foreach (var c in this.ColorIdentity)
            {
                var letter = c.ToLower() switch
                {
                    "white" => 'W',
                    "blue" => 'U',
                    "black" => 'B',
                    "red" => 'R',
                    "green" => 'G',
                    _ => (char?)null
                };
                if (letter.HasValue) colors.Add(letter.Value);
            }
        }
    }

    internal string GetCockatriceColors()
    {
        var colors = new HashSet<char>();
        PopulateColorsFromManaCost(colors);
        if (colors.Count == 0)
        {
            PopulateColorsFromColorIdentity(colors);
        }
        // Sort in WUBRG order
        var order = new[] { 'W', 'U', 'B', 'R', 'G' };
        var sorted = colors.OrderBy(c => Array.IndexOf(order, c));
        return string.Join(string.Empty, sorted);
    }

    internal string GetOracleText()
    {
        var origCardName = this.Name;
        var thisName = origCardName;
        var ht = (this.Types ?? []).ToHashSet();
        var sb = new StringBuilder(this.OracleTextFull);
        //if (ht.Contains("Instant") || ht.Contains("Sorcery"))
        //    thisName = "this spell";
        if (ht.Contains("Creature"))
        {
            if (ht.Contains("Legendary"))
                thisName = GetLegendaryName(origCardName);
            else
                thisName = "this creature";
        }
        if (ht.Contains("Enchantment"))
        {
            if (ht.Contains("Legendary"))
            {
                thisName = GetLegendaryName(origCardName);
            }
            else
            {
                if (ht.Contains("Aura"))
                    thisName = "this Aura";
                else
                    thisName = "this enchantment";
            }
        }
        if (ht.Contains("Artifact"))
        {
            if (ht.Contains("Legendary"))
            {
                thisName = GetLegendaryName(origCardName);
            }
            else
            {
                if (ht.Contains("Vehicle"))
                    thisName = "this vehicle";
                else if (ht.Contains("Creature"))
                    thisName = "this creature";
                else if (ht.Contains("Equipment"))
                    thisName = "this equipment";
                else
                    thisName = "this artifact";
            }
        }
        if (ht.Contains("Land"))
        {
            if (ht.Contains("Legendary"))
            {
                thisName = GetLegendaryName(origCardName);
            }
            else
            {
                thisName = "this land";
            }
        }

        static string? GetLegendaryName(string? origCardName)
        {
            if (origCardName?.Contains(",") == true)
                return origCardName.Substring(0, origCardName.IndexOf(",")); // Take the part before the comma
            else
                return origCardName;
        }

        sb.Replace(": ~", ": " + (string.IsNullOrEmpty(thisName) ? thisName : char.ToUpper(thisName[0]) + thisName.Substring(1)));
        sb.Replace(". ~", ". " + (string.IsNullOrEmpty(thisName) ? thisName : char.ToUpper(thisName[0]) + thisName.Substring(1)));
        sb.Replace("- ~", "- " + (string.IsNullOrEmpty(thisName) ? thisName : char.ToUpper(thisName[0]) + thisName.Substring(1)));
        sb.Replace("— ~", "— " + (string.IsNullOrEmpty(thisName) ? thisName : char.ToUpper(thisName[0]) + thisName.Substring(1)));
        sb.Replace("\n~", "\n" + (string.IsNullOrEmpty(thisName) ? thisName : char.ToUpper(thisName[0]) + thisName.Substring(1)));
        sb.Replace("~", thisName);
        sb.Replace("$DEVOID_REMINDER_TEXT", "(This card has no color.)");
        sb.Replace("$SHIELD_REMINDER_TEXT", "(If it would be dealt damage or destroyed, remove a shield counter from it instead.)");
        sb.Replace("$FOOD_REMINDER_TEXT", "(It's an artifact with \"{2}, {T}, Sacrifice this token: You gain 3 life.\")");
        sb.Replace("$LEGENDARY_SORCERY_REMINDER_TEXT", "(You may cast a legendary sorcery only if you control a legendary creature or planeswalker.)");
        sb.Replace("$INVESTIGATE_REMINDER_TEXT", "(Create a Clue token. It's an artifact with \"{2}, Sacrifice this artifact: Draw a card.\")");
        sb.Replace("$NEVRON_DEATH_ABILITY_TEXT_SHORT", "When this creature dies, target opponent creates a Lumina token.");
        sb.Replace("$NEVRON_DEATH_ABILITY_TEXT", "When this creature dies, target opponent creates a Lumina token. $LUMINA_REMINDER_TEXT");
        sb.Replace("$EXPEDITIONER_DEATH_ABILITY_TEXT_LONG", "$EXPEDITIONER_DEATH_ABILITY_TEXT $CHROMA_REMINDER_TEXT");
        sb.Replace("$CHROMA_REMINDER_TEXT", "(It's an artifact with \"{T}, Sacrifice this artifact: Add one mana of any color. Spend this mana only to cast a Nevron, Gestral or Expeditioner spell.\")");
        sb.Replace("$LUMINA_REMINDER_TEXT", "(It's an artifact with \"{T}, Sacrifice this artifact: Scry 1.\")");
        sb.Replace("$EXPEDITIONER_TOKEN_TEXT", "\"When this creature dies, create a Chroma token.\"");
        sb.Replace("$EXPEDITIONER_DEATH_ABILITY_TEXT", "When this creature dies, create a Chroma token.");
        sb.Replace("$STORM_REMINDER_TEXT", "(When you cast this spell, copy it for each spell cast before it this turn. You may choose new targets for the copies.)");

        // Handle parameterized PICTO_REPLICATE_ABILITY and PICTO_REPLICATE_ABILITY_SHORT at the end after all other replacements
        var text = sb.ToString();
        int startIdx;
        while ((startIdx = text.IndexOf("$PICTO_REPLICATE_ABILITY_SHORT(")) != -1)
        {
            var endIdx = text.IndexOf(')', startIdx);
            if (endIdx == -1) break;

            var costValue = text.Substring(startIdx + 31, endIdx - (startIdx + 31));
            var replacement = $"""
        Learn Picto {costValue}
        """;
            text = text.Remove(startIdx, endIdx - startIdx + 1).Insert(startIdx, replacement);
        }
        while ((startIdx = text.IndexOf("$PICTO_REPLICATE_ABILITY(")) != -1)
        {
            var endIdx = text.IndexOf(')', startIdx);
            if (endIdx == -1) break;

            var costValue = text.Substring(startIdx + 25, endIdx - (startIdx + 25));
            var replacement = $"""
        Learn Picto {costValue} (Sacrifice {WordifyNumber(costValue)} Lumina tokens: Create a token copy of {thisName} attached to target creature you control. Activate this ability only if you control no token copies of {thisName}.)
        """;
            text = text.Remove(startIdx, endIdx - startIdx + 1).Insert(startIdx, replacement);
        }

        // Convert first character to uppercase
        if (text.Length > 0)
        {
            text = char.ToUpper(text[0]) + text.Substring(1);
        }
        return text;
    }

    static string WordifyNumber(string value) => value switch
    {
        "1" => "one",
        "2" => "two",
        "3" => "three",
        "4" => "four",
        "5" => "five",
        "6" => "six",
        "7" => "seven",
        "8" => "eight",
        "9" => "nine",
        "10" => "ten",
        _ => value.ToString(CultureInfo.InvariantCulture)
    };
}

/// <summary>
/// The type of this card design
/// </summary>
public enum CardFaceType
{
    Regular,
    SplitRoom,
    SplitFuse,
    Meld,
    DoubleFaced
}

/// <summary>
/// The type of split card we're dealing with
/// </summary>
public enum SplitKind
{
    Room,
    Fuse
}

public class TokenDefinition
{
    public string? Name { get; set; }

    public string? Filename { get; set; }

    public string[]? ManaCost { get; set; }

    public string[]? Types { get; set; }

    public string? PT { get; set; }

    public string[]? Oracle { get; set; }

    public string[]? ForgeScript { get; set; }

    public string[]? Colors { get; set; }

    public string? TypeLine => Types is not null ? string.Join(" ", Types) : null;

    public string? OracleTextFull => Oracle is not null ? string.Join("\n", Oracle) : null;

    public List<string> ReverseRelatedCardNames { get; } = new();

    public string? MainType
    {
        get
        {
            if (Types == null) return null;
            var ht = new HashSet<string>(Types, StringComparer.OrdinalIgnoreCase);
            if (ht.Contains("Creature")) return "Creature";
            if (ht.Contains("Instant")) return "Instant";
            if (ht.Contains("Sorcery")) return "Sorcery";
            if (ht.Contains("Enchantment")) return "Enchantment";
            if (ht.Contains("Land")) return "Land";
            if (ht.Contains("Artifact")) return "Artifact";
            return "Other";
        }
    }

    public int GetTableRow()
    {
        if (Types == null) return 2;
        var ht = new HashSet<string>(Types, StringComparer.OrdinalIgnoreCase);
        if (ht.Contains("Land")) return 0;
        if (ht.Contains("Creature")) return 1;
        if (ht.Contains("Instant") || ht.Contains("Sorcery")) return 3;
        return 2;
    }

    public static async Task<TokenDefinition> ReadAsync(string path)
    {
        var token = new TokenDefinition();
        token.Filename = Path.GetFileNameWithoutExtension(path);
        using var sr = new StreamReader(path);
        string? line;
        while ((line = await sr.ReadLineAsync()) is not null)
        {
            if (line.StartsWith("Name:"))
            {
                token.Name = line.Substring(5);
            }
            else if (line.StartsWith("ManaCost:"))
            {
                token.ManaCost = line.Substring(9).Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            else if (line.StartsWith("Types:"))
            {
                token.Types = line.Substring(6).Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            else if (line.StartsWith("PT:"))
            {
                token.PT = line.Substring(3);
            }
            else if (line.StartsWith("Oracle:"))
            {
                token.Oracle = new[] { line.Substring(7) };
            }
            else if (line.StartsWith("Colors:"))
            {
                token.Colors = line.Substring(7).Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                // Assume ForgeScript
                token.ForgeScript = (token.ForgeScript ?? []).Append(line).ToArray();
            }
        }
        return token;
    }
}

public class CardMasterDesign
{
    private CardFaceDesign _activeFace = new();

    public CardFaceDesign? FrontFull { get; set; }

    public CardFaceDesign? BackFull { get; set; }

    public CardFaceDesign? SplitLeft { get; set; }

    public CardFaceDesign? SplitRight { get; set; }

    public CardFaceDesign? MeldTarget { get; set; }

    private SplitKind? _splitKind;

    public CardFaceType? FaceType { get; set; }

    public bool IsToken { get; set; }

    public bool IsReprint => FrontFull?.IsReprint ?? false; // Only considering regular cards for reprints

    public bool IsCommander => FrontFull?.IsCommander ?? false; // Same for commander

    public string? NicknameFor => FrontFull?.NicknameFor;

    public string Rarity
    {
        get
        {
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return FaceType switch
            {
                CardFaceType.Regular => FrontFull.Rarity,
                CardFaceType.SplitRoom => SplitLeft.Rarity, // Rarity is always specified on the left face
                CardFaceType.SplitFuse => SplitLeft.Rarity, // Rarity is always specified on the left face
                CardFaceType.Meld => FrontFull.Rarity, // Rarity is always specified on the front face
                CardFaceType.DoubleFaced => FrontFull.Rarity, // Rarity is always specified on the front face
                _ => throw new UnreachableException()
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

    public bool IsValid()
    {
        return (this.FaceType.HasValue && this.Bucket is not null && this.Rarity is not null)
            || (this.IsReprint);
    }

    public IEnumerable<string> InvalidReasons
    {
        get
        {
            if (!this.IsReprint)
            {
                if (!this.FaceType.HasValue)
                    yield return "Unknown FaceType";
                if (this.Bucket is null)
                    yield return "Null Bucket";
                if (this.Rarity is null)
                    yield return "No Rarity";
            }
        }
    }

    public string Name
    {
        get
        {
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return FaceType switch
            {
                CardFaceType.Regular => FrontFull.Name,
                CardFaceType.SplitRoom => DualName(SplitLeft, SplitRight, false),
                CardFaceType.SplitFuse => DualName(SplitLeft, SplitRight, false),
                CardFaceType.Meld => DualName(FrontFull, MeldTarget, false),
                CardFaceType.DoubleFaced => DualName(FrontFull, BackFull, false),
                _ => throw new UnreachableException()
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

    string DualName(CardFaceDesign? thisFace, CardFaceDesign? otherFace, bool invariantFirst)
    {
        if (invariantFirst)
        {
            return (thisFace.InvariantName ?? thisFace.Name) + " // " + (otherFace.InvariantName ?? otherFace.Name);
        }
        else
        {
            return thisFace.Name + " // " + otherFace.Name;
        }
    }

    public string? InvariantName
    {
        get
        {
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return FaceType switch
            {
                CardFaceType.Regular => FrontFull.InvariantName,
                CardFaceType.SplitRoom => DualName(SplitLeft, SplitRight, true),
                CardFaceType.SplitFuse => DualName(SplitLeft, SplitRight, true),
                CardFaceType.Meld => DualName(FrontFull, MeldTarget, true),
                CardFaceType.DoubleFaced => DualName(FrontFull, BackFull, true),
                _ => throw new UnreachableException()
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

    public string? Bucket { get; set; }
    public string? MulticolorSubBucket { get; set; }

    public int? DraftScore => FaceType switch
    {
        CardFaceType.SplitRoom => SplitLeft?.DraftScore ?? SplitRight?.DraftScore,
        CardFaceType.SplitFuse => SplitLeft?.DraftScore ?? SplitRight?.DraftScore,
        CardFaceType.DoubleFaced => FrontFull?.DraftScore ?? BackFull?.DraftScore,
        CardFaceType.Meld => FrontFull?.DraftScore ?? MeldTarget?.DraftScore,
        _ => FrontFull?.DraftScore
    };

    public string? OracleTextFull
    {
        get
        {
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return FaceType switch
            {
                CardFaceType.Regular => FrontFull?.GetOracleText(),
                CardFaceType.SplitRoom => $"{SplitLeft?.GetOracleText()}\n---\n{SplitRight?.GetOracleText()}",
                CardFaceType.SplitFuse => $"{SplitLeft?.GetOracleText()}\n---\n{SplitRight?.GetOracleText()}",
                CardFaceType.Meld => $"{FrontFull?.GetOracleText()}\n---\n{MeldTarget?.GetOracleText()}",
                CardFaceType.DoubleFaced => $"{FrontFull?.GetOracleText()}\n---\n{BackFull?.GetOracleText()}",
                _ => null
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

    static string? ColorName(char color)
    {
        return color switch
        {
            'W' or 'w' => "WHITE",
            'U' or 'u' => "BLUE",
            'B' or 'b' => "BLACK",
            'R' or 'r' => "RED",
            'G' or 'g' => "GREEN",
            'C' or 'c' => "COLORLESS",
            _ => null
        };
    }

    public static string? ComputeMulticolorSubBucket(HashSet<char> letters)
    {
        if (letters == null || letters.Count == 0)
            return null;
        if (letters.Count >= 4)
            return "Misc";

        // Pairs
        if (letters.SetEquals(new HashSet<char> { 'U', 'W' })) return "UW";
        if (letters.SetEquals(new HashSet<char> { 'U', 'G' })) return "UG";
        if (letters.SetEquals(new HashSet<char> { 'U', 'R' })) return "UR";
        if (letters.SetEquals(new HashSet<char> { 'U', 'B' })) return "UB";
        if (letters.SetEquals(new HashSet<char> { 'B', 'R' })) return "BR";
        if (letters.SetEquals(new HashSet<char> { 'R', 'G' })) return "RG";
        if (letters.SetEquals(new HashSet<char> { 'G', 'B' })) return "GB";
        if (letters.SetEquals(new HashSet<char> { 'G', 'W' })) return "GW";
        if (letters.SetEquals(new HashSet<char> { 'R', 'W' })) return "RW";
        if (letters.SetEquals(new HashSet<char> { 'W', 'B' })) return "WB";

        // Triples
        if (letters.SetEquals(new HashSet<char> { 'U', 'R', 'W' })) return "URW";
        if (letters.SetEquals(new HashSet<char> { 'B', 'G', 'U' })) return "BGU";
        if (letters.SetEquals(new HashSet<char> { 'G', 'U', 'R' })) return "GUR";
        if (letters.SetEquals(new HashSet<char> { 'W', 'U', 'B' })) return "WUB";
        if (letters.SetEquals(new HashSet<char> { 'R', 'W', 'B' })) return "RWB";
        if (letters.SetEquals(new HashSet<char> { 'R', 'G', 'W' })) return "RGW";
        if (letters.SetEquals(new HashSet<char> { 'B', 'R', 'G' })) return "BRG";
        if (letters.SetEquals(new HashSet<char> { 'U', 'B', 'R' })) return "UBR";
        if (letters.SetEquals(new HashSet<char> { 'G', 'W', 'U' })) return "GWU";
        if (letters.SetEquals(new HashSet<char> { 'W', 'B', 'G' })) return "WBG";

        return "Misc";
    }

    public static string SubBucketFriendlyName(string code)
    {
        return code switch
        {
            "UW" => "Azorius",
            "UG" => "Simic",
            "UR" => "Izzet",
            "UB" => "Dimir",
            "BR" => "Rakdos",
            "RG" => "Gruul",
            "GB" => "Golgari",
            "GW" => "Selesnya",
            "RW" => "Boros",
            "WB" => "Orzhov",
            "URW" => "Jeskai",
            "BGU" => "Sultai",
            "GUR" => "Temur",
            "WUB" => "Esper",
            "RWB" => "Mardu",
            "RGW" => "Naya",
            "BRG" => "Jund",
            "UBR" => "Grixis",
            "GWU" => "Bant",
            "WBG" => "Abzan",
            "Misc" => "Misc",
            _ => code
        };
    }

    public static string? GetSubBucketCodeFromFriendlyName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return null;
        var candidate = name.Trim();
        var codes = new[] { "UW", "UG", "UR", "UB", "BR", "RG", "GB", "GW", "RW", "WB", "URW", "BGU", "GUR", "WUB", "RWB", "RGW", "BRG", "UBR", "GWU", "WBG", "Misc" };
        foreach (var code in codes)
        {
            var friendly = SubBucketFriendlyName(code);
            if (!string.IsNullOrEmpty(friendly) && friendly.Equals(candidate, StringComparison.OrdinalIgnoreCase))
                return code;
        }
        return null;
    }

    public record CockatriceCardFace(string Name, string Rarity, string OracleText, string Colors, string? ManaCost, int? ManaValue, string Type, string MainType, string? PT, string? Loyalty, string? RelatedCardName, bool? EntersTapped, string? Side, string[]? RelatedTokens)
    {
        public int GetTableRow() => this.MainType switch
        {
            "Land" => 0,
            "Creature" => 1,
            "Instant" => 3,
            "Sorcery" => 3,
            _ => 2
        };
    }

    public IEnumerable<string> GetCubeDraftableFaces()
    {
        if (FaceType == CardFaceType.Regular)
            yield return this.InvariantName ?? this.Name;
        else if (FaceType == CardFaceType.SplitFuse || FaceType == CardFaceType.SplitRoom)
            yield return this.InvariantName ?? this.Name;
        else if (FaceType == CardFaceType.DoubleFaced)
            yield return this.FrontFull.InvariantName ?? this.FrontFull.Name;
        else if (FaceType == CardFaceType.Meld)
            yield return this.FrontFull.InvariantName ?? this.FrontFull.Name;
    }

    public IEnumerable<CockatriceCardFace> GetCockatriceFaces()
    {
        if (FaceType == CardFaceType.Regular)
        {
            yield return new(
                // NOTE: Using invariant name as first priority for cockatrice as card images use invariant name
                // and for card images to line up properly the names must match exactly unlike forge which appears
                // to have some kind of ascii fallback.
                this.InvariantName ?? this.Name,
                this.Rarity,
                this.FrontFull.GetOracleText(),
                this.FrontFull.GetCockatriceColors(),
                this.FrontFull.GetCockatriceManaCost(),
                this.FrontFull.GetManaValue(),
                this.FrontFull.TypeLine,
                this.GetPrimaryCategory(),
                this.FrontFull.PT,
                this.FrontFull.Loyalty,
                null,
                this.FrontFull.EntersTapped,
                null,
                this.FrontFull.RelatedTokens
            );
        }
        else if (FaceType == CardFaceType.SplitFuse || FaceType == CardFaceType.SplitRoom)
        {
            var colors = new HashSet<char>();
            this.SplitLeft.PopulateColorsFromColorIdentity(colors);
            this.SplitLeft.PopulateColorsFromManaCost(colors);
            this.SplitRight.PopulateColorsFromColorIdentity(colors);
            this.SplitRight.PopulateColorsFromManaCost(colors);
            // Sort in WUBRG order
            var order = new[] { 'W', 'U', 'B', 'R', 'G' };
            var sColors = string.Join(string.Empty, colors.OrderBy(c => Array.IndexOf(order, c)));

            string[]? relatedTokens = null;
            if (FaceType == CardFaceType.SplitRoom)
            {
                relatedTokens = [.. (this.SplitLeft.RelatedTokens ?? []), .. (this.SplitRight.RelatedTokens ?? [])];
            }

            yield return new(
                // NOTE: Using invariant name as first priority for cockatrice as card images use invariant name
                // and for card images to line up properly the names must match exactly unlike forge which appears
                // to have some kind of ascii fallback.
                this.InvariantName ?? this.Name,
                this.Rarity,
                this.OracleTextFull,
                sColors,
                this.SplitLeft.GetCockatriceManaCost() + " // " + this.SplitRight.GetCockatriceManaCost(),
                this.SplitLeft.GetManaValue() + this.SplitRight.GetManaValue(),
                this.SplitLeft.TypeLine,
                this.GetPrimaryCategory(),
                null,
                null,
                null,
                null,
                null,
                relatedTokens
            );
        }
        else if (FaceType == CardFaceType.DoubleFaced)
        {
            yield return new(
                // NOTE: Using invariant name as first priority for cockatrice as card images use invariant name
                // and for card images to line up properly the names must match exactly unlike forge which appears
                // to have some kind of ascii fallback.
                this.FrontFull.InvariantName ?? this.FrontFull.Name,
                this.Rarity,
                this.FrontFull.GetOracleText(),
                this.FrontFull.GetCockatriceColors(),
                this.FrontFull.GetCockatriceManaCost(),
                this.FrontFull.GetManaValue(),
                this.FrontFull.TypeLine,
                this.GetPrimaryCategory(),
                this.FrontFull.PT,
                this.FrontFull.Loyalty,
                this.BackFull.InvariantName ?? this.BackFull.Name,
                this.FrontFull.EntersTapped,
                "front",
                this.FrontFull.RelatedTokens
            );
            yield return new(
                // NOTE: Using invariant name as first priority for cockatrice as card images use invariant name
                // and for card images to line up properly the names must match exactly unlike forge which appears
                // to have some kind of ascii fallback.
                this.BackFull.InvariantName ?? this.BackFull.Name,
                this.Rarity,
                this.BackFull.GetOracleText(),
                this.BackFull.GetCockatriceColors(),
                null, //this.BackFull.GetCockatriceManaCost(),
                null, //this.BackFull.GetManaValue(),
                this.BackFull.TypeLine,
                this.GetPrimaryCategory(),
                this.BackFull.PT,
                this.BackFull.Loyalty,
                this.FrontFull.InvariantName ?? this.FrontFull.Name,
                null,
                "back",
                this.BackFull.RelatedTokens
            );
        }
        else if (FaceType == CardFaceType.Meld)
        {
            yield return new(
                // NOTE: Using invariant name as first priority for cockatrice as card images use invariant name
                // and for card images to line up properly the names must match exactly unlike forge which appears
                // to have some kind of ascii fallback.
                this.FrontFull.InvariantName ?? this.FrontFull.Name,
                this.Rarity,
                this.FrontFull.GetOracleText(),
                this.FrontFull.GetCockatriceColors(),
                this.FrontFull.GetCockatriceManaCost(),
                this.FrontFull.GetManaValue(),
                this.FrontFull.TypeLine,
                this.GetPrimaryCategory(),
                this.FrontFull.PT,
                this.FrontFull.Loyalty,
                this.MeldTarget.InvariantName ?? this.MeldTarget.Name,
                this.FrontFull.EntersTapped,
                "front",
                this.FrontFull.RelatedTokens
            );
            yield return new(
                // NOTE: Using invariant name as first priority for cockatrice as card images use invariant name
                // and for card images to line up properly the names must match exactly unlike forge which appears
                // to have some kind of ascii fallback.
                this.MeldTarget.InvariantName ?? this.MeldTarget.Name,
                this.Rarity,
                this.MeldTarget.GetOracleText(),
                this.MeldTarget.GetCockatriceColors(),
                null, //this.MeldTarget.GetCockatriceManaCost(),
                null, //this.MeldTarget.GetManaValue(),
                this.MeldTarget.TypeLine,
                this.GetPrimaryCategory(),
                this.MeldTarget.PT,
                this.MeldTarget.Loyalty,
                null,
                null,
                "back",
                this.MeldTarget.RelatedTokens
            );
        }
    }

    internal (bool isBasic, char? pip) IsBasicLand()
    {
        return this.Name switch
        {
            "Forest" => (true, 'G'),
            "Island" => (true, 'U'),
            "Mountain" => (true, 'R'),
            "Plains" => (true, 'W'),
            "Swamp" => (true, 'B'),
            _ => (false, null)
        };
    }

    internal int GetManaValueForStats()
    {
        if (this.FaceType == CardFaceType.SplitFuse || this.FaceType == CardFaceType.SplitRoom)
        {
            var left = this.SplitLeft?.GetManaValue() ?? 0;
            var right = this.SplitRight?.GetManaValue() ?? 0;
            return left + right;
        }
        else
        {
            return this.FrontFull?.GetManaValue() ?? 0;
        }
    }

    internal CardMasterDesign Finalize()
    {
        if (!_splitKind.HasValue)
        {
            if (MeldTarget is not null)
            {
                FaceType = CardFaceType.Meld;
            }
            else if (BackFull is not null)
            {
                FaceType = CardFaceType.DoubleFaced;
            }
            else
            {
                FrontFull = _activeFace;
                FaceType = CardFaceType.Regular;
            }
        }
        else
        {
            FaceType = _splitKind.Value switch
            {
                SplitKind.Fuse when SplitLeft is not null && SplitRight is not null => CardFaceType.SplitFuse,
                SplitKind.Room when SplitLeft is not null && SplitRight is not null => CardFaceType.SplitRoom,
                _ => throw new UnreachableException()
            };
        }

        // Determine bucket
        var colors = new HashSet<string>();

        IEnumerable<CardFaceDesign?> faces = [FrontFull, SplitLeft, SplitRight]; // Omitting MeldTarget as we determine bucket based on its front face
        foreach (var face in faces)
        {
            if (face is null)
                continue;

            // Check cost
            if (face.ManaCost != null)
            {
                foreach (var token in face.ManaCost)
                {
                    if (!token.All(char.IsDigit))
                    {
                        if (token.Length == 1) // Single-color symbol
                        {
                            var color = ColorName(token[0]);
                            if (color is not null)
                                colors.Add(color);
                        }
                        else if (token.Length == 2) // Hybrid symbol
                        {
                            var color1 = ColorName(token[0]);
                            var color2 = ColorName(token[1]);
                            if (color1 is not null)
                                colors.Add(color1);
                            if (color2 is not null)
                                colors.Add(color2);
                        }
                    }
                }
            }
            // Check color identity
            if (face.ColorIdentity is not null)
            {
                foreach (var color in face.ColorIdentity)
                {
                    switch (color.ToUpperInvariant())
                    {
                        case "WHITE":
                        case "BLUE":
                        case "BLACK":
                        case "RED":
                        case "GREEN":
                            colors.Add(color.ToUpperInvariant());
                            break;
                    }
                }
            }
        }

        if (colors.Count > 0)
        {
            if (colors.Count > 1)
                this.Bucket = "MULTICOLOR";
            else
                this.Bucket = colors.First();

            if (this.Bucket == "MULTICOLOR")
            {
                // Build a set of single-letter color codes, ignoring COLORLESS
                var letters = new HashSet<char>();
                foreach (var c in colors)
                {
                    if (c == "COLORLESS")
                        continue;
                    switch (c)
                    {
                        case "WHITE": letters.Add('W'); break;
                        case "BLUE": letters.Add('U'); break;
                        case "BLACK": letters.Add('B'); break;
                        case "RED": letters.Add('R'); break;
                        case "GREEN": letters.Add('G'); break;
                    }
                }
                this.MulticolorSubBucket = ComputeMulticolorSubBucket(letters);
            }
        }
        // There are no split/meld artifact or colorless cards, so if no color identity could be determined it is 99% should be a regular card
        else if (this.FrontFull is not null)
        {
            var (isBasic, pip) = this.IsBasicLand();
            if (isBasic)
            {
                this.Bucket = "LANDS";
                this.FrontFull.Types = ["Basic", "Land", this.FrontFull.Name];
                this.FrontFull.TypeLine = CardFaceDesign.BuildTypeLine(this.FrontFull.Types);
                this.FrontFull.Rarity = "C";
                this.FrontFull.Oracle = ["({T}: Add {" + pip + "}.)"];
            }
            else
            {
                if (this.FrontFull.Types?.Contains("Land") == true)
                    this.Bucket = "LANDS";
                else if (this.FrontFull.Types?.Contains("Artifact") == true)
                    this.Bucket = "ARTIFACTS";
            }
        }

        return this;
    }

    public void MarkRoom()
    {
        this.SplitLeft = _activeFace;
        _activeFace = new();
        this.SplitRight = _activeFace;
        _splitKind = SplitKind.Room;
    }

    public void MarkFused()
    {
        this.SplitLeft = _activeFace;
        _activeFace = new();
        this.SplitRight = _activeFace;
        _splitKind = SplitKind.Fuse;
    }

    public void MarkMeld()
    {
        this.FrontFull = _activeFace;
        _activeFace = new();
        this.MeldTarget = _activeFace;
    }

    public void MarkDfc()
    {
        this.FrontFull = _activeFace;
        _activeFace = new();
        this.BackFull = _activeFace;
    }

    public void Apply(string propertyName, IEnumerable<string> buffer)
    {
        _activeFace.Apply(propertyName, buffer);
    }

    public static async Task<CardMasterDesign> ReadAsync(DirectoryInfo baseDir, string path)
    {
        var card = new CardMasterDesign();
        using var sr = new StreamReader(path);
        var line = await sr.ReadLineAsync();
        var buffer = new List<string>();
        string? activePropertyName = null;
        while (line is not null)
        {
            switch (line)
            {
                case "[Name]":
                case "[InvariantName]":
                case "[Rarity]":
                case "[Artist]":
                case "[ArtNotes]":
                case "[ManaCost]":
                case "[ColorIdentity]":
                case "[Types]":
                case "[PT]":
                case "[ForgeScript]":
                case "[Oracle]":
                case "[AbilityWords]":
                case "[FlavorText]":
                case "[DesignNotes]":
                case "[Rulings]":
                case "[Bugs]":
                case "[Loyalty]":
                case "[Colors]":
                case "[IsReprint]":
                case "[IsCommander]":
                case "[NicknameFor]":
                case "[EntersTapped]":
                case "[RelatedTokens]":
                case "[DraftScore]":
                case "[Tags]":
                case "[Cycle]":
                    // Apply the collected buffer for the previous property name
                    if (activePropertyName != null)
                    {
                        card.Apply(activePropertyName, buffer);
                    }
                    buffer.Clear();
                    activePropertyName = line.Substring(1, line.Length - 2);
                    break;
                case "ALTERNATE:ROOM": // Signal start of new active face
                    // Apply remaining buffer
                    FlushRemainingBuffer();
                    card.MarkRoom();
                    break;
                case "ALTERNATE:FUSE": // Signal start of new active face
                    // Apply remaining buffer
                    FlushRemainingBuffer();
                    card.MarkFused();
                    break;
                case "ALTERNATE:MELD": // Signal start of new active face
                    // Apply remaining buffer
                    FlushRemainingBuffer();
                    card.MarkMeld();
                    break;
                case "ALTERNATE:DFC": // Signal start of DFC
                    FlushRemainingBuffer();
                    card.MarkDfc();
                    break;
                default:
                    buffer.Add(line);
                    break;
            }
            line = await sr.ReadLineAsync();
        }

        // Apply remaining buffer
        FlushRemainingBuffer();

        return card.Finalize();

        void FlushRemainingBuffer()
        {
            if (buffer.Count > 0 && activePropertyName != null)
            {
                card.Apply(activePropertyName, buffer);
            }
        }
    }

    internal async Task WriteScriptAsync(DirectoryInfo cardsDir, DirectoryInfo tokensDir, TextWriter stdout, TextWriter stderr)
    {
        var scriptName = this.ScriptName;
        var firstLetter = scriptName.First();
        var fileName = Path.Combine(cardsDir.FullName, $"{firstLetter}", $"{scriptName}.txt");
        var fi = new FileInfo(fileName);
        if (fi.Directory is not null && !fi.Directory.Exists)
            fi.Directory.Create();
        using var fw = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
        using var sw = new StreamWriter(fw);

        switch (FaceType)
        {
            case CardFaceType.Regular:
                {
                    await FrontFull.WriteScriptAsync(sw, stdout, stderr, FaceType.Value);
                }
                break;
            case CardFaceType.SplitFuse:
            case CardFaceType.SplitRoom:
                {
                    await SplitLeft.WriteScriptAsync(sw, stdout, stderr, FaceType.Value);
                    await sw.WriteLineAsync();
                    await sw.WriteLineAsync();
                    await sw.WriteLineAsync("ALTERNATE");
                    await sw.WriteLineAsync();
                    if (FaceType == CardFaceType.SplitFuse)
                        await SplitRight.WriteScriptAsync(sw, stdout, stderr, CardFaceType.Regular); // Fuse reminder text only needs to be on one side
                    else
                        await SplitRight.WriteScriptAsync(sw, stdout, stderr, FaceType.Value);
                }
                break;
            case CardFaceType.DoubleFaced:
                {
                    await FrontFull.WriteScriptAsync(sw, stdout, stderr, FaceType.Value);
                    await sw.WriteLineAsync();
                    await sw.WriteLineAsync();
                    await sw.WriteLineAsync("ALTERNATE");
                    await sw.WriteLineAsync();
                    await BackFull.WriteScriptAsync(sw, stdout, stderr, FaceType.Value);
                }
                break;
            case CardFaceType.Meld:
                {
                    await FrontFull.WriteScriptAsync(sw, stdout, stderr, FaceType.Value);
                    await sw.WriteLineAsync();
                    await sw.WriteLineAsync();
                    await sw.WriteLineAsync("ALTERNATE");
                    await sw.WriteLineAsync();
                    await MeldTarget.WriteScriptAsync(sw, stdout, stderr, FaceType.Value);
                }
                break;
        }

        await stdout.WriteLineAsync($"Wrote: {fileName}");
    }

    public string ScriptName
    {
        get
        {
            return (this.InvariantName ?? this.Name).ToLower().Replace(" // ", "_").Replace("-", "_").Replace(":", "").Replace("'", "").Replace("!", "").Replace(",", "").Replace(" ", "_");
        }
    }

    public IEnumerable<string> AllDesignNotes => [.. FrontFull?.DesignNotes ?? [], .. SplitLeft?.DesignNotes ?? [], .. SplitRight?.DesignNotes ?? [], .. MeldTarget?.DesignNotes ?? [], .. BackFull?.DesignNotes ?? []];

    public IEnumerable<string> AllExtraNotes => [.. FrontFull?.ExtraNotes ?? [], .. SplitLeft?.ExtraNotes ?? [], .. SplitRight?.ExtraNotes ?? [], .. MeldTarget?.ExtraNotes ?? [], .. BackFull?.ExtraNotes ?? []];

    public IEnumerable<string> AllCycles => [.. FrontFull?.Cycle ?? [], .. SplitLeft?.Cycle ?? [], .. SplitRight?.Cycle ?? [], .. MeldTarget?.Cycle ?? [], .. BackFull?.Cycle ?? []];

    internal async Task WriteDocAsync(string baseDir, TextWriter writer, TextWriter stdout, TextWriter stderr)
    {
        if (!this.AllDesignNotes.Any())
        {
            await stderr.WriteLineAsync($"Warning: No design notes found for card '{this.Name}'");
        }

        if (this.IsReprint)
        {
            if (this.NicknameFor is not null)
            {
                await writer.WriteLineAsync($"## {this.Name} ({this.NicknameFor})");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync($"> This card is a nicknamed reprint of ({this.NicknameFor})");
                await writer.WriteLineAsync($"[Scryfall](https://scryfall.com/search?q={Uri.EscapeDataString(this.NicknameFor)})");
            }
            else
            {
                await writer.WriteLineAsync($"## {this.Name}");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("> This card is a reprint");
                await writer.WriteLineAsync($"[Scryfall](https://scryfall.com/search?q={Uri.EscapeDataString(this.Name)})");
            }
            await WriteNotesAsync(writer, this.AllDesignNotes, "Notes");

        }
        else
        {
            await writer.WriteLineAsync($"## {this.Name}");
            await writer.WriteLineAsync();
            var normBaseDir = baseDir.Replace("\\", "/");
            var scriptName = this.ScriptName + ".txt";
            var firstLetter = scriptName.First();
            switch (this.FaceType)
            {
                case CardFaceType.Regular:
                    {
                        await writer.WriteLineAsync("```");
                        if (FrontFull?.ManaCost is not null)
                            await writer.WriteLineAsync(FrontFull.FormatManaCost());
                        await writer.WriteLineAsync(FrontFull.TypeLine);
                        await writer.WriteLineAsync(FrontFull.GetOracleText());
                        if (FrontFull.FlavorText is not null)
                        {
                            await writer.WriteLineAsync("---");
                            await writer.WriteLineAsync(FrontFull.FlavorTextFull);
                        }
                        if (FrontFull.PT is not null)
                        {
                            await writer.WriteLineAsync();
                            await writer.WriteLineAsync(FrontFull.PT);
                        }
                        await writer.WriteLineAsync("```");
                        await writer.WriteLineAsync();

                        if (FrontFull?.ForgeScript is null)
                            await writer.WriteLineAsync("> This card is not yet implemented in Forge");
                        else
                            await writer.WriteLineAsync($"[card implementation]({normBaseDir}/{firstLetter}/{scriptName})");

                        await WriteNotesAsync(writer, this.AllDesignNotes);
                        await WriteNotesAsync(writer, this.AllExtraNotes, "Rulings");
                    }
                    break;
                case CardFaceType.SplitFuse:
                case CardFaceType.SplitRoom:
                    {
                        await writer.WriteLineAsync("```");
                        IEnumerable<CardFaceDesign?> faces = [SplitLeft, SplitRight];
                        foreach (var face in faces)
                        {
                            await writer.WriteLineAsync(face.Name);
                            if (face?.ManaCost is not null)
                                await writer.WriteLineAsync(face.FormatManaCost());
                            await writer.WriteLineAsync(face.TypeLine);
                            await writer.WriteLineAsync(face.GetOracleText());
                            if (face.PT is not null)
                            {
                                await writer.WriteLineAsync();
                                await writer.WriteLineAsync(face.PT);
                            }
                            await writer.WriteLineAsync();
                        }
                        if (this.FaceType == CardFaceType.SplitFuse)
                        {
                            await writer.WriteLineAsync("Fuse (You may cast one or both halves of this card from your hand.)");
                        }
                        await writer.WriteLineAsync("```");
                        await writer.WriteLineAsync();
                        if (SplitLeft?.ForgeScript is null || SplitRight?.ForgeScript is null)
                            await writer.WriteLineAsync("> This card is not yet implemented in Forge");
                        else
                            await writer.WriteLineAsync($"[card implementation]({normBaseDir}/{firstLetter}/{scriptName})");

                        await WriteNotesAsync(writer, this.AllDesignNotes);
                        await WriteNotesAsync(writer, this.AllExtraNotes, "Rulings");
                    }
                    break;
                case CardFaceType.Meld:
                case CardFaceType.DoubleFaced:
                    {
                        await writer.WriteLineAsync("```");
                        if (FrontFull?.ManaCost is not null)
                            await writer.WriteLineAsync(FrontFull.FormatManaCost());
                        await writer.WriteLineAsync(FrontFull.TypeLine);
                        await writer.WriteLineAsync(FrontFull.GetOracleText());
                        if (FrontFull.PT is not null)
                        {
                            await writer.WriteLineAsync();
                            await writer.WriteLineAsync(FrontFull.PT);
                        }
                        await writer.WriteLineAsync("```");
                        await writer.WriteLineAsync();
                        if (this.FaceType == CardFaceType.Meld)
                            await writer.WriteLineAsync("Melds into:");
                        else if (this.FaceType == CardFaceType.DoubleFaced)
                            await writer.WriteLineAsync("Transforms into:");
                        await writer.WriteLineAsync();
                        await writer.WriteLineAsync("```");
                        if (this.FaceType == CardFaceType.Meld)
                        {
                            if (MeldTarget?.ManaCost is not null)
                                await writer.WriteLineAsync(MeldTarget.FormatManaCost());
                            await writer.WriteLineAsync(MeldTarget.TypeLine);
                            await writer.WriteLineAsync(MeldTarget.GetOracleText());
                        }
                        else if (this.FaceType == CardFaceType.DoubleFaced)
                        {
                            if (BackFull?.ManaCost is not null)
                                await writer.WriteLineAsync(BackFull.FormatManaCost());
                            await writer.WriteLineAsync(BackFull.TypeLine);
                            await writer.WriteLineAsync(BackFull.GetOracleText());
                        }
                        if (this.FaceType == CardFaceType.Meld && MeldTarget.PT is not null)
                        {
                            await writer.WriteLineAsync();
                            await writer.WriteLineAsync(MeldTarget.PT);
                        }
                        else if (this.FaceType == CardFaceType.DoubleFaced && BackFull?.PT is not null)
                        {
                            await writer.WriteLineAsync();
                            await writer.WriteLineAsync(BackFull.PT);
                        }
                        await writer.WriteLineAsync("```");

                        await writer.WriteLineAsync();
                        if (FrontFull?.ForgeScript is null || (this.FaceType == CardFaceType.Meld && MeldTarget?.ForgeScript is null) || (this.FaceType == CardFaceType.DoubleFaced && BackFull?.ForgeScript is null))
                            await writer.WriteLineAsync("> This card is not yet implemented in Forge");
                        else
                            await writer.WriteLineAsync($"[card implementation]({normBaseDir}/{firstLetter}/{scriptName})");

                        await WriteNotesAsync(writer, this.AllDesignNotes);
                        await WriteNotesAsync(writer, this.AllExtraNotes, "Rulings");
                    }
                    break;
            }
        }

        static async Task WriteNotesAsync(TextWriter writer, IEnumerable<string> notes, string heading = "Design Notes")
        {
            if (!notes.Any())
                return;

            await writer.WriteLineAsync();
            await writer.WriteLineAsync($"### {heading}");
            await writer.WriteLineAsync();
            foreach (var n in notes)
            {
                await writer.WriteLineAsync(n);
            }
            await writer.WriteLineAsync();
        }
    }

    internal string GetArtist()
    {
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8601 // Possible null reference assignment.
        return FaceType switch
        {
            CardFaceType.Regular => FrontFull.Artist,
            CardFaceType.SplitRoom => string.Join(" & ", new string[] { SplitLeft.Artist, SplitRight.Artist }.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct()),
            CardFaceType.SplitFuse => string.Join(" & ", new string[] { SplitLeft.Artist, SplitRight.Artist }.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct()),
            CardFaceType.Meld => string.Join(" & ", new string[] { FrontFull.Artist, MeldTarget.Artist }.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct()),
            CardFaceType.DoubleFaced => string.Join(" & ", new string[] { FrontFull.Artist, BackFull.Artist }.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct()),
            _ => throw new UnreachableException()
        };
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
    }

    internal async Task WriteBugsAsync(StreamWriter sw)
    {
        List<string> bugs = [.. FrontFull?.Bugs ?? [], .. SplitLeft?.Bugs ?? [], .. SplitRight?.Bugs ?? [], .. MeldTarget?.Bugs ?? []];
        if (bugs.Count > 0)
        {
            await sw.WriteLineAsync($"## {this.Name}");
            await sw.WriteLineAsync();
            foreach (var line in bugs)
            {
                await sw.WriteLineAsync(line);
            }
            await sw.WriteLineAsync();
        }
    }

    internal IEnumerable<string> GetImageNames()
    {
        switch (FaceType)
        {
            case CardFaceType.Regular:
                yield return (this.InvariantName ?? this.Name) + ".full.jpg";
                break;
            case CardFaceType.SplitFuse:
            case CardFaceType.SplitRoom:
                yield return (this.InvariantName ?? this.Name).Replace(" // ", "") + ".full.jpg";
                break;
            case CardFaceType.DoubleFaced:
                yield return (this.FrontFull.InvariantName ?? this.FrontFull.Name) + ".full.jpg";
                yield return (this.BackFull.InvariantName ?? this.BackFull.Name) + ".full.jpg";
                break;
            case CardFaceType.Meld:
                yield return (this.FrontFull.InvariantName ?? this.FrontFull.Name) + ".full.jpg";
                yield return (this.MeldTarget.InvariantName ?? this.MeldTarget.Name) + ".full.jpg";
                break;
        }
    }

    public string GetPrimaryCategory()
    {
        CardFaceDesign? face = this.FaceType switch
        {
            CardFaceType.SplitFuse or CardFaceType.SplitRoom => this.SplitLeft,
            CardFaceType.Meld or CardFaceType.DoubleFaced => this.FrontFull,
            _ => this.FrontFull
        };

        if (face?.Types != null)
        {
            var ht = new HashSet<string>(face.Types, StringComparer.OrdinalIgnoreCase);
            if (ht.Contains("Creature")) return "Creature";
            if (ht.Contains("Instant")) return "Instant";
            if (ht.Contains("Sorcery")) return "Sorcery";
            if (ht.Contains("Enchantment")) return "Enchantment";
            if (ht.Contains("Land")) return "Land";
            if (ht.Contains("Artifact")) return "Artifact";
        }
        return "Other";
    }

    IEnumerable<string> AllTags => [
        ..FrontFull?.Tags ?? [],
        ..BackFull?.Tags ?? [],
        ..MeldTarget?.Tags ?? [],
        ..SplitLeft?.Tags ?? [],
        ..SplitRight?.Tags ?? []
    ];

    internal IEnumerable<string> Tags => AllTags.Distinct();

    internal bool HasAnyTag(string[] tags)
    {
        if (tags.Length == 0)
            return true;
        return AllTags.Intersect(tags).Any();
    }
}

public enum StatsType
{
    Bucket,
    PrimaryType,
    ManaCurve
}

public static class StatsPrinter
{
    public static string BuildBucketTable(SortedDictionary<string, CardMasterDesign> cards, bool showEmptyRows = false)
    {
        var rarityCodes = new[] { "C", "U", "R", "M", "?" }; // ? == unknown
        var distro = new SortedDictionary<string, Dictionary<string, int>>(StringComparer.OrdinalIgnoreCase);
        var multicolorSubDistro = new Dictionary<string, Dictionary<string, int>>(StringComparer.OrdinalIgnoreCase);
        var rarityTotals = rarityCodes.ToDictionary(r => r, r => 0);
        int overallTotal = 0;

        foreach (var (_, card) in cards)
        {
            overallTotal++;

            var r = card.Rarity ?? "?";
            if (r.Length != 1 || (r != "C" && r != "U" && r != "R" && r != "M"))
                r = "?";
            rarityTotals[r]++;

            var b = card.Bucket ?? "UNKNOWN";
            if (!distro.TryGetValue(b, out var map))
            {
                map = rarityCodes.ToDictionary(rr => rr, rr => 0);
                distro[b] = map;
            }
            map[r]++;

            if (b.Equals("MULTICOLOR", StringComparison.OrdinalIgnoreCase))
            {
                var sub = card.MulticolorSubBucket ?? "Misc";
                if (!multicolorSubDistro.TryGetValue(sub, out var smap))
                {
                    smap = rarityCodes.ToDictionary(rr => rr, rr => 0);
                    multicolorSubDistro[sub] = smap;
                }
                smap[r]++;
            }
        }

        var canonicalBuckets = new[] { "WHITE", "BLUE", "BLACK", "RED", "GREEN", "MULTICOLOR", "LANDS", "ARTIFACTS", "UNKNOWN" };
        var pairOrder = new[] { "UW", "UG", "UR", "UB", "BR", "RG", "GB", "GW", "RW", "WB" };
        var tripleOrder = new[] { "URW", "BGU", "GUR", "WUB", "RWB", "RGW", "BRG", "UBR", "GWU", "WBG" };

        if (showEmptyRows)
        {
            foreach (var cb in canonicalBuckets)
            {
                if (!distro.ContainsKey(cb))
                    distro[cb] = rarityCodes.ToDictionary(rr => rr, rr => 0);
            }
            foreach (var code in pairOrder.Concat(tripleOrder).Concat(new[] { "Misc" }))
            {
                if (!multicolorSubDistro.ContainsKey(code))
                    multicolorSubDistro[code] = rarityCodes.ToDictionary(rr => rr, rr => 0);
            }
        }

        // Prepare a simple aligned table
        var subLabels = multicolorSubDistro.Keys.Select(k => $"  {k} ({CardMasterDesign.SubBucketFriendlyName(k)})").ToList();
        int nameWidth = Math.Max(6, Math.Max(distro.Keys.Select(k => k.Length).DefaultIfEmpty(6).Max(), subLabels.Select(s => s.Length).DefaultIfEmpty(0).Max()));
        var sb = new StringBuilder();

        // Header
        sb.Append(' ', 0);
        sb.Append("Bucket".PadRight(nameWidth + 2));
        sb.Append("| ");
        sb.Append(String.Join(" | ", rarityCodes.Select(rc => rc.PadLeft(3))));
        sb.Append(" | Tot (%)\n");

        // Separator
        sb.Append(new string('-', nameWidth + 2));
        sb.Append("|-----|-----|-----|-----|-----|-----\n");

        IEnumerable<string> bucketOrder = showEmptyRows ? canonicalBuckets : distro.Keys;

        // Rows per bucket
        foreach (var bucket in bucketOrder)
        {
            var map = distro.ContainsKey(bucket) ? distro[bucket] : rarityCodes.ToDictionary(rr => rr, rr => 0);
            var rowTotal = map.Values.Sum();
            if (!showEmptyRows && rowTotal == 0)
                continue;
            double pct = overallTotal > 0 ? (100.0 * rowTotal / overallTotal) : 0.0;
            sb.Append(bucket.PadRight(nameWidth + 2));
            sb.Append("| ");
            sb.Append(String.Join(" | ", rarityCodes.Select(rc => map.ContainsKey(rc) ? map[rc].ToString().PadLeft(3) : "  0")));
            sb.Append($" | {rowTotal} ({pct:F1}%)\n");

            if (bucket.Equals("MULTICOLOR", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var code in pairOrder.Concat(tripleOrder).Concat(new[] { "Misc" }))
                {
                    var smap = multicolorSubDistro.ContainsKey(code) ? multicolorSubDistro[code] : rarityCodes.ToDictionary(rr => rr, rr => 0);
                    var sTotal = smap.Values.Sum();
                    if (!showEmptyRows && sTotal == 0)
                        continue;
                    var label = $"  {code} ({CardMasterDesign.SubBucketFriendlyName(code)})";
                    sb.Append(label.PadRight(nameWidth + 2));
                    sb.Append("| ");
                    sb.Append(String.Join(" | ", rarityCodes.Select(rc => smap.ContainsKey(rc) ? smap[rc].ToString().PadLeft(3) : "  0")));
                    sb.Append($" | {sTotal}\n");
                }
            }
        }

        // Totals row
        sb.Append(new string('-', nameWidth + 2));
        sb.Append("|-----|-----|-----|-----|-----|-----\n");
        sb.Append("Total".PadRight(nameWidth + 2));
        sb.Append("| ");
        sb.Append(String.Join(" | ", rarityCodes.Select(rc => rarityTotals[rc].ToString().PadLeft(3))));
        sb.Append($" | {overallTotal} (100.0%)\n\n");

        var result = new StringBuilder();
        result.AppendLine("Rarity distribution by bucket:");
        result.Append(sb.ToString());
        return result.ToString();
    }

    public static string BuildTypeTable(SortedDictionary<string, CardMasterDesign> cards, bool showEmptyRows = false)
    {
        var rarityCodes = new[] { "C", "U", "R", "M", "?" };
        var typeCategories = new[] { "Creature", "Instant", "Sorcery", "Enchantment", "Land", "Artifact", "Other" };

        var typeDistro = new SortedDictionary<string, Dictionary<string, int>>(StringComparer.OrdinalIgnoreCase);
        foreach (var t in typeCategories)
        {
            typeDistro[t] = rarityCodes.ToDictionary(rc => rc, rc => 0);
        }

        int overallTotal = 0;
        foreach (var (_, card) in cards)
        {
            overallTotal++;
            var cat = card.GetPrimaryCategory();
            var r = card.Rarity ?? "?";
            if (r.Length != 1 || (r != "C" && r != "U" && r != "R" && r != "M"))
                r = "?";

            if (!typeDistro.ContainsKey(cat))
                cat = "Other";

            typeDistro[cat][r]++;
        }

        // Build table string
        var tbl = new StringBuilder();
        // Header
        tbl.Append(' ', 0);
        tbl.Append("Type".PadRight(Math.Max(6, typeCategories.Select(t => t.Length).Max()) + 2));
        tbl.Append("| ");
        tbl.Append(String.Join(" | ", rarityCodes.Select(rc => rc.PadLeft(3))));
        tbl.Append(" | Tot (% )\n\n");

        // Separator
        tbl.Append(new string('-', Math.Max(6, typeCategories.Select(t => t.Length).Max()) + 2));
        tbl.Append("|-----|-----|-----|-----|-----|-----\n");

        var grandTotalFromType = typeDistro.Values.Select(m => m.Values.Sum()).Sum();
        foreach (var t in typeCategories)
        {
            var map = typeDistro[t];
            var rowTotal = map.Values.Sum();

            if (!showEmptyRows && rowTotal == 0)
                continue;

            tbl.Append(t.PadRight(Math.Max(6, typeCategories.Select(tt => tt.Length).Max()) + 2));
            tbl.Append("| ");
            tbl.Append(String.Join(" | ", rarityCodes.Select(rc => map.ContainsKey(rc) ? map[rc].ToString().PadLeft(3) : "  0")));
            double pct = grandTotalFromType > 0 ? (100.0 * rowTotal / grandTotalFromType) : 0.0;
            tbl.Append($" | {rowTotal.ToString().PadLeft(3)} ({pct:F1}%)\n");
        }

        // Totals row
        tbl.Append(new string('-', Math.Max(6, typeCategories.Select(tt => tt.Length).Max()) + 2));
        tbl.Append("|-----|-----|-----|-----|-----|-----\n");
        tbl.Append("Total".PadRight(Math.Max(6, typeCategories.Select(tt => tt.Length).Max()) + 2));
        tbl.Append("| ");
        tbl.Append(String.Join(" | ", rarityCodes.Select(rc => typeDistro.Values.Sum(m => m.ContainsKey(rc) ? m[rc] : 0).ToString().PadLeft(3))));
        tbl.Append($" | {grandTotalFromType}\n\n");

        var result = new StringBuilder();
        result.AppendLine("Count by primary type (rows = type, cols = rarity):");
        result.Append(tbl.ToString());
        result.AppendLine($"Grand total (by type sum): {grandTotalFromType}");
        if (grandTotalFromType == overallTotal)
            result.AppendLine($"Sanity check: OK (matches rarity total {overallTotal})");
        else
            result.AppendLine($"Sanity check: MISMATCH - type grand total {grandTotalFromType} != rarity grand total {overallTotal}");

        return result.ToString();
    }

    public static string BuildManaCurveTable(SortedDictionary<string, CardMasterDesign> cards, bool showEmptyRows = false)
    {
        var rarityCodes = new[] { "C", "U", "R", "M", "?" };
        var distro = new SortedDictionary<int, Dictionary<string, int>>();
        var rarityTotals = rarityCodes.ToDictionary(r => r, r => 0);
        int overallTotal = 0;
        int maxMV = 0;
        long weightedSum = 0;

        foreach (var (_, card) in cards)
        {
            overallTotal++;
            var r = card.Rarity ?? "?";
            if (r.Length != 1 || (r != "C" && r != "U" && r != "R" && r != "M"))
                r = "?";
            rarityTotals[r]++;

            var mv = card.GetManaValueForStats();
            if (!distro.TryGetValue(mv, out var map))
            {
                map = rarityCodes.ToDictionary(rr => rr, rr => 0);
                distro[mv] = map;
            }
            map[r]++;
            weightedSum += mv;
            if (mv > maxMV) maxMV = mv;
        }

        if (showEmptyRows)
        {
            for (int i = 0; i <= maxMV; i++)
            {
                if (!distro.ContainsKey(i))
                    distro[i] = rarityCodes.ToDictionary(rr => rr, rr => 0);
            }
        }

        var nameWidth = Math.Max(6, Math.Max(distro.Keys.Select(k => k.ToString().Length).DefaultIfEmpty(1).Max(), 6));
        var sb = new StringBuilder();

        // Header
        sb.Append(' ', 0);
        sb.Append("Mana".PadRight(nameWidth + 2));
        sb.Append("| ");
        sb.Append(String.Join(" | ", rarityCodes.Select(rc => rc.PadLeft(3))));
        sb.Append(" | Tot (%)\n");

        // Separator
        sb.Append(new string('-', nameWidth + 2));
        sb.Append("|-----|-----|-----|-----|-----|-----\n");

        foreach (var mv in distro.Keys.OrderBy(k => k))
        {
            var map = distro[mv];
            var rowTotal = map.Values.Sum();
            if (!showEmptyRows && rowTotal == 0)
                continue;
            double pct = overallTotal > 0 ? (100.0 * rowTotal / overallTotal) : 0.0;
            sb.Append(mv.ToString().PadRight(nameWidth + 2));
            sb.Append("| ");
            sb.Append(String.Join(" | ", rarityCodes.Select(rc => map.ContainsKey(rc) ? map[rc].ToString().PadLeft(3) : "  0")));
            sb.Append($" | {rowTotal} ({pct:F1}%)\n");
        }

        // Totals row
        sb.Append(new string('-', nameWidth + 2));
        sb.Append("|-----|-----|-----|-----|-----|-----\n");
        sb.Append("Total".PadRight(nameWidth + 2));
        sb.Append("| ");
        sb.Append(String.Join(" | ", rarityCodes.Select(rc => rarityTotals[rc].ToString().PadLeft(3))));
        sb.Append($" | {overallTotal} (100.0%)\n\n");

        // Average mana value (weighted by number of cards at each mana value)
        double average = overallTotal > 0 ? (double)weightedSum / overallTotal : 0.0;
        sb.AppendLine($"Average mana value: {average:F2}\n");

        var result = new StringBuilder();
        result.AppendLine("Mana curve by mana value (rows = mana value, cols = rarity):");
        result.Append(sb.ToString());
        return result.ToString();
    }

    public static string BuildStats(SortedDictionary<string, CardMasterDesign> cards, bool showEmptyRows = false)
    {
        var sb = new StringBuilder();
        sb.AppendLine(BuildBucketTable(cards, showEmptyRows));
        sb.AppendLine(BuildTypeTable(cards, showEmptyRows));
        return sb.ToString();
    }
}

public abstract class BaseCommand
{
    public abstract required DirectoryInfo BaseDirectory { get; set; }

    public Task<int> RunAsync(CliContext context) => ExecuteAsync(context, Console.Out, Console.Error);

    protected abstract Task<int> ExecuteAsync(CliContext context, TextWriter stdout, TextWriter stderr);

    protected async Task<SortedDictionary<string, CardMasterDesign>> ReadCardDesignsAsync(TextWriter stdout, TextWriter stderr, bool silent = false)
    {
        var subDirs = this.BaseDirectory.GetDirectories();
        var designDir = subDirs.FirstOrDefault(d => d.Name == "design");
        if (designDir is null)
            throw new InvalidOperationException("Design dir not found");

        var cards = new SortedDictionary<string, CardMasterDesign>();
        foreach (var scriptFile in Directory.EnumerateFiles(designDir.FullName, "*.txt", SearchOption.AllDirectories))
        {
            //if (!scriptFile.EndsWith("when_one_falls_we_continue.txt"))
            //    continue;
            if (!silent)
                await stdout.WriteLineAsync($"Processing: {scriptFile}");
            var card = await CardMasterDesign.ReadAsync(this.BaseDirectory, scriptFile);
            if (card.IsValid())
                cards.Add(card.Name, card);
            else
                await stderr.WriteLineAsync($"Card script ({card.Name}) not valid! ({string.Join(", ", card.InvalidReasons)})");
        }

        await stdout.WriteLineAsync($"Read: {cards.Count} cards");
        return cards;
    }

    protected async Task<SortedDictionary<string, TokenDefinition>> ReadTokensAsync(SortedDictionary<string, CardMasterDesign> cards, TextWriter stdout, TextWriter stderr)
    {
        var subDirs = this.BaseDirectory.GetDirectories();
        var tokensDir = subDirs.FirstOrDefault(d => d.Name == "tokens");
        if (tokensDir is null)
            throw new InvalidOperationException("Tokens dir not found");

        var tokensByScript = new Dictionary<string, TokenDefinition>();
        var tokens = new SortedDictionary<string, TokenDefinition>();
        foreach (var tokenFile in Directory.EnumerateFiles(tokensDir.FullName, "*.txt", SearchOption.AllDirectories))
        {
            await stdout.WriteLineAsync($"Processing token: {tokenFile}");
            var token = await TokenDefinition.ReadAsync(tokenFile);
            tokensByScript[Path.GetFileNameWithoutExtension(tokenFile)] = token;
            if (token.Name is not null)
                tokens.Add(token.Name, token);
            else
                await stderr.WriteLineAsync($"Token file ({tokenFile}) has no name!");
        }

        await stdout.WriteLineAsync($"Read: {tokens.Count} tokens");

        // Register reverse relations
        foreach (var card in cards.Values)
        {
            foreach (var face in card.GetCockatriceFaces())
            {
                if (face.RelatedTokens is null)
                    continue;

                foreach (var tokenScript in face.RelatedTokens)
                {
                    if (tokensByScript.TryGetValue(tokenScript, out var token))
                    {
                        token.ReverseRelatedCardNames.Add(face.Name);
                    }
                    else
                    {
                        await stderr.WriteLineAsync($"WARNING: Card face ({face.Name}) references unknown token script: {tokenScript}");
                    }
                }
            }
        }

        return tokens;
    }
}

[CliCommand(Name = "genall", Description = "Generate all outputs (scripts, docs, edition, bugs)")]
public class GenAllCommand : BaseCommand
{
    [CliOption(Required = true, Description = "The base content directory")]
    public override required DirectoryInfo BaseDirectory { get; set; }

    [CliOption(Required = true, Description = "The output directory")]
    public required DirectoryInfo OutputDir { get; set; }

    [CliOption(Description = "Link card captions to their documentation in bucket .md files")]
    public bool LinkifyCaptions { get; set; }

    [CliOption(Required = false, Description = "(cockatrice) The base URL for card images")]
    public string? ImageBaseUrl { get; set; }

    protected override async Task<int> ExecuteAsync(
        CliContext context,
        TextWriter stdout,
        TextWriter stderr
    )
    {
        // Read cards once for all operations
        var cards = await ReadCardDesignsAsync(stdout, stderr);
        var tokens = await ReadTokensAsync(cards, stdout, stderr);

        var subDirs = this.BaseDirectory.GetDirectories();
        var cardsDir = subDirs.FirstOrDefault(d => d.Name == "cards");
        var tokensDir = subDirs.FirstOrDefault(d => d.Name == "tokens");
        var editionsDir = subDirs.FirstOrDefault(d => d.Name == "editions");
        var designDir = subDirs.FirstOrDefault(d => d.Name == "design");
        if (cardsDir is null)
            throw new InvalidOperationException("cards dir not found");
        if (tokensDir is null)
            throw new InvalidOperationException("tokens dir not found");
        if (editionsDir is null)
            throw new InvalidOperationException("editions dir not found");
        if (designDir is null)
            throw new InvalidOperationException("design dir not found");

        // 1. Generate card scripts (from GenCardScriptsCommand)
        await GenerateCardScriptsAsync(cards, cardsDir, tokensDir, stdout, stderr);

        // 2. Generate docs (from GenDocsCommand)
        await GenerateDocsAsync(cards, OutputDir, BaseDirectory, stdout, stderr);

        // 3. Generate edition (from GenEditionCommand)
        await GenerateEditionAsync(cards, editionsDir, designDir, stdout);

        // 4. Generate bugs (from GenBugsCommand)
        await GenerateBugsAsync(cards, designDir, OutputDir, stdout);

        // 5. Generate card name list
        await GenerateCardListAsync(cards, designDir, OutputDir, stdout);

        // 6. Generate Cockatrice XML
        await GenerateCockatriceXmlAsync(cards, tokens, stdout);

        // 7. Generate Forge cube defn
        await GenerateForgeCubeAsync(cards, tokens, stdout, stderr);

        // 8. Generate draft rankings file
        await GenerateDraftRankingsAsync(cards, stdout);

        // Generate SPOILER.md containing a 3-column table of card and token images
        await GenerateSpoilerAsync(cards, tokens, BaseDirectory, OutputDir, stdout, stderr);

        await stdout.WriteLineAsync("All generation tasks completed successfully!");

        return 0;
    }

    private async Task GenerateCardScriptsAsync(SortedDictionary<string, CardMasterDesign> cards, DirectoryInfo cardsDir, DirectoryInfo tokensDir, TextWriter stdout, TextWriter stderr)
    {
        await stdout.WriteLineAsync("Generating card scripts...");
        foreach (var (name, card) in cards)
        {
            if (card.IsReprint) // Reprints already have card scripts
                continue;
            await card.WriteScriptAsync(cardsDir, tokensDir, stdout, stderr);
        }
    }

    private async Task GenerateDocsAsync(SortedDictionary<string, CardMasterDesign> cards, DirectoryInfo outputDir, DirectoryInfo baseDirectory, TextWriter stdout, TextWriter stderr)
    {
        await stdout.WriteLineAsync("Generating documentation...");
        Directory.CreateDirectory(outputDir.FullName);
        var writers = new Dictionary<string, StringWriter>();
        var scriptBaseDir = Path.GetRelativePath(
            outputDir.FullName,
            Path.Combine(baseDirectory.FullName, "cards")
        );

        foreach (var (name, card) in cards)
        {
            if (card.IsToken)
                continue;

            var (isBasic, _) = card.IsBasicLand();
            if (isBasic)
                continue;

            if (!writers.TryGetValue(card.Bucket!, out var writer))
            {
                var headerSb = new StringBuilder();
                writer = new StringWriter(headerSb);
                await writer.WriteLineAsync("# Cards");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("> Last generated: PLACEHOLDER");
                await writer.WriteLineAsync();
                writers[card.Bucket!] = writer;
            }
            await card.WriteDocAsync(scriptBaseDir, writer, stdout, stderr);
        }

        foreach (var kvp in writers)
        {
            var writer = kvp.Value;
            var contentSb = writer.GetStringBuilder();
            var newContent = contentSb.ToString().Replace("PLACEHOLDER", DateTime.UtcNow.ToString());
            var filePath = Path.Combine(outputDir.FullName, kvp.Key + ".md");
            string existingContent = null;
            if (File.Exists(filePath))
            {
                existingContent = File.ReadAllText(filePath);
                // Replace the timestamp with PLACEHOLDER
                var timestampRegex = new Regex(@"> Last generated: .*");
                existingContent = timestampRegex.Replace(existingContent, "> Last generated: PLACEHOLDER");
            }
            if (existingContent == null || existingContent != contentSb.ToString())
            {
                File.WriteAllText(filePath, newContent);
                await stdout.WriteLineAsync($"Updated: {filePath}");
            }
            else
            {
                await stdout.WriteLineAsync($"No changes: {filePath}");
            }
        }
    }

    private async Task GenerateEditionAsync(SortedDictionary<string, CardMasterDesign> cards, DirectoryInfo editionsDir, DirectoryInfo designDir, TextWriter stdout)
    {
        await stdout.WriteLineAsync("Generating edition file...");
        var templateFile = Path.Combine(designDir.FullName, "edition.tpl");
        if (!File.Exists(templateFile))
            throw new InvalidOperationException("Could not find edition.tpl");
        var cmdrTemplateFile = Path.Combine(designDir.FullName, "commander.tpl");
        if (!File.Exists(cmdrTemplateFile))
            throw new InvalidOperationException("Could not find commander.tpl");

        int collectorNum = 1;
        var cardList = new StringBuilder();
        var reprintList = new StringBuilder();
        var cmdrList = new StringBuilder();
        foreach (var (name, card) in cards)
        {
            if (card.IsReprint) // NOTE: Our commander sheet is all reprints, there are no "designed for commander" cards in this set. Hence why it's going down the reprint code path.
            {
                var sbList = card.IsCommander ? cmdrList : reprintList;

                var nicknamed = card.NicknameFor;
                if (nicknamed is not null)
                    sbList.AppendLine($"{collectorNum} {card.Rarity} {nicknamed} @{card.GetArtist()} ${{\"flavorName\": \"{name}\"}}");
                else
                    sbList.AppendLine($"{collectorNum} {card.Rarity} {name} @{card.GetArtist()}");
            }
            else
            {
                if (card.FaceType == CardFaceType.Meld || card.FaceType == CardFaceType.DoubleFaced) // Meld/DFC cards only care about the front face name
                    cardList.AppendLine(
                        $"{collectorNum} {card.Rarity} {card.FrontFull.Name} @{card.GetArtist()}"
                    );
                else
                    cardList.AppendLine($"{collectorNum} {card.Rarity} {name} @{card.GetArtist()}");
            }
            collectorNum++;
        }

        var sbEdition = new StringBuilder(File.ReadAllText(templateFile));
        sbEdition.Replace("$CARD_LIST$", cardList.ToString());
        sbEdition.Replace("$REPRINT_LIST$", reprintList.ToString());
        File.WriteAllText(
            Path.Combine(editionsDir.FullName, "Clair Obscur Expedition 33.txt"),
            sbEdition.ToString()
        );

        await stdout.WriteLineAsync("Updated edition file");

        var sbCommander = new StringBuilder(File.ReadAllText(cmdrTemplateFile));
        sbCommander.Replace("$REPRINT_LIST$", cmdrList.ToString());
        File.WriteAllText(
            Path.Combine(editionsDir.FullName, "Clair Obscur Expedition 33 Commander.txt"),
            sbCommander.ToString()
        );
    }

    private async Task GenerateBugsAsync(SortedDictionary<string, CardMasterDesign> cards, DirectoryInfo designDir, DirectoryInfo outputDir, TextWriter stdout)
    {
        await stdout.WriteLineAsync("Generating bugs file...");
        var bugsFile = Path.Combine(outputDir.FullName, "BUGS.md");
        using var sw = new StreamWriter(bugsFile);

        await sw.WriteLineAsync("# General");
        await sw.WriteLineAsync();

        var genBugsFile = Path.Combine(designDir.FullName, "GENERAL_BUGS.md");
        await sw.WriteLineAsync(File.ReadAllText(genBugsFile));

        await sw.WriteLineAsync("# Card-specific");
        await sw.WriteLineAsync();

        foreach (var (name, card) in cards)
        {
            // Reprints have no bugs (we care about) as their implementation is already in Forge. Card not working
            // properly? Take it to their github/discord/whatever.
            if (card.IsReprint)
                continue;
            await card.WriteBugsAsync(sw);
        }

        await stdout.WriteLineAsync("Updated bugs file");
    }

    private async Task GenerateCardListAsync(SortedDictionary<string, CardMasterDesign> cards, DirectoryInfo designDir, DirectoryInfo outputDir, TextWriter stdout)
    {
        var cardListFile = Path.Combine(designDir.FullName, "CARDLIST.md");
        if (!File.Exists(cardListFile))
            throw new InvalidOperationException("Could not find CARDLIST.md");

        using var srCardList = new StreamReader(cardListFile);
        await stdout.WriteLineAsync("Generating card list...");
        var cardListOutFile = Path.Combine(outputDir.FullName, "CARDLIST.md");
        var sbCardList = new StringBuilder();

        bool bInsideCardList = false;
        var line = await srCardList.ReadLineAsync();
        int cardNameTotal = 0;
        while (line is not null)
        {
            if (line == "```")
            {
                bInsideCardList = !bInsideCardList;
            }
            else
            {
                if (bInsideCardList) // Means line is a card name
                {
                    if (cards.TryGetValue(line, out var design))
                    {
                        if (design.IsReprint)
                        {
                            if (design.NicknameFor is not null)
                            {
                                if (design.IsCommander)
                                    line = $"[Z] {line}";
                                else
                                    line = $"[N] {line}";
                            }
                            else
                            {
                                if (design.IsCommander)
                                    line = $"[C] {line}";
                                else
                                    line = $"[R] {line}";
                            }
                        }
                        else
                        {
                            line = $"[x] {line}";
                        }
                    }
                    else
                    {
                        line = $"[ ] {line}";
                    }
                    cardNameTotal++;
                }
            }

            sbCardList.AppendLine(line);
            line = await srCardList.ReadLineAsync();
        }

        sbCardList.Replace("%_IMPL_STATUS_%", $"Cards implemented: {cards.Count}");
        sbCardList.Replace("%_IMPL_LEGEND_%", "[x] - Card is implemented or in development, [C] - Card is a commander reprint, [R] - Card is a regular reprint, [N] - Card is a nickname reprint, [Z] - Card is a nickname reprint for commander [ ] - Card is not implemented");

        await File.WriteAllTextAsync(cardListOutFile, sbCardList.ToString());
        await stdout.WriteLineAsync("Updated CARDLIST.md");
    }

    private async Task GenerateForgeCubeAsync(SortedDictionary<string, CardMasterDesign> cards, SortedDictionary<string, TokenDefinition> tokens, TextWriter stdout, TextWriter stderr)
    {
        var forgeDir = Path.Combine(this.BaseDirectory.FullName, "dist", "forge");
        Directory.CreateDirectory(forgeDir);

        var draftPath = Path.Combine(forgeDir, "E33_Cube.draft");
        await File.WriteAllTextAsync(draftPath, $"""
        Name:E33 Cube
        DeckFile:E33 Cube
        Singleton:True

        Booster: 15 Any
        NumPacks: 3
        """);

        var cubePath = Path.Combine(forgeDir, "E33_Cube.dck");
        using var sw = new StreamWriter(cubePath);

        await sw.WriteLineAsync($"""
        [metadata]
        Name=E33 Cube
        [Main]
        """);

        // Generate dr4ft cube listing
        foreach (var (name, card) in cards)
        {
            if (card.IsCommander)
                continue;

            var (isBasic, _) = card.IsBasicLand();
            if (isBasic)
                continue;

            if (card.FaceType == CardFaceType.SplitRoom || card.FaceType == CardFaceType.SplitFuse)
                await sw.WriteLineAsync(card.Name + "|E33");
            else
                await sw.WriteLineAsync(card.FrontFull.Name + "|E33");
        }
    }

    record CockatriceXmlOptions(string FileName, string? ImageBaseUrl, bool IncludeBasics, bool IncludeCommander, bool IncludeTokens, bool Dr4ftForkSupport);

    private async Task GenerateCockatriceXmlAsync(SortedDictionary<string, CardMasterDesign> cards, SortedDictionary<string, TokenDefinition> tokens, TextWriter stdout)
    {
        var cockatriceDir = Path.Combine(this.BaseDirectory.FullName, "dist", "cockatrice");
        Directory.CreateDirectory(cockatriceDir);

        await GenerateXmlAsync(cards, tokens, new DirectoryInfo(cockatriceDir), stdout, new("Expedition33.xml", this.ImageBaseUrl, true, true, true, false));
        await GenerateXmlAsync(cards, tokens, new DirectoryInfo(cockatriceDir), stdout, new("Expedition33_dr4ft.xml", this.ImageBaseUrl, false, false, false, false));
        await GenerateXmlAsync(cards, tokens, new DirectoryInfo(cockatriceDir), stdout, new("Expedition33_dr4ft_fork.xml", this.ImageBaseUrl, false, false, false, true));

        var cubePath = Path.Combine(cockatriceDir, "dr4ft_cube.txt");
        using var sw = new StreamWriter(cubePath);

        // Generate dr4ft cube listing
        foreach (var (name, card) in cards)
        {
            if (card.IsCommander)
                continue;

            var (isBasic, _) = card.IsBasicLand();
            if (isBasic)
                continue;

            foreach (var face in card.GetCubeDraftableFaces())
            {
                await sw.WriteLineAsync(face);
            }
        }
    }

    static string UrlEncode(string str) => Uri.EscapeDataString(str);

    private async Task GenerateXmlAsync(SortedDictionary<string, CardMasterDesign> cards, SortedDictionary<string, TokenDefinition> tokens, DirectoryInfo outputDir, TextWriter stdout, CockatriceXmlOptions options)
    {
        var sb = new StringBuilder();
        sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        sb.AppendLine("<cockatrice_carddatabase version=\"4\">");

        sb.AppendLine(
            $$"""
              <sets>
                <set>
                  <name>E33</name>
                  <longname>Clair Obscur: Expedition 33</longname>
                  <settype>Custom</settype>
                  <releasedate>2025-09-17</releasedate>
                </set>
                {{(options.IncludeCommander ?
            $$"""
            <set>
                  <name>E3C</name>
                  <longname>Clair Obscur: Expedition 33 Commander</longname>
                  <settype>Custom</settype>
                  <releasedate>2025-09-17</releasedate>
                </set>
            """ : "<!-- Commander set omitted -->")}}
              </sets>
              <cards>
            """);

        foreach (var (name, card) in cards)
        {
            if (!options.IncludeCommander && card.IsCommander)
                continue;

            var (isBasic, _) = card.IsBasicLand();
            if (!options.IncludeBasics && isBasic)
                continue;

            var setCode = card.IsCommander ? "E3C" : "E33";
            var faces = card.GetCockatriceFaces();
            foreach (var face in faces)
            {
                string setEl = $"<set rarity=\"{GetRarity(face.Name, face.Rarity)}\">{setCode}</set>";
                if (options.ImageBaseUrl is not null)
                {
                    var imageName = face.Name;
                    if (card.FaceType == CardFaceType.SplitFuse || card.FaceType == CardFaceType.SplitRoom)
                        imageName = face.Name.Replace(" // ", string.Empty);
                    var picUrl = $"{options.ImageBaseUrl}/{UrlEncode(imageName)}.full.jpg";
                    setEl = $"<set rarity=\"{GetRarity(face.Name, face.Rarity)}\" picurl=\"{picUrl}\">{setCode}</set>";
                }

                string layoutEl;
                if (options.Dr4ftForkSupport) // My fork of dr4ft supports DFC/Meld cards, but this metadata breaks import if imported into dr4ft.info
                {
                    layoutEl = card.FaceType switch
                    {
                        CardFaceType.SplitFuse => "<layout>split</layout>",
                        CardFaceType.SplitRoom => "<layout>split</layout>",
                        CardFaceType.DoubleFaced => "<layout>transform</layout>",
                        CardFaceType.Meld => "<layout>meld</layout>",
                        _ => "<!-- no layout -->"
                    };
                }
                else // For importing into dr4ft.info. DFC/Meld cards won't work (you'll only ever see the front face)
                {
                    layoutEl = (card.FaceType == CardFaceType.SplitFuse || card.FaceType == CardFaceType.SplitRoom ? "<layout>split</layout>" : "<!-- no layout -->");
                }

                sb.AppendLine($$"""
                    <card>
                      <name>{{EscapeXml(face.Name)}}</name>
                      <text>{{EscapeXml(face.OracleText)}}</text>
                      {{setEl}}
                      <prop>
                        <colors>{{face.Colors}}</colors>
                        <manacost>{{face.ManaCost}}</manacost>
                        {{(face.ManaValue.HasValue ? $"<cmc>{face.ManaValue.Value}</cmc>" : "<!-- no mana value -->")}}
                        <type>{{face.Type}}</type>
                        <maintype>{{face.MainType}}</maintype>
                        {{(face.Side is not null ? $"<side>{face.Side}</side>" : "<!-- no side -->")}}
                        {{(face.PT is not null ? $"<pt>{face.PT}</pt>" : "<!-- no pt -->")}}
                        {{(face.Loyalty is not null ? $"<loyalty>{face.Loyalty}</loyalty>" : "<!-- no pw loyalty -->")}}
                        {{(layoutEl)}}
                      </prop>
                      <tablerow>{{face.GetTableRow()}}</tablerow>
                      {{(face.RelatedCardName is not null ? $"<related attach=\"transform\">{face.RelatedCardName}</related>" : "<!-- no related -->")}}
                      {{(face.EntersTapped == true ? $"<cipt>1</cipt>" : "<!-- no cipt -->")}}
                    </card>
                """);
            }
        }

        if (options.IncludeTokens)
        {
            sb.AppendLine("    <!-- BEGIN tokens -->");

            foreach (var (name, token) in tokens)
            {
                var setCode = "E33"; // tokens don't have IsCommander
                string setEl = $"<set>{setCode}</set>";
                if (options.ImageBaseUrl is not null)
                {
                    var picUrl = $"{options.ImageBaseUrl}/{token.Filename}.jpg";
                    setEl = $"<set picurl=\"{picUrl}\">{setCode}</set>";
                }
                sb.AppendLine($$"""
                    <card>
                      <name>{{EscapeXml(name)}}</name>
                      <text>{{EscapeXml(token.OracleTextFull ?? string.Empty)}}</text>
                      {{setEl}}
                      <prop>
                        <colors>{{string.Join("", token.Colors ?? [])}}</colors>
                        <cmc>0</cmc>
                        <type>{{token.TypeLine}}</type>
                        <maintype>{{token.MainType}}</maintype>
                        {{(token.PT is not null ? $"<pt>{token.PT}</pt>" : "<!-- no pt -->")}}
                      </prop>
                      <token>1</token>
                      <tablerow>{{token.GetTableRow()}}</tablerow>
                """);

                foreach (var reverseName in token.ReverseRelatedCardNames)
                {
                    sb.AppendLine($$"""
                          <reverse-related>{{EscapeXml(reverseName)}}</reverse-related>
                    """);
                }

                sb.AppendLine("""
                    </card>
                """);
            }

            sb.AppendLine("    <!-- END tokens -->");
        }
        sb.AppendLine("  </cards>");

        string GetRarity(string name, string rarityCode) => rarityCode?.ToLowerInvariant() switch
        {
            "c" => "common",
            "u" => "uncommon",
            "r" => "rare",
            "m" => "mythic",
            _ => throw new UnreachableException($"No rarity for: {name}")
        };

        sb.AppendLine("</cockatrice_carddatabase>");

        var filePath = Path.Combine(outputDir.FullName, options.FileName);
        await File.WriteAllTextAsync(filePath, sb.ToString());
        await stdout.WriteLineAsync($"Generated Expedition33.xml with {cards.Count} cards and {tokens.Count} tokens");
    }

    private static string EscapeXml(string text)
    {
        return text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
    }

    private async Task GenerateSpoilerAsync(SortedDictionary<string, CardMasterDesign> cards, SortedDictionary<string, TokenDefinition> tokens, DirectoryInfo baseDirectory, DirectoryInfo outputDir, TextWriter stdout, TextWriter stderr)
    {
        try
        {
            var picsBase = Path.Combine(baseDirectory.FullName, "pics");
            var baseCardsPicsDir = Path.Combine(picsBase, "cards", "E33");
            var cmdrCardsPicsDir = Path.Combine(picsBase, "cards", "E3C");
            var tokensPicsDir = Path.Combine(picsBase, "tokens", "E33");

            var missingImages = new List<string>();

            var tokenImages = new List<(string path, string name, string bucket, string? nicknameFor, bool isCommander, string[] tags, string[] cycles)>();
            if (Directory.Exists(tokensPicsDir))
            {
                foreach (var token in tokens)
                {
                    var imgPath = Path.Combine(tokensPicsDir, token.Value.Filename + ".jpg");
                    if (File.Exists(imgPath))
                        tokenImages.Add((imgPath, token.Value.Name ?? "", "TOKENS", null, false, Array.Empty<string>(), Array.Empty<string>()));
                }

                // Special case for tokens without script files
                var specialTokens = new[] {
                    ("c_a_food_sac.jpg", "Food Token"),
                    ("c_a_clue_draw.jpg", "Clue Token"),
                    ("c_a_blood_draw.jpg", "Blood Token"),
                    ("c_a_map_sac_explore.jpg", "Map Token")
                };
                foreach (var (filename, name) in specialTokens)
                {
                    var imgPath = Path.Combine(tokensPicsDir, filename);
                    if (File.Exists(imgPath))
                        tokenImages.Add((imgPath, name, "TOKENS", null, false, Array.Empty<string>(), Array.Empty<string>()));
                }

                // Sort tokens alphabetically by name
                tokenImages = tokenImages.OrderBy(t => t.name).ToList();
            }

            var spoilerPath = Path.Combine(outputDir.FullName, "SPOILER.md");
            using (var spoilerWriter = new StreamWriter(spoilerPath, false, Encoding.UTF8))
            {
                spoilerWriter.WriteLine("# Visual Spoiler");
                spoilerWriter.WriteLine();
                spoilerWriter.WriteLine("> SPOILER WITHIN A SPOILER: Before you scroll down, please note that the cards in this set will spoil characters, plot, events and moments in the Expedition 33 video game. It is recommended you play through the video game first before continuing. If you don't want to be spoiled on video game plot/characters/events/etc, play through the game first and come back later. You have been warned!");
                spoilerWriter.WriteLine();
                spoilerWriter.WriteLine("> This set is not yet finalized. This set is now in the game/color balancing phase and cards may be removed or replaced as a result.");
                spoilerWriter.WriteLine();
                //spoilerWriter.WriteLine();
                //spoilerWriter.WriteLine("> This currently only shows cards/tokens we have full CardConjurer designs for and does not fully represent the whole set\n");
                {
                    var totalCards = 0;
                    var totalCardsWithImages = 0;
                    var bucketSummaries = new Dictionary<string, (int withImages, int total)>();
                    var baseImages = new List<(string path, string name, string bucket, string? nicknameFor, bool isCommander, string[] tags, string[] cycles)>();
                    foreach (var (bucket, imageList, cardsWithImagesTotal, cardsTotal) in GenerateImageLists(false))
                    {
                        //spoilerWriter.WriteLine("## " + bucket);
                        //WriteSpoilerTable(spoilerWriter, imageList, this.OutputDir);    
                        baseImages.AddRange(imageList);
                        totalCards += cardsTotal;
                        totalCardsWithImages += cardsWithImagesTotal;
                        bucketSummaries[bucket] = (cardsWithImagesTotal, cardsTotal);
                    }
                    spoilerWriter.WriteLine($"## Clair Obscur: Expedition 33 (E33) [{totalCardsWithImages}/{totalCards} cards]");
                    var bucketOrder = new[] { "COLORLESS", "WHITE", "BLUE", "BLACK", "RED", "GREEN", "MULTICOLOR", "ARTIFACTS", "LANDS" };
                    foreach (var bucket in bucketOrder)
                    {
                        if (bucketSummaries.TryGetValue(bucket, out var summary))
                        {
                            var displayBucket = char.ToUpper(bucket[0]) + bucket.ToLower().Substring(1);
                            spoilerWriter.WriteLine($"- {displayBucket}: {summary.withImages}/{summary.total} cards");
                        }
                    }
                    spoilerWriter.WriteLine(); // Need a newline before the markdown table, otherwise rendering is screwy
                    WriteSpoilerTable(spoilerWriter, baseImages, outputDir, this.LinkifyCaptions, false);
                }

                spoilerWriter.WriteLine("### Tokens");
                WriteSpoilerTable(spoilerWriter, tokenImages, outputDir, this.LinkifyCaptions, true);

                {
                    var totalCards = 0;
                    var totalCardsWithImages = 0;
                    var bucketSummaries = new Dictionary<string, (int withImages, int total)>();
                    var cmdrImages = new List<(string path, string name, string bucket, string? nicknameFor, bool isCommander, string[] tags, string[] cycles)>();
                    foreach (var (bucket, imageList, cardsWithImagesTotal, cardsTotal) in GenerateImageLists(true))
                    {
                        //spoilerWriter.WriteLine("## " + bucket);
                        //WriteSpoilerTable(spoilerWriter, imageList, this.OutputDir);    
                        cmdrImages.AddRange(imageList);
                        totalCards += cardsTotal;
                        totalCardsWithImages += cardsWithImagesTotal;
                        bucketSummaries[bucket] = (cardsWithImagesTotal, cardsTotal);
                    }
                    spoilerWriter.WriteLine($"## Clair Obscur: Expedition 33 Commander (E3C) [{totalCardsWithImages}/{totalCards} cards]");
                    spoilerWriter.WriteLine();
                    spoilerWriter.WriteLine("> This set is not yet finalized. This set is now in the game/color balancing phase and cards may be removed or replaced as a result.");
                    spoilerWriter.WriteLine();
                    var bucketOrder = new[] { "COLORLESS", "WHITE", "BLUE", "BLACK", "RED", "GREEN", "MULTICOLOR", "ARTIFACTS", "LANDS" };
                    foreach (var bucket in bucketOrder)
                    {
                        if (bucketSummaries.TryGetValue(bucket, out var summary))
                        {
                            var displayBucket = char.ToUpper(bucket[0]) + bucket.ToLower().Substring(1);
                            spoilerWriter.WriteLine($"- {displayBucket}: {summary.withImages}/{summary.total} cards");
                        }
                    }
                    spoilerWriter.WriteLine(); // Need a newline before the markdown table, otherwise rendering is screwy
                    WriteSpoilerTable(spoilerWriter, cmdrImages, outputDir, this.LinkifyCaptions, false);
                }
            }

            if (missingImages.Any())
            {
                await stdout.WriteLineAsync($"Cards missing images:");
                foreach (var cardName in missingImages.OrderBy(n => n))
                {
                    await stdout.WriteLineAsync("  " + cardName);
                }
            }

            IEnumerable<(string bucket, List<(string path, string name, string bucket, string? nicknameFor, bool isCommander, string[] tags, string[] cycles)> images, int cardsWithImagesTotal, int cardsTotal)> GenerateImageLists(bool isCommander)
            {
                var picsDir = isCommander ? cmdrCardsPicsDir : baseCardsPicsDir;
                var baseGroups = cards.Where(c => c.Value.IsCommander == isCommander).GroupBy(c => c.Value.Bucket).ToList();
                IEnumerable<string> buckets = ["COLORLESS", "WHITE", "BLUE", "BLACK", "RED", "GREEN", "MULTICOLOR", "ARTIFACTS", "LANDS"];
                foreach (var bucket in buckets)
                {
                    var group = baseGroups.FirstOrDefault(grp => grp.Key == bucket);
                    if (group is not null)
                    {
                        var cardsWithImagesTotal = 0;
                        var cardsTotal = 0;
                        var images = new List<(string path, string name, string bucket, string? nicknameFor, bool isCommander, string[] tags, string[] cycles)>();
                        var orderedGroup = bucket == "LANDS" ? (IEnumerable<KeyValuePair<string, CardMasterDesign>>)group.OrderBy(c => IsBasicLand(c.Value.Name) ? 1 : 0).ThenBy(c => c.Key) : group;
                        foreach (var (name, card) in orderedGroup)
                        {
                            cardsTotal++;
                            bool complete = true;
                            foreach (var imgName in card.GetImageNames())
                            {
                                var imgPath = Path.Combine(picsDir, imgName);
                                if (File.Exists(imgPath))
                                    images.Add((imgPath, card.Name, bucket, card.NicknameFor, card.IsCommander, card.Tags.ToArray(), card.AllCycles?.ToArray() ?? Array.Empty<string>()));
                                else
                                    complete = false;
                            }
                            if (complete)
                                cardsWithImagesTotal++;
                            else
                                missingImages.Add(card.Name);
                        }
                        yield return (bucket, images, cardsWithImagesTotal, cardsTotal);
                    }
                }

                bool IsBasicLand(string name) => name is "Forest" or "Island" or "Mountain" or "Plains" or "Swamp";
            }

            static void WriteSpoilerTable(StreamWriter spoilerWriter, List<(string path, string name, string bucket, string? nicknameFor, bool isCommander, string[] tags, string[] cycles)> images, DirectoryInfo outputDir, bool linkifyCaptions, bool isTokenImages)
            {
                const int COLUMNS = 3;

                // Table header (3 columns)
                spoilerWriter.WriteLine("| | | |");
                spoilerWriter.WriteLine("|---|---|---|");

                for (int i = 0; i < images.Count; i += COLUMNS)
                {
                    var imageRow = new string[COLUMNS];
                    var captionRow = new string[COLUMNS];
                    for (int c = 0; c < COLUMNS; c++)
                    {
                        var idx = i + c;
                        if (idx < images.Count)
                        {
                            var (abs, name, bucket, nicknameFor, isCommander, tags, cycles) = images[idx];
                            var rel = Path.GetRelativePath(outputDir.FullName, abs).Replace("\\", "/");
                            // Percent-encode each path segment so spaces and special chars work in Markdown image URLs
                            var encodedRel = string.Join("/", rel.Split('/').Select(seg => System.Uri.EscapeDataString(seg)));
                            // Image in one row
                            imageRow[c] = $"![]({encodedRel})";
                            // Build tag HTML only for non-commander cards with non-empty tag arrays
                            var tagsHtml = string.Empty;
                            var cyclesHtml = string.Empty;
                            if (!isCommander && !isTokenImages)
                            {
                                if (tags is not null && tags.Length > 0)
                                {
                                    var sortedTags = tags.OrderBy(t => t).ToArray();
                                    var tagsText = EscapeXml(string.Join(", ", sortedTags));
                                    tagsHtml = $"<br/><small>Tags: {tagsText}</small>";
                                }
                                else
                                {
                                    tagsHtml = $"<br/><small>Tags: (none)</small>";
                                }

                                if (cycles is not null && cycles.Length > 0)
                                {
                                    var sortedCycles = cycles.OrderBy(c => c).ToArray();
                                    var cyclesText = EscapeXml(string.Join(", ", sortedCycles));
                                    cyclesHtml = $"<br/><small>Cycle(s): {cyclesText}</small>";
                                }
                            }
                            // Caption in the next row
                            if (linkifyCaptions && !string.IsNullOrEmpty(bucket) && bucket != "TOKENS" && !IsBasicLand(name))
                            {
                                // Create a markdown link to the card's documentation
                                var anchorName = nicknameFor != null ? $"{name} ({nicknameFor})" : name;
                                var anchor = CreateMarkdownAnchor(anchorName);
                                var displayName = anchorName;
                                captionRow[c] = $"<center>[{displayName}]({bucket}.md#{anchor}){tagsHtml}{cyclesHtml}</center>";
                            }
                            else
                            {
                                captionRow[c] = $"<center>{name}{tagsHtml}{cyclesHtml}</center>";
                            }

                            static bool IsBasicLand(string name) => name switch
                            {
                                "Forest" => true,
                                "Island" => true,
                                "Mountain" => true,
                                "Plains" => true,
                                "Swamp" => true,
                                _ => false
                            };
                        }
                        else
                        {
                            imageRow[c] = " ";
                            captionRow[c] = " ";
                        }
                    }
                    spoilerWriter.WriteLine($"| {string.Join(" | ", imageRow)} |");
                    spoilerWriter.WriteLine($"| {string.Join(" | ", captionRow)} |");
                }
            }

            static string CreateMarkdownAnchor(string name)
            {
                // Convert to lowercase, replace spaces and special chars with hyphens
                // Remove or replace characters that aren't suitable for anchors
                return name
                    .ToLowerInvariant()
                    .Replace(" ", "-")
                    .Replace("'", "")
                    .Replace("//", "")
                    .Replace("\"", "")
                    .Replace(",", "")
                    .Replace(".", "")
                    .Replace("!", "")
                    .Replace("?", "")
                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("[", "")
                    .Replace("]", "")
                    .Replace("{", "")
                    .Replace("}", "")
                    .Replace("/", "-")
                    .Replace("\\", "-")
                    .Replace("&", "");
            }
        }
        catch (Exception ex)
        {
            await stderr.WriteLineAsync($"Failed to write SPOILER.md: {ex.Message}");
        }
    }

    private async Task GenerateDraftRankingsAsync(SortedDictionary<string, CardMasterDesign> cards, TextWriter stdout)
    {
        await stdout.WriteLineAsync("Generating draft rankings...");
        var forgeDir = Path.Combine(this.BaseDirectory.FullName, "dist", "forge");
        Directory.CreateDirectory(forgeDir);

        var rankingsPath = Path.Combine(forgeDir, "e33.rnk");
        using var sw = new StreamWriter(rankingsPath);

        // Write header
        await sw.WriteLineAsync("//Rank|Name|Rarity|Set");

        // Collect cards with draft scores and without
        var rankedCards = new List<(string displayName, string rarity, int score)>();
        var unrankedCards = new List<(string displayName, string rarity)>();

        foreach (var (_, card) in cards)
        {
            // Skip commander cards
            if (card.IsCommander)
                continue;

            // Skip basic lands
            var (isBasic, _) = card.IsBasicLand();
            if (isBasic)
                continue;

            string displayName = card.Name;

            // For split/room cards, remove " // "
            if (card.FaceType == CardFaceType.SplitFuse || card.FaceType == CardFaceType.SplitRoom)
            {
                displayName = displayName.Replace(" // ", " ");
            }
            // For DFC/meld cards, use only the front face name
            else if (card.FaceType == CardFaceType.DoubleFaced || card.FaceType == CardFaceType.Meld)
            {
                displayName = card.FrontFull?.Name ?? card.Name;
            }

            if (card.DraftScore.HasValue)
            {
                rankedCards.Add((displayName, card.Rarity ?? "?", card.DraftScore.Value));
            }
            else
            {
                unrankedCards.Add((displayName, card.Rarity ?? "?"));
            }
        }

        // Sort ranked cards by score descending, then by name for consistency
        rankedCards.Sort((a, b) => b.score.CompareTo(a.score) switch
        {
            0 => a.displayName.CompareTo(b.displayName),
            int cmp => cmp
        });

        // Sort unranked cards by name for consistency
        unrankedCards.Sort((a, b) => a.displayName.CompareTo(b.displayName));

        // Write ranked cards
        int rankNumber = 1;
        for (int i = 0; i < rankedCards.Count; i++)
        {
            var (name, rarity, score) = rankedCards[i];
            await sw.WriteLineAsync($"#{rankNumber}|{name}|{rarity}|E33");
            rankNumber++;
        }

        // Write unranked cards at the end
        for (int i = 0; i < unrankedCards.Count; i++)
        {
            var (name, rarity) = unrankedCards[i];
            await sw.WriteLineAsync($"#{rankNumber}|{name}|{rarity}|E33");
            rankNumber++;
        }

        await stdout.WriteLineAsync($"Generated e33.rnk with {rankedCards.Count} ranked cards and {unrankedCards.Count} unranked cards");
    }
}

[CliCommand(Name = "cardconjurer", Description = "Validate CardConjurer config against current design")]
public class CardConjurerValidateCommand : BaseCommand
{
    [CliOption(Required = true, Description = "The base content directory")]
    public override required DirectoryInfo BaseDirectory { get; set; }

    protected override async Task<int> ExecuteAsync(
        CliContext context,
        TextWriter stdout,
        TextWriter stderr
    )
    {
        var subDirs = this.BaseDirectory.GetDirectories();
        var designDir = subDirs.FirstOrDefault(d => d.Name == "design");
        if (designDir is null)
            throw new InvalidOperationException("Design dir not found");

        var ccConfigPath = Path.Combine(designDir.FullName, "saved-cards.cardconjurer");
        if (!File.Exists(ccConfigPath))
            throw new InvalidOperationException("Could not find saved-cards.cardconjurer");

        // Read cards once for all operations
        var cards = await ReadCardDesignsAsync(stdout, stderr);

        // Read current cardconjurer config
        var conf = System.Text.Json.JsonDocument.Parse(File.ReadAllText(ccConfigPath));
        int totalCcCards = conf.RootElement.EnumerateArray().Count();

        int totalCards = 0;
        int matchingCards = 0;
        int mismatchedCards = 0;
        int missingCards = 0;
        int invalidCards = 0;
        int splitCards = 0;

        // Color order requirements for mana cost validation
        var colorOrders = new Dictionary<string, string>
        {
            // 5 colors
            ["BGRUW"] = "WUBRG",
            // 4 colors
            ["BRUW"] = "WUBR",
            ["BURG"] = "UBRG",
            ["BGRW"] = "BRGW",
            ["GRUW"] = "RGWU",
            ["GUWB"] = "GWUB",
            // 3 colors
            ["BUW"] = "WUB", // Esper
            ["GRU"] = "GUR", // Temur
            ["GUW"] = "GWU", // Bant
            ["BRW"] = "RWB", // Mardu
            ["BGW"] = "WBG", // Abzan
            ["RUW"] = "URW", // Jeskai
            ["BGU"] = "BGU", // Sultai
            ["GRW"] = "RGW", // Naya
            ["BRG"] = "BRG", // Jund
            ["BRU"] = "UBR", // Grixis
            // 2 colors
            ["GW"] = "GW", // Selesnya
            ["GR"] = "RG", // Gruul
            ["BR"] = "BR", // Rakdos
            ["BU"] = "UB", // Dimir
            ["UW"] = "WU", // Azorious
            ["GU"] = "GU", // Simic
            ["RW"] = "RW", // Boros
            ["BW"] = "WB", // Orzhov
            ["BG"] = "BG", // Golgari
            ["RU"] = "UR", // Izzet
        };

        // Normalize text to ASCII for comparison (strip markup and normalize common punctuation)
        static string NormalizeToAscii(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            // Remove any {markup} tags
            var stripped = System.Text.RegularExpressions.Regex.Replace(text, "{[^}]*}", "");

            return stripped
                .Replace("\u2018", "'") // LEFT SINGLE QUOTATION MARK
                .Replace("\u2019", "'") // RIGHT SINGLE QUOTATION MARK
                .Replace("\u201C", "\"") // LEFT DOUBLE QUOTATION MARK
                .Replace("\u201D", "\"") // RIGHT DOUBLE QUOTATION MARK
                .Replace("\u2013", "-") // EN DASH
                ; // Keep em dashes (\u2014) in source
        }

        foreach (var (cardName, design) in cards)
        {
            totalCards++;

            if (string.IsNullOrWhiteSpace(design.GetArtist()))
            {
                await stdout.WriteLineAsync($"WARNING: No artist credits found for {cardName}");
            }

            // Skip split/fuse cards as they have different validation requirements
            if (design.FaceType == CardFaceType.SplitRoom || design.FaceType == CardFaceType.SplitFuse)
            {
                await stdout.WriteLineAsync($"INFO: Skipping split/fuse card: {cardName}");
                splitCards++;
                continue;
            }

            // Nickname cards have a specific name format
            List<(string name, CardFaceDesign? face)> cardFaceNames = [(cardName, design.FrontFull)];
            bool isNicknamed = false;
            if (design.NicknameFor is not null)
            {
                cardFaceNames.Clear();
                cardFaceNames.Add(($"{design.NicknameFor} ({cardName})", design.FrontFull));
                isNicknamed = true;
            }
            else if (design.FaceType == CardFaceType.Meld)
            {
                cardFaceNames.Clear();
                cardFaceNames.Add((design.FrontFull!.Name!, design.FrontFull));
                cardFaceNames.Add((design.MeldTarget!.Name!, design.MeldTarget));
            }
            else if (design.FaceType == CardFaceType.DoubleFaced)
            {
                cardFaceNames.Clear();
                cardFaceNames.Add((design.FrontFull!.Name!, design.FrontFull));
                cardFaceNames.Add((design.BackFull!.Name!, design.BackFull));
            }

            foreach (var (cardFaceName, cardFace) in cardFaceNames)
            {
                // Find matching CardConjurer design (null-safe key read)
                var ccDesign = conf.RootElement.EnumerateArray()
                    .FirstOrDefault(el => NormalizeToAscii(el.GetProperty("key").GetString() ?? "") == cardFaceName);

                if (ccDesign.ValueKind == System.Text.Json.JsonValueKind.Undefined)
                {
                    await stdout.WriteLineAsync($"WARNING: No CardConjurer design found for {cardFaceName}");
                    missingCards++;
                    continue;
                }

                bool hasWarnings = false;

                // Try to get data and text properties
                if (!ccDesign.TryGetProperty("data", out var data) || !data.TryGetProperty("text", out var text))
                {
                    await stdout.WriteLineAsync($"WARNING: {cardFaceName} - Missing data or text properties in CardConjurer design");
                    invalidCards++;
                    continue;
                }

                // Check mana cost
                if (!isNicknamed &&
                    cardFace?.ManaCost != null &&
                    text.TryGetProperty("mana", out var manaObj) &&
                    manaObj.TryGetProperty("text", out var manaText))
                {
                    var ccManaCost = manaText.GetString();
                    var designManaCost = string.Join(" ", cardFace.ManaCost);
                    if (designManaCost == "no cost")
                        designManaCost = "";
                    if (NormalizeToAscii(ccManaCost ?? "") != NormalizeToAscii(designManaCost))
                    {
                        await stdout.WriteLineAsync($"WARNING: Mana cost mismatch found in card face: {cardFaceName}");
                        await stdout.WriteLineAsync($"  Mana cost:");
                        await stdout.WriteLineAsync($"    CC: {ccManaCost}");
                        await stdout.WriteLineAsync($"    DF: {designManaCost}");
                        await stdout.WriteLineAsync(GetDifferenceMarker(ccManaCost, designManaCost));
                        hasWarnings = true;
                    }

                    // Check color pip order
                    var manaTokens = (ccManaCost ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var colorSequence = new List<string>();
                    foreach (var token in manaTokens)
                    {
                        var match = Regex.Match(token, @"^([WUBRG])$");
                        if (match.Success)
                        {
                            colorSequence.Add(match.Groups[1].Value);
                        }
                    }
                    var uniqueColors = new HashSet<string>(colorSequence);
                    if (uniqueColors.Count >= 2)
                    {
                        var key = string.Concat(uniqueColors.OrderBy(c => c));
                        if (colorOrders.TryGetValue(key, out var requiredOrder))
                        {
                            var requiredList = requiredOrder.Select(c => c.ToString()).ToList();
                            // Check if the color sequence respects the required order, allowing repeats
                            bool orderValid = true;
                            for (int i = 0; i < requiredList.Count - 1; i++)
                            {
                                var earlierColor = requiredList[i];
                                var laterColor = requiredList[i + 1];
                                var earlierIndices = colorSequence.Select((c, idx) => c == earlierColor ? idx : -1).Where(idx => idx >= 0).ToList();
                                var laterIndices = colorSequence.Select((c, idx) => c == laterColor ? idx : -1).Where(idx => idx >= 0).ToList();
                                if (earlierIndices.Any() && laterIndices.Any())
                                {
                                    var maxEarlier = earlierIndices.Max();
                                    var minLater = laterIndices.Min();
                                    if (maxEarlier >= minLater)
                                    {
                                        orderValid = false;
                                        break;
                                    }
                                }
                            }
                            if (!orderValid)
                            {
                                if (!hasWarnings)
                                    await stdout.WriteLineAsync($"WARNING: Color pip ordering mismatches found in card: {cardFaceName}");
                                await stdout.WriteLineAsync($"  Mana color pip order:");
                                await stdout.WriteLineAsync($"    CC: {string.Join("", colorSequence)}");
                                await stdout.WriteLineAsync($"    Required: {requiredOrder}");
                                hasWarnings = true;
                            }
                        }
                        else
                        {
                            await stdout.WriteLineAsync($"WARNING: {cardFaceName} - Unknown color combination for mana order validation: {key}");
                            hasWarnings = true;
                        }
                    }
                }

                // Check title
                if (!isNicknamed &&
                    text.TryGetProperty("title", out var titleObj) &&
                    titleObj.TryGetProperty("text", out var titleText))
                {
                    var ccTitle = titleText.GetString();
                    if (NormalizeToAscii(ccTitle ?? "") != NormalizeToAscii(cardFaceName ?? ""))
                    {
                        if (!hasWarnings)
                            await stdout.WriteLineAsync($"WARNING: Title mismatches found in card: {cardFaceName}");
                        await stdout.WriteLineAsync($"  Title:");
                        await stdout.WriteLineAsync($"    CC: {ccTitle}");
                        await stdout.WriteLineAsync($"    DF: {cardFaceName}");
                        await stdout.WriteLineAsync(GetDifferenceMarker(ccTitle, cardFaceName));
                        hasWarnings = true;
                    }
                }

                // Check type line
                if (!isNicknamed &&
                    cardFace?.TypeLine != null &&
                    text.TryGetProperty("type", out var typeObj) &&
                    typeObj.TryGetProperty("text", out var typeText))
                {
                    var ccType = typeText.GetString();
                    if (NormalizeToAscii(ccType ?? "") != NormalizeToAscii(cardFace.TypeLine ?? ""))
                    {
                        if (!hasWarnings)
                            await stdout.WriteLineAsync($"WARNING: Type line mismatches found in card: {cardFaceName}");
                        await stdout.WriteLineAsync($"  Type line:");
                        await stdout.WriteLineAsync($"    CC: {ccType}");
                        await stdout.WriteLineAsync($"    DF: {cardFace.TypeLine}");
                        await stdout.WriteLineAsync(GetDifferenceMarker(ccType, cardFace.TypeLine));
                        hasWarnings = true;
                    }
                }

                // Check rarity / set symbol source
                // .data.setSymbolSource in CardConjurer should correspond to the filename
                // Regular Set: https://cardconjurer.app/img/setSymbols/official/pz1-$RARITY.svg
                // Commander: https://cardconjurer.app/img/setSymbols/official/cmd-$RARITY.svg
                // Also check that design.Rarity matches .data.infoRarity in CardConjurer config
                if (data.TryGetProperty("infoRarity", out var infoRarityObj) && infoRarityObj.ValueKind == System.Text.Json.JsonValueKind.String)
                {
                    var infoRarity = infoRarityObj.GetString() ?? "";
                    if (!string.IsNullOrWhiteSpace(design.Rarity) && !string.Equals(design.Rarity, infoRarity, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!hasWarnings)
                            await stdout.WriteLineAsync($"WARNING: Rarity code mismatch found in card: {cardFaceName}");
                        await stdout.WriteLineAsync($"  Rarity code mismatch:");
                        await stdout.WriteLineAsync($"    Design rarity: {design.Rarity}");
                        await stdout.WriteLineAsync($"    CC .data.infoRarity: {infoRarity}");
                        hasWarnings = true;
                    }
                }

                if (data.TryGetProperty("setSymbolSource", out var setSymbolSourceObj) && setSymbolSourceObj.ValueKind == System.Text.Json.JsonValueKind.String)
                {
                    var setSymbolSource = setSymbolSourceObj.GetString() ?? "";

                    // Prefer reading the rarity code from the design (`CardMasterDesign.Rarity`)
                    // design.Rarity MUST be a single-letter code if specified; otherwise emit an error, increment invalidCards, and skip rarity validation
                    string? rarityCode = null;
                    bool skipRaritySymbolValidation = false;
                    if (!string.IsNullOrWhiteSpace(design.Rarity))
                    {
                        var dr = design.Rarity.Trim();
                        if (dr.Length == 1)
                        {
                            rarityCode = dr;
                        }
                        else
                        {
                            await stdout.WriteLineAsync($"ERROR: {cardFaceName} - design.Rarity must be a single-letter code if specified; value: '{dr}'");
                            invalidCards++;
                            skipRaritySymbolValidation = true;
                        }
                    }

                    // Meld and DFC back faces don't have rarity symbols, so skip for such cases
                    if (design.FaceType == CardFaceType.Meld && design.MeldTarget == cardFace)
                    {
                        skipRaritySymbolValidation = true;
                    }
                    else if (design.FaceType == CardFaceType.DoubleFaced && design.BackFull == cardFace)
                    {
                        skipRaritySymbolValidation = true;
                    }

                    if (skipRaritySymbolValidation)
                    {
                        // Don't validate set symbol for this card when the design rarity is malformed.
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(rarityCode))
                        {
                            var filename = design.IsCommander ? $"cmd-{rarityCode}.svg" : $"pz1-{rarityCode}.svg";
                            var constructedUrl = $"https://cardconjurer.app/img/setSymbols/official/{filename}";

                            var src = (setSymbolSource ?? "").Trim();
                            bool match = string.Equals(src, filename, StringComparison.OrdinalIgnoreCase)
                                         || src.EndsWith('/' + filename, StringComparison.OrdinalIgnoreCase)
                                         || string.Equals(src, constructedUrl, StringComparison.OrdinalIgnoreCase);

                            if (!match)
                            {
                                if (!hasWarnings)
                                    await stdout.WriteLineAsync($"WARNING: Rarity symbol mismatch found in card: {cardFaceName}");
                                await stdout.WriteLineAsync($"  Set symbol source / rarity:");
                                await stdout.WriteLineAsync($"    CC .data.setSymbolSource: {setSymbolSource}");
                                await stdout.WriteLineAsync($"    Constructed from design rarity code: {constructedUrl}");
                                hasWarnings = true;
                            }
                        }
                        else
                        {
                            await stdout.WriteLineAsync($"INFO: {cardFaceName} - Could not determine rarity code from design or CardConjurer data to validate set symbol.");
                        }
                    }
                }

                // Check rules text
                if (!isNicknamed &&
                    cardFace?.Oracle != null &&
                    text.TryGetProperty("rules", out var rulesObj) &&
                    rulesObj.TryGetProperty("text", out var rulesText))
                {
                    var ccRules = NormalizeToAscii(rulesText.GetString() ?? "");
                    var designRules = NormalizeToAscii(cardFace.GetCardConjurerOracleText());

                    if (ccRules != designRules)
                    {
                        if (!hasWarnings)
                            await stdout.WriteLineAsync($"WARNING: Oracle text mismatch found in card: {cardFaceName}");
                        await stdout.WriteLineAsync($"  Rules text:");
                        await stdout.WriteLineAsync($"    CC: {ccRules}");
                        await stdout.WriteLineAsync($"    DF: {designRules}");
                        await stdout.WriteLineAsync(GetDifferenceMarker(ccRules, designRules));
                        hasWarnings = true;
                    }
                }

                // Check P/T
                if (!isNicknamed &&
                    cardFace?.PT != null &&
                    text.TryGetProperty("pt", out var ptObj) &&
                    ptObj.TryGetProperty("text", out var ptText))
                {
                    var ccPT = System.Text.RegularExpressions.Regex.Replace(ptText.GetString() ?? "", "{[^}]*}", "");
                    var designPT = cardFace.PT ?? "";
                    if (NormalizeToAscii(ccPT) != NormalizeToAscii(designPT))
                    {
                        if (!hasWarnings)
                            await stdout.WriteLineAsync($"WARNING: P/T mismatch found in card: {cardFaceName}");
                        await stdout.WriteLineAsync($"  Power/Toughness:");
                        await stdout.WriteLineAsync($"    CC: {ccPT}");
                        await stdout.WriteLineAsync($"    DF: {designPT}");
                        await stdout.WriteLineAsync(GetDifferenceMarker(ccPT, designPT));
                        hasWarnings = true;
                    }
                }

                // Check 1/8 margin
                if (!data.TryGetProperty("margins", out var m))
                {
                    await stdout.WriteLineAsync($"WARNING: No 1/8 margin set for {cardFaceName}");
                    hasWarnings = true;
                }

                if (!hasWarnings)
                {
                    await stdout.WriteLineAsync($"INFO: {cardFaceName} - All elements match");
                    matchingCards++;
                }
                else
                {
                    mismatchedCards++;
                }
            }

            // Helper method to show where strings differ
            static string GetDifferenceMarker(string? str1, string? str2)
            {
                var marker = new StringBuilder();

                // Treat nulls as empty for comparisons
                str1 ??= string.Empty;
                str2 ??= string.Empty;

                // Normalize line endings to \n and handle escaped characters
                string NormalizeString(string s) => s
                    .Replace("\r\n", "\n")
                    .Replace("\r", "\n");

                str1 = NormalizeString(str1);
                str2 = NormalizeString(str2);

                // Helper to get unicode info for a character
                static string GetUnicodeInfo(char c)
                {
                    if (c == ' ') return "SPACE";
                    if (c == '\t') return "TAB";
                    if (c == '\n') return "NEWLINE";
                    if (char.IsControl(c)) return $"CTRL U+{(int)c:X4}";
                    return c > 127 ? $"U+{(int)c:X4}" : $"'{c}'";
                }

                // Helper to escape whitespace for display
                static string EscapeWhitespace(string s) => s
                    .Replace(" ", "·")      // Visible space
                    .Replace("\t", "→")     // Tab
                    .Replace("\n", "↵\n");  // Newline

                // Split into lines
                var lines1 = str1.Split('\n');
                var lines2 = str2.Split('\n');

                if (lines1.Length == 1 && lines2.Length == 1)
                {
                    // Single-line comparison - find the first difference
                    int diffPos = 0;
                    while (diffPos < str1.Length && diffPos < str2.Length && str1[diffPos] == str2[diffPos])
                        diffPos++;

                    if (diffPos < str1.Length || diffPos < str2.Length)
                    {
                        // Show context around the first difference
                        int contextStart = Math.Max(0, diffPos - 30);
                        int contextEnd1 = Math.Min(str1.Length, diffPos + 30);
                        int contextEnd2 = Math.Min(str2.Length, diffPos + 30);

                        var cc = str1.Substring(contextStart, contextEnd1 - contextStart);
                        var df = str2.Substring(contextStart, contextEnd2 - contextStart);

                        marker.AppendLine($"              First difference at position {diffPos}:");
                        marker.AppendLine($"                CC: ...{EscapeWhitespace(cc)}...");
                        marker.AppendLine($"                DF: ...{EscapeWhitespace(df)}...");

                        // Show character details at the diff position
                        if (diffPos < str1.Length && diffPos < str2.Length)
                        {
                            marker.AppendLine($"                Char at {diffPos}: CC={GetUnicodeInfo(str1[diffPos])} vs DF={GetUnicodeInfo(str2[diffPos])}");
                        }
                        else if (diffPos < str1.Length)
                        {
                            marker.AppendLine($"                Char at {diffPos}: CC={GetUnicodeInfo(str1[diffPos])} vs DF=(end of string)");
                        }
                        else
                        {
                            marker.AppendLine($"                Char at {diffPos}: CC=(end of string) vs DF={GetUnicodeInfo(str2[diffPos])}");
                        }
                    }

                    // Also check for all differences (not just non-ASCII)
                    var allDiffs = new List<(int pos, char c1, char c2)>();
                    int minLength = Math.Min(str1.Length, str2.Length);
                    for (int i = 0; i < minLength; i++)
                    {
                        if (str1[i] != str2[i])
                            allDiffs.Add((i, str1[i], str2[i]));
                    }

                    if (allDiffs.Count > 1)
                    {
                        marker.AppendLine($"              All differences found:");
                        foreach (var (pos, c1, c2) in allDiffs.Take(5))
                        {
                            marker.AppendLine($"                pos {pos}: CC={GetUnicodeInfo(c1)} vs DF={GetUnicodeInfo(c2)}");
                        }
                        if (allDiffs.Count > 5)
                            marker.AppendLine($"                ... and {allDiffs.Count - 5} more differences");
                    }
                }
                else
                {
                    // Multi-line comparison
                    marker.AppendLine("              Multi-line difference detected:");

                    // Find first differing line
                    for (int i = 0; i < Math.Min(lines1.Length, lines2.Length); i++)
                    {
                        if (lines1[i] != lines2[i])
                        {
                            marker.AppendLine($"              First difference at line {i + 1}:");
                            marker.AppendLine($"                CC: {EscapeWhitespace(lines1[i])}");
                            marker.AppendLine($"                DF: {EscapeWhitespace(lines2[i])}");

                            // Find first char difference in this line
                            for (int j = 0; j < Math.Min(lines1[i].Length, lines2[i].Length); j++)
                            {
                                if (lines1[i][j] != lines2[i][j])
                                {
                                    marker.AppendLine($"                First char diff at line {i + 1} pos {j}: CC={GetUnicodeInfo(lines1[i][j])} vs DF={GetUnicodeInfo(lines2[i][j])}");
                                    break;
                                }
                            }
                            break;
                        }
                    }

                    // Check for length differences
                    if (lines1.Length != lines2.Length)
                    {
                        marker.AppendLine($"              Line count: CC has {lines1.Length} lines, DF has {lines2.Length} lines");
                    }
                }

                return marker.ToString();
            }
        }

        // Print summary
        await stdout.WriteLineAsync();
        await stdout.WriteLineAsync("=== Validation Summary ===");
        await stdout.WriteLineAsync($"Design files total: {totalCards}");
        await stdout.WriteLineAsync($"CardConjurer total: {totalCcCards}");
        await stdout.WriteLineAsync("---");
        await stdout.WriteLineAsync($"Perfectly matching cards: {matchingCards}");
        await stdout.WriteLineAsync($"Cards with differences: {mismatchedCards}");
        await stdout.WriteLineAsync($"Split/fuse cards skipped: {splitCards}");
        await stdout.WriteLineAsync($"Cards missing from CardConjurer: {missingCards}");
        await stdout.WriteLineAsync($"Cards with invalid CardConjurer data: {invalidCards}");
        await stdout.WriteLineAsync("=====================");

        return 0;

    }
}

// Local CardConjurer -> create a local copy with adjusted URLs
[CliCommand(Name = "localcc", Description = "Create a local CardConjurer config with local URLs")]
public class LocalCardConjurerCommand : BaseCommand
{
    [CliOption(Required = true, Description = "The base content directory")]
    public override required DirectoryInfo BaseDirectory { get; set; }

    protected override async Task<int> ExecuteAsync(
        CliContext context,
        TextWriter stdout,
        TextWriter stderr
    )
    {
        var subDirs = this.BaseDirectory.GetDirectories();
        var designDir = subDirs.FirstOrDefault(d => d.Name == "design");
        if (designDir is null)
            throw new InvalidOperationException("Design dir not found");

        var ccConfigPath = Path.Combine(designDir.FullName, "saved-cards.cardconjurer");
        if (!File.Exists(ccConfigPath))
            throw new InvalidOperationException("Could not find saved-cards.cardconjurer");

        var text = File.ReadAllText(ccConfigPath);
        var root = JsonNode.Parse(text) as JsonArray;
        if (root == null)
            throw new InvalidOperationException("Invalid saved-cards.cardconjurer format");

        foreach (var el in root)
        {
            if (el is JsonObject obj && obj.TryGetPropertyValue("data", out var dataNode) && dataNode is JsonObject data)
            {
                // artSource proxied via CORS proxy
                if (data.TryGetPropertyValue("artSource", out var artNode) && artNode is JsonValue)
                {
                    var artVal = artNode.GetValue<string>() ?? string.Empty;
                    var idx = artVal.IndexOf("corsproxy.io/?url=", StringComparison.OrdinalIgnoreCase);
                    if (idx >= 0)
                    {
                        var encoded = artVal.Substring(idx + "corsproxy.io/?url=".Length);
                        var decoded = WebUtility.UrlDecode(encoded);
                        var qIdx = decoded.IndexOf('?');
                        if (qIdx >= 0) decoded = decoded.Substring(0, qIdx);
                        data["artSource"] = decoded;
                    }
                    else
                    {
                        // handle percent-encoded form like https%3A%2F%2Fcorsproxy.io%2F%3Furl%3D...
                        var encMarker = "https%3A%2F%2Fcorsproxy.io%2F%3Furl%3D";
                        var encIdx = artVal.IndexOf(encMarker, StringComparison.OrdinalIgnoreCase);
                        if (encIdx >= 0)
                        {
                            var encodedPart = artVal.Substring(encIdx + encMarker.Length);
                            var decodedOnce = WebUtility.UrlDecode(encodedPart);
                            var qIdx2 = decodedOnce.IndexOf('?');
                            if (qIdx2 >= 0) decodedOnce = decodedOnce.Substring(0, qIdx2);
                            data["artSource"] = decodedOnce;
                        }
                    }
                }

                // setSymbolSource replacement
                if (data.TryGetPropertyValue("setSymbolSource", out var sNode) && sNode is JsonValue)
                {
                    var sVal = sNode.GetValue<string>() ?? string.Empty;
                    var replaced = sVal.Replace("https://cardconjurer.app", "http://localhost:4242")
                                       .Replace("https%3A%2F%2Fcardconjurer.app", "http%3A%2F%2Flocalhost%3A4242");
                    data["setSymbolSource"] = replaced;
                }

                // watermarkSource replacement
                if (data.TryGetPropertyValue("watermarkSource", out var wNode) && wNode is JsonValue)
                {
                    var wVal = wNode.GetValue<string>() ?? string.Empty;
                    var replaced = wVal.Replace("https://cardconjurer.app", "http://localhost:4242")
                                       .Replace("https%3A%2F%2Fcardconjurer.app", "http%3A%2F%2Flocalhost%3A4242");
                    data["watermarkSource"] = replaced;
                }
            }
        }

        var outPath = Path.Combine(designDir.FullName, "local-saved-cards.cardconjurer");
        File.WriteAllText(outPath, root.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
        await stdout.WriteLineAsync($"Saved: {outPath}");
        return 0;
    }
}

[CliCommand(Name = "stats", Description = "Print stats (rarity distribution and type matrix)")]
public class StatsCommand : BaseCommand
{
    [CliOption(Required = true, Description = "The base content directory")]
    public override required DirectoryInfo BaseDirectory { get; set; }

    [CliOption(Description = "Which table to output: 'bucket', 'type', or 'mana'. Omit to print both.")]
    public StatsType? Type { get; set; }

    [CliOption(Required = false, Description = "Only include cards whose primary type matches (case-insensitive). Example: 'Creature'.")]
    public string? PrimaryType { get; set; }

    [CliOption(Required = false, Description = "Filter results by bucket (e.g., ARTIFACTS, WHITE, MULTICOLOR, or friendly names like Azorius).")]
    public string? Bucket { get; set; }

    [CliOption(Required = false, Description = "Include rows with all-zero totals in the printed tables (default: omit empty rows).")]
    public bool ShowEmptyRows { get; set; } = false;

    [CliOption(Required = false, Description = "Only include cards with any of the specified tags")]
    public string[]? Tags { get; set; }

    protected override async Task<int> ExecuteAsync(CliContext context, TextWriter stdout, TextWriter stderr)
    {
        var cards = await ReadCardDesignsAsync(stdout, stderr, true);

        if (this.Tags is not null)
        {
            var filtered = new SortedDictionary<string, CardMasterDesign>();
            foreach (var kv in cards)
            {
                if (kv.Value.HasAnyTag(this.Tags))
                    filtered.Add(kv.Key, kv.Value);
            }
            cards = filtered;
        }

        // Apply primary-type filter if provided
        if (!string.IsNullOrEmpty(this.PrimaryType))
        {
            var filtered = new SortedDictionary<string, CardMasterDesign>();
            foreach (var kv in cards)
            {
                if (kv.Value.GetPrimaryCategory().Equals(this.PrimaryType, StringComparison.OrdinalIgnoreCase))
                    filtered.Add(kv.Key, kv.Value);
            }
            cards = filtered;
        }

        // Apply bucket filter if provided
        if (!string.IsNullOrEmpty(this.Bucket))
        {
            var b = this.Bucket.Trim();
            var filtered = new SortedDictionary<string, CardMasterDesign>();

            // Try direct bucket match first
            foreach (var kv in cards)
            {
                if (kv.Value.Bucket != null && kv.Value.Bucket.Equals(b, StringComparison.OrdinalIgnoreCase))
                    filtered.Add(kv.Key, kv.Value);
            }

            if (filtered.Count == 0)
            {
                // Try friendly name -> code or direct code (e.g., 'UW', 'URW')
                var code = CardMasterDesign.GetSubBucketCodeFromFriendlyName(b);
                if (code is null)
                    code = b.ToUpperInvariant();

                foreach (var kv in cards)
                {
                    if (kv.Value.MulticolorSubBucket != null && kv.Value.MulticolorSubBucket.Equals(code, StringComparison.OrdinalIgnoreCase))
                        filtered.Add(kv.Key, kv.Value);
                }
            }

            // If still empty, leave it empty per user's instruction
            cards = filtered;
        }

        string output;
        if (Type is null)
        {
            output = StatsPrinter.BuildStats(cards, this.ShowEmptyRows);
        }
        else
        {
            switch (Type.Value)
            {
                case StatsType.Bucket:
                    output = StatsPrinter.BuildBucketTable(cards, this.ShowEmptyRows);
                    break;
                case StatsType.PrimaryType:
                    output = StatsPrinter.BuildTypeTable(cards, this.ShowEmptyRows);
                    break;
                case StatsType.ManaCurve:
                    output = StatsPrinter.BuildManaCurveTable(cards, this.ShowEmptyRows);
                    break;
                default:
                    await stderr.WriteLineAsync("Invalid --type value.");
                    return 1;
            }
        }

        await stdout.WriteLineAsync(output);
        return 0;
    }
}

/// <summary>
/// Validates that no card name overlaps exist across commander decks
/// </summary>
[CliCommand(Name = "commander-validate", Description = "Validate that no card name overlaps exist across commander decks")]
public class CommanderValidateCommand : BaseCommand
{
    [CliOption(Required = true, Description = "The directory containing the commander decks")]
    public override required DirectoryInfo BaseDirectory { get; set; }

    [CliOption(Required = false, Description = "If false, exit 0 even when duplicates are found")]
    public bool FailOnDuplicates { get; set; } = true;
    protected override async Task<int> ExecuteAsync(CliContext context, TextWriter stdout, TextWriter stderr)
    {
        var decks = new Dictionary<string, List<string>>();
        try
        {
            await stdout.WriteLineAsync($"Validating commander decks in: {BaseDirectory}");
            var files = Directory.EnumerateFiles(BaseDirectory.FullName, "*.txt").OrderBy(p => p).ToArray();
            if (files.Length == 0)
            {
                await stderr.WriteLineAsync($"No .txt deck files found in: {BaseDirectory.FullName}");
                return 2;
            }
            foreach (var path in files)
            {
                await stdout.WriteLineAsync($"Processing: {Path.GetFileName(path)}");
                var deckName = Path.GetFileNameWithoutExtension(path);
                var cardsInDeck = new List<string>();
                using var sr = new StreamReader(path);
                string? line;
                string currentSection = "Main";
                while ((line = await sr.ReadLineAsync()) is not null)
                {
                    var trimmed = line.Trim();
                    if (string.IsNullOrWhiteSpace(trimmed))
                        continue;
                    if (trimmed.StartsWith("//"))
                        continue;
                    if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
                    {
                        currentSection = trimmed.Trim('[', ']');
                        continue;
                    }
                    var parts = trimmed.Split(new[] { ' ' }, 2);
                    if (parts.Length > 0)
                    {
                        string? cardName = null;
                        if (parts.Length == 2)
                        {
                            /*
                            if (parts[1].Contains(" // "))
                            {
                                var idx = parts[1].IndexOf(" // ");
                                var first = parts[1].Substring(0, idx).Trim();
                                var second = parts[1].Substring(idx + 4).Trim();
                                if (!string.IsNullOrEmpty(first))
                                    cardsInDeck.Add(first);
                                if (!string.IsNullOrEmpty(second))
                                    cardsInDeck.Add(second);
                            }
                            */
                            cardName = parts[1].Trim();
                        }
                        else
                        {
                            cardName = parts[0].Trim();
                        }
                        if (!string.IsNullOrEmpty(cardName) && cardName != "//")
                            cardsInDeck.Add(cardName);
                    }
                }
                decks[deckName] = cardsInDeck;
            }
            await stdout.WriteLineAsync("");
            await stdout.WriteLineAsync("=== Checking for duplicate card names ===");
            await stdout.WriteLineAsync("");
            var basicLands = new HashSet<string> { "Forest", "Island", "Mountain", "Plains", "Swamp" };
            var commanderCards = new Dictionary<string, HashSet<string>>();
            var seenCards = new Dictionary<string, HashSet<string>>();
            foreach (var (deckName, cards) in decks)
            {
                foreach (var cardName in cards)
                {
                    var tokens = cardName.Trim().Split("|");
                    var norm = tokens[0];
                    var set = tokens[1];
                    if (basicLands.Contains(norm))
                        continue;
                    if (string.IsNullOrEmpty(norm) || norm == "//")
                        continue;
                    if (!seenCards.TryGetValue(norm, out var deckSet))
                    {
                        deckSet = new HashSet<string>();
                        seenCards[norm] = deckSet;
                    }
                    if (!deckSet.Contains(deckName))
                    {
                        deckSet.Add(deckName);
                    }
                    if (set == "E3C")
                    {
                        if (!commanderCards.TryGetValue(deckName, out var cc))
                        {
                            commanderCards[deckName] = new();
                            cc = commanderCards[deckName];
                        }
                        cc.Add(norm);
                    }
                }
            }
            var duplicates = seenCards.Where(c => c.Value.Count > 1).ToList();
            if (duplicates.Count > 0)
            {
                await stdout.WriteLineAsync("=== Duplicate Card Names ===");
                await stdout.WriteLineAsync("");
                foreach (var (duplicateName, deckSet) in duplicates)
                {
                    await stdout.WriteLineAsync($"- \"{duplicateName}\":");
                    foreach (var deck in deckSet.ToList())
                    {
                        await stdout.WriteLineAsync($"  - {deck}");
                    }
                    await stdout.WriteLineAsync("");
                }
                await stdout.WriteLineAsync($"=== Total duplicate card names: {duplicates.Count} ===");
                await stderr.WriteLineAsync("Validation failed: overlapping card names detected");
                return FailOnDuplicates ? 1 : 0;
            }
            else
            {
                await stdout.WriteLineAsync("=== No overlapping card names found ===");
                await stdout.WriteLineAsync("=== Commander cards used amongst decks ===");
                foreach (var (deckName, cc) in commanderCards)
                {
                    await stdout.WriteLineAsync("In deck: " + deckName + " (" + cc.Count +")");
                    foreach (var name in cc.OrderBy(s => s))
                    {
                        await stdout.WriteLineAsync("  - " + name);
                    }
                }
                await stdout.WriteLineAsync("");
                await stdout.WriteLineAsync("All decks are valid.");
                return 0;
            }
        }
        catch (Exception ex)
        {
            await stderr.WriteLineAsync($"Error: {ex.Message}");
            return 2;
        }
    }
}

[CliCommand(
    Children = [
        typeof(GenAllCommand),
        typeof(StatsCommand),
        typeof(CardConjurerValidateCommand),
        typeof(LocalCardConjurerCommand),
        typeof(CommanderValidateCommand)
    ]
)]
public class RootCommand { }
