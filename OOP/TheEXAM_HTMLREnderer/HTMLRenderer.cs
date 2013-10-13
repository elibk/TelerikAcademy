using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HTMLRenderer
{
	public interface IElement
	{
		string Name { get; }
		string TextContent { get; set; }
		IEnumerable<IElement> ChildElements { get; }
		void AddElement(IElement element);
		void Render(StringBuilder output);
		string ToString();
	}

	public interface ITable : IElement
	{
		int Rows { get; }
		int Cols { get; }
		IElement this[int row, int col] { get; set; }
	}

    public interface IElementFactory
    {
		IElement CreateElement(string name);
		IElement CreateElement(string name, string content);
		ITable CreateTable(int rows, int cols);
    }

   public abstract class JustElement : IElement
    {
       private string name;
       private string textContent;
       private IEnumerable<IElement> childElements;

       public JustElement(string name, string textContent = null, List<IElement> childElements = null)
        {
            this.Name = name;
            this.TextContent = textContent;
            if (childElements == null)
            {
                this.ChildElements = new List<IElement>();
            }
            else
            {
                this.ChildElements = childElements;
            }
            
        }

        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }

        public string TextContent
        {
            get
            {
                return this.textContent;
            }
            set
            {
                this.textContent = value;
            }
        }

        public IEnumerable<IElement> ChildElements
        {
            get { return this.childElements; }
            protected set { this.childElements = value; }
        }

        public virtual void AddElement(IElement element)
        {
           (this.childElements as List<IElement>).Add(element);
        }

        public virtual void Render(StringBuilder output)
        {

        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            this.Render(info);
            return info.ToString();
        }
    }

    public class HTMLElement : JustElement
    {
        public HTMLElement(string name, string textContent = null, List<IElement> childElements = null) 
            : base(name,textContent,childElements)
        { 
        }

        public override void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.Append('<');
                output.Append(this.Name);
                output.Append('>');
            }

            if (this.TextContent != null)
            {

                string contentForRendering = Regex.Replace(this.TextContent, "&", "&amp;");

                contentForRendering = Regex.Replace(contentForRendering, ">", "&gt;");
                contentForRendering = Regex.Replace(contentForRendering, "<", "&lt;");
                output.Append(contentForRendering);
            }

            if (this.ChildElements != null)
            {
                foreach (var element in this.ChildElements)
                {
                    output.Append(element.ToString());
                }
            }
            if (this.Name != null)
            {
                output.Append("</");
                output.Append(this.Name);
                output.Append('>');
            }
        }

       
    }

    public class HTMLTable : JustElement, ITable
    {
        private int rows;
        private int cols;
        private IElement[,] tableBody;


        public HTMLTable( int rows, int cols, List<IElement> childElements = null)
            : base("table", null, childElements)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.tableBody = new IElement[this.Rows,this.Cols];
        }

        public int Rows
        {
            get { return this.rows; }
            protected set { this.rows = value; }
        }

        public int Cols
        {
            get { return this.cols; }
            protected set { this.cols = value; }
        }

        public IElement this[int row, int col]
        {
            get
            {
                return this.tableBody[row,col];
            }
            set
            {
                this.tableBody[row,col] = value;
            }
        }

        public override void AddElement(IElement element)
        {
            //base.AddElement(element);
        }

        public override void Render(StringBuilder output)
        {

            output.Append('<');
            output.Append(this.Name);
            output.Append('>');
            
            if (this.ChildElements != null)
            {
                foreach (var element in this.ChildElements)
                {
                    output.Append(element.ToString());
                }
            }
            for (int row = 0; row < this.Rows; row++)
			{
                output.Append("<tr>");
			    for (int col = 0; col < this.Cols; col++)
			    {
			        output.Append("<td>");
                    output.Append(this [row,col].ToString());
                    output.Append("</td>");
			    }
                output.Append("</tr>");
			}
            output.Append("</");
            output.Append(this.Name);
            output.Append('>');
        }
    }

    public class HTMLElementFactory : IElementFactory
    {
		public IElement CreateElement(string name)
		{
            IElement newElement = new HTMLElement(name);
            return newElement;
		}

		public IElement CreateElement(string name, string content)
		{

            IElement newElement = new HTMLElement(name, content);
            return newElement;
		}

		public ITable CreateTable(int rows, int cols)
		{
			ITable newTable = new HTMLTable(rows,cols);
            return newTable;
		}
	}

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
			string csharpCode = ReadInputCSharpCode();
			CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
