using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using System.Xml;
using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// OOP-2 Using C#
    /// Assignment 1 – Classes and Inheritance
    /// Group 2 - Members:
    /// Barros Horta, Fernando
    /// Obad, Ahmed
    /// Xiang, Hangxi
    /// Scenario: A local company, Modern Appliances, has hired you to implement a system to manage their appliance data more efficiently.They want a system that allows both employees and customers to find, list and purchase appliances. The company has provided you with a data file containing a sample list of appliances.The data file contains four types of appliances: refrigerators, vacuums, microwaves and dishwashers.Each appliance is uniquely identified using an item number, and information about each type of appliance is described in the formatting section.
    /// Assignment working method: Skeleton comments and sections were left mostly unchanged except when necessary to match the expected output as per instructed in the Assignment 1 - Classes and Inheritance.pdf file
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
                    Console.WriteLine($"Appliance \"{itemNumber}\" has been checked out.\n");
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
            Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doos):");
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
            Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
            // Get user input as string
            // Create variable to hold voltage
            int voltage = Convert.ToInt16(Console.ReadLine());
            
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
                    if (voltage == 0 || vacuum.BatteryVoltage == voltage ) {
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
            Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();
            // Create character variable that holds room type
            char roomType ;
            switch(userInput) {
                case "W":
                // Assign 'K' to room type variable
                    roomType = 'W';
                    break;
                // Test input is "2"
                case "K":
                // Assign 'W' to room type variable
                    roomType = 'K';
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
            // Write "Enter sound rating:"
            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();
            // Create variable that holds sound rating
            string soundRating = "";
            switch( userInput ) {
                case "Qt":
                    // Assign "Qt" to sound rating variable
                    soundRating = "Qt";
                    break;
                case "Qr":
                    // Assign "Qr" to sound rating variable
                    soundRating = "Qr";
                    break;
                case "Qu":
                    // Assign "Qu" to sound rating variable
                    soundRating = "Qu";
                    break;
                case "M":
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
            // Write "Enter number of appliances: "
            Console.WriteLine("Enter number of appliances: ");
            // Get user input as string and assign to variable
            // Convert user input from string to int
            int num = Convert.ToInt16(Console.ReadLine());
            // Create variable to hold list of found appliances
            List<Appliance> found = new();
            // Loop through appliances
            foreach( var appliance in Appliances ) {
                found.Add(appliance);                
            }
            // Randomize list of found appliances
            found.Sort(new RandomComparer());
            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, num);
        }
    }
}
