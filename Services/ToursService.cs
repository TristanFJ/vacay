using System;
using System.Collections.Generic;
using vacay.Models;
using vacay.Repositories;

namespace vacay.Services
{
  public class ToursService
  {
    private readonly ToursRepository _repo;

    public ToursService(ToursRepository repo)
    {
      _repo = repo;
    }

    internal Tour Create(Tour newTour)
    {
      return _repo.Create(newTour);
    }

    internal List<Tour> GetAll()
    {
      return _repo.GetAll();
    }

    internal void Remove(int id, string userId)
    {
      Tour tour = _repo.Get(id);
      if (tour.CreatorId != userId)
      {
        throw new Exception("ACCESS DENIED");
      }
      _repo.Remove(id);
    }
    // BUG CreatorId is null 
  }
}