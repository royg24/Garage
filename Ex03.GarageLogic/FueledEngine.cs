using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }
    public class FueledEngine : Engine
    {
        private eFuelType m_FuelType;
        internal FueledEngine(string i_CurrentFuelAmount, float i_MaxFuelAmount, eFuelType i_FuelType) : base(i_CurrentFuelAmount, i_MaxFuelAmount)
        {
            m_FuelType = i_FuelType;
        }
        internal void ToFuel(float i_AmountOfFuelToAdd , eFuelType i_FuelType)
        {
            if(i_FuelType == m_FuelType)
            {
                AddValue(i_AmountOfFuelToAdd);
            }
            else
            {
                throw new ArgumentException("Incorrect argument. The fuel type is not suitable");
            }
        }
        public static string ShowNecessaryMessageForFueledEngine()
        {
            string message = 
@"for a vehicle with a fuled engine
    1. Vehicle' current fuel amount.";
            return message;
        }
    }
}
