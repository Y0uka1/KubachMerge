using System;
using UnityEngine;

namespace Databases
{
    [CreateAssetMenu (fileName = "CubesColorsDatabase", menuName = "Databases/CubesColorsDatabase")]
    public class CubesColorsDatabase:ScriptableObject, ICubesColorsDatabase
    {
        [SerializeField] private CubeColorVo[] colours;

        public Color Get(int tier)
        {
            foreach (var colour in colours)
            {
                if(colour.Tier!=tier)
                    continue;
                return colour.CubeColor;
            }
#if UNITY_EDITOR
            throw new Exception($"[CubesColorsDatabase] Color for tier {tier} not found");
#endif
            return colours[0].CubeColor;
        }
    }

    [Serializable]
    public class CubeColorVo
    {
        public Color CubeColor;
        public int Tier;
    }
}