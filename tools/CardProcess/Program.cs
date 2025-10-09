using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using DotMake.CommandLine;

await Cli.RunAsync<RootCommand>(args);

public class CardFaceDesign
{
    public string? Name { get; set; }

    public string[]? ManaCost { get; set; }

    public string[]? ColorIdentity { get; set; }

    public string[]? Types { get; set; }

    public string[]? Oracle { get; set; }

    public string[]? FlavorText { get; set; }

    public string[]? DesignNotes { get; set; }

    public string[]? Bugs { get; set; }

    public string? PT { get; set; }

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
            case nameof(Types):
                Types = buffer.ToArray();
                break;
            case nameof(Oracle):
                Oracle = buffer.ToArray();
                break;
            case nameof(FlavorText):
                FlavorText = buffer.ToArray();
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
        }
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
                case "[ManaCost]":
                case "[Types]":
                case "[Oracle]":
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
                case "ALTERNATIVE:FUSE": // Signal start of new active face
                    card.MarkFused();
                    break;
                case "ALTERNATIVE:MELD": // Signal start of new active face
                    card.MarkMeld();
                    break;
                default:
                    buffer.Add(line);
                    break;
            }
            line = await sr.ReadLineAsync();
        }

        // Apply remaining buffer
        if (buffer.Count > 0 && activePropertyName != null)
        {
            card.Apply(activePropertyName, buffer);
        }

        return card.Finalize();
    }
}

public class CardScript(string scriptRelPath)
{
    public string ScriptRelPath { get; } = scriptRelPath;

    public string? Name { get; set; }

    public string[]? ManaCost { get; set; }

    public List<string> DesignNotes { get; } = new();

