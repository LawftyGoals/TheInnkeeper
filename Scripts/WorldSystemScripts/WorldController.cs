using Godot;
using System;
using System.Collections.Generic;

public partial class WorldController : Node
{
    private InnController _playerInn;
    private Character _playerCharacter;

    private List<Character> ActiveWorldCharacters = new List<Character>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SetProcess(false);
        _playerInn = GetNode<InnController>("NodeInnController");
        _playerCharacter = GetNode<Character>(
            "/root/NodeTimeControl/NodeWorldController/NodePlayerCharacter"
        );
        _playerInn.InnOwner = _playerCharacter;
        _playerCharacter.CharacterType = "Player";
    }

    public Character createRandomCharacter(string characterName)
    {
        return new Character(characterName, "NPC");
    }

    public void runWorld()
    {
        _playerInn.addGuest(
            createRandomCharacter((new jsonNames.jsonNames().returnName()).ToString())
        );
        _playerInn.runInn();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(double delta) { }
}
