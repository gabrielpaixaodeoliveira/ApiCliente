using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiCliente.Domain.Validation
{
    public class DateValidationAttribute : ValidationAttribute
    {
        public DateValidationAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if ((dt > DateTime.Now) || (dt.Year < 1900))
            {
                return false;
            }
            return true;
        }
    }
}
