namespace Schulungsplanung.Properties;

using Interfaces;

public class ListProperty<T> : BaseProperty<List<T>>, IListEditable<T>, IListPrintable
    where T : IEditable, IConsoleCreatable<T>
{
    public ListProperty() : base()
    {
    }

    public ListProperty(string pName, List<T> pValue) : base(pName, pValue)
    {
    }

    public static ListProperty<T> From(string pName, List<T> pValue)
    {
        return new ListProperty<T>(pName, pValue);
    }

    public void PrintList()
    {
        for (int i = 0; i < Value.Count; i++)
        {
            T element = Value.ElementAt(i);
            Console.Write($"{i}:\t");
            Console.WriteLine(element);
        }
    }

    public void EditContents(List<T> selection)
    {
        Console.Clear();
        Console.WriteLine("Inhalte:");
        PrintList();

        /*
        int choice = Util.Choice("Hinzufügen", "Entfernen", "Abbrechen", "Inhalt hinzufügen oder entfernen?");

        switch (choice)
        {
            case 0:
                //Add record from selection to this.Value
                Console.WriteLine($"Wählen Sie einen Datensatz aus.");
                Util.PrintList(selection);

                var selectResult = Util.SafeToInt(Console.ReadLine());
                var maybeIndex = selectResult.Item1;

                //Falls selection außerhalb der Länge der Liste liegt, den Nutzer abbrechen oder neu anfangen lassen...
                if (maybeIndex == null || maybeIndex.Value > Value.Count)
                {
                    Console.WriteLine("Ungültige Eingabe!");
                    bool quit = !Util.Ask("Weiter bearbeiten? [Y/N]");
                    if (quit)
                        return;
                    EditContents(selection);
                }

                int index = maybeIndex!.Value;
                T selected = selection.ElementAt(index);

                Value.Add(selected);
                Console.WriteLine("Eintrag hinzugefügt.");
                break;
            case 1:
                //Eintrag aus this.Value löschen
                Console.WriteLine($"Wählen Sie einen Datensatz aus.");
                PrintList();




                break;
            case 2:
            default:
                return;
        }
        */


        Console.WriteLine("Bitte Datensatz auswählen...");
        var selectResult = Util.SafeToInt(Console.ReadLine());
        Console.WriteLine($"selected {selectResult.Item1}, length {Value.Count}");
        if (selectResult.Item1!.Value > Value.Count || Value.Count == 0)
        {
            Console.WriteLine($"Eintrag aus Daten hinzufügen:");
            Console.WriteLine("Tippen Sie eine Zahl ein, um den Datensatz hinzuzufügen...");
            for (int i = 0; i < selection.Count; i++)
            {
                var p = selection.ElementAt(i);
                Console.WriteLine($"{i}: {p}");
            }

            var insertSelectionResult = Util.SafeToInt(Console.ReadLine());
            T selected = selection.ElementAt(insertSelectionResult.Item1!.Value);
            Value.Add(selected);
            return;
        }

        if (selectResult.Item2)
            EditContents(selection);

        var prop = Value.ElementAt(selectResult.Item1!.Value);

        var deleteOrEditChoice =
            Util.Choice("Löschen", "Bearbeiten", "Abbrechen", "Datensatz löschen oder bearbeiten?");

        switch (deleteOrEditChoice)
        {
            case 0:
                Value.Remove(prop);
                Console.WriteLine("Eintrag gelöscht.");
                break;
            case 1:
                prop.Edit();
                break;
            case 2:
            case -1:
                break;
        }

        var continueOrStopResult = Util.YesNoCancel("Möchten Sie weitere Datensätze bearbeiten?");
        if (continueOrStopResult == YNCResult.Yes)
            EditContents(selection);
        else
            return;
    }
}