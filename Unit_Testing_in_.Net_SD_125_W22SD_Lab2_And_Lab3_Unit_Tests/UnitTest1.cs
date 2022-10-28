using Unit_Testing_in_.Net_SD_125_W22SD_Lab2_And_Lab3_Unit_Tests.BLL;
using Unit_Testing_in_.Net_SD_125_W22SD_Lab2_And_Lab3_Unit_Tests.DAL;
using Unit_Testing_in_.Net_SD_125_W22SD_Lab2_And_Lab3_Unit_Tests.Data;
using Unit_Testing_in_.Net_SD_125_W22SD_Lab2_And_Lab3_Unit_Tests.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
//Hello
namespace Unit_Testing_in_.Net_SD_125_W22SD_Lab2_And_Lab3_Unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
        var data1 = new List<Vehicle>
            {
                new Vehicle{ID = 1, PassID = 1, Parked = true},
                new Vehicle{ID = 2, PassID = 2, Parked = false},
                new Vehicle{ID = 3, PassID = 3, Parked = true},
                new Vehicle{ID = 4, PassID = 4, Parked = false},
                new Vehicle{ID = 5, PassID = 5, Parked = false}
            }.AsQueryable();

        var mockDbSet = new Mock<DbSet<Vehicle>>();

        mockDbSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
        mockDbSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
        mockDbSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockDbSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

        var mockContext = new Mock<Unit_Testing_in_.Net_SD_125_W22SD_Lab2_And_Lab3_Unit_TestsContext>();
        mockContext.Setup(c => c.Vehicle).Returns(mockDbSet.Object);

        var data2 = new List<Pass>
            {
                new Pass{ID = 1, Purchaser = "Max", Premium = true, Capacity = 20},
                new Pass{ID = 2, Purchaser = "Ludwig", Premium = false, Capacity  =15},
                new Pass{ID = 3, Purchaser = "Chad", Premium = true, Capacity = 5},
                new Pass{ID = 4, Purchaser = "Steven", Premium = false, Capacity = 10},
                new Pass{ID = 5, Purchaser = "Mike", Premium = false, Capacity = 100}
            }.AsQueryable();

        var mockDbSet = new Mock<DbSet<Pass>>();

        mockDbSet.As<IQueryable<Pass>>().Setup(m => m.Provider).Returns(data.Provider);
        mockDbSet.As<IQueryable<Pass>>().Setup(m => m.Expression).Returns(data.Expression);
        mockDbSet.As<IQueryable<Pass>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockDbSet.As<IQueryable<Pass>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

        var mockContext = new Mock<Unit_Testing_in_.Net_SD_125_W22SD_Lab2_And_Lab3_Unit_TestsContext>();
        mockContext.Setup(c => c.Pass).Returns(mockDbSet.Object);

        var data3 = new List<ParkingSpot>
            {
                new ParkingSpot{ID = 1, Occupied = true},
                new ParkingSpot{ID = 2, Occupied = false},
                new ParkingSpot{ID = 3, Occupied = true},
                new ParkingSpot{ID = 4, Occupied = false}
                new ParkingSpot{ID = 5, Occupied = false}
            }.AsQueryable();

        var mockDbSet = new Mock<DbSet<ParkingSpot>>();

        mockDbSet.As<IQueryable<ParkingSpot>>().Setup(m => m.Provider).Returns(data.Provider);
        mockDbSet.As<IQueryable<ParkingSpot>>().Setup(m => m.Expression).Returns(data.Expression);
        mockDbSet.As<IQueryable<ParkingSpot>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockDbSet.As<IQueryable<ParkingSpot>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

        var mockContext = new Mock<Unit_Testing_in_.Net_SD_125_W22SD_Lab2_And_Lab3_Unit_TestsContext>();
        mockContext.Setup(c => c.ParkingSpot).Returns(mockDbSet.Object);

        var data4 = new List<Reservation>
            {
                new Reservation{ID = 1, ParkingSpotID = 1, VehicleID = 1, VehicleID = new DateTime(2022, 12, 21), IsCurrent = true},
                new Reservation{ID = 2, ParkingSpotID = 2, VehicleID = 2, VehicleID = new DateTime(2022, 11, 11), IsCurrent = false},
                new Reservation{ID = 3, ParkingSpotID = 3, VehicleID = 3, VehicleID = new DateTime(2022, 1, 2), IsCurrent = true},
                new Reservation{ID = 4, ParkingSpotID = 4, VehicleID = 4, VehicleID = new DateTime(2022, 2, 5), IsCurrent = false}
                new Reservation{ID = 5, ParkingSpotID = 5, VehicleID = 5, VehicleID = new DateTime(2021, 4, 6), IsCurrent = false}
            }.AsQueryable();

        var mockDbSet = new Mock<DbSet<Reservation>>();

        mockDbSet.As<IQueryable<Reservation>>().Setup(m => m.Provider).Returns(data.Provider);
        mockDbSet.As<IQueryable<Reservation>>().Setup(m => m.Expression).Returns(data.Expression);
        mockDbSet.As<IQueryable<Reservation>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockDbSet.As<IQueryable<Reservation>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

        var mockContext = new Mock<Unit_Testing_in_.Net_SD_125_W22SD_Lab2_And_Lab3_Unit_TestsContext>();
        mockContext.Setup(c => c.Reservation).Returns(mockDbSet.Object);
    }

   [TestMethod]
    public void CreatePass_ValidInput_CreatesAPass()
    {
        ParkingHelper parkingHelperTest = new ParkingHelper();
        Pass passTest = parkingHelperTest.CreatePass("Max", true, 20);

        Assert.AreEqual(passTest, data1[1]);
    }

    [TestMethod]
    public void CreatePass_InValidInput_CreatesAPass()
    {
        ParkingHelper parkingHelperTest = new ParkingHelper();

        Assert.ThrowsException<KeyNotFoundException>(() => parkingHelperTest.CreatePass("A", true, 20));
    }

    [TestMethod]
    public void CreateParkingSpot_ValidInput_CreatesAPass()
    {
        ParkingHelper parkingHelperTest = new ParkingHelper();
        ParkingSpot ParkingSpotTest = parkingHelperTest.CreateParkingSpot();

        Assert.AreEqual(ParkingSpotTest, data3[2]);
    }
}