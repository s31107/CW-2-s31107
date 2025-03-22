using Containers.Cargos;

namespace Containers.Interfaces;

public interface IHazardNotifier
{
    public void Notify(string notification);
}