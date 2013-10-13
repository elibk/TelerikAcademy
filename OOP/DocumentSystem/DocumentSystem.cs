using System;
using System.Collections.Generic;
using System.Text;

#region Interfaces
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
#endregion

public class DocumentSystem
{
    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    
    //// Data Storage
    private static readonly List<Document> allDocuments = new List<Document>();

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

    #region Commands

    private static void AddTextDocument(string[] attributes)
    {
        
        IList<KeyValuePair<string, object>> properties = AttributesParse(attributes);

        TextDocument newTextDoc = new TextDocument(null);
        newTextDoc.SaveAllProperties(properties);
        AddDoc(newTextDoc);
        
    }

    private static void AddPdfDocument(string[] attributes)
    {
        IList<KeyValuePair<string, object>> properties = AttributesParse(attributes);

        PDFDocument newPdfDoc = new PDFDocument(null);
        newPdfDoc.SaveAllProperties(properties);
        AddDoc(newPdfDoc);
    }

    private static void AddWordDocument(string[] attributes)
    {
        IList<KeyValuePair<string, object>> properties = AttributesParse(attributes);

        WordDocument newWordDoc = new WordDocument(null);
        newWordDoc.SaveAllProperties(properties);
        AddDoc(newWordDoc);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        IList<KeyValuePair<string, object>> properties = AttributesParse(attributes);

        ExcelDocument newExcelDoc = new ExcelDocument(null);
        newExcelDoc.SaveAllProperties(properties);
        AddDoc(newExcelDoc);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        IList<KeyValuePair<string, object>> properties = AttributesParse(attributes);

        AudioDocument newAudioDoc = new AudioDocument(null);
        newAudioDoc.SaveAllProperties(properties);
        AddDoc(newAudioDoc);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        IList<KeyValuePair<string, object>> properties = AttributesParse(attributes);

        VideoDocument newVideoDoc = new VideoDocument(null);
        newVideoDoc.SaveAllProperties(properties);
        AddDoc(newVideoDoc);
    }

    private static void ListDocuments()
    {
        if (allDocuments.Count == 0)
        {
            Console.WriteLine("No documents found");
        }

        foreach (var doc in allDocuments)
        {
            if (doc is IEncryptable)
            {

                if ((doc as IEncryptable).IsEncrypted)
	            {
                    Console.WriteLine(doc);
	            }
                else
                {
                    Console.WriteLine(SortAttributes(doc)); 
                }
                
            }
            else
            {
                Console.WriteLine(SortAttributes(doc)); 
            }

            
        }
    }

   

    private static void EncryptDocument(string name)
    {
        List<Document> matchedDocs = FindDocs(name);

        if (matchedDocs.Count == 0)
        {
            Console.WriteLine("Document not found: " +  name);
        }
        else
        {
            foreach (var doc in matchedDocs)
            {
                if (doc is IEncryptable)
                {
                    (doc as IEncryptable).Encrypt();
                    Console.WriteLine("Document encrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: " + name);
                }
            }
        }

       
    }

    private static void DecryptDocument(string name)
    {
        List<Document> matchedDocs = FindDocs(name);

        if (matchedDocs.Count == 0)
        {
            Console.WriteLine("Document not found: " + name);
        }
        else
        {
            foreach (var doc in matchedDocs)
            {
                if (doc is IEncryptable)
                {
                    (doc as IEncryptable).Decrypt();
                    Console.WriteLine("Document decrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + name);
                }
            }
        }
    }

    private static void EncryptAllDocuments()
    {
       bool notFoundIEncryptable = true;

        foreach (var doc in allDocuments)
        {
            if (doc is IEncryptable)
            {
                (doc as IEncryptable).Encrypt();
                notFoundIEncryptable = false;
            }
        }

        if (notFoundIEncryptable)
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
        List<Document> matchedDocs = FindDocs(name);

        if (matchedDocs.Count == 0)
        {
            Console.WriteLine("Document not found: " + name);
        }
        else
        {
            foreach (var doc in matchedDocs)
            {
                if (doc is IEditable)
                {
                    (doc as IEditable).ChangeContent(content);
                    Console.WriteLine("Document content changed: " + name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + name);
                }
            }
        }
    }
    #endregion

    #region Help_Methods
    private static void AddDoc(Document newDoc)
    {
        if (newDoc.Name == null)
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            allDocuments.Add(newDoc);
            Console.WriteLine("Document added: " + newDoc.Name);
        }
    }

