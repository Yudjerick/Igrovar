using System;
using System.Collections.Generic;
using UnityEngine;

public static class RuleEventBus
{
    public static Action<Pawn,FieldType> MovedToFieldEvent;
    public static Action<Pawn, FieldType> MovedFromFieldEvent;
    public static Action<Pawn, FieldType> FinishedTurnOnFieldEvent;
    public static Action MovementActionPlayedEvent;
}
