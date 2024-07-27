using Scripts.Utilities;
using UnityEngine;

namespace Scripts.Gameplay.Managers
{
    public class PathManager : SingletonInScene<PathManager>
    {
        public Transform StartPoint;
        public Transform[] PathPoints;


    }
}