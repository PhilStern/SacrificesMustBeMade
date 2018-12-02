using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public string Name;
    public string Intro;
    public int MaxTeamMembers;
    [SerializeField]
    private int EncounterCount;
    [SerializeField]
    private int CurrentEncounter;
    public List<Encounter> Encounters = new List<Encounter>();

    public void Initialize()
    {
        GenerateLevel(EncounterCount);
        for (int i = 0; i < Encounters.Count; i++)
        {
            Encounters[i].Initialize();
        }
        
    }

    public void StartEncounter(int i)
    {
        CurrentEncounter = i;
        Encounters[CurrentEncounter].SetEncounterState(EncounterState.Intro);
    }

    public void NextEncounter()
    {
        CurrentEncounter++;
        Encounters[CurrentEncounter].SetEncounterState(EncounterState.Intro);
    }

    public int GetCurrentEncounter()
    {
        return CurrentEncounter;
    }

    public void GenerateLevel(int encounterCount)
    {
        for (int i = 0; i < encounterCount; i++)
        {
            int j = Mathf.RoundToInt(Random.Range(-0.5f, Manager.Instance.Encounters.Count - 0.5f));
            while (i!= 0 && Manager.Instance.Encounters[j].Name == Encounters[i-1].Name)
            {
                j = Mathf.RoundToInt(Random.Range(-0.5f, Manager.Instance.Encounters.Count - 0.5f));
            }

            Encounters.Add(new Encounter(Manager.Instance.Encounters[j]));
        }
    }
}
