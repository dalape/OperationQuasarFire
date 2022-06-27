using OperationQuasarFire.Business.Interfaces;
using System;

namespace OperationQuasarFire.Business.Services
{
    public class Communication: ICommunication
    {
        public float[] CoordinatesByName(string sateliteName)
        {
            float[] coordinates = new float[2];
            switch(sateliteName.ToLower())
            {
                case "kenobi":
                    coordinates[0] = -500;
                    coordinates[1] = -200;
                    break;
                case "skywalker":
                    coordinates[0] = 100;
                    coordinates[1] = -100;
                    break;
                case "sato":
                    coordinates[0] = 500;
                    coordinates[1] = 100;
                    break;
                default:
                    throw new CommunicationException($"No se encuentra el satélite {sateliteName}");
            }

            return coordinates;
        }

        public bool ValidateSateliteName(string sateliteName)
        {
            return sateliteName.ToLower() switch
            {
                "kenobi" => true,
                "skywalker" => true,
                "sato" => true,
                _ => throw new CommunicationException($"No se encuentra el satélite {sateliteName}"),
            };
        }

        public float[] GetLocation(float distance)
        {
            float[] coordinates = new float[2];

            switch (distance)
            {
                //Kenobi
                case 100.0F:
                    coordinates[0] = -500;
                    coordinates[1] = -200;
                    break;
                //Skywalker
                case 115.5F:
                    coordinates[0] = 100;
                    coordinates[1] = -100;
                    break;
                //Sato
                case 142.7F:
                    coordinates[0] = 500;
                    coordinates[1] = 100;
                    break;
                default:
                    throw new CommunicationException($"No se encuentra el satélite por la distancia {distance}");
            }

            return coordinates;
        }

        public string GetMessage(string[] messages)
        {
            return string.Join(' ', messages);
        }

    }

    public class CommunicationException : Exception
    {
        public CommunicationException(string message) : base(message)
        {
        }
    }
}
