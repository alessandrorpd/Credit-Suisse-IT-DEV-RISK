using Credit_Suisse;

class MainProgram
{
    static void Main(string[] args)
    {
        // The Input String 
        string entry = "12/11/2020\n4\n2000000 Private 12/29/2025\n400000 Public 07/01/2020\n5000000 Public 01/02/2024\n3000000 Public 10/26/2023";
        
        //Calling the method to read the entry string... could be a file... but it is a string in this solution
        readInput(entry);        

        }

    // This method reads the entry and extract each one of the necessary data for the classification
    private static void readInput(String sInput)  {

        string[] input = { };

        List<string> list = new List<string>();


        // Reading each line to parse later
        using (StringReader reader = new StringReader(sInput))
        {
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                list.Add(line);
            }
            input = list.ToArray();
        }

        Trade tr1 = new Trade();

        // Getting the reference date
        if (DateTime.TryParse(input[0], null, System.Globalization.DateTimeStyles.None, out DateTime result))
        {
            tr1.RefDate = (result);
        }

        //the data to classify starts in the 3nd position of the input, as described in the problem
        for (int i = 2; i < input.Length; i++)
        {
            //separating everything by space
            string[] words = input[i].Split(' ');
            for (int j = 0; j < 3; j++)
            {
                // Getting the amount
                tr1.TradeAmount = Convert.ToDouble(words[0]);
                // Getting the Client Sector
                tr1.ClientSector = words[1];
                // Getting the Next Pending Payment
                if (DateTime.TryParse(words[2], null, System.Globalization.DateTimeStyles.None, out DateTime result2))
                {
                    tr1.NextPendingPayment = (result2);
                }

            }
            // calling the method to print the classification... the classification is made in the class Trade, in the method Classify
            printClassification(tr1.Classify());
            
        }
    }

    // method to print the output
    private static void printClassification(string outPut)
    {
        Console.WriteLine(outPut);
    }
}