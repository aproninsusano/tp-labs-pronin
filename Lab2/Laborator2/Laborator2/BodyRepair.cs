using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator2
{
    //Здесь сделаю добавлю ремонт и переопределю стоимость по новым деталям для ремонта,ничего тут сложного нет
    public class BodyRepairJob : RepairJob
    {
        public int DamagedPartsCount { get; }

        public BodyRepairJob(string clientName, double normHours, double hourRate, int damagedPartsCount)
            : base(clientName, normHours, hourRate)
        {
            if (damagedPartsCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(damagedPartsCount), "Количество деталей должно быть > 0");
            DamagedPartsCount = damagedPartsCount;
        }

        public override string JobType => "Кузовной ремонт";
        public override double CalculateCost() =>
            base.CalculateCost() * (1 + 0.3 * DamagedPartsCount);
    }
}
