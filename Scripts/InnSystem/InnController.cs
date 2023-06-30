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
    Label guestLabel;

    public override void _Ready()
    {
        SetProcess(false);

        _innOwner = GetNode<Character>(
            "/root/NodeTimeControl/NodeWorldController/NodePlayerCharacter"
        );
        _innName = $"{_innOwner.CharacterName}'s Inn";
        _availableCapacity = 11;
        guestLabel = GetNode<Label>("GuestLabel");
    }

    private int checkCapacity()
    {
        return _availableCapacity - _guestList.Count;
    }

    public string showGuestList()
    {
        string guestList = "";
        foreach (Character guest in _guestList)
        {
            guestList += guest.CharacterName + ", ";
        }
        return guestList;
    }

    public void addGuest(Character guest)
    {
        _guestList.Add(guest);
    }

    public void runInn()
    {
        guestLabel.Text = showGuestList();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    //public override void _Process(double delta) { }
}
