using System.Collections;
using System.Collections.Generic;

public class Order
{
    public string description;
    public Requirement[] requirements;
    public Condition[] conditions;
    public int day;
    public int failure;
    public int good;
    public int best;

    public Order(string description, Requirement[] requirements, Condition[] conditions, int day, int failure, int good, int best)
    {
        this.description = description;
        this.requirements = requirements;
        this.conditions = conditions;
        this.day = day;
        this.failure = failure;
        this.good = good;
        this.best = best;
    }

    public Requirement[] GetRequirements() { return requirements; }
    public Condition[] GetConditions() { return conditions;}
    public int GetDay() { return day;}
    public int GetFailure() { return failure;}
    public int GetGood() { return good;}
    public int GetBest() { return best;}

}
