using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Ionic,
    Metallic,
    Covalent,
    Molecular,
    Exothermic,
    Endothermic,
    Acid,
    Base,
    Oxidation,
    Reduction
}

public class Bullet : MonoBehaviour
{
    public BulletType bulletType;
}

