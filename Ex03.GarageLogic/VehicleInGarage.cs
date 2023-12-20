using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        underRepair = 1,
        wasFixed =  2,
        paidUp = 3
    }
    public class VehicleInGarage
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
       private  eVehicleStatus m_Status;
        private Vehicle m_Vehicle;
        public VehicleInGarage(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            OwnerName = i_OwnerName;
            OwnerPhone = i_OwnerPhone;
            Vehicle = i_Vehicle;
            m_Status = eVehicleStatus.underRepair;
        }

        public string OwnerName
        {
            get 
            { 
                return m_OwnerName; 
            }
            set
            {
                m_OwnerName = value;
            }
        }
    public string OwnerPhone
        {
            get 
            { 
                return m_OwnerPhone;
            }
            set
            {
                m_OwnerPhone = value;
            }
        }
        public eVehicleStatus VehicleStatus
        {
            get
            { 
                return m_Status;
            }
            set
            {
                m_Status = value;
            }
        }
        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }
    }
}
