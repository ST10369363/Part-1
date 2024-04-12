using System;
using System.Collections.Generic;

// Defining the Recipe class
class Recipe
{
    // Properties of the Recipe class
    public string Name { get; set; } // Name of the recipe
    public List<Ingredient> Ingredients { get; set; } // List of ingredients
    public List<string> Steps { get; set; } // List of steps for preparation

    // Constructor to initialize lists
    public Recipe()
    {
        Ingredients = new List<Ingredient>(); // Initialize 
        Steps = new List<string>(); // Initialize Steps list
    }

    // Method to display the recipe details
    public void DisplayRecipe()
    {
        Console.WriteLine($"Recipe: {Name}\n");
        // Display the recipe name

        Console.WriteLine("Ingredients:");

        // Display section header for ingredients
        foreach (var ingredient in Ingredients)
        {

            // Display each ingredient with quantity and unit
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }

        Console.WriteLine("\nSteps:"); // Display section header for steps
        for (int i = 0; i < Steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Steps[i]}");
            // Display each step with step number
        }
    }

    // Method to scale the recipe by a factor
    public void ScaleRecipe(double factor)
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity *= factor; // Multiply each ingredient quantity by the scaling factor
        }
    }

    // Method to reset all ingredient quantities to zero
    public void ResetQuantities()
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity = 0; // Resetting quantities to 0
        }
    }
}

// Define the Ingredient class
class Ingredient
{
    // Properties of the Ingredient class
    public string Name { get; set; } // Name 
    public double Quantity { get; set; } // Quantity 
    public string Unit { get; set; } // Unit of measurement 
}

// Main program class
class Program
{
    static void Main()
    {
        while (true)
        {
            Recipe recipe = new Recipe();

            // Create a new recipe object

            Console.Write("Enter recipe name: ");


            // Get the recipe name from user input
            recipe.Name = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter the number of ingredients: ");
                if (int.TryParse(Console.ReadLine(), out int ingredientCount))
                {
                    for (int i = 0; i < ingredientCount; i++)
                    {
                        Ingredient ingredient = new Ingredient(); // Create a new ingredient object

                        Console.Write($"Enter name for ingredient {i + 1}: ");
                        ingredient.Name = Console.ReadLine(); // Get the ingredient name from user input

                        while (true)
                        {
                            Console.Write($"Enter quantity for {ingredient.Name}: ");
                            if (double.TryParse(Console.ReadLine(), out double quantity))
                            {
                                ingredient.Quantity = quantity; // Get the ingredient quantity from user input
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid number for quantity.");
                            }
                        }

                        // Ask for unit of measurement and validate it
                        Console.WriteLine("Enter unit of measurement for the ingredient:");
                        // Display valid unit options
                        Console.WriteLine("Each (ea), Dozen (doz), Pack (pk), Case (cs), Pound (lb), Ounce (oz), Gram (g), Kilogram (kg),");
                        Console.WriteLine("Fluid Ounce (fl oz), Pint (pt), Quart (qt), Gallon (gal), Milliliter (mL), Liter (L)");
                        Console.WriteLine("You can enter units in lowercase or uppercase and the measurement must be entered if full.");
                        Console.WriteLine("Example: Each (ea), not Each o (ea) in full space sensitive.");

                        while (true)
                        {
                            Console.Write($"Enter unit of measurement for {ingredient.Name}: ");
                            string unit = Console.ReadLine().ToLower(); // Convert to lowercase for comparison
                            if (IsUnitValid(unit))
                            {
                                ingredient.Unit = unit; // Set the ingredient unit of measurement
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid unit from the list.");
                            }
                        }

                        recipe.Ingredients.Add(ingredient); // Add the ingredient to the recipe
                    }

                    Console.Write("Enter the number of steps: ");
                    if (int.TryParse(Console.ReadLine(), out int stepCount))
                    {
                        for (int i = 0; i < stepCount; i++)
                        {
                            Console.Write($"Enter step {i + 1}: ");
                            recipe.Steps.Add(Console.ReadLine()); // Add each step to the recipe
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number for steps.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number for ingredient count.");
                }
            }

            recipe.DisplayRecipe(); // Display the entered recipe details

            while (true)
            {
                Console.Write("\nEnter scaling factor (0.5, 2, or 3) or 'reset' to reset quantities: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "reset")
                {
                    recipe.ResetQuantities(); // Reset all ingredient quantities
                }
                else if (double.TryParse(input, out double factor))
                {
                    recipe.ScaleRecipe(factor); // Scale the recipe by the entered factor
                }

                recipe.DisplayRecipe(); // Display the modified recipe
                break;
            }

            Console.WriteLine("\nRecipe data cleared. Do you want to add another recipe? (y/n): ");
            string addAnother = Console.ReadLine().ToLower();

            if (addAnother != "y" && addAnother != "yes")
            {
                break;
            }
        }

        Console.WriteLine("Task ended. Press any key to exit.");
        Console.ReadKey(); // Wait for user input before exiting
    }

    // Method to validate if a unit of measurement is valid
    static bool IsUnitValid(string unit)
    {
        string[] validUnits = { "each (ea)", "dozen (doz)", "pack (pk)", "case (cs)", "pound (lb)", "ounce (oz)", "gram (g)", "kilogram (kg)",
                                "fluid ounce (fl oz)", "pint (pt)", "quart (qt)", "gallon (gal)", "milliliter (ml)", "liter (l)" };
        return Array.Exists(validUnits, u => u.Equals(unit, StringComparison.OrdinalIgnoreCase));
    }
}
