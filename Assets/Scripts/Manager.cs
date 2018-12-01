using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {


    private static Manager _instance;

    public static Manager Instance { get { return _instance; } }


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


    public GameState State;
    public CharacterGenerator CGenerator;
    public List<Character> Characters = new List<Character>();
    public List<Character> Team = new List<Character>();
    public List<Trait> Traits = new List<Trait>();
    public List<Buff> Buffs = new List<Buff>();

    public void Start()
    {
        //GenerateTeam
        CGenerator.GenerateCharacters(3, CGenerator.TeamTransform, Team);
    }




}
