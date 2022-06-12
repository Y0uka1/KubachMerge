using UnityEngine;

namespace Databases
{
    public interface IFightersColorsDatabase
    {
        Sprite Get(int tier);
    }
}