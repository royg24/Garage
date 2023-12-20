using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }
        public Wheel ShallowClone()
        {
            return this.MemberwiseClone() as Wheel;
        }
        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
            set
            {
                m_MaxAirPressure = value;
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }
        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
        }
        public void AddAirPressure(float i_AmountOfAirToAdd)
        {
            if(m_CurrentAirPressure + i_AmountOfAirToAdd <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AmountOfAirToAdd;
            }
        }
        internal void ChangeAirPressureInWheel(float i_MaxAirPressure)
        {
            m_CurrentAirPressure = i_MaxAirPressure;
        }
    }
}
