using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        Exception m_InnerException;
        float m_OutOfRangeValue;
        string m_ValueRepresententation;
        public float OutOfRangeValue
        {
            get
            {
                return m_OutOfRangeValue;
            }

        }
        public string ValueRepresentation
        {
            get
            {
                return m_ValueRepresententation;
            }
        }
       

        public ValueOutOfRangeException(float i_Value, string i_Representation, Exception i_InnerException = null)
            : base(string.Format("an error occured while using the value {0} which represents {1}. \n Its not in the desired value range ", i_Value, i_Representation), i_InnerException)
        {
            m_OutOfRangeValue = i_Value;
            m_ValueRepresententation = i_Representation;
            m_InnerException = i_InnerException;

        }  
    }
}
