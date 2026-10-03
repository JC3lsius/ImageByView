namespace ImageByView.Core;

using System.Drawing;

// No AI written

public class ImageFolder
{
    private static readonly HashSet<string> PicExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        // JPEG y variantes
    ".jpg", ".jpeg", ".jpe", ".jfif",

    // Formatos clásicos (Windows los abre de serie)
    ".png", ".gif", ".bmp", ".dib", ".tif", ".tiff", ".ico",

    // JPEG XR (de serie)
    ".jxr", ".wdp", ".hdp",

    // Formatos modernos (necesitan extensiones gratuitas de Microsoft Store)
    ".webp",                    // de serie en Windows 11; en Windows 10, "Webp Image Extensions"
    ".heic", ".heif", ".hif",   // "HEIF Image Extensions" (iPhone, algunas Canon y Fujifilm)
    ".avif",                    // "AV1 Video Extension"
    ".jxl",                     // JPEG XL, solo si el ordenador tiene su códec instalado

    // RAW (necesitan "Raw Image Extension")
    ".dng",                     // Adobe Digital Negative (Pixel, Leica, Pentax, DJI...)
    ".cr2", ".cr3", ".crw",     // Canon
    ".nef", ".nrw",             // Nikon
    ".arw", ".srf", ".sr2",     // Sony
    ".raf",                     // Fujifilm
    ".orf",                     // Olympus / OM System
    ".rw2", ".raw",             // Panasonic
    ".rwl",                     // Leica
    ".pef",                     // Pentax
    ".srw",                     // Samsung
    ".x3f",                     // Sigma
    ".3fr", ".fff",             // Hasselblad
    ".iiq",                     // Phase One
    ".erf",                     // Epson
    ".mef",                     // Mamiya
    ".mos",                     // Leaf
    ".mrw",                     // Minolta
    ".kdc", ".dcr", ".k25",     // Kodak
    ".gpr",                     // GoPro
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
