public class Solution {
    // Dictionary of all possible entries
    private readonly Dictionary<char, int> dict = new Dictionary<char, int>{{'I',1},{'V',5},{'X',10},{'L',50},{'C',100},{'D',500},{'M',1000}};
    
    public int RomanToInt(string s) {
   
        // splits the string into an array of all the characters
        char[] ch = s.ToCharArray();
        // establish variables
        int result = 0;
        int intVal,nextIntVal;
        // step through each character in the array
        for(int i = 0; i <ch.Length ; i++){
            // sets the current character equal to its value in the dict.
            intVal = dict[ch[i]];
            
            if(i != ch.Length-1)
            {
                // sets the next value equal to its value in the dict
                nextIntVal = dict[ch[i+1]];
                
                // if the next character is higher than the last subtract the current from the next: I is less than V so IV = 4 etc...
                if(nextIntVal>intVal){
                    intVal = nextIntVal-intVal;
                // skips forwad so the number isn't counted twice
                    i = i+1;
                }
            }
            // adds the value to the result
             result = result + intVal;
        }
        return result;
    }
}