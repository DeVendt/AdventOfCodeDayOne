namespace AdventOfCodeDayOne
{
    public class DepthMeasureMentsHelper
    {
        /// <summary>
        /// All returned measurements from AdventOfCode.com website
        /// </summary>
        private List<int> DepthMeasurements { get; set; }

        public async Task WorkOnDayOne(string filePath)
        {
            // lets load data first.
            await this.GetDepthMeasurements(filePath);

            // log all data that is bigger than its previous value;
            FindAllBiggerThanLastMeasurements();
            Console.WriteLine("\n We retrieved data from a file, checked it, worked on it and now we are finished.");
            Console.WriteLine("\n This should be the end of AdventOfCode day 1.");
        }

        /// <summary>
        /// Get all depths measurements according to the AdventOfCode website input.
        /// </summary>
        /// <returns></returns>
        public async Task GetDepthMeasurements(string filePath)
        {
            // check if we have a url
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("\n filePath is either null or empty");
                return;
            }

            // if file not exists just return no need to continue.
            if (!System.IO.File.Exists(filePath))
            {
                Console.Write("\n File couldnt be found.");
                return;
            }

            // Lets look if we can convert this data.
            List<int> aOCData;
            try
            {
                aOCData = CastToInt(System.IO.File.ReadAllLines(filePath, Encoding.UTF8));

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occured: {e.Message}");
                return;
            }

            // if its not null lets set the data
            if (aOCData is not null)
                DepthMeasurements = aOCData;

            return;
        }

        private List<int> CastToInt(string[] listOfMeasurements)
        {
            var list = new List<int>();

            foreach (var measurement in listOfMeasurements)
            {
                if (int.TryParse(measurement, out int intMeasurement))
                {
                    list.Add(intMeasurement);
                }
            }

            return list;
        }

        private int itemsBigger { get; set; } = 0;
        private int itemsSmaller { get; set; } = 0;
        public void FindAllBiggerThanLastMeasurements()
        {
            if (!DepthMeasurements.Any())
            {
                Console.WriteLine("No measurements found.");
                return;
            }

            int itemBefore;
            int currentItem;
            // lets start at 1 and loop over all DepthMeasurements
            for (int i = 1; i < DepthMeasurements.Count; i++)
            {
                // find the before and current item.
                itemBefore = DepthMeasurements[i - 1];
                currentItem = DepthMeasurements[i];

                if (currentItem > itemBefore)
                {
                    itemsBigger++;
                    continue;
                }

                itemsSmaller++;
            }

            Console.WriteLine($"\n\n Items bigger than previous items: {itemsBigger}");
            Console.WriteLine($"\n Items smaller than previous: {itemsSmaller}");
        }
    }
}
