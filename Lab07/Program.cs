using System.Reflection;
using Lab07.Problem_1_2._Define_an_Interface_IPerson___Multiple_Implementation.Interfaces;
using Lab07.Problem_1_2._Define_an_Interface_IPerson___Multiple_Implementation.Models;
using Lab07.Problem_3._Ferrari.Interfaces;
using Lab07.Problem_3._Ferrari.Models;
using Lab07.Problem_4._Telephony.Models;
using Lab07.Problem_5_6._Border_Control___Birthday_Celebrations.Models;
using Lab07.Problem_7._Food_Shortage.Interfaces;
using Lab07.Problem_7._Food_Shortage.Models;
using Lab07.Problem_8._Military_Elite.Interfaces;
using Lab07.Problem_8._Military_Elite.Models;

var loopBreak = true;
while (loopBreak)
{
    Console.WriteLine("Select the problem(1-8) or exit(0):");

    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            Problem1_2();
            break;
        case 2:
            Problem1_2();
            break;
        case 3:
            Problem3();
            break;
        case 4:
            Problem4();
            break;
        case 5:
            Problem5_6();
            break;
        case 6:
            Problem5_6();
            break;
        case 7:
            Problem7();
            break;
        case 8:
            Problem8();
            break;
        default:
            Console.WriteLine("Exiting the Lab 7...");
            loopBreak = false;
            break;
    }

    if (!loopBreak) break;
}

// Problem 1 & 2
void Problem1_2()
{
    Console.WriteLine("Problem 1 & 2");

    Type identifiableInterface = typeof(Citizen).GetInterface("IIdentifiable");
    Type birthableInterface = typeof(Citizen).GetInterface("IBirthable");
    PropertyInfo[] properties = identifiableInterface.GetProperties();
    Console.WriteLine(properties.Length);
    Console.WriteLine(properties[0].PropertyType.Name);
    properties = birthableInterface.GetProperties();
    Console.WriteLine(properties.Length);
    Console.WriteLine(properties[0].PropertyType.Name);

    Console.WriteLine("Name: ");
    var name = Console.ReadLine();

    Console.WriteLine("Age: ");
    var age = int.Parse(Console.ReadLine());

    Console.WriteLine("Id: ");
    var id = Console.ReadLine();

    Console.WriteLine("Birthday: ");
    var birthdate = Console.ReadLine();

    IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
    IBirthable birthable = new Citizen(name, age, id, birthdate);
    Console.WriteLine(identifiable.Id);
    Console.WriteLine(birthable.Birthdate);
}

// Problem 3
void Problem3()
{
    Console.WriteLine("Problem 3");

    string ferrariName = typeof(Ferrari).Name;
    string iCarInterfaceName = typeof(ICar).Name;

    bool isCreated = typeof(ICar).IsInterface;
    if (!isCreated)
    {
        throw new Exception("No interface ICar was created");
    }

    Console.WriteLine("Driver name: ");
    var driverName = Console.ReadLine();
    ICar car = new Ferrari(driverName);
    Console.WriteLine(car);
}

// Problem 4
void Problem4()
{
    Console.WriteLine("Problem 4");

    Console.WriteLine("Input numbers:");
    var numbers = Console.ReadLine().Split();

    Console.WriteLine("Input urls:");
    var urls = Console.ReadLine().Split();

    var phone = new Smartphone();
    foreach (var number in numbers)
    {
        Console.WriteLine(phone.Calling(number));
    }

    foreach (var url in urls)
    {
        Console.WriteLine(phone.Browsing(url));
    }
}

