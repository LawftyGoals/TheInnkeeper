using Godot;
using System;
using System.Collections.Generic;

public partial class InnController : Node
{
    private int _renown;

    private string _innName;
    public string InnName
    {
        get => _innName;
        set => _innName = value;
    }

    private Character _innOwner;
    public Character InnOwner
    {
        get => _innOwner;
        set => _innOwner = value;
    }

    private int _availableCapacity;

    public int AvailableCapacity
    {
        get => _availableCapacity;
        set => _availableCapacity = value;
    }

    private List<Character> _guestList = new List<Character>();

    private int checkCapacity()
    {
        return _availableCapacity - _guestList.Count;
    }

    public override void _Ready()
    {
        _innName = $"{_innOwner.CharacterName}'s Inn";
        _availableCapacity = 11;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    //public override void _Process(double delta) { }
}
