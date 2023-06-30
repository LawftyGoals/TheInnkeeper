using Godot;
using System;
using System.Collections.Generic;

public partial class EventController : Node
{
    private List<EventObject> _eventList;
    public List<EventObject> EventList
    {
        get => _eventList;
    }

    private List<EventObject> _playerActiveEventList;
    private List<EventObject> _playerInactiveEventList;

    private List<EventObject> _worldActiveEventList;
    private List<EventObject> _worldInactiveEventList;
    private List<EventObject> _worldForPlayerActiveEventList;

    private VBoxContainer EventVBoxList;
    private Button AddEvent;

    private Character playerCharacter;

    public override void _Ready()
    {
        SetProcess(false);

        _eventList = new List<EventObject>();
        EventVBoxList = GetNode<VBoxContainer>("EventVBoxContainer");

        playerCharacter = GetNode<Character>(
            "/root/NodeTimeControl/NodeWorldController/NodePlayerCharacter"
        );

        _playerActiveEventList = new List<EventObject>();
        _playerInactiveEventList = new List<EventObject>();
        _worldActiveEventList = new List<EventObject>();
        _worldInactiveEventList = new List<EventObject>();
        _worldForPlayerActiveEventList = new List<EventObject>();

        AddEvent = GetNode<Button>("Button");
        AddEvent.Pressed += tempAddEvent;
    }

    // public override void _Process(double delta) { }

    public void eventLabelKiller()
    {
        foreach (EventLabel eventLabel in EventVBoxList.GetChildren())
        {
            if (eventLabel.ParentEvent.RemainingDuration < 1)
            {
                eventLabel.QueueFree();
            }
        }
    }

    private void tempAddEvent()
    {
        new EventObject(
            this,
            5,
            "boogy",
            new List<TransactionContainer>
            {
                new TransactionContainer(
                    new Dictionary<string, int>() { { "COINS", new Random().Next(100, 200) } },
                    playerCharacter
                )
            }
        );
        // please remember the following = AddEvent.ReleaseFocus();
        // also that there is a focus mode under inspector that can be set to None <- this is what is done
    }

    public void handleTimeOnEventList()
    {
        // TODO: LINQ EventList.Where(p => p.RemainingDuration-- <1).Remove(p);
        if (EventList.Count > 0)
        {
            for (int i = EventList.Count - 1; i >= 0; i--)
            {
                EventObject deleteObject = EventList[i];
                deleteObject.RemainingDuration--;
                if (deleteObject.RemainingDuration < 1)
                {
                    EventList.Remove(deleteObject);
                    deleteObject.endObject();
                }
            }
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
