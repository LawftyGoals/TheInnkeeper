using Godot;
using System;
using System.Collections.Generic;

/*
    Hva om obejktet har ansvar selv for å legge seg til i kontroller objektet? kontrolleren blir fast og vil ikke flytte på seg. Et hvert objekt kan ved skapelse legge segg inn i riktig liste. Slipper man å kalle objektkontrolleren ved skapelse. Ved død kan objektet da også fjerne seg selv fra listen i kontrolleren.
    under _Ready:
    EventController = GetNode<EventController>("root/.../EventController")
    EventController.EventList.Add(this);
    
    EventController kan da kjøre en sånn LINQ spørring kim bob snakket om og kjøre en metode som da gjør alt inn på selve objektet.
*/

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

    private EventController myEventController;

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
        Node parentNode,
        int duration,
        string name,
        List<TransactionContainer> possibleTransaction = null
    )
    {
        parentNode.AddChild(this);
        myEventController = GetNode<EventController>("/root/TimeControl/EventController");
        myEventController.addEventToEventList(this);

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
