using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    class GameProperties:MonoBehaviour
    {

        const int maxPlayers = 4;
        //public static int curActivePlayer;
        public static int curPlayer;
        public static int curDay;
        public static int playerCount;

        public static Player[] player;

        void Awake()
        {
            DontDestroyOnLoad(this);
        }

    }

