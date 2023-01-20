using System;
using System.Collections.Generic;
using System.IO;
using Domain;
using DAL;
//using Microsoft.EntityFrameworkCore;

namespace DAL.FileSystem;

// json serializer - данные из одного формата парсить в другой формат

public class GameBroardRepositoryFileSystem : IGameBoardRepository
{
    private const string FileExtension = "json";
    private readonly string _boardDirectory = "." + System.IO.Path.DirectorySeparatorChar + "Board";

    public string Name { get; } = "FileSystem";

    public List<string> GetGameBoardList()
    {
        CheckOrCreateDirectory();

        var res = new List<string>();

        foreach (var fileName in Directory.GetFileSystemEntries(_boardDirectory, "*." + FileExtension))
        {
            res.Add(System.IO.Path.GetFileNameWithoutExtension(fileName));
        }

        return res;
    }

    public TicTacToeBoard GetGameBoard(string id)
    {
        var fileContent = System.IO.File.ReadAllText(GetFileName(id));
        var boards = System.Text.Json.JsonSerializer.Deserialize<TicTacToeBoard>(fileContent);
        if (boards == null)
        {
            throw new NullReferenceException($"Could not deserialize: {fileContent}");
        }

        return boards;
    }

    public void SaveGameBoard(string id, TicTacToeBoard boards)
    {
        CheckOrCreateDirectory();

        var fileContent = System.Text.Json.JsonSerializer.Serialize(boards);
        System.IO.File.WriteAllText(GetFileName(id), fileContent);
    }

    public void DeleteGameOptions(string id)
    {
        System.IO.File.Delete(GetFileName(id));
    }

    private string GetFileName(string id)
    {
        return _boardDirectory +
               System.IO.Path.DirectorySeparatorChar +
               id + "." + FileExtension;
    }

    private void CheckOrCreateDirectory()
    {
        if (!System.IO.Directory.Exists(_boardDirectory))
        {
            System.IO.Directory.CreateDirectory(_boardDirectory);
        }
    }
}