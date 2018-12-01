using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CharacterGenerator : MonoBehaviour {

    [SerializeField]
    private List<string> Names = new List<string>();
    string path = "Assets/Resources/Names.txt";
    
    string text;

    private void Start()
    {
        LoadNames();
    }


    public void LoadNames()
    {
        StreamReader reader = new StreamReader(path);
        while ((text = reader.ReadLine()) != null)
        {
            Names.Add(text);
        }
        reader.Close();
    }



    public void CreateCharacter()
    {

    }
}
