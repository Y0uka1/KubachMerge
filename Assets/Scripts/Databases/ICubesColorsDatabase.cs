using UnityEngine;

namespace Databases
{
    public interface ICubesColorsDatabase
    {
        Color Get(int tier);
    }
}