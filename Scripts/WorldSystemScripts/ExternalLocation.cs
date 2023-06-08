using Godot;
using System;

public partial class ExternalLocation : GeneralLocation
{
    private string[] _locationTypes = { "TOWN", "DUNGEON", "FIELD", "MOUNTAIN", "MINE" };

    private string _locationName;
    public string LocationName
    {
        get => _locationName;
        set => _locationName = value;
    }

    private string _locationType;
    public string LocationType
    {
        get => _locationType;
    }

    private Vector2 _locationCoordinates;
    public Vector2 LocationCoordinates
    {
        get => _locationCoordinates;
    }

    private string _controllingFaction;
    public string ControllingFaction
    {
        get => _controllingFaction;
        set => _controllingFaction = value;
    }

    public ExternalLocation(
        string locationName,
        int locationType,
        Vector2 locationCoordinates,
        string controllingFaction
    )
    {
        _locationName = locationName;
        _locationType = _locationTypes[locationType];
        _locationCoordinates = locationCoordinates;
        _controllingFaction = controllingFaction;
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SetProcess(false);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(double delta) { }
}
