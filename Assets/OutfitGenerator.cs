using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitGenerator : MonoBehaviour
{

    public Transform headRefPoint, carryRefPoint;

    // Use this for initialization
    void Start()
    {
        GenerateOutfit();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateOutfit()
    {
        CharacterAssets cAssets = Manager.Instance.CGenerator.GetComponent<CharacterAssets>();

        var headitems = cAssets.headItems.items;
        var head = Instantiate(headitems[Random.Range(0, headitems.Count)], headRefPoint.position, Quaternion.identity);

        var go = new GameObject();
        go.transform.position = headRefPoint.position;
        head.transform.parent = go.transform;
        go.transform.parent = gameObject.transform;
        

        var carryitems = cAssets.carryItems.items;
        var carry = Instantiate(carryitems[Random.Range(0, carryitems.Count)], carryRefPoint.position, Quaternion.identity);
        carry.transform.parent = gameObject.transform;



    }
}
