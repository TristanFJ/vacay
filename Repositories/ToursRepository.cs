using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using vacay.Models;

namespace vacay.Repositories
{
  public class ToursRepository
  {
    private readonly IDbConnection _db;

    public ToursRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Tour Create(Tour newTour)
    {
      string sql = @"
  INSERT INTO tours
  (location, duration, price, attending)
  VALUES
  (@Location, @Duration, @Price, @Attending);
  SELECT LAST_INSERT_ID();
  ";

      int id = _db.ExecuteScalar<int>(sql, newTour);
      newTour.Id = id;
      return newTour;
    }

    internal List<Tour> GetAll()
    {
      string sql = @"
      SELECT * FROM tours 
      ";

      return _db.Query<Tour>(sql).ToList();
    }

    internal Tour Get(int id)
    {
      string sql = "SELECT * FROM tours WHERE id = @id";
      return _db.QueryFirstOrDefault<Tour>(sql, new { id });
    }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM tours WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }


  }
}