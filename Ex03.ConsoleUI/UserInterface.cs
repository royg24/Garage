using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.VehiclesCreator;
using static Ex03.ConsoleUI.GetUserData;
using Ex03.GarageLogic;
using System.IO;

namespace Ex03.ConsoleUI
{
    internal class UserInterface
    {
        private const string k_EndString = "END";
        private const string k_ReturnString = "RETURN";
        internal static void WelcomeToTheGarage()
        {
            Garage garage = new Garage();
            bool finish = false;
            string userChoice = null;
            string message = string.Format(
@"Welcome to the garage!
Please choose one of the following options:
1.Enter a new vehicle to the garage
2.Show vehicles's lisence number
3.Change a vehicle's status
4.Add the maximum air value to a vehicle
5.Refule a fuled vehicle
6.Charge an electric vehicle
7.Show a vehicle's data
8.Finish your visit in the garage"
                                        );
            do
            {
                Console.WriteLine(message);
                userChoice = Console.ReadLine();
                try
                 {
                    Console.Clear();
                    finish = ChooseMethod(garage, userChoice);
                 }
                 catch(Exception ex)
                 {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    waitToReturn();
                }
              
            } while (finish == false);
        }
        internal static bool ChooseMethod(Garage garage, string i_UserChoice)
        {
            bool finish = false;
            int userChoiceNumber;
            if (int.TryParse(i_UserChoice, out userChoiceNumber) == false)
            {
                throw new FormatException("You have to insert an *integer number* to describe which option you chose!");
            }
            else
            {
                switch (userChoiceNumber)
                {
                    case 1:
                        AddNewVehicleToGarage(garage);
                        break;
                    case 2:
                        ShowLisencePlatesIDInGarage(garage);
                        break;
                    case 3:
                        ChangeVehicleStatusInGarage(garage);
                        break;
                    case 4:
                        AddAMaxAirAmountVehicleWheels(garage);
                        break;
                    case 5:
                        RefuelVheicleInGarage(garage);
                        break;
                    case 6:
                        ChargeVehicleInGarage(garage);
                        break;
                    case 7:
                        ShowAllDataOfVehicleInGarage(garage);
                        break;
                    case 8:
                        finish = true;
                        break;
                    default:
                        throw new ArgumentException("You have to choose an integer number between 1 to 8.");
                }
                return finish;
            }
        }
        internal static void AddNewVehicleToGarage(Garage i_Garage)
        {
            string ownerName = null;
            string ownerPhoneNumber = null;
            string licensePlateID = null;
            licensePlateID = GetLicensePlateID(i_Garage, true);
            ownerName = GetOwnerName();
            ownerPhoneNumber = GetOwnerPhoneNumber();
            Vehicle newVehicle = CreateVehicle(i_Garage, licensePlateID);
            VehicleInGarage newVehicleInGarage = new VehicleInGarage(ownerName, ownerPhoneNumber, newVehicle);
            i_Garage.AddNewVehicle(licensePlateID, newVehicleInGarage);         
        }
        internal static Vehicle CreateVehicle(Garage i_Garage,string i_LicensePlate)
        {
            List<string> vehicleData = null;
            Vehicle newVehicle = null;
            try
            {
                string userChoice = GetUserChoice();
                 newVehicle = i_Garage.CreateNewVehicle(userChoice);
                newVehicle.LicensePlateID = i_LicensePlate;
                vehicleData = GetVehicleData();
                newVehicle.FillVehicleData(ref vehicleData);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                waitToReturn();
            }
            return newVehicle;
        }
        internal static List<string> GetVehicleData()
        {
            Console.Clear();
            List<string> data = new List<string>();
            string message = null;
            string input = null;
            message = VehiclesCreator.GettingDataMessage();
            Console.WriteLine(message);
            do
            {
                input = Console.ReadLine();
                data.Add(input);
            } while (input != k_EndString);
            Console.Clear();
            return data;
        }
        internal static void ShowLisencePlatesIDInGarage(Garage i_Garage)
        {
            string message = null;
            eVehicleStatus vehicleStatus;
            int counter = 0;
            vehicleStatus = GetVehicleStatus(i_Garage);
            message = string.Format("The license plate's ID of vehicle that {0} are:", vehicleStatus.ToString());
            Tuple<string, eVehicleStatus>[] lisencePlatesIdArray = i_Garage.GetLisencePlateID();
            foreach (Tuple<string, eVehicleStatus> element in lisencePlatesIdArray)
            {
                if (element.Item2 == vehicleStatus)
                {
                    Console.WriteLine(element.Item1);
                    counter++;
                }
            }
            if (counter == 0)
            {
                message = string.Format("No vehicles under the status {0} in the garage",  vehicleStatus.ToString());
                Console.WriteLine(message);
            }
            waitToReturn();
        }
        internal static void ChangeVehicleStatusInGarage(Garage i_Garage)
        {
            string lisencePlateID = GetLicensePlateID(i_Garage, false);
            eVehicleStatus vehicleStatus = GetVehicleStatus(i_Garage);
            i_Garage.ChangeVehicleStatus(lisencePlateID, vehicleStatus);
            waitToReturn();
        }
        internal static void AddAMaxAirAmountVehicleWheels(Garage i_Garage)
        {
            string licensePlateID = GetLicensePlateID(i_Garage, false);
            i_Garage.MakeAirPressureInVehicleMaximum(licensePlateID);
            waitToReturn();
        }
        internal static void RefuelVheicleInGarage(Garage i_Garage)
        {
            string licensePlateID = GetLicensePlateID(i_Garage, false);
            eFuelType fuelType = GetFuelType(i_Garage);
            Console.WriteLine("Choose amount to fuel to fill");
            float amountToFuel = GetFloatFromUser();
            i_Garage.RefuelVheicle(licensePlateID, amountToFuel, fuelType);
            waitToReturn();
        }
        internal static void ChargeVehicleInGarage(Garage i_Garage)
        {
            string licensePlateID = GetLicensePlateID(i_Garage, false);
            Console.WriteLine("Choose amount to minutes to add battery");
            float amountToCharge = GetFloatFromUser();
            amountToCharge /= 60;
            i_Garage.ChargeVehicle(licensePlateID, amountToCharge);
            waitToReturn();
        }
        internal static void ShowAllDataOfVehicleInGarage(Garage i_Garage)
        {
            string licensePlateID = GetLicensePlateID(i_Garage, false);
            List<string> dataList = i_Garage.VehiclesInGarage[licensePlateID].Vehicle.PullFullDataOfVehicle();
            foreach (var dataStr in dataList)
            {
                Console.WriteLine(dataStr);
                
            }
            waitToReturn();
        }
        private static void waitToReturn()
        {
            string returnString = null;
            Console.WriteLine("Press RETURN to return to main menu");
            do
            {
               returnString = Console.ReadLine();
            } while (returnString != k_ReturnString);
            Console.Clear();
        }
        internal static void MessageIfLicensePlateIDExistsAndChanged(string i_LicensePlateID)
        {
            string message = string.Format("Vehicle with license plate ID {0} status changed to under repair", i_LicensePlateID);
            Console.WriteLine(message);
            waitToReturn();
        }
    }
}
