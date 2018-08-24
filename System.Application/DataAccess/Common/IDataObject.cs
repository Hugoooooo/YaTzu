using System.Reflection;

namespace System.Application.DataAccess.Common
{
    public enum ObjectType
    {
        Table,
        View
    }

    public enum ObjectItem
    {
        FieldSet,
        TableName
    }

    public interface IDataObject
    {
        string Mapping { get; }
        string Fields { get; }
    }
}
