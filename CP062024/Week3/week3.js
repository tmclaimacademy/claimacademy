function changeMe() {
    document.getElementById("changedbyjs").innerHTML = "I have been changed by JavaScript";
}

function nuke() {
    document.write("Your web page is obliterated.");
}

function guessWhat() {
    window.alert("Chicken Butt");
}

function consoleDemo() {
    console.log("This is being written to the console");
    console.log("To see this, right-click in the web page, click Inspect, and then click the Console tab.");
}

function add() {
    let a, b, c;
    a = 2;
    b = 3;
    c = a + b;
    window.alert(a + " + " + b + " = " + c);
}