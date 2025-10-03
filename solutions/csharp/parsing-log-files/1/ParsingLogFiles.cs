using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text) =>
        Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");

    public string[] SplitLogLine(string text) => 
        Regex.Split(text,  @"<[\^*=-]+>");

    public int CountQuotedPasswords(string lines) =>
        Regex.Matches(lines, @""".*password.*""", RegexOptions.IgnoreCase).Count;

    public string RemoveEndOfLineText(string line) =>
        Regex.Replace(line, @"end-of-line\d+", string.Empty);

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var processedLines = new List<string>();
        foreach(string line in lines)
        {
            Match passwordMatch = Regex.Match(line, @"password\w+", RegexOptions.IgnoreCase);
            if (passwordMatch == Match.Empty)
                processedLines.Add($"--------: {line}");
            else 
                processedLines.Add($"{passwordMatch.Value}: {line}");
        }
        return processedLines.ToArray();
    }
}
