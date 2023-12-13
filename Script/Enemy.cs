using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float Hp= 100;
    
/*
    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter(Collision collision)
        {
            
            GameObject bullet = collision.gameObject;

            if (bullet.CompareTag("Ionic"))
            {
                // Handle behavior for BulletType1 collision
                Debug.Log(collision.gameObject.name);
                Destroy(collision.gameObject);
                Hp-=1;
                Debug.Log("HP"+Hp);
            }
            else if (collision.gameObject.CompareTag("Covalent"))
            {
                // Handle behavior for BulletType2 collision
                Debug.Log(collision.gameObject.name);
                Destroy(collision.gameObject);
                Hp-=1;
                Debug.Log("HP"+Hp);
            }
            else if (collision.gameObject.CompareTag("Molecular"))
            {
                // Handle behavior for BulletType2 collision
                Debug.Log(collision.gameObject.name);
            }
            else if (collision.gameObject.CompareTag("Metallic"))
            {
                // Handle behavior for BulletType2 collision
                Debug.Log(collision.gameObject.name);
            }
            else if (collision.gameObject.CompareTag("Acid"))
            {
                // Handle behavior for BulletType2 collision
                Debug.Log(collision.gameObject.name);
            }
            else if (collision.gameObject.CompareTag("Base"))
            {
                // Handle behavior for BulletType2 collision
                Debug.Log(collision.gameObject.name);
            }
            else if (collision.gameObject.CompareTag("Oxidation"))
            {
                // Handle behavior for BulletType2 collision
                Debug.Log(collision.gameObject.name);
            }
            else if (collision.gameObject.CompareTag("Reduction"))
            {
                // Handle behavior for BulletType2 collision
                Debug.Log(collision.gameObject.name);
            }
            else if (collision.gameObject.CompareTag("Exothermic"))
            {
                // Handle behavior for BulletType2 collision
                Debug.Log(collision.gameObject.name);
            }
            else if (collision.gameObject.CompareTag("Endothermic"))
            {
                // Handle behavior for BulletType2 collision
                Debug.Log(collision.gameObject.name);
            }

            // Add more conditions for other bullet types if needed*/

    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null) // Check if the collided object is a bullet
        {
            switch (bullet.bulletType)
            {
                case BulletType.Ionic:
                    Debug.Log(collision.gameObject.name);
                    Destroy(collision.gameObject);
                    Hp-=1;
                    Debug.Log("HP"+Hp);
                    break;

                case BulletType.Metallic:
                    // React to Metallic bullet
                    Debug.Log(collision.gameObject.name);
                    Destroy(collision.gameObject);
                    Hp-=2;
                    Debug.Log("HP"+Hp);
                    break;

                case BulletType.Covalent:
                    // React to Covalent bullet
                    Debug.Log(collision.gameObject.name);
                    Destroy(collision.gameObject);
                    Hp-=3;
                    Debug.Log("HP"+Hp);
                    break;

                case BulletType.Molecular:
                    // React to Molecular bullet
                    Debug.Log(collision.gameObject.name);
                    Destroy(collision.gameObject);
                    Hp-=4;
                    Debug.Log("HP"+Hp);
                    break;

                case BulletType.Exothermic:
                    // React to Exothermic bullet
                    Debug.Log(collision.gameObject.name);
                    Destroy(collision.gameObject);
                    Hp-=5;
                    Debug.Log("HP"+Hp);
                    break;

                case BulletType.Endothermic:
                    // React to Endothermic bullet
                    Debug.Log(collision.gameObject.name);
                    Destroy(collision.gameObject);
                    Hp-=6;
                    Debug.Log("HP"+Hp);
                    break;

                case BulletType.Acid:
                    // React to Acid bullet
                    Debug.Log(collision.gameObject.name);
                    Destroy(collision.gameObject);
                    Hp-=7;
                    Debug.Log("HP"+Hp);
                    break;

                case BulletType.Base:
                    // React to Base bullet
                    Debug.Log(collision.gameObject.name);
                    Destroy(collision.gameObject);
                    Hp-=8;
                    Debug.Log("HP"+Hp);
                    break;

                case BulletType.Oxidation:
                    // React to Oxidation bullet
                    Debug.Log(collision.gameObject.name);
                    Destroy(collision.gameObject);
                    Hp-=9;
                    Debug.Log("HP"+Hp);
                    break;

                case BulletType.Reduction:
                    // React to Reduction bullet
                    Debug.Log(collision.gameObject.name);
                    Destroy(collision.gameObject);
                    Hp-=10;
                    Debug.Log("HP"+Hp);
                    break;
            }
        }
    }
}

