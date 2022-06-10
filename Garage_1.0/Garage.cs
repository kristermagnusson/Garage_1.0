
using System.Collections;

public class Garage<T> : IEnumerable<T>, IGarage<T> where T : Vehicle
{



    public int Capacity { get; init; }



    private T[] vehicles;

    public Garage(int capacity)
    {
        Capacity = capacity;
        vehicles = new T[capacity];
    }

    public bool Park(T vehicle)
    {
        for (int i = 0; i < (Capacity); i++)
        {
            if (vehicles[i] == null)
            {
                vehicles[i] = vehicle;
                return true;
            }
        }
        return false;


    }

    public bool Unpark(string regnr)
    {

        for (int i = 0; i < (Capacity); i++)
        {
            if (vehicles[i] is not null && vehicles[i].RegNumber == regnr)
            {
                vehicles[i] = null;
                return true;
            }
        }
        return false;



    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] is not null)
            {
                yield return vehicles[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

