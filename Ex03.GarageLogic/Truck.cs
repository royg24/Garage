using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const string k_PositiveAnswer = "Y";
        private const string k_NegativeAnswer = "N";
        private const int k_NumOfWheels = 14;
        private const float k_MaxAirPressure = 26f;
        private const float k_MaxFuelAmount = 135f;
        private bool m_IsDeliverDangerousSubstance;
        private int m_CargoVolume;
        
        public override void FillVehicleData(ref List<string> io_Data)
        {
            base.FillVehicleData(ref io_Data);
            fillDangerousSubstanceStatus(io_Data[0]);
            fillCargoVolume(io_Data[1]);
            m_Wheels = FillWheelsData(io_Data[2], io_Data[3], k_NumOfWheels, k_MaxAirPressure);
            m_Engine = new FueledEngine(io_Data[4], k_MaxFuelAmount, eFuelType.Soler);
            io_Data = io_Data.Skip(2).ToList();
        }
        private void fillDangerousSubstanceStatus(string i_Answer)
        {
            if(i_Answer == k_PositiveAnswer)
            {
                m_IsDeliverDangerousSubstance = true;
            }
            else if(i_Answer == k_NegativeAnswer)
            {
                m_IsDeliverDangerousSubstance= false;
            }
            else
            {
                throw new FormatException("Incorrect Format. It should be In this format: Y or N ");
            }
        }
        private void fillCargoVolume(string i_CargoVolume)
        {
            if (int.TryParse(i_CargoVolume, out m_CargoVolume) == false)
            {
                throw new FormatException("Incorrect Format. cargo valume should be an integer number.");
            }
        }
        public override List<string> PullFullDataOfVehicle()
        {
            List <string> dataList = base.PullFullDataOfVehicle();
            string dataStr = m_Engine.CreatStrDataForFuelEngine();
            dataList.Add(dataStr);
            dataStr = string.Format("Is this truck deliver dangerous substance? : {0} \n Cargo Valume: {1}", m_IsDeliverDangerousSubstance, m_CargoVolume);
            dataList.Add(dataStr);
            return dataList;
        }
        public static string ShowNecessaryMessageForTruck()
        {
            string message = 
@"for a truck:
    1. is it delivers a dangerous substance (Y/N).
    2. Cargo volume.";
            return message;
        }
    }
}
