using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CharacterGenerator : MonoBehaviour {

    public List<string> Names = new List<string>();
    [SerializeField]
    public void LoadNames()
    {

    }

    [MenuItem("Tools/Read file")]
    static void ReadString()
    {
        string path = "Assets/Resources/Names.txt";
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }


    public void CreateCharacter()
    {

    }
}
