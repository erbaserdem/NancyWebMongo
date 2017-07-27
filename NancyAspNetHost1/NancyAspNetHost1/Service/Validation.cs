using System;
using System.Linq;

namespace NancyAspNetHost1.Service
{
    public class Validation : CheckExisting
    {

        public virtual bool ValidateUserParameters(out string message)
        {
            message = string.Empty;
            return ValidateEmail(out message) && ValidateName(out message) && ValidateUserName(out message) && ValidateId(out message);
        }

        public virtual bool ValidateName(out string message)
        {

            message = string.Empty;
            if (string.IsNullOrWhiteSpace(_userToValidate.Name) & string.IsNullOrEmpty(_userToValidate.Name))
            {
                message += "White space, Empty and NULL ID's are not allowed";
                return false;
            }
            if (_userToValidate.Name.Length > 50)
            {
                message += "Name is too long";
                return false;
            }

            return true;

        }

        public virtual bool ValidateUserName(out string message)
        {

            message = string.Empty;
            if (string.IsNullOrWhiteSpace(_userToValidate.UserName))
            {
                message+="White space, Empty and NULL User Names are not allowed";
                return false;
            }
            if (_userToValidate.UserName.Length > 25)
            {
                message += "User Name is too long";
                return false;
            }

             if (CheckForExistingUserName() == null)
             {
                message += _userToValidate.UserName + "is already in use ";
                 return false;
             } // check if that username exists

            return true;


        }

        public virtual bool ValidateEmail(out string message)
        {

            message = string.Empty;
            if (string.IsNullOrWhiteSpace(_userToValidate.Email))
            {
                message += "White space, Empty and NULL ID's are not allowed";
                return false;
            }
            if (_userToValidate.Email.Length > 50)
            {
                message += "Email is too long";
                return false;
            }

            /* if (CustomerList.Find(find => find.ID == _userToValidate.Id.PadLeft(13, '0')) == null)
             {
                 Console.WriteLine("Not a valid CustomerID");
                 return false;
             }*/
            if (CheckForExistingEmail() == null)
            {
                message += _userToValidate.Email + "is already in use ";
                return false;
            } // check if that username exists

            return true;

        }

        public virtual bool ValidateId(out string message)
        {
            message = string.Empty;
            if (string.IsNullOrWhiteSpace(_userToValidate.Id))
            {
                message += "White space, Empty and NULL ID's are not allowed";
                return false;
            }
            if (!_userToValidate.Id.All(str => str >= '0' & str <= '9'))
            {
                message += "ID consists only of numerical values";
                return false;
            }
            if (_userToValidate.Id.Length > 13)
            {
                message += "ID must be a 13 digitnumber. If entered less it will be padded with 0's.";
                return false;
            }
            if (CheckForExistingId() == null)
            {
                message += _userToValidate.Id + "is already in use ";
                return false;
            } // check if that username exists

            return true;
        }
    }
}