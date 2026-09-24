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