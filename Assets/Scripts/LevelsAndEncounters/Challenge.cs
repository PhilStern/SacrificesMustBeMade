using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Challenge
{
    public int ChallengeValue
    {
        get
        {
            int lvl = lm.GetLevel();
            int enc = lm.Levels[lvl - 1].GetCurrentEncounter();
            int progress = lm.GetCurrentEncounterCount(lvl,enc)/lm.GetTotalEncounterCount();
            int value = Mathf.RoundToInt(DificultyCurve.Evaluate(progress));
            return value;
        }
    }
    public AttributeType Type;

    [SerializeField]
    private AnimationCurve DificultyCurve;
    [SerializeField]
    private int MinValue;
    [SerializeField]
    private int MaxValue;
    [SerializeField]
    [Tooltip("A value of 5 is -5 in the y axis.")]
    private float TopTangent;
    private LevelManager lm;
    

    public void Initialize()
    {
        DificultyCurve = new AnimationCurve();
        DificultyCurve.AddKey(0f, MinValue);
        DificultyCurve.AddKey(1f, MaxValue);
        for (int i = 0; i < DificultyCurve.length; i++)
        {
            Keyframe key = DificultyCurve[i];
            key.inTangent = 10f;
            key.outTangent = 1f;
            DificultyCurve.MoveKey(i, key);
        }
        lm = Manager.Instance.LManager;
    }
}


