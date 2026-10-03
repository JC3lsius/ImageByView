namespace ImageByView.Core;

using System.Drawing;

// No AI written

public class ImageFolder
{
    private static readonly HashSet<string> PicExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg",
        ".jpeg",
        ".png",
        ".gif",
        ".bmp",
        ".tiff",
        ".tif",
        ".webp",
        ".ico",
        ".heic",
        ".heif",
        ".svg",
        ".emf",
        ".wmf"
    };

    public static IReadOnlyList<string> GetFolderPics(string folderRoute)
    {
        List<string> pics = new List<string>();
        string[] files = Directory.GetFiles(folderRoute);

        foreach (string file in files)
        {         
            string extension = Path.GetExtension(file);
            if (PicExtensions.Contains(extension)) pics.Add(file);
        }

        return pics;
    }
}
