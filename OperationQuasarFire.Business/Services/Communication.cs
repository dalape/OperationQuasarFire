using OperationQuasarFire.Business.Interfaces;

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
                    return coordinates;
            }

            return coordinates;
        }

    }
}
