namespace Tests
{
    using System;
    using Numaka.VinValidator;

    class Program
    {
        static void Main(string[] args)
        {
	        //string vin = "1VWBP7A37DC046870";
	        //string vin = "12345678901234567";

            string vin = args.Length > 0 ? args[0] : string.Empty;

            if (string.IsNullOrWhiteSpace(vin))
            {
                Console.WriteLine("VIN not provided");
                return;
            }

            var validationResult = VinValidator.Validate(vin);
            
            Console.WriteLine($"VIN Provided:     {vin}");
	        Console.WriteLine($"Is Valid:         {validationResult.IsValid}");
            Console.WriteLine($"Validation Error: {validationResult.Error}");
        }
    }
}
