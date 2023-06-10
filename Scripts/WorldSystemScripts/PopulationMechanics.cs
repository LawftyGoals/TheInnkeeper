using Godot;
using System;

public partial class PopulationMechanics
{
    private int _totalPopulation;
    private int _numberOfFemales;

    //base the number of fertile females on plausible number of females between age 12-48, at this point it is a 60% of total female pop.
    private float _percentageFertileF;
    private int _numberOfMales;
    private float _percentageFertileM;

    private float _birthFactor;

    private float _birthProgress;

    public int PopulationTotal
    {
        get => _numberOfFemales + _numberOfMales;
    }

    public PopulationMechanics(
        int females = 160,
        int males = 140,
        float femalePer = 0.60f,
        float malePer = 0.95f,
        float birthFactor = 0.04f
    )
    {
        _numberOfFemales = females;
        _numberOfMales = males;
        _percentageFertileF = femalePer;
        _percentageFertileM = malePer;
        _birthFactor = birthFactor; // 4% is pretty close to norway
        _birthProgress = (float)new Random().NextDouble();
    }

    public void births()
    {
        if (_birthProgress >= 1)
        {
            double mOrF = new Random().NextDouble();
            if (mOrF < 0.5145631067961165)
            {
                _numberOfMales++;
            }
            else
            {
                _numberOfFemales++;
            }
            _birthProgress = _birthProgress % 1;
        }

        GD.Print(
            _numberOfFemales * _percentageFertileF * _percentageFertileM * _birthFactor / 365 / 24
        );
    }

    public void deaths() { }
}
