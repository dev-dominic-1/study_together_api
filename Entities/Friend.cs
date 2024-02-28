using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace study_together_api.Entities;

public class Friend
{
    [Key, Column(Order = 0)]
    public required int UserId { get; init; }

    [Key, Column(Order = 1)]
    public required int FriendUserId { get; init; }

    public DateTime createDate { get; init; } = DateTime.Now;

    [ForeignKey("UserId")]
    public User? User { get; init; }

    [ForeignKey("FriendUserId")]
    public User? FriendUser { get; init; }
}