List<decimal> typedNumbers = new List<decimal>();
decimal result = 0;
int typedOption = 0;
bool running  = true;

//Si se pregunta porque es diferente al codigo que usted proporciono es que lo hice desde 0 en base a la proporcionada

while (running)
{
    try
    {
        Display();
        typedOption = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine($"You need to choose a correct option: {ex.Message}");
    }
    if (typedOption == 5)
    { 
        running = false;
        Console.WriteLine("Closing program...");
    }
    else
    {
        try
        {
            Console.WriteLine("Please type the first number");
            typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

            Console.WriteLine("Please type the second number");
            typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"You need to choose a correct option: {ex.Message}");
        }
        switch (typedOption)
        {
            case 1:
                {
                    Sum(ref result, typedNumbers);
                    Console.WriteLine($"Result: {result}");
                    break;
                }
            case 2:
                {
                    Sustrac(ref result, typedNumbers);
                    Console.WriteLine($"Result: {result}");
                    break;
                }
            case 3:
                {
                    Multiplication(ref result, typedNumbers);
                    Console.WriteLine($"Result: {result}");
                    break;
                }
            case 4:
                {
                    Divition(ref result, typedNumbers);
                    Console.WriteLine($"Result: {result}");
                    break;
                }
            default:
                {
                    Console.WriteLine("ERROR");
                    break;
                }
        }

        typedNumbers.Clear();
    }
}
static void Display()
{

    Console.WriteLine("--------------------------------");
    Console.WriteLine("Please type the option number.\n 1- Sum.\n 2- Sustrac.\n 3- Multiplication. \n 4- Divition. \n 5- Exit.");
    Console.WriteLine("--------------------------------");
}
static void Sum(ref decimal result, List<decimal> typedNumbers)
{
    result = typedNumbers[0] + typedNumbers[1];
}
static void Sustrac(ref decimal result, List<decimal> typedNumbers)
{
    result = typedNumbers[0] - typedNumbers[1];
}
static void Multiplication(ref decimal result, List<decimal> typedNumbers) 
{ 
    result = typedNumbers[0] * typedNumbers[1];
}
static void Divition(ref decimal result, List<decimal> typedNumbers)
{
    try
    {
        result = typedNumbers[0] / typedNumbers[1];
    }
    catch(DivideByZeroException ex) {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
