using BestMessenger.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BestMessenger.Infrastructure.Utils
{
    public enum ValidateType
    {
        EmptryStr,
        /// <summary>
        /// Проверка на отсутствие чисел
        /// </summary>
        DigitContains,
        SpecialSymb,
        IsEmailValidate
    }

    public class ValidationUtils
    {
        public event Action<ValidProperty> Validate;
        public ValidationUtils()
        {
            
        }

        //public bool IsValid(string value, params ValidateType[] validates)
        //{
        //    if (validates.Contains(ValidateType.EmptryStr) == true)
        //    {
        //        Validate += EmptyStrValidate;
        //    }
        //    else if (validates.Contains(ValidateType.DigitContains) == true)
        //    {
        //        Validate += DigitContainsValidate;
        //    }
        //    else if (validates.Contains(ValidateType.SpecialSymb) == true)
        //    {
        //        Validate += SpecialSymbValidate;
        //    }
        //    else if ( validates.Contains(ValidateType.IsEmailValidate) == true)
        //    {
        //        Validate += IsEmailValidate;
        //    }
        //    if(Validate != null)
        //    {
        //        return Validate(value);
        //    }
        //    throw new Exception();
        //}
        public void IsValid(List<ValidProperty> properties)
        {
            for (int i = 0; i < properties.Count; i++)
            {
                if (properties[i].ValidateTypes.Contains(ValidateType.EmptryStr) == true)
                {
                    Validate += EmptyStrValidate;
                }
                if (properties[i].ValidateTypes.Contains(ValidateType.DigitContains) == true)
                {
                    Validate += DigitContainsValidate;
                }
                if (properties[i].ValidateTypes.Contains(ValidateType.SpecialSymb) == true)
                {
                    Validate += SpecialSymbValidate;
                }
                if (properties[i].ValidateTypes.Contains(ValidateType.IsEmailValidate) == true)
                {
                    Validate += IsEmailValidate;
                }

                if (Validate != null)
                {
                    Validate(properties[i]);
                }
            }
        }
        /// <summary>
        /// Проверка на пустое значение
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private void EmptyStrValidate(ValidProperty property)
        {
            if (property.Value == null || property.Value.Length == 0)
            {
                property.IsValid = false;
            }
        }
        /// <summary>
        /// Проверят на отсутствие чисел в строке
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private void DigitContainsValidate(ValidProperty property)
        {
            if(property.Value == null)
            {
                property.IsValid = false;
                return;
            }
            foreach (var item in property.Value)
            {
                if (Char.IsDigit(item) == true)
                {
                    property.IsValid = false;
                }
            }
        }
        private void SpecialSymbValidate(ValidProperty property)
        {
            foreach (var item in property.Value)
            {
                if (item == '^')
                {
                    property.IsValid = false;
                }
            }
             
        }
        private void IsEmailValidate(ValidProperty property)
        {
            if (property.Value == null)
            {
                property.IsValid = false;
                return;
            }
                bool flag = false;
            foreach (var item in property.Value)
            {
                if (item == '@')
                {
                    flag = true;
                }
            }
            if(flag != true) property.IsValid = false;
        }

    }
}
