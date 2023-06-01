using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ButtonPosInGrid : MonoBehaviour
{
    public static Action<float,float> shakeScreen;
    public Vector2 Pos;
    public TextMeshProUGUI TextObject;


    [HideInInspector] public TicTacToeStages TicTacStage = TicTacToeStages.Neutral;


    public void SetStage()
    {
        if (TicTacStage != TicTacToeStages.Neutral) return;
        if (GlobalStage.isCrossesGo == true) TicTacStage = TicTacToeStages.Cross;
        else TicTacStage = TicTacToeStages.Naught;

        GlobalStage.isCrossesGo = !GlobalStage.isCrossesGo;
        shakeScreen?.Invoke(1f,.10f);
    }
}
