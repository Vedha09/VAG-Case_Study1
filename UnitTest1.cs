using NUnit.Framework;
using System.Collections.Generic;
using VirtualArtGalleryTests;
using static VirtualArtGalleryTests.VirtualArtGalleryImpl;
using static VirtualArtGalleryTests.DBUtilityTests;
using System.Data.SqlClient;

[TestFixture]
public class Tests
{
    private IVirtualArtGallery gallery;
    private List<int> createdArtworkId;

    [SetUp]
    public void SetUp()
    {
        gallery = new VirtualArtGalleryImpl();
        createdArtworkId = new List<int>();
    }

    [TearDown]
    public void TearDown()
    {
        foreach (int id in createdArtworkId)
        {
            gallery.RemoveArtwork(id);
        }
        createdArtworkId.Clear();
    }

    [Test]
    public void AddArtwork_ShouldAddSuccessfully()
    {
        //Arrange
        var artwork = new ArtworkManagement
        {
            ArtworkId = GenerateRandomId(),
            Title = "Test to add Artwork",
            Description = "Test to add Description",
            Artist = "Test to add Artist",
            CreatedDate = DateTime.Now
        };
        //Act
        var result = gallery.AddArtwork(artwork);
        createdArtworkId.Add(artwork.ArtworkId);
        //Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void RemoveArtwork_ShouldRemoveSuccessfully()
    {
        //Arrange
        var artwork = new ArtworkManagement
        {
            ArtworkId = GenerateRandomId(),
            Title = "Test to remove Artwork",
            Description = "Test to remove Description",
            Artist = "Test to remove Artist",
            CreatedDate = DateTime.Now
        };
        gallery.AddArtwork(artwork);
        //Act
        var result = gallery.RemoveArtwork(artwork.ArtworkId);
        //Assert
        Assert.IsTrue(result);
        Assert.Throws<Exception>(() => gallery.GetArtworkById(artwork.ArtworkId));
    }

    private int GenerateRandomId()
    {
        return new Random().Next();
    }
}
