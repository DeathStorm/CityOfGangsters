using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    class Player:GangMember
    {

        

        public string gangName = "gangname";
        public int gangsterLevel = 1;
        public int gansterPoints = 0;
        public int curMovementPoints = 10;
        public int maxMovementPoints = 10;
        public int money = 50;

        public Item body = null;
        public Item head = null;
        public Item legs = null;
        public Item shoes = null;
        public Item smartPhone = null;
        public Item[] inventory = new Item[6];
        public GangMember[] gangMember = new GangMember[8];

        //public int strenght = 10;
        //public int intelligence = 10;
        //public int dexterity = 10;
        //public int resistance = 10;

        //public int maxHealth = 100;
        //public int curHealth;

        //public Item rangedWeapon = null;
        //public Item meleeWeapon = null;


        public Player():base()
        {
            
            for (int i = 0; i < inventory.Length; i++)
            {
                inventory[i] = null;
            }
            for (int i = 0; i < gangMember.Length; i++)
            {
                gangMember[i] = null;
            }
        }


        public void ReCalcAllAttributes ()
        {

        }


    }
