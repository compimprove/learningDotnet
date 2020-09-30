using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace First.Validations
{
    public class FileSizeValidator : ValidationAttribute
    {
        private readonly int maxFileSizeInMbs;

        public FileSizeValidator(int MaxFileSizeInMbs)
        {
            maxFileSizeInMbs = MaxFileSizeInMbs;
        }

        
    }
}
