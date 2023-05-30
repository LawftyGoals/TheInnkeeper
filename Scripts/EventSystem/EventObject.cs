using Godot;
using System;

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

    /*
    This was considered for a linked list type sturcture which would base
    itself on the remaining duration of the object. Objects would then link
    to the object that ends or reaches a "milestone" later in time"
    */
    //public EventObject followingEvent = null;

    //Constructor
    public EventObject(int duration, string name)
    {
        RemainingDuration = duration;
        EventName = name;
    }

    public override void _Process(double delta)
    {
        if (RemainingDuration < 0)
        {
            QueueFree();
        }
    }
}
