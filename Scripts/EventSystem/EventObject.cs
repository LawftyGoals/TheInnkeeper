using Godot;
using System;
using System.Collections.Generic;

public partial class EventObject : Node
{
    private int _remainingDuration;
    public int RemainingDuration
    {
        get => _remainingDuration;
        set => _remainingDuration = value;
    }
    private string _eventName;
    public string EventName
    {
        get => _eventName;
        set => _eventName = value;
    }

    private List<TransactionContainer> _transactionItemsList;

    public List<TransactionContainer> TransactionItemsList
    {
        get => _transactionItemsList;
        set => _transactionItemsList = value;
    }

    /*
    This was considered for a linked list type sturcture which would base
    itself on the remaining duration of the object. Objects would then link
    to the object that ends or reaches a "milestone" later in time"
    */
    //public EventObject followingEvent = null;

    //Constructor
    public EventObject(
        int duration,
        string name,
        List<TransactionContainer> possibleTransaction = null
    )
    {
        if (possibleTransaction != null)
            TransactionItemsList = possibleTransaction;
        else
            TransactionItemsList = new List<TransactionContainer>();

        RemainingDuration = duration;
        EventName = name;
    }

    //public override void _Process(double delta)
    //{
    //
    //}

    public void endObject()
    {
        performTransaction();
        QueueFree();
    }

    private void performTransaction()
    {
        if (TransactionItemsList.Count > 0)
        {
            foreach (TransactionContainer container in TransactionItemsList)
            {
                foreach (KeyValuePair<string, int> item in container.getDictionary())
                {
                    switch (item.Key)
                    {
                        case "COINS":
                            container.TargetCharacter.addCoins(item.Value);
                            container.TargetCharacter.coinLabel.Text =
                                container.TargetCharacter.Coin.ToString();
                            break;
                    }
                }
            }
        }
    }
}
