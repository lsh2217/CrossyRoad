using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Car Data", menuName = "Scriptable Object/Car Data", order = int.MaxValue)]
public class CarSO : ScriptableObject
{
    [SerializeField]
    private int id;
    public GameObject prefab;
}
