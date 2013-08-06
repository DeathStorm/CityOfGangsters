using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class GUI_MainMenu:MonoBehaviour
{
    private enum MENUS { MainMenu, NewGame, PlayerGeneration, Options };

    private MENUS currentMenu = MENUS.MainMenu;

    private int buttonWidth = 100;
    private int buttonHeight = 50;
    private int buttonSpace = 20;

    private int playerCount = 0;
    private string[] selectionGridPlayer = new string[4] { "1", "2", "3", "4" };

    private int curPlayerConfiguration = 0;

    private string playerName = "PlayerName";
    private string gangName = "GangName";
        

    void OnGUI()
    {
        switch (currentMenu)
        {
            case MENUS.MainMenu:
                Draw_MainMenu();
                break;
            case MENUS.NewGame:
                Draw_NewGame();
                break;
            case MENUS.PlayerGeneration:
                Draw_PlayerGeneration();
                break;
        }
    }

    void Draw_MainMenu()
    {
        int xPos = (Screen.width - buttonWidth) / 2;

        if (GUI.Button(new Rect(xPos, 100, buttonWidth, buttonHeight), "Start"))
        { currentMenu = MENUS.NewGame; }
        if (GUI.Button(new Rect(xPos, 100 + buttonHeight + buttonSpace, buttonWidth, buttonHeight), "Quit"))
        {
            Application.Quit();
        }
    }

    void Draw_NewGame()
    {
        int xPos = (Screen.width - buttonWidth) / 2;

        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 1:
                    playerCount = GUI.SelectionGrid(new Rect(xPos, 100 + (buttonHeight + buttonSpace) * i, buttonWidth, buttonHeight), playerCount, selectionGridPlayer, selectionGridPlayer.Length);
                    break;
                case 2:
                    if (GUI.Button(new Rect(xPos, 100 + (buttonHeight + buttonSpace)*i, buttonWidth, buttonHeight), "Spieler konfigurieren"))
                    {
                        GameProperties.player = new Player[playerCount+1];
                        GameProperties.playerCount = playerCount;
                        currentMenu = MENUS.PlayerGeneration; }
                    break;
                case 4:
                    if (GUI.Button(new Rect(xPos, 100 + (buttonHeight + buttonSpace)*i, buttonWidth, buttonHeight), "Zurück"))
                    { currentMenu = MENUS.MainMenu; }
                    break;
            }
        }
        //playerCount = GUI.SelectionGrid(new Rect(xPos,100,buttonWidth,buttonHeight),playerCount,selectionGridPlayer,4)
    }

    void Draw_PlayerGeneration()
    {
        int xPos = (Screen.width - buttonWidth) / 2;

        for (int i = 0; i < 6; i++)
        {
            Rect rect = new Rect(xPos, 100 + (buttonHeight + buttonSpace) * i, buttonWidth, buttonHeight);
            switch (i)
            {
                case 1:
                    GUI.Label(rect, "Spieler - " + (curPlayerConfiguration+1).ToString());
                    break;
                case 2:
                    playerName = GUI.TextField(rect, playerName);                    
                    break;
                case 3:
                    gangName = GUI.TextField(rect, gangName);
                    break;
                case 5:
                    string text;
                    if (curPlayerConfiguration == playerCount)
                    { text = "Spiel starten"; } 
                    else
                    { text = "Nächster Spieler"; } 

                    if (GUI.Button(rect, text))
                    {
                        GameProperties.player[curPlayerConfiguration] = new Player();
                        if (GameProperties.player[0] == null) Debug.Log("IS NULL");
                        GameProperties.player[curPlayerConfiguration].playerName = playerName;
                        GameProperties.player[curPlayerConfiguration].gangName = gangName;

                        if (curPlayerConfiguration == playerCount)
                        {
                            GameProperties.curDay = 1;
                            Application.LoadLevel(Application.loadedLevel+1);
                        }
                        else
                        {
                            
                            curPlayerConfiguration++;
                            playerName = "PlayerName";
                            gangName = "GangName";
                        }
                    }
                    break;
                case 6:
                    if (GUI.Button(rect, "Zurück"))
                    { currentMenu = MENUS.NewGame; }
                    break;
            }
        }
    }
}
