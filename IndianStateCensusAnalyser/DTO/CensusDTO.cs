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

        public CensusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }
    }
}



