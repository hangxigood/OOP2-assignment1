using System.Collections;
using System.Runtime.CompilerServices;
using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.WriteLine("Enter the item number of an Appliance:");
            // Create long variable to hold item number
            // Get user input as string and assign to variable.
            // Convert user input from string to long and store as item number variable.
            long itemNumber = Convert.ToInt64(Console.ReadLine());
            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)
            Appliance? foundAppliance = null;
            // Loop through Appliances
            foreach ( var applicance in Appliances ) {
                // Test appliance item number equals entered item number
                if (applicance.ItemNumber == itemNumber) {
                    // Assign appliance in list to foundAppliance variable
                    foundAppliance = applicance;
                    // Break out of loop (since we found what need to)
                    break;
                }
            }
            // Test appliance was not found (foundAppliance is null)
            if( foundAppliance == null) {
                // Write "No appliances found with that item number."
                Console.WriteLine("No appliances found with that item number.\n");
            }
            // Otherwise (appliance was found)
            else {
                // Test found appliance is available
                if( foundAppliance.IsAvailable ) {
                    // Checkout found appliance
                    foundAppliance.Checkout();
                    // Write "Appliance has been checked out."
                    Console.WriteLine("Appliance has been checked out.\n");
                }
                // Otherwise (appliance isn't available)
                else {
                    // Write "The appliance is not available to be checked out."
                    Console.WriteLine("The appliance is not available to be checked out.\n");
                }
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.WriteLine( "Enter brand to search for:");
            // Create string variable to hold entered brand
            // Get user input as string and assign to variable.
            string brand = Console.ReadLine();
            // Create list to hold found Appliance objects
            List<Appliance> found = new();
            // Iterate through loaded appliances
            foreach( var appliance in Appliances) {
                // Test current appliance brand matches what user entered
                if( appliance.Brand == brand ) {
                    // Add current appliance in list to found list
                    found.Add(appliance);
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options:");
            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");
            // Write "Enter number of doors: "
            Console.WriteLine("Enter number of doors: ");
            // Create variable to hold entered number of doors
            // Get user input as string and assign to variable
            // Convert user input from string to int and store as number of doors variable.
            int numberOfDoors = Convert.ToInt32(Console.ReadLine());
            // Create list to hold found Appliance objects
            List<Appliance> found = new();
            // Iterate/loop through Appliances
            foreach( var appliance in Appliances) {
                // Test that current appliance is a refrigerator
                if( appliance is Refrigerator ) {
                    // Down cast Appliance to Refrigerator
                    Refrigerator refrigerator = (Refrigerator) appliance;
                    // Test user entered 0 or refrigerator doors equals what user entered.
                    if ( numberOfDoors == 0 || refrigerator.Doors == numberOfDoors) {
                        // Add current appliance in list to found list
                        found.Add(refrigerator);
                }
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options:");
            // Write "0 - Any"
            // Write "1 - Residential"
            // Write "2 - Commercial"
            // Write "Enter grade:"
            Console.WriteLine("0 - Any\n1 - Residential\n2 - Commercial\nEnter grade:");
            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();
            // Create grade variable to hold grade to find (Any, Residential, or Commercial)
            string grade = "";
            switch(userInput) {
                // Test input is "0"
                // Assign "Any" to grade
                case "0":
                grade = "Any";
                break;
                // Test input is "1"
                // Assign "Residential" to grade
                case "1":
                grade = "Residential";
                break;
                // Test input is "2"
                // Assign "Commercial" to grade
                case "2":
                grade = "Commercial";
                break;
                // Otherwise (input is something else)
                // Write "Invalid option."
                default:
                Console.WriteLine("Invalid option.");
                // Return to calling (previous) method
                return;
            }

            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"
            // Write "Enter voltage:"
            Console.WriteLine("Possible options:\n0 - Any\n1 - 18 Volt\n2 - 24 Volt\nEnter voltage:");
            // Get user input as string
            // Create variable to hold voltage
            string voltageInput = Console.ReadLine();
            int voltage = 0;
            switch (voltageInput) {
                // Test input is "0"
                // Assign 0 to voltage
                case "0":
                voltage = 0;
                break;
                // Test input is "1"
                // Assign 18 to voltage
                case "1":
                voltage = 18;
                break;
                // Test input is "2"
                // Assign 24 to voltage
                case "2":
                voltage = 24;
                break;
                // Otherwise
                // Write "Invalid option."
                default:
                Console.WriteLine("Invalid option.");
                // Return to calling (previous) method
                return;
            }
            // Create found variable to hold list of found appliances.
            List<Appliance> found = new();
            // Loop through Appliances
            foreach( var appliance in Appliances) {
                // Check if current appliance is vacuum
                if( appliance is Vacuum ) {
                    // Down cast current Appliance to Vacuum object
                    // Vacuum vacuum = (Vacuum)appliance;
                    Vacuum vacuum = (Vacuum)appliance;
                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                    if ( grade == "Any" || vacuum.Grade == grade && ( voltage == 0 || vacuum.BatteryVoltage == voltage )) {
                        // Add current appliance in list to found list
                        found.Add(vacuum);
                    }
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"
            // Write "Enter room type:"
            Console.WriteLine("Possible options:\n0 - Any\n1 - Kitchen\n2 - Work site\nEnter room type:");
            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();
            // Create character variable that holds room type
            char roomType ;
            switch(userInput) {
                // Test input is "0"
                case "0":
                // Assign 'A' to room type variable
                roomType = 'A';
                break;
                // Test input is "1"
                case "1":
                // Assign 'K' to room type variable
                roomType = 'K';
                break;
                // Test input is "2"
                case "2":
                // Assign 'W' to room type variable
                roomType = 'W';
                break;
                default:
                // Otherwise (input is something else)
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling method
                return;
            }
            // Create variable that holds list of 'found' appliances
            List<Appliance> found = new();
            // Loop through Appliances
            foreach( var appliance in Appliances) {
                // Test current appliance is Microwave
                if( appliance is Microwave ) {
                    // Down cast Appliance to Microwave
                    Microwave microwave = (Microwave)appliance;
                    // Test room type equals 'A' or microwave room type
                    if( roomType == 'A' || microwave.RoomType == roomType) {
                        // Add current appliance in list to found list
                        found.Add(microwave);
                    }
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"
            // Write "Enter sound rating:"
            Console.WriteLine("Possible options:\n0 - Any\n1 - Quietest\n2 - Quieter\n3 - Quiet\n4 - Moderate\nEnter sound rating:");
            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();
            // Create variable that holds sound rating
            string soundRating = "";
            switch( userInput ) {
                // Test input is "0"
                case "0":
                // Assign "Any" to sound rating variable
                soundRating = "Any";
                break;
                // Test input is "1"
                case "1":
                // Assign "Qt" to sound rating variable
                soundRating = "Qt";
                break;
                // Test input is "2"
                case "2":
                // Assign "Qr" to sound rating variable
                soundRating = "Qr";
                break;
                // Test input is "3"
                case "3":
                // Assign "Qu" to sound rating variable
                soundRating = "Qu";
                break;
                // Test input is "4"
                case "4":
                // Assign "M" to sound rating variable
                soundRating = "M";
                break;
                // Otherwise (input is something else)
                default:
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling method
                return;

            }
            // Create variable that holds list of found appliances
            List<Appliance> found = new();
            // Loop through Appliances
            foreach( var appliance in Appliances) {
                // Test if current appliance is dishwasher
                if( appliance is Dishwasher ) {
                    // Down cast current Appliance to Dishwasher
                    Dishwasher diswasher = (Dishwasher)appliance;
                    // Test sound rating is "Any" or equals soundrating for current dishwasher
                    if( soundRating == "Any" || diswasher.SoundRating == soundRating) {
                        // Add current appliance in list to found list
                        found.Add(diswasher);
                    }
                }
            }
            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Appliance Types"
            // Write "0 - Any"
            // Write "1 – Refrigerators"
            // Write "2 – Vacuums"
            // Write "3 – Microwaves"
            // Write "4 – Dishwashers"
            // Write "Enter type of appliance:"
            Console.WriteLine("Appliance Types\n0 - Any\n1 – Refrigerators\n2 – Vacuums\n3 – Microwaves\n4 – Dishwashers\nEnter type of appliance:");
            // Get user input as string and assign to appliance type variable
            string applianceTypeInput = Console.ReadLine();
            // Write "Enter number of appliances: "
            Console.WriteLine("Enter number of appliances: ");
            // Get user input as string and assign to variable
            // Convert user input from string to int
            int num = Convert.ToInt16(Console.ReadLine());
            // Create variable to hold list of found appliances
            List<Appliance> found = new();
            // Loop through appliances
            foreach( var appliance in Appliances ) {
                // Test inputted appliance type is "0"
                    // Add current appliance in list to found list
                // Test inputted appliance type is "1"
                    // Test current appliance type is Refrigerator
                        // Add current appliance in list to found list
                // Test inputted appliance type is "2"
                    // Test current appliance type is Vacuum
                        // Add current appliance in list to found list
                // Test inputted appliance type is "3"
                    // Test current appliance type is Microwave
                        // Add current appliance in list to found list
                // Test inputted appliance type is "4"
                    // Test current appliance type is Dishwasher
                        // Add current appliance in list to found list
                bool matchesType =  applianceTypeInput switch {
                    "0" => true,
                    "1" => appliance is Refrigerator,
                    "2" => appliance is Vacuum,
                    "3" => appliance is Microwave,
                    "4" => appliance is Dishwasher,
                    _ => false
                };
                if( matchesType ) {
                    found.Add(appliance);
                }
            }
            // Randomize list of found appliances
            found.Sort(new RandomComparer());
            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, num);
        }
    }
}
