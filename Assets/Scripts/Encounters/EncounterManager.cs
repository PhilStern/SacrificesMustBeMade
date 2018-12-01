using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour {

    [SerializeField]
    private List<Encounter> Encounters = new List<Encounter>();

	// Use this for initialization
	public void Initialize ()
    {
        for (int i = 0; i < Encounters.Count; i++)
        {
            Encounters[i].Initialize();
        }
	}

}
