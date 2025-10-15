using System.Diagnostics;
using System.Text;
using DotMake.CommandLine;

await Cli.RunAsync<RootCommand>(args);

public class CardFaceDesign
{
    public string? Name { get; set; }

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

    public string[]? Bugs { get; set; }

    public string? PT { get; set; }

    public string? Loyalty { get; set; }

    public string? Rarity { get; set; }

    public string? Artist { get; set; }

    public string? ArtImage { get; set; }

    public string? ArtNotes { get; set; }

    internal void Apply(string propertyName, IEnumerable<string> buffer)
    {
        switch (propertyName)
        {
            case nameof(Name):
                Name = string.Join(" ", buffer);
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
            case nameof(ArtImage):
                ArtImage = string.Join(" ", buffer);
                break;
            case nameof(ArtNotes):
                ArtNotes = string.Join("\n", buffer);
                break;
            case nameof(Types):
                {
                    Types = buffer.ToArray();
                    var tokens = Types.ToList();

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

                    this.TypeLine = string.Join(" ", tokens);
                }
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
        }
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
            // HACK: WriteAsync seems to be interleave the line content, whereas sync Write does not
            if (faceType == CardFaceType.SplitRoom)
                sw.Write($"Oracle:(You may cast either half. That door unlocks on the battlefield. As a sorcery, you may pay the mana cost of a locked door to unlock it.)\\n{string.Join("\\n", oracle)}");
            else if (faceType == CardFaceType.SplitFuse)
                sw.Write($"Oracle:{string.Join("\\n", oracle)}\\nFuse (You may cast one or both halves of this card from your hand.)");
            else
                sw.Write($"Oracle:{string.Join("\\n", oracle)}");
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
        sb.Replace("$LEGENDARY_SORCERY_REMINDER_TEXT", "(You may cast a legendary sorcery only if you control a legendary creature or planeswalker.)");
        sb.Replace("$INVESTIGATE_REMINDER_TEXT", "(Create a Clue token. It's an artifact with \"{2}, Sacrifice this token: Draw a card.\")");
        sb.Replace("$CHROMA_REMINDER_TEXT", "(It's an artifact with \"{T}, Sacrifice this token: Add one mana of any color. Spend this mana only to cast a Nevron, Gestral or Expeditioner spell.\")");
        sb.Replace("$LUMINA_REMINDER_TEXT", "(It's an artifact with \"{T}, Sacrifice this token: Sacrifice this token: Scry 1.\")");
        sb.Replace("$EXPEDITIONER_TOKEN_TEXT", "\"When this creature dies, create a Chroma token.\"");
        sb.Replace("$NEVRON_DEATH_ABILITY_TEXT", "When this creature dies, target opponent creates a Lumina token.");
        sb.Replace("$EXPEDITIONER_DEATH_ABILITY_TEXT", "When this creature dies, create a Chroma token.");
        return sb.ToString();
    }

    internal string GetOracleText()
    {
        var origCardName = this.Name;
        var thisName = origCardName;
        var ht = (this.Types ?? []).ToHashSet();
        var sb = new StringBuilder(this.OracleTextFull);
        if (ht.Contains("Instant") || ht.Contains("Sorcery"))
            thisName = "this spell";
        if (ht.Contains("Creature"))
            thisName = "this creature";
        if (ht.Contains("Enchantment"))
            thisName = "this enchantment";
        if (ht.Contains("Artifact"))
        {
            if (ht.Contains("Vehicle"))
                thisName = "this vehicle";
            else if (ht.Contains("Creature"))
                thisName = "this creature";
            else
                thisName = "this artifact";
        }
        if (ht.Contains("Land"))
            thisName = "this land";

        if (ht.Contains("Legendary") && ht.Contains("Creature") && origCardName?.Contains(",") == true)
            thisName = origCardName.Substring(origCardName.IndexOf(","));

        sb.Replace(". ~", ". " + (string.IsNullOrEmpty(thisName) ? thisName : char.ToUpper(thisName[0]) + thisName.Substring(1)));
        sb.Replace("\n~", "\n" + (string.IsNullOrEmpty(thisName) ? thisName : char.ToUpper(thisName[0]) + thisName.Substring(1)));
        sb.Replace("~", thisName);
        sb.Replace("$DEVOID_REMINDER_TEXT", "(This card has no color.)");
        sb.Replace("$LEGENDARY_SORCERY_REMINDER_TEXT", "(You may cast a legendary sorcery only if you control a legendary creature or planeswalker.)");
        sb.Replace("$INVESTIGATE_REMINDER_TEXT", "(Create a Clue token. It's an artifact with \"{2}, Sacrifice this token: Draw a card.\")");
        sb.Replace("$CHROMA_REMINDER_TEXT", "(It's an artifact with \"{T}, Sacrifice this token: Add one mana of any color. Spend this mana only to cast a Nevron, Gestral or Expeditioner spell.\")");
        sb.Replace("$LUMINA_REMINDER_TEXT", "(It's an artifact with \"{T}, Sacrifice this token: Sacrifice this token: Scry 1.\")");
        sb.Replace("$EXPEDITIONER_TOKEN_TEXT", "\"When this creature dies, create a Chroma token.\"");
        sb.Replace("$NEVRON_DEATH_ABILITY_TEXT", "When this creature dies, target opponent creates a Lumina token.");
        sb.Replace("$EXPEDITIONER_DEATH_ABILITY_TEXT", "When this creature dies, create a Chroma token.");
        sb.Replace("$STORM_REMINDER_TEXT", "(When you cast this spell, copy it for each spell cast before it this turn. You may choose new targets for the copies.)");

        if (sb.Length > 0)
        {
            sb[0] = char.ToUpper(sb[0]);
        }
        return sb.ToString();
    }
}

