using Godot;
using System;

public partial class PopulationMechanics
{
    private int _numberOfFemales;

    //base the number of fertile females on plausible number of females between age 12-48, at this point it is a 60% of total female pop.
    private float _percentageFertileF;
    private int _numberOfMales;
    private float _percentageFertileM;

    private float _birthRate;

    public int PopulationTotal
    {
        get => _numberOfFemales + _numberOfMales;
    }

    public PopulationMechanics(
        int females = 160,
        int males = 140,
        float femalePer = 0.60f,
        float malePer = 0.95f,
        float birthRate = 0.10f
    )
    {
        _numberOfFemales = females;
        _numberOfMales = males;
        _percentageFertileF = femalePer;
        _percentageFertileM = malePer;
        _birthRate = birthRate;
    }

    public void births()
    {
        GD.Print(_numberOfFemales * _percentageFertileF * _percentageFertileM * _birthRate / 365);
    }

    public void deaths() { }
}
