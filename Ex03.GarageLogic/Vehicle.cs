using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LisencePlateID;
        protected float m_PrecentageOfEnergyLeft;
        protected Wheel[] m_Wheels;
        protected Engine m_Engine;
        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }
        public string LicensePlateID
        {
            get
            {
                return m_LisencePlateID;
            }
            set
            {
                if(m_LisencePlateID == null)
                {
                    m_LisencePlateID = value;
                }
            }
        }
        public Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }
        }
        public virtual void FillVehicleData(ref List<string> io_Data)
        {
            m_ModelName = io_Data[0];
            fillPrecentageOfEnergyLeft(io_Data[1]);
            io_Data = io_Data.Skip(2).ToList();
        }
        private void fillPrecentageOfEnergyLeft(string i_PrecentageOfEnergyLeft)
        {
            float precenatgeOfEnergyLeft;
            if(float.TryParse(i_PrecentageOfEnergyLeft, out precenatgeOfEnergyLeft) == true)
            {
                if((precenatgeOfEnergyLeft >= 0) && (precenatgeOfEnergyLeft <= 100))
                {
                    m_PrecentageOfEnergyLeft = precenatgeOfEnergyLeft;
                }
                else
                {
                    throw new ArgumentException("Incorrect Argument. Precentage of energy left should be between 0 to 100 ");
                }
            }
            else
            {
                throw new FormatException("Incoreect format. Precentage of energy left bshould be a real number");
            }
        }
        protected Wheel[] FillWheelsData(string i_ManufacturerName, string i_CurrentAirPressure, int i_NumOfWheels, float i_MaxAirPressure)
        {
            float currentAirPressure;
            if (float.TryParse(i_CurrentAirPressure, out currentAirPressure) == false)
            {
                throw new FormatException("The format is incorrect. It should be a real number which represents the current air pressure.");
            }
            else if (currentAirPressure > i_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(currentAirPressure, "current air pressure");
            }
            else
            {
                Wheel[] wheels = new Wheel[i_NumOfWheels];
                Wheel wheel = new Wheel(i_ManufacturerName, currentAirPressure, i_MaxAirPressure);
                for (int i = 0; i < i_NumOfWheels; i++)
                {
                    wheels[i] = wheel.ShallowClone();
                }
                return wheels;
            }
        }
        internal void ChangeAirPressure(float i_MaxAirPressure)
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.ChangeAirPressureInWheel(i_MaxAirPressure);
            }
        }
        private List<string> PullDataOfVehicleWheels()
        {
            List<string> dataList = new List<string>() ;
            string dataStr;
            for(int i = 0; i < m_Wheels.Length; i++)
            {
                dataStr = string.Format(
@"wheel number {0} :
Manufacturer name: {1}
Current Air Pressure: {2}
Max air Pressure {3}", i + 1, m_Wheels[i].ManufacturerName, m_Wheels[i].CurrentAirPressure, m_Wheels[i].MaxAirPressure);
                
                dataList.Add(dataStr);
                   
            }
            return dataList;      
        }  
        public virtual List<string> PullFullDataOfVehicle()
        {
            List<string> vehicleData;
            vehicleData = (PullDataOfVehicleWheels());
            string dataStr = string.Format(
@"The Data of the vehicle whose license plate ID is {0} :  
Model Name: {1}
Precentage of energy left: {2}
 ", m_LisencePlateID, m_ModelName, m_PrecentageOfEnergyLeft);
            vehicleData.Add(dataStr);
            return vehicleData;
        }
        
        public static string ShowNecessaryDataForvehicle()
        {
            string message = 
@"for every vehicle:
    1. Vehicle's model.
    2. Presentage of energy left.";
            return message;
        }
        public static string ShowNecessaryMessageForWheels()
        {
            string message = 
@"for every vehicle:
    1. Wheels manufacturer Name.
    2. Wheels current air pressure.";
            return message;
        }
    }
}