using OperationQuasarFire.Business.Interfaces;
using OperationQuasarFire.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Services
{
    public class Utils : IUtils
    {
        private readonly ICommunication _communication;
        private static readonly string path = "./SateliteInformation.txt";
        public Utils(ICommunication communication) => _communication = communication;

        public float[] CalculatePosition(List<Satelite> satellites)
        {
            float[] finallyCoordinates = new float[2];
            float[][] satelliteCoordinates = new float[3][];
            int count = 0; 
            foreach(Satelite satelite in satellites)
                satelliteCoordinates[count++] = _communication.CoordinatesByName(satelite.Name);

            float xCoordinateBetweenSatelliteOneTwo = CalculateCoordinatesbetweenSatellites(satelliteCoordinates[0][0], satelliteCoordinates[1][0]);
            float yCoordinateBetweenSatelliteOneTwo = CalculateCoordinatesbetweenSatellites(satelliteCoordinates[0][1], satelliteCoordinates[1][1]);
            float xCoordinateBetweenSatelliteTwoThree = CalculateCoordinatesbetweenSatellites(satelliteCoordinates[1][0], satelliteCoordinates[2][0]);
            float yCoordinateBetweenSatelliteTwoThree = CalculateCoordinatesbetweenSatellites(satelliteCoordinates[1][0], satelliteCoordinates[2][0]);
            float distanceDifferenceBetweenSatelliteOneTwo = CalculateDistanceSector(satellites[0].Distance, satellites[1].Distance,
                                                             satelliteCoordinates[0][0], satelliteCoordinates[0][1], satelliteCoordinates[1][0],
                                                             satelliteCoordinates[1][1]);
            float distanceDifferenceBetweenSatelliteTwoThree = CalculateDistanceSector(satellites[1].Distance, satellites[2].Distance,
                                                             satelliteCoordinates[1][0], satelliteCoordinates[1][1], satelliteCoordinates[2][0],
                                                             satelliteCoordinates[2][1]);

            finallyCoordinates[0] = CalculateCoordinateX(xCoordinateBetweenSatelliteOneTwo, yCoordinateBetweenSatelliteOneTwo, distanceDifferenceBetweenSatelliteOneTwo,
                                    xCoordinateBetweenSatelliteTwoThree, yCoordinateBetweenSatelliteTwoThree, distanceDifferenceBetweenSatelliteTwoThree);
            finallyCoordinates[1] = CalculateCoordinateY(xCoordinateBetweenSatelliteOneTwo, yCoordinateBetweenSatelliteOneTwo, distanceDifferenceBetweenSatelliteOneTwo,
                                    xCoordinateBetweenSatelliteTwoThree, yCoordinateBetweenSatelliteTwoThree, distanceDifferenceBetweenSatelliteTwoThree);

            return finallyCoordinates;
        }

        public string CreateMessage(List<Satelite> satellites)
        {
            string[] MessagePart = new string[5];
            foreach (Satelite satelite in satellites)
            {
                for (int i = 0; i < satelite.Message.Length; i++)
                {
                    if (!string.IsNullOrEmpty(satelite.Message[i]))
                    {
                        MessagePart[i] = satelite.Message[i];
                    }
                }
            }

            return string.Join(" ", MessagePart);
        }

        private static float CalculateCoordinatesbetweenSatellites(float coordinateOne, float coordinateTwo)
        { 
            return (-2 * (coordinateOne) + 2 * (coordinateTwo)); 
        }

        private static float CalculateDistanceSector(float distanceOne, float distanceTwo, float coordinateOneX, float coordinateOneY, float coordinateTwoX, float coordinateTwoY)
        {
            return (float)(Math.Pow(distanceOne, 2) - Math.Pow(distanceTwo, 2) - Math.Pow(coordinateOneX, 2) + Math.Pow(coordinateTwoX, 2) - Math.Pow(coordinateOneY, 2) + Math.Pow(coordinateTwoY, 2));
        }

        private static float CalculateCoordinateX(float u, float v, float w, float x, float y, float z)
        {
            return ((w * y - z * v) / (y * u - v * x));
        }

        private static float CalculateCoordinateY(float u, float v, float w, float x, float y, float z)
        {
            return ((w * x - u * z) / (v * x - u * y));
        }

        public async Task<List<Satelite>> ReadInformationFromFile()
        {
            if (File.Exists(path))
            {
                List<Satelite> satellites = JsonSerializer.Deserialize<List<Satelite>>(await File.ReadAllTextAsync(path));

                return satellites;
            }
            else
                return new List<Satelite>();
        }

        public async Task WriteInformationInFile(List<Satelite> satellites)
        {
            using StreamWriter writer = new(path);
            await writer.WriteAsync(JsonSerializer.Serialize<List<Satelite>>(satellites));
        }

        public void DeleteFile()
        {
            File.Delete(path);
        }

    }
}
