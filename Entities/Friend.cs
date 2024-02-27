using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace study_together_api.Entities;

public class Friend
{
    [Key, Column(Order = 0)]
    public int UserId { get; init; }

    [Key, Column(Order = 1)]
    public int FriendUserId { get; init; }

    public DateTime createDate { get; init; } = DateTime.Now;
}