/// <summary>
/// The type of this card design
/// </summary>
public enum CardFaceType
{
    Regular,
    SplitRoom,
    SplitFuse,
    Meld
}

/// <summary>
/// The type of split card we're dealing with
/// </summary>
public enum SplitKind
{
    Room,
    Fuse
}

public class CardMasterDesign(string designFile)
{
    private CardFaceDesign _activeFace = new();

    public CardFaceDesign? FrontFull { get; set; }

    public CardFaceDesign? SplitLeft { get; set; }

    public CardFaceDesign? SplitRight { get; set; }

    public CardFaceDesign? MeldTarget { get; set; }

    private SplitKind? _splitKind;

    public CardFaceType? FaceType { get; set; }

    public bool IsToken { get; set; }

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
                _ => throw new UnreachableException()
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

    public bool IsValid()
    {
        return this.FaceType.HasValue && this.Bucket is not null && this.Rarity is not null;
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
                CardFaceType.SplitRoom => SplitLeft.Name + " // " + SplitRight.Name,
                CardFaceType.SplitFuse => SplitLeft.Name + " // " + SplitRight.Name,
                CardFaceType.Meld => FrontFull.Name + " // " + MeldTarget.Name,
                _ => throw new UnreachableException()
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

    public string? Bucket { get; set; }

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

    internal CardMasterDesign Finalize()
    {
        if (!_splitKind.HasValue)
        {
            if (MeldTarget is not null)
            {
                FaceType = CardFaceType.Meld;
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
        }
        // There are no split/meld artifacet or colorless cards, so if no color identity could be determined it is 99% should be a regular card
        else if (this.FrontFull is not null)
        {
            if (this.FrontFull.Types?.Contains("Land") == true)
                this.Bucket = "LANDS";
            else if (this.FrontFull.Types?.Contains("Artifact") == true)
                this.Bucket = "ARTIFACTS";
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

    public void Apply(string propertyName, IEnumerable<string> buffer)
    {
        _activeFace.Apply(propertyName, buffer);
    }

    public static async Task<CardMasterDesign> ReadAsync(DirectoryInfo baseDir, string path)
    {
        var card = new CardMasterDesign(Path.GetRelativePath(baseDir.FullName, path));
        using var sr = new StreamReader(path);
        var line = await sr.ReadLineAsync();
        var buffer = new List<string>();
        string? activePropertyName = null;
        while (line is not null)
        {
            switch (line)
            {
                case "[Name]":
                case "[Rarity]":
                case "[Artist]":
                case "[ArtImage]":
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
                case "[Bugs]":
                case "[Loyalty]":
                case "[Colors]":
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
        using var fw = fi.OpenWrite();
        fw.Position = 0L;
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
            return this.Name.ToLower().Replace(" // ", "_").Replace(":", "").Replace("'", "").Replace("!", "").Replace(",", "").Replace(" ", "_");
        }
    }

    public IEnumerable<string> AllDesignNotes => [.. FrontFull?.DesignNotes ?? [], .. SplitLeft?.DesignNotes ?? [], .. SplitRight?.DesignNotes ?? [], .. MeldTarget?.DesignNotes ?? []];

    internal async Task WriteDocAsync(string baseDir, StreamWriter writer, TextWriter stdout, TextWriter stderr)
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
                    await writer.WriteLineAsync();
                    await writer.WriteLineAsync("### Design Notes");
                    await writer.WriteLineAsync();
                    foreach (var n in this.AllDesignNotes)
                    {
                        await writer.WriteLineAsync(n);
                    }
                    await writer.WriteLineAsync();
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
                    await writer.WriteLineAsync();
                    await writer.WriteLineAsync("### Design Notes");
                    await writer.WriteLineAsync();
                    foreach (var n in this.AllDesignNotes)
                    {
                        await writer.WriteLineAsync(n);
                    }
                    await writer.WriteLineAsync();
                }
                break;
            case CardFaceType.Meld:
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
                    await writer.WriteLineAsync("Melds into:");
                    await writer.WriteLineAsync();
                    await writer.WriteLineAsync("```");
                    if (MeldTarget?.ManaCost is not null)
                        await writer.WriteLineAsync(MeldTarget.FormatManaCost());
                    await writer.WriteLineAsync(MeldTarget.TypeLine);
                    await writer.WriteLineAsync(MeldTarget.GetOracleText());
                    if (MeldTarget.PT is not null)
                    {
                        await writer.WriteLineAsync();
                        await writer.WriteLineAsync(MeldTarget.PT);
                    }
                    await writer.WriteLineAsync("```");

                    await writer.WriteLineAsync();
                    if (FrontFull?.ForgeScript is null || MeldTarget?.ForgeScript is null)
                        await writer.WriteLineAsync("> This card is not yet implemented in Forge");
                    else
                        await writer.WriteLineAsync($"[card implementation]({normBaseDir}/{firstLetter}/{scriptName})");
                    await writer.WriteLineAsync();
                    await writer.WriteLineAsync("### Design Notes");
                    await writer.WriteLineAsync();
                    foreach (var n in this.AllDesignNotes)
                    {
                        await writer.WriteLineAsync(n);
                    }
                    await writer.WriteLineAsync();
                }
                break;
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
}

public abstract class BaseCommand
{
    public abstract required DirectoryInfo BaseDirectory { get; set; }

    public Task<int> RunAsync(CliContext context) => ExecuteAsync(context, Console.Out, Console.Error);

    protected abstract Task<int> ExecuteAsync(CliContext context, TextWriter stdout, TextWriter stderr);

    protected async Task<SortedDictionary<string, CardMasterDesign>> ReadCardDesignsAsync(TextWriter stdout, TextWriter stderr)
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

            await stdout.WriteLineAsync($"Processing: {scriptFile}");
            var card = await CardMasterDesign.ReadAsync(this.BaseDirectory, scriptFile);
            if (card.IsValid())
                cards.Add(card.Name, card);
            else
                await stderr.WriteLineAsync($"Card script not valid!");
        }

        await stdout.WriteLineAsync($"Read: {cards.Count} cards");
        return cards;
    }
}

[CliCommand(Name = "genscripts", Description = "Generate card scripts")]
public class GenCardScriptsCommand : BaseCommand
{
    // HACK: Source generator won't generate if attribute placed on base property, so that has been made
    // abstract and we're decorating here
    [CliOption(Required = true, Description = "The base content directory")]
    public override required DirectoryInfo BaseDirectory { get; set; }

