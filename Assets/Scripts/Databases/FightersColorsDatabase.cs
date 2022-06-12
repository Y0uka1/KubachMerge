using System;
using UnityEngine;

namespace Databases
{
    [CreateAssetMenu (fileName = "FightersColorsDatabase", menuName = "Databases/FightersColorsDatabase")]
    public class FightersColorsDatabase:ScriptableObject, IFightersColorsDatabase
    {
        [SerializeField] private FighterStyleVo[] colours;

        public Sprite Get(int tier)
        {
            foreach (var colour in colours)
            {
                if(colour.Tier!=tier)
                    continue;
                return colour.FighterSprite;
            }
            UnityEngine.Debug.LogError($"[FightersColorsDatabase] Color for tier {tier} not found");
            return colours[tier%colours.Length].FighterSprite;
        }
    }

    [Serializable]
    public class FighterStyleVo
    {
        public Sprite FighterSprite;
        public int Tier;
    }
}