    private static List<Document> FindDocs(string name)
    {
        List<Document> matchedDocs = new List<Document>();
        foreach (var doc in allDocuments)
        {
            if (doc.Name == name)
            {
                matchedDocs.Add(doc);
            }
        }

        return matchedDocs;
    }

    private static List<KeyValuePair<string, object>> AttributesParse(string[] attributes)
    {
        List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
        string[] keyValue = new string[2];
        foreach (var item in attributes)
        {
            keyValue = item.Split('=');
            properties.Add(new KeyValuePair<string, object>(keyValue[0], (Object)keyValue[1]));
        }

        return properties;
    }

    private static string SortAttributes(Document doc)
    {
        //Sort attributes lexicograficly
        int attributesStart = doc.ToString().IndexOf('[') + 1;
        int lenght = (doc.ToString().Length - attributesStart) - 2;

        string array = doc.ToString().Substring(attributesStart, lenght).Trim();
        string[] splited = array.Split(new char[] { '[', ';', ']' });
        Array.Sort(splited);
        return doc.GetType().Name + '[' + String.Join(";", splited) + ']';
    }
    #endregion
}

#region AbstractTypesOfDocuments

public abstract class Document : IDocument
{
    #region Fields
    string name;
    string content;
    #endregion

    #region Constructor
    public Document(string name, string content = null)
    {
        this.Name = name;
        this.Content = content;
    }
    #endregion

    #region Properties
    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public string Content
    {
        get { return this.content; }
        protected set { this.content = value; }
    }
    #endregion

    #region Override_Methods_IDocument
    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        else if (key == "content")
        {
            this.Content = value;
        }
        else
        {
            throw new ArgumentException("Invalid key for property of document!"+ key);
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            if (property.Key == "name")
            {
                this.Name = property.Value.ToString();
            }
            else if (property.Key == "content")
            {
                this.Content = property.Value.ToString();
            }
        }
    }
    #endregion

    #region Override_official_Methods
    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.Append(this.GetType().Name);
        info.Append('[');
        info.Append("name=");
        info.Append(this.Name);
        info.Append(';');
        if (this.Content != null)
        {
            info.Append("content=");
            info.Append(this.content);
            info.Append(';');
        
        }

        return info.ToString();
    }
    #endregion
}

public abstract class BinaryDocument : Document
{
    #region Fields
    string size;
    #endregion

    #region Constructor
    public BinaryDocument(string name, string content = null, string size = null)
        : base(name, content)
    {
        this.Size = size;
    }
    #endregion

    #region Properties
    public string Size
    {
        get
        {
            return this.size;
        }
        set
        {
            this.size = value;
        }
    }
    #endregion

    #region Override_Methods_IDocument
    public override void LoadProperty(string key, string value)
    {
        if (key == "size")
        {
            this.Size = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
       
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            if (property.Key == "size")
            {
                this.Size = property.Value.ToString();
            }
        }

        base.SaveAllProperties(output);
    }
    #endregion

    #region Override_official_Methods
    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        if (this.Size != null)
        {
            info.Append("size=");
            info.Append(this.Size); 
            info.Append(';');
        }

        return base.ToString() + info.ToString();
    }
    #endregion
}

public abstract class OfficeDocument : BinaryDocument
{
    #region Fields
    private string version;
    #endregion

    #region Constructor
    public OfficeDocument(string name, string content = null, string size = null, string version = null)
        : base(name, content, size)
    {
        this.Version = version;
    }
    #endregion

    #region Properties
    public string Version
    {
        get
        {
            return this.version;
        }
       protected set
        {
            this.version = value;
        }
    }
    #endregion

    #region Override_Methods_IDocument
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
        foreach (var property in output)
        {
            if (property.Key == "version")
            {
                this.Version = property.Value.ToString();
                break;
            }
        }

        base.SaveAllProperties(output);
    }
    #endregion

    #region Override_official_Methods
    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        if (this.Version != null)
        {
            info.Append("version=");
            info.Append(this.Version);
            info.Append(';');
        }

        return base.ToString() + info.ToString();
    }
    #endregion
}

public abstract class MultimediaDocument : BinaryDocument
{
    #region Fields
    private string lengthInSec;
    #endregion

    #region Constructor
    public MultimediaDocument(string name, string content = null, string size = null, string lengthInSec = null)
        : base(name, content, size)
    {
        this.LengthInSec = lengthInSec;
    }
    #endregion

    #region Properties
    public string LengthInSec
    {
        get
        {
            return this.lengthInSec;
        }
       protected set
        {
            this.lengthInSec = value;
        }
    }
    #endregion

