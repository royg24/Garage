using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class GetUserData
    {
        internal static string GetUserChoice()
        {
            VehiclesCreator creator = new VehiclesCreator();
            string message = null;
            string userChoice = null;
            int index = 1;
            Console.WriteLine("Choose the type of vehicle to add from the following:");
            foreach (string element in creator.VehiclesArray)
            {
                message = string.Format("{0}. {1}", index, element);
                Console.WriteLine(message);
                index++;
            }
            userChoice = Console.ReadLine();
            return userChoice;
        }
        internal static string GetOwnerName()
        {
            Console.Clear();
            Console.WriteLine("Please enter your name:");
            string ownerName = Console.ReadLine();
            if(!IsStringConsistsInlyLetters(ownerName))
            {
                throw new FormatException("The name you inserted is invalid. It must be a real name which consists only letters!");
            }
            return ownerName;
        }
        internal static string GetOwnerPhoneNumber()
        {
            Console.Clear();
            Console.WriteLine("Please enter your phone number:");
            string ownerPhoneNumber = Console.ReadLine();
            if(!IsStringConsistsOnlyDigits(ownerPhoneNumber))
            {
                throw new FormatException("The phone you inserted is invalid. phone number consists only digits!!");
            }
            return ownerPhoneNumber;
        }
        internal static string GetLicensePlateID(Garage i_Garage, bool i_ExcistOrNot)
        {
            Console.Clear();
            Console.WriteLine("Please enter the license plate's ID of your vehicle:");
            string licensePlateID = Console.ReadLine();
            if(i_ExcistOrNot == true)
            {
                bool alreadyExists = i_Garage.CheckIfLicensePlateIDExcists(licensePlateID);
                if (alreadyExists == true)
                {
                    UserInterface.MessageIfLicensePlateIDExistsAndChanged(licensePlateID);
                }
            }
            else
            {
                i_Garage.CheckIfLicensePlateIDnotExcists(licensePlateID);
            }
            return licensePlateID;
        }
        internal static eVehicleStatus GetVehicleStatus(Garage i_Garage)
        {
            Console.WriteLine(
@"Choose the status of vehicle:
1. under repair
2. was fixed
3. paid up ");
            string vheicleStatusString = Console.ReadLine();
            eVehicleStatus vehicleStatus = i_Garage.CheckIfStatusValid(vheicleStatusString);
            return vehicleStatus;
        }
        internal static eFuelType GetFuelType(Garage i_Garage)
        {
            Console.WriteLine("Choose vehicle's fuel type:");
            string fuelTypeString = Console.ReadLine();
            eFuelType fuelType = i_Garage.CheckIfFuelTypeValid(fuelTypeString);
            return fuelType;
        }
        internal static float GetFloatFromUser()
        {
            float amountToFill = float.Parse(Console.ReadLine());
            return amountToFill;
        }
        internal static bool IsStringConsistsOnlyDigits(string i_Str)
        {
            bool IsValid = true;
            foreach(char ch in i_Str)
            {
                if(!(ch >= 48 && ch <= 57))
                {
                    IsValid = false;
                    break;
                }
            }
            return IsValid;
        }
        internal static bool IsStringConsistsInlyLetters(string i_Str)
        {
            bool IsValid = true;
            foreach (char ch in i_Str)
            {
                if (!((ch >= 97 && ch <= 122) || (ch >= 65 && ch <= 90)))
                {
                    IsValid = false;
                    break;
                }
            }
            return IsValid;
        }

    }
}
