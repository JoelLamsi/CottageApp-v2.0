using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CottageApp.Models;

public class CottageItem
{
    public static CottageItem NotFound = new CottageItem();
    [Key]
    public int Id { get; set; }
    [Required, StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
    public string Title { get; set; } = null!;
    [StringLength(500)]
    public string? Description { get; set; }
    public string? PictureUrl { get; set; }
    [NotMapped]
    public int[] Ratings { get; set; } = new int[] {0};
    public DateTime DateAdded { get; set; }
    public int Rooms { get; set; }
    public bool IsSauna { get; set; }
    public bool IsElectricity { get; set; }

    public float AvgRating 
    {
        get { return AvgRatings(); }
    }
    [Required]
    public decimal CostPerDay { get; set; }

    private float AvgRatings()
    {
        var count = Ratings.Length;
        var sum = 0;
        foreach (var i in Ratings)
        {
            sum += i;
        }
        return sum / count;
    }
}