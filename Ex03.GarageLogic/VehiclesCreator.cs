using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
namespace Ex03.GarageLogic
{
    public class VehiclesCreator
    {
        private String[] m_VehiclesArray = { "Electric car", "Electric motorcycle", "Fuled car", "Fuled motorcycle", "Truck" };
        public Vehicle CreateVehicle(string i_UserChoice)
        {
            int userChoiceNumber;
            if(int.TryParse(i_UserChoice, out userChoiceNumber) == false)
            {
                throw new FormatException("Incorrect format! It should be an integer that represents one of the options.");
            }
            Vehicle result;
            if(userChoiceNumber == 1)
            {
                result = new ElectricCar();
            }
            else if(userChoiceNumber == 2)
            {
                result = new ElectricMotorCycle();
            }
            else if(userChoiceNumber == 3)
            {
                result = new FueledCar();
            }
            else if(userChoiceNumber == 4)
            {
                result = new FueledMotorcycle();
            }
            else if(userChoiceNumber == 5) 
            {
                result = new Truck();
            }
            else
            {
                int vehiclesArraySize = m_VehiclesArray.Length;
                throw new ArgumentException(string.Format("Incorrect argument. It should be an integer number between 1 to {0}", vehiclesArraySize)); 
            }
            return result;
        }
        public String[] VehiclesArray
        {
            get
            {
                return m_VehiclesArray;
            }
        }
        public static string GettingDataMessage()
        {
            string message = null;
            message = string.Format(
@"Please enter your vehicle's data in the following order:
{0}

according to vehicle's type:
{1}
{2}
{3}

{4}

according to vehicle's engine type:
{5}
{6}

Please write END when you finish put the data."
                , Vehicle.ShowNecessaryDataForvehicle(), Car.ShowNecessaryDataForCar(), MotorCycle.ShowNecessaryMessageForMotorcycle(),
Truck.ShowNecessaryMessageForTruck(), Vehicle.ShowNecessaryMessageForWheels(), FueledEngine.ShowNecessaryMessageForFueledEngine(), ElectricEngine.ShowNecessaryMessageForElectricEngine());
            return message;
        }
    }
}
