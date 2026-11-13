using System;
using System.Collections.Generic;
using System.Text;
namespace Laborator2
{
    public class MaintenanceJob : RepairJob
    {
        //доп.свойство
        public int OilChangeInterval { get; }
        //Конструктор от родителя 
        public MaintenanceJob(string clientName, double normHours, double hourRate, int oilChangeInterval)
            : base(clientName, normHours, hourRate)
        {
            if (oilChangeInterval <= 0)
                throw new ArgumentOutOfRangeException(nameof(oilChangeInterval), "Интервал замены масла должен быть > 0");
            OilChangeInterval = oilChangeInterval;
        }
        //абстрактное свойство из родителя
        public override string JobType => "ТО";
        //Переопределяем и добавляем новое свойство
        public override string ToString() =>
            $"{base.ToString()} Интервал замены масла: {OilChangeInterval} км";
    }
}