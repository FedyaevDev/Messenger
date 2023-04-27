using BestMessenger.Infrastructure.Commands;
using BestMessenger.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BestMessenger.ViewModels
{
    public class ValidProperty 
    {
        public string FieldName { get; set; } 
        public string Value { get; set; }
        public ValidateType[] ValidateTypes { get; set; }
        public bool IsValid { get; set; } = true;
    }

    public class RegistrationViewModel : BaseViewModel
    {
        #region Properties
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { UpdateValue<string>(ref firstName, value); }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { UpdateValue<string>(ref lastName, value); }
        }

        private string nickName;

        public string NickName
        {
            get { return nickName; }
            set { UpdateValue<string>(ref nickName, value);}
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { UpdateValue<string>(ref email, value); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { UpdateValue<string>(ref password, value); }
        }

        private bool nameValid = true;

        public bool NameValid
        {
            get { return nameValid; }
            set { UpdateValue<bool>(ref nameValid, value); }
        }

        private bool lastNameValid = true;

        public bool LastNameValid
        {
            get { return lastNameValid; }
            set { UpdateValue<bool>(ref lastNameValid, value);}
        }

        private bool emailValid = true;

        public bool EmailValid
        {
            get { return emailValid; }
            set { UpdateValue<bool>(ref emailValid, value); }
        }


        private ValidationUtils _validationUtils;

        #endregion

        #region Commands
        public ActionCommand RegistrationCommand => new ActionCommand(x => ValidateProperties());
        #endregion

        public RegistrationViewModel()
        {
            _validationUtils = new ValidationUtils();
        }
        private void ValidateProperties()
        {
            List<ValidProperty> validProperties = new List<ValidProperty>()
            {
                new ValidProperty(){ FieldName = nameof(FirstName), Value = FirstName, ValidateTypes = new ValidateType[] { ValidateType.EmptryStr, ValidateType.DigitContains } },
                new ValidProperty(){ FieldName = nameof(Email), Value = Email, ValidateTypes = new ValidateType[] {ValidateType.IsEmailValidate, ValidateType.EmptryStr}}
            };

            _validationUtils.IsValid(validProperties);

            foreach (var item in validProperties)
            {
                if (item.FieldName == nameof(FirstName))
                {
                    NameValid = item.IsValid;
                }
                else if (item.FieldName == nameof(Email))
                {
                    EmailValid = item.IsValid;
                }
            }
            
        }
    }
}
