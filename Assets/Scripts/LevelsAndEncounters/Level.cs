using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public string Name;
    [SerializeField]
    private int CurrentEncounter;
    public List<Encounter> Encounters = new List<Encounter>();

    public void Initialize()
    {
        for (int i = 0; i < Encounters.Count; i++)
        {
            Encounters[i].Initialize();
        }
    }

    public void StartEncounter(int i)
    {
        CurrentEncounter = i+1;
        Encounters[CurrentEncounter-1].SetEncounterState(EncounterState.Intro);
    }

    public void NextEncounter()
    {
        CurrentEncounter++;
        Encounters[CurrentEncounter-1].SetEncounterState(EncounterState.Intro);
    }

    public int GetCurrentEncounter()
    {
        return CurrentEncounter;
    }
}
