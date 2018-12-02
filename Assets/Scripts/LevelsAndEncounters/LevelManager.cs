using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public List<Level> Levels = new List<Level>();
    private int currentLevel = 0;
    
    // Use this for initialization
    public void Initialize()
    {
        for (int i = 0; i < Levels.Count; i++)
        {
            Levels[i].Initialize();
        }
    }

    public void StartLevel(int index)
    {
        currentLevel = index;
        Levels[index].StartEncounter(0);
    }

    public void NextLevel()
    {
        currentLevel++;
        Levels[currentLevel].StartEncounter(0);
    }

    public int GetLevel()
    {
        return currentLevel;
    }

    public int GetCurrentEncounterCount(int currentLevel, int currentEncounter)
    {
        int c = 0;
        for (int i = 0; i < currentLevel; i++)
        {
            for (int j = 0; j < Levels[i].Encounters.Count; j++)
            {
                if (i < currentLevel)
                {
                    c++;
                }
                else if (i == currentLevel && j < currentEncounter)
                {
                    c++;
                }
            }
        }
        return c;
    }

    public int GetTotalEncounterCount()
    {
        int c = 0;
        for (int i = 0; i < Levels.Count; i++)
        {
            c += Levels[i].Encounters.Count;
        }
        return c;
    }

    
}
