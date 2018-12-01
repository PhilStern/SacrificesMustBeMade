using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public List<Character> Team = new List<Character>();
    public List<Character> SacrificedMembers = new List<Character>();
    public List<Character> ReplacedMembers = new List<Character>();
    public float TeamChemistry;
    public int MaxAttributeValue = 13;
    public int MinAttributeValue = -3;

    public void Initialize()
    {
        TeamChemistry = GetTeamChemistry();
    }

    public float GetTeamChemistry()
    {
        float tc = 0;

        for (int i = 0; i < Team.Count; i++)
        {
            for (int j = i + 1; j < Team.Count; j++)
            {
                for (int x = 0; x < Team[i].Attributes.Count; x++)
                {
                    tc += GetDifference(Team[i].GetAttributeValue(Team[i].Attributes[x].GetAttributeType()), Team[j].GetAttributeValue(Team[j].Attributes[x].GetAttributeType()));
                }
            }
        }

        tc = tc / Team.Count;
        tc = tc / GetDifference(MaxAttributeValue, MinAttributeValue);
        return 1f-(Mathf.Round(tc*100)/100);
    }

    public int GetDifference(int a, int b)
    {
        int r = (a - b) <0 ? (a - b)*-1: (a - b);

        return r;
    }

    public void SwitchTeamCharacter(Character OldCharacter, Character NewCharacter)
    {
        for (int i = 0; i < Team.Count; i++)
        {
            if (Team[i] == OldCharacter)
            {
                OldCharacter.LeaveTeam();
                Team[i] = NewCharacter;
                NewCharacter.EnterTeam(i);
            }
        }
    }

}
