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
            GUI.Label(new Rect(0, 0, 300, 20), "Spieler Nr. " + GameProperties.curPlayer.ToString());
            GUI.Label(new Rect(0, 30, 300, 20), "Tag = " + GameProperties.curDay.ToString());

            if (GUI.Button(new Rect(0, Screen.height - 50, Screen.width, 50), "Nächster Spieler"))
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

    }
