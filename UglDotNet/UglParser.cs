using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglDotNet.Models;

namespace UglDotNet
{
    public static class UglParser
    {
        public static UglNode UglParse(IEnumerable<UglLine> lines)
        {
            var scopes = new Stack<UglNode>();
            var rootScope = new UglNode
            {
                Line = new UglLine
                {
                    LineNumber = -1,
                    Indent = -1,
                    Key = null,
                    Value = null
                },
                Fields = new Dictionary<string, UglNode>(),
                Elements = new List<UglNode>(),
                Depth = -1,
                Type = null
            };
            scopes.Push(rootScope);
            foreach(var line in lines)
            {
                var currentScope = scopes.Peek();
                while (line.Indent <= currentScope.Line.Indent)
                {
                    scopes.Pop();
                    currentScope = scopes.Peek();
                }
                var node = new UglNode
                {
                    Line = line,
                    Depth = currentScope.Depth + 1,
                    Fields = new Dictionary<string, UglNode>(),
                    Elements = new List<UglNode>(),
                    Type = null
                };
                if (node.Line.Key == UglNode.ArrayKey)
                    currentScope.Elements.Add(node);
                else
                    currentScope.Fields[node.Line.Key] = node;
                scopes.Push(node);
            }
            return rootScope;
        }
    }
}
