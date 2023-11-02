using System;
using System.Collections.Generic;

class Employee
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Department { get; set; }
}

class Program
{
    // Eine Liste, um Mitarbeiterdaten zu speichern
    static List<Employee> employees = new List<Employee>();
    // Eine Variable, um die nächste verfügbare Mitarbeiter-ID zu verfolgen
    static int nextId = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            // Menüanzeige
            Console.WriteLine("Mitarbeiterregistrierungs-Anwendung");
            Console.WriteLine("1. Mitarbeiter anzeigen");
            Console.WriteLine("2. Mitarbeiter registrieren");
            Console.WriteLine("3. Mitarbeiter aktualisieren");
            Console.WriteLine("4. Mitarbeiter löschen");
            Console.WriteLine("5. Beenden");
            Console.Write("Bitte wählen Sie eine Option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Anzeige der Mitarbeiterdaten
                    DisplayEmployees();
                    break;
                case 2:
                    // Registrierung eines neuen Mitarbeiters
                    RegisterEmployee();
                    break;
                case 3:
                    // Aktualisierung eines bestehenden Mitarbeiters
                    UpdateEmployee();
                    break;
                case 4:
                    // Löschen eines Mitarbeiters
                    DeleteEmployee();
                    break;
                case 5:
                    // Beenden der Anwendung
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie eine gültige Option.");
                    break;
            }
            Console.WriteLine(); // Leere Zeile hinzufügen
        }
    }

    static void DisplayEmployees()
    {
        // Anzeige der Mitarbeiterdaten
        Console.WriteLine("Mitarbeiterliste:");
        Console.WriteLine("ID\tName\tVorname\tAbteilung");

        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.Id}\t{employee.LastName}\t{employee.FirstName}\t{employee.Department}");
        }
        Console.WriteLine(); // Leere Zeile hinzufügen
    }

    static void RegisterEmployee()
    {
        // Registrierung eines neuen Mitarbeiters
        Employee employee = new Employee
        {
            Id = nextId++,
            LastName = GetInput("Nachname: "),
            FirstName = GetInput("Vorname: "),
            Address = GetInput("Adresse: "),
            PostalCode = GetInput("PLZ: "),
            City = GetInput("Wohnort: "),
            PhoneNumber = GetInput("Telefonnummer: "),
            Email = GetInput("Email: "),
            Department = GetInput("Abteilung: ")
        };

        employees.Add(employee);
        Console.WriteLine("Mitarbeiter wurde registriert.");
        Console.WriteLine(); // Leere Zeile hinzufügen
    }

    static void UpdateEmployee()
    {
        // Aktualisierung eines bestehenden Mitarbeiters
        Console.Write("Geben Sie die ID des Mitarbeiters ein, den Sie aktualisieren möchten: ");
        int id = int.Parse(Console.ReadLine());

        Employee employee = employees.Find(e => e.Id == id);
        if (employee == null)
        {
            Console.WriteLine("Mitarbeiter mit dieser ID wurde nicht gefunden.");
            return;
        }

        Console.WriteLine($"Mitarbeiter {employee.LastName}, {employee.FirstName} aktualisieren:");
        employee.LastName = GetInput("Nachname: ");
        employee.FirstName = GetInput("Vorname: ");
        employee.Address = GetInput("Adresse: ");
        employee.PostalCode = GetInput("PLZ: ");
        employee.City = GetInput("Wohnort: ");
        employee.PhoneNumber = GetInput("Telefonnummer: ");
        employee.Email = GetInput("Email: ");
        employee.Department = GetInput("Abteilung: ");

        Console.WriteLine("Mitarbeiter wurde aktualisiert.");
        Console.WriteLine(); // Leere Zeile hinzufügen
    }

    static void DeleteEmployee()
    {
        // Löschen eines Mitarbeiters
        Console.Write("Geben Sie die ID des Mitarbeiters ein, den Sie löschen möchten: ");
        int id = int.Parse(Console.ReadLine());

        Employee employee = employees.Find(e => e.Id == id);
        if (employee == null)
        {
            Console.WriteLine("Mitarbeiter mit dieser ID wurde nicht gefunden.");
            return;
        }

        employees.Remove(employee);
        Console.WriteLine("Mitarbeiter wurde gelöscht.");
        Console.WriteLine(); // Leere Zeile hinzufügen
    }

    static string GetInput(string prompt)
    {
        // Eingabeaufforderung und Eingabeaufforderung
        Console.Write(prompt);
        return Console.ReadLine();
    }
}
