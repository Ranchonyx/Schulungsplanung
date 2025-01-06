using Schulungsplanung;

Console.WriteLine("---- Schulungsplanung ----");
Console.WriteLine(Directory.GetCurrentDirectory());
var fSer = new Serializer("./schulungsplanung.xml");

TrainingCompany company = null;

if (fSer.CanDeserialize())
{
    Console.WriteLine("Deserialisiere Instanz aus Datendatei...");
    company = fSer.Deserialize<TrainingCompany>();
}
else
{
    Console.WriteLine("Generiere neue Instanz...");
    company = new TrainingCompany();
}

void Cleanup()
{
    Console.WriteLine("Schreibe Datendatei...");
    fSer.Serialize(company);
}

Console.CancelKeyPress += delegate
{
    Cleanup();
};

DataRegistry.Initialise(company.Participants, company.Employees, company.EmployedTeachers, company.OfferedCourses);
while (company.Edit())
{
    //Console.Clear();
}

Cleanup();