var counter = 1; /*Counter*/

/*Method to Entry the Player Game*/
function PlayerProgram()
{
    var generatedRandom = GenerateRandomNumber(); /*Generate Number*/
    console.log("Playing Game");
    console.log("Guess a combination of 4 digits ranging from 1 to 6");
    var userInput = TakeUserInput(); /*User Input Combination*/
    var output = "";

    do {
        if (userInput.length == 4 && IsDigitsOnly(userInput)) {
            if (generatedRandom && generatedRandom != "" && userInput && userInput != "" && userInput.length == 4 && generatedRandom.length == 4) {
                output = ValidateUserInput(generatedRandom, userInput);
                if (output && output != "") {
                    console.log("Your Result: " + output);
                    console.log("- : Guessed digit is correct but in correct order");
                    console.log("+ : Guessed digit is correct and in correct order");
                    userInput = "E";
                }
                else {
                    console.log("Try once Again or Press E to exit the game");
                    userInput = TakeUserInput();
                }
                IncrementCounter(counter);
            }
        }
        else {
            console.log("Invalid Input. Please try again later or Press E to exit the game");
            userInput = TakeUserInput();
        }

    }
    while (counter < 11 && userInput.toUpperCase() != "E");
    if (counter == 11) {
        console.log("You have Lost");
    }
    if (userInput.toUpperCase() == "E") {
        console.log("Happy Gaming. Have a nice day.");
    }

}

/*Method to Increment the counter*/
function IncrementCounter(value)
{
    counter = value + 1;
}

/*Method to Validate user combination with generated comination*/
function ValidateUserInput(generatedRandom, userInput) {
    var result = ""
    var arrInputDigits = new Array();
    var arrGeneratedDigits = new Array();
    for (let char of generatedRandom) {
        arrGeneratedDigits.push(char);
    }
    for (let char of userInput) {
        arrInputDigits.push(char);
    }
    if (arrInputDigits.length > 0 && arrGeneratedDigits.length > 0) {

        arrInputDigits.forEach(function (item) {
            if (arrGeneratedDigits.indexOf(item) != -1) {
                if (arrGeneratedDigits.indexOf(item) > 0 && arrGeneratedDigits.indexOf(item) != arrInputDigits.indexOf(item))
                    result = result + "-";
                else if (arrGeneratedDigits.indexOf(item) > 0 && arrGeneratedDigits.indexOf(item) == arrInputDigits.indexOf(item))
                    result = result + "+";
            }
            else
                result = "";
        });
    }
    return result;
}

/*Method to Check User input is Digits only*/
function IsDigitsOnly(string)
{
    if (string.match(/^[1-6]+$/) != null)
        return true;
    else
        return false;
}

/*Method to Entry the Player Game*/
function GenerateRandomNumber() {
    var numOrg = Math.floor(1000 + (9999 - 1000) * Math.random());
    var strNumOrg = numOrg.toString();
    if (strNumOrg && strNumOrg != "") {
        strNumOrg = strNumOrg.replace("7", "1");
        strNumOrg = strNumOrg.replace("8", "2");
        strNumOrg = strNumOrg.replace("9", "3");
        strNumOrg = strNumOrg.replace("0", "4");
        return strNumOrg.trim();
    }
    else {
        return strNumOrg;
    }
}

/*Method to Take User Input in a Popup*/
function TakeUserInput() {
    var popupText = prompt("Please enter your combination");
    if (popupText != null) {
        return popupText;
    }
    else
        return "";
}
