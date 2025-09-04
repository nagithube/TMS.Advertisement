using System.ComponentModel.DataAnnotations;

namespace TMS.Advertisement.Domain.Models;

public class Advertisement
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    public DateTime CreatedAt { get; set; }

    [Required]
    public Guid UserId { get; set; }
}