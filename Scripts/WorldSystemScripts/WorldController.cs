using Godot;
using System;

public partial class WorldController : Node
{
    private InnController _playerInn;
    private Character _playerCharacter;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SetProcess(false);
        _playerInn = GetNode<InnController>("NodeInnController");
        _playerCharacter = GetNode<Character>("NodePlayerCharacter");
        _playerInn.InnOwner = _playerCharacter;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(double delta) { }
}
