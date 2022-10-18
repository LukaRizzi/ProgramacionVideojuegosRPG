using System;
using System.Collections.Generic;
using UnityEngine;


namespace RPGUNDAV.Gameplay{
    public class WeaponLoader : MonoBehaviour{
        public Weapon startingWeapon;
        private HashSet<Weapon> obtainedWeapons;

        [SerializeField] private List<GameObject> weaponInventory;
        private Dictionary<Weapon,GameObject> weaponObjects;
        private GameObject currentWeaponObject {get; set;}


        public void Start(){
            InitializeWeapons();
            obtainedWeapons.Add(startingWeapon);
            currentWeaponObject = weaponObjects[startingWeapon];
            currentWeaponObject.SetActive(true);
        }

        public void Swap(Weapon weapon){
            if(obtainedWeapons.Contains(weapon)){
                currentWeaponObject.SetActive(false);
                currentWeaponObject = weaponObjects[weapon];
                currentWeaponObject.SetActive(true);
            }
        }

        public void Add(Weapon weapon){
            obtainedWeapons.Add(weapon);
        }

        private void InitializeWeapons(){
            //aca se linkean los prefabs con los weapons
        }
    }
}