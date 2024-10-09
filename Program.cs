using System;

public class Program
{

    // Gloibal values that can be used for validation
    // Initalised to the size of the screen

    public static int screenX = 200;
    public static int screenY = 200;

    //
    // updatePos()
    // event: the string event to process
    // x and y are passed by reference and are update in the routine

    public static void updatePos(string e, ref int x, ref int y)
    {

        switch (e)
        {
            case "a":
                x = x - 1;
                break;

            // Task 1: 
            // Include other cases to cater for A W S D  and Space for jump
            default:
                // ignore event
                break;
        }

        // Task 2: 
        // Add in validation for x and y not going off the screen size
        // Use screenX and screenY
        Console.WriteLine("Compare [{0}, {1}] to [{2}, {3}]", x, y, screenX, screenY);

    }

    public static void Main()
    {
        Console.WriteLine("Hello to Game World");


        // x and y cordinates
        // local variables, initialised to 0
        int x = 0;
        int y = 0;

        // Task 3: 
        // Test your code!
        // Write a loop which:
        //     Prompt the user to enter a string
        //     Calls updatePos to update the position
        //     Prints out the new x and y cordinates.
        // The loop exits when the user enters, for example, the event "x"

        // Testing with known cases
        updatePos("a", ref x, ref y);
        Console.WriteLine("[{0}, {1}]", x, y);


        // Testing with user input
        Console.Write("Input: ");
        string e = Console.ReadLine();
        updatePos(e, ref x, ref y);
        Console.WriteLine("[{0}, {1}]", x, y);


        // Extention:
        // Task 4: Modify the interface of updatePos () to return the new x and y values
        //         Note: you will have to change the call to and the definition of updatePos()
        // What style of interface is better????
        // Call by reference or mutliple values?

    }
}