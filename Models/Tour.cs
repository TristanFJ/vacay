using System;
using vacay.Interfaces;

namespace vacay.Models
{
  public class Tour : IVacation
  {
    public int Id { get; set; }
    public string Location { get; set; }
    public string Duration { get; set; }
    public float Price { get; set; }
    public int Attending { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatorId { get; set; }
  }
}