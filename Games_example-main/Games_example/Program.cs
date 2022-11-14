using System;
using System.Collections.Generic;

using ConsoleUI;
using GameBrain;
using Domain;
using DAL;
using DAL.Db;
using DAL.FileSystem;

using MenuSystem;
using System.Diagnostics.Tracing;
using Microsoft.EntityFrameworkCore;



var gameOptions = new TicTacToeOption();
gameOptions.Name = "SNDoptions";
    


var game = new TicTacToeBrain(gameOptions);

var dbOptions =
    new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlite("Data Source=/Users/janaf/Documents/temp_IT/TicTacToe.db")
        .Options;

var ctx = new AppDbContext(dbOptions);

IGameOptionsRepository repoFs = new GameOptionsRepositoryFileSystem();
IGameOptionsRepository repoDb = new GameOptionsRepositoryDb(ctx);

IGameOptionsRepository repo = repoDb;

repo.SaveGameOptions(gameOptions.Name, gameOptions);

//Menu List

var thirdMenu = new Menu(
    EMenuLevel.Other,
    "> Third level  <",
    new List<MenuItem>()
    {
        new MenuItem("N", "Nothing", null),
    }
);


var LoadMenu = new Menu(
    EMenuLevel.Second,
    "> Second level  <",
    new List<MenuItem>()
    {
        new MenuItem("T", "Third level", thirdMenu.RunMenu),
    }
);

var sizeMenu = new Menu(
    EMenuLevel.Second,
    "> Second Level, Game stats <",
    new List<MenuItem>()
    {
        new MenuItem("N", "New Game", DoNewGame),
    }
);

var OptionsMenu = new Menu(
    EMenuLevel.Second,
    ">  2nd lvl, Game Options  <",
    new List<MenuItem>()
    {
        new MenuItem("C", "Create options", SaveAsCurrentGameOptions),
        new MenuItem("O", "List saved options", ListGameOptions),
        new MenuItem("L", "Load options", LoadGameOptions),
        new MenuItem("D", "Delete options", DeleteNameGameOptions),
        //new MenuItem("S", "Save current options", SaveOptions),
        //new MenuItem("E", "Edit current options", null),
        new MenuItem("I", "Show currect Game Options", ShowGameOptions),
        new MenuItem("P", "Persistence method swap", SwapPersistenceEngine),
    }
);

var mainMenu = new Menu(
    EMenuLevel.Main,
    ">  1st lvl, Main Menu  <",
    new List<MenuItem>()
    {
        new MenuItem("N", "New Game", sizeMenu.RunMenu),
        new MenuItem("L", "Load Game", LoadMenu.RunMenu),
        new MenuItem("O", "Options", OptionsMenu.RunMenu)
    }
);



var choice = mainMenu.RunMenu();

string DoNewGame()
{
    game = new TicTacToeBrain(gameOptions);
    UI.DrawGameBoard(game.GetBoard());
    return "-";
}

// LIST OF COMMANDS FOR OPTIONS MENU

string SwapPersistenceEngine()
{
    if (repo == repoDb)
    {
        repo = repoFs;
    }
    else
    {
        repo = repoDb;
    }

    Console.WriteLine("Persistence engine: " + repo.Name);

    return repo.Name;
}


string ListGameOptions()
{
    Console.WriteLine("=========");
    Console.WriteLine("List of Options:");
    foreach (var name in repo.GetGameOptionsList())
    {
        Console.WriteLine(name);
    }
    return "-";
}

string LoadGameOptions()
{
    Console.Write("Options name:");
    var optionsName = Console.ReadLine();
    gameOptions = repo.GetGameOptions(optionsName);
    return "-";
}
 
string SaveAsCurrentGameOptions()
{
    Console.Write("Save as:");
    string optionsName = Console.ReadLine();
    repo.SaveGameOptions(optionsName, gameOptions);
    //Console.WriteLine(" "+ TicTacToeOptions (optionsName)+ "");
    return "-";
}

string DeleteNameGameOptions()
{
    Console.Write("Write option to delete:");
    var optionsName = Console.ReadLine();
    repo.DeleteGameOptions(optionsName);
    return "-";
}

string SaveOptions()
{
    Console.Write("Saving"+gameOptions+"!");
    string optionsName = Console.ReadLine();
    repo.SaveGameOptions(optionsName, gameOptions);

    return "";
}

string ShowGameOptions ()
{
    Console.WriteLine("=========");
    Console.WriteLine("Currect Game options: " + gameOptions + ".");
    Console.WriteLine("=========");
    return "";
}