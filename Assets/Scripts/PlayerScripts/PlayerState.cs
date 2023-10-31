using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum FightStates
    {
        Fighting,
        Roaming,
    }
    public static FightStates fightState = FightStates.Roaming;
}
