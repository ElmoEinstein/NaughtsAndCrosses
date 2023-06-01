using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateTicTacToe : MonoBehaviour
{
    [SerializeField] List<GameObject> grid;
    Dictionary<GameObject, ButtonPosInGrid> gridDict;
    [SerializeField] List<ListOfWinConditions> winConditions;

    [SerializeField] TextMeshProUGUI _winningText;
    [SerializeField] GameObject restartButton;

    private void Start()
    {
        GlobalStage.isCrossesGo = true;
        _winningText.text = "";

        gridDict = new Dictionary<GameObject, ButtonPosInGrid>();
        foreach (GameObject _obj in grid)
        {

            ButtonPosInGrid _buttonPos = _obj.GetComponent<ButtonPosInGrid>();
            gridDict.Add(_obj, _buttonPos);
            Debug.Log($"{_obj} {_buttonPos.Pos}");
        }
    }

    private void Update()
    {
        foreach (KeyValuePair<GameObject, ButtonPosInGrid> _item in gridDict)
        {
            if (_item.Value.TicTacStage == TicTacToeStages.Neutral)
                _item.Value.TextObject.text = "";
            else if (_item.Value.TicTacStage == TicTacToeStages.Cross)
                _item.Value.TextObject.text = "X";
            else if (_item.Value.TicTacStage == TicTacToeStages.Naught)
                _item.Value.TextObject.text = "0";
        }

        
        foreach(ListOfWinConditions _list in winConditions)
        {
                int i = 0;
                bool _break = false;
                TicTacToeStages _stage = TicTacToeStages.Neutral;

                foreach (Vector2 _positions in _list.winCons)
                {

                    if (i == 0)
                    {
                        foreach (KeyValuePair<GameObject, ButtonPosInGrid> _item in gridDict)
                        {
                            if(_item.Value.Pos == _positions)
                            {
                                _stage = _item.Value.TicTacStage;
                                break;
                            }
                        }
                    }

                    foreach (KeyValuePair<GameObject, ButtonPosInGrid> _item in gridDict)
                    {
                        if (_stage == TicTacToeStages.Neutral)
                        {
                            _break = true;
                        }

                        if (_item.Value.Pos == _positions)
                        {
                            if (_stage != _item.Value.TicTacStage)
                            {
                                _break = true;
                                Debug.Log("broke because of stage");
                            }
                        }


                    }
                    Debug.Log(i);
                    if (_break == true) break;
                    i++;
                    if (i == 3)
                    {
                        _winningText.text = $"{_stage} Wins!!!";
                    restartButton.SetActive(true);
                        gameObject.SetActive(false);
                    }


                }


        



        }

        int _value = 0;
        foreach (KeyValuePair<GameObject, ButtonPosInGrid> _item in gridDict)
        {
            if (_item.Value.TicTacStage == TicTacToeStages.Neutral) break;
            _value++;
            if(_value == 9)
            {
                _winningText.text = $"Draw";
                restartButton.SetActive(true);

                gameObject.SetActive(false);
            }
        }


    }




}

[System.Serializable]
public class ListOfWinConditions
{
    public List<Vector2> winCons;
}
public enum TicTacToeStages
{
    Neutral,
    Cross,
    Naught
}