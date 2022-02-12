using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TankSO;
using BulletSO;

namespace TankServices
{
    //this class is responsilbe to take care of data...
    public class TankModel
    {
        //Tank Type
        private TankController tankController;
        public TankType tankType { get; private set; }

        //Movement Related 
        public float movementSpeed { get; private set; }
        public float rotationSpeed { get; private set; }

        //Attack Related 
        public float fireRate { get; private set; }
        public BulletScriptableObject bulletType { get; private set; }

        //Health Related
        public float health { get; set; }

        //Visuals
        public Material material { get; private set; }

        //Achievenement Related 
        public int BulletsFired;
        public int EnemiesKilled;

        public TankModel(TankScriptableObject tankScriptable, TankSOList tankList)
        {
            //type
            tankType = tankScriptable.tankType;

            // behaviour vars
            movementSpeed = tankScriptable.movementSpeed;
            rotationSpeed = tankScriptable.rotationSpeed;
            fireRate = tankScriptable.fireRate;
            health = tankScriptable.health;
            bulletType = tankScriptable.bulletType;

            //color
            material = tankScriptable.material;

            //achivement related
            BulletsFired = PlayerPrefs.GetInt("BulletsFired");
            EnemiesKilled = PlayerPrefs.GetInt("EnemiesKilled");
        }
        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        public void DestroyModel()
        {
            material = null;
            bulletType = null;
            tankController = null;
        }
    }
}