using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RuleEventBus: MonoBehaviour 
{
    public static RuleEventBus instance;

    private void Start()
    {
        instance = this;
    }

    public Action<Pawn,FieldType> MovedToFieldEvent;
    public Action<Pawn, FieldType> MovedFromFieldEvent;
    public Action<Pawn, FieldType> FinishedTurnOnFieldEvent;
    public UnityEvent PawnPlayedEvent;
    public UnityEvent RookPlayedEvent;
    public UnityEvent BishopPlayedEvent;
    public UnityEvent KnightPlayedEvent;
    public UnityEvent KingPlayedEvent;
    public UnityEvent QueenPlayedEvent;
}
