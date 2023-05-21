using Godot;
using System;

public partial class GameTime : Node
{
    int speed;
    int hour;
    double deltaConvert { get; set; } = 0;

    double[] speedValues = { 2, 1, 0.75, 0.5, 0.25 };

    Label timeLabel;

    EventController EventController;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        hour = 0;
        speed = 1;

        timeLabel = GetNode<Label>("TimeLabel");
        EventController = GetNode<EventController>("EventController");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        timeUpdate(delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventKey eventKey && eventKey.Pressed)
        {
            var pressed = eventKey.Keycode;
            switch (pressed)
            {
                case Key.Period:
                    addSpeed();
                    break;
                case Key.Comma:
                    reduceSpeed();
                    break;
            }
        }
    }

    private void addSpeed()
    {
        if (speed < 4)
            speed++;
    }

    private void reduceSpeed()
    {
        if (speed > 0)
            speed--;
    }

    private void timeUpdate(double delta)
    {
        deltaConvert += delta;
        if (deltaConvert >= speedValues[speed])
        {
            hour++;
            deltaConvert = 0;
            timeLabel.Text = hour.ToString();
            EventController.updateTimeOnEventList();
        }
    }
}
