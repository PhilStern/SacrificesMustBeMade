using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {


    private static Manager _instance;

    public static Manager Instance { get { return _instance; } }

    public GameState State;
    public GameState LastState = GameState.Credits;

    [Header("Managers")]
    public CharacterGenerator CGenerator;
    public LevelManager LManager;
    public TeamManager TManager;

    [Header("Character References")]
    public List<Character> Characters = new List<Character>();
    public List<Trait> Traits = new List<Trait>();
    public List<Buff> Buffs = new List<Buff>();



    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void Start()
    {
        //GenerateTeam
        CGenerator.GenerateCharacters(3, CGenerator.TeamTransform, TManager.Team);
        LManager.Initialize();
        TManager.Initialize();
        CGenerator.GenerateCharacters(3, CGenerator.ChooseCharacterTransform, TManager.ChooseNewMembers);
        SetGameState(GameState.Intro);
    }


    public void SetGameState(GameState state)
    {
        State = state;
        if (State != LastState)
        {
            
            if(State == GameState.Credits)
            {

            }
            else if (State == GameState.Intro)
            {

            }
            else if (State == GameState.Lost)
            {

            }
            else if (State == GameState.Menu)
            {

            }
            else if (State == GameState.Outro)
            {

            }
            else if (State == GameState.Paused)
            {

            }
            else if (State == GameState.Playing)
            {

            }
            else if (State == GameState.Won)
            {

            }
            LastState = State;
        }
    }

}
