using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button Button;
    public Text buttontext;
    private GameController gameController;

    public void setGameControllerReference(GameController Controller)
    {
        gameController = Controller;
    }

    public void setspace()
    {
        buttontext.text = gameController.GetPlayerSide();
        Button.interactable = false;
        gameController.EndTurn();
    }
}
