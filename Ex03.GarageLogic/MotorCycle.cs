using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public enum eLisenceType
    {
        A1,
        A2,
        AA,
        B1
    }
    public abstract class MotorCycle : Vehicle
    {
        protected eLisenceType m_LisenceType;
        protected int m_EngineVolume;
        public override void FillVehicleData(ref List<string> io_Data)
        {
            base.FillVehicleData(ref io_Data);
            fillLisenceType(io_Data[0]);
            fillEngineVolume(io_Data[1]);
            io_Data = io_Data.Skip(2).ToList();
        }
        private void fillLisenceType(string i_LisenceType)
        {
            if(Enum.TryParse(i_LisenceType, true, out m_LisenceType) == false)
            {
                throw new FormatException("Incorrect Format. lisence type is not suitable to the format");
            }
        }
        private void fillEngineVolume(string i_EngineVolume)
        {
            if(int.TryParse(i_EngineVolume, out m_EngineVolume) == false)
            {
                throw new FormatException("Incorrect Format. Engine volume should be an integer number ");
            }
        }
        public override List<string> PullFullDataOfVehicle()
        {
            List<string> motorCycleData = base.PullFullDataOfVehicle();
            string dataStr = string.Format(@"
Lisence type: {0}
Engine Voulume: {1} ", m_LisenceType.ToString(), m_EngineVolume);
            motorCycleData.Add(dataStr);
            return motorCycleData;
        }
        public static string ShowNecessaryMessageForMotorcycle()
        {
            string message = 
@"for a motorcycle:
    1. Lisence type ( type 1 for A1, 2 for A2,  3 for AA, or 4 for B1).
    2. Engine volume.";
            return message;
        }
    }
}
