namespace TestProject_Garage
{
    public class GarageTest
    {
        //[Fact]
        //public void TestPositiveCapacityOfInternalArray()
        //{
        //    int capacity = 2;//Arrange
        //    var garage = new Garage<Vehicle>(capacity); //Act
        //    Assert.Equal(capacity, garage.vehicles.Length); //Assert

        //}
        //[Fact]                                                                       // Does only work if  internal array  is set to public
        //public void TestZeroCapacityOfInternalArray()                                //in Garage<T>
        //{
        //    int capacity = 0;
        //    var garage = new Garage<Vehicle>(capacity);
        //    Assert.Equal(capacity, garage.vehicles.Length);
        //}
        [Fact]

        public void TestNumberOfvehiclesInGarage()
        {
            int capacity = 10;

            var garage = new Garage<Vehicle>(capacity);

            garage.Park(new Boat("AAA002", "Black", 3, false));
            garage.Park(new Bus("AAA001", "Yelow", 4, "diesel"));
            garage.Park(new Boat("AAA003", "Black", 3, true));
            garage.Park(new Car("AAA004", "White", 4, 4));
            garage.Park(new Airplane("AAA005", "Silver", 3, 50));

            Assert.Equal(5, garage.Count());
        }
        [Fact]

        public void TestOverCapacityOFGarage()
        {
            int capacity = 4;

            var garage = new Garage<Vehicle>(capacity);

            garage.Park(new Boat("AAA002", "Black", 3, false));
            garage.Park(new Bus("AAA001", "Yelow", 4, "diesel"));
            garage.Park(new Boat("AAA003", "Black", 3, true));
            garage.Park(new Car("AAA004", "White", 4, 4));
            garage.Park(new Airplane("AAA005", "Silver", 3, 50));

            Assert.Equal(capacity, garage.Count());
        }


        [Fact]

        public void TestOverCapacityOFPark()
        {
            int capacity = 3;

            var garage = new Garage<Vehicle>(capacity);

            garage.Park(new Boat("AAA002", "Black", 3, false));
            garage.Park(new Bus("AAA001", "Yelow", 4, "diesel"));
            garage.Park(new Boat("AAA003", "Black", 3, true));
            garage.Park(new Car("AAA004", "White", 4, 4));

            bool Test = garage.Park(new Airplane("AAA005", "Silver", 3, 50));

            Assert.False(Test);
        }
        [Fact]
        public void TestinCapacityOFPark()
        {
            int capacity = 7;

            var garage = new Garage<Vehicle>(capacity);

            garage.Park(new Boat("AAA002", "Black", 3, false));
            garage.Park(new Bus("AAA001", "Yelow", 4, "diesel"));
            garage.Park(new Boat("AAA003", "Black", 3, true));
            garage.Park(new Car("AAA004", "White", 4, 4));
           
            bool Test = garage.Park(new Airplane("AAA005", "Silver", 3, 50));

            Assert.True(Test);
        }

        [Fact]
        public void TestinputEmptyCarTogaragek()
        {
            int capacity = 7;

            var garage = new Garage<Vehicle>(capacity);

            garage.Park(new Boat(default, default, default, default));

            Assert.Equal(1, garage.Count());
        }

            [Fact]
        public void TestRemoveOneOfFiveinCapacityOFPark()
        {
            int capacity = 7;

            var garage = new Garage<Vehicle>(capacity);

            garage.Park(new Boat("AAA002", "Black", 3, false));
            garage.Park(new Bus("AAA001", "Yelow", 4, "diesel"));
            garage.Park(new Boat("AAA003", "Black", 3, true));
            garage.Park(new Car("AAA004", "White", 4, 4));
            garage.Park(new Airplane("AAA005", "Silver", 3, 50));

            garage.Unpark("AAA004");

            Assert.Equal(4, garage.Count());
         }

            [Fact]
        public void TestOFUnParkWithZeroVehiclesInGarage()
        {
            int capacity = 1;
            var garage = new Garage<Vehicle>(capacity);
            bool Test = garage.Unpark("AAA004");

            Assert.False(Test);
        }

        [Fact]
        public void TestOFUnParkWithOutTargetVehicleInGarage()
        {
            int capacity = 3;
            var garage = new Garage<Vehicle>(capacity);
            garage.Park(new Boat("AAA002", "Black", 3, false));
            garage.Park(new Bus("AAA001", "Yelow", 4, "diesel"));
            garage.Park(new Boat("AAA003", "Black", 3, true));

            bool Test = garage.Unpark("AAA004");

            Assert.False(Test);
        }

        [Fact]
        public void TestOFUnParkWithTargetVehicleInGarage()
        {
            int capacity = 7;
            var garage = new Garage<Vehicle>(capacity);
            garage.Park(new Boat("AAA002", "Black", 3, false));
            garage.Park(new Bus("AAA001", "Yelow", 4, "diesel"));
            garage.Park(new Boat("AAA003", "Black", 3, true));

            bool Test = garage.Unpark("AAA003");

            Assert.True(Test);
        }
    }
}
