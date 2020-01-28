using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shooter", menuName = "Item/Shooter")]
public class SO_Shooter : ScriptableObject
{
    [SerializeField] GameObject prefabBullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float delay;
    [SerializeField] Sprite sprite;

    [SerializeField] float dispertion;
    [SerializeField] int numb;

    public Sprite Sprite => sprite;

    public float Delay => delay;

    public float BulletSpeed => bulletSpeed;

    public GameObject PrefablaserGreen => prefabBullet;

    public float Dispertion => dispertion;

    public int Numb => numb;
}
