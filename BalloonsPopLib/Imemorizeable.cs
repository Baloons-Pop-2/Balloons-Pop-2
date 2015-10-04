namespace BalloonsPop
{
    public interface IMemorizeable<T>
    {
        T SaveMemento();

        void RestoreMemento(T memento);
    }
}
