using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AudioDocument : MultimediaDocuments
{
    public double SampleRate { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "samplerate")
        {
            this.SampleRate = double.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        base.SaveAllProperties(output);
    }
}

public abstract class BinaryDocument : Document
{
    public long? Size { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "size")
        {
            this.Size = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("size", this.Size));
        base.SaveAllProperties(output);
    }
}

public abstract class Document : IDocument
{
    public string Name { get; protected set; }
    public string Content { get; protected set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        if (key == "content")
        {
            this.Content = value;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(this.GetType().Name);
        sb.Append('[');
        IList<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
        SaveAllProperties(properties);
        var sorted =
                from prop in properties
                orderby prop.Key
                select prop;

        foreach (var item in sorted)
        {

            if (item.Value != null)
            {
                sb.Append(item.Key);
                sb.Append('=');
                sb.Append(item.Value);
                sb.Append(';');
            }

        }
        sb.Length--;
        sb.Append(']');
        return sb.ToString();
    }
}

public abstract class EncryptableDocument : BinaryDocument, IEncryptable
{
    public bool IsEncrypted { get; protected set; }

    public virtual void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public virtual void Decrypt()
    {
        this.IsEncrypted = false;
    }

    public override string ToString()
    {
        if (IsEncrypted == true)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType().Name);
            sb.Append('[');
            sb.Append("encrypted");
            sb.Append(']');
            return sb.ToString();
        }
        else
        {
            return base.ToString();
        }

    }
}

public class ExcelDocument : OfficeDocuments
{
    public long Colls { get; protected set; }
    public long Rows { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "cols")
        {
            this.Colls = long.Parse(value);
        }
        if (key == "rows")
        {
            this.Rows = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("cols", this.Colls));
        output.Add(new KeyValuePair<string, object>("rows", this.Rows));
        base.SaveAllProperties(output);
    }
}

public interface IDocument
{
    string Name { get; }
    string Content { get; }
    void LoadProperty(string key, string value);
    void SaveAllProperties(IList<KeyValuePair<string, object>> output);
    string ToString();
}

public interface IEditable
{
    void ChangeContent(string newContent);
}

public interface IEncryptable
{
    bool IsEncrypted { get; }
    void Encrypt();
    void Decrypt();
}

public abstract class MultimediaDocuments : BinaryDocument
{
    public long? Length { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "length")
        {
            this.Length = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("length", this.Length));
        base.SaveAllProperties(output);
    }
}

public abstract class OfficeDocuments : EncryptableDocument
{
    public string Version { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "version")
        {
            this.Version = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("version", this.Version));
        base.SaveAllProperties(output);
    }
}

public class PDFDocument : EncryptableDocument
{
    public int? Pages { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
        {
            this.Pages = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        base.SaveAllProperties(output);
    }
}

public class TextDocument : Document, IEditable
{
    public string Charset { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "charset")
        {
            this.Charset = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }

    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        base.SaveAllProperties(output);
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
}

public class VideoDocument : MultimediaDocuments
{
    public double? FrameRate { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "framerate")
        {
            this.FrameRate = double.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        base.SaveAllProperties(output);
    }
}

public class WordDocument : OfficeDocuments, IEditable
{
    public long? CharacterCount { get; protected set; }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
        {
            this.CharacterCount = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("chars", this.CharacterCount));
        base.SaveAllProperties(output);
    }
}

class DocumentSystem
{
    private static IList<IDocument> documents = new List<IDocument>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        TextDocument doc = new TextDocument();
        AddDocument(attributes, doc);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        PDFDocument doc = new PDFDocument();
        AddDocument(attributes, doc);
    }

    private static void AddWordDocument(string[] attributes)
    {
        WordDocument doc = new WordDocument();
        AddDocument(attributes, doc);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        ExcelDocument doc = new ExcelDocument();
        AddDocument(attributes, doc);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AudioDocument doc = new AudioDocument();
        AddDocument(attributes, doc);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        VideoDocument doc = new VideoDocument();
        AddDocument(attributes, doc);
    }

    private static void AddDocument(string[] attributes, IDocument doc)
    {
        bool isDocument = false;
        var properties = new List<KeyValuePair<string, object>>();
        foreach (var item in attributes)
        {
            string[] attribs = item.Split('=');
            doc.LoadProperty(attribs[0], attribs[1]);
            if (attribs[0] == "name")
            {
                isDocument = true;
            }
        }
        if (isDocument)
        {
            documents.Add(doc);
            Console.WriteLine("Document added: " + doc.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void ListDocuments()
    {
        if (documents.Count == 0)
        {
            Console.WriteLine("No documents found");
        }
        foreach (var item in documents)
        {
            Console.WriteLine(item);
        }
    }

    private static void EncryptDocument(string name)
    {
        bool docFound = false;
        foreach (var item in documents)
        {
            if (item.Name == name)
            {
                if (item is IEncryptable)
                {
                    ((IEncryptable)item).Encrypt();
                    Console.WriteLine("Document encrypted: " + item.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: " + item.Name);
                }
                docFound = true;
            }
        }
        if (docFound == false)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool haveDecription = false;
        foreach (var item in documents)
        {
            if (item.Name == name)
            {
                if (item is IEncryptable)
                {
                    ((IEncryptable)item).Decrypt();
                    Console.WriteLine("Document decrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + item.Name);
                }
                haveDecription = true;
            }
        }
        if (!haveDecription)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool haveEcnryption = false;
        foreach (var item in documents)
        {
            if (item is IEncryptable)
            {
                ((IEncryptable)item).Encrypt();
                haveEcnryption = true;
            }
        }
        if (haveEcnryption == false)
        {
            Console.WriteLine("No encryptable documents found");
        }
        else
        {
            Console.WriteLine("All documents encrypted");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool docFound = false;
        foreach (var item in documents)
        {
            if (item.Name == name)
            {
                if (item is IEditable)
                {
                    ((IEditable)item).ChangeContent(content);
                    Console.WriteLine("Document content changed: " + name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + item.Name);
                }
                docFound = true;
            }
        }

        if (docFound == false)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }
}
