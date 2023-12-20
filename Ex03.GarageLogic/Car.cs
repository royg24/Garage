using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public enum eNumOfDoors
    {
        two = 2,
        three = 3,
        four = 4,
        five = 5
    }
    public enum eColor
    {
        white = 1,
        black = 2,
        yellow = 3,
        red = 4
    }
    public abstract class Car : Vehicle
    {
        protected eColor m_CarColor;
        protected eNumOfDoors m_NumOfDoors;
        public eNumOfDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }         
        }
        public eColor CarColor
        {
            get
            {
                return m_CarColor;
            }
        }
        public override void FillVehicleData(ref List<string> io_Data)
        {
            base.FillVehicleData(ref io_Data);
            fillCarColor(io_Data[0]);
            fillNumberOfDoors(io_Data[1]);
            io_Data = io_Data.Skip(2).ToList();
        }
        private void fillCarColor(string i_CarColor)
        {
            if(Enum.TryParse(i_CarColor, true, out m_CarColor) == false)
            {
                throw new ArgumentException("Incorrect argument. car color is not suitable");
            }
        }
        private void fillNumberOfDoors(string i_NumberOfDoors)
        {
            if (Enum.TryParse(i_NumberOfDoors, true, out m_NumOfDoors) == false)
            {
                throw new ArgumentException("Incorrect argument. numbers of doors is not suitable");
            }
        }
        public override List<string> PullFullDataOfVehicle()
        {
            List<string> carData = base.PullFullDataOfVehicle();
            string dataStr = string.Format(@"
number of doors: {0}
color: {1} ", m_NumOfDoors, CarColor);
            carData.Add(dataStr);
            return carData;
        }
        public static string ShowNecessaryDataForCar()
        {
            string message = 
@"for a car:
    1. Car's color (type 1 for white, 2 for black, 3 for yellow or 4 for red).
    2. Number of doors (2, 3, 4 or 5).";
            return message;
        }
    }
}
