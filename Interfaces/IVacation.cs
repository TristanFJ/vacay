using System;

namespace vacay.Interfaces
{
  public interface IVacation
  {
    int Id { get; set; }
    string Location { get; set; }
    string Duration { get; set; }
    float Price { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
    string CreatorId { get; set; }
  }
}