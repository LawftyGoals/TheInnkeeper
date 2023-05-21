using Godot;
using System;

public partial class EventObject : Node
{
    public int RemainingDuration { set; get; }
    public string EventName { set; get; }
    public EventObject followingEvent = null;

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
