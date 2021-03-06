﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Utils;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        public string Name = "A weapon";
        //stats of the weapon
        public WeaponData Data;
        //model representing the weapon
        public GameObject Model;
        //materials on weapon model
        public List<Material> Materials;
        #region Weapon Property Accessors
        public float Speed {
            get
            {
                if(Data == null)
                {
                    throw new FieldAccessException("WeaponData not initalised for weapon." +
                        " Failed when accessing Speed value");
                }
                return Data.Speed;
            }
        }
        public Vector2i DamageRange
        {
            get
            {
                if(Data == null)
                {
                    throw new FieldAccessException("WeaponData not initalised for weapon. Failed when accessing Damage Range");
                }
                return Data.DamageRange;
            }
        }
        public string DamageText
        {
            get
            {
                if(Data == null)
                {
                    throw new FieldAccessException("WeaponData not initalised for weapon. Failed when getting damage range");
                }
                return Data.DamageText();
            }
        }
        public string QualityText
        {
            get
            {
                if (Data == null)
                {
                    throw new FieldAccessException("WeaponData not initalised for weapon. Failed when getting damage range");
                }
                return Data.QualityText();

            }
        }
        public int DamageRoll
        {
            get
            {
                if(Data == null)
                {
                    throw new FieldAccessException("WeaponData not initalised for weapon. Failed when rolling Damage");

                }
                return Data.RollDamage();
            }
        }
        #endregion

       
        public void DisableRigidBody()
        {
            Rigidbody body = GetComponent<Rigidbody>();
            if (body)
            {
                body.isKinematic = true;
                body.useGravity = false;
                body.mass = 0f;
            }
            BoxCollider[] childColl = GetComponentsInChildren<BoxCollider>();
            if (childColl != null)
            {
                foreach(var c in childColl)
                {
                    c.enabled = false;
                }
            }
        }

        public void EnableRigidBody()
        {
            Rigidbody body = GetComponent<Rigidbody>();
            if (body)
            {
                body.isKinematic = false;
                body.useGravity = true;
                body.mass = 0.1f;
                
            }
            BoxCollider[] childColl = GetComponentsInChildren<BoxCollider>();
            if (childColl != null)
            {
                foreach (var c in childColl)
                {
                    c.enabled = true;
                }
            }
        }

      

    }
}
