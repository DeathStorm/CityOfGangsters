using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    class GangMember:MonoBehaviour
    {
        public string playerName = "player";
        public int strenght = 10;
        public int intelligence = 10;
        public int dexterity = 10;
        public int resistance = 10;

        public int maxHealth = 100;
        public int curHealth;

        public Item rangedWeapon = null;
        public Item meleeWeapon = null;


        void Awake()
        {
            curHealth = maxHealth;
        }

        public void GetDamage(int damage)
        {
            damage = Mathf.Clamp(damage - resistance, 0, damage);
            curHealth = Mathf.Clamp(curHealth - damage, 0, curHealth);

            if (curHealth <= 0)
            {
                Destroy(this);
            }
        }

    }
