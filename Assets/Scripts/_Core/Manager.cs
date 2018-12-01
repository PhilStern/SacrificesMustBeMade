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

    [Header("Base Objects")]
    public List<Encounter> Encounters = new List<Encounter>();
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
        LastState = State;
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
            else if (State == GameState.LevelStart)
            {

            }
            else if (State == GameState.Walking)
            {
                if (LastState == GameState.Acquaintance)
                {
                    StartCoroutine(ChangePhaseInSeconds(GameState.Encounter, 2f));
                }
                else
                {
                    StartCoroutine(ChangePhaseInSeconds(GameState.Acquaintance, 3f));
                }
            }
            else if (State == GameState.Acquaintance)
            {

            }
            else if (State == GameState.Encounter)
            {

            }
            else if (State == GameState.Won)
            {

            }
            
        }
    }

    IEnumerator ChangePhaseInSeconds(GameState state, float wait)
    {
        yield return new WaitForSeconds(wait);
        SetGameState(state);
    }

}
