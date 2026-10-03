using ImageByView.Core;

IReadOnlyList<string> pics = ImageFolder.GetFolderPics(@"C:\Users\micro\Pictures\3DS XL");

foreach (string pic in pics)
{
    Console.WriteLine(pic);
}