Console.WriteLine("Введите n от 0 до 20:");
if (!int.TryParse(Console.ReadLine(),out int n)||n<0||n>20)
{
    Console.WriteLine("Ошибка: Введите ЦЕЛОЕ число от ");
    return;
}
Console.WriteLine($"{n}!={Factorial(n)}");
static long Factorial(int n)
{
    long result = 1;
    for(int i=2;i<=n;i++)
        result *= i;
        return result;
    
}
int result1 = 0;
int result2 = 1;
Console.WriteLine("Введите последовательность:");
if (!int.TryParse(Console.ReadLine(), out int numbers))
{
    Console.WriteLine($"Вы ввели: {numbers}");
}
for (int i=0;i<=numbers;i++)
{
    int result3 = result1 + result2;
    result1 = result2;
    result2 = result3;

    Console.WriteLine($"{result3}");
}
Console.WriteLine($"Итог последовательности Фибоначчи приведён выше с колчиепство шагов равным:{numbers}");