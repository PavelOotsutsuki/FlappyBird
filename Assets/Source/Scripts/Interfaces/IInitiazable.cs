public interface IInitiazable
{
    public void Init();
}

public interface IInitiazable<T>
{
    public void Init(T parametr);
}

public interface IInitiazable<T,U>
{
    public void Init(T parametr1, U parametr2);
}
