using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_MaxValue;
        protected float m_CurrentValue;
        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }
        public float CurrentValue
        {
            get
            {
                return m_CurrentValue;
            }
        }
        protected Engine(string i_MaxValue, float i_CurrentValue)
        {
            fillEngineData(i_MaxValue, i_CurrentValue);
        }
        internal void AddValue(float i_Value)
        {
            if (m_CurrentValue + i_Value <= m_MaxValue)
            {
                m_CurrentValue += i_Value;
            }
            else
            { 
                throw new ValueOutOfRangeException(i_Value,  "Current value in the engine");
            }
        }
        protected void fillEngineData(string i_CurrentValue, float i_MaxValue)
        {
            float currentValue;
            if (float.TryParse(i_CurrentValue, out currentValue) == false)
            {
                throw new FormatException("The format of the argument is incorrect. It should be a real number represents current value of engine");
            }
            else
            {
                if (currentValue > i_MaxValue)
                {
                    throw new ValueOutOfRangeException(currentValue, "current value in the engine");
                }
                else
                {
                    m_MaxValue = i_MaxValue;
                    m_CurrentValue = currentValue;
                }
            }
        }
        public string CreateStrDataForElectricEngine()
        {
            string dataStr = string.Format(
@"Remaining battery time : {0} hours
Maximum battery time: {1} hours
", this.CurrentValue, this.MaxValue);
            return dataStr;
        }
        public string CreatStrDataForFuelEngine()
        {
            string dataStr = string.Format(
@"Current fuel Amount: {0}
Maximun fuel Amount: {1}
", this.CurrentValue, this.MaxValue);
            return dataStr;
        }
    }
}
