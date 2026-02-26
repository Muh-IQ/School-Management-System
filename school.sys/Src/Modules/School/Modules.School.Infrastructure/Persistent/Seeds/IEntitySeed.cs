namespace Modules.School.Infrastructure.Persistent.Seeds;

public interface IEntitySeed<out T> where T : class
{
    T[] GetData();
}
