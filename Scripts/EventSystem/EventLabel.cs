using Godot;
using System;

public partial class EventLabel : Label
{
    public EventObject parentEvent { get; set; }
    public string EventName { get; set; }
    public int RemainingDuration { get; set; }

    public EventLabel(string name, int duration, EventObject eventObject)
    {
        EventName = name;
        RemainingDuration = duration;
        parentEvent = eventObject;
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Text = $"{EventName} - {RemainingDuration}";
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Text = $"{parentEvent.EventName} - {parentEvent.RemainingDuration}";
    }
}
