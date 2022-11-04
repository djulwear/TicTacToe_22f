using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Db;

public class GameOptionsRepositoryDb : IGameOptionsRepository
{
    private readonly AppDbContext _dbContext;

    public GameOptionsRepositoryDb(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string Name { get; } = "DB";

    public List<string> GetGameOptionsList() =>
        _dbContext
            .TicTacToeOptions
            .OrderBy(o => o.Name)
            .Select(o => o.Name)
            .ToList();


    public TicTacToeOption GetGameOptions(string id)
    {
        return _dbContext.TicTacToeOptions.First(o => o.Name == id);
    }

    public void SaveGameOptions(string id, TicTacToeOption option)
    {
        var optionsFromDb = _dbContext.TicTacToeOptions.FirstOrDefault(o => o.Name == id);
        if (optionsFromDb == null)
        {
            _dbContext.TicTacToeOptions.Add(option);
            _dbContext.SaveChanges();
            return;
        }

        optionsFromDb.Name = option.Name;
        optionsFromDb.Width = option.Width;
        optionsFromDb.Height = option.Height;
        optionsFromDb.RandomMoves = option.RandomMoves;
        optionsFromDb.WhiteStarts = option.WhiteStarts;

        _dbContext.SaveChanges();
    }

    public void DeleteGameOptions(string id)
    {
        var optionsFromDb = GetGameOptions(id);
        _dbContext.TicTacToeOptions.Remove(optionsFromDb);
        _dbContext.SaveChanges();
    }
}

//dotnet ef migrations add InitialCreate --project DAL.db --startup-project ConsoleApp 
//dotnet ef database update --project DAL.Db --startup-project ConsoleApp

