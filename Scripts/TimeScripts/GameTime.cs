using Godot;
using System;

public partial class GameTime : Node
{
    private int speed;
    private int hour;
    private int _days;

    public int Days
    {
        get => _days;
        set => _days = value;
    }

    private bool paused = true;
    private double _deltaConvert;
    public double DeltaConvert
    {
        get => _deltaConvert;
        set => _deltaConvert = value;
    }

    private double[] speedValues = { 2, 1, 0.75, 0.5, 0.25, 0.05 };

    Label timeLabel;
    Label dateLabel;

    EventController EventController;
    PopulationMechanics Population;
    Label popLabel;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        hour = 0;
        _days = 0;
        speed = 1;

        DeltaConvert = 0;

        timeLabel = GetNode<Label>("TimeLabel");
        dateLabel = GetNode<Label>("DateLabel");

        timeLabel.Text = hour.ToString();
        timeLabel.Text = _days.ToString();

        EventController = GetNode<EventController>("NodeEventController");

        Population = new PopulationMechanics();

        popLabel = GetNode<Label>("PopLabel");
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
        _inputHandler(@event);
    }

    public void togglePause()
    {
        paused = !paused;
    }

    private void addSpeed()
    {
        updatePresentedTime();
        if (speed < 5)
            speed++;
    }

    private void reduceSpeed()
    {
        updatePresentedTime();
        if (speed > 0)
            speed--;
    }

    private void timeUpdate(double delta)
    {
        DeltaConvert += delta;
        if (DeltaConvert >= speedValues[speed])
        {
            hour++;
            addDay();
            DeltaConvert = 0;
            updatePresentedTime();
            EventController.handleTimeOnEventList();
            EventController.eventLabelKiller();
            Population.births();
            popLabel.Text = Population.PopulationTotal.ToString();
        }
    }

    private void addDay()
    {
        if (hour == 24)
        {
            hour = 0;
            _days++;
        }
    }

    public void updatePresentedTime()
    {
        timeLabel.Text = $"{speed.ToString()} :  {hour.ToString()}";
        dateLabel.Text = _days.ToString();
    }

    private void _inputHandler(InputEvent @event)
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
                case Key.Key1:
                    speed = 0;
                    updatePresentedTime();
                    break;
                case Key.Key2:
                    speed = 1;
                    updatePresentedTime();
                    break;
                case Key.Key3:
                    speed = 2;
                    updatePresentedTime();
                    break;
                case Key.Key4:
                    speed = 3;
                    updatePresentedTime();
                    break;
                case Key.Key5:
                    speed = 4;
                    updatePresentedTime();
                    break;
            }
        }
    }
}
