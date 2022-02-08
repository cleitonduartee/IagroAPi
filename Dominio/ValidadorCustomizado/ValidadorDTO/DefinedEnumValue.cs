using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValidadorCustomizado.ValidadorDTO
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DefinedEnumValueAttribute : ValidationAttribute
    {
        private readonly Type enumType;

        public DefinedEnumValueAttribute(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException($"The given type is not an enum.");
            }

            this.enumType = enumType;
        }

        public override bool IsValid(object value)
        {
            if (value is IEnumerable enumerable)
            {
                return enumerable.Cast<object>().All(val => Enum.IsDefined(enumType, val));
            }
            else
            {
                return Enum.IsDefined(enumType, value);
            }
        }
    }
}
