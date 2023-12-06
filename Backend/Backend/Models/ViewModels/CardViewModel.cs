namespace Backend.Models.ViewModels;

public class CardViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Base64ImageContent { get; set; } = null!;
}