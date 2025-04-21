/*namespace Virtual_Art_Gallery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Artwork art = new Artwork
            (11, "Snow in the Desert", "Visual Treat to creatures", DateTime.Now, "Lamination sheet and Glitterings", "https:\\C:\\Users\\VEDHASRUTHI\\OneDrive\\Pictures\\Visual_Art_Gallery\\image65.jpg");
            art.DisplayArtWork();
            Artwork art1 = new Artwork
            (12, "The Queen Jungle", "Motherhood Survival", DateTime.Now, "Glass and Poster colours", "https:\\C:\\Users\\VEDHASRUTHI\\OneDrive\\Pictures\\Visual_Art_Gallery\\image66.jpg");
            art1.DisplayArtWork();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Artist artist = new Artist
            (51, "Mr.John", "Age: 29, Profession: Actor and Artist, Passion: Photographer, Status: Single", DateTime.UtcNow, "American", "John Life Mistery", "5432167890");
            artist.DisplayArtist();
            Artist artist1 = new Artist
            (52, "Mrs.Carrie", "Age: 34, Profession: Actress and Poetic Artist, Passion: Cooking, Status: Married", DateTime.UtcNow, "Britain", "Carrie's Step", "5467320981");
            artist1.DisplayArtist();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            var artwork1 = new Art_Work
            (11, "Snow in the Desert");
            var artwork2 = new Art_Work
            (12, "The Queen Jungle");

            var favorite_artworks = new List<Art_Work> { artwork1, artwork2 };

            User user = new User
            (1, "Vedha09", "V1s9@100.1", "vedha091203@gmail.com", "Vedha", "sruthi", DateTime.UtcNow, "Nature.jpeg", favorite_artworks);
            user.DisplayUserDetails();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            var gallery1 = new Artist_Curator
            (51, "Mr.John");
            var gallery2 = new Artist_Curator
            (52, "Mrs.Carrie");

            var curator = new List<Artist_Curator> { gallery1, gallery2 };

            Gallery ag = new Gallery
            (1001, "Galaxy-Buzz Art Gallery", "Museum of Ancient Ornaments indulged in Space Air-crafts Manufacturers", "Andhra Pradesh(AP)", "2025-04-20", curator);
            ag.DisplayGallery();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}*/

using System;
using System.Collections.Generic;
using Virtual_Art_Gallery.Data;
using Virtual_Art_Gallery;
using Virtual_Art_Gallery.Models;

class Program
{
    static void Main(string[] args)
    {
        IVirtualArtGallery gallery = new VAGdaoImpl();

        while(true)
        {
            Console.WriteLine("============================== Virtual Art Gallery ==============================");
            Console.WriteLine("1. Add Artwork");
            Console.WriteLine("2. Update Artwork");
            Console.WriteLine("3. Remove Artwork");
            Console.WriteLine("4. Get Artwork by ID");
            Console.WriteLine("5. Search Artworks");
            Console.WriteLine("6. Add Artwork to Favorites");
            Console.WriteLine("7. Remove Artwork from Favorites");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var art = new Artwork1();
                    Console.Write("Artwork ID: ");
                    art.ArtworkId = int.Parse(Console.ReadLine());
                    Console.Write("Title: ");
                    art.Title = Console.ReadLine();
                    Console.Write("Description: ");
                    art.Description = Console.ReadLine();
                    Console.Write("Artist: ");
                    art.Artist = Console.ReadLine();
                    Console.Write("CreatedDate: ");
                    art.CreatedDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine(gallery.AddArtwork(art) ? "Artwork added." : "Failed to add artwork.");
                    break;

                case "2":
                    var updatedArt = new Artwork1();
                    Console.Write("Artwork ID to Update: ");
                    updatedArt.ArtworkId = int.Parse(Console.ReadLine());
                    Console.Write("New Title: ");
                    updatedArt.Title = Console.ReadLine();
                    Console.Write("New Description: ");
                    updatedArt.Description = Console.ReadLine();
                    Console.Write("New Artist: ");
                    updatedArt.Artist = Console.ReadLine();
                    Console.Write("New CreatedDate: ");
                    updatedArt.CreatedDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine(gallery.UpdateArtwork(updatedArt) ? "Artwork updated." : "Failed to update artwork.");
                    break;

                case "3":
                    Console.Write("Enter Artwork ID to remove: ");
                    int removeId = int.Parse(Console.ReadLine());
                    Console.WriteLine(gallery.RemoveArtwork(removeId) ? "Artwork removed." : "Failed to remove artwork.");
                    break;

                case "4":
                    Console.Write("Enter Artwork ID to retrieve: ");
                    int artId = int.Parse(Console.ReadLine());
                    Artwork1 artwork = gallery.GetArtworkById(artId);
                    Console.WriteLine($"ID: {artwork.ArtworkId}, Title: {artwork.Title}, Artist: {artwork.Artist}");
                    break;

                case "5":
                    Console.Write("Enter keyword to search: ");
                    string keyword = Console.ReadLine();
                    List<Artwork1> results = gallery.SearchArtworks(keyword);
                    foreach (var art1 in results)
                    {
                        Console.WriteLine($"ID: {art1.ArtworkId}, Title: {art1.Title}, Artist: {art1.Artist}");
                    }
                    break;

                case "6":
                    Console.Write("Enter User ID: ");
                    int userId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Artwork ID to favorite: ");
                    int favArtId = int.Parse(Console.ReadLine());
                    Console.WriteLine(gallery.AddArtworkToFavorite(userId, favArtId) ? "Artwork favorited." : "Failed to favorite artwork.");
                    break;

                case "7":
                    Console.Write("Enter User ID: ");
                    int userId1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter Artwork ID to unfavorite: ");
                    int favArtId1 = int.Parse(Console.ReadLine());
                    Console.WriteLine(gallery.RemoveArtworkFromFavorite(userId1, favArtId1) ? "Artwork unfavorited." : "Failed to unfavorite artwork.");
                    break;

                case "8":
                    Console.WriteLine("Exited!!");
                    return;

                default:
                    Console.WriteLine("Invalid choice!!");
                    break;
            }
        }
    }
}
