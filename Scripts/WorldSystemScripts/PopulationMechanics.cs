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
    private float _maleskew = 0.5145631067961165f;

    private float _birthFactor;
    private float _deathFactor;

    private const float _ticksInYear = 8760;

    public int PopulationTotal
    {
        get => _numberOfFemales + _numberOfMales;
    }

    /**
       The birth factor bases itself on a subset of the total population, hence why it is set to 4%, because it is a percent of the subset. Meanwhile the deathFactor
       bases itself on the total population, as such it pertains to the total population and is based on an approximation of 1000. For this scenario (Mideaval) the
       numbers should be changed eventually and turned into something more reliable, ie, much higher birthFactor and deathFactor. For now it's fine.
     */
    public PopulationMechanics(
        int females = 160,
        int males = 140,
        float femalePer = 0.60f,
        float malePer = 0.95f,
        float birthFactor = 0.04f,
        float deathFactor = 0.008f
    )
    {
        _numberOfFemales = females;
        _numberOfMales = males;
        _percentageFertileF = femalePer;
        _percentageFertileM = malePer;
        _birthFactor = birthFactor; // 4% is pretty close to norway
        _deathFactor = deathFactor;
    }

    public void births()
    {
        double yearlyBirths =
            _numberOfFemales * _percentageFertileF * _percentageFertileM * _birthFactor;
        double chanceOfBirth = new Random().Next(0, 8761);
        while (chanceOfBirth < yearlyBirths)
        {
            chanceOfBirth = new Random().Next(0, 8761);
            inPopulationBirth();
        }
    }

    public void deaths()
    {
        double yearlyDeaths = _totalPopulation * _deathFactor;
        double chanceOfDeath = new Random().Next(0, 8761);
        while (chanceOfDeath < yearlyDeaths)
        {
            chanceOfDeath = new Random().Next(0, 8761);
            inPopulationDeath();
        }
    }

    private void inPopulationBirth()
    {
        double coinFlip = new Random().NextDouble();
        if (coinFlip < _maleskew)
        {
            _numberOfMales += 1;
        }
        else
        {
            _numberOfFemales += 1;
        }
    }

    private void inPopulationDeath()
    {
        double coinFlip = new Random().NextDouble();
        if (coinFlip < _maleskew)
        {
            _numberOfMales -= 1;
        }
        else
        {
            _numberOfFemales -= 1;
        }
    }

    public void specificPopulationReduction(int male = 0, int female = 0)
    {
        if (male > 0)
        {
            _numberOfMales -= male;
        }
        if (female > 0)
        {
            _numberOfFemales -= female;
        }
    }

    public void specificPopulationGrowth(int male = 0, int female = 0)
    {
        if (male > 0)
        {
            _numberOfMales -= male;
        }
        if (female > 0)
        {
            _numberOfFemales -= female;
        }
    }
}
