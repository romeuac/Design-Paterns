using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Design_Paterns
{
    public class Code
    {
        public string className { get; set; }
        public List<(string, string)> fields = new List<(string, string)>();
         
        //public List<string> fieldTypes = new List<string>();
        //public List<string> fieldNames = new List<string>();

    }

    // Separte component to build the object CODE
    public class CodeBuilder
    {
        private Code code = new Code();

        public CodeBuilder(string className)
        {
            this.code.className = className ?? throw new ArgumentNullException(paramName: nameof(className));
        }

        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            code.fields.Add((fieldType, fieldName));
            //code.fieldTypes.Add(fieldType);
            //code.fieldNames.Add(fieldName);
            return this;
        }

        private string ToStringImpl()
        {
            var sb = new StringBuilder();
            int indentSize = 2;
            var i = new string(' ', indentSize);

            if (!string.IsNullOrEmpty(code.className))
            {
                //sb.Append(new string(' ', indentSize));
                sb.AppendLine("public class " + code.className);
                sb.AppendLine("{");
            }

            foreach (var field in code.fields)
            {
                sb.Append(new string(' ', indentSize));
                sb.AppendLine("public " + field.Item1 + " " + field.Item2 + ";");
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl();
        }
    }

    //public class FieldBuilder : CodeBuilder
    //{

    //}

    class Exercise
    { 

        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person")
                .AddField("Name", "string")
                .AddField("Age", "int");
            Console.WriteLine(cb);
        }

    }
}
