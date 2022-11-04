using System.Collections.Generic;
using Domain;

namespace DAL;

// DAL - Data Access Layer - большое приложение разбивать на слои/модули

public interface IGameOptionsRepository
{
    //string Name { get; }
    // BUG


    // crud methods (create, read, updat, delete)

    // read
    List<string> GetGameOptionsList();
    TicTacToeOption GetGameOptions(string id);

    // create and update
    void SaveGameOptions(string id, TicTacToeOption options);

    // delete
    void DeleteGameOptions(string id);
}