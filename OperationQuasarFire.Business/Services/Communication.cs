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

    }

    public class CommunicationException : Exception
    {
        public CommunicationException(string message) : base(message)
        {
        }
    }
}