    protected override async Task<int> ExecuteAsync(CliContext context, TextWriter stdout, TextWriter stderr)
    {
        var subDirs = this.BaseDirectory.GetDirectories();
        var cardsDir = subDirs.FirstOrDefault(d => d.Name == "cards");
        var tokensDir = subDirs.FirstOrDefault(d => d.Name == "tokens");
        if (cardsDir is null)
            throw new InvalidOperationException("cards dir not found");
        if (tokensDir is null)
            throw new InvalidOperationException("tokens dir not found");

        var cards = await ReadCardDesignsAsync(stdout, stderr);
        foreach (var (name, card) in cards)
        {
            await card.WriteScriptAsync(cardsDir, tokensDir, stdout, stderr);
        }

        return 0;
    }
}

[CliCommand(Name = "gendocs", Description = "Generate design docs")]
public class GenDocsCommand : BaseCommand
{
    // HACK: Source generator won't generate if attribute placed on base property, so that has been made
    // abstract and we're decorating here
    [CliOption(Required = true, Description = "The base content directory")]
    public override required DirectoryInfo BaseDirectory { get; set; }

    [CliOption(Required = true, Description = "The output directory")]
    public required DirectoryInfo OutputDir { get; set; }

    protected override async Task<int> ExecuteAsync(CliContext context, TextWriter stdout, TextWriter stderr)
    {
        var cards = await ReadCardDesignsAsync(stdout, stderr);
        var writers = new Dictionary<string, StreamWriter>();
        var scriptBaseDir = Path.GetRelativePath(
            OutputDir.FullName,
            Path.Combine(BaseDirectory.FullName, "cards")
        );
        // Now write docs
        foreach (var (name, card) in cards)
        {
            if (card.IsToken)
                continue;

            if (!writers.TryGetValue(card.Bucket!, out var writer))
            {
                writer = new StreamWriter(Path.Combine(this.OutputDir.FullName, card.Bucket + ".md"));
                await writer.WriteLineAsync("# Cards");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync($"> Last generated: {DateTime.UtcNow}");
                await writer.WriteLineAsync();
                writers[card.Bucket!] = writer;
            }
            await card.WriteDocAsync(scriptBaseDir, writer, stdout, stderr);
        }

        // Close all writers
        foreach (var kvp in writers)
        {
            kvp.Value.Close();
            kvp.Value.Dispose();
        }

        return 0;
    }
}

[CliCommand(Name = "genedition", Description = "Generate set edition file")]
public class GenEditionCommand : BaseCommand
{
    // HACK: Source generator won't generate if attribute placed on base property, so that has been made
    // abstract and we're decorating here
    [CliOption(Required = true, Description = "The base content directory")]
    public override required DirectoryInfo BaseDirectory { get; set; }

