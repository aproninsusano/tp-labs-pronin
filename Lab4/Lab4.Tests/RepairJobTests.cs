using Lab4.Core;
using System;
namespace Laborator2
{
    public class RepairJobTests
    {
        [Fact]
        public void MaintenanceJob_CalculatesCostCorrectly()
        {
            var job = new MaintenanceJob("Иванов", 2.0, 1500, 10000);
            Assert.Equal(3000, job.CalculateCost());
        }

        [Fact]
        public void RepairJob_EmptyClientName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new MaintenanceJob("", 2.0, 1500, 10000));
        }

        [Fact]
        public void BodyRepairJob_CalculatesCostWithMarkup()
        {
            var job = new BodyRepairJob("Петров", 5.0, 2000, 2);
            Assert.Equal(16000, job.CalculateCost());
        }
    }
}