using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        // Header in Indian state Census csv file
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        // Indian State Census Csv file path
        static string indianStateCensusFilePath = @"C:\Users\sajju2002\source\repos\CensusAnalyserDemo\CensusAnalyserTest\CSV Files\IndiaStateCensusData.csv";
        // Wrong delimiter 
        static string delimiterIndianStateCensusFilePath = @"C:\Users\sajju2002\source\repos\CensusAnalyserDemo\CensusAnalyserTest\CSV Files\DelimiterIndiaStateCensusData.csv";
        // Wrong File Path
        static string wrongIndianStateCensusFilePath = @"C:\Users\sajju2002\source\repos\CensusAnalyserDemo\CensusAnalyserTest\CSV Files\WrongPath.csv";
        // Wrong File Type
        static string wrongIndianStateCensusFileType = @"C:\Users\sajju2002\source\repos\CensusAnalyserDemo\CensusAnalyserTest\CSV Files\IndiaStateCensusData.txt";
        // Wrong Header
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\sajju2002\source\repos\CensusAnalyserDemo\CensusAnalyserTest\CSV Files\WrongIndiaStateCensusData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}