using Godot;
using System;

public partial class GameTime : Node
{
    private int speed;
    private int hour;
    private bool paused = true;
    private double _deltaConvert;
    public double DeltaConvert
    {
        get => _deltaConvert;
        set => _deltaConvert = value;
    }

    double[] speedValues = { 2, 1, 0.75, 0.5, 0.25 };

    Label timeLabel;

    EventController EventController;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        hour = 0;
        speed = 1;

        DeltaConvert = 0;

        timeLabel = GetNode<Label>("TimeLabel");
        EventController = GetNode<EventController>("EventController");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (!paused)
        {
            timeUpdate(delta);
        }
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
                case Key.Space:
                    togglePause();
                    break;
            }
        }
    }

    public void togglePause()
    {
        paused = !paused;
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
        DeltaConvert += delta;
        if (DeltaConvert >= speedValues[speed])
        {
            hour++;
            DeltaConvert = 0;
            timeLabel.Text = hour.ToString();
            EventController.handleTimeOnEventList();
            EventController.eventLabelKiller();
        }
    }
}
