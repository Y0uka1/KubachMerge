using Views;

namespace Databases
{
    public interface ICubesMeshesDatabase
    {
        CubeView Get(string key);
    }
}