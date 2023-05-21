using Godot;
using System;
using System.Collections.Generic;

public partial class EventController : Node
{
    List<EventObject> EventList;
    VBoxContainer EventVBoxList;
    Button AddEvent;

    public override void _Ready()
    {
        EventList = new List<EventObject>();
        EventVBoxList = GetNode<VBoxContainer>("EventVBoxContainer");
        AddEvent = GetNode<Button>("Button");
        AddEvent.Pressed += tempAddEvent;

        GD.Print(GetChildren());
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

    private void tempAddEvent()
    {
        GD.Print("pressed button!");
        addEventToEventList(new EventObject(5, "boogy"));
    }

    public void updateTimeOnEventList()
    {
        foreach (EventObject eventObject in EventList)
        {
            eventObject.RemainingDuration--;
            GD.Print(EventVBoxList.GetChildren());
        }
    }

    public void addEventToEventList(EventObject eventObject)
    {
        GD.Print("added event");
        EventList.Add(eventObject);

        EventVBoxList.AddChild(
            new EventLabel(eventObject.EventName, eventObject.RemainingDuration, eventObject)
        );
    }
}