    #region Override_Methods_IDocument
    public override void LoadProperty(string key, string value)
    {
        if (key == "length")
        {
            this.LengthInSec = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            if (property.Key == "length")
            {
                this.LengthInSec = property.Value.ToString();
                break;
            }
        }

        base.SaveAllProperties(output);
    }
    #endregion

    #region Override_official_Methods
    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        if (this.LengthInSec != null)
        {
            info.Append("length=");
            info.Append(this.LengthInSec);
            info.Append(';');
        }
       
        return base.ToString() + info.ToString();
    }
    #endregion
}
#endregion

#region TypesOfDocuments
public class TextDocument : Document, IEditable
{
    #region Fields
    private string charset;
    #endregion

    #region Constructor
    public TextDocument(string name, string content = null, string charset = null)
        : base(name, content)
    {
        this.Charset = charset;
    }
    #endregion

    #region Properties
    public string Charset
    {
        get
        {
            return this.charset;
        }
        protected set
        {
            this.charset = value;
        }
    }
    #endregion

    #region Override_Methods_IDocument
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
        foreach (var property in output)
        {
            if (property.Key == "charset")
            {
                this.Charset = property.Value.ToString();
            }
        }

        base.SaveAllProperties(output);
    }
    #endregion

    #region Override_official_Methods
    public override string ToString()
    {
        StringBuilder info = new StringBuilder();
        if (this.Charset != null)
        {
            info.Append("charset=");
            info.Append(this.Charset);
            info.Append(';');
        }

        info.Append(']');

        return base.ToString() + info.ToString();
    }
    #endregion

    #region Methods_OtherInterfaces
    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
    #endregion
}

public class PDFDocument : BinaryDocument, IEncryptable
{
    #region Fields
    private string numberOfPages;
    private bool isEncrypted = false;
    #endregion

    #region Constructor
    public PDFDocument(string name, string content = null, string size = null, string numberOfPages = null)
        : base(name, content, size)
    {
        this.NumberOfPages = numberOfPages;
    }
    #endregion

    #region Properties
    public string NumberOfPages
    {
        get
        {
            return this.numberOfPages;
        }
       protected set
        {
            this.numberOfPages = value;
        }
    }
    #endregion

    #region Override_Methods_IDocument
    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
        {
            this.NumberOfPages = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
        
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            if (property.Key == "pages")
            {
                this.NumberOfPages = property.Value.ToString();
                break;
            }
        }

        base.SaveAllProperties(output);
    }
    #endregion

    #region Override_official_Methods
    public override string ToString()
    {
        if (IsEncrypted == true)
        {
            return this.GetType().Name + "[encrypted]";
        }

        StringBuilder info = new StringBuilder();

        if (this.NumberOfPages != null)
        {
            info.Append("pages=");
            info.Append(this.NumberOfPages);
            info.Append(';');
        }
       
        info.Append(']');

        return base.ToString() + info.ToString();
    }
    #endregion

    #region Methods_OtherInterfaces
    public bool IsEncrypted
    {
        get { return isEncrypted; }
    }

    public void Encrypt()
    {
        this.isEncrypted = true;
    }

    public void Decrypt()
    {
        this.isEncrypted = false;
    }
    #endregion
}

public class WordDocument : OfficeDocument, IEditable, IEncryptable
{
    #region Fields
    private string numberOfCharacters;
    private bool isEncrypted = false;
    #endregion

    #region Constructor
    public WordDocument(string name, string content = null, string size = null, string version = null, string numberOfCharacters = null)
        : base(name, content, size, version)
    {
        this.NumberOfCharacters = numberOfCharacters;
    }
    #endregion

    #region Properties
    public string NumberOfCharacters
    {
        get
        {
            return this.numberOfCharacters;
        }
       protected set
        {
            this.numberOfCharacters = value;
        }
    }
    #endregion

    #region Override_Methods_IDocument
    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
        {
            this.NumberOfCharacters = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
       
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            if (property.Key == "chars")
            {
                this.NumberOfCharacters = property.Value.ToString();
                break;
            }
        }
        base.SaveAllProperties(output);
    }
    #endregion

    #region Override_official_Methods
    public override string ToString()
    {
        if (IsEncrypted == true)
        {
            return this.GetType().Name + "[encrypted]";
        }
        StringBuilder info = new StringBuilder();

        if (this.NumberOfCharacters != null)
        {
            info.Append("chars=");
            info.Append(this.NumberOfCharacters);
            info.Append(';');
        }
       
        info.Append(']');

        return base.ToString() + info.ToString();
    }
    #endregion

    #region Methods_OtherInterfaces
    public bool IsEncrypted
    {
        get { return isEncrypted; }
    }

    public void Encrypt()
    {
        this.isEncrypted = true;
    }

    public void Decrypt()
    {
        this.isEncrypted = false;
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
    #endregion
}

