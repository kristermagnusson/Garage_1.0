public abstract class Vehicle : IVehicle
{
    public string RegNumber;
    public string Color;
    public int NumberOfWheels;
    public Vehicle(string regnumber, string color, int numberOfWheels)
    {
        RegNumber = regnumber;
        Color = color;
        NumberOfWheels = numberOfWheels;
    }

    public override string ToString()
    {
        return $"Regnumber: {RegNumber}   Color: {Color}  Number Of Wheels: {NumberOfWheels}";
    }
}


public class Car : Vehicle
{
    public int NumberOfDoors;

    public override string ToString()
    {
        return  $" Car        {base.ToString()} Number of Doors {NumberOfDoors} ";
    }


    public Car(string regnumber, string color, int numberOfWheels, int numberOfdoors) : base(regnumber, color, numberOfWheels)
    {
        NumberOfDoors = numberOfdoors;
    }
}

public class Motorcycle : Vehicle
{
    public int CylinderVolume;

    public override string ToString()
    {
        return $" Motorcycle {base.ToString()} Cyl vol: {CylinderVolume} ";
    }

    public Motorcycle(string regnumber, string color, int numberOfWheels, int cylinderVolume) : base(regnumber, color, numberOfWheels)
    {
        CylinderVolume = cylinderVolume;
    }


}
public class Airplane : Vehicle
{
    public int NumberOfSeats;

    public override string ToString()
    {
        return $" Airplane   {base.ToString()} Number of seats: {NumberOfSeats} ";
    }

    public Airplane(string regnumber, string color, int numberOfWheels, int numberOfseats) : base(regnumber, color, numberOfWheels)
    {
        NumberOfSeats = numberOfseats;

    }
}
public class Bus : Vehicle
{
    public string Fueltype;

    public override string ToString()
    {
        return $" Bus        {base.ToString()} Fueltype: {Fueltype} ";
    }

    public Bus(string regnumber, string color, int numberOfWheels, string fueltype) : base(regnumber, color, numberOfWheels)
    {
        Fueltype = fueltype;
    }
}

public class Boat : Vehicle
{
    public bool Doesfloat;

    public override string ToString()
    {
        return $" Boat       {base.ToString()} Floats: {Doesfloat} ";
    }

    public Boat(string regnumber, string color, int numberOfWheels, bool doesfloat) : base(regnumber, color, numberOfWheels)
    {
        Doesfloat = doesfloat;
    }
}

