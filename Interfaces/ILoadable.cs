using Containers.Cargos;

namespace Containers.Interfaces;

public interface ILoadable<T> where T : Cargo
{
    public void Load(T cargo);
    public List<T> Unload();
}