using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    private string playerSide;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public int moveCount;
    public GameObject playerXactive;
    public GameObject playerOactive;
    public GameObject chooseSidePanel;
    
    public GameObject restartButton;

     void Awake()
    {
        chooseSidePanel.SetActive(false);
        restartButton.SetActive(false);
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
         playerSide = "X";
        moveCount = 0;
        changePanels();
    }
    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().setGameControllerReference(this);
        }
    }
   
    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        
        moveCount++;
          if (moveCount >= 9)
            setGameOverText("It's Draw");
        //Raws
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
         GameOver();
        }
           
        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver();
        }
        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }
        //columns
        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }
        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver();
        }
        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }
        //Diagonals
        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }
        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

       

        changeSide();
        changePanels();
    }
    void GameOver()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
       
        setGameOverText(playerSide + "  Wins!");
  

    }

    void changeSide()
    {
        if (playerSide == "X")
        {
            playerXactive.SetActive(true);
            playerOactive.SetActive(false);
            playerSide = "O";
        }
        
        else if (playerSide == "O")
        {
        playerXactive.SetActive(false);
        playerOactive.SetActive(true);
            playerSide = "X";
        }
            
        
    }
    void setGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
        restartButton.SetActive(true);
    }
    public void restartGame()
    {
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        chooseSidePanel.SetActive(true);
       
        changePanels();
    }
    public void changePanels()
    {
        if (playerSide == "X")
        {
            playerXactive.SetActive(true);
            playerOactive.SetActive(false);
        }
        if (playerSide == "O")
        {
            playerXactive.SetActive(false);
            playerOactive.SetActive(true);
        }
    }
   public void chooseSideX()
    {
        playerSide = "X";
        chooseSidePanel.SetActive(false);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = true;
            buttonList[i].text = "";
        }
    }
    public void chooseSideO()
    {
        playerSide = "O";
        chooseSidePanel.SetActive(false);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = true;
            buttonList[i].text = "";
        }
    }
}
