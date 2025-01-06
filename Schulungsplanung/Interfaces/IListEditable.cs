namespace Schulungsplanung.Interfaces;

public interface IListEditable<T>
{
    public void EditContents(List<T> selection);
}