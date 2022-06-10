public interface IGarage<T> where T : IVehicle
{
    int Capacity { get; init; }

    IEnumerator<T> GetEnumerator();
    bool Park(T vehicle);
    bool Unpark(string regnr);
}