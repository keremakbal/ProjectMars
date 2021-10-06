using Facade;
using System;

namespace ProjectMars
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionResult<IPlateauDTO> result;

            do
            {
                Console.WriteLine("Please enter the upper-right coordinates of the plateau. (For example:5 5)");
                string coordinates = Console.ReadLine();
                result = PlateauFacade.Current().Create(coordinates);
            } while (!result.IsSuccess);


            do
            {
                bool isRoverCreated;
                do
                {
                    Console.WriteLine("Please enter the rover's coordinates (X and Y) and direction. (For example:1 2 N)");
                    string roverCoordinates = Console.ReadLine();

                    var roverResult = RoverFacade.Current().Create(result.Response, roverCoordinates);

                    isRoverCreated = roverResult.IsSuccess;

                    if (!roverResult.IsSuccess)
                    {
                        Console.WriteLine(roverResult.Message);
                        continue;
                    }

                    var displayResult = PlateauFacade.Current().MissionResult(result.Response, "L");
                    if (displayResult.IsSuccess)
                    {
                        Console.Clear();
                        Console.WriteLine(displayResult.Response);
                    }


                    bool isDiscoveryFinished;
                    do
                    {
                        Console.WriteLine("Please enter the rover's discovery command series. (For example:LMLMLMLMM)");
                        string commandSeries = Console.ReadLine();

                        var discoveryResult = RoverFacade.Current().Explore(roverResult.Response, commandSeries);

                        isDiscoveryFinished = discoveryResult.IsSuccess;

                        if (!isDiscoveryFinished)
                        {
                            Console.WriteLine(discoveryResult.Message);
                            continue;
                        }

                        displayResult = PlateauFacade.Current().MissionResult(result.Response, "D");
                        if (displayResult.IsSuccess)
                        {
                            Console.Clear();
                            Console.WriteLine(displayResult.Response);
                        }

                    } while (!isDiscoveryFinished);

                } while (!isRoverCreated);

            } while (true);
        }
    }
}
