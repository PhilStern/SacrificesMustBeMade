using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Encounter
{
    public string Name;
    public EncounterState State;
    public string Intro;
    public string Decision;
    public string Sacrificed;

    public List<Challenge> Challenges = new List<Challenge>();

    public string EndPositive;
    public List<string> Rewards = new List<string>();
    protected List<Trait> TraitsRewards = new List<Trait>();
    protected List<Buff> BuffRewards = new List<Buff>();

    public string EndNegative;
    public List<string> Punishments = new List<string>();
    protected List<Trait> TraitsPunishments = new List<Trait>();
    protected List<Buff> BuffPunishments = new List<Buff>();

    public Encounter(Encounter e)
    {
        Name = e.Name;
        Intro = e.Intro;
        Decision = e.Decision;
        Sacrificed = e.Sacrificed;
        Challenges = new List<Challenge>(e.Challenges);
        EndPositive = e.EndPositive;
        Rewards = new List<string>(e.Rewards);
        EndNegative = e.EndNegative;
        Punishments = new List<string>(e.Punishments);
    }

    public void Initialize()
    {
        for(int i = 0; i < Rewards.Count; i++)
        {
            for (int j = 0; j < Manager.Instance.Traits.Count; j++)
            {
                if (Manager.Instance.Traits[j].Name == Rewards[i])
                {
                    TraitsRewards.Add(new Trait(Manager.Instance.Traits[j]));
                }
            }
            for (int j = 0; j < Manager.Instance.Buffs.Count; j++)
            {
                if (Manager.Instance.Buffs[j].Name == Rewards[i])
                {
                    BuffRewards.Add(new Buff(Manager.Instance.Buffs[j]));
                }

            }
        }

        for (int i = 0; i < Punishments.Count; i++)
        {
            for (int j = 0; j < Manager.Instance.Traits.Count; j++)
            {
                if (Manager.Instance.Traits[j].Name == Punishments[i])
                {
                    TraitsPunishments.Add(new Trait(Manager.Instance.Traits[j]));
                }
            }
            for (int j = 0; j < Manager.Instance.Buffs.Count; j++)
            {
                if (Manager.Instance.Buffs[j].Name == Punishments[i])
                {
                    BuffPunishments.Add(new Buff(Manager.Instance.Buffs[j]));
                }

            }
        }

        for (int i = 0; i < Challenges.Count; i++)
        {
            Challenges[i].Initialize();
        }
    }

    private void UpdateEncounter()
    {
        switch (State)
        {
            case EncounterState.Intro:

            break;
            case EncounterState.Decision:

            break;
            case EncounterState.Sacrificed:

            break;
            case EncounterState.Won:

            break;
            case EncounterState.Lost:

            break;
        }
    }

    public void SetEncounterState(EncounterState state)
    {
        if (State != state)
        {
            State = state;
            UpdateEncounter();
        }
    }
}