public class ExcelDocument : OfficeDocument, IEncryptable
{
    #region Fields
    private string numberOfRows;
    private string numberOfCols;
    private bool isEncrypted = false;
    #endregion

    #region Constructor
    public ExcelDocument(string name, string content = null, string size = null, string version = null, string numberOfRows = null, string numberOfCols = null)
        : base(name, content, size, version)
    {
        this.NumberOfRows = numberOfRows;
        this.NumberOfCols = numberOfCols;
    }
    #endregion

    #region Properties
    public string NumberOfRows
    {
        get
        {
            return this.numberOfRows;
        }
       protected set
        {
            this.numberOfRows = value;
        }
    }

    public string NumberOfCols
    {
        get
        {
            return this.numberOfCols;
        }
       protected set
        {
            this.numberOfCols = value;
        }
    }
    #endregion

    #region Override_Methods_IDocument
    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
        {
            this.NumberOfRows = value;
        }
        else if (key == "cols")
        {
            this.NumberOfCols = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            if (property.Key == "rows")
            {
                this.NumberOfRows = property.Value.ToString();
            }
            else if (property.Key == "cols")
            {
                this.NumberOfCols = property.Value.ToString();
            }
        }

        base.SaveAllProperties(output);
    }
    #endregion

    #region Override_official_Methods
    public override string ToString()
    {
        if (IsEncrypted == true)
        {
            return this.GetType().Name + "[encrypted]";
        }

        StringBuilder info = new StringBuilder();

        if (this.numberOfRows != null)
        {
            info.Append("rows=");
            info.Append(this.NumberOfRows);
            info.Append(';');
        }
        if (this.NumberOfCols != null)
        {
            info.Append("cols=");
            info.Append(this.NumberOfCols);
            info.Append(';');
        }
        
        info.Append(']');

        return base.ToString() + info.ToString();
    }
    #endregion

    #region Methods_OtherInterfaces
    public bool IsEncrypted
    {
        get { return isEncrypted; }
    }

    public void Encrypt()
    {
        this.isEncrypted = true;
    }

    public void Decrypt()
    {
        this.isEncrypted = false;
    }
    #endregion
}

public class AudioDocument : MultimediaDocument
{
    #region Fields
    private string sampleRate;
    #endregion

    #region Constructor
    public AudioDocument(string name, string content = null, string size = null, string lengthInSec = null, string sampleRate = null)
        : base(name, content, size, lengthInSec)
    {
        this.SampleRate = sampleRate;
    }
    #endregion

    #region Properties
    public string SampleRate
    {
        get
        {
            return this.sampleRate;
        }
        set
        {
            this.sampleRate = value;
        }
    }
    #endregion

    #region Override_Methods_IDocument
    public override void LoadProperty(string key, string value)
    {
        if (key == "samplerate")
        {
            this.SampleRate = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            if (property.Key == "samplerate")
            {
                this.SampleRate = property.Value.ToString();
                break;
            }
        }

        base.SaveAllProperties(output);
    }
    #endregion

    #region Override_official_Methods
    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        if (this.SampleRate != null)
        {
            info.Append("samplerate=");
            info.Append(this.SampleRate);
            info.Append(';');
            
        }
        info.Append(']');

        return base.ToString() + info.ToString();
    }
    #endregion
}

public class VideoDocument : MultimediaDocument
{
    #region Fields
    private string frameRate;
    #endregion

    #region Constructor
    public VideoDocument(string name, string content = null, string size = null, string lengthInSec = null, string frameRate = null)
        : base(name, content, size, lengthInSec)
    {
        this.FrameRate = frameRate;
    }
    #endregion

    #region Properties
    public string FrameRate
    {
        get
        {
            return this.frameRate;
        }
       protected set
        {
            this.frameRate = value;
        }
    }
    #endregion

    #region Override_Methods_IDocument
    public override void LoadProperty(string key, string value)
    {
        if (key == "framerate")
        {
            this.FrameRate = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            if (property.Key == "framerate")
            {
                this.FrameRate = property.Value.ToString();
                break;
            }
        }

        base.SaveAllProperties(output);
    }
    #endregion

    #region Override_official_Methods
    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        if (this.FrameRate != null)
        {
            info.Append("framerate=");
            info.Append(this.FrameRate);
            info.Append(';');
        }
        
        info.Append(']');

        return base.ToString() + info.ToString();
    }
    #endregion
}
#endregion