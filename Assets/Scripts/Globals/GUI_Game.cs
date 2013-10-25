using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    class GUI_Game:MonoBehaviour
    {
        void OnGUI()
        {
            
            GUILayout.BeginArea(new Rect(Screen.width - 300, 0, 300, Screen.height), "");
            GUI.Box(new Rect(0, 0, 300, Screen.height), "");

            GUI.Label(new Rect(0, 0, 300, 25), "Spieler: " + GameProperties.player[GameProperties.curPlayer].characterName);
            GUI.Label(new Rect(0, 40, 300, 25), "Gang: " + GameProperties.player[GameProperties.curPlayer].gangName);

            GUI.Label(new Rect(0, 80, 150, 25), "Stärke");
            GUI.Label(new Rect(150, 80, 150, 25), GameProperties.player[GameProperties.curPlayer].abilities[ENUMS.ABILITIES.Strength].ToString());
            
            GUI.Label(new Rect(0, 120, 150, 25), "Geschicklichkeit");
            GUI.Label(new Rect(150, 120, 150, 25), GameProperties.player[GameProperties.curPlayer].abilities[ENUMS.ABILITIES.Dexterity].ToString());
            
            GUI.Label(new Rect(0, 160, 150, 25), "Intelligenz");
            GUI.Label(new Rect(150, 160, 150, 25), GameProperties.player[GameProperties.curPlayer].abilities[ENUMS.ABILITIES.Intelligence].ToString());

            GUI.Label(new Rect(0, 200, 150, 25), "Wiederstand");
            GUI.Label(new Rect(150, 200, 150, 25), GameProperties.player[GameProperties.curPlayer].abilities[ENUMS.ABILITIES.Resistance].ToString());


            GUI.Label(new Rect(0, 240, 300, 25), "Tag = " + GameProperties.curDay.ToString());

            if (GUI.Button(new Rect(0, Screen.height - 50, 300, 50), "Nächster Spieler"))
            {
                if (GameProperties.curPlayer == GameProperties.playerCount)
                {
                    GameProperties.curPlayer = 0;
                    GameProperties.curDay++;
                }
                else
                {
                    GameProperties.curPlayer++;
                }
            }
            GUILayout.EndArea();
        }


        void Draw_BattleScreen()
        { 

        }

    }
