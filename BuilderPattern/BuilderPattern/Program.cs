using BuilderPattern;

var persons = new List<Person>();
File.ReadAllLines("persons_with_address.csv").Skip(1).ToList().ForEach(x =>
{
    var splitted = x.Split(';');
    //Console.WriteLine(splitted[2]);
    try
    {
        persons.Add(new Person.Builder(splitted[0], splitted[1])
        .Age(int.Parse(splitted[2]))
        .Phone(splitted[3])
        .Address(splitted[4])
        .Build());
    }
    catch (InvalidDataException)
    {
        Console.WriteLine($"Invalid Age: {splitted[2]} or Firstname: {splitted[0]}");
    }
    
});
Console.WriteLine(persons.Count);
