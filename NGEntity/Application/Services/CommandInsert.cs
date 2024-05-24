using Microsoft.Extensions.Primitives;
using Mysqlx.Crud;
using NGEntity.Application.Interfaces;
using NGEntity.Attributes;
using NGEntity.Enums;
using NGEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Application.Services
{
    internal class CommandInsert : ICommandInsert
    {
        public string Fields { get; set; }
        public List<string> Values { get; set; }
        public CommandInsert() { Fields = null; Values = []; }
        public void SetValues(IEntity entity)
        {
            IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(entity);
            Fields ??= GetFields(propertyInfos);
            Values.Add(GetValues(entity, propertyInfos));
        }

        private static IEnumerable<PropertyInfo> GetPropertyInfo(IEntity entity)
        {
            return entity
                    .GetType()
                    .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                    .Where(w => IsTypeValid(w.PropertyType));
        }
        private static string GetFields(IEnumerable<PropertyInfo> propertyInfos)
        {
            return String.Join(',', propertyInfos.Select(s => s.Name));
        }
        private static string GetValues(IEntity entity, IEnumerable<PropertyInfo> propertyInfos)
        {
            return String.Join(',', propertyInfos.Select(s => GetValue(entity, s)));
            //insert.Values
            //    .AddRange(
            //        propertyInfos
            //            .Select(s => (s.GetCustomAttributes().Any(a => a.GetType() == typeof(FieldsAttributes))) ?
            //                        (
            //                            (VariableType.String == s.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().FirstOrDefault().Type ||
            //                            VariableType.DateTime == s.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().FirstOrDefault().Type) ? ////if
            //                                (s.GetValue(entity) == null) ? "null" : "'" + s.GetValue(entity) + "'" :
            //                                    (VariableType.Bool == s.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().FirstOrDefault().Type) ? ////// else if
            //                                            (s.GetValue(entity) == null) ? "null" : (((bool)s.GetValue(entity) == true) ? 1 : 0).ToString() :
            //                                            (s.GetValue(entity) ?? "null").ToString()  ////////// else
            //                        ) :
            //                        (
            //                            (VariableType.String == Generic.GetVariableType(s.GetType().ToString()) ||
            //                            VariableType.DateTime == Generic.GetVariableType(s.GetType().ToString())) ? ////if
            //                                (s.GetValue(entity) == null) ? "null" : "'" + s.GetValue(entity) + "'" :
            //                                    (VariableType.Bool == Generic.GetVariableType(s.GetType().ToString())) ? ////// else if
            //                                            (s.GetValue(entity) == null) ? "null" : (((bool)s.GetValue(entity) == true) ? 1 : 0).ToString() :
            //                                            (s.GetValue(entity) ?? "null").ToString()  ////////// else
            //                        )
            //                    )
            //            );
        }
        private static string GetValue(IEntity entity, PropertyInfo propertyInfo)
        {
            var typeCode = Type.GetTypeCode(GetNullableType(propertyInfo.PropertyType));
            object value = propertyInfo.GetValue(entity);

            if (value == null)
                return "NULL";

            return typeCode switch
            {
                TypeCode.Boolean => ((bool)value == true) ? "1" : "0",
                TypeCode.String or 
                TypeCode.Char or 
                TypeCode.DateTime => $"'{value}'",
                //case TypeCode.Byte:
                //case TypeCode.Decimal:
                //case TypeCode.Double:
                //case TypeCode.Int16:
                //case TypeCode.Int32:
                //case TypeCode.Int64:
                //case TypeCode.SByte:
                //case TypeCode.Single:
                //case TypeCode.UInt16:
                //case TypeCode.UInt32:
                //case TypeCode.UInt64:
                _ => value.ToString(),
            };
        }
        private static Type GetNullableType(Type typeToCheck)
        {
            if (typeToCheck.IsGenericType &&
                typeToCheck.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return Nullable.GetUnderlyingType(typeToCheck);
            }
            else
            {
                return typeToCheck;
            }
        }
        private static bool IsTypeValid(Type typeToCheck)
        {
            var typeCode = Type.GetTypeCode(GetNullableType(typeToCheck));

            return typeCode switch
            {
                TypeCode.Boolean or 
                TypeCode.Byte or 
                TypeCode.Char or 
                TypeCode.DateTime or 
                TypeCode.Decimal or 
                TypeCode.Double or 
                TypeCode.Int16 or 
                TypeCode.Int32 or 
                TypeCode.Int64 or 
                TypeCode.SByte or 
                TypeCode.Single or 
                TypeCode.String or 
                TypeCode.UInt16 or 
                TypeCode.UInt32 or 
                TypeCode.UInt64 => true,
                _ => false,
            };
        } 
    }
}
