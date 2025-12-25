using System.Security.Cryptography;

bool CheckFile(string PathToHash)
{
    return File.Exists(PathToHash) ? true : false;
}

string? GetFileHash(string PathToHash)
{
    try
    {
        if (!CheckFile(PathToHash))
            return string.Empty;

        using var sha256 = SHA256.Create();
        using var stream = File.OpenRead(PathToHash);

        byte[] hashBytes = sha256.ComputeHash(stream);
        return Convert.ToHexString(hashBytes).ToLower();
    }
    catch
    {
        return null;
    }
}

string CompareHashes(string PathToHash, string HashToCheck)
{
    string? FileHash = GetFileHash(PathToHash);

    return 
        FileHash == null ? "Failed to Compute the Hash." : 
        FileHash == string.Empty ? "File not found." : 
        FileHash == HashToCheck ? "MATCH." : "MISMATCH.";
}

string CommandHelper = "GetFileHash: Hach <PathToHash>\nCompareHashes: Hach <PathToHash> <HashToCheck>";

Console.WriteLine(
    args.Length == 1 ? GetFileHash(args[0]) :
    args.Length == 2 ? CompareHashes(args[0], args[1]) :
    CommandHelper);