// Problem 5 & 6
void Problem5_6()
{
    Console.WriteLine("Problem 5 & 6");

    var citizens = new List<CitizenProblem5>();
    var pets = new List<Pet>();

    Console.WriteLine("Input lines of information for each citizen until you will input \"END\" command");
    var inputLine = Console.ReadLine();
    while (!inputLine.Equals("End"))
    {
        var tokens = inputLine.Split();
        if (tokens[0].Equals("Citizen"))
        {
            citizens.Add(new CitizenProblem5(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
        }
        else if (tokens[0].Equals("Pet"))
        {
            pets.Add(new Pet(tokens[1], tokens[2]));
        }

        inputLine = Console.ReadLine();
    }

    var year = Console.ReadLine();
    var dates = citizens
        .Where(x => x.Birthdate.EndsWith(year))
        .Select(x => x.Birthdate)
        .ToList()
        .Concat(pets.Where(x => x.Birthdate.EndsWith(year))
            .Select(x => x.Birthdate)
            .ToList());

    Console.WriteLine(string.Join(Environment.NewLine, dates));
}

// Problem 7
void Problem7()
{
    Console.WriteLine("Problem 7");

    IList<IPersonProblem7> people = new List<IPersonProblem7>();

    var numberOfLines = int.Parse(Console.ReadLine());
    for (int i = 0; i < numberOfLines; i++)
    {
        var inputLine = Console.ReadLine();
        people.Add(CreatePerson(inputLine));
    }

    var name = Console.ReadLine();
    while (!name.Equals("End"))
    {
        AddFood(name, people);
        name = Console.ReadLine();
    }

    Console.WriteLine(people.Sum(x => x.Food));
}

// Problem 8
void Problem8()
{
    Console.WriteLine("Problem 8");

//60/100
    List<ISoldier> soldiers = new List<ISoldier>();

    var inputLine = Console.ReadLine();
    while (!inputLine.Equals("End"))
    {
        ParseDate(inputLine, ref soldiers);
        inputLine = Console.ReadLine();
    }

    foreach (var soldier in soldiers)
    {
        Console.WriteLine(soldier);
    }
}

#region Problem 8 Helper methods

void ParseDate(string inputLine, ref List<ISoldier> soldiers)
{
    var tokens = inputLine.Split();
    if (tokens[0].Equals("Private"))
    {
        var @private = new Private(tokens[1], tokens[2], tokens[3], double.Parse(tokens[4]));
        soldiers.Add(@private);
        return;
    }

    if (tokens[0].Equals("LeutenantGeneral"))
    {
        var leutenantGeneral = new LeutenantGeneral(tokens[1], tokens[2], tokens[3], double.Parse(tokens[4]));
        var privateIds = tokens.Skip(5);
        var privates = GetPrivates(privateIds, soldiers);
        privates.ForEach(x => leutenantGeneral.Privates.Add(x));
        soldiers.Add(leutenantGeneral);
        return;
    }

    if (tokens[0].Equals("Engineer"))
    {
        var engineer = new Engineer(tokens[1], tokens[2], tokens[3], double.Parse(tokens[4]), tokens[5]);
        var restOfTokens = tokens.Skip(6).ToList();
        var repairs = TakeRepairs(restOfTokens);
        foreach (var repair in repairs)
        {
            engineer.Repairs.Add(repair);
        }

        soldiers.Add(engineer);
        return;
    }

    if (tokens[0].Equals("Commando"))
    {
        if (tokens[5] != "Airforces" && tokens[5] != "Marines")
        {
            return;
        }

        var comando = new Commando(tokens[1], tokens[2], tokens[3], double.Parse(tokens[4]), tokens[5]);
        var restOfTokens = tokens.Skip(6).ToList();
        var missions = TakeMission(restOfTokens);
        foreach (var mission in missions)
        {
            comando.Missions.Add(mission);
        }

        soldiers.Add(comando);
        return;
    }

    soldiers.Add(new Spy(tokens[1], tokens[2], tokens[3], int.Parse(tokens[4])));
}

IList<IMission> TakeMission(List<string> restOfTokens)
{
    var allMissions = new List<IMission>();
    for (int i = 0; i < restOfTokens.Count() - 1; i += 2)
    {
        var code = restOfTokens[i];
        var state = restOfTokens[i + 1];

        if (state != "inProgress" && state != "Finished") continue;

        allMissions.Add(new Mission(code, state));
    }

    return allMissions;
}

IList<IRepair> TakeRepairs(IList<string> restOfTokens)
{
    var allRepairs = new List<IRepair>();
    for (int i = 0; i < restOfTokens.Count() - 1; i += 2)
    {
        var part = restOfTokens[i];
        var hour = int.Parse(restOfTokens[i + 1]);
        allRepairs.Add(new Repair(part, hour));
    }

    return allRepairs;
}

List<IPrivate> GetPrivates(IEnumerable<string> privateIds, List<ISoldier> allPrivates)
{
    var list = new List<IPrivate>();
    foreach (var id in privateIds)
    {
        if (allPrivates.Any(x => x.Id == id))
        {
            list.Add((IPrivate)allPrivates.First(x => x.Id == id));
        }
    }

    return list;
}

#endregion

#region Problem 7 Helper methods

static void AddFood(string name, IList<IPersonProblem7> people)
{
    if (people.Any(p => p.Name == name))
    {
        people.First(x => x.Name == name).BuyFood();
    }
}

static IPersonProblem7 CreatePerson(string inputLine)
{
    var tokens = inputLine.Split();

    if (tokens.Length == 3)
    {
        return new CitizenProblem7(tokens[0], int.Parse(tokens[1]), tokens[2]);
    }

    return new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
}

#endregion