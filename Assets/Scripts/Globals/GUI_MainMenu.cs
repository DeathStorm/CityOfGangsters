using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class GUI_MainMenu : MonoBehaviour
{
    private enum MENUS { MainMenu, NewGame, PlayerGeneration, Options };

    private MENUS currentMenu = MENUS.MainMenu;



    private int playerCount = 0;
    private string[] selectionGridPlayer = new string[4] { "1", "2", "3", "4" };

    private int curPlayerConfiguration = 0;

    private string characterName;
    private string gangName;
    private Dictionary<ENUMS.ABILITIES, int> abilities = new Dictionary<ENUMS.ABILITIES, int>();

    //private int strenght;
    //private int intelligence;
    //private int dexterity;
    //private int resistance;
    private int abillityPoints;

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
        int buttonWidth = 100;
        int buttonHeight = 50;
        int buttonSpace = 20;

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
        int buttonWidth = 100;
        int buttonHeight = 50;
        int buttonSpace = 20;

        int xPos = (Screen.width - buttonWidth) / 2;

        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 1:
                    playerCount = GUI.SelectionGrid(new Rect(xPos, 100 + (buttonHeight + buttonSpace) * i, buttonWidth, buttonHeight), playerCount, selectionGridPlayer, selectionGridPlayer.Length);
                    break;
                case 2:
                    if (GUI.Button(new Rect(xPos, 100 + (buttonHeight + buttonSpace) * i, buttonWidth, buttonHeight), "Spieler konfigurieren"))
                    {
                        GameProperties.player = new Player[playerCount + 1];
                        GameProperties.playerCount = playerCount;
                        SetDefault();
                        currentMenu = MENUS.PlayerGeneration;
                    }
                    break;
                case 4:
                    if (GUI.Button(new Rect(xPos, 100 + (buttonHeight + buttonSpace) * i, buttonWidth, buttonHeight), "Zurück"))
                    { currentMenu = MENUS.MainMenu; }
                    break;
            }
        }
        //playerCount = GUI.SelectionGrid(new Rect(xPos,100,buttonWidth,buttonHeight),playerCount,selectionGridPlayer,4)
    }

    void Draw_PlayerGeneration()
    {
        int buttonWidth = 200;
        int buttonHeight = 25;
        int buttonSpace = 10;


        int posX = (Screen.width - buttonWidth) / 2;
        int posY;
        ENUMS.ABILITIES abilitie;

        for (int i = 0; i < 10; i++)
        {
            Rect rect = new Rect(posX, 100 + (buttonHeight + buttonSpace) * i, buttonWidth, buttonHeight);
            posY = 100 + (buttonHeight + buttonSpace) * i;

            switch (i)
            {
                case 1:
                    GUI.Label(rect, "Spieler - " + (curPlayerConfiguration + 1).ToString());
                    break;
                case 2:
                    GUI.Label(new Rect(posX, posY, buttonWidth / 2, buttonHeight), "Spielername:");
                    characterName = GUI.TextField(new Rect(posX+buttonWidth/2,posY,buttonWidth/2,buttonHeight), characterName);
                    break;
                case 3:
                    GUI.Label(new Rect(posX, posY, buttonWidth / 2, buttonHeight), "Gangname:");
                    gangName = GUI.TextField(new Rect(posX + buttonWidth / 2, posY, buttonWidth / 2, buttonHeight), gangName);                    
                    break;
                case 4:                     
                    GUI.Label(new Rect(posX, posY, buttonWidth / 2, buttonHeight), "Stärke:");
                    abilitie = ENUMS.ABILITIES.Strength;
                    if (GUI.Button(new Rect(posX + buttonWidth / 2, posY, buttonWidth / 8, buttonHeight), "-")) ChangeAbilitie(abilitie, -1);
                    GUI.TextArea(new Rect(posX + buttonWidth * 5 / 8, posY, buttonWidth / 4, buttonHeight), abilities[abilitie].ToString());
                    if (GUI.Button(new Rect(posX + buttonWidth * 7 / 8, posY, buttonWidth / 8, buttonHeight), "+")) ChangeAbilitie(abilitie, 1);
                    break;
                case 5:
                    GUI.Label(new Rect(posX, posY, buttonWidth / 2, buttonHeight), "Geschicklichkeit:");
                    abilitie = ENUMS.ABILITIES.Dexterity;
                    if (GUI.Button(new Rect(posX + buttonWidth / 2, posY, buttonWidth / 8, buttonHeight), "-")) ChangeAbilitie(abilitie, -1);
                    GUI.TextArea(new Rect(posX + buttonWidth * 5 / 8, posY, buttonWidth / 4, buttonHeight), abilities[abilitie].ToString());
                    if (GUI.Button(new Rect(posX + buttonWidth * 7 / 8, posY, buttonWidth / 8, buttonHeight), "+")) ChangeAbilitie(abilitie, 1);
                    break;
                case 6:
                    GUI.Label(new Rect(posX, posY, buttonWidth / 2, buttonHeight), "Intelligenz:");
                    abilitie = ENUMS.ABILITIES.Intelligence;
                    if (GUI.Button(new Rect(posX + buttonWidth / 2, posY, buttonWidth / 8, buttonHeight), "-")) ChangeAbilitie(abilitie, -1);
                    GUI.TextArea(new Rect(posX + buttonWidth * 5 / 8, posY, buttonWidth / 4, buttonHeight), abilities[abilitie].ToString());
                    if (GUI.Button(new Rect(posX + buttonWidth * 7 / 8, posY, buttonWidth / 8, buttonHeight), "+")) ChangeAbilitie(abilitie, 1);
                    break;
                case 7:
                    GUI.Label(new Rect(posX, posY, buttonWidth / 2, buttonHeight), "Wiederstand:");
                    abilitie = ENUMS.ABILITIES.Resistance;
                    if (GUI.Button(new Rect(posX + buttonWidth / 2, posY, buttonWidth / 8, buttonHeight), "-")) ChangeAbilitie(abilitie, -1);
                    GUI.TextArea(new Rect(posX + buttonWidth * 5 / 8, posY, buttonWidth / 4, buttonHeight), abilities[abilitie].ToString());
                    if (GUI.Button(new Rect(posX + buttonWidth * 7 / 8, posY, buttonWidth / 8, buttonHeight), "+")) ChangeAbilitie(abilitie, 1);
                    break;
                case 8:
                    GUI.Label(new Rect(posX, posY, buttonWidth / 2, buttonHeight), "Fertigkeitpunkte:");                    
                    GUI.TextArea(new Rect(posX + buttonWidth /2, posY, buttonWidth / 4, buttonHeight), abillityPoints.ToString());                    
                    break;
                case 9:
                    string text;
                    if (curPlayerConfiguration == playerCount)
                    { text = "Spiel starten"; }
                    else
                    { text = "Nächster Spieler"; }

                    if (GUI.Button(rect, text))
                    {
                        Debug.Log(GameProperties.player.Length.ToString() + " - " + curPlayerConfiguration.ToString());
                        GameProperties.player[curPlayerConfiguration] = new Player();
                        GameProperties.player[curPlayerConfiguration].characterName = characterName;
                        GameProperties.player[curPlayerConfiguration].gangName = gangName;
                        //GameProperties.player[curPlayerConfiguration].abilities = abilities;
                        GameProperties.player[curPlayerConfiguration].abilities[ENUMS.ABILITIES.Strength] = abilities[ENUMS.ABILITIES.Strength];
                        GameProperties.player[curPlayerConfiguration].abilities[ENUMS.ABILITIES.Dexterity] = abilities[ENUMS.ABILITIES.Dexterity];
                        GameProperties.player[curPlayerConfiguration].abilities[ENUMS.ABILITIES.Intelligence] = abilities[ENUMS.ABILITIES.Intelligence];
                        GameProperties.player[curPlayerConfiguration].abilities[ENUMS.ABILITIES.Resistance] = abilities[ENUMS.ABILITIES.Resistance];

                        //GameProperties.player[curPlayerConfiguration].strenght = ab;
                        //GameProperties.player[curPlayerConfiguration].intelligence = intelligence;
                        //GameProperties.player[curPlayerConfiguration].dexterity = dexterity;
                        //GameProperties.player[curPlayerConfiguration].resistance = resistance;

                        if (curPlayerConfiguration == playerCount)
                        {
                            GameProperties.curDay = 1;
                            Application.LoadLevel(Application.loadedLevel + 1);
                        }
                        else
                        {

                            curPlayerConfiguration++;
                            SetDefault();
                        }
                    }
                    break;
                case 10:
                    if (GUI.Button(rect, "Zurück"))
                    { currentMenu = MENUS.NewGame; }
                    break;
            }
        }
    }

    void SetDefault()
    {
        characterName = "PlayerName";
        gangName = "GangName";
        abilities[ENUMS.ABILITIES.Strength] = 10;
        abilities[ENUMS.ABILITIES.Intelligence] = 10;
        abilities[ENUMS.ABILITIES.Dexterity] = 10;
        abilities[ENUMS.ABILITIES.Resistance] = 10;

        abillityPoints = 5;
    }

    void ChangeAbilitie(ENUMS.ABILITIES abilitie, int i)
    {
        if (i > 0)
        {
            if (abillityPoints > 0)
            {
                abilities[abilitie]++;
                abillityPoints--;
            }
        }
        else
        {
            if (abilities[abilitie] >= 11)
            {
                abilities[abilitie]--;
                abillityPoints++;
            }
        }
    }

}
