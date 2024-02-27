
try
{
    Console.WriteLine(" sheiyvanet gamosaxuleba (( ricxvebi da operatori daashoret ertmanets )) :");
    string input = Console.ReadLine();


    string[] elements = input.Split(' ');
    if (elements.Length != 3)
    {
        throw new FormatException(" sheiyvanet gamosaxuleba sworad ( ricxvi moqmedeba ricxvi )");
    }

    double ricxvi1 = double.Parse(elements[0]);
    string moqmedeba = elements[1];
    double ricxvi2 = double.Parse(elements[2]);

    double result = 0;

    switch (moqmedeba)
    {
        case "+":
            result = ricxvi1 + ricxvi2;
            break;
        case "-":
            result = ricxvi1 - ricxvi2;
            break;
        case "*":
            result = ricxvi1 * ricxvi2;
            break;
        case "/":
            if (ricxvi2 == 0)
            {
                throw new DivideByZeroException("nulze gayofa sheudzlebelia.");
            }
            result = ricxvi1 / ricxvi2;
            break;
        default:
            throw new ArgumentException("arasworioperatori! ( +, -, *, /)");
    }

    Console.WriteLine($"shedegi: {result}");
}
catch (FormatException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($" error : {ex.Message}");
}