    protected override async Task<int> ExecuteAsync(CliContext context, TextWriter stdout, TextWriter stderr)
    {
        var subDirs = this.BaseDirectory.GetDirectories();
        var editionsDir = subDirs.FirstOrDefault(d => d.Name == "editions");
        var designDir = subDirs.FirstOrDefault(d => d.Name == "design");
        if (editionsDir is null)
            throw new InvalidOperationException("editions dir not found");
        if (designDir is null)
            throw new InvalidOperationException("design dir not found");
        var templateFile = Path.Combine(designDir.FullName, "edition.tpl");
        if (!File.Exists(templateFile))
            throw new InvalidOperationException("Could not find edition.tpl");

        int collectorNum = 1;
        var cardList = new StringBuilder();
        var cards = await ReadCardDesignsAsync(stdout, stderr);
        foreach (var (name, card) in cards)
        {
            if (card.FaceType == CardFaceType.Meld) // Meld cards only care about the front face name
                cardList.AppendLine($"{collectorNum} {card.Rarity} {card.FrontFull.Name} @{card.GetArtist()}");
            else
                cardList.AppendLine($"{collectorNum} {card.Rarity} {name} @{card.GetArtist()}");
            collectorNum++;
        }

        var sbEdition = new StringBuilder(File.ReadAllText(templateFile));
        sbEdition.Replace("$CARD_LIST$", cardList.ToString());
        File.WriteAllText(Path.Combine(editionsDir.FullName, "Clair Obscur Expedition 33.txt"), sbEdition.ToString());

        await stdout.WriteLineAsync("Updated edition file");

        return 0;
    }
}

[CliCommand(Name = "genbugs", Description = "Generate bug list")]
public class GenBugsCommand : BaseCommand
{
    // HACK: Source generator won't generate if attribute placed on base property, so that has been made
    // abstract and we're decorating here
    [CliOption(Required = true, Description = "The base content directory")]
    public override required DirectoryInfo BaseDirectory { get; set; }

    [CliOption(Required = true, Description = "The output directory")]
    public required DirectoryInfo OutputDir { get; set; }

    protected override async Task<int> ExecuteAsync(CliContext context, TextWriter stdout, TextWriter stderr)
    {
        var bugsFile = Path.Combine(this.OutputDir.FullName, "BUGS.md");
        using var sw = new StreamWriter(bugsFile);

        await sw.WriteLineAsync("# General");
        await sw.WriteLineAsync();
        await sw.WriteLineAsync("# Card-specific");
        await sw.WriteLineAsync();

        var cards = await ReadCardDesignsAsync(stdout, stderr);
        foreach (var (name, card) in cards)
        {
            await card.WriteBugsAsync(sw);
        }

        await stdout.WriteLineAsync("Updated bugs file");

        return 0;
    }
}

[CliCommand(Name = "genall", Description = "Generate all outputs (scripts, docs, edition, bugs)")]
public class GenAllCommand : BaseCommand
{
    [CliOption(Required = true, Description = "The base content directory")]
    public override required DirectoryInfo BaseDirectory { get; set; }

