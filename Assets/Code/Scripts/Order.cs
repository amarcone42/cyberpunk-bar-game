using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public Requirement[] requirements;
    public Condition[] conditions;
    public int day;
    public int failure;
    public int good;
    public int best;

    public Order(Requirement[] requirements, Condition[] conditions, int day, int failure, int good, int best)
    {
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
