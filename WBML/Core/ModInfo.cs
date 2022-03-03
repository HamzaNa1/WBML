﻿namespace WBML.Core;

public readonly struct ModInfo
{
    public string Name { get; }
    public string Version { get; }
    public string Author { get; }

    public ModInfo(string name, string version, string author)
    {
        Name = name;
        Version = version;
        Author = author;
    }
}