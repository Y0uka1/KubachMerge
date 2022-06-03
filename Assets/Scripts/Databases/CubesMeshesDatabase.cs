using UnityEngine;
using Views;

namespace Databases
{
    [CreateAssetMenu (fileName = "CubesMeshesDatabase", menuName = "Databases/CubesMeshesDatabase")]
    //Here we can add and store any skins for cubes and get them by key (that we should previously add of cource),
    //but since I had only one skin i'll just mock getting the first element of a collection
    public class CubesMeshesDatabase:ScriptableObject, ICubesMeshesDatabase
    {
        [SerializeField] private CubeView[] meshes;

        
        public CubeView Get(string key)
        {
            return meshes[0];
        }
    }
}