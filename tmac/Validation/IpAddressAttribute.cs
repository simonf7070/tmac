using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace tmac.Validation
{
    public class IpAddressAttribute : ValidationAttribute, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (!ValidIpAddress(value.ToString()))
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;
        }

        private bool ValidIpAddress(string ipAddress)
        {
            var ipAddressParts = ipAddress.Split('.');
            if (ipAddressParts.Length != 4)
            {
                return false;
            }

            foreach (var ipAddressPart in ipAddressParts)
            {
                int partValue;
                if (int.TryParse(ipAddressPart, out partValue))
                {
                    if (partValue < 0 || partValue > 255)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "ipaddress"
            };
            yield return rule;
        }
    }
}