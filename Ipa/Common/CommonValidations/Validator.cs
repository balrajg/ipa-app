using System;
using System.Text.RegularExpressions;

namespace Ipa
{
	public static class Validator
	{
		public static bool IsValidPostalCode(string PostalCode){
			//TODO : To implement postal code validation logic
			return true;
		}

		public static bool IsNumeric(string Number){
			if (string.IsNullOrEmpty (Number) || string.IsNullOrWhiteSpace (Number)) {
				return false;
			}
			double temp;
			bool Result = double.TryParse (Number, out temp);
			return Result;
		}

		public static bool IsValidPhoneNumber(string Number){
			if (string.IsNullOrEmpty (Number))
				return false;

			string pattern ="^((\\+){0,1}91(\\s){0,1}(\\-){0,1}(\\s){0,1}){0,1}9[0-9](\\s){0,1}(\\-){0,1}(\\s){0,1}[1-9]{1}[0-9]{7}$";
			if(Regex.IsMatch(Number, pattern))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool IsValidEmailId(string Email){
			if (string.IsNullOrEmpty (Email))
				return false;
			// "^[a-zA-Z]{1}[a-zA-Z0-9._!#$%&'?{}|*+/=`~^-]+@[a-zA-Z0-9]+.[a-zA-Z0-9]+((.[a-zA-Z0-9]+)+)"
			string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

			if (Regex.IsMatch(Email.Trim(), pattern))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool IsValidPassword(string Password){
			//TODO: To implement password validation conditions
			if (!string.IsNullOrEmpty (Password) && Password.Length >= 8) {
				return true;
			} else {
				return false;
			}
		}

		public static bool IsPasswordMatch(string Password, string ConfirmPassword){
			if (!string.IsNullOrEmpty (Password) && !string.IsNullOrEmpty (ConfirmPassword) && Password.Equals (ConfirmPassword)) {
				return true;
			} else {
				return false;
			}
		}
	}
}