    [CliOption(Required = true, Description = "The output directory")]
    public required DirectoryInfo OutputDir { get; set; }

    protected override async Task<int> ExecuteAsync(
        CliContext context,
        TextWriter stdout,
        TextWriter stderr
    )
    {
        // Read cards once for all operations
        var cards = await ReadCardDesignsAsync(stdout, stderr);

        // 1. Generate card scripts (from GenCardScriptsCommand)
        await stdout.WriteLineAsync("Generating card scripts...");
        var subDirs = this.BaseDirectory.GetDirectories();
        var cardsDir = subDirs.FirstOrDefault(d => d.Name == "cards");
        var tokensDir = subDirs.FirstOrDefault(d => d.Name == "tokens");
        if (cardsDir is null)
            throw new InvalidOperationException("cards dir not found");
        if (tokensDir is null)
            throw new InvalidOperationException("tokens dir not found");

        foreach (var (name, card) in cards)
        {
            await card.WriteScriptAsync(cardsDir, tokensDir, stdout, stderr);
        }

        // 2. Generate docs (from GenDocsCommand)
        await stdout.WriteLineAsync("Generating documentation...");
        var writers = new Dictionary<string, StreamWriter>();
        var scriptBaseDir = Path.GetRelativePath(
            OutputDir.FullName,
            Path.Combine(BaseDirectory.FullName, "cards")
        );

        foreach (var (name, card) in cards)
        {
            if (card.IsToken)
                continue;

            if (!writers.TryGetValue(card.Bucket!, out var writer))
            {
                writer = new StreamWriter(
                    Path.Combine(this.OutputDir.FullName, card.Bucket + ".md")
                );
                await writer.WriteLineAsync("# Cards");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync($"> Last generated: {DateTime.UtcNow}");
                await writer.WriteLineAsync();
                writers[card.Bucket!] = writer;
            }
            await card.WriteDocAsync(scriptBaseDir, writer, stdout, stderr);
        }

        foreach (var kvp in writers)
        {
            kvp.Value.Close();
            kvp.Value.Dispose();
        }

        // 3. Generate edition (from GenEditionCommand)
        await stdout.WriteLineAsync("Generating edition file...");
        var editionsDir = subDirs.FirstOrDefault(d => d.Name == "editions");
        var designDir = subDirs.FirstOrDefault(d => d.Name == "design");
        if (editionsDir is null)
            throw new InvalidOperationException("editions dir not found");
        if (designDir is null)
            throw new InvalidOperationException("design dir not found");
        var templateFile = Path.Combine(designDir.FullName, "edition.tpl");
        if (!File.Exists(templateFile))
            throw new InvalidOperationException("Could not find edition.tpl");

        int collectorNum = 1;
        var cardList = new StringBuilder();
        foreach (var (name, card) in cards)
        {
            if (card.FaceType == CardFaceType.Meld)
                cardList.AppendLine(
                    $"{collectorNum} {card.Rarity} {card.FrontFull.Name} @{card.GetArtist()}"
                );
            else
                cardList.AppendLine($"{collectorNum} {card.Rarity} {name} @{card.GetArtist()}");
            collectorNum++;
        }

        var sbEdition = new StringBuilder(File.ReadAllText(templateFile));
        sbEdition.Replace("$CARD_LIST$", cardList.ToString());
        File.WriteAllText(
            Path.Combine(editionsDir.FullName, "Clair Obscur Expedition 33.txt"),
            sbEdition.ToString()
        );

        await stdout.WriteLineAsync("Updated edition file");

        // 4. Generate bugs (from GenBugsCommand)
        await stdout.WriteLineAsync("Generating bugs file...");
        var bugsFile = Path.Combine(this.OutputDir.FullName, "BUGS.md");
        using var sw = new StreamWriter(bugsFile);

        await sw.WriteLineAsync("# General");
        await sw.WriteLineAsync();
        await sw.WriteLineAsync("# Card-specific");
        await sw.WriteLineAsync();

        foreach (var (name, card) in cards)
        {
            await card.WriteBugsAsync(sw);
        }

        await stdout.WriteLineAsync("Updated bugs file");

        await stdout.WriteLineAsync("All generation tasks completed successfully!");

        return 0;
    }
}

[CliCommand(
    Children = [
        typeof(GenDocsCommand),
        typeof(GenCardScriptsCommand),
        typeof(GenEditionCommand),
        typeof(GenBugsCommand),
        typeof(GenAllCommand),
    ]
)]
public class RootCommand { }
