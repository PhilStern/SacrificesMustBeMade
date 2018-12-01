using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CharacterGenerator : MonoBehaviour {


    public Transform TeamTransform;
    public Transform ChooseCharacterTransform;
    public Transform SacrificedCharactersTransform;
    public Transform ReplacedCharactersTransform;

    [SerializeField]
    private int CharacterStartTraitCount;
    [SerializeField]
    private GameObject CharacterPrefab;
    [SerializeField]
    private List<string> Names = new List<string>();
    private string path = "Assets/Resources/Names.txt";
    private string text;

    public void Awake()
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

    public Character GenerateCharacter()
    {
        GameObject Character = (GameObject)Instantiate(CharacterPrefab, TeamTransform.parent);
        Character c = Character.GetComponent<Character>();
        string n = Names[Random.Range(0, Names.Count - 1)];
        string g = n.Substring(0, 1);
        n = n.Substring(1, n.Length-1);
        c.Name = n;
        c.name = c.Name;
        c.Gender = g.ToUpper();
        c.StartTraitCount = CharacterStartTraitCount;
        c.GenerateAttributes();

        return c;
    }

    public void GenerateCharacters(int count, Transform parent, List<Character> CharList)
    {
        CharList.Clear();
        for (int i = 0; i < count; i++)
        {
            Character c = GenerateCharacter();
            c.transform.parent = parent;
            CharList.Add(c);
        }
    }
}
