// This application is used to take two positive integers from the user,
// add those numbers together, find the least significant digit of that number,
// seperate it from the sum and add it to the new number
// and repeat this until only one digit remains

// Only do twice:{
// accept input from the user-> input should be a positive integer
// validate if the input is a positive int
// if yes add to the total and continue, if no prompt the user for correct input

int count = 0;
var userTotal = 0;
while (count < 2)
{
    // prompts user for positive integer
    Console.WriteLine("Enter a positive integer: ");
    var userInput = Console.ReadLine();

    // checks if input is an integer
    try
    {
        var valid = Int32.Parse(userInput);

        // checks if input is valid
        if (valid > 0)
        {
            userTotal+= valid;
            count++;
        }
        else
        {
            Console.WriteLine("Please enter a POSITIVE integer (greater than 0)");
        }

    }catch(Exception)
    {
        Console.WriteLine("Please enter a positive int!");
    }
    
}

var tempUserTotal = userTotal.ToString();
var leastSig = "a";
var tempTotal = 0;
//LOOP while numLength > 1{
// Copy least sig digit from total and store in a tempVar
 // Remove the least sig digit from total
 // add tempVar to total}
 while(tempUserTotal.Length > 1)
{
    // stores userTotal as string
    tempUserTotal = userTotal.ToString();
    // stores leastSig
    leastSig = $"{tempUserTotal[tempUserTotal.Length - 1]}";

    // remove leastSig from number
    tempUserTotal =  tempUserTotal.Substring(0, tempUserTotal.Length - 1);

    // add sig to total
    tempTotal = Int32.Parse(leastSig) + Int32.Parse(tempUserTotal);

    // puts temp total in userTotal
    userTotal = tempTotal;
}


// Display the final digit
Console.WriteLine(userTotal);
