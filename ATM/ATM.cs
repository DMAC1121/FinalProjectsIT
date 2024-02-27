

using System;
using System.IO;

class ATM
{
    static void Main(string[] args)
    {
        string filePath = "C:\\Users\\User\\Desktop\\5555\\users.txt";     // sawiroa misamrti failis sadac aris momxmareblis monacemebi


        if (!File.Exists(filePath))
        {
            Console.WriteLine(" faili ar arsebobs ! ");

        }
        else
        {
            Console.WriteLine("tanxa sheiyvanet decimal tipis monacemad (mag: 100,40 ; 122,00 ...)");
            while (true)
            {
                Console.WriteLine("1. balansis shemowmeba");
                Console.WriteLine("2. tanxis shetana");
                Console.WriteLine("3. tanxis gamotana");
                Console.WriteLine("4. dasruleba");
                Console.Write("airchiet operacia: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CheckBalance(filePath);
                        break;
                    case "2":
                        DepositMoney(filePath);
                        break;
                    case "3":
                        WithdrawMoney(filePath);
                        break;
                    case "4":
                        Console.WriteLine("sabanko operacia dasrulebulia.");
                        return;
                    default:
                        Console.WriteLine("miutitet operacia sworad.");
                        break;
                }
            }
        }
    }

    static void CheckBalance(string filePath)
    {
        Console.Write("momxmareblis saxeli (username) ");
        string username = Console.ReadLine();

        Console.Write("momxmareblis ID: ");
       
        if (!int.TryParse(Console.ReadLine(), out int userId))
        {
            Console.WriteLine("sheiyvanet Id sworad! ");            
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] userAccount = line.Split(';');
            if (userAccount[0] == username && int.Parse(userAccount[1]) == userId)
            {
                Console.WriteLine($"tqveni balansi aris {userAccount[2]}");
                return;
            }
        }

        Console.WriteLine("momxmarebeli ver moidzebna.");
    }

    static void DepositMoney(string filePath)
    {
        Console.Write("momxmareblis saxeli (username): ");
        string username = Console.ReadLine();

        Console.Write("momxmareblis ID:");
        int userId = int.Parse(Console.ReadLine());

        Console.Write("shesatani tanxis odenoba: ");
        decimal depositAmount = decimal.Parse(Console.ReadLine());

        string[] lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] userAccount = lines[i].Split(';');
            if (userAccount[0] == username && int.Parse(userAccount[1]) == userId)
            {
                decimal currentBalance = decimal.Parse(userAccount[2]);
                currentBalance += depositAmount;
                userAccount[2] = currentBalance.ToString();

                lines[i] = string.Join(";", userAccount);
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("warmatebit moxda tanxis shetana");
                return;
            }
        }

        Console.WriteLine("momxmarebeli ver moidzebna");
    }

    static void WithdrawMoney(string filePath)
    {
        Console.Write("momxmareblis saxeli (username): ");
        string username = Console.ReadLine();

        Console.Write("momxmareblis ID: ");
        int userId = int.Parse(Console.ReadLine());

        Console.Write("gamosatani tanxis odenoba: ");
        decimal withdrawAmount = decimal.Parse(Console.ReadLine());

        string[] lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] userAccount = lines[i].Split(';');
            if (userAccount[0] == username && int.Parse(userAccount[1]) == userId)
            {
                decimal currentBalance = decimal.Parse(userAccount[2]);
                if (currentBalance < withdrawAmount)
                {
                    Console.WriteLine("arasakmarisi tanxa angarishze! ");
                    return;
                }

                currentBalance -= withdrawAmount;
                userAccount[2] = currentBalance.ToString();

                lines[i] = string.Join(";", userAccount);
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("warmatebit moxda tanxis gamotana");
                return;
            }
        }

        Console.WriteLine("momxmarebeli ver moidzebna");
    }
}







