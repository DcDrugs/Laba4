using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Json
{
    public class Parser
    {
        public static Document Load(StreamReader input)
        {
            return new Document(LoadNode(input));
        }
        private static Node LoadArray(StreamReader input)
        {
            List<Node> result = new List<Node>();

            for (char c; RemoveSpace(input) && (c = Convert.ToChar(input.Peek())) != -1 && c != ']';)
            {
                if (c == ',')
                {
                    input.Read();
                }
                result.Add(LoadNode(input));
            }

            return new Node(result);
        }

        private static Node LoadInt(StreamReader input)
        {
            int result = 0;
            while (Char.IsDigit(Convert.ToChar(input.Peek())))
            {
                result *= 10;
                result += input.Read() - 48;
            }
            return new Node(result);
        }

        private static string Separated(StreamReader input, char by = '\0')
        {
            var line = string.Empty;
            while (input.Peek() >= 0)
            {
                char c = (char)input.Read();
                if (c == '\n' || c == by || c== '\r')
                {
                    return line;
                }
                else
                {
                    line += c;
                }
            }
            return line;
        }

        private static Node LoadString(StreamReader input)
        {
            string line;
            line = Separated(input, '"');
            return new Node(line);
        }

        private static Node LoadDict(StreamReader input)
        {
            var result = new Dictionary<string, Node>();


            for (char c; RemoveSpace(input) && (c = Convert.ToChar(input.Read())) != -1 && c != '}';)
            {
                if (c == ',')
                {
                    RemoveSpace(input);
                    c = Convert.ToChar(input.Read());
                }

                string key = LoadString(input).AsString();
                input.Read();
                result.Add(key, LoadNode(input));
            }

            return new Node(result);
        }

        private static bool RemoveSpace(StreamReader input)
        {
            while (input.Peek() == 32 || input.Peek() == '\r' || input.Peek() == '\n') input.Read();
            return true;
        }

        private static Node LoadNode(StreamReader input)
        {
            RemoveSpace(input);
            char c = Convert.ToChar(input.Peek());

            switch (c)
            {
                case '[':
                    {
                        input.Read();
                        RemoveSpace(input);
                        return LoadArray(input);
                    }
                case '{':
                    {
                        input.Read();
                        RemoveSpace(input);
                        return LoadDict(input);
                    }
                case '"':
                    {
                        input.Read();
                        RemoveSpace(input);
                        return LoadString(input);
                    }
                default:
                    {
                        return LoadInt(input);
                    }
            }
        }
    }

    public class Node : IConvertible
    {
        private readonly Object _data;
        public Node(Object data)
        {
            _data = data;
        }

        public List<Node> AsArray()
        {
            return (List<Node>)Convert.ChangeType(_data, typeof(List<Node>));
        }

        public Dictionary<string, Node> AsDictionary()
        {
            return (Dictionary<string, Node>)Convert.ChangeType(_data, typeof(Dictionary<string, Node>));
        }
        public int AsInt()
        {
            return (int)Convert.ChangeType(_data, typeof(int));
        }
        public string AsString()
        {
            return (string)Convert.ChangeType(_data, typeof(string));
        }

        public new Type GetType()
        {
            return _data.GetType();
        }

        public static explicit operator int(Node node)
        {
            return node.AsInt();
        }

        public static explicit operator string(Node node)
        {
            return node.AsString();
        }

        public static explicit operator List<Node>(Node node)
        {
            return node.AsArray();
        }

        public static explicit operator Dictionary<string, Node>(Node node)
        {
            return node.AsDictionary();
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            if (_data != null)
                return true;
            else
                return false;
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_data);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(_data);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(_data);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(_data);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(_data);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(_data);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(_data);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(_data);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(_data);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(_data);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return Convert.ToString(_data);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(_data, conversionType);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(_data);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(_data);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(_data);
        }
    };

    public class Document
    {
        private readonly Node _root;
        public Document(Node root)
        {
            _root = root;
        }

        public Node GetRoot()
        {
            return _root;
        }
    };
}