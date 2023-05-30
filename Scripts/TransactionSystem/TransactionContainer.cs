using Godot;
using System;
using System.Collections.Generic;

public partial class TransactionContainer
{
    private Character _targetCharacter;
    public Character TargetCharacter
    {
        get => _targetCharacter;
        set => _targetCharacter = value;
    }

    // Called when the node enters the scene tree for the first time.
    private Dictionary<string, int> transactionItems;

    public TransactionContainer(Dictionary<string, int> initialTransactionItems, Character target)
    {
        transactionItems = initialTransactionItems;
        TargetCharacter = target;
    }

    public void addToItems(string type, int value)
    {
        transactionItems.Add(type, value);
    }

    public Dictionary<string, int> getDictionary()
    {
        return transactionItems;
    }
}
