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

        return ErrorHandler(string.Empty);
    }
    catch
    {
        return ErrorHandler(null);
    }
}

string CompareHashes(string PathToHash, string HashToCheck)
{
    return GetFileHash(PathToHash) == HashToCheck ? "MATCH." : "MISMATCH.";
}

string CommandHelper = "GetFileHash: Hach <PathToHash>\nCompareHashes: Hach <PathToHash> <HashToCheck>";

Console.WriteLine(
    args.Length == 1 ? GetFileHash(args[0]) :
    args.Length == 2 ? CompareHashes(args[0], args[1]) :
    CommandHelper);