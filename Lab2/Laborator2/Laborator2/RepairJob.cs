using System;

namespace Lab2
{
    public abstract class RepairJob : IComparable<RepairJob>
    {
// Задаём переменыне для будущей работы и последующего переорпеделения по небходимости
        private string _clientName;
        private double _normHours;
        private double _hourRate;

        public string ClientName => _clientName;
        public double NormHours => _normHours;
        public double HourRate => _hourRate;
        // Проверки защищают объект от некорректного состояния (нужны по условию задания)
        protected RepairJob(string clientName, double normHours, double hourRate)
        {
            if (string.IsNullOrWhiteSpace(clientName))
                throw new ArgumentException("Имя клиента не может быть пустым", nameof(clientName));
            if (normHours <= 0)
                throw new ArgumentOutOfRangeException(nameof(normHours), "Нормо-часы работы должны быть более > 0");
            if (hourRate <= 0)
                throw new ArgumentOutOfRangeException(nameof(hourRate), "Ставка должна быть > 0");

            _clientName = clientName;
            _normHours = normHours;
            _hourRate = hourRate;
        }
        // Считаем стоимость работ путём перемножения время × ставка
        public virtual double CalculateCost() => _normHours * _hourRate;
        //Абстрактное свойство
        public abstract string JobType { get; }
        //выводим в терминал 
        public override string ToString() =>
            $"{JobType} | Клиент: {ClientName} | Нормо-часы: {NormHours:F1} | Стоимость: {CalculateCost():F2} руб.";
        //реализация будущего интерфейса
        public int CompareTo(RepairJob? other)
        {
            if (other == null) return 1;
            return CalculateCost().CompareTo(other.CalculateCost());
        }
    }
}