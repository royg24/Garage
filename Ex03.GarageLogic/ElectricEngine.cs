using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        internal ElectricEngine(string i_HoursLeftInBattery, float i_MaxHoursInBattery) : base(i_HoursLeftInBattery, i_MaxHoursInBattery)
        {
            
        }
        internal void ChargeBattery(float i_HoursToAddToBattery)
        {
            AddValue(i_HoursToAddToBattery);
        }
        public static string ShowNecessaryMessageForElectricEngine()
        {
            string message = 
@"for a vehicle with an electric engine:
    1. Vehicle's current hours left in the battery.";
            return message;
        }
    }
}
