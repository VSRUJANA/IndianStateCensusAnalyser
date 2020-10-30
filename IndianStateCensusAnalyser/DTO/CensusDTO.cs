using System;
using System.Collections.Generic;
using System.Text;
using IndianStateCensusAnalyser.POCO;

namespace IndianStateCensusAnalyser.DTO
{
    public class CensusDTO
    {
        public string state;
        public long population;
        public long area;
        public long density;
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        public CensusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }

        public CensusDTO(StateCodeDAO stateCodeDao)
        {
            this.serialNumber = stateCodeDao.serialNumber;
            this.stateName = stateCodeDao.stateName;
            this.tin = stateCodeDao.tin;
            this.stateCode = stateCodeDao.stateCode;
        }
    }
}



