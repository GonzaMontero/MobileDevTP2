using System;
using UnityEngine;

namespace Scripts.Gameplay.Turrets
{
    [System.Serializable]
    public class TurretSerializable
    {
        public string Name;
        public int Cost;
        public GameObject Prefab;

        public TurretSerializable(string _name, int _cost, GameObject _prefab)
        {
            Name = _name;
            Cost = _cost;
            Prefab = _prefab;
        }
    }

}
