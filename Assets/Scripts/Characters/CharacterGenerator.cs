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
    [SerializeField]
    private List<Sprite> MaleBodies = new List<Sprite>();
    [SerializeField]
    private List<Sprite> FemaleBodies = new List<Sprite>();
    private string path = "Assets/Resources/Names.txt";
    private string text;


    [SerializeField]
    private Vector3 TeamStartPosition;
    [SerializeField]
    private float TeamSectionWidth;
    [SerializeField]
    private Vector3 ChooseCharaStartPosition;
    [SerializeField]
    private float ChooseCharaSectionWidth;

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
        GameObject Character = (GameObject)Instantiate(CharacterPrefab, Vector3.zero, Quaternion.identity);
        Character c = Character.GetComponent<Character>();
        GameObject body = new GameObject("Body");
        body.transform.position = Character.transform.position;
        body.transform.parent = Character.transform;
        SpriteRenderer sr = body.AddComponent<SpriteRenderer>();
        c.SR = sr;
        string n = Names[Random.Range(0, Names.Count - 1)];
        string g = n.Substring(0, 1);
        n = n.Substring(1, n.Length-1);
        c.Name = n;
        c.name = c.Name;
        c.Gender = g.ToUpper();
        if (c.Gender == "M")
        {
            c.SR.sprite = MaleBodies[Random.Range(0, MaleBodies.Count)];
        }
        else if (c.Gender == "F")
        {
            c.SR.sprite = FemaleBodies[Random.Range(0, FemaleBodies.Count)];
        }
        c.Drag = c.gameObject.AddComponent<Dragable>();
        c.Drag.sr = sr;
        c.Target = c.gameObject.AddComponent<Targetable>();
        c.BC = c.gameObject.AddComponent<BoxCollider2D>();
        c.BC.size = new Vector2(1.5f, 3f);
        c.RB = c.gameObject.AddComponent<Rigidbody2D>();
        c.RB.isKinematic = true;
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
            if (parent == TeamTransform)
            {
                c.Drag.Active = false;
            }
            else if (parent == ChooseCharacterTransform)
            {
                c.Target.Active = false;
            }
            c.transform.parent = parent;
            CharList.Add(c);
        }
        if (parent == TeamTransform)
        {
            PlaceCharacters(TeamStartPosition, TeamSectionWidth, Manager.Instance.TManager.Team);
        }
        if (parent == ChooseCharacterTransform)
        {
            PlaceCharacters(ChooseCharaStartPosition, ChooseCharaSectionWidth, Manager.Instance.TManager.ChooseNewMembers);
        }

    }

    public void SpawnNewCharactersToChoose(int count)
    {
        GenerateCharacters(count, ChooseCharacterTransform, Manager.Instance.TManager.ChooseNewMembers);
    }

    public void PlaceCharacters(Vector3 startPosition, float areaWidth, List<Character> charas)
    {
        float dist = areaWidth / charas.Count;

        for(int i = 0; i < charas.Count; i++)
        {
            charas[i].transform.position = startPosition + new Vector3(dist * i,0f,0f);
            charas[i].CharacterPosition = charas[i].transform.position;
        }
    }
}
