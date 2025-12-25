using System.Security.Cryptography;

string? GetFileHash(string PathToHash)
{
    try
    {
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

string VerifyHash(string PathToHash, string HashToCheck)
{
    string? FileHash = GetFileHash(PathToHash);

    return FileHash == null
        ? "Failed to Compute the Hash." : FileHash == HashToCheck ? "MATCH." : "MISMATCH.";
}

string CommandHelper = "GetFileHash: Hach <PathToHash>\nVerifyHash: Hach <PathToHash> <HashToCheck>";

Console.WriteLine(
    args.Length == 1 ? GetFileHash(args[0]) :
    args.Length == 2 ? VerifyHash(args[0], args[1]) :
    CommandHelper);