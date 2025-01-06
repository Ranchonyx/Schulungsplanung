using System.Xml.Serialization;

namespace Schulungsplanung;

public class Serializer
{
    private string _filePath;

    public Serializer(string pFilePath)
    {
        this._filePath = pFilePath;
    }

    public void Serialize<T>(T? obj) where T : new()
    {
        TextWriter writer = null;
        try
        {
            XmlSerializer ser = new(typeof(T));
            writer = new StreamWriter(_filePath, false);
            ser.Serialize(writer, obj);
        }
        finally
        {
            if (writer != null)
                writer.Close();
        }
    }

    public T Deserialize<T>() where T : new()
    {
        TextReader reader = null;
        try
        {
            XmlSerializer ser = new(typeof(T));
            reader = new StreamReader(_filePath);
            return (T)ser.Deserialize(reader);
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }

    public bool CanDeserialize()
    {
        return File.Exists(_filePath);
    }
}