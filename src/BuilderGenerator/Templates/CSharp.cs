namespace BuilderGenerator.Templates;

/// <summary>Defines code generation templates compatible with C# 10 features.</summary>
public class CSharp
{
    public virtual string BuilderBaseClass
    {
        get
        {
            return """
                   #nullable enable

                   namespace BuilderGenerator
                   {
                       /// <summary>Base class for object builder classes.</summary>
                       /// <typeparam name="T">The type of the objects built by this builder.</typeparam>
                       public abstract class Builder<T> where T : class
                       {
                           /// <summary>Gets or sets the object returned by this builder.</summary>
                           /// <value>The constructed object.</value>
                           #pragma warning disable CA1720 // Identifier contains type name
                           protected System.Lazy<T> Object { get; set; }
                           #pragma warning restore CA1720 // Identifier contains type name

                           /// <summary>Builds the object instance.</summary>
                           /// <returns>The constructed object.</returns>
                           public abstract T Build();

                           protected virtual void PostProcess(T value)
                           {
                           }
                       }
                   }
                   """;
        }
    }

    public virtual string BuilderClass
    {
        get
        {
            return """
                   #nullable enable

                   //-------------------------------------------------------------------------------------
                   // <auto-generated>
                   //     This code was generated by BuilderGenerator at {{GenerationTime:u}} in {{GenerationDuration}}ms
                   // </auto-generated>
                   //-------------------------------------------------------------------------------------
                   using System.CodeDom.Compiler;
                   {{BuilderClassUsingBlock}}

                   namespace {{BuilderClassNamespace}}
                   {
                       {{BuilderClassAccessibility}} partial class {{BuilderClassName}} : BuilderGenerator.Builder<{{TargetClassFullName}}>
                       {
                   {{Properties}}

                   {{Constructors}}

                   {{WithValuesFromMethod}}

                   {{BuildMethod}}

                   {{WithObjectMethod}}
                   {{WithMethods}}
                       }
                   }

                   """;
        }
    }

    public virtual string BuilderForAttribute
    {
        get
        {
            return """
                   namespace BuilderGenerator
                   {
                       [System.AttributeUsage(System.AttributeTargets.Class)]
                       public class BuilderForAttribute : System.Attribute
                       {
                           public bool IncludeInternals { get; }
                           public System.Type Type { get; }

                           public BuilderForAttribute(System.Type type, bool includeInternals = false)
                           {
                               IncludeInternals = includeInternals;
                               Type = type;
                           }
                       }
                   }
                   """;
        }
    }

    public virtual string BuildMethod
    {
        get
        {
            return """
                           public override {{TargetClassFullName}} Build()
                           {
                               if (Object?.IsValueCreated != true)
                               {
                                   Object = new System.Lazy<{{TargetClassFullName}}>(() =>
                                   {
                                       var result = new {{TargetClassFullName}}
                                       {
                   {{Setters}}
                                       };

                                       return result;
                                   });

                                   PostProcess(Object.Value);
                               }

                               return Object.Value;
                           }
                   """;
        }
    }

    public virtual string BuildMethodSetter
    {
        get
        {
            return "                        {{PropertyName}} = {{PropertyName}}.Value,";
        }
    }

    public virtual string Constructors
    {
        get
        {
            return """
                           /// <summary>Initializes a new instance of the <see cref="{{BuilderClassName}}"/> class using the provided <see cref="{{TargetClassFullName}}" /> for the Object value.</summary>
                           /// <param name="value">The <see cref="{{TargetClassFullName}}" /> instance to build on.</param>
                           /// <remarks>Note: <paramref name="value" /> is not simply a template. The actual instance will be remembered and returned.</remarks>
                           public {{BuilderClassName}}({{TargetClassFullName}}? value = null)
                           {
                               if (value != null)
                               {
                                   WithObject(value);
                               }
                           }
                   """;
        }
    }

    public virtual string Property
    {
        get
        {
            return "        public System.Lazy<{{PropertyType}}> {{PropertyName}} = new System.Lazy<{{PropertyType}}>(() => default({{PropertyType}})!);";
        }
    }

    public virtual string WithMethods
    {
        get
        {
            return """

                           public {{BuilderClassName}} With{{PropertyName}}({{PropertyType}} value)
                           {
                               return With{{PropertyName}}(() => value);
                           }

                           public {{BuilderClassName}} With{{PropertyName}}(System.Func<{{PropertyType}}> func)
                           {
                               {{PropertyName}} = new System.Lazy<{{PropertyType}}>(func);
                               return this;
                           }

                           public {{BuilderClassName}} Without{{PropertyName}}()
                           {
                               {{PropertyName}} = new System.Lazy<{{PropertyType}}>(() => default({{PropertyType}})!);
                               return this;
                           }
                   """;
        }
    }

    public virtual string WithObjectMethod
    {
        get
        {
            return """
                           /// <summary>Sets the object to be returned by this instance.</summary>
                           /// <param name="value">The object to be returned.</param>
                           /// <returns>A reference to this builder instance.</returns>
                           public {{BuilderClassName}} WithObject({{TargetClassFullName}} value)
                           {
                               Object = new System.Lazy<{{TargetClassFullName}}>(() => value);
                               WithValuesFrom(value);

                               return this;
                           }
                   """;
        }
    }

    public virtual string WithValuesFromMethod
    {
        get
        {
            return """
                           /// <summary>Populates this instance with values from the provided example.</summary>
                           /// <remarks>This is a shallow clone, and does not traverse the example object creating builders for its properties.</remarks>
                           public {{BuilderClassName}} WithValuesFrom({{TargetClassFullName}} example)
                           {
                   {{WithValuesFromSetters}}

                               return this;
                           }
                   """;
        }
    }

    public virtual string WithValuesFromSetter
    {
        get
        {
            return "            With{{PropertyName}}(example.{{PropertyName}});";
        }
    }
}
