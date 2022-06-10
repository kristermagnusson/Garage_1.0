namespace Garage_1._0
{
    public interface IGarageHandler
    {
        bool CheckRegNr(string regnr);
        void FindByRegNr(string regnr);
        int FreePlaces();
        void Park(Vehicle vehicle);
        void PrintAllVehicles();
        void PutVehicle();
        void Query();
        void Search(List<Vehicle> VehicleList, int Wheels = 0, string GColors = "");
        void SeedData();
        void TypeAndNumber();
        void UnPark(string regNumber);
    }
}