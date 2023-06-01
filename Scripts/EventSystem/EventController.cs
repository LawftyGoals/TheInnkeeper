using Godot;
using System;
using System.Collections.Generic;

public partial class EventController : Node
{
    List<EventObject> EventList;
    VBoxContainer EventVBoxList;
    private Button AddEvent;

    Character playerCharacter;

    public override void _Ready()
    {
        EventList = new List<EventObject>();
        EventVBoxList = GetNode<VBoxContainer>("EventVBoxContainer");
        AddEvent = GetNode<Button>("Button");
        AddEvent.Pressed += tempAddEvent;
        playerCharacter = GetNode<Character>("/root/TimeControl/PlayerCharacter");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

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
        addEventToEventList(
            new EventObject(
                5,
                "boogy",
                new List<TransactionContainer>
                {
                    new TransactionContainer(
                        new Dictionary<string, int>() { { "COINS", new Random().Next(100, 200) } },
                        playerCharacter
                    )
                }
            )
        );
        // please remember the following = AddEvent.ReleaseFocus();
        // also that there is a focus mode under inspector that can be set to None
    }

    public void handleTimeOnEventList()
    {
        // LINQ EventList.Where(p => p.RemainingDuration-- <1).Remove(p);
        if (EventList.Count > 0)
        {
            EventObject[] deleteList = new EventObject[EventList.Count];
            int listIndex = 0;

            foreach (EventObject eventObject in EventList)
            {
                eventObject.RemainingDuration--;
                if (eventObject.RemainingDuration < 1)
                {
                    deleteList[listIndex] = eventObject;
                }
            }
            if (deleteList[0] != null)
            {
                for (int i = 0; i < deleteList.Length; i++)
                {
                    EventObject deletedObject = deleteList[i];
                    deleteList[i] = null;
                    EventList.Remove(deletedObject);
                    deletedObject.endObject();
                }
            }
        }
    }

    public void addEventToEventList(EventObject eventObject)
    {
        EventList.Add(eventObject);
        AddChild(eventObject);
        EventVBoxList.AddChild(
            new EventLabel(eventObject.EventName, eventObject.RemainingDuration, eventObject)
        );
    }
}
