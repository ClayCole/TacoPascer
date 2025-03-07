﻿namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(','); // basically read the line and once a comma appears it spilts it and put into a array, (which will be called cells)

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)   // This will turn the TacoBell US into three arrays - "34.0098" , "67.0098" , "TacoBell Huntervilles"
            {
                // Log that and return null
                logger.LogWarning("Less than three items. need more info.");

                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            var latitude = double.Parse(cells[0]); 

            // grab the longitude from your array at index 1
            var longitude = double.Parse(cells[1]);

            // grab the name from your array at index 2
            var name = cells[2];

            // Your going to need to parse your string as a `double` - done 
            // which is similar to parsing a string as an `int` - done

            // You'll need to create a TacoBell class - done 
            // that conforms to ITrackable - done 

            // Then, you'll need an instance of the TacoBell class- done
            // With the name and point set correctly - done

            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;

            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable - All you do is change null to TacoBell

            return tacoBell;
        }

    }
}