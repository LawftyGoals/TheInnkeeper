using Godot;
using System;
using System.Collections.Generic;

public partial class EventController : Node
{
    List<EventObject> EventList;
    VBoxContainer EventVBoxList;
    private Button AddEvent;

    public override void _Ready()
    {
        EventList = new List<EventObject>();
        EventVBoxList = GetNode<VBoxContainer>("EventVBoxContainer");
        AddEvent = GetNode<Button>("Button");
        AddEvent.Pressed += tempAddEvent;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

    public void eventLabelKiller()
    {
        foreach (EventLabel eventLabel in EventVBoxList.GetChildren())
        {
            if (eventLabel.ParentEvent.RemainingDuration < 0)
            {
                eventLabel.QueueFree();
            }
        }
    }

    private void tempAddEvent()
    {
        addEventToEventList(new EventObject(5, "boogy"));
        // please remember the following = AddEvent.ReleaseFocus();
        // also that there is a focus mode under inspector that can be set to None
    }

    public void updateTimeOnEventList()
    {
        foreach (EventObject eventObject in EventList)
        {
            eventObject.RemainingDuration--;
        }
    }

    public void addEventToEventList(EventObject eventObject)
    {
        EventList.Add(eventObject);
        EventVBoxList.AddChild(
            new EventLabel(eventObject.EventName, eventObject.RemainingDuration, eventObject)
        );
    }
}
