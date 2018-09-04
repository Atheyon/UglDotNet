using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglDotNet.Models.Types;

namespace UglDotNet.Models.Schema
{
    class Schema
    {
        public static readonly string TypeKindObject = "object";
        public static readonly string TypeKindTuple = "tuple";

        public List<SchemaField> Fields { get; set; }
        public List<SchemaType> Types { get; set; }

        public static readonly Schema MetaSchema = new Schema {
            Fields = new List<SchemaField>
            {
                new SchemaField
                {
                    Key = "fields",
                    Type = "void",
                    Array = new SchemaArrayOpts
                    {
                        Type = "field"
                    }
                },
                new SchemaField
                {
                    Key = "types",
                    Type = "void",
                    Array = new SchemaArrayOpts
                    {
                        Type = "type"
                    }
                }
            },
            Types = new List<SchemaType>
            {
                new SchemaType
                {
                    Key = "arrayField",
                    Kind = Schema.TypeKindObject,
                    Type = "void",
                    Fields = new List<SchemaField>
                    {
                        new SchemaField
                        {
                            Key = "type",
                            Type = "string",
                            Required = true
                        },
                        new SchemaField
                        {
                            Key = "min",
                            Type = "int"
                        },
                        new SchemaField
                        {
                            Key = "max",
                            Type = "int"
                        }
                    }
                },
                new SchemaType
                {
                    Key = "field",
                    Kind = TypeKindObject,
                    Type = "string",
                    Array = new SchemaArrayOpts
                    {
                        Type = "field"
                    },
                    Fields = new List<SchemaField>
                    {
                        new SchemaField
                        {
                            Key = "type",
                            Type = "string",
                            Default = "void"
                        },
                        new SchemaField
                        {
                            Key = "array",
                            Type = "arrayField"
                        },
                        new SchemaField
                        {
                            Key = "required",
                            Type = "bool"
                        },
                        new SchemaField
                        {
                            Key = "default",
                            Type = "string"
                        }
                    }
                },
                new SchemaType
                {
                    Key = "type",
                    Kind = TypeKindObject,
                    Type = "string",
                    Array = new SchemaArrayOpts
                    {
                        Type = "field"
                    },
                    Fields = new List<SchemaField>
                    {
                        new SchemaField
                        {
                            Key = "kind",
                            Type = "string",
                            Required = true
                        },
                        new SchemaField
                        {
                            Key = "type",
                            Type = "string",
                            Default = "void"
                        },
                        new SchemaField
                        {
                            Key = "array",
                            Type = "arrayField"
                        }
                    }
                }
            }
        };

        public static SchemaContext ApplySchema(UglNode root, Schema schema, UglOptions options = null)
        {
            var typeMap = new Dictionary<string, OneOf<SchemaType, UglType>>();
            foreach (var type in UglType.Primitives)
                typeMap[type.Key] = type;
            var context = new SchemaContext
            {
                Root = root,
                Schema = schema,
                Types = typeMap,
                Errors = new List<SchemaError>()
            };
            foreach (var type in options?.Types?? new List<UglType>())
                context.Types[type.Key] = type;
            foreach (var type in schema.Types)
                context.Types[type.Key] = type;

            var rootType = GetRootType(schema);
            TypeCheckNode(root, rootType, context);

            return context;
        }

        public static SchemaContext BuildSchema(UglNode root)
        {
            var context = ApplySchema(root, MetaSchema);
            var schema = new Schema
            {
                Fields = new List<SchemaField>(),
                Types = new List<SchemaType>()
            };

            if(root.Fields.TryGetValue("fields", out UglNode fieldsNode))
                foreach (var child in fieldsNode.Elements)
                    schema.Fields.Add(BuildSchemaField(child));

            if (root.Fields.TryGetValue("types", out UglNode typesNode))
                foreach (var child in fieldsNode.Elements)
                    schema.Types.Add(BuildSchemaType(child));

            context.Result = schema;
            return context;
        }

        private static SchemaField BuildSchemaField(UglNode child)
        {
            throw new NotImplementedException();
        }

        private static SchemaType BuildSchemaType(UglNode child)
        {
            throw new NotImplementedException();
        }

        private static void TypeCheckNode(UglNode root, object rootType, SchemaContext context)
        {
            throw new NotImplementedException();
        }

        private static object GetRootType(Schema schema)
        {
            throw new NotImplementedException();
        }
    }


}
