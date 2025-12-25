using System.Security.Cryptography;

bool CheckFile(string PathToHash)
{
    return File.Exists(PathToHash);
}

string ErrorHandler(string? data)
{
    return
        data == null ? "Failed to Compute the Hash." :
        data == string.Empty ? "File not found." :
        data;
}

string GetFileHash(string PathToHash)
{
    try
    {
        if (CheckFile(PathToHash))
        {
            using var sha256 = SHA256.Create();
            using var stream = File.OpenRead(PathToHash);

            byte[] hashBytes = sha256.ComputeHash(stream);
            return Convert.ToHexString(hashBytes).ToLower();
        }

        return string.Empty;
    }
    catch
    {
        return null;
    }
}

string CompareHashes(string PathToHash, string HashToCheck)
{
    string Hash = GetFileHash(PathToHash);

    return 
        string.IsNullOrEmpty(Hash) ? Hash : 
        Hash == HashToCheck ? "MATCH." : "MISMATCH.";
}

string CommandHelper = "GetFileHash: Hach <PathToHash>\nCompareHashes: Hach <PathToHash> <HashToCheck>";

Console.WriteLine(
    args.Length == 1 ? ErrorHandler(GetFileHash(args[0])) :
    args.Length == 2 ? ErrorHandler(CompareHashes(args[0], args[1])) :
    CommandHelper);