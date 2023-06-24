using Godot;
using System;
using System.Collections.Generic;

public partial class Character : Node
{
    private string _name;
    public string CharacterName
    {
        get => _name;
        set => _name = value;
    }

    //TODO:
    private string _firstName;
    private string _middleName;
    private string _nickName;
    private string _lastName;

    private int _coin;
    public int Coin
    {
        get => _coin;
        //set => _coin = value;
    }
    private int _experience;
    public int Experience
    {
        get => _experience;
        //set => _experience = value;
    }

    public Label coinLabel;

    public override void _Ready()
    {
        CharacterName = "Innkeeper";
        _experience = 0;
        _coin = 500;
        coinLabel = GetNode<Label>("CoinLabel");
        coinLabel.Text = Coin.ToString();
        SetProcess(false);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(double delta) { }

    public void addExperience(int expAmount)
    {
        _experience += expAmount;
    }

    public void removeExperience(int expAmount)
    {
        _experience -= expAmount;
    }

    public void addCoins(int coinAmount)
    {
        _coin += coinAmount;
    }

    public void removeCoins(int coinAmount)
    {
        _coin -= coinAmount;
    }
}
