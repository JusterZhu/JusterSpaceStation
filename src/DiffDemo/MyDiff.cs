using System.Security.Cryptography;

namespace DiffDemo;

public class MyDiff
{
    private static readonly List<string> DefaultBlackFileFormats = new List<string>
    {
        ".patch",
        ".7z",
        ".zip",
        ".rar",
        ".tar",
        ".json"
    };

    private static readonly List<string> DefaultBlackFiles = new List<string> { "Newtonsoft.Json.dll" };

    public static void CompareDirectories(string dirA, string dirB, List<string> uniqueToA, List<string> uniqueToB, List<string> differentFiles)
    {
        var filesA = GetRelativeFilePaths(dirA, dirA).Where(f => !IsBlacklisted(f)).ToList();
        var filesB = GetRelativeFilePaths(dirB, dirB).Where(f => !IsBlacklisted(f)).ToList();

        uniqueToA.AddRange(filesA.Except(filesB).Select(f => Path.Combine(dirA, f)));
        uniqueToB.AddRange(filesB.Except(filesA).Select(f => Path.Combine(dirB, f)));

        var commonFiles = filesA.Intersect(filesB);

        foreach (var file in commonFiles)
        {
            var fileA = Path.Combine(dirA, file);
            var fileB = Path.Combine(dirB, file);

            if (!FilesAreEqual(fileA, fileB))
            {
                differentFiles.Add(file);
            }
        }
    }

    static IEnumerable<string> GetRelativeFilePaths(string rootDir, string currentDir)
    {
        foreach (var file in Directory.GetFiles(currentDir))
        {
            yield return Path.GetRelativePath(rootDir, file);
        }

        foreach (var dir in Directory.GetDirectories(currentDir))
        {
            foreach (var file in GetRelativeFilePaths(rootDir, dir))
            {
                yield return file;
            }
        }
    }

    static bool IsBlacklisted(string relativeFilePath)
    {
        var fileName = Path.GetFileName(relativeFilePath);
        var fileExtension = Path.GetExtension(relativeFilePath);

        return DefaultBlackFiles.Contains(fileName) || DefaultBlackFileFormats.Contains(fileExtension);
    }

    static bool FilesAreEqual(string fileA, string fileB)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashA = sha256.ComputeHash(File.ReadAllBytes(fileA));
            var hashB = sha256.ComputeHash(File.ReadAllBytes(fileB));

            return hashA.SequenceEqual(hashB);
        }
    }
}