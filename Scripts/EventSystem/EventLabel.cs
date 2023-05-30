using Godot;
using System;

public partial class EventLabel : Label
{
    private EventObject _parentEvent;
    public EventObject ParentEvent
    {
        get => _parentEvent;
        set => _parentEvent = value;
    }
    private string _eventName;
    public string EventName
    {
        get => _eventName;
        set => _eventName = value;
    }
    private int _remainingDuration;
    public int RemainingDuration
    {
        get => _remainingDuration;
        set => _remainingDuration = value;
    }

    public EventLabel(string name, int duration, EventObject eventObject)
    {
        EventName = name;
        RemainingDuration = duration;
        ParentEvent = eventObject;
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Text = $"{EventName} - {RemainingDuration}";
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Text = $"{ParentEvent.EventName} - {ParentEvent.RemainingDuration}";
    }
}