    public string FormatManaCost()
    {
        return string.Join(string.Empty, ManaCost.Select(mc => FormatPip(mc)));
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

    public string[]? ColorIdentity { get; set; }

    internal void ProcessTypeLine(string typeLine)
    {
        this.TypeLineRaw = typeLine;
        var tokens = typeLine.Split(" ").ToList();

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
                        mostSignificantIdx = i;
                        break;
                }
            }
        }
        if (mostSignificantIdx < tokens.Count - 1)
        {
            tokens.Insert(mostSignificantIdx + 1, "-");
        }

        this.TypeLine = string.Join(" ", tokens);
    }

    public string? TypeLineRaw { get; set; }

    public string? TypeLine { get; set; }

    public string? OracleText { get; set; }

    internal void ProcessOracleText(string oracle)
    {
        this.OracleText = string.Join("\n", oracle.Split("\\n", StringSplitOptions.RemoveEmptyEntries));
    }

    public string? Bucket { get; set; }

    public string? PT { get; set; }

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

    internal CardScript Finalize()
    {
        // Determine bucket
        var colors = new HashSet<string>();
        // Check cost
        if (this.ManaCost != null)
        {
            foreach (var token in this.ManaCost)
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
        if (this.ColorIdentity != null)
        {
            foreach (var color in ColorIdentity)
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

        if (colors.Count > 0)
        {
            if (colors.Count > 1)
                this.Bucket = "MULTICOLOR";
            else
                this.Bucket = colors.First();
        }
        else
        {
            if (this.TypeLine?.Contains("Land") == true)
                this.Bucket = "LANDS";
            else if (this.TypeLine?.Contains("Artifact") == true)
                this.Bucket = "ARTIFACTS";
        }

        return this;
    }

    [MemberNotNullWhen(true, nameof(Name))]
    [MemberNotNullWhen(true, nameof(Bucket))]
    [MemberNotNullWhen(true, nameof(OracleText))]
    [MemberNotNullWhen(true, nameof(TypeLine))]
    internal bool IsValid()
    {
        return !string.IsNullOrEmpty(Name)
            && !string.IsNullOrEmpty(Bucket)
            && (!string.IsNullOrEmpty(OracleText) || (string.IsNullOrEmpty(OracleText) && !string.IsNullOrEmpty(PT)))
            && !string.IsNullOrEmpty(TypeLine);
    }

    public static async Task<CardScript> ReadAsync(DirectoryInfo baseDir, string path)
    {
        var card = new CardScript(Path.GetRelativePath(baseDir.FullName, path));
        using var sr = new StreamReader(path);
        var line = await sr.ReadLineAsync();
        bool bInsideNotes = false;
        while (line is not null)
        {
            if (line.StartsWith("Name:"))
                card.Name = line.Substring("Name:".Length);
            if (line.StartsWith("ManaCost:") && !line.Contains("no cost"))
                card.ManaCost = line.Substring("ManaCost:".Length).Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (line.StartsWith("Colors:"))
                card.ColorIdentity = line.Substring("Colors:".Length).Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (line.StartsWith("Types:"))
                card.ProcessTypeLine(line.Substring("Types:".Length));
            if (line.StartsWith("Oracle:"))
                card.ProcessOracleText(line.Substring("Oracle:".Length));
            if (line.StartsWith("PT:"))
                card.PT = line.Substring("PT:".Length);

            if (line.StartsWith("#NOTESBEGIN"))
                bInsideNotes = true;
            if (line.StartsWith("#NOTESEND"))
                bInsideNotes = false;

            if (bInsideNotes && !line.StartsWith("#NOTESBEGIN"))
                card.DesignNotes.Add(line.Substring(1));

            line = await sr.ReadLineAsync();
        }
        return card.Finalize();
    }

    internal async Task WriteAsync(StreamWriter writer)
    {
        await writer.WriteLineAsync($"## {this.Name}");
        await writer.WriteLineAsync();
        await writer.WriteLineAsync("```");
        if (this.ManaCost is not null)
            await writer.WriteLineAsync(this.FormatManaCost());
        await writer.WriteLineAsync(this.TypeLine);
        await writer.WriteLineAsync(this.OracleText);
        if (this.PT is not null)
        {
            await writer.WriteLineAsync();
            await writer.WriteLineAsync(this.PT);
        }
        await writer.WriteLineAsync("```");
        await writer.WriteLineAsync();
        await writer.WriteLineAsync($"[card implementation]({this.ScriptRelPath})");
        await writer.WriteLineAsync();
        await writer.WriteLineAsync("### Design Notes");
        await writer.WriteLineAsync();
        if (this.DesignNotes.Count > 0)
        {
            foreach (var n in this.DesignNotes)
            {
                await writer.WriteLineAsync(n);
            }
            await writer.WriteLineAsync();
        }
    }
}

public class CardDocWriter(string path)
{

}

public abstract class BaseCommand
{
    public abstract required DirectoryInfo BaseDirectory { get; set; }

    public Task<int> RunAsync(CliContext context) => ExecuteAsync(context, Console.Out, Console.Error);

    protected abstract Task<int> ExecuteAsync(CliContext context, TextWriter stdout, TextWriter stderr);
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
        var subDirs = this.BaseDirectory.GetDirectories();
        var cardsDir = subDirs.FirstOrDefault(d => d.Name == "cards");
        var editionsDir = subDirs.FirstOrDefault(d => d.Name == "editions");
        var tokensDir = subDirs.FirstOrDefault(d => d.Name == "tokens");
        if (cardsDir is null)
            throw new InvalidOperationException("Cards dir not found");
        if (editionsDir is null)
            throw new InvalidOperationException("Editions dir not found");
        if (tokensDir is null)
            throw new InvalidOperationException("Tokens dir not found");

        var cards = new SortedDictionary<string, CardScript>();
        foreach (var scriptFile in Directory.EnumerateFiles(cardsDir.FullName, "*.txt", SearchOption.AllDirectories))
        {
            await stdout.WriteLineAsync($"Processing: {scriptFile}");
            var card = await CardScript.ReadAsync(this.BaseDirectory, scriptFile);
            if (card.IsValid())
                cards.Add(card.Name, card);
            else
                await stderr.WriteLineAsync($"Card script not valid!");
        }

        await stdout.WriteLineAsync($"Processed: {cards.Count} cards");

        var writers = new Dictionary<string, StreamWriter>();
        // Now write docs
        foreach (var kvp in cards)
        {
            var card = kvp.Value;
            if (!writers.TryGetValue(card.Bucket!, out var writer))
            {
                writer = new StreamWriter(Path.Combine(this.OutputDir.FullName, card.Bucket + ".md"));
                await writer.WriteLineAsync("# Cards");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync($"> Last generated: {DateTime.UtcNow}");
                await writer.WriteLineAsync();
                writers[card.Bucket!] = writer;
            }
            await card.WriteAsync(writer);            
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

[CliCommand(Children = [typeof(GenDocsCommand)])]
public class RootCommand
{
}