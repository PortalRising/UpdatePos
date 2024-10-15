using System;

public class Program
{

    // Global values that can be used for validation
    // Initalised to the size of the screen

    public static int screenX = 200;
    public static int screenY = 200;

    //
    // UpdatePos()
    // event: the string event to process
    // x and y are passed by reference and are update in the routine

    public static (int, int) UpdatePosVal(char input, int x, int y)
    {
        // Pass the values as reference to UpdatePosRef
        UpdatePosRef(input, ref x,  ref y);

        // Return the new position
        return (x, y);
    }

    public static void UpdatePosRef(char input, ref int x, ref int y)
    {

        switch (input)
        {
            case 's':
                y -= 1;
                break;

            case 'w':
                y += 1;
                break;

            case 'a':
                x -= 1;
                break;

            case 'd':
                x += 1;
                break;

            case ' ':
                x += 1;
                y += 1;
                break;

            // Task 1: 
            // Include other cases to cater for A W S D  and Space for jump
            default:
                // ignore event
                Console.WriteLine("That is not a valid move");
                break;
        }

        // Task 2: 
        // Add in validation for x and y not going off the screen size
        // Use screenX and screenY
        // Console.WriteLine("Compare [{0}, {1}] to [{2}, {3}]", x, y, screenX, screenY);

        // Limit x and y to the border of the screen
        int border_x = Math.Min(x, screenX);
        int border_y = Math.Min(y, screenY);
        
        // Make sure x and y are not negative
        border_x = Math.Max(border_x, 0);
        border_y = Math.Max(border_y, 0);

        // Write a response to the user if they attempted to leave the confines of this world
        if (border_x != x || border_y != y)
        {
            Console.WriteLine("You attempted to leave the confines of this world, please stop");
        }

        // Update x and y to the confined version
        x = border_x;
        y = border_y;
    }

    public static void ReadUserInput(ref char input)
    {
        // Prompt the user for a valid move
        Console.Write("Move: ");

        // Read the move into the char reference
        input = Console.ReadKey().KeyChar;

        // Add a newline so any further console writes are not merged
        Console.WriteLine();
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

        char input = ' ';

        // Check if we are in test mode
        if (Environment.GetCommandLineArgs().Contains("test-mode"))
        {
            // We are in testing mode

            // Test every valid key
            char[] validKeys = { ' ', 'w', 'a', 's', 'd' };

            foreach (char key in validKeys)
            {
                UpdatePosRef(key, ref x, ref y);
                Console.WriteLine("Position [{0}, {1}]", x, y);
            }


            // Testing with user input
            Console.Write("Input: ");

            ReadUserInput(ref input);

            UpdatePosRef(input, ref x, ref y);
            Console.WriteLine("Position [{0}, {1}]", x, y);

            // Testing complete and we do not run the main program so return
            return;
        }

        // We are not in testing mode so run the main program with the user
        // Take in user input
        ReadUserInput(ref input);

        // Loop until the user presses x
        while (input != 'x') {
            // Update user position based on their input
            UpdatePosRef(input, ref x, ref y);

            // Output their new position
            Console.WriteLine("Position: [{0}, {1}]", x, y);

            // Take in user input
            ReadUserInput(ref input);
        }


        // Extention:
        // Task 4: Modify the interface of updatePos () to return the new x and y values
        //         Note: you will have to change the call to and the definition of updatePos()
        // What style of interface is better????
        // Call by reference or mutliple values?
        while (input != 'x')
        {
            // Update user position based on their input
            x,y = UpdatePosVal(input, x, y);

            // Output their new position
            Console.WriteLine("Position: [{0}, {1}]", x, y);

            // Take in user input
            ReadUserInput(ref input);
        }
    }
}