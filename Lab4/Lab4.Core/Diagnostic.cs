using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator2
{
    //Используем тернарный оператор: если IsCompDiagnostics равно true, умножаем на 1.5 просто доп. работы
    public class DiagnosticJob : RepairJob
    {
        public bool IsCompDiagnostics { get; }
        public DiagnosticJob(string clientName, double normHours, double hourRate, bool isCompDiagnostics)
            : base(clientName, normHours, hourRate)
        {
            IsCompDiagnostics = isCompDiagnostics;
        }
        public override string JobType => "Диагностика";
        public override double CalculateCost() =>
            base.CalculateCost() * (IsCompDiagnostics ? 1.5 : 1.0);
    }
}